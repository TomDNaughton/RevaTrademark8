Imports System.Data

Public Module GlobalTables

    Private dtTrademarkJurisdictions As DataTable
    Private dtPatentJurisdictions As DataTable

    Public ReadOnly Property tblTrademarkJurisdicitons As DataTable
        Get
            If dtTrademarkJurisdictions Is Nothing Then
                FillTrademarkJurisdictions()
            End If
            Return dtTrademarkJurisdictions
        End Get
    End Property

    Public Sub FillTrademarkJurisdictions()
        Try
            dtTrademarkJurisdictions = GetDataTable("Select JurisdictionID, Jurisdiction from tblJurisdictions where IsTrademark=1 Order by Jurisdiction")
        Catch ex As Exception

        End Try

    End Sub

End Module
