Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmPatents

#Region "Declarations"

    'data tables for Grids and Drop-Down lists
    Private dtPatentsList As DataTable
    Private dtContacts As DataTable
    Private dtMatters As DataTable
    Private dvTreatyTypes As DataView
    Private dtDates As DataTable
    Private dtDocLinks As DataTable
    Private dtLicensed As DataTable

    Private rsPatents As New BoundRecordSet
    Private rsActions As New RecordSet
    Private rsPatentClasses As New RecordSet

    'because lots of stuff shouldn't happen until form is loaded
    Private bFormLoaded As Boolean = False

    'need to store these so we can compare old and new values
    Private iOldJurisdictionID As Integer
    Private iOldPatentTypeID As Integer

    Private iTotalRecords As Integer
    Friend bIsTreaty As Boolean
    Friend bIsLinked As Boolean
    Private bIsTreatyBasis As Boolean
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
            'If bWasEdited = True Then SavePatent()
            SavePatent()

            Application.Exit()
        End If
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        AllForms.OpenLogin()
    End Sub

    Private Sub btnGoTrademarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoTrademarks.Click
        On Error Resume Next
        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        AllForms.OpenTrademarks()
        Me.Close()
    End Sub

    Private Sub btnGoToOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToOppositions.Click
        On Error Resume Next
        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        AllForms.OpenOppositions()
        Me.Close()
    End Sub

    Private Sub btnGoToContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToContacts.Click
        On Error Resume Next
        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        AllForms.OpenCompanies()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        On Error Resume Next
        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        AllForms.OpenReports()
    End Sub

    Private Sub btnPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreferences.Click
        On Error Resume Next
        AllForms.OpenPreferences()
    End Sub

    Private Sub btnPrevRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevRecord.Click
        On Error Resume Next
        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        Me.grdLicensed.UpdateData()
        Me.grdDocumentLinks.UpdateData()

        Select Case Globals.NavigatePatentsFrom
            Case 1
                Me.grdList.MovePrevious()
                Globals.PatentID = Me.grdList.GetValue("PatentID")
                GetPatent()

            Case 2
                Me.grdAlerts.MovePrevious()
                Globals.PatentID = Me.grdAlerts.GetValue("PatentID")
                GetPatent()

            Case 3
                AllForms.frmReports.grdPatents.MovePrevious()
                Globals.PatentID = AllForms.frmReports.grdPatents.GetValue("PatentID")
                GetPatent()

            Case 4

        End Select
    End Sub

    Private Sub btnNextRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextRecord.Click
        On Error Resume Next

        SavePatent()
        Me.grdActions.UpdateData()
        Me.grdClasses.UpdateData()
        Me.grdContacts.UpdateData()
        rsActions.Update()
        rsPatentClasses.Update()
        Me.grdLicensed.UpdateData()
        Me.grdDocumentLinks.UpdateData()

        Select Case Globals.NavigatePatentsFrom
            Case 1
                Me.grdList.MoveNext()
                Globals.PatentID = Me.grdList.GetValue("PatentID")
                GetPatent()

            Case 2
                Me.grdAlerts.MoveNext()
                Globals.PatentID = Me.grdAlerts.GetValue("PatentID")
                GetPatent()

            Case 3
                AllForms.frmReports.grdPatents.MoveNext()
                Globals.PatentID = AllForms.frmReports.grdPatents.GetValue("PatentID")
                GetPatent()

            Case 4

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
            If .optList.Checked And (My.Settings.PatentListLayout.Length > 100) Then
                .grdList.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.PatentListLayout))
                .grdList.RemoveFilters()
            End If

            If .optAlerts.Checked And (My.Settings.PatentAlertLayout.Length > 100) Then
                .grdAlerts.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.PatentAlertLayout))
                .grdAlerts.RemoveFilters()
            End If

            If .optEmailAlerts.Checked And (My.Settings.PatentEmailAlertLayout.Length > 100) Then
                .grdAlerts.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.PatentEmailAlertLayout))
                .grdAlerts.RemoveFilters()
            End If
        End With

    End Sub

    Private Sub SaveGridLayouts()
        On Error Resume Next
        With Me
            If .optList.Checked Then
                My.Settings.PatentListLayout = .grdList.GetLayout.GetXmlString

            End If

            If .optAlerts.Checked Then
                My.Settings.PatentAlertLayout = .grdAlerts.GetLayout.GetXmlString

            End If

            If .optEmailAlerts.Checked Then
                My.Settings.PatentEmailAlertLayout = .grdAlerts.GetLayout.GetXmlString

            End If
        End With

    End Sub

    Private Sub mnuResetGrid_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuResetGrid.ItemClicked
        On Error Resume Next
        With Me
            If .optList.Checked Then
                ResetPatentsList()
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

    Private Sub ResetPatentsList()
        On Error Resume Next
        ' this is the panic-button if a grid goes completely haywire.
        If MsgBox("Reset the grid to its default layout?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'clear columns first
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdList.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetListColumn("PatentID", 0, 100, False)
        ResetListColumn("PatentName", 1, 180, True)
        ResetListColumn("CompanyName", 2, 150, True)
        ResetListColumn("Jurisdiction", 3, 100, True)
        ResetListColumn("Treaty", 4, 45, True)
        ResetListColumn("ApplicationNumber", 5, 120, True)
        ResetListColumn("PatentNumber", 6, 90, True)
        ResetListColumn("FilingBasis", 7, 90, True)
        ResetListColumn("Status", 8, 80, True)
        ResetListColumn("OurDocket", 9, 100, False)
        ResetListColumn("ClientDocket", 10, 100, False)
        ResetListColumn("PatentType", 11, 100, True)
        ResetListColumn("FileNumber", 12, 100, False)
        ResetListColumn("lnkDelete", 13, 18, True)

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

        ResetAlertColumn("PatentDateID", 0, 100, False)
        ResetAlertColumn("PatentID", 1, 100, False)
        ResetAlertColumn("DateID", 2, 100, False)
        ResetAlertColumn("PatentName", 3, 180, True)
        ResetAlertColumn("CompanyName", 4, 150, True)
        ResetAlertColumn("Jurisdiction", 5, 100, True)
        ResetAlertColumn("ApplicationNumber", 6, 110, True)
        ResetAlertColumn("PatentNumber", 7, 80, True)
        ResetAlertColumn("FilingBasis", 8, 80, False)
        ResetAlertColumn("Status", 9, 80, True)
        ResetAlertColumn("OurDocket", 10, 100, False)
        ResetAlertColumn("ClientDocket", 11, 100, False)
        ResetAlertColumn("FileNumber", 12, 100, False)
        ResetAlertColumn("DateName", 13, 145, True)
        ResetAlertColumn("PatentDate", 14, 80, True)
        ResetAlertColumn("Completed", 15, 49, True)
        ResetAlertColumn("lnkSend", 16, 90, False)
        ResetAlertColumn("EmailSent", 17, 49, False)
        ResetAlertColumn("PatentType", 18, 100, False)
        ResetAlertColumn("EmailAlert", 19, 100, False)
        ResetAlertColumn("EmailSubjectLine", 20, 100, False)

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

        ResetAlertColumn("PatentDateID", 0, 100, False)
        ResetAlertColumn("PatentID", 1, 100, False)
        ResetAlertColumn("DateID", 2, 100, False)
        ResetAlertColumn("PatentName", 3, 150, True)
        ResetAlertColumn("CompanyName", 4, 175, True)
        ResetAlertColumn("Jurisdiction", 5, 100, True)
        ResetAlertColumn("ApplicationNumber", 6, 80, True)
        ResetAlertColumn("PatentNumber", 7, 80, True)
        ResetAlertColumn("FilingBasis", 8, 100, False)
        ResetAlertColumn("Status", 9, 80, True)
        ResetAlertColumn("OurDocket", 10, 100, True)
        ResetAlertColumn("ClientDocket", 11, 100, False)
        ResetAlertColumn("FileNumber", 12, 100, False)
        ResetAlertColumn("DateName", 13, 145, True)
        ResetAlertColumn("PatentDate", 14, 80, True)
        ResetAlertColumn("Completed", 15, 49, False)
        ResetAlertColumn("lnkSend", 16, 90, True)
        ResetAlertColumn("EmailSent", 17, 49, True)
        ResetAlertColumn("PatentType", 18, 100, False)
        ResetAlertColumn("EmailAlert", 19, 100, False)
        ResetAlertColumn("EmailSubjectLine", 20, 100, False)


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
                GetPatentsList()
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
                .grpAlerts.Enabled = False
                .BetweenStart.Enabled = False
                .BetweenStart.Text = ""
                .BetweenEnd.Enabled = False
                .BetweenEnd.Text = ""
                .cboEnd.Enabled = False
                .cboStart.Enabled = False
                .grpListButtons.Enabled = True
                .btnPrintList.Text = "Print List"
                .btnPrintRecords.Visible = False
                .btnNewPatent.Visible = True
                .lblReportWidth.Visible = True
                .lblReportWidth.Left = 715

                .pnlBrowse.Height = 46
                .grpCustomize.Top = 0
                .grpCustomize.Left = 0
                .grpCustomize.Dock = DockStyle.Top
                .grpCustomize.Visible = True
                .grpSetContact.Visible = False
                .grdSetContacts.Visible = False
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .cboSetPosition.DataBindings.Clear()
                .cboSetPosition.Clear()
                .btnAddContacts.Visible = False
                .btnRemoveContacts.Visible = False
                .grdSetContacts.DataSource = Nothing
            End With
            With Me.grdList
                .Visible = True
                .Dock = DockStyle.Fill
                .SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .ScrollBars = Janus.Windows.GridEX.ScrollBars.Automatic
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                .RootTable.Columns("PatentID").ShowInFieldChooser = False
                .RootTable.Columns("lnkDelete").ShowInFieldChooser = False
                .RootTable.Columns("PatentName").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                .Row = 0
            End With
        End If


        If Me.optSetContacts.Checked = True Then
            With Me
                .grdAlerts.Visible = False
                .grdAlerts.DataSource = Nothing
                .grpAlerts.Enabled = False
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
                .cboSetPosition.SetDataBinding(RevaData.tblPatentPositions, "")
                .btnAddContacts.Visible = True
                .btnRemoveContacts.Visible = True
                .lblReportWidth.Visible = False
            End With
            With Me.grdList
                .Visible = True
                .Dock = DockStyle.Left
                .SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RootTable.Columns("CompanyName").Width = 180
                .RootTable.Columns("PatentName").Width = 200
                .RootTable.Columns("Jurisdiction").Width = 95
                .RootTable.Columns("PatentName").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                .Row = 0
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
                .grpCustomize.Visible = True
                .grpCustomize.Dock = DockStyle.Top
                .cboSetPosition.SetDataBinding(RevaData.tblPatentPositions, "")
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .grpSetContact.Visible = True
                .grpAlerts.Enabled = True
                .grdSetContacts.Visible = False
                .grdList.Visible = False
                .BetweenStart.Enabled = True
                .BetweenEnd.Enabled = True
                .cboEnd.Enabled = True
                .cboStart.Enabled = True
                .grpListButtons.Enabled = True
                .btnPrintList.Text = "Print Alerts"
                .btnPrintRecords.Visible = True
                .btnNewPatent.Visible = False
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
                .RootTable.Columns("PatentID").ShowInFieldChooser = False
                .RootTable.Columns("PatentDateID").ShowInFieldChooser = False
                .RootTable.Columns("EmailAlert").ShowInFieldChooser = False
                .RootTable.Columns("EmailSubjectLine").ShowInFieldChooser = False
                .RootTable.Columns("DateID").ShowInFieldChooser = False
                .RootTable.Columns("IsLocked").ShowInFieldChooser = False
                .RootTable.Columns("RecurNumber").ShowInFieldChooser = False
                .RootTable.Columns("lnkSend").ShowInFieldChooser = False
                .RootTable.Columns("EmailSent").ShowInFieldChooser = False

                GetAlertDates()
                .Row = 0
            End With

        End If

        If Me.optEmailAlerts.Checked = True Then
            With Me
                .btnAddContacts.Visible = False
                .btnRemoveContacts.Visible = False
                .pnlBrowse.Height = 46
                .grpCustomize.Visible = True
                .cboSetPosition.SetDataBinding(RevaData.tblPatentPositions, "")
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
                .btnNewPatent.Visible = False
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
                .RootTable.Columns("PatentID").ShowInFieldChooser = False
                .RootTable.Columns("PatentDateID").ShowInFieldChooser = False
                .RootTable.Columns("EmailAlert").ShowInFieldChooser = False
                .RootTable.Columns("EmailSubjectLine").ShowInFieldChooser = False
                .RootTable.Columns("DateID").ShowInFieldChooser = False
                .RootTable.Columns("IsLocked").ShowInFieldChooser = False
                .RootTable.Columns("RecurNumber").ShowInFieldChooser = False
                .RootTable.Columns("lnkSend").ShowInFieldChooser = False
                .RootTable.Columns("EmailSent").ShowInFieldChooser = False
                .RootTable.Columns("Completed").ShowInFieldChooser = False
                GetEmailAlerts()
                ' .Row = 0
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
        GetPatentsList()
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
                GetPatentsList()
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
        Dim drReader As OleDb.OleDbDataReader, rptPatent As New rptOnePatent, strSQL As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor
        strFilter = "PatentID in ("
        strSort = "CompanyName, PatentName, Jurisdiction, PatentID, PatentDate"

        For i = 0 To Me.grdAlerts.RowCount
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("PatentID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = SQL.vwReportPatents & " where " & strFilter & " order by " & strSort
        drReader = DataStuff.GetDataReader(strSQL)
        rptPatent.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptPatent.Document
        rptPatent.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnNewPatent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewPatent.Click
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

        DataStuff.RunSQL("insert into tblPatents (PatentName, GraphicSizeToFit) values ('Type Patent Name Here',0)")
        Globals.PatentID = DataStuff.DMax("PatentID", "tblPatents")

        'add any contacts who are supposed to be on all Patents
        DataStuff.RunSQL("Insert into tblPatentContacts (PatentID, ContactID, PositionID) select " &
            Globals.PatentID & ", ContactID, PositionID from tblContacts where AddToPatents <> 0 and PositionID > 0")

        GetPatent()
        Globals.NavigatePatentsFrom = 0
        Me.Tabs.SelectedIndex = 1
        'Me.btnNextRecord.Enabled = False
        'Me.btnPrevRecord.Enabled = False
        'Me.RecordCount.Text = ""
    End Sub

    Private Sub grdList_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdList.LinkClicked
        On Error Resume Next

        If (e.Column.Key = "PatentName") Or (e.Column.Key = "ApplicationNumber") Then
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
                Globals.PatentID = Me.grdList.GetValue("PatentID")
                Globals.NavigatePatentsFrom = 1
                GetPatent()
                Me.Tabs.SelectedIndex = 1
            End If
        End If

        If e.Column.Key = "lnkDelete" Then
            If Globals.SecurityLevel > 1 Then Exit Sub
            Dim strMessage As String, iPatentID As Integer

            iPatentID = Me.grdList.GetValue("PatentID")
            If DataStuff.DCount("TreatyFilingID", "tblPatentTreatyFilings", "PatentID=" & iPatentID) > 0 Then
                MsgBox("You cannot delete a Patent that is the basis Patent for a treaty filing.")
                Exit Sub
            End If

            strMessage = "This will delete the Patent and all related Patent contacts and Patent dates." &
                    vbCrLf & "This delete cannot be undone.  Are you sure?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'if we're still here, let's do it
            DataStuff.DeletePatent(iPatentID)
            GetPatentsList()
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
                strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwPatentContacts" &
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
            strSQL = "SELECT PatentContactID, CompanyName, PatentName, Jurisdiction, PatentID, ContactID, PositionID " &
            "from qvwPatentContacts where ContactID=" & iContactID & " and PositionID=" & iPositionID &
            " order by CompanyName, PatentName"
            dtPositionsList = DataStuff.GetDataTable(strSQL)
            Me.grdSetContacts.DataSource = dtPositionsList
        End If

    End Sub

    Private Sub btnAddContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContacts.Click
        On Error Resume Next
        Dim iContactID As Integer, iPositionID As Integer, i As Integer, iPatentID As Integer,
            GRow As Janus.Windows.GridEX.GridEXRow, strFilter As String, strSQL As String, rsContacts As New RecordSet

        'don't bother if nothing is selected
        If Me.grdList.SelectedItems.Count < 1 Then
            MsgBox("You must select Patents to add first.")
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
        strSQL = "Select * from tblPatentContacts where ContactID=" & iContactID & " and PositionID=" & iPositionID
        rsContacts.GetFromSQL(strSQL)

        For i = 0 To Me.grdList.SelectedItems.Count - 1
            GRow = Me.grdList.SelectedItems(i).GetRow
            iPatentID = GRow.Cells("PatentID").Value
            strFilter = "ContactID=" & iContactID & " and PositionID=" & iPositionID &
                " and PatentID=" & iPatentID
            If rsContacts.RecordExists(strFilter) = False Then
                rsContacts.AddRow()
                'final precaution, make sure it's a new row
                If rsContacts.CurrentRow("PatentID").ToString = "" Then
                    rsContacts.CurrentRow("PatentID") = iPatentID
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
        strSQL = "delete from tblPatentContacts where PatentContactID in ("
        For i = 0 To Me.grdSetContacts.SelectedItems.Count - 1
            GRow = Me.grdSetContacts.SelectedItems(i).GetRow
            strSQL = strSQL & GRow.Cells("PatentContactID").Value & ","
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
                    strSQL = SQL.vwPatentAlerts
                    strSQL = strSQL & " and PatentDate >=" & FixDate(.BetweenStart.Text)
                    strSQL = strSQL & " and PatentDate <=" & FixDate(.BetweenEnd.Text)

                    If .cboSetPosition.Value > 0 And .cboSetContact.Value > 0 Then
                        strSQL = strSQL & " and PatentID in (Select PatentID from qvwPatentContacts" &
                            " where ContactID=" & .cboSetContact.Value & " and PositionID=" & .cboSetPosition.Value & ")"
                    End If

                    strSQL = strSQL & " union " & SQL.vwPatentActionAlerts
                    strSQL = strSQL & " and ActionDate >=" & FixDate(.BetweenStart.Text)
                    strSQL = strSQL & " and ActionDate <=" & FixDate(.BetweenEnd.Text)

                    If .cboSetPosition.Value > 0 And .cboSetContact.Value > 0 Then
                        strSQL = strSQL & " and PatentID in (Select PatentID from qvwPatentContacts" &
                            " where ContactID=" & .cboSetContact.Value & " and PositionID=" & .cboSetPosition.Value & ")"
                    End If
                    strSQL = strSQL & " order by PatentDate, CompanyName"

                    dtAlerts = DataStuff.GetDataTable(strSQL)
                    .grdAlerts.DataSource = dtAlerts
                Else
                    dtAlerts = Nothing
                    .grdAlerts.DataSource = Nothing
                End If
            End With
        End If

    End Sub

    Private Sub grdAlerts_GetChildList(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.GetChildListEventArgs) Handles grdAlerts.GetChildList
        On Error Resume Next
        'populates child table rows when the + sign is clicked on a parent row.
        Dim PatentID As Integer, strSQL As String
        PatentID = e.ParentRow.Cells("PatentID").Value

        grdAlerts.Tables("Dates").FormatConditions.Clear()
        ApplyListDateFormatting()

        If e.ChildTable.Key = "Actions" Then
            strSQL = "Select * from tblPatentActions where PatentID=" & PatentID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If

        If e.ChildTable.Key = "Dates" Then
            strSQL = "SELECT PatentDateID, PatentID, JurisdictionDateID, JurisdictionID, DateID, DateName, " &
            "PatentDate, NoDay, NoMonth, ListOrder, Completed, IsLocked, RecursAtInterval, " &
            "HasRelatives, DisplayInLinked, IsRelative from qvwPatentDates where PatentID=" & PatentID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If
    End Sub

    Private Sub ApplyListDateFormatting()
        On Error Resume Next
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition, PatentDateID As Integer
        PatentDateID = grdAlerts.GetValue("PatentDateID")
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdAlerts.Tables("Dates").Columns("PatentDateID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentDateID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdAlerts.Tables("Dates").FormatConditions.Add(fc)
    End Sub

    Private Sub grdAlerts_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdAlerts.LinkClicked
        On Error Resume Next
        If e.Column.Key = "PatentName" Or e.Column.Key = "ApplicationNumber" Then
            Me.grdAlerts.UpdateData()
            Globals.PatentID = Me.grdAlerts.GetValue("PatentID")
            Globals.NavigatePatentsFrom = 2
            GetPatent()
            Me.Tabs.SelectedIndex = 1
        End If

        If e.Column.Key = "lnkSend" Then
            Dim OL As Outlook.Application, Email As Outlook.MailItem

            OL = GetObject(, "Outlook.Application")
            If OL Is Nothing Then
                OL = CreateObject("Outlook.Application")
            End If

            Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
            GenerateEmails(Me.grdAlerts.CurrentRow, Email)
            OL = Nothing

        End If

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
            Dim ReportTable As DataTable, rptAlerts As New rptPatentAlerts
            Me.Cursor = Cursors.WaitCursor
            ReportTable = DataStuff.GetTableFromGrid(Me.grdAlerts, "PatentName", False)

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
        Dim strSort As String, strFilter As String, strField As String, strValue As String,
            i As Integer, strSQL As String, drReader As OleDb.OleDbDataReader

        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor

        strFilter = " where PatentID <> 0"

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

        strFilter = strFilter & " and PatentDateID in ("
        For i = 0 To Me.grdAlerts.RowCount - 1
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("PatentDateID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        Dim rptAlertsPosition As New rptPatentAlertsPosition
        strSQL = "Select * from (" & SQL.vwReportPatentAlertsPosition & " union " &
        SQL.vwReportPatentActionAlertsPosition & ") Q " & strFilter

        Select Case strSort
            Case "CompanyName"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "CompanyName, PatentName, PatentID, PatentDate"

            Case "PatentName"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "PatentName, PatentID, CompanyName, PatentDate"

            Case "PatentDate"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "PatentDate, PatentID,CompanyName, PatentName"

            Case "Status"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "Status, PatentDate, PatentID,CompanyName, PatentName"

            Case "FilingBasis"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "FilingBasis, PatentDate, PatentID,CompanyName, PatentName"

            Case "FileNumber"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "FileNumber, PatentDate, PatentID,CompanyName, PatentName"

            Case "OurDocket"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "OurDocket, PatentDate, PatentID,CompanyName, PatentName"

            Case "ClientDocket"
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                    "ClientDocket, PatentDate, PatentID,CompanyName, PatentName"

            Case Else
                strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                     "CompanyName, PatentName, PatentID, PatentDate"

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

        On Error Resume Next

        Dim ReportTable As DataTable, rptList As New rptPatentsList
        Me.Cursor = Cursors.WaitCursor
        ReportTable = DataStuff.GetTableFromGrid(Me.grdList, "PatentName", False)

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
        Dim strSubject As String, dPatentDate As Date, strDayBefore As String, strDayAfter As String,
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

                'some Patents and company names have quotes in them, have to kill 'em
                strSubject = strSubject & Replace(.Cells("PatentName").Value, Chr(34), "") & " | "
                strSubject = strSubject & Replace(.Cells("CompanyName").Value, Chr(34), "") & " | "

                strSubject = strSubject & .Cells("Jurisdiction").Value & " | "
                strSubject = strSubject & .Cells("ApplicationNumber").Value & " | "
                strSubject = strSubject & .Cells("DateName").Value & " | "

                strBody = strBody & .Cells("PatentName").Value & vbCrLf
                strBody = strBody & .Cells("CompanyName").Value & vbCrLf
                strBody = strBody & .Cells("Jurisdiction").Value & vbCrLf
                strBody = strBody & .Cells("ApplicationNumber").Value & vbCrLf
                strBody = strBody & .Cells("DateName").Value & " due on " & .Cells("PatentDate").Value


                dPatentDate = .Cells("PatentDate").Value
                If IsDate(dPatentDate) = False Then
                    MsgBox("Could not interpret date for " & .Cells("PatentName").Value & ".  Please check the selected data and try again.")
                End If
            End With

            dPatentDate = DateAdd("d", -iLeadDays, dPatentDate)
            If sngAlertTime <> 0 Then
                dPatentDate = DateAdd(DateInterval.Minute, sngAlertTime * 60, dPatentDate)
            End If

            'if saturday or sunday, move warning to Friday
            If Weekday(dPatentDate) = vbSunday Then dPatentDate = DateAdd("d", -2, dPatentDate)
            If Weekday(dPatentDate) = vbSaturday Then dPatentDate = DateAdd("d", -1, dPatentDate)

            'needed for restrict clause later
            strDayBefore = Format(DateAdd("d", -1, dPatentDate), "MMM dd, yyyy")
            strDayAfter = Format(DateAdd("d", 1, dPatentDate), "MMM dd, yyyy")

            objTask = objOutlook.CreateItem(Outlook.OlItemType.olAppointmentItem)

            With objTask
                .Subject = strSubject
                .Body = strBody
                .AllDayEvent = IIf(sngAlertTime = 0, True, False)
                .ReminderMinutesBeforeStart = 0
                .ReminderSet = True
                .Start = dPatentDate

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
        Me.grdAlerts.DataSource = DataStuff.GetDataTable("Select * from qvwPatentEmailAlerts order by PatentDate, CompanyName")
    End Sub

    Private Sub grdAlerts_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.RecordUpdated
        On Error Resume Next
        Dim iPatentDateID As Long, bEmailSent As Boolean, bCompleted As Boolean, strSQL As String, iDateID As Integer
        iPatentDateID = Me.grdAlerts.GetValue("PatentDateID")
        iDateID = Me.grdAlerts.GetValue("DateID")

        If Me.optEmailAlerts.Checked = True Then
            bEmailSent = Me.grdAlerts.GetValue("EmailSent")
            If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                strSQL = "update tblPatentDates set EmailSent=" & IIf(bEmailSent = True, "-1", "0") &
                    " where PatentDateID=" & iPatentDateID
            Else
                strSQL = "update tblPatentDates set EmailSent=" & IIf(bEmailSent = True, "1", "0") &
                    " where PatentDateID=" & iPatentDateID
            End If
            DataStuff.RunSQL(strSQL)
        End If

        If Me.optAlerts.Checked = True Then
            bCompleted = Me.grdAlerts.GetValue("Completed")
            ' a dateID of zero means it's an action alert
            If iDateID <> 0 Then
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblPatentDates set Completed=" & IIf(bCompleted = True, "-1", "0") &
                        " where PatentDateID=" & iPatentDateID
                Else
                    strSQL = "update tblPatentDates set Completed=" & IIf(bCompleted = True, "1", "0") &
                        " where PatentDateID=" & iPatentDateID
                End If
            Else
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblPatentActions set Completed=" & IIf(bCompleted = True, "-1", "0") &
                        " where PatentActionID=" & iPatentDateID
                Else
                    strSQL = "update tblPatentActions set Completed=" & IIf(bCompleted = True, "1", "0") &
                        " where PatentActionID=" & iPatentDateID
                End If
            End If

            DataStuff.RunSQL(strSQL)
        End If

    End Sub

    Private Sub grdAlerts_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdAlerts.ColumnHeaderClick
        On Error Resume Next

        'send all email alerts
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
                    strFilter = strFilter & GRow.Cells("PatentDateID").Text & ","
                End If
            Next

            strFilter = strFilter & "0)"

            If bSent = True Then
                If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                    strSQL = "update tblPatentDates set EmailSent= -1 where PatentDateID in " & strFilter
                Else
                    strSQL = "update tblPatentDates set EmailSent= 1 where PatentDateID in " & strFilter
                End If
            Else
                strSQL = "update tblPatentDates set EmailSent= 0 where PatentDateID in " & strFilter
            End If

            DataStuff.RunSQL(strSQL)

        End If

    End Sub

    Private Sub GenerateEmails(ByVal GRow As Janus.Windows.GridEX.GridEXRow, ByVal Email As Outlook.MailItem)
        On Error Resume Next
        Dim strTo As String, strSubject As String, strMessage As String,
             drToList As OleDb.OleDbDataReader, strSQL As String

        strTo = ""
        strSQL = "SELECT distinct PatentDateID, AutoEmail, EmailSent, ReceivesAlerts, FirstName, LastName, ContactEmail " &
        "from qvwPatentDatesAndContacts WHERE AutoEmail <> 0 AND EmailSent = 0 AND ReceivesAlerts <> 0 " &
        "and  PatentDateID=" & GRow.Cells("PatentDateID").Value
        drToList = DataStuff.GetDataReader(strSQL)

        'don't bother if there are no recipients
        If drToList.HasRows = False Then
            MsgBox("There are no contacts designated to receive alert emails for the patent.")
            Exit Sub
        End If

        While drToList.Read
            strTo = strTo & drToList("ContactEmail") & ";"
        End While

        strSubject = GRow.Cells("EmailSubjectLine").Value.ToString
        strMessage = GRow.Cells("EmailAlert").Value.ToString

        strMessage = Replace(strMessage, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strMessage = Replace(strMessage, "[PatentName]", GRow.Cells("PatentName").Value.ToString)
        strMessage = Replace(strMessage, "[ApplicationNumber]", GRow.Cells("ApplicationNumber").Value.ToString)
        strMessage = Replace(strMessage, "[PatentNumber]", GRow.Cells("PatentNumber").Value.ToString)
        strMessage = Replace(strMessage, "[FileNumber]", GRow.Cells("FileNumber").Value.ToString)
        strMessage = Replace(strMessage, "[ClientDocket]", GRow.Cells("ClientDocket").Value.ToString)
        strMessage = Replace(strMessage, "[OurDocket]", GRow.Cells("OurDocket").Value.ToString)
        strMessage = Replace(strMessage, "[Status]", GRow.Cells("Status").Value.ToString)
        strMessage = Replace(strMessage, "[PatentType]", GRow.Cells("PatentType").Value.ToString)
        strMessage = Replace(strMessage, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        strSubject = Replace(strSubject, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strSubject = Replace(strSubject, "[PatentName]", GRow.Cells("PatentName").Value.ToString)
        strSubject = Replace(strSubject, "[ApplicationNumber]", GRow.Cells("ApplicationNumber").Value.ToString)
        strSubject = Replace(strSubject, "[PatentNumber]", GRow.Cells("PatentNumber").Value.ToString)
        strSubject = Replace(strSubject, "[FileNumber]", GRow.Cells("FileNumber").Value.ToString)
        strSubject = Replace(strSubject, "[ClientDocket]", GRow.Cells("ClientDocket").Value.ToString)
        strSubject = Replace(strSubject, "[OurDocket]", GRow.Cells("OurDocket").Value.ToString)
        strSubject = Replace(strSubject, "[Status]", GRow.Cells("Status").Value.ToString)
        strSubject = Replace(strSubject, "[PatentType]", GRow.Cells("PatentType").Value.ToString)
        strSubject = Replace(strSubject, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        If RevaSettings.USADates = True Then
            strMessage = Replace(strMessage, "[PatentDate]", Format(GRow.Cells("PatentDate").Value, "MMM dd, yyyy"))
            strSubject = Replace(strSubject, "[PatentDate]", Format(GRow.Cells("PatentDate").Value, "MMM dd, yyyy"))
        Else
            strMessage = Replace(strMessage, "[PatentDate]", Format(GRow.Cells("PatentDate").Value, "dd MMM, yyyy"))
            strSubject = Replace(strSubject, "[PatentDate]", Format(GRow.Cells("PatentDate").Value, "dd MMM, yyyy"))
        End If

        GRow.BeginEdit()
        GRow.Cells("EmailSent").Value = True
        GRow.EndEdit()

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            strSQL = "update tblPatentDates set EmailSent= -1" &
                " where PatentDateID=" & GRow.Cells("PatentDateID").Value
        Else
            strSQL = "update tblPatentDates set EmailSent= 1" &
                " where PatentDateID=" & GRow.Cells("PatentDateID").Value
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

    Private Sub frmPatents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmPatents = Me
        iTotalRecords = DataStuff.RecordCount

        'if there email alerts due, open that form
        If RevaData.DCount("PatentDateID", "qvwPatentEmailAlerts", "PatentID<>0") > 0 Then
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
        GetPatentsList()
        FillDropDowns()
        SetSecurity()
        SetContactActionView()

        'now form is loaded and we let stuff happen
        bFormLoaded = True
        SetBrowseGrid()
        SetOptions()
        SetNavigationButtons()

    End Sub

    Private Sub frmPatents_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        SavePatent()
        SaveGridLayouts()
        AllForms.frmPatents = Nothing
        Globals.PatentID = 0

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
        DataStuff.RunSQL("update tblPatentActions set IsAlert = 0 where IsAlert Is null")
        DataStuff.RunSQL("update tblPatentActions set Completed = 0 where Completed Is null")
    End Sub

    Friend Sub SetDateFormats()
        On Error Resume Next
        With Me
            If RevaSettings.USADates = True Then
                .grdDates.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "MMM dd, yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "MMM dd, yyyy"
            Else
                .grdDates.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("PatentDate").FormatString = "dd MMM yyyy"
                .grdTreatyFilings.RootTable.Columns("FilingDate").FormatString = "dd MMM yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "dd MMM yyyy"
            End If
        End With

        With Me.grdLinked
            If RevaSettings.USADates = True Then
                .Tables("Dates01").Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .Tables("Dates02").Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .Tables("Dates03").Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .Tables("Dates04").Columns("PatentDate").FormatString = "MMM dd, yyyy"
                .Tables("Dates05").Columns("PatentDate").FormatString = "MMM dd, yyyy"
            Else
                .Tables("Dates01").Columns("PatentDate").FormatString = "dd MMM yyyy"
                .Tables("Dates02").Columns("PatentDate").FormatString = "dd MMM yyyy"
                .Tables("Dates03").Columns("PatentDate").FormatString = "dd MMM yyyy"
                .Tables("Dates04").Columns("PatentDate").FormatString = "dd MMM yyyy"
                .Tables("Dates05").Columns("PatentDate").FormatString = "dd MMM yyyy"
            End If
        End With

    End Sub

    Private Sub SetSecurity()
        On Error Resume Next

        Dim iSecurityLevel As Integer
        iSecurityLevel = Globals.SecurityLevel
        With Me

            .PatentName.ReadOnly = (iSecurityLevel = 3)
            .OurDocket.ReadOnly = (iSecurityLevel = 3)
            .ClientDocket.ReadOnly = (iSecurityLevel = 3)
            .ApplicationNumber.ReadOnly = (iSecurityLevel = 3)
            .AppInternational.ReadOnly = (iSecurityLevel = 3)
            .PatentNumber.ReadOnly = (iSecurityLevel = 3)
            .DeptUnit.ReadOnly = (iSecurityLevel = 3)
            .Abstract.ReadOnly = (iSecurityLevel = 3)
            .Claims.ReadOnly = (iSecurityLevel = 3)
            .Comments.ReadOnly = (iSecurityLevel = 3)
            .Category.ReadOnly = (iSecurityLevel = 3)
            .Subcategory.ReadOnly = (iSecurityLevel = 3)
            .GraphicPath.ReadOnly = (iSecurityLevel = 3)
            .FastTrack.Enabled = (iSecurityLevel < 3)
            .NonPublication.Enabled = (iSecurityLevel < 3)
            .btnAddContacts.Enabled = (iSecurityLevel < 3)
            .btnAddDates.Enabled = (iSecurityLevel < 3)
            .btnRemoveContacts.Enabled = (iSecurityLevel = 1)
            .btnAddTreatyFiling.Enabled = (iSecurityLevel < 3)
            .btnRemoveTreatyFiling.Enabled = (iSecurityLevel = 1)
            .btnNewPatent.Enabled = (iSecurityLevel < 3)
        End With

        'Janus has their own versions of true and false; have to use them
        Select Case iSecurityLevel
            Case 1 'PatentUser

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

            Case 2 'No Delete

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
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

            Case 3 'View Only

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
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

        End Select

    End Sub

    Private Sub SetNavigationButtons()
        On Error Resume Next
        With Me

            Select Case Globals.NavigatePatentsFrom
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
                        AllForms.frmReports.grdPatents.Row < (AllForms.frmReports.grdPatents.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (AllForms.frmReports.grdPatents.Row > 0)
                    .RecordCount.Text = (AllForms.frmReports.grdPatents.Row + 1).ToString +
                        " of " + AllForms.frmReports.grdPatents.RowCount.ToString

                Case 4 'Patents on companies form
                    .btnNextRecord.Enabled = False
                    .btnPrevRecord.Enabled = False
                    .RecordCount.Text = ""
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
                    GetTreatyPatents()
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
                .grdActions.RootTable.Columns("PatentAction").Width = 519
            Else
                .grdActions.RootTable.Columns("ActionHours").Visible = False
                .grdActions.RootTable.Columns("ActionBilled").Visible = False
                .grdActions.RootTable.Columns("Expenses").Visible = False
                .grdActions.RootTable.Columns("ExpensesBilled").Visible = False
                .grdActions.RootTable.Columns("PatentAction").Width = 700
            End If

        End With

    End Sub

    Friend Sub GetPatent()
        On Error Resume Next

        rsPatents.GetFromSQL("Select * from tblPatents where PatentID=" & Globals.PatentID)
        With rsPatents
            .BindData(Me.StatusID)
            .BindData(Me.FilingBasisID)
            .BindData(Me.CompanyID)
            .BindData(Me.FileID)
            .BindData(Me.PatentName)
            .BindData(Me.JurisdictionID)
            .BindData(Me.DeptUnit)
            .BindData(Me.PatentTypeID)
            .BindData(Me.OurDocket)
            .BindData(Me.ClientDocket)
            .BindData(Me.PublicationNumber)
            .BindData(Me.ApplicationNumber)
            .BindData(Me.AppInternational)
            .BindData(Me.PatentNumber)
            .BindData(Me.NonPublication)
            .BindData(Me.FastTrack)
            .BindData(Me.Abstract)
            .BindData(Me.Comments)
            .BindData(Me.Claims)
            .BindData(Me.GraphicPath)
            .BindData(Me.GraphicSizeToFit)
            .BindData(Me.Category)
            .BindData(Me.Subcategory, "Text")
        End With

        Me.picGraphic.ImageLocation = ""
        Globals.TreatyFilingID = IIf(rsPatents.CurrentRow("TreatyFilingID") Is DBNull.Value, 0, rsPatents.CurrentRow("TreatyFilingID"))
        'store these so we can warn user if they're changed later
        Me.iOldPatentTypeID = Nz(PatentTypeID.Value, 0)
        Me.iOldJurisdictionID = Nz(JurisdictionID.Value, 0)

        GetCompany()
        GetClasses()
        GetDates()
        GetMatters()
        GetActions()
        GetContacts()
        GetDocuments()
        GetLicensed()
        SetMoreInfo()

        'need to re-set each time we open a new Patent
        ' bWasEdited = False
        bTreatyFilingsFilled = False

        If DataStuff.DCount("TreatyFilingID", "tblPatentTreatyFilings", "PatentID=" & Globals.PatentID) > 0 Then
            bIsTreatyBasis = True
        Else
            bIsTreatyBasis = False
        End If

        If DataStuff.DLookup("IsTreaty", "tblPatentTypes", "PatentTypeID=" & Nz(PatentTypeID.Value, 0)) <> 0 Then
            bIsTreaty = True
        Else
            bIsTreaty = False
        End If

        If Nz(rsPatents.CurrentRow("ParentPatentID"), 0) > 0 Then
            bIsLinked = True
        Else
            If DataStuff.DCount("PatentID", "tblPatents", "ParentPatentID=" & Globals.PatentID) > 0 Then
                bIsLinked = True
            Else
                bIsLinked = False
            End If

        End If

        Me.Tabs.Focus()
        Me.chkShowRelated.Visible = ((bIsTreaty = True) Or (bIsTreatyBasis = True))
        Me.lblLinked.Visible = bIsLinked

        If (bIsTreaty = False) And (bIsTreatyBasis = False) Then
            Me.lblIsRelated.Visible = False
            'user may have navigated to non-treaty Patent with "show related" still checked
            If Me.chkShowRelated.Checked = True Then
                Me.chkShowRelated.Checked = False
                ' SetOptions()
            End If
        Else
            Me.lblIsRelated.Visible = True
        End If
        SetOptions()
        SetNavigationButtons()
        If Me.Tabs.SelectedIndex = 2 Then  'more information page
            GetGraphic()
        End If
    End Sub

    Friend Sub GetCompany()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader, iCompanyID As Integer, strSQL As String

        iCompanyID = Nz(rsPatents.CurrentRow("CompanyID"), 0)

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

    Friend Sub SavePatent()
        On Error Resume Next
        ' the replace is to protect customers against themselves.  A carriage return hoses merges.
        With Me
            If .Claims.Text.Contains(vbCrLf) Then
                .Claims.Text = Claims.Text.Replace(vbCrLf, " ")
            End If
            If .Comments.Text.Contains(vbCrLf) Then
                .Comments.Text = Comments.Text.Replace(vbCrLf, " ")
            End If
            If .Abstract.Text.Contains(vbCrLf) Then
                .Abstract.Text = Abstract.Text.Replace(vbCrLf, " ")
            End If
        End With
        rsPatents.Update()
    End Sub

    Private Sub tbPatent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPatent.Leave
        On Error Resume Next
        SavePatent()
        LockAndLoadActions()
    End Sub

    Private Sub SetMoreInfo()
        On Error Resume Next
        With Me
            .ShowCompany.Text = .CompanyID.Text
            .ShowFilingBasis.Text = .FilingBasisID.Text
            .ShowPatentType.Text = .PatentTypeID.Text
            .ShowApplication.Text = IIf(bIsTreaty = False, .ApplicationNumber.Text, .AppInternational.Text)
            .ShowPatentNumber.Text = .PatentNumber.Text
            .ShowPatent.Text = .PatentName.Text
            .ShowJurisdiction.Text = .JurisdictionID.Text
        End With
    End Sub

    Private Sub tbMoreInfo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMoreInfo.Enter
        On Error Resume Next
        SetMoreInfo()
    End Sub

    Private Sub tbMoreInfo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMoreInfo.Leave
        On Error Resume Next
        SavePatent()
        Me.grdClasses.UpdateData()
        rsPatentClasses.Update()
    End Sub

    Private Sub tbTreatyFilings_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTreatyFilings.Enter
        On Error Resume Next
        With Me
            .ShowCompany2.Text = .CompanyID.Text
            .ShowFilingBasis2.Text = .FilingBasisID.Text
            .ShowPatentType2.Text = .PatentTypeID.Text
            .ShowApplication2.Text = IIf(bIsTreaty = False, .ApplicationNumber.Text, .AppInternational.Text)
            .ShowPatentNumber2.Text = .PatentNumber.Text
            .ShowPatent2.Text = .PatentName.Text
            .ShowJurisdiction2.Text = .JurisdictionID.Text
        End With
        'just for now, delete later
        'Me.grdTreatyFilings.DataSource = DataStuff.GetDataTable("Select * from tblPatentTreatyFilings where PatentID=0")
        SetTreatyFilingPage()
        ShowTreatyGrids()
    End Sub

    Private Sub Tabs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.SelectedIndexChanged
        On Error Resume Next
        'keep user from opening empty data forms
        If (Me.Tabs.SelectedIndex = 1) Or (Me.Tabs.SelectedIndex = 2) _
            Or (Me.Tabs.SelectedIndex = 3) Or (Me.Tabs.SelectedIndex = 4) Then
            If (Globals.PatentID = 0) Then
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
        If (Me.Tabs.SelectedIndex = 1) Or (Me.Tabs.SelectedIndex = 2) _
            Or (Me.Tabs.SelectedIndex = 3) Or (Me.Tabs.SelectedIndex = 4) Then
            If (Globals.PatentID = 0) Then
                Me.Tabs.SelectedIndex = 0
            End If
        End If

        If Me.Tabs.SelectedIndex = 2 Then  'more information page
            GetGraphic()
        End If
    End Sub

    Private Sub CompanyID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CompanyID.Validated
        On Error Resume Next
        SavePatent()
        GetCompany()
        AddContacts()
        GetMatters()
    End Sub

    Private Sub PatentTypeID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatentTypeID.Validated
        On Error Resume Next

        'we're not changing a blank patent type
        If (iOldPatentTypeID <> 0) And (iOldPatentTypeID <> Nz(Me.PatentTypeID.Value, 0)) Then

            'make sure we're on patent page
            Me.Tabs.SelectedIndex = 1

            Dim strMessage As String
            strMessage = "You are about to change the Patent Type for this Patent.  This will delete the dates " &
                "for this patent and you will need to enter them again.  Proceed?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.PatentTypeID.Value = iOldPatentTypeID
                SavePatent()
                Exit Sub
            Else
                DataStuff.RunSQL("delete from tblPatentDates where PatentID=" & Globals.PatentID)
            End If
        End If

        'if we're still here, then enter patent dates
        AppendPatentDates()
    End Sub

    Private Sub JurisdictionID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JurisdictionID.Validated
        On Error Resume Next

        If (iOldJurisdictionID <> 0) And (iOldJurisdictionID <> Nz(Me.JurisdictionID.Value, 0)) Then
            'make sure we're on patent page
            Me.Tabs.SelectedIndex = 1

            Dim strMessage As String
            strMessage = "You are about to change the Jurisdiction for this Patent.  This will delete the dates " &
                "for this patent and you will need to enter them again.  Proceed?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.JurisdictionID.Value = iOldJurisdictionID
                SavePatent()
                Exit Sub
            Else
                DataStuff.RunSQL("delete from tblPatentDates where PatentID=" & Globals.PatentID)
            End If
        End If
        'if we're still here, then enter patent dates
        AppendPatentDates()
    End Sub

    Private Sub StatusID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.Validated
        On Error Resume Next
        AppendPatentDates()
    End Sub

    Private Sub AppendPatentDates()
        On Error Resume Next
        SavePatent()
        'we can't do the dates without a jurisdiction and a patent type
        If (Nz(Me.PatentTypeID.Value, 0) = 0) Or (Nz(Me.JurisdictionID.Value, 0) = 0) Then Exit Sub

        Dim PD As New PatentDates
        With PD
            .PatentID = Globals.PatentID
            .JurisdictionID = Nz(Me.JurisdictionID.Value, 0)
            .PatentTypeID = Nz(Me.PatentTypeID.Value, 0)
            .LoadPatentDates()
            .LoadJurisdictionDates()
            .AppendPatentTypeDates(Nz(Me.PatentTypeID.Value, 0))
            .AppendStatusDates(Nz(Me.StatusID.Value, 0))
            .UpdateRecurNumbers()
            .ReOrderPatentDates()
            .SaveChanges()
        End With
        PD = Nothing
        GetDates()
    End Sub

    Private Sub btnPrintOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOne.Click
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        Dim drReader As OleDb.OleDbDataReader, rptPatent As New rptOnePatent, strSQL As String
        strSQL = SQL.vwReportPatents & " where PatentID=" & Globals.PatentID &
                " order by CompanyName, PatentName, PatentDate"
        drReader = DataStuff.GetDataReader(strSQL)
        rptPatent.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptPatent.Document
        rptPatent.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

#Region "Link buttons"

    Private Sub btnPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentType.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmPatentPopups
        f.GetRecordset(2)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnFilingBasis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilingBasis.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmPatentPopups
        f.GetRecordset(1)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmGeneralPopups
        f.GetRecordset(4)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJurisdiction.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmGeneralPopups
        f.GetRecordset(5)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompany.Click
        On Error Resume Next
        If Nz(Me.CompanyID.Value, 0) = 0 Then Exit Sub
        SavePatent()
        AllForms.OpenCompanies()
        Globals.CompanyID = Me.CompanyID.Value
        AllForms.frmCompanies.GetCompany()
        AllForms.frmCompanies.Tabs.SelectedIndex = 1

    End Sub

    Private Sub btnFileMatter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileMatter.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmGeneralPopups
        f.GetRecordset(7)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnPublication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPublication.Click
        On Error Resume Next
        SavePatent()
        Dim strSQL As String


        If Nz(Me.JurisdictionID.Value, 0) = 0 Then
            MsgBox("You must select a jurisdiction before using the publication link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strPubNumber As String,
            bUsesFields As Boolean, strFieldName As String

        strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("PatentPublicationURL") & ""

        If strTargetURL = "" Then
            MsgBox("Publication search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("PatentPublicationUsesFields")
        strFieldName = dr("PatentPublicationField")
        strPubNumber = Me.PublicationNumber.Text & ""
        If dr("PatentPublicationNumbersOnly") = True Then strPubNumber = NumbersOnly(strPubNumber)
        strTargetURL = Replace(strTargetURL, "[PublicationNumber]", strPubNumber)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .btnGetNumber.Text = "Get Publication Number"
                .FieldName = strFieldName & ""
                .SearchNumber = strPubNumber & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With
    End Sub

    Private Sub btnApplicationNat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplicationNat.Click
        On Error Resume Next
        SavePatent()
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
        strTargetURL = dr("PatentApplicationURL") & ""

        If strTargetURL = "" Then
            MsgBox("Application search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("PatentApplicationUsesFields")
        strFieldName = dr("PatentApplicationField")
        strAppNumber = Me.ApplicationNumber.Text & ""
        If dr("PatentApplicationNumbersOnly") = True Then strAppNumber = NumbersOnly(strAppNumber)
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

    Private Sub btnApplicationInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplicationInt.Click
        On Error Resume Next
        SavePatent()
        Dim strSQL As String


        If Nz(Me.PatentTypeID.Value, 0) = 0 Then
            MsgBox("You must select a Patent Type before using the international application link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strAppNumber As String,
            bUsesFields As Boolean, strFieldName As String

        strSQL = "Select * from tblPatentTypes where PatentTypeID=" & Me.PatentTypeID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("ApplicationURL") & ""

        If strTargetURL = "" Then
            MsgBox("Application search is not configured or not available for this Patent Type.")
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

    Private Sub btnPatentNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentNumber.Click
        On Error Resume Next
        SavePatent()
        Dim strSQL As String


        If Nz(Me.JurisdictionID.Value, 0) = 0 Then
            MsgBox("You must select a jurisdiction before using the Patent Number link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strPatentNumber As String,
            bUsesFields As Boolean, strFieldName As String

        strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("PatentNumberURL") & ""

        If strTargetURL = "" Then
            MsgBox("Patent Number search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("PatentNumberUsesFields")
        strFieldName = dr("PatentNumberField")
        strPatentNumber = Me.PatentNumber.Text & ""
        If dr("PatentNumberNumbersOnly") = True Then strPatentNumber = NumbersOnly(strPatentNumber)
        strTargetURL = Replace(strTargetURL, "[PatentNumber]", strPatentNumber)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .btnGetNumber.Text = "Get Patent Number"
                .FieldName = strFieldName & ""
                .SearchNumber = strPatentNumber & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With
    End Sub

    Private Sub btnClasses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClasses.Click
        On Error Resume Next
        SavePatent()
        Dim f As New frmPatentPopups
        f.GetRecordset(3)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

#End Region

#Region "Kill The Wheel"

    Private Sub ComboClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.ButtonClick, PatentTypeID.ButtonClick, JurisdictionID.ButtonClick, FilingBasisID.ButtonClick, FileID.ButtonClick, CompanyID.ButtonClick
        ' to prevent the mouse scroll wheel from changing values, drop-downs are ready-only until opened
        On Error Resume Next
        If Globals.SecurityLevel < 3 Then
            Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
            Combo = sender
            Combo.ReadOnly = False
            Combo.DroppedDown = True
        End If
    End Sub

    Private Sub ComboCloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.CloseUp, PatentTypeID.CloseUp, JurisdictionID.CloseUp, FilingBasisID.CloseUp, FileID.CloseUp, CompanyID.CloseUp
        On Error Resume Next
        Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Combo = sender
        Combo.ReadOnly = True
    End Sub

#End Region

#Region "Escape/Undo for TextBoxes"

    Private Sub PatentName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PatentName.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.PatentName.Undo()
    End Sub

    Private Sub OurDocket_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OurDocket.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.OurDocket.Undo()
    End Sub

    Private Sub ClientDocket_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ClientDocket.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.ClientDocket.Undo()
    End Sub

    Private Sub ApplicationNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ApplicationNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.ApplicationNumber.Undo()
    End Sub

    Private Sub Comments_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Comments.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Comments.Undo()
    End Sub

    Private Sub DeptUnit_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DeptUnit.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.DeptUnit.Undo()
    End Sub

    Private Sub PublicationNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PublicationNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.PublicationNumber.Undo()
    End Sub

    Private Sub AppInternational_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AppInternational.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.AppInternational.Undo()
    End Sub

    Private Sub PatentNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PatentNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.PatentNumber.Undo()
    End Sub

    Private Sub Abstract_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Abstract.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Abstract.Undo()
    End Sub

    Private Sub Claims_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Claims.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Claims.Undo()
    End Sub

#End Region

#End Region

#Region "Fill Data Tables / Drop Downs"

    Friend Sub FillDropDowns()
        Try
            Me.JurisdictionID.DataSource = RevaData.tblPatentJurisdictions
            Me.CompanyID.DataSource = RevaData.tblCompaniesList
            Me.grdLicensed.DropDowns("cboCompany").SetDataBinding(RevaData.tblCompaniesList, "")
            Me.grdContacts.DropDowns("cboContact").SetDataBinding(RevaData.tblContactsList, "")
            Me.grdContacts.DropDowns("cboPositions").SetDataBinding(RevaData.tblPatentPositions, "")

            Me.StatusID.DataSource = RevaData.tblPatentStatus
            Me.grdTreatyFilings.DropDowns("cboStatus").SetDataBinding(RevaData.tblPatentStatus, "")

            Me.FilingBasisID.DataSource = RevaData.tblPatentFilingBasis
            Me.grdTreatyFilings.DropDowns("cboFilingBasis").SetDataBinding(RevaData.tblPatentFilingBasis, "")

            Me.PatentTypeID.DataSource = RevaData.tblPatentTypes
            dvTreatyTypes = New DataView(RevaData.tblPatentTypes, "IsTreaty<>0", "PatentType", DataViewRowState.CurrentRows)

            Me.grdClasses.RootTable.Columns("PatentClassID").ValueList.Clear()
            For Each dr As DataRow In RevaData.tblPatentClasses.Rows
                Me.grdClasses.RootTable.Columns("PatentClassID").ValueList.Add(dr("PatentClassID"), dr("PatentClass"))
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetPatentsList()
        On Error Resume Next
        Dim strSQL As String
        strSQL = SQL.vwPatentsList
        dtPatentsList = DataStuff.GetDataTable(strSQL)
        Me.grdList.DataSource = dtPatentsList
        Me.grdList.Row = 0
    End Sub

#End Region

#Region "Fill Grid Subforms"

    Private Sub GetClasses()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "select * from tblPatentClasses where PatentID=" & Globals.PatentID
        rsPatentClasses.GetFromSQL(strSQL)
        Me.grdClasses.DataSource = rsPatentClasses.Table
    End Sub

    Private Sub GetActions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPatentActions where PatentID=" & Globals.PatentID &
            " order by ActionDate, PatentActionID"
        rsActions.GetFromSQL(strSQL)
        grdActions.DataSource = rsActions.Table
    End Sub

    Friend Sub GetContacts()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "SELECT PatentContactID, CompanyID, ContactID, ContactName, ContactCompany as CompanyName, ContactPhone, " &
        "PositionID, PatentID, ContactEmail, WordExcel, PositionName from qvwPatentContacts where PatentID=" & Globals.PatentID
        dtContacts = DataStuff.GetDataTable(strSQL)
        Me.grdContacts.DataSource = dtContacts
    End Sub

    Friend Sub GetMatters()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from qvwClientMattersLinked WHERE CompanyID=" &
            rsPatents.CurrentRow("CompanyID") & " order by FileNumber"
        dtMatters = DataStuff.GetDataTable(strSQL)
        Me.FileID.DataSource = dtMatters
    End Sub

    Friend Sub GetDates()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "SELECT PatentDateID, PatentID, JurisdictionDateID, JurisdictionID, DateID, DateName, PatentDate, " &
        "NoDay, NoMonth, ListOrder, Completed, IsLocked, RecursAtInterval, HasRelatives, DisplayInLinked, IsRelative " &
        "from qvwPatentDates where PatentID=" & Globals.PatentID & " order by ListOrder"
        dtDates = DataStuff.GetDataTable(strSQL)
        Me.grdDates.DataSource = dtDates
    End Sub

    Friend Sub GetDocuments()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPatentDocuments where PatentID=" & Globals.PatentID
        dtDocLinks = DataStuff.GetDataTable(strSQL)
        Me.grdDocumentLinks.DataSource = dtDocLinks
    End Sub

    Friend Sub GetLicensed()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPatentsLicensed where PatentID=" & Globals.PatentID
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
        Me.grdActions.SetValue("PatentID", Globals.PatentID)
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
        Me.grdClasses.SetValue("PatentID", Globals.PatentID)
    End Sub

    Private Sub grdClasses_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdClasses.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this class from the Patent?"
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

        strSQL = "Insert into tblPatentContacts (PatentID, ContactID, PositionID) Select " &
            Globals.PatentID & ", ContactID, PositionID from tblContacts where CompanyID=" & iCompanyID &
                " and PositionID is not null and PositionID in (Select PositionID from tblPositions" &
                " where IsPatent <> 0)"
        DataStuff.RunSQL(strSQL)

        GetContacts()

    End Sub

    Private Sub grdContacts_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "PositionID" Then
            SavePatent()
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
                    strSubject = .CompanyID.Text & " | " & .PatentName.Text & " | " & .JurisdictionID.Text &
                        " | App# " & IIf(.AppInternational.Text & "" <> "", .AppInternational.Text, .ApplicationNumber.Text)
                    If .PatentNumber.Text & "" <> "" Then
                        strSubject = strSubject & " | Pat# " & .PatentNumber.Text
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
            If MsgBox("Are you sure you want to delete this contact from the Patent?",
                MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iPatentContactID As Integer
            iPatentContactID = Me.grdContacts.GetValue("PatentContactID")
            strSQL = "Delete from tblPatentContacts where PatentContactID=" & iPatentContactID
            DataStuff.RunSQL(strSQL)
            GetContacts()
        End If

        If e.Column.Key = "ContactEmail" Then
            Me.Cursor = Cursors.WaitCursor
            Dim OL As Outlook.Application, Email As Outlook.MailItem, strTo As String, strSubject As String

            strTo = Me.grdContacts.GetValue("ContactEmail") & ""
            strSubject = ""
            If strTo <> "" Then
                OL = GetObject(, "Outlook.Application")
                If OL Is Nothing Then
                    OL = CreateObject("Outlook.Application")
                End If
                Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                With Me
                    strSubject = .CompanyID.Text & " | " & .PatentName.Text & " | " & .JurisdictionID.Text &
                        " | App# " & IIf(.AppInternational.Text & "" <> "", .AppInternational.Text, .ApplicationNumber.Text)
                    If .PatentNumber.Text & "" <> "" Then
                        strSubject = strSubject & " | Pat# " & .PatentNumber.Text
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
            SavePatent()
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
            rsContacts.GetFromSQL("Select * from tblPatentContacts where PatentContactID=0")
            dRow = rsContacts.Table.Rows.Add
            dRow("PatentID") = Globals.PatentID
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
                rsContacts.GetFromSQL("Select * from tblPatentContacts where PatentContactID=" &
                    .GetValue("PatentContactID"))
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
                        .InitialDirectory = RevaSettings.PatentDocumentsDemo
                    Else
                        .InitialDirectory = RevaSettings.PatentDocuments
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
                        .SelectedPath = RevaSettings.PatentDocumentsDemo
                    Else
                        .SelectedPath = RevaSettings.PatentDocuments
                    End If
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.grdDocumentLinks.SetValue("DocumentLink", .SelectedPath & "")
                    End If
                End With
            End If

        End If

        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this document link?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iPatentDocID As Integer
            iPatentDocID = Me.grdDocumentLinks.GetValue("PatentDocumentID")
            strSQL = "delete from tblPatentDocuments where PatentDocumentID = " & iPatentDocID
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

        rsRecord.GetFromSQL("Select * from tblPatentDocuments where PatentDocumentID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdDocumentLinks
            dRow("PatentID") = Globals.PatentID
            dRow("DocumentLink") = .GetValue("DocumentLink")
            dRow("DocDescription") = .GetValue("DocDescription")
            dRow("OnExtraNet") = IIf(.GetValue("OnExtraNet") = False, False, True)
            dRow("IsFolder") = IIf(.GetValue("IsFolder") = False, False, True)
        End With
        rsRecord.Update()
    End Sub

    Private Sub grdDocumentLinks_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumentLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iPatentDocID As Integer

        With Me.grdDocumentLinks
            iPatentDocID = .GetValue("PatentDocumentID")
            rsRecord.GetFromSQL("Select * from tblPatentDocuments where PatentDocumentID=" & iPatentDocID)
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
                .InitialDirectory = RevaSettings.PatentGraphicsDemo
            Else
                .InitialDirectory = RevaSettings.PatentGraphics
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

        rsRecord.GetFromSQL("Select * from tblPatentsLicensed where LicensedID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdLicensed
            dRow("PatentID") = Globals.PatentID
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
            rsRecord.GetFromSQL("Select * from tblPatentsLicensed where LicensedID=" & iLicensedID)
            dRow = rsRecord.CurrentRow
            dRow("PatentID") = .GetValue("PatentID")
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
            strSQL = "delete from tblPatentsLicensed where LicensedID = " & iLicensedID
            DataStuff.RunSQL(strSQL)
            GetLicensed()
        End If
    End Sub

#End Region

#Region "Dates Grid / Date Events"

    Private Sub grdDates_ColumnHeaderClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.ColumnHeaderClick
        On Error Resume Next
        'Sorts by Patent Date
        If e.Column.Key = "PatentDate" Then
            Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer

            If Me.chkReOrder.Checked = False Then
                rsRecord.GetFromSQL("Select PatentDateID, PatentDate, ListOrder from tblPatentDates " &
                    "where PatentID=" & Globals.PatentID & " order by PatentDate, ListOrder")
            Else
                rsRecord.GetFromSQL("Select PatentDateID, PatentDate, ListOrder from tblPatentDates " &
                    "where PatentID=" & Globals.PatentID & " order by PatentDate DESC, ListOrder DESC")
            End If

            If RevaSettings.BlankDatesLast = True Then
                Dim iListOrder As Integer
                iListOrder = 1
                'tick up the ones with dates first
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    If IsDate(dRow("PatentDate")) Then
                        dRow("ListOrder") = iListOrder
                    End If
                    iListOrder = iListOrder + 1
                Next i
                'now tick up the ones without dates
                For i = 0 To rsRecord.Table.Rows.Count - 1
                    dRow = rsRecord.Table.Rows(i)
                    If Not IsDate(dRow("PatentDate")) Then
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
        'to allow for dates to be expressed like "Jan 2000" without a day
        If (e.Row.RowType = Janus.Windows.GridEX.RowType.Record) And (e.Row.Cells("NoDay").Value = True) Then
            e.Row.Cells("PatentDate").Text = Format(e.Row.Cells("PatentDate").Value, "MMM yyyy")
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
                SavePatent()
                AllForms.OpenEditPatentDate()
            End If
        End If

        If (e.Column.Key = "lnkDelete") And (Globals.SecurityLevel < 2) Then
            If MsgBox("Are you sure you want to delete this date?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            Else
                Dim iPatentDateID As Integer
                iPatentDateID = Me.grdDates.GetValue("PatentDateID")
                Dim PD As New PatentDates
                With PD
                    .PatentID = Globals.PatentID
                    .LoadPatentDates()
                    .DeleteDate(iPatentDateID)
                    .SaveChanges()
                End With
                PD = Nothing
                GetDates()
            End If

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdDates.GetValue("ListOrder")
            iRow = Me.grdDates.CurrentRow.RowIndex

            If iOrder > 1 Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select PatentDateID, ListOrder from tblPatentDates where PatentID=" &
                    Globals.PatentID)
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
                rsRecord.GetFromSQL("Select PatentDateID, ListOrder from tblPatentDates where PatentID=" &
                    Globals.PatentID)
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
        If (Nz(Me.PatentTypeID.Value, 0) = 0) Or (Nz(Me.JurisdictionID.Value, 0) = 0) Then
            MsgBox("You must select the Jurisdiction and Patent Type before adding dates.")
            Exit Sub
        End If
        SavePatent()
        AllForms.OpenAddPatentDates()
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
        SavePatent()
        Globals.PatentID = Me.grdRelated.GetValue("PatentID")
        GetPatent()
        Me.Tabs.SelectedIndex = 1
        'End If
    End Sub

#End Region

#Region "Merge Panel"

    Private Sub optWord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWord.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optWord.Checked = True Then
            SetMergeOptions()
        End If
    End Sub

    Private Sub optOutlook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOutlook.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optOutlook.Checked = True Then
            SetMergeOptions()
        End If
    End Sub

    Private Sub optDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDate.CheckedChanged
        On Error Resume Next
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

        If (Not (strDocumentName Like "*.doc")) And (Not (strDocumentName Like "*.docx")) Then
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
                .InitialDirectory = RevaSettings.PatentDocumentsDemo
            Else
                .InitialDirectory = RevaSettings.PatentDocuments
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
        SavePatent()
        If Me.optWord.Checked = True Then
            MergeNewWordDoc()
        End If

        If Me.optOutlook.Checked = True Then
            MakeNewEmail()
        End If
    End Sub

    Private Sub btnEditDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDocument.Click
        On Error Resume Next
        SavePatent()
        If Me.optOutlook.Checked = True Then
            EditEmail()
        End If

        If Me.optDate.Checked = True Then
            EditDateEmail()
        End If

    End Sub

    Private Sub btnMergeDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergeDocument.Click
        On Error Resume Next
        SavePatent()
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
                .InitialDirectory = RevaSettings.PatentDocumentsDemo
            Else
                .InitialDirectory = RevaSettings.PatentDocuments
            End If

            .FileName = ""
            .Filter = "Word Documents (*.docx)|*.docx|All Files|*.*"
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


        Dim PM As New PatentMerge
        With PM
            .DocumentName = Me.MergeDocument.Text
            .ContactsFilter = GetContactsFilter()
            .WriteDataFile()
            .CreateNewDocument()
        End With
        PM = Nothing
    End Sub

    Private Sub MergeExistingWordDoc()
        On Error Resume Next

        If IsWordDoc() = False Then
            MsgBox("Cannot open a document without a recognizable Word document name.")
            Exit Sub
        End If

        My.Settings.LastMergeType = 1
        My.Settings.LastMergeWord = Me.MergeDocument.Text


        Dim PM As New PatentMerge
        With PM
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
            .MergeStatus = frmMergeHelper.mStatus.PatentOutlook
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
            .MergeStatus = frmMergeHelper.mStatus.PatentOutlook
            .bNewDocument = False
            .DocumentName = Me.MergeDocument.Text
            .SetOptions()
        End With
    End Sub

    Private Sub EditDateEmail()
        On Error Resume Next
        AllForms.OpenMergeHelper()
        With AllForms.frmMergeHelper
            .MergeStatus = frmMergeHelper.mStatus.PatentJurisDate
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


        Dim OM As New PatentOutlookMerge
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
        strSQL = "Select EmailMessage from tblPatentJurisdictionDates where JurisdictionDateID=" &
            Me.grdDates.GetValue("JurisdictionDateID")
        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        If dr("EmailMessage") & "" = "" Then
            MsgBox("There is no merge text set up for this date.  You can create text by clicking the Edit button.")
            Exit Sub
        End If

        'okay, go for it

        My.Settings.LastMergeType = 4


        Dim OM As New PatentOutlookMerge
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

#Region "Set Options and such"

    Private Sub SetTreatyFilingPage()
        On Error Resume Next

        'user is looking at patents related by treaty

        If Me.optTreaties.Checked = True Then
            GetTreatyPatents()
            ClearConditionalFormatting()
            'may want to link multiple patents from various jurisdictions by treaty
            Me.grdLinkExisting.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        End If

        'user is looking at patents linked by parent/child chain ... provisional becomes full patent,
        'or patent is divided into divisional patents, etc.

        If Me.optLinkedPatents.Checked = True Then
            GetLinkedPatents()
            ApplyConditionalFormatting()
            'only create one child patent at a time
            Me.grdLinkExisting.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection
        End If

        GetTreatyJurisdictions()
        GetTreatyFilings()

    End Sub

    Private Sub ShowTreatyGrids()
        On Error Resume Next
        With Me
            .grdLinkExisting.Visible = .chkLinkExisting.Checked = True
            .grdJurisdictions.Visible = (.chkLinkExisting.Checked = False) And (.optTreaties.Checked = True)
            .grdTreatyFilings.Visible = (.optTreaties.Checked = True) Or (.chkLinkExisting.Checked = False)
            .chkSameOwner.Visible = .chkLinkExisting.Checked = True
        End With

    End Sub

    Private Sub optTreaties_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTreaties.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optTreaties.Checked = True Then
            SetTreatyFilingPage()
            ShowTreatyGrids()
        End If
    End Sub

    Private Sub optLinkedPatents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLinkedPatents.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        If optLinkedPatents.Checked = True Then
            SetTreatyFilingPage()
            ShowTreatyGrids()
        End If
    End Sub

    Private Sub chkLinkExisting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLinkExisting.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        ShowTreatyGrids()
        GetLinkList()
    End Sub

    Private Sub chkSameOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSameOwner.CheckedChanged
        On Error Resume Next
        If bFormLoaded = False Then Exit Sub
        GetLinkList()
    End Sub

    Private Sub SetTreatyButtons()
        On Error Resume Next
        With Me

            If .chkLinkExisting.Checked = True Then
                .btnAddTreatyFiling.Enabled = (.grdLinkExisting.SelectedItems.Count > 0) _
                And (Globals.SecurityLevel < 3) And (.grdTreatyFilings.SelectedItems.Count > 0)
            Else
                .btnAddTreatyFiling.Enabled = (.grdTreatyFilings.SelectedItems.Count = 1) _
                    And ((.grdJurisdictions.SelectedItems.Count > 0) Or (.optLinkedPatents.Checked = True)) _
                    And (Globals.SecurityLevel < 3)
            End If

            .btnRemoveTreatyFiling.Enabled = (.grdLinked.SelectedItems.Count > 0) And
                (Globals.SecurityLevel = 1) And (.grdLinked.GetValue("PatentID") <> Globals.PatentID)

        End With

    End Sub

    Private Sub ClearConditionalFormatting()
        On Error Resume Next
        With Me.grdLinked
            .Tables("Patent01").FormatConditions.Clear()
            .Tables("Patent02").FormatConditions.Clear()
            .Tables("Patent03").FormatConditions.Clear()
            .Tables("Patent04").FormatConditions.Clear()
            .Tables("Patent05").FormatConditions.Clear()
        End With
    End Sub

    Private Sub ApplyConditionalFormatting()
        On Error Resume Next

        ClearConditionalFormatting()

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition, PatentID As Integer
        PatentID = Globals.PatentID


        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdLinked.Tables("Patent01").Columns("PatentID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdLinked.Tables("Patent01").FormatConditions.Add(fc)

        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdLinked.Tables("Patent02").Columns("PatentID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdLinked.Tables("Patent02").FormatConditions.Add(fc)

        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdLinked.Tables("Patent03").Columns("PatentID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdLinked.Tables("Patent03").FormatConditions.Add(fc)

        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdLinked.Tables("Patent04").Columns("PatentID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdLinked.Tables("Patent04").FormatConditions.Add(fc)

        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdLinked.Tables("Patent05").Columns("PatentID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, PatentID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdLinked.Tables("Patent05").FormatConditions.Add(fc)



    End Sub

#End Region

#Region "Populate/Fill the Grids"

    Private Sub GetTreatyFilings()
        On Error Resume Next
        Dim strSQL As String
        If Me.optTreaties.Checked = True Then
            strSQL = "Select * from tblPatentTreatyFilings where PatentID=" & Globals.PatentID &
                " and IsTreaty <> 0 order by FilingDate"
            With Me.grdTreatyFilings
                .RootTable.Columns("PatentTypeID").Position = 2
                .RootTable.Columns("FilingBasisID").Position = 3
                .DataSource = DataStuff.GetDataTable(strSQL)
                .DropDowns("cboPatentType").SetDataBinding(dvTreatyTypes, "")
            End With
        End If

        If Me.optLinkedPatents.Checked = True Then
            'we treat Linked Patent records as treaty filings; there's just no treaty
            strSQL = "Select * from tblPatentTreatyFilings where PatentID=" & Globals.PatentID &
                 " and IsTreaty = 0 order by FilingDate"
            With Me.grdTreatyFilings
                .RootTable.Columns("FilingBasisID").Position = 2
                .RootTable.Columns("PatentTypeID").Position = 3
                .DataSource = DataStuff.GetDataTable(strSQL)
                .DropDowns("cboPatentType").SetDataBinding(RevaData.tblPatentTypes, "")
            End With
        End If

    End Sub

    Private Sub GetJurisdictionDates()
        On Error Resume Next
        Dim strSQL As String, dtJurisdictionDates As DataTable, iPatentTypeID As Integer
        iPatentTypeID = Me.grdTreatyFilings.GetValue("PatentTypeID")
        strSQL = "select JurisdictionDateID, DateID, DateName from qvwPatentJurisdictionDates where JurisdictionID=" &
            Me.JurisdictionID.Value & " and PatentTypeID=" & iPatentTypeID & " order by ListOrder"
        dtJurisdictionDates = DataStuff.GetDataTable(strSQL)
        Me.grdTreatyFilings.DropDowns("cboJurisdictionDate").SetDataBinding(dtJurisdictionDates, "")
    End Sub

    Private Sub GetTreatyJurisdictions()
        On Error Resume Next
        Dim strSQL As String, dtTreatyJurisdictions As DataTable, iPatentTypeID As Integer
        iPatentTypeID = Me.grdTreatyFilings.GetValue("PatentTypeID")
        strSQL = "select * from qvwPatentTreatyJurisdictions where PatentTypeID=" & iPatentTypeID &
            " and IsParticipant <> 0 order by Jurisdiction"
        dtTreatyJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.grdJurisdictions.DataSource = dtTreatyJurisdictions
    End Sub

    Private Sub GetLinkedPatents()
        On Error Resume Next
        Dim TopPatentID As Integer, PatentID As Integer, strSQL As String

        TopPatentID = GetTopPatentID()
        strSQL = "Select PatentID, ApplicationNumber, FilingBasis, Jurisdiction from " &
            "qvwPatents where PatentID=" & TopPatentID

        Me.grdLinked.DataSource = DataStuff.GetDataTable(strSQL)
        Me.grdLinked.ExpandRecords()
        Me.grdLinked.Tables("Patent01").Columns("FilingBasis").Visible = True
        Me.grdLinked.Tables("Patent01").Columns("ShowPatentType").Visible = False

    End Sub

    Private Sub GetLinkList()
        On Error Resume Next
        If Me.chkLinkExisting.Checked = False Then Exit Sub

        Dim drPatents As DataView
        If Me.chkSameOwner.Checked = False Then
            drPatents = New DataView(dtPatentsList, "PatentID<>0", "PatentName", DataViewRowState.CurrentRows)
        Else
            drPatents = New DataView(dtPatentsList, "CompanyID=" & Me.CompanyID.Value, "PatentName", DataViewRowState.CurrentRows)
        End If
        Me.grdLinkExisting.DataSource = drPatents

    End Sub

    Private Function GetTopPatentID() As Integer
        On Error Resume Next
        'if this patent is part of a chain of linked patents, find the top of the chain
        Dim dtPatents As DataTable, dRow As DataRow, TopPatentID As Integer, i As Integer
        dtPatents = DataStuff.GetDataTable("Select PatentID, ParentPatentID from tblPatents")
        dRow = dtPatents.Select("PatentID=" & Globals.PatentID)(0)
        TopPatentID = Globals.PatentID
        For i = 1 To 5
            If Nz(dRow("ParentPatentID"), 0) <> 0 Then
                TopPatentID = dRow("ParentPatentID")
                dRow = dtPatents.Select("PatentID=" & TopPatentID)(0)
            End If
        Next
        GetTopPatentID = TopPatentID
    End Function

    Private Sub GetTreatyPatents()
        On Error Resume Next
        Dim strSQL As String, dtTreatyPatents As DataTable

        'other Patents for which this patent is basis
        strSQL = "select * from qvwPatentTreatyFilings where BasisPatentID=" & Globals.PatentID

        'this Patent if it's the basis for a treaty filing
        strSQL = strSQL & " UNION select * from qvwPatentBasisFilings where BasisPatentID=" & Globals.PatentID

        'other patent filed on same treaty filing as this patent
        strSQL = strSQL & " UNION select * from qvwPatentTreatyFilings where TreatyFilingID=" & Globals.TreatyFilingID

        'basis patent used for treaty filing for this Patent
        strSQL = strSQL & " UNION select * from qvwPatentBasisFilings where TreatyFilingID=" & Globals.TreatyFilingID


        dtTreatyPatents = DataStuff.GetDataTable(strSQL)
        Me.grdLinked.DataSource = dtTreatyPatents
        Me.grdRelated.DataSource = dtTreatyPatents
        Me.grdLinked.Tables("Patent01").Columns("FilingBasis").Visible = False
        Me.grdLinked.Tables("Patent01").Columns("ShowPatentType").Visible = True

    End Sub

#End Region

#Region "Grid Events"

    Private Sub grdLinked_GetChildList(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.GetChildListEventArgs) Handles grdLinked.GetChildList
        On Error Resume Next
        Dim PatentID As Integer, strSQL As String
        PatentID = e.ParentRow.Cells("PatentID").Value

        If Me.optTreaties.Checked = True Then
            If e.ChildTable.Key = "Dates01" Then
                strSQL = "Select distinct PatentDateID, PatentDate, DateName, Completed from qvwPatentDates " &
                " where PatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If
        End If

        If Me.optLinkedPatents.Checked = True Then
            'linked patents display a slew of possible child tables
            If e.ChildTable.Key = "Patent02" Then
                strSQL = "Select distinct PatentID, ApplicationNumber, FilingBasis, Jurisdiction" &
                    " from qvwPatents where ParentPatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Dates02" Then
                strSQL = "Select distinct PatentDateID, PatentDate, DateName, Completed from qvwPatentDates " &
                    " where DisplayInLinked <> 0 and PatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Patent03" Then
                strSQL = "Select distinct PatentID, ApplicationNumber, FilingBasis, Jurisdiction" &
                       " from qvwPatents where ParentPatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Dates03" Then
                strSQL = "Select distinct PatentDateID, PatentDate, DateName, Completed from qvwPatentDates " &
                    " where DisplayInLinked <> 0 and PatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Patent04" Then
                strSQL = "Select distinct PatentID, ApplicationNumber, FilingBasis, Jurisdiction" &
                      " from qvwPatents where ParentPatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Dates04" Then
                strSQL = "Select distinct PatentDateID, PatentDate, DateName, Completed from qvwPatentDates " &
                    " where DisplayInLinked <> 0 and PatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Patent05" Then
                strSQL = "Select distinct PatentID, ApplicationNumber, FilingBasis, Jurisdiction" &
                    " from qvwPatents where ParentPatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If

            If e.ChildTable.Key = "Dates05" Then
                strSQL = "Select distinct PatentDateID, PatentDate, DateName, Completed from qvwPatentDates " &
                    " where DisplayInLinked <> 0 and PatentID=" & PatentID
                e.ChildList = DataStuff.GetDataTable(strSQL)
            End If
        End If

    End Sub

    Private Sub grdLinked_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdLinked.LinkClicked
        On Error Resume Next
        Globals.PatentID = Me.grdLinked.GetValue("PatentID")
        GetPatent()
        Me.Tabs.SelectedIndex = 1
    End Sub

    Private Sub grdLinked_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLinked.SelectionChanged
        On Error Resume Next
        SetTreatyButtons()
    End Sub

    Private Sub grdTreatyFilings_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTreatyFilings.CellValueChanged
        On Error Resume Next
        If e.Column.Key = "PatentTypeID" Then
            GetTreatyJurisdictions()
            GetJurisdictionDates()
        End If
    End Sub

    Private Sub grdTreatyFilings_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.RecordAdded
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iRow As Integer

        iRow = Me.grdTreatyFilings.Row
        rsRecord.GetFromSQL("Select * from tblPatentTreatyFilings where TreatyFilingID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdTreatyFilings
            dRow("PatentID") = Globals.PatentID
            dRow("FilingBasisID") = .GetValue("FilingBasisID")
            dRow("PatentTypeID") = .GetValue("PatentTypeID")
            dRow("PatentID") = Globals.PatentID
            dRow("ApplicationNumber") = .GetValue("ApplicationNumber")
            dRow("FilingDate") = .GetValue("FilingDate")
            dRow("CopyClasses") = IIf(.GetValue("CopyClasses") = True, True, False)
            dRow("CopyClaims") = IIf(.GetValue("CopyClaims") = True, True, False)
            dRow("CopyAbstract") = IIf(.GetValue("CopyAbstract") = True, True, False)
            dRow("CopyContacts") = IIf(.GetValue("CopyContacts") = True, True, False)
            dRow("DateID") = .GetValue("DateID")
            dRow("StatusID") = .GetValue("StatusID")
            dRow("IsTreaty") = IIf(Me.optTreaties.Checked = True, True, False)
        End With

        rsRecord.Update()
        GetTreatyFilings()
        Me.grdTreatyFilings.Row = iRow

        If Me.optTreaties.Checked = True Then
            GetTreatyPatents()
        End If

    End Sub

    Private Sub grdTreatyFilings_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iTreatyFilingID As Integer

        With Me.grdTreatyFilings
            iTreatyFilingID = .GetValue("TreatyFilingID")
            rsRecord.GetFromSQL("Select * from tblPatentTreatyFilings where TreatyFilingID=" & iTreatyFilingID)
            dRow = rsRecord.CurrentRow
            dRow("FilingBasisID") = .GetValue("FilingBasisID")
            dRow("PatentTypeID") = .GetValue("PatentTypeID")
            dRow("ApplicationNumber") = .GetValue("ApplicationNumber")
            dRow("FilingDate") = .GetValue("FilingDate")
            dRow("CopyClasses") = IIf(.GetValue("CopyClasses") = True, True, False)
            dRow("CopyClaims") = IIf(.GetValue("CopyClaims") = True, True, False)
            dRow("CopyAbstract") = IIf(.GetValue("CopyAbstract") = True, True, False)
            dRow("CopyContacts") = IIf(.GetValue("CopyContacts") = True, True, False)
            dRow("DateID") = .GetValue("DateID")
            dRow("StatusID") = .GetValue("StatusID")
        End With

        rsRecord.Update()
    End Sub

    Private Sub grdTreatyFilings_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTreatyFilings.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strSQL As String, iTreatyFilingID As Integer
            iTreatyFilingID = Me.grdTreatyFilings.GetValue("TreatyFilingID")

            If DataStuff.DCount("PatentID", "tblPatents", "TreatyFilingID=" & iTreatyFilingID) > 0 Then
                MsgBox("You cannot delete a treaty filing that's linked to existing Patents.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Treaty Filing?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblPatentTreatyFilings where TreatyFilingID = " & iTreatyFilingID
            DataStuff.RunSQL(strSQL)
            GetTreatyJurisdictions()
            GetTreatyFilings()
        End If
    End Sub

    Private Sub grdTreatyFilings_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTreatyFilings.SelectionChanged
        On Error Resume Next
        GetTreatyJurisdictions()
        GetJurisdictionDates()
        SetTreatyButtons()
    End Sub

    Private Sub grdLinkExisting_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLinkExisting.SelectionChanged
        On Error Resume Next
        SetTreatyButtons()
    End Sub

    Private Sub grdJurisdictions_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdJurisdictions.SelectionChanged
        On Error Resume Next
        SetTreatyButtons()
    End Sub

#End Region

#Region "Link and Unlink Patents"

    Private Sub btnRemoveTreatyFiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTreatyFiling.Click
        On Error Resume Next
        Dim iPatentID As Integer, strMessage As String, strSQL As String
        iPatentID = Me.grdLinked.GetValue("PatentID")

        If Me.optTreaties.Checked = True Then
            strMessage = "This will not delete the patent.  This will unlink the selected patent " &
            "from the treaty filing.  Proceed?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "update tblPatents set TreatyFilingID=null where PatentID=" & iPatentID
            DataStuff.RunSQL(strSQL)
            GetTreatyPatents()
            'GetPatentsList()
            RefreshBrowse()
            MsgBox("The patent has been unlinked.  You may need to change the patent type and dates.")
            SetTreatyButtons()
        End If

        If Me.optLinkedPatents.Checked = True Then
            strMessage = "This will not delete the patent.  This will unlink the selected patent " &
                "from the its parent patent.  Proceed?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "update tblPatents set ParentPatentID=null where PatentID=" & iPatentID
            DataStuff.RunSQL(strSQL)
            GetLinkedPatents()
            MsgBox("The patent has been unlinked.  You may need to change the filing basis.")
            SetTreatyButtons()
        End If

    End Sub

    Private Sub btnAddTreatyFiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTreatyFiling.Click
        On Error Resume Next

        If Me.optTreaties.Checked = True Then
            If Me.chkLinkExisting.Checked = True Then
                LinkTreatyPatents()
            Else
                NewTreatyPatents()
            End If
        End If

        If Me.optLinkedPatents.Checked = True Then
            If Me.chkLinkExisting.Checked = True Then
                LinkChildPatent()
            Else
                NewChildPatent()
            End If
        End If

    End Sub

    Private Sub LinkTreatyPatents()
        On Error Resume Next
        Dim iPatentID As Integer, iJurisdictionID As Integer, GRow As Janus.Windows.GridEX.GridEXRow,
            strFilter As String, i As Integer, iTreatyFilingID As Integer

        If Me.grdLinkExisting.SelectedItems.Count < 1 Then
            MsgBox("You must select the patents to link first.")
            Exit Sub
        End If

        iTreatyFilingID = Me.grdTreatyFilings.GetValue("TreatyFilingID")

        strFilter = " where PatentID in ("
        For i = 0 To Me.grdLinkExisting.SelectedItems.Count - 1
            GRow = Me.grdLinkExisting.SelectedItems(i).GetRow
            iPatentID = GRow.Cells("PatentID").Value
            strFilter = strFilter & iPatentID & ","
        Next i
        strFilter = strFilter & "0)"

        DataStuff.RunSQL("update tblPatents set TreatyFilingID=" & iTreatyFilingID & strFilter)
        'GetPatentsList()
        RefreshBrowse()
        GetTreatyPatents()

        MsgBox("Existing patents are now linked.  Linking does not affect the dates for the linked patents.")

    End Sub

    Private Sub LinkChildPatent()
        On Error Resume Next
        Dim iPatentID As Integer, iParentPatentID As Integer

        If Me.grdLinkExisting.SelectedItems.Count < 1 Then
            MsgBox("You must select the patent to link first.")
            Exit Sub
        End If

        If Me.grdLinked.SelectedItems.Count < 1 Then
            MsgBox("You must select a target patent.")
            Exit Sub
        End If

        iPatentID = Me.grdLinkExisting.GetValue("PatentID")
        iParentPatentID = Me.grdLinked.GetValue("PatentID")

        DataStuff.RunSQL("update tblPatents set ParentPatentID=" & iParentPatentID &
            " where PatentID=" & iPatentID)

        GetLinkedPatents()
        MsgBox("Existing patents are now linked.  Linking does not affect the dates for the linked patents.")

    End Sub

    Private Sub NewTreatyPatents()
        On Error Resume Next
        Dim iPatentID As Integer, iJurisdictionID As Integer, GRow As Janus.Windows.GridEX.GridEXRow,
            strFilter As String, iPatentTypeID As Integer, i As Integer, iTreatyFilingID As Integer

        iTreatyFilingID = Me.grdTreatyFilings.GetValue("TreatyFilingID")
        iPatentTypeID = Me.grdTreatyFilings.GetValue("PatentTypeID")

        'don't bother if nothing is selected
        If Me.grdJurisdictions.SelectedItems.Count < 1 Then
            MsgBox("You must select the Jurisdictions in which to file first.")
            Exit Sub
        End If

        Dim rsPatents As New RecordSet, dPatentRow As DataRow,
            dPatentRows As DataRow(), iStatusID As Integer, NewPatentID As Integer,
            dtTempPatents As New DataTable, dTempRow As DataRow, j As Integer,
            iDateID As Integer, PatentDate As Date

        'we're using a temporary table to avoid having to open and close the Patents table several times
        dtTempPatents.Columns.Add("JurisdictionID", GetType(System.Int32))
        dtTempPatents.Columns.Add("TreatyFilingID", GetType(System.Int32))
        dtTempPatents.Columns.Add("PatentID", GetType(System.Int32))


        iStatusID = Nz(Me.grdTreatyFilings.GetValue("StatusID"), 0)
        iDateID = Nz(Me.grdTreatyFilings.GetValue("DateID"), 0)

        If IsDate(Me.grdTreatyFilings.GetValue("FilingDate")) Then
            PatentDate = Me.grdTreatyFilings.GetValue("FilingDate")
        Else
            PatentDate = Date.MinValue
        End If


        For i = 0 To Me.grdJurisdictions.SelectedItems.Count - 1
            GRow = Me.grdJurisdictions.SelectedItems(i).GetRow
            iJurisdictionID = GRow.Cells("JurisdictionID").Value

            'make sure we haven't already filed in this jurisdiction using this treaty filing
            strFilter = "JurisdictionID=" & iJurisdictionID & " and TreatyFilingID=" & iTreatyFilingID

            'rather than open a new datatable just for lookups, we're going to leverage
            'the Patents list, which is already open and populated
            dPatentRows = dtPatentsList.Select(strFilter)
            If dPatentRows.Length = 0 Then  'no match found, proceed
                dtTempPatents.Rows.Add()
                dTempRow = dtTempPatents.Rows(dtTempPatents.Rows.Count - 1)
                dTempRow("JurisdictionID") = iJurisdictionID
                dTempRow("TreatyFilingID") = iTreatyFilingID
                dTempRow("PatentID") = 0
            End If
        Next i

        rsPatents.GetFromSQL("Select * from tblPatents where PatentID=0")

        For i = 0 To dtTempPatents.Rows.Count - 1
            With Me
                rsPatents.AddRow()
                dPatentRow = rsPatents.CurrentRow
                dPatentRow("PatentName") = .PatentName.Text & ""
                dPatentRow("GraphicPath") = .GraphicPath.Text & ""
                dPatentRow("GraphicSizeToFit") = IIf(.GraphicSizeToFit.Checked = True, True, False)
                dPatentRow("NonPublication") = False
                dPatentRow("FastTrack") = False
                dPatentRow("FileID") = .FileID.Value
                dPatentRow("FilingBasisID") = .grdTreatyFilings.GetValue("FilingBasisID")
                dPatentRow("CompanyID") = .CompanyID.Value
                dPatentRow("JurisdictionID") = dtTempPatents.Rows(i).Item("JurisdictionID")
                dPatentRow("PatentTypeID") = iPatentTypeID
                dPatentRow("TreatyFilingID") = iTreatyFilingID
                dPatentRow("AppInternational") = .grdTreatyFilings.GetValue("ApplicationNumber") & ""

                If .grdTreatyFilings.GetValue("CopyAbstract") = True Then
                    dPatentRow("Abstract") = .Abstract.Text & ""
                End If

                If .grdTreatyFilings.GetValue("CopyClaims") = True Then
                    dPatentRow("Claims") = .Claims.Text & ""
                End If

                If Nz(.grdTreatyFilings.GetValue("StatusID"), 0) <> 0 Then
                    dPatentRow("StatusID") = .grdTreatyFilings.GetValue("StatusID")
                End If

            End With
        Next i

        'update the Patents recordset and requery our Patents list, then get new PatentIDs
        rsPatents.Update()
        GetPatentsList()

        For i = 0 To dtTempPatents.Rows.Count - 1
            dTempRow = dtTempPatents.Rows(i)
            strFilter = "JurisdictionID=" & dTempRow("JurisdictionID") & " and TreatyFilingID=" & iTreatyFilingID
            dPatentRows = dtPatentsList.Select(strFilter)
            If dPatentRows.Length <> 0 Then
                dPatentRow = dPatentRows(0)  'there's only one jurisdiction filing per treaty filing
                dTempRow("PatentID") = dPatentRow("PatentID")
            End If
        Next

        'now we have real PatentIDs to work with and can add the dates, contacts, etc.
        If Me.grdTreatyFilings.GetValue("CopyContacts") = True Then
            Dim rsContacts As New RecordSet
            rsContacts.GetFromSQL("Select * from tblPatentContacts where PatentID=0")
            For i = 0 To dtTempPatents.Rows.Count - 1
                dTempRow = dtTempPatents.Rows(i)
                NewPatentID = dTempRow("PatentID")
                For j = 0 To Me.grdContacts.RowCount - 1
                    GRow = Me.grdContacts.GetRow(j)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        rsContacts.AddRow()
                        rsContacts.CurrentRow("PatentID") = NewPatentID
                        rsContacts.CurrentRow("ContactID") = GRow.Cells("ContactID").Value
                        rsContacts.CurrentRow("PositionID") = GRow.Cells("PositionID").Value
                    End If
                Next j
            Next i
            rsContacts.Update()
        End If

        If Me.grdTreatyFilings.GetValue("CopyClasses") = True Then
            Dim rsPatentClasses As New RecordSet
            rsPatentClasses.GetFromSQL("Select * from tblPatentClasses where PatentID=0")
            For i = 0 To dtTempPatents.Rows.Count - 1
                dTempRow = dtTempPatents.Rows(i)
                NewPatentID = dTempRow("PatentID")
                For j = 0 To Me.grdClasses.RowCount - 1
                    GRow = Me.grdClasses.GetRow(j)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        rsPatentClasses.AddRow()
                        rsPatentClasses.CurrentRow("PatentID") = NewPatentID
                        rsPatentClasses.CurrentRow("PatentClassID") = GRow.Cells("PatentClassID").Value
                    End If
                Next j
            Next i
            rsPatentClasses.Update()
        End If

        If (iDateID <> 0) And (PatentDate <> Date.MinValue) Then
            Dim PD As New PatentDates

            With PD
                For i = 0 To dtTempPatents.Rows.Count - 1
                    dTempRow = dtTempPatents.Rows(i)
                    NewPatentID = dTempRow("PatentID")
                    .PatentID = NewPatentID
                    .JurisdictionID = dTempRow("JurisdictionID")
                    .PatentTypeID = iPatentTypeID
                    .LoadJurisdictionDates()
                    .LoadPatentDates()

                    If (iDateID <> 0) And (PatentDate <> Date.MinValue) Then
                        .AddDate(iDateID, 0, PatentDate, False, False, True, False)
                    End If

                    .AppendPatentTypeDates(iPatentTypeID)

                    If iStatusID <> 0 Then
                        .AppendStatusDates(iStatusID)
                    End If

                    .UpdateRecurNumbers()
                    .ReOrderPatentDates()
                    .SaveChanges()
                Next i
            End With
            PD = Nothing
        End If

        GetTreatyPatents()
        SetTreatyButtons()

    End Sub

    Private Sub NewChildPatent()
        On Error Resume Next
        Dim GRow As Janus.Windows.GridEX.GridEXRow, iPatentTypeID As Integer, rsPatents As New RecordSet,
             dPatentRow As DataRow, iStatusID As Integer, NewPatentID As Integer,
               j As Integer, iDateID As Integer, PatentDate As Date

        iPatentTypeID = Me.grdTreatyFilings.GetValue("PatentTypeID")
        iStatusID = Nz(Me.grdTreatyFilings.GetValue("StatusID"), 0)
        iDateID = Nz(Me.grdTreatyFilings.GetValue("DateID"), 0)

        If IsDate(Me.grdTreatyFilings.GetValue("FilingDate")) Then
            PatentDate = Me.grdTreatyFilings.GetValue("FilingDate")
        Else
            PatentDate = Date.MinValue
        End If

        rsPatents.GetFromSQL("Select * from tblPatents where PatentID=0")

        With Me
            rsPatents.AddRow()
            dPatentRow = rsPatents.CurrentRow
            dPatentRow("PatentName") = .PatentName.Text & ""
            dPatentRow("GraphicPath") = .GraphicPath.Text & ""
            dPatentRow("GraphicSizeToFit") = IIf(.GraphicSizeToFit.Checked = True, True, False)
            dPatentRow("NonPublication") = False
            dPatentRow("FastTrack") = False
            dPatentRow("FileID") = .FileID.Value
            dPatentRow("FilingBasisID") = .grdTreatyFilings.GetValue("FilingBasisID")
            dPatentRow("CompanyID") = .CompanyID.Value
            dPatentRow("JurisdictionID") = Me.JurisdictionID.Value
            dPatentRow("PatentTypeID") = iPatentTypeID
            dPatentRow("ParentPatentID") = Globals.PatentID
            dPatentRow("ApplicationNumber") = .grdTreatyFilings.GetValue("ApplicationNumber") & ""

            If .grdTreatyFilings.GetValue("CopyAbstract") = True Then
                dPatentRow("Abstract") = .Abstract.Text & ""
            End If

            If .grdTreatyFilings.GetValue("CopyClaims") = True Then
                dPatentRow("Claims") = .Claims.Text & ""
            End If

            If Nz(.grdTreatyFilings.GetValue("StatusID"), 0) <> 0 Then
                dPatentRow("StatusID") = .grdTreatyFilings.GetValue("StatusID")
            End If

        End With

        'update the Patents recordset and requery our Patents list, then get new PatentIDs
        rsPatents.Update()
        NewPatentID = DataStuff.DMax("PatentID", "tblPatents", "ParentPatentID=" & Globals.PatentID)
        GetPatentsList()

        'now we have real PatentIDs to work with and can add the dates, contacts, etc.
        If Me.grdTreatyFilings.GetValue("CopyContacts") = True Then
            Dim rsContacts As New RecordSet
            rsContacts.GetFromSQL("Select * from tblPatentContacts where PatentID=0")
            For j = 0 To Me.grdContacts.RowCount - 1
                GRow = Me.grdContacts.GetRow(j)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    rsContacts.AddRow()
                    rsContacts.CurrentRow("PatentID") = NewPatentID
                    rsContacts.CurrentRow("ContactID") = GRow.Cells("ContactID").Value
                    rsContacts.CurrentRow("PositionID") = GRow.Cells("PositionID").Value
                End If
            Next j
            rsContacts.Update()
        End If

        If Me.grdTreatyFilings.GetValue("CopyClasses") = True Then
            Dim rsPatentClasses As New RecordSet
            rsPatentClasses.GetFromSQL("Select * from tblPatentClasses where PatentID=0")
            For j = 0 To Me.grdClasses.RowCount - 1
                GRow = Me.grdClasses.GetRow(j)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    rsPatentClasses.AddRow()
                    rsPatentClasses.CurrentRow("PatentID") = NewPatentID
                    rsPatentClasses.CurrentRow("PatentClassID") = GRow.Cells("PatentClassID").Value
                End If
            Next j
            rsPatentClasses.Update()
        End If

        If (iDateID <> 0) And (PatentDate <> Date.MinValue) Then
            Dim PD As New PatentDates

            With PD
                .PatentID = NewPatentID
                .JurisdictionID = Me.JurisdictionID.Value
                .PatentTypeID = iPatentTypeID
                .LoadJurisdictionDates()
                .LoadPatentDates()

                If (iDateID <> 0) And (PatentDate <> Date.MinValue) Then
                    .AddDate(iDateID, 0, PatentDate, False, False, True, False)
                End If

                .AppendPatentTypeDates(iPatentTypeID)

                If iStatusID <> 0 Then
                    .AppendStatusDates(iStatusID)
                End If

                .UpdateRecurNumbers()
                .ReOrderPatentDates()
                .SaveChanges()
            End With
            PD = Nothing
        End If

        GetLinkedPatents()
        SetTreatyButtons()

    End Sub

#End Region

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