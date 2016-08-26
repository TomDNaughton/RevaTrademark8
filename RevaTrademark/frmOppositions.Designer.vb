<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOppositions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOppositions))
        Dim grdAlerts_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim cboSetContact_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cboSetPosition_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdOppositionMarks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdClientMarks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdDocumentLinks_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdDates_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdDates_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.Image")
        Dim grdDates_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.Image")
        Dim grdActions_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim StatusID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim CompanyID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim OpposingCompanyID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim JurisdictionID_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdContacts_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTrademarkJurisDates_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTrademarkJurisDates_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.Image")
        Dim grdTrademarkJurisDates_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.Image")
        Dim grdTrademarkMasterDates_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTrademarkMasterDates_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.Image")
        Dim grdTrademarkMasterDates_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.Image")
        Dim cboMarkJurisdiction_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.tlsTrademarks = New System.Windows.Forms.ToolStrip
        Me.btnFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnConnection = New System.Windows.Forms.ToolStripMenuItem
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnHelp = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Tutorials = New System.Windows.Forms.ToolStripTextBox
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
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrevRecord = New System.Windows.Forms.ToolStripButton
        Me.RecordCount = New System.Windows.Forms.ToolStripTextBox
        Me.btnNextRecord = New System.Windows.Forms.ToolStripButton
        Me.sepDemo = New System.Windows.Forms.ToolStripSeparator
        Me.lblDemo = New System.Windows.Forms.ToolStripLabel
        Me.pnlSeparator = New System.Windows.Forms.Panel
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.tbList = New System.Windows.Forms.TabPage
        Me.grdAlerts = New Janus.Windows.GridEX.GridEX
        Me.grdList = New Janus.Windows.GridEX.GridEX
        Me.pnlBrowse = New System.Windows.Forms.Panel
        Me.grpSetContact = New System.Windows.Forms.GroupBox
        Me.cboStart = New Janus.Windows.EditControls.UIComboBox
        Me.cboEnd = New Janus.Windows.EditControls.UIComboBox
        Me.BetweenStart = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.BetweenEnd = New System.Windows.Forms.TextBox
        Me.cboSetContact = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboSetPosition = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.pnlListBottom = New System.Windows.Forms.Panel
        Me.grpListButtons = New System.Windows.Forms.GroupBox
        Me.btnNewOpposition = New Janus.Windows.EditControls.UIButton
        Me.btnPrintList = New Janus.Windows.EditControls.UIButton
        Me.btnClearFilters = New Janus.Windows.EditControls.UIButton
        Me.btnPrintRecords = New Janus.Windows.EditControls.UIButton
        Me.grpAlerts = New System.Windows.Forms.GroupBox
        Me.LeadDays = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnAddToOutlook = New Janus.Windows.EditControls.UIButton
        Me.grpViewBy = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New Janus.Windows.EditControls.UIButton
        Me.optEmailAlerts = New System.Windows.Forms.RadioButton
        Me.optAlerts = New System.Windows.Forms.RadioButton
        Me.optList = New System.Windows.Forms.RadioButton
        Me.tbOpposition = New System.Windows.Forms.TabPage
        Me.grdOppositionMarks = New Janus.Windows.GridEX.GridEX
        Me.grdClientMarks = New Janus.Windows.GridEX.GridEX
        Me.grdDocumentLinks = New Janus.Windows.GridEX.GridEX
        Me.grdDates = New Janus.Windows.GridEX.GridEX
        Me.grdActions = New Janus.Windows.GridEX.GridEX
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.optDocumentLinks = New System.Windows.Forms.RadioButton
        Me.btnPrintActions = New Janus.Windows.EditControls.UIButton
        Me.chkReOrder = New System.Windows.Forms.CheckBox
        Me.optLitigationActions = New System.Windows.Forms.RadioButton
        Me.optLitigationDates = New System.Windows.Forms.RadioButton
        Me.btnDatesFromTemplate = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.optOppositionMarks = New System.Windows.Forms.RadioButton
        Me.btnPrintOne = New Janus.Windows.EditControls.UIButton
        Me.optClientMarks = New System.Windows.Forms.RadioButton
        Me.optClientAndOpposition = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.OppositionName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.OppositionNotes = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.optDefendant = New System.Windows.Forms.RadioButton
        Me.optPlaintiff = New System.Windows.Forms.RadioButton
        Me.StatusID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnStatus = New System.Windows.Forms.Button
        Me.CompanyID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnCompany = New System.Windows.Forms.Button
        Me.OpposingCompanyID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnOpposingCompany = New System.Windows.Forms.Button
        Me.ProceedingNumber = New System.Windows.Forms.TextBox
        Me.btnProceeding = New System.Windows.Forms.Button
        Me.JurisdictionID = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label5 = New System.Windows.Forms.Label
        Me.grdContacts = New Janus.Windows.GridEX.GridEX
        Me.tbPreferences = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkOrderDates = New System.Windows.Forms.CheckBox
        Me.grdTrademarkJurisDates = New Janus.Windows.GridEX.GridEX
        Me.grdTrademarkMasterDates = New Janus.Windows.GridEX.GridEX
        Me.btnAddTrademarkDates = New Janus.Windows.EditControls.UIButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboMarkJurisdiction = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.Label29 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.tlsTrademarks.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.tbList.SuspendLayout()
        CType(Me.grdAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrowse.SuspendLayout()
        Me.grpSetContact.SuspendLayout()
        CType(Me.cboSetContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSetPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListBottom.SuspendLayout()
        Me.grpListButtons.SuspendLayout()
        Me.grpAlerts.SuspendLayout()
        Me.grpViewBy.SuspendLayout()
        Me.tbOpposition.SuspendLayout()
        CType(Me.grdOppositionMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClientMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDocumentLinks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.StatusID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpposingCompanyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JurisdictionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPreferences.SuspendLayout()
        CType(Me.grdTrademarkJurisDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTrademarkMasterDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMarkJurisdiction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsTrademarks
        '
        Me.tlsTrademarks.BackColor = System.Drawing.SystemColors.Control
        Me.tlsTrademarks.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFile, Me.btnHelp, Me.ToolStripSeparator1, Me.lblGoTo, Me.btnGoTrademarks, Me.btnGoToPatents, Me.btnGoToOppositions, Me.btnGoToContacts, Me.btnReports, Me.btnPreferences, Me.ToolStripSeparator3, Me.btnPrevRecord, Me.RecordCount, Me.btnNextRecord, Me.sepDemo, Me.lblDemo})
        Me.tlsTrademarks.Location = New System.Drawing.Point(0, 0)
        Me.tlsTrademarks.Name = "tlsTrademarks"
        Me.tlsTrademarks.Size = New System.Drawing.Size(1016, 25)
        Me.tlsTrademarks.TabIndex = 0
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
        Me.btnHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbout, Me.ToolStripSeparator2, Me.Tutorials, Me.tutWhatsNew, Me.tutOverview, Me.tutPreferences, Me.tutSortFind, Me.tutCompanies, Me.tutTrademarkRecords, Me.tutSetContacts, Me.tutWebLinks, Me.tutDateTemplates, Me.tutAlertsView, Me.tutWordMerge, Me.tutOutlook, Me.tutTrademarkTreaties, Me.tutStatusCheck, Me.tutPatentTreaties, Me.tutLinkedPatents, Me.tutReports, Me.tutCustomSpreadsheets, Me.tutOppositions})
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(268, 6)
        '
        'Tutorials
        '
        Me.Tutorials.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Tutorials.Name = "Tutorials"
        Me.Tutorials.Size = New System.Drawing.Size(100, 21)
        Me.Tutorials.Text = "Tutorials:"
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
        Me.btnGoToOppositions.ForeColor = System.Drawing.Color.Red
        Me.btnGoToOppositions.Image = CType(resources.GetObject("btnGoToOppositions.Image"), System.Drawing.Image)
        Me.btnGoToOppositions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGoToOppositions.Name = "btnGoToOppositions"
        Me.btnGoToOppositions.Size = New System.Drawing.Size(75, 22)
        Me.btnGoToOppositions.Text = "Oppositions"
        '
        'btnGoToContacts
        '
        Me.btnGoToContacts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrevRecord
        '
        Me.btnPrevRecord.Enabled = False
        Me.btnPrevRecord.Image = CType(resources.GetObject("btnPrevRecord.Image"), System.Drawing.Image)
        Me.btnPrevRecord.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrevRecord.Name = "btnPrevRecord"
        Me.btnPrevRecord.Size = New System.Drawing.Size(72, 22)
        Me.btnPrevRecord.Text = "Previous"
        '
        'RecordCount
        '
        Me.RecordCount.BackColor = System.Drawing.Color.White
        Me.RecordCount.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.RecordCount.Name = "RecordCount"
        Me.RecordCount.ReadOnly = True
        Me.RecordCount.Size = New System.Drawing.Size(100, 25)
        Me.RecordCount.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNextRecord
        '
        Me.btnNextRecord.Enabled = False
        Me.btnNextRecord.Image = CType(resources.GetObject("btnNextRecord.Image"), System.Drawing.Image)
        Me.btnNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNextRecord.Name = "btnNextRecord"
        Me.btnNextRecord.Size = New System.Drawing.Size(51, 22)
        Me.btnNextRecord.Text = "Next"
        Me.btnNextRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
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
        Me.pnlSeparator.TabIndex = 1
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.tbList)
        Me.Tabs.Controls.Add(Me.tbOpposition)
        Me.Tabs.Controls.Add(Me.tbPreferences)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 38)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1016, 703)
        Me.Tabs.TabIndex = 0
        '
        'tbList
        '
        Me.tbList.AutoScroll = True
        Me.tbList.BackColor = System.Drawing.SystemColors.Control
        Me.tbList.Controls.Add(Me.grdAlerts)
        Me.tbList.Controls.Add(Me.grdList)
        Me.tbList.Controls.Add(Me.pnlBrowse)
        Me.tbList.Controls.Add(Me.pnlListBottom)
        Me.tbList.Location = New System.Drawing.Point(4, 22)
        Me.tbList.Name = "tbList"
        Me.tbList.Padding = New System.Windows.Forms.Padding(3)
        Me.tbList.Size = New System.Drawing.Size(1008, 677)
        Me.tbList.TabIndex = 0
        Me.tbList.Text = "Oppositions List"
        '
        'grdAlerts
        '
        Me.grdAlerts.AllowCardSizing = False
        Me.grdAlerts.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdAlerts.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdAlerts.AlternatingColors = True
        Me.grdAlerts.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdAlerts.BackColor = System.Drawing.SystemColors.Control
        Me.grdAlerts.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        grdAlerts_DesignTimeLayout.LayoutString = resources.GetString("grdAlerts_DesignTimeLayout.LayoutString")
        Me.grdAlerts.DesignTimeLayout = grdAlerts_DesignTimeLayout
        Me.grdAlerts.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdAlerts.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdAlerts.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdAlerts.GroupByBoxVisible = False
        Me.grdAlerts.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.grdAlerts.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdAlerts.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdAlerts.Hierarchical = True
        Me.grdAlerts.Location = New System.Drawing.Point(0, 364)
        Me.grdAlerts.Name = "grdAlerts"
        Me.grdAlerts.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdAlerts.RecordNavigator = True
        Me.grdAlerts.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdAlerts.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdAlerts.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdAlerts.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdAlerts.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdAlerts.Size = New System.Drawing.Size(1008, 215)
        Me.grdAlerts.TabIndex = 44
        Me.grdAlerts.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdAlerts.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'grdList
        '
        Me.grdList.AllowCardSizing = False
        Me.grdList.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdList.AlternatingColors = True
        Me.grdList.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdList.BackColor = System.Drawing.SystemColors.Control
        Me.grdList.CellToolTip = Janus.Windows.GridEX.CellToolTip.TruncatedText
        grdList_DesignTimeLayout.LayoutString = resources.GetString("grdList_DesignTimeLayout.LayoutString")
        Me.grdList.DesignTimeLayout = grdList_DesignTimeLayout
        Me.grdList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdList.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdList.GroupByBoxVisible = False
        Me.grdList.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdList.Location = New System.Drawing.Point(3, 87)
        Me.grdList.Name = "grdList"
        Me.grdList.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdList.RecordNavigator = True
        Me.grdList.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdList.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdList.Size = New System.Drawing.Size(1002, 251)
        Me.grdList.TabIndex = 5
        Me.grdList.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        Me.grdList.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'pnlBrowse
        '
        Me.pnlBrowse.Controls.Add(Me.grpSetContact)
        Me.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrowse.Location = New System.Drawing.Point(3, 3)
        Me.pnlBrowse.Name = "pnlBrowse"
        Me.pnlBrowse.Size = New System.Drawing.Size(1002, 42)
        Me.pnlBrowse.TabIndex = 4
        '
        'grpSetContact
        '
        Me.grpSetContact.Controls.Add(Me.cboStart)
        Me.grpSetContact.Controls.Add(Me.cboEnd)
        Me.grpSetContact.Controls.Add(Me.BetweenStart)
        Me.grpSetContact.Controls.Add(Me.Label14)
        Me.grpSetContact.Controls.Add(Me.Label13)
        Me.grpSetContact.Controls.Add(Me.BetweenEnd)
        Me.grpSetContact.Controls.Add(Me.cboSetContact)
        Me.grpSetContact.Controls.Add(Me.Label18)
        Me.grpSetContact.Controls.Add(Me.Label19)
        Me.grpSetContact.Controls.Add(Me.cboSetPosition)
        Me.grpSetContact.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSetContact.Location = New System.Drawing.Point(0, 0)
        Me.grpSetContact.Name = "grpSetContact"
        Me.grpSetContact.Size = New System.Drawing.Size(1002, 38)
        Me.grpSetContact.TabIndex = 0
        Me.grpSetContact.TabStop = False
        '
        'cboStart
        '
        Me.cboStart.BorderStyle = Janus.Windows.UI.BorderStyle.Flat
        Me.cboStart.FlatBorderColor = System.Drawing.Color.Black
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Three Months Ago"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Two Months Ago"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "One Month Ago"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "One Week Ago"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Today"
        Me.cboStart.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5})
        Me.cboStart.Location = New System.Drawing.Point(214, 12)
        Me.cboStart.Name = "cboStart"
        Me.cboStart.Size = New System.Drawing.Size(19, 20)
        Me.cboStart.TabIndex = 22
        Me.cboStart.TabStop = False
        Me.cboStart.Text = "UiComboBox1"
        Me.cboStart.UseThemes = False
        '
        'cboEnd
        '
        Me.cboEnd.BorderStyle = Janus.Windows.UI.BorderStyle.Flat
        Me.cboEnd.FlatBorderColor = System.Drawing.Color.Black
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "One Week From Today"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "One Month From Today"
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "Two Months From Today"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "Three Months From Today"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "Six Months From Today"
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "One Year From Today"
        Me.cboEnd.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11})
        Me.cboEnd.Location = New System.Drawing.Point(412, 12)
        Me.cboEnd.Name = "cboEnd"
        Me.cboEnd.Size = New System.Drawing.Size(19, 20)
        Me.cboEnd.TabIndex = 21
        Me.cboEnd.TabStop = False
        Me.cboEnd.Text = "UiComboBox1"
        Me.cboEnd.UseThemes = False
        '
        'BetweenStart
        '
        Me.BetweenStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BetweenStart.Location = New System.Drawing.Point(232, 12)
        Me.BetweenStart.Name = "BetweenStart"
        Me.BetweenStart.Size = New System.Drawing.Size(78, 20)
        Me.BetweenStart.TabIndex = 17
        Me.BetweenStart.TabStop = False
        Me.BetweenStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(316, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "to:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(112, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Show Dates From:"
        '
        'BetweenEnd
        '
        Me.BetweenEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BetweenEnd.Location = New System.Drawing.Point(335, 12)
        Me.BetweenEnd.Name = "BetweenEnd"
        Me.BetweenEnd.Size = New System.Drawing.Size(78, 20)
        Me.BetweenEnd.TabIndex = 18
        Me.BetweenEnd.TabStop = False
        Me.BetweenEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboSetContact
        '
        Me.cboSetContact.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cboSetContact.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        cboSetContact_DesignTimeLayout.LayoutString = resources.GetString("cboSetContact_DesignTimeLayout.LayoutString")
        Me.cboSetContact.DesignTimeLayout = cboSetContact_DesignTimeLayout
        Me.cboSetContact.DisplayMember = "ContactName"
        Me.cboSetContact.Location = New System.Drawing.Point(829, 11)
        Me.cboSetContact.Name = "cboSetContact"
        Me.cboSetContact.SelectedIndex = -1
        Me.cboSetContact.SelectedItem = Nothing
        Me.cboSetContact.Size = New System.Drawing.Size(167, 20)
        Me.cboSetContact.TabIndex = 15
        Me.cboSetContact.TabStop = False
        Me.cboSetContact.ValueMember = "ContactID"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(781, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Contact:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(565, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Position:"
        '
        'cboSetPosition
        '
        Me.cboSetPosition.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cboSetPosition.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        cboSetPosition_DesignTimeLayout.LayoutString = resources.GetString("cboSetPosition_DesignTimeLayout.LayoutString")
        Me.cboSetPosition.DesignTimeLayout = cboSetPosition_DesignTimeLayout
        Me.cboSetPosition.DisplayMember = "PositionName"
        Me.cboSetPosition.Location = New System.Drawing.Point(613, 11)
        Me.cboSetPosition.Name = "cboSetPosition"
        Me.cboSetPosition.SelectedIndex = -1
        Me.cboSetPosition.SelectedItem = Nothing
        Me.cboSetPosition.Size = New System.Drawing.Size(162, 20)
        Me.cboSetPosition.TabIndex = 12
        Me.cboSetPosition.TabStop = False
        Me.cboSetPosition.ValueMember = "PositionID"
        '
        'pnlListBottom
        '
        Me.pnlListBottom.Controls.Add(Me.grpListButtons)
        Me.pnlListBottom.Controls.Add(Me.grpAlerts)
        Me.pnlListBottom.Controls.Add(Me.grpViewBy)
        Me.pnlListBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlListBottom.Location = New System.Drawing.Point(3, 588)
        Me.pnlListBottom.Name = "pnlListBottom"
        Me.pnlListBottom.Size = New System.Drawing.Size(1002, 86)
        Me.pnlListBottom.TabIndex = 3
        '
        'grpListButtons
        '
        Me.grpListButtons.Controls.Add(Me.btnNewOpposition)
        Me.grpListButtons.Controls.Add(Me.btnPrintList)
        Me.grpListButtons.Controls.Add(Me.btnClearFilters)
        Me.grpListButtons.Controls.Add(Me.btnPrintRecords)
        Me.grpListButtons.Location = New System.Drawing.Point(356, 10)
        Me.grpListButtons.Name = "grpListButtons"
        Me.grpListButtons.Size = New System.Drawing.Size(373, 43)
        Me.grpListButtons.TabIndex = 51
        Me.grpListButtons.TabStop = False
        '
        'btnNewOpposition
        '
        Me.btnNewOpposition.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnNewOpposition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewOpposition.Image = CType(resources.GetObject("btnNewOpposition.Image"), System.Drawing.Image)
        Me.btnNewOpposition.Location = New System.Drawing.Point(22, 15)
        Me.btnNewOpposition.Name = "btnNewOpposition"
        Me.btnNewOpposition.ShowFocusRectangle = False
        Me.btnNewOpposition.Size = New System.Drawing.Size(100, 20)
        Me.btnNewOpposition.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnNewOpposition.TabIndex = 46
        Me.btnNewOpposition.Text = "New Opposition"
        Me.btnNewOpposition.UseThemes = False
        '
        'btnPrintList
        '
        Me.btnPrintList.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnPrintList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintList.Image = CType(resources.GetObject("btnPrintList.Image"), System.Drawing.Image)
        Me.btnPrintList.Location = New System.Drawing.Point(227, 15)
        Me.btnPrintList.Name = "btnPrintList"
        Me.btnPrintList.ShowFocusRectangle = False
        Me.btnPrintList.Size = New System.Drawing.Size(136, 20)
        Me.btnPrintList.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnPrintList.TabIndex = 45
        Me.btnPrintList.TabStop = False
        Me.btnPrintList.Text = "Print Opposition Alerts"
        Me.btnPrintList.UseThemes = False
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnClearFilters.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilters.Image = CType(resources.GetObject("btnClearFilters.Image"), System.Drawing.Image)
        Me.btnClearFilters.Location = New System.Drawing.Point(135, 15)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.ShowFocusRectangle = False
        Me.btnClearFilters.Size = New System.Drawing.Size(84, 20)
        Me.btnClearFilters.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnClearFilters.TabIndex = 16
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.UseThemes = False
        '
        'btnPrintRecords
        '
        Me.btnPrintRecords.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnPrintRecords.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintRecords.Image = CType(resources.GetObject("btnPrintRecords.Image"), System.Drawing.Image)
        Me.btnPrintRecords.Location = New System.Drawing.Point(16, 15)
        Me.btnPrintRecords.Name = "btnPrintRecords"
        Me.btnPrintRecords.ShowFocusRectangle = False
        Me.btnPrintRecords.Size = New System.Drawing.Size(104, 20)
        Me.btnPrintRecords.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnPrintRecords.TabIndex = 47
        Me.btnPrintRecords.TabStop = False
        Me.btnPrintRecords.Text = "Print Oppositions"
        Me.btnPrintRecords.UseThemes = False
        Me.btnPrintRecords.Visible = False
        '
        'grpAlerts
        '
        Me.grpAlerts.Controls.Add(Me.LeadDays)
        Me.grpAlerts.Controls.Add(Me.Label17)
        Me.grpAlerts.Controls.Add(Me.btnAddToOutlook)
        Me.grpAlerts.Enabled = False
        Me.grpAlerts.Location = New System.Drawing.Point(733, 10)
        Me.grpAlerts.Name = "grpAlerts"
        Me.grpAlerts.Size = New System.Drawing.Size(239, 43)
        Me.grpAlerts.TabIndex = 50
        Me.grpAlerts.TabStop = False
        '
        'LeadDays
        '
        Me.LeadDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LeadDays.Location = New System.Drawing.Point(207, 16)
        Me.LeadDays.Name = "LeadDays"
        Me.LeadDays.Size = New System.Drawing.Size(25, 20)
        Me.LeadDays.TabIndex = 48
        Me.LeadDays.Text = "0"
        Me.LeadDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(113, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 14)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Lead Time (Days):"
        '
        'btnAddToOutlook
        '
        Me.btnAddToOutlook.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnAddToOutlook.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToOutlook.Image = CType(resources.GetObject("btnAddToOutlook.Image"), System.Drawing.Image)
        Me.btnAddToOutlook.Location = New System.Drawing.Point(8, 15)
        Me.btnAddToOutlook.Name = "btnAddToOutlook"
        Me.btnAddToOutlook.ShowFocusRectangle = False
        Me.btnAddToOutlook.Size = New System.Drawing.Size(106, 20)
        Me.btnAddToOutlook.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnAddToOutlook.TabIndex = 46
        Me.btnAddToOutlook.TabStop = False
        Me.btnAddToOutlook.Text = "Add to Outlook"
        Me.btnAddToOutlook.UseThemes = False
        '
        'grpViewBy
        '
        Me.grpViewBy.Controls.Add(Me.btnRefresh)
        Me.grpViewBy.Controls.Add(Me.optEmailAlerts)
        Me.grpViewBy.Controls.Add(Me.optAlerts)
        Me.grpViewBy.Controls.Add(Me.optList)
        Me.grpViewBy.Location = New System.Drawing.Point(15, 10)
        Me.grpViewBy.Name = "grpViewBy"
        Me.grpViewBy.Size = New System.Drawing.Size(337, 43)
        Me.grpViewBy.TabIndex = 49
        Me.grpViewBy.TabStop = False
        Me.grpViewBy.Text = "Select View:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnRefresh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(257, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.ShowFocusRectangle = False
        Me.btnRefresh.Size = New System.Drawing.Size(68, 20)
        Me.btnRefresh.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseThemes = False
        '
        'optEmailAlerts
        '
        Me.optEmailAlerts.AutoSize = True
        Me.optEmailAlerts.Location = New System.Drawing.Point(169, 17)
        Me.optEmailAlerts.Name = "optEmailAlerts"
        Me.optEmailAlerts.Size = New System.Drawing.Size(79, 17)
        Me.optEmailAlerts.TabIndex = 3
        Me.optEmailAlerts.Text = "Email Alerts"
        Me.optEmailAlerts.UseVisualStyleBackColor = True
        '
        'optAlerts
        '
        Me.optAlerts.AutoSize = True
        Me.optAlerts.Location = New System.Drawing.Point(116, 17)
        Me.optAlerts.Name = "optAlerts"
        Me.optAlerts.Size = New System.Drawing.Size(51, 17)
        Me.optAlerts.TabIndex = 1
        Me.optAlerts.Text = "Alerts"
        Me.optAlerts.UseVisualStyleBackColor = True
        '
        'optList
        '
        Me.optList.AutoSize = True
        Me.optList.Checked = True
        Me.optList.Location = New System.Drawing.Point(11, 17)
        Me.optList.Name = "optList"
        Me.optList.Size = New System.Drawing.Size(99, 17)
        Me.optList.TabIndex = 0
        Me.optList.TabStop = True
        Me.optList.Text = "Oppositions List"
        Me.optList.UseVisualStyleBackColor = True
        '
        'tbOpposition
        '
        Me.tbOpposition.AutoScroll = True
        Me.tbOpposition.BackColor = System.Drawing.SystemColors.Control
        Me.tbOpposition.Controls.Add(Me.grdOppositionMarks)
        Me.tbOpposition.Controls.Add(Me.grdClientMarks)
        Me.tbOpposition.Controls.Add(Me.grdDocumentLinks)
        Me.tbOpposition.Controls.Add(Me.grdDates)
        Me.tbOpposition.Controls.Add(Me.grdActions)
        Me.tbOpposition.Controls.Add(Me.GroupBox6)
        Me.tbOpposition.Controls.Add(Me.GroupBox1)
        Me.tbOpposition.Controls.Add(Me.GroupBox2)
        Me.tbOpposition.Controls.Add(Me.grdContacts)
        Me.tbOpposition.Location = New System.Drawing.Point(4, 22)
        Me.tbOpposition.Name = "tbOpposition"
        Me.tbOpposition.Padding = New System.Windows.Forms.Padding(3)
        Me.tbOpposition.Size = New System.Drawing.Size(1008, 677)
        Me.tbOpposition.TabIndex = 1
        Me.tbOpposition.Text = "Opposition Details"
        '
        'grdOppositionMarks
        '
        Me.grdOppositionMarks.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdOppositionMarks.AllowCardSizing = False
        Me.grdOppositionMarks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdOppositionMarks.AlternatingColors = True
        Me.grdOppositionMarks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.grdOppositionMarks.BackColor = System.Drawing.SystemColors.Control
        grdOppositionMarks_DesignTimeLayout.LayoutString = resources.GetString("grdOppositionMarks_DesignTimeLayout.LayoutString")
        Me.grdOppositionMarks.DesignTimeLayout = grdOppositionMarks_DesignTimeLayout
        Me.grdOppositionMarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdOppositionMarks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdOppositionMarks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdOppositionMarks.GroupByBoxVisible = False
        Me.grdOppositionMarks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdOppositionMarks.Location = New System.Drawing.Point(491, 138)
        Me.grdOppositionMarks.Name = "grdOppositionMarks"
        Me.grdOppositionMarks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdOppositionMarks.RowFormatStyle.BackColor = System.Drawing.Color.LemonChiffon
        Me.grdOppositionMarks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdOppositionMarks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdOppositionMarks.Size = New System.Drawing.Size(474, 96)
        Me.grdOppositionMarks.TabIndex = 73
        Me.grdOppositionMarks.TabStop = False
        Me.grdOppositionMarks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdClientMarks
        '
        Me.grdClientMarks.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdClientMarks.AllowCardSizing = False
        Me.grdClientMarks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdClientMarks.AlternatingColors = True
        Me.grdClientMarks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdClientMarks.BackColor = System.Drawing.SystemColors.Control
        grdClientMarks_DesignTimeLayout.LayoutString = resources.GetString("grdClientMarks_DesignTimeLayout.LayoutString")
        Me.grdClientMarks.DesignTimeLayout = grdClientMarks_DesignTimeLayout
        Me.grdClientMarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdClientMarks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdClientMarks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdClientMarks.GroupByBoxVisible = False
        Me.grdClientMarks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdClientMarks.Location = New System.Drawing.Point(40, 138)
        Me.grdClientMarks.Name = "grdClientMarks"
        Me.grdClientMarks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdClientMarks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdClientMarks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdClientMarks.Size = New System.Drawing.Size(445, 96)
        Me.grdClientMarks.TabIndex = 74
        Me.grdClientMarks.TabStop = False
        Me.grdClientMarks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdDocumentLinks
        '
        Me.grdDocumentLinks.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdDocumentLinks.AllowCardSizing = False
        Me.grdDocumentLinks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdDocumentLinks.AlternatingColors = True
        Me.grdDocumentLinks.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdDocumentLinks.BackColor = System.Drawing.SystemColors.Control
        grdDocumentLinks_DesignTimeLayout.LayoutString = resources.GetString("grdDocumentLinks_DesignTimeLayout.LayoutString")
        Me.grdDocumentLinks.DesignTimeLayout = grdDocumentLinks_DesignTimeLayout
        Me.grdDocumentLinks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdDocumentLinks.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdDocumentLinks.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdDocumentLinks.GroupByBoxVisible = False
        Me.grdDocumentLinks.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDocumentLinks.Location = New System.Drawing.Point(694, 288)
        Me.grdDocumentLinks.Name = "grdDocumentLinks"
        Me.grdDocumentLinks.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdDocumentLinks.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdDocumentLinks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdDocumentLinks.Size = New System.Drawing.Size(271, 186)
        Me.grdDocumentLinks.TabIndex = 75
        Me.grdDocumentLinks.TabStop = False
        Me.grdDocumentLinks.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdDates
        '
        Me.grdDates.AllowCardSizing = False
        Me.grdDates.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdDates.AlternatingColors = True
        Me.grdDates.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdDates.BackColor = System.Drawing.SystemColors.Control
        grdDates_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("grdDates_DesignTimeLayout_Reference_0.Instance"), Object)
        grdDates_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("grdDates_DesignTimeLayout_Reference_1.Instance"), Object)
        grdDates_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {grdDates_DesignTimeLayout_Reference_0, grdDates_DesignTimeLayout_Reference_1})
        grdDates_DesignTimeLayout.LayoutString = resources.GetString("grdDates_DesignTimeLayout.LayoutString")
        Me.grdDates.DesignTimeLayout = grdDates_DesignTimeLayout
        Me.grdDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdDates.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdDates.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdDates.GroupByBoxVisible = False
        Me.grdDates.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDates.Location = New System.Drawing.Point(40, 288)
        Me.grdDates.Name = "grdDates"
        Me.grdDates.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdDates.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdDates.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdDates.Size = New System.Drawing.Size(301, 186)
        Me.grdDates.TabIndex = 34
        Me.grdDates.TabStop = False
        Me.grdDates.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdActions
        '
        Me.grdActions.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdActions.AllowCardSizing = False
        Me.grdActions.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdActions.AlternatingColors = True
        Me.grdActions.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdActions.BackColor = System.Drawing.SystemColors.Control
        grdActions_DesignTimeLayout.LayoutString = resources.GetString("grdActions_DesignTimeLayout.LayoutString")
        Me.grdActions.DesignTimeLayout = grdActions_DesignTimeLayout
        Me.grdActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdActions.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdActions.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdActions.GroupByBoxVisible = False
        Me.grdActions.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdActions.Location = New System.Drawing.Point(349, 288)
        Me.grdActions.Name = "grdActions"
        Me.grdActions.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdActions.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdActions.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdActions.Size = New System.Drawing.Size(325, 186)
        Me.grdActions.TabIndex = 35
        Me.grdActions.TabStop = False
        Me.grdActions.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.optDocumentLinks)
        Me.GroupBox6.Controls.Add(Me.btnPrintActions)
        Me.GroupBox6.Controls.Add(Me.chkReOrder)
        Me.GroupBox6.Controls.Add(Me.optLitigationActions)
        Me.GroupBox6.Controls.Add(Me.optLitigationDates)
        Me.GroupBox6.Controls.Add(Me.btnDatesFromTemplate)
        Me.GroupBox6.Location = New System.Drawing.Point(40, 474)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(927, 43)
        Me.GroupBox6.TabIndex = 77
        Me.GroupBox6.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Select View:"
        '
        'optDocumentLinks
        '
        Me.optDocumentLinks.AutoSize = True
        Me.optDocumentLinks.Location = New System.Drawing.Point(309, 17)
        Me.optDocumentLinks.Name = "optDocumentLinks"
        Me.optDocumentLinks.Size = New System.Drawing.Size(102, 17)
        Me.optDocumentLinks.TabIndex = 3
        Me.optDocumentLinks.Text = "Document Links"
        Me.optDocumentLinks.UseVisualStyleBackColor = True
        '
        'btnPrintActions
        '
        Me.btnPrintActions.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnPrintActions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintActions.Image = CType(resources.GetObject("btnPrintActions.Image"), System.Drawing.Image)
        Me.btnPrintActions.Location = New System.Drawing.Point(749, 15)
        Me.btnPrintActions.Name = "btnPrintActions"
        Me.btnPrintActions.ShowFocusRectangle = False
        Me.btnPrintActions.Size = New System.Drawing.Size(105, 20)
        Me.btnPrintActions.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnPrintActions.TabIndex = 66
        Me.btnPrintActions.TabStop = False
        Me.btnPrintActions.Text = "Print Actions"
        Me.btnPrintActions.UseThemes = False
        '
        'chkReOrder
        '
        Me.chkReOrder.AutoSize = True
        Me.chkReOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReOrder.ForeColor = System.Drawing.Color.Black
        Me.chkReOrder.Location = New System.Drawing.Point(431, 17)
        Me.chkReOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.chkReOrder.Name = "chkReOrder"
        Me.chkReOrder.Size = New System.Drawing.Size(97, 17)
        Me.chkReOrder.TabIndex = 3
        Me.chkReOrder.TabStop = False
        Me.chkReOrder.Text = "Re-Order Dates"
        Me.chkReOrder.UseVisualStyleBackColor = True
        '
        'optLitigationActions
        '
        Me.optLitigationActions.AutoSize = True
        Me.optLitigationActions.Location = New System.Drawing.Point(196, 17)
        Me.optLitigationActions.Name = "optLitigationActions"
        Me.optLitigationActions.Size = New System.Drawing.Size(105, 17)
        Me.optLitigationActions.TabIndex = 1
        Me.optLitigationActions.Text = "Litigation Actions"
        Me.optLitigationActions.UseVisualStyleBackColor = True
        '
        'optLitigationDates
        '
        Me.optLitigationDates.AutoSize = True
        Me.optLitigationDates.Checked = True
        Me.optLitigationDates.Location = New System.Drawing.Point(90, 17)
        Me.optLitigationDates.Name = "optLitigationDates"
        Me.optLitigationDates.Size = New System.Drawing.Size(98, 17)
        Me.optLitigationDates.TabIndex = 0
        Me.optLitigationDates.TabStop = True
        Me.optLitigationDates.Text = "Litigation Dates"
        Me.optLitigationDates.UseVisualStyleBackColor = True
        '
        'btnDatesFromTemplate
        '
        Me.btnDatesFromTemplate.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnDatesFromTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatesFromTemplate.Image = CType(resources.GetObject("btnDatesFromTemplate.Image"), System.Drawing.Image)
        Me.btnDatesFromTemplate.Location = New System.Drawing.Point(534, 15)
        Me.btnDatesFromTemplate.Name = "btnDatesFromTemplate"
        Me.btnDatesFromTemplate.ShowFocusRectangle = False
        Me.btnDatesFromTemplate.Size = New System.Drawing.Size(158, 20)
        Me.btnDatesFromTemplate.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnDatesFromTemplate.TabIndex = 40
        Me.btnDatesFromTemplate.TabStop = False
        Me.btnDatesFromTemplate.Text = "Get Dates From Template"
        Me.btnDatesFromTemplate.UseThemes = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.optOppositionMarks)
        Me.GroupBox1.Controls.Add(Me.btnPrintOne)
        Me.GroupBox1.Controls.Add(Me.optClientMarks)
        Me.GroupBox1.Controls.Add(Me.optClientAndOpposition)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 233)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(927, 43)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Select View:"
        '
        'optOppositionMarks
        '
        Me.optOppositionMarks.AutoSize = True
        Me.optOppositionMarks.Location = New System.Drawing.Point(412, 17)
        Me.optOppositionMarks.Name = "optOppositionMarks"
        Me.optOppositionMarks.Size = New System.Drawing.Size(185, 17)
        Me.optOppositionMarks.TabIndex = 3
        Me.optOppositionMarks.Text = "Opposition Trademarks (Add/Edit)"
        Me.optOppositionMarks.UseVisualStyleBackColor = True
        '
        'btnPrintOne
        '
        Me.btnPrintOne.Appearance = Janus.Windows.UI.Appearance.FlatBorderless
        Me.btnPrintOne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintOne.Image = CType(resources.GetObject("btnPrintOne.Image"), System.Drawing.Image)
        Me.btnPrintOne.Location = New System.Drawing.Point(749, 15)
        Me.btnPrintOne.Name = "btnPrintOne"
        Me.btnPrintOne.ShowFocusRectangle = False
        Me.btnPrintOne.Size = New System.Drawing.Size(152, 20)
        Me.btnPrintOne.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnPrintOne.TabIndex = 66
        Me.btnPrintOne.TabStop = False
        Me.btnPrintOne.Text = "Print Opposition Record"
        Me.btnPrintOne.UseThemes = False
        '
        'optClientMarks
        '
        Me.optClientMarks.AutoSize = True
        Me.optClientMarks.Location = New System.Drawing.Point(243, 17)
        Me.optClientMarks.Name = "optClientMarks"
        Me.optClientMarks.Size = New System.Drawing.Size(161, 17)
        Me.optClientMarks.TabIndex = 1
        Me.optClientMarks.Text = "Client Trademarks (Add/Edit)"
        Me.optClientMarks.UseVisualStyleBackColor = True
        '
        'optClientAndOpposition
        '
        Me.optClientAndOpposition.AutoSize = True
        Me.optClientAndOpposition.Checked = True
        Me.optClientAndOpposition.Location = New System.Drawing.Point(89, 17)
        Me.optClientAndOpposition.Name = "optClientAndOpposition"
        Me.optClientAndOpposition.Size = New System.Drawing.Size(145, 17)
        Me.optClientAndOpposition.TabIndex = 0
        Me.optClientAndOpposition.TabStop = True
        Me.optClientAndOpposition.Text = "Client && Opposition Marks"
        Me.optClientAndOpposition.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.OppositionName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.OppositionNotes)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.optDefendant)
        Me.GroupBox2.Controls.Add(Me.optPlaintiff)
        Me.GroupBox2.Controls.Add(Me.StatusID)
        Me.GroupBox2.Controls.Add(Me.btnStatus)
        Me.GroupBox2.Controls.Add(Me.CompanyID)
        Me.GroupBox2.Controls.Add(Me.btnCompany)
        Me.GroupBox2.Controls.Add(Me.OpposingCompanyID)
        Me.GroupBox2.Controls.Add(Me.btnOpposingCompany)
        Me.GroupBox2.Controls.Add(Me.ProceedingNumber)
        Me.GroupBox2.Controls.Add(Me.btnProceeding)
        Me.GroupBox2.Controls.Add(Me.JurisdictionID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(40, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(924, 115)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Opposition Name:"
        '
        'OppositionName
        '
        Me.OppositionName.BackColor = System.Drawing.Color.White
        Me.OppositionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OppositionName.ForeColor = System.Drawing.Color.Black
        Me.OppositionName.Location = New System.Drawing.Point(114, 15)
        Me.OppositionName.Name = "OppositionName"
        Me.OppositionName.Size = New System.Drawing.Size(464, 20)
        Me.OppositionName.TabIndex = 0
        Me.OppositionName.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(596, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Notes:"
        '
        'OppositionNotes
        '
        Me.OppositionNotes.BackColor = System.Drawing.SystemColors.Window
        Me.OppositionNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OppositionNotes.Location = New System.Drawing.Point(636, 15)
        Me.OppositionNotes.MaxLength = 5000
        Me.OppositionNotes.Multiline = True
        Me.OppositionNotes.Name = "OppositionNotes"
        Me.OppositionNotes.Size = New System.Drawing.Size(275, 89)
        Me.OppositionNotes.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Client Status:"
        '
        'optDefendant
        '
        Me.optDefendant.AutoSize = True
        Me.optDefendant.Location = New System.Drawing.Point(183, 63)
        Me.optDefendant.Name = "optDefendant"
        Me.optDefendant.Size = New System.Drawing.Size(75, 17)
        Me.optDefendant.TabIndex = 3
        Me.optDefendant.Text = "Defendant"
        Me.optDefendant.UseVisualStyleBackColor = True
        '
        'optPlaintiff
        '
        Me.optPlaintiff.AutoSize = True
        Me.optPlaintiff.Checked = True
        Me.optPlaintiff.Location = New System.Drawing.Point(115, 63)
        Me.optPlaintiff.Name = "optPlaintiff"
        Me.optPlaintiff.Size = New System.Drawing.Size(59, 17)
        Me.optPlaintiff.TabIndex = 2
        Me.optPlaintiff.TabStop = True
        Me.optPlaintiff.Text = "Plaintiff"
        Me.optPlaintiff.UseVisualStyleBackColor = True
        '
        'StatusID
        '
        Me.StatusID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.StatusID.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        StatusID_DesignTimeLayout.LayoutString = resources.GetString("StatusID_DesignTimeLayout.LayoutString")
        Me.StatusID.DesignTimeLayout = StatusID_DesignTimeLayout
        Me.StatusID.DisplayMember = "Status"
        Me.StatusID.FlatBorderColor = System.Drawing.SystemColors.ControlText
        Me.StatusID.Location = New System.Drawing.Point(431, 84)
        Me.StatusID.Name = "StatusID"
        Me.StatusID.ReadOnly = True
        Me.StatusID.SelectedIndex = -1
        Me.StatusID.SelectedItem = Nothing
        Me.StatusID.Size = New System.Drawing.Size(147, 20)
        Me.StatusID.TabIndex = 7
        Me.StatusID.ValueMember = "StatusID"
        '
        'btnStatus
        '
        Me.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStatus.FlatAppearance.BorderSize = 0
        Me.btnStatus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.Blue
        Me.btnStatus.Location = New System.Drawing.Point(382, 83)
        Me.btnStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(53, 21)
        Me.btnStatus.TabIndex = 41
        Me.btnStatus.TabStop = False
        Me.btnStatus.Text = "Status:"
        Me.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'CompanyID
        '
        Me.CompanyID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.CompanyID.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        CompanyID_DesignTimeLayout.LayoutString = resources.GetString("CompanyID_DesignTimeLayout.LayoutString")
        Me.CompanyID.DesignTimeLayout = CompanyID_DesignTimeLayout
        Me.CompanyID.DisplayMember = "CompanyName"
        Me.CompanyID.Location = New System.Drawing.Point(114, 38)
        Me.CompanyID.Name = "CompanyID"
        Me.CompanyID.ReadOnly = True
        Me.CompanyID.SelectedIndex = -1
        Me.CompanyID.SelectedItem = Nothing
        Me.CompanyID.Size = New System.Drawing.Size(239, 20)
        Me.CompanyID.TabIndex = 1
        Me.CompanyID.ValueMember = "CompanyID"
        '
        'btnCompany
        '
        Me.btnCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCompany.FlatAppearance.BorderSize = 0
        Me.btnCompany.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompany.ForeColor = System.Drawing.Color.Blue
        Me.btnCompany.Location = New System.Drawing.Point(20, 37)
        Me.btnCompany.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCompany.Name = "btnCompany"
        Me.btnCompany.Size = New System.Drawing.Size(98, 21)
        Me.btnCompany.TabIndex = 28
        Me.btnCompany.TabStop = False
        Me.btnCompany.Text = "Client Company:"
        Me.btnCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCompany.UseVisualStyleBackColor = False
        '
        'OpposingCompanyID
        '
        Me.OpposingCompanyID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.OpposingCompanyID.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        OpposingCompanyID_DesignTimeLayout.LayoutString = resources.GetString("OpposingCompanyID_DesignTimeLayout.LayoutString")
        Me.OpposingCompanyID.DesignTimeLayout = OpposingCompanyID_DesignTimeLayout
        Me.OpposingCompanyID.DisplayMember = "CompanyName"
        Me.OpposingCompanyID.Location = New System.Drawing.Point(114, 84)
        Me.OpposingCompanyID.Name = "OpposingCompanyID"
        Me.OpposingCompanyID.ReadOnly = True
        Me.OpposingCompanyID.SelectedIndex = -1
        Me.OpposingCompanyID.SelectedItem = Nothing
        Me.OpposingCompanyID.Size = New System.Drawing.Size(239, 20)
        Me.OpposingCompanyID.TabIndex = 4
        Me.OpposingCompanyID.ValueMember = "CompanyID"
        '
        'btnOpposingCompany
        '
        Me.btnOpposingCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpposingCompany.FlatAppearance.BorderSize = 0
        Me.btnOpposingCompany.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnOpposingCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpposingCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpposingCompany.ForeColor = System.Drawing.Color.Blue
        Me.btnOpposingCompany.Location = New System.Drawing.Point(3, 83)
        Me.btnOpposingCompany.Margin = New System.Windows.Forms.Padding(0)
        Me.btnOpposingCompany.Name = "btnOpposingCompany"
        Me.btnOpposingCompany.Size = New System.Drawing.Size(115, 21)
        Me.btnOpposingCompany.TabIndex = 68
        Me.btnOpposingCompany.TabStop = False
        Me.btnOpposingCompany.Text = "Opposition Company:"
        Me.btnOpposingCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOpposingCompany.UseVisualStyleBackColor = False
        '
        'ProceedingNumber
        '
        Me.ProceedingNumber.BackColor = System.Drawing.SystemColors.Window
        Me.ProceedingNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProceedingNumber.Location = New System.Drawing.Point(431, 38)
        Me.ProceedingNumber.MaxLength = 50
        Me.ProceedingNumber.Name = "ProceedingNumber"
        Me.ProceedingNumber.Size = New System.Drawing.Size(147, 20)
        Me.ProceedingNumber.TabIndex = 5
        Me.ProceedingNumber.WordWrap = False
        '
        'btnProceeding
        '
        Me.btnProceeding.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceeding.FlatAppearance.BorderSize = 0
        Me.btnProceeding.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnProceeding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceeding.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceeding.ForeColor = System.Drawing.Color.Blue
        Me.btnProceeding.Location = New System.Drawing.Point(361, 37)
        Me.btnProceeding.Margin = New System.Windows.Forms.Padding(0)
        Me.btnProceeding.Name = "btnProceeding"
        Me.btnProceeding.Size = New System.Drawing.Size(75, 21)
        Me.btnProceeding.TabIndex = 37
        Me.btnProceeding.TabStop = False
        Me.btnProceeding.Text = "Proceeding:"
        Me.btnProceeding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProceeding.UseVisualStyleBackColor = False
        '
        'JurisdictionID
        '
        Me.JurisdictionID.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.JurisdictionID.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        JurisdictionID_DesignTimeLayout.LayoutString = resources.GetString("JurisdictionID_DesignTimeLayout.LayoutString")
        Me.JurisdictionID.DesignTimeLayout = JurisdictionID_DesignTimeLayout
        Me.JurisdictionID.DisplayMember = "Jurisdiction"
        Me.JurisdictionID.Location = New System.Drawing.Point(431, 61)
        Me.JurisdictionID.Name = "JurisdictionID"
        Me.JurisdictionID.ReadOnly = True
        Me.JurisdictionID.SelectedIndex = -1
        Me.JurisdictionID.SelectedItem = Nothing
        Me.JurisdictionID.Size = New System.Drawing.Size(147, 20)
        Me.JurisdictionID.TabIndex = 6
        Me.JurisdictionID.ValueMember = "JurisdictionID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(370, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Jurisdiction:"
        '
        'grdContacts
        '
        Me.grdContacts.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdContacts.AllowCardSizing = False
        Me.grdContacts.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
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
        Me.grdContacts.Location = New System.Drawing.Point(40, 531)
        Me.grdContacts.Name = "grdContacts"
        Me.grdContacts.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdContacts.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdContacts.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdContacts.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdContacts.Size = New System.Drawing.Size(925, 96)
        Me.grdContacts.TabIndex = 36
        Me.grdContacts.TabStop = False
        Me.grdContacts.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'tbPreferences
        '
        Me.tbPreferences.AutoScroll = True
        Me.tbPreferences.BackColor = System.Drawing.SystemColors.Control
        Me.tbPreferences.Controls.Add(Me.Label8)
        Me.tbPreferences.Controls.Add(Me.chkOrderDates)
        Me.tbPreferences.Controls.Add(Me.grdTrademarkJurisDates)
        Me.tbPreferences.Controls.Add(Me.grdTrademarkMasterDates)
        Me.tbPreferences.Controls.Add(Me.btnAddTrademarkDates)
        Me.tbPreferences.Controls.Add(Me.Label7)
        Me.tbPreferences.Controls.Add(Me.cboMarkJurisdiction)
        Me.tbPreferences.Location = New System.Drawing.Point(4, 22)
        Me.tbPreferences.Name = "tbPreferences"
        Me.tbPreferences.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPreferences.Size = New System.Drawing.Size(1008, 677)
        Me.tbPreferences.TabIndex = 2
        Me.tbPreferences.Text = "Opposition Preferences"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(693, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Jurisdiction:"
        '
        'chkOrderDates
        '
        Me.chkOrderDates.AutoSize = True
        Me.chkOrderDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOrderDates.Location = New System.Drawing.Point(185, 366)
        Me.chkOrderDates.Name = "chkOrderDates"
        Me.chkOrderDates.Size = New System.Drawing.Size(97, 17)
        Me.chkOrderDates.TabIndex = 69
        Me.chkOrderDates.TabStop = False
        Me.chkOrderDates.Text = "Re-Order Dates"
        Me.chkOrderDates.UseVisualStyleBackColor = True
        '
        'grdTrademarkJurisDates
        '
        Me.grdTrademarkJurisDates.AllowCardSizing = False
        Me.grdTrademarkJurisDates.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkJurisDates.AlternatingColors = True
        Me.grdTrademarkJurisDates.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTrademarkJurisDates.BackColor = System.Drawing.SystemColors.Control
        grdTrademarkJurisDates_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("grdTrademarkJurisDates_DesignTimeLayout_Reference_0.Instance"), Object)
        grdTrademarkJurisDates_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("grdTrademarkJurisDates_DesignTimeLayout_Reference_1.Instance"), Object)
        grdTrademarkJurisDates_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {grdTrademarkJurisDates_DesignTimeLayout_Reference_0, grdTrademarkJurisDates_DesignTimeLayout_Reference_1})
        grdTrademarkJurisDates_DesignTimeLayout.LayoutString = resources.GetString("grdTrademarkJurisDates_DesignTimeLayout.LayoutString")
        Me.grdTrademarkJurisDates.DesignTimeLayout = grdTrademarkJurisDates_DesignTimeLayout
        Me.grdTrademarkJurisDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdTrademarkJurisDates.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdTrademarkJurisDates.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdTrademarkJurisDates.GroupByBoxVisible = False
        Me.grdTrademarkJurisDates.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdTrademarkJurisDates.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTrademarkJurisDates.Location = New System.Drawing.Point(589, 55)
        Me.grdTrademarkJurisDates.Name = "grdTrademarkJurisDates"
        Me.grdTrademarkJurisDates.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdTrademarkJurisDates.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkJurisDates.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdTrademarkJurisDates.Size = New System.Drawing.Size(269, 303)
        Me.grdTrademarkJurisDates.TabIndex = 67
        Me.grdTrademarkJurisDates.TabStop = False
        Me.grdTrademarkJurisDates.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'grdTrademarkMasterDates
        '
        Me.grdTrademarkMasterDates.AllowCardSizing = False
        Me.grdTrademarkMasterDates.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkMasterDates.AlternatingColors = True
        Me.grdTrademarkMasterDates.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTrademarkMasterDates.BackColor = System.Drawing.SystemColors.Control
        grdTrademarkMasterDates_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("grdTrademarkMasterDates_DesignTimeLayout_Reference_0.Instance"), Object)
        grdTrademarkMasterDates_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("grdTrademarkMasterDates_DesignTimeLayout_Reference_1.Instance"), Object)
        grdTrademarkMasterDates_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {grdTrademarkMasterDates_DesignTimeLayout_Reference_0, grdTrademarkMasterDates_DesignTimeLayout_Reference_1})
        grdTrademarkMasterDates_DesignTimeLayout.LayoutString = resources.GetString("grdTrademarkMasterDates_DesignTimeLayout.LayoutString")
        Me.grdTrademarkMasterDates.DesignTimeLayout = grdTrademarkMasterDates_DesignTimeLayout
        Me.grdTrademarkMasterDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdTrademarkMasterDates.GridLineColor = System.Drawing.SystemColors.Control
        Me.grdTrademarkMasterDates.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.grdTrademarkMasterDates.GroupByBoxVisible = False
        Me.grdTrademarkMasterDates.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdTrademarkMasterDates.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTrademarkMasterDates.Location = New System.Drawing.Point(77, 55)
        Me.grdTrademarkMasterDates.Name = "grdTrademarkMasterDates"
        Me.grdTrademarkMasterDates.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdTrademarkMasterDates.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTrademarkMasterDates.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grdTrademarkMasterDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.grdTrademarkMasterDates.Size = New System.Drawing.Size(451, 303)
        Me.grdTrademarkMasterDates.TabIndex = 66
        Me.grdTrademarkMasterDates.TabStop = False
        Me.grdTrademarkMasterDates.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None
        '
        'btnAddTrademarkDates
        '
        Me.btnAddTrademarkDates.Appearance = Janus.Windows.UI.Appearance.Normal
        Me.btnAddTrademarkDates.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTrademarkDates.Image = CType(resources.GetObject("btnAddTrademarkDates.Image"), System.Drawing.Image)
        Me.btnAddTrademarkDates.Location = New System.Drawing.Point(548, 189)
        Me.btnAddTrademarkDates.Name = "btnAddTrademarkDates"
        Me.btnAddTrademarkDates.ShowFocusRectangle = False
        Me.btnAddTrademarkDates.Size = New System.Drawing.Size(27, 20)
        Me.btnAddTrademarkDates.StateStyles.HotFormatStyle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnAddTrademarkDates.TabIndex = 64
        Me.btnAddTrademarkDates.TabStop = False
        Me.btnAddTrademarkDates.UseThemes = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS Outlook", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(72, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 25)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Opposition Dates"
        '
        'cboMarkJurisdiction
        '
        Me.cboMarkJurisdiction.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cboMarkJurisdiction.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None
        cboMarkJurisdiction_DesignTimeLayout.LayoutString = resources.GetString("cboMarkJurisdiction_DesignTimeLayout.LayoutString")
        Me.cboMarkJurisdiction.DesignTimeLayout = cboMarkJurisdiction_DesignTimeLayout
        Me.cboMarkJurisdiction.DisplayMember = "Jurisdiction"
        Me.cboMarkJurisdiction.Location = New System.Drawing.Point(638, 31)
        Me.cboMarkJurisdiction.Name = "cboMarkJurisdiction"
        Me.cboMarkJurisdiction.SelectedIndex = -1
        Me.cboMarkJurisdiction.SelectedItem = Nothing
        Me.cboMarkJurisdiction.Size = New System.Drawing.Size(171, 20)
        Me.cboMarkJurisdiction.TabIndex = 46
        Me.cboMarkJurisdiction.ValueMember = "JurisdictionID"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(10, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 14)
        Me.Label29.TabIndex = 50
        Me.Label29.Text = "Show:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(441, 17)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox1.TabIndex = 49
        Me.CheckBox1.TabStop = False
        Me.CheckBox1.Text = "Client Docket"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox2.ForeColor = System.Drawing.Color.Black
        Me.CheckBox2.Location = New System.Drawing.Point(357, 17)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(78, 17)
        Me.CheckBox2.TabIndex = 48
        Me.CheckBox2.TabStop = False
        Me.CheckBox2.Text = "Our Docket"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox3.ForeColor = System.Drawing.Color.Black
        Me.CheckBox3.Location = New System.Drawing.Point(298, 17)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox3.TabIndex = 47
        Me.CheckBox3.TabStop = False
        Me.CheckBox3.Text = "Status"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox4.ForeColor = System.Drawing.Color.Black
        Me.CheckBox4.Location = New System.Drawing.Point(217, 17)
        Me.CheckBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox4.TabIndex = 46
        Me.CheckBox4.TabStop = False
        Me.CheckBox4.Text = "Filing Basis"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox5.ForeColor = System.Drawing.Color.Black
        Me.CheckBox5.Location = New System.Drawing.Point(52, 17)
        Me.CheckBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(74, 17)
        Me.CheckBox5.TabIndex = 45
        Me.CheckBox5.TabStop = False
        Me.CheckBox5.Text = "File/Matter"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox6.ForeColor = System.Drawing.Color.Black
        Me.CheckBox6.Location = New System.Drawing.Point(132, 17)
        Me.CheckBox6.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox6.TabIndex = 44
        Me.CheckBox6.TabStop = False
        Me.CheckBox6.Text = "Registration"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'frmOppositions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.pnlSeparator)
        Me.Controls.Add(Me.tlsTrademarks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOppositions"
        Me.Text = "Oppositions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlsTrademarks.ResumeLayout(False)
        Me.tlsTrademarks.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.tbList.ResumeLayout(False)
        CType(Me.grdAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrowse.ResumeLayout(False)
        Me.grpSetContact.ResumeLayout(False)
        Me.grpSetContact.PerformLayout()
        CType(Me.cboSetContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSetPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListBottom.ResumeLayout(False)
        Me.grpListButtons.ResumeLayout(False)
        Me.grpAlerts.ResumeLayout(False)
        Me.grpAlerts.PerformLayout()
        Me.grpViewBy.ResumeLayout(False)
        Me.grpViewBy.PerformLayout()
        Me.tbOpposition.ResumeLayout(False)
        CType(Me.grdOppositionMarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClientMarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDocumentLinks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.StatusID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpposingCompanyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JurisdictionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPreferences.ResumeLayout(False)
        Me.tbPreferences.PerformLayout()
        CType(Me.grdTrademarkJurisDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTrademarkMasterDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMarkJurisdiction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsTrademarks As System.Windows.Forms.ToolStrip
    Friend WithEvents btnFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblGoTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnGoTrademarks As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGoToPatents As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGoToContacts As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPreferences As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlSeparator As System.Windows.Forms.Panel
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents tbList As System.Windows.Forms.TabPage
    Friend WithEvents tbOpposition As System.Windows.Forms.TabPage
    Friend WithEvents pnlListBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlBrowse As System.Windows.Forms.Panel
    Friend WithEvents grdList As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnReports As System.Windows.Forms.ToolStripButton
    Friend WithEvents CompanyID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ProceedingNumber As System.Windows.Forms.TextBox
    Friend WithEvents JurisdictionID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents StatusID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCompany As System.Windows.Forms.Button
    Friend WithEvents btnProceeding As System.Windows.Forms.Button
    Friend WithEvents btnStatus As System.Windows.Forms.Button
    Friend WithEvents grdDates As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdContacts As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdActions As Janus.Windows.GridEX.GridEX
    Friend WithEvents chkReOrder As System.Windows.Forms.CheckBox
    Friend WithEvents btnDatesFromTemplate As Janus.Windows.EditControls.UIButton
    Friend WithEvents sepDemo As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDemo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grpSetContact As System.Windows.Forms.GroupBox
    Friend WithEvents cboSetContact As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboSetPosition As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboStart As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cboEnd As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents BetweenStart As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BetweenEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnClearFilters As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdAlerts As Janus.Windows.GridEX.GridEX
    Friend WithEvents LeadDays As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnAddToOutlook As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPrintList As Janus.Windows.EditControls.UIButton
    Friend WithEvents grpViewBy As System.Windows.Forms.GroupBox
    Friend WithEvents optList As System.Windows.Forms.RadioButton
    Friend WithEvents optAlerts As System.Windows.Forms.RadioButton
    Friend WithEvents grpAlerts As System.Windows.Forms.GroupBox
    Friend WithEvents grpListButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewOpposition As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPrintOne As Janus.Windows.EditControls.UIButton
    Friend WithEvents optEmailAlerts As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrintRecords As Janus.Windows.EditControls.UIButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tutorials As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tutOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutSortFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCompanies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkRecords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutSetContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutWebLinks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutDateTemplates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutWordMerge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutOutlook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutAlertEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutDateEmails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutEmailTexts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCreateCompany As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutLinkCompanies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutImportContacts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkTemplates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPatentOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutTrademarkTreaties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutPatentTreaties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutLinkedPatents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutAlertsView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnPrevRecord As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNextRecord As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RecordCount As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnGoToOppositions As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpposingCompanyID As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnOpposingCompany As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optDefendant As System.Windows.Forms.RadioButton
    Friend WithEvents optPlaintiff As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OppositionNotes As System.Windows.Forms.TextBox
    Friend WithEvents grdOppositionMarks As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdClientMarks As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdDocumentLinks As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optOppositionMarks As System.Windows.Forms.RadioButton
    Friend WithEvents optClientMarks As System.Windows.Forms.RadioButton
    Friend WithEvents optClientAndOpposition As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optDocumentLinks As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrintActions As Janus.Windows.EditControls.UIButton
    Friend WithEvents optLitigationActions As System.Windows.Forms.RadioButton
    Friend WithEvents optLitigationDates As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OppositionName As System.Windows.Forms.TextBox
    Friend WithEvents tbPreferences As System.Windows.Forms.TabPage
    Friend WithEvents cboMarkJurisdiction As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grdTrademarkJurisDates As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdTrademarkMasterDates As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAddTrademarkDates As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkOrderDates As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tutWhatsNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutOppositions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutCustomSpreadsheets As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tutStatusCheck As System.Windows.Forms.ToolStripMenuItem
End Class
