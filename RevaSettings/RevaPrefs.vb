Public Module RevaPrefs

    'To store user prefs separately so when I send an update to the program, we don't wipe out the preferences.
    ' This dll will be embedded in the program.


    Public Property AccessConnection As String
        Get
            Return My.Settings.AccessConnection
        End Get
        Set(value As String)
            My.Settings.AccessConnection = value
            My.Settings.Save()
        End Set
    End Property

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

    Public Property XLFitToPage As Boolean
        Get
            Return My.Settings.XLFitToPage
        End Get
        Set(value As Boolean)
            My.Settings.XLFitToPage = value
            My.Settings.Save()
        End Set
    End Property

    Public Property XLDatePrinted As Boolean
        Get
            Return My.Settings.XLDatePrinted
        End Get
        Set(value As Boolean)
            My.Settings.XLDatePrinted = value
            My.Settings.Save()
        End Set
    End Property

    Public Property XLPageNumbers As Boolean
        Get
            Return My.Settings.XLPageNumbers
        End Get
        Set(value As Boolean)
            My.Settings.XLPageNumbers = value
            My.Settings.Save()
        End Set
    End Property

    Public Property XLLandscape As Boolean
        Get
            Return My.Settings.XLLandscape
        End Get
        Set(value As Boolean)
            My.Settings.XLLandscape = value
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

    Public Property UseMergeHelper As Boolean
        Get
            Return My.Settings.UseMergeHelper
        End Get
        Set(value As Boolean)
            My.Settings.UseMergeHelper = value
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

    Public Property LastMergeType As Integer
        Get
            Return My.Settings.LastMergeType
        End Get
        Set(value As Integer)
            My.Settings.LastMergeType = value
            My.Settings.Save()
        End Set
    End Property

    Public Property XLHeaderRows As Integer
        Get
            Return My.Settings.XLHeaderRows
        End Get
        Set(value As Integer)
            My.Settings.XLHeaderRows = value
            My.Settings.Save()
        End Set
    End Property

    Public Property DateFromIndex As Integer
        Get
            Return My.Settings.DateFromIndex
        End Get
        Set(value As Integer)
            My.Settings.DateFromIndex = value
            My.Settings.Save()
        End Set
    End Property

    Public Property DateToIndex As Integer
        Get
            Return My.Settings.DateToIndex
        End Get
        Set(value As Integer)
            My.Settings.DateToIndex = value
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

    Public Property LastMergeWord As String
        Get
            Return My.Settings.LastMergeWord
        End Get
        Set(value As String)
            My.Settings.LastMergeWord = value
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

    Public Property LastMergeExcel As String
        Get
            Return My.Settings.LastMergeExcel
        End Get
        Set(value As String)
            My.Settings.LastMergeExcel = value
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

    Public Property LastMergeOutlook As String
        Get
            Return My.Settings.LastMergeOutlook
        End Get
        Set(value As String)
            My.Settings.LastMergeOutlook = value
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

    Public Property TrademarkListLayout As String
        Get
            Return My.Settings.TrademarkListLayout
        End Get
        Set(value As String)
            My.Settings.TrademarkListLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkEmailAlertLayout As String
        Get
            Return My.Settings.TrademarkEmailAlertLayout
        End Get
        Set(value As String)
            My.Settings.TrademarkEmailAlertLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentListLayout As String
        Get
            Return My.Settings.PatentListLayout
        End Get
        Set(value As String)
            My.Settings.PatentListLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentAlertLayout As String
        Get
            Return My.Settings.PatentAlertLayout
        End Get
        Set(value As String)
            My.Settings.PatentAlertLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentEmailAlertLayout As String
        Get
            Return My.Settings.PatentEmailAlertLayout
        End Get
        Set(value As String)
            My.Settings.PatentEmailAlertLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property TrademarkStatusLayout As String
        Get
            Return My.Settings.TrademarkStatusLayout
        End Get
        Set(value As String)
            My.Settings.TrademarkStatusLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property MarkGeneralReportLayout As String
        Get
            Return My.Settings.MarkGeneralReportLayout
        End Get
        Set(value As String)
            My.Settings.MarkGeneralReportLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property rptTrademarksListLayout As String
        Get
            Return My.Settings.rptTrademarksListLayout
        End Get
        Set(value As String)
            My.Settings.rptTrademarksListLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property rptTrademarksDatesLayout As String
        Get
            Return My.Settings.rptTrademarksDatesLayout
        End Get
        Set(value As String)
            My.Settings.rptTrademarksDatesLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property MarkExportExcelLayout As String
        Get
            Return My.Settings.MarkExportExcelLayout
        End Get
        Set(value As String)
            My.Settings.MarkExportExcelLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property MarkExportWordLayout As String
        Get
            Return My.Settings.MarkExportWordLayout
        End Get
        Set(value As String)
            My.Settings.MarkExportWordLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property rptPatentsListLayout As String
        Get
            Return My.Settings.rptPatentsListLayout
        End Get
        Set(value As String)
            My.Settings.rptPatentsListLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property rptPatentsDatesLayout As String
        Get
            Return My.Settings.rptPatentsDatesLayout
        End Get
        Set(value As String)
            My.Settings.rptPatentsDatesLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentExportWordLayout As String
        Get
            Return My.Settings.PatentExportWordLayout
        End Get
        Set(value As String)
            My.Settings.PatentExportWordLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentExportExcelLayout As String
        Get
            Return My.Settings.PatentExportExcelLayout
        End Get
        Set(value As String)
            My.Settings.PatentExportExcelLayout = value
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

    Public Property PatentGeneralReportLayout As String
        Get
            Return My.Settings.PatentGeneralReportLayout
        End Get
        Set(value As String)
            My.Settings.PatentGeneralReportLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property MarkNextDueDateLayout As String
        Get
            Return My.Settings.MarkNextDueDateLayout
        End Get
        Set(value As String)
            My.Settings.MarkNextDueDateLayout = value
            My.Settings.Save()
        End Set
    End Property

    Public Property PatentNextDueDateLayout As String
        Get
            Return My.Settings.PatentNextDueDateLayout
        End Get
        Set(value As String)
            My.Settings.PatentNextDueDateLayout = value
            My.Settings.Save()
        End Set
    End Property
End Module
