<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyTrademarkName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyTrademarkName))
        Dim grdMarkNames_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnClose = New Janus.Windows.EditControls.UIButton
        Me.grdMarkNames = New Janus.Windows.GridEX.GridEX
        Me.pnlButton.SuspendLayout()
        CType(Me.grdMarkNames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 389)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(368, 44)
        Me.pnlButton.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(154, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 20)
        Me.btnClose.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClose.TabIndex = 43
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseThemes = False
        '
        'grdMarkNames
        '
        Me.grdMarkNames.AllowCardSizing = False
        Me.grdMarkNames.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdMarkNames.AlternatingColors = True
        Me.grdMarkNames.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdMarkNames.BackColor = System.Drawing.Color.DarkSeaGreen
        grdMarkNames_DesignTimeLayout.LayoutString = resources.GetString("grdMarkNames_DesignTimeLayout.LayoutString")
        Me.grdMarkNames.DesignTimeLayout = grdMarkNames_DesignTimeLayout
        Me.grdMarkNames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarkNames.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdMarkNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdMarkNames.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdMarkNames.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdMarkNames.GroupByBoxVisible = False
        Me.grdMarkNames.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdMarkNames.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdMarkNames.Location = New System.Drawing.Point(0, 0)
        Me.grdMarkNames.Name = "grdMarkNames"
        Me.grdMarkNames.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdMarkNames.RecordNavigator = True
        Me.grdMarkNames.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdMarkNames.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdMarkNames.Size = New System.Drawing.Size(368, 389)
        Me.grdMarkNames.TabIndex = 38
        Me.grdMarkNames.TabStop = False
        Me.grdMarkNames.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'frmCopyTrademarkName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(368, 433)
        Me.Controls.Add(Me.grdMarkNames)
        Me.Controls.Add(Me.pnlButton)
        Me.Name = "frmCopyTrademarkName"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy Trademark Name"
        Me.TopMost = True
        Me.pnlButton.ResumeLayout(False)
        CType(Me.grdMarkNames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdMarkNames As Janus.Windows.GridEX.GridEX
End Class
