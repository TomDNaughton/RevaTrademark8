<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompanies))
        Dim grdCompanyList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdLinks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTrademarks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdPatents_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdContacts_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdFileMatters_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim EntityTypeID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim JurisdictionID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim Country_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.tlsTrademarks = New System.Windows.Forms.ToolStrip
        Me.btnFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnConnection = New System.Windows.Forms.ToolStripMenuItem
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnHelp = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.tutWhatsNew = New System.Windows.Forms.ToolStripMenuItem
        Me.tutOverview = New System.Windows.Forms.ToolStripMenuItem
        Me.tutPreferences = New System.Windows.Forms.ToolStripMenuItem
        Me.tutSortFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tutCompanies = New System.Windows.Forms.ToolStripMenuItem
        Me.tutCreateCompany = New System.Windows.Forms.ToolStripMenuItem
        Me.tutLinkCompanies = New System.Windows.Forms.ToolStripMenuItem
        Me.tutContacts = New System.Windows.Forms.ToolStripMenuItem
        Me.tutImportContacts = New System.Windows.Forms.ToolStripMenuItem
        Me.tutTrademarkRecords = New System.Windows.Forms.ToolStripMenuItem
        Me.tutSetContacts = New System.Windows.Forms.ToolStripMenuItem
        Me.tutWebLinks = New System.Windows.Forms.ToolStripMenuItem
        Me.tutDateTemplates = New System.Windows.Forms.ToolStripMenuItem
        Me.tutTrademarkTemplates = New System.Windows.Forms.ToolStripMenuItem
        Me.tutTrademarkOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.tutPatentOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.tutAlertsView = New System.Windows.Forms.ToolStripMenuItem
        Me.tutWordMerge = New System.Windows.Forms.ToolStripMenuItem
        Me.tutOutlook = New System.Windows.Forms.ToolStripMenuItem
        Me.tutAlertEmails = New System.Windows.Forms.ToolStripMenuItem
        Me.tutDateEmails = New System.Windows.Forms.ToolStripMenuItem
        Me.tutEmailTexts = New System.Windows.Forms.ToolStripMenuItem
        Me.tutTrademarkTreaties = New System.Windows.Forms.ToolStripMenuItem
        Me.tutStatusCheck = New System.Windows.Forms.ToolStripMenuItem
        Me.tutPatentTreaties = New System.Windows.Forms.ToolStripMenuItem
        Me.tutLinkedPatents = New System.Windows.Forms.ToolStripMenuItem
        Me.tutReports = New System.Windows.Forms.ToolStripMenuItem
        Me.tutCustomSpreadsheets = New System.Windows.Forms.ToolStripMenuItem
        Me.tutOppositions = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblGoTo = New System.Windows.Forms.ToolStripLabel
        Me.btnGoTrademarks = New System.Windows.Forms.ToolStripButton
        Me.btnGoToPatents = New System.Windows.Forms.ToolStripButton
        Me.btnGoToOppositions = New System.Windows.Forms.ToolStripButton
        Me.btnGoToContacts = New System.Windows.Forms.ToolStripButton
        Me.btnReports = New System.Windows.Forms.ToolStripButton
        Me.btnPreferences = New System.Windows.Forms.ToolStripButton
        Me.sepDemo = New System.Windows.Forms.ToolStripSeparator
        Me.lblDemo = New System.Windows.Forms.ToolStripLabel
        Me.pnlSeparator = New System.Windows.Forms.Panel
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.tbList = New System.Windows.Forms.TabPage
        Me.grdCompanyList = New Janus.Windows.GridEX.GridEX
        Me.pnlBrowse = New System.Windows.Forms.Panel
        Me.pnlListBottom = New System.Windows.Forms.Panel
        Me.grpViewBy = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New Janus.Windows.EditControls.UIButton
        Me.optContacts = New System.Windows.Forms.RadioButton
        Me.optCompanies = New System.Windows.Forms.RadioButton
        Me.grpListButtons = New System.Windows.Forms.GroupBox
        Me.btnPrintAllContacts = New Janus.Windows.EditControls.UIButton
        Me.btnNewCompany = New Janus.Windows.EditControls.UIButton
        Me.btnClearFilters = New Janus.Windows.EditControls.UIButton
        Me.tbCompany = New System.Windows.Forms.TabPage
        Me.chkLinkedOnly = New System.Windows.Forms.CheckBox
        Me.grdLinks = New Janus.Windows.GridEX.GridEX
        Me.chkShowLinked = New System.Windows.Forms.CheckBox
        Me.tabMarksPats = New System.Windows.Forms.TabControl
        Me.tbMarks = New System.Windows.Forms.TabPage
        Me.grdTrademarks = New Janus.Windows.GridEX.GridEX
        Me.tbPatents = New System.Windows.Forms.TabPage
        Me.grdPatents = New Janus.Windows.GridEX.GridEX
        Me.grdContacts = New Janus.Windows.GridEX.GridEX
        Me.grdFileMatters = New Janus.Windows.GridEX.GridEX
        Me.lblRegType = New System.Windows.Forms.GroupBox
        Me.EntityTypeID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.WebSite = New System.Windows.Forms.TextBox
        Me.CompanyFax = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.JurisdictionID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.CompanyPhone = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Notes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnEntityType = New System.Windows.Forms.Button
        Me.btnWebSite = New System.Windows.Forms.Button
        Me.btnJurisdiction = New System.Windows.Forms.Button
        Me.grpCompany = New System.Windows.Forms.GroupBox
        Me.Country = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnCountry = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.AddressTwo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.AddressOne = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CompanyName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PostalCode = New System.Windows.Forms.TextBox
        Me.StateProvince = New System.Windows.Forms.TextBox
        Me.City = New System.Windows.Forms.TextBox
        Me.pnlContacts = New System.Windows.Forms.Panel
        Me.btnGetFromOutlook = New Janus.Windows.EditControls.UIButton
        Me.btnImportContact = New System.Windows.Forms.Button
        Me.btnNewContact = New System.Windows.Forms.Button
        Me.tlsTrademarks.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.tbList.SuspendLayout()
        CType(Me.grdCompanyList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListBottom.SuspendLayout()
        Me.grpViewBy.SuspendLayout()
        Me.grpListButtons.SuspendLayout()
        Me.tbCompany.SuspendLayout()
        CType(Me.grdLinks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMarksPats.SuspendLayout()
        Me.tbMarks.SuspendLayout()
        CType(Me.grdTrademarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPatents.SuspendLayout()
        CType(Me.grdPatents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFileMatters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lblRegType.SuspendLayout()
        CType(Me.EntityTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JurisdictionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCompany.SuspendLayout()
        CType(Me.Country, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContacts.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlsTrademarks
        '
        Me.tlsTrademarks.BackColor = System.Drawing.SystemColors.Control
        Me.tlsTrademarks.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFile, Me.btnHelp, Me.ToolStripSeparator1, Me.lblGoTo, Me.btnGoTrademarks, Me.btnGoToPatents, Me.btnGoToOppositions, Me.btnGoToContacts, Me.btnReports, Me.btnPreferences, Me.sepDemo, Me.lblDemo})
        Me.tlsTrademarks.Location = New System.Drawing.Point(0, 0)
        Me.tlsTrademarks.Name = "tlsTrademarks"
        Me.tlsTrademarks.Size = New System.Drawing.Size(1016, 25)
        Me.tlsTrademarks.TabIndex = 1
        Me.tlsTrademarks.Text = "tblTrademark"
        '
        'btnFile
        '
        Me.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConnection, Me.btnExit})
        Me.btnFile.Image = CType(resources.GetObject("btnFile.Image"), System.Drawing.Image)
        Me.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(38, 22)
        Me.btnFile.Text = "File"
        '
        'btnConnection
        '
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(177, 22)
        Me.btnConnection.Text = "Connection ..."
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(177, 22)
        Me.btnExit.Text = "Exit RevaTrademark"
        '
        'btnHelp
        '
        Me.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbout, Me.ToolStripSeparator3, Me.ToolStripTextBox1, Me.tutWhatsNew, Me.tutOverview, Me.tutPreferences, Me.tutSortFind, Me.tutCompanies, Me.tutTrademarkRecords, Me.tutSetContacts, Me.tutWebLinks, Me.tutDateTemplates, Me.tutAlertsView, Me.tutWordMerge, Me.tutOutlook, Me.tutTrademarkTreaties, Me.tutStatusCheck, Me.tutPatentTreaties, Me.tutLinkedPatents, Me.tutReports, Me.tutCustomSpreadsheets, Me.tutOppositions})
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(45, 22)
        Me.btnHelp.Text = "Help"
        '
        'btnAbout
        '
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(271, 22)
        Me.btnAbout.Text = "About RevaTrademark"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(268, 6)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 21)
        Me.ToolStripTextBox1.Text = "Tutorials:"
        '
        'tutWhatsNew
        '
        Me.tutWhatsNew.Name = "tutWhatsNew"
        Me.tutWhatsNew.Size = New System.Drawing.Size(271, 22)
        Me.tutWhatsNew.Text = "What's New In Version 6.0"
        '
        'tutOverview
        '
        Me.tutOverview.Name = "tutOverview"
        Me.tutOverview.Size = New System.Drawing.Size(271, 22)
        Me.tutOverview.Text = "RevaTrademark Overview"
        '
        'tutPreferences
        '
        Me.tutPreferences.Name = "tutPreferences"
        Me.tutPreferences.Size = New System.Drawing.Size(271, 22)
        Me.tutPreferences.Text = "Setting Your Preferences"
        '
        'tutSortFind
        '
        Me.tutSortFind.Name = "tutSortFind"
        Me.tutSortFind.Size = New System.Drawing.Size(271, 22)
        Me.tutSortFind.Text = "Sorting && Finding Records"
        '
        'tutCompanies
        '
        Me.tutCompanies.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tutCreateCompany, Me.tutLinkCompanies, Me.tutContacts, Me.tutImportContacts})
        Me.tutCompanies.Name = "tutCompanies"
        Me.tutCompanies.Size = New System.Drawing.Size(271, 22)
        Me.tutCompanies.Text = "Companies && Contacts"
        '
        'tutCreateCompany
        '
        Me.tutCreateCompany.Name = "tutCreateCompany"
        Me.tutCreateCompany.Size = New System.Drawing.Size(222, 22)
        Me.tutCreateCompany.Text = "Creating Company Records"
        '
        'tutLinkCompanies
        '
        Me.tutLinkCompanies.Name = "tutLinkCompanies"
        Me.tutLinkCompanies.Size = New System.Drawing.Size(222, 22)
        Me.tutLinkCompanies.Text = "Linking Companies"
        '
        'tutContacts
        '
        Me.tutContacts.Name = "tutContacts"
        Me.tutContacts.Size = New System.Drawing.Size(222, 22)
        Me.tutContacts.Text = "Creating && Editing Contacts"
        '
        'tutImportContacts
        '
        Me.tutImportContacts.Name = "tutImportContacts"
        Me.tutImportContacts.Size = New System.Drawing.Size(222, 22)
        Me.tutImportContacts.Text = "Importing a Contact"
        '
        'tutTrademarkRecords
        '
        Me.tutTrademarkRecords.Name = "tutTrademarkRecords"
        Me.tutTrademarkRecords.Size = New System.Drawing.Size(271, 22)
        Me.tutTrademarkRecords.Text = "New Trademark && Patent Records"
        '
        'tutSetContacts
        '
        Me.tutSetContacts.Name = "tutSetContacts"
        Me.tutSetContacts.Size = New System.Drawing.Size(271, 22)
        Me.tutSetContacts.Text = "Setting Trademark && Patent Contacts"
        '
        'tutWebLinks
        '
        Me.tutWebLinks.Name = "tutWebLinks"
        Me.tutWebLinks.Size = New System.Drawing.Size(271, 22)
        Me.tutWebLinks.Text = "Using Web Links"
        '
        'tutDateTemplates
        '
        Me.tutDateTemplates.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tutTrademarkTemplates, Me.tutTrademarkOptions, Me.tutPatentOptions})
        Me.tutDateTemplates.Name = "tutDateTemplates"
        Me.tutDateTemplates.Size = New System.Drawing.Size(271, 22)
        Me.tutDateTemplates.Text = "Date Templates"
        '
        'tutTrademarkTemplates
        '
        Me.tutTrademarkTemplates.Name = "tutTrademarkTemplates"
        Me.tutTrademarkTemplates.Size = New System.Drawing.Size(203, 22)
        Me.tutTrademarkTemplates.Text = "Master Date Templates"
        '
        'tutTrademarkOptions
        '
        Me.tutTrademarkOptions.Name = "tutTrademarkOptions"
        Me.tutTrademarkOptions.Size = New System.Drawing.Size(203, 22)
        Me.tutTrademarkOptions.Text = "Trademark Date Options"
        '
        'tutPatentOptions
        '
        Me.tutPatentOptions.Name = "tutPatentOptions"
        Me.tutPatentOptions.Size = New System.Drawing.Size(203, 22)
        Me.tutPatentOptions.Text = "Patent Date Options"
        '
        'tutAlertsView
        '
        Me.tutAlertsView.Name = "tutAlertsView"
        Me.tutAlertsView.Size = New System.Drawing.Size(271, 22)
        Me.tutAlertsView.Text = "Using the Alerts View"
        '
        'tutWordMerge
        '
        Me.tutWordMerge.Name = "tutWordMerge"
        Me.tutWordMerge.Size = New System.Drawing.Size(271, 22)
        Me.tutWordMerge.Text = "Merging to Word"
        '
        'tutOutlook
        '
        Me.tutOutlook.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tutAlertEmails, Me.tutDateEmails, Me.tutEmailTexts})
        Me.tutOutlook.Name = "tutOutlook"
        Me.tutOutlook.Size = New System.Drawing.Size(271, 22)
        Me.tutOutlook.Text = "Merging to Outlook Emails"
        '
        'tutAlertEmails
        '
        Me.tutAlertEmails.Name = "tutAlertEmails"
        Me.tutAlertEmails.Size = New System.Drawing.Size(195, 22)
        Me.tutAlertEmails.Text = "Automatic Alert Emails"
        '
        'tutDateEmails
        '
        Me.tutDateEmails.Name = "tutDateEmails"
        Me.tutDateEmails.Size = New System.Drawing.Size(195, 22)
        Me.tutDateEmails.Text = "Date-Specific Emails"
        '
        'tutEmailTexts
        '
        Me.tutEmailTexts.Name = "tutEmailTexts"
        Me.tutEmailTexts.Size = New System.Drawing.Size(195, 22)
        Me.tutEmailTexts.Text = "Email Text Files"
        '
        'tutTrademarkTreaties
        '
        Me.tutTrademarkTreaties.Name = "tutTrademarkTreaties"
        Me.tutTrademarkTreaties.Size = New System.Drawing.Size(271, 22)
        Me.tutTrademarkTreaties.Text = "Trademark Treaty Submissions"
        '
        'tutStatusCheck
        '
        Me.tutStatusCheck.Name = "tutStatusCheck"
        Me.tutStatusCheck.Size = New System.Drawing.Size(271, 22)
        Me.tutStatusCheck.Text = "Trademark Status Check"
        '
        'tutPatentTreaties
        '
        Me.tutPatentTreaties.Name = "tutPatentTreaties"
        Me.tutPatentTreaties.Size = New System.Drawing.Size(271, 22)
        Me.tutPatentTreaties.Text = "Patent Treaty Submissions"
        '
        'tutLinkedPatents
        '
        Me.tutLinkedPatents.Name = "tutLinkedPatents"
        Me.tutLinkedPatents.Size = New System.Drawing.Size(271, 22)
        Me.tutLinkedPatents.Text = "Linking Patents"
        '
        'tutReports
        '
        Me.tutReports.Name = "tutReports"
        Me.tutReports.Size = New System.Drawing.Size(271, 22)
        Me.tutReports.Text = "Reports"
        '
        'tutCustomSpreadsheets
        '
        Me.tutCustomSpreadsheets.Name = "tutCustomSpreadsheets"
        Me.tutCustomSpreadsheets.Size = New System.Drawing.Size(271, 22)
        Me.tutCustomSpreadsheets.Text = "Custom Spreadsheet Reports"
        '
        'tutOppositions
        '
        Me.tutOppositions.Name = "tutOppositions"
        Me.tutOppositions.Size = New System.Drawing.Size(271, 22)
        Me.tutOppositions.Text = "Trademark Oppositions"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblGoTo
        '
        Me.lblGoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblGoTo.Name = "lblGoTo"
        Me.lblGoTo.Size = New System.Drawing.Size(42, 22)
        Me.lblGoTo.Text = "Go To:"
        '
        'btnGoTrademarks
        '
        Me.btnGoTrademarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGoTrademarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGoTrademarks.Image = CType(resources.GetObject("btnGoTrademarks.Image"), System.Drawing.Image)
        Me.btnGoTrademarks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGoTrademarks.Name = "btnGoTrademarks"
        Me.btnGoTrademarks.Size = New System.Drawing.Size(73, 22)
        Me.btnGoTrademarks.Text = "Trademarks"
        '
        'btnGoToPatents
        '
        Me.btnGoToPatents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGoToPatents.Image = CType(resources.GetObject("btnGoToPatents.Image"), System.Drawing.Image)
        Me.btnGoToPatents.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGoToPatents.Name = "btnGoToPatents"
        Me.btnGoToPatents.Size = New System.Drawing.Size(50, 22)
        Me.btnGoToPatents.Text = "Patents"
        '
        'btnGoToOppositions
        '
        Me.btnGoToOppositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGoToOppositions.Image = CType(resources.GetObject("btnGoToOppositions.Image"), System.Drawing.Image)
        Me.btnGoToOppositions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGoToOppositions.Name = "btnGoToOppositions"
        Me.btnGoToOppositions.Size = New System.Drawing.Size(75, 22)
        Me.btnGoToOppositions.Text = "Oppositions"
        '
        'btnGoToContacts
        '
        Me.btnGoToContacts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGoToContacts.ForeColor = System.Drawing.Color.Red
        Me.btnGoToContacts.Image = CType(resources.GetObject("btnGoToContacts.Image"), System.Drawing.Image)
        Me.btnGoToContacts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGoToContacts.Name = "btnGoToContacts"
        Me.btnGoToContacts.Size = New System.Drawing.Size(71, 22)
        Me.btnGoToContacts.Text = "Companies"
        '
        'btnReports
        '
        Me.btnReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(51, 22)
        Me.btnReports.Text = "Reports"
        '
        'btnPreferences
        '
        Me.btnPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPreferences.Image = CType(resources.GetObject("btnPreferences.Image"), System.Drawing.Image)
        Me.btnPreferences.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPreferences.Name = "btnPreferences"
        Me.btnPreferences.Size = New System.Drawing.Size(72, 22)
        Me.btnPreferences.Text = "Preferences"
        '
        'sepDemo
        '
        Me.sepDemo.Name = "sepDemo"
        Me.sepDemo.Size = New System.Drawing.Size(6, 25)
        '
        'lblDemo
        '
        Me.lblDemo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDemo.ForeColor = System.Drawing.Color.Red
        Me.lblDemo.LinkColor = System.Drawing.Color.Red
        Me.lblDemo.Name = "lblDemo"
        Me.lblDemo.Size = New System.Drawing.Size(168, 22)
        Me.lblDemo.Text = "DEMO / PRACTICE DATABASE"
        Me.lblDemo.VisitedLinkColor = System.Drawing.Color.Red
        '
        'pnlSeparator
        '
        Me.pnlSeparator.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSeparator.Location = New System.Drawing.Point(0, 25)
        Me.pnlSeparator.Name = "pnlSeparator"
        Me.pnlSeparator.Size = New System.Drawing.Size(1016, 13)
        Me.pnlSeparator.TabIndex = 2
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.tbList)
        Me.Tabs.Controls.Add(Me.tbCompany)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 38)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1016, 704)
        Me.Tabs.TabIndex = 3
        '
        'tbList
        '
        Me.tbList.AutoScroll = True
        Me.tbList.BackColor = System.Drawing.SystemColors.Control
        Me.tbList.Controls.Add(Me.grdCompanyList)
        Me.tbList.Controls.Add(Me.pnlBrowse)
        Me.tbList.Controls.Add(Me.pnlListBottom)
        Me.tbList.Location = New System.Drawing.Point(4, 22)
        Me.tbList.Name = "tbList"
        Me.tbList.Padding = New System.Windows.Forms.Padding(3)
        Me.tbList.Size = New System.Drawing.Size(1008, 678)
        Me.tbList.TabIndex = 0
        Me.tbList.Text = "Company/Contact List"
        '
        'grdCompanyList
        '
        Me.grdCompanyList.AllowCardSizing = False
        Me.grdCompanyList.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdCompanyList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdCompanyList.AlternatingColors = True
        Me.grdCompanyList.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCompanyList.BackColor = System.Drawing.SystemColors.Control
        grdCompanyList_DesignTimeLayout.LayoutString = resources.GetString("grdCompanyList_DesignTimeLayout.LayoutString")
        Me.grdCompanyList.DesignTimeLayout = grdCompanyList_DesignTimeLayout
        Me.grdCompanyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCompanyList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdCompanyList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdCompanyList.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdCompanyList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdCompanyList.GroupByBoxVisible = False
        Me.grdCompanyList.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdCompanyList.Location = New System.Drawing.Point(3, 22)
        Me.grdCompanyList.Name = "grdCompanyList"
        Me.grdCompanyList.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdCompanyList.RecordNavigator = True
        Me.grdCompanyList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdCompanyList.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdCompanyList.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdCompanyList.Size = New System.Drawing.Size(1002, 568)
        Me.grdCompanyList.TabIndex = 37
        Me.grdCompanyList.TabStop = False
        Me.grdCompanyList.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'pnlBrowse
        '
        Me.pnlBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrowse.Location = New System.Drawing.Point(3, 3)
        Me.pnlBrowse.Name = "pnlBrowse"
        Me.pnlBrowse.Size = New System.Drawing.Size(1002, 19)
        Me.pnlBrowse.TabIndex = 4
        '
        'pnlListBottom
        '
        Me.pnlListBottom.Controls.Add(Me.grpViewBy)
        Me.pnlListBottom.Controls.Add(Me.grpListButtons)
        Me.pnlListBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlListBottom.Location = New System.Drawing.Point(3, 590)
        Me.pnlListBottom.Name = "pnlListBottom"
        Me.pnlListBottom.Size = New System.Drawing.Size(1002, 85)
        Me.pnlListBottom.TabIndex = 3
        '
        'grpViewBy
        '
        Me.grpViewBy.Controls.Add(Me.btnRefresh)
        Me.grpViewBy.Controls.Add(Me.optContacts)
        Me.grpViewBy.Controls.Add(Me.optCompanies)
        Me.grpViewBy.Location = New System.Drawing.Point(146, 10)
        Me.grpViewBy.Name = "grpViewBy"
        Me.grpViewBy.Size = New System.Drawing.Size(353, 43)
        Me.grpViewBy.TabIndex = 62
        Me.grpViewBy.TabStop = False
        Me.grpViewBy.Text = "Select View:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnRefresh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(276, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.ShowFocusRectangle = False
        Me.btnRefresh.Size = New System.Drawing.Size(68, 20)
        Me.btnRefresh.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnRefresh.TabIndex = 18
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseThemes = False
        '
        'optContacts
        '
        Me.optContacts.AutoSize = True
        Me.optContacts.Location = New System.Drawing.Point(126, 17)
        Me.optContacts.Name = "optContacts"
        Me.optContacts.Size = New System.Drawing.Size(143, 17)
        Me.optContacts.TabIndex = 1
        Me.optContacts.Text = "Companies and Contacts"
        Me.optContacts.UseVisualStyleBackColor = True
        '
        'optCompanies
        '
        Me.optCompanies.AutoSize = True
        Me.optCompanies.Checked = True
        Me.optCompanies.Location = New System.Drawing.Point(15, 17)
        Me.optCompanies.Name = "optCompanies"
        Me.optCompanies.Size = New System.Drawing.Size(101, 17)
        Me.optCompanies.TabIndex = 0
        Me.optCompanies.TabStop = True
        Me.optCompanies.Text = "Companies Only"
        Me.optCompanies.UseVisualStyleBackColor = True
        '
        'grpListButtons
        '
        Me.grpListButtons.Controls.Add(Me.btnPrintAllContacts)
        Me.grpListButtons.Controls.Add(Me.btnNewCompany)
        Me.grpListButtons.Controls.Add(Me.btnClearFilters)
        Me.grpListButtons.Location = New System.Drawing.Point(503, 10)
        Me.grpListButtons.Name = "grpListButtons"
        Me.grpListButtons.Size = New System.Drawing.Size(328, 43)
        Me.grpListButtons.TabIndex = 51
        Me.grpListButtons.TabStop = False
        '
        'btnPrintAllContacts
        '
        Me.btnPrintAllContacts.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnPrintAllContacts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAllContacts.Image = CType(resources.GetObject("btnPrintAllContacts.Image"), System.Drawing.Image)
        Me.btnPrintAllContacts.Location = New System.Drawing.Point(217, 16)
        Me.btnPrintAllContacts.Name = "btnPrintAllContacts"
        Me.btnPrintAllContacts.ShowFocusRectangle = False
        Me.btnPrintAllContacts.Size = New System.Drawing.Size(108, 20)
        Me.btnPrintAllContacts.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnPrintAllContacts.TabIndex = 48
        Me.btnPrintAllContacts.TabStop = False
        Me.btnPrintAllContacts.Text = "Print Contacts"
        Me.btnPrintAllContacts.UseThemes = False
        '
        'btnNewCompany
        '
        Me.btnNewCompany.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnNewCompany.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewCompany.Image = CType(resources.GetObject("btnNewCompany.Image"), System.Drawing.Image)
        Me.btnNewCompany.Location = New System.Drawing.Point(15, 16)
        Me.btnNewCompany.Name = "btnNewCompany"
        Me.btnNewCompany.Size = New System.Drawing.Size(100, 20)
        Me.btnNewCompany.TabIndex = 46
        Me.btnNewCompany.Text = "New Company"
        Me.btnNewCompany.UseThemes = False
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClearFilters.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilters.Image = CType(resources.GetObject("btnClearFilters.Image"), System.Drawing.Image)
        Me.btnClearFilters.Location = New System.Drawing.Point(125, 16)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(84, 20)
        Me.btnClearFilters.TabIndex = 16
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.UseThemes = False
        '
        'tbCompany
        '
        Me.tbCompany.AutoScroll = True
        Me.tbCompany.BackColor = System.Drawing.SystemColors.Control
        Me.tbCompany.Controls.Add(Me.chkLinkedOnly)
        Me.tbCompany.Controls.Add(Me.grdLinks)
        Me.tbCompany.Controls.Add(Me.chkShowLinked)
        Me.tbCompany.Controls.Add(Me.tabMarksPats)
        Me.tbCompany.Controls.Add(Me.grdContacts)
        Me.tbCompany.Controls.Add(Me.grdFileMatters)
        Me.tbCompany.Controls.Add(Me.lblRegType)
        Me.tbCompany.Controls.Add(Me.grpCompany)
        Me.tbCompany.Controls.Add(Me.pnlContacts)
        Me.tbCompany.Location = New System.Drawing.Point(4, 22)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.Padding = New System.Windows.Forms.Padding(3)
        Me.tbCompany.Size = New System.Drawing.Size(1008, 678)
        Me.tbCompany.TabIndex = 1
        Me.tbCompany.Text = "Company/Contact Details"
        '
        'chkLinkedOnly
        '
        Me.chkLinkedOnly.AutoSize = True
        Me.chkLinkedOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLinkedOnly.ForeColor = System.Drawing.Color.Black
        Me.chkLinkedOnly.Location = New System.Drawing.Point(776, 7)
        Me.chkLinkedOnly.Margin = New System.Windows.Forms.Padding(0)
        Me.chkLinkedOnly.Name = "chkLinkedOnly"
        Me.chkLinkedOnly.Size = New System.Drawing.Size(109, 17)
        Me.chkLinkedOnly.TabIndex = 55
        Me.chkLinkedOnly.TabStop = False
        Me.chkLinkedOnly.Text = "Show Linked Only"
        Me.chkLinkedOnly.UseVisualStyleBackColor = True
        Me.chkLinkedOnly.Visible = False
        '
        'grdLinks
        '
        Me.grdLinks.AllowCardSizing = False
        Me.grdLinks.AlternatingColors = True
        Me.grdLinks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.grdLinks.BackColor = System.Drawing.SystemColors.Control
        grdLinks_DesignTimeLayout.LayoutString = resources.GetString("grdLinks_DesignTimeLayout.LayoutString")
        Me.grdLinks.DesignTimeLayout = grdLinks_DesignTimeLayout
        Me.grdLinks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdLinks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdLinks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdLinks.GroupByBoxVisible = False
        Me.grdLinks.HasEditorsControlStyle = True
        Me.grdLinks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdLinks.Location = New System.Drawing.Point(634, 29)
        Me.grdLinks.Name = "grdLinks"
        Me.grdLinks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdLinks.RowFormatStyle.BackColor = System.Drawing.Color.LemonChiffon
        Me.grdLinks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdLinks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdLinks.Size = New System.Drawing.Size(251, 183)
        Me.grdLinks.TabIndex = 49
        Me.grdLinks.TabStop = False
        Me.grdLinks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'chkShowLinked
        '
        Me.chkShowLinked.AutoSize = True
        Me.chkShowLinked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkShowLinked.ForeColor = System.Drawing.Color.Black
        Me.chkShowLinked.Location = New System.Drawing.Point(637, 7)
        Me.chkShowLinked.Margin = New System.Windows.Forms.Padding(0)
        Me.chkShowLinked.Name = "chkShowLinked"
        Me.chkShowLinked.Size = New System.Drawing.Size(129, 17)
        Me.chkShowLinked.TabIndex = 48
        Me.chkShowLinked.TabStop = False
        Me.chkShowLinked.Text = "Set Linked Companies"
        Me.chkShowLinked.UseVisualStyleBackColor = True
        '
        'tabMarksPats
        '
        Me.tabMarksPats.Controls.Add(Me.tbMarks)
        Me.tabMarksPats.Controls.Add(Me.tbPatents)
        Me.tabMarksPats.Location = New System.Drawing.Point(20, 374)
        Me.tabMarksPats.Name = "tabMarksPats"
        Me.tabMarksPats.SelectedIndex = 0
        Me.tabMarksPats.Size = New System.Drawing.Size(967, 262)
        Me.tabMarksPats.TabIndex = 47
        '
        'tbMarks
        '
        Me.tbMarks.Controls.Add(Me.grdTrademarks)
        Me.tbMarks.Location = New System.Drawing.Point(4, 22)
        Me.tbMarks.Name = "tbMarks"
        Me.tbMarks.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMarks.Size = New System.Drawing.Size(959, 236)
        Me.tbMarks.TabIndex = 0
        Me.tbMarks.Text = "Trademarks"
        Me.tbMarks.UseVisualStyleBackColor = True
        '
        'grdTrademarks
        '
        Me.grdTrademarks.AllowCardSizing = False
        Me.grdTrademarks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarks.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdTrademarks.AlternatingColors = True
        Me.grdTrademarks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTrademarks.BackColor = System.Drawing.SystemColors.Control
        grdTrademarks_DesignTimeLayout.LayoutString = resources.GetString("grdTrademarks_DesignTimeLayout.LayoutString")
        Me.grdTrademarks.DesignTimeLayout = grdTrademarks_DesignTimeLayout
        Me.grdTrademarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTrademarks.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdTrademarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdTrademarks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdTrademarks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdTrademarks.GroupByBoxVisible = False
        Me.grdTrademarks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdTrademarks.Location = New System.Drawing.Point(3, 3)
        Me.grdTrademarks.Name = "grdTrademarks"
        Me.grdTrademarks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdTrademarks.RecordNavigator = True
        Me.grdTrademarks.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdTrademarks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdTrademarks.Size = New System.Drawing.Size(953, 230)
        Me.grdTrademarks.TabIndex = 6
        Me.grdTrademarks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdTrademarks.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'tbPatents
        '
        Me.tbPatents.Controls.Add(Me.grdPatents)
        Me.tbPatents.Location = New System.Drawing.Point(4, 22)
        Me.tbPatents.Name = "tbPatents"
        Me.tbPatents.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPatents.Size = New System.Drawing.Size(959, 236)
        Me.tbPatents.TabIndex = 1
        Me.tbPatents.Text = "Patents"
        Me.tbPatents.UseVisualStyleBackColor = True
        '
        'grdPatents
        '
        Me.grdPatents.AllowCardSizing = False
        Me.grdPatents.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatents.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPatents.AlternatingColors = True
        Me.grdPatents.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdPatents.BackColor = System.Drawing.SystemColors.Control
        grdPatents_DesignTimeLayout.LayoutString = resources.GetString("grdPatents_DesignTimeLayout.LayoutString")
        Me.grdPatents.DesignTimeLayout = grdPatents_DesignTimeLayout
        Me.grdPatents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPatents.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdPatents.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdPatents.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdPatents.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdPatents.GroupByBoxVisible = False
        Me.grdPatents.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdPatents.Location = New System.Drawing.Point(3, 3)
        Me.grdPatents.Name = "grdPatents"
        Me.grdPatents.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdPatents.RecordNavigator = True
        Me.grdPatents.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdPatents.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatents.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdPatents.Size = New System.Drawing.Size(953, 230)
        Me.grdPatents.TabIndex = 7
        Me.grdPatents.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdPatents.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'grdContacts
        '
        Me.grdContacts.AllowCardSizing = False
        Me.grdContacts.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdContacts.AlternatingColors = True
        Me.grdContacts.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdContacts.BackColor = System.Drawing.SystemColors.Control
        grdContacts_DesignTimeLayout.LayoutString = resources.GetString("grdContacts_DesignTimeLayout.LayoutString")
        Me.grdContacts.DesignTimeLayout = grdContacts_DesignTimeLayout
        Me.grdContacts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdContacts.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdContacts.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdContacts.GroupByBoxVisible = False
        Me.grdContacts.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdContacts.Location = New System.Drawing.Point(20, 250)
        Me.grdContacts.Name = "grdContacts"
        Me.grdContacts.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdContacts.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdContacts.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdContacts.Size = New System.Drawing.Size(967, 115)
        Me.grdContacts.TabIndex = 46
        Me.grdContacts.TabStop = False
        Me.grdContacts.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdFileMatters
        '
        Me.grdFileMatters.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.AllowCardSizing = False
        Me.grdFileMatters.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.AlternatingColors = True
        Me.grdFileMatters.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdFileMatters.BackColor = System.Drawing.SystemColors.Control
        grdFileMatters_DesignTimeLayout.LayoutString = resources.GetString("grdFileMatters_DesignTimeLayout.LayoutString")
        Me.grdFileMatters.DesignTimeLayout = grdFileMatters_DesignTimeLayout
        Me.grdFileMatters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdFileMatters.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdFileMatters.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdFileMatters.GroupByBoxVisible = False
        Me.grdFileMatters.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdFileMatters.Location = New System.Drawing.Point(891, 29)
        Me.grdFileMatters.Name = "grdFileMatters"
        Me.grdFileMatters.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdFileMatters.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFileMatters.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdFileMatters.Size = New System.Drawing.Size(96, 183)
        Me.grdFileMatters.TabIndex = 45
        Me.grdFileMatters.TabStop = False
        Me.grdFileMatters.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'lblRegType
        '
        Me.lblRegType.Controls.Add(Me.EntityTypeID)
        Me.lblRegType.Controls.Add(Me.WebSite)
        Me.lblRegType.Controls.Add(Me.CompanyFax)
        Me.lblRegType.Controls.Add(Me.Label13)
        Me.lblRegType.Controls.Add(Me.JurisdictionID)
        Me.lblRegType.Controls.Add(Me.CompanyPhone)
        Me.lblRegType.Controls.Add(Me.Label5)
        Me.lblRegType.Controls.Add(Me.Notes)
        Me.lblRegType.Controls.Add(Me.Label4)
        Me.lblRegType.Controls.Add(Me.btnEntityType)
        Me.lblRegType.Controls.Add(Me.btnWebSite)
        Me.lblRegType.Controls.Add(Me.btnJurisdiction)
        Me.lblRegType.Location = New System.Drawing.Point(340, 24)
        Me.lblRegType.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblRegType.Name = "lblRegType"
        Me.lblRegType.Size = New System.Drawing.Size(286, 188)
        Me.lblRegType.TabIndex = 1
        Me.lblRegType.TabStop = False
        '
        'EntityTypeID
        '
        Me.EntityTypeID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        EntityTypeID_DesignTimeLayout.LayoutString = resources.GetString("EntityTypeID_DesignTimeLayout.LayoutString")
        Me.EntityTypeID.DesignTimeLayout = EntityTypeID_DesignTimeLayout
        Me.EntityTypeID.DisplayMember = "EntityType"
        Me.EntityTypeID.Location = New System.Drawing.Point(78, 86)
        Me.EntityTypeID.Name = "EntityTypeID"
        Me.EntityTypeID.SelectedIndex = -1
        Me.EntityTypeID.SelectedItem = Nothing
        Me.EntityTypeID.Size = New System.Drawing.Size(190, 20)
        Me.EntityTypeID.TabIndex = 3
        Me.EntityTypeID.ValueMember = "EntityTypeID"
        '
        'WebSite
        '
        Me.WebSite.BackColor = System.Drawing.SystemColors.Window
        Me.WebSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WebSite.Location = New System.Drawing.Point(78, 63)
        Me.WebSite.MaxLength = 50
        Me.WebSite.Name = "WebSite"
        Me.WebSite.Size = New System.Drawing.Size(190, 20)
        Me.WebSite.TabIndex = 2
        '
        'CompanyFax
        '
        Me.CompanyFax.BackColor = System.Drawing.SystemColors.Window
        Me.CompanyFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyFax.Location = New System.Drawing.Point(78, 40)
        Me.CompanyFax.MaxLength = 25
        Me.CompanyFax.Name = "CompanyFax"
        Me.CompanyFax.Size = New System.Drawing.Size(190, 20)
        Me.CompanyFax.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Main Fax:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'JurisdictionID
        '
        Me.JurisdictionID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        JurisdictionID_DesignTimeLayout.LayoutString = resources.GetString("JurisdictionID_DesignTimeLayout.LayoutString")
        Me.JurisdictionID.DesignTimeLayout = JurisdictionID_DesignTimeLayout
        Me.JurisdictionID.DisplayMember = "Jurisdiction"
        Me.JurisdictionID.Location = New System.Drawing.Point(78, 109)
        Me.JurisdictionID.Name = "JurisdictionID"
        Me.JurisdictionID.SelectedIndex = -1
        Me.JurisdictionID.SelectedItem = Nothing
        Me.JurisdictionID.Size = New System.Drawing.Size(190, 20)
        Me.JurisdictionID.TabIndex = 4
        Me.JurisdictionID.ValueMember = "JurisdictionID"
        '
        'CompanyPhone
        '
        Me.CompanyPhone.BackColor = System.Drawing.SystemColors.Window
        Me.CompanyPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyPhone.Location = New System.Drawing.Point(78, 17)
        Me.CompanyPhone.MaxLength = 25
        Me.CompanyPhone.Name = "CompanyPhone"
        Me.CompanyPhone.Size = New System.Drawing.Size(190, 20)
        Me.CompanyPhone.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Main Phone:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Notes
        '
        Me.Notes.BackColor = System.Drawing.SystemColors.Window
        Me.Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Notes.Location = New System.Drawing.Point(78, 132)
        Me.Notes.MaxLength = 255
        Me.Notes.Multiline = True
        Me.Notes.Name = "Notes"
        Me.Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Notes.Size = New System.Drawing.Size(191, 42)
        Me.Notes.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Notes:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEntityType
        '
        Me.btnEntityType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEntityType.FlatAppearance.BorderSize = 0
        Me.btnEntityType.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnEntityType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntityType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntityType.ForeColor = System.Drawing.Color.Blue
        Me.btnEntityType.Location = New System.Drawing.Point(6, 84)
        Me.btnEntityType.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEntityType.Name = "btnEntityType"
        Me.btnEntityType.Size = New System.Drawing.Size(75, 21)
        Me.btnEntityType.TabIndex = 71
        Me.btnEntityType.TabStop = False
        Me.btnEntityType.Text = "Entity Type:"
        Me.btnEntityType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEntityType.UseVisualStyleBackColor = False
        '
        'btnWebSite
        '
        Me.btnWebSite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWebSite.FlatAppearance.BorderSize = 0
        Me.btnWebSite.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnWebSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWebSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWebSite.ForeColor = System.Drawing.Color.Blue
        Me.btnWebSite.Location = New System.Drawing.Point(13, 61)
        Me.btnWebSite.Margin = New System.Windows.Forms.Padding(0)
        Me.btnWebSite.Name = "btnWebSite"
        Me.btnWebSite.Size = New System.Drawing.Size(68, 21)
        Me.btnWebSite.TabIndex = 69
        Me.btnWebSite.TabStop = False
        Me.btnWebSite.Text = "Web Site:"
        Me.btnWebSite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnWebSite.UseVisualStyleBackColor = False
        '
        'btnJurisdiction
        '
        Me.btnJurisdiction.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnJurisdiction.FlatAppearance.BorderSize = 0
        Me.btnJurisdiction.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnJurisdiction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJurisdiction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJurisdiction.ForeColor = System.Drawing.Color.Blue
        Me.btnJurisdiction.Location = New System.Drawing.Point(6, 109)
        Me.btnJurisdiction.Margin = New System.Windows.Forms.Padding(0)
        Me.btnJurisdiction.Name = "btnJurisdiction"
        Me.btnJurisdiction.Size = New System.Drawing.Size(75, 21)
        Me.btnJurisdiction.TabIndex = 65
        Me.btnJurisdiction.TabStop = False
        Me.btnJurisdiction.Text = "Jurisdiction:"
        Me.btnJurisdiction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJurisdiction.UseVisualStyleBackColor = False
        '
        'grpCompany
        '
        Me.grpCompany.Controls.Add(Me.Country)
        Me.grpCompany.Controls.Add(Me.btnCountry)
        Me.grpCompany.Controls.Add(Me.Label10)
        Me.grpCompany.Controls.Add(Me.AddressTwo)
        Me.grpCompany.Controls.Add(Me.Label9)
        Me.grpCompany.Controls.Add(Me.AddressOne)
        Me.grpCompany.Controls.Add(Me.Label6)
        Me.grpCompany.Controls.Add(Me.CompanyName)
        Me.grpCompany.Controls.Add(Me.Label3)
        Me.grpCompany.Controls.Add(Me.Label2)
        Me.grpCompany.Controls.Add(Me.Label1)
        Me.grpCompany.Controls.Add(Me.PostalCode)
        Me.grpCompany.Controls.Add(Me.StateProvince)
        Me.grpCompany.Controls.Add(Me.City)
        Me.grpCompany.Location = New System.Drawing.Point(20, 24)
        Me.grpCompany.Name = "grpCompany"
        Me.grpCompany.Size = New System.Drawing.Size(314, 188)
        Me.grpCompany.TabIndex = 0
        Me.grpCompany.TabStop = False
        '
        'Country
        '
        Me.Country.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Country_DesignTimeLayout.LayoutString = resources.GetString("Country_DesignTimeLayout.LayoutString")
        Me.Country.DesignTimeLayout = Country_DesignTimeLayout
        Me.Country.DisplayMember = "Country"
        Me.Country.Location = New System.Drawing.Point(91, 155)
        Me.Country.Name = "Country"
        Me.Country.SelectedIndex = -1
        Me.Country.SelectedItem = Nothing
        Me.Country.Size = New System.Drawing.Size(205, 20)
        Me.Country.TabIndex = 6
        Me.Country.ValueMember = "Country"
        '
        'btnCountry
        '
        Me.btnCountry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCountry.FlatAppearance.BorderSize = 0
        Me.btnCountry.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountry.ForeColor = System.Drawing.Color.Blue
        Me.btnCountry.Location = New System.Drawing.Point(20, 153)
        Me.btnCountry.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCountry.Name = "btnCountry"
        Me.btnCountry.Size = New System.Drawing.Size(75, 21)
        Me.btnCountry.TabIndex = 70
        Me.btnCountry.TabStop = False
        Me.btnCountry.Text = "Country:"
        Me.btnCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCountry.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Address 2:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AddressTwo
        '
        Me.AddressTwo.BackColor = System.Drawing.SystemColors.Window
        Me.AddressTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddressTwo.Location = New System.Drawing.Point(91, 63)
        Me.AddressTwo.MaxLength = 50
        Me.AddressTwo.Name = "AddressTwo"
        Me.AddressTwo.Size = New System.Drawing.Size(205, 20)
        Me.AddressTwo.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Address 1:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AddressOne
        '
        Me.AddressOne.BackColor = System.Drawing.SystemColors.Window
        Me.AddressOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddressOne.Location = New System.Drawing.Point(91, 40)
        Me.AddressOne.MaxLength = 50
        Me.AddressOne.Name = "AddressOne"
        Me.AddressOne.Size = New System.Drawing.Size(205, 20)
        Me.AddressOne.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Company:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CompanyName
        '
        Me.CompanyName.BackColor = System.Drawing.SystemColors.Window
        Me.CompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyName.Location = New System.Drawing.Point(91, 17)
        Me.CompanyName.MaxLength = 100
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Size = New System.Drawing.Size(205, 20)
        Me.CompanyName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Zip/Postal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "State/Province:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "City:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PostalCode
        '
        Me.PostalCode.BackColor = System.Drawing.SystemColors.Window
        Me.PostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PostalCode.Location = New System.Drawing.Point(91, 132)
        Me.PostalCode.MaxLength = 20
        Me.PostalCode.Name = "PostalCode"
        Me.PostalCode.Size = New System.Drawing.Size(205, 20)
        Me.PostalCode.TabIndex = 5
        '
        'StateProvince
        '
        Me.StateProvince.BackColor = System.Drawing.SystemColors.Window
        Me.StateProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StateProvince.Location = New System.Drawing.Point(91, 109)
        Me.StateProvince.MaxLength = 50
        Me.StateProvince.Name = "StateProvince"
        Me.StateProvince.Size = New System.Drawing.Size(205, 20)
        Me.StateProvince.TabIndex = 4
        '
        'City
        '
        Me.City.BackColor = System.Drawing.SystemColors.Window
        Me.City.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.City.Location = New System.Drawing.Point(91, 86)
        Me.City.MaxLength = 50
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(205, 20)
        Me.City.TabIndex = 3
        '
        'pnlContacts
        '
        Me.pnlContacts.BackColor = System.Drawing.SystemColors.Control
        Me.pnlContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlContacts.Controls.Add(Me.btnGetFromOutlook)
        Me.pnlContacts.Controls.Add(Me.btnImportContact)
        Me.pnlContacts.Controls.Add(Me.btnNewContact)
        Me.pnlContacts.ForeColor = System.Drawing.Color.Black
        Me.pnlContacts.Location = New System.Drawing.Point(20, 218)
        Me.pnlContacts.Name = "pnlContacts"
        Me.pnlContacts.Size = New System.Drawing.Size(967, 32)
        Me.pnlContacts.TabIndex = 37
        '
        'btnGetFromOutlook
        '
        Me.btnGetFromOutlook.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnGetFromOutlook.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetFromOutlook.Image = CType(resources.GetObject("btnGetFromOutlook.Image"), System.Drawing.Image)
        Me.btnGetFromOutlook.Location = New System.Drawing.Point(260, 4)
        Me.btnGetFromOutlook.Name = "btnGetFromOutlook"
        Me.btnGetFromOutlook.Size = New System.Drawing.Size(120, 20)
        Me.btnGetFromOutlook.TabIndex = 48
        Me.btnGetFromOutlook.TabStop = False
        Me.btnGetFromOutlook.Text = "Import From Outlook"
        Me.btnGetFromOutlook.UseThemes = False
        '
        'btnImportContact
        '
        Me.btnImportContact.BackColor = System.Drawing.SystemColors.Control
        Me.btnImportContact.FlatAppearance.BorderSize = 0
        Me.btnImportContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportContact.Image = CType(resources.GetObject("btnImportContact.Image"), System.Drawing.Image)
        Me.btnImportContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportContact.Location = New System.Drawing.Point(114, 1)
        Me.btnImportContact.Name = "btnImportContact"
        Me.btnImportContact.Size = New System.Drawing.Size(135, 23)
        Me.btnImportContact.TabIndex = 47
        Me.btnImportContact.TabStop = False
        Me.btnImportContact.Text = "Import From Company"
        Me.btnImportContact.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportContact.UseVisualStyleBackColor = False
        '
        'btnNewContact
        '
        Me.btnNewContact.BackColor = System.Drawing.SystemColors.Control
        Me.btnNewContact.FlatAppearance.BorderSize = 0
        Me.btnNewContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewContact.Image = CType(resources.GetObject("btnNewContact.Image"), System.Drawing.Image)
        Me.btnNewContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewContact.Location = New System.Drawing.Point(9, 1)
        Me.btnNewContact.Name = "btnNewContact"
        Me.btnNewContact.Size = New System.Drawing.Size(100, 23)
        Me.btnNewContact.TabIndex = 46
        Me.btnNewContact.TabStop = False
        Me.btnNewContact.Text = "New Contact"
        Me.btnNewContact.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNewContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewContact.UseVisualStyleBackColor = False
        '
        'frmCompanies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1016, 742)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.pnlSeparator)
        Me.Controls.Add(Me.tlsTrademarks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCompanies"
        Me.Text = "Companies/Contacts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlsTrademarks.ResumeLayout(False)
        Me.tlsTrademarks.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.tbList.ResumeLayout(False)
        CType(Me.grdCompanyList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListBottom.ResumeLayout(False)
        Me.grpViewBy.ResumeLayout(False)
        Me.grpViewBy.PerformLayout()
        Me.grpListButtons.ResumeLayout(False)
        Me.tbCompany.ResumeLayout(False)
        Me.tbCompany.PerformLayout()
        CType(Me.grdLinks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMarksPats.ResumeLayout(False)
        Me.tbMarks.ResumeLayout(False)
        CType(Me.grdTrademarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPatents.ResumeLayout(False)
        CType(Me.grdPatents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFileMatters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lblRegType.ResumeLayout(False)
        Me.lblRegType.PerformLayout()
        CType(Me.EntityTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JurisdictionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCompany.ResumeLayout(False)
        Me.grpCompany.PerformLayout()
        CType(Me.Country, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContacts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsTrademarks As System.Windows.Forms.ToolStrip
    Friend WithEvents btnFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblGoTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnGoTrademarks As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGoToPatents As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGoToContacts As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReports As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPreferences As System.Windows.Forms.ToolStripButton
    Friend WithEvents sepDemo As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDemo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents pnlSeparator As System.Windows.Forms.Panel
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents tbList As System.Windows.Forms.TabPage
    Friend WithEvents grdCompanyList As Janus.Windows.GridEX.GridEX
    Friend WithEvents pnlBrowse As System.Windows.Forms.Panel
    Friend WithEvents pnlListBottom As System.Windows.Forms.Panel
    Friend WithEvents grpListButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewCompany As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnClearFilters As Janus.Windows.EditControls.UIButton
    Friend WithEvents tbCompany As System.Windows.Forms.TabPage
    Friend WithEvents lblRegType As System.Windows.Forms.GroupBox
    Friend WithEvents grpCompany As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CompanyPhone As System.Windows.Forms.TextBox
    Friend WithEvents Notes As System.Windows.Forms.TextBox
    Friend WithEvents PostalCode As System.Windows.Forms.TextBox
    Friend WithEvents StateProvince As System.Windows.Forms.TextBox
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents pnlContacts As System.Windows.Forms.Panel
    Friend WithEvents grdFileMatters As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents AddressTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AddressOne As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CompanyName As System.Windows.Forms.TextBox
    Friend WithEvents JurisdictionID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnJurisdiction As System.Windows.Forms.Button
    Friend WithEvents Country As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCountry As System.Windows.Forms.Button
    Friend WithEvents EntityTypeID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnEntityType As System.Windows.Forms.Button
    Friend WithEvents btnWebSite As System.Windows.Forms.Button
    Friend WithEvents WebSite As System.Windows.Forms.TextBox
    Friend WithEvents CompanyFax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grdContacts As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnNewContact As System.Windows.Forms.Button
    Friend WithEvents btnImportContact As System.Windows.Forms.Button
    Friend WithEvents tabMarksPats As System.Windows.Forms.TabControl
    Friend WithEvents tbMarks As System.Windows.Forms.TabPage
    Friend WithEvents tbPatents As System.Windows.Forms.TabPage
    Friend WithEvents grdPatents As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpViewBy As System.Windows.Forms.GroupBox
    Friend WithEvents optContacts As System.Windows.Forms.RadioButton
    Friend WithEvents optCompanies As System.Windows.Forms.RadioButton
    Friend WithEvents grdTrademarks As Janus.Windows.GridEX.GridEX
    Friend WithEvents chkShowLinked As System.Windows.Forms.CheckBox
    Friend WithEvents grdLinks As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tutOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutSortFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCompanies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCreateCompany As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutLinkCompanies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutImportContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkRecords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutSetContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutWebLinks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutDateTemplates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkTemplates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPatentOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutAlertsView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutWordMerge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutOutlook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutAlertEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutDateEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutEmailTexts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkTreaties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPatentTreaties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutLinkedPatents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGetFromOutlook As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPrintAllContacts As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkLinkedOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnGoToOppositions As System.Windows.Forms.ToolStripButton
    Friend WithEvents tutWhatsNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCustomSpreadsheets As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutOppositions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutStatusCheck As System.Windows.Forms.ToolStripMenuItem
End Class
