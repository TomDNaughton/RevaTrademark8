Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmTrademarks

#Region "Declarations"

    'data tables for Grids and Drop-Down lists
    Private dtTrademarksList As DataTable
    Private dtContacts As DataTable
    Private dtMatters As DataTable
    Private dtTrademarkUpdates As DataTable

    Private rsActions As New RecordSet 'new in version 5
    Private rsTrademarkClasses As New RecordSet ' new in version 5
    Private rsTrademarks As New BoundRecordSet
    Private dtDates As DataTable
    Private dtDocLinks As DataTable
    Private dtLicensed As DataTable

    'because lots of stuff shouldn't happen until form is loaded
    Private bFormLoaded As Boolean = False

    'need to store these so we can compare old and new values
    Private iOldJurisdictionID As Integer
    Private iOldFilingBasisID As Integer

    Private iTotalRecords As Integer
    Friend bIsTreaty As Boolean
    Friend bIsBasis As Boolean
    Private bTreatyFilingsFilled As Boolean
    Private FormStatus As Status

    Private Enum Status As Integer
        ResetAll = 0
        Merging = 1
        ShowRelated = 2
    End Enum

#End Region

#Region "Toolbar Buttons"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        If MsgBox("Are you sure want to exit RevaTrademark?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'If bWasEdited = True Then SaveTrademark()
            SaveTrademark()
            
            Application.Exit()
        End If
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        AllForms.OpenLogin()
    End Sub

    Private Sub btnGoToPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToPatents.Click
        On Error Resume Next
        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        AllForms.OpenPatents()
        Me.Close()
    End Sub

    Private Sub btnGoToOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToOppositions.Click
        On Error Resume Next
        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        AllForms.OpenOppositions()
        Me.Close()
    End Sub

    Private Sub btnGoToContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToContacts.Click
        On Error Resume Next
        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        AllForms.OpenCompanies()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        On Error Resume Next
        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        AllForms.OpenReports()
    End Sub

    Private Sub btnPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreferences.Click
        On Error Resume Next
        AllForms.OpenPreferences()
    End Sub

    Private Sub btnPrevRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevRecord.Click
        On Error Resume Next
        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        Me.grdLicensed.UpdateData()
        Me.grdDocumentLinks.UpdateData()

        Select Case Globals.NavigateMarksFrom
            Case 1
                Me.grdList.MovePrevious()
                Globals.TrademarkID = Me.grdList.GetValue("TrademarkID")
                GetTrademark()

            Case 2
                Me.grdAlerts.MovePrevious()
                Globals.TrademarkID = Me.grdAlerts.GetValue("TrademarkID")
                GetTrademark()

            Case 3
                AllForms.frmReports.grdMarks.MovePrevious()
                Globals.TrademarkID = AllForms.frmReports.grdMarks.GetValue("TrademarkID")
                GetTrademark()

            Case 4

            Case 5
                AllForms.frmOppositions.grdClientMarks.MovePrevious()
                Globals.TrademarkID = AllForms.frmOppositions.grdClientMarks.GetValue("TrademarkID")
                GetTrademark()

        End Select
    End Sub

    Private Sub btnNextRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextRecord.Click
        On Error Resume Next

        SaveTrademark()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsTrademarkClasses.Update()
        Me.grdLicensed.UpdateData()
        Me.grdDocumentLinks.UpdateData()

        Select Case Globals.NavigateMarksFrom
            Case 1
                Me.grdList.MoveNext()
                Globals.TrademarkID = Me.grdList.GetValue("TrademarkID")
                GetTrademark()

            Case 2
                Me.grdAlerts.MoveNext()
                Globals.TrademarkID = Me.grdAlerts.GetValue("TrademarkID")
                GetTrademark()

            Case 3
                AllForms.frmReports.grdMarks.MoveNext()
                Globals.TrademarkID = AllForms.frmReports.grdMarks.GetValue("TrademarkID")
                GetTrademark()

            Case 4

            Case 5
                AllForms.frmOppositions.grdClientMarks.MoveNext()
                Globals.TrademarkID = AllForms.frmOppositions.grdClientMarks.GetValue("TrademarkID")
                GetTrademark()

        End Select
    End Sub

#End Region

#Region "Browse Screen"

#Region "Customize List"

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        On Error Resume Next
        With Me
            If .optList.Checked Then
                .grdList.HideFieldChooser()
                .grdList.ShowFieldChooser()
            End If
            If (.optAlerts.Checked) Or (.optEmailAlerts.Checked) Then
                .grdAlerts.HideFieldChooser()
                .grdAlerts.ShowFieldChooser()
            End If
        End With
    End Sub

    Private Sub LoadGridLayouts()
        On Error Resume Next
        With Me
            If .optList.Checked And (My.Settings.TrademarkListLayout.Length > 100) Then
                .grdList.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.TrademarkListLayout))
                ' so filters don't get stuck
                .grdList.RemoveFilters()
            End If

            If .optAlerts.Checked And (My.Settings.TrademarkAlertLayout.Length > 100) Then
                .grdAlerts.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.TrademarkAlertLayout))
                .grdAlerts.RemoveFilters()
            End If

            If .optEmailAlerts.Checked And (My.Settings.TrademarkEmailAlertLayout.Length > 100) Then
                .grdAlerts.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.TrademarkEmailAlertLayout))
                .grdAlerts.RemoveFilters()
            End If

            If (My.Settings.TrademarkStatusLayout.Length > 100) Then
                .grdStatusCheck.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.TrademarkStatusLayout))
                .grdStatusCheck.RemoveFilters()
            End If

        End With

    End Sub

    Private Sub SaveGridLayouts()
        On Error Resume Next
        With Me
            If .optList.Checked Then
                My.Settings.TrademarkListLayout = .grdList.GetLayout.GetXmlString
                
            End If

            If .optAlerts.Checked Then
                My.Settings.TrademarkAlertLayout = .grdAlerts.GetLayout.GetXmlString
                
            End If

            If .optEmailAlerts.Checked Then
                My.Settings.TrademarkEmailAlertLayout = .grdAlerts.GetLayout.GetXmlString
                
            End If

            My.Settings.TrademarkStatusLayout = .grdStatusCheck.GetLayout.GetXmlString
            
        End With

    End Sub

    Private Sub mnuResetGrid_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuResetGrid.ItemClicked
        On Error Resume Next
        With Me
            If .optList.Checked Then
                ResetTrademarksList()
            End If
            If .optAlerts.Checked Then
                ResetAlertsList()
            End If
            If .optEmailAlerts.Checked Then
                ResetEmailAlertsList()
            End If
            If .optSetContacts.Checked Then
                MsgBox("Reset not available in this view.")
            End If
        End With
    End Sub

    Private Sub ResetListColumn(ByVal ColumnKey As String, ByVal iPos As Integer, ByVal iWidth As Integer, ByVal isVisible As Boolean)
        With Me.grdList.RootTable
            If .Columns.Contains(ColumnKey) = False Then
                .Columns.Add(ColumnKey)
            End If
            .Columns(ColumnKey).Position = iPos
            .Columns(ColumnKey).Width = iWidth
            .Columns(ColumnKey).Visible = isVisible
            .Columns(ColumnKey).ShowInFieldChooser = True
            .Columns(ColumnKey).FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
        End With
    End Sub

    Private Sub ResetTrademarksList()
        On Error Resume Next
        ' this is the panic-button if a grid goes completely haywire.
        If MsgBox("Reset the grid to its default layout?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'clear columns first
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdList.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetListColumn("TrademarkID", 0, 100, False)
        ResetListColumn("TrademarkName", 1, 150, True)
        ResetListColumn("TrademarkType", 2, 100, True)
        ResetListColumn("CompanyName", 3, 175, True)
        ResetListColumn("Jurisdiction", 4, 100, True)
        ResetListColumn("Treaty", 5, 45, True)
        ResetListColumn("ApplicationNumber", 6, 80, True)
        ResetListColumn("RegistrationNumber", 7, 80, True)
        ResetListColumn("FilingBasis", 8, 100, True)
        ResetListColumn("Status", 9, 80, True)
        ResetListColumn("OurDocket", 10, 100, True)
        ResetListColumn("ClientDocket", 11, 100, False)
        ResetListColumn("FileNumber", 12, 100, False)
        ResetListColumn("CheckStatus", 13, 80, False)
        ResetListColumn("lnkDelete", 14, 18, True)
        ResetListColumn("StatusCode", 15, 18, False)

        SaveGridLayouts()
        SetBrowseGrid()
    End Sub

    Private Sub ResetAlertColumn(ByVal ColumnKey As String, ByVal iPos As Integer, ByVal iWidth As Integer, ByVal isVisible As Boolean)
        With Me.grdAlerts.RootTable
            If .Columns.Contains(ColumnKey) = False Then
                .Columns.Add(ColumnKey)
            End If
            .Columns(ColumnKey).Position = iPos
            .Columns(ColumnKey).Width = iWidth
            .Columns(ColumnKey).Visible = isVisible
            .Columns(ColumnKey).ShowInFieldChooser = True
            .Columns(ColumnKey).FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
        End With
    End Sub

    Private Sub ResetAlertsList()
        On Error Resume Next
        ' this is the panic-button if a grid goes completely haywire.
        If MsgBox("Reset the grid to its default layout?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'clear columns first
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdAlerts.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetAlertColumn("TrademarkDateID", 0, 100, False)
        ResetAlertColumn("TrademarkID", 1, 100, False)
        ResetAlertColumn("TrademarkName", 2, 150, True)
        ResetAlertColumn("CompanyName", 3, 175, True)
        ResetAlertColumn("Jurisdiction", 4, 100, True)
        ResetAlertColumn("ApplicationNumber", 5, 80, True)
        ResetAlertColumn("RegistrationNumber", 6, 80, True)
        ResetAlertColumn("FilingBasis", 7, 100, False)
        ResetAlertColumn("Status", 8, 80, True)
        ResetAlertColumn("OurDocket", 9, 100, True)
        ResetAlertColumn("ClientDocket", 10, 100, False)
        ResetAlertColumn("FileNumber", 11, 100, False)
        ResetAlertColumn("DateName", 12, 145, True)
        ResetAlertColumn("TrademarkDate", 13, 80, True)
        ResetAlertColumn("lnkSend", 14, 90, False)
        ResetAlertColumn("Completed", 15, 49, True)
        ResetAlertColumn("EmailSent", 16, 49, False)
        ResetAlertColumn("RegistrationType", 17, 100, False)
        ResetAlertColumn("EmailAlert", 18, 100, False)
        ResetAlertColumn("EmailSubjectLine", 19, 100, False)
        ResetAlertColumn("JurisdictionID", 20, 100, False)
        ResetAlertColumn("RecurNumber", 21, 100, False)
        ResetAlertColumn("DateID", 22, 100, False)
        ResetAlertColumn("IsLocked", 23, 100, False)

        SaveGridLayouts()
        SetBrowseGrid()
    End Sub

    Private Sub ResetEmailAlertsList()
        On Error Resume Next
        ' this is the panic-button if a grid goes completely haywire.
        If MsgBox("Reset the grid to its default layout?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'clear columns first
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdAlerts.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetAlertColumn("TrademarkDateID", 0, 100, False)
        ResetAlertColumn("TrademarkID", 1, 100, False)
        ResetAlertColumn("TrademarkName", 2, 150, True)
        ResetAlertColumn("CompanyName", 3, 175, True)
        ResetAlertColumn("Jurisdiction", 4, 100, True)
        ResetAlertColumn("ApplicationNumber", 5, 80, True)
        ResetAlertColumn("RegistrationNumber", 6, 80, True)
        ResetAlertColumn("FilingBasis", 7, 100, False)
        ResetAlertColumn("Status", 8, 80, True)
        ResetAlertColumn("OurDocket", 9, 100, True)
        ResetAlertColumn("ClientDocket", 10, 100, False)
        ResetAlertColumn("FileNumber", 11, 100, False)
        ResetAlertColumn("DateName", 12, 145, True)
        ResetAlertColumn("TrademarkDate", 13, 80, True)
        ResetAlertColumn("lnkSend", 14, 90, True)
        ResetAlertColumn("Completed", 15, 49, False)
        ResetAlertColumn("EmailSent", 16, 49, True)
        ResetAlertColumn("RegistrationType", 17, 100, False)
        ResetAlertColumn("EmailAlert", 18, 100, False)
        ResetAlertColumn("EmailSubjectLine", 19, 100, False)
        ResetAlertColumn("JurisdictionID", 20, 100, False)
        ResetAlertColumn("RecurNumber", 21, 100, False)
        ResetAlertColumn("DateID", 22, 100, False)
        ResetAlertColumn("IsLocked", 23, 100, False)

        SaveGridLayouts()
        SetBrowseGrid()
    End Sub

    'we have to capture the click event before changing views in order to save grid layouts

    Private Sub optList_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optList.MouseDown
        SaveGridLayouts()
    End Sub

    Private Sub optAlerts_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optAlerts.MouseDown
        SaveGridLayouts()
    End Sub

    Private Sub optEmailAlerts_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optEmailAlerts.MouseDown
        SaveGridLayouts()
    End Sub

    Private Sub optSetContacts_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optSetContacts.MouseDown
        SaveGridLayouts()
    End Sub

#End Region

    Private Sub optList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optList.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optList.Checked = True Then
            SetBrowseGrid()
        End If
    End Sub

    Private Sub optAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAlerts.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optAlerts.Checked = True Then
            SetBrowseGrid()
        End If
    End Sub

    Private Sub optEmailAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEmailAlerts.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optEmailAlerts.Checked = True Then
            SetBrowseGrid()
        End If
    End Sub

    Private Sub optSetContacts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSetContacts.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optSetContacts.Checked = True Then
            SetBrowseGrid()
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        On Error Resume Next
        With Me
            If .optList.Checked = True Then
                RefreshBrowse()
            End If

            If .optSetContacts.Checked = True Then
                FillDropDowns()
                GetTrademarksList()
            End If

            If .optAlerts.Checked = True Then
                GetAlertDates()
            End If

            If .optEmailAlerts.Checked = True Then
                GetEmailAlerts()
            End If
        End With
    End Sub

    Private Sub SetBrowseGrid()
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        With Me
            .cboSetContact.SelectedIndex = -1
            .cboSetPosition.SelectedIndex = -1
        End With

        LoadGridLayouts()

        If Me.optList.Checked = True Then
            With Me
                .grdAlerts.Visible = False
                .grdAlerts.Dock = DockStyle.None
                .grdAlerts.DataSource = Nothing
                .grpAlerts.Enabled = True
                .btnAddToOutlook.Visible = False
                .LeadDays.Visible = False
                .lblLeadDays.Visible = False
                .BetweenStart.Enabled = False
                .BetweenStart.Text = ""
                .BetweenEnd.Enabled = False
                .BetweenEnd.Text = ""
                .cboEnd.Enabled = False
                .cboStart.Enabled = False
                .grpListButtons.Enabled = True
                .btnPrintList.Text = "Print List"
                .btnPrintRecords.Visible = False
                .btnNewTrademark.Visible = True
                .lblReportWidth.Visible = True
                .lblReportWidth.Left = 710

                .pnlBrowse.Height = 46
                .grpSetContact.Visible = False
                .grdSetContacts.Visible = False
                .grpCustomize.Visible = True
                .grpCustomize.Dock = DockStyle.Top
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .cboSetPosition.DataBindings.Clear()
                .cboSetPosition.Clear()
                .btnAddContacts.Visible = False
                .btnRemoveContacts.Visible = False
                .grdSetContacts.DataSource = Nothing
                .btnCreateOpposition.Visible = True
            End With
            With Me.grdList
                .Visible = True
                .Dock = DockStyle.Fill
                .SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                .RootTable.Columns("TrademarkName").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                .RootTable.Columns("TrademarkName").Caption = "Trademark"
                .RootTable.Columns("TrademarkID").ShowInFieldChooser = False
                .RootTable.Columns("lnkDelete").ShowInFieldChooser = False
                .RootTable.Columns("StatusCode").ShowInFieldChooser = False
                .RootTable.Columns("CheckStatus").ShowInFieldChooser = True
            End With
        End If

        If Me.optSetContacts.Checked = True Then
            With Me
                .grdAlerts.Visible = False
                .grdAlerts.DataSource = Nothing
                .grpAlerts.Enabled = False
                .btnAddToOutlook.Visible = True
                .LeadDays.Visible = True
                .lblLeadDays.Visible = True
                .btnCreateOpposition.Visible = False
                .BetweenStart.Enabled = False
                .BetweenStart.Text = ""
                .BetweenEnd.Enabled = False
                .BetweenEnd.Text = ""
                .cboEnd.Enabled = False
                .cboStart.Enabled = False
                .grpListButtons.Enabled = False
                .pnlBrowse.Height = 46
                .grpSetContact.Visible = True
                .grdSetContacts.Visible = True
                .grpCustomize.Visible = False
                .cboSetContact.SetDataBinding(RevaData.tblContactsList, "")
                .cboSetPosition.SetDataBinding(RevaData.tblTrademarkPositions, "")
                .btnAddContacts.Visible = True
                .btnRemoveContacts.Visible = True
                .btnCreateOpposition.Visible = False
                .lblReportWidth.Visible = False
            End With
            With Me.grdList
                .Visible = True
                .Dock = DockStyle.Left
                .SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RootTable.Columns("CompanyName").Width = 180
                .RootTable.Columns("TradeMarkName").Width = 200
                .RootTable.Columns("Jurisdiction").Width = 95
                .RootTable.Columns("TrademarkType").Visible = False
                .RootTable.Columns("CheckStatus").Visible = False
                .RootTable.Columns("StatusCode").ShowInFieldChooser = False
                .RootTable.Columns("CheckStatus").ShowInFieldChooser = False
                .RootTable.Columns("TrademarkName").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                '.Row = 0
            End With
            'new to accomodate wide screens
            With Me
                .grdSetContacts.Dock = DockStyle.None
                .grdSetContacts.Top = .grdList.Top
                .grdSetContacts.Height = .grdList.Height
                .grdSetContacts.Left = .grdList.Left + .grdList.Width + 55
            End With
        End If

        If Me.optAlerts.Checked = True Then
            With Me
                .btnAddContacts.Visible = False
                .btnRemoveContacts.Visible = False
                .pnlBrowse.Height = 80
                ' .pnlBrowse.Height = 46
                .grpCustomize.Dock = DockStyle.Top
                .grpCustomize.Visible = True
                .cboSetPosition.SetDataBinding(RevaData.tblTrademarkPositions, "")
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .grpSetContact.Visible = True
                .grpAlerts.Enabled = True
                .btnAddToOutlook.Visible = True
                .LeadDays.Visible = True
                .lblLeadDays.Visible = True
                .btnCreateOpposition.Visible = False
                .grdSetContacts.Visible = False
                .grpCustomize.Visible = True
                .grdList.Visible = False
                .BetweenStart.Enabled = True
                .BetweenEnd.Enabled = True
                .cboEnd.Enabled = True
                .cboStart.Enabled = True
                .grpListButtons.Enabled = True
                .btnPrintList.Text = "Print Alerts"
                .btnPrintRecords.Visible = True
                .btnNewTrademark.Visible = False
                .btnCreateOpposition.Visible = False
                .lblReportWidth.Visible = True
                .lblReportWidth.Left = 740
                'get previous date range selection from stored settings
                .cboStart.SelectedIndex = My.Settings.DateFromIndex
                .cboEnd.SelectedIndex = My.Settings.DateToIndex
                SetAlertStartDate()
                SetAlertEndDate()
            End With
            With Me.grdAlerts
                .Dock = DockStyle.Fill
                .ScrollBars = Janus.Windows.GridEX.ScrollBars.Automatic
                .Visible = True
                .DataSource = Nothing
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RowFormatStyle.BackColor = Color.Lavender
                .AlternatingRowFormatStyle.BackColor = Color.WhiteSmoke

                .RootTable.Columns("EmailSent").Visible = False
                .RootTable.Columns("lnkSend").Visible = False
                .RootTable.Columns("Completed").Visible = True
                .RootTable.Columns("JurisdictionID").ShowInFieldChooser = False
                .RootTable.Columns("TrademarkID").ShowInFieldChooser = False
                .RootTable.Columns("TrademarkDateID").ShowInFieldChooser = False
                .RootTable.Columns("EmailAlert").ShowInFieldChooser = False
                .RootTable.Columns("EmailSubjectLine").ShowInFieldChooser = False
                .RootTable.Columns("DateID").ShowInFieldChooser = False
                .RootTable.Columns("IsLocked").ShowInFieldChooser = False
                .RootTable.Columns("RecurNumber").ShowInFieldChooser = False
                .RootTable.Columns("lnkSend").ShowInFieldChooser = False
                .RootTable.Columns("EmailSent").ShowInFieldChooser = False
                GetAlertDates()
                '.Row = 0
            End With

        End If

        If Me.optEmailAlerts.Checked = True Then
            With Me
                .btnAddContacts.Visible = False
                .btnRemoveContacts.Visible = False
                .pnlBrowse.Height = 46
                .grpCustomize.Dock = DockStyle.Top
                .grpCustomize.Visible = True
                .cboSetPosition.SetDataBinding(RevaData.tblTrademarkPositions, "")
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .grpSetContact.Visible = False
                .grpAlerts.Enabled = False
                .grdSetContacts.Visible = False
                .grdList.Visible = False
                .BetweenStart.Enabled = True
                .BetweenEnd.Enabled = True
                .cboEnd.Enabled = False
                .cboStart.Enabled = False
                .grpListButtons.Enabled = False
                .btnPrintList.Text = "Print Alerts"
                .btnPrintRecords.Visible = True
                .btnNewTrademark.Visible = False
                .btnAddToOutlook.Visible = True
                .LeadDays.Visible = True
                .lblLeadDays.Visible = True
                .btnCreateOpposition.Visible = False
                .lblReportWidth.Visible = False
            End With

            With Me.grdAlerts
                .Dock = DockStyle.Fill
                .ScrollBars = Janus.Windows.GridEX.ScrollBars.Automatic
                .Visible = True
                .DataSource = Nothing
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RowFormatStyle.BackColor = Color.Beige
                .AlternatingRowFormatStyle.BackColor = Color.Beige
                .RootTable.Columns("EmailSent").Visible = True
                .RootTable.Columns("lnkSend").Visible = True
                .RootTable.Columns("Completed").Visible = False
                .RootTable.Columns("JurisdictionID").ShowInFieldChooser = False
                .RootTable.Columns("Completed").ShowInFieldChooser = False
                .RootTable.Columns("TrademarkID").ShowInFieldChooser = False
                .RootTable.Columns("TrademarkDateID").ShowInFieldChooser = False
                .RootTable.Columns("EmailAlert").ShowInFieldChooser = False
                .RootTable.Columns("EmailSubjectLine").ShowInFieldChooser = False
                .RootTable.Columns("DateID").ShowInFieldChooser = False
                .RootTable.Columns("IsLocked").ShowInFieldChooser = False
                .RootTable.Columns("RecurNumber").ShowInFieldChooser = False
                .RootTable.Columns("lnkSend").ShowInFieldChooser = False
                .RootTable.Columns("EmailSent").ShowInFieldChooser = False
                GetEmailAlerts()
                '.Row = 0
            End With

            'mostly to fix things that went hooie while testing custom layouts
            For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdList.RootTable.Columns
                GridCol.FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                GridCol.CellStyle.FontUnderline = Janus.Windows.GridEX.TriState.False
            Next

            For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdAlerts.RootTable.Columns
                GridCol.FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                GridCol.CellStyle.FontUnderline = Janus.Windows.GridEX.TriState.False
            Next

        End If

    End Sub

    Private Sub RefreshBrowse()
        On Error Resume Next
        Dim iRow As Integer, iFirst As Integer
        iRow = Me.grdList.CurrentRow.RowIndex
        iFirst = Me.grdList.FirstRow
        GetTrademarksList()
        Me.grdList.Row = iRow
        Me.grdList.FirstRow = iFirst
    End Sub

    Private Sub grdList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.CurrentCellChanged
        On Error Resume Next
        If Me.grdList.CurrentRow.RowType = Janus.Windows.GridEX.RowType.FilterRow Then
            Me.grdList.CurrentCellDroppedDown = True
        End If
    End Sub

    Private Sub grdList_SortKeysChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdList.SortKeysChanged
        On Error Resume Next
        Me.grdList.Row = 0
    End Sub

    Private Sub btnClearFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFilters.Click
        On Error Resume Next
        With Me

            If .optAlerts.Checked = True Then
                .grdAlerts.RemoveFilters()
                .cboSetPosition.SelectedIndex = -1
                .cboSetContact.SelectedIndex = -1
                GetAlertDates()
            End If

            If .optList.Checked = True Then
                .grdList.RemoveFilters()
                GetTrademarksList()
            End If

        End With
    End Sub

    Private Sub btnPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintList.Click
        On Error Resume Next
        If Me.optList.Checked = True Then
            PrintList()
        End If
        If Me.optAlerts.Checked = True Then
            PrintAlerts()
        End If
    End Sub

    Private Sub btnPrintRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintRecords.Click
        On Error Resume Next
        Dim strFilter As String, i As Integer, strSort As String
        Dim drReader As OleDb.OleDbDataReader, rptTrademark As New rtpOneTrademark, strSQL As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor
        strFilter = "TrademarkID in ("
        strSort = "CompanyName, TrademarkName, Jurisdiction, TrademarkID, TrademarkDate"

        For i = 0 To Me.grdAlerts.RowCount - 1
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("TrademarkID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = SQL.vwReportTrademarks & " where " & strFilter & " order by " & strSort
        drReader = DataStuff.GetDataReader(strSQL)
        rptTrademark.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptTrademark.Document
        rptTrademark.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnNewTrademark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTrademark.Click
        On Error Resume Next
        Dim iRecords As Integer
        iRecords = DataStuff.RecordCount

        Select Case Globals.PurchaseLevel
            Case 0
                If iRecords >= 80 Then
                    MsgBox("The Demo Version is limited to 80 trademarks and/or patents.")
                    Exit Sub
                End If
            Case 1
                If iRecords >= 150 Then
                    MsgBox("Level One is limited to 150 trademarks and/or patents.")
                    Exit Sub
                End If
            Case 2
                If iRecords >= 300 Then
                    MsgBox("Level Two is limited to 300 trademarks and/or patents.")
                    Exit Sub
                End If
            Case 3
                If iRecords >= 600 Then
                    MsgBox("Level Three is limited to 600 trademarks and/or patents.")
                    Exit Sub
                End If
            Case 4
                If iRecords >= 1500 Then
                    MsgBox("Level Four is limited to 1500 trademarks and/or patents.")
                    Exit Sub
                End If
            Case 5
                'Level Five is unlimited

            Case 6
                'new server demo level
                If iRecords >= 30 Then
                    MsgBox("the Server Demo version is limited to 30 trademarks and/or patents.")
                    Exit Sub
                End If
        End Select

        DataStuff.RunSQL("insert into tblTrademarks (TrademarkName, CheckStatus, GraphicSizeToFit) values ('Type Trademark Name Here',0,0)")
        Globals.TrademarkID = DataStuff.DMax("TrademarkID", "tblTrademarks")

        'add any contacts who are supposed to be on all Trademarks
        DataStuff.RunSQL("Insert into tblTrademarkContacts (TrademarkID, ContactID, PositionID) select " & _
            Globals.TrademarkID & ", ContactID, PositionID from tblContacts where AddToTrademarks <> 0 and PositionID > 0")


        GetTrademark()
        Me.Tabs.SelectedIndex = 1
        Globals.NavigateMarksFrom = 0
        SetNavigationButtons()
    End Sub

    Private Sub btnCreateOpposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateOpposition.Click
        On Error Resume Next
        Dim i As Integer, dtOppositionMarks As DataTable, strSQL As String, iJurisdictionID As Integer, _
            iCompanyID As Integer, GRow As Janus.Windows.GridEX.GridEXRow, iOppositionID As Integer

        strSQL = "Select TrademarkID, CompanyID, JurisdictionID from tblTrademarks where TrademarkID in ("
        For i = 0 To Me.grdList.SelectedItems.Count - 1
            GRow = Me.grdList.SelectedItems(i).GetRow
            strSQL = strSQL & GRow.Cells("TrademarkID").Text & ","
        Next i
        strSQL = strSQL & "0)"

        dtOppositionMarks = DataStuff.GetDataTable(strSQL)
        'make sure we're not mixing companies or jurisdictions
        For i = 0 To dtOppositionMarks.Rows.Count - 1
            If i > 0 Then
                If dtOppositionMarks.Rows(i).Item("CompanyID") <> iCompanyID Then
                    MsgBox("You cannot mix companies in the same opposition record.")
                    Exit Sub
                End If
                If dtOppositionMarks.Rows(i).Item("JurisdictionID") <> iJurisdictionID Then
                    MsgBox("You cannot mix jurisdictions in the same opposition record.")
                    Exit Sub
                End If
            End If
            iCompanyID = dtOppositionMarks.Rows(i).Item("CompanyID")
            iJurisdictionID = dtOppositionMarks.Rows(i).Item("JurisdictionID")
        Next

        'still here?  Then it's okay to go.
        strSQL = "insert into tblOppositions (OppositionName, CompanyID, JurisdictionID) values " & _
            "('Type Opposition Name Here'," & iCompanyID & "," & iJurisdictionID & ")"

        Globals.OppositionID = DataStuff.DMax("OppositionID", "tblOppositions")

        DataStuff.RunSQL(strSQL)
        iOppositionID = DataStuff.DMax("OppositionID", "tblOppositions")
        Globals.OppositionID = iOppositionID

        ' add any contacts who are supposed to be on all Trademarks, which will include Oppositions for marks
        DataStuff.RunSQL("Insert into tblOppositionContacts (OppositionID, ContactID, PositionID) select " & _
            iOppositionID & ", ContactID, PositionID from tblContacts where AddToTrademarks <> 0 and PositionID > 0")

        'add the selected trademarks as client marks
        For i = 0 To Me.grdList.SelectedItems.Count - 1
            GRow = Me.grdList.SelectedItems(i).GetRow
            strSQL = "Insert into tblOppositionClientTrademarks (OppositionID, TrademarkID) values (" & _
                iOppositionID & "," & GRow.Cells("TrademarkID").Text & ")"
            DataStuff.RunSQL(strSQL)
        Next i

        'add company contacts
        strSQL = "Insert into tblOppositionContacts (OppositionID, ContactID, PositionID) Select " & _
           iOppositionID & ", ContactID, PositionID from tblContacts where CompanyID=" & iCompanyID & _
               " and PositionID is not null and PositionID in (Select PositionID from tblPositions" & _
               " where IsTrademark <> 0)"
        DataStuff.RunSQL(strSQL)

        AllForms.OpenOppositions()
        With AllForms.frmOppositions
            .GetOpposition()
            .btnNextRecord.Enabled = False
            .btnPrevRecord.Enabled = False
            .RecordCount.Text = ""
        End With

    End Sub

    Private Sub grdList_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdList.LinkClicked
        On Error Resume Next

        If (e.Column.Key = "TrademarkName") Or (e.Column.Key = "ApplicationNumber") Then
            'first part is to make sure nobody tries to manually enter records on the server
            Select Case Globals.PurchaseLevel
                Case 0
                    If iTotalRecords >= 80 Then
                        MsgBox("The Demo Version is limited to 80 trademarks and/or patents.")
                        Exit Sub
                    End If
                Case 1
                    If iTotalRecords >= 150 Then
                        MsgBox("Level One is limited to 150 trademarks and/or patents.")
                        Exit Sub
                    End If
                Case 2
                    If iTotalRecords >= 300 Then
                        MsgBox("Level Two is limited to 300 trademarks and/or patents.")
                        Exit Sub
                    End If
                Case 3
                    If iTotalRecords >= 600 Then
                        MsgBox("Level Three is limited to 600 trademarks and/or patents.")
                        Exit Sub
                    End If
                Case 4
                    If iTotalRecords >= 1500 Then
                        MsgBox("Level Four is limited to 1500 trademarks and/or patents.")
                        Exit Sub
                    End If
                Case 5
                    'Level Five is unlimited

                Case 6
                    'new server demo level
                    If iTotalRecords >= 30 Then
                        MsgBox("the Server Demo version is limited to 30 trademarks and/or patents.")
                        Exit Sub
                    End If
            End Select

            If Me.optList.Checked = True Then
                Globals.TrademarkID = Me.grdList.GetValue("TrademarkID")
                Globals.NavigateMarksFrom = 1
                GetTrademark()
                Me.Tabs.SelectedIndex = 1
            End If
        End If

        If e.Column.Key = "lnkDelete" Then
            If Globals.SecurityLevel > 1 Then Exit Sub
            Dim strMessage As String, iTrademarkID As Integer

            iTrademarkID = Me.grdList.GetValue("TrademarkID")
            If DataStuff.DCount("TreatyFilingID", "tblTreatyFilings", "TrademarkID=" & iTrademarkID) > 0 Then
                MsgBox("You cannot delete a trademark that is the basis mark for a treaty filing.")
                Exit Sub
            End If

            strMessage = "This will delete the trademark and all related trademark contacts, actions, oppositions, and trademark dates." & _
                   vbCrLf & vbCrLf & "This delete cannot be undone.  Are you sure?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'if we're still here, let's do it
            DataStuff.DeleteTrademark(iTrademarkID)
            GetTrademarksList()
        End If

    End Sub


#Region "Set Multiple Contacts"

    Private Sub grdList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        On Error Resume Next
        If Me.optSetContacts.Checked = True Then
            SetContactButtons()
        End If
    End Sub

    Private Sub cboSetContact_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSetContact.ValueChanged
        On Error Resume Next
        If Me.optSetContacts.Checked = True Then
            GetPositionList()
            SetContactButtons()
        End If
        If Me.optAlerts.Checked = True Then
            GetAlertDates()
        End If
    End Sub

    Private Sub cboSetPosition_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSetPosition.ValueChanged
        On Error Resume Next

        If Me.optSetContacts.Checked = True Then
            GetPositionList()
            SetContactButtons()
        End If

        If Me.optAlerts.Checked = True Then
            Dim iPositionID As Integer, dtContactList As DataTable, strSQL As String
            iPositionID = cboSetPosition.Value
            If iPositionID > 0 Then
                strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwTrademarkContacts" & _
                    " where PositionID=" & iPositionID & " order by ContactName"
                dtContactList = DataStuff.GetDataTable(strSQL)
                Me.cboSetContact.DataSource = dtContactList
            End If
        End If
        Me.cboSetContact.SelectedIndex = -1
    End Sub

    Private Sub GetPositionList()
        On Error Resume Next
        If Me.cboSetContact.Value > 0 And Me.cboSetPosition.Value > 0 Then
            Dim dtPositionsList As DataTable, strSQL As String, iContactID As Integer, iPositionID As Integer
            iContactID = Me.cboSetContact.Value
            iPositionID = Me.cboSetPosition.Value
            strSQL = "SELECT TrademarkContactID, CompanyName, TrademarkName, Jurisdiction, TrademarkID, ContactID, PositionID " & _
             "from qvwTrademarkContacts where ContactID=" & iContactID & " and PositionID=" & iPositionID & _
             " order by CompanyName, TrademarkName"
            dtPositionsList = DataStuff.GetDataTable(strSQL)
            Me.grdSetContacts.DataSource = dtPositionsList
        End If

    End Sub

    Private Sub btnAddContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContacts.Click
        On Error Resume Next
        Dim iContactID As Integer, iPositionID As Integer, i As Integer, iTrademarkID As Integer, _
            GRow As Janus.Windows.GridEX.GridEXRow, strFilter As String, strSQL As String, rsContacts As New RecordSet

        'don't bother if nothing is selected
        If Me.grdList.SelectedItems.Count < 1 Then
            MsgBox("You must select Trademarks to add first.")
            Exit Sub
        End If

        If Not (Me.cboSetPosition.Value > 0) Then
            MsgBox("You must select a contact and position first.")
            Exit Sub
        End If

        If Not (Me.cboSetContact.Value > 0) Then
            MsgBox("You must select a contact and position first.")
            Exit Sub
        End If

        iContactID = Me.cboSetContact.Value
        iPositionID = Me.cboSetPosition.Value
        'open table where this contact occupies this position
        strSQL = "Select * from tblTrademarkContacts where ContactID=" & iContactID & " and PositionID=" & iPositionID
        rsContacts.GetFromSQL(strSQL)

        For i = 0 To Me.grdList.SelectedItems.Count - 1
            GRow = Me.grdList.SelectedItems(i).GetRow
            iTrademarkID = GRow.Cells("TrademarkID").Value
            strFilter = "ContactID=" & iContactID & " and PositionID=" & iPositionID & _
                " and TrademarkID=" & iTrademarkID
            If rsContacts.RecordExists(strFilter) = False Then
                rsContacts.AddRow()
                'final precaution, make sure it's a new row
                If rsContacts.CurrentRow("TrademarkID").ToString = "" Then
                    rsContacts.CurrentRow("TrademarkID") = iTrademarkID
                    rsContacts.CurrentRow("PositionID") = iPositionID
                    rsContacts.CurrentRow("ContactID") = iContactID
                End If
            End If
        Next i
        rsContacts.Update()
        GetPositionList()

    End Sub

    Private Sub btnRemoveContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveContacts.Click
        On Error Resume Next
        Dim strSQL As String, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        strSQL = "delete from tblTrademarkContacts where TrademarkContactID in ("
        For i = 0 To Me.grdSetContacts.SelectedItems.Count - 1
            GRow = Me.grdSetContacts.SelectedItems(i).GetRow
            strSQL = strSQL & GRow.Cells("TrademarkContactID").Value & ","
        Next i
        strSQL = strSQL & "0)"
        DataStuff.RunSQL(strSQL)
        GetPositionList()
    End Sub

    Private Sub SetContactButtons()
        On Error Resume Next
        With Me
            .btnAddContacts.Enabled = (.grdList.SelectedItems.Count > 0) And (.cboSetContact.Value > 0) _
                And (.cboSetPosition.Value > 0) And (Globals.SecurityLevel < 3) And (.grdList.Row >= 0)

            .btnRemoveContacts.Enabled = (.grdSetContacts.SelectedItems.Count > 0) _
                And (Globals.SecurityLevel = 1) And (.grdSetContacts.Row >= 0)
        End With
    End Sub


    Private Sub grdSetContacts_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSetContacts.SelectionChanged
        On Error Resume Next
        SetContactButtons()
    End Sub

#End Region

#Region "Alerts Screen"

    Private Sub cboStart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStart.SelectedIndexChanged
        On Error Resume Next
        SetAlertEndDate()
        GetAlertDates()
        My.Settings.DateFromIndex = Me.cboStart.SelectedIndex
        
    End Sub

    Private Sub SetAlertStartDate()
        On Error Resume Next
        If RevaSettings.USADates = True Then
            Select Case Me.cboEnd.SelectedIndex
                Case 0
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Day, 7, DateTime.Now.Date), "MMM dd, yyyy")
                Case 1
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 1, DateTime.Now.Date), "MMM dd, yyyy")
                Case 2
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 2, DateTime.Now.Date), "MMM dd, yyyy")
                Case 3
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 3, DateTime.Now.Date), "MMM dd, yyyy")
                Case 4
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 6, DateTime.Now.Date), "MMM dd, yyyy")
                Case 5
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Year, 1, DateTime.Now.Date), "MMM dd, yyyy")
            End Select
        Else  'else European dates
            Select Case Me.cboEnd.SelectedIndex
                Case 0
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Day, 7, DateTime.Now.Date), "dd MMM yyyy")
                Case 1
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 1, DateTime.Now.Date), "dd MMM yyyy")
                Case 2
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 2, DateTime.Now.Date), "dd MMM yyyy")
                Case 3
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 3, DateTime.Now.Date), "dd MMM yyyy")
                Case 4
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Month, 6, DateTime.Now.Date), "dd MMM yyyy")
                Case 5
                    Me.BetweenEnd.Text = Format(DateAdd(DateInterval.Year, 1, DateTime.Now.Date), "dd MMM yyyy")
            End Select
        End If
    End Sub

    Private Sub BetweenStart_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BetweenStart.Validated
        On Error Resume Next
        If IsDate(Me.BetweenStart.Text) Then
            If RevaSettings.USADates = True Then
                Me.BetweenStart.Text = Format(DateValue(Me.BetweenStart.Text), "MMM dd, yyyy")
            Else
                Me.BetweenStart.Text = Format(DateValue(Me.BetweenStart.Text), "dd MMM yyyy")
            End If
        Else
            Me.BetweenStart.Text = ""
        End If
        GetAlertDates()
    End Sub

    Private Sub cboEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnd.SelectedIndexChanged
        On Error Resume Next
        SetAlertStartDate()
        GetAlertDates()
        My.Settings.DateToIndex = Me.cboEnd.SelectedIndex
        
    End Sub

    Private Sub BetweenEnd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BetweenEnd.Validated
        On Error Resume Next
        If IsDate(Me.BetweenEnd.Text) Then
            If RevaSettings.USADates = True Then
                Me.BetweenEnd.Text = Format(DateValue(Me.BetweenEnd.Text), "MMM dd, yyyy")
            Else
                Me.BetweenEnd.Text = Format(DateValue(Me.BetweenEnd.Text), "dd MMM yyyy")
            End If
        Else
            Me.BetweenEnd.Text = ""
        End If
        GetAlertDates()
    End Sub

    Private Sub SetAlertEndDate()
        On Error Resume Next
        If RevaSettings.USADates = True Then
            Select Case Me.cboStart.SelectedIndex
                Case 0
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -3, DateTime.Now.Date), "MMM dd, yyyy")
                Case 1
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -2, DateTime.Now.Date), "MMM dd, yyyy")
                Case 2
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -1, DateTime.Now.Date), "MMM dd, yyyy")
                Case 3
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Day, -7, DateTime.Now.Date), "MMM dd, yyyy")
                Case 4
                    Me.BetweenStart.Text = Format(DateTime.Now.Date, "MMM dd, yyyy")
            End Select
        Else
            Select Case Me.cboStart.SelectedIndex
                Case 0
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -3, DateTime.Now.Date), "dd MMM yyyy")
                Case 1
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -2, DateTime.Now.Date), "dd MMM yyyy")
                Case 2
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Month, -1, DateTime.Now.Date), "dd MMM yyyy")
                Case 3
                    Me.BetweenStart.Text = Format(DateAdd(DateInterval.Day, -7, DateTime.Now.Date), "dd MMM yyyy")
                Case 4
                    Me.BetweenStart.Text = Format(DateTime.Now.Date, "dd MMM yyyy")
            End Select
        End If
    End Sub

    Friend Sub GetAlertDates()
        On Error Resume Next
        If Me.optAlerts.Checked = True Then
            Dim strSQL As String, dtAlerts As DataTable

            With Me
                If IsDate(.BetweenEnd.Text) And IsDate(.BetweenStart.Text) Then
                    ' first the real actions
                    strSQL = SQL.vwTrademarkAlerts
                    strSQL = strSQL & " and TrademarkDate >=" & FixDate(.BetweenStart.Text)
                    strSQL = strSQL & " and TrademarkDate <=" & FixDate(.BetweenEnd.Text)

                    If .cboSetPosition.Value > 0 And .cboSetContact.Value > 0 Then
                        strSQL = strSQL & " and TrademarkID in (Select TrademarkID from qvwTrademarkContacts" & _
                            " where ContactID=" & .cboSetContact.Value & " and PositionID=" & .cboSetPosition.Value & ")"
                    End If

                    'now tag on any actions marked as alerts
                    strSQL = strSQL & " union " & SQL.vwTrademarkActionAlerts
                    strSQL = strSQL & " and ActionDate >=" & FixDate(.BetweenStart.Text)
                    strSQL = strSQL & " and ActionDate <=" & FixDate(.BetweenEnd.Text)

                    If .cboSetPosition.Value > 0 And .cboSetContact.Value > 0 Then
                        strSQL = strSQL & " and TrademarkID in (Select TrademarkID from qvwTrademarkContacts" & _
                            " where ContactID=" & .cboSetContact.Value & " and PositionID=" & .cboSetPosition.Value & ")"
                    End If
                    strSQL = strSQL & " order by TrademarkDate, CompanyName"

                    dtAlerts = DataStuff.GetDataTable(strSQL)
                    .grdAlerts.DataSource = dtAlerts
                Else
                    dtAlerts = Nothing
                    .grdAlerts.DataSource = Nothing
                End If
            End With
        End If

    End Sub


    Private Sub grdAlerts_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdAlerts.LinkClicked
        On Error Resume Next
        If e.Column.Key = "TrademarkName" Or e.Column.Key = "ApplicationNumber" Then
            Me.grdAlerts.UpdateData()
            Globals.TrademarkID = Me.grdAlerts.GetValue("TrademarkID")
            Globals.NavigateMarksFrom = 2
            GetTrademark()
            Me.Tabs.SelectedIndex = 1
        End If

        If e.Column.Key = "lnkSend" Then
            Dim OL As Outlook.Application, Email As Outlook.MailItem


            If OL Is Nothing Then
                OL = CreateObject("Outlook.Application")
            Else
                OL = GetObject(, "Outlook.Application")
            End If

            Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
            GenerateEmails(Me.grdAlerts.CurrentRow, Email)
            OL = Nothing
        End If

    End Sub

    Private Sub grdAlerts_GetChildList(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.GetChildListEventArgs) Handles grdAlerts.GetChildList
        On Error Resume Next
        'populates child table rows when the + sign is clicked on a parent row.
        Dim TrademarkID As Integer, strSQL As String
        TrademarkID = e.ParentRow.Cells("TrademarkID").Value

        grdAlerts.Tables("Dates").FormatConditions.Clear()
        ApplyListDateFormatting()

        If e.ChildTable.Key = "Actions" Then
            strSQL = "Select * from tblTrademarkActions where TrademarkID=" & TrademarkID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If

        If e.ChildTable.Key = "Dates" Then
            strSQL = "SELECT TrademarkDateID, TrademarkID, JurisdictionDateID, JurisdictionID, DateID, " & _
            "DateName, TrademarkDate, NoDay, NoMonth, ListOrder, Completed, RecursAtInterval, " & _
            "HasRelatives, FilingBasisID, IsTreaty, IsRelative from qvwTrademarkDates where TrademarkID=" & TrademarkID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If

    End Sub

    Private Sub ApplyListDateFormatting()
        On Error Resume Next
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition, TrademarkDateID As Integer
        TrademarkDateID = grdAlerts.GetValue("TrademarkDateID")
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdAlerts.Tables("Dates").Columns("TrademarkDateID"), _
            Janus.Windows.GridEX.ConditionOperator.Equal, TrademarkDateID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdAlerts.Tables("Dates").FormatConditions.Add(fc)
    End Sub

    Private Sub grdAlerts_SortKeysChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.SortKeysChanged
        On Error Resume Next
        Me.grdAlerts.Row = 0
    End Sub

    Private Sub PrintAlerts()
        On Error Resume Next

        If Me.cboSetPosition.Value > 0 Then
            PrintAlertsPosition()
        Else
            Dim ReportTable As DataTable, rptAlerts As New rptTrademarkAlerts
            Me.Cursor = Cursors.WaitCursor
            ReportTable = DataStuff.GetTableFromGrid(Me.grdAlerts, "TrademarkName", False)

            rptAlerts.DataSource = ReportTable
            AllForms.OpenReport()
            AllForms.frmReportPreview.ReportViewer.Document = rptAlerts.Document
            rptAlerts.Run()
            AllForms.frmReportPreview.Show()

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub PrintAlertsPosition()
        On Error Resume Next
        Dim strSort As String, strFilter As String, _
            i As Integer, strSQL As String, drReader As OleDb.OleDbDataReader
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor

        strFilter = "where TrademarkID <> 0"

        With Me
            If .cboSetPosition.Value > 0 Then
                strFilter = strFilter & " and PositionID=" & .cboSetPosition.Value
            End If

            If .cboSetContact.Value > 0 Then
                strFilter = strFilter & " and ContactID=" & .cboSetContact.Value
            End If
        End With

        With Me.grdAlerts.RootTable
            If .SortKeys.Count > 0 Then
                strSort = .SortKeys(0).Column.Key
            Else
                strSort = ""
            End If
        End With

        strFilter = strFilter & " and TrademarkDateID in ("
        For i = 0 To Me.grdAlerts.RowCount - 1
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("TrademarkDateID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        Dim rptAlertsPosition As New rptTrademarkAlertsPosition
        strSQL = "Select * from (" & SQL.vwReportTrademarkAlertsPosition & " union " & _
        SQL.vwReportTrademarkActionAlertsPosition & ") Q " & strFilter

        Select Case strSort
            Case "CompanyName"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "CompanyName, TrademarkName, TrademarkID, TrademarkDate"

            Case "TrademarkName"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "TrademarkName, TrademarkID, CompanyName, TrademarkDate"

            Case "TrademarkDate"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case "Status"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "Status, TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case "FilingBasis"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "FilingBasis, TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case "FileNumber"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "FileNumber, TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case "OurDocket"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "OurDocket, TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case "ClientDocket"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                    "ClientDocket, TrademarkDate, TrademarkID,CompanyName, TrademarkName"

            Case Else
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " & _
                     "CompanyName, TrademarkName, TrademarkID, TrademarkDate"

        End Select

        drReader = DataStuff.GetDataReader(strSQL)
        rptAlertsPosition.DataSource = drReader
        rptAlertsPosition.ReportDescription.Text = "Between " & Me.BetweenStart.Text & " and " & Me.BetweenEnd.Text
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptAlertsPosition.Document
        rptAlertsPosition.Run()
        AllForms.frmReportPreview.Show()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrintList()
        On Error Resume Next

        Dim ReportTable As DataTable, rptList As New rptTrademarksList
        Me.Cursor = Cursors.WaitCursor
        ReportTable = DataStuff.GetTableFromGrid(Me.grdList, "TrademarkName", False)

        rptList.DataSource = ReportTable
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptList.Document
        rptList.Run()
        AllForms.frmReportPreview.Show()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnAddToOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToOutlook.Click
        On Error Resume Next
        If Me.grdAlerts.SelectedItems.Count < 1 Then
            MsgBox("You must select at least one item in the list first.")
            Exit Sub
        End If

        If IsNumeric(Me.LeadDays.Text) = False Then
            MsgBox("You must a number for Lead Time (enter a zero for no lead time).")
        End If

        'still here, so let's doit toit

        Dim objOutlook As Outlook.Application
        Dim objTask As Outlook.AppointmentItem
        Dim objTest As Outlook.AppointmentItem
        Dim objNamespace As Outlook.NameSpace
        Dim colCalendarItems As Outlook.Items
        Dim colItems As Outlook.Items
        Dim objCalendarFolder As Outlook.MAPIFolder
        Dim strSubject As String, dTrademarkDate As Date, strDayBefore As String, strDayAfter As String, _
            i As Integer, iLeadDays As Integer, strBody As String, GridRow As Janus.Windows.GridEX.GridEXRow
        Dim sngAlertTime As Single

        objOutlook = CreateObject("Outlook.Application")
        objNamespace = objOutlook.GetNamespace("MAPI")

        'calendar folder
        objCalendarFolder = objNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)
        'all the current calendar items
        colCalendarItems = objCalendarFolder.Items

        iLeadDays = CInt(Me.LeadDays.Text)
        sngAlertTime = Nz(RevaSettings.OutlookAlertTime, 0)

        For i = 0 To Me.grdAlerts.SelectedItems.Count - 1
            GridRow = Me.grdAlerts.SelectedItems(i).GetRow
            strSubject = ""
            strBody = ""
            With GridRow

                'some marks and company names have quotes in them, have to kill 'em
                strSubject = strSubject & Replace(.Cells("TrademarkName").Value, Chr(34), "") & " | "
                strSubject = strSubject & Replace(.Cells("CompanyName").Value, Chr(34), "") & " | "

                strSubject = strSubject & .Cells("Jurisdiction").Value & " | "
                strSubject = strSubject & .Cells("ApplicationNumber").Value & " | "
                strSubject = strSubject & .Cells("DateName").Value & " | "

                strBody = strBody & .Cells("TrademarkName").Value & vbCrLf
                strBody = strBody & .Cells("CompanyName").Value & vbCrLf
                strBody = strBody & .Cells("Jurisdiction").Value & vbCrLf
                strBody = strBody & .Cells("ApplicationNumber").Value & vbCrLf
                strBody = strBody & .Cells("DateName").Value & " due on " & .Cells("TrademarkDate").Value


                dTrademarkDate = .Cells("TrademarkDate").Value
                If IsDate(dTrademarkDate) = False Then
                    MsgBox("Could not interpret date for " & .Cells("TrademarkName").Value & ".  Please check the selected data and try again.")
                End If
            End With

            dTrademarkDate = DateAdd("d", -iLeadDays, dTrademarkDate)
            If sngAlertTime <> 0 Then
                dTrademarkDate = DateAdd(DateInterval.Minute, sngAlertTime * 60, dTrademarkDate)
            End If

            'if saturday or sunday, move warning to Friday
            If Weekday(dTrademarkDate) = vbSunday Then dTrademarkDate = DateAdd("d", -2, dTrademarkDate)
            If Weekday(dTrademarkDate) = vbSaturday Then dTrademarkDate = DateAdd("d", -1, dTrademarkDate)

            'needed for restrict clause later
            strDayBefore = Format(DateAdd("d", -1, dTrademarkDate), "MMM dd, yyyy")
            strDayAfter = Format(DateAdd("d", 1, dTrademarkDate), "MMM dd, yyyy")

            objTask = objOutlook.CreateItem(Outlook.OlItemType.olAppointmentItem)

            With objTask
                .Subject = strSubject
                .Body = strBody
                .AllDayEvent = IIf(sngAlertTime = 0, True, False)
                .ReminderMinutesBeforeStart = 0
                .ReminderSet = True
                .Start = dTrademarkDate

            End With

            'reduce calendar items to those on this day, same subject
            colItems = colCalendarItems.Restrict("[Start]> '" & strDayBefore & "'")
            colItems = colItems.Restrict("[Start]< '" & strDayAfter & "'")
            colItems = colItems.Restrict("[Subject]=""" & strSubject & """")

            'to prevent adding same item on same day more than once
            If colItems.Count < 1 Then
                objTask.Save()
            End If

            objTask = Nothing

        Next i

        objOutlook = Nothing
        objTask = Nothing
        objTest = Nothing
        objNamespace = Nothing
        colItems = Nothing
        objCalendarFolder = Nothing

        MsgBox("Check your calendar to make sure items were added.")

    End Sub

#End Region  'alerts

#Region "Alert Emails"

    Private Sub GetEmailAlerts()
        On Error Resume Next
        Me.grdAlerts.DataSource = DataStuff.GetDataTable("Select * from qvwTrademarkEmailAlerts order by TrademarkDate, CompanyName")
    End Sub

    Private Sub grdAlerts_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.RecordUpdated
        On Error Resume Next
        Dim iTrademarkDateID As Long, bEmailSent As Boolean, bCompleted As Boolean, strSQL As String, iDateID As Integer
        iTrademarkDateID = Me.grdAlerts.GetValue("TrademarkDateID")
        iDateID = Me.grdAlerts.GetValue("DateID")


        If Me.optEmailAlerts.Checked = True Then
            bEmailSent = Me.grdAlerts.GetValue("EmailSent")
            If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                strSQL = "update tblTrademarkDates set EmailSent=" & IIf(bEmailSent = True, "-1", "0") &
                    " where TrademarkDateID=" & iTrademarkDateID
            Else
                strSQL = "update tblTrademarkDates set EmailSent=" & IIf(bEmailSent = True, "1", "0") &
                    " where TrademarkDateID=" & iTrademarkDateID
            End If
            DataStuff.RunSQL(strSQL)
        End If

        If Me.optAlerts.Checked = True Then
            bCompleted = Me.grdAlerts.GetValue("Completed")
            'if the DateID is zero, this is actually an Action Alert, not a TrademarkDate Alert
            'in the union query, TrademarkActionID is aliased as TrademarkDateID
            If iDateID <> 0 Then
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblTrademarkDates set Completed=" & IIf(bCompleted = True, "-1", "0") &
                        " where TrademarkDateID=" & iTrademarkDateID
                Else
                    strSQL = "update tblTrademarkDates set Completed=" & IIf(bCompleted = True, "1", "0") &
                        " where TrademarkDateID=" & iTrademarkDateID
                End If
            Else ' action alert
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblTrademarkActions set Completed=" & IIf(bCompleted = True, "-1", "0") &
                        " where TrademarkActionID=" & iTrademarkDateID
                Else
                    strSQL = "update tblTrademarkActions set Completed=" & IIf(bCompleted = True, "1", "0") &
                        " where TrademarkActionID=" & iTrademarkDateID
                End If
            End If



            DataStuff.RunSQL(strSQL)
        End If

        'NEW in version 5.0; can update from here, so run related updates, etc.
        If bCompleted = True Then

            Dim DateID As Integer, RecurNumber As Integer, TrademarkDate As Date, NoDay As Boolean, NoMonth As Boolean,
                        Completed As Boolean, IsLocked As Boolean, EmailSent As Boolean,
                        UpdateRelatives As Boolean, AddNext As Boolean, JurisdictionID As Integer

            With Me.grdAlerts
                TrademarkDate = IIf(IsDate(.GetValue("TrademarkDate")), .GetValue("TrademarkDate"), Date.MinValue)
                NoDay = False
                NoMonth = False
                Completed = True
                IsLocked = IIf(.GetValue("IsLocked") = True, True, False)
                EmailSent = IIf(.GetValue("EmailSent") = True, True, False)
                UpdateRelatives = True
                AddNext = True
                'if we're updating a treaty trademark, the jurisdiction of the dates isn't the same
                'as the jurisdiction of the mark itself ... e.g., mark is Germany, dates are Madrid Protocol
                JurisdictionID = .GetValue("JurisdictionID")
                DateID = .GetValue("DateID")
                RecurNumber = .GetValue("RecurNumber")
            End With

            Dim MD As New MarkDates
            With MD
                .TrademarkID = grdAlerts.GetValue("TrademarkID")
                .JurisdictionID = JurisdictionID
                .LoadMarkDates()
                .LoadJurisdictionDates()
                .EditTrademarkDate(DateID, RecurNumber, TrademarkDate, NoDay, NoMonth, Completed, IsLocked,
                    EmailSent, UpdateRelatives, AddNext, JurisdictionID)
                .UpdateRecurNumbers()
                .ReOrderTrademarkDates()
                .SaveChanges()
            End With

        End If

    End Sub

    Private Sub grdAlerts_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdAlerts.ColumnHeaderClick
        On Error Resume Next

        If e.Column.Key = "lnkSend" Then
            Dim GRow As Janus.Windows.GridEX.GridEXRow, i As Integer
            Dim OL As Outlook.Application, Email As Outlook.MailItem

            OL = GetObject(, "Outlook.Application")
            If OL Is Nothing Then
                OL = CreateObject("Outlook.Application")
            End If

            For i = 0 To Me.grdAlerts.RowCount - 1
                GRow = Me.grdAlerts.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                    GenerateEmails(GRow, Email)
                End If
            Next

            OL = Nothing
        End If

        'toggle all email alerts as sent or not sent
        If e.Column.Key = "EmailSent" Then
            Dim GRow As Janus.Windows.GridEX.GridEXRow, i As Integer, bSent As Boolean,
                strFilter As String, strSQL As String

            bSent = Not (Me.grdAlerts.GetValue("EmailSent"))
            strFilter = "("


            For i = 0 To Me.grdAlerts.RowCount - 1
                GRow = Me.grdAlerts.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    GRow.BeginEdit()
                    GRow.Cells("EmailSent").Value = bSent
                    GRow.EndEdit()
                    strFilter = strFilter & GRow.Cells("TrademarkDateID").Text & ","
                End If
            Next

            strFilter = strFilter & "0)"

            If bSent = True Then
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblTrademarkDates set EmailSent= -1 where TrademarkDateID in " & strFilter
                Else
                    strSQL = "update tblTrademarkDates set EmailSent= 1 where TrademarkDateID in " & strFilter
                End If
            Else
                strSQL = "update tblTrademarkDates set EmailSent= 0 where TrademarkDateID in " & strFilter
            End If

            DataStuff.RunSQL(strSQL)

        End If


    End Sub

    Private Sub GenerateEmails(ByVal GRow As Janus.Windows.GridEX.GridEXRow, ByVal Email As Outlook.MailItem)
        On Error Resume Next
        Dim strTo As String, strSubject As String, strMessage As String,
             drToList As OleDb.OleDbDataReader, strSQL As String

        strTo = ""
        strSQL = "SELECT distinct TrademarkDateID, AutoEmail, EmailSent, ReceivesAlerts, FirstName, LastName, ContactEmail " &
        "from qvwTrademarkDatesAndContacts WHERE AutoEmail <> 0 AND EmailSent = 0 AND ReceivesAlerts <> 0 " &
        "and  TrademarkDateID=" & GRow.Cells("TrademarkDateID").Value
        drToList = DataStuff.GetDataReader(strSQL)

        'don't bother if there are no recipients
        If drToList.HasRows = False Then
            MsgBox("There are no contacts designated to receive alert emails for the trademark.")
            Exit Sub
        End If


        While drToList.Read
            strTo = strTo & drToList("ContactEmail") & ";"
        End While

        strSubject = GRow.Cells("EmailSubjectLine").Value.ToString
        strMessage = GRow.Cells("EmailAlert").Value.ToString

        strMessage = Replace(strMessage, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strMessage = Replace(strMessage, "[TrademarkName]", GRow.Cells("TrademarkName").Value.ToString)
        strMessage = Replace(strMessage, "[ApplicationNumber]", GRow.Cells("ApplicationNumber").Value.ToString)
        strMessage = Replace(strMessage, "[RegistrationNumber]", GRow.Cells("RegistrationNumber").Value.ToString)
        strMessage = Replace(strMessage, "[FileNumber]", GRow.Cells("FileNumber").Value.ToString)
        strMessage = Replace(strMessage, "[ClientDocket]", GRow.Cells("ClientDocket").Value.ToString)
        strMessage = Replace(strMessage, "[OurDocket]", GRow.Cells("OurDocket").Value.ToString)
        strMessage = Replace(strMessage, "[Status]", GRow.Cells("Status").Value.ToString)
        strMessage = Replace(strMessage, "[RegistrationType]", GRow.Cells("RegistrationType").Value.ToString)
        strMessage = Replace(strMessage, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        strSubject = Replace(strSubject, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strSubject = Replace(strSubject, "[TrademarkName]", GRow.Cells("TrademarkName").Value.ToString)
        strSubject = Replace(strSubject, "[ApplicationNumber]", GRow.Cells("ApplicationNumber").Value.ToString)
        strSubject = Replace(strSubject, "[RegistrationNumber]", GRow.Cells("RegistrationNumber").Value.ToString)
        strSubject = Replace(strSubject, "[FileNumber]", GRow.Cells("FileNumber").Value.ToString)
        strSubject = Replace(strSubject, "[ClientDocket]", GRow.Cells("ClientDocket").Value.ToString)
        strSubject = Replace(strSubject, "[OurDocket]", GRow.Cells("OurDocket").Value.ToString)
        strSubject = Replace(strSubject, "[Status]", GRow.Cells("Status").Value.ToString)
        strSubject = Replace(strSubject, "[RegistrationType]", GRow.Cells("RegistrationType").Value.ToString)
        strSubject = Replace(strSubject, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        If RevaSettings.USADates = True Then
            strMessage = Replace(strMessage, "[TrademarkDate]", Format(GRow.Cells("TrademarkDate").Value, "MMM dd, yyyy"))
            strSubject = Replace(strSubject, "[TrademarkDate]", Format(GRow.Cells("TrademarkDate").Value, "MMM dd, yyyy"))
        Else
            strMessage = Replace(strMessage, "[TrademarkDate]", Format(GRow.Cells("TrademarkDate").Value, "dd MMM, yyyy"))
            strSubject = Replace(strSubject, "[TrademarkDate]", Format(GRow.Cells("TrademarkDate").Value, "dd MMM, yyyy"))
        End If

        GRow.BeginEdit()
        GRow.Cells("EmailSent").Value = True
        GRow.EndEdit()

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            strSQL = "update tblTrademarkDates set EmailSent= -1" &
                " where TrademarkDateID=" & GRow.Cells("TrademarkDateID").Value
        Else
            strSQL = "update tblTrademarkDates set EmailSent= 1" &
                " where TrademarkDateID=" & GRow.Cells("TrademarkDateID").Value
        End If
        DataStuff.RunSQL(strSQL)

        With Email
            .To = strTo
            .Subject = strSubject
            If RevaSettings.EmailHTML = True Then
                strMessage = strMessage.Replace(vbCrLf, "<p>")
                .HTMLBody = strMessage
            Else
                .Body = strMessage
            End If
            .Display()
        End With

    End Sub

#End Region

#End Region   'browse screen

#Region "Form - General Properties/Events"

    Private Sub frmTrademarks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmTrademarks = Me
        iTotalRecords = DataStuff.RecordCount

        'if there email alerts due, open that form
        If RevaData.DCount("TrademarkDateID", "qvwTrademarkEmailAlerts", "TrademarkID<>0") > 0 Then
            Me.optEmailAlerts.Checked = True
        End If

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            Me.sepDemo.Visible = True
            Me.lblDemo.Visible = True
        Else
            Me.sepDemo.Visible = False
            Me.lblDemo.Visible = False
        End If

        FormStatus = Status.ResetAll
        ContactView = ActionContactView.NormalView
        ClearNulls()
        SetDateFormats()
        GetTrademarksList()
        FillDropDowns()
        SetSecurity()
        SetContactActionView()
        'now we consider the form loaded, let stuff happen
        bFormLoaded = True
        SetBrowseGrid()
        SetOptions()
        SetNavigationButtons()

    End Sub

    Private Sub frmTrademarks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        SaveTrademark()
        SaveGridLayouts()
        AllForms.frmTrademarks = Nothing
        Globals.TrademarkID = 0

        'trying to get a clean close
        If AllForms.frmTrademarks Is Nothing And AllForms.frmPatents Is Nothing And AllForms.frmLogin Is Nothing _
        And AllForms.frmPreferences Is Nothing And AllForms.frmReports Is Nothing _
        And AllForms.frmCompanies Is Nothing And AllForms.frmOppositions Is Nothing Then

            Application.Exit()
        End If
    End Sub

    Private Sub ClearNulls()
        On Error Resume Next
        'just because certain null values have been a pain in the tootie
        DataStuff.RunSQL("update tblTrademarkActions set IsAlert = 0 where IsAlert Is null")
        DataStuff.RunSQL("update tblTrademarkActions set Completed = 0 where Completed Is null")
        DataStuff.RunSQL("update tblTrademarks set CheckStatus = 0 where CheckStatus Is null")
    End Sub

    Friend Sub SetDateFormats()
        On Error Resume Next
        With Me
            If RevaSettings.USADates = True Then
                .grdDates.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "MMM dd, yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "MMM dd, yyyy"
                .MarkStatusTo.CustomFormat = "MMM dd, yyyy"
                .MarkStatusFrom.CustomFormat = "MMM dd, yyyy"
                .grdStatusCheck.RootTable.Columns("DateRecorded").FormatString = "MMM dd, yyyy"
                .grdStatusCheck.RootTable.Columns("StatusDate").FormatString = "MMM dd, yyyy"
            Else
                .grdDates.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "dd MMM yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "dd MMM yyyy"
                .MarkStatusTo.CustomFormat = "dd MMM yyyy"
                .MarkStatusFrom.CustomFormat = "dd MMM yyyy"
                .grdStatusCheck.RootTable.Columns("DateRecorded").FormatString = "dd MMM yyyy"
                .grdStatusCheck.RootTable.Columns("StatusDate").FormatString = "dd MMM yyyy"
            End If
            'we'll go ahead and set defaults for the status check here
            .MarkStatusTo.Value = Date.Today
            .MarkStatusFrom.Value = Date.Today.AddDays(-7)
        End With
    End Sub

    Private Sub SetSecurity()
        On Error Resume Next

        Dim iSecurityLevel As Integer
        iSecurityLevel = Globals.SecurityLevel
        With Me
            '.StatusID.ReadOnly = (iSecurityLevel = 3)
            '.FilingBasisID.ReadOnly = (iSecurityLevel = 3)
            '.CompanyID.ReadOnly = (iSecurityLevel = 3)
            '.FileID.ReadOnly = (iSecurityLevel = 3)
            '.RegTypeID.ReadOnly = (iSecurityLevel = 3)
            '.JurisdictionID.ReadOnly = (iSecurityLevel = 3)

            .TrademarkName.ReadOnly = (iSecurityLevel = 3)
            .OurDocket.ReadOnly = (iSecurityLevel = 3)
            .ClientDocket.ReadOnly = (iSecurityLevel = 3)
            .ApplicationNumber.ReadOnly = (iSecurityLevel = 3)
            .AppInternational.ReadOnly = (iSecurityLevel = 3)
            .RegistrationNumber.ReadOnly = (iSecurityLevel = 3)
            .GoodsServices.ReadOnly = (iSecurityLevel = 3)
            .Comments.ReadOnly = (iSecurityLevel = 3)
            .Disclaimers.ReadOnly = (iSecurityLevel = 3)
            .GraphicPath.ReadOnly = (iSecurityLevel = 3)

            .btnAddContacts.Enabled = (iSecurityLevel < 3)
            .btnAddDates.Enabled = (iSecurityLevel < 3)
            .btnRemoveContacts.Enabled = (iSecurityLevel = 1)
            .btnAddTreatyFiling.Enabled = (iSecurityLevel < 3)
            .btnRemoveTreatyFiling.Enabled = (iSecurityLevel = 1)
            .btnNewTrademark.Enabled = (iSecurityLevel < 3)
            .btnCreateOpposition.Enabled = (iSecurityLevel < 3)
            .btnCheckStatus.Enabled = (iSecurityLevel < 3)
        End With

        'Janus has their own versions of true and false; have to use them
        Select Case iSecurityLevel
            Case 1 'TrademarkUser

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdActions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdContacts
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdDates
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdLicensed
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdTreatyFilings
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                Me.grdStatusCheck.RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red

            Case 2 'No Delete

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdActions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdContacts
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDates
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdLicensed
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdTreatyFilings
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                Me.grdStatusCheck.RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red

            Case 3 'View Only

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdActions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdContacts
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDates
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdLicensed
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdTreatyFilings
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                Me.grdStatusCheck.RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray

        End Select

    End Sub

    Private Sub SetNavigationButtons()
        On Error Resume Next
        With Me

            Select Case Globals.NavigateMarksFrom
                Case 0 'new record
                    .btnNextRecord.Enabled = False
                    .btnPrevRecord.Enabled = False
                    .RecordCount.Text = ""

                Case 1  'list view
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                    .grdList.Row < (grdList.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (.grdList.Row > 0)
                    .RecordCount.Text = (.grdList.Row + 1).ToString + " of " + .grdList.RowCount.ToString

                Case 2  'either alerts view
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                    .grdAlerts.Row < (grdAlerts.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (.grdAlerts.Row > 0)
                    .RecordCount.Text = (.grdAlerts.Row + 1).ToString + " of " + .grdAlerts.RowCount.ToString

                Case 3 'reports grid
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        AllForms.frmReports.grdMarks.Row < (AllForms.frmReports.grdMarks.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (AllForms.frmReports.grdMarks.Row > 0)
                    .RecordCount.Text = (AllForms.frmReports.grdMarks.Row + 1).ToString +
                        " of " + AllForms.frmReports.grdMarks.RowCount.ToString

                Case 4 'trademarks on companies form
                    .btnNextRecord.Enabled = False
                    .btnPrevRecord.Enabled = False
                    .RecordCount.Text = ""

                Case 5 'oppositions
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        AllForms.frmOppositions.grdClientMarks.Row < (AllForms.frmOppositions.grdClientMarks.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (AllForms.frmOppositions.grdClientMarks.Row > 0)
                    .RecordCount.Text = (AllForms.frmOppositions.grdClientMarks.Row + 1).ToString +
                        " of " + AllForms.frmOppositions.grdClientMarks.RowCount.ToString

                Case 6 'status update
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                    .grdStatusCheck.Row < (grdList.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (.grdList.Row > 0)
                    .RecordCount.Text = (.grdStatusCheck.Row + 1).ToString + " of " + .grdStatusCheck.RowCount.ToString
            End Select

            If Not (.Tabs.SelectedIndex = 1 Or .Tabs.SelectedIndex = 2) Then
                .RecordCount.Text = ""
            End If

        End With

    End Sub

    Friend Sub SetOptions()
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        With Me
            Select Case FormStatus
                Case Status.ResetAll
                    .grdRelated.Visible = False
                    .grdDates.RootTable.Columns("InMerge").Visible = False
                    .grdDates.RootTable.Columns("Completed").Visible = True
                    .pnlMerge.Visible = False
                    .grdContacts.Width = 925
                    .grdContacts.RootTable.Columns("InMerge").Visible = False
                    .grdContacts.RootTable.Columns("CompanyName").Width = 243
                    .pnlContacts.Width = 925
                    .grdActions.Width = 925
                    .chkMergeContacts.Checked = False

                Case Status.ShowRelated
                    GetTreatyTrademarks()
                    .grdRelated.Visible = True
                    .grdActions.Width = 588
                    .chkMergeContacts.Checked = False

                Case Status.Merging
                    .pnlMerge.Visible = True
                    .pnlMerge.Left = 634
                    .pnlMerge.Top = .pnlContacts.Top
                    .grdContacts.Width = 588
                    .grdDates.RootTable.Columns("InMerge").Visible = True
                    .grdDates.RootTable.Columns("Completed").Visible = False
                    .grdContacts.RootTable.Columns("InMerge").Visible = True
                    .grdContacts.RootTable.Columns("CompanyName").Width = 203
                    .pnlContacts.Width = 588

                    'set all merge fields in dates list and contact list to false
                    Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, iLastMergeType As Integer
                    For i = 0 To .grdDates.RowCount - 1
                        GRow = .grdDates.GetRow(i)
                        If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                            GRow.BeginEdit()
                            GRow.Cells("InMerge").Value = False
                            GRow.EndEdit()
                        End If
                    Next
                    For i = 0 To .grdContacts.RowCount - 1
                        GRow = .grdContacts.GetRow(i)
                        If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                            GRow.BeginEdit()
                            GRow.Cells("InMerge").Value = False
                            GRow.EndEdit()
                        End If
                    Next

                    iLastMergeType = My.Settings.LastMergeType
                    .optWord.Checked = (iLastMergeType = 1)
                    .optOutlook.Checked = (iLastMergeType = 3)
                    .optDate.Checked = (iLastMergeType = 4)
                    SetMergeOptions()


            End Select

            If RevaSettings.ShowHoursExpenses = True Then
                .grdActions.RootTable.Columns("ActionHours").Visible = True
                .grdActions.RootTable.Columns("ActionBilled").Visible = True
                .grdActions.RootTable.Columns("Expenses").Visible = True
                .grdActions.RootTable.Columns("ExpensesBilled").Visible = True
                .grdActions.RootTable.Columns("TrademarkAction").Width = 519
            Else
                .grdActions.RootTable.Columns("ActionHours").Visible = False
                .grdActions.RootTable.Columns("ActionBilled").Visible = False
                .grdActions.RootTable.Columns("Expenses").Visible = False
                .grdActions.RootTable.Columns("ExpensesBilled").Visible = False
                .grdActions.RootTable.Columns("TrademarkAction").Width = 700
            End If

        End With

    End Sub

    Private Sub grdContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdContacts.Click
        On Error Resume Next
        If Globals.SecurityLevel = 3 Then
            If grdContacts.CurrentColumn.Caption = "Merge" Then
                Dim GRow As Janus.Windows.GridEX.GridEXRow, bCurrentValue As Boolean
                GRow = grdContacts.CurrentRow
                bCurrentValue = GRow.Cells("InMerge").Value
                GRow.BeginEdit()
                GRow.Cells("InMerge").Value = (Not bCurrentValue)
                GRow.EndEdit()
            End If
        End If
    End Sub

    Private Sub grdDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDates.Click
        On Error Resume Next
        If Globals.SecurityLevel = 3 Then
            If grdDates.CurrentColumn.Caption = "Merge" Then
                Dim GRow As Janus.Windows.GridEX.GridEXRow, bCurrentValue As Boolean
                GRow = grdDates.CurrentRow
                bCurrentValue = GRow.Cells("InMerge").Value
                GRow.BeginEdit()
                GRow.Cells("InMerge").Value = (Not bCurrentValue)
                GRow.EndEdit()
            End If
        End If
    End Sub

    Friend Sub GetTrademark()
        On Error Resume Next
        Dim iOppositionID As Integer

        rsTrademarks.GetFromSQL("Select * from tblTrademarks where TrademarkID=" & Globals.TrademarkID)
        With rsTrademarks
            .BindData(Me.TrademarkTypeID)
            .BindData(Me.StatusID)
            .BindData(Me.FilingBasisID)
            .BindData(Me.CompanyID)
            .BindData(Me.FileID)
            .BindData(Me.TrademarkName)
            .BindData(Me.JurisdictionID)
            .BindData(Me.OurDocket)
            .BindData(Me.ClientDocket)
            .BindData(Me.ApplicationNumber)
            .BindData(Me.AppInternational)
            .BindData(Me.RegistrationNumber)
            .BindData(Me.GoodsServices)
            .BindData(Me.Comments)
            .BindData(Me.Disclaimers)
            .BindData(Me.GraphicPath)
            .BindData(Me.RegTypeID)
            .BindData(Me.GraphicSizeToFit)
            .BindData(Me.CheckStatus)
        End With

        Me.picGraphic.ImageLocation = ""
        'store these so we can warn user if they're changed later
        Me.iOldFilingBasisID = Nz(rsTrademarks.CurrentRow("FilingBasisID"), 0)
        Me.iOldJurisdictionID = Nz(rsTrademarks.CurrentRow("JurisdictionID"), 0)

        GetCompany()
        GetClasses()
        GetDates()
        GetMatters()
        GetActions()
        GetContacts()
        GetDocuments()
        GetLicensed()
        GetTreatyStatus()

        'need to re-set each time we open a new trademark
        bTreatyFilingsFilled = False

        iOppositionID = DataStuff.DMax("OppositionID", "tblOppositionClientTrademarks", "TrademarkID=" & Globals.TrademarkID)
        iOppositionID = Nz(iOppositionID, 0)
        If iOppositionID <> 0 Then
            Me.btnOpposition.Visible = True
            Me.btnOpposition.Tag = iOppositionID
        Else
            Me.btnOpposition.Visible = False
            Me.btnOpposition.Tag = 0
        End If

        Me.Tabs.Focus()

        SetOptions()
        SetNavigationButtons()
        SetMoreInfo()

        If Me.Tabs.SelectedIndex = 2 Then  'more information page
            GetGraphic()
        End If

    End Sub

    Friend Sub GetTreatyStatus()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader, iTrademarkID As Integer
        iTrademarkID = Nz(rsTrademarks.CurrentRow("TrademarkID"), 0)
        dr = DataStuff.GetDataReader("Select * from tblTreatyFilingTrademarks where TrademarkID=" & iTrademarkID)
        dr.Read()

        With Me
            If dr.HasRows Then
                If dr("IsBasis") = True Then
                    bIsTreaty = False
                    bIsBasis = True
                Else
                    bIsTreaty = True
                    bIsBasis = False
                End If
                .chkShowRelated.Visible = True
                .lblIsRelated.Visible = True
                Globals.TreatyFilingID = dr("TreatyFilingID")
            Else
                bIsTreaty = False
                .chkShowRelated.Visible = False
                .lblIsRelated.Visible = False
                'user may have navigated to non-treaty mark with "show related" still checked
                If .chkShowRelated.Checked = True Then
                    .chkShowRelated.Checked = False
                End If
            End If
        End With

    End Sub

    Friend Sub GetCompany()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader, iCompanyID As Integer, strSQL As String
        iCompanyID = Nz(rsTrademarks.CurrentRow("CompanyID"), 0)

        strSQL = "SELECT CompanyID, CompanyName, City, StateProvince, PostalCode, Country, CompanyPhone," &
       "AddressOne, AddressTwo from tblCompanies where CompanyID=" & iCompanyID

        dr = DataStuff.GetDataReader(strSQL)

        dr.Read()
        With Me
            .City.Text = ""
            .StateProvince.Text = ""
            .Country.Text = ""
            .PostalCode.Text = ""
            .CompanyPhone.Text = ""

            If iCompanyID > 0 Then
                .City.Text = dr("City")
                .StateProvince.Text = dr("StateProvince")
                .Country.Text = dr("Country")
                .PostalCode.Text = dr("PostalCode")
                .CompanyPhone.Text = dr("CompanyPhone")
            End If

        End With
    End Sub

    Friend Sub SaveTrademark()
        On Error Resume Next
        ' the replace is to protect customers against themselves.  A carriage return hoses merges.
        With Me
            'If .Disclaimers.Text.Contains(vbCrLf) Then
            '    .Disclaimers.Text = Disclaimers.Text.Replace(vbCrLf, " ")
            'End If
            'If .Comments.Text.Contains(vbCrLf) Then
            '    .Comments.Text = Comments.Text.Replace(vbCrLf, " ")
            'End If
            'If .GoodsServices.Text.Contains(vbCrLf) Then
            '    .GoodsServices.Text = GoodsServices.Text.Replace(vbCrLf, " ")
            'End If
        End With
        rsTrademarks.Update()
    End Sub

    Private Sub tbTrademark_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTrademark.Leave
        On Error Resume Next
        SaveTrademark()
        LockAndLoadActions()
        Me.grdClasses.UpdateData()
        rsTrademarkClasses.Update()
    End Sub

    Private Sub SetMoreInfo()
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        With Me
            .ShowCompany.Text = .CompanyID.Text
            .ShowApplication.Text = .ApplicationNumber.Text
            .ShowRegistration.Text = .RegistrationNumber.Text
            .ShowTrademark.Text = .TrademarkName.Text
            .ShowJurisdiction.Text = .JurisdictionID.Text
        End With
        ' new in version 5; don't bother with a table, just read from classes grid
        With Me.grdShowClasses
            .ClearItems()
            For i = 0 To Me.grdClasses.RowCount - 1
                GRow = Me.grdClasses.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    .AddItem()
                    .MoveLast()
                    .SetValue("RegClass", GRow.Cells("RegClassID").Text)
                End If
            Next
            .MoveFirst()
            .UpdateData()
        End With

    End Sub

    Private Sub tbMoreInfo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMoreInfo.Enter
        On Error Resume Next
        SetMoreInfo()
    End Sub

    Private Sub tbMoreInfo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMoreInfo.Leave
        On Error Resume Next
        SaveTrademark()
    End Sub

    Private Sub tbTreatyFilings_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTreatyFilings.Enter
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        With Me
            .ShowCompany2.Text = .CompanyID.Text
            .ShowApplication2.Text = .ApplicationNumber.Text
            .ShowRegistration2.Text = .RegistrationNumber.Text
            .ShowTrademark2.Text = .TrademarkName.Text
            .ShowJurisdiction2.Text = .JurisdictionID.Text
        End With
        ' new in version 5; don't bother with a table, just read from classes grid
        With Me.grdShowClasses2
            .ClearItems()
            For i = 0 To Me.grdClasses.RowCount - 1
                GRow = Me.grdClasses.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    .AddItem()
                    .MoveLast()
                    .SetValue("RegClass", GRow.Cells("RegClassID").Text)
                End If
            Next
            .MoveFirst()
            .UpdateData()
        End With
        SetTreatyFilingPage()
    End Sub

    Private Sub Tabs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.SelectedIndexChanged
        On Error Resume Next
        'keep user from opening empty data forms
        If (Me.Tabs.SelectedIndex = 1) Or (Me.Tabs.SelectedIndex = 2) Or (Me.Tabs.SelectedIndex = 3) Then
            If (Globals.TrademarkID = 0) Then
                Me.Tabs.SelectedIndex = 0
            End If
        End If

        SetNavigationButtons()

        If Me.Tabs.SelectedIndex = 2 Then  'more information page
            GetGraphic()
        End If
    End Sub

    Private Sub Tabs_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles Tabs.Selecting
        On Error Resume Next
        'keep user from opening empty data forms
        If (Me.Tabs.SelectedIndex = 1) Or (Me.Tabs.SelectedIndex = 2) Or (Me.Tabs.SelectedIndex = 3) Then
            If (Globals.TrademarkID = 0) Then
                Me.Tabs.SelectedIndex = 0
            End If
        End If

        If Me.Tabs.SelectedIndex = 2 Then  'more information page
            GetGraphic()
        End If
    End Sub

    Private Sub CompanyID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CompanyID.Validated
        On Error Resume Next
        SaveTrademark()
        GetCompany()
        AddContacts()
        GetMatters()
    End Sub

    Private Sub JurisdictionID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JurisdictionID.Validated
        On Error Resume Next

        'user changed jurisdictions of the trademark
        If (Nz(Me.JurisdictionID.Value, 0) <> Me.iOldJurisdictionID) And (Nz(Me.iOldJurisdictionID, 0) <> 0) Then

            'make sure we're on trademark page
            Me.Tabs.SelectedIndex = 1
            Dim strMessage As String

            'can't do this for treaty trademark
            If Me.bIsTreaty = True Then
                strMessage = "You cannot change the jurisdiction of a trademark filed under a treaty agreement. " &
                    "To change the jurisdiction, first remove this trademark from the treaty filing."
                MsgBox(strMessage)
                Me.JurisdictionID.Value = Me.iOldJurisdictionID
                Exit Sub
            End If

            strMessage = "You are about to change the jurisdiction for this trademark.  " &
                "Trademark dates with the same names will remain intact, " &
                "but others will be deleted.  Proceed?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.JurisdictionID.Value = Me.iOldJurisdictionID
                Exit Sub
            End If


            SaveTrademark()
            Dim MDate As New MarkDates
            With MDate
                .TrademarkID = Globals.TrademarkID
                .JurisdictionID = Me.JurisdictionID.Value
                .LoadMarkDates()
                .LoadJurisdictionDates()
                .ChangeJurisdiction()
                .UpdateRecurNumbers()
                .ReOrderTrademarkDates()
                .SaveChanges()
            End With
            MDate = Nothing

        End If

        SaveTrademark()
        Dim MD As New MarkDates
        With MD
            .TrademarkID = Globals.TrademarkID
            .JurisdictionID = Nz(Me.JurisdictionID.Value, 0)
            .LoadMarkDates()
            .LoadJurisdictionDates()
            .AppendFilingBasisDates(Nz(Me.FilingBasisID.Value, 0))
            .AppendStatusDates(Nz(Me.StatusID.Value, 0))
            .UpdateRecurNumbers()
            .ReOrderTrademarkDates()
            .SaveChanges()
        End With
        MD = Nothing

        Me.iOldJurisdictionID = Me.JurisdictionID.Value
        GetDates()

    End Sub

    Private Sub FilingBasisID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilingBasisID.Validated
        On Error Resume Next
        Dim bNewBasisIsTreaty As Boolean, iJurisdictionID As Integer

        If DataStuff.DLookup("IsTreaty", "tblFilingBasis", "FilingBasisID=" & Me.FilingBasisID.Value) <> 0 Then
            bNewBasisIsTreaty = True
            Me.bIsTreaty = True
            iJurisdictionID = Me.FilingBasisID.Value * (-1)
        Else
            bNewBasisIsTreaty = False
            Me.bIsTreaty = False
            iJurisdictionID = Me.JurisdictionID.Value
        End If

        'if user changes from a treaty filing basis to a non-treaty filing basis or vice versa,
        'it's the same as changing jurisdictions as far as dates
        If (Nz(Me.FilingBasisID.Value, 0) <> Me.iOldFilingBasisID) And (Nz(Me.iOldFilingBasisID, 0) <> 0) Then
            If (Me.bIsTreaty = True) Or (bNewBasisIsTreaty = True) Then

                'make sure we're on trademark page
                Me.Tabs.SelectedIndex = 1

                Dim strMessage As String

                strMessage = "You are about to change to or from a treaty filing basis with its own date template." &
                "  Trademark dates with the same names will remain intact, but others will be deleted.  Proceed?"

                If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Me.FilingBasisID.Value = Me.iOldFilingBasisID
                    SaveTrademark()
                    GetTrademark()
                    Exit Sub
                End If

                SaveTrademark()

                Dim MDate As New MarkDates
                With MDate
                    .TrademarkID = Globals.TrademarkID
                    .JurisdictionID = iJurisdictionID
                    .LoadMarkDates()
                    .LoadJurisdictionDates()
                    .ChangeJurisdiction()
                    .UpdateRecurNumbers()
                    .ReOrderTrademarkDates()
                    .SaveChanges()
                End With
                MDate = Nothing

            End If
        End If

        SaveTrademark()

        Dim MD As New MarkDates
        With MD
            .TrademarkID = Globals.TrademarkID
            .JurisdictionID = iJurisdictionID
            .LoadMarkDates()
            .LoadJurisdictionDates()
            .AppendFilingBasisDates(Me.FilingBasisID.Value)
            .UpdateRecurNumbers()
            .ReOrderTrademarkDates()
            .SaveChanges()
        End With
        MD = Nothing

        GetDates()

    End Sub

    Private Sub StatusID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.Validated
        On Error Resume Next
        Dim iJurisdictionID As Integer

        If Me.bIsTreaty = True Then
            iJurisdictionID = Me.FilingBasisID.Value * (-1)
        Else
            iJurisdictionID = Me.JurisdictionID.Value
        End If

        SaveTrademark()

        If (Nz(Me.StatusID.Value, 0) <> 0) And Nz(iJurisdictionID, 0) <> 0 Then
            Dim MD As New MarkDates
            With MD
                .TrademarkID = Globals.TrademarkID
                .JurisdictionID = iJurisdictionID
                .LoadMarkDates()
                .LoadJurisdictionDates()
                .AppendStatusDates(Me.StatusID.Value)
                .UpdateRecurNumbers()
                .ReOrderTrademarkDates()
                .SaveChanges()
            End With
            MD = Nothing
            GetDates()
        End If

    End Sub

    Private Sub btnPrintOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOne.Click
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        Dim drReader As OleDb.OleDbDataReader, rptTrademark As New rtpOneTrademark, strSQL As String
        strSQL = SQL.vwReportTrademarks & " where TrademarkID=" & Globals.TrademarkID &
                " order by qvwTradeMarkDates.CompanyName, TrademarkName, TrademarkDate"
        drReader = DataStuff.GetDataReader(strSQL)
        rptTrademark.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptTrademark.Document
        rptTrademark.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOpposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpposition.Click
        On Error Resume Next
        Globals.OppositionID = Me.btnOpposition.Tag
        Globals.NavigateOppositionsFrom = 3
        AllForms.OpenOppositions()
        AllForms.frmOppositions.GetOpposition()
    End Sub

    Private Sub TrademarkName_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkName.DoubleClick
        On Error Resume Next
        Dim f As New frmCopyTrademarkName
        f.Show()
    End Sub

#Region "Link buttons"

    Private Sub btnRegType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegType.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmTrademarkPopups
        f.GetRecordset(1)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnRegClasses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegClasses.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmTrademarkPopups
        f.GetRecordset(2)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnFilingBasis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilingBasis.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmTrademarkPopups
        f.GetRecordset(3)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Try
            SaveTrademark()
            Dim f As New frmStatus
            f.ShowDialog(Me)
            f = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJurisdiction.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmGeneralPopups
        f.GetRecordset(5)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnTrademarkType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrademarkType.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmGeneralPopups
        f.GetRecordset(10)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompany.Click
        On Error Resume Next
        If Nz(Me.CompanyID.Value, 0) = 0 Then Exit Sub
        SaveTrademark()
        AllForms.OpenCompanies()
        Globals.CompanyID = Me.CompanyID.Value
        AllForms.frmCompanies.GetCompany()
        AllForms.frmCompanies.Tabs.SelectedIndex = 1
    End Sub

    Private Sub btnFileMatter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileMatter.Click
        On Error Resume Next
        SaveTrademark()
        Dim f As New frmGeneralPopups
        f.GetRecordset(7)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnAppInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppInt.Click
        On Error Resume Next
        Dim strSQL As String

        If Nz(Me.FilingBasisID.Value, 0) = 0 Then
            MsgBox("You must select a treaty filing basis before using the international application link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strAppNumber As String,
            bUsesFields As Boolean, strFieldName As String

        strSQL = "Select * from tblFilingBasis where FilingBasisID=" & Me.FilingBasisID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("ApplicationURL") & ""

        If strTargetURL = "" Then
            MsgBox("Application search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("ApplicationUsesFields")
        strFieldName = dr("ApplicationField")
        strAppNumber = Me.AppInternational.Text & ""
        If dr("ApplicationNumbersOnly") = True Then strAppNumber = NumbersOnly(strAppNumber)
        strTargetURL = Replace(strTargetURL, "[ApplicationNumber]", strAppNumber)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .FieldName = strFieldName & ""
                .SearchNumber = strAppNumber & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With
    End Sub

    Private Sub btnApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplication.Click
        On Error Resume Next
        Dim strSQL As String

        If Nz(Me.JurisdictionID.Value, 0) = 0 Then
            MsgBox("You must select a jurisdiction before using the application link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strAppNumber As String,
            bUsesFields As Boolean, strFieldName As String

        strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("ApplicationURL") & ""

        If strTargetURL = "" Then
            MsgBox("Application search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("ApplicationUsesFields")
        strFieldName = dr("ApplicationField")
        strAppNumber = Me.ApplicationNumber.Text & ""
        If dr("ApplicationNumbersOnly") = True Then strAppNumber = NumbersOnly(strAppNumber)
        strTargetURL = Replace(strTargetURL, "[ApplicationNumber]", strAppNumber)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .FieldName = strFieldName & ""
                .SearchNumber = strAppNumber & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With

    End Sub

    Private Sub btnRegistration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistration.Click
        On Error Resume Next
        Dim strSQL As String

        If Me.bIsTreaty = False Then
            If Nz(Me.JurisdictionID.Value, 0) = 0 Then
                MsgBox("You must select a jurisdiction before using the Registration link.")
                Exit Sub
            End If
        Else
            If Nz(Me.FilingBasisID.Value, 0) = 0 Then
                MsgBox("You must select a jurisdiction before using the Registration link.")
                Exit Sub
            End If
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strRegNumber As String,
            bUsesFields As Boolean, strFieldName As String

        If Me.bIsTreaty = False Then
            strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value
        Else
            strSQL = "Select * from tblFilingBasis where FilingBasisID=" & Me.FilingBasisID.Value
        End If


        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("RegistrationURL") & ""


        If strTargetURL = "" Then
            MsgBox("Registration search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("RegistrationUsesFields")
        strFieldName = dr("RegistrationField")
        strRegNumber = Me.RegistrationNumber.Text & ""
        If dr("RegistrationNumbersOnly") = True Then strRegNumber = NumbersOnly(strRegNumber)
        strTargetURL = Replace(strTargetURL, "[RegistrationNumber]", strRegNumber)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .btnGetNumber.Text = "Get Registration Number"
                .FieldName = strFieldName & ""
                .SearchNumber = strRegNumber & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With
    End Sub

#End Region

#Region "Kill The Wheel"

    Private Sub ComboClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkTypeID.ButtonClick, StatusID.ButtonClick, RegTypeID.ButtonClick, JurisdictionID.ButtonClick, FilingBasisID.ButtonClick, FileID.ButtonClick, CompanyID.ButtonClick
        ' to prevent the mouse scroll wheel from changing values, drop-downs are ready-only until opened
        On Error Resume Next
        If Globals.SecurityLevel < 3 Then
            Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
            Combo = sender
            Combo.ReadOnly = False
            Combo.DroppedDown = True
        End If
    End Sub

    Private Sub ComboCloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkTypeID.CloseUp, StatusID.CloseUp, RegTypeID.CloseUp, JurisdictionID.CloseUp, FilingBasisID.CloseUp, FileID.CloseUp, CompanyID.CloseUp
        On Error Resume Next
        Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Combo = sender
        Combo.ReadOnly = True
    End Sub

#End Region

#Region "Escape/Undo for TextBoxes"

    Private Sub TrademarkName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrademarkName.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.TrademarkName.Undo()
    End Sub

    Private Sub OurDocket_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OurDocket.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.OurDocket.Undo()
    End Sub

    Private Sub ClientDocket_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ClientDocket.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.ClientDocket.Undo()
    End Sub

    Private Sub RegistrationNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RegistrationNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.RegistrationNumber.Undo()
    End Sub

    Private Sub ApplicationNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ApplicationNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.ApplicationNumber.Undo()
    End Sub

    Private Sub GoodsServices_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GoodsServices.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.GoodsServices.Undo()
    End Sub

    Private Sub Comments_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Comments.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Comments.Undo()
    End Sub

    Private Sub Disclaimers_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Disclaimers.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Disclaimers.Undo()
    End Sub

#End Region

#End Region

#Region "Fill Data Tables / Drop Downs"

    Friend Sub FillDropDowns()
        Try

            Me.JurisdictionID.DataSource = RevaData.tblTrademarkJurisdicitons
            Me.CompanyID.DataSource = RevaData.tblCompaniesList
            Me.grdLicensed.DropDowns("cboCompany").SetDataBinding(RevaData.tblCompaniesList, "")
            Me.FilingBasisID.DataSource = RevaData.tblTrademarkFilingBasis

            Me.grdContacts.DropDowns("cboContact").SetDataBinding(RevaData.tblContactsList, "")
            Me.grdContacts.DropDowns("cboPositions").SetDataBinding(RevaData.tblTrademarkPositions, "")

            Me.StatusID.DataSource = RevaData.tblTrademarkStatus
            Me.grdTreatyFilings.DropDowns("cboStatus").SetDataBinding(RevaData.tblTrademarkStatus, "")

            Me.TrademarkTypeID.DataSource = RevaData.tblTrademarkTypes
            Me.RegTypeID.DataSource = RevaData.tblTrademarkRegTypes

            Me.grdClasses.RootTable.Columns("RegClassID").ValueList.Clear()
            For Each dr As DataRow In RevaData.tblTrademarkRegClasses.Rows
                Me.grdClasses.RootTable.Columns("RegClassID").ValueList.Add(dr("RegClassID"), dr("RegClass"))
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetTrademarksList()
        On Error Resume Next

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            Dim strSQL As String
            strSQL = SQL.vwTrademarksList
            dtTrademarksList = DataStuff.GetDataTable(strSQL)
        Else
            dtTrademarksList = RevaData.GetTrademarksList()
        End If

        Me.grdList.DataSource = dtTrademarksList
        Me.grdList.Row = 0
    End Sub

#End Region

#Region "Fill Grid Subforms"

    Private Sub GetClasses()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "select * from tblTrademarkRegClasses where TrademarkID=" & Globals.TrademarkID
        rsTrademarkClasses.GetFromSQL(strSQL)
        Me.grdClasses.DataSource = rsTrademarkClasses.Table
    End Sub

    Private Sub GetActions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblTrademarkActions where TrademarkID=" & Globals.TrademarkID &
            " order by ActionDate, TrademarkActionID"
        rsActions.GetFromSQL(strSQL)
        Me.grdActions.DataSource = rsActions.Table
    End Sub

    Friend Sub GetContacts()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "SELECT TrademarkContactID, CompanyID, ContactID, ContactName, ContactCompany as CompanyName, ContactPhone, " &
        "PositionID, TrademarkID, ContactEmail, WordExcel, PositionName from qvwTrademarkContacts where TrademarkID=" & Globals.TrademarkID
        dtContacts = DataStuff.GetDataTable(strSQL)
        Me.grdContacts.DataSource = dtContacts
    End Sub

    Friend Sub GetMatters()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from qvwClientMattersLinked WHERE CompanyID=" &
            Nz(rsTrademarks.CurrentRow("CompanyID"), 0) & " order by FileNumber"
        dtMatters = DataStuff.GetDataTable(strSQL)
        Me.FileID.DataSource = dtMatters
    End Sub

    Friend Sub GetDates()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "SELECT TrademarkDateID, TrademarkID, JurisdictionDateID, JurisdictionID, DateID, DateName, TrademarkDate, " &
        "NoDay, NoMonth, ListOrder, Completed, IsLocked, RecursAtInterval, HasRelatives, IsRelative " &
        "from qvwTrademarkDates where TrademarkID=" & Globals.TrademarkID & " order by ListOrder"
        dtDates = DataStuff.GetDataTable(strSQL)
        Me.grdDates.DataSource = dtDates
    End Sub

    Friend Sub GetDocuments()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblTrademarkDocuments where TrademarkID=" & Globals.TrademarkID
        dtDocLinks = DataStuff.GetDataTable(strSQL)
        Me.grdDocumentLinks.DataSource = dtDocLinks
    End Sub

    Friend Sub GetLicensed()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblTrademarksLicensed where TrademarkID=" & Globals.TrademarkID
        dtLicensed = DataStuff.GetDataTable(strSQL)
        Me.grdLicensed.DataSource = dtLicensed
    End Sub

#End Region

#Region "Actions Grid"

    Private Sub LockAndLoadActions()
        On Error Resume Next
        If Me.grdActions.RowCount = 0 Then Exit Sub
        Dim iTop As Integer, iRow As Integer
        'to avoid concurrence conflicts if user moves away and comes back
        iTop = Me.grdActions.FirstRow
        iRow = Me.grdActions.Row
        Me.grdActions.UpdateData()
        rsActions.Update()
        GetActions()
        Me.grdActions.FirstRow = iTop
        Me.grdActions.Row = iRow
    End Sub

    Private Sub grdActions_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdActions.AddingRecord
        On Error Resume Next
        Me.grdActions.SetValue("TrademarkID", Globals.TrademarkID)
        If Not IsDate(Me.grdActions.GetValue("ActionDate")) Then Me.grdActions.SetValue("ActionDate", Date.Now)
    End Sub

    Private Sub grdActions_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdActions.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this action?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdActions.CurrentRow.Delete()
        End If
    End Sub

#End Region

#Region "Classes Grid"

    Private Sub grdClasses_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdClasses.AddingRecord
        On Error Resume Next
        Me.grdClasses.SetValue("TrademarkID", Globals.TrademarkID)
    End Sub

    Private Sub grdClasses_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdClasses.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this class from the trademark?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdClasses.CurrentRow.Delete()
        End If
    End Sub

#End Region

#Region "Actions/Contacts View"

    Private Enum ActionContactView As Integer
        NormalView = 0
        ExpandAction = 1
        ExpandContact = 2
    End Enum

    Dim ContactView As ActionContactView

    Private Sub btnContractActions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractActions.Click
        On Error Resume Next
        ContactView = ActionContactView.NormalView
        SetContactActionView()
    End Sub

    Private Sub btnExpandActions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpandActions.Click
        On Error Resume Next
        ContactView = ActionContactView.ExpandAction
        SetContactActionView()
    End Sub

    Private Sub btnExpandContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpandContacts.Click
        On Error Resume Next
        ContactView = ActionContactView.ExpandContact
        SetContactActionView()
    End Sub

    Private Sub btnContractContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractContacts.Click
        On Error Resume Next
        ContactView = ActionContactView.NormalView
        SetContactActionView()
    End Sub

    Private Sub SetContactActionView()
        On Error Resume Next
        With Me
            Select Case ContactView
                Case ActionContactView.NormalView
                    .grdActions.Height = 164
                    .grdActions.Visible = True
                    .grdContacts.Top = 532
                    .grdContacts.Height = 96
                    .grdContacts.Visible = True
                    .pnlContacts.Visible = True
                    .pnlContacts.Top = 508
                    .btnExpandActions.Visible = True
                    .btnExpandActions.Top = 472
                    .btnExpandContacts.Visible = True
                    .btnExpandContacts.Top = 505
                    .btnContractActions.Visible = False
                    .btnContractContacts.Visible = False
                    .pnlMerge.Visible = .chkMergeContacts.Checked

                Case ActionContactView.ExpandAction
                    .grdActions.Height = 285
                    .grdActions.Visible = True
                    .grdContacts.Visible = False
                    .pnlContacts.Visible = False
                    .btnExpandActions.Visible = False
                    .btnExpandContacts.Visible = False
                    .btnContractActions.Visible = True
                    .btnContractActions.Top = 590
                    .btnContractContacts.Visible = False
                    .pnlMerge.Visible = False

                Case ActionContactView.ExpandContact
                    .grdActions.Visible = False
                    .grdContacts.Top = 355
                    .grdContacts.Height = 260
                    .grdContacts.Visible = True
                    .pnlContacts.Visible = True
                    .pnlContacts.Top = 330
                    .btnExpandActions.Visible = False
                    .btnExpandContacts.Visible = False
                    .btnContractActions.Visible = False
                    .btnContractContacts.Visible = True
                    .btnContractContacts.Top = grdContacts.Top
                    .pnlMerge.Visible = .chkMergeContacts.Checked
            End Select
            If .chkMergeContacts.Checked Then
                .pnlMerge.Top = .pnlContacts.Top
            End If
        End With
    End Sub

#End Region

#Region "Contacts Grid"

    Private Sub AddContacts()
        On Error Resume Next
        Dim iCompanyID As Integer, strSQL As String
        iCompanyID = Nz(Me.CompanyID.Value, 0)
        If iCompanyID = 0 Then Exit Sub

        strSQL = "Insert into tblTrademarkContacts (TrademarkID, ContactID, PositionID) Select " &
            Globals.TrademarkID & ", ContactID, PositionID from tblContacts where CompanyID=" & iCompanyID &
                " and PositionID is not null and PositionID in (Select PositionID from tblPositions" &
                " where IsTrademark <> 0)"
        DataStuff.RunSQL(strSQL)

        GetContacts()

    End Sub

    Private Sub grdContacts_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "PositionID" Then
            SaveTrademark()
            Dim f As New frmGeneralPopups
            f.GetRecordset(6)
            f.ShowDialog(Me)
            f = Nothing
        End If

        If e.Column.Key = "ContactEmail" Then
            Me.Cursor = Cursors.WaitCursor
            Dim OL As Outlook.Application, Email As Outlook.MailItem, strTo As String, strSubject As String,
                GRow As Janus.Windows.GridEX.GridEXRow, i As Integer

            strSubject = ""
            strTo = ""

            For i = 0 To Me.grdContacts.SelectedItems.Count - 1
                GRow = Me.grdContacts.SelectedItems(i).GetRow
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    If (GRow.Cells("ContactEmail").Value & "" <> "") Then
                        strTo = strTo & GRow.Cells("ContactEmail").Value & ";"
                    End If
                End If
            Next i

            If strTo <> "" Then
                OL = GetObject(, "Outlook.Application")
                If OL Is Nothing Then
                    OL = CreateObject("Outlook.Application")
                End If
                Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                With Me
                    strSubject = .CompanyID.Text & " | " & .TrademarkName.Text & " | " & .JurisdictionID.Text &
                        " | App# " & .ApplicationNumber.Text
                    If .RegistrationNumber.Text & "" <> "" Then
                        strSubject = strSubject & " | Reg# " & .RegistrationNumber.Text
                    End If
                End With
                With Email
                    .Subject = strSubject
                    .To = strTo
                    .Display()
                End With
            End If
            OL = Nothing
            Email = Nothing
            Me.Cursor = Cursors.Default

        End If
    End Sub

    Private Sub grdContacts_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.LinkClicked
        On Error Resume Next

        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            If MsgBox("Are you sure you want to delete this contact from the trademark?",
                MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iTrademarkContactID As Integer
            iTrademarkContactID = Me.grdContacts.GetValue("TrademarkContactID")
            strSQL = "Delete from tblTrademarkContacts where TrademarkContactID=" & iTrademarkContactID
            DataStuff.RunSQL(strSQL)
            GetContacts()
        End If

        If e.Column.Key = "ContactEmail" Then
            Me.Cursor = Cursors.WaitCursor
            Dim OL As Outlook.Application, Email As Outlook.MailItem, strTo As String, strSubject As String
            strTo = Me.grdContacts.GetValue("ContactEmail") & ""
            strSubject = ""
            If strTo <> "" Then
                If OL Is Nothing Then
                    OL = CreateObject("Outlook.Application")
                Else
                    OL = GetObject(, "Outlook.Application")
                End If
                Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                With Me
                    strSubject = .CompanyID.Text & " | " & .TrademarkName.Text & " | " & .JurisdictionID.Text &
                        " | App# " & .ApplicationNumber.Text
                    If .RegistrationNumber.Text & "" <> "" Then
                        strSubject = strSubject & " | Reg# " & .RegistrationNumber.Text
                    End If
                End With
                With Email
                    .Subject = strSubject
                    .To = strTo
                    .Display()
                End With
            End If
            OL = Nothing
            Email = Nothing
            Me.Cursor = Cursors.Default
        End If

        If e.Column.Key = "CompanyName" Then
            SaveTrademark()
            Globals.CompanyID = Me.grdContacts.GetValue("CompanyID")
            AllForms.OpenCompanies()
            AllForms.frmCompanies.GetCompany()
            AllForms.frmCompanies.Tabs.SelectedIndex = 1

        End If
    End Sub

    Private Sub grdContacts_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContacts.RecordAdded
        On Error Resume Next
        Dim rsContacts As New RecordSet, dRow As DataRow
        With Me.grdContacts
            rsContacts.GetFromSQL("Select * from tblTrademarkContacts where TrademarkContactID=0")
            dRow = rsContacts.Table.Rows.Add
            dRow("TrademarkID") = Globals.TrademarkID
            dRow("PositionID") = .GetValue("PositionID")
            dRow("ContactID") = .GetValue("ContactID")
        End With
        rsContacts.Update()
        GetContacts()
    End Sub

    Private Sub grdContacts_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContacts.RecordUpdated
        On Error Resume Next
        If FormStatus = Status.ResetAll Then
            Dim rsContacts As New RecordSet, dRow As DataRow
            With Me.grdContacts
                rsContacts.GetFromSQL("Select * from tblTrademarkContacts where TrademarkContactID=" &
                    .GetValue("TrademarkContactID"))
                dRow = rsContacts.CurrentRow
                dRow("PositionID") = .GetValue("PositionID")
                dRow("ContactID") = .GetValue("ContactID")
            End With
            rsContacts.Update()
            GetContacts()
        End If
    End Sub

    Private Sub chkMergeContacts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMergeContacts.CheckedChanged
        On Error Resume Next
        If Me.chkMergeContacts.Checked = True Then
            FormStatus = Status.Merging
        Else
            FormStatus = Status.ResetAll
        End If
        SetOptions()
    End Sub

#End Region

#Region "Documents Grid"

    Private Sub grdDocumentLinks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDocumentLinks.LinkClicked
        On Error Resume Next
        If e.Column.Key = "SetLink" Then

            If Globals.SecurityLevel = 3 Then Exit Sub

            If grdDocumentLinks.GetValue("IsFolder") = False Then
                With Me.OpenFileDialog
                    If My.Settings.DemoConnection = My.Settings.CurrentConnection Then
                        .InitialDirectory = RevaSettings.TrademarkDocumentsDemo
                    Else
                        .InitialDirectory = RevaSettings.TrademarkDocuments
                    End If
                    .FileName = ""
                    .Filter = "Word Documents (*.docx)|*.docx|All Files|*.*"
                    .FilterIndex = 1
                    .RestoreDirectory = False
                    .ShowDialog()
                    If Len(.FileName & "") > 3 Then
                        Me.grdDocumentLinks.SetValue("DocumentLink", .FileName & "")
                    End If
                End With
            Else
                With Me.FolderBrowserDialog
                    If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                        .SelectedPath = RevaSettings.TrademarkDocumentsDemo
                    Else
                        .SelectedPath = RevaSettings.TrademarkDocuments
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.grdDocumentLinks.SetValue("DocumentLink", .SelectedPath & "")
                    End If
                End With
            End If

        End If

        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this document/folder link?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iTrademarkDocID As Integer
            iTrademarkDocID = Nz(Me.grdDocumentLinks.GetValue("TrademarkDocID"), 0)
            strSQL = "delete from tblTrademarkDocuments where TrademarkDocID = " & iTrademarkDocID
            DataStuff.RunSQL(strSQL)
            GetDocuments()
        End If

        If e.Column.Key = "DocumentLink" Then

            Dim strDocument As String
            strDocument = Me.grdDocumentLinks.GetValue("DocumentLink")
            If Len(strDocument) > 2 Then
                System.Diagnostics.Process.Start(strDocument)
            End If
        End If

    End Sub

    Private Sub grdDocumentLinks_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumentLinks.RecordAdded
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow

        rsRecord.GetFromSQL("Select * from tblTrademarkDocuments where TrademarkDocID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdDocumentLinks
            dRow("TrademarkID") = Globals.TrademarkID
            dRow("DocumentLink") = .GetValue("DocumentLink")
            dRow("DocDescription") = .GetValue("DocDescription")
            dRow("OnExtraNet") = IIf(.GetValue("OnExtraNet") = False, False, True)
            dRow("IsFolder") = IIf(.GetValue("IsFolder") = False, False, True)
        End With
        rsRecord.Update()
    End Sub

    Private Sub grdDocumentLinks_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumentLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iTrademarkDocID As Integer

        With Me.grdDocumentLinks
            iTrademarkDocID = .GetValue("TrademarkDocID")
            rsRecord.GetFromSQL("Select * from tblTrademarkDocuments where TrademarkDocID=" & iTrademarkDocID)
            dRow = rsRecord.CurrentRow
            dRow("DocumentLink") = .GetValue("DocumentLink")
            dRow("DocDescription") = .GetValue("DocDescription")
            dRow("OnExtraNet") = IIf(.GetValue("OnExtraNet") = False, False, True)
            dRow("IsFolder") = IIf(.GetValue("IsFolder") = False, False, True)
        End With
        rsRecord.Update()
    End Sub

#End Region

#Region "Graphic Path"

    Private Sub btnGraphicPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraphicPath.Click
        On Error Resume Next
        If Globals.SecurityLevel = 3 Then Exit Sub
        With Me.OpenFileDialog
            If My.Settings.DemoConnection = My.Settings.CurrentConnection Then
                .InitialDirectory = RevaSettings.TrademarkGraphicsDemo
            Else
                .InitialDirectory = RevaSettings.TrademarkGraphics
            End If
            .FileName = ""
            .Filter = "All Files|*.*"
            .FilterIndex = 1
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName & "") > 3 Then
                Me.GraphicPath.Text = .FileName & ""
                'bWasEdited = True
                GetGraphic()
            End If
        End With
    End Sub

    Private Sub GetGraphic()
        On Error Resume Next
        With Me
            .picGraphic.ImageLocation = .GraphicPath.Text
            If .GraphicSizeToFit.Checked = True Then
                .picGraphic.SizeMode = PictureBoxSizeMode.Zoom
            Else
                .picGraphic.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        End With
    End Sub

    Private Sub GraphicSizeToFit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraphicSizeToFit.CheckedChanged
        On Error Resume Next
        'bWasEdited = True
        GetGraphic()
    End Sub

    Private Sub mnuGraphic_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuGraphic.ItemClicked
        On Error Resume Next
        Clipboard.Clear()
        Clipboard.SetImage(picGraphic.Image)
    End Sub

#End Region

#Region "Licensed To Grid"

    Private Sub grdLicensed_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLicensed.RecordAdded
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow

        rsRecord.GetFromSQL("Select * from tblTrademarksLicensed where LicensedID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdLicensed
            dRow("TrademarkID") = Globals.TrademarkID
            dRow("CompanyID") = .GetValue("CompanyID")
            dRow("Comments") = .GetValue("Comments")
        End With
        rsRecord.Update()

    End Sub

    Private Sub grdLicensed_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLicensed.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iLicensedID As Integer

        With Me.grdLicensed
            iLicensedID = .GetValue("LicensedID")
            rsRecord.GetFromSQL("Select * from tblTrademarksLicensed where LicensedID=" & iLicensedID)
            dRow = rsRecord.CurrentRow
            dRow("TrademarkID") = .GetValue("TrademarkID")
            dRow("CompanyID") = .GetValue("CompanyID")
            dRow("Comments") = .GetValue("Comments")
        End With
        rsRecord.Update()

    End Sub

    Private Sub grdLicensed_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdLicensed.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this company from the list?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iLicensedID As Integer
            iLicensedID = Nz(Me.grdLicensed.GetValue("LicensedID"), 0)
            strSQL = "delete from tblTrademarksLicensed where LicensedID = " & iLicensedID
            DataStuff.RunSQL(strSQL)
            GetLicensed()
        End If
    End Sub

#End Region

#Region "Dates Grid / Date Events"

    Private Sub grdDates_ColumnHeaderClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.ColumnHeaderClick
        On Error Resume Next
        'Sorts by Trademark Date
        If e.Column.Key = "TrademarkDate" Then
            Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer

            'if user checks re-order box first, we'll sort in reverse order
            If Me.chkReOrder.Checked = False Then
                rsRecord.GetFromSQL("Select TrademarkDateID, TrademarkDate, ListOrder from tblTrademarkDates " &
                    "where TrademarkID=" & Globals.TrademarkID & " order by TrademarkDate, ListOrder")
            Else
                rsRecord.GetFromSQL("Select TrademarkDateID, TrademarkDate, ListOrder from tblTrademarkDates " &
                    "where TrademarkID=" & Globals.TrademarkID & " order by TrademarkDate DESC, ListOrder DESC")
            End If

            If RevaSettings.BlankDatesLast = True Then
                Dim iListOrder As Integer
                iListOrder = 1
                'tick up the ones with dates first
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    If IsDate(dRow("TrademarkDate")) Then
                        dRow("ListOrder") = iListOrder
                    End If
                    iListOrder = iListOrder + 1
                Next i
                'now tick up the ones without dates
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    If Not IsDate(dRow("TrademarkDate")) Then
                        dRow("ListOrder") = iListOrder
                    End If
                    iListOrder = iListOrder + 1
                Next i
                'not putting blank dates last, so just tick 'em up
            Else
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    dRow("ListOrder") = (i + 1)
                Next i
            End If

            rsRecord.Update()
            GetDates()
        End If

    End Sub

    Private Sub chkReOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReOrder.CheckedChanged
        On Error Resume Next
        Dim bReOrder As Boolean
        bReOrder = Me.chkReOrder.Checked
        With Me.grdDates.RootTable
            .Columns("MoveUp").Visible = bReOrder
            .Columns("MoveDown").Visible = bReOrder
            .Columns("Completed").Visible = Not bReOrder
        End With
    End Sub

    Private Sub grdDates_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdDates.FormattingRow
        On Error Resume Next

        'to allow for dates to be expressed like "2000" without a month or day
        If (e.Row.RowType = Janus.Windows.GridEX.RowType.Record) And (e.Row.Cells("NoMonth").Value = True) Then
            e.Row.Cells("TrademarkDate").Text = Format(e.Row.Cells("TrademarkDate").Value, "yyyy")
            Exit Sub
        End If

        'to allow for dates to be expressed like "Jan 2000" without a day
        If (e.Row.RowType = Janus.Windows.GridEX.RowType.Record) And (e.Row.Cells("NoDay").Value = True) Then
            e.Row.Cells("TrademarkDate").Text = Format(e.Row.Cells("TrademarkDate").Value, "MMM yyyy")
        End If
    End Sub

    Private Sub grdDates_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.CellValueChanged
        On Error Resume Next
        'we only allow one date to be merged at a time, so de-select all others
        If FormStatus = Status.Merging Then
            If e.Column.Key = "InMerge" Then
                If Me.grdDates.GetValue("InMerge") = True Then
                    Dim iRow As Integer, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
                    iRow = Me.grdDates.Row
                    For i = 0 To Me.grdDates.RowCount - 1
                        If iRow <> i Then
                            GRow = Me.grdDates.GetRow(i)
                            GRow.BeginEdit()
                            GRow.Cells("InMerge").Value = False
                            GRow.EndEdit()
                        End If
                    Next
                End If
                SetMergeOptions()
            End If
        End If
    End Sub

    Private Sub grdDates_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.LinkClicked
        On Error Resume Next

        If e.Column.Key = "DateName" Then
            On Error Resume Next
            If Globals.SecurityLevel < 3 Then
                SaveTrademark()
                AllForms.OpenEditTrademarkDate()
            End If
        End If

        If (e.Column.Key = "lnkDelete") And (Globals.SecurityLevel < 2) Then
            If MsgBox("Are you sure you want to delete this date?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            Else
                Dim iTrademarkDateID As Integer
                iTrademarkDateID = Me.grdDates.GetValue("TrademarkDateID")
                Dim MD As New MarkDates
                With MD
                    .TrademarkID = Globals.TrademarkID
                    .LoadMarkDates()
                    .DeleteDate(iTrademarkDateID)
                    .SaveChanges()
                End With
                MD = Nothing
                GetDates()
            End If

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdDates.GetValue("ListOrder")
            iRow = Me.grdDates.CurrentRow.RowIndex

            If iOrder > 1 Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select TrademarkDateID, ListOrder from tblTrademarkDates where TrademarkID=" &
                    Globals.TrademarkID)
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    Select Case dRow("ListOrder")
                        Case (iOrder - 1)
                            dRow("ListOrder") = iOrder
                        Case (iOrder)
                            dRow("ListOrder") = (iOrder - 1)
                    End Select
                Next i
                rsRecord.Update()
                GetDates()
                Me.grdDates.Row = iRow - 1
            End If

        End If

        If e.Column.Key = "MoveDown" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdDates.GetValue("ListOrder")
            iRow = Me.grdDates.CurrentRow.RowIndex

            If iOrder < Me.grdDates.RowCount Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select TrademarkDateID, ListOrder from tblTrademarkDates where TrademarkID=" &
                    Globals.TrademarkID)
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    Select Case dRow("ListOrder")
                        Case (iOrder + 1)
                            dRow("ListOrder") = iOrder
                        Case (iOrder)
                            dRow("ListOrder") = (iOrder + 1)
                    End Select
                Next i
                rsRecord.Update()
                GetDates()
                Me.grdDates.Row = iRow + 1
            End If

        End If
    End Sub

    Private Sub btnAddDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDates.Click
        On Error Resume Next
        If (Nz(Me.JurisdictionID.Value, 0) = 0) Then
            MsgBox("You must select the Jurisdiction before adding dates.")
            Exit Sub
        End If
        AllForms.OpenAddTrademarkDates()
    End Sub

    Private Sub chkShowRelated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowRelated.CheckedChanged
        On Error Resume Next
        If Me.chkShowRelated.Checked = True Then
            FormStatus = Status.ShowRelated
        Else
            FormStatus = Status.ResetAll
        End If
        SetOptions()
    End Sub

    Private Sub grdRelated_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRelated.LinkClicked
        On Error Resume Next
        'If Me.optList.Checked = True Then
        SaveTrademark()
        Globals.TrademarkID = Me.grdRelated.GetValue("TrademarkID")
        GetTrademark()
        Me.Tabs.SelectedIndex = 1
        'End If
    End Sub

#End Region

#Region "Merge Panel"

    Private Sub optWord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWord.CheckedChanged
        If bFormLoaded = False Then Exit Sub
        If optWord.Checked = True Then
            SetMergeOptions()
        End If
    End Sub

    Private Sub optOutlook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOutlook.CheckedChanged
        If bFormLoaded = False Then Exit Sub
        If optOutlook.Checked = True Then
            SetMergeOptions()
        End If
    End Sub

    Private Sub optDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDate.CheckedChanged
        If bFormLoaded = False Then Exit Sub
        If optDate.Checked = True Then
            SetMergeOptions()
        End If
    End Sub

    Private Function GetContactsFilter() As String
        On Error Resume Next
        Dim strContacts As String, i As Integer, grow As Janus.Windows.GridEX.GridEXRow
        strContacts = " and ContactID in ("
        For i = 0 To Me.grdContacts.RowCount - 1
            grow = Me.grdContacts.GetRow(i)
            If grow.Cells("InMerge").Value = True Then
                strContacts = strContacts & grow.Cells("ContactID").Value & ","
            End If
        Next
        strContacts = strContacts & "0)"
        GetContactsFilter = strContacts
    End Function

    Private Function IsWordDoc() As Boolean
        On Error Resume Next
        Dim bIsWord As Boolean, strDocumentName As String
        strDocumentName = Me.MergeDocument.Text & ""

        bIsWord = True

        If Len(strDocumentName) < 4 Then
            bIsWord = False
        End If

        If (Not (strDocumentName Like "*.doc")) And (Not (strDocumentName Like "*.docx")) And (Not (strDocumentName Like "*.dotx")) Then
            bIsWord = False
        End If
        IsWordDoc = bIsWord

    End Function

    Private Function IsTextDoc() As Boolean
        On Error Resume Next
        Dim bIsText As Boolean, strDocumentName As String
        strDocumentName = Me.MergeDocument.Text & ""

        bIsText = True

        If Len(strDocumentName) < 4 Then
            bIsText = False
        End If

        If (Not (strDocumentName Like "*.txt")) Then
            bIsText = False
        End If
        IsTextDoc = bIsText

    End Function

    Private Function ContactSelected() As Boolean
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, bContactSelected As Boolean

        'assume we don't have a selection until we discover otherwise
        bContactSelected = False
        For i = 0 To Me.grdContacts.RowCount - 1
            GRow = Me.grdContacts.GetRow(i)
            If GRow.Cells("InMerge").Value = True Then
                bContactSelected = True
            End If
        Next
        ContactSelected = (bContactSelected = True)
    End Function

    Private Function ContactAndDateSelected() As Boolean
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, bDateSelected As Boolean, bContactSelected As Boolean

        'assume we don't have a selection until we discover otherwise
        bContactSelected = False
        bDateSelected = False

        For i = 0 To Me.grdContacts.RowCount - 1
            GRow = Me.grdContacts.GetRow(i)
            If GRow.Cells("InMerge").Value = True Then
                bContactSelected = True
            End If
        Next

        For i = 0 To Me.grdDates.RowCount - 1
            GRow = Me.grdDates.GetRow(i)
            If GRow.Cells("InMerge").Value = True Then
                bDateSelected = True
            End If
        Next
        ContactAndDateSelected = ((bContactSelected = True) And (bDateSelected = True))

    End Function

    Private Sub SetMergeOptions()
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        With Me
            If .optWord.Checked = True Then
                .MergeDocument.Text = My.Settings.LastMergeWord
            End If

            If .optOutlook.Checked = True Then
                .MergeDocument.Text = My.Settings.LastMergeOutlook
            End If

            If .optDate.Checked = True Then
                .MergeDocument.Text = ""
                .btnEditDocument.Enabled = (Me.grdDates.GetValue("InMerge") = True)
            Else
                .btnEditDocument.Enabled = (Len(.MergeDocument.Text) > 2) And Me.optWord.Checked = False
            End If

            .btnSelectDocument.Enabled = Not (.optDate.Checked)
            .btnNewDocument.Enabled = Not (.optDate.Checked)
            .MergeDocument.Enabled = Not (.optDate.Checked)
        End With
    End Sub

    Private Sub btnSelectDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDocument.Click
        On Error Resume Next

        With Me.OpenFileDialog
            If My.Settings.DemoConnection = My.Settings.CurrentConnection Then
                .InitialDirectory = RevaSettings.TrademarkDocumentsDemo
            Else
                .InitialDirectory = RevaSettings.TrademarkDocuments
            End If
            .FileName = ""

            If Me.optWord.Checked = True Then
                .Filter = "Word Documents (*.docx)|*.docx|All Files|*.*"
            End If

            If Me.optOutlook.Checked = True Then
                .Filter = "Text Documents (*.txt)|*.txt|All Files|*.*"
            End If

            .FilterIndex = 1
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName & "") > 3 Then
                Me.MergeDocument.Text = .FileName & ""

                If Me.optWord.Checked = True Then
                    My.Settings.LastMergeWord = .FileName & ""
                End If

                If Me.optOutlook.Checked = True Then
                    My.Settings.LastMergeOutlook = .FileName & ""
                End If



            End If
        End With

    End Sub

    Private Sub btnNewDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDocument.Click
        On Error Resume Next
        SaveTrademark()
        If Me.optWord.Checked = True Then
            MergeNewWordDoc()
        End If

        If Me.optOutlook.Checked = True Then
            MakeNewEmail()
        End If
    End Sub

    Private Sub btnEditDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDocument.Click
        On Error Resume Next
        SaveTrademark()
        If Me.optOutlook.Checked = True Then
            EditEmail()
        End If

        If Me.optDate.Checked = True Then
            EditDateEmail()
        End If

    End Sub

    Private Sub btnMergeDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergeDocument.Click
        On Error Resume Next
        SaveTrademark()
        If Me.optWord.Checked = True Then
            MergeExistingWordDoc()
        End If

        If Me.optOutlook.Checked = True Then
            MergeEmail()
        End If

        If Me.optDate.Checked = True Then
            MergeDateEmail()
        End If

    End Sub

    Private Sub MergeNewWordDoc()
        On Error Resume Next
        Dim strMessage As String

        If ContactSelected() = False Then
            strMessage = "You have not selected any contacts.  You can still create the merge document in Word," &
                " but there won't be any contact information if you merge the document immediately." &
                " Do you still want to create the document?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        End If

        With Me.SaveFileDialog
            If My.Settings.DemoConnection = My.Settings.CurrentConnection Then
                .InitialDirectory = RevaSettings.TrademarkDocumentsDemo
            Else
                .InitialDirectory = RevaSettings.TrademarkDocuments
            End If

            .FileName = ""
            .Filter = "Word Documents (*.docx)|*.docx|Word Templat(*.dotx)|*.dotx|All Files|*.*"
            .FilterIndex = 1
            .Title = "Name the new document"
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName & "") > 3 Then
                Me.MergeDocument.Text = .FileName & ""

            End If
        End With

        If IsWordDoc() = False Then
            MsgBox("Cannot save the document without a recognizable Word document name.")
            Exit Sub
        End If

        My.Settings.LastMergeType = 1
        My.Settings.LastMergeWord = Me.MergeDocument.Text


        Dim MM As New MarkMerge
        With MM
            .DocumentName = Me.MergeDocument.Text
            .ContactsFilter = GetContactsFilter()
            .WriteDataFile()
            .CreateNewDocument()
        End With
        MM = Nothing
    End Sub

    Private Sub MergeExistingWordDoc()
        On Error Resume Next

        If IsWordDoc() = False Then
            MsgBox("Cannot open a document without a recognizable Word document name.")
            Exit Sub
        End If

        My.Settings.LastMergeType = 1
        My.Settings.LastMergeWord = Me.MergeDocument.Text


        Dim MM As New MarkMerge
        With MM
            .ContactsFilter = GetContactsFilter()
            .WriteDataFile()
            .DocumentName = Me.MergeDocument.Text & ""
            .OpenExistingDocument()
        End With
    End Sub

    Private Sub MakeNewEmail()
        On Error Resume Next

        AllForms.OpenMergeHelper()
        With AllForms.frmMergeHelper
            .MergeStatus = frmMergeHelper.mStatus.TrademarkOutlook
            .bNewDocument = True
            .SetOptions()
        End With
    End Sub

    Private Sub EditEmail()
        On Error Resume Next
        If IsTextDoc() = False Then
            MsgBox("You must select a text document to edit first.")
            Exit Sub
        End If

        AllForms.OpenMergeHelper()
        With AllForms.frmMergeHelper
            .MergeStatus = frmMergeHelper.mStatus.TrademarkOutlook
            .bNewDocument = False
            .DocumentName = Me.MergeDocument.Text
            .SetOptions()
        End With
    End Sub

    Private Sub EditDateEmail()
        On Error Resume Next
        AllForms.OpenMergeHelper()
        With AllForms.frmMergeHelper
            .MergeStatus = frmMergeHelper.mStatus.TrademarkJurisDate
            .JurisdictionDateID = Me.grdDates.GetValue("JurisdictionDateID")
            .bNewDocument = False
            .SetOptions()
        End With

    End Sub

    Private Sub MergeEmail()
        On Error Resume Next

        If IsTextDoc() = False Then
            MsgBox("You must select a text document to merge first.")
            Exit Sub
        End If

        If ContactSelected() = False Then
            MsgBox("You must select a contact before merging.")
            Exit Sub
        End If

        My.Settings.LastMergeOutlook = Me.MergeDocument.Text
        My.Settings.LastMergeType = 3


        Dim OM As New MarkOutlookMerge
        With OM
            .ContactsFilter = GetContactsFilter()
            .DocumentName = Me.MergeDocument.Text
            .IsDateMerge = False
            .MergeToDocument()
        End With
        OM = Nothing

    End Sub

    Private Sub MergeDateEmail()
        On Error Resume Next
        'make sure user has correct options set
        If ContactAndDateSelected() = False Then
            MsgBox("You must select a date and at least one contact before merging.")
            Exit Sub
        End If

        'make sure merge texts exists
        Dim strSQL As String, dr As OleDb.OleDbDataReader
        strSQL = "Select EmailMessage from tblJurisdictionDates where JurisdictionDateID=" &
            Me.grdDates.GetValue("JurisdictionDateID")
        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        If dr("EmailMessage") & "" = "" Then
            MsgBox("There is no merge text set up for this date.  You can create text by clicking the Edit button.")
            Exit Sub
        End If

        'okay, go for it

        My.Settings.LastMergeType = 4


        Dim OM As New MarkOutlookMerge
        With OM
            .ContactsFilter = GetContactsFilter()
            .IsDateMerge = True
            .JurisdictionDateID = Me.grdDates.GetValue("JurisdictionDateID")
            .MergeToDocument()
        End With
        OM = Nothing

    End Sub

#End Region

#Region "Treaty Filings"

    Private Sub SetTreatyFilingPage()
        On Error Resume Next
        'most of the time, they'll never open this page, so we don't fill it unless it's necessary
        If bTreatyFilingsFilled = False Then
            GetTreatyFilingBasis()
            GetTreatyFilings()
            GetTreatyJurisdictions()
            GetTreatyTrademarks()
            SetTreatyFilingTrademarks()
            bTreatyFilingsFilled = True
        End If
    End Sub

    Private Sub SetTreatyFilingTrademarks()
        On Error Resume Next

        Dim dtExisting As DataTable, strSQL As String

        With Me
            strSQL = SQL.vwTrademarksList & " where CompanyID=" &
                .CompanyID.Value & " and TrademarkID<>" & Globals.TrademarkID

            ' showing jurisdiction to add to filing
            If .optRelatedAll.Checked Then
                .grdLinkExisting.Visible = False
                .grdJurisdictions.Visible = True
                .grdJurisdictions.Left = 282
                .lblRelatedTrademarks.Visible = False
            End If

            'showing trademarks so user can add basis marks
            If .optRelatedBasis.Checked Then
                If dtExisting Is Nothing Then
                    dtExisting = DataStuff.GetDataTable(strSQL)
                End If

                .grdLinkExisting.RootTable.HeaderLines = 2
                .grdJurisdictions.Visible = False
                .grdLinkExisting.DataSource = dtExisting
                .grdLinkExisting.Visible = True
                .grdLinkExisting.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .lblRelatedTrademarks.Visible = True
                .lblRelatedTrademarks.Text = "Select from the list below to add to the treaty filing as the basis trademark(s)."
                .lblRelatedTrademarks.Left = .grdLinkExisting.Left + 20
            End If

            If .optRelatedLinkExisting.Checked Then
                If dtExisting Is Nothing Then
                    dtExisting = DataStuff.GetDataTable(strSQL)
                End If

                .grdLinkExisting.RootTable.HeaderLines = 2
                .grdJurisdictions.Visible = False
                .grdLinkExisting.DataSource = dtExisting
                .grdLinkExisting.Visible = True
                .grdLinkExisting.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False

                .lblRelatedTrademarks.Visible = True
                .lblRelatedTrademarks.Text = "Select trademarks from the list below to include as part of the treaty filing."
                .lblRelatedTrademarks.Left = .grdLinkExisting.Left + 20
            End If

        End With

        SetTreatyButtons()
    End Sub

    Private Sub GetTreatyFilings()
        On Error Resume Next
        Dim strSQL As String, dtTreatyFilings As DataTable

        strSQL = "Select * from tblTreatyFilings where TreatyFilingID in " &
        "(Select TreatyFilingID from tblTreatyFilingTrademarks where TrademarkID=@TrademarkID)"

        strSQL = strSQL.Replace("@TrademarkID", Globals.TrademarkID)
        dtTreatyFilings = DataStuff.GetDataTable(strSQL)

        With Me.grdTreatyFilings
            .DataSource = dtTreatyFilings
            If .RowCount > 0 Then
                Globals.TreatyFilingID = .GetValue("TreatyFilingID")
            End If
        End With
    End Sub

    Private Sub GetTreatyFilingBasis()
        On Error Resume Next
        Dim strSQL As String, dtTreatyFilingBasis As DataTable
        strSQL = "Select FilingBasisID, FilingBasis from qvwTrademarkTreatyJurisdictions where JurisdictionID=" &
            Me.JurisdictionID.Value & " and IsParticipant <> 0 order by FilingBasis"
        dtTreatyFilingBasis = DataStuff.GetDataTable(strSQL)
        Me.grdTreatyFilings.DropDowns("cboFilingBasis").SetDataBinding(dtTreatyFilingBasis, "")
    End Sub

    Private Sub GetTreatyJurisdictionDates()
        On Error Resume Next
        Dim iJurisdictionID As Integer, strSQL As String, dtJurisdictionDates As DataTable
        'treaty filing basis is aliased as a jurisdiction; it's FilingBasisID * -1
        iJurisdictionID = Me.grdTreatyFilings.GetValue("FilingBasisID") * -1
        strSQL = "select * from qvwTrademarkJurisdictionDates where JurisdictionID=" & iJurisdictionID &
            " order by ListOrder"
        dtJurisdictionDates = DataStuff.GetDataTable(strSQL)
        Me.grdTreatyFilings.DropDowns("cboJurisdictionDate").SetDataBinding(dtJurisdictionDates, "")
    End Sub

    Private Sub GetTreatyJurisdictions()
        On Error Resume Next
        Dim strSQL As String, dtTreatyJurisdictions As DataTable, iFilingBasisID As Integer

        iFilingBasisID = Me.grdTreatyFilings.GetValue("FilingBasisID")
        strSQL = "select * from qvwTrademarkTreatyJurisdictions where FilingBasisID=" & iFilingBasisID &
            " and IsParticipant <> 0 order by Jurisdiction"
        dtTreatyJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.grdJurisdictions.DataSource = dtTreatyJurisdictions
    End Sub

    Private Sub GetTreatyTrademarks()
        On Error Resume Next
        Dim strSQL As String, dtTreatyTrademarks As DataTable

        ' becuz in Access, false = -1, in SQL Server, false = 1
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            strSQL = "select * from qvwTreatyFilingTrademarks where TreatyFilingID=" & Globals.TreatyFilingID &
                    " order by IsBasis, Jurisdiction"
        Else
            strSQL = "select * from qvwTreatyFilingTrademarks where TreatyFilingID=" & Globals.TreatyFilingID &
                    " order by IsBasis DESC, Jurisdiction"
        End If

        dtTreatyTrademarks = DataStuff.GetDataTable(strSQL)
        Me.grdTreatyTrademarks.DataSource = dtTreatyTrademarks
        Me.grdRelated.DataSource = dtTreatyTrademarks

    End Sub

    Private Sub grdTreatyFilings_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTreatyFilings.CellValueChanged
        On Error Resume Next
        If e.Column.Key = "FilingBasisID" Then
            GetTreatyJurisdictionDates()
            GetTreatyJurisdictions()
        End If
    End Sub

    Private Sub grdTreatyFilings_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTreatyFilings.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strSQL As String, iTreatyFilingID As Integer
            iTreatyFilingID = Me.grdTreatyFilings.GetValue("TreatyFilingID")

            If DataStuff.DCount("TrademarkID", "tblTreatyFilingTrademarks", "TreatyFilingID=" & iTreatyFilingID) > 0 Then
                MsgBox("You cannot delete a treaty filing that's linked to existing trademarks.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Treaty Filing?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblTreatyFilings where TreatyFilingID = " & iTreatyFilingID
            DataStuff.RunSQL(strSQL)
            GetTreatyFilings()
            GetTreatyJurisdictions()
        End If
    End Sub

    Private Sub grdTreatyFilings_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.RecordAdded
        On Error Resume Next

        If bIsTreaty = True Then
            Dim strMessage As String
            strMessage = "This trademark is already part of a treay filing.  " &
                "Are you sure you want to create a new treaty filing based on this trademark?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                GetTreatyFilings()
                Exit Sub
            End If
        End If

        Dim rsRecord As New RecordSet, dRow As DataRow, iRow As Integer, iTreatyFilingID As Integer

        iRow = Me.grdTreatyFilings.Row
        rsRecord.GetFromSQL("Select * from tblTreatyFilings where TreatyFilingID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdTreatyFilings
            dRow("FilingBasisID") = .GetValue("FilingBasisID")
            dRow("TrademarkID") = Globals.TrademarkID
            dRow("ApplicationNumber") = .GetValue("ApplicationNumber")
            dRow("RegistrationNumber") = .GetValue("RegistrationNumber")
            dRow("FilingDate") = .GetValue("FilingDate")
            dRow("CopyClasses") = IIf(.GetValue("CopyClasses") = True, True, False)
            dRow("CopyGoods") = IIf(.GetValue("CopyGoods") = True, True, False)
            dRow("CopyDisclaimers") = IIf(.GetValue("CopyDisclaimers") = True, True, False)
            dRow("CopyContacts") = IIf(.GetValue("CopyContacts") = True, True, False)
            dRow("JurisdictionDateID") = .GetValue("JurisdictionDateID")
            dRow("StatusID") = .GetValue("StatusID")
        End With

        rsRecord.Update()

        'with the new functionality of being able to use multiple marks as the basis for a treaty filing, we now need to copy this record
        'to the new table that contains all the treaty marks.  We're still going to keep the trademark information in tblTreatyFilings
        'so treaty-filing records don't get lost.
        iTreatyFilingID = DataStuff.DMax("TreatyFilingID", "tblTreatyFilings")
        rsRecord.GetFromSQL("Select * from tblTreatyFilingTrademarks where TreatyTrademarkID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdTreatyFilings
            dRow("TreatyFilingID") = iTreatyFilingID
            dRow("TrademarkID") = Globals.TrademarkID
            dRow("IsBasis") = True
        End With

        rsRecord.Update()

        GetTreatyFilings()
        GetTreatyTrademarks()
        Me.grdTreatyFilings.Row = iRow
    End Sub

    Private Sub grdTreatyFilings_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iTreatyFilingID As Integer

        With Me.grdTreatyFilings
            iTreatyFilingID = .GetValue("TreatyFilingID")
            rsRecord.GetFromSQL("Select * from tblTreatyFilings where TreatyFilingID=" & iTreatyFilingID)
            dRow = rsRecord.CurrentRow
            dRow("FilingBasisID") = .GetValue("FilingBasisID")
            dRow("ApplicationNumber") = .GetValue("ApplicationNumber")
            dRow("RegistrationNumber") = .GetValue("RegistrationNumber")
            dRow("FilingDate") = .GetValue("FilingDate")
            dRow("CopyClasses") = IIf(.GetValue("CopyClasses") = True, True, False)
            dRow("CopyGoods") = IIf(.GetValue("CopyGoods") = True, True, False)
            dRow("CopyDisclaimers") = IIf(.GetValue("CopyDisclaimers") = True, True, False)
            dRow("CopyContacts") = IIf(.GetValue("CopyContacts") = True, True, False)
            dRow("JurisdictionDateID") = .GetValue("JurisdictionDateID")
            dRow("StatusID") = .GetValue("StatusID")
        End With

        rsRecord.Update()
    End Sub

    Private Sub grdTreatyFilings_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.SelectionChanged
        On Error Resume Next
        GetTreatyJurisdictionDates()
        GetTreatyJurisdictions()
        SetTreatyButtons()
    End Sub

    Private Sub grdTreatyTrademarks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTreatyTrademarks.LinkClicked
        On Error Resume Next
        Globals.TrademarkID = Me.grdTreatyTrademarks.GetValue("TrademarkID")
        GetTrademark()
        Me.Tabs.SelectedIndex = 1
    End Sub

    Private Sub btnAddTreatyFiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTreatyFiling.Click
        On Error Resume Next
        Dim iTrademarkID As Integer, GRow As Janus.Windows.GridEX.GridEXRow,
            i As Integer, iTreatyFilingID As Integer, rsRecord As New RecordSet, dRow As DataRow

        iTreatyFilingID = Me.grdTreatyFilings.GetValue("TreatyFilingID")

        ' ========= adding basis marks to treaty filing ===============================================
        If Me.optRelatedBasis.Checked = True Then

            If Me.grdLinkExisting.SelectedItems.Count < 1 Then
                MsgBox("You must select the new basis marks first.")
                Exit Sub
            End If

            rsRecord.GetFromSQL("Select * from tblTreatyFilingTrademarks where TreatyTrademarkID=0")

            For i = 0 To Me.grdLinkExisting.SelectedItems.Count - 1
                GRow = Me.grdLinkExisting.SelectedItems(i).GetRow
                dRow = rsRecord.Table.Rows.Add
                With Me.grdLinkExisting
                    dRow("TreatyFilingID") = iTreatyFilingID
                    dRow("TrademarkID") = GRow.Cells("TrademarkID").Value
                    dRow("IsBasis") = True
                End With
                rsRecord.Update()
            Next i
            RefreshBrowse()
            GetTreatyTrademarks()
            Exit Sub
        End If

        ' ======================= adding existing marks to treaty =================================================
        If Me.optRelatedLinkExisting.Checked = True Then
            If Me.grdLinkExisting.SelectedItems.Count < 1 Then
                MsgBox("You must select the marks to link first.")
                Exit Sub
            End If

            rsRecord.GetFromSQL("Select * from tblTreatyFilingTrademarks where TreatyTrademarkID=0")

            For i = 0 To Me.grdLinkExisting.SelectedItems.Count - 1
                GRow = Me.grdLinkExisting.SelectedItems(i).GetRow
                dRow = rsRecord.Table.Rows.Add
                With Me.grdLinkExisting
                    dRow("TreatyFilingID") = iTreatyFilingID
                    dRow("TrademarkID") = GRow.Cells("TrademarkID").Value
                    dRow("IsBasis") = False
                End With
                rsRecord.Update()
            Next i
            RefreshBrowse()
            GetTreatyTrademarks()

            MsgBox("Existing marks are now linked.  Linking does not affect the trademark dates for the linked marks.")
            Exit Sub
        End If


        ' =========================== adding foreign jurisdictions to treaty filing ===============================
        If Me.optRelatedAll.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            'don't bother if nothing is selected
            If Me.grdJurisdictions.SelectedItems.Count < 1 Then
                MsgBox("You must select the Jurisdictions in which to file first.")
                Exit Sub
            End If

            Dim iStatusID As Integer, iJurisdictionDateID As Integer, iFilingBasis As Integer
            Dim GJurisRow As Janus.Windows.GridEX.GridEXRow, iTreatyJurisdictionID As Integer
            Dim iJurisdictionID As Integer, rsTrademarks As New RecordSet, dMarkRow As DataRow
            Dim rsTreatyMarks As New RecordSet, strSQL As String, dtTrademarks As DataTable
            Dim strGoods As String, strDisclaimers As String, strBasisWhere As String
            Dim rsContacts As New RecordSet, rsRegClasses As New RecordSet
            Dim dtContacts As New DataTable, dtRegClasses As New DataTable
            Dim dContactRow As DataRow, dClassRow As DataRow
            Dim TrademarkDate As Date, MD As New MarkDates

            'get values from treaty-filing record
            iStatusID = Nz(Me.grdTreatyFilings.GetValue("StatusID"), 0)
            iJurisdictionDateID = Nz(Me.grdTreatyFilings.GetValue("JurisdictionDateID"), 0)
            iFilingBasis = Me.grdTreatyFilings.GetValue("FilingBasisID")
            iTreatyJurisdictionID = (iFilingBasis * -1)  ' fake jurisdictionID for treaties is filing basis as a negative

            If IsDate(Me.grdTreatyFilings.GetValue("FilingDate")) Then
                TrademarkDate = Me.grdTreatyFilings.GetValue("FilingDate")
            Else
                TrademarkDate = Date.MinValue
            End If

            strGoods = ""
            strDisclaimers = ""

            'becuz we'll need to pull the basis marks a few times
            strBasisWhere = " where TrademarkID in ("
            For Each GRow In Me.grdTreatyTrademarks.GetRows
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record And GRow.Cells("IsBasis").Value = True Then
                    strBasisWhere = strBasisWhere & GRow.Cells("TrademarkID").Value & ","
                End If
            Next
            strBasisWhere = strBasisWhere & "0)"

            ' get required records for basis marks
            If Me.grdTreatyFilings.GetValue("CopyContacts") = True Then
                strSQL = "Select distinct ContactID, PositionID from tblTrademarkContacts" & strBasisWhere
                dtContacts = DataStuff.GetDataTable(strSQL)
            End If

            If Me.grdTreatyFilings.GetValue("CopyClasses") = True Then
                strSQL = "Select distinct RegClassID from tblTrademarkRegClasses" & strBasisWhere
                dtRegClasses = DataStuff.GetDataTable(strSQL)
            End If

            If (Me.grdTreatyFilings.GetValue("CopyGoods") = True) Or (Me.grdTreatyFilings.GetValue("CopyDisclaimers")) = True Then
                ' get info from basis marks already in grid
                strSQL = "Select TrademarkID, GoodsServices, Disclaimers from tblTrademarks" & strBasisWhere
                dtTrademarks = DataStuff.GetDataTable(strSQL)

                For i = 0 To dtTrademarks.Rows.Count - 1
                    dMarkRow = dtTrademarks.Rows(i)
                    If i > 0 Then 'not first row
                        strGoods = strGoods & " "
                        strDisclaimers = strDisclaimers & " "
                    End If
                    strGoods = strGoods & dMarkRow("GoodsServices")
                    strDisclaimers = strDisclaimers & dMarkRow("Disclaimers")
                Next
                ' to make sure we don't exceed field length
                strDisclaimers = strDisclaimers.Substring(0, 500)
            End If

            'Dim f As New frmTestViewTable(dtTrademarks)
            'f.Show()
            'Exit Sub

            'get the tables where we're adding rows
            rsTrademarks.GetFromSQL("Select * from tblTrademarks where TrademarkID=0")

            If Me.grdTreatyFilings.GetValue("CopyClasses") = True Then
                rsRegClasses.GetFromSQL("Select * from tblTrademarkRegClasses where TrademarkID=0")
            End If

            If Me.grdTreatyFilings.GetValue("CopyContacts") = True Then
                rsContacts.GetFromSQL("Select * from tblTrademarkContacts where TrademarkID=0")
            End If

            'load up the date class if necessary
            If (iStatusID <> 0) Or ((iJurisdictionDateID <> 0) And (TrademarkDate <> Date.MinValue)) Then
                MD.JurisdictionID = iTreatyJurisdictionID
                MD.LoadJurisdictionDates()
            End If

            'create new trademark records for selected jurisdictions
            For i = 0 To Me.grdJurisdictions.SelectedItems.Count - 1
                GJurisRow = Me.grdJurisdictions.SelectedItems(i).GetRow
                iJurisdictionID = GJurisRow.Cells("JurisdictionID").Value

                ' can't add jurisdiciton to same treaty filing twice
                If JurisdictionInTreaty(iJurisdictionID) = False Then
                    With Me
                        dMarkRow = rsTrademarks.Table.Rows.Add
                        dMarkRow("TrademarkName") = .TrademarkName.Text & ""
                        dMarkRow("TrademarkTypeID") = .TrademarkTypeID.Value
                        dMarkRow("GraphicPath") = .GraphicPath.Text & ""
                        dMarkRow("GraphicSizeToFit") = IIf(.GraphicSizeToFit.Checked = True, True, False)
                        dMarkRow("FileID") = .FileID.Value
                        dMarkRow("FilingBasisID") = iFilingBasis
                        dMarkRow("CompanyID") = .CompanyID.Value
                        dMarkRow("JurisdictionID") = iJurisdictionID
                        dMarkRow("TreatyFilingID") = iTreatyFilingID
                        dMarkRow("CheckStatus") = False
                        dMarkRow("ApplicationNumber") = .grdTreatyFilings.GetValue("ApplicationNumber") & ""
                        dMarkRow("RegistrationNumber") = .grdTreatyFilings.GetValue("RegistrationNumber") & ""
                        If .grdTreatyFilings.GetValue("CopyGoods") = True Then
                            dMarkRow("GoodsServices") = strGoods  'value set above
                        End If
                        If .grdTreatyFilings.GetValue("CopyDisclaimers") = True Then
                            dMarkRow("Disclaimers") = strDisclaimers  'ditto
                        End If
                        If Nz(.grdTreatyFilings.GetValue("StatusID"), 0) <> 0 Then
                            dMarkRow("StatusID") = .grdTreatyFilings.GetValue("StatusID")
                        End If
                    End With
                    rsTrademarks.Update()
                End If
            Next i
            rsTrademarks = Nothing

            'okay, we created the new trademarks.  Now we need to get them again so we have legit TrademarkIDs.
            strSQL = "Select TrademarkID, JurisdictionID, TreatyFilingID from tblTrademarks where TreatyFilingID=" & iTreatyFilingID
            dtTrademarks = DataStuff.GetDataTable(strSQL)

            For Each dMarkRow In dtTrademarks.Rows
                iTrademarkID = dMarkRow("TrademarkID")
                iJurisdictionID = dMarkRow("JurisdictionID")

                ' once again, make sure this jurisdiciton hasn't been added before.
                ' the treaty-marks list hasn't been requeried yet, so we'll use it
                If JurisdictionInTreaty(iJurisdictionID) = False Then

                    ' get it into tblTreatyFilingTrademarks
                    strSQL = "insert into tblTreatyFilingTrademarks (TrademarkID, TreatyFilingID, IsBasis) values " &
                    "(@TrademarkID, @TreatyFilingID, 0)"
                    strSQL = strSQL.Replace("@TrademarkID", iTrademarkID)
                    strSQL = strSQL.Replace("@TreatyFilingID", iTreatyFilingID)
                    DataStuff.RunSQL(strSQL)

                    ' add basis mark contacts if option selected
                    If Me.grdTreatyFilings.GetValue("CopyContacts") = True Then
                        For Each dRow In dtContacts.Rows
                            dContactRow = rsContacts.Table.Rows.Add
                            dContactRow("TrademarkID") = iTrademarkID
                            dContactRow("ContactID") = dRow("ContactID")
                            dContactRow("PositionID") = dRow("PositionID")
                        Next
                        rsContacts.Update()
                    End If

                    ' add classes if option selected
                    If Me.grdTreatyFilings.GetValue("CopyClasses") = True Then
                        For Each dRow In dtRegClasses.Rows
                            dClassRow = rsRegClasses.Table.Rows.Add
                            dClassRow("TrademarkID") = iTrademarkID
                            dClassRow("RegClassID") = dRow("RegClassID")
                        Next
                        rsRegClasses.Update()
                    End If

                    ' add dates and update if necessary options selected
                    If (iStatusID <> 0) Or ((iJurisdictionDateID <> 0) And (TrademarkDate <> Date.MinValue)) Then
                        With MD
                            .TrademarkID = iTrademarkID
                            .LoadMarkDates()

                            If (iJurisdictionDateID <> 0) And (TrademarkDate <> Date.MinValue) Then
                                .AddJurisdictionDate(iJurisdictionDateID, TrademarkDate)
                            End If

                            If iStatusID <> 0 Then
                                .AppendStatusDates(iStatusID)
                            End If

                            .UpdateRecurNumbers()
                            .ReOrderTrademarkDates()
                            .SaveChanges()
                        End With
                    End If

                End If ' if not already in jurisdiction
            Next  'next new trademark row

            GetTreatyTrademarks()
            SetTreatyButtons()
            RefreshBrowse()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Function JurisdictionInTreaty(ByVal JurisdictionID As Integer) As Boolean
        On Error Resume Next
        ' see if jurisdiction is already in current treaty filing
        Dim bInTreaty As Boolean = False, GMarkRow As Janus.Windows.GridEX.GridEXRow, i As Integer
        For i = 0 To Me.grdTreatyTrademarks.RowCount - 1
            GMarkRow = Me.grdTreatyTrademarks.GetRow(i)
            If GMarkRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If GMarkRow.Cells("JurisdictionID").Value = JurisdictionID Then bInTreaty = True
            End If
        Next
        Return bInTreaty
    End Function

    Private Sub btnRemoveTreatyFiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTreatyFiling.Click
        On Error Resume Next
        Dim strMsg As String

        strMsg = "This will not delete the trademark.  This will unlink the selected trademark " &
            "from the treaty filing.  Proceed?"

        If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim iTrademarkID As Integer, iTreatyTrademarkID As Integer, strSQL As String

        iTrademarkID = Me.grdTreatyTrademarks.GetValue("TrademarkID")
        iTreatyTrademarkID = Me.grdTreatyTrademarks.GetValue("TreatyTrademarkID")

        strMsg = "This trademark has been unlinked from the treaty filing.  " &
                    "You may need to change the Filing Basis, Application Number and Registration Number."

        ' clear the old way, just in case
        strSQL = "update tblTrademarks SET TreatyFilingID=null where TrademarkID=" & iTrademarkID
        DataStuff.RunSQL(strSQL)

        'clear the new way
        strSQL = "delete from tblTreatyFilingTrademarks where TreatyTrademarkID=" & iTreatyTrademarkID
        DataStuff.RunSQL(strSQL)

        SetTreatyButtons()
        GetTrademarksList()
        GetTreatyTrademarks()
        Globals.TrademarkID = iTrademarkID
        GetTrademark()
        Me.Tabs.SelectedIndex = 1
        MsgBox(strMsg)
    End Sub

    Private Sub grdJurisdictions_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdJurisdictions.SelectionChanged
        On Error Resume Next
        SetTreatyButtons()
    End Sub

    Private Sub grdTreatyTrademarks_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTreatyTrademarks.SelectionChanged
        On Error Resume Next
        SetTreatyButtons()
    End Sub

    Private Sub optRelatedAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRelatedAll.CheckedChanged
        If Me.optRelatedAll.Checked = True Then SetTreatyFilingTrademarks()
    End Sub

    Private Sub optRelatedBasis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRelatedBasis.CheckedChanged
        If Me.optRelatedBasis.Checked = True Then SetTreatyFilingTrademarks()
    End Sub

    Private Sub optRelatedLinkExisting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRelatedLinkExisting.CheckedChanged
        If Me.optRelatedLinkExisting.Checked = True Then SetTreatyFilingTrademarks()
    End Sub

    Private Sub SetTreatyButtons()
        On Error Resume Next
        With Me
            If (.optRelatedLinkExisting.Checked = True) Or (.optRelatedBasis.Checked = True) Then
                .btnAddTreatyFiling.Enabled = (.grdTreatyFilings.SelectedItems.Count = 1) _
                    And (.grdLinkExisting.SelectedItems.Count > 0) And (Globals.SecurityLevel < 3)
            Else
                .btnAddTreatyFiling.Enabled = (.grdTreatyFilings.SelectedItems.Count = 1) _
                    And (.grdJurisdictions.SelectedItems.Count > 0) And (Globals.SecurityLevel < 3)
            End If
            'must be on basis mark screen to remove, but can't remove basis mark itself from list
            .btnRemoveTreatyFiling.Enabled = (.grdTreatyTrademarks.SelectedItems.Count > 0) And
                (Globals.SecurityLevel = 1) And (.grdTreatyTrademarks.GetValue("TrademarkID") <> Globals.TrademarkID)
        End With
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

#Region "Status Updates"

    Private Sub tbUSPTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbUSPTO.Enter
        On Error Resume Next
        ' no point filling the table if user never goes to this page
        If (dtTrademarkUpdates Is Nothing) Then
            GetTrademarkUpdates()
        End If
        SetUpdateOptions()
    End Sub

    Private Sub btnCheckStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckStatus.Click
        On Error Resume Next

        Dim dtMarksToCheck As DataTable
        dtMarksToCheck = DataStuff.GetDataTable("Select TrademarkID, StatusCode, ApplicationNumber from tblTrademarks where CheckStatus<>0 order by TrademarkID")

        If dtMarksToCheck.Rows.Count = 0 Then
            MsgBox("There are no trademarks on the status-check list.")
            dtMarksToCheck = Nothing
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        'still here?  Then let's DoIt ToIt
        Dim US As New USPTO
        US.GetUpdates(dtMarksToCheck)
        US = Nothing
        GetTrademarkUpdates()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SetUpdateOptions()
        On Error Resume Next
        With Me
            .MarkStatusFrom.Enabled = .optStatusRange.Checked
            .MarkStatusTo.Enabled = .optStatusRange.Checked
        End With
    End Sub

    Private Sub optStatusAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusAll.CheckedChanged
        On Error Resume Next
        If bFormLoaded = True And Me.optStatusAll.Checked = True Then
            GetTrademarkUpdates()
            SetUpdateOptions()
        End If

    End Sub

    Private Sub optStatusRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusRange.CheckedChanged
        On Error Resume Next
        If bFormLoaded = True And Me.optStatusRange.Checked = True Then
            GetTrademarkUpdates()
            SetUpdateOptions()
        End If
    End Sub

    Private Sub MarkStatusFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkStatusFrom.ValueChanged
        On Error Resume Next
        If bFormLoaded = True Then GetTrademarkUpdates()
    End Sub

    Private Sub MarkStatusTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkStatusTo.ValueChanged
        On Error Resume Next
        If bFormLoaded = True Then GetTrademarkUpdates()
    End Sub

    Private Sub GetTrademarkUpdates()
        On Error Resume Next
        Dim strSQL As String

        With Me
            strSQL = "Select * from qvwTrademarkUpdates where TrademarkID <> 0"
            If .optStatusRange.Checked Then
                If IsDate(.MarkStatusFrom.Text) And IsDate(.MarkStatusTo.Text) Then
                    strSQL = strSQL & " and StatusDate >=" & FixDate(.MarkStatusFrom.Text)
                    strSQL = strSQL & " and StatusDate <=" & FixDate(.MarkStatusTo.Text)
                End If
            End If

            strSQL = strSQL & " order by StatusDate"
            dtTrademarkUpdates = DataStuff.GetDataTable(strSQL)
            With .grdStatusCheck
                .DataSource = dtTrademarkUpdates

                If (.RootTable.Columns.Contains("lnkSend") = False) Then
                    .RootTable.Columns.Add("lnkSend")
                    .RootTable.Columns("lnkSend").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                    .RootTable.Columns("lnkSend").CellStyle.FontUnderline = False
                    .RootTable.Columns("lnkSend").Width = 90
                    .RootTable.Columns("lnkSend").BoundMode = Janus.Windows.GridEX.ColumnBoundMode.Unbound
                    .RootTable.Columns("lnkSend").Caption = "Send Email"

                End If
                If (.RootTable.Columns.Contains("EmailSent") = False) Then
                    .RootTable.Columns.Add("EmailSent")
                    .RootTable.Columns("EmailSent").Width = 49
                    .RootTable.Columns("EmailSent").DataMember = "EmailSent"
                    .RootTable.Columns("EmailSent").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                End If
                .RootTable.Columns("lnkSend").Visible = True
                .RootTable.Columns("lnkSend").ShowInFieldChooser = False
                .RootTable.Columns("EmailSent").Visible = True
                .RootTable.Columns("EmailSent").ShowInFieldChooser = False
            End With

            ' .grdStatusCheck.RootTable.Columns("lnkSend").Visible = True

        End With
    End Sub

    Private Sub grdStatusCheck_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdStatusCheck.LinkClicked
        On Error Resume Next

        If (e.Column.Key = "TrademarkName") Or (e.Column.Key = "ApplicationNumber") Then
            Globals.TrademarkID = Me.grdStatusCheck.GetValue("TrademarkID")
            Globals.NavigateMarksFrom = 6
            GetTrademark()
            Me.Tabs.SelectedIndex = 1
        End If

        If e.Column.Key = "lnkSend" Then
            Dim OL As Outlook.Application, Email As Outlook.MailItem

            If OL Is Nothing Then
                OL = CreateObject("Outlook.Application")
            Else
                OL = GetObject(, "Outlook.Application")
            End If

            Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
            GenerateStatusEmails(Me.grdStatusCheck.CurrentRow, Email)
            OL = Nothing
        End If

        If e.Column.Key = "lnkDelete" Then
            If Globals.SecurityLevel = 3 Then Exit Sub

            If MsgBox("Are you sure you want to permanently delete this status-update record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim iTrademarkUpdateID As Integer, strSQL As String
            iTrademarkUpdateID = Me.grdStatusCheck.GetValue("TrademarkUpdateID")
            strSQL = "Delete from tblTrademarkUpdates where TrademarkUpdateID=" & iTrademarkUpdateID
            DataStuff.RunSQL(strSQL)
            GetTrademarkUpdates()
        End If

    End Sub

    Private Sub grdStatusCheck_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdStatusCheck.ColumnHeaderClick
        On Error Resume Next

        If e.Column.Key = "lnkSend" Then
            Dim GRow As Janus.Windows.GridEX.GridEXRow, i As Integer
            Dim OL As Outlook.Application, Email As Outlook.MailItem

            OL = GetObject(, "Outlook.Application")
            If OL Is Nothing Then
                OL = CreateObject("Outlook.Application")
            End If

            For i = 0 To Me.grdStatusCheck.RowCount - 1
                GRow = Me.grdStatusCheck.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record And GRow.Cells("EmailSent").Value = False Then
                    Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                    GenerateStatusEmails(GRow, Email)
                End If
            Next

            OL = Nothing
        End If

        'toggle all email alerts as sent or not sent
        If e.Column.Key = "EmailSent" Then
            Dim GRow As Janus.Windows.GridEX.GridEXRow, i As Integer, bSent As Boolean,
                strFilter As String, strSQL As String

            strFilter = "("

            'This part is just to show the checkmark to the user.  Table update happens below.
            For i = 0 To Me.grdStatusCheck.RowCount - 1
                GRow = Me.grdStatusCheck.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record And GRow.Cells("EmailSent").Value = False Then
                    GRow.BeginEdit()
                    GRow.Cells("EmailSent").Value = True
                    GRow.EndEdit()
                    strFilter = strFilter & GRow.Cells("TrademarkUpdateID").Text & ","
                End If
            Next

            strFilter = strFilter & "0)"

            If bSent = True Then
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblTrademarkUpdates set EmailSent= -1 where TrademarkUpdateID in " & strFilter
                Else
                    strSQL = "update tblTrademarkUpdates set EmailSent= 1 where TrademarkUpdateID in " & strFilter
                End If
            Else
                strSQL = "update tblTrademarkUpdates set EmailSent= 0 where TrademarkUpdateID in " & strFilter
            End If

            DataStuff.RunSQL(strSQL)

        End If
    End Sub

    Private Sub GenerateStatusEmails(ByVal GRow As Janus.Windows.GridEX.GridEXRow, ByVal Email As Outlook.MailItem)
        On Error Resume Next
        Dim strTo As String, strSubject As String, strMessage As String,
             drToList As OleDb.OleDbDataReader, strSQL As String

        strTo = ""
        strSQL = "Select distinct ContactEmail from qvwTrademarkStatusToList where TrademarkUpdateID=" & GRow.Cells("TrademarkUpdateID").Value
        drToList = DataStuff.GetDataReader(strSQL)

        'don't bother if there are no recipients
        If drToList.HasRows = False Then
            MsgBox("There are no contacts designated to receive alert emails for the trademark.")
            Exit Sub
        End If

        While drToList.Read
            strTo = strTo & drToList("ContactEmail") & ";"
        End While

        strSubject = "Status Update: " & GRow.Cells("TrademarkName").Value.ToString
        strSubject = strSubject & " | " & GRow.Cells("ApplicationNumber").Value.ToString

        strMessage = "The status of @TrademarkName | App# @ApplicationNumber was changed to @StatusText on @StatusDate."

        strMessage = Replace(strMessage, "@TrademarkName", GRow.Cells("TrademarkName").Value.ToString)
        strMessage = Replace(strMessage, "@ApplicationNumber", GRow.Cells("ApplicationNumber").Value.ToString)
        strMessage = Replace(strMessage, "@StatusText", GRow.Cells("StatusText").Value.ToString)
        strMessage = Replace(strMessage, "@StatusDate", GRow.Cells("StatusDate").Text)

        GRow.BeginEdit()
        GRow.Cells("EmailSent").Value = True
        GRow.EndEdit()

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            strSQL = "update tblTrademarkUpdates set EmailSent= -1" &
                " where TrademarkUpdateID=" & GRow.Cells("TrademarkUpdateID").Value
        Else
            strSQL = "update tblTrademarkUpdates set EmailSent= 1" &
                " where TrademarkUpdateID=" & GRow.Cells("TrademarkUpdateID").Value
        End If
        DataStuff.RunSQL(strSQL)

        With Email
            .To = strTo
            .Subject = strSubject
            If RevaSettings.EmailHTML = True Then
                strMessage = strMessage.Replace(vbCrLf, "<p>")
                .HTMLBody = strMessage
            Else
                .Body = strMessage
            End If
            .Display()
        End With

    End Sub

    Private Sub grdStatusCheck_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdStatusCheck.RecordUpdated
        On Error Resume Next
        Dim bEmailSent As Boolean = False
        Dim iTrademarkUpdateID As Integer
        Dim strSQL As String

        bEmailSent = Me.grdStatusCheck.GetValue("EmailSent")
        iTrademarkUpdateID = Me.grdStatusCheck.GetValue("TrademarkUpdateID")

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            strSQL = "update tblTrademarkUpdates set EmailSent=" & IIf(bEmailSent = True, "-1", "0") &
                " where TrademarkUpdateID=" & iTrademarkUpdateID
        Else
            strSQL = "update tblTrademarkUpdates set EmailSent=" & IIf(bEmailSent = True, "1", "0") &
                " where TrademarkUpdateID=" & iTrademarkUpdateID
        End If
        DataStuff.RunSQL(strSQL)
    End Sub

    Private Sub btnChooseColsUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseColsUpdates.Click
        On Error Resume Next
        With Me.grdStatusCheck
            .RootTable.Columns("lnkSend").ShowInFieldChooser = False
            .RootTable.Columns("TrademarkUpdateID").ShowInFieldChooser = False
            .RootTable.Columns("TrademarkID").ShowInFieldChooser = False
            .HideFieldChooser()
            .ShowFieldChooser()
        End With
    End Sub

#End Region



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        'clear columns first
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdList.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next
        ResetListColumn("TrademarkID", 0, 100, False)
        ResetListColumn("TrademarkName", 1, 150, True)
        ResetListColumn("TrademarkType", 2, 100, True)
        ResetListColumn("CompanyName", 3, 175, True)
        ResetListColumn("Jurisdiction", 4, 100, True)
        ResetListColumn("Treaty", 5, 45, True)
        ResetListColumn("ApplicationNumber", 6, 100, True)
        ResetListColumn("RegistrationNumber", 7, 100, True)
        ResetListColumn("FilingBasis", 8, 100, True)
        ResetListColumn("Status", 9, 100, True)
        ResetListColumn("OurDocket", 10, 100, True)
        ResetListColumn("ClientDocket", 11, 100, False)
        ResetListColumn("FileNumber", 12, 100, False)
        ResetListColumn("CheckStatus", 13, 80, False)
        ResetListColumn("lnkDelete", 14, 18, True)
        ResetListColumn("StatusCode", 15, 18, False)

        SaveGridLayouts()
        SetBrowseGrid()



        'Dim f As New aForm1
        'f.Show()
        'Dim strAddress As String
        'strAddress = "234 Main Street" & vbCrLf & "Suite Two"
        'Dim sLines() As String, N As Long
        'sLines = Split(strAddress, vbCrLf)
        'For N = 0 To UBound(sLines)
        '    MsgBox(sLines(N))
        'Next N


    End Sub



    Private Sub TrademarkTypeID_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrademarkTypeID.MouseWheel
        ' Ctype(Janus.Windows.GridEX.EditControls.MultiColumnCombo, sender).
        'Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
        'Combo = sender
        'Dim Hme As HandledMouseEventArgs = e
        'Hme.Handled = True


        'Dim mwe As HandledMouseEventArgs = CType(e, HandledMouseEventArgs)
        'mwe.Handled = True


        'Combo.SelectedIndex = Combo.
    End Sub





End Class