<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPatentsByCompanyList
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
    Private WithEvents PatentDetail As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPatentsByCompanyList))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.PatentDetail = New DataDynamics.ActiveReports.Detail
        Me.txtPatentName1 = New DataDynamics.ActiveReports.TextBox
        Me.FieldOne = New DataDynamics.ActiveReports.TextBox
        Me.FieldTwo = New DataDynamics.ActiveReports.TextBox
        Me.FieldThree = New DataDynamics.ActiveReports.TextBox
        Me.FieldFour = New DataDynamics.ActiveReports.TextBox
        Me.FieldFive = New DataDynamics.ActiveReports.TextBox
        Me.FieldSix = New DataDynamics.ActiveReports.TextBox
        Me.FieldSeven = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.PatentIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.PatentIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.LabelTwo = New DataDynamics.ActiveReports.Label
        Me.LabelThree = New DataDynamics.ActiveReports.Label
        Me.LabelFour = New DataDynamics.ActiveReports.Label
        Me.LabelSeven = New DataDynamics.ActiveReports.Label
        Me.LabelSix = New DataDynamics.ActiveReports.Label
        Me.LabelOne = New DataDynamics.ActiveReports.Label
        Me.LabelFive = New DataDynamics.ActiveReports.Label
        Me.CompanyFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.CompanyCountLabel = New DataDynamics.ActiveReports.TextBox
        Me.CompanyCount = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatentName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldSix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldSeven, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelSeven, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelSix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyCountLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyCount, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblReportTitle.Width = 6.208333!
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
        Me.ReportGraphic.Left = 7.958333!
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
        Me.Line1.Width = 9.875!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.875!
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
        Me.ReportSubtitle.Width = 6.208333!
        '
        'PatentDetail
        '
        Me.PatentDetail.ColumnSpacing = 0.0!
        Me.PatentDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPatentName1, Me.FieldOne, Me.FieldTwo, Me.FieldThree, Me.FieldFour, Me.FieldFive, Me.FieldSix, Me.FieldSeven})
        Me.PatentDetail.Height = 0.2604167!
        Me.PatentDetail.Name = "PatentDetail"
        '
        'txtPatentName1
        '
        Me.txtPatentName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPatentName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPatentName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPatentName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPatentName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtPatentName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPatentName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtPatentName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPatentName1.CanShrink = True
        Me.txtPatentName1.DataField = "PatentName"
        Me.txtPatentName1.Height = 0.1666667!
        Me.txtPatentName1.Left = 0.0!
        Me.txtPatentName1.Name = "txtPatentName1"
        Me.txtPatentName1.Style = "font-weight: bold; font-size: 9pt; "
        Me.txtPatentName1.Text = "txtPatentName1"
        Me.txtPatentName1.Top = 0.04166667!
        Me.txtPatentName1.Width = 2.333333!
        '
        'FieldOne
        '
        Me.FieldOne.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldOne.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldOne.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldOne.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldOne.Border.RightColor = System.Drawing.Color.Black
        Me.FieldOne.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldOne.Border.TopColor = System.Drawing.Color.Black
        Me.FieldOne.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldOne.CanShrink = True
        Me.FieldOne.DataField = "FileNumber"
        Me.FieldOne.Height = 0.1666667!
        Me.FieldOne.Left = 2.40625!
        Me.FieldOne.Name = "FieldOne"
        Me.FieldOne.Style = "font-size: 9pt; "
        Me.FieldOne.Text = "fileNumber"
        Me.FieldOne.Top = 0.04166667!
        Me.FieldOne.Width = 1.03125!
        '
        'FieldTwo
        '
        Me.FieldTwo.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldTwo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldTwo.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldTwo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldTwo.Border.RightColor = System.Drawing.Color.Black
        Me.FieldTwo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldTwo.Border.TopColor = System.Drawing.Color.Black
        Me.FieldTwo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldTwo.CanShrink = True
        Me.FieldTwo.DataField = "ApplicationNumber"
        Me.FieldTwo.Height = 0.1666667!
        Me.FieldTwo.Left = 3.465278!
        Me.FieldTwo.Name = "FieldTwo"
        Me.FieldTwo.Style = "font-size: 9pt; "
        Me.FieldTwo.Text = "ApplicationNumber"
        Me.FieldTwo.Top = 0.04166667!
        Me.FieldTwo.Width = 1.041667!
        '
        'FieldThree
        '
        Me.FieldThree.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldThree.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldThree.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldThree.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldThree.Border.RightColor = System.Drawing.Color.Black
        Me.FieldThree.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldThree.Border.TopColor = System.Drawing.Color.Black
        Me.FieldThree.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldThree.CanShrink = True
        Me.FieldThree.DataField = "RegistrationNumber"
        Me.FieldThree.Height = 0.1666667!
        Me.FieldThree.Left = 4.534722!
        Me.FieldThree.Name = "FieldThree"
        Me.FieldThree.Style = "font-size: 9pt; "
        Me.FieldThree.Text = "RegistrationNumber"
        Me.FieldThree.Top = 0.04166667!
        Me.FieldThree.Width = 1.041667!
        '
        'FieldFour
        '
        Me.FieldFour.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldFour.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFour.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldFour.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFour.Border.RightColor = System.Drawing.Color.Black
        Me.FieldFour.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFour.Border.TopColor = System.Drawing.Color.Black
        Me.FieldFour.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFour.CanShrink = True
        Me.FieldFour.DataField = "Jurisdiction"
        Me.FieldFour.Height = 0.1666667!
        Me.FieldFour.Left = 5.604167!
        Me.FieldFour.Name = "FieldFour"
        Me.FieldFour.Style = "font-size: 9pt; "
        Me.FieldFour.Text = "Jurisdiction"
        Me.FieldFour.Top = 0.04166667!
        Me.FieldFour.Width = 1.041667!
        '
        'FieldFive
        '
        Me.FieldFive.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldFive.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFive.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldFive.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFive.Border.RightColor = System.Drawing.Color.Black
        Me.FieldFive.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFive.Border.TopColor = System.Drawing.Color.Black
        Me.FieldFive.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldFive.CanShrink = True
        Me.FieldFive.DataField = "FilingBasis"
        Me.FieldFive.Height = 0.1666667!
        Me.FieldFive.Left = 6.673612!
        Me.FieldFive.Name = "FieldFive"
        Me.FieldFive.Style = "font-size: 9pt; "
        Me.FieldFive.Text = "FilingBasis"
        Me.FieldFive.Top = 0.04166667!
        Me.FieldFive.Width = 1.03125!
        '
        'FieldSix
        '
        Me.FieldSix.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldSix.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSix.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldSix.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSix.Border.RightColor = System.Drawing.Color.Black
        Me.FieldSix.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSix.Border.TopColor = System.Drawing.Color.Black
        Me.FieldSix.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSix.CanShrink = True
        Me.FieldSix.DataField = "RegistrationType"
        Me.FieldSix.Height = 0.1666667!
        Me.FieldSix.Left = 7.732639!
        Me.FieldSix.Name = "FieldSix"
        Me.FieldSix.Style = "font-size: 9pt; "
        Me.FieldSix.Text = "RegistrationType"
        Me.FieldSix.Top = 0.04166667!
        Me.FieldSix.Width = 1.041667!
        '
        'FieldSeven
        '
        Me.FieldSeven.Border.BottomColor = System.Drawing.Color.Black
        Me.FieldSeven.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSeven.Border.LeftColor = System.Drawing.Color.Black
        Me.FieldSeven.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSeven.Border.RightColor = System.Drawing.Color.Black
        Me.FieldSeven.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSeven.Border.TopColor = System.Drawing.Color.Black
        Me.FieldSeven.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FieldSeven.CanShrink = True
        Me.FieldSeven.DataField = "Status"
        Me.FieldSeven.Height = 0.1666667!
        Me.FieldSeven.Left = 8.802083!
        Me.FieldSeven.Name = "FieldSeven"
        Me.FieldSeven.Style = "font-size: 9pt; "
        Me.FieldSeven.Text = "Status"
        Me.FieldSeven.Top = 0.04166667!
        Me.FieldSeven.Width = 1.041667!
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
        Me.ReportInfo1.Left = 3.75!
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
        'PatentIDHeader
        '
        Me.PatentIDHeader.CanShrink = True
        Me.PatentIDHeader.ColumnGroupKeepTogether = True
        Me.PatentIDHeader.DataField = "PatentID"
        Me.PatentIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.PatentIDHeader.Height = 0.0!
        Me.PatentIDHeader.Name = "PatentIDHeader"
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
        Me.Line3.Width = 9.875!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 9.875!
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
        Me.Label1.Text = "Patent:"
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
        'PatentIDFooter
        '
        Me.PatentIDFooter.Height = 0.0!
        Me.PatentIDFooter.Name = "PatentIDFooter"
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
        Me.Line2.Top = 0.02083333!
        Me.Line2.Width = 9.875!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.875!
        Me.Line2.Y1 = 0.02083333!
        Me.Line2.Y2 = 0.02083333!
        '
        'CompanyHeader
        '
        Me.CompanyHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCompanyName1, Me.Label1, Me.Line4, Me.Line3, Me.LabelTwo, Me.LabelThree, Me.LabelFour, Me.LabelSeven, Me.LabelSix, Me.LabelOne, Me.LabelFive})
        Me.CompanyHeader.DataField = "CompanyID"
        Me.CompanyHeader.Height = 0.75!
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
        Me.Line4.Top = 0.375!
        Me.Line4.Width = 9.875!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.875!
        Me.Line4.Y1 = 0.375!
        Me.Line4.Y2 = 0.375!
        '
        'LabelTwo
        '
        Me.LabelTwo.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelTwo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelTwo.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelTwo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelTwo.Border.RightColor = System.Drawing.Color.Black
        Me.LabelTwo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelTwo.Border.TopColor = System.Drawing.Color.Black
        Me.LabelTwo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelTwo.Height = 0.1666667!
        Me.LabelTwo.HyperLink = Nothing
        Me.LabelTwo.Left = 3.475695!
        Me.LabelTwo.Name = "LabelTwo"
        Me.LabelTwo.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelTwo.Text = "Application:"
        Me.LabelTwo.Top = 0.5416667!
        Me.LabelTwo.Width = 1.0!
        '
        'LabelThree
        '
        Me.LabelThree.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelThree.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelThree.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelThree.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelThree.Border.RightColor = System.Drawing.Color.Black
        Me.LabelThree.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelThree.Border.TopColor = System.Drawing.Color.Black
        Me.LabelThree.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelThree.Height = 0.1666667!
        Me.LabelThree.HyperLink = Nothing
        Me.LabelThree.Left = 4.545139!
        Me.LabelThree.Name = "LabelThree"
        Me.LabelThree.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelThree.Text = "Patent Number:"
        Me.LabelThree.Top = 0.5416667!
        Me.LabelThree.Width = 1.0!
        '
        'LabelFour
        '
        Me.LabelFour.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelFour.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFour.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelFour.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFour.Border.RightColor = System.Drawing.Color.Black
        Me.LabelFour.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFour.Border.TopColor = System.Drawing.Color.Black
        Me.LabelFour.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFour.Height = 0.1666667!
        Me.LabelFour.HyperLink = Nothing
        Me.LabelFour.Left = 5.614583!
        Me.LabelFour.Name = "LabelFour"
        Me.LabelFour.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFour.Text = "Jurisdiction:"
        Me.LabelFour.Top = 0.5416667!
        Me.LabelFour.Width = 1.0!
        '
        'LabelSeven
        '
        Me.LabelSeven.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelSeven.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSeven.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelSeven.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSeven.Border.RightColor = System.Drawing.Color.Black
        Me.LabelSeven.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSeven.Border.TopColor = System.Drawing.Color.Black
        Me.LabelSeven.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSeven.Height = 0.1666667!
        Me.LabelSeven.HyperLink = Nothing
        Me.LabelSeven.Left = 8.8125!
        Me.LabelSeven.Name = "LabelSeven"
        Me.LabelSeven.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelSeven.Text = "Status:"
        Me.LabelSeven.Top = 0.5416667!
        Me.LabelSeven.Width = 1.0!
        '
        'LabelSix
        '
        Me.LabelSix.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelSix.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSix.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelSix.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSix.Border.RightColor = System.Drawing.Color.Black
        Me.LabelSix.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSix.Border.TopColor = System.Drawing.Color.Black
        Me.LabelSix.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelSix.Height = 0.1666667!
        Me.LabelSix.HyperLink = Nothing
        Me.LabelSix.Left = 7.743055!
        Me.LabelSix.Name = "LabelSix"
        Me.LabelSix.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelSix.Text = "Reg. Type:"
        Me.LabelSix.Top = 0.5416667!
        Me.LabelSix.Width = 1.0!
        '
        'LabelOne
        '
        Me.LabelOne.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelOne.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelOne.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelOne.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelOne.Border.RightColor = System.Drawing.Color.Black
        Me.LabelOne.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelOne.Border.TopColor = System.Drawing.Color.Black
        Me.LabelOne.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelOne.Height = 0.1666667!
        Me.LabelOne.HyperLink = Nothing
        Me.LabelOne.Left = 2.416667!
        Me.LabelOne.Name = "LabelOne"
        Me.LabelOne.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelOne.Text = "File Number:"
        Me.LabelOne.Top = 0.5416667!
        Me.LabelOne.Width = 1.0!
        '
        'LabelFive
        '
        Me.LabelFive.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelFive.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFive.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelFive.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFive.Border.RightColor = System.Drawing.Color.Black
        Me.LabelFive.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFive.Border.TopColor = System.Drawing.Color.Black
        Me.LabelFive.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelFive.Height = 0.1666667!
        Me.LabelFive.HyperLink = Nothing
        Me.LabelFive.Left = 6.684029!
        Me.LabelFive.Name = "LabelFive"
        Me.LabelFive.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFive.Text = "Filing Basis:"
        Me.LabelFive.Top = 0.5416667!
        Me.LabelFive.Width = 1.0!
        '
        'CompanyFooter
        '
        Me.CompanyFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyCountLabel, Me.CompanyCount})
        Me.CompanyFooter.Height = 0.28125!
        Me.CompanyFooter.Name = "CompanyFooter"
        '
        'CompanyCountLabel
        '
        Me.CompanyCountLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.CompanyCountLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCountLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.CompanyCountLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCountLabel.Border.RightColor = System.Drawing.Color.Black
        Me.CompanyCountLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCountLabel.Border.TopColor = System.Drawing.Color.Black
        Me.CompanyCountLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCountLabel.CanShrink = True
        Me.CompanyCountLabel.Height = 0.1666667!
        Me.CompanyCountLabel.Left = 3.791667!
        Me.CompanyCountLabel.Name = "CompanyCountLabel"
        Me.CompanyCountLabel.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.CompanyCountLabel.Text = "Total Patents for:"
        Me.CompanyCountLabel.Top = 0.08333334!
        Me.CompanyCountLabel.Width = 5.166667!
        '
        'CompanyCount
        '
        Me.CompanyCount.Border.BottomColor = System.Drawing.Color.Black
        Me.CompanyCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCount.Border.LeftColor = System.Drawing.Color.Black
        Me.CompanyCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCount.Border.RightColor = System.Drawing.Color.Black
        Me.CompanyCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCount.Border.TopColor = System.Drawing.Color.Black
        Me.CompanyCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyCount.CanShrink = True
        Me.CompanyCount.DataField = "PatentID"
        Me.CompanyCount.Height = 0.1666667!
        Me.CompanyCount.Left = 9.083333!
        Me.CompanyCount.Name = "CompanyCount"
        Me.CompanyCount.Style = "font-weight: bold; font-size: 9pt; "
        Me.CompanyCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.CompanyCount.SummaryGroup = "CompanyHeader"
        Me.CompanyCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.CompanyCount.Text = "CompanyCount"
        Me.CompanyCount.Top = 0.08333334!
        Me.CompanyCount.Width = 0.7083333!
        '
        'rptPatentsByCompanyList
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportPatentsList order by companyname, companyid, Patentname, Pa" & _
            "tentid"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.875!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.CompanyHeader)
        Me.Sections.Add(Me.PatentIDHeader)
        Me.Sections.Add(Me.PatentDetail)
        Me.Sections.Add(Me.PatentIDFooter)
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
        CType(Me.txtPatentName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldSix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldSeven, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelSeven, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelSix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyCountLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents PatentIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PatentIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPatentName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents CompanyFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyCountLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyCount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelTwo As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelThree As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelFour As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelSeven As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelSix As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelOne As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelFive As DataDynamics.ActiveReports.Label
    Friend WithEvents FieldOne As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldTwo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldThree As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldFour As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldFive As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldSix As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldSeven As DataDynamics.ActiveReports.TextBox
End Class
