<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContact))
        Dim PositionID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim ContactCountry_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnAddToOutlook = New Janus.Windows.EditControls.UIButton
        Me.btnClose = New Janus.Windows.EditControls.UIButton
        Me.btnSaveContact = New Janus.Windows.EditControls.UIButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.ContactAddressTwo = New System.Windows.Forms.TextBox
        Me.ContactAddressOne = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContactPostalCode = New System.Windows.Forms.TextBox
        Me.ContactStateProvince = New System.Windows.Forms.TextBox
        Me.ContactCity = New System.Windows.Forms.TextBox
        Me.ContactMobilePhone = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ContactPhone = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LastName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.FirstName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Salutation = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GreetingLine = New System.Windows.Forms.TextBox
        Me.ContactTitle = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.MiddleName = New System.Windows.Forms.TextBox
        Me.Suffix = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.ContactEmail = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ContactFax = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.ContactPager = New System.Windows.Forms.TextBox
        Me.PositionID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnPosition = New System.Windows.Forms.Button
        Me.AddToTrademarks = New System.Windows.Forms.CheckBox
        Me.AddToPatents = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ContactCountry = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnCopyAddress = New System.Windows.Forms.Button
        Me.btnCopyPhone = New System.Windows.Forms.Button
        Me.pnlButton.SuspendLayout()
        CType(Me.PositionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlButton.Controls.Add(Me.btnAddToOutlook)
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Controls.Add(Me.btnSaveContact)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 436)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(330, 44)
        Me.pnlButton.TabIndex = 0
        '
        'btnAddToOutlook
        '
        Me.btnAddToOutlook.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToOutlook.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnAddToOutlook.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToOutlook.Image = CType(resources.GetObject("btnAddToOutlook.Image"), System.Drawing.Image)
        Me.btnAddToOutlook.Location = New System.Drawing.Point(125, 11)
        Me.btnAddToOutlook.Name = "btnAddToOutlook"
        Me.btnAddToOutlook.Size = New System.Drawing.Size(102, 20)
        Me.btnAddToOutlook.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToOutlook.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnAddToOutlook.TabIndex = 44
        Me.btnAddToOutlook.TabStop = False
        Me.btnAddToOutlook.Text = "Save To Outlook"
        Me.btnAddToOutlook.UseThemes = False
        '
        'btnClose
        '
        Me.btnClose.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(243, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 20)
        Me.btnClose.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClose.TabIndex = 43
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Cancel"
        Me.btnClose.UseThemes = False
        '
        'btnSaveContact
        '
        Me.btnSaveContact.ActiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSaveContact.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnSaveContact.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveContact.Image = CType(resources.GetObject("btnSaveContact.Image"), System.Drawing.Image)
        Me.btnSaveContact.Location = New System.Drawing.Point(18, 11)
        Me.btnSaveContact.Name = "btnSaveContact"
        Me.btnSaveContact.Size = New System.Drawing.Size(90, 20)
        Me.btnSaveContact.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSaveContact.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnSaveContact.TabIndex = 41
        Me.btnSaveContact.TabStop = False
        Me.btnSaveContact.Text = "Save Contact"
        Me.btnSaveContact.UseThemes = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(36, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Address 2:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactAddressTwo
        '
        Me.ContactAddressTwo.BackColor = System.Drawing.SystemColors.Window
        Me.ContactAddressTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactAddressTwo.Location = New System.Drawing.Point(94, 196)
        Me.ContactAddressTwo.MaxLength = 50
        Me.ContactAddressTwo.Name = "ContactAddressTwo"
        Me.ContactAddressTwo.Size = New System.Drawing.Size(211, 20)
        Me.ContactAddressTwo.TabIndex = 12
        '
        'ContactAddressOne
        '
        Me.ContactAddressOne.BackColor = System.Drawing.SystemColors.Window
        Me.ContactAddressOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactAddressOne.Location = New System.Drawing.Point(94, 173)
        Me.ContactAddressOne.MaxLength = 50
        Me.ContactAddressOne.Name = "ContactAddressOne"
        Me.ContactAddressOne.Size = New System.Drawing.Size(211, 20)
        Me.ContactAddressOne.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Zip/Postal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "State/Province:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "City:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactPostalCode
        '
        Me.ContactPostalCode.BackColor = System.Drawing.SystemColors.Window
        Me.ContactPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactPostalCode.Location = New System.Drawing.Point(94, 265)
        Me.ContactPostalCode.MaxLength = 20
        Me.ContactPostalCode.Name = "ContactPostalCode"
        Me.ContactPostalCode.Size = New System.Drawing.Size(211, 20)
        Me.ContactPostalCode.TabIndex = 15
        '
        'ContactStateProvince
        '
        Me.ContactStateProvince.BackColor = System.Drawing.SystemColors.Window
        Me.ContactStateProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactStateProvince.Location = New System.Drawing.Point(94, 242)
        Me.ContactStateProvince.MaxLength = 50
        Me.ContactStateProvince.Name = "ContactStateProvince"
        Me.ContactStateProvince.Size = New System.Drawing.Size(211, 20)
        Me.ContactStateProvince.TabIndex = 14
        '
        'ContactCity
        '
        Me.ContactCity.BackColor = System.Drawing.SystemColors.Window
        Me.ContactCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactCity.Location = New System.Drawing.Point(94, 219)
        Me.ContactCity.MaxLength = 50
        Me.ContactCity.Name = "ContactCity"
        Me.ContactCity.Size = New System.Drawing.Size(211, 20)
        Me.ContactCity.TabIndex = 13
        '
        'ContactMobilePhone
        '
        Me.ContactMobilePhone.BackColor = System.Drawing.SystemColors.Window
        Me.ContactMobilePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactMobilePhone.Location = New System.Drawing.Point(94, 334)
        Me.ContactMobilePhone.MaxLength = 25
        Me.ContactMobilePhone.Name = "ContactMobilePhone"
        Me.ContactMobilePhone.Size = New System.Drawing.Size(211, 20)
        Me.ContactMobilePhone.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 338)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "Cell Phone:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactPhone
        '
        Me.ContactPhone.BackColor = System.Drawing.SystemColors.Window
        Me.ContactPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactPhone.Location = New System.Drawing.Point(94, 311)
        Me.ContactPhone.MaxLength = 25
        Me.ContactPhone.Name = "ContactPhone"
        Me.ContactPhone.Size = New System.Drawing.Size(211, 20)
        Me.ContactPhone.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Last Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LastName
        '
        Me.LastName.BackColor = System.Drawing.SystemColors.Window
        Me.LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LastName.Location = New System.Drawing.Point(94, 58)
        Me.LastName.MaxLength = 50
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(105, 20)
        Me.LastName.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "First Name:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FirstName
        '
        Me.FirstName.BackColor = System.Drawing.SystemColors.Window
        Me.FirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FirstName.Location = New System.Drawing.Point(94, 35)
        Me.FirstName.MaxLength = 50
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(105, 20)
        Me.FirstName.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Salutation:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Salutation
        '
        Me.Salutation.BackColor = System.Drawing.SystemColors.Window
        Me.Salutation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Salutation.Location = New System.Drawing.Point(94, 12)
        Me.Salutation.MaxLength = 5
        Me.Salutation.Name = "Salutation"
        Me.Salutation.Size = New System.Drawing.Size(105, 20)
        Me.Salutation.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Greeting Line:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(63, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Title:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GreetingLine
        '
        Me.GreetingLine.BackColor = System.Drawing.SystemColors.Window
        Me.GreetingLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GreetingLine.Location = New System.Drawing.Point(94, 104)
        Me.GreetingLine.MaxLength = 50
        Me.GreetingLine.Name = "GreetingLine"
        Me.GreetingLine.Size = New System.Drawing.Size(211, 20)
        Me.GreetingLine.TabIndex = 7
        '
        'ContactTitle
        '
        Me.ContactTitle.BackColor = System.Drawing.SystemColors.Window
        Me.ContactTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactTitle.Location = New System.Drawing.Point(94, 81)
        Me.ContactTitle.MaxLength = 50
        Me.ContactTitle.Name = "ContactTitle"
        Me.ContactTitle.Size = New System.Drawing.Size(211, 20)
        Me.ContactTitle.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(201, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Middle:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MiddleName
        '
        Me.MiddleName.BackColor = System.Drawing.SystemColors.Window
        Me.MiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MiddleName.Location = New System.Drawing.Point(243, 35)
        Me.MiddleName.MaxLength = 15
        Me.MiddleName.Name = "MiddleName"
        Me.MiddleName.Size = New System.Drawing.Size(62, 20)
        Me.MiddleName.TabIndex = 3
        '
        'Suffix
        '
        Me.Suffix.BackColor = System.Drawing.SystemColors.Window
        Me.Suffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Suffix.Location = New System.Drawing.Point(243, 58)
        Me.Suffix.MaxLength = 10
        Me.Suffix.Name = "Suffix"
        Me.Suffix.Size = New System.Drawing.Size(62, 20)
        Me.Suffix.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(206, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Suffix:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactEmail
        '
        Me.ContactEmail.BackColor = System.Drawing.SystemColors.Window
        Me.ContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactEmail.Location = New System.Drawing.Point(94, 403)
        Me.ContactEmail.MaxLength = 125
        Me.ContactEmail.Name = "ContactEmail"
        Me.ContactEmail.Size = New System.Drawing.Size(211, 20)
        Me.ContactEmail.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(58, 408)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Email:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactFax
        '
        Me.ContactFax.BackColor = System.Drawing.SystemColors.Window
        Me.ContactFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactFax.Location = New System.Drawing.Point(94, 380)
        Me.ContactFax.MaxLength = 25
        Me.ContactFax.Name = "ContactFax"
        Me.ContactFax.Size = New System.Drawing.Size(211, 20)
        Me.ContactFax.TabIndex = 20
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(66, 384)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Fax:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(55, 359)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Pager:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactPager
        '
        Me.ContactPager.BackColor = System.Drawing.SystemColors.Window
        Me.ContactPager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactPager.Location = New System.Drawing.Point(94, 357)
        Me.ContactPager.MaxLength = 25
        Me.ContactPager.Name = "ContactPager"
        Me.ContactPager.Size = New System.Drawing.Size(211, 20)
        Me.ContactPager.TabIndex = 19
        '
        'PositionID
        '
        Me.PositionID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        PositionID_DesignTimeLayout.LayoutString = resources.GetString("PositionID_DesignTimeLayout.LayoutString")
        Me.PositionID.DesignTimeLayout = PositionID_DesignTimeLayout
        Me.PositionID.DisplayMember = "PositionName"
        Me.PositionID.Location = New System.Drawing.Point(94, 127)
        Me.PositionID.Name = "PositionID"
        Me.PositionID.SelectedIndex = -1
        Me.PositionID.SelectedItem = Nothing
        Me.PositionID.Size = New System.Drawing.Size(211, 20)
        Me.PositionID.TabIndex = 8
        Me.PositionID.ValueMember = "PositionID"
        '
        'btnPosition
        '
        Me.btnPosition.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPosition.FlatAppearance.BorderSize = 0
        Me.btnPosition.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPosition.ForeColor = System.Drawing.Color.Blue
        Me.btnPosition.Location = New System.Drawing.Point(43, 125)
        Me.btnPosition.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPosition.Name = "btnPosition"
        Me.btnPosition.Size = New System.Drawing.Size(55, 21)
        Me.btnPosition.TabIndex = 106
        Me.btnPosition.TabStop = False
        Me.btnPosition.Text = "Position:"
        Me.btnPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPosition.UseVisualStyleBackColor = False
        '
        'AddToTrademarks
        '
        Me.AddToTrademarks.AutoSize = True
        Me.AddToTrademarks.BackColor = System.Drawing.Color.Transparent
        Me.AddToTrademarks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddToTrademarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddToTrademarks.Location = New System.Drawing.Point(94, 151)
        Me.AddToTrademarks.Name = "AddToTrademarks"
        Me.AddToTrademarks.Size = New System.Drawing.Size(93, 17)
        Me.AddToTrademarks.TabIndex = 9
        Me.AddToTrademarks.Text = "All Trademarks"
        Me.AddToTrademarks.UseVisualStyleBackColor = False
        '
        'AddToPatents
        '
        Me.AddToPatents.AutoSize = True
        Me.AddToPatents.BackColor = System.Drawing.Color.Transparent
        Me.AddToPatents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddToPatents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddToPatents.Location = New System.Drawing.Point(223, 151)
        Me.AddToPatents.Name = "AddToPatents"
        Me.AddToPatents.Size = New System.Drawing.Size(73, 17)
        Me.AddToPatents.TabIndex = 10
        Me.AddToPatents.Text = "All Patents"
        Me.AddToPatents.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Country:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactCountry
        '
        Me.ContactCountry.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        ContactCountry_DesignTimeLayout.LayoutString = resources.GetString("ContactCountry_DesignTimeLayout.LayoutString")
        Me.ContactCountry.DesignTimeLayout = ContactCountry_DesignTimeLayout
        Me.ContactCountry.DisplayMember = "Country"
        Me.ContactCountry.Location = New System.Drawing.Point(94, 288)
        Me.ContactCountry.Name = "ContactCountry"
        Me.ContactCountry.SelectedIndex = -1
        Me.ContactCountry.SelectedItem = Nothing
        Me.ContactCountry.Size = New System.Drawing.Size(211, 20)
        Me.ContactCountry.TabIndex = 16
        Me.ContactCountry.ValueMember = "Country"
        '
        'btnCopyAddress
        '
        Me.btnCopyAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyAddress.FlatAppearance.BorderSize = 0
        Me.btnCopyAddress.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCopyAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAddress.ForeColor = System.Drawing.Color.Blue
        Me.btnCopyAddress.Location = New System.Drawing.Point(33, 172)
        Me.btnCopyAddress.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCopyAddress.Name = "btnCopyAddress"
        Me.btnCopyAddress.Size = New System.Drawing.Size(65, 21)
        Me.btnCopyAddress.TabIndex = 111
        Me.btnCopyAddress.TabStop = False
        Me.btnCopyAddress.Text = "Address 1:"
        Me.btnCopyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopyAddress.UseVisualStyleBackColor = False
        '
        'btnCopyPhone
        '
        Me.btnCopyPhone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyPhone.FlatAppearance.BorderSize = 0
        Me.btnCopyPhone.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCopyPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyPhone.ForeColor = System.Drawing.Color.Blue
        Me.btnCopyPhone.Location = New System.Drawing.Point(47, 311)
        Me.btnCopyPhone.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCopyPhone.Name = "btnCopyPhone"
        Me.btnCopyPhone.Size = New System.Drawing.Size(50, 21)
        Me.btnCopyPhone.TabIndex = 112
        Me.btnCopyPhone.TabStop = False
        Me.btnCopyPhone.Text = "Phone:"
        Me.btnCopyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopyPhone.UseVisualStyleBackColor = False
        '
        'frmContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(330, 480)
        Me.Controls.Add(Me.ContactCountry)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AddToPatents)
        Me.Controls.Add(Me.AddToTrademarks)
        Me.Controls.Add(Me.PositionID)
        Me.Controls.Add(Me.btnPosition)
        Me.Controls.Add(Me.ContactEmail)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ContactFax)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ContactPager)
        Me.Controls.Add(Me.Suffix)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MiddleName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Salutation)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GreetingLine)
        Me.Controls.Add(Me.ContactTitle)
        Me.Controls.Add(Me.ContactMobilePhone)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ContactPhone)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ContactAddressTwo)
        Me.Controls.Add(Me.ContactAddressOne)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ContactPostalCode)
        Me.Controls.Add(Me.ContactStateProvince)
        Me.Controls.Add(Me.ContactCity)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnCopyAddress)
        Me.Controls.Add(Me.btnCopyPhone)
        Me.Name = "frmContact"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add / Edit Contacts"
        Me.TopMost = True
        Me.pnlButton.ResumeLayout(False)
        CType(Me.PositionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactCountry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnSaveContact As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ContactAddressTwo As System.Windows.Forms.TextBox
    Friend WithEvents ContactAddressOne As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContactPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents ContactStateProvince As System.Windows.Forms.TextBox
    Friend WithEvents ContactCity As System.Windows.Forms.TextBox
    Friend WithEvents ContactMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LastName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Salutation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GreetingLine As System.Windows.Forms.TextBox
    Friend WithEvents ContactTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MiddleName As System.Windows.Forms.TextBox
    Friend WithEvents Suffix As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ContactEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ContactFax As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ContactPager As System.Windows.Forms.TextBox
    Friend WithEvents PositionID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnPosition As System.Windows.Forms.Button
    Friend WithEvents AddToTrademarks As System.Windows.Forms.CheckBox
    Friend WithEvents AddToPatents As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ContactCountry As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCopyAddress As System.Windows.Forms.Button
    Friend WithEvents btnCopyPhone As System.Windows.Forms.Button
    Friend WithEvents btnAddToOutlook As Janus.Windows.EditControls.UIButton
End Class
