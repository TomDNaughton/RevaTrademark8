<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportPreview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportPreview))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnExportDropDown = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnPDF = New System.Windows.Forms.ToolStripMenuItem
        Me.btnExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.btnRTF = New System.Windows.Forms.ToolStripMenuItem
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.PdfExport = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        Me.RtfExport = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
        Me.XlsExport = New DataDynamics.ActiveReports.Export.Xls.XlsExport
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.ReportViewer = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportDropDown, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(843, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnExportDropDown
        '
        Me.btnExportDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExportDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPDF, Me.btnExcel, Me.btnRTF})
        Me.btnExportDropDown.Image = CType(resources.GetObject("btnExportDropDown.Image"), System.Drawing.Image)
        Me.btnExportDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportDropDown.Name = "btnExportDropDown"
        Me.btnExportDropDown.Size = New System.Drawing.Size(88, 22)
        Me.btnExportDropDown.Text = "Export Report"
        '
        'btnPDF
        '
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(181, 22)
        Me.btnPDF.Text = "PDF"
        '
        'btnExcel
        '
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(181, 22)
        Me.btnExcel.Text = "Excel Spreadsheet"
        '
        'btnRTF
        '
        Me.btnRTF.Name = "btnRTF"
        Me.btnRTF.Size = New System.Drawing.Size(181, 22)
        Me.btnRTF.Text = "Rich Text Document"
        Me.btnRTF.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(89, 22)
        Me.btnClose.Text = "Close Report"
        '
        'PdfExport
        '
        Me.PdfExport.Security.Permissions = CType(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents) _
                    Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy) _
                    Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations) _
                    Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn) _
                    Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders) _
                    Or DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly), DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)
        '
        'RtfExport
        '
        Me.RtfExport.EnableShapes = False
        '
        'XlsExport
        '
        Me.XlsExport.Tweak = 0
        '
        'ReportViewer
        '
        Me.ReportViewer.BackColor = System.Drawing.SystemColors.Control
        Me.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer.Document = New DataDynamics.ActiveReports.Document.Document("ARNet Document")
        Me.ReportViewer.Location = New System.Drawing.Point(0, 25)
        Me.ReportViewer.Name = "ReportViewer"
        Me.ReportViewer.ReportViewer.CurrentPage = 0
        Me.ReportViewer.ReportViewer.MultiplePageCols = 3
        Me.ReportViewer.ReportViewer.MultiplePageRows = 2
        Me.ReportViewer.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.ReportViewer.ReportViewer.Zoom = 0.75!
        Me.ReportViewer.Size = New System.Drawing.Size(843, 495)
        Me.ReportViewer.TabIndex = 1
        Me.ReportViewer.TableOfContents.Text = "Table Of Contents"
        Me.ReportViewer.TableOfContents.Width = 200
        Me.ReportViewer.TabTitleLength = 35
        Me.ReportViewer.Toolbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'frmReportPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 520)
        Me.Controls.Add(Me.ReportViewer)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportPreview"
        Me.Text = "RevaTrademark Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportDropDown As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRTF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents PdfExport As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    Friend WithEvents RtfExport As DataDynamics.ActiveReports.Export.Rtf.RtfExport
    Friend WithEvents XlsExport As DataDynamics.ActiveReports.Export.Xls.XlsExport
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ReportViewer As DataDynamics.ActiveReports.Viewer.Viewer
End Class
