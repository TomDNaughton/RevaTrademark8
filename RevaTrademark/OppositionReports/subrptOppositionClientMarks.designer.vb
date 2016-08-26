<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class subrptOppositionClientMarks
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(subrptOppositionClientMarks))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TrademarkName = New DataDynamics.ActiveReports.TextBox
        Me.ApplicationNumber = New DataDynamics.ActiveReports.TextBox
        Me.RegistrationNumber = New DataDynamics.ActiveReports.TextBox
        Me.TrademarkNote = New DataDynamics.ActiveReports.TextBox
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        CType(Me.TrademarkName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegistrationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrademarkNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TrademarkName, Me.ApplicationNumber, Me.RegistrationNumber, Me.TrademarkNote})
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
        'TrademarkNote
        '
        Me.TrademarkNote.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TrademarkNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkNote.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TrademarkNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkNote.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TrademarkNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkNote.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TrademarkNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TrademarkNote.DataField = "TrademarkNote"
        Me.TrademarkNote.Height = 0.1875!
        Me.TrademarkNote.Left = 4.635417!
        Me.TrademarkNote.Name = "TrademarkNote"
        Me.TrademarkNote.Style = "color: Black; text-align: left; font-weight: normal; font-size: 9pt; "
        Me.TrademarkNote.Tag = ""
        Me.TrademarkNote.Text = "TrademarkNote"
        Me.TrademarkNote.Top = 0.0!
        Me.TrademarkNote.Width = 2.666667!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.Label3, Me.Label4, Me.Label5})
        Me.ReportHeader1.Height = 0.1979167!
        Me.ReportHeader1.Name = "ReportHeader1"
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
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label2.Tag = ""
        Me.Label2.Text = "Client Trademark"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 1.28125!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.01041667!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1666667!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.802083!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label3.Tag = ""
        Me.Label3.Text = "Application"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 0.875!
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
        Me.Label4.Height = 0.1666667!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.718749!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label4.Tag = ""
        Me.Label4.Text = "Reg. Number"
        Me.Label4.Top = 0.0!
        Me.Label4.Width = 0.8854167!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1666667!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 4.635417!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Black; text-align: left; font-weight: bold; font-size: 9pt; "
        Me.Label5.Tag = ""
        Me.Label5.Text = "Note"
        Me.Label5.Top = 0.0!
        Me.Label5.Width = 0.8854167!
        '
        'subrptOppositionClientMarks
        '
        OleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademar" & _
            "k\RevaTrademark.mdb;Persist Security Info=False"
        OleDBDataSource1.SQL = "Select * from qvwOppositionClientMarks"
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
        CType(Me.TrademarkNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents TrademarkName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ApplicationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents RegistrationNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TrademarkNote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
End Class
