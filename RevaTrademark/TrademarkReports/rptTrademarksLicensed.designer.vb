<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTrademarksLicensed
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTrademarksLicensed))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.DateDetail = New DataDynamics.ActiveReports.Detail
        Me.Licensee = New DataDynamics.ActiveReports.TextBox
        Me.LicenseeCity = New DataDynamics.ActiveReports.TextBox
        Me.LicenseeCountry = New DataDynamics.ActiveReports.TextBox
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.ApplicationNumber = New DataDynamics.ActiveReports.TextBox
        Me.RegistrationNumber = New DataDynamics.ActiveReports.TextBox
        Me.txtTrademarkName1 = New DataDynamics.ActiveReports.TextBox
        Me.FileNumber = New DataDynamics.ActiveReports.TextBox
        Me.FilingBasis = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TrademarkIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.CompanyFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.Label7 = New DataDynamics.ActiveReports.Label
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Licensee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicenseeCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicenseeCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilingBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblReportTitle.Width = 5.083333!
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
        Me.ReportGraphic.Left = 5.583333!
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
        Me.Line1.Width = 7.4!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.4!
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
        Me.ReportSubtitle.Width = 5.083333!
        '
        'DateDetail
        '
        Me.DateDetail.ColumnSpacing = 0.0!
        Me.DateDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Licensee, Me.LicenseeCity, Me.LicenseeCountry, Me.Label7})
        Me.DateDetail.Height = 0.25!
        Me.DateDetail.Name = "DateDetail"
        '
        'Licensee
        '
        Me.Licensee.Border.BottomColor = System.Drawing.Color.Black
        Me.Licensee.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Licensee.Border.LeftColor = System.Drawing.Color.Black
        Me.Licensee.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Licensee.Border.RightColor = System.Drawing.Color.Black
        Me.Licensee.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Licensee.Border.TopColor = System.Drawing.Color.Black
        Me.Licensee.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Licensee.CanShrink = True
        Me.Licensee.DataField = "Licensee"
        Me.Licensee.Height = 0.1666667!
        Me.Licensee.Left = 1.166667!
        Me.Licensee.Name = "Licensee"
        Me.Licensee.Style = "font-weight: bold; font-size: 9pt; "
        Me.Licensee.Text = "Licensee"
        Me.Licensee.Top = 0.04166667!
        Me.Licensee.Width = 2.916667!
        '
        'LicenseeCity
        '
        Me.LicenseeCity.Border.BottomColor = System.Drawing.Color.Black
        Me.LicenseeCity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCity.Border.LeftColor = System.Drawing.Color.Black
        Me.LicenseeCity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCity.Border.RightColor = System.Drawing.Color.Black
        Me.LicenseeCity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCity.Border.TopColor = System.Drawing.Color.Black
        Me.LicenseeCity.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCity.CanShrink = True
        Me.LicenseeCity.DataField = "LicenseeCity"
        Me.LicenseeCity.Height = 0.1666667!
        Me.LicenseeCity.Left = 4.166667!
        Me.LicenseeCity.Name = "LicenseeCity"
        Me.LicenseeCity.Style = "font-size: 9pt; "
        Me.LicenseeCity.Text = "LicenseeCity"
        Me.LicenseeCity.Top = 0.04166667!
        Me.LicenseeCity.Width = 1.541667!
        '
        'LicenseeCountry
        '
        Me.LicenseeCountry.Border.BottomColor = System.Drawing.Color.Black
        Me.LicenseeCountry.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCountry.Border.LeftColor = System.Drawing.Color.Black
        Me.LicenseeCountry.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCountry.Border.RightColor = System.Drawing.Color.Black
        Me.LicenseeCountry.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCountry.Border.TopColor = System.Drawing.Color.Black
        Me.LicenseeCountry.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LicenseeCountry.CanShrink = True
        Me.LicenseeCountry.DataField = "LicenseeCountry"
        Me.LicenseeCountry.Height = 0.1666667!
        Me.LicenseeCountry.Left = 5.791667!
        Me.LicenseeCountry.Name = "LicenseeCountry"
        Me.LicenseeCountry.Style = "font-size: 9pt; "
        Me.LicenseeCountry.Text = "LicenseeCountry"
        Me.LicenseeCountry.Top = 0.04166667!
        Me.LicenseeCountry.Width = 1.583333!
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
        Me.Jurisdiction.Left = 5.25!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "font-size: 9pt; "
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 0.0!
        Me.Jurisdiction.Width = 1.083333!
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
        Me.ApplicationNumber.Left = 3.333333!
        Me.ApplicationNumber.Name = "ApplicationNumber"
        Me.ApplicationNumber.Style = "font-size: 9pt; "
        Me.ApplicationNumber.Text = "ApplicationNumber"
        Me.ApplicationNumber.Top = 0.0!
        Me.ApplicationNumber.Width = 0.9166667!
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
        Me.RegistrationNumber.Left = 4.291667!
        Me.RegistrationNumber.Name = "RegistrationNumber"
        Me.RegistrationNumber.Style = "font-size: 9pt; "
        Me.RegistrationNumber.Text = "RegistrationNumber"
        Me.RegistrationNumber.Top = 0.0!
        Me.RegistrationNumber.Width = 0.9166667!
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
        Me.txtTrademarkName1.Height = 0.1666667!
        Me.txtTrademarkName1.Left = 0.0!
        Me.txtTrademarkName1.Name = "txtTrademarkName1"
        Me.txtTrademarkName1.Style = "font-weight: bold; font-size: 9pt; "
        Me.txtTrademarkName1.Text = "txtTrademarkName1"
        Me.txtTrademarkName1.Top = 0.0!
        Me.txtTrademarkName1.Width = 2.333333!
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
        Me.FileNumber.Height = 0.1666667!
        Me.FileNumber.Left = 2.375!
        Me.FileNumber.Name = "FileNumber"
        Me.FileNumber.Style = "font-size: 9pt; "
        Me.FileNumber.Text = "fileNumber"
        Me.FileNumber.Top = 0.0!
        Me.FileNumber.Width = 0.9166667!
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
        Me.FilingBasis.Height = 0.1666667!
        Me.FilingBasis.Left = 6.375!
        Me.FilingBasis.Name = "FilingBasis"
        Me.FilingBasis.Style = "font-size: 9pt; "
        Me.FilingBasis.Text = "FilingBasis"
        Me.FilingBasis.Top = 0.0!
        Me.FilingBasis.Width = 0.9583333!
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
        Me.ReportInfo1.Left = 2.546875!
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
        Me.TrademarkIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTrademarkName1, Me.ApplicationNumber, Me.RegistrationNumber, Me.Jurisdiction, Me.FileNumber, Me.FilingBasis, Me.Line5})
        Me.TrademarkIDHeader.DataField = "TrademarkID"
        Me.TrademarkIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.TrademarkIDHeader.Height = 0.21875!
        Me.TrademarkIDHeader.Name = "TrademarkIDHeader"
        '
        'Line5
        '
        Me.Line5.Border.BottomColor = System.Drawing.Color.Black
        Me.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line5.Border.LeftColor = System.Drawing.Color.Black
        Me.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line5.Border.RightColor = System.Drawing.Color.Black
        Me.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line5.Border.TopColor = System.Drawing.Color.Black
        Me.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.0!
        Me.Line5.LineWeight = 2.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Tag = ""
        Me.Line5.Top = 0.1875!
        Me.Line5.Width = 7.4!
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 7.4!
        Me.Line5.Y1 = 0.1875!
        Me.Line5.Y2 = 0.1875!
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
        Me.Label4.Left = 5.25!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Jurisdiction:"
        Me.Label4.Top = 0.5416667!
        Me.Label4.Width = 1.041667!
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
        Me.Label5.Left = 3.333333!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label5.Text = "Application:"
        Me.Label5.Top = 0.5416667!
        Me.Label5.Width = 0.9166667!
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
        Me.Label6.Left = 4.291667!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label6.Text = "Registration:"
        Me.Label6.Top = 0.5416667!
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
        Me.Line3.Top = 0.7291667!
        Me.Line3.Width = 7.4!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 7.4!
        Me.Line3.Y1 = 0.7291667!
        Me.Line3.Y2 = 0.7291667!
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
        Me.Label1.Height = 0.1666667!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label1.Text = "Trademark:"
        Me.Label1.Top = 0.5416667!
        Me.Label1.Width = 1.25!
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
        Me.txtCompanyName1.Height = 0.2916667!
        Me.txtCompanyName1.Left = 0.0!
        Me.txtCompanyName1.Name = "txtCompanyName1"
        Me.txtCompanyName1.Style = "font-weight: bold; font-size: 11pt; "
        Me.txtCompanyName1.Text = "txtCompanyName1"
        Me.txtCompanyName1.Top = 0.04166667!
        Me.txtCompanyName1.Width = 5.5!
        '
        'TrademarkIDFooter
        '
        Me.TrademarkIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line6, Me.Line7})
        Me.TrademarkIDFooter.Height = 0.1458333!
        Me.TrademarkIDFooter.Name = "TrademarkIDFooter"
        '
        'Line6
        '
        Me.Line6.Border.BottomColor = System.Drawing.Color.Black
        Me.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line6.Border.LeftColor = System.Drawing.Color.Black
        Me.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line6.Border.RightColor = System.Drawing.Color.Black
        Me.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line6.Border.TopColor = System.Drawing.Color.Black
        Me.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Tag = ""
        Me.Line6.Top = 0.0!
        Me.Line6.Width = 7.4!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 7.4!
        Me.Line6.Y1 = 0.0!
        Me.Line6.Y2 = 0.0!
        '
        'Line7
        '
        Me.Line7.Border.BottomColor = System.Drawing.Color.Black
        Me.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line7.Border.LeftColor = System.Drawing.Color.Black
        Me.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line7.Border.RightColor = System.Drawing.Color.Black
        Me.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line7.Border.TopColor = System.Drawing.Color.Black
        Me.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 0.0!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Tag = ""
        Me.Line7.Top = 0.04166667!
        Me.Line7.Width = 7.4!
        Me.Line7.X1 = 0.0!
        Me.Line7.X2 = 7.4!
        Me.Line7.Y1 = 0.04166667!
        Me.Line7.Y2 = 0.04166667!
        '
        'CompanyHeader
        '
        Me.CompanyHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCompanyName1, Me.Label1, Me.Label5, Me.Label6, Me.Label4, Me.Label3, Me.Line4, Me.Line3, Me.Label2})
        Me.CompanyHeader.DataField = "CompanyID"
        Me.CompanyHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.CompanyHeader.Height = 0.75!
        Me.CompanyHeader.Name = "CompanyHeader"
        Me.CompanyHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
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
        Me.Label3.Height = 0.1666667!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.375!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "File Number:"
        Me.Label3.Top = 0.5416667!
        Me.Label3.Width = 0.9166667!
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
        Me.Line4.Top = 0.375!
        Me.Line4.Width = 7.4!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 7.4!
        Me.Line4.Y1 = 0.375!
        Me.Line4.Y2 = 0.375!
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
        Me.Label2.Height = 0.1666667!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.333333!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label2.Text = "Filing Basis:"
        Me.Label2.Top = 0.5416667!
        Me.Label2.Width = 0.875!
        '
        'CompanyFooter
        '
        Me.CompanyFooter.Height = 0.01041667!
        Me.CompanyFooter.Name = "CompanyFooter"
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
        Me.Label7.Height = 0.1666667!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.4166667!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label7.Text = "Licensee:"
        Me.Label7.Top = 0.04166667!
        Me.Label7.Width = 0.6666667!
        '
        'rptTrademarksLicensed
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportTrademarksLicensed order by companyname, companyid, tradema" & _
            "rkname, trademarkid, licensee"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.427083!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.CompanyHeader)
        Me.Sections.Add(Me.TrademarkIDHeader)
        Me.Sections.Add(Me.DateDetail)
        Me.Sections.Add(Me.TrademarkIDFooter)
        Me.Sections.Add(Me.CompanyFooter)
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
        CType(Me.Licensee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicenseeCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicenseeCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilingBasis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TrademarkIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents TrademarkIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents ApplicationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents RegistrationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTrademarkName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents CompanyFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents FileNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents FilingBasis As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Licensee As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LicenseeCity As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LicenseeCountry As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
End Class
