<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCompanyContacts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCompanyContacts))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ContactDetail = New DataDynamics.ActiveReports.Detail
        Me.ContactName = New DataDynamics.ActiveReports.TextBox
        Me.ContactTitle = New DataDynamics.ActiveReports.TextBox
        Me.ContactAddressOne = New DataDynamics.ActiveReports.TextBox
        Me.ContactAddressTwo = New DataDynamics.ActiveReports.TextBox
        Me.CityStateZip = New DataDynamics.ActiveReports.TextBox
        Me.ContactCountry = New DataDynamics.ActiveReports.TextBox
        Me.ContactPhone = New DataDynamics.ActiveReports.TextBox
        Me.ContactMobilePhone = New DataDynamics.ActiveReports.TextBox
        Me.ContactFax = New DataDynamics.ActiveReports.TextBox
        Me.ContactEmail = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.CompanyName = New DataDynamics.ActiveReports.TextBox
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactAddressOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactAddressTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CityStateZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactMobilePhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.ReportGraphic, Me.Line1})
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
        Me.lblReportTitle.Text = "Company Contacts"
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
        'ContactDetail
        '
        Me.ContactDetail.ColumnSpacing = 0.0!
        Me.ContactDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ContactName, Me.ContactTitle, Me.ContactAddressOne, Me.ContactAddressTwo, Me.CityStateZip, Me.ContactCountry, Me.ContactPhone, Me.ContactMobilePhone, Me.ContactFax, Me.ContactEmail, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Line2})
        Me.ContactDetail.Height = 1.46875!
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
        Me.ContactName.Height = 0.1875!
        Me.ContactName.Left = 0.375!
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Style = "font-size: 9pt; "
        Me.ContactName.Text = "ContactName"
        Me.ContactName.Top = 0.0625!
        Me.ContactName.Width = 3.125!
        '
        'ContactTitle
        '
        Me.ContactTitle.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactTitle.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactTitle.Border.RightColor = System.Drawing.Color.Black
        Me.ContactTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactTitle.Border.TopColor = System.Drawing.Color.Black
        Me.ContactTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactTitle.CanShrink = True
        Me.ContactTitle.DataField = "ContactTitle"
        Me.ContactTitle.Height = 0.1875!
        Me.ContactTitle.Left = 0.375!
        Me.ContactTitle.Name = "ContactTitle"
        Me.ContactTitle.Style = "font-size: 9pt; "
        Me.ContactTitle.Text = "ContactTitle"
        Me.ContactTitle.Top = 0.275!
        Me.ContactTitle.Width = 3.125!
        '
        'ContactAddressOne
        '
        Me.ContactAddressOne.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactAddressOne.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressOne.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactAddressOne.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressOne.Border.RightColor = System.Drawing.Color.Black
        Me.ContactAddressOne.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressOne.Border.TopColor = System.Drawing.Color.Black
        Me.ContactAddressOne.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressOne.CanShrink = True
        Me.ContactAddressOne.DataField = "ContactAddressOne"
        Me.ContactAddressOne.Height = 0.1875!
        Me.ContactAddressOne.Left = 0.375!
        Me.ContactAddressOne.Name = "ContactAddressOne"
        Me.ContactAddressOne.Style = "font-size: 9pt; "
        Me.ContactAddressOne.Text = "ContactAddressOne"
        Me.ContactAddressOne.Top = 0.4791667!
        Me.ContactAddressOne.Width = 3.125!
        '
        'ContactAddressTwo
        '
        Me.ContactAddressTwo.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactAddressTwo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressTwo.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactAddressTwo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressTwo.Border.RightColor = System.Drawing.Color.Black
        Me.ContactAddressTwo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressTwo.Border.TopColor = System.Drawing.Color.Black
        Me.ContactAddressTwo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactAddressTwo.CanShrink = True
        Me.ContactAddressTwo.DataField = "ContactAddressTwo"
        Me.ContactAddressTwo.Height = 0.1875!
        Me.ContactAddressTwo.Left = 0.375!
        Me.ContactAddressTwo.Name = "ContactAddressTwo"
        Me.ContactAddressTwo.Style = "font-size: 9pt; "
        Me.ContactAddressTwo.Text = "ContactAddressTwo"
        Me.ContactAddressTwo.Top = 0.6875!
        Me.ContactAddressTwo.Width = 3.125!
        '
        'CityStateZip
        '
        Me.CityStateZip.Border.BottomColor = System.Drawing.Color.Black
        Me.CityStateZip.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CityStateZip.Border.LeftColor = System.Drawing.Color.Black
        Me.CityStateZip.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CityStateZip.Border.RightColor = System.Drawing.Color.Black
        Me.CityStateZip.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CityStateZip.Border.TopColor = System.Drawing.Color.Black
        Me.CityStateZip.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CityStateZip.CanShrink = True
        Me.CityStateZip.DataField = "CityStateZip"
        Me.CityStateZip.Height = 0.1875!
        Me.CityStateZip.Left = 0.375!
        Me.CityStateZip.Name = "CityStateZip"
        Me.CityStateZip.Style = "font-size: 9pt; "
        Me.CityStateZip.Text = "CityStateZip"
        Me.CityStateZip.Top = 0.8958333!
        Me.CityStateZip.Width = 3.125!
        '
        'ContactCountry
        '
        Me.ContactCountry.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactCountry.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCountry.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactCountry.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCountry.Border.RightColor = System.Drawing.Color.Black
        Me.ContactCountry.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCountry.Border.TopColor = System.Drawing.Color.Black
        Me.ContactCountry.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactCountry.CanShrink = True
        Me.ContactCountry.DataField = "ContactCountry"
        Me.ContactCountry.Height = 0.1875!
        Me.ContactCountry.Left = 0.375!
        Me.ContactCountry.Name = "ContactCountry"
        Me.ContactCountry.Style = "font-size: 9pt; "
        Me.ContactCountry.Text = "ContactCountry"
        Me.ContactCountry.Top = 1.104167!
        Me.ContactCountry.Width = 3.125!
        '
        'ContactPhone
        '
        Me.ContactPhone.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactPhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactPhone.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactPhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactPhone.Border.RightColor = System.Drawing.Color.Black
        Me.ContactPhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactPhone.Border.TopColor = System.Drawing.Color.Black
        Me.ContactPhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactPhone.CanShrink = True
        Me.ContactPhone.DataField = "ContactPhone"
        Me.ContactPhone.Height = 0.1875!
        Me.ContactPhone.Left = 4.6875!
        Me.ContactPhone.Name = "ContactPhone"
        Me.ContactPhone.Style = "font-size: 9pt; "
        Me.ContactPhone.Text = "ContactPhone"
        Me.ContactPhone.Top = 0.0625!
        Me.ContactPhone.Width = 2.6875!
        '
        'ContactMobilePhone
        '
        Me.ContactMobilePhone.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactMobilePhone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactMobilePhone.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactMobilePhone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactMobilePhone.Border.RightColor = System.Drawing.Color.Black
        Me.ContactMobilePhone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactMobilePhone.Border.TopColor = System.Drawing.Color.Black
        Me.ContactMobilePhone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactMobilePhone.CanShrink = True
        Me.ContactMobilePhone.DataField = "ContactMobilePhone"
        Me.ContactMobilePhone.Height = 0.1875!
        Me.ContactMobilePhone.Left = 4.6875!
        Me.ContactMobilePhone.Name = "ContactMobilePhone"
        Me.ContactMobilePhone.Style = "font-size: 9pt; "
        Me.ContactMobilePhone.Text = "ContactMobilePhone"
        Me.ContactMobilePhone.Top = 0.275!
        Me.ContactMobilePhone.Width = 2.6875!
        '
        'ContactFax
        '
        Me.ContactFax.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactFax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactFax.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactFax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactFax.Border.RightColor = System.Drawing.Color.Black
        Me.ContactFax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactFax.Border.TopColor = System.Drawing.Color.Black
        Me.ContactFax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactFax.CanShrink = True
        Me.ContactFax.DataField = "ContactFax"
        Me.ContactFax.Height = 0.1875!
        Me.ContactFax.Left = 4.6875!
        Me.ContactFax.Name = "ContactFax"
        Me.ContactFax.Style = "font-size: 9pt; "
        Me.ContactFax.Text = "ContactFax"
        Me.ContactFax.Top = 0.4791667!
        Me.ContactFax.Width = 2.6875!
        '
        'ContactEmail
        '
        Me.ContactEmail.Border.BottomColor = System.Drawing.Color.Black
        Me.ContactEmail.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactEmail.Border.LeftColor = System.Drawing.Color.Black
        Me.ContactEmail.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactEmail.Border.RightColor = System.Drawing.Color.Black
        Me.ContactEmail.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactEmail.Border.TopColor = System.Drawing.Color.Black
        Me.ContactEmail.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ContactEmail.CanShrink = True
        Me.ContactEmail.DataField = "ContactEmail"
        Me.ContactEmail.Height = 0.1875!
        Me.ContactEmail.Left = 4.6875!
        Me.ContactEmail.Name = "ContactEmail"
        Me.ContactEmail.Style = "font-size: 9pt; "
        Me.ContactEmail.Text = "ContactEmail"
        Me.ContactEmail.Top = 0.6875!
        Me.ContactEmail.Width = 2.6875!
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 4.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label1.Text = "Phone:"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 0.625!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 3.5625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label2.Text = "Mobile Phone:"
        Me.Label2.Top = 0.275!
        Me.Label2.Width = 1.0625!
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
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 4.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "FAX:"
        Me.Label3.Top = 0.4791667!
        Me.Label3.Width = 0.625!
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
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 4.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Email:"
        Me.Label4.Top = 0.6875!
        Me.Label4.Width = 0.625!
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
        Me.Line2.Top = 1.375!
        Me.Line2.Width = 9.8125!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.8125!
        Me.Line2.Y1 = 1.375!
        Me.Line2.Y2 = 1.375!
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
        Me.CompanyName.Text = "CompanyName"
        Me.CompanyName.Top = 0.0!
        Me.CompanyName.Width = 5.5!
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
        'rptCompanyContacts
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademar" & _
            "k\RevaTrademark.mdb"
        OleDBDataSource1.SQL = "Select * from qvwContactsAndCompanies where ContactID is not null"
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
        Me.Sections.Add(Me.ContactDetail)
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
        CType(Me.ContactName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactAddressOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactAddressTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CityStateZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactMobilePhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents CompanyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents ContactName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents ContactAddressOne As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactAddressTwo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CityStateZip As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactCountry As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactPhone As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactMobilePhone As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactFax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactEmail As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
End Class
