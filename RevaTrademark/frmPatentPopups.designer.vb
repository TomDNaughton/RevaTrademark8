<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatentPopups
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
        Dim grdFilingBasis_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatentPopups))
        Dim grdPatentClass_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdPatentTypes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.grdFilingBasis = New Janus.Windows.GridEX.GridEX
        Me.btnClose = New System.Windows.Forms.Button
        Me.grdPatentClass = New Janus.Windows.GridEX.GridEX
        Me.grdPatentTypes = New Janus.Windows.GridEX.GridEX
        CType(Me.grdFilingBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPatentClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPatentTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdFilingBasis.Location = New System.Drawing.Point(0, 0)
        Me.grdFilingBasis.Name = "grdFilingBasis"
        Me.grdFilingBasis.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdFilingBasis.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilingBasis.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdFilingBasis.Size = New System.Drawing.Size(224, 220)
        Me.grdFilingBasis.TabIndex = 35
        Me.grdFilingBasis.TabStop = False
        Me.grdFilingBasis.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdFilingBasis.Visible = False
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
        'grdPatentClass
        '
        Me.grdPatentClass.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentClass.AllowCardSizing = False
        Me.grdPatentClass.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentClass.AlternatingColors = True
        Me.grdPatentClass.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdPatentClass.BackColor = System.Drawing.Color.DarkSeaGreen
        grdPatentClass_DesignTimeLayout.LayoutString = resources.GetString("grdPatentClass_DesignTimeLayout.LayoutString")
        Me.grdPatentClass.DesignTimeLayout = grdPatentClass_DesignTimeLayout
        Me.grdPatentClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdPatentClass.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdPatentClass.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdPatentClass.GroupByBoxVisible = False
        Me.grdPatentClass.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdPatentClass.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdPatentClass.Location = New System.Drawing.Point(579, 0)
        Me.grdPatentClass.Name = "grdPatentClass"
        Me.grdPatentClass.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdPatentClass.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentClass.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdPatentClass.Size = New System.Drawing.Size(251, 291)
        Me.grdPatentClass.TabIndex = 38
        Me.grdPatentClass.TabStop = False
        Me.grdPatentClass.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdPatentClass.Visible = False
        '
        'grdPatentTypes
        '
        Me.grdPatentTypes.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentTypes.AllowCardSizing = False
        Me.grdPatentTypes.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentTypes.AlternatingColors = True
        Me.grdPatentTypes.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdPatentTypes.BackColor = System.Drawing.Color.DarkSeaGreen
        grdPatentTypes_DesignTimeLayout.LayoutString = resources.GetString("grdPatentTypes_DesignTimeLayout.LayoutString")
        Me.grdPatentTypes.DesignTimeLayout = grdPatentTypes_DesignTimeLayout
        Me.grdPatentTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdPatentTypes.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdPatentTypes.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdPatentTypes.GroupByBoxVisible = False
        Me.grdPatentTypes.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdPatentTypes.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdPatentTypes.Location = New System.Drawing.Point(258, 0)
        Me.grdPatentTypes.Name = "grdPatentTypes"
        Me.grdPatentTypes.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdPatentTypes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatentTypes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdPatentTypes.Size = New System.Drawing.Size(283, 220)
        Me.grdPatentTypes.TabIndex = 40
        Me.grdPatentTypes.TabStop = False
        Me.grdPatentTypes.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdPatentTypes.Visible = False
        '
        'frmPatentPopups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(852, 339)
        Me.Controls.Add(Me.grdPatentTypes)
        Me.Controls.Add(Me.grdPatentClass)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdFilingBasis)
        Me.Name = "frmPatentPopups"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTrademarkPopups"
        Me.TopMost = True
        CType(Me.grdFilingBasis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPatentClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPatentTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdFilingBasis As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grdPatentClass As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdPatentTypes As Janus.Windows.GridEX.GridEX
End Class
