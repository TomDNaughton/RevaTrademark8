<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportContact))
        Dim grdContactList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnClose = New Janus.Windows.EditControls.UIButton
        Me.grdContactList = New Janus.Windows.GridEX.GridEX
        Me.pnlButton.SuspendLayout()
        CType(Me.grdContactList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 389)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(581, 44)
        Me.pnlButton.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(255, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 20)
        Me.btnClose.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClose.TabIndex = 43
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseThemes = False
        '
        'grdContactList
        '
        Me.grdContactList.AllowCardSizing = False
        Me.grdContactList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdContactList.AlternatingColors = True
        Me.grdContactList.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdContactList.BackColor = System.Drawing.Color.DarkSeaGreen
        grdContactList_DesignTimeLayout.LayoutString = resources.GetString("grdContactList_DesignTimeLayout.LayoutString")
        Me.grdContactList.DesignTimeLayout = grdContactList_DesignTimeLayout
        Me.grdContactList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdContactList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdContactList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdContactList.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdContactList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdContactList.GroupByBoxVisible = False
        Me.grdContactList.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdContactList.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdContactList.Location = New System.Drawing.Point(0, 0)
        Me.grdContactList.Name = "grdContactList"
        Me.grdContactList.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdContactList.RecordNavigator = True
        Me.grdContactList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdContactList.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdContactList.Size = New System.Drawing.Size(581, 389)
        Me.grdContactList.TabIndex = 38
        Me.grdContactList.TabStop = False
        Me.grdContactList.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'frmImportContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(581, 433)
        Me.Controls.Add(Me.grdContactList)
        Me.Controls.Add(Me.pnlButton)
        Me.Name = "frmImportContact"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Contact"
        Me.TopMost = True
        Me.pnlButton.ResumeLayout(False)
        CType(Me.grdContactList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdContactList As Janus.Windows.GridEX.GridEX
End Class
