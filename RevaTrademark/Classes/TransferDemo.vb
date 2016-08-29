Imports System.Data
Imports System.Data.OleDb

Public Class TransferDemo

    Friend strSQL As String
    Friend strAccess As String

    Friend TableName As String

    Friend AccessRow As DataRow
    Friend SQLRow As DataRow

    Private AccessDSet As New DataSet
    Private SQLDSet As New DataSet

    Private AccessTable As DataTable
    Private SQLTable As DataTable

    Private AccessdbAdapter As OleDbDataAdapter
    Private AccesscmdBuilder As OleDbCommandBuilder

    Private SQLdbAdapter As OleDbDataAdapter
    Private SQLcmdBuilder As OleDbCommandBuilder

    Private AccessAdapter As OleDbDataAdapter
    Private SQLAdapter As OleDbDataAdapter

    Private AccessCnn As New OleDbConnection
    Private SQLCnn As New OleDbConnection

    Friend Sub Connect()
        On Error Resume Next
        AccessCnn.ConnectionString = My.Settings.DemoConnection
        AccessdbAdapter = New OleDbDataAdapter(strAccess, AccessCnn)
        AccesscmdBuilder = New OleDbCommandBuilder(AccessdbAdapter)
        AccesscmdBuilder.DataAdapter = AccessdbAdapter
        AccessdbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        SQLCnn.ConnectionString = My.Settings.CurrentConnection
        SQLdbAdapter = New OleDbDataAdapter(strSQL, SQLCnn)
        SQLcmdBuilder = New OleDbCommandBuilder(SQLdbAdapter)
        SQLcmdBuilder.DataAdapter = SQLdbAdapter
        SQLdbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        SQLdbAdapter.AcceptChangesDuringUpdate = True
    End Sub

    Friend Sub GetRecords()
        On Error Resume Next
        AccessDSet.Tables.Clear()
        AccessdbAdapter.Fill(AccessDSet, "tblTable")
        AccessTable = AccessDSet.Tables(0)
        AccessRow = AccessTable.Rows(0)

        SQLDSet.Tables.Clear()
        SQLdbAdapter.Fill(SQLDSet, "tblTable")
        SQLTable = SQLDSet.Tables(0)
        SQLRow = SQLTable.Rows(0)
    End Sub

    Friend Sub GetFromSQL(ByVal strTable As String)
        On Error Resume Next
        TableName = strTable
        strSQL = "SET IDENTITY_INSERT " & TableName & " ON;"
        strSQL = strSQL & "select * from " & strTable
        MsgBox(strSQL)
        strAccess = "select * from " & strTable
        Connect()
        GetRecords()
    End Sub

    Friend Sub AddSQLRow()
        On Error Resume Next
        SQLTable.Rows.Add()
        SQLRow = SQLTable.Rows(SQLTable.Rows.Count - 1)
    End Sub

    Friend Sub Update()
        On Error Resume Next
        SQLdbAdapter.Update(SQLTable)
    End Sub

    Friend Sub TransferData()
        On Error Resume Next
        Dim i As Integer, j As Integer, strField As String
        SQLTable.Rows.Clear()
        Update()

        'IdentityOn()
        For i = 0 To AccessTable.Rows.Count - 1
            AccessRow = AccessTable.Rows(i)
            AddSQLRow()
            For j = 0 To AccessTable.Columns.Count - 1
                If j = 0 Then
                    SQLTable.Columns(j).AutoIncrement = False
                End If
                strField = AccessTable.Columns(j).ColumnName
                SQLRow.Item(strField) = AccessRow.Item(strField)
            Next
        Next
        Update()
        IdentityOff()
    End Sub

    Private Sub IdentityOn()
        On Error Resume Next
        strSQL = "SET IDENTITY_INSERT " & TableName & " ON"
        Dim cmd As New OleDbCommand(strSQL, SQLCnn)
        SQLCnn.Open()
        cmd.ExecuteNonQuery()
        'SQLCnn.Close()
    End Sub

    Private Sub IdentityOff()
        On Error Resume Next
        strSQL = "SET INENTITY_INSERT " & TableName & " OFF"
        Dim cmd As New OleDbCommand(strSQL, SQLCnn)
        SQLCnn.Open()
        cmd.ExecuteNonQuery()
        SQLCnn.Close()
    End Sub

End Class
