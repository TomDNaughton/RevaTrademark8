Imports Microsoft.Office.Interop

Public Class MarkMerge

    Private dtTrademark As DataTable
    Private dtTrademarkDates As DataTable
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

        strSQL = SQL.vwTrademarkMerge & " where TrademarkID=" & Globals.TrademarkID
        dtTrademark = DataStuff.GetDataTable(strSQL)

        strSQL = SQL.vwTrademarkContactsMerge & " where TrademarkID=" & Globals.TrademarkID & ContactsFilter
        dtContacts = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblTrademarkDates where TrademarkID=" & Globals.TrademarkID & " order by ListOrder"
        dtTrademarkDates = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblDatesTemplate order by ListOrder"
        dtDatesTemplate = DataStuff.GetDataTable(strSQL)

        'put all classes in one field
        dtTrademark.Columns.Add("RegistrationClasses", GetType(System.String))
        dReader = DataStuff.GetDataReader("Select * from qvwTrademarkClasses where TrademarkID=" & _
            Globals.TrademarkID & " order by RegClass")

        strClasses = ""
        While dReader.Read
            strClasses = strClasses & dReader("RegClass") & ", "
        End While
        strClasses = Left(strClasses, Len(strClasses) - 2)
        dtTrademark.Rows(0).Item("RegistrationClasses") = strClasses

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
            DateID As Integer, TrademarkDate As Date, strTrademarkDate As String

        Dim dRow As DataRow
        Dim strColumnName As String

        If dtContacts.Rows.Count < 1 Then
            iRows = 1 'just the trademark
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

        For i = 0 To dtTrademark.Columns.Count - 1
            'trademark fields
            strColumnName = dtTrademark.Columns(i).ColumnName
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


            'add trademark fields and data ... only one mark, so it's row zero.
            dRow = dtTrademark.Rows(0)
            For i = 0 To dtTrademark.Columns.Count - 1
                strColumnName = dtTrademark.Columns(i).ColumnName
                If Not (strColumnName Like "*ID") Then
                    strData = strData & dRow.Item(i).ToString().Replace(vbCrLf, " ") & vbTab
                End If
            Next

            ' strData = strData.Replace(vbCrLf, " ")


            'now we have to pivot in the date information
            For j = 0 To dtDatesTemplate.Rows.Count - 1
                DateID = dtDatesTemplate.Rows(j).Item("DateID")
                strTrademarkDate = ""

                'scroll through all dates, look for match
                For i = 0 To dtTrademarkDates.Rows.Count - 1
                    dRow = dtTrademarkDates.Rows(i)
                    If IsDate(dRow("TrademarkDate")) And (dRow("DateID") = DateID) Then
                        TrademarkDate = dRow("TrademarkDate")
                        If RevaSettings.USADates = True Then
                            If RevaSettings.SpellMonthMerge = True Then
                                strTrademarkDate = Format(TrademarkDate, "MMMM dd, yyyy")
                            Else
                                strTrademarkDate = Format(TrademarkDate, "MMM dd, yyyy")
                            End If
                        Else
                            If RevaSettings.SpellMonthMerge = True Then
                                strTrademarkDate = Format(TrademarkDate, "dd MMMM yyyy")
                            Else
                                strTrademarkDate = Format(TrademarkDate, "dd MMM yyyy")
                            End If
                        End If
                    End If
                Next i
                strData = strData & strTrademarkDate & vbTab
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
        'WordDoc = WordApp.Documents(DocumentName)
        WordDoc.MailMerge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters
        WordDoc.MailMerge.OpenDataSource(Application.StartupPath & "\MergeData.txt")
        WordDoc.MailMerge.EditMainDocument()
        WordDoc.MailMerge.SuppressBlankLines = True

    End Sub


End Class
