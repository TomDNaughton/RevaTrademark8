Imports System.Data

Public Module GlobalTables

    ' Not going to bother with stored procedures for these itty-bitty tables that rarely need updating.

    Private dtTrademarkJurisdictions As DataTable
    Private dtPatentJurisdictions As DataTable
    Private dtCompaniesList As DataTable
    Private dtContactsList As DataTable
    Private dtTrademarkFilingBasis As DataTable
    Private dtPatentFilingBasis As DataTable
    Private dtTrademarkStatus As DataTable
    Private dtPatentStatus As DataTable
    Private dtTrademarkTypes As DataTable
    Private dtPatentTypes As DataTable

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

    Public ReadOnly Property tblPatentJurisdicitons As DataTable
        Get
            If dtPatentJurisdictions Is Nothing Then
                FillPatentJurisdictions()
            End If
            Return dtPatentJurisdictions
        End Get
    End Property

    Public Sub FillPatentJurisdictions()
        Try
            dtPatentJurisdictions = GetDataTable("Select JurisdictionID, Jurisdiction from tblJurisdictions where IsPatent=1 Order by Jurisdiction")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblCompaniesList As DataTable
        Get
            If dtCompaniesList Is Nothing Then
                FillCompaniesList()
            End If
            Return dtCompaniesList
        End Get
    End Property

    Public Sub FillCompaniesList()
        Try
            dtCompaniesList = GetDataTable("Select CompanyID, CompanyName from tblCompanies order by CompanyName")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblContactsList As DataTable
        Get
            If dtContactsList Is Nothing Then
                FillContactsList()
            End If
            Return dtContactsList
        End Get
    End Property

    Public Sub FillContactsList()
        Try
            dtContactsList = GetDataTable("Select distinct ContactID, ContactName, CompanyName from qvwContactsAndCompanies order by ContactName")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblTrademarkFilingBasis As DataTable
        Get
            If dtTrademarkFilingBasis Is Nothing Then
                FillTrademarkFilingBasis()
            End If
            Return dtTrademarkFilingBasis
        End Get
    End Property

    Public Sub FillTrademarkFilingBasis()
        Try
            dtTrademarkFilingBasis = GetDataTable("Select FilingBasisID, FilingBasis, IsTreaty from tblFilingBasis Order by FilingBasisID")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblPatentFilingBasis As DataTable
        Get
            If dtPatentFilingBasis Is Nothing Then
                FillPatentFilingBasis()
            End If
            Return dtPatentFilingBasis
        End Get
    End Property

    Public Sub FillPatentFilingBasis()
        Try
            dtPatentFilingBasis = GetDataTable("Select FilingBasisID, FilingBasis from tblPatentFilingBasis Order by FilingBasisID")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblTrademarkStatus As DataTable
        Get
            If dtTrademarkStatus Is Nothing Then
                FillTrademarkStatus()
            End If
            Return dtTrademarkStatus
        End Get
    End Property

    Public Sub FillTrademarkStatus()
        Try
            dtTrademarkStatus = GetDataTable("Select StatusID, Status from tblStatus where IsTrademark =1 Order by Status")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblPatentStatus As DataTable
        Get
            If dtPatentStatus Is Nothing Then
                FillPatentStatus()
            End If
            Return dtPatentStatus
        End Get
    End Property

    Public Sub FillPatentStatus()
        Try
            dtPatentStatus = GetDataTable("Select StatusID, Status from tblStatus where IsPatent =1 Order by Status")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblTrademarkTypes As DataTable
        Get
            If dtTrademarkTypes Is Nothing Then
                FillTrademarkTypes()
            End If
            Return dtTrademarkTypes
        End Get
    End Property

    Public Sub FillTrademarkTypes()
        Try
            dtTrademarkTypes = GetDataTable("Select TrademarkTypeID, TrademarkType from tblTrademarkTypes Order by TrademarkType")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property tblPatentTypes As DataTable
        Get
            If dtPatentTypes Is Nothing Then
                FillPatentTypes()
            End If
            Return dtPatentTypes
        End Get
    End Property

    Public Sub FillPatentTypes()
        Try
            dtPatentTypes = GetDataTable("Select PatentTypeID, PatentType, IsTreaty from tblPatentTypes order by PatentTypeID")
        Catch ex As Exception

        End Try
    End Sub

End Module
