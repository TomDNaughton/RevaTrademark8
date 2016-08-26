<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPatentsByNameList
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
    Private WithEvents TrademarkDetail As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPatentsByNameList))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.LabelFive = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LabelTwo = New DataDynamics.ActiveReports.Label
        Me.LabelThree = New DataDynamics.ActiveReports.Label
        Me.LabelOne = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.LabelFour = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.TrademarkDetail = New DataDynamics.ActiveReports.Detail
        Me.FieldThree = New DataDynamics.ActiveReports.TextBox
        Me.FieldOne = New DataDynamics.ActiveReports.TextBox
        Me.FieldTwo = New DataDynamics.ActiveReports.TextBox
        Me.PatentName = New DataDynamics.ActiveReports.TextBox
        Me.FieldFive = New DataDynamics.ActiveReports.TextBox
        Me.FieldFour = New DataDynamics.ActiveReports.TextBox
        Me.CompanyName = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.PatentCount = New DataDynamics.ActiveReports.TextBox
        Me.CompanyCountLabel = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.PatentIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.PatentIDFooter = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyCountLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.ReportGraphic, Me.Line1, Me.ReportSubtitle, Me.LabelFive, Me.Label1, Me.LabelTwo, Me.LabelThree, Me.LabelOne, Me.Label7, Me.LabelFour, Me.Line4})
        Me.PageHeader1.Height = 1.072917!
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
        Me.Line1.Width = 9.916667!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.916667!
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
        Me.LabelFive.Left = 8.854167!
        Me.LabelFive.Name = "LabelFive"
        Me.LabelFive.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFive.Text = "Status:"
        Me.LabelFive.Top = 0.875!
        Me.LabelFive.Width = 0.96875!
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
        Me.Label1.Top = 0.875!
        Me.Label1.Width = 1.25!
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
        Me.LabelTwo.Left = 5.697917!
        Me.LabelTwo.Name = "LabelTwo"
        Me.LabelTwo.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelTwo.Text = "Patent No:"
        Me.LabelTwo.Top = 0.875!
        Me.LabelTwo.Width = 0.96875!
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
        Me.LabelThree.Left = 6.75!
        Me.LabelThree.Name = "LabelThree"
        Me.LabelThree.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelThree.Text = "Jurisdiction:"
        Me.LabelThree.Top = 0.875!
        Me.LabelThree.Width = 0.96875!
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
        Me.LabelOne.Left = 4.645833!
        Me.LabelOne.Name = "LabelOne"
        Me.LabelOne.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelOne.Text = "Application:"
        Me.LabelOne.Top = 0.875!
        Me.LabelOne.Width = 0.96875!
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
        Me.Label7.Left = 2.458333!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label7.Text = "Company/Owner:"
        Me.Label7.Top = 0.875!
        Me.Label7.Width = 1.458333!
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
        Me.LabelFour.Left = 7.802083!
        Me.LabelFour.Name = "LabelFour"
        Me.LabelFour.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFour.Text = "Patent Type:"
        Me.LabelFour.Top = 0.875!
        Me.LabelFour.Width = 0.96875!
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
        Me.Line4.Top = 1.041667!
        Me.Line4.Width = 9.916667!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.916667!
        Me.Line4.Y1 = 1.041667!
        Me.Line4.Y2 = 1.041667!
        '
        'TrademarkDetail
        '
        Me.TrademarkDetail.ColumnSpacing = 0.0!
        Me.TrademarkDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.FieldThree, Me.FieldOne, Me.FieldTwo, Me.PatentName, Me.FieldFive, Me.FieldFour, Me.CompanyName})
        Me.TrademarkDetail.Height = 0.2604167!
        Me.TrademarkDetail.Name = "TrademarkDetail"
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
        Me.FieldThree.DataField = "Jurisdiction"
        Me.FieldThree.Height = 0.1666667!
        Me.FieldThree.Left = 6.75!
        Me.FieldThree.Name = "FieldThree"
        Me.FieldThree.Style = "font-size: 9pt; "
        Me.FieldThree.Text = "Jurisdiction"
        Me.FieldThree.Top = 0.04166667!
        Me.FieldThree.Width = 1.0!
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
        Me.FieldOne.DataField = "ApplicationNumber"
        Me.FieldOne.Height = 0.1666667!
        Me.FieldOne.Left = 4.645833!
        Me.FieldOne.Name = "FieldOne"
        Me.FieldOne.Style = "font-size: 9pt; "
        Me.FieldOne.Text = "ApplicationNumber"
        Me.FieldOne.Top = 0.04166667!
        Me.FieldOne.Width = 1.0!
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
        Me.FieldTwo.DataField = "PatentNumber"
        Me.FieldTwo.Height = 0.1666667!
        Me.FieldTwo.Left = 5.697917!
        Me.FieldTwo.Name = "FieldTwo"
        Me.FieldTwo.Style = "font-size: 9pt; "
        Me.FieldTwo.Text = "PatentNumber"
        Me.FieldTwo.Top = 0.04166667!
        Me.FieldTwo.Width = 1.0!
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
        Me.PatentName.Height = 0.1666667!
        Me.PatentName.Left = 0.0!
        Me.PatentName.Name = "PatentName"
        Me.PatentName.Style = "font-weight: bold; font-size: 9pt; "
        Me.PatentName.Text = "PatentName"
        Me.PatentName.Top = 0.04166667!
        Me.PatentName.Width = 2.333333!
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
        Me.FieldFive.DataField = "Status"
        Me.FieldFive.Height = 0.1666667!
        Me.FieldFive.Left = 8.854167!
        Me.FieldFive.Name = "FieldFive"
        Me.FieldFive.Style = "font-size: 9pt; "
        Me.FieldFive.Text = "Status"
        Me.FieldFive.Top = 0.04166667!
        Me.FieldFive.Width = 1.0!
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
        Me.FieldFour.DataField = "PatentType"
        Me.FieldFour.Height = 0.1666667!
        Me.FieldFour.Left = 7.802083!
        Me.FieldFour.Name = "FieldFour"
        Me.FieldFour.Style = "font-size: 9pt; "
        Me.FieldFour.Text = "PatentType"
        Me.FieldFour.Top = 0.04166667!
        Me.FieldFour.Width = 1.0!
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
        Me.CompanyName.Height = 0.1666667!
        Me.CompanyName.Left = 2.458333!
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Style = "font-size: 9pt; "
        Me.CompanyName.Text = "CompanyName"
        Me.CompanyName.Top = 0.04166667!
        Me.CompanyName.Width = 2.125!
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PatentCount, Me.CompanyCountLabel, Me.Line2})
        Me.ReportFooter1.Height = 0.3020833!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'PatentCount
        '
        Me.PatentCount.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentCount.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentCount.Border.RightColor = System.Drawing.Color.Black
        Me.PatentCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentCount.Border.TopColor = System.Drawing.Color.Black
        Me.PatentCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentCount.CanShrink = True
        Me.PatentCount.DataField = "PatentID"
        Me.PatentCount.Height = 0.1666667!
        Me.PatentCount.Left = 9.125!
        Me.PatentCount.Name = "PatentCount"
        Me.PatentCount.Style = "font-weight: bold; font-size: 9pt; "
        Me.PatentCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.PatentCount.SummaryGroup = "TrademarkIDHeader"
        Me.PatentCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.PatentCount.Text = "PatentCount"
        Me.PatentCount.Top = 0.07291666!
        Me.PatentCount.Width = 0.7083333!
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
        Me.CompanyCountLabel.Left = 3.833333!
        Me.CompanyCountLabel.Name = "CompanyCountLabel"
        Me.CompanyCountLabel.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.CompanyCountLabel.Text = "Total Patents:"
        Me.CompanyCountLabel.Top = 0.07291666!
        Me.CompanyCountLabel.Width = 5.166667!
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
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 9.916667!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.916667!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.0!
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
        'PatentIDFooter
        '
        Me.PatentIDFooter.Height = 0.0!
        Me.PatentIDFooter.Name = "PatentIDFooter"
        '
        'rptPatentsByNameList
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportTrademarksList order by companyname, companyid, trademarkna" & _
            "me, trademarkid"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.916667!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.PatentIDHeader)
        Me.Sections.Add(Me.TrademarkDetail)
        Me.Sections.Add(Me.PatentIDFooter)
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
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyCountLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents PatentIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PatentIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelThree As DataDynamics.ActiveReports.Label
    Friend WithEvents FieldThree As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelOne As DataDynamics.ActiveReports.Label
    Friend WithEvents FieldOne As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldTwo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelTwo As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents PatentName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldFive As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents CompanyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelFive As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyCountLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PatentCount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldFour As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelFour As DataDynamics.ActiveReports.Label
End Class
