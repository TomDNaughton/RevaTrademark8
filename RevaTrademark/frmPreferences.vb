Public Class frmPreferences

#Region "Declarations"

    Private rsMarkDates As New RecordSet
    Private rsMarkJurisDates As New RecordSet

    Private dtMarkJurisdictions As DataTable
    Private drMarkFilingBasis As OleDb.OleDbDataReader
    Private drMarkStatus As OleDb.OleDbDataReader
    Private dtMarkTreatyJurisdictions As DataTable
    Private dtMarkTreaties As DataTable

    Private rsPatentDates As New RecordSet
    Private rsPatentJurisDates As New RecordSet

    Private dtPatentJurisdictions As DataTable
    Private drPatentStatus As OleDb.OleDbDataReader
    Friend dtPatentTypes As DataTable
    Private dtPatentTreatyJurisdictions As DataTable
    Private dtPatentTreaties As DataTable

    Private dtPatentTreatyLinks As DataTable
    Private dtMarkTreatyLinks As DataTable
    Private dtPatentLinks As DataTable
    Private dtMarkLinks As DataTable

#End Region

#Region "Form General"

    Private Sub frmPreferences_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
            Me.sepDemo.Visible = True
            Me.lblDemo.Visible = True
        Else
            Me.sepDemo.Visible = False
            Me.lblDemo.Visible = False
        End If

        AllForms.frmPreferences = Me

        FillFilingBasis()
        FillStatus()
        FillJurisdictions()
        SetIntervalLists()
        SetTrademarkOptions()
        SetSecurity()
        GetTrademarkMasterDates()
        GetPatentMasterDates()
        FillWebLinks()
        GetFolderPreferences()

        With Me
            .optOpenTrademarks.Checked = (My.Settings.OpenOnMarks = True)
            .optOpenPatents.Checked = (My.Settings.OpenOnMarks = False)
            .optUSDates.Checked = (My.Settings.USADates = True)
            .optEuroDates.Checked = (My.Settings.USADates = False)
            .chkSpellMonth.Checked = My.Settings.SpellMonthMerge
            .chkBlankDatesLast.Checked = My.Settings.BlankDatesLast
            .chkEmailHTML.Checked = My.Settings.EmailHTML
            .chkHoursExpenses.Checked = (My.Settings.ShowHoursExpenses = True)
            .cboOutlookAlertTime.SelectedValue = My.Settings.OutlookAlertTime
            .optLinksMarks.Checked = (My.Settings.OpenOnMarks = True)
            .optLinksPatents.Checked = (My.Settings.OpenOnMarks = False)
            .optLinksMarks.Enabled = .chkEnableEdit.Checked
            .optLinksPatents.Enabled = .chkEnableEdit.Checked
        End With
        SetWebLinks()

    End Sub

    Private Sub SetSecurity()
        On Error Resume Next
        Dim iSecurityLevel As Integer
        iSecurityLevel = Globals.SecurityLevel

        Select Case iSecurityLevel
            Case 1

                With Me.grdTrademarkMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdTrademarkJurisDates
                    'jurisdiction dates are added by a button
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdMarkTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

                With Me
                    .btnAddTrademarkDates.Enabled = True
                    .btnAddPatentDates.Enabled = True
                End With

                With Me.grdPatentMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdPatentJurisDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdPatentTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

            Case 2

                With Me.grdTrademarkMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdTrademarkJurisDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdMarkTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

                With Me
                    .btnAddTrademarkDates.Enabled = True
                    .btnAddPatentDates.Enabled = True
                End With

                With Me.grdPatentMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdPatentJurisDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdPatentTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

            Case 3

                With Me.grdTrademarkMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdTrademarkJurisDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                    .RootTable.Columns("lnkBatchUpdate").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdMarkTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

                With Me
                    .btnAddTrademarkDates.Enabled = False
                    .btnAddPatentDates.Enabled = False
                End With

                With Me.grdPatentMasterDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdPatentJurisDates
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdPatentTreatyJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End With

        End Select

        Me.chkEnableEdit.Enabled = (Globals.SecurityLevel = 1)

    End Sub

    Private Sub frmPreferences_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        rsMarkDates.Update()
        rsMarkJurisDates.Update()
        rsPatentDates.Update()
        rsPatentJurisDates.Update()
        SaveFolderLocations()
        AllForms.frmPreferences = Nothing

        'trying to get a clean close
        If AllForms.frmTrademarks Is Nothing And AllForms.frmPatents Is Nothing And AllForms.frmLogin Is Nothing _
        And AllForms.frmPreferences Is Nothing And AllForms.frmReports Is Nothing _
        And AllForms.frmCompanies Is Nothing And AllForms.frmOppositions Is Nothing Then
            My.Settings.Save()
            Application.Exit()
        End If
    End Sub

    Private Sub tbTrademarks_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTrademarks.Leave
        On Error Resume Next
        'just to make sure ...
        rsMarkDates.Update()
        rsMarkJurisDates.Update()
    End Sub

    Private Sub cboMarkJurisdiction_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkJurisdiction.DoubleClick
        On Error Resume Next
        Dim f As New frmCopyJurisDates
        f.Show(Me)
    End Sub

    Private Sub cboPatentJurisdiction_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatentJurisdiction.DoubleClick
        On Error Resume Next
        Dim f As New frmCopyJurisDates
        f.Show(Me)
    End Sub

#End Region

#Region "Toolbar Buttons"

    Private Sub btnGoTrademarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoTrademarks.Click
        On Error Resume Next

        'if trademark form is open on a trademark, need to requery the dates grid in case it's changed
        If Not (AllForms.frmTrademarks Is Nothing) And (Globals.TrademarkID > 0) Then
            AllForms.frmTrademarks.GetDates()
            AllForms.frmTrademarks.SetDateFormats()
        End If
        AllForms.OpenTrademarks()
        Me.Close()
    End Sub

    Private Sub btnGoToPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToPatents.Click
        On Error Resume Next

        If Not (AllForms.frmPatents Is Nothing) And (Globals.PatentID > 0) Then
            AllForms.frmPatents.GetDates()
            AllForms.frmPatents.SetDateFormats()
        End If
        AllForms.OpenPatents()
        Me.Close()
    End Sub

    Private Sub btnGoToOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToOppositions.Click
        On Error Resume Next

        If Not (AllForms.frmOppositions Is Nothing) And (Globals.OppositionID > 0) Then
            AllForms.frmOppositions.GetDates()
            AllForms.frmOppositions.SetDateFormats()
        End If
        AllForms.OpenOppositions()
        Me.Close()
    End Sub

    Private Sub btnGoToContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToContacts.Click
        On Error Resume Next
        AllForms.OpenCompanies()
        Me.Close()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        On Error Resume Next
        AllForms.OpenReports()
        Me.Close()
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        AllForms.OpenLogin()
        Me.Close()
        AllForms.frmTrademarks.Close()
        AllForms.frmPatents.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        If MsgBox("Are you sure want to exit RevaTrademark?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            My.Settings.Save()
            Application.Exit()
        End If
    End Sub

#End Region

#Region "Fill Data Tables / Drop Downs"

    Friend Sub FillJurisdictions()
        On Error Resume Next
        Dim strSQL As String

        'Filing Bases marked as treaties are a type of jurisdiction
        strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsTrademark <> 0 " & _
        "UNION Select FilingBasisID * (-1) as JurisdictionID, FilingBasis + ' (Treaty)' as Jurisdiction " & _
        "from tblFilingBasis where IsTreaty <> 0 ORDER BY Jurisdiction"
        dtMarkJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.cboMarkJurisdiction.DataSource = dtMarkJurisdictions

        strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsPatent <> 0 Order by Jurisdiction"
        dtPatentJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.cboPatentJurisdiction.DataSource = dtPatentJurisdictions
    End Sub

    Friend Sub FillStatus()
        On Error Resume Next
        Dim strSQL As String

        'STATUS FOR TRADEMARKS
        strSQL = "Select StatusID, Status from tblStatus where IsTrademark <> 0 " & _
        "UNION Select - 1, '(All)' from tblStatus " & _
        "UNION Select - 2, '(None)' from tblStatus ORDER BY StatusID"
        'it's not multi-column so we use a datareader
        drMarkStatus = DataStuff.GetDataReader(strSQL)
        Me.grdTrademarkJurisDates.RootTable.Columns("StatusID").ValueList.PopulateValueList(drMarkStatus, "StatusID", "Status")

        'STATUS FOR PATENTS
        strSQL = "Select StatusID, Status from tblStatus where IsPatent <> 0 " & _
        "UNION Select - 1, '(All)' from tblStatus " & _
        "UNION Select - 2, '(None)' from tblStatus ORDER BY StatusID"
        'it's not multi-column so we use a datareader
        drPatentStatus = DataStuff.GetDataReader(strSQL)
        Me.grdPatentJurisDates.RootTable.Columns("StatusID").ValueList.PopulateValueList(drPatentStatus, "StatusID", "Status")

    End Sub

    Friend Sub FillFilingBasis()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select FilingBasisID, FilingBasis from tblFilingBasis where IsTreaty=0" & vbCrLf & _
        "Union Select - 1, '(All)' from tblFilingBasis" & vbCrLf & _
        "UNION Select - 2, '(None)' from tblFilingBasis ORDER BY FilingBasisID"

        'it's not multi-column so we use a datareader
        drMarkFilingBasis = DataStuff.GetDataReader(strSQL)
        Me.grdTrademarkJurisDates.RootTable.Columns("FilingBasisID").ValueList.PopulateValueList(drMarkFilingBasis, "FilingBasisID", "FilingBasis")

        strSQL = "Select FilingBasisID, FilingBasis from tblFilingBasis where IsTreaty<>0"
        dtMarkTreaties = DataStuff.GetDataTable(strSQL)
        Me.cboMarkFilingBasis.DataSource = dtMarkTreaties

    End Sub

    Friend Sub FillPatentTypes()
        On Error Resume Next
        Dim strSQL As String
        If Me.optPatentTreaty.Checked = True Then
            strSQL = "Select PatentTypeID, PatentType from tblPatentTypes where IsTreaty <> 0 order by PatentType"
        Else
            strSQL = "Select PatentTypeID, PatentType from tblPatentTypes order by PatentType"
        End If
        dtPatentTypes = DataStuff.GetDataTable(strSQL)
        Me.cboPatentType.DataSource = dtPatentTypes

        'if we are selecting treaty types, we have to clear the current selection
        If Me.optPatentTreaty.Checked = True Then
            Me.cboPatentType.SelectedIndex = -1
        End If

    End Sub

#End Region

#Region "Trademark Dates"

    Private Sub SetTrademarkOptions()
        On Error Resume Next

        'CREATING, SETTING MASTER DATES
        If Me.optMasterDates.Checked = True Then

            With Me.grdMarkTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdTrademarkJurisDates.Dock = DockStyle.None
                .grdTrademarkJurisDates.Left = 593
                .grdTrademarkJurisDates.Width = 278
                .grdTrademarkJurisDates.Height = 484
                .grdTrademarkJurisDates.RootTable.HeaderLines = 2
                .grdTrademarkMasterDates.Visible = True
                .grdTrademarkMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                .grdTrademarkMasterDates.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .grdTrademarkMasterDates.AllowDrop = False
                .grdTrademarkJurisDates.AllowDrop = False
                .grdTrademarkJurisDates.Visible = True
                .grdTrademarkJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .chkSetMarkRecur.Visible = False
                .btnAddTrademarkDates.Visible = False
                .btnAddTrademarkDates.Enabled = False
                .btnMarkFilingBasis.Visible = False
                .btnMarkJurisdiction.Visible = True
                .cboMarkFilingBasis.Visible = False
                .cboMarkJurisdiction.Visible = True
                .btnMarkJurisdiction.Visible = True
            End With

            With Me.grdTrademarkJurisDates.RootTable
                .Columns("FilingBasisID").Visible = False
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With
        End If

        'COPYING MASTER DATES TO JURISDICTION
        If Me.optCopyDates.Checked = True Then

            With Me.grdMarkTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdTrademarkJurisDates.Dock = DockStyle.None
                .grdTrademarkJurisDates.Left = 593
                .grdTrademarkJurisDates.Width = 278
                .grdTrademarkJurisDates.Height = 484
                .grdTrademarkJurisDates.RootTable.HeaderLines = 2
                .grdTrademarkMasterDates.Visible = True
                .grdTrademarkMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                .grdTrademarkMasterDates.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                .grdTrademarkMasterDates.AllowDrop = False
                .grdTrademarkJurisDates.AllowDrop = False
                .grdTrademarkJurisDates.Visible = True
                .grdTrademarkJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .chkSetMarkRecur.Visible = False
                .btnAddTrademarkDates.Visible = True
                .btnAddTrademarkDates.Enabled = True
                .btnMarkFilingBasis.Visible = False
                .btnMarkJurisdiction.Visible = True
                .cboMarkFilingBasis.Visible = False
                .cboMarkJurisdiction.Visible = True
                .btnMarkJurisdiction.Visible = True
            End With

            With Me.grdTrademarkJurisDates.RootTable
                .Columns("FilingBasisID").Visible = False
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With

        End If

        'RE-ORDERING BOTH SETS OF DATES
        If Me.optReorderDates.Checked = True Then

            With Me.grdMarkTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdTrademarkJurisDates.Dock = DockStyle.None
                .grdTrademarkJurisDates.Left = 593
                .grdTrademarkJurisDates.Width = 278
                .grdTrademarkJurisDates.Height = 484
                .grdTrademarkJurisDates.RootTable.HeaderLines = 2
                .grdTrademarkMasterDates.Visible = True
                .grdTrademarkMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                .grdTrademarkMasterDates.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .grdTrademarkMasterDates.AllowDrop = True
                .grdTrademarkJurisDates.AllowDrop = True
                .grdTrademarkJurisDates.Visible = True
                .grdTrademarkJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .chkSetMarkRecur.Visible = False
                .btnAddTrademarkDates.Visible = False
                .btnAddTrademarkDates.Enabled = True
                .btnMarkFilingBasis.Visible = False
                .btnMarkJurisdiction.Visible = True
                .cboMarkFilingBasis.Visible = False
                .cboMarkJurisdiction.Visible = True
                .btnMarkJurisdiction.Visible = True
            End With

            With Me.grdTrademarkJurisDates.RootTable
                .Columns("FilingBasisID").Visible = False
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With

        End If

        'SETTING OPTIONS FOR JURISDICTION DATES
        If Me.optJurisDates.Checked = True Then

            With Me.grdMarkTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdTrademarkJurisDates.Visible = True
                .grdTrademarkJurisDates.Dock = DockStyle.Fill
                .grdTrademarkJurisDates.RootTable.HeaderLines = 3
                .grdTrademarkJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .grdTrademarkMasterDates.Visible = False
                .chkSetMarkRecur.Visible = True
                .btnMarkJurisdiction.Visible = True
                .btnAddTrademarkDates.Visible = False
                .btnMarkFilingBasis.Visible = False
                .cboMarkFilingBasis.Visible = False
                .grdMarkTreatyJurisdictions.Visible = False
                .cboMarkJurisdiction.Visible = True
                .btnMarkJurisdiction.Visible = True
            End With

            With Me.grdTrademarkJurisDates.RootTable
                .Columns("FilingBasisID").Visible = True
                .Columns("StatusID").Visible = True
                .Columns("IsRelative").Visible = True
                .Columns("AlwaysAddRelative").Visible = True
                .Columns("IntervalNumber").Visible = Not (Me.chkSetMarkRecur.Checked)
                .Columns("IntervalType").Visible = Not (Me.chkSetMarkRecur.Checked)
                .Columns("OtherDateID").Visible = Not (Me.chkSetMarkRecur.Checked)
                .Columns("IntervalAdjust").Visible = Not (Me.chkSetMarkRecur.Checked)
                .Columns("CanRecur").Visible = (Me.chkSetMarkRecur.Checked)
                .Columns("RecursAtInterval").Visible = (Me.chkSetMarkRecur.Checked)
                .Columns("RecurIntervalNumber").Visible = (Me.chkSetMarkRecur.Checked)
                .Columns("RecurIntervalType").Visible = (Me.chkSetMarkRecur.Checked)
                .Columns("RecurAdjust").Visible = (Me.chkSetMarkRecur.Checked)
                .Columns("lnkBatchUpdate").Visible = True
                .Columns("lnkEmail").Visible = False
                .Columns("lnkDelete").Visible = False
            End With


        End If
        'SETTING WHICH JURISDICTIONS PARTCIPATE IN TREATIES
        If Me.optTreaty.Checked = True Then
            With Me
                .chkSetMarkRecur.Visible = False
                .grdTrademarkJurisDates.Visible = False
                .grdTrademarkMasterDates.Visible = False
                .cboMarkJurisdiction.Visible = False
                .btnMarkFilingBasis.Visible = True
                .cboMarkFilingBasis.Visible = True
                .grdMarkTreatyJurisdictions.Visible = False
                .btnMarkJurisdiction.Visible = False
            End With

            With Me.grdMarkTreatyJurisdictions
                .Left = 386
                .Width = 261
                .Visible = True
            End With

        End If

        'THIS ONE IS SORT OF AFTER THE FACT
        Dim bOrder As Boolean
        bOrder = Me.optReorderDates.Checked

        With Me.grdTrademarkJurisDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
        End With

        With Me.grdTrademarkMasterDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
        End With

    End Sub

    Private Sub optMasterDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasterDates.CheckedChanged
        On Error Resume Next
        If Me.optMasterDates.Checked = True Then
            SetTrademarkOptions()
        Else
            'if we we're switching AWAY from this view, save any changes
            LockAndLoadMarkMasterDates()
        End If
    End Sub

    Private Sub optJurisDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optJurisDates.CheckedChanged
        On Error Resume Next
        If Me.optJurisDates.Checked = True Then
            SetTrademarkOptions()
        Else
            'we're navigating away from possible changes, so ...
            LockAndLoadMarkJurisDates()
        End If

    End Sub

    Private Sub optTreaty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTreaty.CheckedChanged
        On Error Resume Next
        If Me.optTreaty.Checked = True Then
            'to clean up that issue with null boxes looking checked
            DataStuff.RunSQL("update tblTreatyJurisdictions set IsParticipant = 0 where IsParticipant is null")
            SetTrademarkOptions()
        End If
    End Sub

    Private Sub optCopyDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCopyDates.CheckedChanged
        If Me.optCopyDates.Checked = True Then
            SetTrademarkOptions()
        Else
            'we're navigating away from possible changes, so ...
            LockAndLoadMarkJurisDates()
        End If

    End Sub

    Private Sub optReorderDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optReorderDates.CheckedChanged
        If Me.optReorderDates.Checked = True Then
            SetTrademarkOptions()
        Else
            'we may have been moving dates around, then leaving
            LockAndLoadMarkJurisDates()
            LockAndLoadMarkMasterDates()
        End If

    End Sub

    Private Sub btnMarkFilingBasis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkFilingBasis.Click
        On Error Resume Next
        Dim f As New frmTrademarkPopups
        f.GetRecordset(3)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnMarkJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkJurisdiction.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(5)
        f.ShowDialog(Me)
        f = Nothing
    End Sub


#Region "Trademark Master Dates"

    Private Sub GetTrademarkMasterDates()
        On Error Resume Next
        rsMarkDates.GetFromSQL("Select * from tblDatesTemplate")
        Me.grdTrademarkMasterDates.DataSource = rsMarkDates.Table
    End Sub

    Private Sub LockAndLoadMarkMasterDates()
        On Error Resume Next
        Dim iRow As Integer, iTop As Integer
        With Me.grdTrademarkMasterDates
            iRow = .Row
            iTop = .FirstRow
            .UpdateData()
            rsMarkDates.Update()
            GetTrademarkMasterDates()
            .Row = iRow
            .FirstRow = iTop
        End With

    End Sub

    Private Sub grdTrademarkMasterDates_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdTrademarkMasterDates.DragDrop
        On Error Resume Next
        Dim rowDrop As Integer = grdTrademarkMasterDates.RowPositionFromPoint()
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        'becuz dropping below last row produces a negative number
        If rowDrop < 0 Then rowDrop = Me.grdTrademarkMasterDates.RowCount + 1
        'because the grid is zero-based
        rowDrop = rowDrop + 1

        Dim iCurrentOrder As Integer, iSmallestOrder As Integer, i As Integer

        iSmallestOrder = 9999
        For i = 0 To Me.grdTrademarkMasterDates.SelectedItems.Count - 1
            GRow = Me.grdTrademarkMasterDates.SelectedItems(i).GetRow
            If GRow.Cells("ListOrder").Value < iSmallestOrder Then
                iSmallestOrder = GRow.Cells("ListOrder").Value
            End If
        Next

        For Each GRow In Me.grdTrademarkMasterDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                iCurrentOrder = GRow.Cells("ListOrder").Value
                GRow.BeginEdit()

                If GRow.Selected Then
                    GRow.Cells("ListOrder").Value = (iCurrentOrder - iSmallestOrder + rowDrop)
                Else
                    If iCurrentOrder >= rowDrop Then
                        GRow.Cells("ListOrder").Value = (iCurrentOrder + 10000)
                    End If
                End If
                GRow.EndEdit()
            End If
        Next

        ReOrderMarkMasterDates()
        rsMarkDates.Update()

    End Sub

    Private Sub grdTrademarkMasterDates_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdTrademarkMasterDates.DragOver
        On Error Resume Next
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub grdTrademarkMasterDates_RowDrag(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowDragEventArgs) Handles grdTrademarkMasterDates.RowDrag
        On Error Resume Next
        Dim MoveDateID As Object = 0  'DoDragDrop won't work without an object
        Me.grdTrademarkMasterDates.DoDragDrop(MoveDateID, DragDropEffects.Move)
    End Sub

    Private Sub grdTrademarkMasterDates_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdTrademarkMasterDates.AddingRecord
        On Error Resume Next
        Dim iListOrder As Integer
        'apparently the grid counts header rows
        iListOrder = Me.grdTrademarkMasterDates.RowCount - 1
        Me.grdTrademarkMasterDates.SetValue("ListOrder", iListOrder)
    End Sub

    Private Sub grdTrademarkMasterDates_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkMasterDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim iDateID As Integer
            iDateID = Me.grdTrademarkMasterDates.GetValue("DateID")

            If DataStuff.DCount("DateID", "tblJurisdictionDates", "DateID=" & iDateID) > 0 Then
                MsgBox("You cannot delete a date that has been applied to a Jurisdiction.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdTrademarkMasterDates.CurrentRow.Delete()
            ReOrderMarkMasterDates()
            rsMarkDates.Update()

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdTrademarkMasterDates.GetValue("ListOrder")
            iDateID = Me.grdTrademarkMasterDates.GetValue("DateID")

            If iCurrentOrder > 1 Then
                For Each dr As DataRow In rsMarkDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder - 1
                    Else
                        If dr("ListOrder") = iCurrentOrder - 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If

        End If

        If e.Column.Key = "MoveDown" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdTrademarkMasterDates.GetValue("ListOrder")
            iDateID = Me.grdTrademarkMasterDates.GetValue("DateID")

            If iCurrentOrder < Me.grdTrademarkMasterDates.RowCount Then
                For Each dr As DataRow In rsMarkDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder + 1
                    Else
                        If dr("ListOrder") = iCurrentOrder + 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If

        End If

        If (e.Column.Key = "lnkEmail") And (Globals.SecurityLevel < 3) Then
            On Error Resume Next
            'to make sure we have a true DateID in grid
            LockAndLoadMarkMasterDates()
            AllForms.OpenMergeHelper()

            With AllForms.frmMergeHelper
                .MergeStatus = frmMergeHelper.mStatus.TrademarkAlertDate
                .DateID = Me.grdTrademarkMasterDates.GetValue("DateID")
                .lblDateName.Visible = True
                .lblDateName.Text = "Alert Email for " & Me.grdTrademarkMasterDates.GetValue("DateName")
                .SetOptions()
            End With
        End If

    End Sub

    Private Sub grdTrademarkMasterDates_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkMasterDates.RecordAdded
        On Error Resume Next
        rsMarkDates.Update()
    End Sub

    Private Sub grdTrademarkMasterDates_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkMasterDates.RecordUpdated
        On Error Resume Next
        rsMarkDates.Update()
    End Sub

    Private Sub ReOrderMarkMasterDates()
        On Error Resume Next
        Dim iListOrder As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        iListOrder = 1
        For Each GRow In Me.grdTrademarkMasterDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("ListOrder").Value = iListOrder
                GRow.EndEdit()
                iListOrder = iListOrder + 1
            End If
        Next
    End Sub

    Private Sub btnAddTrademarkDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrademarkDates.Click
        On Error Resume Next
        Dim iJurisdictionID As Integer, GRow As Janus.Windows.GridEX.GridEXRow, i As Integer, iDateID As Integer, strFilter As String

        iJurisdictionID = Nz(Me.cboMarkJurisdiction.Value, 0)

        If iJurisdictionID = 0 Then
            MsgBox("You must select the jurisdiction first.")
            Exit Sub
        End If

        'don't bother if nothing is selected
        If Me.grdTrademarkMasterDates.SelectedItems.Count < 1 Then
            MsgBox("You must select dates to add first.")
            Exit Sub
        End If

        For i = 0 To Me.grdTrademarkMasterDates.SelectedItems.Count - 1
            GRow = Me.grdTrademarkMasterDates.SelectedItems(i).GetRow
            iDateID = GRow.Cells("DateID").Value
            'make sure it's not a blank dateID
            If iDateID <> 0 Then
                'make sure it doesn't already exist
                strFilter = "DateID=" & iDateID
                If rsMarkJurisDates.RecordExists(strFilter) = False Then
                    rsMarkJurisDates.AddRow()
                    'final precaution, make sure it's a new row
                    If rsMarkJurisDates.CurrentRow("DateID").ToString = "" Then
                        rsMarkJurisDates.CurrentRow("DateID") = iDateID
                        rsMarkJurisDates.CurrentRow("JurisdictionID") = iJurisdictionID
                        rsMarkJurisDates.CurrentRow("ListOrder") = GRow.Cells("ListOrder").Value
                        rsMarkJurisDates.CurrentRow("IsRelative") = False
                        rsMarkJurisDates.CurrentRow("AlwaysAddRelative") = False
                        rsMarkJurisDates.CurrentRow("CanRecur") = False
                        rsMarkJurisDates.CurrentRow("RecursAtInterval") = False
                    End If
                End If
            End If
        Next i

        ' for some reason, the numbers go wacky without a full lock and load before and after re-ordering
        ' since this function is only used in setting up a jurisdiction, we'll let it go.
        LockAndLoadMarkJurisDates()
        ReOrderMarkJurisDates()
        LockAndLoadMarkJurisDates()
        Me.grdTrademarkMasterDates.SelectedItems.Clear()

    End Sub


#End Region

#Region "Trademark Jurisdiction Dates"

    Friend Sub GetTrademarkJurisDates()
        On Error Resume Next
        Dim strSQL As String, iJurisdictionID As Integer, drOtherDates As OleDb.OleDbDataReader

        iJurisdictionID = Me.cboMarkJurisdiction.Value

        strSQL = "Select *, (Select DateName from tblDatesTemplate where DateID = tblJurisdictionDates.DateID) as DateName " & _
            "from tblJurisdictionDates where JurisdictionID=" & iJurisdictionID

        rsMarkJurisDates.GetFromSQL(strSQL)
        Me.grdTrademarkJurisDates.DataSource = rsMarkJurisDates.Table

        'datareader to bind drop-down for related dates
        strSQL = "Select DateID, DateName, ListOrder from tblDatesTemplate where DateID in (" & _
            "Select DateID from tblJurisdictionDates where JurisdictionID=" & iJurisdictionID & ")"
        strSQL = strSQL & " UNION Select 0, '(None)', -1 from tblDatesTemplate order by ListOrder"

        drOtherDates = DataStuff.GetDataReader(strSQL)
        Me.grdTrademarkJurisDates.RootTable.Columns("OtherDateID").ValueList.PopulateValueList(drOtherDates, "DateID", "DateName")

    End Sub

    Private Sub LockAndLoadMarkJurisDates()
        On Error Resume Next
        Dim iRow As Integer, iTop As Integer
        With Me.grdTrademarkJurisDates
            iRow = .Row
            iTop = .FirstRow
            .UpdateData()
            rsMarkJurisDates.Update()
            GetTrademarkJurisDates()
            .Row = iRow
            .FirstRow = iTop
        End With

    End Sub

    Private Sub cboMarkJurisdiction_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkJurisdiction.ValueChanged
        On Error Resume Next
        GetTrademarkJurisDates()
    End Sub

    Private Sub SetIntervalLists()
        On Error Resume Next

        'these get attached to drop-downs for intervals
        With Me.grdTrademarkJurisDates.RootTable.Columns("IntervalType").ValueList
            .Add(0, "(None)")
            .Add(1, "Days Before")
            .Add(2, "Months Before")
            .Add(3, "Years Before")
            .Add(4, "Days After")
            .Add(5, "Months After")
            .Add(6, "Years After")
        End With

        With Me.grdTrademarkJurisDates.RootTable.Columns("RecurIntervalType").ValueList
            .Add(0, "(None)")
            .Add(1, "Days Before")
            .Add(2, "Months Before")
            .Add(3, "Years Before")
            .Add(4, "Days After")
            .Add(5, "Months After")
            .Add(6, "Years After")
        End With

        With Me.grdTrademarkJurisDates.RootTable.Columns("IntervalAdjust").ValueList
            .Add(0, "(None)")
            .Add(1, "Minus One Day")
            .Add(2, "End of Month")
            .Add(3, "Start of Month")
            .Add(4, "End of Previous Month")
            .Add(5, "Start of Next Month")
            .Add(6, "Plus One Day")
        End With

        With Me.grdTrademarkJurisDates.RootTable.Columns("RecurAdjust").ValueList
            .Add(0, "(None)")
            .Add(1, "Minus One Day")
            .Add(2, "End of Month")
            .Add(3, "Start of Month")
            .Add(4, "End of Previous Month")
            .Add(5, "Start of Next Month")
            .Add(6, "Plus One Day")
        End With

        'PATENTS LISTS 

        With Me.grdPatentJurisDates.RootTable.Columns("IntervalType").ValueList
            .Add(0, "(None)")
            .Add(1, "Days Before")
            .Add(2, "Months Before")
            .Add(3, "Years Before")
            .Add(4, "Days After")
            .Add(5, "Months After")
            .Add(6, "Years After")
        End With

        With Me.grdPatentJurisDates.RootTable.Columns("RecurIntervalType").ValueList
            .Add(0, "(None)")
            .Add(1, "Days Before")
            .Add(2, "Months Before")
            .Add(3, "Years Before")
            .Add(4, "Days After")
            .Add(5, "Months After")
            .Add(6, "Years After")
        End With

        With Me.grdPatentJurisDates.RootTable.Columns("IntervalAdjust").ValueList
            .Add(0, "(None)")
            .Add(1, "Minus One Day")
            .Add(2, "End of Month")
            .Add(3, "Start of Month")
            .Add(4, "End of Previous Month")
            .Add(5, "Start of Next Month")
            .Add(6, "Plus One Day")
        End With

        With Me.grdPatentJurisDates.RootTable.Columns("RecurAdjust").ValueList
            .Add(0, "(None)")
            .Add(1, "Minus One Day")
            .Add(2, "End of Month")
            .Add(3, "Start of Month")
            .Add(4, "End of Previous Month")
            .Add(5, "Start of Next Month")
            .Add(6, "Plus One Day")
        End With
    End Sub

    Private Sub grdTrademarkJurisDates_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkJurisDates.CellValueChanged
        On Error Resume Next
        'if it's not relative, clear the other options
        If e.Column.Key = "IsRelative" And Me.grdTrademarkJurisDates.GetValue("IsRelative") = False Then
            With Me.grdTrademarkJurisDates
                .SetValue("AlwaysAddRelative", False)
                .SetValue("IntervalNumber", DBNull.Value)
                .SetValue("IntervalType", DBNull.Value)
                .SetValue("OtherDateID", DBNull.Value)
                .SetValue("IntervalAdjust", DBNull.Value)
            End With
        End If

        If e.Column.Key = "CanRecur" And Me.grdTrademarkJurisDates.GetValue("CanRecur") = False Then
            With Me.grdTrademarkJurisDates
                .SetValue("RecursAtInterval", False)
                .SetValue("RecurIntervalNumber", DBNull.Value)
                .SetValue("RecurIntervalType", DBNull.Value)
                .SetValue("RecurAdjust", DBNull.Value)
            End With
        End If

        If e.Column.Key = "RecursAtInterval" And Me.grdTrademarkJurisDates.GetValue("RecursAtInterval") = False Then
            With Me.grdTrademarkJurisDates
                .SetValue("RecurIntervalNumber", DBNull.Value)
                .SetValue("RecurIntervalType", DBNull.Value)
                .SetValue("RecurAdjust", DBNull.Value)
            End With
        End If

    End Sub

    Private Sub grdTrademarkJurisDates_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkJurisDates.RecordUpdated
        On Error Resume Next
        rsMarkJurisDates.Update()
    End Sub

    Friend Sub ReOrderMarkJurisDates()
        On Error Resume Next
        On Error Resume Next
        Dim iListOrder As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        iListOrder = 1
        For Each GRow In Me.grdTrademarkJurisDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("ListOrder").Value = iListOrder
                GRow.EndEdit()
                iListOrder = iListOrder + 1
            End If
        Next
        Me.grdPatentJurisDates.UpdateData()
    End Sub

    Private Sub grdTrademarkJurisDates_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdTrademarkJurisDates.DragDrop
        On Error Resume Next
        Dim rowDrop As Integer = grdTrademarkJurisDates.RowPositionFromPoint()
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        'becuz dropping below last row produces a negative number
        If rowDrop < 0 Then rowDrop = Me.grdTrademarkJurisDates.RowCount + 1
        'because the grid is zero-based
        rowDrop = rowDrop + 1
        Dim iCurrentOrder As Integer, iSmallestOrder As Integer, i As Integer

        iSmallestOrder = 9999
        For i = 0 To Me.grdTrademarkJurisDates.SelectedItems.Count - 1
            GRow = Me.grdTrademarkJurisDates.SelectedItems(i).GetRow
            If GRow.Cells("ListOrder").Value < iSmallestOrder Then
                iSmallestOrder = GRow.Cells("ListOrder").Value
            End If
        Next

        For Each GRow In Me.grdTrademarkJurisDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                iCurrentOrder = GRow.Cells("ListOrder").Value
                GRow.BeginEdit()

                If GRow.Selected Then
                    GRow.Cells("ListOrder").Value = (iCurrentOrder - iSmallestOrder + rowDrop)
                Else
                    If iCurrentOrder >= rowDrop Then
                        GRow.Cells("ListOrder").Value = (iCurrentOrder + 10000)
                    End If
                End If
                GRow.EndEdit()
            End If
        Next

        ReOrderMarkJurisDates()
        rsMarkJurisDates.Update()

    End Sub

    Private Sub grdTrademarkJurisDates_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdTrademarkJurisDates.DragOver
        On Error Resume Next
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub grdTrademarkJurisDates_RowDrag(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowDragEventArgs) Handles grdTrademarkJurisDates.RowDrag
        On Error Resume Next
        Dim MoveDateID As Object = 0  'DoDragDrop won't work without an object
        Me.grdTrademarkJurisDates.DoDragDrop(MoveDateID, DragDropEffects.Move)
    End Sub

    Private Sub grdTrademarkJurisDates_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkJurisDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim iJurisdictionDateID As Integer
            iJurisdictionDateID = Me.grdTrademarkJurisDates.GetValue("JurisdictionDateID")

            If DataStuff.DCount("JurisdictionDateID", "tblTrademarkDates", "JurisdictionDateID=" & iJurisdictionDateID) > 0 Then
                MsgBox("You cannot delete a date that has been applied to a trademark.")
                Exit Sub
            End If


            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date from the jurisdiction?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Me.grdTrademarkJurisDates.CurrentRow.Delete()
            ReOrderMarkJurisDates()
            rsMarkJurisDates.Update()

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdTrademarkJurisDates.GetValue("ListOrder")
            iDateID = Me.grdTrademarkJurisDates.GetValue("DateID")

            If iCurrentOrder > 1 Then
                For Each dr As DataRow In rsMarkJurisDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder - 1
                    Else
                        If dr("ListOrder") = iCurrentOrder - 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If
        End If

        If e.Column.Key = "MoveDown" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdTrademarkJurisDates.GetValue("ListOrder")
            iDateID = Me.grdTrademarkJurisDates.GetValue("DateID")

            If iCurrentOrder < Me.grdTrademarkJurisDates.RowCount Then
                For Each dr As DataRow In rsMarkJurisDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder + 1
                    Else
                        If dr("ListOrder") = iCurrentOrder + 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If
        End If

        If (e.Column.Key = "lnkBatchUpdate") And (Globals.SecurityLevel < 3) Then
            Dim strMessage As String, iJurisdictionID As Integer, iDateID As Integer

            strMessage = "This will update the selected date throughout the database.  Dates marked as " & _
                "completed will not be affected.  Proceed?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            Me.grdTrademarkJurisDates.UpdateData()
            iJurisdictionID = Me.cboMarkJurisdiction.Value
            iDateID = Me.grdTrademarkJurisDates.GetValue("DateID")
            Dim MD As New MarkDates
            MD.BatchUpdate(iJurisdictionID, iDateID)
            MD = Nothing
            Me.Cursor = Cursors.Default

        End If

        If (e.Column.Key = "lnkEmail") And (Globals.SecurityLevel < 3) Then
            On Error Resume Next
            AllForms.OpenMergeHelper()
            With AllForms.frmMergeHelper
                .MergeStatus = frmMergeHelper.mStatus.TrademarkJurisDate
                .JurisdictionDateID = Me.grdTrademarkJurisDates.GetValue("JurisdictionDateID")
                .lblDateName.Visible = True
                .lblDateName.Text = "Email for " & Me.grdTrademarkJurisDates.GetValue("DateName")
                .SetOptions()
            End With
        End If

    End Sub

    Private Sub grdTrademarkJurisDates_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTrademarkJurisDates.Resize
        On Error Resume Next
        With Me.grdTrademarkJurisDates
            If .Dock = DockStyle.Fill Then
                .RootTable.Columns("DateName").Width = .Width - 875
            Else
                .RootTable.Columns("DateName").Width = 155
            End If
        End With
    End Sub

    Private Sub chkSetMarkRecur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSetMarkRecur.CheckedChanged
        On Error Resume Next
        SetTrademarkOptions()
    End Sub


#End Region

#Region "Treaty Jurisdictions"

    Private Sub cboMarkFilingBasis_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkFilingBasis.ValueChanged
        On Error Resume Next
        Dim iFilingBasisID As Integer, strSQL As String
        iFilingBasisID = Me.cboMarkFilingBasis.Value

        strSQL = "Select * from qvwTrademarkTreatyJurisdictions where FilingBasisID=" & iFilingBasisID
        dtMarkTreatyJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.grdMarkTreatyJurisdictions.DataSource = dtMarkTreatyJurisdictions
        Me.grdMarkTreatyJurisdictions.FirstRow = 0
    End Sub

    Private Sub grdMarkTreatyJurisdictions_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMarkTreatyJurisdictions.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iTreatyJurisID As Integer

        With Me.grdMarkTreatyJurisdictions
            iTreatyJurisID = .GetValue("TreatyJurisID")
            rsRecord.GetFromSQL("Select * from tblTreatyJurisdictions where TreatyJurisID=" & iTreatyJurisID)
            dRow = rsRecord.CurrentRow
            dRow("IsParticipant") = IIf(.GetValue("IsParticipant") = True, True, False)
        End With

        rsRecord.Update()

    End Sub

#End Region

#End Region

#Region "Patent Dates"

    Private Sub SetPatentOptions()
        On Error Resume Next

        'SETTING MASTER DATES
        If Me.optPatentMasterDates.Checked = True Then

            With Me.grdPatentTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdPatentJurisDates.Dock = DockStyle.None
                .grdPatentJurisDates.Left = 593
                .grdPatentJurisDates.Width = 278
                .grdPatentJurisDates.Height = 483
                .grdPatentJurisDates.RootTable.HeaderLines = 2
                .grdPatentMasterDates.Visible = True
                .grdPatentJurisDates.Visible = True
                .grdPatentMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                .grdPatentMasterDates.AllowDrop = False
                .grdPatentJurisDates.AllowDrop = False
                .grdPatentJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .chkSetPatentRecur.Visible = False
                .btnAddPatentDates.Visible = False
                .btnPatentJurisdiction.Visible = True
                .cboPatentJurisdiction.Visible = True
                .btnPatentJurisdiction.Visible = True
                .cboPatentType.Left = 739
                .btnPatentType.Left = 761
            End With

            With Me.grdPatentJurisDates.RootTable
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With
            FillPatentTypes()

        End If

        'COPYING TO JURISDICTION
        If Me.optPatentCopyDates.Checked = True Then

            With Me.grdPatentTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdPatentJurisDates.Dock = DockStyle.None
                .grdPatentJurisDates.Left = 593
                .grdPatentJurisDates.Width = 278
                .grdPatentJurisDates.Height = 483
                .grdPatentJurisDates.RootTable.HeaderLines = 2
                .grdPatentMasterDates.Visible = True
                .grdPatentJurisDates.Visible = True
                .grdPatentMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                .grdPatentJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .grdPatentMasterDates.AllowDrop = False
                .grdPatentJurisDates.AllowDrop = False
                .chkSetPatentRecur.Visible = False
                .btnAddPatentDates.Visible = True
                .btnPatentJurisdiction.Visible = True
                .cboPatentJurisdiction.Visible = True
                .btnPatentJurisdiction.Visible = True
                .cboPatentType.Left = 739
                .btnPatentType.Left = 761
            End With

            With Me.grdPatentJurisDates.RootTable
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With
            FillPatentTypes()

        End If

        'SETTING OPTIONS FOR JURISDICTION DATES
        If Me.optPatentJurisDates.Checked = True Then

            With Me.grdPatentTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdPatentJurisDates.Visible = True
                .grdPatentJurisDates.Dock = DockStyle.Fill
                .grdPatentJurisDates.RootTable.HeaderLines = 3
                .grdPatentMasterDates.Visible = False
                .grdPatentJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
                .chkSetPatentRecur.Visible = True
                .btnPatentJurisdiction.Visible = True
                .btnAddPatentDates.Visible = False
                .grdPatentTreatyJurisdictions.Visible = False
                .cboPatentJurisdiction.Visible = True
                .btnPatentJurisdiction.Visible = True
                .cboPatentType.Left = 739
                .btnPatentType.Left = 761
            End With

            With Me.grdPatentJurisDates.RootTable
                .Columns("StatusID").Visible = True
                .Columns("IsRelative").Visible = True
                .Columns("AlwaysAddRelative").Visible = True
                .Columns("IntervalNumber").Visible = Not (Me.chkSetPatentRecur.Checked)
                .Columns("IntervalType").Visible = Not (Me.chkSetPatentRecur.Checked)
                .Columns("OtherDateID").Visible = Not (Me.chkSetPatentRecur.Checked)
                .Columns("IntervalAdjust").Visible = Not (Me.chkSetPatentRecur.Checked)
                .Columns("CanRecur").Visible = (Me.chkSetPatentRecur.Checked)
                .Columns("RecursAtInterval").Visible = (Me.chkSetPatentRecur.Checked)
                .Columns("RecurIntervalNumber").Visible = (Me.chkSetPatentRecur.Checked)
                .Columns("RecurIntervalType").Visible = (Me.chkSetPatentRecur.Checked)
                .Columns("RecurAdjust").Visible = (Me.chkSetPatentRecur.Checked)
                .Columns("lnkBatchUpdate").Visible = True
                .Columns("lnkEmail").Visible = False
                .Columns("lnkDelete").Visible = False
            End With
            FillPatentTypes()

        End If

        'Reorder Dates
        If Me.optPatentReorder.Checked = True Then

            With Me.grdPatentTreatyJurisdictions
                .Left = 900
                .Width = 100
                .Visible = False
            End With

            With Me
                .grdPatentJurisDates.Dock = DockStyle.None
                .grdPatentJurisDates.Left = 593
                .grdPatentJurisDates.Width = 278
                .grdPatentJurisDates.Height = 483
                .grdPatentJurisDates.RootTable.HeaderLines = 2
                .grdPatentMasterDates.Visible = True
                .grdPatentJurisDates.Visible = True
                .grdPatentMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                .grdPatentMasterDates.AllowDrop = True
                .grdPatentJurisDates.AllowDrop = True
                .grdPatentJurisDates.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .chkSetPatentRecur.Visible = False
                .btnAddPatentDates.Visible = False
                .btnPatentJurisdiction.Visible = True
                .cboPatentJurisdiction.Visible = True
                .btnPatentJurisdiction.Visible = True
                .cboPatentType.Left = 739
                .btnPatentType.Left = 761
            End With

            With Me.grdPatentJurisDates.RootTable
                .Columns("StatusID").Visible = False
                .Columns("IsRelative").Visible = False
                .Columns("AlwaysAddRelative").Visible = False
                .Columns("IntervalNumber").Visible = False
                .Columns("IntervalType").Visible = False
                .Columns("OtherDateID").Visible = False
                .Columns("IntervalAdjust").Visible = False
                .Columns("CanRecur").Visible = False
                .Columns("RecursAtInterval").Visible = False
                .Columns("RecurIntervalNumber").Visible = False
                .Columns("RecurIntervalType").Visible = False
                .Columns("RecurAdjust").Visible = False
                .Columns("lnkBatchUpdate").Visible = False
                .Columns("lnkEmail").Visible = True
                .Columns("lnkDelete").Visible = True
            End With
            FillPatentTypes()

        End If

        'SETTING WHICH JURISDICTIONS PARTCIPATE IN TREATIES
        If Me.optPatentTreaty.Checked = True Then
            With Me
                .chkSetPatentRecur.Visible = False
                .grdPatentJurisDates.Visible = False
                .grdPatentMasterDates.Visible = False
                .cboPatentJurisdiction.Visible = False
                .grdPatentTreatyJurisdictions.Visible = False
                .btnPatentJurisdiction.Visible = False
                .cboPatentType.Left = 450
                .btnPatentType.Left = 472
            End With

            With Me.grdPatentTreatyJurisdictions
                .Left = 386
                .Width = 261
                .Visible = True
            End With
            FillPatentTypes()
        End If

        Dim bOrder As Boolean
        bOrder = Me.optPatentReorder.Checked

        With Me.grdPatentJurisDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
        End With

        With Me.grdPatentMasterDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
        End With

    End Sub

    Private Sub optPatentMasterDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatentMasterDates.CheckedChanged
        On Error Resume Next
        If Me.optPatentMasterDates.Checked Then
            SetPatentOptions()
        Else
            LockAndLoadPatentMasterDates()
        End If
    End Sub

    Private Sub optPatentJurisDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatentJurisDates.CheckedChanged
        On Error Resume Next
        If Me.optPatentJurisDates.Checked Then
            SetPatentOptions()
        Else
            LockAndLoadPatentJurisDates()
        End If
    End Sub

    Private Sub optPatentTreaty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatentTreaty.CheckedChanged
        On Error Resume Next
        If Me.optPatentTreaty.Checked Then
            'to clean up that issue with null boxes looking checked
            DataStuff.RunSQL("update tblPatentTreatyJurisdictions set IsParticipant = 0 where IsParticipant is null")
            SetPatentOptions()
        End If
    End Sub

    Private Sub optPatentCopyDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatentCopyDates.CheckedChanged
        If Me.optPatentCopyDates.Checked Then
            SetPatentOptions()
        Else
            LockAndLoadPatentJurisDates()
        End If
    End Sub

    Private Sub optPatentReorder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatentReorder.CheckedChanged
        If Me.optPatentReorder.Checked Then
            SetPatentOptions()
        Else
            LockAndLoadPatentJurisDates()
            LockAndLoadPatentMasterDates()
        End If
    End Sub

    Private Sub btnPatentJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentJurisdiction.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(5)
        f.ShowDialog(Me)
        f = Nothing
    End Sub


#Region "Patent Master Dates"

    Private Sub GetPatentMasterDates()
        On Error Resume Next
        Dim strSQL As String
        rsPatentDates.GetFromSQL("Select * from tblPatentDatesTemplate")
        Me.grdPatentMasterDates.DataSource = rsPatentDates.Table

    End Sub

    Private Sub LockAndLoadPatentMasterDates()
        On Error Resume Next
        Dim iRow As Integer, iTop As Integer
        With Me.grdPatentMasterDates
            iRow = .Row
            iTop = .FirstRow
            .UpdateData()
            rsPatentDates.Update()
            GetPatentMasterDates()
            .Row = iRow
            .FirstRow = iTop
        End With
    End Sub

    Private Sub grdPatentMasterDates_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdPatentMasterDates.DragDrop
        On Error Resume Next
        Dim rowDrop As Integer = grdPatentMasterDates.RowPositionFromPoint()
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        'becuz dropping below last row produces a negative number
        If rowDrop < 0 Then rowDrop = Me.grdPatentMasterDates.RowCount + 1
        'because the grid is zero-based
        rowDrop = rowDrop + 1
        Dim iCurrentOrder As Integer, iSmallestOrder As Integer, i As Integer

        iSmallestOrder = 9999
        For i = 0 To Me.grdPatentMasterDates.SelectedItems.Count - 1
            GRow = Me.grdPatentMasterDates.SelectedItems(i).GetRow
            If GRow.Cells("ListOrder").Value < iSmallestOrder Then
                iSmallestOrder = GRow.Cells("ListOrder").Value
            End If
        Next

        For Each GRow In Me.grdPatentMasterDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                iCurrentOrder = GRow.Cells("ListOrder").Value
                GRow.BeginEdit()

                If GRow.Selected Then
                    GRow.Cells("ListOrder").Value = (iCurrentOrder - iSmallestOrder + rowDrop)
                Else
                    If iCurrentOrder >= rowDrop Then
                        GRow.Cells("ListOrder").Value = (iCurrentOrder + 10000)
                    End If
                End If
                GRow.EndEdit()
            End If
        Next

        ReOrderPatentMasterDates()
        rsPatentDates.Update()

    End Sub

    Private Sub grdPatentMasterDates_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdPatentMasterDates.DragOver
        On Error Resume Next
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub grdPatentMasterDates_RowDrag(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowDragEventArgs) Handles grdPatentMasterDates.RowDrag
        On Error Resume Next
        Dim MoveDateID As Object = 0  'DoDragDrop won't work without an object
        Me.grdPatentMasterDates.DoDragDrop(MoveDateID, DragDropEffects.Move)
    End Sub


    Private Sub grdPatentMasterDates_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdPatentMasterDates.AddingRecord
        On Error Resume Next
        Dim iListOrder As Integer
        'apparently the grid counts header rows
        iListOrder = Me.grdPatentMasterDates.RowCount - 1
        Me.grdPatentMasterDates.SetValue("ListOrder", iListOrder)
    End Sub

    Private Sub grdPatentMasterDates_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentMasterDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim iDateID As Integer
            iDateID = Me.grdPatentMasterDates.GetValue("DateID")

            If DataStuff.DCount("DateID", "tblPatentJurisdictionDates", "DateID=" & iDateID) > 0 Then
                MsgBox("You cannot delete a date that has been applied to a Jurisdiction.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdPatentMasterDates.CurrentRow.Delete()
            ReOrderPatentMasterDates()
            rsPatentDates.Update()

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdPatentMasterDates.GetValue("ListOrder")
            iDateID = Me.grdPatentMasterDates.GetValue("DateID")

            If iCurrentOrder > 1 Then
                For Each dr As DataRow In rsPatentDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder - 1
                    Else
                        If dr("ListOrder") = iCurrentOrder - 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If

        End If

        If e.Column.Key = "MoveDown" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdPatentMasterDates.GetValue("ListOrder")
            iDateID = Me.grdPatentMasterDates.GetValue("DateID")

            If iCurrentOrder < Me.grdPatentMasterDates.RowCount Then
                For Each dr As DataRow In rsPatentDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder + 1
                    Else
                        If dr("ListOrder") = iCurrentOrder + 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If
        End If

        If e.Column.Key = "lnkEmail" Then
            On Error Resume Next
            'to make sure we have a true DateID in grid
            LockAndLoadPatentMasterDates()
            AllForms.OpenMergeHelper()

            AllForms.OpenMergeHelper()
            With AllForms.frmMergeHelper
                .MergeStatus = frmMergeHelper.mStatus.PatentAlertDate
                .DateID = Me.grdPatentMasterDates.GetValue("DateID")
                .lblDateName.Visible = True
                .lblDateName.Text = "Alert Email for " & Me.grdPatentMasterDates.GetValue("DateName")
                .SetOptions()
            End With
        End If

    End Sub

    Private Sub grdPatentMasterDates_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPatentMasterDates.RecordAdded
        On Error Resume Next
        rsPatentDates.Update()
    End Sub

    Private Sub grdPatentMasterDates_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPatentMasterDates.RecordUpdated
        On Error Resume Next
        rsPatentDates.Update()
    End Sub

    Private Sub ReOrderPatentMasterDates()
        On Error Resume Next
        Dim iListOrder As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        iListOrder = 1
        For Each GRow In Me.grdPatentMasterDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("ListOrder").Value = iListOrder
                GRow.EndEdit()
                iListOrder = iListOrder + 1
            End If
        Next
    End Sub

    Private Sub btnAddPatentDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPatentDates.Click
        On Error Resume Next
        Dim iJurisdictionID As Integer, iPatentTypeID As Integer, GRow As Janus.Windows.GridEX.GridEXRow, _
        i As Integer, strSQL As String, iDateID As Integer, strFilter As String

        iJurisdictionID = Me.cboPatentJurisdiction.Value
        iPatentTypeID = Me.cboPatentType.Value

        If Not (iJurisdictionID > 0) Then
            MsgBox("You must select the jurisdiction and patent type first.")
            Exit Sub
        End If

        If Not (iPatentTypeID > 0) Then
            MsgBox("You must select the jurisdiction and patent type first.")
            Exit Sub
        End If

        'don't bother if nothing is selected
        If Me.grdPatentMasterDates.SelectedItems.Count < 1 Then
            MsgBox("You must select dates to add first.")
            Exit Sub
        End If

        strSQL = "Select * from tblPatentJurisdictionDates where JurisdictionID=" & iJurisdictionID & _
            " and PatentTypeID=" & iPatentTypeID
        rsPatentJurisDates.GetFromSQL(strSQL)

        For i = 0 To Me.grdPatentMasterDates.SelectedItems.Count - 1
            GRow = Me.grdPatentMasterDates.SelectedItems(i).GetRow
            iDateID = GRow.Cells("DateID").Value
            'make sure real date is selected
            If iDateID <> 0 Then
                'make sure it doesn't already exist
                strFilter = "DateID=" & iDateID
                If rsPatentJurisDates.RecordExists(strFilter) = False Then
                    rsPatentJurisDates.AddRow()
                    'final precaution, make sure it's a new row
                    If rsPatentJurisDates.CurrentRow("DateID").ToString = "" Then
                        rsPatentJurisDates.CurrentRow("DateID") = iDateID
                        rsPatentJurisDates.CurrentRow("JurisdictionID") = iJurisdictionID
                        rsPatentJurisDates.CurrentRow("PatentTypeID") = iPatentTypeID
                        rsPatentJurisDates.CurrentRow("ListOrder") = GRow.Cells("ListOrder").Value
                        rsPatentJurisDates.CurrentRow("IsRelative") = False
                        rsPatentJurisDates.CurrentRow("AlwaysAddRelative") = False
                        rsPatentJurisDates.CurrentRow("CanRecur") = False
                        rsPatentJurisDates.CurrentRow("RecursAtInterval") = False
                    End If
                End If
            End If
        Next i

        'full lock and load shouldn't be necessary ... and yet it is.
        LockAndLoadPatentJurisDates()
        ReOrderPatentJurisDates()
        LockAndLoadPatentJurisDates()
        Me.grdPatentMasterDates.SelectedItems.Clear()


    End Sub

#End Region

#Region "Patent Jurisdiction Dates"

    Friend Sub GetPatentJurisDates()
        On Error Resume Next
        Dim strSQL As String, iJurisdictionID As Integer, iPatentTypeID As Integer, drOtherDates As OleDb.OleDbDataReader

        iJurisdictionID = Me.cboPatentJurisdiction.Value
        iPatentTypeID = Me.cboPatentType.Value

        strSQL = "Select *, (Select DateName from tblPatentDatesTemplate where DateID = tblPatentJurisdictionDates.DateID) as DateName " & _
            "from tblPatentJurisdictionDates where JurisdictionID=" & iJurisdictionID & " and PatentTypeID=" & iPatentTypeID
        rsPatentJurisDates.GetFromSQL(strSQL)
        Me.grdPatentJurisDates.DataSource = rsPatentJurisDates.Table

        'datareader to bind drop-down for related dates
        strSQL = "Select DateID, DateName, ListOrder from tblPatentDatesTemplate where DateID in (" & _
            "Select DateID from tblPatentJurisdictionDates where JurisdictionID=" & iJurisdictionID & _
            " and PatentTypeID=" & iPatentTypeID & ")"
        strSQL = strSQL & " UNION Select 0, '(None)', -1 from tblPatentDatesTemplate order by ListOrder"

        drOtherDates = DataStuff.GetDataReader(strSQL)
        Me.grdPatentJurisDates.RootTable.Columns("OtherDateID").ValueList.PopulateValueList(drOtherDates, "DateID", "DateName")

    End Sub

    Private Sub LockAndLoadPatentJurisDates()
        On Error Resume Next
        Dim iRow As Integer, iTop As Integer
        With Me.grdPatentJurisDates
            iRow = .Row
            iTop = .FirstRow
            .UpdateData()
            rsPatentJurisDates.Update()
            GetPatentJurisDates()
            .Row = iRow
            .FirstRow = iTop
        End With

    End Sub

    Private Sub cboPatentJurisdiction_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatentJurisdiction.ValueChanged
        On Error Resume Next
        GetPatentJurisDates()
    End Sub

    Private Sub cboPatentType_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatentType.ValueChanged
        On Error Resume Next
        If Me.optPatentTreaty.Checked = True Then
            Dim iPatentTypeID As Integer, strSQL As String
            iPatentTypeID = Me.cboPatentType.Value
            strSQL = "Select * from qvwPatentTreatyJurisdictions where PatentTypeID=" & iPatentTypeID
            dtPatentTreatyJurisdictions = DataStuff.GetDataTable(strSQL)
            Me.grdPatentTreatyJurisdictions.DataSource = dtPatentTreatyJurisdictions

            Me.grdPatentTreatyJurisdictions.FirstRow = 0
        Else
            GetPatentJurisDates()
        End If
    End Sub

    Private Sub grdPatentJurisDates_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentJurisDates.CellValueChanged
        On Error Resume Next
        'if it's not relative, clear the other options
        If e.Column.Key = "IsRelative" And Me.grdPatentJurisDates.GetValue("IsRelative") = False Then
            With Me.grdPatentJurisDates
                .SetValue("AlwaysAddRelative", False)
                .SetValue("IntervalNumber", DBNull.Value)
                .SetValue("IntervalType", DBNull.Value)
                .SetValue("OtherDateID", DBNull.Value)
                .SetValue("IntervalAdjust", DBNull.Value)
            End With
        End If

        If e.Column.Key = "CanRecur" And Me.grdPatentJurisDates.GetValue("CanRecur") = False Then
            With Me.grdPatentJurisDates
                .SetValue("RecursAtInterval", False)
                .SetValue("RecurIntervalNumber", DBNull.Value)
                .SetValue("RecurIntervalType", DBNull.Value)
                .SetValue("RecurAdjust", DBNull.Value)
            End With
        End If

        If e.Column.Key = "RecursAtInterval" And Me.grdPatentJurisDates.GetValue("RecursAtInterval") = False Then
            With Me.grdPatentJurisDates
                .SetValue("RecurIntervalNumber", DBNull.Value)
                .SetValue("RecurIntervalType", DBNull.Value)
                .SetValue("RecurAdjust", DBNull.Value)
            End With
        End If

    End Sub

    Friend Sub ReOrderPatentJurisDates()
        On Error Resume Next
        Dim iListOrder As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        iListOrder = 1
        For Each GRow In Me.grdPatentJurisDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("ListOrder").Value = iListOrder
                GRow.EndEdit()
                iListOrder = iListOrder + 1
            End If
        Next
    End Sub

    Private Sub grdPatentJurisDates_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdPatentJurisDates.DragDrop
        On Error Resume Next
        Dim rowDrop As Integer = grdPatentJurisDates.RowPositionFromPoint()
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        'becuz dropping below last row produces a negative number
        If rowDrop < 0 Then rowDrop = Me.grdPatentJurisDates.RowCount + 1
        'because the grid is zero-based
        rowDrop = rowDrop + 1
        Dim iCurrentOrder As Integer, iSmallestOrder As Integer, i As Integer

        iSmallestOrder = 9999
        For i = 0 To Me.grdPatentJurisDates.SelectedItems.Count - 1
            GRow = Me.grdPatentJurisDates.SelectedItems(i).GetRow
            If GRow.Cells("ListOrder").Value < iSmallestOrder Then
                iSmallestOrder = GRow.Cells("ListOrder").Value
            End If
        Next

        For Each GRow In Me.grdPatentJurisDates.GetRows
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                iCurrentOrder = GRow.Cells("ListOrder").Value
                GRow.BeginEdit()

                If GRow.Selected Then
                    GRow.Cells("ListOrder").Value = (iCurrentOrder - iSmallestOrder + rowDrop)
                Else
                    If iCurrentOrder >= rowDrop Then
                        GRow.Cells("ListOrder").Value = (iCurrentOrder + 10000)
                    End If
                End If
                GRow.EndEdit()
            End If
        Next

        ReOrderPatentJurisDates()
        rsPatentJurisDates.Update()

    End Sub

    Private Sub grdPatentJurisDates_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdPatentJurisDates.DragOver
        On Error Resume Next
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub grdPatentJurisDates_RowDrag(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowDragEventArgs) Handles grdPatentJurisDates.RowDrag
        On Error Resume Next
        Dim MoveDateID As Object = 0  'DoDragDrop won't work without an object
        Me.grdPatentJurisDates.DoDragDrop(MoveDateID, DragDropEffects.Move)
    End Sub

    Private Sub grdPatentJurisDates_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPatentJurisDates.RecordUpdated
        On Error Resume Next
        ' rsPatentJurisDates.Update()
    End Sub

    Private Sub grdPatentJurisDates_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentJurisDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iJurisdictionDateID As Integer
            iJurisdictionDateID = Me.grdPatentJurisDates.GetValue("JurisdictionDateID")

            If DataStuff.DCount("JurisdictionDateID", "tblPatentDates", "JurisdictionDateID=" & iJurisdictionDateID) > 0 Then
                MsgBox("You cannot delete a date that has been applied to a Patent.")
                Exit Sub
            End If


            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date from the jurisdiction?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdPatentJurisDates.CurrentRow.Delete()
            ReOrderPatentJurisDates()
            rsPatentJurisDates.Update()

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdPatentJurisDates.GetValue("ListOrder")
            iDateID = Me.grdPatentJurisDates.GetValue("DateID")

            If iCurrentOrder > 1 Then
                For Each dr As DataRow In rsPatentJurisDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder - 1
                    Else
                        If dr("ListOrder") = iCurrentOrder - 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If
        End If

        If e.Column.Key = "MoveDown" Then
            Dim iCurrentOrder As Integer, iDateID As Integer
            iCurrentOrder = Me.grdPatentJurisDates.GetValue("ListOrder")
            iDateID = Me.grdPatentJurisDates.GetValue("DateID")

            If iCurrentOrder < Me.grdPatentJurisDates.RowCount Then
                For Each dr As DataRow In rsPatentJurisDates.Table.Rows
                    If dr("DateID") = iDateID Then
                        dr("ListOrder") = iCurrentOrder + 1
                    Else
                        If dr("ListOrder") = iCurrentOrder + 1 Then
                            dr("ListOrder") = iCurrentOrder
                        End If
                    End If
                Next
            End If
        End If

        If (e.Column.Key = "lnkBatchUpdate") And (Globals.SecurityLevel < 3) Then
            Dim strMessage As String, iJurisdictionID As Integer, iPatentTypeID As Integer, iDateID As Integer

            strMessage = "This will update the selected date throughout the database.  Dates marked as " & _
                "completed will not be affected.  Proceed?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            Me.grdPatentJurisDates.UpdateData()
            iJurisdictionID = Me.cboPatentJurisdiction.Value
            iPatentTypeID = Me.grdPatentJurisDates.GetValue("PatentTypeID")
            iDateID = Me.grdPatentJurisDates.GetValue("DateID")
            Dim PD As New PatentDates
            PD.BatchUpdate(iJurisdictionID, iPatentTypeID, iDateID)
            PD = Nothing
            Me.Cursor = Cursors.Default

        End If

        If (e.Column.Key = "lnkEmail") And (Globals.SecurityLevel < 3) Then
            On Error Resume Next
            AllForms.OpenMergeHelper()
            With AllForms.frmMergeHelper
                .MergeStatus = frmMergeHelper.mStatus.PatentJurisDate
                .JurisdictionDateID = Me.grdPatentJurisDates.GetValue("JurisdictionDateID")
                .lblDateName.Visible = True
                .lblDateName.Text = "Email for " & Me.grdPatentJurisDates.GetValue("DateName")
                .SetOptions()
            End With
        End If

    End Sub

    Private Sub grdPatentJurisDates_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentJurisDates.Resize
        On Error Resume Next
        With Me.grdPatentJurisDates
            If .Dock = DockStyle.Fill Then
                .RootTable.Columns("DateName").Width = .Width - 875
            Else
                .RootTable.Columns("DateName").Width = 155
            End If
        End With
    End Sub

    Private Sub chkSetPatentRecur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSetPatentRecur.CheckedChanged
        On Error Resume Next
        SetPatentOptions()
    End Sub


#End Region

#Region "Patent Treaty Jurisdictions"

    Private Sub grdPatentTreatyJurisdictions_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPatentTreatyJurisdictions.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iTreatyJurisID As Integer

        With Me.grdPatentTreatyJurisdictions
            iTreatyJurisID = .GetValue("TreatyJurisID")
            rsRecord.GetFromSQL("Select * from tblPatentTreatyJurisdictions where TreatyJurisID=" & iTreatyJurisID)
            dRow = rsRecord.CurrentRow
            dRow("IsParticipant") = IIf(.GetValue("IsParticipant") = True, True, False)
        End With

        rsRecord.Update()

    End Sub

#End Region

#End Region

#Region "Settings"

    Private Sub GetFolderPreferences()
        On Error Resume Next
        If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
            With Me
                .TrademarkDocs.Text = My.Settings.TrademarkDocumentsDemo
                .TrademarkGraphics.Text = My.Settings.TrademarkGraphicsDemo
                .PatentDocs.Text = My.Settings.PatentDocumentsDemo
                .PatentGraphics.Text = My.Settings.PatentGraphicsDemo
                .ReportIcon.Text = My.Settings.ReportIconDemo
            End With
        Else
            With Me
                .TrademarkDocs.Text = My.Settings.TrademarkDocuments
                .TrademarkGraphics.Text = My.Settings.TrademarkGraphics
                .PatentDocs.Text = My.Settings.PatentDocuments
                .PatentGraphics.Text = My.Settings.PatentGraphics
                .ReportIcon.Text = My.Settings.ReportIcon
            End With
        End If

    End Sub

    Private Sub btnTrademarkDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrademarkDocs.Click
        On Error Resume Next
        Dim strFolder As String
        With Me.FolderBrowserDialog
            .SelectedPath = Application.StartupPath
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                strFolder = .SelectedPath
                Me.TrademarkDocs.Text = strFolder
                With My.Settings
                    If .CurrentConnection = .AccessConnection Then
                        .TrademarkDocumentsDemo = strFolder
                    Else
                        .TrademarkDocuments = strFolder
                    End If
                End With
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub btnTrademarkGraphics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrademarkGraphics.Click
        On Error Resume Next
        Dim strFolder As String
        With Me.FolderBrowserDialog
            .SelectedPath = Application.StartupPath
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                strFolder = .SelectedPath
                Me.TrademarkGraphics.Text = strFolder
                With My.Settings
                    If .CurrentConnection = .AccessConnection Then
                        .TrademarkGraphicsDemo = strFolder
                    Else
                        .TrademarkGraphics = strFolder
                    End If
                End With
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub btnPatentDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentDocs.Click
        On Error Resume Next
        Dim strFolder As String
        With Me.FolderBrowserDialog
            .SelectedPath = Application.StartupPath
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                strFolder = .SelectedPath
                Me.PatentDocs.Text = strFolder
                With My.Settings
                    If .CurrentConnection = .AccessConnection Then
                        .PatentDocumentsDemo = strFolder
                    Else
                        .PatentDocuments = strFolder
                    End If
                End With
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub btnPatentGraphics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentGraphics.Click
        On Error Resume Next
        Dim strFolder As String
        With Me.FolderBrowserDialog
            .SelectedPath = Application.StartupPath
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                strFolder = .SelectedPath
                Me.PatentGraphics.Text = strFolder
                With My.Settings
                    If .CurrentConnection = .AccessConnection Then
                        .PatentGraphicsDemo = strFolder
                    Else
                        .PatentGraphics = strFolder
                    End If
                End With
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub optOpenTrademarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOpenTrademarks.CheckedChanged
        On Error Resume Next
        SaveOpenSetting()
    End Sub

    Private Sub optOpenPatents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOpenPatents.CheckedChanged
        On Error Resume Next
        SaveOpenSetting()
    End Sub

    Private Sub optUSDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUSDates.CheckedChanged
        On Error Resume Next
        SaveDateSettings()
    End Sub

    Private Sub optEuroDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEuroDates.CheckedChanged
        On Error Resume Next
        SaveDateSettings()
    End Sub

    Private Sub SaveOpenSetting()
        On Error Resume Next
        If Me.optOpenTrademarks.Checked = True Then
            My.Settings.OpenOnMarks = True
        End If
        If Me.optOpenPatents.Checked = True Then
            My.Settings.OpenOnMarks = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub SaveFolderLocations()
        On Error Resume Next
        ' This is new, since we're now allowing users to type in folder locations in addition to navigating to them.
        With Me
            If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                My.Settings.TrademarkDocumentsDemo = Me.TrademarkDocs.Text
                My.Settings.TrademarkGraphicsDemo = Me.TrademarkGraphics.Text
                My.Settings.PatentDocumentsDemo = Me.PatentDocs.Text
                My.Settings.PatentGraphicsDemo = Me.PatentGraphics.Text
                My.Settings.ReportIconDemo = Me.ReportIcon.Text
            Else
                My.Settings.TrademarkDocuments = Me.TrademarkDocs.Text
                My.Settings.TrademarkGraphics = Me.TrademarkGraphics.Text
                My.Settings.PatentDocuments = Me.PatentDocs.Text
                My.Settings.PatentGraphics = Me.PatentGraphics.Text
                My.Settings.ReportIcon = Me.ReportIcon.Text
            End If
        End With
        My.Settings.Save()
    End Sub

    Private Sub SaveDateSettings()
        On Error Resume Next
        If Me.optEuroDates.Checked = True Then
            My.Settings.USADates = False
        End If
        If Me.optUSDates.Checked = True Then
            My.Settings.USADates = True
        End If

        My.Settings.Save()
        If Not (AllForms.frmTrademarks Is Nothing) Then
            With AllForms.frmTrademarks
                If My.Settings.USADates = True Then
                    .grdDates.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                    .grdAlerts.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                    .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "MMM dd, yyyy"
                    .grdStatusCheck.RootTable.Columns("DateRecorded").FormatString = "MMM dd, yyyy"
                    .grdStatusCheck.RootTable.Columns("StatusDate").FormatString = "MMM dd, yyyy"
                Else
                    .grdDates.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                    .grdAlerts.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                    .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "dd MMM yyyy"
                    .grdStatusCheck.RootTable.Columns("DateRecorded").FormatString = "dd MMM yyyy"
                    .grdStatusCheck.RootTable.Columns("StatusDate").FormatString = "dd MMM yyyy"
                End If
            End With
        End If


        If Not (AllForms.frmPatents Is Nothing) Then
            With AllForms.frmPatents
                If My.Settings.USADates = True Then
                    .grdDates.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
                    .grdAlerts.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
                    .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "MMM dd, yyyy"
                Else
                    .grdDates.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
                    .grdAlerts.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
                    .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "dd MMM yyyy"
                End If
            End With
        End If

    End Sub

    Private Sub chkSpellMonth_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSpellMonth.Validated
        On Error Resume Next
        If Me.chkSpellMonth.Checked = True Then
            My.Settings.SpellMonthMerge = True
        Else
            My.Settings.SpellMonthMerge = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub chkBlankDatesLast_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBlankDatesLast.Validated
        On Error Resume Next
        If Me.chkBlankDatesLast.Checked = True Then
            My.Settings.BlankDatesLast = True
        Else
            My.Settings.BlankDatesLast = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub chkEmailHTML_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmailHTML.Validated
        On Error Resume Next
        If Me.chkEmailHTML.Checked = True Then
            My.Settings.EmailHTML = True
        Else
            My.Settings.EmailHTML = False
        End If
    End Sub

    Private Sub chkHoursExpenses_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHoursExpenses.Validated
        On Error Resume Next
        If Me.chkHoursExpenses.Checked = True Then
            My.Settings.ShowHoursExpenses = True
        Else
            My.Settings.ShowHoursExpenses = False
        End If
        My.Settings.Save()

        If Not (AllForms.frmTrademarks Is Nothing) Then
            AllForms.frmTrademarks.SetOptions()
        End If

        If Not (AllForms.frmPatents Is Nothing) Then
            AllForms.frmPatents.SetOptions()
        End If

    End Sub

    Private Sub btnReportIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportIcon.Click
        On Error Resume Next
        With Me.OpenFileDialog
            .Filter = "All Files (*.*)|*.*"
            .FileName = ""
            .Title = "Select the Report Icon File"
            .InitialDirectory = Application.ExecutablePath
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.ReportIcon.Text = .FileName
                If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                    My.Settings.ReportIconDemo = .FileName
                Else
                    My.Settings.ReportIcon = .FileName
                End If
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub cboOutlookAlertTime_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOutlookAlertTime.Validated
        On Error Resume Next
        My.Settings.OutlookAlertTime = Me.cboOutlookAlertTime.SelectedValue
        My.Settings.Save()
    End Sub

#End Region

#Region "Web Links"

    Friend Sub FillWebLinks()
        On Error Resume Next
        Dim strSQL As String

        strSQL = "Select * from tblPatentTypes where IsTreaty <> 0"
        dtPatentTreatyLinks = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblJurisdictions where IsPatent <> 0"
        dtPatentLinks = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblFilingBasis where IsTreaty <> 0"
        dtMarkTreatyLinks = DataStuff.GetDataTable(strSQL)

        strSQL = "Select * from tblJurisdictions where IsTrademark <> 0"
        dtMarkLinks = DataStuff.GetDataTable(strSQL)


        With Me
            .grdPatentTreatyLinks.DataSource = dtPatentTreatyLinks
            .grdPatentLinks.DataSource = dtPatentLinks
            .grdMarkTreatyLinks.DataSource = dtMarkTreatyLinks
            .grdMarkLinks.DataSource = dtMarkLinks
        End With

    End Sub

    Private Sub chkEnableEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableEdit.CheckedChanged
        On Error Resume Next
        With Me
            .grdPatentTreatyLinks.Enabled = .chkEnableEdit.Checked
            .grdPatentLinks.Enabled = .chkEnableEdit.Checked
            .grdMarkTreatyLinks.Enabled = .chkEnableEdit.Checked
            .grdMarkLinks.Enabled = .chkEnableEdit.Checked
            .optLinksMarks.Enabled = .chkEnableEdit.Checked
            .optLinksPatents.Enabled = .chkEnableEdit.Checked
        End With

    End Sub

    Private Sub optLinksMarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLinksMarks.CheckedChanged
        On Error Resume Next
        If Me.optLinksMarks.Checked = True Then SetWebLinks()
    End Sub

    Private Sub optLinksPatents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLinksPatents.CheckedChanged
        On Error Resume Next
        If Me.optLinksPatents.Checked = True Then SetWebLinks()
    End Sub

    Private Sub SetWebLinks()
        On Error Resume Next
        With Me
            .grdMarkLinks.Visible = (.optLinksMarks.Checked = True)
            .grdMarkTreatyLinks.Visible = (.optLinksMarks.Checked = True)
            .grdPatentLinks.Visible = (.optLinksPatents.Checked = True)
            .grdPatentTreatyLinks.Visible = (.optLinksPatents.Checked = True)

            If .optLinksMarks.Checked = True Then
                .grdMarkLinks.Left = 19
                .grdMarkLinks.Top = 121
                .grdMarkLinks.Width = 920
                .grdMarkLinks.Height = 308
                .grdMarkTreatyLinks.Left = 19
                .grdMarkTreatyLinks.Top = 41
                .grdMarkTreatyLinks.Width = 920
                .grdMarkTreatyLinks.Height = 73
            End If

            If .optLinksPatents.Checked = True Then
                .grdPatentLinks.Left = 19
                .grdPatentLinks.Top = 121
                .grdPatentLinks.Width = 920
                .grdPatentLinks.Height = 308
                .grdPatentTreatyLinks.Left = 19
                .grdPatentTreatyLinks.Top = 41
                .grdPatentTreatyLinks.Width = 920
                .grdPatentTreatyLinks.Height = 73
            End If

        End With
    End Sub

    Private Sub grdMarkTreatyLinks_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarkTreatyLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iFilingBasisID As Integer

        With Me.grdMarkTreatyLinks
            iFilingBasisID = .GetValue("FilingBasisID")
            rsRecord.GetFromSQL("Select * from tblFilingBasis where FilingBasisID=" & iFilingBasisID)
            dRow = rsRecord.CurrentRow
            dRow("ApplicationURL") = .GetValue("ApplicationURL")
            dRow("ApplicationUsesFields") = IIf(.GetValue("ApplicationUsesFields") = True, True, False)
            dRow("ApplicationNumbersOnly") = IIf(.GetValue("ApplicationNumbersOnly") = True, True, False)
            dRow("ApplicationField") = .GetValue("ApplicationField")
            dRow("RegistrationURL") = .GetValue("RegistrationURL")
            dRow("RegistrationUsesFields") = IIf(.GetValue("RegistrationUsesFields") = True, True, False)
            dRow("RegistrationNumbersOnly") = IIf(.GetValue("RegistrationNumbersOnly") = True, True, False)
            dRow("RegistrationField") = .GetValue("RegistrationField")
        End With

        rsRecord.Update()

    End Sub

    Private Sub grdMarkLinks_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarkLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iJurisdictionID As Integer

        With Me.grdMarkLinks
            iJurisdictionID = .GetValue("JurisdictionID")
            rsRecord.GetFromSQL("Select * from tblJurisdictions where JurisdictionID=" & iJurisdictionID)
            dRow = rsRecord.CurrentRow
            dRow("ApplicationURL") = .GetValue("ApplicationURL")
            dRow("ApplicationUsesFields") = IIf(.GetValue("ApplicationUsesFields") = True, True, False)
            dRow("ApplicationNumbersOnly") = IIf(.GetValue("ApplicationNumbersOnly") = True, True, False)
            dRow("ApplicationField") = .GetValue("ApplicationField")
            dRow("RegistrationURL") = .GetValue("RegistrationURL")
            dRow("RegistrationUsesFields") = IIf(.GetValue("RegistrationUsesFields") = True, True, False)
            dRow("RegistrationNumbersOnly") = IIf(.GetValue("RegistrationNumbersOnly") = True, True, False)
            dRow("RegistrationField") = .GetValue("RegistrationField")
            dRow("OppositionURL") = .GetValue("OppositionURL")
            dRow("OppositionUsesFields") = IIf(.GetValue("OppositionUsesFields") = True, True, False)
            dRow("OppositionNumbersOnly") = IIf(.GetValue("OppositionNumbersOnly") = True, True, False)
            dRow("OppositionField") = .GetValue("OppositionField")
        End With

        rsRecord.Update()

    End Sub

    Private Sub grdPatentTreatyLinks_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentTreatyLinks.RecordUpdated
        On Error Resume Next

        Dim rsRecord As New RecordSet, dRow As DataRow, iPatentTypeID As Integer

        With Me.grdPatentTreatyLinks
            iPatentTypeID = .GetValue("PatentTypeID")
            rsRecord.GetFromSQL("Select * from tblPatentTypes where PatentTypeID=" & iPatentTypeID)
            dRow = rsRecord.CurrentRow
            dRow("ApplicationURL") = .GetValue("ApplicationURL")
            dRow("ApplicationUsesFields") = IIf(.GetValue("ApplicationUsesFields") = True, True, False)
            dRow("ApplicationNumbersOnly") = IIf(.GetValue("ApplicationNumbersOnly") = True, True, False)
            dRow("ApplicationField") = .GetValue("ApplicationField")
        End With

        rsRecord.Update()
    End Sub

    Private Sub grdPatentLinks_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iJurisdictionID As Integer

        With Me.grdPatentLinks
            iJurisdictionID = .GetValue("JurisdictionID")
            rsRecord.GetFromSQL("Select * from tblJurisdictions where JurisdictionID=" & iJurisdictionID)
            dRow = rsRecord.CurrentRow
            dRow("PatentApplicationURL") = .GetValue("PatentApplicationURL")
            dRow("PatentApplicationUsesFields") = IIf(.GetValue("PatentApplicationUsesFields") = True, True, False)
            dRow("PatentApplicationNumbersOnly") = IIf(.GetValue("PatentApplicationNumbersOnly") = True, True, False)
            dRow("PatentApplicationField") = .GetValue("PatentApplicationField")
            dRow("PatentNumberURL") = .GetValue("PatentNumberURL")
            dRow("PatentNumberUsesFields") = IIf(.GetValue("PatentNumberUsesFields") = True, True, False)
            dRow("PatentNumberNumbersOnly") = IIf(.GetValue("PatentNumberNumbersOnly") = True, True, False)
            dRow("PatentNumberField") = .GetValue("PatentNumberField")
            dRow("PatentPublicationURL") = .GetValue("PatentPublicationURL")
            dRow("PatentPublicationUsesFields") = IIf(.GetValue("PatentPublicationUsesFields") = True, True, False)
            dRow("PatentPublicationNumbersOnly") = IIf(.GetValue("PatentPublicationNumbersOnly") = True, True, False)
            dRow("PatentPublicationField") = .GetValue("PatentPublicationField")
        End With

        rsRecord.Update()
    End Sub

#End Region

#Region "Help Buttons"

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        On Error Resume Next
        Dim f As New frmAbout
        f.Show()
    End Sub

    Private Sub tutAlertsView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutAlertsView.Click
        On Error Resume Next
        Tutorial("AlertsView")
    End Sub

    Private Sub tutOverview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutOverview.Click
        On Error Resume Next
        Tutorial("Overview")
    End Sub

    Private Sub tutPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutPreferences.Click
        On Error Resume Next
        Tutorial("Preferences")
    End Sub

    Private Sub tutSortFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutSortFind.Click
        On Error Resume Next
        Tutorial("SortFind")
    End Sub

    Private Sub tutCreateCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutCreateCompany.Click
        On Error Resume Next
        Tutorial("CompaniesNew")
    End Sub

    Private Sub tutLinkCompanies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutLinkCompanies.Click
        On Error Resume Next
        Tutorial("LinkCompanies")
    End Sub

    Private Sub tutContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutContacts.Click
        On Error Resume Next
        Tutorial("Contacts")
    End Sub

    Private Sub tutImportContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutImportContacts.Click
        On Error Resume Next
        Tutorial("ImportContacts")
    End Sub

    Private Sub tutTrademarkRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutTrademarkRecords.Click
        On Error Resume Next
        Tutorial("NewMarksPatents")
    End Sub

    Private Sub tutSetContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutSetContacts.Click
        On Error Resume Next
        Tutorial("MultipleContacts")
    End Sub

    Private Sub tutWebLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutWebLinks.Click
        On Error Resume Next
        Tutorial("WebLinks")
    End Sub

    Private Sub tutWordMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutWordMerge.Click
        On Error Resume Next
        Tutorial("Merges")
    End Sub

    Private Sub tutAlertEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutAlertEmails.Click
        On Error Resume Next
        Tutorial("EmailAlerts")
    End Sub

    Private Sub tutDateEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutDateEmails.Click
        On Error Resume Next
        Tutorial("DateSpecific")
    End Sub

    Private Sub tutEmailTexts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutEmailTexts.Click
        On Error Resume Next
        Tutorial("EmailText")
    End Sub

    Private Sub tutTrademarkTreaties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutTrademarkTreaties.Click
        On Error Resume Next
        Tutorial("MarkTreatyFilings")
    End Sub

    Private Sub tutStatusCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutStatusCheck.Click
        On Error Resume Next
        Tutorial("MarkStatusCheck")
    End Sub

    Private Sub tutPatentTreaties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutPatentTreaties.Click
        On Error Resume Next
        Tutorial("PatentTreatyFilings")
    End Sub

    Private Sub tutLinkedPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutLinkedPatents.Click
        On Error Resume Next
        Tutorial("LinkedPatents")
    End Sub

    Private Sub tutReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutReports.Click
        On Error Resume Next
        Tutorial("Reports")
    End Sub

    Private Sub tutTrademarkOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutTrademarkOptions.Click
        On Error Resume Next
        Tutorial("MarkDateOptions")
    End Sub

    Private Sub tutPatentOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutPatentOptions.Click
        On Error Resume Next
        Tutorial("PatentDateOptions")
    End Sub

    Private Sub tutTrademarkTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutTrademarkTemplates.Click
        On Error Resume Next
        Tutorial("DateBasics")
    End Sub

    '============= new ones, copy to all ===============================
    Private Sub tutWhatsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutWhatsNew.Click
        On Error Resume Next
        Tutorial("WhatsNew")
    End Sub

    Private Sub tutCustomSpreadsheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutCustomSpreadsheets.Click
        On Error Resume Next
        Tutorial("CustomSpreadsheets")
    End Sub

    Private Sub tutOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tutOppositions.Click
        On Error Resume Next
        Tutorial("Oppositions")
    End Sub

#End Region

   
    
End Class