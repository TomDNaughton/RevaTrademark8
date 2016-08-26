<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditTrademarkDate
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
        Dim grdRelated_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditTrademarkDate))
        Dim grdEditDate_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlRelated = New System.Windows.Forms.Panel
        Me.grdRelated = New Janus.Windows.GridEX.GridEX
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnClose = New Janus.Windows.EditControls.UIButton
        Me.btnUpdate = New Janus.Windows.EditControls.UIButton
        Me.lblDateName = New System.Windows.Forms.Label
        Me.grdEditDate = New Janus.Windows.GridEX.GridEX
        Me.pnlRelated.SuspendLayout()
        CType(Me.grdRelated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.grdEditDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRelated
        '
        Me.pnlRelated.Controls.Add(Me.grdRelated)
        Me.pnlRelated.Controls.Add(Me.Label1)
        Me.pnlRelated.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRelated.Location = New System.Drawing.Point(0, 112)
        Me.pnlRelated.Name = "pnlRelated"
        Me.pnlRelated.Size = New System.Drawing.Size(431, 135)
        Me.pnlRelated.TabIndex = 3
        '
        'grdRelated
        '
        Me.grdRelated.AllowCardSizing = False
        Me.grdRelated.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.grdRelated.BackColor = System.Drawing.Color.DarkSeaGreen
        grdRelated_DesignTimeLayout.LayoutString = resources.GetString("grdRelated_DesignTimeLayout.LayoutString")
        Me.grdRelated.DesignTimeLayout = grdRelated_DesignTimeLayout
        Me.grdRelated.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRelated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdRelated.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdRelated.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdRelated.GroupByBoxVisible = False
        Me.grdRelated.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdRelated.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdRelated.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdRelated.Location = New System.Drawing.Point(0, 25)
        Me.grdRelated.Name = "grdRelated"
        Me.grdRelated.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdRelated.RowFormatStyle.BackColor = System.Drawing.Color.LemonChiffon
        Me.grdRelated.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRelated.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdRelated.Size = New System.Drawing.Size(431, 110)
        Me.grdRelated.TabIndex = 57
        Me.grdRelated.TabStop = False
        Me.grdRelated.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Update Same Date In Selected Related Marks:"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Controls.Add(Me.btnUpdate)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 247)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(431, 44)
        Me.pnlButton.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(218, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(69, 20)
        Me.btnClose.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClose.TabIndex = 42
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseThemes = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(122, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(87, 20)
        Me.btnUpdate.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnUpdate.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnUpdate.TabIndex = 41
        Me.btnUpdate.TabStop = False
        Me.btnUpdate.Text = "Update Date"
        Me.btnUpdate.UseThemes = False
        '
        'lblDateName
        '
        Me.lblDateName.AutoSize = True
        Me.lblDateName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateName.Location = New System.Drawing.Point(7, 11)
        Me.lblDateName.Name = "lblDateName"
        Me.lblDateName.Size = New System.Drawing.Size(112, 20)
        Me.lblDateName.TabIndex = 55
        Me.lblDateName.Text = "lblDateName"
        '
        'grdEditDate
        '
        Me.grdEditDate.AllowCardSizing = False
        Me.grdEditDate.AlternatingColors = True
        Me.grdEditDate.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdEditDate.BackColor = System.Drawing.Color.DarkSeaGreen
        grdEditDate_DesignTimeLayout.LayoutString = resources.GetString("grdEditDate_DesignTimeLayout.LayoutString")
        Me.grdEditDate.DesignTimeLayout = grdEditDate_DesignTimeLayout
        Me.grdEditDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdEditDate.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdEditDate.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdEditDate.GroupByBoxVisible = False
        Me.grdEditDate.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdEditDate.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdEditDate.Location = New System.Drawing.Point(0, 39)
        Me.grdEditDate.Name = "grdEditDate"
        Me.grdEditDate.ScrollBars = Janus.Windows.GridEX.ScrollBars.None
        Me.grdEditDate.Size = New System.Drawing.Size(430, 51)
        Me.grdEditDate.TabIndex = 54
        Me.grdEditDate.TabStop = False
        Me.grdEditDate.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'frmEditTrademarkDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(431, 291)
        Me.Controls.Add(Me.lblDateName)
        Me.Controls.Add(Me.grdEditDate)
        Me.Controls.Add(Me.pnlRelated)
        Me.Controls.Add(Me.pnlButton)
        Me.Name = "frmEditTrademarkDate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Trademark Date"
        Me.TopMost = True
        Me.pnlRelated.ResumeLayout(False)
        Me.pnlRelated.PerformLayout()
        CType(Me.grdRelated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.grdEditDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlRelated As System.Windows.Forms.Panel
    Friend WithEvents grdRelated As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnUpdate As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblDateName As System.Windows.Forms.Label
    Friend WithEvents grdEditDate As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
End Class
