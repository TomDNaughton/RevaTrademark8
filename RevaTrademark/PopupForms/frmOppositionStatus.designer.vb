<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOppositionStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOppositionStatus))
        Dim grdStatus_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.grdStatus = New Janus.Windows.GridEX.GridEX
        Me.pnlButton.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 119)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(266, 44)
        Me.pnlButton.TabIndex = 40
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(89, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 21)
        Me.btnClose.TabIndex = 37
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grdStatus
        '
        Me.grdStatus.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.AllowCardSizing = False
        Me.grdStatus.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.AlternatingColors = True
        Me.grdStatus.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdStatus.BackColor = System.Drawing.Color.DarkSeaGreen
        grdStatus_DesignTimeLayout.LayoutString = resources.GetString("grdStatus_DesignTimeLayout.LayoutString")
        Me.grdStatus.DesignTimeLayout = grdStatus_DesignTimeLayout
        Me.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdStatus.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdStatus.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdStatus.GroupByBoxVisible = False
        Me.grdStatus.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdStatus.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdStatus.Location = New System.Drawing.Point(0, 0)
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdStatus.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdStatus.Size = New System.Drawing.Size(266, 119)
        Me.grdStatus.TabIndex = 41
        Me.grdStatus.TabStop = False
        Me.grdStatus.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'frmOppositionStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(266, 163)
        Me.Controls.Add(Me.grdStatus)
        Me.Controls.Add(Me.pnlButton)
        Me.Name = "frmOppositionStatus"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opposition Status"
        Me.TopMost = True
        Me.pnlButton.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grdStatus As Janus.Windows.GridEX.GridEX
End Class
