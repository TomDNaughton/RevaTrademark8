<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestViewTable
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
        Me.grdViewTable = New Janus.Windows.GridEX.GridEX
        CType(Me.grdViewTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdViewTable
        '
        Me.grdViewTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdViewTable.Location = New System.Drawing.Point(0, 0)
        Me.grdViewTable.Name = "grdViewTable"
        Me.grdViewTable.RecordNavigator = True
        Me.grdViewTable.Size = New System.Drawing.Size(983, 500)
        Me.grdViewTable.TabIndex = 0
        '
        'frmTestViewTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 500)
        Me.Controls.Add(Me.grdViewTable)
        Me.Name = "frmTestViewTable"
        Me.Text = "frmTestViewTable"
        CType(Me.grdViewTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdViewTable As Janus.Windows.GridEX.GridEX
End Class
