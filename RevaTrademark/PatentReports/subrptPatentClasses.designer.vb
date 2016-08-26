<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class subrptPatentClasses
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(subrptPatentClasses))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PatentClass = New DataDynamics.ActiveReports.TextBox
        CType(Me.PatentClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PatentClass})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'PatentClass
        '
        Me.PatentClass.Border.BottomColor = System.Drawing.Color.Black
        Me.PatentClass.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentClass.Border.LeftColor = System.Drawing.Color.Black
        Me.PatentClass.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentClass.Border.RightColor = System.Drawing.Color.Black
        Me.PatentClass.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentClass.Border.TopColor = System.Drawing.Color.Black
        Me.PatentClass.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PatentClass.CanShrink = True
        Me.PatentClass.DataField = "PatentClass"
        Me.PatentClass.Height = 0.2083333!
        Me.PatentClass.Left = 0.0!
        Me.PatentClass.Name = "PatentClass"
        Me.PatentClass.Style = "font-size: 9pt; "
        Me.PatentClass.Text = "PatentClass"
        Me.PatentClass.Top = 0.0!
        Me.PatentClass.Width = 2.833333!
        '
        'subrptPatentClasses
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb"
        OleDBDataSource1.SQL = "Select * from qvwPatentClasses where PatentID=1"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.822917!
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.PatentClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents PatentClass As DataDynamics.ActiveReports.TextBox
End Class
