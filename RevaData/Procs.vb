Imports System.Data.SqlClient
Imports VistaDB.Provider

Module Procs

    Public CurrentConnectionString As String = String.Empty

    Private Function IsVista() As Boolean
        If CurrentConnectionString.ToUpper().Contains("VDB5") Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "Stored Procedure Functions"

    Public Function GetSPDataSet(ByVal ProcName As String,
        Optional ByVal Param1 As String = "x", Optional ByVal Value1 As Object = Nothing,
        Optional ByVal Param2 As String = "x", Optional ByVal Value2 As Object = Nothing,
        Optional ByVal Param3 As String = "x", Optional ByVal Value3 As Object = Nothing,
        Optional ByVal Param4 As String = "x", Optional ByVal Value4 As Object = Nothing,
        Optional ByVal Param5 As String = "x", Optional ByVal Value5 As Object = Nothing,
        Optional ByVal Param6 As String = "x", Optional ByVal Value6 As Object = Nothing) As DataSet

        'returns a dataset based on a stored procedure

        On Error Resume Next
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
        Return ds
    End Function

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

        On Error Resume Next

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
        Optional ByVal Param10 As String = "x", Optional ByVal Value10 As Object = Nothing) As SqlDataReader

        'returns a data-reader based on a stored procedure; cannot be used for editing

        On Error Resume Next

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

        On Error Resume Next

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

        On Error Resume Next

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
    End Function

    Public Function RunSPTextResult(ByVal ProcName As String,
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

        On Error Resume Next

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

        Dim strResult As Integer
        Cnn.Open()
        strResult = cmd.ExecuteScalar()
        Cnn.Close()
        Return strResult

    End Function

#End Region

End Module
