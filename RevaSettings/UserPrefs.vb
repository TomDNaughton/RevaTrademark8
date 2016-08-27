Public Module UserPrefs

    'To store user prefs separately so when I send an update to the program, we don't wipe out the preferences.
    ' This dll will be embedded in the program.

    Public Property SpellMonthMerge As Boolean
        Get
            Return My.Settings.SpellMonthMerge
        End Get
        Set(value As Boolean)
            My.Settings.SpellMonthMerge = value
            My.Settings.Save()
        End Set
    End Property

    Public Property OpenOnMarks As Boolean
        Get
            Return My.Settings.OpenOnMarks
        End Get
        Set(value As Boolean)
            My.Settings.OpenOnMarks = value
            My.Settings.Save()
        End Set
    End Property

    Public Property BlankDatesLast As Boolean
        Get
            Return My.Settings.BlankDatesLast
        End Get
        Set(value As Boolean)
            My.Settings.BlankDatesLast = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SavePassword As Boolean
        Get
            Return My.Settings.SavePassword
        End Get
        Set(value As Boolean)
            My.Settings.SavePassword = value
            My.Settings.Save()
        End Set
    End Property

    Public Property USADates As Boolean
        Get
            Return My.Settings.USADates
        End Get
        Set(value As Boolean)
            My.Settings.USADates = value
            My.Settings.Save()
        End Set
    End Property

    Public Property EmailHTML As Boolean
        Get
            Return My.Settings.EmailHTML
        End Get
        Set(value As Boolean)
            My.Settings.EmailHTML = value
            My.Settings.Save()
        End Set
    End Property

    Public Property ShowHoursExpenses As Boolean
        Get
            Return My.Settings.ShowHoursExpenses
        End Get
        Set(value As Boolean)
            My.Settings.ShowHoursExpenses = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SecurityType As Integer
        Get
            Return My.Settings.SecurityType
        End Get
        Set(value As Integer)
            My.Settings.SecurityType = value
            My.Settings.Save()
        End Set
    End Property



    Public Property OutlookAlertTime As Single
        Get
            Return My.Settings.OutlookAlertTime
        End Get
        Set(value As Single)
            My.Settings.OutlookAlertTime = value
            My.Settings.Save()
        End Set
    End Property

    Public Property ReportIcon As String
        Get
            Return My.Settings.ReportIcon
        End Get
        Set(value As String)
            My.Settings.ReportIcon = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentGraphicsDemo As String
        Get
            Return My.Settings.PatentGraphicsDemo
        End Get
        Set(value As String)
            My.Settings.PatentGraphicsDemo = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkGraphicsDemo As String
        Get
            Return My.Settings.TrademarkGraphicsDemo
        End Get
        Set(value As String)
            My.Settings.TrademarkGraphicsDemo = value
            My.Settings.Save()
        End Set
    End Property

    Public Property ReportIconDemo As String
        Get
            Return My.Settings.ReportIconDemo
        End Get
        Set(value As String)
            My.Settings.ReportIconDemo = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentDocumentsDemo As String
        Get
            Return My.Settings.PatentDocumentsDemo
        End Get
        Set(value As String)
            My.Settings.PatentDocumentsDemo = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkDocuments As String
        Get
            Return My.Settings.TrademarkDocuments
        End Get
        Set(value As String)
            My.Settings.TrademarkDocuments = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkDocumentsDemo As String
        Get
            Return My.Settings.TrademarkDocumentsDemo
        End Get
        Set(value As String)
            My.Settings.TrademarkDocumentsDemo = value
            My.Settings.Save()
        End Set
    End Property

    Public Property UserName As String
        Get
            Return My.Settings.UserName
        End Get
        Set(value As String)
            My.Settings.UserName = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentDocuments As String
        Get
            Return My.Settings.PatentDocuments
        End Get
        Set(value As String)
            My.Settings.PatentDocuments = value
            My.Settings.Save()
        End Set
    End Property

    Public Property DatabaseName As String
        Get
            Return My.Settings.DatabaseName
        End Get
        Set(value As String)
            My.Settings.DatabaseName = value
            My.Settings.Save()
        End Set
    End Property

    Public Property ServerName As String
        Get
            Return My.Settings.ServerName
        End Get
        Set(value As String)
            My.Settings.ServerName = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkGraphics As String
        Get
            Return My.Settings.TrademarkGraphics
        End Get
        Set(value As String)
            My.Settings.TrademarkGraphics = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentGraphics As String
        Get
            Return My.Settings.PatentGraphics
        End Get
        Set(value As String)
            My.Settings.PatentGraphics = value
            My.Settings.Save()
        End Set
    End Property

    Public Property LicenseKey As String
        Get
            Return My.Settings.LicenseKey
        End Get
        Set(value As String)
            My.Settings.LicenseKey = value
            My.Settings.Save()
        End Set
    End Property


    Public Property Password As String
        Get
            Return My.Settings.Password
        End Get
        Set(value As String)
            My.Settings.Password = value
            My.Settings.Save()
        End Set
    End Property


End Module
