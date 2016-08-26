<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aForm1
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
        Dim grdMarks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(aForm1))
        Me.grdMarks = New Janus.Windows.GridEX.GridEX
        CType(Me.grdMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMarks
        '
        Me.grdMarks.AllowCardSizing = False
        Me.grdMarks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdMarks.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdMarks.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdMarks.AlternatingColors = True
        Me.grdMarks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdMarks.BackColor = System.Drawing.SystemColors.Control
        grdMarks_DesignTimeLayout.LayoutString = resources.GetString("grdMarks_DesignTimeLayout.LayoutString")
        Me.grdMarks.DesignTimeLayout = grdMarks_DesignTimeLayout
        Me.grdMarks.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdMarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdMarks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdMarks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdMarks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdMarks.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdMarks.Location = New System.Drawing.Point(22, 123)
        Me.grdMarks.Name = "grdMarks"
        Me.grdMarks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdMarks.RecordNavigator = True
        Me.grdMarks.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdMarks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdMarks.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdMarks.Size = New System.Drawing.Size(980, 261)
        Me.grdMarks.TabIndex = 83
        Me.grdMarks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdMarks.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'aForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 507)
        Me.Controls.Add(Me.grdMarks)
        Me.Name = "aForm1"
        Me.Text = "aForm1"
        CType(Me.grdMarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdMarks As Janus.Windows.GridEX.GridEX
End Class
