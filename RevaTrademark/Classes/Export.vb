Imports Microsoft.Office.Interop

Public Class Export

    Friend ExportTable As DataTable  'this is the one we expose publicly

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
                    'if it's not a date, format as text
                    .Cells(i + 2, j + 1).NumberFormat = "@"
                    .Cells(i + 2, j + 1).Value = Nz(dRow.Item(j), "")

                    'have to format the dates or they'll get wacky on us
                    If IsDate(dRow.Item(j)) Then
                        If RevaSettings.USADates = True Then
                            If RevaSettings.SpellMonthMerge = True Then
                                .Cells(i + 2, j + 1).NumberFormat = "MMMM dd, yyyy"
                            Else
                                .Cells(i + 2, j + 1).NumberFormat = "MMM dd, yyyy"
                            End If
                        Else
                            If RevaSettings.SpellMonthMerge = True Then
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


End Class
