<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTrademarksByCompanyContacts
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
    Private WithEvents ContactDetail As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTrademarksByCompanyContacts))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.ContactDetail = New DataDynamics.ActiveReports.Detail
        Me.ContactName = New DataDynamics.ActiveReports.TextBox
        Me.ContactCompany = New DataDynamics.ActiveReports.TextBox
        Me.PositionName = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TrademarkIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.txtTrademarkName1 = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.ApplicationNumber = New DataDynamics.ActiveReports.TextBox
        Me.RegistrationNumber = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.CompanyName = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.FooterLine = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PositionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.ReportGraphic, Me.Line1, Me.ReportSubtitle})
        Me.PageHeader1.Height = 0.7083333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblReportTitle
        '
        Me.lblReportTitle.Border.BottomColor = System.Drawing.Color.Black
        Me.lblReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblReportTitle.Border.LeftColor = System.Drawing.Color.Black
        Me.lblReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblReportTitle.Border.RightColor = System.Drawing.Color.Black
        Me.lblReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblReportTitle.Border.TopColor = System.Drawing.Color.Black
        Me.lblReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblReportTitle.Height = 0.375!
        Me.lblReportTitle.HyperLink = Nothing
        Me.lblReportTitle.Left = 0.0!
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Style = "color: Black; text-align: left; font-weight: bold; font-style: italic; background" & _
            "-color: White; font-size: 20pt; font-family: Times New Roman; "
        Me.lblReportTitle.Tag = ""
        Me.lblReportTitle.Text = "ReportTitle"
        Me.lblReportTitle.Top = 0.0!
        Me.lblReportTitle.Width = 5.5!
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
        Me.Line1.Top = 0.6666667!
        Me.Line1.Width = 9.791667!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.791667!
        Me.Line1.Y1 = 0.6666667!
        Me.Line1.Y2 = 0.6666667!
        '
        'ReportSubtitle
        '
        Me.ReportSubtitle.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportSubtitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportSubtitle.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportSubtitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportSubtitle.Border.RightColor = System.Drawing.Color.Black
        Me.ReportSubtitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportSubtitle.Border.TopColor = System.Drawing.Color.Black
        Me.ReportSubtitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportSubtitle.CanShrink = True
        Me.ReportSubtitle.Height = 0.1666667!
        Me.ReportSubtitle.Left = 0.0!
        Me.ReportSubtitle.Name = "ReportSubtitle"
        Me.ReportSubtitle.Style = "font-weight: normal; font-style: italic; font-size: 9pt; "
        Me.ReportSubtitle.Text = "ReportSubtitle"
        Me.ReportSubtitle.Top = 0.4166667!
        Me.ReportSubtitle.Width = 5.5!
        '
        'ContactDetail
        '
        Me.ContactDetail.ColumnSpacing = 0.0!
        Me.ContactDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ContactName, Me.ContactCompany, Me.PositionName})
        Me.ContactDetail.Height = 0.2395833!
        Me.ContactDetail.Name = "ContactDetail"
        '
        'ContactName
        '
        Me.ContactName.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactName.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactName.Border.RightColor = System.Drawing.Color.Black
        Me.ContactName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactName.Border.TopColor = System.Drawing.Color.Black
        Me.ContactName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactName.CanShrink = True
        Me.ContactName.DataField = "ContactName"
        Me.ContactName.Height = 0.1666667!
        Me.ContactName.Left = 0.6666667!
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Style = "font-size: 9pt; "
        Me.ContactName.Text = "ContactName"
        Me.ContactName.Top = 0.02083333!
        Me.ContactName.Width = 1.791667!
        '
        'ContactCompany
        '
        Me.ContactCompany.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactCompany.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCompany.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactCompany.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCompany.Border.RightColor = System.Drawing.Color.Black
        Me.ContactCompany.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCompany.Border.TopColor = System.Drawing.Color.Black
        Me.ContactCompany.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCompany.CanShrink = True
        Me.ContactCompany.DataField = "ContactCompany"
        Me.ContactCompany.Height = 0.1666667!
        Me.ContactCompany.Left = 2.583333!
        Me.ContactCompany.Name = "ContactCompany"
        Me.ContactCompany.Style = "font-size: 9pt; "
        Me.ContactCompany.Text = "ContactCompany"
        Me.ContactCompany.Top = 0.02083333!
        Me.ContactCompany.Width = 2.291667!
        '
        'PositionName
        '
        Me.PositionName.Border.BottomColor = System.Drawing.Color.Black
        Me.PositionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PositionName.Border.LeftColor = System.Drawing.Color.Black
        Me.PositionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PositionName.Border.RightColor = System.Drawing.Color.Black
        Me.PositionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PositionName.Border.TopColor = System.Drawing.Color.Black
        Me.PositionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PositionName.CanShrink = True
        Me.PositionName.DataField = "PositionName"
        Me.PositionName.Height = 0.1666667!
        Me.PositionName.Left = 4.958333!
        Me.PositionName.Name = "PositionName"
        Me.PositionName.Style = "font-size: 9pt; "
        Me.PositionName.Text = "PositionName"
        Me.PositionName.Top = 0.02083333!
        Me.PositionName.Width = 1.791667!
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
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.2083333!
        Me.ReportInfo1.Left = 2.583333!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "text-align: center; "
        Me.ReportInfo1.Top = 0.04166667!
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
        'TrademarkIDHeader
        '
        Me.TrademarkIDHeader.CanShrink = True
        Me.TrademarkIDHeader.ColumnGroupKeepTogether = True
        Me.TrademarkIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTrademarkName1, Me.Label4, Me.Jurisdiction, Me.Label5, Me.ApplicationNumber, Me.RegistrationNumber, Me.Label6, Me.Line3})
        Me.TrademarkIDHeader.DataField = "TrademarkID"
        Me.TrademarkIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.TrademarkIDHeader.Height = 0.5520833!
        Me.TrademarkIDHeader.Name = "TrademarkIDHeader"
        '
        'txtTrademarkName1
        '
        Me.txtTrademarkName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTrademarkName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTrademarkName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTrademarkName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTrademarkName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtTrademarkName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTrademarkName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtTrademarkName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTrademarkName1.CanShrink = True
        Me.txtTrademarkName1.DataField = "TrademarkName"
        Me.txtTrademarkName1.Height = 0.2083333!
        Me.txtTrademarkName1.Left = 0.2916667!
        Me.txtTrademarkName1.Name = "txtTrademarkName1"
        Me.txtTrademarkName1.Style = "font-weight: bold; font-size: 9pt; "
        Me.txtTrademarkName1.Text = "txtTrademarkName1"
        Me.txtTrademarkName1.Top = 0.0!
        Me.txtTrademarkName1.Width = 6.791667!
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
        Me.Label4.Height = 0.1666667!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.083333!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Jurisdiction:"
        Me.Label4.Top = 0.3333333!
        Me.Label4.Width = 0.7916667!
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
        Me.Jurisdiction.Height = 0.1666667!
        Me.Jurisdiction.Left = 5.916667!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "font-size: 9pt; "
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 0.3333333!
        Me.Jurisdiction.Width = 1.375!
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
        Me.Label5.Height = 0.1666667!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.125!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label5.Text = "Application:"
        Me.Label5.Top = 0.3333333!
        Me.Label5.Width = 0.9166667!
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
        Me.ApplicationNumber.Height = 0.1666667!
        Me.ApplicationNumber.Left = 1.083333!
        Me.ApplicationNumber.Name = "ApplicationNumber"
        Me.ApplicationNumber.Style = "font-size: 9pt; "
        Me.ApplicationNumber.Text = "ApplicationNumber"
        Me.ApplicationNumber.Top = 0.3333333!
        Me.ApplicationNumber.Width = 1.375!
        '
        'RegistrationNumber
        '
        Me.RegistrationNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.RegistrationNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.RegistrationNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.RightColor = System.Drawing.Color.Black
        Me.RegistrationNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.TopColor = System.Drawing.Color.Black
        Me.RegistrationNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.CanShrink = True
        Me.RegistrationNumber.DataField = "RegistrationNumber"
        Me.RegistrationNumber.Height = 0.1666667!
        Me.RegistrationNumber.Left = 3.583333!
        Me.RegistrationNumber.Name = "RegistrationNumber"
        Me.RegistrationNumber.Style = "font-size: 9pt; "
        Me.RegistrationNumber.Text = "RegistrationNumber"
        Me.RegistrationNumber.Top = 0.3333333!
        Me.RegistrationNumber.Width = 1.291667!
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
        Me.Label6.Height = 0.1666667!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label6.Text = "Registration:"
        Me.Label6.Top = 0.3333333!
        Me.Label6.Width = 0.9166667!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Tag = ""
        Me.Line3.Top = 0.5208333!
        Me.Line3.Width = 9.875!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 9.875!
        Me.Line3.Y1 = 0.5208333!
        Me.Line3.Y2 = 0.5208333!
        '
        'CompanyName
        '
        Me.CompanyName.Border.BottomColor = System.Drawing.Color.Black
        Me.CompanyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.LeftColor = System.Drawing.Color.Black
        Me.CompanyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.RightColor = System.Drawing.Color.Black
        Me.CompanyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.TopColor = System.Drawing.Color.Black
        Me.CompanyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.CanShrink = True
        Me.CompanyName.DataField = "CompanyName"
        Me.CompanyName.Height = 0.2083333!
        Me.CompanyName.Left = 0.0!
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Style = "font-weight: bold; font-size: 11pt; "
        Me.CompanyName.Text = "txtCompanyName1"
        Me.CompanyName.Top = 0.0!
        Me.CompanyName.Width = 5.5!
        '
        'TrademarkIDFooter
        '
        Me.TrademarkIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.FooterLine, Me.Line2})
        Me.TrademarkIDFooter.Height = 0.1666667!
        Me.TrademarkIDFooter.Name = "TrademarkIDFooter"
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
        Me.FooterLine.LineWeight = 2.0!
        Me.FooterLine.Name = "FooterLine"
        Me.FooterLine.Tag = ""
        Me.FooterLine.Top = 0.08333334!
        Me.FooterLine.Width = 9.875!
        Me.FooterLine.X1 = 0.0!
        Me.FooterLine.X2 = 9.875!
        Me.FooterLine.Y1 = 0.08333334!
        Me.FooterLine.Y2 = 0.08333334!
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
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Tag = ""
        Me.Line2.Top = 0.04166667!
        Me.Line2.Width = 9.875!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.875!
        Me.Line2.Y1 = 0.04166667!
        Me.Line2.Y2 = 0.04166667!
        '
        'CompanyHeader
        '
        Me.CompanyHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CompanyName, Me.Line4})
        Me.CompanyHeader.DataField = "CompanyID"
        Me.CompanyHeader.Height = 0.28125!
        Me.CompanyHeader.Name = "CompanyHeader"
        Me.CompanyHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before
        Me.CompanyHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'Line4
        '
        Me.Line4.Border.BottomColor = System.Drawing.Color.Black
        Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line4.Border.LeftColor = System.Drawing.Color.Black
        Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line4.Border.RightColor = System.Drawing.Color.Black
        Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line4.Border.TopColor = System.Drawing.Color.Black
        Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.0!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Tag = ""
        Me.Line4.Top = 0.25!
        Me.Line4.Width = 9.791667!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.791667!
        Me.Line4.Y1 = 0.25!
        Me.Line4.Y2 = 0.25!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.02083333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptTrademarksByCompanyContacts
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportTrademarkContacts order by companyname, trademarkname, trad" & _
            "emarkid"
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
        Me.Sections.Add(Me.CompanyHeader)
        Me.Sections.Add(Me.TrademarkIDHeader)
        Me.Sections.Add(Me.ContactDetail)
        Me.Sections.Add(Me.TrademarkIDFooter)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PositionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TrademarkIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents TrademarkIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtTrademarkName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents ApplicationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents RegistrationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents FooterLine As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents ContactName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactCompany As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PositionName As DataDynamics.ActiveReports.TextBox
End Class
