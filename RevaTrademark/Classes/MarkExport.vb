Public Class MarkExport

    Private dtTrademarks As DataTable
    Private dtTrademarkDates As DataTable
    Private dtTrademarkClasses As DataTable
    Private dtTrademarkContacts As DataTable
    Private dtExportTable As DataTable
    Friend ExportTable As DataTable  'this is the one we expose publicly
    Private strSQL As String
    Private grdFields As Janus.Windows.GridEX.GridEX



    Friend Sub GetExportTable(ByVal IncludeGraphic As Boolean)
        On Error Resume Next
        Dim i As Integer, j As Integer, k As Integer
        Dim iFieldType As Integer
        Dim iTrademarkID As Integer
        Dim strColumnName As String
        Dim strValue As String
        Dim iDateID As Integer
        Dim TrademarkDate As Date
        Dim strTrademarkDate As String
        Dim strClasses As String
        Dim strContacts As String
        Dim strSort As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow
        Dim DRow As DataRow
        Dim GridRows As DataRow()

        ' the () makes it a collection of rows
        Dim DateRow() As DataRow
        Dim ClassRow() As DataRow
        Dim ContactRow() As DataRow
        grdFields = AllForms.frmReports.grdMarkFields

        'field types:  1 = field, 2 = graphic, 3 = Date, 4 = Classes placeholder

        'first create the table with placeholders for dates, classes and contacts
        strSQL = "Select "
        For i = 0 To grdFields.RowCount - 1
            GRow = grdFields.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If (GRow.Cells("Selected").Value = True) Then
                    iFieldType = GRow.Cells("FieldType").Value
                    Select Case iFieldType
                        Case 1
                            strSQL = strSQL & GRow.Cells("FieldName").Text & ", "
                        Case 2
                            If IncludeGraphic = True Then
                                strSQL = strSQL & "GraphicPath as [Graphic], "
                            End If
                        Case 3
                            strSQL = strSQL & "'xygDate:" & GRow.Cells("DateID").Text & "'" & _
                                " as [" & GRow.Cells("DisplayName").Text & "], "
                        Case 4
                            strSQL = strSQL & "'xygCLASSES' as [" & GRow.Cells("DisplayName").Text & "], "
                        Case 5
                            strSQL = strSQL & "'xygCONTACT' as [" & GRow.Cells("DisplayName").Text & "], "
                    End Select
                End If
            End If
        Next
        strSQL = strSQL & "TrademarkID"
        strSQL = strSQL & " from vwReportTrademarksList" & AllForms.frmReports.GetTrademarksToPrint


        'we should now have a select statement that gets the records in user's preferred order
        dtExportTable = DataStuff.GetDataTable(strSQL)

        ' rename fields for the trademark stuff
        For i = 0 To grdFields.RowCount - 1
            GRow = grdFields.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If (GRow.Cells("Selected").Value = True) Then
                    iFieldType = GRow.Cells("FieldType").Value
                    strColumnName = GRow.Cells("FieldName").Text
                    If iFieldType = 1 Then
                        dtExportTable.Columns(strColumnName).ColumnName = GRow.Cells("DisplayName").Text
                    End If
                End If
            End If
        Next

        'this one should in theory pull latest date, per customer request
        strSQL = "SELECT DISTINCT tblTrademarkDates.TrademarkID, tblTrademarkDates.DateID, " & _
        "Max(tblTrademarkDates.TrademarkDate) as TrademarkDate FROM (tblTrademarkDates)" & _
         AllForms.frmReports.GetTrademarksToPrint() & _
        "GROUP BY tblTrademarkDates.TrademarkID, tblTrademarkDates.DateID"

        dtTrademarkDates = DataStuff.GetDataTable(strSQL)

        'get the classes too
        strSQL = "Select * from vwTrademarkRegClasses" & AllForms.frmReports.GetTrademarksToPrint() & _
        " order by TrademarkID, RegClass"
        dtTrademarkClasses = DataStuff.GetDataTable(strSQL)

        'get the Contacts
        strSQL = "Select TrademarkID, ContactName, PositionName from vwReportTrademarkContacts" & _
            AllForms.frmReports.GetTrademarksToPrint() & " order by TrademarkID, ContactName"
        dtTrademarkContacts = DataStuff.GetDataTable(strSQL)


        '======================= The Big Loop To Populate Dates, Classes, Contacts ==================
        'now we can loop through the records ... i = Table Row, j = table column, k = data loop
        For i = 0 To dtExportTable.Rows.Count - 1

            DRow = dtExportTable.Rows(i)
            iTrademarkID = DRow("TrademarkID")

            'get dates, classes, contacts based on TrademarkID, put in row collections
            DateRow = dtTrademarkDates.Select("TrademarkID=" & iTrademarkID)
            ClassRow = dtTrademarkClasses.Select("TrademarkID=" & iTrademarkID)
            ContactRow = dtTrademarkContacts.Select("TrademarkID=" & iTrademarkID)

            For j = 0 To dtExportTable.Columns.Count - 2
                strColumnName = dtExportTable.Columns(j).ColumnName
                strValue = Convert.ToString(DRow(j)) 'pluck value from column

                'it's a date
                If strValue Like "xygDate*" Then

                    strTrademarkDate = ""
                    iDateID = Convert.ToInt32(Replace(strValue, "xygDate:", ""))

                    For k = 0 To DateRow.Length - 1
                        If DateRow(k).Item("DateID") = iDateID Then
                            'we need this format now so the date will sort correctly later
                            If IsDate(DateRow(k).Item("TrademarkDate")) Then
                                TrademarkDate = DateRow(k).Item("TrademarkDate")
                                strTrademarkDate = Format(TrademarkDate, "yyyy/MM/dd")
                            Else
                                strTrademarkDate = ""
                            End If
                        End If ' if the dates match
                    Next k
                    DRow(j) = strTrademarkDate
                    ''make sure we really have a date
                    'If IsDate(strTrademarkDate) Then
                    '    DRow(j) = strTrademarkDate
                    'Else
                    '    DRow(j) = ""
                    'End If
                End If  'if it's a date

                ' it's classes
                strClasses = ""
                If strValue = "xygCLASSES" Then
                    For k = 0 To ClassRow.Length - 1
                        strClasses = strClasses & ClassRow(k).Item("RegClass") & ", "
                    Next
                    If Len(strClasses) > 5 Then
                        'trim last comma and space
                        strClasses = Left(strClasses, Len(strClasses) - 2)
                        DRow(j) = strClasses
                    Else
                        DRow(j) = ""
                    End If
                End If

                'it's a contact
                If strValue = "xygCONTACT" Then
                    strContacts = ""
                    For k = 0 To ContactRow.Length - 1
                        If dtExportTable.Columns(j).ColumnName = ContactRow(k).Item("PositionName") Then
                            strContacts = strContacts & ContactRow(k).Item("ContactName") & "; "
                        End If
                    Next
                    If Len(strContacts) > 5 Then
                        'trim last semicolon and space
                        strContacts = Left(strContacts, Len(strContacts) - 2)
                        DRow(j) = strContacts
                    Else
                        DRow(j) = ""
                    End If

                End If

            Next j  'next column in the row

        Next i 'next row in the table

        '===============================================================================================
        'now we loop through our fields again to pick up the sort order
        GridRows = AllForms.frmReports.rsMarkExportFields.Table.Select("Selected<>0 and SortOrder>0", "SortOrder")
        strSort = ""
        For i = 0 To GridRows.Length - 1
            If GridRows(i).Item("SortOrder") < 4 Then
                strSort = strSort & "[" & GridRows(i).Item("DisplayName") & "], "
            End If
        Next

        strSort = strSort & "TrademarkID"
        dtExportTable.DefaultView.Sort = strSort
        '================================================================================================
        'Create public table
        ExportTable = dtExportTable.DefaultView.ToTable

        'now that we've sorted, we can finally convert dates to strings to fit user's preferred format
        For i = 0 To ExportTable.Rows.Count - 1
            DRow = ExportTable.Rows(i)
            For j = 0 To ExportTable.Columns.Count - 1
                If IsDate(DRow.Item(j)) Then
                    TrademarkDate = DRow.Item(j)
                    If My.Settings.USADates = True Then
                        If My.Settings.SpellMonthMerge = True Then
                            strTrademarkDate = Format(TrademarkDate, "MMMM dd, yyyy")
                        Else
                            strTrademarkDate = Format(TrademarkDate, "MMM dd, yyyy")
                        End If
                    Else
                        If My.Settings.SpellMonthMerge = True Then
                            strTrademarkDate = Format(TrademarkDate, "dd MMMM yyyy")
                        Else
                            strTrademarkDate = Format(TrademarkDate, "dd MMM yyyy")
                        End If
                    End If
                    DRow.Item(j) = strTrademarkDate
                End If
            Next j 'column in row
        Next i 'row in table

        'remove TrademarkID from table; don't need it in our spreadsheets
        ExportTable.Columns.RemoveAt(ExportTable.Columns.Count - 1)

    End Sub

    Friend Sub CreateWordTable()
        On Error Resume Next
        '========= ANOTHER WHOLE NEW APPROACH ===============

        'the new ExportTable is the only one that sorts correctly on dates, so we'll use it
        Dim WordDoc As Word.Document
        Dim WordApp As Word.Application
        Dim tbl As Word.Table
        Dim rng As Word.Range

        Dim dRow As DataRow
        Dim iRows As Integer, iCols As Integer
        Dim i As Integer, j As Integer
        Dim strGraphicPath As String

        'Populate the Export table
        GetExportTable(True) 'it's okay to put graphics in a Word table

        'we need one row for each record, plus one for the header row
        iRows = ExportTable.Rows.Count + 1
        iCols = ExportTable.Columns.Count

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

            'copy field names from table into first row of the table
            For i = 0 To ExportTable.Columns.Count - 1
                .Cell(1, i + 1).Range.Text = ExportTable.Columns(i).ColumnName
            Next

            'now loop through the records:  i = table row, j = column 
            'Datatable indexes are zero-based, but Word Table use real numbers.
            'We're starting in row two, so offset for rows is 2, for columns it's 1.
            For i = 0 To ExportTable.Rows.Count - 1
                dRow = ExportTable.Rows(i)

                For j = 0 To ExportTable.Columns.Count - 1

                    'make an exception only for graphics
                    If ExportTable.Columns(j).ColumnName = "Graphic" Then
                        strGraphicPath = Nz(dRow.Item(j), "")
                        If (Len(strGraphicPath) > 2) And (System.IO.File.Exists(strGraphicPath)) Then
                            .Cell(i + 2, j + 1).Select()
                            rng = .Cell(i + 2, j + 1).Range
                            rng.InlineShapes.AddPicture(FileName:=strGraphicPath, LinkToFile:=False, SaveWithDocument:=True)
                        End If
                    Else  'just copy the value
                        .Cell(i + 2, j + 1).Range.Text = Nz(dRow.Item(j), "")
                    End If

                Next  ' next column
            Next i  'next datarow

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
        Dim i As Integer, j As Integer
        Dim dRow As DataRow

        If XL Is Nothing Then
            XL = CreateObject("Excel.Application")
        Else
            XL = GetObject(, "Excel.Application")
        End If

        XLBook = XL.Workbooks.Add
        XLSheet = XLBook.ActiveSheet
        XL.Visible = True

        'Populate the Export table
        GetExportTable(False) 'no graphics in spreadsheets

        With XLSheet

            'copy field names from table into first row of the spreadsheet
            For i = 0 To ExportTable.Columns.Count - 1
                .Cells(1, i + 1).Value = ExportTable.Columns(i).ColumnName
            Next

            'now loop through the records:  i = table row, j = column 
            'Datatable indexes are zero-based, but Excel uses real numbers.
            'We're starting in row two, so offset for rows is 2, for columns it's 1.
            For i = 0 To ExportTable.Rows.Count - 1
                dRow = ExportTable.Rows(i)
                For j = 0 To ExportTable.Columns.Count - 1
                    'just copy the value
                    .Cells(i + 2, j + 1).Value = Nz(dRow.Item(j), "")

                    'have to format the dates or they'll get wacky on us
                    If IsDate(dRow.Item(j)) Then
                        If My.Settings.USADates = True Then
                            If My.Settings.SpellMonthMerge = True Then
                                .Cells(i + 2, j + 1).NumberFormat = "MMMM dd, yyyy"
                            Else
                                .Cells(i + 2, j + 1).NumberFormat = "MMM dd, yyyy"
                            End If
                        Else
                            If My.Settings.SpellMonthMerge = True Then
                                .Cells(i + 2, j + 1).NumberFormat = "dd MMMM yyyy"
                            Else
                                .Cells(i + 2, j + 1).NumberFormat = "dd MMM yyyy"
                            End If
                        End If
                    End If

                Next  ' next column
            Next i  'next datarow

        End With

        XL = Nothing
        XLBook = Nothing
        XLSheet = Nothing
    End Sub


#Region "Old Methods - Save Just In Case"

    'Public Sub GetMergeRecords()
    '    On Error Resume Next
    '    Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
    '    grdFields = AllForms.frmReports.grdMarkFields

    '    'field types:  1 = field, 2 = graphic, 3 = Date, 4 = Classes placeholder
    '    strSQL = "Select * from vwReportTrademarksList" & AllForms.frmReports.GetTrademarksToPrint & " order by "
    '    For i = 0 To grdFields.RowCount - 1
    '        GRow = grdFields.GetRow(i)
    '        If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
    '            If (GRow.Cells("FieldType").Value = 1) And (GRow.Cells("Selected").Value = True) Then
    '                strSQL = strSQL & GRow.Cells("FieldName").Value & ", "
    '            End If
    '        End If
    '    Next
    '    strSQL = strSQL & "TrademarkID"

    '    'we should now have a select statement that gets the records in user's preferred order
    '    dtTrademarks = DataStuff.GetDataTable(strSQL)

    '    'this one should in theory pull latest date, per customer request
    '    strSQL = "SELECT DISTINCT tblTrademarkDates.TrademarkID, tblTrademarkDates.DateID, " & _
    '    "Max(tblTrademarkDates.TrademarkDate) as TrademarkDate FROM (tblTrademarkDates)" & _
    '     AllForms.frmReports.GetTrademarksToPrint() & _
    '    "GROUP BY tblTrademarkDates.TrademarkID, tblTrademarkDates.DateID"

    '    dtTrademarkDates = DataStuff.GetDataTable(strSQL)

    '    'get the classes too
    '    strSQL = "Select * from vwTrademarkRegClasses" & AllForms.frmReports.GetTrademarksToPrint() & _
    '    " order by TrademarkID, RegClass"
    '    dtTrademarkClasses = DataStuff.GetDataTable(strSQL)

    '    'get the Contacts
    '    strSQL = "Select TrademarkID, ContactName, PositionName from vwReportTrademarkContacts" & _
    '        AllForms.frmReports.GetTrademarksToPrint() & " order by TrademarkID, ContactName"
    '    dtTrademarkContacts = DataStuff.GetDataTable(strSQL)

    'End Sub

    'Friend Sub CreateWordTable()
    '    On Error Resume Next
    '    '========= WHOLE NEW APPROACH ===============
    '    Dim WordDoc As Word.Document
    '    Dim WordApp As Word.Application
    '    Dim tbl As Word.Table
    '    Dim rng As Word.Range

    '    Dim dRow As DataRow
    '    'Dim dDateRow As DataRow
    '    Dim iRows As Integer, iCurrentRow As Integer
    '    Dim iCols As Integer, iCurrentCol As Integer
    '    Dim i As Integer, j As Integer, k As Integer

    '    Dim strCriteria As String
    '    Dim iTrademarkID As String
    '    Dim strGraphic As String
    '    Dim strColumnName As String
    '    Dim TrademarkDate As Date
    '    Dim strTrademarkDate As String
    '    Dim strClasses As String
    '    Dim strContacts As String
    '    Dim GRow As Janus.Windows.GridEX.GridEXRow

    '    ' the () makes it a collection of rows
    '    Dim DateRow() As DataRow
    '    Dim ClassRow() As DataRow
    '    Dim ContactRow() As DataRow

    '    'we need one row for each record, plus one for the header row
    '    iRows = dtTrademarks.Rows.Count + 1
    '    iCols = 0
    '    grdFields = AllForms.frmReports.grdMarkFields

    '    'find out how many columns we need in the table, one for each selected field name
    '    For i = 0 To grdFields.RowCount - 1
    '        GRow = grdFields.GetRow(i)
    '        If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
    '            And (GRow.Cells("Selected").Value = True) Then
    '            iCols = iCols + 1
    '        End If
    '    Next

    '    'If Word is running, use existing instance; otherwise, create instance
    '    If WordApp Is Nothing Then
    '        WordApp = CreateObject("Word.Application")
    '    Else
    '        WordApp = GetObject(, "Word.Application")
    '    End If

    '    WordDoc = WordApp.Documents.Add
    '    'Set rng = WordDoc.Range
    '    WordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape

    '    WordApp.Visible = True
    '    WordApp.Activate()

    '    WordApp.Selection.TypeParagraph()
    '    WordApp.Selection.TypeParagraph()
    '    WordApp.Selection.TypeParagraph()
    '    WordDoc.Characters.Last.Select()

    '    tbl = WordDoc.Tables.Add(WordApp.Selection.Range, iRows, iCols)

    '    With tbl
    '        iCurrentRow = 1
    '        iCurrentCol = 1

    '        'copy field display name into first row of the table
    '        For i = 0 To grdFields.RowCount - 1
    '            GRow = grdFields.GetRow(i)
    '            If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
    '                And (GRow.Cells("Selected").Value = True) Then
    '                .Cell(1, iCurrentCol).Range.Text = GRow.Cells("DisplayName").Text
    '                iCurrentCol = iCurrentCol + 1
    '            End If
    '        Next

    '        'first table row for data is row 2
    '        iCurrentRow = 2

    '        'now we can loop through the records
    '        For j = 0 To dtTrademarks.Rows.Count - 1

    '            'reset to column 1 in table for each record
    '            iCurrentCol = 1
    '            dRow = dtTrademarks.Rows(j)
    '            iTrademarkID = dRow("TrademarkID")

    '            'get dates, classes, contacts based on TrademarkID, put in row collections
    '            DateRow = dtTrademarkDates.Select("TrademarkID=" & iTrademarkID)
    '            ClassRow = dtTrademarkClasses.Select("TrademarkID=" & iTrademarkID)
    '            ContactRow = dtTrademarkContacts.Select("TrademarkID=" & iTrademarkID)

    '            'now loop through our selected fields again and fill appropriate data
    '            For i = 0 To grdFields.RowCount - 1

    '                GRow = grdFields.GetRow(i)
    '                If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
    '                    And (GRow.Cells("Selected").Value = True) Then

    '                    strColumnName = GRow.Cells("FieldName").Text

    '                    'trademark fields, just pluck matching column from current trademark row
    '                    If GRow.Cells("FieldType").Value = 1 Then
    '                        .Cell(iCurrentRow, iCurrentCol).Range.Text = dRow(strColumnName)
    '                    End If

    '                    'graphic, so we have to insert it from the path
    '                    If GRow.Cells("FieldType").Value = 2 Then
    '                        strGraphic = dRow("GraphicPath") & ""
    '                        If (Len(strGraphic) > 2) And (System.IO.File.Exists(strGraphic)) Then
    '                            .Cell(iCurrentRow, iCurrentCol).Select()
    '                            rng = .Cell(iCurrentRow, iCurrentCol).Range
    '                            rng.InlineShapes.AddPicture(FileName:=strGraphic, LinkToFile:=False, SaveWithDocument:=True)
    '                        End If
    '                    End If

    '                    'Date fields, trickier, have to match on Date ID
    '                    If GRow.Cells("FieldType").Value = 3 Then
    '                        For k = 0 To DateRow.Length - 1
    '                            If DateRow(k).Item("DateID") = GRow.Cells("DateID").Value Then
    '                                TrademarkDate = DateRow(k).Item("TrademarkDate")
    '                                'now format it for region preference
    '                                If (IsDate(TrademarkDate)) And (TrademarkDate <> Date.MinValue) Then
    '                                    If My.Settings.USADates = True Then
    '                                        If My.Settings.SpellMonthMerge = True Then
    '                                            strTrademarkDate = Format(TrademarkDate, "MMMM dd, yyyy")
    '                                        Else
    '                                            strTrademarkDate = Format(TrademarkDate, "MMM dd, yyyy")
    '                                        End If
    '                                    Else
    '                                        If My.Settings.SpellMonthMerge = True Then
    '                                            strTrademarkDate = Format(TrademarkDate, "dd MMMM yyyy")
    '                                        Else
    '                                            strTrademarkDate = Format(TrademarkDate, "dd MMM yyyy")
    '                                        End If
    '                                    End If
    '                                    .Cell(iCurrentRow, iCurrentCol).Range.Text = strTrademarkDate
    '                                End If
    '                            End If
    '                        Next k
    '                    End If

    '                    'classes, so have to build a string
    '                    If GRow.Cells("FieldType").Value = 4 Then
    '                        strClasses = ""
    '                        For k = 0 To ClassRow.Length - 1
    '                            strClasses = strClasses & ClassRow(k).Item("RegClass") & ", "
    '                        Next
    '                        If Len(strClasses) > 2 Then
    '                            'trim last comma and space
    '                            strClasses = Left(strClasses, Len(strClasses) - 2)
    '                            .Cell(iCurrentRow, iCurrentCol).Range.Text = strClasses
    '                        End If
    '                    End If

    '                    'Contacts, have to match and build a string
    '                    If GRow.Cells("FieldType").Value = 5 Then
    '                        strContacts = ""
    '                        For k = 0 To ContactRow.Length - 1
    '                            If GRow.Cells("DisplayName").Text = ContactRow(k).Item("PositionName") Then
    '                                strContacts = strContacts & ContactRow(k).Item("ContactName") & "; "
    '                            End If
    '                        Next
    '                        If Len(strContacts) > 2 Then
    '                            'trim last semicolon and space
    '                            strContacts = Left(strContacts, Len(strContacts) - 2)
    '                            .Cell(iCurrentRow, iCurrentCol).Range.Text = strContacts
    '                        End If
    '                    End If

    '                    iCurrentCol = iCurrentCol + 1
    '                End If
    '            Next i

    '            'go to next row in table for next trademark record
    '            iCurrentRow = iCurrentRow + 1
    '        Next j

    '    End With

    '    WordApp = Nothing
    '    WordDoc = Nothing
    '    tbl = Nothing
    '    rng = Nothing

    'End Sub

    'Friend Sub CreateSpreadsheet()
    '    On Error Resume Next

    '    Dim XL As Excel.Application
    '    Dim XLBook As Excel.Workbook
    '    Dim XLSheet As Excel.Worksheet

    '    Dim iCurrentRow As Integer, iCurrentCol As Integer
    '    Dim i As Integer, j As Integer, k As Integer

    '    Dim dRow As DataRow
    '    Dim strColumnName As String
    '    Dim TrademarkDate As Date

    '    Dim strCriteria As String
    '    Dim iTrademarkID As String
    '    Dim strClasses As String
    '    Dim strContacts As String
    '    Dim GRow As Janus.Windows.GridEX.GridEXRow

    '    ' the () makes it a collection of rows
    '    Dim DateRow() As DataRow
    '    Dim ClassRow() As DataRow
    '    Dim ContactRow() As DataRow
    '    grdFields = AllForms.frmReports.grdMarkFields

    '    If XL Is Nothing Then
    '        XL = CreateObject("Excel.Application")
    '    Else
    '        XL = GetObject(, "Excel.Application")
    '    End If

    '    XLBook = XL.Workbooks.Add
    '    XLSheet = XLBook.ActiveSheet

    '    XL.Visible = True

    '    With XLSheet

    '        iCurrentRow = 1
    '        iCurrentCol = 1

    '        'copy field display name into first row of the sheet
    '        For i = 0 To grdFields.RowCount - 1
    '            GRow = grdFields.GetRow(i)
    '            If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
    '                And (GRow.Cells("Selected").Value = True) And (GRow.Cells("FieldType").Value <> 2) Then
    '                .Cells(1, iCurrentCol).Value = GRow.Cells("DisplayName").Text
    '                iCurrentCol = iCurrentCol + 1
    '            End If
    '        Next

    '        iCurrentRow = 2

    '        'now we can loop through the records
    '        For j = 0 To dtTrademarks.Rows.Count - 1

    '            'reset to column 1 in sheet for each record
    '            iCurrentCol = 1
    '            dRow = dtTrademarks.Rows(j)
    '            iTrademarkID = dRow("TrademarkID")

    '            'get dates and classes based on TrademarkID, put in row collections
    '            DateRow = dtTrademarkDates.Select("TrademarkID=" & iTrademarkID)
    '            ClassRow = dtTrademarkClasses.Select("TrademarkID=" & iTrademarkID)
    '            ContactRow = dtTrademarkContacts.Select("TrademarkID=" & iTrademarkID)

    '            'now loop through our selected fields again and fill appropriate data
    '            For i = 0 To grdFields.RowCount - 1

    '                GRow = grdFields.GetRow(i)
    '                If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) _
    '                    And (GRow.Cells("Selected").Value = True) Then

    '                    strColumnName = GRow.Cells("FieldName").Text

    '                    'trademark fields, just pluck matching column from current trademark row
    '                    If GRow.Cells("FieldType").Value = 1 Then
    '                        .Cells(iCurrentRow, iCurrentCol).Value = dRow(strColumnName)
    '                    End If

    '                    'Date fields, trickier, have to match on Date ID
    '                    If GRow.Cells("FieldType").Value = 3 Then
    '                        For k = 0 To DateRow.Length - 1
    '                            If DateRow(k).Item("DateID") = GRow.Cells("DateID").Value Then
    '                                TrademarkDate = DateRow(k).Item("TrademarkDate")
    '                                'now format it for region preference
    '                                If (IsDate(TrademarkDate)) And (TrademarkDate <> Date.MinValue) Then
    '                                    .Cells(iCurrentRow, iCurrentCol).Value = TrademarkDate
    '                                    If My.Settings.USADates = True Then
    '                                        If My.Settings.SpellMonthMerge = True Then
    '                                            .Cells(iCurrentRow, iCurrentCol).NumberFormat = "MMMM dd, yyyy"
    '                                        Else
    '                                            .Cells(iCurrentRow, iCurrentCol).NumberFormat = "MMM dd, yyyy"
    '                                        End If
    '                                    Else
    '                                        If My.Settings.SpellMonthMerge = True Then
    '                                            .Cells(iCurrentRow, iCurrentCol).NumberFormat = "dd MMMM yyyy"
    '                                        Else
    '                                            .Cells(iCurrentRow, iCurrentCol).NumberFormat = "dd MMM yyyy"
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                        Next k
    '                    End If

    '                    'classes, so have to build a string
    '                    If GRow.Cells("FieldType").Value = 4 Then
    '                        strClasses = ""
    '                        For k = 0 To ClassRow.Length - 1
    '                            strClasses = strClasses & ClassRow(k).Item("RegClass") & ", "
    '                        Next
    '                        'trim last comma and space
    '                        If Len(strClasses) > 2 Then
    '                            strClasses = Left(strClasses, Len(strClasses) - 2)
    '                            .Cells(iCurrentRow, iCurrentCol).Value = strClasses
    '                        End If
    '                    End If

    '                    'Contacts, have to match and build a string
    '                    If GRow.Cells("FieldType").Value = 5 Then
    '                        strContacts = ""
    '                        For k = 0 To ContactRow.Length - 1
    '                            If GRow.Cells("DisplayName").Text = ContactRow(k).Item("PositionName") Then
    '                                strContacts = strContacts & ContactRow(k).Item("ContactName") & "; "
    '                            End If
    '                        Next
    '                        If Len(strContacts) > 2 Then
    '                            'trim last semicolon and space
    '                            strContacts = Left(strContacts, Len(strContacts) - 2)
    '                            .Cells(iCurrentRow, iCurrentCol).Value = strContacts
    '                        End If
    '                    End If

    '                    'don't move on graphic becuz we don't do it
    '                    If GRow.Cells("FieldType").Value <> 2 Then
    '                        iCurrentCol = iCurrentCol + 1
    '                    End If
    '                End If
    '            Next i

    '            'go to next row in table for next trademark record
    '            iCurrentRow = iCurrentRow + 1
    '        Next j

    '    End With

    '    XL = Nothing
    '    XLBook = Nothing
    '    XLSheet = Nothing
    'End Sub


#End Region

End Class
