Public Class Globals

    Friend Shared TrademarkID As Integer
    Friend Shared TreatyFilingID As Integer
    Friend Shared PatentID As Integer
    Friend Shared CompanyID As Integer
    Friend Shared ContactID As Integer
    Friend Shared UserName As String
    Friend Shared OppositionID As Integer
    Friend Shared SecurityLevel As Integer
    Friend Shared PurchaseLevel As Integer = 1

    '1 = list, 2 = alerts, 3 = reports, 4 = company, 5 = Oppositions, 0 = new record
    Friend Shared NavigateMarksFrom As Integer = 1
    Friend Shared NavigatePatentsFrom As Integer = 1
    '1 = list, 2 = alerts, 3 = trademark, 0 = new record
    Friend Shared NavigateOppositionsFrom As Integer = 1

End Class
