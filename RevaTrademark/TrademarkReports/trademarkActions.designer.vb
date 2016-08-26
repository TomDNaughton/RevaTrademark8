<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class trademarkActions
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(trademarkActions))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.ActionDate = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkAction = New DataDynamics.ActiveReports.TextBox
        Me.Line96 = New DataDynamics.ActiveReports.Line
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrademarkAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.BackColor = System.Drawing.Color.White
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ActionDate, Me.TrademarkAction, Me.Line96})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
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
        Me.ActionDate.Height = 0.1770833!
        Me.ActionDate.Left = 0.0!
        Me.ActionDate.Name = "ActionDate"
        Me.ActionDate.OutputFormat = resources.GetString("ActionDate.OutputFormat")
        Me.ActionDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.ActionDate.Tag = ""
        Me.ActionDate.Text = "ActionDate"
        Me.ActionDate.Top = 0.0!
        Me.ActionDate.Width = 0.8333333!
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
        Me.TrademarkAction.DataField = "TrademarkAction"
        Me.TrademarkAction.Height = 0.1770833!
        Me.TrademarkAction.Left = 0.9375!
        Me.TrademarkAction.Name = "TrademarkAction"
        Me.TrademarkAction.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.TrademarkAction.Tag = ""
        Me.TrademarkAction.Text = "TrademarkAction"
        Me.TrademarkAction.Top = 0.0!
        Me.TrademarkAction.Width = 6.333333!
        '
        'Line96
        '
        Me.Line96.Border.BottomColor = System.Drawing.Color.Navy
        Me.Line96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line96.Border.LeftColor = System.Drawing.Color.Navy
        Me.Line96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line96.Border.RightColor = System.Drawing.Color.Navy
        Me.Line96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line96.Border.TopColor = System.Drawing.Color.Navy
        Me.Line96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line96.Height = 0.0!
        Me.Line96.Left = 0.0!
        Me.Line96.LineColor = System.Drawing.Color.Navy
        Me.Line96.LineWeight = 0.0!
        Me.Line96.Name = "Line96"
        Me.Line96.Tag = ""
        Me.Line96.Top = 0.2083333!
        Me.Line96.Width = 7.302083!
        Me.Line96.X1 = 0.0!
        Me.Line96.X2 = 7.302083!
        Me.Line96.Y1 = 0.2083333!
        Me.Line96.Y2 = 0.2083333!
        '
        'subrptTrademarkActions
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\xDemoVersion\ImportReports" & _
            ".mdb"
        OleDBDataSource1.SQL = "Select * from [SELECT * FROM tblTrademarkactions; ]"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.416667!
        Me.Script = "/*Option Compare Database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Private Sub Report_NoData(Cancel As Integer)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "On Err" & _
            "or Resume Next" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Msg ""There are no matching records.""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cancel = True" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub" & Global.Microsoft.VisualBasic.ChrW(13) & "*/" & Global.Microsoft.VisualBasic.ChrW(10) & _
            ""
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrademarkAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ActionDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TrademarkAction As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line96 As DataDynamics.ActiveReports.Line
End Class