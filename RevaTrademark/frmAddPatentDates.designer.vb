<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPatentDates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddPatentDates))
        Dim grdAddDates_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnClose = New Janus.Windows.EditControls.UIButton
        Me.btnAddDates = New Janus.Windows.EditControls.UIButton
        Me.grdAddDates = New Janus.Windows.GridEX.GridEX
        Me.pnlButton.SuspendLayout()
        CType(Me.grdAddDates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Controls.Add(Me.btnAddDates)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 311)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(364, 44)
        Me.pnlButton.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(195, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 20)
        Me.btnClose.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClose.TabIndex = 43
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseThemes = False
        '
        'btnAddDates
        '
        Me.btnAddDates.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddDates.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnAddDates.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDates.Image = CType(resources.GetObject("btnAddDates.Image"), System.Drawing.Image)
        Me.btnAddDates.Location = New System.Drawing.Point(112, 11)
        Me.btnAddDates.Name = "btnAddDates"
        Me.btnAddDates.Size = New System.Drawing.Size(76, 20)
        Me.btnAddDates.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddDates.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnAddDates.TabIndex = 41
        Me.btnAddDates.TabStop = False
        Me.btnAddDates.Text = "Add Dates"
        Me.btnAddDates.UseThemes = False
        '
        'grdAddDates
        '
        Me.grdAddDates.AllowCardSizing = False
        Me.grdAddDates.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdAddDates.AlternatingColors = True
        Me.grdAddDates.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdAddDates.BackColor = System.Drawing.Color.DarkSeaGreen
        grdAddDates_DesignTimeLayout.LayoutString = resources.GetString("grdAddDates_DesignTimeLayout.LayoutString")
        Me.grdAddDates.DesignTimeLayout = grdAddDates_DesignTimeLayout
        Me.grdAddDates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAddDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdAddDates.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdAddDates.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdAddDates.GroupByBoxVisible = False
        Me.grdAddDates.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdAddDates.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdAddDates.Location = New System.Drawing.Point(0, 0)
        Me.grdAddDates.Name = "grdAddDates"
        Me.grdAddDates.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdAddDates.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdAddDates.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdAddDates.Size = New System.Drawing.Size(364, 311)
        Me.grdAddDates.TabIndex = 53
        Me.grdAddDates.TabStop = False
        Me.grdAddDates.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'frmAddPatentDates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(364, 355)
        Me.Controls.Add(Me.grdAddDates)
        Me.Controls.Add(Me.pnlButton)
        Me.Name = "frmAddPatentDates"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Patent Dates"
        Me.TopMost = True
        Me.pnlButton.ResumeLayout(False)
        CType(Me.grdAddDates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents grdAddDates As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAddDates As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
End Class
