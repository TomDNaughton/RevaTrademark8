<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTrademarksList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTrademarksList))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ReportDescription = New DataDynamics.ActiveReports.TextBox
        Me.Line89 = New DataDynamics.ActiveReports.Line
        Me.lblList = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Line112 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.lbl100 = New DataDynamics.ActiveReports.Label
        Me.PictureBox = New DataDynamics.ActiveReports.Picture
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportDescription, Me.Line89, Me.lblList, Me.ReportGraphic, Me.Line1})
        Me.PageHeader1.Height = 0.9583333!
        Me.PageHeader1.Name = "PageHeader1"
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
        'lblList
        '
        Me.lblList.Border.BottomColor = System.Drawing.Color.Black
        Me.lblList.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblList.Border.LeftColor = System.Drawing.Color.Black
        Me.lblList.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblList.Border.RightColor = System.Drawing.Color.Black
        Me.lblList.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblList.Border.TopColor = System.Drawing.Color.Black
        Me.lblList.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblList.Height = 0.3125!
        Me.lblList.HyperLink = Nothing
        Me.lblList.Left = 0.0!
        Me.lblList.Name = "lblList"
        Me.lblList.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 20pt; font-fam" & _
            "ily: Times New Roman; "
        Me.lblList.Text = "Trademarks List"
        Me.lblList.Top = 0.0!
        Me.lblList.Width = 2.75!
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line112, Me.PictureBox})
        Me.Detail1.Height = 0.2395833!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.lbl100})
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
        Me.TextBox1.DataField = "TrademarkName"
        Me.TextBox1.Height = 0.1666667!
        Me.TextBox1.Left = 8.416667!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: Black; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.TextBox1.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox1.Tag = ""
        Me.TextBox1.Text = "TotalTrademarks"
        Me.TextBox1.Top = 0.04166667!
        Me.TextBox1.Width = 0.5416667!
        '
        'lbl100
        '
        Me.lbl100.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbl100.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbl100.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbl100.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbl100.Height = 0.2083333!
        Me.lbl100.HyperLink = Nothing
        Me.lbl100.Left = 9.0!
        Me.lbl100.Name = "lbl100"
        Me.lbl100.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.lbl100.Tag = ""
        Me.lbl100.Text = "Trademarks"
        Me.lbl100.Top = 0.04166667!
        Me.lbl100.Width = 0.8333333!
        '
        'PictureBox
        '
        Me.PictureBox.Border.BottomColor = System.Drawing.Color.Black
        Me.PictureBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PictureBox.Border.LeftColor = System.Drawing.Color.Black
        Me.PictureBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PictureBox.Border.RightColor = System.Drawing.Color.Black
        Me.PictureBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PictureBox.Border.TopColor = System.Drawing.Color.Black
        Me.PictureBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PictureBox.Height = 0.15625!
        Me.PictureBox.Image = Nothing
        Me.PictureBox.ImageData = Nothing
        Me.PictureBox.Left = 5.9375!
        Me.PictureBox.LineWeight = 0.0!
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Top = 0.01041667!
        Me.PictureBox.Visible = False
        Me.PictureBox.Width = 1.0!
        '
        'rptTrademarksList
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
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line89 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblList As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line112 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lbl100 As DataDynamics.ActiveReports.Label
    Friend WithEvents PictureBox As DataDynamics.ActiveReports.Picture
End Class
