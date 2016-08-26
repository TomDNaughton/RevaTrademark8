
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


    Public Shared Function GetAccessTable(ByVal strSQL As String) As DataTable
        On Error Resume Next

        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.AccessConnection
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

    Public Shared Sub RunAccessSQL(ByVal strSQL As String)
        On Error Resume Next
        Dim Cnn As New OleDbConnection
        Cnn.ConnectionString = My.Settings.AccessConnection
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

#Region "Stored Procedure Functions"
    'Public Shared Function GetSPDataSet(ByVal ProcName As String, _
    '    Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '    Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '    Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '    Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '    Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '    Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataSet

    '    'returns a dataset based on a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim ds As New DataSet
    '    Dim da As New OleDbDataAdapter
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    da.SelectCommand = cmd
    '    da.Fill(ds)
    '    Return ds
    'End Function

    'Public Shared Function GetSPDataTable(ByVal ProcName As String, _
    '    Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '    Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '    Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '    Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '    Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '    Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataTable

    '    'returns a data table based on a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim ds As New DataSet
    '    Dim da As New OleDbDataAdapter
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    da.SelectCommand = cmd
    '    da.Fill(ds)
    '    Return ds.Tables(0)

    'End Function

    'Public Shared Function GetSPDataRow(ByVal ProcName As String, _
    '   Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '   Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '   Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '   Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '   Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '   Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataRow

    '    'returns a data row based on a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim ds As New DataSet
    '    Dim da As New OleDbDataAdapter
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    da.SelectCommand = cmd
    '    da.Fill(ds)
    '    Return ds.Tables(0).Rows(0)

    'End Function



    'Public Shared Function GetSPDataReader(ByVal ProcName As String, _
    '    Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '    Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '    Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '    Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '    Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '    Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing, _
    '    Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing, _
    '    Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing, _
    '    Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing, _
    '    Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing) As OleDbDataReader

    '    'returns a data-reader based on a stored procedure; cannot be used for editing

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Cnn.Open()

    '    Dim dr As OleDbDataReader
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    If Not (Value7 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param7, Value7))
    '    End If

    '    If Not (Value8 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param8, Value8))
    '    End If

    '    If Not (Value9 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param9, Value9))
    '    End If

    '    If Not (Value10 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param10, Value10))
    '    End If

    '    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '    Return dr
    '    Cnn.Close()

    'End Function

    'Public Shared Sub RunSP(ByVal ProcName As String, _
    '    Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '    Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '    Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '    Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '    Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '    Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing, _
    '    Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing, _
    '    Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing, _
    '    Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing, _
    '    Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing, _
    '    Optional ByVal Param11 As String = "x", Optional ByVal Value11 As Object = Nothing, _
    '    Optional ByVal Param12 As String = "x", Optional ByVal Value12 As Object = Nothing, _
    '    Optional ByVal Param13 As String = "x", Optional ByVal Value13 As Object = Nothing, _
    '    Optional ByVal Param14 As String = "x", Optional ByVal Value14 As Object = Nothing, _
    '    Optional ByVal Param15 As String = "x", Optional ByVal Value15 As Object = Nothing, _
    '    Optional ByVal Param16 As String = "x", Optional ByVal Value16 As Object = Nothing)

    '    'runs a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param6, Value6))
    '    End If

    '    If Not (Value7 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param7, Value7))
    '    End If

    '    If Not (Value8 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param8, Value8))
    '    End If

    '    If Not (Value9 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param9, Value9))
    '    End If

    '    If Not (Value10 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param10, Value10))
    '    End If

    '    If Not (Value11 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param11, Value11))
    '    End If

    '    If Not (Value12 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param12, Value12))
    '    End If

    '    If Not (Value13 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param13, Value13))
    '    End If

    '    If Not (Value14 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param14, Value14))
    '    End If

    '    If Not (Value15 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param15, Value15))
    '    End If

    '    If Not (Value16 Is Nothing) Then
    '        cmd.Parameters.Add(New OleDbParameter(Param16, Value16))
    '    End If

    '    Cnn.Open()
    '    cmd.ExecuteNonQuery()
    '    Cnn.Close()
    'End Sub

    'Public Shared Function RunSPWithResult(ByVal ProcName As String, _
    '    Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '    Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '    Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '    Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '    Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '    Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing, _
    '    Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing, _
    '    Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing, _
    '    Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing, _
    '    Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing, _
    '    Optional ByVal Param11 As String = "x", Optional ByVal Value11 As Object = Nothing, _
    '    Optional ByVal Param12 As String = "x", Optional ByVal Value12 As Object = Nothing, _
    '    Optional ByVal Param13 As String = "x", Optional ByVal Value13 As Object = Nothing, _
    '    Optional ByVal Param14 As String = "x", Optional ByVal Value14 As Object = Nothing, _
    '    Optional ByVal Param15 As String = "x", Optional ByVal Value15 As Object = Nothing, _
    '    Optional ByVal Param16 As String = "x", Optional ByVal Value16 As Object = Nothing) As Integer

    '    'runs a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    If Not (Value7 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param7, Value7))
    '    End If

    '    If Not (Value8 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param8, Value8))
    '    End If

    '    If Not (Value9 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param9, Value9))
    '    End If

    '    If Not (Value10 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param10, Value10))
    '    End If

    '    If Not (Value11 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param11, Value11))
    '    End If

    '    If Not (Value12 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param12, Value12))
    '    End If

    '    If Not (Value13 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param13, Value13))
    '    End If

    '    If Not (Value14 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param14, Value14))
    '    End If

    '    If Not (Value15 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param15, Value15))
    '    End If

    '    If Not (Value16 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param16, Value16))
    '    End If

    '    Dim i As Integer
    '    Cnn.Open()
    '    i = cmd.ExecuteScalar()
    '    Cnn.Close()
    '    Return i
    'End Function

    'Public Shared Function RunSPTextResult(ByVal ProcName As String, _
    '        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing, _
    '        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing, _
    '        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing, _
    '        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing, _
    '        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing, _
    '        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing, _
    '        Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing, _
    '        Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing, _
    '        Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing, _
    '        Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing, _
    '        Optional ByVal Param11 As String = "x", Optional ByVal Value11 As Object = Nothing, _
    '        Optional ByVal Param12 As String = "x", Optional ByVal Value12 As Object = Nothing, _
    '        Optional ByVal Param13 As String = "x", Optional ByVal Value13 As Object = Nothing, _
    '        Optional ByVal Param14 As String = "x", Optional ByVal Value14 As Object = Nothing, _
    '        Optional ByVal Param15 As String = "x", Optional ByVal Value15 As Object = Nothing, _
    '        Optional ByVal Param16 As String = "x", Optional ByVal Value16 As Object = Nothing) As Integer

    '    'runs a stored procedure

    '    On Error Resume Next

    '    Dim Cnn As New OleDbConnection
    '    Cnn.ConnectionString = My.Settings.CurrentConnection
    '    Dim cmd As New OleDbCommand

    '    cmd.Connection = Cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = ProcName

    '    'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
    '    If Not (Value1 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param1, Value1))
    '    End If

    '    If Not (Value2 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param2, Value2))
    '    End If

    '    If Not (Value3 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param3, Value3))
    '    End If

    '    If Not (Value4 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param4, Value4))
    '    End If

    '    If Not (Value5 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param5, Value5))
    '    End If

    '    If Not (Value6 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param6, Value6))
    '    End If

    '    If Not (Value7 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param7, Value7))
    '    End If

    '    If Not (Value8 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param8, Value8))
    '    End If

    '    If Not (Value9 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param9, Value9))
    '    End If

    '    If Not (Value10 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param10, Value10))
    '    End If

    '    If Not (Value11 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param11, Value11))
    '    End If

    '    If Not (Value12 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param12, Value12))
    '    End If

    '    If Not (Value13 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param13, Value13))
    '    End If

    '    If Not (Value14 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param14, Value14))
    '    End If

    '    If Not (Value15 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param15, Value15))
    '    End If

    '    If Not (Value16 Is Nothing) Then
    '        cmd.Parameters.Add(New SqlParameter(Param16, Value16))
    '    End If

    '    Dim strResult As Integer
    '    Cnn.Open()
    '    strResult = cmd.ExecuteScalar()
    '    Cnn.Close()
    '    Return strResult

    'End Function

#End Region


End Class
