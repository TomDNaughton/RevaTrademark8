<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class subrptPatentActions
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(subrptPatentActions))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.ActionDate = New DataDynamics.ActiveReports.TextBox
        Me.PatentAction = New DataDynamics.ActiveReports.TextBox
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatentAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ActionDate, Me.PatentAction})
        Me.Detail1.Height = 0.1979167!
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
        'PatentAction
        '
        Me.PatentAction.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentAction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentAction.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentAction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentAction.Border.RightColor = System.Drawing.Color.Black
        Me.PatentAction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentAction.Border.TopColor = System.Drawing.Color.Black
        Me.PatentAction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentAction.DataField = "PatentAction"
        Me.PatentAction.Height = 0.1770833!
        Me.PatentAction.Left = 0.9375!
        Me.PatentAction.Name = "PatentAction"
        Me.PatentAction.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.PatentAction.Tag = ""
        Me.PatentAction.Text = "PatentAction"
        Me.PatentAction.Top = 0.0!
        Me.PatentAction.Width = 6.333333!
        '
        'subrptPatentActions
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from tblPatentActions"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.364583!
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.ActionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatentAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ActionDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PatentAction As DataDynamics.ActiveReports.TextBox
End Class
