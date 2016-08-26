<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMergeHelper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMergeHelper))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.tlsHelper = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCopy = New System.Windows.Forms.ToolStripButton
        Me.btnPaste = New System.Windows.Forms.ToolStripButton
        Me.btnUndo = New System.Windows.Forms.ToolStripButton
        Me.btnSpellCheck = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCloseForm = New System.Windows.Forms.ToolStripButton
        Me.pnlFields = New System.Windows.Forms.Panel
        Me.lblEmailSubjectLine = New System.Windows.Forms.Label
        Me.EmailSubjectLine = New System.Windows.Forms.TextBox
        Me.cboDates = New Janus.Windows.EditControls.UIComboBox
        Me.cboContacts = New Janus.Windows.EditControls.UIComboBox
        Me.cboMarkPatent = New Janus.Windows.EditControls.UIComboBox
        Me.lblMarkPatent = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.FontDialog = New System.Windows.Forms.FontDialog
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PlainTextBox = New System.Windows.Forms.TextBox
        Me.lblDateName = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tlsHelper.SuspendLayout()
        Me.pnlFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlsHelper
        '
        Me.tlsHelper.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator1, Me.btnCopy, Me.btnPaste, Me.btnUndo, Me.btnSpellCheck, Me.ToolStripSeparator3, Me.btnCloseForm, Me.ToolStripSeparator2, Me.lblDateName})
        Me.tlsHelper.Location = New System.Drawing.Point(0, 0)
        Me.tlsHelper.Name = "tlsHelper"
        Me.tlsHelper.Size = New System.Drawing.Size(785, 25)
        Me.tlsHelper.TabIndex = 0
        Me.tlsHelper.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 22)
        Me.btnSave.Text = "Save Text Document"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnCopy
        '
        Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(23, 22)
        Me.btnCopy.Text = "Copy"
        '
        'btnPaste
        '
        Me.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPaste.Image = CType(resources.GetObject("btnPaste.Image"), System.Drawing.Image)
        Me.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(23, 22)
        Me.btnPaste.Text = "Paste"
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(23, 22)
        Me.btnUndo.Text = "Undo"
        '
        'btnSpellCheck
        '
        Me.btnSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSpellCheck.Image = CType(resources.GetObject("btnSpellCheck.Image"), System.Drawing.Image)
        Me.btnSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSpellCheck.Name = "btnSpellCheck"
        Me.btnSpellCheck.Size = New System.Drawing.Size(23, 22)
        Me.btnSpellCheck.Text = "Spell Check"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnCloseForm
        '
        Me.btnCloseForm.Image = CType(resources.GetObject("btnCloseForm.Image"), System.Drawing.Image)
        Me.btnCloseForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCloseForm.Name = "btnCloseForm"
        Me.btnCloseForm.Size = New System.Drawing.Size(87, 22)
        Me.btnCloseForm.Text = "Close Form"
        '
        'pnlFields
        '
        Me.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFields.Controls.Add(Me.lblEmailSubjectLine)
        Me.pnlFields.Controls.Add(Me.EmailSubjectLine)
        Me.pnlFields.Controls.Add(Me.cboDates)
        Me.pnlFields.Controls.Add(Me.cboContacts)
        Me.pnlFields.Controls.Add(Me.cboMarkPatent)
        Me.pnlFields.Controls.Add(Me.lblMarkPatent)
        Me.pnlFields.Controls.Add(Me.Label1)
        Me.pnlFields.Controls.Add(Me.Label2)
        Me.pnlFields.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFields.Location = New System.Drawing.Point(0, 25)
        Me.pnlFields.Name = "pnlFields"
        Me.pnlFields.Size = New System.Drawing.Size(785, 71)
        Me.pnlFields.TabIndex = 1
        '
        'lblEmailSubjectLine
        '
        Me.lblEmailSubjectLine.AutoSize = True
        Me.lblEmailSubjectLine.Location = New System.Drawing.Point(13, 35)
        Me.lblEmailSubjectLine.Name = "lblEmailSubjectLine"
        Me.lblEmailSubjectLine.Size = New System.Drawing.Size(97, 13)
        Me.lblEmailSubjectLine.TabIndex = 28
        Me.lblEmailSubjectLine.Text = "Email Subject Line:"
        Me.lblEmailSubjectLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EmailSubjectLine
        '
        Me.EmailSubjectLine.BackColor = System.Drawing.SystemColors.Window
        Me.EmailSubjectLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EmailSubjectLine.Location = New System.Drawing.Point(116, 33)
        Me.EmailSubjectLine.MaxLength = 200
        Me.EmailSubjectLine.Multiline = True
        Me.EmailSubjectLine.Name = "EmailSubjectLine"
        Me.EmailSubjectLine.Size = New System.Drawing.Size(613, 20)
        Me.EmailSubjectLine.TabIndex = 27
        Me.EmailSubjectLine.TabStop = False
        '
        'cboDates
        '
        Me.cboDates.BorderStyle = Janus.Windows.UI.BorderStyle.Flat
        Me.cboDates.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboDates.ControlAppearance.ScrollBarColor = System.Drawing.Color.LightSteelBlue
        Me.cboDates.FlatBorderColor = System.Drawing.Color.Black
        Me.cboDates.Location = New System.Drawing.Point(579, 5)
        Me.cboDates.Name = "cboDates"
        Me.cboDates.Size = New System.Drawing.Size(150, 20)
        Me.cboDates.TabIndex = 20
        Me.cboDates.TabStop = False
        Me.cboDates.UseThemes = False
        '
        'cboContacts
        '
        Me.cboContacts.BorderStyle = Janus.Windows.UI.BorderStyle.Flat
        Me.cboContacts.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboContacts.ControlAppearance.ScrollBarColor = System.Drawing.Color.LightSteelBlue
        Me.cboContacts.FlatBorderColor = System.Drawing.Color.Black
        Me.cboContacts.Location = New System.Drawing.Point(354, 5)
        Me.cboContacts.Name = "cboContacts"
        Me.cboContacts.Size = New System.Drawing.Size(142, 20)
        Me.cboContacts.TabIndex = 19
        Me.cboContacts.TabStop = False
        Me.cboContacts.UseThemes = False
        '
        'cboMarkPatent
        '
        Me.cboMarkPatent.BorderStyle = Janus.Windows.UI.BorderStyle.Flat
        Me.cboMarkPatent.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cboMarkPatent.ControlAppearance.ScrollBarColor = System.Drawing.Color.LightSteelBlue
        Me.cboMarkPatent.FlatBorderColor = System.Drawing.Color.Black
        Me.cboMarkPatent.Location = New System.Drawing.Point(116, 5)
        Me.cboMarkPatent.Name = "cboMarkPatent"
        Me.cboMarkPatent.Size = New System.Drawing.Size(136, 20)
        Me.cboMarkPatent.TabIndex = 18
        Me.cboMarkPatent.TabStop = False
        Me.cboMarkPatent.UseThemes = False
        '
        'lblMarkPatent
        '
        Me.lblMarkPatent.AutoSize = True
        Me.lblMarkPatent.Location = New System.Drawing.Point(19, 8)
        Me.lblMarkPatent.Name = "lblMarkPatent"
        Me.lblMarkPatent.Size = New System.Drawing.Size(91, 13)
        Me.lblMarkPatent.TabIndex = 15
        Me.lblMarkPatent.Text = "Trademark Fields:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(271, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Contact Fields:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(514, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Date Fields:"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 535)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 10)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 439)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(775, 96)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 439)
        Me.Panel3.TabIndex = 6
        '
        'PlainTextBox
        '
        Me.PlainTextBox.AcceptsTab = True
        Me.PlainTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlainTextBox.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlainTextBox.Location = New System.Drawing.Point(10, 96)
        Me.PlainTextBox.Multiline = True
        Me.PlainTextBox.Name = "PlainTextBox"
        Me.PlainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PlainTextBox.Size = New System.Drawing.Size(765, 439)
        Me.PlainTextBox.TabIndex = 8
        '
        'lblDateName
        '
        Me.lblDateName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDateName.Name = "lblDateName"
        Me.lblDateName.Size = New System.Drawing.Size(73, 22)
        Me.lblDateName.Text = "Date Name:"
        Me.lblDateName.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frmMergeHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(785, 545)
        Me.Controls.Add(Me.PlainTextBox)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFields)
        Me.Controls.Add(Me.tlsHelper)
        Me.Name = "frmMergeHelper"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outlook Merge Editor"
        Me.tlsHelper.ResumeLayout(False)
        Me.tlsHelper.PerformLayout()
        Me.pnlFields.ResumeLayout(False)
        Me.pnlFields.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tlsHelper As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlFields As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMarkPatent As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontDialog As System.Windows.Forms.FontDialog
    Friend WithEvents btnCloseForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PlainTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cboMarkPatent As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cboDates As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cboContacts As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblEmailSubjectLine As System.Windows.Forms.Label
    Friend WithEvents EmailSubjectLine As System.Windows.Forms.TextBox
    Friend WithEvents btnSpellCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDateName As System.Windows.Forms.ToolStripLabel
End Class
