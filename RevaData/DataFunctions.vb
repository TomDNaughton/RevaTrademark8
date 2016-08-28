Public Module DataFunctions

    ' This dll is embedded in the RevaTrademark Program.  It provides nearly all get/update data functions.

    Public Property ConnectionString As String
        Get
            Return Procs.CurrentConnectionString
        End Get
        Set(value As String)
            Procs.CurrentConnectionString = value
        End Set
    End Property

    Public Function GetTrademarksList() As DataTable
        Try
            ConnectionString = "data source = 'RevaTrademark.vdb5'"
            Return Procs.GetSPDataTable("prd_recTrademarksList")

        Catch ex As Exception
            Return Nothing
        End Try

    End Function




End Module
