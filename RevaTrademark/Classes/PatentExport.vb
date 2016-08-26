Public Class PatentExport

    Private dtPatents As DataTable
    Private dtPatentDates As DataTable
    Private dtPatentClasses As DataTable
    Private dtPatentContacts As DataTable
    Private strSQL As String
    Private grdFields As Janus.Windows.GridEX.GridEX


    Public Sub GetMergeRecords()
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        grdFields = AllForms.frmReports.grdPatentFields

        'field types:  1 = field, 2 = graphic, 3 = Date, 4 = Classes placeholder
        strSQL = "Select * from vwReportPatentsList" & AllForms.frmReports.GetPatentsToPrint & " order by "
        For i = 0 To grdFields.RowCount - 1
            GRow = grdFields.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If (GRow.Cells("FieldType").Value = 1) And (GRow.Cells("Selected").Value = True) Then
                    strSQL = strSQL & GRow.Cells("FieldName").Value & ", "
                End If
            End If
        Next
        strSQL = strSQL & "PatentID"

        'we should now have a select statement that gets the records in user's preferred order
        dtPatents = DataStuff.GetDataTable(strSQL)

        'this one should in theory pull latest date, per customer request
        strSQL = "SELECT DISTINCT tblPatentDates.PatentID, tblPatentDates.DateID, " & _
        "Max(tblPatentDates.PatentDate) as PatentDate FROM (tblPatentDates)" & _
         AllForms.frmReports.GetPatentsToPrint() & _
        "GROUP BY tblPatentDates.PatentID, tblPatentDates.DateID"

        dtPatentDates = DataStuff.GetDataTable(strSQL)

        'get the classes too
        strSQL = "Select * from vwPatentClasses" & AllForms.frmReports.GetPatentsToPrint() & _
        " order by PatentID, PatentClass"
        dtPatentClasses = DataStuff.GetDataTable(strSQL)

        'get the Contacts
        strSQL = "Select PatentID, ContactName, PositionName from vwReportPatentContacts" & _
            AllForms.frmReports.GetPatentsToPrint() & " order by PatentID, ContactName"
        dtPatentContacts = DataStuff.GetDataTable(strSQL)



    End Sub

    Friend Sub CreateWordTable()
        On Error Resume Next
        '========= WHOLE NEW APPROACH ===============
        Dim WordDoc As Word.Document
        Dim WordApp As Word.Application
        Dim tbl As Word.Table
        Dim rng As Word.Range

        Dim dRow As DataRow
        'Dim dDateRow As DataRow
        Dim iRows As Integer, iCurrentRow As Integer
        Dim iCols As Integer, iCurrentCol As Integer
        Dim i As Integer, j As Integer, k As Integer

        Dim strCriteria As String
        Dim iPatentID As String
        Dim strGraphic As String
        Dim strColumnName As String
        Dim PatentDate As Date
        Dim strPatentDate As String
        Dim strClasses As String
        Dim strContacts As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        ' the () makes it a collection of rows
        Dim DateRow() As DataRow
        Dim ClassRow() As DataRow
        Dim ContactRow() As DataRow

        'we need one row for each record, plus one for the header row
        iRows = dtPatents.Rows.Count + 1
        iCols = 0
        grdFields = AllForms.frmReports.grdPatentFields

        'find out how many columns we need in the table, one for each selected field name
        For i = 0 To grdFields.RowCount - 1
            GRow = grdFields.GetRow(i)
            If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
                And (GRow.Cells("Selected").Value = True) Then
                iCols = iCols + 1
            End If
        Next

        'If Word is running, use existing instance; otherwise, create instance
        If WordApp Is Nothing Then
            WordApp = CreateObject("Word.Application")
        Else
            WordApp = GetObject(, "Word.Application")
        End If

        WordDoc = WordApp.Documents.Add
        'Set rng = WordDoc.Range
        WordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape

        WordApp.Visible = True
        WordApp.Activate()

        WordApp.Selection.TypeParagraph()
        WordApp.Selection.TypeParagraph()
        WordApp.Selection.TypeParagraph()
        WordDoc.Characters.Last.Select()

        tbl = WordDoc.Tables.Add(WordApp.Selection.Range, iRows, iCols)

        With tbl
            iCurrentRow = 1
            iCurrentCol = 1

            'copy field display name into first row of the table
            For i = 0 To grdFields.RowCount - 1
                GRow = grdFields.GetRow(i)
                If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
                    And (GRow.Cells("Selected").Value = True) Then
                    .Cell(1, iCurrentCol).Range.Text = GRow.Cells("DisplayName").Text
                    iCurrentCol = iCurrentCol + 1
                End If
            Next

            'first table row for data is row 2
            iCurrentRow = 2

            'now we can loop through the records
            For j = 0 To dtPatents.Rows.Count - 1

                'reset to column 1 in table for each record
                iCurrentCol = 1
                dRow = dtPatents.Rows(j)
                iPatentID = dRow("PatentID")

                'get dates, classes, contacts based on PatentID, put in row collections
                DateRow = dtPatentDates.Select("PatentID=" & iPatentID)
                ClassRow = dtPatentClasses.Select("PatentID=" & iPatentID)
                ContactRow = dtPatentContacts.Select("PatentID=" & iPatentID)

                'now loop through our selected fields again and fill appropriate data
                For i = 0 To grdFields.RowCount - 1

                    GRow = grdFields.GetRow(i)
                    If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
                        And (GRow.Cells("Selected").Value = True) Then

                        strColumnName = GRow.Cells("FieldName").Text

                        'Patent fields, just pluck matching column from current Patent row
                        If GRow.Cells("FieldType").Value = 1 Then
                            .Cell(iCurrentRow, iCurrentCol).Range.Text = dRow(strColumnName)
                        End If

                        'graphic, so we have to insert it from the path
                        If GRow.Cells("FieldType").Value = 2 Then
                            strGraphic = dRow("GraphicPath") & ""
                            If (Len(strGraphic) > 2) And (System.IO.File.Exists(strGraphic)) Then
                                .Cell(iCurrentRow, iCurrentCol).Select()
                                rng = .Cell(iCurrentRow, iCurrentCol).Range
                                rng.InlineShapes.AddPicture(FileName:=strGraphic, LinkToFile:=False, SaveWithDocument:=True)
                            End If
                        End If

                        'Date fields, trickier, have to match on Date ID
                        If GRow.Cells("FieldType").Value = 3 Then
                            For k = 0 To DateRow.Length - 1
                                If DateRow(k).Item("DateID") = GRow.Cells("DateID").Value Then
                                    PatentDate = DateRow(k).Item("PatentDate")
                                    'now format it for region preference
                                    If (IsDate(PatentDate)) And (PatentDate <> Date.MinValue) Then
                                        If My.Settings.USADates = True Then
                                            If My.Settings.SpellMonthMerge = True Then
                                                strPatentDate = Format(PatentDate, "MMMM dd, yyyy")
                                            Else
                                                strPatentDate = Format(PatentDate, "MMM dd, yyyy")
                                            End If
                                        Else
                                            If My.Settings.SpellMonthMerge = True Then
                                                strPatentDate = Format(PatentDate, "dd MMMM yyyy")
                                            Else
                                                strPatentDate = Format(PatentDate, "dd MMM yyyy")
                                            End If
                                        End If
                                        .Cell(iCurrentRow, iCurrentCol).Range.Text = strPatentDate
                                    End If
                                End If
                            Next k
                        End If

                        'classes, so have to build a string
                        If GRow.Cells("FieldType").Value = 4 Then
                            strClasses = ""
                            For k = 0 To ClassRow.Length - 1
                                strClasses = strClasses & ClassRow(k).Item("PatentClass") & ", "
                            Next
                            'trim last comma and space
                            If Len(strClasses) > 2 Then
                                strClasses = Left(strClasses, Len(strClasses) - 2)
                                .Cell(iCurrentRow, iCurrentCol).Range.Text = strClasses
                            End If
                        End If

                        'Contacts, have to match and build a string
                        If GRow.Cells("FieldType").Value = 5 Then
                            strContacts = ""
                            For k = 0 To ContactRow.Length - 1
                                If GRow.Cells("DisplayName").Text = ContactRow(k).Item("PositionName") Then
                                    strContacts = strContacts & ContactRow(k).Item("ContactName") & "; "
                                End If
                            Next
                            If Len(strContacts) > 2 Then
                                'trim last semicolon and space
                                strContacts = Left(strContacts, Len(strContacts) - 2)
                                .Cell(iCurrentRow, iCurrentCol).Range.Text = strContacts
                            End If
                        End If

                        iCurrentCol = iCurrentCol + 1
                    End If
                Next i

                'go to next row in table for next Patent record
                iCurrentRow = iCurrentRow + 1
            Next j

        End With

        WordApp = Nothing
        WordDoc = Nothing
        tbl = Nothing
        rng = Nothing

    End Sub

    Friend Sub CreateSpreadsheet()
        On Error Resume Next

        Dim XL As Excel.Application
        Dim XLBook As Excel.Workbook
        Dim XLSheet As Excel.Worksheet

        Dim iCurrentRow As Integer, iCurrentCol As Integer
        Dim i As Integer, j As Integer, k As Integer

        Dim dRow As DataRow
        Dim strColumnName As String
        Dim PatentDate As Date

        Dim strCriteria As String
        Dim iPatentID As String
        Dim strClasses As String
        Dim strContacts As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        ' the () makes it a collection of rows
        Dim DateRow() As DataRow
        Dim ClassRow() As DataRow
        Dim ContactRow() As DataRow
        grdFields = AllForms.frmReports.grdPatentFields

        If XL Is Nothing Then
            XL = CreateObject("Excel.Application")
        Else
            XL = GetObject(, "Excel.Application")
        End If

        XLBook = XL.Workbooks.Add
        XLSheet = XLBook.ActiveSheet

        XL.Visible = True

        With XLSheet

            iCurrentRow = 1
            iCurrentCol = 1

            'copy field display name into first row of the sheet
            For i = 0 To grdFields.RowCount - 1
                GRow = grdFields.GetRow(i)
                If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
                    And (GRow.Cells("Selected").Value = True) And (GRow.Cells("FieldType").Value <> 2) Then
                    .Cells(1, iCurrentCol).Value = GRow.Cells("DisplayName").Text
                    iCurrentCol = iCurrentCol + 1
                End If
            Next

            iCurrentRow = 2

            'now we can loop through the records
            For j = 0 To dtPatents.Rows.Count - 1

                'reset to column 1 in sheet for each record
                iCurrentCol = 1
                dRow = dtPatents.Rows(j)
                iPatentID = dRow("PatentID")

                'get dates and classes based on PatentID, put in row collections
                DateRow = dtPatentDates.Select("PatentID=" & iPatentID)
                ClassRow = dtPatentClasses.Select("PatentID=" & iPatentID)
                ContactRow = dtPatentContacts.Select("PatentID=" & iPatentID)

                'now loop through our selected fields again and fill appropriate data
                For i = 0 To grdFields.RowCount - 1

                    GRow = grdFields.GetRow(i)
                    If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
                        And (GRow.Cells("Selected").Value = True) Then

                        strColumnName = GRow.Cells("FieldName").Text

                        'Patent fields, just pluck matching column from current Patent row
                        If GRow.Cells("FieldType").Value = 1 Then
                            .Cells(iCurrentRow, iCurrentCol).Value = dRow(strColumnName)
                        End If

                        'Date fields, trickier, have to match on Date ID
                        If GRow.Cells("FieldType").Value = 3 Then
                            For k = 0 To DateRow.Length - 1
                                If DateRow(k).Item("DateID") = GRow.Cells("DateID").Value Then
                                    PatentDate = DateRow(k).Item("PatentDate")
                                    'now format it for region preference
                                    If (IsDate(PatentDate)) And (PatentDate <> Date.MinValue) Then
                                        .Cells(iCurrentRow, iCurrentCol).Value = PatentDate
                                        If My.Settings.USADates = True Then
                                            If My.Settings.SpellMonthMerge = True Then
                                                .Cells(iCurrentRow, iCurrentCol).NumberFormat = "MMMM dd, yyyy"
                                            Else
                                                .Cells(iCurrentRow, iCurrentCol).NumberFormat = "MMM dd, yyyy"
                                            End If
                                        Else
                                            If My.Settings.SpellMonthMerge = True Then
                                                .Cells(iCurrentRow, iCurrentCol).NumberFormat = "dd MMMM yyyy"
                                            Else
                                                .Cells(iCurrentRow, iCurrentCol).NumberFormat = "dd MMM yyyy"
                                            End If
                                        End If
                                    End If
                                End If
                            Next k
                        End If

                        'classes, so have to build a string
                        If GRow.Cells("FieldType").Value = 4 Then
                            strClasses = ""
                            For k = 0 To ClassRow.Length - 1
                                strClasses = strClasses & ClassRow(k).Item("PatentClass") & ", "
                            Next
                            If Len(strClasses) > 2 Then
                                'trim last comma and space
                                strClasses = Left(strClasses, Len(strClasses) - 2)
                                .Cells(iCurrentRow, iCurrentCol).Value = strClasses
                            End If
                        End If

                        'Contacts, have to match and build a string
                        If GRow.Cells("FieldType").Value = 5 Then
                            strContacts = ""
                            For k = 0 To ContactRow.Length - 1
                                If GRow.Cells("DisplayName").Text = ContactRow(k).Item("PositionName") Then
                                    strContacts = strContacts & ContactRow(k).Item("ContactName") & "; "
                                End If
                            Next
                            If Len(strContacts) > 2 Then
                                'trim last semicolon and space
                                strContacts = Left(strContacts, Len(strContacts) - 2)
                                .Cells(iCurrentRow, iCurrentCol).Value = strContacts
                            End If
                        End If

                        'don't move on graphic becuz we don't do it
                        If GRow.Cells("FieldType").Value <> 2 Then
                            iCurrentCol = iCurrentCol + 1
                        End If

                    End If
                Next i

                'go to next row in table for next Patent record
                iCurrentRow = iCurrentRow + 1
            Next j

        End With

        XL = Nothing
        XLBook = Nothing
        XLSheet = Nothing
    End Sub


End Class
