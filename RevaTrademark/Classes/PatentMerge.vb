Imports Microsoft.Office.Interop

Public Class PatentMerge

    Private dtPatent As DataTable
    Private dtPatentDates As DataTable
    Private dtDatesTemplate As DataTable
    Private dtContacts As DataTable
    Private dr As Data.DataRow
    Private WordApp As Word.Application
    Private WordDoc As Word.Document

    '=============================
    Friend DocumentName As String
    Friend ContactsFilter As String

    Private Sub OpenRecords()
        On Error Resume Next
        Dim strSQL As String, dReader As OleDb.OleDbDataReader, strClasses As String

        strSQL = SQL.vwPatentMerge & " where PatentID=" & Globals.PatentID
        dtPatent = DataStuff.GetDataTable(strSQL)

        strSQL = SQL.vwPatentContactsMerge & " where PatentID=" & Globals.PatentID & ContactsFilter
        dtContacts = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblPatentDates where PatentID=" & Globals.PatentID & " order by ListOrder"
        dtPatentDates = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblPatentDatesTemplate order by ListOrder"
        dtDatesTemplate = DataStuff.GetDataTable(strSQL)

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

    Friend Sub WriteDataFile()
        On Error Resume Next
        Dim strFullPath As String, strData As String

        'Set the name of the file we'll create
        strFullPath = Application.StartupPath & "\MergeData.txt"
        strData = ""
        OpenRecords()

        'now loopy-loop through the records.  Tab delimited, paragraph mark to end records
        Dim iRows As Integer, i As Integer, j As Integer, k As Integer, _
            DateID As Integer, PatentDate As Date, strPatentDate As String

        Dim dRow As DataRow
        Dim strColumnName As String

        If dtContacts.Rows.Count < 1 Then
            iRows = 1 'just the Patent
        Else
            iRows = dtContacts.Rows.Count 'one row for each selected contact
        End If

        '======================== create the header row names =================
        For i = 0 To dtContacts.Columns.Count - 1
            'contact fields
            strColumnName = dtContacts.Columns(i).ColumnName
            If Not (strColumnName Like "*ID") Then
                strData = strData & strColumnName & vbTab
            End If
        Next

        For i = 0 To dtPatent.Columns.Count - 1
            'Patent fields
            strColumnName = dtPatent.Columns(i).ColumnName
            If Not (strColumnName Like "*ID") Then
                strData = strData & strColumnName & vbTab
            End If
        Next

        For i = 0 To dtDatesTemplate.Rows.Count - 1
            'pivot in the date fields
            dRow = dtDatesTemplate.Rows(i)
            strColumnName = dRow("DateName")
            strData = strData & strColumnName & vbTab
        Next
        'that's the end, so mark end of record
        strData = strData & vbCrLf

        '====================== loop in the actual data =====================
        For k = 0 To iRows - 1
            'add contact data, if there is any
            If dtContacts.Rows.Count > 0 Then
                dRow = dtContacts.Rows(k)
                For i = 0 To dtContacts.Columns.Count - 1
                    strColumnName = dtContacts.Columns(i).ColumnName
                    If Not (strColumnName Like "*ID") Then
                        strData = strData & dRow.Item(i) & vbTab
                    End If
                Next
            Else
                'no contact info, so just fill the spaces
                For i = 0 To dtContacts.Columns.Count - 1
                    strColumnName = dtContacts.Columns(i).ColumnName
                    If Not (strColumnName Like "*ID") Then
                        strData = strData & vbTab
                    End If
                Next
            End If


            'add Patent fields and data ... only one mark, so it's row zero.
            dRow = dtPatent.Rows(0)
            For i = 0 To dtPatent.Columns.Count - 1
                strColumnName = dtPatent.Columns(i).ColumnName
                If Not (strColumnName Like "*ID") Then
                    strData = strData & dRow.Item(i) & vbTab
                End If
            Next

            'now we have to pivot in the date information
            For j = 0 To dtDatesTemplate.Rows.Count - 1
                DateID = dtDatesTemplate.Rows(j).Item("DateID")
                strPatentDate = ""

                'scroll through all dates, look for match
                For i = 0 To dtPatentDates.Rows.Count - 1
                    dRow = dtPatentDates.Rows(i)
                    If IsDate(dRow("PatentDate")) And (dRow("DateID") = DateID) Then
                        PatentDate = dRow("PatentDate")
                        If RevaSettings.USADates = True Then
                            If RevaSettings.SpellMonthMerge = True Then
                                strPatentDate = Format(PatentDate, "MMMM dd, yyyy")
                            Else
                                strPatentDate = Format(PatentDate, "MMM dd, yyyy")
                            End If
                        Else
                            If RevaSettings.SpellMonthMerge = True Then
                                strPatentDate = Format(PatentDate, "dd MMMM yyyy")
                            Else
                                strPatentDate = Format(PatentDate, "dd MMM yyyy")
                            End If
                        End If
                    End If
                Next i
                strData = strData & strPatentDate & vbTab
            Next j
            'end of record
            strData = strData & vbCrLf
        Next k


        Dim objStreamWriter As System.IO.StreamWriter
        objStreamWriter = New System.IO.StreamWriter(strFullPath)
        objStreamWriter.Write(strData)
        objStreamWriter.Close()

    End Sub

    Friend Sub CreateNewDocument()
        On Error Resume Next
        WordApp = GetObject(, "Word.Application")
        If WordApp Is Nothing Then
            WordApp = CreateObject("Word.Application")
        End If

        WordDoc = WordApp.Documents.Add
        WordApp.Visible = True
        WordDoc.MailMerge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters
        WordDoc.MailMerge.OpenDataSource(Application.StartupPath & "\MergeData.txt")
        WordDoc.MailMerge.EditMainDocument()
        WordDoc.MailMerge.SuppressBlankLines = True
        WordDoc.SaveAs(DocumentName)

    End Sub

    Friend Sub OpenExistingDocument()
        On Error Resume Next
        WordApp = GetObject(, "Word.Application")
        If WordApp Is Nothing Then
            WordApp = CreateObject("Word.Application")
        End If
        WordApp.Visible = True
        WordDoc = WordApp.Documents.Open(FileName:=DocumentName)
        WordDoc.MailMerge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters
        WordDoc.MailMerge.OpenDataSource(Application.StartupPath & "\MergeData.txt")
        WordDoc.MailMerge.EditMainDocument()
        WordDoc.MailMerge.SuppressBlankLines = True

    End Sub

End Class
