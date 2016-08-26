Public Class SQL

    Private Shared strSQL As String

    'The idea here is to take ugly-ass SQL statements we use frequently and store them in one place.
    'The function names match the old view names, now that we're reducing the number of views by
    'creating fewer views that contain all possible columns and selecting from them.

    Public Shared Function vwTrademarkMerge() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "MatterName," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "EntityType," & vbCrLf & _
        "CompanyAddressOne," & vbCrLf & _
        "CompanyAddressTwo," & vbCrLf & _
        "CompanyCity," & vbCrLf & _
        "CompanyStateProvince," & vbCrLf & _
        "CompanyPostalCode," & vbCrLf & _
        "CompanyCountry," & vbCrLf & _
        "CompanyPhone," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "RegistrationType," & vbCrLf & _
        "Status," & vbCrLf & _
        "GoodsServices," & vbCrLf & _
        "Disclaimers" & vbCrLf & _
        "from qvwTrademarks" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwTrademarkContactsMerge() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkContactID," & vbCrLf & _
        "TrademarkID," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "Salutation," & vbCrLf & _
        "FirstName," & vbCrLf & _
        "MiddleName," & vbCrLf & _
        "LastName," & vbCrLf & _
        "Suffix," & vbCrLf & _
        "GreetingLine," & vbCrLf & _
        "ContactTitle," & vbCrLf & _
        "PositionName AS TrademarkPosition," & vbCrLf & _
        "CompanyName AS ContactCompany," & vbCrLf & _
        "ContactAddressOne," & vbCrLf & _
        "ContactAddressTwo," & vbCrLf & _
        "ContactCity," & vbCrLf & _
        "ContactStateProvince," & vbCrLf & _
        "ContactPostalCode," & vbCrLf & _
        "ContactCountry," & vbCrLf & _
        "ContactPhone," & vbCrLf & _
        "ContactEmail" & vbCrLf & _
        "from qvwTrademarkContacts" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwTrademarkAlerts() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "DateName," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "Completed," & vbCrLf & _
        "TrademarkDate," & vbCrLf & _
        "DateID," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "ShowInAlerts," & vbCrLf & _
        "TrademarkDateID," & vbCrLf & _
        "RecurNumber," & vbCrLf & _
        "EmailSent," & vbCrLf & _
        "IsLocked," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "RegistrationType" & vbCrLf & _
        "from qvwTrademarkDates" & vbCrLf & _
        "Where IsAlert <> 0" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwTrademarkActionAlerts() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "TrademarkAction AS DateName," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "Completed," & vbCrLf & _
        "ActionDate AS TrademarkDate," & vbCrLf & _
        "0 AS DateID," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "0 AS ShowInAlerts," & vbCrLf & _
        "TrademarkActionID AS TrademarkDateID," & vbCrLf & _
        "0 AS RecurNumber," & vbCrLf & _
        "0 AS EmailSent," & vbCrLf & _
        "0 AS IsLocked," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "RegistrationType" & vbCrLf & _
        "from qvwTrademarkActions" & vbCrLf & _
        "Where IsAlert <> 0" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwReportTrademarks() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkID," & vbCrLf & _
        "RegTypeID," & vbCrLf & _
        "StatusID," & vbCrLf & _
        "FilingBasisID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "FileID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "CompanyAddressOne," & vbCrLf & _
        "CompanyAddressTwo," & vbCrLf & _
        "CompanyCity," & vbCrLf & _
        "CompanyStateProvince," & vbCrLf & _
        "CompanyPostalCode," & vbCrLf & _
        "CompanyCountry," & vbCrLf & _
        "CityStateZip," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "GoodsServices," & vbCrLf & _
        "Comments," & vbCrLf & _
        "Disclaimers," & vbCrLf & _
        "GraphicPath," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "Status," & vbCrLf & _
        "DateID," & vbCrLf & _
        "DateName," & vbCrLf & _
        "NoDay," & vbCrLf & _
        "ListOrder," & vbCrLf & _
        "TrademarkDate," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "Completed," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "RegistrationType," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "GraphicSizeToFit," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket" & vbCrLf & _
        "from qvwTrademarkDates" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwReportTrademarkAlertsPosition() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkDateID," & vbCrLf & _
        "TrademarkID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ListOrder," & vbCrLf & _
        "TrademarkDate," & vbCrLf & _
        "Completed," & vbCrLf & _
        "DateID," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "DateName," & vbCrLf & _
        "'' AS SubTitle," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "PositionID," & vbCrLf & _
        "ContactName," & vbCrLf & _
        "PositionName," & vbCrLf & _
        "ShowOnReports," & vbCrLf & _
        " FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "RegistrationType from qvwTrademarkDatesAndContacts" & vbCrLf & _
        "Where IsAlert <> 0 and " & vbCrLf & _
        "(ShowOnReports <> 0 or StatusID is null)" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwReportTrademarkActionAlertsPosition() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkActionID AS TrademarkDateID," & vbCrLf & _
        "TrademarkID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "0 AS ListOrder," & vbCrLf & _
        "ActionDate AS TrademarkDate," & vbCrLf & _
        "Completed," & vbCrLf & _
        "0 AS DateID," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "TrademarkAction AS DateName," & vbCrLf & _
        "'' AS SubTitle," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "PositionID," & vbCrLf & _
        "ContactName," & vbCrLf & _
        "PositionName," & vbCrLf & _
        "ShowOnReports," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "RegistrationType from qvwTrademarkActionsAndContacts" & vbCrLf & _
        "Where IsAlert <> 0 and " & vbCrLf & _
        "(ShowOnReports <> 0 or StatusID is null)" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwTrademarksList() As String
        On Error Resume Next
        strSQL = "SELECT distinct TrademarkID," & vbCrLf & _
        "TrademarkName," & vbCrLf & _
        "TrademarkType," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "Treaty," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "RegistrationNumber," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "IsTreaty," & vbCrLf & _
        "TreatyFilingID," & vbCrLf & _
        "Status," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "StatusID," & vbCrLf & _
        "FilingBasisID," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "CheckStatus," & vbCrLf & _
        "StatusCode" & vbCrLf & _
        "from qvwTrademarks"
        Return strSQL
    End Function

    Public Shared Function vwPatentMerge() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "MatterName," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "EntityType," & vbCrLf & _
        "CompanyAddressOne," & vbCrLf & _
        "CompanyAddressTwo," & vbCrLf & _
        "CompanyCity," & vbCrLf & _
        "CompanyStateProvince," & vbCrLf & _
        "CompanyPostalCode," & vbCrLf & _
        "CompanyCountry," & vbCrLf & _
        "CompanyPhone," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "PublicationNumber," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "Status," & vbCrLf & _
        "PatentType" & vbCrLf & _
        "from qvwPatents" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwPatentContactsMerge() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentContactID," & vbCrLf & _
        "PatentID," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "Salutation," & vbCrLf & _
        "FirstName," & vbCrLf & _
        "MiddleName," & vbCrLf & _
        "LastName," & vbCrLf & _
        "Suffix," & vbCrLf & _
        "GreetingLine," & vbCrLf & _
        "ContactTitle," & vbCrLf & _
        "PositionName AS PatentPosition," & vbCrLf & _
        "CompanyName AS ContactCompany," & vbCrLf & _
        "ContactAddressOne," & vbCrLf & _
        "ContactAddressTwo," & vbCrLf & _
        "ContactCity," & vbCrLf & _
        "ContactStateProvince," & vbCrLf & _
        "ContactPostalCode," & vbCrLf & _
        "ContactCountry," & vbCrLf & _
        "ContactPhone," & vbCrLf & _
        "ContactEmail" & vbCrLf & _
        "from qvwPatentContacts" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwReportPatents() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentID," & vbCrLf & _
        "PatentTypeID," & vbCrLf & _
        "StatusID," & vbCrLf & _
        "FilingBasisID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "FileID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "GraphicPath," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "CompanyAddressOne," & vbCrLf & _
        "CompanyAddressTwo," & vbCrLf & _
        "CityStateZip," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "Status," & vbCrLf & _
        "CompanyCountry," & vbCrLf & _
        "DateID," & vbCrLf & _
        "DateName," & vbCrLf & _
        "ListOrder," & vbCrLf & _
        "PatentDate," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "Completed," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "PatentType," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "Category," & vbCrLf & _
        "Subcategory," & vbCrLf & _
        "PublicationNumber" & vbCrLf & _
        "from qvwPatentDates" & vbCrLf
        Return strSQL

    End Function

    Public Shared Function vwPatentAlerts() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentDateID," & vbCrLf & _
        "PatentID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "DateName," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "Completed," & vbCrLf & _
        "PatentDate," & vbCrLf & _
        "DateID," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "RecurNumber," & vbCrLf & _
        "EmailSent," & vbCrLf & _
        "IsLocked," & vbCrLf & _
        "Status," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "PatentType" & vbCrLf & _
        "from qvwPatentDates" & vbCrLf & _
        "where IsAlert <> 0" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwPatentActionAlerts() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentActionID AS PatentDateID," & vbCrLf & _
        "PatentID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "PatentAction AS DateName," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "Completed," & vbCrLf & _
        "ActionDate AS PatentDate," & vbCrLf & _
        "0 AS DateID," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "0 AS RecurNumber," & vbCrLf & _
        "0 AS EmailSent," & vbCrLf & _
        "0 AS IsLocked," & vbCrLf & _
        "Status," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "PatentType" & vbCrLf & _
        "from qvwPatentActions" & vbCrLf & _
        "where IsAlert <> 0" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwReportPatentAlertsPosition() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentDateID," & vbCrLf & _
        "PatentID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "ListOrder," & vbCrLf & _
        "PatentDate," & vbCrLf & _
        "Completed," & vbCrLf & _
        "DateID," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "DateName," & vbCrLf & _
        "'' AS SubTitle," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "PositionID," & vbCrLf & _
        "ContactName," & vbCrLf & _
        "PositionName," & vbCrLf & _
        "ShowOnReports," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "PatentType" & vbCrLf & _
        "from qvwPatentDatesAndContacts" & vbCrLf & _
        "Where IsAlert <> 0 and " & vbCrLf & _
        "(ShowOnReports <> 0 or StatusID is null)" & vbCrLf
        Return strSQL
    End Function

    Public Shared Function vwReportPatentActionAlertsPosition() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentActionID AS PatentDateID," & vbCrLf & _
        "PatentID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "0 AS ListOrder," & vbCrLf & _
        "ActionDate AS PatentDate," & vbCrLf & _
        "Completed," & vbCrLf & _
        "0 AS DateID," & vbCrLf & _
        "IsAlert," & vbCrLf & _
        "PatentAction AS DateName," & vbCrLf & _
        "'' AS SubTitle," & vbCrLf & _
        "ContactID," & vbCrLf & _
        "PositionID," & vbCrLf & _
        "ContactName," & vbCrLf & _
        "PositionName," & vbCrLf & _
        "ShowOnReports," & vbCrLf & _
        "Status," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "PatentType" & vbCrLf & _
        "from qvwPatentActionsAndContacts" & vbCrLf & _
        "Where IsAlert <> 0 and " & vbCrLf & _
        "(ShowOnReports <> 0 or StatusID is null)" & vbCrLf

        Return strSQL
    End Function

    Public Shared Function vwPatentsList() As String
        On Error Resume Next
        strSQL = "SELECT distinct PatentID," & vbCrLf & _
        "PatentName," & vbCrLf & _
        "CompanyName," & vbCrLf & _
        "Jurisdiction," & vbCrLf & _
        "Treaty," & vbCrLf & _
        "ApplicationNumber," & vbCrLf & _
        "PatentNumber," & vbCrLf & _
        "OurDocket," & vbCrLf & _
        "ClientDocket," & vbCrLf & _
        "JurisdictionID," & vbCrLf & _
        "CompanyID," & vbCrLf & _
        "IsTreaty," & vbCrLf & _
        "FilingBasis," & vbCrLf & _
        "Status," & vbCrLf & _
        "FileNumber," & vbCrLf & _
        "TreatyFilingID," & vbCrLf & _
        "ParentPatentID," & vbCrLf & _
        "PatentType," & vbCrLf & _
        "StatusID," & vbCrLf & _
        "PatentTypeID" & vbCrLf & _
        "from qvwPatents" & vbCrLf

        Return strSQL
    End Function


End Class
