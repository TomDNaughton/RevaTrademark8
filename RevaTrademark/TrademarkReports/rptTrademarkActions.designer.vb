<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTrademarkActions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTrademarkActions))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportSubtitle = New DataDynamics.ActiveReports.TextBox
        Me.DateDetail = New DataDynamics.ActiveReports.Detail
        Me.ActionDate = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkAction = New DataDynamics.ActiveReports.TextBox
        Me.ExpensesBilled = New DataDynamics.ActiveReports.CheckBox
        Me.ActionHours = New DataDynamics.ActiveReports.TextBox
        Me.Expenses = New DataDynamics.ActiveReports.TextBox
        Me.UnBilledHours = New DataDynamics.ActiveReports.TextBox
        Me.BilledHours = New DataDynamics.ActiveReports.TextBox
        Me.ActionBilled = New DataDynamics.ActiveReports.CheckBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.BilledExpenses = New DataDynamics.ActiveReports.TextBox
        Me.FieldFour = New DataDynamics.ActiveReports.TextBox
        Me.FieldTwo = New DataDynamics.ActiveReports.TextBox
        Me.FieldThree = New DataDynamics.ActiveReports.TextBox
        Me.txtTrademarkName1 = New DataDynamics.ActiveReports.TextBox
        Me.FieldOne = New DataDynamics.ActiveReports.TextBox
        Me.FieldFive = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TrademarkIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.FieldSix = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.LabelFour = New DataDynamics.ActiveReports.Label
        Me.LabelTwo = New DataDynamics.ActiveReports.Label
        Me.LabelThree = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.TotalUnbilledExpenses = New DataDynamics.ActiveReports.TextBox
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.TotalBilledHours = New DataDynamics.ActiveReports.TextBox
        Me.TotalBilledExpenses = New DataDynamics.ActiveReports.TextBox
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TotalUnbilledHours = New DataDynamics.ActiveReports.TextBox
        Me.CompanyHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.LabelOne = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.LabelFive = New DataDynamics.ActiveReports.Label
        Me.LabelSix = New DataDynamics.ActiveReports.Label
        Me.CompanyFooter = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrademarkAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesBilled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActionHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Expenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnBilledHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BilledHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActionBilled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BilledExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldSix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalUnbilledExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalBilledHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalBilledExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalUnbilledHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelSix, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportGraphic.Left = 8.0!
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
        Me.Line1.Height = 0.00333333!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 3.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Tag = ""
        Me.Line1.Top = 0.6666667!
        Me.Line1.Width = 9.8125!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.8125!
        Me.Line1.Y1 = 0.6666667!
        Me.Line1.Y2 = 0.67!
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
        Me.DateDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ActionDate, Me.TrademarkAction, Me.ExpensesBilled, Me.ActionHours, Me.Expenses, Me.UnBilledHours, Me.BilledHours, Me.ActionBilled, Me.TextBox1, Me.BilledExpenses})
        Me.DateDetail.Height = 0.25!
        Me.DateDetail.Name = "DateDetail"
        '
        'ActionDate
        '
        Me.ActionDate.Border.BottomColor = System.Drawing.Color.Black
        Me.ActionDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionDate.Border.LeftColor = System.Drawing.Color.Black
        Me.ActionDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionDate.Border.RightColor = System.Drawing.Color.Black
        Me.ActionDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionDate.Border.TopColor = System.Drawing.Color.Black
        Me.ActionDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionDate.DataField = "ActionDate"
        Me.ActionDate.Height = 0.1666667!
        Me.ActionDate.Left = 0.0!
        Me.ActionDate.Name = "ActionDate"
        Me.ActionDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.ActionDate.Tag = ""
        Me.ActionDate.Text = "ActionDate"
        Me.ActionDate.Top = 0.04166667!
        Me.ActionDate.Width = 0.875!
        '
        'TrademarkAction
        '
        Me.TrademarkAction.Border.BottomColor = System.Drawing.Color.Black
        Me.TrademarkAction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkAction.Border.LeftColor = System.Drawing.Color.Black
        Me.TrademarkAction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkAction.Border.RightColor = System.Drawing.Color.Black
        Me.TrademarkAction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkAction.Border.TopColor = System.Drawing.Color.Black
        Me.TrademarkAction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkAction.CanShrink = True
        Me.TrademarkAction.DataField = "TrademarkAction"
        Me.TrademarkAction.Height = 0.1666667!
        Me.TrademarkAction.Left = 0.9375!
        Me.TrademarkAction.Name = "TrademarkAction"
        Me.TrademarkAction.Style = "font-size: 9pt; "
        Me.TrademarkAction.Text = "TrademarkAction"
        Me.TrademarkAction.Top = 0.04166667!
        Me.TrademarkAction.Width = 6.791667!
        '
        'ExpensesBilled
        '
        Me.ExpensesBilled.Border.BottomColor = System.Drawing.Color.Black
        Me.ExpensesBilled.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ExpensesBilled.Border.LeftColor = System.Drawing.Color.Black
        Me.ExpensesBilled.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ExpensesBilled.Border.RightColor = System.Drawing.Color.Black
        Me.ExpensesBilled.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ExpensesBilled.Border.TopColor = System.Drawing.Color.Black
        Me.ExpensesBilled.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ExpensesBilled.DataField = "ExpensesBilled"
        Me.ExpensesBilled.Height = 0.1875!
        Me.ExpensesBilled.Left = 9.5625!
        Me.ExpensesBilled.Name = "ExpensesBilled"
        Me.ExpensesBilled.Style = "font-size: 9pt; "
        Me.ExpensesBilled.Text = ""
        Me.ExpensesBilled.Top = 0.02083333!
        Me.ExpensesBilled.Width = 0.1875!
        '
        'ActionHours
        '
        Me.ActionHours.Border.BottomColor = System.Drawing.Color.Black
        Me.ActionHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionHours.Border.LeftColor = System.Drawing.Color.Black
        Me.ActionHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionHours.Border.RightColor = System.Drawing.Color.Black
        Me.ActionHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionHours.Border.TopColor = System.Drawing.Color.Black
        Me.ActionHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionHours.CanShrink = True
        Me.ActionHours.CountNullValues = True
        Me.ActionHours.DataField = "ActionHours"
        Me.ActionHours.Height = 0.1875!
        Me.ActionHours.Left = 7.802083!
        Me.ActionHours.Name = "ActionHours"
        Me.ActionHours.OutputFormat = resources.GetString("ActionHours.OutputFormat")
        Me.ActionHours.Style = "text-align: right; font-size: 9pt; "
        Me.ActionHours.Text = "ActionHours"
        Me.ActionHours.Top = 0.04166667!
        Me.ActionHours.Width = 0.4375!
        '
        'Expenses
        '
        Me.Expenses.Border.BottomColor = System.Drawing.Color.Black
        Me.Expenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Expenses.Border.LeftColor = System.Drawing.Color.Black
        Me.Expenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Expenses.Border.RightColor = System.Drawing.Color.Black
        Me.Expenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Expenses.Border.TopColor = System.Drawing.Color.Black
        Me.Expenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Expenses.CanShrink = True
        Me.Expenses.CountNullValues = True
        Me.Expenses.DataField = "Expenses"
        Me.Expenses.Height = 0.1666667!
        Me.Expenses.Left = 8.75!
        Me.Expenses.Name = "Expenses"
        Me.Expenses.OutputFormat = resources.GetString("Expenses.OutputFormat")
        Me.Expenses.Style = "text-align: right; font-size: 9pt; "
        Me.Expenses.Text = "Expenses"
        Me.Expenses.Top = 0.04166667!
        Me.Expenses.Width = 0.65625!
        '
        'UnBilledHours
        '
        Me.UnBilledHours.Border.BottomColor = System.Drawing.Color.Black
        Me.UnBilledHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.UnBilledHours.Border.LeftColor = System.Drawing.Color.Black
        Me.UnBilledHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.UnBilledHours.Border.RightColor = System.Drawing.Color.Black
        Me.UnBilledHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.UnBilledHours.Border.TopColor = System.Drawing.Color.Black
        Me.UnBilledHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.UnBilledHours.CanShrink = True
        Me.UnBilledHours.CountNullValues = True
        Me.UnBilledHours.DataField = "UnBilledHours"
        Me.UnBilledHours.Height = 0.1666667!
        Me.UnBilledHours.Left = 4.375!
        Me.UnBilledHours.Name = "UnBilledHours"
        Me.UnBilledHours.OutputFormat = resources.GetString("UnBilledHours.OutputFormat")
        Me.UnBilledHours.Style = "text-align: right; font-weight: bold; background-color: AntiqueWhite; font-size: " & _
            "9pt; "
        Me.UnBilledHours.Text = "UnBilledHours"
        Me.UnBilledHours.Top = 0.0625!
        Me.UnBilledHours.Visible = False
        Me.UnBilledHours.Width = 0.5625!
        '
        'BilledHours
        '
        Me.BilledHours.Border.BottomColor = System.Drawing.Color.Black
        Me.BilledHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledHours.Border.LeftColor = System.Drawing.Color.Black
        Me.BilledHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledHours.Border.RightColor = System.Drawing.Color.Black
        Me.BilledHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledHours.Border.TopColor = System.Drawing.Color.Black
        Me.BilledHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledHours.CanShrink = True
        Me.BilledHours.CountNullValues = True
        Me.BilledHours.DataField = "BilledHours"
        Me.BilledHours.Height = 0.1875!
        Me.BilledHours.Left = 8.8125!
        Me.BilledHours.Name = "BilledHours"
        Me.BilledHours.OutputFormat = resources.GetString("BilledHours.OutputFormat")
        Me.BilledHours.Style = "text-align: right; font-weight: bold; background-color: AntiqueWhite; font-size: " & _
            "9pt; "
        Me.BilledHours.Text = "BilledHours"
        Me.BilledHours.Top = 0.0625!
        Me.BilledHours.Visible = False
        Me.BilledHours.Width = 0.25!
        '
        'ActionBilled
        '
        Me.ActionBilled.Border.BottomColor = System.Drawing.Color.Black
        Me.ActionBilled.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionBilled.Border.LeftColor = System.Drawing.Color.Black
        Me.ActionBilled.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionBilled.Border.RightColor = System.Drawing.Color.Black
        Me.ActionBilled.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionBilled.Border.TopColor = System.Drawing.Color.Black
        Me.ActionBilled.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ActionBilled.DataField = "ActionBilled"
        Me.ActionBilled.Height = 0.1875!
        Me.ActionBilled.Left = 8.354167!
        Me.ActionBilled.Name = "ActionBilled"
        Me.ActionBilled.Style = "font-size: 9pt; "
        Me.ActionBilled.Text = ""
        Me.ActionBilled.Top = 0.02083333!
        Me.ActionBilled.Width = 0.1875!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.CanShrink = True
        Me.TextBox1.CountNullValues = True
        Me.TextBox1.DataField = "UnBilledHours"
        Me.TextBox1.Height = 0.1666667!
        Me.TextBox1.Left = 5.020833!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "text-align: right; font-weight: bold; background-color: AntiqueWhite; font-size: " & _
            "9pt; "
        Me.TextBox1.Text = "UnBilledExpenses"
        Me.TextBox1.Top = 0.03125!
        Me.TextBox1.Visible = False
        Me.TextBox1.Width = 0.5625!
        '
        'BilledExpenses
        '
        Me.BilledExpenses.Border.BottomColor = System.Drawing.Color.Black
        Me.BilledExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledExpenses.Border.LeftColor = System.Drawing.Color.Black
        Me.BilledExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledExpenses.Border.RightColor = System.Drawing.Color.Black
        Me.BilledExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledExpenses.Border.TopColor = System.Drawing.Color.Black
        Me.BilledExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BilledExpenses.CanShrink = True
        Me.BilledExpenses.CountNullValues = True
        Me.BilledExpenses.DataField = "BilledExpenses"
        Me.BilledExpenses.Height = 0.1875!
        Me.BilledExpenses.Left = 9.166667!
        Me.BilledExpenses.Name = "BilledExpenses"
        Me.BilledExpenses.OutputFormat = resources.GetString("BilledExpenses.OutputFormat")
        Me.BilledExpenses.Style = "text-align: right; font-weight: bold; background-color: AntiqueWhite; font-size: " & _
            "9pt; "
        Me.BilledExpenses.Text = "BilledExpenses"
        Me.BilledExpenses.Top = 0.02083333!
        Me.BilledExpenses.Visible = False
        Me.BilledExpenses.Width = 0.25!
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
        Me.FieldFour.Height = 0.1875!
        Me.FieldFour.Left = 6.537499!
        Me.FieldFour.Name = "FieldFour"
        Me.FieldFour.Style = "font-size: 9pt; "
        Me.FieldFour.Text = "Jurisdiction"
        Me.FieldFour.Top = 0.0!
        Me.FieldFour.Width = 1.052083!
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
        Me.FieldTwo.Left = 4.304166!
        Me.FieldTwo.Name = "FieldTwo"
        Me.FieldTwo.Style = "font-size: 9pt; "
        Me.FieldTwo.Text = "ApplicationNumber"
        Me.FieldTwo.Top = 0.0!
        Me.FieldTwo.Width = 1.052083!
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
        Me.FieldThree.Left = 5.420832!
        Me.FieldThree.Name = "FieldThree"
        Me.FieldThree.Style = "font-size: 9pt; "
        Me.FieldThree.Text = "RegistrationNumber"
        Me.FieldThree.Top = 0.0!
        Me.FieldThree.Width = 1.052083!
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
        Me.txtTrademarkName1.Height = 0.1875!
        Me.txtTrademarkName1.Left = 0.0!
        Me.txtTrademarkName1.Name = "txtTrademarkName1"
        Me.txtTrademarkName1.Style = "font-weight: bold; font-size: 9pt; "
        Me.txtTrademarkName1.Text = "txtTrademarkName1"
        Me.txtTrademarkName1.Top = 0.0!
        Me.txtTrademarkName1.Width = 3.125!
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
        Me.FieldOne.Left = 3.1875!
        Me.FieldOne.Name = "FieldOne"
        Me.FieldOne.Style = "font-size: 9pt; "
        Me.FieldOne.Text = "fileNumber"
        Me.FieldOne.Top = 0.0!
        Me.FieldOne.Width = 1.052083!
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
        Me.FieldFive.Left = 7.654165!
        Me.FieldFive.Name = "FieldFive"
        Me.FieldFive.Style = "font-size: 9pt; "
        Me.FieldFive.Text = "FilingBasis"
        Me.FieldFive.Top = 0.0!
        Me.FieldFive.Width = 1.052083!
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
        Me.ReportInfo1.Left = 3.78125!
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
        Me.TrademarkIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTrademarkName1, Me.FieldTwo, Me.FieldThree, Me.FieldFour, Me.FieldOne, Me.FieldFive, Me.Line5, Me.FieldSix, Me.Line2, Me.Label8, Me.Label9, Me.Label10, Me.Label13})
        Me.TrademarkIDHeader.DataField = "TrademarkID"
        Me.TrademarkIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.TrademarkIDHeader.Height = 0.5!
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
        Me.Line5.Width = 9.8125!
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 9.8125!
        Me.Line5.Y1 = 0.1875!
        Me.Line5.Y2 = 0.1875!
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
        Me.FieldSix.DataField = "Status"
        Me.FieldSix.Height = 0.1666667!
        Me.FieldSix.Left = 8.770833!
        Me.FieldSix.Name = "FieldSix"
        Me.FieldSix.Style = "font-size: 9pt; "
        Me.FieldSix.Text = "Status"
        Me.FieldSix.Top = 0.0!
        Me.FieldSix.Width = 1.052083!
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
        Me.Line2.Top = 0.4583333!
        Me.Line2.Width = 9.8125!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.8125!
        Me.Line2.Y1 = 0.4583333!
        Me.Line2.Y2 = 0.4583333!
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
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 7.770833!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label8.Text = "Hours:"
        Me.Label8.Top = 0.3125!
        Me.Label8.Width = 0.4375!
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
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 8.75!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label9.Text = "Expenses:"
        Me.Label9.Top = 0.3125!
        Me.Label9.Width = 0.6875!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 9.4375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label10.Text = "Billed:"
        Me.Label10.Top = 0.3125!
        Me.Label10.Width = 0.4375!
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
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 8.260417!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label13.Text = "Billed:"
        Me.Label13.Top = 0.3125!
        Me.Label13.Width = 0.4270833!
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
        Me.LabelFour.Left = 6.541667!
        Me.LabelFour.Name = "LabelFour"
        Me.LabelFour.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFour.Text = "Jurisdiction:"
        Me.LabelFour.Top = 0.5520833!
        Me.LabelFour.Width = 1.052083!
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
        Me.LabelTwo.Left = 4.322916!
        Me.LabelTwo.Name = "LabelTwo"
        Me.LabelTwo.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelTwo.Text = "Application:"
        Me.LabelTwo.Top = 0.5520833!
        Me.LabelTwo.Width = 1.052083!
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
        Me.LabelThree.Left = 5.427083!
        Me.LabelThree.Name = "LabelThree"
        Me.LabelThree.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelThree.Text = "Registration:"
        Me.LabelThree.Top = 0.5520833!
        Me.LabelThree.Width = 1.052083!
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
        Me.Line3.Width = 9.8125!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 9.8125!
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
        Me.Label1.Top = 0.5520833!
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
        Me.TrademarkIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line6, Me.Line7, Me.TotalUnbilledExpenses, Me.Label11, Me.TotalBilledHours, Me.TotalBilledExpenses, Me.Label12, Me.TotalUnbilledHours})
        Me.TrademarkIDFooter.Height = 0.4270833!
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
        Me.Line6.Width = 9.8125!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 9.8125!
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
        Me.Line7.LineWeight = 3.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Tag = ""
        Me.Line7.Top = 0.3958333!
        Me.Line7.Width = 9.8125!
        Me.Line7.X1 = 0.0!
        Me.Line7.X2 = 9.8125!
        Me.Line7.Y1 = 0.3958333!
        Me.Line7.Y2 = 0.3958333!
        '
        'TotalUnbilledExpenses
        '
        Me.TotalUnbilledExpenses.Border.BottomColor = System.Drawing.Color.Black
        Me.TotalUnbilledExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledExpenses.Border.LeftColor = System.Drawing.Color.Black
        Me.TotalUnbilledExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledExpenses.Border.RightColor = System.Drawing.Color.Black
        Me.TotalUnbilledExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledExpenses.Border.TopColor = System.Drawing.Color.Black
        Me.TotalUnbilledExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledExpenses.CanShrink = True
        Me.TotalUnbilledExpenses.CountNullValues = True
        Me.TotalUnbilledExpenses.DataField = "UnBilledExpenses"
        Me.TotalUnbilledExpenses.Height = 0.1666667!
        Me.TotalUnbilledExpenses.Left = 2.895834!
        Me.TotalUnbilledExpenses.Name = "TotalUnbilledExpenses"
        Me.TotalUnbilledExpenses.OutputFormat = resources.GetString("TotalUnbilledExpenses.OutputFormat")
        Me.TotalUnbilledExpenses.Style = "text-align: right; font-size: 9pt; "
        Me.TotalUnbilledExpenses.SummaryGroup = "TrademarkIDHeader"
        Me.TotalUnbilledExpenses.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TotalUnbilledExpenses.Text = "TotalUnbilledExpenses"
        Me.TotalUnbilledExpenses.Top = 0.05208333!
        Me.TotalUnbilledExpenses.Width = 0.75!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Height = 0.1666667!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.1458337!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label11.Text = "Total Unbilled Hours\Expenses:"
        Me.Label11.Top = 0.05208333!
        Me.Label11.Width = 2.0625!
        '
        'TotalBilledHours
        '
        Me.TotalBilledHours.Border.BottomColor = System.Drawing.Color.Black
        Me.TotalBilledHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledHours.Border.LeftColor = System.Drawing.Color.Black
        Me.TotalBilledHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledHours.Border.RightColor = System.Drawing.Color.Black
        Me.TotalBilledHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledHours.Border.TopColor = System.Drawing.Color.Black
        Me.TotalBilledHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledHours.CanShrink = True
        Me.TotalBilledHours.CountNullValues = True
        Me.TotalBilledHours.DataField = "BilledHours"
        Me.TotalBilledHours.Height = 0.1666667!
        Me.TotalBilledHours.Left = 6.114583!
        Me.TotalBilledHours.Name = "TotalBilledHours"
        Me.TotalBilledHours.OutputFormat = resources.GetString("TotalBilledHours.OutputFormat")
        Me.TotalBilledHours.Style = "text-align: right; font-size: 9pt; "
        Me.TotalBilledHours.SummaryGroup = "TrademarkIDHeader"
        Me.TotalBilledHours.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TotalBilledHours.Text = "TotalBilledHours"
        Me.TotalBilledHours.Top = 0.05208333!
        Me.TotalBilledHours.Width = 0.5625!
        '
        'TotalBilledExpenses
        '
        Me.TotalBilledExpenses.Border.BottomColor = System.Drawing.Color.Black
        Me.TotalBilledExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledExpenses.Border.LeftColor = System.Drawing.Color.Black
        Me.TotalBilledExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledExpenses.Border.RightColor = System.Drawing.Color.Black
        Me.TotalBilledExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledExpenses.Border.TopColor = System.Drawing.Color.Black
        Me.TotalBilledExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalBilledExpenses.CanShrink = True
        Me.TotalBilledExpenses.CountNullValues = True
        Me.TotalBilledExpenses.DataField = "BilledExpenses"
        Me.TotalBilledExpenses.Height = 0.1666667!
        Me.TotalBilledExpenses.Left = 6.729167!
        Me.TotalBilledExpenses.Name = "TotalBilledExpenses"
        Me.TotalBilledExpenses.OutputFormat = resources.GetString("TotalBilledExpenses.OutputFormat")
        Me.TotalBilledExpenses.Style = "text-align: right; font-size: 9pt; "
        Me.TotalBilledExpenses.SummaryGroup = "TrademarkIDHeader"
        Me.TotalBilledExpenses.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TotalBilledExpenses.Text = "TotalBilledExpenses"
        Me.TotalBilledExpenses.Top = 0.05208333!
        Me.TotalBilledExpenses.Width = 0.75!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Height = 0.1666667!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.989583!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label12.Text = "Total Billed Hours\Expenses:"
        Me.Label12.Top = 0.05208333!
        Me.Label12.Width = 2.0625!
        '
        'TotalUnbilledHours
        '
        Me.TotalUnbilledHours.Border.BottomColor = System.Drawing.Color.Black
        Me.TotalUnbilledHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledHours.Border.LeftColor = System.Drawing.Color.Black
        Me.TotalUnbilledHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledHours.Border.RightColor = System.Drawing.Color.Black
        Me.TotalUnbilledHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledHours.Border.TopColor = System.Drawing.Color.Black
        Me.TotalUnbilledHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TotalUnbilledHours.CountNullValues = True
        Me.TotalUnbilledHours.DataField = "UnbilledHours"
        Me.TotalUnbilledHours.Height = 0.1666667!
        Me.TotalUnbilledHours.Left = 2.270834!
        Me.TotalUnbilledHours.Name = "TotalUnbilledHours"
        Me.TotalUnbilledHours.OutputFormat = resources.GetString("TotalUnbilledHours.OutputFormat")
        Me.TotalUnbilledHours.Style = "text-align: right; font-size: 9pt; "
        Me.TotalUnbilledHours.SummaryGroup = "TrademarkIDHeader"
        Me.TotalUnbilledHours.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TotalUnbilledHours.Text = "TotalUnbilledHours"
        Me.TotalUnbilledHours.Top = 0.05208333!
        Me.TotalUnbilledHours.Width = 0.5625!
        '
        'CompanyHeader
        '
        Me.CompanyHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCompanyName1, Me.Label1, Me.LabelTwo, Me.LabelThree, Me.LabelFour, Me.LabelOne, Me.Line4, Me.Line3, Me.LabelFive, Me.LabelSix})
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
        Me.LabelOne.Left = 3.1875!
        Me.LabelOne.Name = "LabelOne"
        Me.LabelOne.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelOne.Text = "File Number:"
        Me.LabelOne.Top = 0.5520833!
        Me.LabelOne.Width = 1.052083!
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
        Me.Line4.LineWeight = 3.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Tag = ""
        Me.Line4.Top = 0.375!
        Me.Line4.Width = 9.8125!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.8125!
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
        Me.LabelFive.Height = 0.1666667!
        Me.LabelFive.HyperLink = Nothing
        Me.LabelFive.Left = 7.65625!
        Me.LabelFive.Name = "LabelFive"
        Me.LabelFive.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelFive.Text = "Filing Basis:"
        Me.LabelFive.Top = 0.5520833!
        Me.LabelFive.Width = 1.052083!
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
        Me.LabelSix.Left = 8.770833!
        Me.LabelSix.Name = "LabelSix"
        Me.LabelSix.Style = "text-align: left; font-weight: bold; font-size: 9pt; "
        Me.LabelSix.Text = "Status:"
        Me.LabelSix.Top = 0.5520833!
        Me.LabelSix.Width = 1.052083!
        '
        'CompanyFooter
        '
        Me.CompanyFooter.Height = 0.01041667!
        Me.CompanyFooter.Name = "CompanyFooter"
        '
        'rptTrademarkActions
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademar" & _
            "k\RevaTrademark.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportTrademarkActions order by companyname, companyid, trademark" & _
            "name, trademarkid, actiondate"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.895833!
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
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportSubtitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrademarkAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesBilled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActionHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Expenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnBilledHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BilledHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActionBilled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BilledExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrademarkName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldSix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalUnbilledExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalBilledHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalBilledExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalUnbilledHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelOne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelFive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelSix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TrademarkIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents TrademarkIDFooter As DataDynamics.ActiveReports.GroupFooter
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
    Friend WithEvents txtTrademarkName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents CompanyFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents FieldOne As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelOne As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents FieldFive As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelFive As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents ActionDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents TrademarkAction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FieldSix As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelSix As DataDynamics.ActiveReports.Label
    Friend WithEvents ExpensesBilled As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents ActionHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Expenses As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents TotalUnbilledExpenses As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents TotalBilledHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TotalBilledExpenses As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TotalUnbilledHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents UnBilledHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BilledHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ActionBilled As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BilledExpenses As DataDynamics.ActiveReports.TextBox
End Class
