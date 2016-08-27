Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop

Public Class PatentOutlookMerge

    Private dtPatent As DataTable
    Private dtPatentDates As DataTable
    Private dtContacts As DataTable
    Private dr As Data.DataRow
    Private OL As Outlook.Application
    Private Email As Outlook.MailItem
   
    Private strMessage As String
    Private strEmailBody As String
    Private strSubject As String

    '=============================
    Friend JurisdictionDateID As Integer
    Friend IsDateMerge As Boolean
    Friend DocumentName As String
    Friend ContactsFilter As String


    Private Sub OpenRecords()
        On Error Resume Next
        Dim strSQL As String, dReader As OleDb.OleDbDataReader, strClasses As String

        strSQL = SQL.vwPatentMerge & " where PatentID=" & Globals.PatentID
        dtPatent = DataStuff.GetDataTable(strSQL)

        strSQL = SQL.vwPatentContactsMerge & " where PatentID=" & Globals.PatentID & ContactsFilter
        dtContacts = DataStuff.GetDataTable(strSQL)

        strSQL = "SELECT tblPatentDates.PatentDateID, tblPatentDates.PatentID, tblPatentDatesTemplate.DateName, " & _
        "tblPatentDates.PatentDate AS DateValue, tblPatentDates.ListOrder, tblPatentDates.NoDay, tblPatentDates.NoMonth " & _
        "FROM tblPatentDates INNER JOIN tblPatentDatesTemplate ON tblPatentDates.DateID = tblPatentDatesTemplate.DateID " & _
        "where PatentID=" & Globals.PatentID & " order by tblPatentDates.ListOrder"
        dtPatentDates = DataStuff.GetDataTable(strSQL)

        'put all classes in one field
        dtPatent.Columns.Add("PatentClasses", GetType(System.String))
        dReader = DataStuff.GetDataReader("Select * from qvwPatentClasses where PatentID=" & _
            Globals.PatentID & " order by PatentClass")

        strClasses = ""
        While dReader.Read
            strClasses = strClasses & dReader("PatentClass") & ", "
        End While
        strClasses = Left(strClasses, Len(strClasses) - 2)
        dtPatent.Rows(0).Item("PatentClasses") = strClasses

    End Sub

    Private Sub OpenDocument()
        On Error Resume Next
        Dim fs As Object, f As Object
        fs = CreateObject("Scripting.FileSystemObject")
        f = fs.OpenTextFile(DocumentName)
        strMessage = f.ReadAll
    End Sub

    Private Sub LoadPatentJurisDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select EmailMessage, EmailSubjectLine from tblPatentJurisdictionDates where JurisdictionDateID=" & _
            Me.JurisdictionDateID)
        dr.Read()
        strMessage = dr("EmailMessage")
        strSubject = dr("EmailSubjectLine")
        dr.Close()
    End Sub

    Public Sub MergeToDocument()
        On Error Resume Next
        Dim iNumContacts As Integer, iContact As Integer, bContactFields As Boolean, i As Integer, _
            strField As String, strContacts As String

        bContactFields = False
        OpenRecords()

        If IsDateMerge = True Then
            LoadPatentJurisDate()
        Else
            OpenDocument()
        End If

        OL = GetObject(, "Outlook.Application")
        If OL Is Nothing Then
            OL = CreateObject("Outlook.Application")
        End If

        'does email message contain contact fields?
        With dtContacts
            For i = 0 To .Columns.Count - 1
                strField = dtContacts.Columns(i).ColumnName
                If Not (strField Like "*ID") Then
                    strField = "[" & strField & "]"
                    If InStr(strMessage, strField) > 0 Then
                        bContactFields = True
                    End If
                End If
            Next
        End With

        iNumContacts = dtContacts.Rows.Count

        If bContactFields = True Then
            For iContact = 0 To iNumContacts - 1
                If dtContacts.Rows(iContact).Item("Email") & "" <> "" Then
                    'merge the information
                    strEmailBody = strMessage
                    MergeSingle(0, dtPatent)
                    MergeSingle(iContact, dtContacts)
                    MergeDates()

                    Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                    With Email
                        .To = dtContacts.Rows(iContact).Item("ContactEmail")
                        If RevaSettings.EmailHTML = True Then
                            strEmailBody = strEmailBody.Replace(vbCrLf, "<p>")
                            .HTMLBody = strEmailBody
                        Else
                            .Body = strEmailBody
                        End If
                        .Subject = strSubject
                        .Display()
                    End With
                End If
            Next iContact
        End If

        'if there are no contact fields, merge all into a single email
        If bContactFields = False Then
            strContacts = ""
            For iContact = 0 To iNumContacts - 1
                If dtContacts.Rows(iContact).Item("Email") & "" <> "" Then
                    strContacts = strContacts & dtContacts.Rows(iContact).Item("ContactEmail") & ";"
                End If
            Next iContact

            'merge the information
            strEmailBody = strMessage
            MergeSingle(0, dtPatent)
            MergeDates()

            Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
            With Email
                .To = strContacts
                If RevaSettings.EmailHTML = True Then
                    strEmailBody = strEmailBody.Replace(vbCrLf, "<p>")
                    .HTMLBody = strEmailBody
                Else
                    .Body = strEmailBody
                End If
                .Subject = strSubject
                .Display()
            End With
        End If

        OL = Nothing

    End Sub

    Private Sub MergeSingle(ByVal iRow As Integer, ByVal DT As DataTable)
        On Error Resume Next
        Dim iNumCols As Integer, iCol As Integer, strField As String, strValue As String
        dr = DT.Rows(iRow)

        iNumCols = DT.Columns.Count
        For iCol = 0 To (iNumCols - 1)
            strField = "[" & DT.Columns(iCol).ColumnName & "]"
            strValue = dr(iCol).ToString & ""
            strEmailBody = Replace(strEmailBody, strField, strValue)
            strSubject = Replace(strSubject, strField, strValue)
        Next iCol
    End Sub

    Private Sub MergeDates()
        On Error Resume Next
        Dim strField As String, strValue As String, iRows As Integer, dRow As DataRow, _
            bUSADates As Boolean, bSpellMonth As Boolean

        bUSADates = RevaSettings.USADates
        bSpellMonth = RevaSettings.SpellMonthMerge

        iRows = dtPatentDates.Rows.Count
        For iRows = 0 To (iRows - 1)
            dRow = dtPatentDates.Rows(iRows)
            strField = "[" & dRow("DateName") & "]"
            strField = Replace(strField, " ", "")
            strField = Replace(strField, "'", "")
            If bUSADates = True Then
                If bSpellMonth = True Then
                    strValue = Format(dRow("DateValue"), "MMMM dd, yyyy")
                Else
                    strValue = Format(dRow("DateValue"), "MMM dd, yyyy")
                End If
            Else
                If bSpellMonth = True Then
                    strValue = Format(dRow("DateValue"), "dd MMMM, yyyy")
                Else
                    strValue = Format(dRow("DateValue"), "dd MMM yyyy")
                End If
            End If
            'one last possibility ... no day in the date
            If Nz(dRow("NoDay"), False) = True Then
                If bSpellMonth = True Then
                    strValue = Format(dRow("DateValue"), "MMMM yyyy")
                Else
                    strValue = Format(dRow("DateValue"), "MMM yyyy")
                End If
            End If

            ' one last-last possibility ... no month, no day
            If Nz(dRow("NoMonth"), False) = True Then
                strValue = Format(dRow("DateValue"), "yyyy")
            End If

            strEmailBody = Replace(strEmailBody, strField, strValue)
        Next iRows
    End Sub


End Class
