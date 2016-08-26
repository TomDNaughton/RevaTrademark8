<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPatentsListGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPatentsListGroup))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.PatentDetail = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupTwoHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupTwoTextField = New DataDynamics.ActiveReports.TextBox
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.GroupOneTextField = New DataDynamics.ActiveReports.TextBox
        Me.GroupTwoFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupTwoCount = New DataDynamics.ActiveReports.TextBox
        Me.GroupTwoCountLabel = New DataDynamics.ActiveReports.TextBox
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.GroupOneHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.GroupOneFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupOneCountLabel = New DataDynamics.ActiveReports.TextBox
        Me.GroupOneCount = New DataDynamics.ActiveReports.TextBox
        Me.LabelGroup = New DataDynamics.ActiveReports.GroupHeader
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.LabelFooter = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupTwoTextField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupOneTextField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupTwoCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupTwoCountLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupOneCountLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupOneCount, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PatentDetail.Height = 0.2604167!
        Me.PatentDetail.Name = "PatentDetail"
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
        'GroupTwoHeader
        '
        Me.GroupTwoHeader.CanShrink = True
        Me.GroupTwoHeader.ColumnGroupKeepTogether = True
        Me.GroupTwoHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.GroupTwoTextField, Me.Line6})
        Me.GroupTwoHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupTwoHeader.Height = 0.3!
        Me.GroupTwoHeader.Name = "GroupTwoHeader"
        '
        'GroupTwoTextField
        '
        Me.GroupTwoTextField.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupTwoTextField.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoTextField.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupTwoTextField.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoTextField.Border.RightColor = System.Drawing.Color.Black
        Me.GroupTwoTextField.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoTextField.Border.TopColor = System.Drawing.Color.Black
        Me.GroupTwoTextField.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoTextField.CanShrink = True
        Me.GroupTwoTextField.Height = 0.1875!
        Me.GroupTwoTextField.Left = 0.0!
        Me.GroupTwoTextField.Name = "GroupTwoTextField"
        Me.GroupTwoTextField.Style = "font-weight: bold; font-size: 10pt; "
        Me.GroupTwoTextField.Text = "GroupTwoText"
        Me.GroupTwoTextField.Top = 0.08333334!
        Me.GroupTwoTextField.Width = 5.5!
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
        Me.Line6.Top = 0.2708333!
        Me.Line6.Width = 9.875!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 9.875!
        Me.Line6.Y1 = 0.2708333!
        Me.Line6.Y2 = 0.2708333!
        '
        'GroupOneTextField
        '
        Me.GroupOneTextField.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupOneTextField.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneTextField.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupOneTextField.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneTextField.Border.RightColor = System.Drawing.Color.Black
        Me.GroupOneTextField.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneTextField.Border.TopColor = System.Drawing.Color.Black
        Me.GroupOneTextField.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneTextField.CanShrink = True
        Me.GroupOneTextField.Height = 0.25!
        Me.GroupOneTextField.Left = 0.0!
        Me.GroupOneTextField.Name = "GroupOneTextField"
        Me.GroupOneTextField.Style = "font-weight: bold; font-size: 11pt; "
        Me.GroupOneTextField.Text = "GroupOneText"
        Me.GroupOneTextField.Top = 0.0625!
        Me.GroupOneTextField.Width = 5.5!
        '
        'GroupTwoFooter
        '
        Me.GroupTwoFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.GroupTwoCount, Me.GroupTwoCountLabel, Me.Line5})
        Me.GroupTwoFooter.Height = 0.25!
        Me.GroupTwoFooter.Name = "GroupTwoFooter"
        '
        'GroupTwoCount
        '
        Me.GroupTwoCount.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupTwoCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCount.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupTwoCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCount.Border.RightColor = System.Drawing.Color.Black
        Me.GroupTwoCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCount.Border.TopColor = System.Drawing.Color.Black
        Me.GroupTwoCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCount.CanShrink = True
        Me.GroupTwoCount.DataField = "PatentID"
        Me.GroupTwoCount.Height = 0.1875!
        Me.GroupTwoCount.Left = 9.1875!
        Me.GroupTwoCount.Name = "GroupTwoCount"
        Me.GroupTwoCount.Style = "font-weight: bold; font-size: 9pt; "
        Me.GroupTwoCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.GroupTwoCount.SummaryGroup = "GroupTwoHeader"
        Me.GroupTwoCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.GroupTwoCount.Text = "CompanyCount"
        Me.GroupTwoCount.Top = 0.04166667!
        Me.GroupTwoCount.Width = 0.5!
        '
        'GroupTwoCountLabel
        '
        Me.GroupTwoCountLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupTwoCountLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCountLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupTwoCountLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCountLabel.Border.RightColor = System.Drawing.Color.Black
        Me.GroupTwoCountLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCountLabel.Border.TopColor = System.Drawing.Color.Black
        Me.GroupTwoCountLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupTwoCountLabel.CanShrink = True
        Me.GroupTwoCountLabel.Height = 0.1875!
        Me.GroupTwoCountLabel.Left = 3.4375!
        Me.GroupTwoCountLabel.Name = "GroupTwoCountLabel"
        Me.GroupTwoCountLabel.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.GroupTwoCountLabel.Text = "Total Patents:"
        Me.GroupTwoCountLabel.Top = 0.04166667!
        Me.GroupTwoCountLabel.Width = 5.6875!
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
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 9.875!
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 9.875!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.0!
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
        'GroupOneHeader
        '
        Me.GroupOneHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.GroupOneTextField, Me.Line4})
        Me.GroupOneHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupOneHeader.Height = 0.34375!
        Me.GroupOneHeader.Name = "GroupOneHeader"
        Me.GroupOneHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before
        Me.GroupOneHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
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
        Me.Line4.Top = 0.3125!
        Me.Line4.Width = 9.875!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.875!
        Me.Line4.Y1 = 0.3125!
        Me.Line4.Y2 = 0.3125!
        '
        'GroupOneFooter
        '
        Me.GroupOneFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.GroupOneCountLabel, Me.GroupOneCount})
        Me.GroupOneFooter.Height = 0.28125!
        Me.GroupOneFooter.Name = "GroupOneFooter"
        '
        'GroupOneCountLabel
        '
        Me.GroupOneCountLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupOneCountLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCountLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupOneCountLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCountLabel.Border.RightColor = System.Drawing.Color.Black
        Me.GroupOneCountLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCountLabel.Border.TopColor = System.Drawing.Color.Black
        Me.GroupOneCountLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCountLabel.CanShrink = True
        Me.GroupOneCountLabel.Height = 0.1875!
        Me.GroupOneCountLabel.Left = 3.4375!
        Me.GroupOneCountLabel.Name = "GroupOneCountLabel"
        Me.GroupOneCountLabel.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.GroupOneCountLabel.Text = "Total Patents:"
        Me.GroupOneCountLabel.Top = 0.0625!
        Me.GroupOneCountLabel.Width = 5.6875!
        '
        'GroupOneCount
        '
        Me.GroupOneCount.Border.BottomColor = System.Drawing.Color.Black
        Me.GroupOneCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCount.Border.LeftColor = System.Drawing.Color.Black
        Me.GroupOneCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCount.Border.RightColor = System.Drawing.Color.Black
        Me.GroupOneCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCount.Border.TopColor = System.Drawing.Color.Black
        Me.GroupOneCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.GroupOneCount.CanShrink = True
        Me.GroupOneCount.DataField = "PatentID"
        Me.GroupOneCount.Height = 0.1875!
        Me.GroupOneCount.Left = 9.1875!
        Me.GroupOneCount.Name = "GroupOneCount"
        Me.GroupOneCount.Style = "font-weight: bold; font-size: 9pt; "
        Me.GroupOneCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.GroupOneCount.SummaryGroup = "GroupOneHeader"
        Me.GroupOneCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.GroupOneCount.Text = "CompanyCount"
        Me.GroupOneCount.Top = 0.0625!
        Me.GroupOneCount.Width = 0.5!
        '
        'LabelGroup
        '
        Me.LabelGroup.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3})
        Me.LabelGroup.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.LabelGroup.Height = 0.3!
        Me.LabelGroup.Name = "LabelGroup"
        Me.LabelGroup.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
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
        Me.Line3.Top = 0.2708333!
        Me.Line3.Width = 9.875!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 9.875!
        Me.Line3.Y1 = 0.2708333!
        Me.Line3.Y2 = 0.2708333!
        '
        'LabelFooter
        '
        Me.LabelFooter.Height = 0.0!
        Me.LabelFooter.Name = "LabelFooter"
        Me.LabelFooter.Visible = False
        '
        'rptPatentsListGroup
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaPatent\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportPatentsList order by companyname, companyid, Patentna" & _
            "me, Patentid"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.9375!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupOneHeader)
        Me.Sections.Add(Me.GroupTwoHeader)
        Me.Sections.Add(Me.LabelGroup)
        Me.Sections.Add(Me.PatentDetail)
        Me.Sections.Add(Me.LabelFooter)
        Me.Sections.Add(Me.GroupTwoFooter)
        Me.Sections.Add(Me.GroupOneFooter)
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
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupTwoTextField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupOneTextField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupTwoCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupTwoCountLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupOneCountLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupOneCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupTwoHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupTwoFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupOneTextField As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupOneHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupOneFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupOneCountLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupOneCount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupTwoCount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupTwoCountLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents LabelGroup As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents LabelFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupTwoTextField As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
End Class
