<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LicenseNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnLicense = New Janus.Windows.EditControls.UIButton
        Me.lblUser = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSecurity = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RevaTrademark version 6.0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Copyright 2014, RevaWare Inc."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Technical Support:  Trademarks@RevaWare.com"
        '
        'LicenseNumber
        '
        Me.LicenseNumber.Location = New System.Drawing.Point(120, 173)
        Me.LicenseNumber.Name = "LicenseNumber"
        Me.LicenseNumber.Size = New System.Drawing.Size(109, 20)
        Me.LicenseNumber.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "in the field below and click the License button."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(244, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "To License the software, type your license number"
        '
        'btnLicense
        '
        Me.btnLicense.ActiveFormatStyle.BackColor = System.Drawing.SystemColors.Control
        Me.btnLicense.Appearance = Janus.Windows.UI.Appearance.Normal
        Me.btnLicense.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLicense.Image = CType(resources.GetObject("btnLicense.Image"), System.Drawing.Image)
        Me.btnLicense.Location = New System.Drawing.Point(128, 202)
        Me.btnLicense.Name = "btnLicense"
        Me.btnLicense.Size = New System.Drawing.Size(93, 23)
        Me.btnLicense.StateStyles.FormatStyle.BackColor = System.Drawing.SystemColors.Control
        Me.btnLicense.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnLicense.TabIndex = 42
        Me.btnLicense.TabStop = False
        Me.btnLicense.Text = "License"
        Me.btnLicense.UseThemes = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(58, 248)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(39, 13)
        Me.lblUser.TabIndex = 43
        Me.lblUser.Text = "Label6"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "UserID:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Security Level:"
        '
        'lblSecurity
        '
        Me.lblSecurity.AutoSize = True
        Me.lblSecurity.Location = New System.Drawing.Point(327, 248)
        Me.lblSecurity.Name = "lblSecurity"
        Me.lblSecurity.Size = New System.Drawing.Size(13, 13)
        Me.lblSecurity.TabIndex = 45
        Me.lblSecurity.Text = "0"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(349, 270)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSecurity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnLicense)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LicenseNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RevaTrademark"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LicenseNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnLicense As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSecurity As System.Windows.Forms.Label

End Class
