Imports System.Data.SqlClient
Imports VistaDB.Provider

Public Class RecordSet

    Public Table As DataTable
    Public strSQL As String
    Public CurrentRow As DataRow
    Private DSet As New DataSet

    Private SqlAdapter As SqlDataAdapter
    Private SqlBuilder As SqlCommandBuilder
    Private SqlCnn As New SqlConnection

    Private VistaAdapter As VistaDBDataAdapter
    Private VistaBuilder As VistaDBCommandBuilder
    Private VistaCnn As New VistaDBConnection

    Private Function IsVista() As Boolean
        If CurrentConnectionString.ToUpper().Contains("VDB5") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Connect()
        Try
            If IsVista() = False Then
                SqlCnn.ConnectionString = CurrentConnectionString
                SqlAdapter = New SqlDataAdapter(strSQL, SqlCnn)
                SqlBuilder = New SqlCommandBuilder(SqlAdapter)
                SqlAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            End If

            If IsVista() = True Then
                VistaCnn.ConnectionString = CurrentConnectionString
                VistaAdapter = New VistaDBDataAdapter(strSQL, VistaCnn)
                VistaBuilder = New VistaDBCommandBuilder(VistaAdapter)
                VistaAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ConnectDemo()
        Try
            VistaCnn.ConnectionString = VistaConnectionString
            VistaAdapter = New VistaDBDataAdapter(strSQL, VistaCnn)
            VistaBuilder = New VistaDBCommandBuilder(VistaAdapter)
            VistaAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception

        End Try
    End Sub


    Public Sub GetRecords()
        Try
            DSet.Tables.Clear()

            If IsVista() = False Then
                SqlAdapter.Fill(DSet, "tblTable")
            End If

            If IsVista() = True Then
                VistaAdapter.Fill(DSet, "tblTable")
            End If

            Table = DSet.Tables(0)
            If Table.Rows.Count > 0 Then
                CurrentRow = Table.Rows(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddRow()
        Try
            Table.Rows.Add()
            CurrentRow = Table.Rows(Table.Rows.Count - 1)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetFromSQL(ByVal SQL As String)
        Try
            strSQL = SQL
            Connect()
            GetRecords()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetFromDemo(ByVal SQL As String)
        Try
            strSQL = SQL
            ConnectDemo()
            GetRecords()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Update()
        Try
            If Not (Me.Table Is Nothing) Then
                If DSet.HasChanges = True Then
                    If IsVista() = False Then
                        SqlAdapter.Update(Table)
                    End If
                    If IsVista() = True Then
                        VistaAdapter.Update(Table)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function RecordExists(ByVal strFilter) As Boolean
        Try
            'to see if a record exists, filter and check results
            Dim dr As DataRow
            dr = Table.Select(strFilter)(0)  'zero gets first row only
            If (dr Is Nothing) Then
                Return False
            Else
                dr = Nothing
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
