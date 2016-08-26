<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.Server = New System.Windows.Forms.TextBox()
        Me.UserID = New System.Windows.Forms.TextBox()
        Me.Database = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.optSpecific = New System.Windows.Forms.RadioButton()
        Me.optIntegrated = New System.Windows.Forms.RadioButton()
        Me.grpSecurityType = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkSavePassword = New System.Windows.Forms.CheckBox()
        Me.optSQL = New System.Windows.Forms.RadioButton()
        Me.optAccess = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnHookDev = New System.Windows.Forms.Button()
        Me.btnSQLDev = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.grpSecurityType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLogIn
        '
        Me.btnLogIn.Location = New System.Drawing.Point(71, 292)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(99, 27)
        Me.btnLogIn.TabIndex = 0
        Me.btnLogIn.Text = "Log In"
        Me.btnLogIn.UseVisualStyleBackColor = True
        '
        'Server
        '
        Me.Server.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Server.Location = New System.Drawing.Point(77, 85)
        Me.Server.MaxLength = 500
        Me.Server.Name = "Server"
        Me.Server.Size = New System.Drawing.Size(195, 20)
        Me.Server.TabIndex = 1
        '
        'UserID
        '
        Me.UserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserID.Location = New System.Drawing.Point(134, 197)
        Me.UserID.Name = "UserID"
        Me.UserID.Size = New System.Drawing.Size(138, 20)
        Me.UserID.TabIndex = 3
        '
        'Database
        '
        Me.Database.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Database.Location = New System.Drawing.Point(77, 111)
        Me.Database.Name = "Database"
        Me.Database.Size = New System.Drawing.Size(195, 20)
        Me.Database.TabIndex = 2
        '
        'Password
        '
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Password.Location = New System.Drawing.Point(134, 223)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(138, 20)
        Me.Password.TabIndex = 4
        Me.Password.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Server:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Database:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "User Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Password:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(173, 249)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(99, 27)
        Me.btnTestConnection.TabIndex = 9
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'optSpecific
        '
        Me.optSpecific.AutoSize = True
        Me.optSpecific.Location = New System.Drawing.Point(11, 32)
        Me.optSpecific.Name = "optSpecific"
        Me.optSpecific.Size = New System.Drawing.Size(176, 17)
        Me.optSpecific.TabIndex = 1
        Me.optSpecific.Text = "Specific User Name / Password"
        Me.optSpecific.UseVisualStyleBackColor = True
        '
        'optIntegrated
        '
        Me.optIntegrated.AutoSize = True
        Me.optIntegrated.Location = New System.Drawing.Point(11, 10)
        Me.optIntegrated.Name = "optIntegrated"
        Me.optIntegrated.Size = New System.Drawing.Size(161, 17)
        Me.optIntegrated.TabIndex = 0
        Me.optIntegrated.Text = "Windows Integrated Security"
        Me.optIntegrated.UseVisualStyleBackColor = True
        '
        'grpSecurityType
        '
        Me.grpSecurityType.Controls.Add(Me.optSpecific)
        Me.grpSecurityType.Controls.Add(Me.optIntegrated)
        Me.grpSecurityType.ForeColor = System.Drawing.Color.Black
        Me.grpSecurityType.Location = New System.Drawing.Point(77, 132)
        Me.grpSecurityType.Name = "grpSecurityType"
        Me.grpSecurityType.Size = New System.Drawing.Size(195, 55)
        Me.grpSecurityType.TabIndex = 10
        Me.grpSecurityType.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(173, 292)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 27)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkSavePassword
        '
        Me.chkSavePassword.AutoSize = True
        Me.chkSavePassword.Location = New System.Drawing.Point(71, 255)
        Me.chkSavePassword.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.chkSavePassword.Name = "chkSavePassword"
        Me.chkSavePassword.Size = New System.Drawing.Size(100, 17)
        Me.chkSavePassword.TabIndex = 24
        Me.chkSavePassword.Text = "Save Password"
        Me.chkSavePassword.UseVisualStyleBackColor = True
        '
        'optSQL
        '
        Me.optSQL.AutoSize = True
        Me.optSQL.Location = New System.Drawing.Point(11, 39)
        Me.optSQL.Name = "optSQL"
        Me.optSQL.Size = New System.Drawing.Size(129, 17)
        Me.optSQL.TabIndex = 1
        Me.optSQL.Text = "SQL Server Database"
        Me.optSQL.UseVisualStyleBackColor = True
        '
        'optAccess
        '
        Me.optAccess.AutoSize = True
        Me.optAccess.Checked = True
        Me.optAccess.Location = New System.Drawing.Point(11, 17)
        Me.optAccess.Name = "optAccess"
        Me.optAccess.Size = New System.Drawing.Size(152, 17)
        Me.optAccess.TabIndex = 0
        Me.optAccess.TabStop = True
        Me.optAccess.Text = "Demo / Practice Database"
        Me.optAccess.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optSQL)
        Me.GroupBox1.Controls.Add(Me.optAccess)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(78, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 63)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect To:"
        '
        'btnHookDev
        '
        Me.btnHookDev.Location = New System.Drawing.Point(12, 29)
        Me.btnHookDev.Name = "btnHookDev"
        Me.btnHookDev.Size = New System.Drawing.Size(54, 21)
        Me.btnHookDev.TabIndex = 26
        Me.btnHookDev.Text = "AC Dev"
        Me.btnHookDev.UseVisualStyleBackColor = True
        Me.btnHookDev.Visible = False
        '
        'btnSQLDev
        '
        Me.btnSQLDev.Location = New System.Drawing.Point(12, 56)
        Me.btnSQLDev.Name = "btnSQLDev"
        Me.btnSQLDev.Size = New System.Drawing.Size(54, 21)
        Me.btnSQLDev.TabIndex = 27
        Me.btnSQLDev.Text = "SQL DB"
        Me.btnSQLDev.UseVisualStyleBackColor = True
        Me.btnSQLDev.Visible = False
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(12, 195)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(54, 21)
        Me.btnTest.TabIndex = 28
        Me.btnTest.Text = "Test Stuff"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 348)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnSQLDev)
        Me.Controls.Add(Me.btnHookDev)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkSavePassword)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpSecurityType)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Database)
        Me.Controls.Add(Me.UserID)
        Me.Controls.Add(Me.Server)
        Me.Controls.Add(Me.btnLogIn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect to Database"
        Me.TopMost = True
        Me.grpSecurityType.ResumeLayout(False)
        Me.grpSecurityType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogIn As System.Windows.Forms.Button
    Friend WithEvents Server As System.Windows.Forms.TextBox
    Friend WithEvents UserID As System.Windows.Forms.TextBox
    Friend WithEvents Database As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents optSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents optIntegrated As System.Windows.Forms.RadioButton
    Friend WithEvents grpSecurityType As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkSavePassword As System.Windows.Forms.CheckBox
    Friend WithEvents optSQL As System.Windows.Forms.RadioButton
    Friend WithEvents optAccess As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHookDev As System.Windows.Forms.Button
    Friend WithEvents btnSQLDev As System.Windows.Forms.Button
    Friend WithEvents btnTest As Button
End Class
