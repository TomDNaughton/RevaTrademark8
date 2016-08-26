<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class subrptOppositionMarks
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(subrptOppositionMarks))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TrademarkName = New DataDynamics.ActiveReports.TextBox
        Me.ApplicationNumber = New DataDynamics.ActiveReports.TextBox
        Me.RegistrationNumber = New DataDynamics.ActiveReports.TextBox
        Me.FilingDate = New DataDynamics.ActiveReports.TextBox
        Me.FirstUseDate = New DataDynamics.ActiveReports.TextBox
        Me.RegistrationDate = New DataDynamics.ActiveReports.TextBox
        Me.Label92 = New DataDynamics.ActiveReports.Label
        Me.Label106 = New DataDynamics.ActiveReports.Label
        Me.Label334 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.FirstUse = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.TrademarkName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilingDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstUseDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegistrationDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label334, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TrademarkName, Me.ApplicationNumber, Me.RegistrationNumber, Me.FilingDate, Me.FirstUseDate, Me.RegistrationDate})
        Me.Detail1.Height = 0.1979167!
        Me.Detail1.Name = "Detail1"
        '
        'TrademarkName
        '
        Me.TrademarkName.Border.BottomColor = System.Drawing.Color.Black
        Me.TrademarkName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkName.Border.LeftColor = System.Drawing.Color.Black
        Me.TrademarkName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkName.Border.RightColor = System.Drawing.Color.Black
        Me.TrademarkName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkName.Border.TopColor = System.Drawing.Color.Black
        Me.TrademarkName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkName.DataField = "TrademarkName"
        Me.TrademarkName.Height = 0.1770833!
        Me.TrademarkName.Left = 0.01041667!
        Me.TrademarkName.Name = "TrademarkName"
        Me.TrademarkName.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.TrademarkName.Tag = ""
        Me.TrademarkName.Text = "TrademarkName"
        Me.TrademarkName.Top = 0.0!
        Me.TrademarkName.Width = 2.739583!
        '
        'ApplicationNumber
        '
        Me.ApplicationNumber.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ApplicationNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ApplicationNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ApplicationNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ApplicationNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ApplicationNumber.DataField = "ApplicationNumber"
        Me.ApplicationNumber.Height = 0.1875!
        Me.ApplicationNumber.Left = 2.802083!
        Me.ApplicationNumber.Name = "ApplicationNumber"
        Me.ApplicationNumber.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.ApplicationNumber.Tag = ""
        Me.ApplicationNumber.Text = "ApplicationNumber"
        Me.ApplicationNumber.Top = 0.0!
        Me.ApplicationNumber.Width = 0.875!
        '
        'RegistrationNumber
        '
        Me.RegistrationNumber.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RegistrationNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RegistrationNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RegistrationNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RegistrationNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationNumber.DataField = "RegistrationNumber"
        Me.RegistrationNumber.Height = 0.1875!
        Me.RegistrationNumber.Left = 3.718749!
        Me.RegistrationNumber.Name = "RegistrationNumber"
        Me.RegistrationNumber.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.RegistrationNumber.Tag = ""
        Me.RegistrationNumber.Text = "RegistrationNumber"
        Me.RegistrationNumber.Top = 0.0!
        Me.RegistrationNumber.Width = 0.8854167!
        '
        'FilingDate
        '
        Me.FilingDate.Border.BottomColor = System.Drawing.Color.Black
        Me.FilingDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingDate.Border.LeftColor = System.Drawing.Color.Black
        Me.FilingDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingDate.Border.RightColor = System.Drawing.Color.Black
        Me.FilingDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingDate.Border.TopColor = System.Drawing.Color.Black
        Me.FilingDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FilingDate.DataField = "FilingDate"
        Me.FilingDate.Height = 0.1666667!
        Me.FilingDate.Left = 4.645833!
        Me.FilingDate.Name = "FilingDate"
        Me.FilingDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.FilingDate.Tag = ""
        Me.FilingDate.Text = "FilingDate"
        Me.FilingDate.Top = 0.0!
        Me.FilingDate.Width = 0.875!
        '
        'FirstUseDate
        '
        Me.FirstUseDate.Border.BottomColor = System.Drawing.Color.Black
        Me.FirstUseDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUseDate.Border.LeftColor = System.Drawing.Color.Black
        Me.FirstUseDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUseDate.Border.RightColor = System.Drawing.Color.Black
        Me.FirstUseDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUseDate.Border.TopColor = System.Drawing.Color.Black
        Me.FirstUseDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUseDate.DataField = "FirstUseDate"
        Me.FirstUseDate.Height = 0.1666667!
        Me.FirstUseDate.Left = 5.5625!
        Me.FirstUseDate.Name = "FirstUseDate"
        Me.FirstUseDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.FirstUseDate.Tag = ""
        Me.FirstUseDate.Text = "FirstUseDate"
        Me.FirstUseDate.Top = 0.0!
        Me.FirstUseDate.Width = 0.875!
        '
        'RegistrationDate
        '
        Me.RegistrationDate.Border.BottomColor = System.Drawing.Color.Black
        Me.RegistrationDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationDate.Border.LeftColor = System.Drawing.Color.Black
        Me.RegistrationDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationDate.Border.RightColor = System.Drawing.Color.Black
        Me.RegistrationDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationDate.Border.TopColor = System.Drawing.Color.Black
        Me.RegistrationDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RegistrationDate.DataField = "RegistrationDate"
        Me.RegistrationDate.Height = 0.1666667!
        Me.RegistrationDate.Left = 6.46875!
        Me.RegistrationDate.Name = "RegistrationDate"
        Me.RegistrationDate.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.RegistrationDate.Tag = ""
        Me.RegistrationDate.Text = "RegistrationDate"
        Me.RegistrationDate.Top = 0.0!
        Me.RegistrationDate.Width = 0.875!
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
        Me.Label92.Left = 0.0!
        Me.Label92.Name = "Label92"
        Me.Label92.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label92.Tag = ""
        Me.Label92.Text = "Opposition Trademark"
        Me.Label92.Top = 0.0!
        Me.Label92.Width = 1.489583!
        '
        'Label106
        '
        Me.Label106.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label106.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label106.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label106.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label106.Height = 0.1666667!
        Me.Label106.HyperLink = Nothing
        Me.Label106.Left = 2.833333!
        Me.Label106.Name = "Label106"
        Me.Label106.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label106.Tag = ""
        Me.Label106.Text = "Application"
        Me.Label106.Top = 0.0!
        Me.Label106.Width = 0.875!
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
        Me.Label334.Left = 3.718749!
        Me.Label334.Name = "Label334"
        Me.Label334.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label334.Tag = ""
        Me.Label334.Text = "Reg. Number"
        Me.Label334.Top = 0.0!
        Me.Label334.Width = 0.8854167!
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
        Me.Label1.Height = 0.1666667!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 4.645833!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label1.Tag = ""
        Me.Label1.Text = "Filing Date"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.8854167!
        '
        'FirstUse
        '
        Me.FirstUse.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FirstUse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUse.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FirstUse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUse.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FirstUse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUse.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FirstUse.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FirstUse.Height = 0.1666667!
        Me.FirstUse.HyperLink = Nothing
        Me.FirstUse.Left = 5.5625!
        Me.FirstUse.Name = "FirstUse"
        Me.FirstUse.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.FirstUse.Tag = ""
        Me.FirstUse.Text = "First Use"
        Me.FirstUse.Top = 0.0!
        Me.FirstUse.Width = 0.75!
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
        Me.Label2.Left = 6.46875!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label2.Tag = ""
        Me.Label2.Text = "Registration"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.8229167!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label92, Me.Label106, Me.Label334, Me.Label1, Me.FirstUse, Me.Label2})
        Me.ReportHeader1.Height = 0.1875!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'subrptOppositionMarks
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\RevaVB\RevaTrademark\RevaTrademar" & _
            "k.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from tblPatentActions"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.364583!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.TrademarkName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilingDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstUseDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegistrationDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label334, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents TrademarkName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ApplicationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents RegistrationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label92 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label106 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label334 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents FilingDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FirstUseDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents RegistrationDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FirstUse As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
End Class
