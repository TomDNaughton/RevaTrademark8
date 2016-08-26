<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowser))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnBack = New System.Windows.Forms.ToolStripButton
        Me.btnForward = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cboAddress = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.btnGetNumber = New System.Windows.Forms.ToolStripButton
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Browser = New System.Windows.Forms.WebBrowser
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBack, Me.btnForward, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cboAddress, Me.ToolStripSeparator2, Me.btnGo, Me.btnGetNumber, Me.btnRefresh, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "tlsTools"
        '
        'btnBack
        '
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(49, 22)
        Me.btnBack.Text = "Back"
        '
        'btnForward
        '
        Me.btnForward.Image = CType(resources.GetObject("btnForward.Image"), System.Drawing.Image)
        Me.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(67, 22)
        Me.btnForward.Text = "Forward"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripLabel1.Text = "Go To:"
        '
        'cboAddress
        '
        Me.cboAddress.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.Size = New System.Drawing.Size(400, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnGo
        '
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(40, 22)
        Me.btnGo.Text = "Go"
        '
        'btnGetNumber
        '
        Me.btnGetNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGetNumber.Image = CType(resources.GetObject("btnGetNumber.Image"), System.Drawing.Image)
        Me.btnGetNumber.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGetNumber.Name = "btnGetNumber"
        Me.btnGetNumber.Size = New System.Drawing.Size(123, 22)
        Me.btnGetNumber.Text = "Get Application Number"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(65, 22)
        Me.btnRefresh.Text = "Refresh"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 22)
        Me.btnClose.Text = "Close"
        '
        'Browser
        '
        Me.Browser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Browser.Location = New System.Drawing.Point(0, 25)
        Me.Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Browser.Name = "Browser"
        Me.Browser.Size = New System.Drawing.Size(920, 504)
        Me.Browser.TabIndex = 1
        '
        'frmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 529)
        Me.Controls.Add(Me.Browser)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBrowser"
        Me.Text = "Web Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnForward As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboAddress As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGetNumber As System.Windows.Forms.ToolStripButton
End Class
