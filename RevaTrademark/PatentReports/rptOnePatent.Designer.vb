<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptOnePatent
    Inherits DataDynamics.ActiveReports.ActiveReport3

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents DateDetail As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOnePatent))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.DateDetail = New DataDynamics.ActiveReports.Detail
        Me.DateLabel = New DataDynamics.ActiveReports.TextBox
        Me.PatentDate = New DataDynamics.ActiveReports.TextBox
        Me.MonthYear = New DataDynamics.ActiveReports.TextBox
        Me.Completed = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.PatentIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.PatentName = New DataDynamics.ActiveReports.TextBox
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtAddressOne1 = New DataDynamics.ActiveReports.TextBox
        Me.txtAddressTwo1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCityStateZip1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCountry1 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.FileNumber = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.ApplicationNumber = New DataDynamics.ActiveReports.TextBox
        Me.PatentNumber = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.PatentType = New DataDynamics.ActiveReports.TextBox
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Status = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.FilingBasis = New DataDynamics.ActiveReports.TextBox
        Me.picGraphic = New DataDynamics.ActiveReports.Picture
        Me.subrptPatentClasses = New DataDynamics.ActiveReports.SubReport
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.OurDocket = New DataDynamics.ActiveReports.TextBox
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.ClientDocket = New DataDynamics.ActiveReports.TextBox
        Me.PatentIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.subrptPatentActions = New DataDynamics.ActiveReports.SubReport
        Me.FooterLine = New DataDynamics.ActiveReports.Line
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressOne1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressTwo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCityStateZip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCountry1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilingBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OurDocket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientDocket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label40, Me.ReportGraphic, Me.Line1})
        Me.PageHeader1.Height = 0.7083333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Label40
        '
        Me.Label40.Border.BottomColor = System.Drawing.Color.Black
        Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.LeftColor = System.Drawing.Color.Black
        Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.RightColor = System.Drawing.Color.Black
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.TopColor = System.Drawing.Color.Black
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Height = 0.3541667!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 0.0!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "color: Black; text-align: left; font-weight: bold; font-style: italic; background" & _
            "-color: White; font-size: 20pt; font-family: Times New Roman; "
        Me.Label40.Tag = ""
        Me.Label40.Text = "Patent Record"
        Me.Label40.Top = 0.0!
        Me.Label40.Width = 4.583333!
        '
        'ReportGraphic
        '
        Me.ReportGraphic.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportGraphic.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportGraphic.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportGraphic.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportGraphic.Border.RightColor = System.Drawing.Color.Black
        Me.ReportGraphic.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportGraphic.Border.TopColor = System.Drawing.Color.Black
        Me.ReportGraphic.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportGraphic.Height = 0.5833333!
        Me.ReportGraphic.Image = CType(resources.GetObject("ReportGraphic.Image"), System.Drawing.Image)
        Me.ReportGraphic.ImageData = CType(resources.GetObject("ReportGraphic.ImageData"), System.IO.Stream)
        Me.ReportGraphic.Left = 5.625!
        Me.ReportGraphic.LineWeight = 0.0!
        Me.ReportGraphic.Name = "ReportGraphic"
        Me.ReportGraphic.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopRight
        Me.ReportGraphic.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.ReportGraphic.Top = 0.0!
        Me.ReportGraphic.Width = 1.791667!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Tag = ""
        Me.Line1.Top = 0.625!
        Me.Line1.Width = 9.791667!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.791667!
        Me.Line1.Y1 = 0.625!
        Me.Line1.Y2 = 0.625!
        '
        'DateDetail
        '
        Me.DateDetail.ColumnSpacing = 0.0!
        Me.DateDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.DateLabel, Me.PatentDate, Me.MonthYear, Me.Completed})
        Me.DateDetail.Height = 0.2083333!
        Me.DateDetail.Name = "DateDetail"
        '
        'DateLabel
        '
        Me.DateLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.DateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.DateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateLabel.Border.RightColor = System.Drawing.Color.Black
        Me.DateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateLabel.Border.TopColor = System.Drawing.Color.Black
        Me.DateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateLabel.DataField = "DateName"
        Me.DateLabel.Height = 0.2083333!
        Me.DateLabel.Left = 0.0!
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Style = "color: Black; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.DateLabel.Tag = ""
        Me.DateLabel.Text = "DateName"
        Me.DateLabel.Top = 0.0!
        Me.DateLabel.Width = 2.625!
        '
        'PatentDate
        '
        Me.PatentDate.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentDate.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentDate.Border.RightColor = System.Drawing.Color.Black
        Me.PatentDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentDate.Border.TopColor = System.Drawing.Color.Black
        Me.PatentDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentDate.DataField = "PatentDate"
        Me.PatentDate.Height = 0.2083333!
        Me.PatentDate.Left = 2.75!
        Me.PatentDate.Name = "PatentDate"
        Me.PatentDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.PatentDate.Tag = ""
        Me.PatentDate.Text = "PatentDate"
        Me.PatentDate.Top = 0.0!
        Me.PatentDate.Width = 0.9583333!
        '
        'MonthYear
        '
        Me.MonthYear.Border.BottomColor = System.Drawing.Color.Black
        Me.MonthYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.LeftColor = System.Drawing.Color.Black
        Me.MonthYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.RightColor = System.Drawing.Color.Black
        Me.MonthYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.TopColor = System.Drawing.Color.Black
        Me.MonthYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.DataField = "TrademarkDate"
        Me.MonthYear.Height = 0.2083333!
        Me.MonthYear.Left = 2.75!
        Me.MonthYear.Name = "MonthYear"
        Me.MonthYear.OutputFormat = resources.GetString("MonthYear.OutputFormat")
        Me.MonthYear.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.MonthYear.Tag = ""
        Me.MonthYear.Text = "MonthYear"
        Me.MonthYear.Top = 0.0!
        Me.MonthYear.Width = 1.0!
        '
        'Completed
        '
        Me.Completed.Border.BottomColor = System.Drawing.Color.Black
        Me.Completed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.LeftColor = System.Drawing.Color.Black
        Me.Completed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.RightColor = System.Drawing.Color.Black
        Me.Completed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.TopColor = System.Drawing.Color.Black
        Me.Completed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.DataField = "Completed"
        Me.Completed.Height = 0.2083333!
        Me.Completed.Left = 3.791667!
        Me.Completed.Name = "Completed"
        Me.Completed.Style = ""
        Me.Completed.Text = ""
        Me.Completed.Top = 0.0!
        Me.Completed.Width = 0.2916667!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.RightColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.TopColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.FormatString = "Page{PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.2083333!
        Me.ReportInfo1.Left = 2.583333!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "text-align: center; "
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 2.333333!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.01041667!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'PatentIDHeader
        '
        Me.PatentIDHeader.CanShrink = True
        Me.PatentIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PatentName, Me.txtCompanyName1, Me.txtAddressOne1, Me.txtAddressTwo1, Me.txtCityStateZip1, Me.txtCountry1, Me.Label1, Me.Label2, Me.Label3, Me.FileNumber, Me.Label4, Me.Jurisdiction, Me.Label5, Me.ApplicationNumber, Me.PatentNumber, Me.Label6, Me.Label7, Me.PatentType, Me.Label8, Me.Status, Me.Label9, Me.FilingBasis, Me.picGraphic, Me.subrptPatentClasses, Me.Label13, Me.Line2, Me.Label14, Me.OurDocket, Me.Label15, Me.ClientDocket})
        Me.PatentIDHeader.DataField = "PatentID"
        Me.PatentIDHeader.Height = 3.40625!
        Me.PatentIDHeader.Name = "PatentIDHeader"
        Me.PatentIDHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before
        '
        'PatentName
        '
        Me.PatentName.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentName.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentName.Border.RightColor = System.Drawing.Color.Black
        Me.PatentName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentName.Border.TopColor = System.Drawing.Color.Black
        Me.PatentName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentName.CanShrink = True
        Me.PatentName.DataField = "PatentName"
        Me.PatentName.Height = 0.2083333!
        Me.PatentName.Left = 1.583333!
        Me.PatentName.Name = "PatentName"
        Me.PatentName.Style = "font-weight: bold; font-size: 9pt; "
        Me.PatentName.Text = "PatentName"
        Me.PatentName.Top = 0.0!
        Me.PatentName.Width = 5.5!
        '
        'txtCompanyName1
        '
        Me.txtCompanyName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCompanyName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompanyName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCompanyName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompanyName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCompanyName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompanyName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCompanyName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompanyName1.CanShrink = True
        Me.txtCompanyName1.DataField = "CompanyName"
        Me.txtCompanyName1.Height = 0.2083333!
        Me.txtCompanyName1.Left = 1.583333!
        Me.txtCompanyName1.Name = "txtCompanyName1"
        Me.txtCompanyName1.Style = "font-size: 9pt; "
        Me.txtCompanyName1.Text = "txtCompanyName1"
        Me.txtCompanyName1.Top = 0.2083333!
        Me.txtCompanyName1.Width = 2.833333!
        '
        'txtAddressOne1
        '
        Me.txtAddressOne1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAddressOne1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressOne1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAddressOne1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressOne1.Border.RightColor = System.Drawing.Color.Black
        Me.txtAddressOne1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressOne1.Border.TopColor = System.Drawing.Color.Black
        Me.txtAddressOne1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressOne1.CanShrink = True
        Me.txtAddressOne1.DataField = "CompanyAddressOne"
        Me.txtAddressOne1.Height = 0.2083333!
        Me.txtAddressOne1.Left = 1.583333!
        Me.txtAddressOne1.Name = "txtAddressOne1"
        Me.txtAddressOne1.Style = "font-size: 9pt; "
        Me.txtAddressOne1.Text = "txtAddressOne1"
        Me.txtAddressOne1.Top = 0.4166667!
        Me.txtAddressOne1.Width = 2.833333!
        '
        'txtAddressTwo1
        '
        Me.txtAddressTwo1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAddressTwo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressTwo1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAddressTwo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressTwo1.Border.RightColor = System.Drawing.Color.Black
        Me.txtAddressTwo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressTwo1.Border.TopColor = System.Drawing.Color.Black
        Me.txtAddressTwo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAddressTwo1.CanShrink = True
        Me.txtAddressTwo1.DataField = "CompanyAddressTwo"
        Me.txtAddressTwo1.Height = 0.2083333!
        Me.txtAddressTwo1.Left = 1.583333!
        Me.txtAddressTwo1.Name = "txtAddressTwo1"
        Me.txtAddressTwo1.Style = "font-size: 9pt; "
        Me.txtAddressTwo1.Text = "txtAddressTwo1"
        Me.txtAddressTwo1.Top = 0.625!
        Me.txtAddressTwo1.Width = 2.833333!
        '
        'txtCityStateZip1
        '
        Me.txtCityStateZip1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCityStateZip1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCityStateZip1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCityStateZip1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCityStateZip1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCityStateZip1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCityStateZip1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCityStateZip1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCityStateZip1.CanShrink = True
        Me.txtCityStateZip1.DataField = "CityStateZip"
        Me.txtCityStateZip1.Height = 0.2083333!
        Me.txtCityStateZip1.Left = 1.583333!
        Me.txtCityStateZip1.Name = "txtCityStateZip1"
        Me.txtCityStateZip1.Style = "font-size: 9pt; "
        Me.txtCityStateZip1.Text = "txtCityStateZip1"
        Me.txtCityStateZip1.Top = 0.8333333!
        Me.txtCityStateZip1.Width = 2.833333!
        '
        'txtCountry1
        '
        Me.txtCountry1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCountry1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCountry1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCountry1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCountry1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCountry1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCountry1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCountry1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCountry1.CanShrink = True
        Me.txtCountry1.DataField = "CompanyCountry"
        Me.txtCountry1.Height = 0.2083333!
        Me.txtCountry1.Left = 1.583333!
        Me.txtCountry1.Name = "txtCountry1"
        Me.txtCountry1.Style = "font-size: 9pt; "
        Me.txtCountry1.Text = "txtCountry1"
        Me.txtCountry1.Top = 1.041667!
        Me.txtCountry1.Width = 2.833333!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.2083333!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.291667!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label1.Text = "Patent:"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.25!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.2083333!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.291667!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label2.Text = "Owner:"
        Me.Label2.Top = 0.2083333!
        Me.Label2.Width = 1.25!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.2083333!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.291667!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "File Number:"
        Me.Label3.Top = 1.25!
        Me.Label3.Width = 1.25!
        '
        'FileNumber
        '
        Me.FileNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.FileNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FileNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.FileNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FileNumber.Border.RightColor = System.Drawing.Color.Black
        Me.FileNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FileNumber.Border.TopColor = System.Drawing.Color.Black
        Me.FileNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FileNumber.CanShrink = True
        Me.FileNumber.DataField = "FileNumber"
        Me.FileNumber.Height = 0.2083333!
        Me.FileNumber.Left = 1.583333!
        Me.FileNumber.Name = "FileNumber"
        Me.FileNumber.Style = "font-size: 9pt; "
        Me.FileNumber.Text = "fileNumber"
        Me.FileNumber.Top = 1.25!
        Me.FileNumber.Width = 2.833333!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.2083333!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.291667!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Jurisdiction:"
        Me.Label4.Top = 1.458333!
        Me.Label4.Width = 1.25!
        '
        'Jurisdiction
        '
        Me.Jurisdiction.Border.BottomColor = System.Drawing.Color.Black
        Me.Jurisdiction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.LeftColor = System.Drawing.Color.Black
        Me.Jurisdiction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.RightColor = System.Drawing.Color.Black
        Me.Jurisdiction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.TopColor = System.Drawing.Color.Black
        Me.Jurisdiction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.CanShrink = True
        Me.Jurisdiction.DataField = "Jurisdiction"
        Me.Jurisdiction.Height = 0.2083333!
        Me.Jurisdiction.Left = 1.583333!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "font-size: 9pt; "
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 1.458333!
        Me.Jurisdiction.Width = 2.833333!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.2083333!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.291667!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label5.Text = "Application:"
        Me.Label5.Top = 1.666667!
        Me.Label5.Width = 1.25!
        '
        'ApplicationNumber
        '
        Me.ApplicationNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.ApplicationNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.ApplicationNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.RightColor = System.Drawing.Color.Black
        Me.ApplicationNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.TopColor = System.Drawing.Color.Black
        Me.ApplicationNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.CanShrink = True
        Me.ApplicationNumber.DataField = "ApplicationNumber"
        Me.ApplicationNumber.Height = 0.2083333!
        Me.ApplicationNumber.Left = 1.583333!
        Me.ApplicationNumber.Name = "ApplicationNumber"
        Me.ApplicationNumber.Style = "font-size: 9pt; "
        Me.ApplicationNumber.Text = "ApplicationNumber"
        Me.ApplicationNumber.Top = 1.666667!
        Me.ApplicationNumber.Width = 2.833333!
        '
        'PatentNumber
        '
        Me.PatentNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentNumber.Border.RightColor = System.Drawing.Color.Black
        Me.PatentNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentNumber.Border.TopColor = System.Drawing.Color.Black
        Me.PatentNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentNumber.CanShrink = True
        Me.PatentNumber.DataField = "PatentNumber"
        Me.PatentNumber.Height = 0.2083333!
        Me.PatentNumber.Left = 1.583333!
        Me.PatentNumber.Name = "PatentNumber"
        Me.PatentNumber.Style = "font-size: 9pt; "
        Me.PatentNumber.Text = "PatentNumber"
        Me.PatentNumber.Top = 1.875!
        Me.PatentNumber.Width = 2.833333!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.2083333!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.291667!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label6.Text = "Patent Number:"
        Me.Label6.Top = 1.875!
        Me.Label6.Width = 1.25!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.2083333!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.291667!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label7.Text = "Patent Type:"
        Me.Label7.Top = 2.5!
        Me.Label7.Width = 1.25!
        '
        'PatentType
        '
        Me.PatentType.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentType.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentType.Border.RightColor = System.Drawing.Color.Black
        Me.PatentType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentType.Border.TopColor = System.Drawing.Color.Black
        Me.PatentType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentType.CanShrink = True
        Me.PatentType.DataField = "PatentType"
        Me.PatentType.Height = 0.2083333!
        Me.PatentType.Left = 1.583333!
        Me.PatentType.Name = "PatentType"
        Me.PatentType.Style = "font-size: 9pt; "
        Me.PatentType.Text = "PatentType"
        Me.PatentType.Top = 2.5!
        Me.PatentType.Width = 2.833333!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.2083333!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.291667!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label8.Text = "Status:"
        Me.Label8.Top = 2.708334!
        Me.Label8.Width = 1.25!
        '
        'Status
        '
        Me.Status.Border.BottomColor = System.Drawing.Color.Black
        Me.Status.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.LeftColor = System.Drawing.Color.Black
        Me.Status.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.RightColor = System.Drawing.Color.Black
        Me.Status.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.TopColor = System.Drawing.Color.Black
        Me.Status.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.CanShrink = True
        Me.Status.DataField = "Status"
        Me.Status.Height = 0.2083333!
        Me.Status.Left = 1.583333!
        Me.Status.Name = "Status"
        Me.Status.Style = "font-size: 9pt; "
        Me.Status.Text = "Status"
        Me.Status.Top = 2.708334!
        Me.Status.Width = 2.833333!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.2083333!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.291667!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label9.Text = "Filing Basis:"
        Me.Label9.Top = 2.916667!
        Me.Label9.Width = 1.25!
        '
        'FilingBasis
        '
        Me.FilingBasis.Border.BottomColor = System.Drawing.Color.Black
        Me.FilingBasis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingBasis.Border.LeftColor = System.Drawing.Color.Black
        Me.FilingBasis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingBasis.Border.RightColor = System.Drawing.Color.Black
        Me.FilingBasis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingBasis.Border.TopColor = System.Drawing.Color.Black
        Me.FilingBasis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingBasis.CanShrink = True
        Me.FilingBasis.DataField = "FilingBasis"
        Me.FilingBasis.Height = 0.2083333!
        Me.FilingBasis.Left = 1.583333!
        Me.FilingBasis.Name = "FilingBasis"
        Me.FilingBasis.Style = "font-size: 9pt; "
        Me.FilingBasis.Text = "FilingBasis"
        Me.FilingBasis.Top = 2.916667!
        Me.FilingBasis.Width = 2.833333!
        '
        'picGraphic
        '
        Me.picGraphic.Border.BottomColor = System.Drawing.Color.Black
        Me.picGraphic.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picGraphic.Border.LeftColor = System.Drawing.Color.Black
        Me.picGraphic.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picGraphic.Border.RightColor = System.Drawing.Color.Black
        Me.picGraphic.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picGraphic.Border.TopColor = System.Drawing.Color.Black
        Me.picGraphic.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picGraphic.Height = 2.458333!
        Me.picGraphic.Image = Nothing
        Me.picGraphic.ImageData = Nothing
        Me.picGraphic.Left = 4.5!
        Me.picGraphic.LineWeight = 0.0!
        Me.picGraphic.Name = "picGraphic"
        Me.picGraphic.Top = 0.4166667!
        Me.picGraphic.Width = 2.875!
        '
        'subrptPatentClasses
        '
        Me.subrptPatentClasses.Border.BottomColor = System.Drawing.Color.Black
        Me.subrptPatentClasses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentClasses.Border.LeftColor = System.Drawing.Color.Black
        Me.subrptPatentClasses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentClasses.Border.RightColor = System.Drawing.Color.Black
        Me.subrptPatentClasses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentClasses.Border.TopColor = System.Drawing.Color.Black
        Me.subrptPatentClasses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentClasses.CloseBorder = False
        Me.subrptPatentClasses.Height = 0.1666667!
        Me.subrptPatentClasses.Left = 1.583333!
        Me.subrptPatentClasses.Name = "subrptPatentClasses"
        Me.subrptPatentClasses.Report = Nothing
        Me.subrptPatentClasses.ReportName = "subrptPatentClasses"
        Me.subrptPatentClasses.Top = 3.125!
        Me.subrptPatentClasses.Width = 2.875!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Height = 0.2083333!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.2916667!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label13.Text = "Classes:"
        Me.Label13.Top = 3.125!
        Me.Label13.Width = 1.25!
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Tag = ""
        Me.Line2.Top = 3.364583!
        Me.Line2.Width = 9.833333!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.833333!
        Me.Line2.Y1 = 3.364583!
        Me.Line2.Y2 = 3.364583!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.2083333!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.4583333!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label14.Text = "Our Docket:"
        Me.Label14.Top = 2.083333!
        Me.Label14.Width = 1.083333!
        '
        'OurDocket
        '
        Me.OurDocket.Border.BottomColor = System.Drawing.Color.Black
        Me.OurDocket.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OurDocket.Border.LeftColor = System.Drawing.Color.Black
        Me.OurDocket.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OurDocket.Border.RightColor = System.Drawing.Color.Black
        Me.OurDocket.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OurDocket.Border.TopColor = System.Drawing.Color.Black
        Me.OurDocket.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OurDocket.CanShrink = True
        Me.OurDocket.DataField = "OurDocket"
        Me.OurDocket.Height = 0.2083333!
        Me.OurDocket.Left = 1.583334!
        Me.OurDocket.Name = "OurDocket"
        Me.OurDocket.Style = "font-size: 9pt; "
        Me.OurDocket.Text = "OurDocket"
        Me.OurDocket.Top = 2.083333!
        Me.OurDocket.Width = 2.125!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Height = 0.2083333!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.4583333!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label15.Text = "Client Docket:"
        Me.Label15.Top = 2.291667!
        Me.Label15.Width = 1.083333!
        '
        'ClientDocket
        '
        Me.ClientDocket.Border.BottomColor = System.Drawing.Color.Black
        Me.ClientDocket.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientDocket.Border.LeftColor = System.Drawing.Color.Black
        Me.ClientDocket.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientDocket.Border.RightColor = System.Drawing.Color.Black
        Me.ClientDocket.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientDocket.Border.TopColor = System.Drawing.Color.Black
        Me.ClientDocket.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientDocket.CanShrink = True
        Me.ClientDocket.DataField = "ClientDocket"
        Me.ClientDocket.Height = 0.2083333!
        Me.ClientDocket.Left = 1.583334!
        Me.ClientDocket.Name = "ClientDocket"
        Me.ClientDocket.Style = "font-size: 9pt; "
        Me.ClientDocket.Text = "ClientDocket"
        Me.ClientDocket.Top = 2.291667!
        Me.ClientDocket.Width = 2.125!
        '
        'PatentIDFooter
        '
        Me.PatentIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.subrptPatentActions, Me.FooterLine})
        Me.PatentIDFooter.Height = 0.25!
        Me.PatentIDFooter.Name = "PatentIDFooter"
        '
        'subrptPatentActions
        '
        Me.subrptPatentActions.Border.BottomColor = System.Drawing.Color.Black
        Me.subrptPatentActions.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentActions.Border.LeftColor = System.Drawing.Color.Black
        Me.subrptPatentActions.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentActions.Border.RightColor = System.Drawing.Color.Black
        Me.subrptPatentActions.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentActions.Border.TopColor = System.Drawing.Color.Black
        Me.subrptPatentActions.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptPatentActions.CloseBorder = False
        Me.subrptPatentActions.Height = 0.125!
        Me.subrptPatentActions.Left = 0.2916667!
        Me.subrptPatentActions.Name = "subrptPatentActions"
        Me.subrptPatentActions.Report = Nothing
        Me.subrptPatentActions.ReportName = "subrptPatentActions"
        Me.subrptPatentActions.Top = 0.04166667!
        Me.subrptPatentActions.Width = 7.125!
        '
        'FooterLine
        '
        Me.FooterLine.Border.BottomColor = System.Drawing.Color.Black
        Me.FooterLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FooterLine.Border.LeftColor = System.Drawing.Color.Black
        Me.FooterLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FooterLine.Border.RightColor = System.Drawing.Color.Black
        Me.FooterLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FooterLine.Border.TopColor = System.Drawing.Color.Black
        Me.FooterLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.FooterLine.Height = 0.0!
        Me.FooterLine.Left = 0.0!
        Me.FooterLine.LineWeight = 1.0!
        Me.FooterLine.Name = "FooterLine"
        Me.FooterLine.Tag = ""
        Me.FooterLine.Top = 0.0!
        Me.FooterLine.Width = 9.875!
        Me.FooterLine.X1 = 0.0!
        Me.FooterLine.X2 = 9.875!
        Me.FooterLine.Y1 = 0.0!
        Me.FooterLine.Y2 = 0.0!
        '
        'rptOnePatent
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportPatents where PatentID=1"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.4375!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.PatentIDHeader)
        Me.Sections.Add(Me.DateDetail)
        Me.Sections.Add(Me.PatentIDFooter)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressOne1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressTwo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCityStateZip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCountry1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilingBasis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OurDocket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientDocket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents PatentIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PatentIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents PatentName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddressOne1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddressTwo1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCityStateZip1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCountry1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PatentDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label40 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents FileNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents ApplicationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PatentNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents PatentType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Status As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents FilingBasis As DataDynamics.ActiveReports.TextBox
    Friend WithEvents picGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents subrptPatentClasses As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents DateLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MonthYear As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents subrptPatentActions As DataDynamics.ActiveReports.SubReport
    Friend WithEvents FooterLine As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Completed As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents OurDocket As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents ClientDocket As DataDynamics.ActiveReports.TextBox
End Class
