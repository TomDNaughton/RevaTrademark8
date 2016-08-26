<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptOneOpposition
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOneOpposition))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.DateDetail = New DataDynamics.ActiveReports.Detail
        Me.DateName = New DataDynamics.ActiveReports.TextBox
        Me.OppositionDate = New DataDynamics.ActiveReports.TextBox
        Me.Completed = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.OppositionIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.OppositionName = New DataDynamics.ActiveReports.TextBox
        Me.txtCompanyName1 = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.OppositionCompany = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.ProceedingNumber = New DataDynamics.ActiveReports.TextBox
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Status = New DataDynamics.ActiveReports.TextBox
        Me.subrptOppositionClientMarks = New DataDynamics.ActiveReports.SubReport
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.subrptOppositionMarks = New DataDynamics.ActiveReports.SubReport
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.OppositionIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.SubrptOppositionActions = New DataDynamics.ActiveReports.SubReport
        Me.FooterLine = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label40.Text = "Trademark Opposition Record"
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
        Me.DateDetail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.DateName, Me.OppositionDate, Me.Completed})
        Me.DateDetail.Height = 0.2083333!
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
        Me.DateName.Top = 0.0!
        Me.DateName.Width = 3.822917!
        '
        'OppositionDate
        '
        Me.OppositionDate.Border.BottomColor = System.Drawing.Color.Black
        Me.OppositionDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionDate.Border.LeftColor = System.Drawing.Color.Black
        Me.OppositionDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionDate.Border.RightColor = System.Drawing.Color.Black
        Me.OppositionDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionDate.Border.TopColor = System.Drawing.Color.Black
        Me.OppositionDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionDate.DataField = "OppositionDate"
        Me.OppositionDate.Height = 0.2083333!
        Me.OppositionDate.Left = 3.895833!
        Me.OppositionDate.Name = "OppositionDate"
        Me.OppositionDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.OppositionDate.Tag = ""
        Me.OppositionDate.Text = "OppositionDate"
        Me.OppositionDate.Top = 0.0!
        Me.OppositionDate.Width = 0.875!
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
        Me.Completed.Left = 4.875!
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
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
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
        'OppositionIDHeader
        '
        Me.OppositionIDHeader.CanShrink = True
        Me.OppositionIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.OppositionName, Me.txtCompanyName1, Me.Label2, Me.Label3, Me.OppositionCompany, Me.Label4, Me.Jurisdiction, Me.Label5, Me.ProceedingNumber, Me.Label8, Me.Status, Me.subrptOppositionClientMarks, Me.Line3, Me.subrptOppositionMarks, Me.Line4, Me.Line2})
        Me.OppositionIDHeader.DataField = "OppositionID"
        Me.OppositionIDHeader.Height = 1.645833!
        Me.OppositionIDHeader.Name = "OppositionIDHeader"
        Me.OppositionIDHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before
        Me.OppositionIDHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'OppositionName
        '
        Me.OppositionName.Border.BottomColor = System.Drawing.Color.Black
        Me.OppositionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionName.Border.LeftColor = System.Drawing.Color.Black
        Me.OppositionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionName.Border.RightColor = System.Drawing.Color.Black
        Me.OppositionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionName.Border.TopColor = System.Drawing.Color.Black
        Me.OppositionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionName.CanShrink = True
        Me.OppositionName.DataField = "OppositionName"
        Me.OppositionName.Height = 0.2083333!
        Me.OppositionName.Left = 0.01041635!
        Me.OppositionName.Name = "OppositionName"
        Me.OppositionName.Style = "font-weight: bold; font-size: 12pt; "
        Me.OppositionName.Text = "OppositionName"
        Me.OppositionName.Top = 0.0!
        Me.OppositionName.Width = 7.395833!
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
        Me.txtCompanyName1.Left = 1.302083!
        Me.txtCompanyName1.Name = "txtCompanyName1"
        Me.txtCompanyName1.Style = "font-size: 9pt; "
        Me.txtCompanyName1.Text = "txtCompanyName1"
        Me.txtCompanyName1.Top = 0.3020833!
        Me.txtCompanyName1.Width = 5.1875!
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
        Me.Label2.Left = 0.01041702!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label2.Text = "Client Company"
        Me.Label2.Top = 0.3020833!
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
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "Opposing Company:"
        Me.Label3.Top = 0.5104167!
        Me.Label3.Width = 1.291667!
        '
        'OppositionCompany
        '
        Me.OppositionCompany.Border.BottomColor = System.Drawing.Color.Black
        Me.OppositionCompany.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionCompany.Border.LeftColor = System.Drawing.Color.Black
        Me.OppositionCompany.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionCompany.Border.RightColor = System.Drawing.Color.Black
        Me.OppositionCompany.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionCompany.Border.TopColor = System.Drawing.Color.Black
        Me.OppositionCompany.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.OppositionCompany.CanShrink = True
        Me.OppositionCompany.DataField = "OppositionCompany"
        Me.OppositionCompany.Height = 0.2083333!
        Me.OppositionCompany.Left = 1.302083!
        Me.OppositionCompany.Name = "OppositionCompany"
        Me.OppositionCompany.Style = "font-size: 9pt; "
        Me.OppositionCompany.Text = "OppositionCompany"
        Me.OppositionCompany.Top = 0.5104167!
        Me.OppositionCompany.Width = 5.1875!
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
        Me.Label4.Left = 0.01041702!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Jurisdiction:"
        Me.Label4.Top = 0.7187497!
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
        Me.Jurisdiction.Left = 1.302083!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "font-size: 9pt; "
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 0.7187497!
        Me.Jurisdiction.Width = 1.520833!
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
        Me.Label5.Left = 2.864584!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label5.Text = "Proceeding No:"
        Me.Label5.Top = 0.7187497!
        Me.Label5.Width = 1.0!
        '
        'ProceedingNumber
        '
        Me.ProceedingNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.ProceedingNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.ProceedingNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.RightColor = System.Drawing.Color.Black
        Me.ProceedingNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.TopColor = System.Drawing.Color.Black
        Me.ProceedingNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.CanShrink = True
        Me.ProceedingNumber.DataField = "ProceedingNumber"
        Me.ProceedingNumber.Height = 0.2083333!
        Me.ProceedingNumber.Left = 3.906249!
        Me.ProceedingNumber.Name = "ProceedingNumber"
        Me.ProceedingNumber.Style = "font-size: 9pt; "
        Me.ProceedingNumber.Text = "ProceedingNumber"
        Me.ProceedingNumber.Top = 0.7187497!
        Me.ProceedingNumber.Width = 1.010416!
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
        Me.Label8.Left = 5.010417!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label8.Text = "Status:"
        Me.Label8.Top = 0.7187497!
        Me.Label8.Width = 0.5625!
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
        Me.Status.Left = 5.614583!
        Me.Status.Name = "Status"
        Me.Status.Style = "font-size: 9pt; "
        Me.Status.Text = "Status"
        Me.Status.Top = 0.7187497!
        Me.Status.Width = 1.25!
        '
        'subrptOppositionClientMarks
        '
        Me.subrptOppositionClientMarks.Border.BottomColor = System.Drawing.Color.Black
        Me.subrptOppositionClientMarks.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionClientMarks.Border.LeftColor = System.Drawing.Color.Black
        Me.subrptOppositionClientMarks.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionClientMarks.Border.RightColor = System.Drawing.Color.Black
        Me.subrptOppositionClientMarks.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionClientMarks.Border.TopColor = System.Drawing.Color.Black
        Me.subrptOppositionClientMarks.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionClientMarks.CloseBorder = False
        Me.subrptOppositionClientMarks.Height = 0.1666667!
        Me.subrptOppositionClientMarks.Left = 0.07291635!
        Me.subrptOppositionClientMarks.Name = "subrptOppositionClientMarks"
        Me.subrptOppositionClientMarks.Report = Nothing
        Me.subrptOppositionClientMarks.ReportName = "subrptOppositionClientMarks"
        Me.subrptOppositionClientMarks.Top = 1.031249!
        Me.subrptOppositionClientMarks.Width = 7.3125!
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
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Tag = ""
        Me.Line3.Top = 0.96875!
        Me.Line3.Width = 9.875!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 9.875!
        Me.Line3.Y1 = 0.96875!
        Me.Line3.Y2 = 0.96875!
        '
        'subrptOppositionMarks
        '
        Me.subrptOppositionMarks.Border.BottomColor = System.Drawing.Color.Black
        Me.subrptOppositionMarks.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionMarks.Border.LeftColor = System.Drawing.Color.Black
        Me.subrptOppositionMarks.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionMarks.Border.RightColor = System.Drawing.Color.Black
        Me.subrptOppositionMarks.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionMarks.Border.TopColor = System.Drawing.Color.Black
        Me.subrptOppositionMarks.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.subrptOppositionMarks.CloseBorder = False
        Me.subrptOppositionMarks.Height = 0.1666667!
        Me.subrptOppositionMarks.Left = 0.07291635!
        Me.subrptOppositionMarks.Name = "subrptOppositionMarks"
        Me.subrptOppositionMarks.Report = Nothing
        Me.subrptOppositionMarks.ReportName = "subrptOppositionMarks"
        Me.subrptOppositionMarks.Top = 1.333333!
        Me.subrptOppositionMarks.Width = 7.3125!
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
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Tag = ""
        Me.Line4.Top = 1.59375!
        Me.Line4.Width = 9.875!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 9.875!
        Me.Line4.Y1 = 1.59375!
        Me.Line4.Y2 = 1.59375!
        '
        'OppositionIDFooter
        '
        Me.OppositionIDFooter.CanShrink = True
        Me.OppositionIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubrptOppositionActions, Me.FooterLine})
        Me.OppositionIDFooter.Height = 0.25!
        Me.OppositionIDFooter.Name = "OppositionIDFooter"
        '
        'SubrptOppositionActions
        '
        Me.SubrptOppositionActions.Border.BottomColor = System.Drawing.Color.Black
        Me.SubrptOppositionActions.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptOppositionActions.Border.LeftColor = System.Drawing.Color.Black
        Me.SubrptOppositionActions.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptOppositionActions.Border.RightColor = System.Drawing.Color.Black
        Me.SubrptOppositionActions.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptOppositionActions.Border.TopColor = System.Drawing.Color.Black
        Me.SubrptOppositionActions.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptOppositionActions.CloseBorder = False
        Me.SubrptOppositionActions.Height = 0.125!
        Me.SubrptOppositionActions.Left = 0.08333335!
        Me.SubrptOppositionActions.Name = "SubrptOppositionActions"
        Me.SubrptOppositionActions.Report = Nothing
        Me.SubrptOppositionActions.ReportName = "SubrptOppositionActions"
        Me.SubrptOppositionActions.Top = 0.04166667!
        Me.SubrptOppositionActions.Width = 7.291667!
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
        Me.FooterLine.Top = 0.01041667!
        Me.FooterLine.Width = 9.875!
        Me.FooterLine.X1 = 0.0!
        Me.FooterLine.X2 = 9.875!
        Me.FooterLine.Y1 = 0.01041667!
        Me.FooterLine.Y2 = 0.01041667!
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
        Me.Line2.Top = 1.270833!
        Me.Line2.Width = 9.875!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 9.875!
        Me.Line2.Y1 = 1.270833!
        Me.Line2.Y2 = 1.270833!
        '
        'rptOneOpposition
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademar" & _
            "k\RevaTrademark.mdb"
        OleDBDataSource1.SQL = "Select * from qvwReportOppositions where OppositionID=1"
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
        Me.Sections.Add(Me.OppositionIDHeader)
        Me.Sections.Add(Me.DateDetail)
        Me.Sections.Add(Me.OppositionIDFooter)
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
        CType(Me.DateName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents OppositionIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents OppositionIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents OppositionName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompanyName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OppositionDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label40 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents OppositionCompany As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents ProceedingNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Status As DataDynamics.ActiveReports.TextBox
    Friend WithEvents subrptOppositionClientMarks As DataDynamics.ActiveReports.SubReport
    Friend WithEvents DateName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents SubrptOppositionActions As DataDynamics.ActiveReports.SubReport
    Friend WithEvents FooterLine As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Completed As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents subrptOppositionMarks As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
End Class
