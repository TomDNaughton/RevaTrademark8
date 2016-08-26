Imports System.Data.OleDb
Imports System.Data

Public Class RecordSet

    Friend Table As DataTable
    Friend strSQL As String
    Friend CurrentRow As DataRow

    Private DSet As New DataSet
    Private dbAdapter As OleDbDataAdapter
    Private cmdBuilder As OleDbCommandBuilder
    Private cnn As New OleDbConnection

    Friend Sub Connect()
        On Error Resume Next
        cnn.ConnectionString = My.Settings.CurrentConnection
        dbAdapter = New OleDbDataAdapter(strSQL, cnn)
        cmdBuilder = New OleDbCommandBuilder(dbAdapter)
        cmdBuilder.DataAdapter = dbAdapter
        dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
    End Sub

    Friend Sub ConnectAccess()
        On Error Resume Next
        cnn.ConnectionString = My.Settings.AccessConnection
        dbAdapter = New OleDbDataAdapter(strSQL, cnn)
        cmdBuilder = New OleDbCommandBuilder(dbAdapter)
        cmdBuilder.DataAdapter = dbAdapter
        dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
    End Sub

    Friend Sub GetRecords()
        On Error Resume Next
        DSet.Tables.Clear()
        dbAdapter.Fill(DSet, "tblTable")
        Table = DSet.Tables(0)
        If Table.Rows.Count > 0 Then
            CurrentRow = Table.Rows(0)
        End If
    End Sub

    Friend Sub AddRow()
        On Error Resume Next
        Table.Rows.Add()
        CurrentRow = Table.Rows(Table.Rows.Count - 1)
    End Sub

    Friend Sub GetFromSQL(ByVal SQL As String)
        On Error Resume Next
        strSQL = SQL
        Connect()
        GetRecords()
    End Sub

    Friend Sub GetFromAccess(ByVal SQL As String)
        On Error Resume Next
        strSQL = SQL
        ConnectAccess()
        GetRecords()
    End Sub

    Friend Sub Update()
        On Error Resume Next
        If Not (Me.Table Is Nothing) Then
            If DSet.HasChanges = True Then
                dbAdapter.Update(Table)
            End If
        End If
    End Sub

    Friend Function RecordExists(ByVal strFilter) As Boolean
        On Error Resume Next
        'to see if a record exists, filter and check results
        Dim dr As DataRow
        dr = Table.Select(strFilter)(0)  'zero gets first row only
        RecordExists = Not (dr Is Nothing)
        dr = Nothing
    End Function

End Class
