<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrademarkPopups
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
        Dim grdRegTypes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrademarkPopups))
        Dim grdRegClasses_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdFilingBasis_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.grdRegTypes = New Janus.Windows.GridEX.GridEX
        Me.btnClose = New System.Windows.Forms.Button
        Me.grdRegClasses = New Janus.Windows.GridEX.GridEX
        Me.grdFilingBasis = New Janus.Windows.GridEX.GridEX
        CType(Me.grdRegTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRegClasses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFilingBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdRegTypes
        '
        Me.grdRegTypes.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegTypes.AllowCardSizing = False
        Me.grdRegTypes.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegTypes.AlternatingColors = True
        Me.grdRegTypes.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdRegTypes.BackColor = System.Drawing.Color.DarkSeaGreen
        grdRegTypes_DesignTimeLayout.LayoutString = resources.GetString("grdRegTypes_DesignTimeLayout.LayoutString")
        Me.grdRegTypes.DesignTimeLayout = grdRegTypes_DesignTimeLayout
        Me.grdRegTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdRegTypes.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdRegTypes.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdRegTypes.GroupByBoxVisible = False
        Me.grdRegTypes.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdRegTypes.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdRegTypes.Location = New System.Drawing.Point(0, 0)
        Me.grdRegTypes.Name = "grdRegTypes"
        Me.grdRegTypes.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdRegTypes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegTypes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdRegTypes.Size = New System.Drawing.Size(224, 220)
        Me.grdRegTypes.TabIndex = 35
        Me.grdRegTypes.TabStop = False
        Me.grdRegTypes.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdRegTypes.Visible = False
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(23, 226)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(73, 21)
        Me.btnClose.TabIndex = 37
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grdRegClasses
        '
        Me.grdRegClasses.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegClasses.AllowCardSizing = False
        Me.grdRegClasses.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegClasses.AlternatingColors = True
        Me.grdRegClasses.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdRegClasses.BackColor = System.Drawing.Color.DarkSeaGreen
        grdRegClasses_DesignTimeLayout.LayoutString = resources.GetString("grdRegClasses_DesignTimeLayout.LayoutString")
        Me.grdRegClasses.DesignTimeLayout = grdRegClasses_DesignTimeLayout
        Me.grdRegClasses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdRegClasses.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdRegClasses.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdRegClasses.GroupByBoxVisible = False
        Me.grdRegClasses.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdRegClasses.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdRegClasses.Location = New System.Drawing.Point(538, 0)
        Me.grdRegClasses.Name = "grdRegClasses"
        Me.grdRegClasses.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdRegClasses.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdRegClasses.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdRegClasses.Size = New System.Drawing.Size(251, 291)
        Me.grdRegClasses.TabIndex = 38
        Me.grdRegClasses.TabStop = False
        Me.grdRegClasses.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdRegClasses.Visible = False
        '
        'grdFilingBasis
        '
        Me.grdFilingBasis.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilingBasis.AllowCardSizing = False
        Me.grdFilingBasis.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilingBasis.AlternatingColors = True
        Me.grdFilingBasis.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdFilingBasis.BackColor = System.Drawing.Color.DarkSeaGreen
        grdFilingBasis_DesignTimeLayout.LayoutString = resources.GetString("grdFilingBasis_DesignTimeLayout.LayoutString")
        Me.grdFilingBasis.DesignTimeLayout = grdFilingBasis_DesignTimeLayout
        Me.grdFilingBasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdFilingBasis.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdFilingBasis.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdFilingBasis.GroupByBoxVisible = False
        Me.grdFilingBasis.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdFilingBasis.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdFilingBasis.Location = New System.Drawing.Point(240, 0)
        Me.grdFilingBasis.Name = "grdFilingBasis"
        Me.grdFilingBasis.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdFilingBasis.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilingBasis.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdFilingBasis.Size = New System.Drawing.Size(283, 220)
        Me.grdFilingBasis.TabIndex = 40
        Me.grdFilingBasis.TabStop = False
        Me.grdFilingBasis.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdFilingBasis.Visible = False
        '
        'frmTrademarkPopups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(809, 322)
        Me.Controls.Add(Me.grdFilingBasis)
        Me.Controls.Add(Me.grdRegClasses)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdRegTypes)
        Me.Name = "frmTrademarkPopups"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTrademarkPopups"
        Me.TopMost = True
        CType(Me.grdRegTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRegClasses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFilingBasis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdRegTypes As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grdRegClasses As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdFilingBasis As Janus.Windows.GridEX.GridEX
End Class
