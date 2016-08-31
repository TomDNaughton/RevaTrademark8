Imports System.Data.SqlClient
Imports VistaDB.Provider

Public Module Procs

    Public CurrentConnectionString As String = String.Empty
    Public VistaConnectionString As String = "data source = 'RevaTrademark.vdb5'"

    Private Function IsVista() As Boolean
        If CurrentConnectionString.ToUpper().Contains("VDB5") Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "Stored Procedure Functions"

    Public Function GetSPDataTable(ByVal ProcName As String,
        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataTable

        'returns a data table based on a stored procedure

        Try
            If IsVista() = False Then

                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param6, Value6))
                End If

                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0)
            End If

            If IsVista() = True Then

                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New VistaDBDataAdapter
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param6, Value6))
                End If

                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0)
            End If

            Return Nothing

        Catch ex As Exception
            Return Nothing
        End Try



    End Function

    Public Function GetSPDataRow(ByVal ProcName As String,
       Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
       Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
       Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
       Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
       Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
       Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataRow

        'returns a data row based on a stored procedure

        Try

            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param6, Value6))
                End If

                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0).Rows(0)
            End If


            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New VistaDBDataAdapter
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param6, Value6))
                End If

                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0).Rows(0)
            End If

        Catch ex As Exception
            Return Nothing
        End Try



    End Function

    Public Function GetSPDataReader(ByVal ProcName As String,
        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing,
        Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing,
        Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing,
        Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing,
        Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing) As Object

        'returns a data-reader based on a stored procedure; cannot be used for editing

        Try
            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Cnn.Open()

                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param10, Value10))
                End If

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Return dr
                Cnn.Close()
            End If

            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Cnn.Open()

                Dim dr As VistaDBDataReader
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param10, Value10))
                End If

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Return dr
                Cnn.Close()
            End If

            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try



    End Function

    Public Sub RunSP(ByVal ProcName As String,
        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing,
        Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing,
        Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing,
        Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing,
        Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing,
        Optional ByVal Param11 As String = "x", Optional ByVal Value11 As Object = Nothing,
        Optional ByVal Param12 As String = "x", Optional ByVal Value12 As Object = Nothing,
        Optional ByVal Param13 As String = "x", Optional ByVal Value13 As Object = Nothing,
        Optional ByVal Param14 As String = "x", Optional ByVal Value14 As Object = Nothing,
        Optional ByVal Param15 As String = "x", Optional ByVal Value15 As Object = Nothing,
        Optional ByVal Param16 As String = "x", Optional ByVal Value16 As Object = Nothing)

        'runs a stored procedure

        Try
            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param10, Value10))
                End If

                If Not (Value11 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param11, Value11))
                End If

                If Not (Value12 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param12, Value12))
                End If

                If Not (Value13 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param13, Value13))
                End If

                If Not (Value14 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param14, Value14))
                End If

                If Not (Value15 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param15, Value15))
                End If

                If Not (Value16 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param16, Value16))
                End If

                Cnn.Open()
                cmd.ExecuteNonQuery()
                Cnn.Close()
            End If

            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param10, Value10))
                End If

                If Not (Value11 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param11, Value11))
                End If

                If Not (Value12 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param12, Value12))
                End If

                If Not (Value13 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param13, Value13))
                End If

                If Not (Value14 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param14, Value14))
                End If

                If Not (Value15 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param15, Value15))
                End If

                If Not (Value16 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param16, Value16))
                End If

                Cnn.Open()
                cmd.ExecuteNonQuery()
                Cnn.Close()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Function RunSPWithResult(ByVal ProcName As String,
        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing,
        Optional ByVal Param7 As String = "x", Optional ByVal Value7 As Object = Nothing,
        Optional ByVal Param8 As String = "x", Optional ByVal Value8 As Object = Nothing,
        Optional ByVal Param9 As String = "x", Optional ByVal Value9 As Object = Nothing,
        Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing,
        Optional ByVal Param11 As String = "x", Optional ByVal Value11 As Object = Nothing,
        Optional ByVal Param12 As String = "x", Optional ByVal Value12 As Object = Nothing,
        Optional ByVal Param13 As String = "x", Optional ByVal Value13 As Object = Nothing,
        Optional ByVal Param14 As String = "x", Optional ByVal Value14 As Object = Nothing,
        Optional ByVal Param15 As String = "x", Optional ByVal Value15 As Object = Nothing,
        Optional ByVal Param16 As String = "x", Optional ByVal Value16 As Object = Nothing) As Integer

        'runs a stored procedure

        Try
            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param10, Value10))
                End If

                If Not (Value11 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param11, Value11))
                End If

                If Not (Value12 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param12, Value12))
                End If

                If Not (Value13 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param13, Value13))
                End If

                If Not (Value14 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param14, Value14))
                End If

                If Not (Value15 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param15, Value15))
                End If

                If Not (Value16 Is Nothing) Then
                    cmd.Parameters.Add(New SqlParameter(Param16, Value16))
                End If

                Dim i As Integer
                Cnn.Open()
                i = cmd.ExecuteScalar()
                Cnn.Close()
                Return i
            End If

            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = ProcName

                'add parameters if specified, calling function supplies named parameter and value ("@CompanyID",12)
                If Not (Value1 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param1, Value1))
                End If

                If Not (Value2 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param2, Value2))
                End If

                If Not (Value3 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param3, Value3))
                End If

                If Not (Value4 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param4, Value4))
                End If

                If Not (Value5 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param5, Value5))
                End If

                If Not (Value6 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param6, Value6))
                End If

                If Not (Value7 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param7, Value7))
                End If

                If Not (Value8 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param8, Value8))
                End If

                If Not (Value9 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param9, Value9))
                End If

                If Not (Value10 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param10, Value10))
                End If

                If Not (Value11 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param11, Value11))
                End If

                If Not (Value12 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param12, Value12))
                End If

                If Not (Value13 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param13, Value13))
                End If

                If Not (Value14 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param14, Value14))
                End If

                If Not (Value15 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param15, Value15))
                End If

                If Not (Value16 Is Nothing) Then
                    cmd.Parameters.Add(New VistaDBParameter(Param16, Value16))
                End If

                Dim i As Integer
                Cnn.Open()
                i = cmd.ExecuteScalar()
                Cnn.Close()
                Return i
            End If

            Return -1
        Catch ex As Exception
            Return -1
        End Try


    End Function

#End Region


#Region "SQL Statement Functions"

    Public Function GetDataTable(ByVal strSQL As String) As DataTable

        Try

            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandText = strSQL
                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0)
                ds.Dispose()
                da.Dispose()
                cmd.Dispose()
                Cnn.Dispose()
            End If

            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim ds As New DataSet
                Dim da As New VistaDBDataAdapter
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandText = strSQL
                da.SelectCommand = cmd
                da.Fill(ds)
                Return ds.Tables(0)
                ds.Dispose()
                da.Dispose()
                cmd.Dispose()
                Cnn.Dispose()
            End If

            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try


    End Function

    Public Function GetVistaTable(ByVal strSQL As String) As DataTable

        Try
            ' For when we absolutely, positively want to access the demo table only
            Dim Cnn As New VistaDBConnection
            Cnn.ConnectionString = VistaConnectionString
            Dim ds As New DataSet
            Dim da As New VistaDBDataAdapter
            Dim cmd As New VistaDBCommand

            cmd.Connection = Cnn
            cmd.CommandText = strSQL
            da.SelectCommand = cmd
            da.Fill(ds)
            Return ds.Tables(0)
            ds.Dispose()
            da.Dispose()
            cmd.Dispose()
            Cnn.Dispose()

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function DCount(ByVal ColumnName As String, ByVal TableName As String, ByVal Filter As String) As Integer
        Try
            'returns Count of columns found in table with a filtered sql statement
            If IsVista() = False Then
                Dim i As Integer, strSQL As String
                strSQL = "Select Count(" & ColumnName & ") from " & TableName & " WHERE " & Filter
                Dim cmd As New SqlCommand(strSQL, New SqlConnection(CurrentConnectionString))

                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()

                Return i
                cmd.Dispose()
            End If

            If IsVista() = True Then
                Dim i As Integer, strSQL As String
                strSQL = "Select Count(" & ColumnName & ") from " & TableName & " WHERE " & Filter
                Dim cmd As New VistaDBCommand(strSQL, New VistaDBConnection(CurrentConnectionString))

                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()

                Return i
                cmd.Dispose()
            End If

            Return -1
        Catch ex As Exception
            Return -1
        End Try


    End Function

    Public Function DLookup(ByVal ColumnName As String, ByVal TableName As String, Optional ByVal Filter As String = "") As Integer

        Try
            Dim i As Integer, strSQL As String
            strSQL = "Select " & ColumnName & " from " & TableName

            If Filter <> "" Then
                strSQL = strSQL & " WHERE " & Filter
            End If

            If IsVista() = False Then
                Dim cmd As New SqlCommand(strSQL, New SqlConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()

                Return i
                cmd.Dispose()
            End If

            If IsVista() = True Then
                Dim cmd As New VistaDBCommand(strSQL, New VistaDBConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()

                Return i
                cmd.Dispose()
            End If

            Return -1
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function DMax(ByVal ColumnName As String, ByVal TableName As String, Optional ByVal Filter As String = "") As Integer
        Try

            Dim i As Integer, strSQL As String

            If Filter.Trim() <> String.Empty Then
                strSQL = "Select Max(" & ColumnName & ") from " & TableName & " where " & Filter
            Else
                strSQL = "Select Max(" & ColumnName & ") from " & TableName
            End If

            If IsVista() = False Then
                Dim cmd As New SqlCommand(strSQL, New SqlConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()
                Return i
                cmd.Dispose()
            End If

            If IsVista() = True Then
                Dim cmd As New VistaDBCommand(strSQL, New VistaDBConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = Nz(cmd.ExecuteScalar(), 0)
                cmd.Connection.Close()
                Return i
                cmd.Dispose()
            End If

            Return -1
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function DMin(ByVal ColumnName As String, ByVal TableName As String, Optional ByVal Filter As String = "") As Integer
        Try
            Dim i As Integer, strSQL As String

            If Filter.Trim() <> String.Empty Then
                strSQL = "Select Min(" & ColumnName & ") from " & TableName & " where " & Filter
            Else
                strSQL = "Select Min(" & ColumnName & ") from " & TableName
            End If

            If IsVista() = False Then
                Dim cmd As New SqlCommand(strSQL, New SqlConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = cmd.ExecuteScalar()
                cmd.Connection.Close()
                Return i
                cmd.Dispose()
            End If

            If IsVista() = True Then
                Dim cmd As New VistaDBCommand(strSQL, New VistaDBConnection(CurrentConnectionString))
                cmd.Connection.Open()
                i = cmd.ExecuteScalar()
                cmd.Connection.Close()
                Return i
                cmd.Dispose()
            End If

            Return -1
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function RunSQL(ByVal strSQL As String) As Boolean
        Try
            If IsVista() = False Then
                Dim Cnn As New SqlConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New SqlCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL

                Cnn.Open()
                cmd.ExecuteNonQuery()
                Cnn.Close()

                cmd.Dispose()
                Cnn.Dispose()
                Return True
            End If

            If IsVista() = True Then
                Dim Cnn As New VistaDBConnection
                Cnn.ConnectionString = CurrentConnectionString
                Dim cmd As New VistaDBCommand

                cmd.Connection = Cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL

                Cnn.Open()
                cmd.ExecuteNonQuery()
                Cnn.Close()

                cmd.Dispose()
                Cnn.Dispose()
                Return True
            End If

            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RunVistaSQL(ByVal strSQL As String) As Boolean
        Try
            ' for when we absolutely, positively want to run it against the Vista DB.

            Dim Cnn As New VistaDBConnection
            Cnn.ConnectionString = VistaConnectionString
            Dim cmd As New VistaDBCommand

            cmd.Connection = Cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL

            Cnn.Open()
            cmd.ExecuteNonQuery()
            Cnn.Close()

            cmd.Dispose()
            Cnn.Dispose()
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function



    Private Function Nz(ByVal Value As Object, ByVal ValueIfNull As Object) As Object
        On Error Resume Next
        If Value Is DBNull.Value Then
            Nz = ValueIfNull
        Else
            Nz = Value
        End If
    End Function

#End Region

End Module
