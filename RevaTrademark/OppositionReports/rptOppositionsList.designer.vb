<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptOppositionsList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOppositionsList))
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
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.CompanyName = New DataDynamics.ActiveReports.TextBox
        Me.OppositionName = New DataDynamics.ActiveReports.TextBox
        Me.Jurisdiction = New DataDynamics.ActiveReports.TextBox
        Me.ProceedingNumber = New DataDynamics.ActiveReports.TextBox
        Me.Line112 = New DataDynamics.ActiveReports.Line
        Me.Status = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.ClientIsPlaintiff = New DataDynamics.ActiveReports.CheckBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        CType(Me.lblFileNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label334, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientIsPlaintiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFileNumber, Me.Label92, Me.Label334, Me.Label110, Me.Label1, Me.ReportDescription, Me.Line89, Me.Label3, Me.ReportGraphic, Me.Line1, Me.Label2})
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
        Me.lblFileNumber.Left = 7.166667!
        Me.lblFileNumber.Name = "lblFileNumber"
        Me.lblFileNumber.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.lblFileNumber.Tag = ""
        Me.lblFileNumber.Text = "Jurisdiction"
        Me.lblFileNumber.Top = 0.7083333!
        Me.lblFileNumber.Width = 0.979167!
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
        Me.Label92.Left = 2.697917!
        Me.Label92.Name = "Label92"
        Me.Label92.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label92.Tag = ""
        Me.Label92.Text = "Opposition Name"
        Me.Label92.Top = 0.7083333!
        Me.Label92.Width = 1.645833!
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
        Me.Label334.Left = 8.21875!
        Me.Label334.Name = "Label334"
        Me.Label334.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label334.Tag = ""
        Me.Label334.Text = "Proceeding"
        Me.Label334.Top = 0.7083333!
        Me.Label334.Width = 0.7916667!
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
        Me.Label110.Width = 1.958333!
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
        Me.Label1.Left = 9.041667!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label1.Tag = ""
        Me.Label1.Text = "Status"
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
        Me.ReportDescription.Height = 0.2083334!
        Me.ReportDescription.Left = 0.0!
        Me.ReportDescription.Name = "ReportDescription"
        Me.ReportDescription.Style = "color: Black; text-align: left; font-weight: normal; font-style: italic; font-siz" & _
            "e: 12pt; "
        Me.ReportDescription.Tag = ""
        Me.ReportDescription.Text = Nothing
        Me.ReportDescription.Top = 0.3958333!
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
        Me.Label3.Height = 0.34375!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 20pt; font-fam" & _
            "ily: Times New Roman; "
        Me.Label3.Text = "Trademarks Oppositions List"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 4.15625!
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CompanyName, Me.OppositionName, Me.Jurisdiction, Me.ProceedingNumber, Me.Line112, Me.Status, Me.ClientIsPlaintiff})
        Me.Detail1.Height = 0.25!
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
        Me.CompanyName.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.CompanyName.Tag = ""
        Me.CompanyName.Text = "CompanyName"
        Me.CompanyName.Top = 0.0!
        Me.CompanyName.Width = 2.604166!
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
        Me.OppositionName.Left = 2.65625!
        Me.OppositionName.Name = "OppositionName"
        Me.OppositionName.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.OppositionName.Tag = ""
        Me.OppositionName.Text = "OppositionName"
        Me.OppositionName.Top = 0.0!
        Me.OppositionName.Width = 4.041667!
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
        Me.Jurisdiction.Left = 7.166667!
        Me.Jurisdiction.Name = "Jurisdiction"
        Me.Jurisdiction.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.Jurisdiction.Tag = ""
        Me.Jurisdiction.Text = "Jurisdiction"
        Me.Jurisdiction.Top = 0.0!
        Me.Jurisdiction.Width = 1.020833!
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
        Me.ProceedingNumber.Left = 8.21875!
        Me.ProceedingNumber.Name = "ProceedingNumber"
        Me.ProceedingNumber.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.ProceedingNumber.Tag = ""
        Me.ProceedingNumber.Text = "ProceedingNumber"
        Me.ProceedingNumber.Top = 0.0!
        Me.ProceedingNumber.Width = 0.7916667!
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
        Me.Line112.Width = 9.875!
        Me.Line112.X1 = 0.0!
        Me.Line112.X2 = 9.875!
        Me.Line112.Y1 = 0.21875!
        Me.Line112.Y2 = 0.21875!
        '
        'Status
        '
        Me.Status.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Status.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Status.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Status.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Status.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Status.DataField = "Status"
        Me.Status.Height = 0.1875!
        Me.Status.Left = 9.041667!
        Me.Status.Name = "Status"
        Me.Status.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.Status.Tag = ""
        Me.Status.Text = "Status"
        Me.Status.Top = 0.0!
        Me.Status.Width = 0.8020833!
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
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.03125!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.Label4})
        Me.ReportFooter1.Height = 0.3020833!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.DataField = "OppositionID"
        Me.TextBox1.Height = 0.1666667!
        Me.TextBox1.Left = 8.416667!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: Black; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.TextBox1.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox1.Tag = ""
        Me.TextBox1.Text = "TotalOppositions"
        Me.TextBox1.Top = 0.04166667!
        Me.TextBox1.Width = 0.5416667!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.2083333!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 9.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label4.Tag = ""
        Me.Label4.Text = "Oppositions"
        Me.Label4.Top = 0.04166667!
        Me.Label4.Width = 0.8333333!
        '
        'ClientIsPlaintiff
        '
        Me.ClientIsPlaintiff.Border.BottomColor = System.Drawing.Color.Black
        Me.ClientIsPlaintiff.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientIsPlaintiff.Border.LeftColor = System.Drawing.Color.Black
        Me.ClientIsPlaintiff.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientIsPlaintiff.Border.RightColor = System.Drawing.Color.Black
        Me.ClientIsPlaintiff.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientIsPlaintiff.Border.TopColor = System.Drawing.Color.Black
        Me.ClientIsPlaintiff.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientIsPlaintiff.DataField = "ClientIsPlaintiff"
        Me.ClientIsPlaintiff.Height = 0.1979167!
        Me.ClientIsPlaintiff.Left = 6.802083!
        Me.ClientIsPlaintiff.Name = "ClientIsPlaintiff"
        Me.ClientIsPlaintiff.Style = ""
        Me.ClientIsPlaintiff.Text = ""
        Me.ClientIsPlaintiff.Top = 0.0!
        Me.ClientIsPlaintiff.Width = 0.1666667!
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
        Me.Label2.Left = 6.645833!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label2.Tag = ""
        Me.Label2.Text = "Plaintiff"
        Me.Label2.Top = 0.7083333!
        Me.Label2.Width = 0.4895833!
        '
        'rptOppositionsList
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from qvwTrademarksList"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.927087!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
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
        CType(Me.CompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OppositionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Jurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProceedingNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientIsPlaintiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents CompanyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents OppositionName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Jurisdiction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ProceedingNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFileNumber As DataDynamics.ActiveReports.Label
    Friend WithEvents Label92 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label334 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label110 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line89 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line112 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Status As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents ClientIsPlaintiff As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
End Class
