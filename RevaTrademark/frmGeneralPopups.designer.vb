<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralPopups
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
        Dim grdStatus_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneralPopups))
        Dim grdJurisdictions_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdPositions_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdFileMatters_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdCountries_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdEntityTypes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTrademarkTypes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdFilters_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.grdStatus = New Janus.Windows.GridEX.GridEX
        Me.btnClose = New System.Windows.Forms.Button
        Me.grdJurisdictions = New Janus.Windows.GridEX.GridEX
        Me.grdPositions = New Janus.Windows.GridEX.GridEX
        Me.grdFileMatters = New Janus.Windows.GridEX.GridEX
        Me.grdCountries = New Janus.Windows.GridEX.GridEX
        Me.grdEntityTypes = New Janus.Windows.GridEX.GridEX
        Me.grdTrademarkTypes = New Janus.Windows.GridEX.GridEX
        Me.grdFilters = New Janus.Windows.GridEX.GridEX
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdJurisdictions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFileMatters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCountries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEntityTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTrademarkTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFilters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdStatus.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdStatus.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdStatus.GroupByBoxVisible = False
        Me.grdStatus.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdStatus.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdStatus.Location = New System.Drawing.Point(1, 0)
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdStatus.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdStatus.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdStatus.Size = New System.Drawing.Size(418, 219)
        Me.grdStatus.TabIndex = 36
        Me.grdStatus.TabStop = False
        Me.grdStatus.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdStatus.Visible = False
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
        'grdJurisdictions
        '
        Me.grdJurisdictions.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdJurisdictions.AllowCardSizing = False
        Me.grdJurisdictions.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdJurisdictions.AlternatingColors = True
        Me.grdJurisdictions.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdJurisdictions.BackColor = System.Drawing.Color.DarkSeaGreen
        grdJurisdictions_DesignTimeLayout.LayoutString = resources.GetString("grdJurisdictions_DesignTimeLayout.LayoutString")
        Me.grdJurisdictions.DesignTimeLayout = grdJurisdictions_DesignTimeLayout
        Me.grdJurisdictions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdJurisdictions.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdJurisdictions.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdJurisdictions.GroupByBoxVisible = False
        Me.grdJurisdictions.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdJurisdictions.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdJurisdictions.Location = New System.Drawing.Point(429, -1)
        Me.grdJurisdictions.Name = "grdJurisdictions"
        Me.grdJurisdictions.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdJurisdictions.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdJurisdictions.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdJurisdictions.Size = New System.Drawing.Size(321, 220)
        Me.grdJurisdictions.TabIndex = 39
        Me.grdJurisdictions.TabStop = False
        Me.grdJurisdictions.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdJurisdictions.Visible = False
        '
        'grdPositions
        '
        Me.grdPositions.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPositions.AllowCardSizing = False
        Me.grdPositions.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPositions.AlternatingColors = True
        Me.grdPositions.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdPositions.BackColor = System.Drawing.Color.DarkSeaGreen
        grdPositions_DesignTimeLayout.LayoutString = resources.GetString("grdPositions_DesignTimeLayout.LayoutString")
        Me.grdPositions.DesignTimeLayout = grdPositions_DesignTimeLayout
        Me.grdPositions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdPositions.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdPositions.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdPositions.GroupByBoxVisible = False
        Me.grdPositions.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdPositions.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdPositions.Location = New System.Drawing.Point(1, 253)
        Me.grdPositions.Name = "grdPositions"
        Me.grdPositions.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdPositions.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPositions.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdPositions.Size = New System.Drawing.Size(399, 220)
        Me.grdPositions.TabIndex = 41
        Me.grdPositions.TabStop = False
        Me.grdPositions.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdPositions.Visible = False
        '
        'grdFileMatters
        '
        Me.grdFileMatters.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.AllowCardSizing = False
        Me.grdFileMatters.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.AlternatingColors = True
        Me.grdFileMatters.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdFileMatters.BackColor = System.Drawing.Color.DarkSeaGreen
        grdFileMatters_DesignTimeLayout.LayoutString = resources.GetString("grdFileMatters_DesignTimeLayout.LayoutString")
        Me.grdFileMatters.DesignTimeLayout = grdFileMatters_DesignTimeLayout
        Me.grdFileMatters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdFileMatters.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdFileMatters.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdFileMatters.GroupByBoxVisible = False
        Me.grdFileMatters.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdFileMatters.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdFileMatters.Location = New System.Drawing.Point(408, 253)
        Me.grdFileMatters.Name = "grdFileMatters"
        Me.grdFileMatters.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdFileMatters.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdFileMatters.Size = New System.Drawing.Size(364, 220)
        Me.grdFileMatters.TabIndex = 42
        Me.grdFileMatters.TabStop = False
        Me.grdFileMatters.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdFileMatters.Visible = False
        '
        'grdCountries
        '
        Me.grdCountries.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdCountries.AllowCardSizing = False
        Me.grdCountries.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdCountries.AlternatingColors = True
        Me.grdCountries.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCountries.BackColor = System.Drawing.Color.DarkSeaGreen
        grdCountries_DesignTimeLayout.LayoutString = resources.GetString("grdCountries_DesignTimeLayout.LayoutString")
        Me.grdCountries.DesignTimeLayout = grdCountries_DesignTimeLayout
        Me.grdCountries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdCountries.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdCountries.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdCountries.GroupByBoxVisible = False
        Me.grdCountries.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdCountries.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdCountries.Location = New System.Drawing.Point(755, 0)
        Me.grdCountries.Name = "grdCountries"
        Me.grdCountries.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdCountries.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdCountries.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdCountries.Size = New System.Drawing.Size(224, 220)
        Me.grdCountries.TabIndex = 43
        Me.grdCountries.TabStop = False
        Me.grdCountries.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdCountries.Visible = False
        '
        'grdEntityTypes
        '
        Me.grdEntityTypes.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdEntityTypes.AllowCardSizing = False
        Me.grdEntityTypes.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdEntityTypes.AlternatingColors = True
        Me.grdEntityTypes.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdEntityTypes.BackColor = System.Drawing.Color.DarkSeaGreen
        grdEntityTypes_DesignTimeLayout.LayoutString = resources.GetString("grdEntityTypes_DesignTimeLayout.LayoutString")
        Me.grdEntityTypes.DesignTimeLayout = grdEntityTypes_DesignTimeLayout
        Me.grdEntityTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdEntityTypes.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdEntityTypes.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdEntityTypes.GroupByBoxVisible = False
        Me.grdEntityTypes.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdEntityTypes.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdEntityTypes.Location = New System.Drawing.Point(778, 253)
        Me.grdEntityTypes.Name = "grdEntityTypes"
        Me.grdEntityTypes.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdEntityTypes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdEntityTypes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdEntityTypes.Size = New System.Drawing.Size(224, 181)
        Me.grdEntityTypes.TabIndex = 44
        Me.grdEntityTypes.TabStop = False
        Me.grdEntityTypes.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdEntityTypes.Visible = False
        '
        'grdTrademarkTypes
        '
        Me.grdTrademarkTypes.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkTypes.AllowCardSizing = False
        Me.grdTrademarkTypes.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkTypes.AlternatingColors = True
        Me.grdTrademarkTypes.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTrademarkTypes.BackColor = System.Drawing.Color.DarkSeaGreen
        grdTrademarkTypes_DesignTimeLayout.LayoutString = resources.GetString("grdTrademarkTypes_DesignTimeLayout.LayoutString")
        Me.grdTrademarkTypes.DesignTimeLayout = grdTrademarkTypes_DesignTimeLayout
        Me.grdTrademarkTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdTrademarkTypes.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdTrademarkTypes.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdTrademarkTypes.GroupByBoxVisible = False
        Me.grdTrademarkTypes.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdTrademarkTypes.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdTrademarkTypes.Location = New System.Drawing.Point(995, -1)
        Me.grdTrademarkTypes.Name = "grdTrademarkTypes"
        Me.grdTrademarkTypes.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdTrademarkTypes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkTypes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdTrademarkTypes.Size = New System.Drawing.Size(224, 181)
        Me.grdTrademarkTypes.TabIndex = 45
        Me.grdTrademarkTypes.TabStop = False
        Me.grdTrademarkTypes.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdTrademarkTypes.Visible = False
        '
        'grdFilters
        '
        Me.grdFilters.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilters.AllowCardSizing = False
        Me.grdFilters.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilters.AlternatingColors = True
        Me.grdFilters.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdFilters.BackColor = System.Drawing.Color.DarkSeaGreen
        grdFilters_DesignTimeLayout.LayoutString = resources.GetString("grdFilters_DesignTimeLayout.LayoutString")
        Me.grdFilters.DesignTimeLayout = grdFilters_DesignTimeLayout
        Me.grdFilters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdFilters.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdFilters.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdFilters.GroupByBoxVisible = False
        Me.grdFilters.HeaderFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdFilters.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdFilters.Location = New System.Drawing.Point(1022, 253)
        Me.grdFilters.Name = "grdFilters"
        Me.grdFilters.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdFilters.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFilters.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdFilters.Size = New System.Drawing.Size(224, 181)
        Me.grdFilters.TabIndex = 46
        Me.grdFilters.TabStop = False
        Me.grdFilters.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdFilters.Visible = False
        '
        'frmGeneralPopups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(1270, 488)
        Me.Controls.Add(Me.grdFilters)
        Me.Controls.Add(Me.grdTrademarkTypes)
        Me.Controls.Add(Me.grdEntityTypes)
        Me.Controls.Add(Me.grdCountries)
        Me.Controls.Add(Me.grdFileMatters)
        Me.Controls.Add(Me.grdPositions)
        Me.Controls.Add(Me.grdJurisdictions)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdStatus)
        Me.Name = "frmGeneralPopups"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTrademarkPopups"
        Me.TopMost = True
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdJurisdictions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPositions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFileMatters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCountries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEntityTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTrademarkTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFilters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdStatus As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grdJurisdictions As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdPositions As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdFileMatters As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdCountries As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdEntityTypes As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdTrademarkTypes As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdFilters As Janus.Windows.GridEX.GridEX
End Class
