
Imports System.Data
Imports System.Data.OleDb


Public Class DataStuff

    Public Shared Function GetDataTable(ByVal strSQL As String) As DataTable
        On Error Resume Next

        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.CurrentConnection
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandText = strSQL
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds.Tables(0)
        ds.Dispose()
        da.Dispose()
        cmd.Dispose()
        Cnn.Dispose()
    End Function


    Public Shared Function GetDemoTable(ByVal strSQL As String) As DataTable
        On Error Resume Next

        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.DemoConnection
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandText = strSQL
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds.Tables(0)
        ds.Dispose()
        da.Dispose()
        cmd.Dispose()
        Cnn.Dispose()
    End Function

    Public Shared Function GetDataRow(ByVal strSQL As String) As DataRow
        On Error Resume Next

        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.CurrentConnection
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandText = strSQL
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds.Tables(0).Rows(0)
        ds.Dispose()
        da.Dispose()
        cmd.Dispose()
        Cnn.Dispose()
    End Function

    Public Shared Function GetDataSet(ByVal strSQL As String) As DataSet
        On Error Resume Next

        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.CurrentConnection
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandText = strSQL
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds
        ds.Dispose()
        da.Dispose()
        cmd.Dispose()
        Cnn.Dispose()
    End Function

    Public Shared Function GetDataReader(ByVal strSQL As String) As OleDbDataReader
        On Error Resume Next
        'returns a data-reader based on a SQL statement
        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.CurrentConnection
        Cnn.Open()  'for a data reader, must specifically open connection

        Dim dr As OleDbDataReader
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandText = strSQL
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Return dr
        Cnn.Close()
        cmd.Dispose()
        Cnn.Dispose()

    End Function


    Public Shared Function DCount(ByVal ColumnName As String, ByVal TableName As String, ByVal Filter As String) As Integer
        On Error Resume Next
        'returns Count of columns found in table with a filtered sql statement
        Dim i As Integer, strSQL As String
        strSQL = "Select Count(" & ColumnName & ") from " & TableName & " WHERE " & Filter
        Dim cmd As New OleDbCommand(strSQL, New OleDbConnection(My.Settings.CurrentConnection))

        cmd.Connection.Open()
        i = Nz(cmd.ExecuteScalar(), 0)
        cmd.Connection.Close()

        Return i
        cmd.Dispose()

    End Function

    Public Shared Function DLookup(ByVal ColumnName As String, ByVal TableName As String, _
            Optional ByVal Filter As String = "") As Integer

        On Error Resume Next

        Dim i As Integer, strSQL As String
        strSQL = "Select " & ColumnName & " from " & TableName

        If Filter <> "" Then
            strSQL = strSQL & " WHERE " & Filter
        End If

        Dim cmd As New OleDbCommand(strSQL, New OleDbConnection(My.Settings.CurrentConnection))

        cmd.Connection.Open()
        i = Nz(cmd.ExecuteScalar(), 0)
        cmd.Connection.Close()

        Return i

        cmd.Dispose()

    End Function

    Public Shared Function DMax(ByVal ColumnName As String, ByVal TableName As String, _
        Optional ByVal Filter As String = "") As Integer
        On Error Resume Next

        Dim i As Integer, strSQL As String
        If Filter & "" <> "" Then
            strSQL = "Select Max(" & ColumnName & ") from " & TableName & " where " & Filter
        Else
            strSQL = "Select Max(" & ColumnName & ") from " & TableName
        End If


        Dim cmd As New OleDbCommand(strSQL, New OleDbConnection(My.Settings.CurrentConnection))

        cmd.Connection.Open()
        i = Nz(cmd.ExecuteScalar(), 0)
        cmd.Connection.Close()
        Return i

        cmd.Dispose()

    End Function

    Public Shared Function DMin(ByVal ColumnName As String, ByVal TableName As String, _
    Optional ByVal Filter As String = "") As Integer
        On Error Resume Next

        Dim i As Integer, strSQL As String
        If Filter & "" <> "" Then
            strSQL = "Select Min(" & ColumnName & ") from " & TableName & " where " & Filter
        Else
            strSQL = "Select Min(" & ColumnName & ") from " & TableName
        End If


        Dim cmd As New OleDbCommand(strSQL, New OleDbConnection(My.Settings.CurrentConnection))

        cmd.Connection.Open()
        i = cmd.ExecuteScalar()
        cmd.Connection.Close()
        Return i


        cmd.Dispose()

    End Function

    Public Shared Sub RunSQL(ByVal strSQL As String)
        On Error Resume Next
        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.CurrentConnection
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strSQL

        Cnn.Open()
        cmd.ExecuteNonQuery()
        Cnn.Close()

        cmd.Dispose()
        Cnn.Dispose()
    End Sub

    Public Shared Sub RunDemoSQL(ByVal strSQL As String)
        On Error Resume Next
        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.DemoConnection
        Dim cmd As New OleDbCommand

        cmd.Connection = Cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strSQL

        Cnn.Open()
        cmd.ExecuteNonQuery()
        Cnn.Close()

        cmd.Dispose()
        Cnn.Dispose()
    End Sub


    Public Shared Function RecordCount() As Integer
        On Error Resume Next
        Dim iRecords As Integer
        iRecords = Nz(DCount("TrademarkID", "tblTrademarks", "TrademarkID>0"), 0) + _
            Nz(DCount("PatentID", "tblPatents", "PatentID>0"), 0)
        RecordCount = iRecords
    End Function

    Public Shared Sub DeleteTrademark(ByVal iTrademarkID As Integer)
        On Error Resume Next
        RunSQL("Delete from tblTrademarks where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTrademarkContacts where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTrademarkDates where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTrademarkActions where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTrademarkRegClasses where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTrademarksLicensed where TrademarkID=" & iTrademarkID)
        RunSQL("delete from tblTrademarkDocuments where TrademarkID = " & iTrademarkID)
        RunSQL("delete from tblTreatyFilings where TrademarkID = " & iTrademarkID)
        RunSQL("Delete from tblOppositionClientTrademarks where TrademarkID=" & iTrademarkID)
        RunSQL("Delete from tblTreatyFilingTrademarks where TrademarkID=" & iTrademarkID)

    End Sub

    Public Shared Sub DeletePatent(ByVal iPatentID As Integer)
        On Error Resume Next
        RunSQL("Delete from tblPatents where PatentID=" & iPatentID)
        RunSQL("Delete from tblPatentContacts where PatentID=" & iPatentID)
        RunSQL("Delete from tblPatentDates where PatentID=" & iPatentID)
        RunSQL("Delete from tblPatentActions where PatentID=" & iPatentID)
        RunSQL("Delete from tblPatentClasses where PatentID=" & iPatentID)
        RunSQL("Delete from tblPatentsLicensed where PatentID=" & iPatentID)
        RunSQL("delete from tblPatentDocuments where PatentID = " & iPatentID)
        RunSQL("delete from tblPatentTreatyFilings where PatentID = " & iPatentID)

    End Sub

    Public Shared Sub DeleteOpposition(ByVal iOppositionID As Integer)
        On Error Resume Next
        RunSQL("Delete from tblOppositions where OppositionID=" & iOppositionID)
        RunSQL("Delete from tblOppositionContacts where OppositionID=" & iOppositionID)
        RunSQL("Delete from tblOppositionDates where OppositionID=" & iOppositionID)
        RunSQL("Delete from tblOppositionActions where OppositionID=" & iOppositionID)
        RunSQL("Delete from tblOppositionTrademarks where OppositionID=" & iOppositionID)
        RunSQL("Delete from tblOppositionClientTrademarks where OppositionID=" & iOppositionID)
        RunSQL("delete from tblOppositionDocuments where OppositionID = " & iOppositionID)

    End Sub

    Public Shared Function GetTableFromGrid(ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal RequiredField As String, ByVal RenameColumns As Boolean) As DataTable
        On Error Resume Next
        Dim GridTable As New DataTable, dRow As DataRow, i As Integer, j As Integer, strColumnName As String
        Dim GridCol As Janus.Windows.GridEX.GridEXColumn, GRow As Janus.Windows.GridEX.GridEXRow

        ' Rather than hit the database again to retrieve the same data we've already got in a grid,
        ' we'll just copy the grid rows into a table.

        With Grid
            'make a table and add same columns as are visible in grid
            For i = 0 To .RootTable.Columns.Count - 1
                GridCol = .RootTable.Columns.GetColumnInPosition(i)
                ' we only want columns in grid or a group
                If (GridCol.Visible = True) Or (GridCol.IsGrouped) Then
                    strColumnName = GridCol.Key
                    If GridCol.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox Then
                        GridTable.Columns.Add(strColumnName, GetType(Boolean))
                    Else
                        GridTable.Columns.Add(strColumnName, GetType(String))
                    End If

                End If
            Next i
            GridTable.AcceptChanges()

            ' because I need to count on one specific field to do totals on reports
            If GridTable.Columns.Contains(RequiredField) = False Then
                GridTable.Columns.Add(RequiredField)
            End If

            'now for each record row in grid, copy cells into table fields
            For i = 0 To .RowCount - 1
                GRow = .GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    dRow = GridTable.Rows.Add
                    For j = 0 To GridTable.Columns.Count - 1
                        strColumnName = GridTable.Columns(j).ColumnName
                        If GridTable.Columns(j).DataType Is GetType(Boolean) Then
                            dRow.Item(strColumnName) = GRow.Cells(strColumnName).Value
                        Else
                            dRow.Item(strColumnName) = GRow.Cells(strColumnName).Text
                        End If

                    Next j
                End If
            Next

            GridTable.AcceptChanges()

            If RenameColumns = True Then
                ' Rename columns in table to match grid captions -- no ugly column names in Word/Excel exports
                For i = 0 To .RootTable.Columns.Count - 1
                    GridCol = .RootTable.Columns(i)
                    strColumnName = GridCol.Key
                    If GridTable.Columns.Contains(strColumnName) Then
                        GridTable.Columns(strColumnName).ColumnName = GridCol.Caption
                    End If
                Next i
            End If

        End With

        GridTable.AcceptChanges()
        Return GridTable
    End Function


End Class
