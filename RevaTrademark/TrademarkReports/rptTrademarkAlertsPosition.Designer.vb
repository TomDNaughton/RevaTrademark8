<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTrademarkAlertsPosition
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTrademarkAlertsPosition))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ReportDescription = New DataDynamics.ActiveReports.TextBox
        Me.Line89 = New DataDynamics.ActiveReports.Line
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.ReportGraphic = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Line112 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ContactIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.txtPositionName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtContactName1 = New DataDynamics.ActiveReports.TextBox
        Me.ContactFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.FooterLine = New DataDynamics.ActiveReports.Line
        Me.TrademarkIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.TrademarkIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.PositionIDHeader = New DataDynamics.ActiveReports.GroupHeader
        Me.PositionIDFooter = New DataDynamics.ActiveReports.GroupFooter
        Me.SubrptTrademarkActions = New DataDynamics.ActiveReports.SubReport
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPositionName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportDescription, Me.Line89, Me.Label3, Me.ReportGraphic})
        Me.PageHeader1.Height = 0.6875!
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
        Me.Line89.Width = 9.8!
        Me.Line89.X1 = 0.0!
        Me.Line89.X2 = 9.8!
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
        Me.Label3.Text = "Trademark Alerts"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 2.75!
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
        Me.Line1.Top = 0.8333333!
        Me.Line1.Width = 9.8!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 9.8!
        Me.Line1.Y1 = 0.8333333!
        Me.Line1.Y2 = 0.8333333!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
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
        Me.Line112.Top = 0.0!
        Me.Line112.Width = 9.8!
        Me.Line112.X1 = 0.0!
        Me.Line112.X2 = 9.8!
        Me.Line112.Y1 = 0.0!
        Me.Line112.Y2 = 0.0!
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
        'ContactIDHeader
        '
        Me.ContactIDHeader.CanShrink = True
        Me.ContactIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.txtPositionName1, Me.txtContactName1})
        Me.ContactIDHeader.DataField = "ContactID"
        Me.ContactIDHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.ContactIDHeader.Height = 0.84375!
        Me.ContactIDHeader.Name = "ContactIDHeader"
        Me.ContactIDHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'txtPositionName1
        '
        Me.txtPositionName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPositionName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPositionName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPositionName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPositionName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtPositionName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPositionName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtPositionName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPositionName1.DataField = "PositionName"
        Me.txtPositionName1.Height = 0.2083333!
        Me.txtPositionName1.Left = 0.0!
        Me.txtPositionName1.Name = "txtPositionName1"
        Me.txtPositionName1.Style = "text-decoration: underline; font-weight: bold; font-size: 11pt; "
        Me.txtPositionName1.Text = "txtPositionName1"
        Me.txtPositionName1.Top = 0.04166667!
        Me.txtPositionName1.Width = 3.0!
        '
        'txtContactName1
        '
        Me.txtContactName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtContactName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtContactName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtContactName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtContactName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtContactName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtContactName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtContactName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtContactName1.DataField = "ContactName"
        Me.txtContactName1.Height = 0.2083333!
        Me.txtContactName1.Left = 0.0!
        Me.txtContactName1.Name = "txtContactName1"
        Me.txtContactName1.Style = "font-weight: bold; font-size: 11pt; "
        Me.txtContactName1.Text = "txtContactName1"
        Me.txtContactName1.Top = 0.2916667!
        Me.txtContactName1.Width = 3.083333!
        '
        'ContactFooter
        '
        Me.ContactFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.FooterLine})
        Me.ContactFooter.Height = 0.0!
        Me.ContactFooter.Name = "ContactFooter"
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
        Me.FooterLine.Top = 0.0!
        Me.FooterLine.Width = 9.875!
        Me.FooterLine.X1 = 0.0!
        Me.FooterLine.X2 = 9.875!
        Me.FooterLine.Y1 = 0.0!
        Me.FooterLine.Y2 = 0.0!
        '
        'TrademarkIDHeader
        '
        Me.TrademarkIDHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line112})
        Me.TrademarkIDHeader.DataField = "TrademarkID"
        Me.TrademarkIDHeader.Height = 0.02083333!
        Me.TrademarkIDHeader.Name = "TrademarkIDHeader"
        '
        'TrademarkIDFooter
        '
        Me.TrademarkIDFooter.CanShrink = True
        Me.TrademarkIDFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubrptTrademarkActions})
        Me.TrademarkIDFooter.Height = 0.18!
        Me.TrademarkIDFooter.Name = "TrademarkIDFooter"
        '
        'PositionIDHeader
        '
        Me.PositionIDHeader.DataField = "PositionID"
        Me.PositionIDHeader.Height = 0.0!
        Me.PositionIDHeader.Name = "PositionIDHeader"
        '
        'PositionIDFooter
        '
        Me.PositionIDFooter.Height = 0.0!
        Me.PositionIDFooter.Name = "PositionIDFooter"
        Me.PositionIDFooter.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'SubrptTrademarkActions
        '
        Me.SubrptTrademarkActions.Border.BottomColor = System.Drawing.Color.Black
        Me.SubrptTrademarkActions.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptTrademarkActions.Border.LeftColor = System.Drawing.Color.Black
        Me.SubrptTrademarkActions.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptTrademarkActions.Border.RightColor = System.Drawing.Color.Black
        Me.SubrptTrademarkActions.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptTrademarkActions.Border.TopColor = System.Drawing.Color.Black
        Me.SubrptTrademarkActions.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubrptTrademarkActions.CloseBorder = False
        Me.SubrptTrademarkActions.Height = 0.08333334!
        Me.SubrptTrademarkActions.Left = 1.75!
        Me.SubrptTrademarkActions.Name = "SubrptTrademarkActions"
        Me.SubrptTrademarkActions.Report = Nothing
        Me.SubrptTrademarkActions.ReportName = "subrptTrademarkActions"
        Me.SubrptTrademarkActions.Top = 0.0!
        Me.SubrptTrademarkActions.Width = 7.416667!
        '
        'rptTrademarkAlertsPosition
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from qvwReportTrademarkAlertsPosition" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "order by ContactName"
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
        Me.Sections.Add(Me.PositionIDHeader)
        Me.Sections.Add(Me.ContactIDHeader)
        Me.Sections.Add(Me.TrademarkIDHeader)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.TrademarkIDFooter)
        Me.Sections.Add(Me.ContactFooter)
        Me.Sections.Add(Me.PositionIDFooter)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.ReportDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPositionName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line89 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportGraphic As DataDynamics.ActiveReports.Picture
    Friend WithEvents ContactIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents ContactFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line112 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents TrademarkIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents TrademarkIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtPositionName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContactName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FooterLine As DataDynamics.ActiveReports.Line
    Friend WithEvents PositionIDHeader As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PositionIDFooter As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents SubrptTrademarkActions As DataDynamics.ActiveReports.SubReport
End Class
