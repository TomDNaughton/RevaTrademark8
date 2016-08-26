<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPatentsByCompanyDates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPatentsByCompanyDates))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.DateDetail = New DataDynamics.ActiveReports.Detail
        Me.DateName = New DataDynamics.ActiveReports.TextBox
        Me.PatentDate = New DataDynamics.ActiveReports.TextBox
        Me.MonthYear = New DataDynamics.ActiveReports.TextBox
        Me.Completed = New DataDynamics.ActiveReports.CheckBox
        Me.FieldFour = New DataDynamics.ActiveReports.TextBox
        Me.FieldTwo = New DataDynamics.ActiveReports.TextBox
        Me.FieldThree = New DataDynamics.ActiveReports.TextBox
        Me.PatentName = New DataDynamics.ActiveReports.TextBox
        Me.FieldOne = New DataDynamics.ActiveReports.TextBox
        Me.FieldFive = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.PatentIDIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.LabelFour = New DataDynamics.ActiveReports.Label
        Me.LabelTwo = New DataDynamics.ActiveReports.Label
        Me.LabelThree = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.PatentIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.LabelOne = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.LabelFive = New DataDynamics.ActiveReports.Label
        Me.CompanyFooter = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DateDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.DateName, Me.PatentDate, Me.MonthYear, Me.Completed})
        Me.DateDetail.Height = 0.25!
        Me.DateDetail.Name = "DateDetail"
        '
        'DateName
        '
        Me.DateName.Border.BottomColor = System.Drawing.Color.Black
        Me.DateName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateName.Border.LeftColor = System.Drawing.Color.Black
        Me.DateName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateName.Border.RightColor = System.Drawing.Color.Black
        Me.DateName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateName.Border.TopColor = System.Drawing.Color.Black
        Me.DateName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DateName.DataField = "DateName"
        Me.DateName.Height = 0.2083333!
        Me.DateName.Left = 0.0!
        Me.DateName.Name = "DateName"
        Me.DateName.Style = "color: Black; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.DateName.Tag = ""
        Me.DateName.Text = "DateName"
        Me.DateName.Top = 0.02083333!
        Me.DateName.Width = 2.583333!
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
        Me.PatentDate.Left = 2.625!
        Me.PatentDate.Name = "PatentDate"
        Me.PatentDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.PatentDate.Tag = ""
        Me.PatentDate.Text = "PatentDate"
        Me.PatentDate.Top = 0.02083333!
        Me.PatentDate.Width = 0.875!
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
        Me.MonthYear.Left = 2.625!
        Me.MonthYear.Name = "MonthYear"
        Me.MonthYear.OutputFormat = resources.GetString("MonthYear.OutputFormat")
        Me.MonthYear.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.MonthYear.Tag = ""
        Me.MonthYear.Text = "MonthYear"
        Me.MonthYear.Top = 0.02083333!
        Me.MonthYear.Visible = False
        Me.MonthYear.Width = 0.9166667!
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
        Me.Completed.Left = 3.625!
        Me.Completed.Name = "Completed"
        Me.Completed.Style = ""
        Me.Completed.Text = ""
        Me.Completed.Top = 0.02083333!
        Me.Completed.Width = 0.2916667!
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
        Me.FieldFour.Left = 5.375!
        Me.FieldFour.Name = "FieldFour"
        Me.FieldFour.Style = "font-size: 9pt; "
        Me.FieldFour.Text = "Jurisdiction"
        Me.FieldFour.Top = 0.0!
        Me.FieldFour.Width = 0.96875!
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
        Me.FieldTwo.Left = 3.375!
        Me.FieldTwo.Name = "FieldTwo"
        Me.FieldTwo.Style = "font-size: 9pt; "
        Me.FieldTwo.Text = "ApplicationNumber"
        Me.FieldTwo.Top = 0.0!
        Me.FieldTwo.Width = 0.96875!
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
        Me.FieldThree.DataField = "PatentNumber"
        Me.FieldThree.Height = 0.1666667!
        Me.FieldThree.Left = 4.375!
        Me.FieldThree.Name = "FieldThree"
        Me.FieldThree.Style = "font-size: 9pt; "
        Me.FieldThree.Text = "PatentNumber"
        Me.FieldThree.Top = 0.0!
        Me.FieldThree.Width = 0.96875!
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
        Me.PatentName.Top = 0.0!
        Me.PatentName.Width = 2.333333!
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
        Me.FieldOne.Left = 2.375!
        Me.FieldOne.Name = "FieldOne"
        Me.FieldOne.Style = "font-size: 9pt; "
        Me.FieldOne.Text = "fileNumber"
        Me.FieldOne.Top = 0.0!
        Me.FieldOne.Width = 0.96875!
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
        Me.FieldFive.DataField = "PatentType"
        Me.FieldFive.Height = 0.1666667!
        Me.FieldFive.Left = 6.375!
        Me.FieldFive.Name = "FieldFive"
        Me.FieldFive.Style = "font-size: 9pt; "
        Me.FieldFive.Text = "PatentType"
        Me.FieldFive.Top = 0.0!
        Me.FieldFive.Width = 0.96875!
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
        'PatentIDIDHeader
        '
        Me.PatentIDIDHeader.CanShrink = True
        Me.PatentIDIDHeader.ColumnGroupKeepTogether = True
        Me.PatentIDIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PatentName, Me.FieldTwo, Me.FieldThree, Me.FieldFour, Me.FieldOne, Me.FieldFive, Me.Line5})
        Me.PatentIDIDHeader.DataField = "PatentID"
        Me.PatentIDIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.PatentIDIDHeader.Height = 0.21875!
        Me.PatentIDIDHeader.Name = "PatentIDIDHeader"
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
        Me.LabelFour.Left = 5.375!
        Me.LabelFour.Name = "LabelFour"
        Me.LabelFour.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFour.Text = "Jurisdiction:"
        Me.LabelFour.Top = 0.5416667!
        Me.LabelFour.Width = 0.96875!
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
        Me.LabelTwo.Left = 3.375!
        Me.LabelTwo.Name = "LabelTwo"
        Me.LabelTwo.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelTwo.Text = "Application:"
        Me.LabelTwo.Top = 0.5416667!
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
        Me.LabelThree.Left = 4.375!
        Me.LabelThree.Name = "LabelThree"
        Me.LabelThree.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelThree.Text = "Patent No:"
        Me.LabelThree.Top = 0.5416667!
        Me.LabelThree.Width = 0.96875!
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
        Me.PatentIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line6, Me.Line7})
        Me.PatentIDFooter.Height = 0.1875!
        Me.PatentIDFooter.Name = "PatentIDFooter"
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
        Me.CompanyHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCompanyName1, Me.Label1, Me.LabelTwo, Me.LabelThree, Me.LabelFour, Me.LabelOne, Me.Line4, Me.Line3, Me.LabelFive})
        Me.CompanyHeader.DataField = "CompanyID"
        Me.CompanyHeader.Height = 0.75!
        Me.CompanyHeader.Name = "CompanyHeader"
        Me.CompanyHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before
        Me.CompanyHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
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
        Me.LabelOne.Left = 2.375!
        Me.LabelOne.Name = "LabelOne"
        Me.LabelOne.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelOne.Text = "File Number:"
        Me.LabelOne.Top = 0.5416667!
        Me.LabelOne.Width = 0.96875!
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
        Me.LabelFive.Height = 0.1770834!
        Me.LabelFive.HyperLink = Nothing
        Me.LabelFive.Left = 6.375!
        Me.LabelFive.Name = "LabelFive"
        Me.LabelFive.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFive.Text = "Patent Type:"
        Me.LabelFive.Top = 0.5416667!
        Me.LabelFive.Width = 0.96875!
        '
        'CompanyFooter
        '
        Me.CompanyFooter.Height = 0.01041667!
        Me.CompanyFooter.Name = "CompanyFooter"
        '
        'rptPatentsByCompanyDates
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportPatents order by companyname, companyid, Patentname,Patenti" & _
            "d"
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
        Me.Sections.Add(Me.PatentIDIDHeader)
        Me.Sections.Add(Me.DateDetail)
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
        CType(Me.DateName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents PatentIDIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PatentIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelFour As DataDynamics.ActiveReports.Label
    Friend WithEvents FieldFour As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelTwo As DataDynamics.ActiveReports.Label
    Friend WithEvents FieldTwo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldThree As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelThree As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportSubtitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents PatentName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents CompanyFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents FieldOne As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelOne As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents FieldFive As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelFive As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents DateName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PatentDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MonthYear As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Completed As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
End Class
