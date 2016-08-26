Public Module RevaPrefs





    Public Property TrademarkDocuments As String
        Get
            Return My.Settings.TrademarkDocuments
        End Get
        Set(value As String)
            My.Settings.TrademarkDocuments = value
            My.Settings.Save()
        End Set
    End Property





End Module
