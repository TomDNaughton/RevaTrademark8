<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptOppositionAlerts
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOppositionAlerts))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblFileNumber = New DataDynamics.ActiveReports.Label
        Me.Label92 = New DataDynamics.ActiveReports.Label
        Me.Label334 = New DataDynamics.ActiveReports.Label
        Me.Label110 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.ReportDescription = New DataDynamics.ActiveReports.TextBox
        Me.Line89 = New DataDynamics.ActiveReports.Line
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.CompanyName = New DataDynamics.ActiveReports.TextBox
        Me.OppositionName = New DataDynamics.ActiveReports.TextBox
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.ProceedingNumber = New DataDynamics.ActiveReports.TextBox
        Me.DateLabel = New DataDynamics.ActiveReports.TextBox
        Me.OppositionDate = New DataDynamics.ActiveReports.TextBox
        Me.Completed = New DataDynamics.ActiveReports.CheckBox
        Me.Line112 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.OppositionIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.TrademarkIDFooter = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblFileNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label334, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFileNumber, Me.Label92, Me.Label334, Me.Label110, Me.Label1, Me.ReportDescription, Me.Line89, Me.Label3, Me.ReportGraphic, Me.Label2, Me.Line1})
        Me.PageHeader1.Height = 0.9583333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblFileNumber
        '
        Me.lblFileNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFileNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFileNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFileNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFileNumber.Border.RightColor = System.Drawing.Color.Black
        Me.lblFileNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFileNumber.Border.TopColor = System.Drawing.Color.Black
        Me.lblFileNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFileNumber.Height = 0.1666667!
        Me.lblFileNumber.HyperLink = Nothing
        Me.lblFileNumber.Left = 4.864583!
        Me.lblFileNumber.Name = "lblFileNumber"
        Me.lblFileNumber.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.lblFileNumber.Tag = ""
        Me.lblFileNumber.Text = "Jurisdiction"
        Me.lblFileNumber.Top = 0.7083333!
        Me.lblFileNumber.Width = 0.8854167!
        '
        'Label92
        '
        Me.Label92.Border.BottomColor = System.Drawing.Color.Black
        Me.Label92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label92.Border.LeftColor = System.Drawing.Color.Black
        Me.Label92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label92.Border.RightColor = System.Drawing.Color.Black
        Me.Label92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label92.Border.TopColor = System.Drawing.Color.Black
        Me.Label92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label92.Height = 0.1666667!
        Me.Label92.HyperLink = Nothing
        Me.Label92.Left = 2.041667!
        Me.Label92.Name = "Label92"
        Me.Label92.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label92.Tag = ""
        Me.Label92.Text = "Opposition Name"
        Me.Label92.Top = 0.7083333!
        Me.Label92.Width = 1.0!
        '
        'Label334
        '
        Me.Label334.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label334.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label334.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label334.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label334.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label334.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label334.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label334.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label334.Height = 0.1666667!
        Me.Label334.HyperLink = Nothing
        Me.Label334.Left = 5.8125!
        Me.Label334.Name = "Label334"
        Me.Label334.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label334.Tag = ""
        Me.Label334.Text = "Proceeding"
        Me.Label334.Top = 0.7083333!
        Me.Label334.Width = 0.7708333!
        '
        'Label110
        '
        Me.Label110.Border.BottomColor = System.Drawing.Color.Black
        Me.Label110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label110.Border.LeftColor = System.Drawing.Color.Black
        Me.Label110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label110.Border.RightColor = System.Drawing.Color.Black
        Me.Label110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label110.Border.TopColor = System.Drawing.Color.Black
        Me.Label110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label110.Height = 0.1666667!
        Me.Label110.HyperLink = Nothing
        Me.Label110.Left = 0.0!
        Me.Label110.Name = "Label110"
        Me.Label110.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label110.Tag = ""
        Me.Label110.Text = "Company/Owner"
        Me.Label110.Top = 0.7083333!
        Me.Label110.Width = 1.9375!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 9.208333!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label1.Tag = ""
        Me.Label1.Text = "Completed"
        Me.Label1.Top = 0.7083333!
        Me.Label1.Width = 0.6875!
        '
        'ReportDescription
        '
        Me.ReportDescription.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportDescription.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportDescription.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportDescription.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportDescription.Border.RightColor = System.Drawing.Color.Black
        Me.ReportDescription.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportDescription.Border.TopColor = System.Drawing.Color.Black
        Me.ReportDescription.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportDescription.Height = 0.2291667!
        Me.ReportDescription.Left = 0.0!
        Me.ReportDescription.Name = "ReportDescription"
        Me.ReportDescription.Style = "color: Black; text-align: left; font-weight: normal; font-style: italic; font-siz" & _
            "e: 12pt; "
        Me.ReportDescription.Tag = ""
        Me.ReportDescription.Text = Nothing
        Me.ReportDescription.Top = 0.375!
        Me.ReportDescription.Width = 5.541667!
        '
        'Line89
        '
        Me.Line89.Border.BottomColor = System.Drawing.Color.Black
        Me.Line89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line89.Border.LeftColor = System.Drawing.Color.Black
        Me.Line89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line89.Border.RightColor = System.Drawing.Color.Black
        Me.Line89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line89.Border.TopColor = System.Drawing.Color.Black
        Me.Line89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line89.Height = 0.0!
        Me.Line89.Left = 0.0!
        Me.Line89.LineWeight = 2.0!
        Me.Line89.Name = "Line89"
        Me.Line89.Tag = ""
        Me.Line89.Top = 0.6666667!
        Me.Line89.Width = 9.875!
        Me.Line89.X1 = 0.0!
        Me.Line89.X2 = 9.875!
        Me.Line89.Y1 = 0.6666667!
        Me.Line89.Y2 = 0.6666667!
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
        Me.Label3.Height = 0.3125!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 20pt; font-fam" & _
            "ily: Times New Roman; "
        Me.Label3.Text = "Trademark Opposition Alerts"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 3.916667!
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
        Me.ReportGraphic.Left = 8.083333!
        Me.ReportGraphic.LineWeight = 0.0!
        Me.ReportGraphic.Name = "ReportGraphic"
        Me.ReportGraphic.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopRight
        Me.ReportGraphic.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.ReportGraphic.Top = 0.0!
        Me.ReportGraphic.Width = 1.791667!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.1666667!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label2.Tag = ""
        Me.Label2.Text = "Litigation Date"
        Me.Label2.Top = 0.7083333!
        Me.Label2.Width = 1.25!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Tag = ""
        Me.Line1.Top = 0.9166667!
        Me.Line1.Width = 9.875!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.875!
        Me.Line1.Y1 = 0.9166667!
        Me.Line1.Y2 = 0.9166667!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CompanyName, Me.OppositionName, Me.Jurisdiction, Me.ProceedingNumber, Me.DateLabel, Me.OppositionDate, Me.Completed, Me.Line112})
        Me.Detail1.Height = 0.2395833!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'CompanyName
        '
        Me.CompanyName.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompanyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompanyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompanyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompanyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompanyName.DataField = "CompanyName"
        Me.CompanyName.Height = 0.1875!
        Me.CompanyName.Left = 0.0!
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.CompanyName.Tag = ""
        Me.CompanyName.Text = "CompanyName"
        Me.CompanyName.Top = 0.0!
        Me.CompanyName.Width = 1.9375!
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
        Me.OppositionName.DataField = "OppositionName"
        Me.OppositionName.Height = 0.1875!
        Me.OppositionName.Left = 2.0!
        Me.OppositionName.Name = "OppositionName"
        Me.OppositionName.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.OppositionName.Tag = ""
        Me.OppositionName.Text = "OppositionName"
        Me.OppositionName.Top = 0.0!
        Me.OppositionName.Width = 2.802083!
        '
        'Jurisdiction
        '
        Me.Jurisdiction.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Jurisdiction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Jurisdiction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Jurisdiction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Jurisdiction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Jurisdiction.DataField = "Jurisdiction"
        Me.Jurisdiction.Height = 0.1875!
        Me.Jurisdiction.Left = 4.864583!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.Jurisdiction.Tag = ""
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 0.0!
        Me.Jurisdiction.Width = 0.8958333!
        '
        'ProceedingNumber
        '
        Me.ProceedingNumber.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProceedingNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProceedingNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProceedingNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProceedingNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProceedingNumber.DataField = "ProceedingNumber"
        Me.ProceedingNumber.Height = 0.1875!
        Me.ProceedingNumber.Left = 5.8125!
        Me.ProceedingNumber.Name = "ProceedingNumber"
        Me.ProceedingNumber.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.ProceedingNumber.Tag = ""
        Me.ProceedingNumber.Text = "ProceedingNumber"
        Me.ProceedingNumber.Top = 0.0!
        Me.ProceedingNumber.Width = 0.7708333!
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
        Me.DateLabel.Height = 0.1875!
        Me.DateLabel.Left = 6.625!
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.DateLabel.Tag = ""
        Me.DateLabel.Text = "DateName"
        Me.DateLabel.Top = 0.0!
        Me.DateLabel.Width = 2.0!
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
        Me.OppositionDate.Height = 0.1875!
        Me.OppositionDate.Left = 8.677083!
        Me.OppositionDate.Name = "OppositionDate"
        Me.OppositionDate.OutputFormat = resources.GetString("OppositionDate.OutputFormat")
        Me.OppositionDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.OppositionDate.Tag = ""
        Me.OppositionDate.Text = "OppositionDate"
        Me.OppositionDate.Top = 0.0!
        Me.OppositionDate.Width = 0.8541667!
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
        Me.Completed.Height = 0.125!
        Me.Completed.Left = 9.604167!
        Me.Completed.Name = "Completed"
        Me.Completed.Style = ""
        Me.Completed.Text = "CheckBox1"
        Me.Completed.Top = 0.04166667!
        Me.Completed.Width = 0.1875!
        '
        'Line112
        '
        Me.Line112.Border.BottomColor = System.Drawing.Color.Black
        Me.Line112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line112.Border.LeftColor = System.Drawing.Color.Black
        Me.Line112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line112.Border.RightColor = System.Drawing.Color.Black
        Me.Line112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line112.Border.TopColor = System.Drawing.Color.Black
        Me.Line112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line112.Height = 0.0!
        Me.Line112.Left = 0.0!
        Me.Line112.LineWeight = 1.0!
        Me.Line112.Name = "Line112"
        Me.Line112.Tag = ""
        Me.Line112.Top = 0.21875!
        Me.Line112.Width = 9.802083!
        Me.Line112.X1 = 0.0!
        Me.Line112.X2 = 9.802083!
        Me.Line112.Y1 = 0.21875!
        Me.Line112.Y2 = 0.21875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1})
        Me.PageFooter1.Height = 0.3645833!
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
        Me.ReportInfo1.Left = 3.708333!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "text-align: center; "
        Me.ReportInfo1.Top = 0.125!
        Me.ReportInfo1.Width = 2.333333!
        '
        'OppositionIDHeader
        '
        Me.OppositionIDHeader.DataField = "OppositionID"
        Me.OppositionIDHeader.Height = 0.0!
        Me.OppositionIDHeader.Name = "OppositionIDHeader"
        '
        'TrademarkIDFooter
        '
        Me.TrademarkIDFooter.Height = 0.0!
        Me.TrademarkIDFooter.Name = "TrademarkIDFooter"
        '
        'rptOppositionAlerts
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademar" & _
            "k\RevaTrademark.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from qvwReportOppositionAlerts"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.927087!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.OppositionIDHeader)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.TrademarkIDFooter)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblFileNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label334, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label110, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents CompanyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OppositionName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ProceedingNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents DateLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OppositionDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Completed As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblFileNumber As DataDynamics.ActiveReports.Label
    Friend WithEvents Label92 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label334 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label110 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line89 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents OppositionIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents TrademarkIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line112 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class
