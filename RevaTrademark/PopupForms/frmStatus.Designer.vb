<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim grdStatus_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatus))
        Me.grdStatus = New Janus.Windows.GridEX.GridEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdStatus
        '
        Me.grdStatus.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.AllowCardSizing = False
        Me.grdStatus.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.AlternatingColors = True
        Me.grdStatus.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdStatus.BackColor = System.Drawing.Color.LightSteelBlue
        grdStatus_DesignTimeLayout.LayoutString = resources.GetString("grdStatus_DesignTimeLayout.LayoutString")
        Me.grdStatus.DesignTimeLayout = grdStatus_DesignTimeLayout
        Me.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdStatus.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdStatus.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdStatus.GroupByBoxVisible = False
        Me.grdStatus.HeaderFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStatus.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdStatus.Location = New System.Drawing.Point(0, 0)
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdStatus.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdStatus.Size = New System.Drawing.Size(419, 401)
        Me.grdStatus.TabIndex = 37
        Me.grdStatus.TabStop = False
        Me.grdStatus.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdStatus.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 362)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(419, 39)
        Me.Panel1.TabIndex = 38
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(163, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(73, 21)
        Me.btnClose.TabIndex = 38
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 401)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Status"
        Me.TopMost = True
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdStatus As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClose As Button
End Class
