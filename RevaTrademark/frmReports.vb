Imports System.Data.OleDb
Imports System.Data


Public Class frmReports

    Private rsMarkReports As New RecordSet
    Private rsPatentReports As New RecordSet
    Private dtMarkPositions As DataTable
    Private dtPatentPositions As DataTable
    Private dtTrademarkStatus As DataTable
    Private dtMarkFilters As DataTable
    Private dtPatentFilters As DataTable
    Private dtPatentStatus As DataTable
    Private dtMarkDates As DataTable
    Private dtPatentDates As DataTable
    Private bSpreadsheetChanged As Boolean
    'for the preview grids
    Private dtMarks As DataTable
    Private dtPatents As DataTable


#Region "Toolbar Buttons"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        If MsgBox("Are you sure want to exit RevaTrademark?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            
            Application.Exit()
        End If
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        AllForms.OpenLogin()
    End Sub

    Private Sub btnGoTrademarks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoTrademarks.Click
        On Error Resume Next
        AllForms.OpenTrademarks()
        Me.Close()
    End Sub

    Private Sub btnGoToPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToPatents.Click
        On Error Resume Next
        AllForms.OpenPatents()
        Me.Close()
    End Sub

    Private Sub btnGoToOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToOppositions.Click
        On Error Resume Next
        AllForms.OpenOppositions()
        Me.Close()
    End Sub

    Private Sub btnGoToContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToContacts.Click
        On Error Resume Next
        AllForms.OpenCompanies()
        Me.Close()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click

    End Sub

    Private Sub btnPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreferences.Click
        On Error Resume Next
        AllForms.OpenPreferences()
        Me.Close()
    End Sub

#End Region

#Region "Form - General Properties/Events"

    Private Sub frmReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmReports = Me
        bSpreadsheetChanged = False

        rsMarkReports.GetFromDemo("Select * from tblReports where IsTrademark <> 0 order by ReportID")
        rsPatentReports.GetFromDemo("Select * from tblReports where IsTrademark = 0 order by ReportID")

        dtMarkPositions = DataStuff.GetDataTable("Select * from tblPositions where IsTrademark <> 0")
        dtPatentPositions = DataStuff.GetDataTable("Select * from tblPositions where IsPatent <> 0")

        dtMarkDates = DataStuff.GetDataTable("Select * from tblDatesTemplate order by ListOrder")
        dtPatentDates = DataStuff.GetDataTable("Select * from tblPatentDatesTemplate order by ListOrder")

        With Me
            .grdMarkDates.DataSource = dtMarkDates
            SetMarkDateCompleted(2)
            SetSelected(.grdMarkDates, True)

            If RevaSettings.USADates = True Then
                .grdMarkDates.RootTable.Columns("DateFrom").FormatString = "MMM dd, yyyy"
                .grdMarkDates.RootTable.Columns("DateTo").FormatString = "MMM dd, yyyy"
                .grdMarks.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                .grdPatentDates.RootTable.Columns("DateFrom").FormatString = "MMM dd, yyyy"
                .grdPatentDates.RootTable.Columns("DateTo").FormatString = "MMM dd, yyyy"
                .MarkAlertsTo.CustomFormat = "MMM dd, yyyy"
                .MarkAlertsFrom.CustomFormat = "MMM dd, yyyy"
                .PatentAlertsFrom.CustomFormat = "MMM dd, yyyy"
                .PatentAlertsTo.CustomFormat = "MMM dd, yyyy"
            Else
                .grdMarkDates.RootTable.Columns("DateFrom").FormatString = "dd MMM yyyy"
                .grdMarkDates.RootTable.Columns("DateTo").FormatString = "dd MMM yyyy"
                .grdMarks.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                .grdPatentDates.RootTable.Columns("DateFrom").FormatString = "dd MMM yyyy"
                .grdPatentDates.RootTable.Columns("DateTo").FormatString = "dd MMM yyyy"
                .MarkAlertsTo.CustomFormat = "dd MMM yyyy"
                .MarkAlertsFrom.CustomFormat = "dd MMM yyyy"
                .PatentAlertsFrom.CustomFormat = "dd MMM yyyy"
                .PatentAlertsTo.CustomFormat = "dd MMM yyyy"
            End If

            .grdPatentDates.DataSource = dtPatentDates
            SetPatentDateCompleted(2)
            SetSelected(.grdPatentDates, True)

            .grdMarkReports.DataSource = rsMarkReports.Table
            .grdPatentReports.DataSource = rsPatentReports.Table
            SetSelected(.grdMarkReports, False)
            SetSelected(.grdPatentReports, False)
            .btnPrintMarkReport.Enabled = False

            .cboMarkContact.SelectedIndex = -1
            .cboMarkPosition.SelectedIndex = -1
            .cboMarkPosition.DataSource = dtMarkPositions
            .cboPatentPosition.SelectedIndex = -1
            .cboPatentContact.SelectedIndex = -1
            .cboPatentPosition.DataSource = dtPatentPositions

            GetStatus()
            SetCompletedLists()
            SetSpreadsheetFont()
            GetPrintOptions()
            GetTrademarkStoredFilters()
            GetPatentStoredFilters()

            If RevaSettings.OpenOnMarks = True Then
                .Tabs.SelectedIndex = 0
            Else
                .Tabs.SelectedIndex = 1
            End If

            If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
                .sepDemo.Visible = True
                .lblDemo.Visible = True
            Else
                .sepDemo.Visible = False
                .lblDemo.Visible = False
            End If

            Select Case My.Settings.DateToIndex
                Case 0
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Day, 7, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Day, 7, DateTime.Now.Date)
                Case 1
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Month, 1, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Month, 1, DateTime.Now.Date)
                Case 2
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Month, 2, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Month, 2, DateTime.Now.Date)
                Case 3
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Month, 3, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Month, 3, DateTime.Now.Date)
                Case 4
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Month, 6, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Month, 6, DateTime.Now.Date)
                Case 5
                    .MarkAlertsTo.Value = DateAdd(DateInterval.Year, 1, DateTime.Now.Date)
                    .PatentAlertsTo.Value = DateAdd(DateInterval.Year, 1, DateTime.Now.Date)
            End Select

            Select Case My.Settings.DateFromIndex
                Case 0
                    .MarkAlertsFrom.Value = DateAdd(DateInterval.Month, -3, DateTime.Now.Date)
                    .PatentAlertsFrom.Value = DateAdd(DateInterval.Month, -3, DateTime.Now.Date)
                Case 1
                    .MarkAlertsFrom.Value = DateAdd(DateInterval.Month, -2, DateTime.Now.Date)
                    .PatentAlertsFrom.Value = DateAdd(DateInterval.Month, -2, DateTime.Now.Date)
                Case 2
                    .MarkAlertsFrom.Value = DateAdd(DateInterval.Month, -1, DateTime.Now.Date)
                    .PatentAlertsFrom.Value = DateAdd(DateInterval.Month, -1, DateTime.Now.Date)
                Case 3
                    .MarkAlertsFrom.Value = DateAdd(DateInterval.Day, -7, DateTime.Now.Date)
                    .PatentAlertsFrom.Value = DateAdd(DateInterval.Day, -7, DateTime.Now.Date)
                Case 4
                    .MarkAlertsFrom.Value = DateTime.Now.Date
                    .PatentAlertsFrom.Value = DateTime.Now.Date
            End Select

        End With
    End Sub



    Private Sub frmReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If bSpreadsheetChanged = True Then
            If MsgBox("The spreadsheet has changed but has not been saved.  Save to Excel?", MsgBoxStyle.YesNo) _
                = MsgBoxResult.Yes Then
                SaveSpreadsheet()
            End If
        End If
        AllForms.frmReports = Nothing

        'trying to get a clean close
        If AllForms.frmTrademarks Is Nothing And AllForms.frmPatents Is Nothing And AllForms.frmLogin Is Nothing _
        And AllForms.frmPreferences Is Nothing And AllForms.frmReports Is Nothing _
        And AllForms.frmCompanies Is Nothing And AllForms.frmOppositions Is Nothing Then

            Application.Exit()
        End If
    End Sub

    Private Sub SetSelected(ByVal GridEx As Janus.Windows.GridEX.GridEX, ByVal bSelected As Boolean)
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To GridEx.RowCount - 1
            GRow = GridEx.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("Selected").Value = bSelected
                GRow.EndEdit()
            End If
        Next
    End Sub

#End Region

#Region "Fill Data Tables"

    Private Sub SetCompletedLists()
        On Error Resume Next
        With Me.grdMarkDates.RootTable.Columns("Completed").ValueList
            .Add(2, "(All)")
            .Add(1, "Yes")
            .Add(0, "No")
        End With
        With Me.grdPatentDates.RootTable.Columns("Completed").ValueList
            .Add(2, "(All)")
            .Add(1, "Yes")
            .Add(0, "No")
        End With
    End Sub

    Friend Sub GetTrademarkStoredFilters()
        On Error Resume Next
        Dim strSQL As String
        'They're all in one Access table, but we need separate Access and SQL versions because the fields being
        'stored my differ from the demo version to the SQL version.
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            ' Access version, trademark filters
            strSQL = "Select * from tblFilterNames where IsTrademark <> 0 and IsSQL = 0 order by FilterName"
            dtMarkFilters = DataStuff.GetDemoTable(strSQL)
        Else
            ' SQL version, trademark filters
            strSQL = "Select * from tblFilterNames where IsTrademark <> 0 and IsSQL <> 0 order by FilterName"
            dtMarkFilters = DataStuff.GetDemoTable(strSQL)
        End If
        Me.MarkFilterID.DataSource = dtMarkFilters
        Me.MarkFilterID.SelectedIndex = -1
    End Sub

    Friend Sub GetPatentStoredFilters()
        On Error Resume Next
        Dim strSQL As String
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            ' Access version, Patent filters
            strSQL = "Select * from tblFilterNames where IsTrademark = 0 and IsSQL = 0 order by FilterName"
            dtPatentFilters = DataStuff.GetDemoTable(strSQL)
        Else
            ' SQL version, Patent filters
            strSQL = "Select * from tblFilterNames where IsTrademark = 0 and IsSQL <> 0 order by FilterName"
            dtPatentFilters = DataStuff.GetDemoTable(strSQL)
        End If
        Me.PatentFilterID.DataSource = dtPatentFilters
        Me.PatentFilterID.SelectedIndex = -1
    End Sub

    Friend Sub GetStatus()
        On Error Resume Next
        'We need these whether filters applied or not so we can limit it to ShowOnReports = true
        Dim strSQL As String

        strSQL = "Select * from tblStatus where IsTrademark <> 0 Order by Status"
        dtTrademarkStatus = DataStuff.GetDataTable(strSQL)
        strSQL = "Select * from tblStatus where IsPatent <> 0 order by Status"
        dtPatentStatus = DataStuff.GetDataTable(strSQL)

    End Sub

#End Region

#Region "Trademark Filter Settings"

    'BIG CHANGE:  Now we don't fill any of the filter grids until the user enables a filter.
    'The exception is Status, because we want to filter down to ShowOnReports = true 
    'if no status is selected as a filter.


    Private Sub chkMarkCompanies_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkCompanies.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkCompanies.Enabled = .chkMarkCompanies.Checked
            If .cboMarkCompanies.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select distinct CompanyID, CompanyName from qvwTrademarks Order by CompanyName"
                .cboMarkCompanies.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkMarkCompanies.Checked = True Then .cboMarkCompanies.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkJurisdictions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkJurisdictions.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkJurisdictions.Enabled = .chkMarkJurisdictions.Checked
            If .cboMarkJurisdictions.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsTrademark <> 0 Order by Jurisdiction"
                .cboMarkJurisdictions.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkMarkJurisdictions.Checked = True Then .cboMarkJurisdictions.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkStatus.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkStatus.Enabled = .chkMarkStatus.Checked
            If .cboMarkStatus.DropDownDataSource Is Nothing Then
                'NOTE, IF NO STATUS SELECTED, REMEMBER TO EXCLUDE WHERE ShownOnReport = FALSE
                dtTrademarkStatus.Rows.Add(0, "(Blank Status)", 0, 0, 0, 0)
                .cboMarkStatus.DropDownDataSource = dtTrademarkStatus
            End If
            If .chkMarkStatus.Checked = True Then .cboMarkStatus.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkFilingBasis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkFilingBasis.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkFilingBasis.Enabled = .chkMarkFilingBasis.Checked
            If .cboMarkFilingBasis.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select FilingBasisID, FilingBasis, IsTreaty from tblFilingBasis Order by FilingBasisID"
                .cboMarkFilingBasis.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkMarkFilingBasis.Checked = True Then .cboMarkFilingBasis.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkRegTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkRegTypes.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkRegTypes.Enabled = .chkMarkRegTypes.Checked
            If .cboMarkRegTypes.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select * from tblRegistrationTypes order by RegistrationType"
                .cboMarkRegTypes.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkMarkRegTypes.Checked = True Then .cboMarkRegTypes.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkClasses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkClasses.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkClasses.Enabled = .chkMarkClasses.Checked
            If .cboMarkClasses.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select * from tblRegistrationClass order by RegClass"
                .cboMarkClasses.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkMarkClasses.Checked = True Then .cboMarkClasses.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkPositions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkPositions.CheckedChanged
        On Error Resume Next
        With Me
            .cboMarkPosition.Enabled = .chkMarkPositions.Checked
            .cboMarkContact.Enabled = .chkMarkPositions.Checked
            If .chkMarkPositions.Checked = True Then .cboMarkPosition.DroppedDown = True
        End With
    End Sub

    Private Sub chkMarkPositions_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkPosition.ValueChanged
        Dim iPositionID As Integer, dtContactList As DataTable, strSQL As String
        iPositionID = cboMarkPosition.Value
        If iPositionID > 0 Then
            strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwTrademarkContacts" &
                " where PositionID=" & iPositionID & " order by ContactName"
            dtContactList = DataStuff.GetDataTable(strSQL)
            Me.cboMarkContact.DataSource = dtContactList
            Me.cboMarkContact.SelectedIndex = -1
        End If
    End Sub

    Private Sub chkMarkDateFilters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkDateFilters.CheckedChanged
        On Error Resume Next
        Me.grdMarkDates.Visible = Me.chkMarkDateFilters.Checked
        If Me.chkMarkDateFilters.Checked = True Then
            Me.chkMarkAlerts.Checked = False
        End If
    End Sub

    Private Sub grdMarkDates_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdMarkDates.ColumnHeaderClick
        On Error Resume Next

        If e.Column.Key = "Selected" Then
            Dim bSelected As Boolean
            If Me.grdMarkDates.GetValue("Selected") = False Then
                SetSelected(Me.grdMarkDates, True)
            Else
                SetSelected(Me.grdMarkDates, False)
            End If
        End If

        If e.Column.Key = "Completed" Then
            Select Case Me.grdMarkDates.GetValue("Completed")
                Case 0
                    SetMarkDateCompleted(2)   'all
                Case 1
                    SetMarkDateCompleted(0)    'no
                Case Else
                    SetMarkDateCompleted(1)   'yes
            End Select
        End If

        If e.Column.Key = "DateFrom" Then
            On Error Resume Next
            Me.grdMarkDates.UpdateData()
            Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, dDateFrom As DateTime
            For i = 0 To Me.grdMarkDates.RowCount - 1

                GRow = Me.grdMarkDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then

                    If IsDate(GRow.Cells("DateFrom").Text) Then
                        dDateFrom = GRow.Cells("DateFrom").Value
                    End If

                    If GRow.Cells("Selected").Value = True Then
                        GRow.BeginEdit()
                        If dDateFrom <> Date.MinValue Then
                            GRow.Cells("DateFrom").Value = dDateFrom
                        End If
                        GRow.EndEdit()
                    Else
                        GRow.BeginEdit()
                        GRow.Cells("DateFrom").Value = DBNull.Value
                        GRow.EndEdit()
                    End If

                End If
            Next
        End If

        If e.Column.Key = "DateTo" Then
            On Error Resume Next
            Me.grdMarkDates.UpdateData()
            Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, dDateTo As DateTime
            For i = 0 To Me.grdMarkDates.RowCount - 1

                GRow = Me.grdMarkDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then

                    If IsDate(GRow.Cells("DateTo").Text) Then
                        dDateTo = GRow.Cells("DateTo").Value
                    End If

                    If GRow.Cells("Selected").Value = True Then
                        GRow.BeginEdit()
                        If dDateTo <> Date.MinValue Then
                            GRow.Cells("DateTo").Value = dDateTo
                        End If
                        GRow.EndEdit()
                    Else
                        GRow.BeginEdit()
                        GRow.Cells("DateTo").Value = DBNull.Value
                        GRow.EndEdit()
                    End If

                End If
            Next
        End If

    End Sub


    Private Sub SetMarkDateCompleted(ByVal iCompleted As Integer)
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.grdMarkDates.RowCount - 1
            GRow = Me.grdMarkDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("Completed").Value = iCompleted
                GRow.EndEdit()
            End If
        Next
    End Sub

    Private Sub btnResetMarkFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMarkFilters.Click
        On Error Resume Next
        ClearMarkDates()
        With Me
            .chkMarkCompanies.Checked = False
            .chkMarkJurisdictions.Checked = False
            .chkMarkStatus.Checked = False
            .chkMarkFilingBasis.Checked = False
            .chkMarkRegTypes.Checked = False
            .chkMarkClasses.Checked = False
            .chkMarkPositions.Checked = False
            .chkMarkDateFilters.Checked = False
            .chkMarkAlerts.Checked = False

            .cboMarkCompanies.UncheckAll()
            .cboMarkJurisdictions.UncheckAll()
            .cboMarkStatus.UncheckAll()
            .cboMarkFilingBasis.UncheckAll()
            .cboMarkRegTypes.UncheckAll()
            .cboMarkClasses.UncheckAll()
            .cboMarkPosition.SelectedIndex = -1
            .cboMarkContact.SelectedIndex = -1

            .grdMarks.DataSource = Nothing
            .grdMarks.RemoveFilters()
            .MarkFilterID.SelectedIndex = -1
            .btnPrintMarkReport.Enabled = False
        End With

    End Sub

    Private Sub ClearMarkDates()
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.grdMarkDates.RowCount - 1
            GRow = Me.grdMarkDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("DateFrom").Value = DBNull.Value
                GRow.Cells("DateTo").Value = DBNull.Value
                GRow.Cells("Selected").Value = False
                GRow.Cells("Completed").Value = 2
                GRow.EndEdit()
            End If
        Next
    End Sub

    ' =================== New Sept. 2013, allow loading/saving stored filters ===============

    Private Sub btnMarkFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkFilter.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(11)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnSaveMarkFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMarkFilters.Click
        On Error Resume Next
        If Me.MarkFilterID.Text.Length < 3 Then
            MsgBox("To save a filter, you must first select a filter name in the drop-down list.  To create new filter names, click the Stored Filter hyperlink.")
            Exit Sub
        End If

        If MsgBox("The selected filter values will be saved as " & Me.MarkFilterID.Text & ". Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ' If we're still here, it's time to save all those values.  Start by clearing any previous ones.
        Dim strSQL As String, rsFilterValues As New RecordSet, iFilterID As Integer
        Dim i As Integer, FilterRows As Object(), GRow As Janus.Windows.GridEX.GridEXRow

        iFilterID = Me.MarkFilterID.Value
        strSQL = "Delete from tblFilterValues where FilterID=" & iFilterID
        DataStuff.RunDemoSQL(strSQL)
        rsFilterValues.GetFromDemo("Select * from tblFilterValues where FilterID=" & iFilterID)

        With Me
            ' write selected company values
            If Not (.cboMarkCompanies.CheckedValues Is Nothing) And (.chkMarkCompanies.Checked = True) Then
                FilterRows = .cboMarkCompanies.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    'MsgBox(FilterRows(i).ToString)
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "CompanyID"
                    End With
                Next
            End If

            'jurisdiction values
            If Not (.cboMarkJurisdictions.CheckedValues Is Nothing) And (.chkMarkJurisdictions.Checked = True) Then
                FilterRows = .cboMarkJurisdictions.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "JurisdictionID"
                    End With
                Next
            End If

            'Status values
            If Not (.cboMarkStatus.CheckedValues Is Nothing) And (.chkMarkStatus.Checked = True) Then
                FilterRows = .cboMarkStatus.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "StatusID"
                    End With
                Next
            End If

            'FilingBasis values
            If Not (.cboMarkFilingBasis.CheckedValues Is Nothing) And (.chkMarkFilingBasis.Checked = True) Then
                FilterRows = .cboMarkFilingBasis.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "FilingBasisID"
                    End With
                Next
            End If

            'RegType values
            If Not (.cboMarkRegTypes.CheckedValues Is Nothing) And (.chkMarkRegTypes.Checked = True) Then
                FilterRows = .cboMarkRegTypes.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "RegTypeID"
                    End With
                Next
            End If

            'Reg Class values
            If Not (.cboMarkClasses.CheckedValues Is Nothing) And (.chkMarkClasses.Checked = True) Then
                FilterRows = .cboMarkClasses.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "RegClassID"
                    End With
                Next
            End If

            'Position values
            If Not (.cboMarkPosition.SelectedIndex = -1) And (.chkMarkPositions.Checked = True) Then
                rsFilterValues.AddRow()
                With rsFilterValues.CurrentRow
                    .Item("FilterID") = iFilterID
                    .Item("IntegerValue") = Me.cboMarkPosition.Value
                    .Item("FieldName") = "PositionID"
                End With
            End If

            'Contact values
            If Not (.cboMarkContact.SelectedIndex = -1) Then
                rsFilterValues.AddRow()
                With rsFilterValues.CurrentRow
                    .Item("FilterID") = iFilterID
                    .Item("IntegerValue") = Me.cboMarkContact.Value
                    .Item("FieldName") = "ContactID"
                End With
            End If

            ' Date Selections
            If .chkMarkDateFilters.Checked = True Then
                ' first make sure grid is updated
                Me.grdMarkDates.UpdateData()
                For i = 0 To Me.grdMarkDates.RowCount - 1
                    GRow = grdMarkDates.GetRow(i)
                    With rsFilterValues
                        If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) And (GRow.Cells("Selected").Value = True) Then
                            .AddRow()
                            .CurrentRow.Item("FilterID") = iFilterID
                            .CurrentRow.Item("IsSelected") = True
                            .CurrentRow.Item("DateID") = GRow.Cells("DateID").Value
                            ' we store completed drop-down value in Integer Value
                            .CurrentRow.Item("IntegerValue") = GRow.Cells("Completed").Value

                            If IsDate(GRow.Cells("DateFrom").Value) Then
                                .CurrentRow.Item("DateFrom") = GRow.Cells("DateFrom").Value
                            End If

                            If IsDate(GRow.Cells("DateTo").Value) Then
                                .CurrentRow.Item("DateTo") = GRow.Cells("DateTo").Value
                            End If
                        End If
                    End With 'with rsFilterValues
                Next
            End If
        End With

        rsFilterValues.Update()
        MsgBox("Stored filter saved.")

    End Sub

    Private Sub MarkFilterID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkFilterID.ValueChanged
        On Error Resume Next
        ' don't bother if a real filter isn't selected
        If Me.MarkFilterID.SelectedIndex < 0 Then
            Exit Sub
        End If

        Dim dtFilters As DataTable, strSQL As String, iFilterID As Integer, i As Integer
        Dim SelectedValues As New ArrayList, GRow As Janus.Windows.GridEX.GridEXRow


        iFilterID = Me.MarkFilterID.Value
        dtFilters = DataStuff.GetDemoTable("Select * from tblFilterValues where FilterID=" & iFilterID & " order by DateID, FieldName")

        ' could be a new filter, don't want to clear selections
        If dtFilters.Rows.Count = 0 Then
            Exit Sub
        End If

        With Me
            .chkMarkCompanies.Checked = False
            .chkMarkJurisdictions.Checked = False
            .chkMarkStatus.Checked = False
            .chkMarkFilingBasis.Checked = False
            .chkMarkRegTypes.Checked = False
            .chkMarkClasses.Checked = False
            .chkMarkPositions.Checked = False
            .chkMarkDateFilters.Checked = False
            .cboMarkCompanies.UncheckAll()
            .cboMarkJurisdictions.UncheckAll()
            .cboMarkStatus.UncheckAll()
            .cboMarkFilingBasis.UncheckAll()
            .cboMarkRegTypes.UncheckAll()
            .cboMarkClasses.UncheckAll()
            .cboMarkPosition.SelectedIndex = -1
            .cboMarkContact.SelectedIndex = -1
            .chkMarkDateFilters.Checked = False
        End With



        ' Companies
        i = dtFilters.Rows.Count
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "CompanyID" Then
                Me.chkMarkCompanies.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkCompanies.CheckedValues = SelectedValues.ToArray
        End If


        'Jurisdictions
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "JurisdictionID" Then
                Me.chkMarkJurisdictions.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkJurisdictions.CheckedValues = SelectedValues.ToArray
        End If

        'Status
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "StatusID" Then
                Me.chkMarkStatus.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkStatus.CheckedValues = SelectedValues.ToArray
        End If

        'Filing Basis
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "FilingBasisID" Then
                Me.chkMarkFilingBasis.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkFilingBasis.CheckedValues = SelectedValues.ToArray
        End If

        'RegType
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "RegTypeID" Then
                Me.chkMarkRegTypes.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkRegTypes.CheckedValues = SelectedValues.ToArray
        End If

        'RegClass
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "RegClassID" Then
                Me.chkMarkClasses.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboMarkClasses.CheckedValues = SelectedValues.ToArray
        End If

        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "PositionID" Then
                Me.chkMarkPositions.Checked = True
                Me.cboMarkPosition.Value = dr("IntegerValue")
            End If
        Next

        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "ContactID" Then
                Me.cboMarkContact.Value = dr("IntegerValue")
            End If
        Next

        'otherwise they stay dropped down ... weird
        Me.cboMarkPosition.DroppedDown = False
        Me.cboMarkContact.DroppedDown = False

        ClearMarkDates()
        For Each dr As DataRow In dtFilters.Rows
            If Nz(dr("DateID"), 0) > 0 Then
                Me.chkMarkDateFilters.Checked = True

                With Me.grdMarkDates
                    For i = 0 To .RowCount - 1
                        GRow = .GetRow(i)
                        If GRow.Cells("DateID").Value = dr("DateID") Then
                            GRow.BeginEdit()
                            GRow.Cells("Selected").Value = dr("IsSelected")
                            GRow.Cells("DateFrom").Value = dr("DateFrom")
                            GRow.Cells("DateTo").Value = dr("DateTo")
                            GRow.Cells("Completed").Value = dr("IntegerValue")
                            GRow.EndEdit()
                        End If
                    Next
                End With

            End If
        Next

        Me.MarkFilterID.Focus()

    End Sub

#End Region

#Region "Trademark Custom Fields"

    'So we don't force a new previous for the same filters, same layout
    Dim LastMarkLayout As String

    Private Sub btnMarkChooseColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkChooseColumns.Click
        On Error Resume Next
        Me.grdMarks.HideFieldChooser()
        Me.grdMarks.ShowFieldChooser()
        Me.grdMarks.RootTable.Columns("TrademarkID").ShowInFieldChooser = False
    End Sub

    Private Sub btnMarkPositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkPositions.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(6)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub SaveMarkReportLayout()
        On Error Resume Next
        Dim LayoutName As String
        LayoutName = Me.grdMarkReports.GetValue("ReportLayout") & ""

        If Not (My.Settings.Item(LayoutName) Is Nothing) Then
            My.Settings.Item(LayoutName) = Me.grdMarks.GetLayout.GetXmlString
        End If

    End Sub

    Private Sub LoadMarkReportLayout()
        On Error Resume Next
        Dim LayoutName As String, strColumnName As String
        LayoutName = Me.grdMarkReports.GetValue("ReportLayout") & ""

        If Not (My.Settings.Item(LayoutName) Is Nothing) Then
            If (My.Settings.Item(LayoutName).Length > 100) Then
                Me.grdMarks.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.Item(LayoutName)))
                LastMarkLayout = LayoutName
            End If
        End If

        If (dtMarks Is Nothing) Or (dtMarks.Rows.Count = 0) Then Exit Sub

        'Remove any columns that shouldn't show up in the grid or field chooser
        For Each gridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdMarks.RootTable.Columns
            strColumnName = gridCol.Key
            If dtMarks.Columns.Contains(strColumnName) = False Then
                gridCol.ShowInFieldChooser = False
                gridCol.Visible = False
            End If
            If strColumnName.Contains("Goods") Then
                gridCol.WordWrap = True
                gridCol.MaxLines = 128
            End If
        Next

    End Sub

    Private Sub mnuResetGrid_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuResetGrid.ItemClicked
        On Error Resume Next
        If Me.Tabs.SelectedTab.Name = "tbMarkReports" Then
            ResetTrademarksList()
        End If
        If Me.Tabs.SelectedTab.Name = "tbPatentReports" Then
            ResetPatentsList()
        End If
    End Sub

    Private Sub ResetMarkColumn(ByVal ColumnKey As String, ByVal iPos As Integer, ByVal iWidth As Integer, ByVal isVisible As Boolean)
        With Me.grdMarks.RootTable
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
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdMarks.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetMarkColumn("TrademarkID", 0, 100, False)
        ResetMarkColumn("CompanyName", 1, 175, True)
        ResetMarkColumn("TrademarkName", 2, 150, True)
        ResetMarkColumn("TrademarkType", 3, 100, False)
        ResetMarkColumn("Jurisdiction", 4, 100, True)
        ResetMarkColumn("ApplicationNumber", 5, 80, True)
        ResetMarkColumn("RegistrationNumber", 6, 80, True)
        ResetMarkColumn("OurDocket", 7, 100, True)
        ResetMarkColumn("ClientDocket", 8, 100, False)
        ResetMarkColumn("Status", 9, 80, True)
        ResetMarkColumn("RegistrationType", 10, 80, False)
        ResetMarkColumn("FileNumber", 11, 100, False)
        ResetMarkColumn("FilingBasis", 12, 100, False)
        ResetMarkColumn("GoodsServices", 13, 100, False)

        If dtMarks.Columns.Contains("DateName") Then
            ResetMarkColumn("DateName", 14, 100, True)
            ResetMarkColumn("TrademarkDate", 15, 100, True)
        End If

        ResetMarkColumn("Graphic", 16, 80, False)

        Me.grdMarks.RootTable.Columns("TrademarkID").ShowInFieldChooser = False

    End Sub

#End Region

#Region "Trademark Reports"

    Private Sub grdMarks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdMarks.LinkClicked
        On Error Resume Next
        If (e.Column.Key = "TrademarkName") Then
            Globals.TrademarkID = Me.grdMarks.GetValue("TrademarkID")
            Globals.NavigateMarksFrom = 3
            AllForms.OpenTrademarks()
            AllForms.frmTrademarks.GetTrademark()
            AllForms.frmTrademarks.Tabs.SelectedIndex = 1
        End If
    End Sub

    Private Sub PreviewMarks()
        On Error Resume Next
        Dim strReportName As String, strReportLayout As String

        'becuz user may have added fields to grid and then hit preview again
        Me.grdMarks.RemoveFilters()
        If Me.grdMarks.RowCount > 0 Then
            SaveMarkReportLayout()
        End If

        With Me
            strReportName = .grdMarkReports.GetValue("ReportFileName")
            strReportLayout = .grdMarkReports.GetValue("ReportLayout")
            .grdMarks.RemoveFilters()
            .Cursor = Cursors.WaitCursor

            Select Case strReportName

                '============================== List reports ============================

                Case "rptTrademarksByNameList"
                    ' GetTrademarksList pulls most trademark fields and can be used as a recordset for list reports
                    If strReportLayout = "rptTrademarksListLayout" Then

                        GetTrademarksList()
                        LoadMarkReportLayout()
                        ShowMarkDateColumns(False)
                    Else
                        GetTrademarksListNextDueDate()
                        LoadMarkReportLayout()
                        ShowMarkDateColumns(True)
                    End If

                    .grdMarks.GroupByBoxVisible = True
                    .grdMarks.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True
                    .lblMarkReportWidth.Visible = True
                    SetMarkReportMargin()

                Case "rptTrademarkDates"
                    ' GetTrademarksList pulls most trademark field and the selected date fields 
                    ' and can be used as a recordset for list reports
                    GetTrademarksListWithDates()
                    LoadMarkReportLayout()
                    ShowMarkDateColumns(True)
                    .grdMarks.GroupByBoxVisible = True
                    .grdMarks.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True
                    .lblMarkReportWidth.Visible = True
                    SetMarkReportMargin()

                Case "rptTrademarksByCompanyList"
                    GetTrademarksList()
                    LoadMarkReportLayout()
                    ShowMarkDateColumns(True)
                    .grdMarks.GroupByBoxVisible = False
                    .lblMarkReportWidth.Visible = True
                    SetMarkReportMargin()

                '============================== Formatted reports ============================
                Case "rptTrademarksByCompany", "rptTrademarksAlpha", "rptTrademarksByCompanyContacts",
                    "rptTrademarksByNameList", "rptTrademarksByCompanyDates", "rptTrademarkActions",
                    "rptTrademarkActions", "rptTrademarksLicensed"

                    GetTrademarksList()
                    LoadMarkReportLayout()
                    ShowMarkDateColumns(False)
                    .grdMarks.GroupByBoxVisible = False
                    .grdMarks.RootTable.Groups.Clear()
                    .lblMarkReportWidth.Visible = False

                '============================== Export reports ============================
                ' For these we have to load the layout FIRST, since we'll need to add/remove date and position columns after the fact
                Case "MarkExportExcel"
                    LoadMarkReportLayout()
                    GetTrademarksForExport(True)
                    ShowMarkDateColumns(False)
                    .grdMarks.GroupByBoxVisible = False
                    .grdMarks.RootTable.Groups.Clear()
                    .lblMarkReportWidth.Visible = False

                Case "MarkExportWord"
                    LoadMarkReportLayout()
                    GetTrademarksForExport(False)
                    ShowMarkDateColumns(False)
                    .grdMarks.GroupByBoxVisible = False
                    .grdMarks.RootTable.Groups.Clear()
                    .lblMarkReportWidth.Visible = False

                Case Else

            End Select

            If .grdMarks.RowCount > 0 Then
                .btnMarkChooseColumns.Enabled = True
                .grdMarks.ScrollBars = Janus.Windows.GridEX.ScrollBars.Automatic
                .btnPrintMarkReport.Enabled = True
                .grdMarks.Row = 0
                .chkMarkGroupNewPage.Visible = .grdMarks.RootTable.Groups.Count > 0
            End If

            .Cursor = Cursors.Default

        End With

    End Sub

    Private Sub GetTrademarksList()
        On Error Resume Next
        Dim strSQL As String

        strSQL = "Select distinct TrademarkID, TrademarkName, TrademarkType, CompanyName, Jurisdiction, ApplicationNumber, " &
        "RegistrationNumber, Status, FilingBasis, FileNumber, RegistrationType, OurDocket, ClientDocket, GoodsServices " &
        "from qvwTrademarksFullList " & GetTrademarkFilters(False)

        dtMarks = DataStuff.GetDataTable(strSQL)
        Me.grdMarks.DataSource = dtMarks

    End Sub

    Private Sub GetTrademarksListWithDates()
        On Error Resume Next
        Dim strSQL As String

        strSQL = "Select distinct TrademarkID, TrademarkName, TrademarkType, CompanyName, Jurisdiction, ApplicationNumber, " &
        "RegistrationNumber, Status, FilingBasis, FileNumber, RegistrationType, OurDocket, ClientDocket, GoodsServices, " &
        "DateName, TrademarkDate, NoDay, NoMonth, Completed from qvwTrademarksFullList" & GetTrademarkFilters(True)

        dtMarks = DataStuff.GetDataTable(strSQL)
        Me.grdMarks.DataSource = dtMarks

    End Sub

    Private Sub GetTrademarksListNextDueDate()
        On Error Resume Next
        Dim strFilter As String, i As Integer, Grow As Janus.Windows.GridEX.GridEXRow, strSQL As String

        ' This gets just the list of dates selected to appear in Next Due Date. There are no actual date filters.
        strFilter = "where Completed = 0 and DateID in ("

        For i = 0 To Me.grdMarkDates.RowCount - 1
            Grow = grdMarkDates.GetRow(i)
            If Grow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If Grow.Cells("Selected").Value = True Then
                    strFilter = strFilter & Grow.Cells("DateID").Value & ","
                End If
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = "select distinct qvwTrademarkDates.TrademarkID as TrademarkID, TrademarkDateID, TrademarkName, TrademarkType, Jurisdiction, ApplicationNumber, RegistrationNumber," &
        " Status, GraphicPath as Graphic, GoodsServices, OurDocket, ClientDocket, DateName, Q.TrademarkDate as TrademarkDate from qvwTrademarkDates " &
        " inner join (Select TrademarkID as MarkID, Min(TrademarkDate) as TrademarkDate from tblTrademarkDates " & strFilter &
        " group by TrademarkID) Q on Q.MarkID = qvwTrademarkDates.TrademarkID and Q.TrademarkDate = qvwTrademarkDates.TrademarkDate " & GetTrademarkFilters(False)

        dtMarks = DataStuff.GetDataTable(strSQL)
        Me.grdMarks.DataSource = dtMarks

    End Sub

    Private Sub GetTrademarksForExport(ByVal IsExcel As Boolean)
        On Error Resume Next
        Dim i As Integer, dtTrademarkDates As DataTable, dtTrademarkContacts As DataTable, dtClasses As DataTable
        Dim strColumnName As String, UpdateRows As DataRow(), strSQL As String, strFilter As String, strClasses As String
        Dim bShowGraphic As Boolean, bShowClasses As Boolean, GRow As Janus.Windows.GridEX.GridEXRow, bDateSelected As Boolean

        strSQL = "Select distinct TrademarkID, TrademarkName, TrademarkType, CompanyName, Jurisdiction, ApplicationNumber, " &
              "RegistrationNumber, Status, FilingBasis, FileNumber, RegistrationType, OurDocket, ClientDocket, GoodsServices, GraphicPath as Graphic " &
              "from qvwTrademarksFullList " & GetTrademarkFilters(False)

        dtMarks = DataStuff.GetDataTable(strSQL)

        'no graphics exported to Excel -- doesn't work.
        If IsExcel = True Then
            dtMarks.Columns.Remove("Graphic")
        End If

        'so we limit other tables to trademarks we already found
        strFilter = " where TrademarkID in ("
        For Each dr As DataRow In dtMarks.Rows
            strFilter = strFilter & dr("TrademarkID") & ", "
        Next
        strFilter = strFilter & "0)"

        dtMarks.Columns.Add("Classes")

        ' get all classes for trademarks
        strSQL = "Select TrademarkID, RegClass from qvwTrademarkClasses " & strFilter & " order by RegClass"
        dtClasses = DataStuff.GetDataTable(strSQL)

        'make sure a filter has been applied or a date has been checked
        bDateSelected = False
        For i = 0 To Me.grdMarkDates.RowCount - 1
            GRow = Me.grdMarkDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If GRow.Cells("Selected").Value = True Then
                    bDateSelected = True
                End If
            End If
        Next

        If (Me.chkMarkDateFilters.Checked = True) And (bDateSelected = True) Then
            'get trademark dates marked for Word/Excel export
            strSQL = "Select distinct TrademarkID, DateName, Max(TrademarkDate) as TrademarkDate from tblTrademarkDates " &
                    "inner join tblDatesTemplate on tblTrademarkDates.DateID = tblDatesTemplate.DateID " &
                    strFilter & GetDatesToPrint() & " Group by TrademarkID, TrademarkDate, DateName"

            ' Okay, it's a hack.  I admit it.  Both tables have DateID in them.
            strSQL = strSQL.Replace("(DateID", "(tblTrademarkDates.DateID")
            dtTrademarkDates = DataStuff.GetDataTable(strSQL)
        End If

        ' get positions marked for Word/Excel export
        strSQL = "Select distinct TrademarkID, PositionName, ContactName from qvwTrademarkContacts " & strFilter &
                " and WordExcel <> 0 and PositionName <> ''"
        dtTrademarkContacts = DataStuff.GetDataTable(strSQL)

        For Each MarkRow As DataRow In dtMarks.Rows
            strFilter = "TrademarkID=" & MarkRow("TrademarkID").ToString()

            ' add classes as a single string separated by commas
            UpdateRows = dtClasses.Select(strFilter)
            strClasses = String.Empty
            For i = 0 To UpdateRows.Length - 1
                strClasses = strClasses & UpdateRows(i).Item("RegClass")
                If i < (UpdateRows.Length - 1) Then
                    strClasses = strClasses & ", "
                End If
            Next

            MarkRow("Classes") = strClasses

            If Not (dtTrademarkDates Is Nothing) Then
                ' for selected dates, create column if necessary and fill date value for each row
                UpdateRows = dtTrademarkDates.Select(strFilter)
                For i = 0 To UpdateRows.Length - 1
                    strColumnName = "[" & UpdateRows(i).Item("DateName") & "]"
                    If dtMarks.Columns.Contains(strColumnName) = False Then
                        dtMarks.Columns.Add(strColumnName)
                    End If
                    If IsDate(UpdateRows(i).Item("TrademarkDate")) Then
                        If RevaSettings.USADates = True Then
                            MarkRow(strColumnName) = Convert.ToDateTime(UpdateRows(i).Item("TrademarkDate")).ToString("MMM dd, yyyy")
                        Else
                            MarkRow(strColumnName) = Convert.ToDateTime(UpdateRows(i).Item("TrademarkDate")).ToString("dd MMM,yyyy")
                        End If

                    End If
                Next
            End If

            ' ditto for selected positions
            UpdateRows = dtTrademarkContacts.Select(strFilter)
            For i = 0 To UpdateRows.Length - 1
                strColumnName = "[" & UpdateRows(i).Item("PositionName") & "]"
                If dtMarks.Columns.Contains(strColumnName) = False Then
                    dtMarks.Columns.Add(strColumnName)
                End If
                MarkRow(strColumnName) = UpdateRows(i).Item("ContactName")
            Next

        Next 'next MarkRow

        dtMarks.AcceptChanges()

        With Me.grdMarks.RootTable
            'see if graphic and classes are current visible
            bShowGraphic = False
            bShowClasses = False
            If .Columns.Contains("Graphic") Then
                If .Columns("Graphic").Visible = True Then
                    bShowGraphic = True
                End If
            End If
            If .Columns.Contains("Classes") Then
                If .Columns("Classes").Visible = True Then
                    bShowClasses = True
                End If
            End If
        End With

        ' Now we have to add missing columns to grid.  Those were all named with brackets, except for GraphicPath
        For Each dc As DataColumn In dtMarks.Columns
            With Me.grdMarks.RootTable

                If (dc.ColumnName.Contains("[")) Or (dc.ColumnName = "Graphic") Or (dc.ColumnName = "Classes") Then
                    strColumnName = dc.ColumnName
                    If .Columns.Contains(strColumnName) = False Then
                        .Columns.Add(strColumnName)
                    End If

                    .Columns(strColumnName).Caption = strColumnName.Replace("[", "").Replace("]", "")
                    .Columns(strColumnName).ShowInFieldChooser = True
                    .Columns(strColumnName).Visible = True
                    .Columns(strColumnName).FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                    'turn these off if they werent' previously visible
                    If strColumnName = "Graphic" Then
                        .Columns("Graphic").Visible = bShowGraphic
                    End If
                    If strColumnName = "Classes" Then
                        .Columns("Classes").Visible = bShowClasses
                    End If

                End If
            End With
        Next
        ' And remove any columns from the grid no longer in our table.  
        ' For reasons that make no sense, we have to do this as many times as there are dates to clear the columns that are gone.
        For i = 1 To Me.grdMarkDates.RowCount
            For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdMarks.RootTable.Columns
                strColumnName = GridCol.Key
                If dtMarks.Columns.Contains(strColumnName) = False Then
                    GridCol.Visible = False
                    GridCol.ShowInFieldChooser = False
                    Me.grdMarks.RootTable.Columns.Remove(GridCol)
                End If
            Next
        Next

        Me.grdMarks.DataSource = dtMarks


    End Sub

    Private Sub ShowMarkDateColumns(ByVal HasDates As Boolean)
        On Error Resume Next
        'For some reason, dates can get exluded from a layout and then they're not avaiable, period.
        'So we'll decide whether to show them or not AFTER the layout is loaded.

        If HasDates = True Then
            With Me.grdMarks.RootTable
                ' make sure these weren't hosed by a previous layout
                If .Columns.Contains("DateName") = False Then
                    .Columns.Add("DateName")
                End If

                If .Columns.Contains("TrademarkDate") = False Then
                    .Columns.Add("TrademarkDate")
                End If

                If .Columns.Contains("NoMonth") = False Then
                    .Columns.Add("NoMonth")
                End If

                If .Columns.Contains("NoDay") = False Then
                    .Columns.Add("NoDay")
                End If

                If .Columns.Contains("Completed") = False Then
                    .Columns.Add("Completed")
                    .Columns("Completed").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                    .Columns("Completed").ShowInFieldChooser = True
                    .Columns("Completed").Caption = "Compl."
                    .Columns("Completed").Width = 45
                End If

                .Columns("DateName").Visible = True
                .Columns("DateName").ShowInFieldChooser = True
                .Columns("DateName").Caption = "Date Name"
                .Columns("TrademarkDate").Visible = True
                .Columns("TrademarkDate").ShowInFieldChooser = True
                .Columns("TrademarkDate").Caption = "Date"

                If RevaSettings.USADates = True Then
                    Me.grdMarks.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
                Else
                    Me.grdMarks.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
                End If

                ' No need to ever show these
                .Columns("NoMonth").Visible = False
                .Columns("NoMonth").ShowInFieldChooser = False
                .Columns("NoDay").Visible = False
                .Columns("NoDay").ShowInFieldChooser = False
                .Columns("TrademarkID").ShowInFieldChooser = False
            End With

        Else
            With Me.grdMarks.RootTable
                If .Columns.Contains("DateName") = True Then
                    .Columns("DateName").Visible = False
                    .Columns("DateName").ShowInFieldChooser = False
                End If

                If .Columns.Contains("TrademarkDate") = True Then
                    .Columns("TrademarkDate").Visible = False
                    .Columns("TrademarkDate").ShowInFieldChooser = False
                End If

                If .Columns.Contains("NoMonth") = True Then
                    .Columns("NoMonth").Visible = False
                    .Columns("NoMonth").ShowInFieldChooser = False
                End If

                If .Columns.Contains("NoDay") = True Then
                    .Columns("NoDay").Visible = False
                    .Columns("NoDay").ShowInFieldChooser = False
                End If

                If .Columns.Contains("Completed") = True Then
                    .Columns("Completed").Visible = False
                    .Columns("Completed").ShowInFieldChooser = False
                End If

                .Columns("TrademarkID").ShowInFieldChooser = False
            End With
        End If
    End Sub


    Private Sub btnGetMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMarks.Click
        On Error Resume Next
        PreviewMarks()
    End Sub

    Private Sub chkMarkRelated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkRelated.CheckedChanged
        On Error Resume Next
        PreviewMarks()
    End Sub

    Private Sub chkMarkAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkAlerts.CheckedChanged
        On Error Resume Next
        With Me
            If .chkMarkAlerts.Checked = True Then
                .MarkAlertsFrom.Visible = True
                .MarkAlertsTo.Visible = True
                .lblMarkFrom.Visible = True
                .lblMarkTo.Visible = True
                .chkMarkDateFilters.Checked = False
            Else
                .MarkAlertsFrom.Visible = False
                .MarkAlertsTo.Visible = False
                .lblMarkFrom.Visible = False
                .lblMarkTo.Visible = False
            End If
        End With
    End Sub

    Private Sub grdMarkReports_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarkReports.RecordUpdated
        On Error Resume Next
        rsMarkReports.Update()
    End Sub

    Private Function GetTrademarkFilters(ByVal AddSelectedDates As Boolean) As String
        On Error Resume Next
        Dim strFilter As String, i As Integer, FilterRows As Object(), GRow As Janus.Windows.GridEX.GridEXRow,
            bDateFilters As Boolean, bRowDateFilter As Boolean, bDatesSelected As Boolean, dtLinkedCompanies As DataTable,
            LinkedCompanies As DataRow(), dRow As DataRow, j As Integer

        With Me

            If .chkMarkRelated.Checked = True Then
                dtLinkedCompanies = DataStuff.GetDataTable("Select * from qvwLinkedCompanies where LinkCompanyID >0")
            End If

            strFilter = " where TrademarkID <> 0 and (StatusID in ("

            '=============================================================================
            'look for status filter; if none, include only where ShowOnReports = true
            If (.cboMarkStatus.CheckedValues Is Nothing) Or (.chkMarkStatus.Checked = False) Then
                For i = 0 To dtTrademarkStatus.Rows.Count - 1
                    dRow = dtTrademarkStatus.Rows(i)
                    If dRow("ShowOnReports") = True Then
                        strFilter = strFilter & dRow("StatusID") & ", "
                    End If
                Next
                strFilter = strFilter & "0) or StatusID is null)"
            Else
                Dim bIncludeNull As Boolean
                bIncludeNull = False
                FilterRows = .cboMarkStatus.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                    If FilterRows(i) = 0 Then
                        bIncludeNull = True
                    End If
                Next
                If bIncludeNull = False Then
                    strFilter = strFilter & "0))"
                Else
                    strFilter = strFilter & "0) or StatusID is null)"
                End If
            End If

            '=============================================================================
            'look for company filter

            If (.cboMarkCompanies.CheckedValues Is Nothing) Or (.chkMarkCompanies.Checked = False) Then
                'no filter applied
            Else

                strFilter = strFilter & " and CompanyID in ("
                FilterRows = .cboMarkCompanies.CheckedValues

                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "

                    If .chkMarkRelated.Checked = True Then
                        LinkedCompanies = dtLinkedCompanies.Select("LinkCompanyID=" & FilterRows(i).ToString)
                        For j = 0 To LinkedCompanies.Length - 1
                            dRow = LinkedCompanies(j)
                            strFilter = strFilter & dRow("CompanyID") & ","
                        Next
                    End If
                Next

                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for jurisdiction filter
            If (.cboMarkJurisdictions.CheckedValues Is Nothing) Or (.chkMarkJurisdictions.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and JurisdictionID in ("
                FilterRows = .cboMarkJurisdictions.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for filingbasis filter
            If (.cboMarkFilingBasis.CheckedValues Is Nothing) Or (.chkMarkFilingBasis.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and FilingBasisID in ("
                FilterRows = .cboMarkFilingBasis.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for RegType filter
            If (.cboMarkRegTypes.CheckedValues Is Nothing) Or (.chkMarkRegTypes.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and RegTypeID in ("
                FilterRows = .cboMarkRegTypes.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for classes filter
            If (.cboMarkClasses.CheckedValues Is Nothing) Or (.chkMarkClasses.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and RegClassID in ("
                FilterRows = .cboMarkClasses.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '============= Position/Contact Filter ======================================
            If (.cboMarkContact.SelectedIndex >= 0) And (.cboMarkPosition.SelectedIndex >= 0) _
                And (.chkMarkPositions.Checked = True) Then
                strFilter = strFilter & " and ContactID=" & cboMarkContact.Value & " and PositionID=" & cboMarkPosition.Value
            End If
            '=============================================================================

            'see if date filters were applied and if dates are selected to print
            bDateFilters = False
            bDatesSelected = False
            If .chkMarkDateFilters.Checked = True Then
                For i = 0 To Me.grdMarkDates.RowCount - 1
                    GRow = grdMarkDates.GetRow(i)
                    With GRow
                        If .RowType = Janus.Windows.GridEX.RowType.Record Then
                            If IsDate(.Cells("DateFrom").Value) Then bDateFilters = True
                            If IsDate(.Cells("DateTo").Value) Then bDateFilters = True
                            If (.Cells("Completed").Value) <> 2 Then bDateFilters = True
                            If .Cells("Selected").Value = True Then bDatesSelected = True
                        End If
                    End With
                Next
            End If

            If bDateFilters = True Then
                'August 2010 -- switching from AND to OR for the date filters
                strFilter = strFilter & " and TrademarkID in (Select TrademarkID from " &
                    "tblTrademarkDates where ((TrademarkID = 0) "
                For i = 0 To Me.grdMarkDates.RowCount - 1
                    GRow = grdMarkDates.GetRow(i)
                    With GRow
                        If .RowType = Janus.Windows.GridEX.RowType.Record Then

                            'does this row have a filter?
                            bRowDateFilter = False
                            If IsDate(.Cells("DateFrom").Value) Then bRowDateFilter = True
                            If IsDate(.Cells("DateTo").Value) Then bRowDateFilter = True
                            If (.Cells("Completed").Value) <> 2 Then bRowDateFilter = True

                            'if so, proceed with caution
                            If bRowDateFilter = True Then
                                'strFilter = strFilter & " and TrademarkID in (Select TrademarkID from " & _
                                '    "tblTrademarkDates where DateID=" & .Cells("DateID").Value

                                strFilter = strFilter & " or (DateID=" & .Cells("DateID").Value

                                If IsDate(.Cells("DateFrom").Value) Then
                                    strFilter = strFilter & " and TrademarkDate >=" & FixDate(.Cells("DateFrom").Text)
                                End If

                                If IsDate(.Cells("DateTo").Value) Then
                                    strFilter = strFilter & " and TrademarkDate <=" & FixDate(.Cells("DateTo").Text)
                                End If

                                If (.Cells("Completed").Value) <> 2 Then
                                    strFilter = strFilter & " and Completed" &
                                    IIf(.Cells("Completed").Value = 0, "=0", "<>0")
                                End If
                                strFilter = strFilter & ")"
                            End If   'if there's a row filter
                        End If   'if it's a record row
                    End With
                Next
                strFilter = strFilter & "))"
            End If  'if there are date filters

            ' Now add selected dates to recordset if necessary for reports that print dates
            If (AddSelectedDates = True And bDatesSelected = True) Then
                strFilter = strFilter & " and DateID in ("
                For i = 0 To .grdMarkDates.RowCount - 1
                    GRow = grdMarkDates.GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        If GRow.Cells("Selected").Value = True Then
                            strFilter = strFilter & GRow.Cells("DateID").Value & ","
                        End If
                    End If
                Next
                strFilter = strFilter & "0)"
            End If

            'NEW August 2010 -- simple alerts filter option
            If .chkMarkAlerts.Checked = True Then
                strFilter = strFilter & " and TrademarkDate >=" & FixDate(.MarkAlertsFrom.Text) &
                    " and TrademarkDate <=" & FixDate(.MarkAlertsTo.Text) & " and DateID in " &
                    "(Select DateID from tblDatesTemplate WHERE IsAlert <> 0)"
            End If
        End With

        GetTrademarkFilters = strFilter
        'MsgBox(strFilter)

    End Function

    Friend Function GetTrademarksToPrint() As String
        On Error Resume Next
        Dim strFilter As String, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow

        strFilter = " where TrademarkID in ("
        'get list of trademark IDs that are in the preview grid; GetTrademarkFilters already has selected
        'the marks that fit the user's filter selections.
        For i = 0 To Me.grdMarks.RowCount - 1
            GRow = Me.grdMarks.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("TrademarkID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"
        GetTrademarksToPrint = strFilter
    End Function

    Private Function GetDatesToPrint() As String
        On Error Resume Next
        Dim strFilter As String, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, bDateSelected As Boolean
        strFilter = ""
        bDateSelected = False
        If Me.chkMarkDateFilters.Checked = True Then

            'make sure a filter has been applied or a date has been checked
            For i = 0 To Me.grdMarkDates.RowCount - 1
                GRow = Me.grdMarkDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    If GRow.Cells("Selected").Value = True Then
                        bDateSelected = True
                    End If
                End If
            Next

            If bDateSelected = True Then
                strFilter = " and ((DateID = 0)"
                'get list of Dates that are selected in the Date Filters grid.
                For i = 0 To Me.grdMarkDates.RowCount - 1
                    GRow = Me.grdMarkDates.GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        If GRow.Cells("Selected").Value = True Then

                            strFilter = strFilter & " or (DateID =" & GRow.Cells("DateID").Value

                            If IsDate(GRow.Cells("DateFrom").Text) Then
                                strFilter = strFilter & " and TrademarkDate >=" &
                                FixDate(GRow.Cells("DateFrom").Text)
                            End If

                            If IsDate(GRow.Cells("DateTo").Text) Then
                                strFilter = strFilter & " and TrademarkDate <=" &
                                FixDate(GRow.Cells("DateTo").Text)
                            End If

                            If (GRow.Cells("Completed").Value) <> 2 Then
                                strFilter = strFilter & " and Completed" &
                                IIf(GRow.Cells("Completed").Value = 0, "=0", "<>0")
                            End If

                            strFilter = strFilter & ")"

                        End If
                    End If

                Next
                strFilter = strFilter & ")"
            End If
        End If

        If Me.chkMarkAlerts.Checked = True Then
            'strFilter = " and DateID in (Select DateID from tblDatesTemplate where IsAlert <> 0)"
            strFilter = " and (TrademarkDate >=" & FixDate(Me.MarkAlertsFrom.Text) &
                    " and TrademarkDate <=" & FixDate(Me.MarkAlertsTo.Text) & " and DateID in " &
                    "(Select DateID from tblDatesTemplate WHERE IsAlert <> 0))"
        End If

        GetDatesToPrint = strFilter
        'MsgBox(strFilter)

    End Function

    Private Sub grdMarkReports_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdMarkReports.CellValueChanged
        On Error Resume Next
        Dim bReportSelected As Boolean = False, LayoutName As String = String.Empty

        'start by assuming the Positions button isn't necessary -- it's only for exports to Word/XL.
        Me.btnMarkPositions.Visible = False

        If e.Column.Key = "Selected" Then
            If Me.grdMarkReports.GetValue("Selected") = True Then
                bReportSelected = True
                Dim iRow As Integer, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
                iRow = Me.grdMarkReports.Row
                For i = 0 To Me.grdMarkReports.RowCount - 1
                    If iRow <> i Then
                        GRow = Me.grdMarkReports.GetRow(i)
                        GRow.BeginEdit()
                        GRow.Cells("Selected").Value = False
                        GRow.EndEdit()
                    End If
                Next

                LayoutName = Me.grdMarkReports.GetValue("ReportLayout") & ""
                ' So user has to preview when selecting a report with a different layout.  Otherwise, the layouts would be wrong.
                If LayoutName <> LastMarkLayout Then
                    Me.grdMarks.RemoveFilters()
                    Me.grdMarks.DataSource = Nothing
                End If

                'if Word/Excel is selected, show positions button
                If (LayoutName = "MarkExportWordLayout") Or (LayoutName = "MarkExportExcelLayout") Then
                    Me.btnMarkPositions.Visible = True
                End If

                ' if it's next due date report, automatically 
                If LayoutName = "MarkNextDueDateLayout" Then
                    Me.chkMarkDateFilters.Checked = True
                End If

            End If

            Me.btnGetMarks.Enabled = bReportSelected
            Me.btnPrintMarkReport.Enabled = ((Me.grdMarks.RowCount > 0) And (bReportSelected))

        End If
    End Sub

    Private Sub grdMarks_GroupsChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.GroupsChangedEventArgs) Handles grdMarks.GroupsChanged
        On Error Resume Next
        SetMarkReportMargin()
        Me.chkMarkGroupNewPage.Visible = Me.grdMarks.RootTable.Groups.Count > 0
        ' don't want user to create more groups than exist on report
        Me.grdMarks.RootTable.AllowGroup = Me.grdMarks.RootTable.Groups.Count < 2
    End Sub

    Private Sub SetMarkReportMargin()
        On Error Resume Next
        'because when we create groups, the root table columns move left a bit.
        'the idea is that the columns within the margin marker all fit on the report
        If Me.grdMarks.RootTable.Groups.Count = 0 Then
            Me.lblMarkReportWidth.Left = 725
        End If

        If Me.grdMarks.RootTable.Groups.Count = 1 Then
            Me.lblMarkReportWidth.Left = 735
        End If

        If Me.grdMarks.RootTable.Groups.Count = 2 Then
            Me.lblMarkReportWidth.Left = 750
        End If
    End Sub

    Private Sub btnPrintMarkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintMarkReport.Click
        On Error Resume Next

        If Me.grdMarkReports.GetValue("Selected") = False Then
            MsgBox("You must select a report to print first.")
            Exit Sub
        End If

        If Me.grdMarks.RecordCount = 0 Then
            MsgBox("There are no trademarks in the preview grid. Click the Preview Trademarks button to see which " &
                       "trademarks match your filters.")
            Exit Sub
        End If

        ' Still here?  Okay, let's go ...
        Dim strReportName As String, strSQL As String, ReportTable As DataTable

        strReportName = Me.grdMarkReports.GetValue("ReportFileName")

        Select Case strReportName

            '============================== List reports ============================
            Case "rptTrademarksByNameList"
                Dim rptReport As New rptTrademarksListGroup
                ReportTable = DataStuff.GetTableFromGrid(Me.grdMarks, "TrademarkID", False)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptTrademarkDates"  'same report, different fields available
                Dim rptReport As New rptTrademarksListGroup
                ReportTable = DataStuff.GetTableFromGrid(Me.grdMarks, "TrademarkID", False)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            '============================== Formatted reports ============================
            Case "rptTrademarksByCompany"
                Dim rptReport As New rptTrademarksByCompany

                strSQL = SQL.vwReportTrademarks & GetTrademarksToPrint() & GetDatesToPrint() &
                    " order by CompanyName, CompanyID, TrademarkName, TrademarkID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptTrademarksAlpha"
                Dim rptReport As New rptTrademarksAlpha

                strSQL = SQL.vwReportTrademarks & GetTrademarksToPrint() & GetDatesToPrint() &
                    " order by TrademarkName, TrademarkID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptTrademarksByCompanyContacts"
                Dim rptReport As New rptTrademarksByCompanyContacts

                strSQL = "SELECT TrademarkName, Jurisdiction, ApplicationNumber, RegistrationNumber, " & vbCrLf &
                "TrademarkContactID, CompanyName, ContactName, ContactCompany, PositionName," & vbCrLf &
                "TrademarkID, PositionID, CompanyID, ContactID from qvwTrademarkContacts" & GetTrademarksToPrint() &
                " order by CompanyName, TrademarkName, TrademarkID, ContactName"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()


            Case "rptTrademarksByCompanyDates"
                Dim rptReport As New rptTrademarksByCompanyDates

                strSQL = SQL.vwReportTrademarks & GetTrademarksToPrint() & GetDatesToPrint() &
                    " order by qvwTrademarkDates.CompanyName, CompanyID, TrademarkName, TrademarkID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()


            Case "rptTrademarkActions"
                Dim rptReport As New rptTrademarkActions

                strSQL = "SELECT * from qvwTrademarkActions " & GetTrademarksToPrint() &
                " order by CompanyName, CompanyID, TrademarkName, TrademarkID, ActionDate"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()


            Case "rptTrademarksLicensed"
                Dim rptReport As New rptTrademarksLicensed

                strSQL = "Select * from qvwTrademarksLicensed" & GetTrademarksToPrint() &
                    " order by CompanyName, CompanyID, TrademarkName, TrademarkID, Licensee"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            '============================== Export reports ============================

            Case "MarkExportExcel"
                Dim ExcelExport As New Export
                ExcelExport.ExportTable = DataStuff.GetTableFromGrid(Me.grdMarks, "TrademarkName", True)

                If ExcelExport.ExportTable Is Nothing Then
                    MsgBox("Unable to create export table.")
                    Exit Sub
                Else
                    ExcelExport.CreateSpreadsheet()
                End If

            Case "MarkExportWord"
                Dim WordExport As New Export
                WordExport.ExportTable = DataStuff.GetTableFromGrid(Me.grdMarks, "TrademarkName", True)

                If WordExport.ExportTable Is Nothing Then
                    MsgBox("Unable to create export table.")
                    Exit Sub
                Else
                    WordExport.CreateWordTable()
                End If

            Case Else

        End Select

        ' user may have made field/order changes, so save layout
        SaveMarkReportLayout()

    End Sub


#End Region

#Region "Patent Filter Settings"

    'BIG CHANGE:  Now we don't fill any of the filter grids until the user enables a filter.
    'The exception is Status, because we want to filter down to ShowOnReports = true 
    'if no status is selected as a filter.

    Private Sub chkPatentCompanies_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentCompanies.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentCompanies.Enabled = .chkPatentCompanies.Checked
            If .cboPatentCompanies.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select distinct CompanyID, CompanyName from qvwPatents Order by CompanyName"
                .cboPatentCompanies.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkPatentCompanies.Checked = True Then .cboPatentCompanies.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentJurisdictions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentJurisdictions.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentJurisdictions.Enabled = .chkPatentJurisdictions.Checked
            If .cboPatentJurisdictions.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsPatent <> 0 Order by Jurisdiction"
                .cboPatentJurisdictions.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkPatentJurisdictions.Checked = True Then .cboPatentJurisdictions.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentStatus.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentStatus.Enabled = .chkPatentStatus.Checked
            If .cboPatentStatus.DropDownDataSource Is Nothing Then
                'NOTE, IF NO STATUS SELECTED, REMEMBER TO EXCLUDE WHERE ShownOnReport = FALSE
                dtPatentStatus.Rows.Add(0, "(Blank Status)", 0, 0, 0, 0)
                .cboPatentStatus.DropDownDataSource = dtPatentStatus
            End If
            If .chkPatentStatus.Checked = True Then .cboPatentStatus.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentFilingBasis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentFilingBasis.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentFilingBasis.Enabled = .chkPatentFilingBasis.Checked
            If .cboPatentFilingBasis.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select FilingBasisID, FilingBasis from tblPatentFilingBasis Order by FilingBasisID"
                .cboPatentFilingBasis.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkPatentFilingBasis.Checked = True Then .cboPatentFilingBasis.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentTypes.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentTypes.Enabled = .chkPatentTypes.Checked
            If .cboPatentTypes.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select * from tblPatentTypes order by PatentType"
                .cboPatentTypes.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkPatentTypes.Checked = True Then .cboPatentTypes.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentClasses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentClasses.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentClasses.Enabled = .chkPatentClasses.Checked
            If .cboPatentClasses.DropDownDataSource Is Nothing Then
                Dim strSQL As String
                strSQL = "Select * from tblPatentClass order by PatentClass"
                .cboPatentClasses.DropDownDataSource = DataStuff.GetDataTable(strSQL)
            End If
            If .chkPatentClasses.Checked = True Then .cboPatentClasses.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentPositions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentPositions.CheckedChanged
        On Error Resume Next
        With Me
            .cboPatentPosition.Enabled = .chkPatentPositions.Checked
            .cboPatentContact.Enabled = .chkPatentPositions.Checked
            If .chkPatentPositions.Checked = True Then .cboPatentPosition.DroppedDown = True
        End With
    End Sub

    Private Sub chkPatentCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentCategory.CheckedChanged
        On Error Resume Next
        With Me
            .Category.Enabled = .chkPatentCategory.Checked = True
            .Subcategory.Enabled = .chkPatentCategory.Checked = True
            If .chkPatentCategory.Checked = True Then
                .Category.BackColor = Color.White
                .Subcategory.BackColor = Color.White
                .Category.BorderStyle = BorderStyle.FixedSingle
                .Subcategory.BorderStyle = BorderStyle.FixedSingle
                .Category.ReadOnly = False
                .Subcategory.ReadOnly = False
            Else
                .Category.BackColor = Color.WhiteSmoke
                .Subcategory.BackColor = Color.WhiteSmoke
                .Category.BorderStyle = BorderStyle.None
                .Subcategory.BorderStyle = BorderStyle.None
            End If
        End With
    End Sub

    Private Sub chkPatentPositions_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatentPosition.ValueChanged
        Dim iPositionID As Integer, dtContactList As DataTable, strSQL As String
        iPositionID = cboPatentPosition.Value
        If iPositionID > 0 Then
            strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwPatentContacts" &
                " where PositionID=" & iPositionID & " order by ContactName"
            dtContactList = DataStuff.GetDataTable(strSQL)
            Me.cboPatentContact.DataSource = dtContactList
            Me.cboPatentContact.SelectedIndex = -1
        End If
    End Sub

    Private Sub chkPatentDateFilters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentDateFilters.CheckedChanged
        On Error Resume Next
        Me.grdPatentDates.Visible = Me.chkPatentDateFilters.Checked
        If Me.chkPatentDateFilters.Checked = True Then
            Me.chkPatentAlerts.Checked = False
        End If
    End Sub

    Private Sub cboPatentPosition_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatentPosition.ValueChanged
        On Error Resume Next
        Dim iPositionID As Integer, dtContactList As DataTable, strSQL As String
        iPositionID = cboPatentPosition.Value
        If iPositionID > 0 Then
            strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwPatentContacts" &
                " where PositionID=" & iPositionID & " order by ContactName"
            dtContactList = DataStuff.GetDataTable(strSQL)
            Me.cboPatentContact.DataSource = dtContactList
        End If
    End Sub

    Private Sub grdPatentDates_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentDates.ColumnHeaderClick
        On Error Resume Next

        If e.Column.Key = "Selected" Then
            Dim bSelected As Boolean
            If Me.grdPatentDates.GetValue("Selected") = False Then
                SetSelected(Me.grdPatentDates, True)
            Else
                SetSelected(Me.grdPatentDates, False)
            End If
        End If

        If e.Column.Key = "Completed" Then
            Select Case Me.grdPatentDates.GetValue("Completed")
                Case 0
                    SetPatentDateCompleted(2)   'all
                Case 1
                    SetPatentDateCompleted(0)    'no
                Case Else
                    SetPatentDateCompleted(1)   'yes
            End Select
        End If

        If e.Column.Key = "DateFrom" Then
            On Error Resume Next
            Me.grdPatentDates.UpdateData()
            Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, dDateFrom As DateTime
            For i = 0 To Me.grdPatentDates.RowCount - 1

                GRow = Me.grdPatentDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then

                    If IsDate(GRow.Cells("DateFrom").Text) Then
                        dDateFrom = GRow.Cells("DateFrom").Value
                    End If

                    If GRow.Cells("Selected").Value = True Then
                        GRow.BeginEdit()
                        If dDateFrom <> Date.MinValue Then
                            GRow.Cells("DateFrom").Value = dDateFrom
                        End If
                        GRow.EndEdit()
                    Else
                        GRow.BeginEdit()
                        GRow.Cells("DateFrom").Value = DBNull.Value
                        GRow.EndEdit()
                    End If

                End If
            Next
        End If

        If e.Column.Key = "DateTo" Then
            On Error Resume Next
            Me.grdPatentDates.UpdateData()
            Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, dDateTo As DateTime
            For i = 0 To Me.grdPatentDates.RowCount - 1

                GRow = Me.grdPatentDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then

                    If IsDate(GRow.Cells("DateTo").Text) Then
                        dDateTo = GRow.Cells("DateTo").Value
                    End If

                    If GRow.Cells("Selected").Value = True Then
                        GRow.BeginEdit()
                        If dDateTo <> Date.MinValue Then
                            GRow.Cells("DateTo").Value = dDateTo
                        End If
                        GRow.EndEdit()
                    Else
                        GRow.BeginEdit()
                        GRow.Cells("DateTo").Value = DBNull.Value
                        GRow.EndEdit()
                    End If

                End If
            Next
        End If

    End Sub

    Private Sub SetPatentDateCompleted(ByVal iCompleted As Integer)
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.grdPatentDates.RowCount - 1
            GRow = Me.grdPatentDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("Completed").Value = iCompleted
                GRow.EndEdit()
            End If
        Next
    End Sub

    Private Sub btnResetPatentFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPatentFilters.Click
        On Error Resume Next
        ClearPatentDates()
        With Me
            .chkPatentCompanies.Checked = False
            .chkPatentJurisdictions.Checked = False
            .chkPatentStatus.Checked = False
            .chkPatentFilingBasis.Checked = False
            .chkPatentTypes.Checked = False
            .chkPatentClasses.Checked = False
            .chkPatentPositions.Checked = False
            .chkPatentDateFilters.Checked = False
            .chkPatentAlerts.Checked = False
            .chkPatentCategory.Checked = False
            .Category.Text = ""
            .Subcategory.Text = ""

            .cboPatentCompanies.UncheckAll()
            .cboPatentJurisdictions.UncheckAll()
            .cboPatentStatus.UncheckAll()
            .cboPatentFilingBasis.UncheckAll()
            .cboPatentTypes.UncheckAll()
            .cboPatentClasses.UncheckAll()
            .cboPatentPosition.SelectedIndex = -1
            .cboPatentContact.SelectedIndex = -1
            .grdPatents.DataSource = Nothing
            .grdPatents.RemoveFilters()
            .PatentFilterID.SelectedIndex = -1
            .btnPrintPatentReport.Enabled = False
        End With

    End Sub

    Private Sub ClearPatentDates()
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.grdPatentDates.RowCount - 1
            GRow = Me.grdPatentDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                GRow.Cells("DateFrom").Value = DBNull.Value
                GRow.Cells("DateTo").Value = DBNull.Value
                GRow.Cells("Selected").Value = False
                GRow.Cells("Completed").Value = 2
                GRow.EndEdit()
            End If
        Next
    End Sub

    ' =================== New Sept. 2013, allow loading/saving stored filters ===============

    Private Sub btnPatentFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentFilter.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(12)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnSavePatentFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePatentFilters.Click
        On Error Resume Next
        If Me.PatentFilterID.Text.Length < 3 Then
            MsgBox("To save a filter, you must first select a filter name in the drop-down list.  To create new filter names, click the Stored Filter hyperlink.")
            Exit Sub
        End If

        If MsgBox("The selected filter values will be saved as " & Me.PatentFilterID.Text & ". Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ' If we're still here, it's time to save all those values.  Start by clearing any previous ones.
        Dim strSQL As String, rsFilterValues As New RecordSet, iFilterID As Integer
        Dim i As Integer, FilterRows As Object(), GRow As Janus.Windows.GridEX.GridEXRow

        iFilterID = Me.PatentFilterID.Value
        strSQL = "Delete from tblFilterValues where FilterID=" & iFilterID
        DataStuff.RunDemoSQL(strSQL)
        rsFilterValues.GetFromDemo("Select * from tblFilterValues where FilterID=" & iFilterID)

        With Me
            ' write selected company values
            If Not (.cboPatentCompanies.CheckedValues Is Nothing) And (.chkPatentCompanies.Checked = True) Then
                FilterRows = .cboPatentCompanies.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    'MsgBox(FilterRows(i).ToString)
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "CompanyID"
                    End With
                Next
            End If

            'jurisdiction values
            If Not (.cboPatentJurisdictions.CheckedValues Is Nothing) And (.chkPatentJurisdictions.Checked = True) Then
                FilterRows = .cboPatentJurisdictions.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "JurisdictionID"
                    End With
                Next
            End If

            'Status values
            If Not (.cboPatentStatus.CheckedValues Is Nothing) And (.chkPatentStatus.Checked = True) Then
                FilterRows = .cboPatentStatus.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "StatusID"
                    End With
                Next
            End If

            'FilingBasis values
            If Not (.cboPatentFilingBasis.CheckedValues Is Nothing) And (.chkPatentFilingBasis.Checked = True) Then
                FilterRows = .cboPatentFilingBasis.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "FilingBasisID"
                    End With
                Next
            End If

            'Patent Type values
            If Not (.cboPatentTypes.CheckedValues Is Nothing) And (.chkPatentTypes.Checked = True) Then
                FilterRows = .cboPatentTypes.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "PatentTypeID"
                    End With
                Next
            End If

            'Patent Class values
            If Not (.cboPatentClasses.CheckedValues Is Nothing) And (.chkPatentClasses.Checked = True) Then
                FilterRows = .cboPatentClasses.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    rsFilterValues.AddRow()
                    With rsFilterValues.CurrentRow
                        .Item("FilterID") = iFilterID
                        .Item("IntegerValue") = FilterRows(i)
                        .Item("FieldName") = "PatentClassID"
                    End With
                Next
            End If

            'Position values
            If Not (.cboPatentPosition.SelectedIndex = -1) And (.chkPatentPositions.Checked = True) Then
                rsFilterValues.AddRow()
                With rsFilterValues.CurrentRow
                    .Item("FilterID") = iFilterID
                    .Item("IntegerValue") = Me.cboPatentPosition.Value
                    .Item("FieldName") = "PositionID"
                End With
            End If

            'Contact values
            If Not (.cboPatentContact.SelectedIndex = -1) Then
                rsFilterValues.AddRow()
                With rsFilterValues.CurrentRow
                    .Item("FilterID") = iFilterID
                    .Item("IntegerValue") = Me.cboPatentContact.Value
                    .Item("FieldName") = "ContactID"
                End With
            End If

            ' Date Selections
            If .chkPatentDateFilters.Checked = True Then
                ' first make sure grid is updated
                Me.grdPatentDates.UpdateData()
                For i = 0 To Me.grdPatentDates.RowCount - 1
                    GRow = grdPatentDates.GetRow(i)
                    With rsFilterValues
                        If (GRow.RowType = Janus.Windows.GridEX.RowType.Record) And (GRow.Cells("Selected").Value = True) Then
                            .AddRow()
                            .CurrentRow.Item("FilterID") = iFilterID
                            .CurrentRow.Item("IsSelected") = True
                            .CurrentRow.Item("DateID") = GRow.Cells("DateID").Value
                            ' we store completed drop-down value in Integer Value
                            .CurrentRow.Item("IntegerValue") = GRow.Cells("Completed").Value

                            If IsDate(GRow.Cells("DateFrom").Value) Then
                                .CurrentRow.Item("DateFrom") = GRow.Cells("DateFrom").Value
                            End If

                            If IsDate(GRow.Cells("DateTo").Value) Then
                                .CurrentRow.Item("DateTo") = GRow.Cells("DateTo").Value
                            End If
                        End If
                    End With 'with rsFilterValues
                Next
            End If
        End With

        rsFilterValues.Update()
        MsgBox("Stored filter saved.")

    End Sub

    Private Sub PatentFilterID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatentFilterID.ValueChanged
        On Error Resume Next
        ' don't bother if a real filter isn't selected
        If Me.PatentFilterID.SelectedIndex < 0 Then
            Exit Sub
        End If

        Dim dtFilters As DataTable, strSQL As String, iFilterID As Integer, i As Integer
        Dim SelectedValues As New ArrayList, GRow As Janus.Windows.GridEX.GridEXRow


        iFilterID = Me.PatentFilterID.Value
        dtFilters = DataStuff.GetDemoTable("Select * from tblFilterValues where FilterID=" & iFilterID & " order by DateID, FieldName")

        ' could be a new filter, don't want to clear selections
        If dtFilters.Rows.Count = 0 Then
            Exit Sub
        End If

        With Me
            .chkPatentCompanies.Checked = False
            .chkPatentJurisdictions.Checked = False
            .chkPatentStatus.Checked = False
            .chkPatentFilingBasis.Checked = False
            .chkPatentTypes.Checked = False
            .chkPatentClasses.Checked = False
            .chkPatentPositions.Checked = False
            .chkPatentDateFilters.Checked = False
            .cboPatentCompanies.UncheckAll()
            .cboPatentJurisdictions.UncheckAll()
            .cboPatentStatus.UncheckAll()
            .cboPatentFilingBasis.UncheckAll()
            .cboPatentTypes.UncheckAll()
            .cboPatentClasses.UncheckAll()
            .cboPatentPosition.SelectedIndex = -1
            .cboPatentContact.SelectedIndex = -1
            .chkPatentDateFilters.Checked = False
        End With

        ' Companies
        i = dtFilters.Rows.Count
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "CompanyID" Then
                Me.chkPatentCompanies.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentCompanies.CheckedValues = SelectedValues.ToArray
        End If

        'Jurisdictions
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "JurisdictionID" Then
                Me.chkPatentJurisdictions.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentJurisdictions.CheckedValues = SelectedValues.ToArray
        End If

        'Status
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "StatusID" Then
                Me.chkPatentStatus.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentStatus.CheckedValues = SelectedValues.ToArray
        End If

        'Filing Basis
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "FilingBasisID" Then
                Me.chkPatentFilingBasis.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentFilingBasis.CheckedValues = SelectedValues.ToArray
        End If

        'Patent Type
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "PatentTypeID" Then
                Me.chkPatentTypes.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentTypes.CheckedValues = SelectedValues.ToArray
        End If

        'Patent Class
        SelectedValues.Clear()
        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "PatentClassID" Then
                Me.chkPatentClasses.Checked = True
                SelectedValues.Add(dr("IntegerValue"))
            End If
        Next
        If SelectedValues.Count > 0 Then
            Me.cboPatentClasses.CheckedValues = SelectedValues.ToArray
        End If

        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "PositionID" Then
                Me.chkPatentPositions.Checked = True
                Me.cboPatentPosition.Value = dr("IntegerValue")
            End If
        Next

        For Each dr As DataRow In dtFilters.Rows
            If dr("FieldName").ToString = "ContactID" Then
                Me.cboPatentContact.Value = dr("IntegerValue")
            End If
        Next

        'otherwise they stay dropped down ... weird
        Me.cboPatentPosition.DroppedDown = False
        Me.cboPatentContact.DroppedDown = False

        ClearPatentDates()

        For Each dr As DataRow In dtFilters.Rows
            If Nz(dr("DateID"), 0) > 0 Then
                Me.chkPatentDateFilters.Checked = True

                With Me.grdPatentDates
                    For i = 0 To .RowCount - 1
                        GRow = .GetRow(i)
                        If GRow.Cells("DateID").Value = dr("DateID") Then
                            GRow.BeginEdit()
                            GRow.Cells("Selected").Value = dr("IsSelected")
                            GRow.Cells("DateFrom").Value = dr("DateFrom")
                            GRow.Cells("DateTo").Value = dr("DateTo")
                            GRow.Cells("Completed").Value = dr("IntegerValue")
                            GRow.EndEdit()
                        End If
                    Next
                End With

            End If
        Next

        Me.PatentFilterID.Focus()

    End Sub

#End Region

#Region "Patent Custom Fields"

    'So we don't force a new previous for the same filters, same layout
    Dim LastPatentLayout As String

    Private Sub btnPatentChooseColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentChooseColumns.Click
        On Error Resume Next
        Me.grdPatents.HideFieldChooser()
        Me.grdPatents.ShowFieldChooser()
        Me.grdPatents.RootTable.Columns("PatentID").ShowInFieldChooser = False
    End Sub

    Private Sub btnPatentPositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatentPositions.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(6)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub SavePatentReportLayout()
        On Error Resume Next
        Dim LayoutName As String
        LayoutName = Me.grdPatentReports.GetValue("ReportLayout") & ""

        If Not (My.Settings.Item(LayoutName) Is Nothing) Then
            My.Settings.Item(LayoutName) = Me.grdPatents.GetLayout.GetXmlString

        End If

    End Sub

    Private Sub LoadPatentReportLayout()
        On Error Resume Next
        Dim LayoutName As String, strColumnName As String
        LayoutName = Me.grdPatentReports.GetValue("ReportLayout") & ""

        If Not (My.Settings.Item(LayoutName) Is Nothing) Then
            If (My.Settings.Item(LayoutName).Length > 100) Then
                Me.grdPatents.LoadLayout(Janus.Windows.GridEX.GridEXLayout.FromXMLString(My.Settings.Item(LayoutName)))
                LastPatentLayout = LayoutName
            End If
        End If

        If (dtPatents Is Nothing) Or (dtPatents.Rows.Count = 0) Then Exit Sub

        'Remove any columns that shouldn't show up in the grid or field chooser
        For Each gridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdPatents.RootTable.Columns
            strColumnName = gridCol.Key
            If dtPatents.Columns.Contains(strColumnName) = False Then
                gridCol.ShowInFieldChooser = False
                gridCol.Visible = False
            End If
        Next

    End Sub

    Private Sub ResetPatentColumn(ByVal ColumnKey As String, ByVal iPos As Integer, ByVal iWidth As Integer, ByVal isVisible As Boolean)
        With Me.grdPatents.RootTable
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
        For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdPatents.RootTable.Columns
            GridCol.Visible = False
            GridCol.ShowInFieldChooser = False
        Next

        ResetPatentColumn("PatentID", 0, 100, False)
        ResetPatentColumn("CompanyName", 1, 175, True)
        ResetPatentColumn("PatentName", 2, 150, True)
        ResetPatentColumn("Jurisdiction", 3, 100, True)
        ResetPatentColumn("ApplicationNumber", 4, 80, True)
        ResetPatentColumn("PatentNumber", 5, 80, True)
        ResetPatentColumn("OurDocket", 6, 100, True)
        ResetPatentColumn("ClientDocket", 7, 100, False)
        ResetPatentColumn("Status", 8, 80, True)
        ResetPatentColumn("PatentType", 9, 100, False)
        ResetPatentColumn("FileNumber", 10, 100, False)
        ResetPatentColumn("FilingBasis", 11, 100, False)
        ResetPatentColumn("Category", 12, 100, False)
        ResetPatentColumn("SubCategory", 13, 100, False)
        ResetPatentColumn("Claims", 14, 100, False)

        If dtPatents.Columns.Contains("DateName") Then
            ResetPatentColumn("DateName", 15, 100, True)
            ResetPatentColumn("PatentDate", 16, 100, True)
        End If
        Me.grdPatents.RootTable.Columns("PatentID").ShowInFieldChooser = False

    End Sub

#End Region

#Region "Patent Reports"

    Private Sub grdPatentReports_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdPatentReports.FormattingRow
        On Error Resume Next
        e.Row.Cells("ReportName").ToolTipText = e.Row.Cells("UserFields").Text & " user-selected fields."
    End Sub

    Private Sub grdPatents_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatents.LinkClicked
        On Error Resume Next
        If (e.Column.Key = "PatentName") Then
            Globals.PatentID = Me.grdPatents.GetValue("PatentID")
            Globals.NavigatePatentsFrom = 3
            AllForms.OpenPatents()
            AllForms.frmPatents.GetPatent()
            AllForms.frmPatents.Tabs.SelectedIndex = 1
        End If
    End Sub

    Private Sub PreviewPatents()
        On Error Resume Next
        Dim strReportName As String, strReportLayout As String
        strReportName = Me.grdPatentReports.GetValue("ReportFileName")
        strReportLayout = Me.grdPatentReports.GetValue("ReportFileName")

        'becuz user may have added fields to grid and then hit preview again
        Me.grdPatents.RemoveFilters()
        If Me.grdPatents.RowCount > 0 Then
            SavePatentReportLayout()
        End If

        With Me
            .grdPatents.RemoveFilters()
            .Cursor = Cursors.WaitCursor

            Select Case strReportName

                '============================== List reports ============================
                Case "rptPatentsByNameList"
                    If strReportLayout = "rptPatentsListLayout" Then

                        GetPatentsList()
                        LoadPatentReportLayout()
                        ShowPatentDateColumns(False)
                    Else
                        GetPatentsListNextDueDate()
                        LoadPatentReportLayout()
                        ShowPatentDateColumns(True)
                    End If

                    .grdPatents.GroupByBoxVisible = True
                    .grdPatents.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True
                    .lblPatentReportWidth.Visible = True
                    SetPatentReportMargin()

                Case "rptPatentsByNameList"
                    ' GetPatentsList pulls most Patent fields and can be used as a recordset for list reports

                    GetPatentsList()
                    LoadPatentReportLayout()
                    ShowPatentDateColumns(False)
                    .grdPatents.GroupByBoxVisible = True
                    .grdPatents.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True
                    .lblPatentReportWidth.Visible = True
                    SetPatentReportMargin()

                Case "rptPatentDates"
                    ' GetPatentsList pulls most Patent field and the selected date fields 
                    ' and can be used as a recordset for list reports
                    GetPatentsListWithDates()
                    LoadPatentReportLayout()
                    ShowPatentDateColumns(True)
                    .grdPatents.GroupByBoxVisible = True
                    .grdPatents.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True
                    .lblPatentReportWidth.Visible = True
                    SetPatentReportMargin()

                Case "rptPatentsByCompanyList"
                    GetPatentsList()
                    LoadPatentReportLayout()
                    ShowPatentDateColumns(True)
                    .grdPatents.GroupByBoxVisible = False
                    .lblPatentReportWidth.Visible = True
                    SetPatentReportMargin()

                '============================== Formatted reports ============================
                Case "rptPatentsByCompany", "rptPatentsAlpha", "rptPatentsByCompanyContacts",
                    "rptPatentsByNameList", "rptPatentsByCompanyDates", "rptPatentActions",
                    "rptPatentActions", "rptPatentsLicensed"

                    GetPatentsList()
                    LoadPatentReportLayout()
                    ShowPatentDateColumns(False)
                    .grdPatents.GroupByBoxVisible = False
                    .grdPatents.RootTable.Groups.Clear()
                    .lblPatentReportWidth.Visible = False

                '============================== Export reports ============================
                ' For these we have to load the layout FIRST, since we'll need to add/remove date and position columns after the fact
                Case "PatentExportExcel"
                    LoadPatentReportLayout()
                    GetPatentsForExport(True)
                    ShowPatentDateColumns(False)
                    .grdPatents.GroupByBoxVisible = False
                    .grdPatents.RootTable.Groups.Clear()
                    .lblPatentReportWidth.Visible = False

                Case "PatentExportWord"
                    LoadPatentReportLayout()
                    GetPatentsForExport(False)
                    ShowPatentDateColumns(False)
                    .grdPatents.GroupByBoxVisible = False
                    .grdPatents.RootTable.Groups.Clear()
                    .lblPatentReportWidth.Visible = False

                Case Else

            End Select

            If .grdPatents.RowCount > 0 Then
                .btnPatentChooseColumns.Enabled = True
                .grdPatents.ScrollBars = Janus.Windows.GridEX.ScrollBars.Automatic
                .btnPrintPatentReport.Enabled = True
                .grdPatents.Row = 0
                .chkPatentGroupNewPage.Visible = .grdPatents.RootTable.Groups.Count > 0
            End If
            .Cursor = Cursors.Default

        End With
    End Sub

    Private Sub GetPatentsList()
        On Error Resume Next
        Dim strSQL As String

        strSQL = "Select distinct PatentID, PatentName, PatentType, CompanyName, Jurisdiction, ApplicationNumber, " &
        "PatentNumber, Status, FilingBasis, FileNumber, OurDocket, ClientDocket, Claims, Category, Subcategory " &
        "from qvwPatentsFullList " & GetPatentFilters(False)

        dtPatents = DataStuff.GetDataTable(strSQL)
        Me.grdPatents.DataSource = dtPatents

    End Sub

    Private Sub GetPatentsListWithDates()
        On Error Resume Next
        Dim strSQL As String

        strSQL = "Select distinct PatentID, PatentName, PatentType, CompanyName, Jurisdiction, ApplicationNumber, " &
        "PatentNumber, Status, FilingBasis, FileNumber, PatentType, OurDocket, ClientDocket, Claims, Category, Subcategory, " &
        "DateName, PatentDate, NoDay, NoMonth, Completed from qvwPatentsFullList " & GetPatentFilters(True)

        dtPatents = DataStuff.GetDataTable(strSQL)
        Me.grdPatents.DataSource = dtPatents

    End Sub

    Private Sub GetPatentsListNextDueDate()
        On Error Resume Next
        Dim strFilter As String, i As Integer, Grow As Janus.Windows.GridEX.GridEXRow, strSQL As String

        ' This gets just the list of dates selected to appear in Next Due Date. There are no actual date filters.
        strFilter = "where Completed = 0 and DateID in ("

        For i = 0 To Me.grdPatentDates.RowCount - 1
            Grow = grdPatentDates.GetRow(i)
            If Grow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If Grow.Cells("Selected").Value = True Then
                    strFilter = strFilter & Grow.Cells("DateID").Value & ","
                End If
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = "select distinct qvwPatentDates.PatentID as PatentID, PatentDateID, PatentName, PatentType, Jurisdiction, ApplicationNumber, PatentNumber," &
        " Status, GraphicPath, OurDocket, ClientDocket, DateName, Q.PatentDate as PatentDate from qvwPatentDates " &
        " inner join (Select PatentID as PatID, Min(PatentDate) as PatentDate from tblPatentDates " & strFilter &
        " group by PatentID) Q on Q.PatID = qvwPatentDates.PatentID and Q.PatentDate = qvwPatentDates.PatentDate " & GetPatentFilters(False)

        dtPatents = DataStuff.GetDataTable(strSQL)
        Me.grdPatents.DataSource = dtPatents

    End Sub


    Private Sub GetPatentsForExport(ByVal IsExcel As Boolean)
        On Error Resume Next
        Dim i As Integer, dtPatentDates As DataTable, dtPatentContacts As DataTable, dtClasses As DataTable
        Dim strColumnName As String, UpdateRows As DataRow(), strSQL As String, strFilter As String, strClasses As String
        Dim bShowGraphic As Boolean, bShowClasses As Boolean, GRow As Janus.Windows.GridEX.GridEXRow, bDateSelected As Boolean

        strSQL = "Select distinct PatentID, PatentName, PatentType, CompanyName, Jurisdiction, ApplicationNumber, " &
              "PatentNumber, Status, FilingBasis, FileNumber, PatentType, OurDocket, ClientDocket, " &
              "Category, Subcategory, Claims, GraphicPath as Graphic from qvwPatentsFullList " & GetPatentFilters(False)

        dtPatents = DataStuff.GetDataTable(strSQL)

        'no graphics exported to Excel -- doesn't work.
        If IsExcel = True Then
            dtPatents.Columns.Remove("Graphic")
        End If

        'so we limit other tables to Patents we already found
        strFilter = " where PatentID in ("
        For Each dr As DataRow In dtPatents.Rows
            strFilter = strFilter & dr("PatentID") & ", "
        Next
        strFilter = strFilter & "0)"

        dtPatents.Columns.Add("Classes")

        ' get all classes for Patents
        strSQL = "Select PatentID, PatentClass from qvwPatentClasses " & strFilter & " order by PatentClass"
        dtClasses = DataStuff.GetDataTable(strSQL)


        'make sure a filter has been applied or a date has been checked
        bDateSelected = False
        For i = 0 To Me.grdPatentDates.RowCount - 1
            GRow = Me.grdPatentDates.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                If GRow.Cells("Selected").Value = True Then
                    bDateSelected = True
                End If
            End If
        Next

        If (Me.chkPatentDateFilters.Checked = True) And (bDateSelected = True) Then
            'get Patent dates Patented for Word/Excel export
            strSQL = "Select distinct PatentID, DateName, Max(PatentDate) as PatentDate from tblPatentDates " &
                    "inner join tblPatentDatesTemplate on tblPatentDates.DateID = tblPatentDatesTemplate.DateID " &
                    strFilter & GetPatentDatesToPrint() & " Group by PatentID, PatentDate, DateName"

            ' Okay, it's a hack.  I admit it.  Both tables have DateID in them.
            strSQL = strSQL.Replace("(DateID", "(tblPatentDates.DateID")
            dtPatentDates = DataStuff.GetDataTable(strSQL)
        End If

        ' get positions Patented for Word/Excel export
        strSQL = "Select PatentID, PositionName, ContactName from qvwPatentContacts " & strFilter &
                " and WordExcel <> 0"
        dtPatentContacts = DataStuff.GetDataTable(strSQL)

        For Each PatentRow As DataRow In dtPatents.Rows
            strFilter = "PatentID=" & PatentRow("PatentID").ToString()

            ' add classes as a single string separated by commas
            UpdateRows = dtClasses.Select(strFilter)
            strClasses = String.Empty
            For i = 0 To UpdateRows.Length - 1
                strClasses = strClasses & UpdateRows(i).Item("PatentClass")
                If i < (UpdateRows.Length - 1) Then
                    strClasses = strClasses & ", "
                End If
            Next

            PatentRow("Classes") = strClasses

            ' for selected dates, create column if necessary and fill date value for each row
            If Not (dtPatentDates Is Nothing) Then
                UpdateRows = dtPatentDates.Select(strFilter)
                For i = 0 To UpdateRows.Length - 1
                    strColumnName = "[" & UpdateRows(i).Item("DateName") & "]"
                    If dtPatents.Columns.Contains(strColumnName) = False Then
                        dtPatents.Columns.Add(strColumnName)
                    End If
                    If IsDate(UpdateRows(i).Item("PatentDate")) Then
                        If RevaSettings.USADates = True Then
                            PatentRow(strColumnName) = Convert.ToDateTime(UpdateRows(i).Item("PatentDate")).ToString("MMM dd, yyyy")
                        Else
                            PatentRow(strColumnName) = Convert.ToDateTime(UpdateRows(i).Item("PatentDate")).ToString("dd MMM,yyyy")
                        End If

                    End If
                Next
            End If
            ' ditto for selected positions
            UpdateRows = dtPatentContacts.Select(strFilter)
            For i = 0 To UpdateRows.Length - 1
                strColumnName = "[" & UpdateRows(i).Item("PositionName") & "]"
                If dtPatents.Columns.Contains(strColumnName) = False Then
                    dtPatents.Columns.Add(strColumnName)
                End If
                PatentRow(strColumnName) = UpdateRows(i).Item("ContactName")
            Next

        Next 'next PatentRow

        dtPatents.AcceptChanges()

        With Me.grdPatents.RootTable
            'see if graphic and classes are current visible
            bShowGraphic = False
            bShowClasses = False
            If .Columns.Contains("Graphic") Then
                If .Columns("Graphic").Visible = True Then
                    bShowGraphic = True
                End If
            End If
            If .Columns.Contains("Classes") Then
                If .Columns("Classes").Visible = True Then
                    bShowClasses = True
                End If
            End If
        End With

        ' Now we have to add missing columns to grid.  Those were all named with brackets, except for GraphicPath
        For Each dc As DataColumn In dtPatents.Columns
            With Me.grdPatents.RootTable
                If (dc.ColumnName.Contains("[")) Or (dc.ColumnName = "Graphic") Or (dc.ColumnName = "Classes") Then
                    strColumnName = dc.ColumnName
                    If .Columns.Contains(strColumnName) = False Then
                        .Columns.Add(strColumnName)
                    End If
                    .Columns(strColumnName).Caption = strColumnName.Replace("[", "").Replace("]", "")
                    .Columns(strColumnName).ShowInFieldChooser = True
                    .Columns(strColumnName).Visible = True
                    .Columns(strColumnName).FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                    'turn these off if they werent' previously visible
                    If strColumnName = "Graphic" Then
                        .Columns("Graphic").Visible = bShowGraphic
                    End If
                    If strColumnName = "Classes" Then
                        .Columns("Classes").Visible = bShowClasses
                    End If

                End If
            End With
        Next
        ' And remove any columns from the grid no longer in our table.  
        ' For reasons that make no sense, we have to do this as many times as there are dates to clear the columns that are gone.
        For i = 1 To Me.grdPatentDates.RowCount
            For Each GridCol As Janus.Windows.GridEX.GridEXColumn In Me.grdPatents.RootTable.Columns
                strColumnName = GridCol.Key
                If dtPatents.Columns.Contains(strColumnName) = False Then
                    GridCol.Visible = False
                    GridCol.ShowInFieldChooser = False
                    Me.grdPatents.RootTable.Columns.Remove(GridCol)
                End If
            Next
        Next

        Me.grdPatents.DataSource = dtPatents


    End Sub

    Private Sub ShowPatentDateColumns(ByVal HasDates As Boolean)
        On Error Resume Next
        'For some reason, dates can get exluded from a layout and then they're not avaiable, period.
        'So we'll decided whether to show them or not AFTER the layout is loaded.

        If HasDates = True Then
            With Me.grdPatents.RootTable
                ' make sure these weren't hosed by a previous layout
                If .Columns.Contains("DateName") = False Then
                    .Columns.Add("DateName")
                End If

                If .Columns.Contains("PatentDate") = False Then
                    .Columns.Add("PatentDate")
                End If

                If .Columns.Contains("NoMonth") = False Then
                    .Columns.Add("NoMonth")
                End If

                If .Columns.Contains("NoDay") = False Then
                    .Columns.Add("NoDay")
                End If

                If .Columns.Contains("Completed") = False Then
                    .Columns.Add("Completed")
                    .Columns("Completed").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                    .Columns("Completed").ShowInFieldChooser = True
                    .Columns("Completed").Caption = "Compl."
                    .Columns("Completed").Width = 45
                End If

                .Columns("DateName").Visible = True
                .Columns("DateName").ShowInFieldChooser = True
                .Columns("DateName").Caption = "Date Name"
                .Columns("PatentDate").Visible = True
                .Columns("PatentDate").ShowInFieldChooser = True
                .Columns("PatentDate").Caption = "Date"

                If RevaSettings.USADates = True Then
                    Me.grdPatents.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
                Else
                    Me.grdPatents.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
                End If

                ' No need to ever show these
                .Columns("NoMonth").Visible = False
                .Columns("NoMonth").ShowInFieldChooser = False
                .Columns("NoDay").Visible = False
                .Columns("NoDay").ShowInFieldChooser = False
                .Columns("PatentID").ShowInFieldChooser = False
            End With

        Else
            With Me.grdPatents.RootTable
                If .Columns.Contains("DateName") = True Then
                    .Columns("DateName").Visible = False
                    .Columns("DateName").ShowInFieldChooser = False
                End If

                If .Columns.Contains("PatentDate") = True Then
                    .Columns("PatentDate").Visible = False
                    .Columns("PatentDate").ShowInFieldChooser = False
                End If

                If .Columns.Contains("NoMonth") = True Then
                    .Columns("NoMonth").Visible = False
                    .Columns("NoMonth").ShowInFieldChooser = False
                End If

                If .Columns.Contains("NoDay") = True Then
                    .Columns("NoDay").Visible = False
                    .Columns("NoDay").ShowInFieldChooser = False
                End If

                If .Columns.Contains("Completed") = True Then
                    .Columns("Completed").Visible = False
                    .Columns("Completed").ShowInFieldChooser = False
                End If

                .Columns("PatentID").ShowInFieldChooser = False
            End With
        End If
    End Sub

    Private Sub btnGetPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPatents.Click
        On Error Resume Next
        PreviewPatents()
    End Sub


    Private Sub chkPatentRelated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentRelated.CheckedChanged
        On Error Resume Next
        PreviewPatents()
    End Sub

    Private Sub chkPatentAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatentAlerts.CheckedChanged
        On Error Resume Next
        With Me
            If .chkPatentAlerts.Checked = True Then
                .PatentAlertsFrom.Visible = True
                .PatentAlertsTo.Visible = True
                .lblPatAlertsFrom.Visible = True
                .lblPatAlertsTo.Visible = True
                .chkPatentDateFilters.Checked = False
            Else
                .PatentAlertsFrom.Visible = False
                .PatentAlertsTo.Visible = False
                .lblPatAlertsFrom.Visible = False
                .lblPatAlertsTo.Visible = False
            End If
        End With
    End Sub

    Private Sub grdPatentReports_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentReports.RecordUpdated
        On Error Resume Next
        rsPatentReports.Update()
    End Sub

    Private Function GetPatentFilters(ByVal AddSelectedDates As Boolean) As String
        On Error Resume Next
        Dim strFilter As String, i As Integer, FilterRows As Object(), GRow As Janus.Windows.GridEX.GridEXRow,
            bDateFilters As Boolean, bDatesSelected As Boolean, bRowDateFilter As Boolean, dtLinkedCompanies As DataTable,
            LinkedCompanies As DataRow(), dRow As DataRow, j As Integer

        With Me

            If .chkPatentRelated.Checked = True Then
                dtLinkedCompanies = DataStuff.GetDataTable("Select * from qvwLinkedCompanies where LinkCompanyID >0")
            End If

            strFilter = " where PatentID <> 0 and (StatusID in ("

            '=============================================================================
            'look for status filter; if none, include only where ShowOnReports = true
            If (.cboPatentStatus.CheckedValues Is Nothing) Or (.chkPatentStatus.Checked = False) Then
                For i = 0 To dtPatentStatus.Rows.Count - 1
                    dRow = dtPatentStatus.Rows(i)
                    If dRow("ShowOnReports") = True Then
                        strFilter = strFilter & dRow("StatusID") & ", "
                    End If
                Next
                strFilter = strFilter & "0) or StatusID is null)"
            Else
                Dim bIncludeNull As Boolean
                bIncludeNull = False
                FilterRows = .cboPatentStatus.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                    If FilterRows(i) = 0 Then
                        bIncludeNull = True
                    End If
                Next
                If bIncludeNull = False Then
                    strFilter = strFilter & "0))"
                Else
                    strFilter = strFilter & "0) or StatusID is null)"
                End If

            End If

            '=============================================================================
            'look for company filter

            If (.cboPatentCompanies.CheckedValues Is Nothing) Or (.chkPatentCompanies.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and CompanyID in ("
                FilterRows = .cboPatentCompanies.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "

                    If .chkPatentRelated.Checked = True Then
                        LinkedCompanies = dtLinkedCompanies.Select("LinkCompanyID=" & FilterRows(i).ToString)
                        For j = 0 To LinkedCompanies.Length - 1
                            dRow = LinkedCompanies(j)
                            strFilter = strFilter & dRow("CompanyID") & ","
                        Next
                    End If
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for jurisdiction filter
            If (.cboPatentJurisdictions.CheckedValues Is Nothing) Or (.chkPatentJurisdictions.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and JurisdictionID in ("
                FilterRows = .cboPatentJurisdictions.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for filingbasis filter
            If (.cboPatentFilingBasis.CheckedValues Is Nothing) Or (.chkPatentFilingBasis.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and FilingBasisID in ("
                FilterRows = .cboPatentFilingBasis.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for Patent Type filter
            If (.cboPatentTypes.CheckedValues Is Nothing) Or (.chkPatentTypes.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and PatentTypeID in ("
                FilterRows = .cboPatentTypes.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '=============================================================================
            'look for classes filter
            If (.cboPatentClasses.CheckedValues Is Nothing) Or (.chkPatentClasses.Checked = False) Then
                'no filter applied
            Else
                strFilter = strFilter & " and PatentClassID in ("
                FilterRows = .cboPatentClasses.CheckedValues
                For i = 0 To FilterRows.Length - 1
                    strFilter = strFilter & FilterRows(i).ToString & ", "
                Next
                strFilter = strFilter & "0)"
            End If

            '============= Position/Contact Filter ======================================

            If (.cboPatentContact.SelectedIndex >= 0) And (.cboPatentPosition.SelectedIndex >= 0) _
                And (.chkPatentPositions.Checked = True) Then
                strFilter = strFilter & " and ContactID=" & cboPatentContact.Value &
                    " and PositionID=" & cboPatentPosition.Value
            End If

            '============== Category/SubCategory=========================================
            If .chkPatentCategory.Checked = True Then
                If .Category.Text & "" <> "" Then
                    strFilter = strFilter & " and Category='" & .Category.Text & "'"
                End If

                If .Subcategory.Text & "" <> "" Then
                    strFilter = strFilter & " and SubCategory='" & .Subcategory.Text & "'"
                End If
            End If
            '=============================================================================

            'see if date filters were applied and if dates are selected to print
            bDateFilters = False
            bDatesSelected = False

            If .chkPatentDateFilters.Checked = True Then
                For i = 0 To Me.grdPatentDates.RowCount - 1
                    GRow = grdPatentDates.GetRow(i)
                    With GRow
                        If .RowType = Janus.Windows.GridEX.RowType.Record Then
                            If IsDate(.Cells("DateFrom").Value) Then bDateFilters = True
                            If IsDate(.Cells("DateTo").Value) Then bDateFilters = True
                            If (.Cells("Completed").Value) <> 2 Then bDateFilters = True
                            If .Cells("Selected").Value = True Then bDatesSelected = True
                        End If
                    End With
                Next
            End If

            If bDateFilters = True Then
                'August 2010 -- switching from AND to OR for the date filters
                strFilter = strFilter & " and PatentID in (Select PatentID from " &
                    "tblPatentDates where ((PatentID = 0) "
                For i = 0 To Me.grdPatentDates.RowCount - 1
                    GRow = grdPatentDates.GetRow(i)
                    With GRow
                        If .RowType = Janus.Windows.GridEX.RowType.Record Then

                            'does this row have a filter?
                            bRowDateFilter = False
                            If IsDate(.Cells("DateFrom").Value) Then bRowDateFilter = True
                            If IsDate(.Cells("DateTo").Value) Then bRowDateFilter = True
                            If (.Cells("Completed").Value) <> 2 Then bRowDateFilter = True

                            'if so, proceed with caution
                            If bRowDateFilter = True Then
                                'strFilter = strFilter & " and PatentID in (Select PatentID from " & _
                                '    "tblPatentDates where DateID=" & .Cells("DateID").Value

                                strFilter = strFilter & " or (DateID=" & .Cells("DateID").Value

                                If IsDate(.Cells("DateFrom").Value) Then
                                    strFilter = strFilter & " and PatentDate >=" & FixDate(.Cells("DateFrom").Text)
                                End If

                                If IsDate(.Cells("DateTo").Value) Then
                                    strFilter = strFilter & " and PatentDate <=" & FixDate(.Cells("DateTo").Text)
                                End If

                                If (.Cells("Completed").Value) <> 2 Then
                                    strFilter = strFilter & " and Completed" &
                                    IIf(.Cells("Completed").Value = 0, "=0", "<>0")
                                End If
                                strFilter = strFilter & ")"
                            End If   'if there's a row filter
                        End If   'if it's a record row
                    End With
                Next
                strFilter = strFilter & "))"
            End If  'if there are date filters

            ' Now add selected dates to recordset if necessary for reports that print dates
            If (AddSelectedDates = True And bDatesSelected = True) Then
                strFilter = strFilter & " and DateID in ("
                For i = 0 To .grdPatentDates.RowCount - 1
                    GRow = grdPatentDates.GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        If GRow.Cells("Selected").Value = True Then
                            strFilter = strFilter & GRow.Cells("DateID").Value & ","
                        End If
                    End If
                Next
                strFilter = strFilter & "0)"
            End If

            'NEW August 2010 -- simple alerts filter option
            If .chkPatentAlerts.Checked = True Then
                strFilter = strFilter & " and PatentDate >=" & FixDate(.PatentAlertsFrom.Text) &
                    " and PatentDate <=" & FixDate(.PatentAlertsTo.Text) & " and DateID in " &
                    "(Select DateID from tblDatesTemplate WHERE IsAlert <> 0)"
            End If
        End With

        GetPatentFilters = strFilter
        'MsgBox(strFilter)


    End Function

    Friend Function GetPatentsToPrint() As String
        On Error Resume Next
        Dim strFilter As String, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow

        strFilter = " where PatentID in ("
        'get list of Patent IDs that are in the preview grid
        For i = 0 To Me.grdPatents.RowCount - 1
            GRow = Me.grdPatents.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("PatentID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"
        GetPatentsToPrint = strFilter
    End Function

    Private Function GetPatentDatesToPrint() As String
        Dim strFilter As String, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow, bDateSelected As Boolean
        strFilter = ""
        If Me.chkPatentDateFilters.Checked = True Then
            'make sure a filter has been applied or a date has been checked
            For i = 0 To Me.grdPatentDates.RowCount - 1
                GRow = Me.grdPatentDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    If GRow.Cells("Selected").Value = True Then
                        bDateSelected = True
                    End If
                End If
            Next

            If bDateSelected = True Then
                strFilter = " and ((DateID = 0)"
                'get list of Dates that are selected in the Date Filters grid.
                For i = 0 To Me.grdPatentDates.RowCount - 1
                    GRow = Me.grdPatentDates.GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        If GRow.Cells("Selected").Value = True Then

                            strFilter = strFilter & " or (DateID =" & GRow.Cells("DateID").Value

                            If IsDate(GRow.Cells("DateFrom").Text) Then
                                strFilter = strFilter & " and PatentDate >=" &
                                FixDate(GRow.Cells("DateFrom").Text)
                            End If

                            If IsDate(GRow.Cells("DateTo").Text) Then
                                strFilter = strFilter & " and PatentDate <=" &
                                FixDate(GRow.Cells("DateTo").Text)
                            End If

                            If (GRow.Cells("Completed").Value) <> 2 Then
                                strFilter = strFilter & " and Completed" &
                                IIf(GRow.Cells("Completed").Value = 0, "=0", "<>0")
                            End If

                            strFilter = strFilter & ")"

                        End If
                    End If

                Next
                strFilter = strFilter & ")"
            End If
        End If

        If Me.chkPatentAlerts.Checked = True Then
            'strFilter = " and DateID in (Select DateID from tblDatesTemplate where IsAlert <> 0)"
            strFilter = " and (PatentDate >=" & FixDate(Me.PatentAlertsFrom.Text) &
                    " and PatentDate <=" & FixDate(Me.PatentAlertsTo.Text) & " and DateID in " &
                    "(Select DateID from tblPatentDatesTemplate WHERE IsAlert <> 0))"
        End If

        GetPatentDatesToPrint = strFilter

    End Function

    Private Sub grdPatentReports_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentReports.CellValueChanged
        On Error Resume Next
        Dim bReportSelected As Boolean = False, LayoutName As String = String.Empty

        Me.btnPatentPositions.Visible = False
        If e.Column.Key = "Selected" Then
            If Me.grdPatentReports.GetValue("Selected") = True Then
                bReportSelected = True
                Dim iRow As Integer, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
                iRow = Me.grdPatentReports.Row
                For i = 0 To Me.grdPatentReports.RowCount - 1
                    If iRow <> i Then
                        GRow = Me.grdPatentReports.GetRow(i)
                        GRow.BeginEdit()
                        GRow.Cells("Selected").Value = False
                        GRow.EndEdit()
                    End If
                Next

                LayoutName = Me.grdPatentReports.GetValue("ReportLayout") & ""
                ' So user has to preview when selecting a report with a different layout.  Otherwise, the layouts would be wrong.
                If LayoutName <> LastPatentLayout Then
                    Me.grdPatents.RemoveFilters()
                    Me.grdPatents.DataSource = Nothing
                End If

                'if Word/Excel is selected, show positions button
                If (LayoutName = "PatentExportWordLayout") Or (LayoutName = "PatentExportExcelLayout") Then
                    Me.btnPatentPositions.Visible = True
                End If

                ' if it's next due date report, automatically 
                If LayoutName = "PatentNextDueDateLayout" Then
                    Me.chkPatentDateFilters.Checked = True
                End If

            End If

            Me.btnGetPatents.Enabled = bReportSelected
            Me.btnPrintPatentReport.Enabled = ((Me.grdPatents.RowCount > 0) And (bReportSelected))

        End If
    End Sub

    Private Sub grdPatents_GroupsChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.GroupsChangedEventArgs) Handles grdPatents.GroupsChanged
        On Error Resume Next
        SetPatentReportMargin()
        Me.chkPatentGroupNewPage.Visible = Me.grdPatents.RootTable.Groups.Count > 0
        ' don't want user to create more groups than exist on report
        Me.grdPatents.RootTable.AllowGroup = Me.grdPatents.RootTable.Groups.Count < 2
    End Sub

    Private Sub SetPatentReportMargin()
        On Error Resume Next
        'because when we create groups, the root table columns move left a bit.
        'the idea is that the columns within the margin Patenter all fit on the report
        If Me.grdPatents.RootTable.Groups.Count = 0 Then
            Me.lblPatentReportWidth.Left = 725
        End If

        If Me.grdPatents.RootTable.Groups.Count = 1 Then
            Me.lblPatentReportWidth.Left = 735
        End If

        If Me.grdPatents.RootTable.Groups.Count = 2 Then
            Me.lblPatentReportWidth.Left = 750
        End If
    End Sub

    Private Sub btnPrintPatentReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPatentReport.Click
        On Error Resume Next

        If Me.grdPatentReports.GetValue("Selected") = False Then
            MsgBox("You must select a report to print first.")
            Exit Sub
        End If

        If Me.grdPatents.RecordCount = 0 Then
            MsgBox("There are no Patents in the preview grid. Click the Preview Patents button to see which " &
                       "Patents match your filters.")
            Exit Sub
        End If

        ' Still here?  Okay, let's go ...
        Dim strReportName As String, strSQL As String, ReportTable As DataTable

        strReportName = Me.grdPatentReports.GetValue("ReportFileName")

        Select Case strReportName

            '============================== List reports ============================
            Case "rptPatentsByNameList"
                Dim rptReport As New rptPatentsListGroup
                ReportTable = DataStuff.GetTableFromGrid(Me.grdPatents, "PatentID", False)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptPatentDates"  'same report, different fields available
                Dim rptReport As New rptPatentsListGroup
                ReportTable = DataStuff.GetTableFromGrid(Me.grdPatents, "PatentID", False)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            '============================== Formatted reports ============================
            Case "rptPatentsByCompany"
                Dim rptReport As New rptPatentsByCompany

                strSQL = SQL.vwReportPatents & GetPatentsToPrint() & GetPatentDatesToPrint() &
                    " order by CompanyName, CompanyID, PatentName, PatentID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptPatentsAlpha"
                Dim rptReport As New rptPatentsAlpha

                strSQL = SQL.vwReportPatents & GetPatentsToPrint() & GetPatentDatesToPrint() &
                    " order by PatentName, PatentID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptPatentsByCompanyContacts"
                Dim rptReport As New rptPatentsByCompanyContacts

                strSQL = "SELECT PatentName, Jurisdiction, ApplicationNumber, PatentNumber, PatentContactID, CompanyName, " & vbCrLf &
                "ContactName, ContactCompany, PositionName, PatentID, PositionID, " & vbCrLf &
                "CompanyID, ContactID from qvwPatentContacts" & GetPatentsToPrint() &
                " order by CompanyName, PatentName, PatentID, ContactName"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()


            Case "rptPatentsByCompanyDates"
                Dim rptReport As New rptPatentsByCompanyDates

                strSQL = SQL.vwReportPatents & GetPatentsToPrint() & GetPatentDatesToPrint() &
                    " order by CompanyName, CompanyID, PatentName, PatentID, ListOrder"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()


            Case "rptPatentActions"
                Dim rptReport As New rptPatentActions

                strSQL = "Select * from qvwPatentActions" & GetPatentsToPrint() &
                    " order by CompanyName, CompanyID, PatentName, PatentID, ActionDate"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            Case "rptPatentsLicensed"
                Dim rptReport As New rptPatentsLicensed

                strSQL = "Select * from qvwPatentsLicensed" & GetPatentsToPrint() &
                    " order by CompanyName, CompanyID, PatentName, PatentID, Licensee"
                ReportTable = DataStuff.GetDataTable(strSQL)
                rptReport.DataSource = ReportTable
                AllForms.OpenReport()
                AllForms.frmReportPreview.ReportViewer.Document = rptReport.Document
                rptReport.Run()

            '============================== Export reports ============================

            Case "PatentExportExcel"
                Dim ExcelExport As New Export
                ExcelExport.ExportTable = DataStuff.GetTableFromGrid(Me.grdPatents, "PatentName", True)

                If ExcelExport.ExportTable Is Nothing Then
                    MsgBox("Unable to create export table.")
                    Exit Sub
                Else
                    ExcelExport.CreateSpreadsheet()
                End If

            Case "PatentExportWord"
                Dim WordExport As New Export
                WordExport.ExportTable = DataStuff.GetTableFromGrid(Me.grdPatents, "PatentName", True)

                If WordExport.ExportTable Is Nothing Then
                    MsgBox("Unable to create export table.")
                    Exit Sub
                Else
                    WordExport.CreateWordTable()
                End If

            Case Else

        End Select

        ' user may have made field/order changes, so save layout
        SavePatentReportLayout()

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

#Region "Spreadsheet Report"

#Region "Top toolbar"

    Private Sub btnOpenExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenExcel.Click
        On Error Resume Next
        Dim strFile As String
        With Me.OpenFileDialog
            .InitialDirectory = Application.StartupPath
            .FileName = ""
            .Filter = "Excel Spreadsheets|*.xls|All Files|*.*"
            .FilterIndex = 1
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName) > 5 Then
                Dim XLB As SpreadsheetGear.IWorkbook
                strFile = .FileName
                wkbReport.GetLock()
                XLB = SpreadsheetGear.Factory.GetWorkbook(strFile, System.Globalization.CultureInfo.CurrentCulture)
                Me.wkbReport.ActiveWorkbook = XLB
                wkbReport.ReleaseLock()
                bSpreadsheetChanged = True
            End If
        End With
    End Sub

    Private Sub btnSaveExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveExcel.Click
        On Error Resume Next
        SetPrintOptions()
        SaveSpreadsheet()
    End Sub

    Private Sub btnNewSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSheet.Click
        On Error Resume Next
        Dim strSheetName As String
        With Me
            .wkbReport.GetLock()
            .wkbReport.ActiveWorkbook.Worksheets.Add()
            strSheetName = .WorksheetName.Text
            If strSheetName & "" <> "" Then
                .wkbReport.ActiveWorksheet.Name = strSheetName
            End If
            .wkbReport.ReleaseLock()
            .WorksheetName.Text = ""
        End With
        bSpreadsheetChanged = True
        SetSpreadsheetFont()
    End Sub

    Private Sub btnNameWorksheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNameWorksheet.Click
        On Error Resume Next
        Dim strSheetName As String

        strSheetName = Me.WorksheetName.Text
        If strSheetName & "" = "" Then
            MsgBox("Enter a name in the textbox to the right of this button first.")
            Exit Sub
        End If

        With Me
            .wkbReport.GetLock()
            .wkbReport.ActiveWorksheet.Name = strSheetName
            .wkbReport.ReleaseLock()
            .WorksheetName.Text = ""
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnDeleteSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSheet.Click
        On Error Resume Next
        Dim bOkayDelete As Boolean
        bOkayDelete = True

        Me.wkbReport.GetLock()

        If Me.wkbReport.ActiveWorkbook.Worksheets.Count = 1 Then
            MsgBox("Cannot delete the only sheet in a workbook.")
            bOkayDelete = False
        End If

        If bOkayDelete = True Then
            If MsgBox("Are you sure you want to delete this worksheet? This cannot be undone.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                bOkayDelete = False
            End If
        End If

        If bOkayDelete = True Then
            Me.wkbReport.ActiveWorksheet.Delete()
            bSpreadsheetChanged = True
        End If

        Me.wkbReport.ReleaseLock()

    End Sub

    Private Sub btnClearSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSheet.Click
        On Error Resume Next
        If MsgBox("Clear the contents of this worksheet?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        With Me
            Dim cmdClear As SpreadsheetGear.Windows.Forms.Command
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            cmdClear = .wkbReport.ActiveCommandManager.CreateCommandClear(.wkbReport.ActiveWorksheet.Range)
            .wkbReport.ActiveCommandManager.Execute(cmdClear)
            .wkbReport.ReleaseLock()
        End With
        SetSpreadsheetFont()
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCut.Click
        On Error Resume Next
        With Me
            Dim cmdCut As SpreadsheetGear.Windows.Forms.Command
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            cmdCut = .wkbReport.ActiveCommandManager.CreateCommandCut(SelectedCell)
            .wkbReport.ActiveCommandManager.Execute(cmdCut)
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        On Error Resume Next
        With Me
            .wkbReport.GetLock()
            .wkbReport.Copy()
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        On Error Resume Next
        With Me
            Dim cmdPaste As SpreadsheetGear.Windows.Forms.Command
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            cmdPaste = .wkbReport.ActiveCommandManager.CreateCommandPaste(SelectedCell)
            .wkbReport.ActiveCommandManager.Execute(cmdPaste)
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        On Error Resume Next
        With Me
            .wkbReport.GetLock()
            .wkbReport.ActiveCommandManager.Undo()
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoFit.Click
        On Error Resume Next
        With Me
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Columns.AutoFit()
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnWordWrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWordWrap.Click
        On Error Resume Next
        With Me
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Columns.WrapText = Not (SelectedCell.Columns.WrapText)
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True
    End Sub

    Private Sub btnAlignTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignTop.Click
        On Error Resume Next
        With Me
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Columns.VerticalAlignment = SpreadsheetGear.VAlign.Top
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True
    End Sub

    Private Sub btnAlignBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignBottom.Click
        On Error Resume Next
        With Me
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Columns.VerticalAlignment = SpreadsheetGear.VAlign.Bottom
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True
    End Sub

    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        On Error Resume Next
        With Me
            .wkbReport.GetLock()
            .wkbReport.ActiveCommandManager.Redo()
            .wkbReport.ReleaseLock()
        End With
        bSpreadsheetChanged = True

    End Sub

    Private Sub btnPrintSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSheet.Click
        On Error Resume Next
        SetPrintOptions()
        With Me
            .wkbReport.GetLock()
            .wkbReport.Print(True)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        On Error Resume Next
        SetPrintOptions()
        With Me
            .wkbReport.GetLock()
            .wkbReport.PrintPreview()
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        On Error Resume Next
        SetPrintOptions()
        Me.wkbReport.GetLock()
        Dim workbookSet As SpreadsheetGear.IWorkbookSet = wkbReport.ActiveWorkbookSet
        Dim explorer As New SpreadsheetGear.Windows.Forms.WorkbookExplorer(workbookSet)
        explorer.Show(wkbReport)
        Me.wkbReport.ReleaseLock()
        bSpreadsheetChanged = True
    End Sub

#End Region

#Region "Bottom toolbar"

    Private Sub btnImportMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportMarks.Click
        On Error Resume Next
        If Me.grdMarks.RowCount < 1 Then
            MsgBox("There are no trademarks in the preview grid to import.  Select the 'Export to Excel' report and click the Preview Trademarks button first.")
            Exit Sub
        End If

        Dim ExportTable As DataTable

        Me.Cursor = Cursors.WaitCursor
        ExportTable = DataStuff.GetTableFromGrid(Me.grdMarks, "TrademarkName", True)

        Me.wkbReport.GetLock()
        Dim SelectedCell As SpreadsheetGear.IRange
        SelectedCell = Me.wkbReport.RangeSelection
        SelectedCell.CopyFromDataTable(ExportTable, SpreadsheetGear.Data.SetDataFlags.AllText)
        Me.wkbReport.ReleaseLock()
        bSpreadsheetChanged = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnImportPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportPatents.Click
        On Error Resume Next
        If Me.grdPatents.RowCount < 1 Then
            MsgBox("There are no patents in the preview grid to import.  Select the 'Export to Excel' report and click the Preview Patents button first.")
            Exit Sub
        End If
        Dim ExportTable As DataTable

        Me.Cursor = Cursors.WaitCursor
        ExportTable = DataStuff.GetTableFromGrid(Me.grdPatents, "PatentName", True)

        Me.wkbReport.GetLock()
        Dim SelectedCell As SpreadsheetGear.IRange
        SelectedCell = Me.wkbReport.RangeSelection
        SelectedCell.CopyFromDataTable(ExportTable, SpreadsheetGear.Data.SetDataFlags.AllText)
        Me.wkbReport.ReleaseLock()
        bSpreadsheetChanged = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnBoldCells_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoldCells.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Font.Bold = Not (SelectedCell.Font.Bold)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItalic.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.Font.Italic = Not (SelectedCell.Font.Italic)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnderline.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            If SelectedCell.Font.Underline = SpreadsheetGear.UnderlineStyle.None Then
                SelectedCell.Font.Underline = SpreadsheetGear.UnderlineStyle.Single
            Else
                SelectedCell.Font.Underline = SpreadsheetGear.UnderlineStyle.None
            End If
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnFormatSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormatSheet.Click
        On Error Resume Next
        wkbReport.GetLock()
        Dim WorkBookSet As SpreadsheetGear.IWorkbookSet = wkbReport.ActiveWorkbookSet
        Dim categoryFlags As SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags =
            SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.All
        Dim explorer As New SpreadsheetGear.Windows.Forms.RangeExplorer(WorkBookSet, categoryFlags)
        explorer.Show(wkbReport)
        wkbReport.ReleaseLock()
    End Sub

    Private Sub btnAlignLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignLeft.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.HorizontalAlignment = SpreadsheetGear.HAlign.Left
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnAlignMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignMiddle.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.HorizontalAlignment = SpreadsheetGear.HAlign.Center
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnAlignRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignRight.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.HorizontalAlignment = SpreadsheetGear.HAlign.Right
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnMergeCells_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergeCells.Click
        On Error Resume Next
        Dim SelectedCell As SpreadsheetGear.IRange
        With Me
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            SelectedCell.MergeCells = Not (SelectedCell.MergeCells)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnInsertRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertRow.Click
        On Error Resume Next
        With Me
            Dim cmdInsertRow As SpreadsheetGear.Windows.Forms.Command
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            cmdInsertRow = .wkbReport.ActiveCommandManager.CreateCommandInsert(SelectedCell, SpreadsheetGear.DeleteShiftDirection.Up)
            .wkbReport.ActiveCommandManager.Execute(cmdInsertRow)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRow.Click
        On Error Resume Next
        With Me
            Dim cmdDeleteRow As SpreadsheetGear.Windows.Forms.Command
            Dim SelectedCell As SpreadsheetGear.IRange
            .wkbReport.GetLock()
            SelectedCell = .wkbReport.RangeSelection
            cmdDeleteRow = .wkbReport.ActiveCommandManager.CreateCommandDelete(SelectedCell, SpreadsheetGear.DeleteShiftDirection.Up)
            .wkbReport.ActiveCommandManager.Execute(cmdDeleteRow)
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub XLLandscape_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XLLandscape.CheckedChanged
        On Error Resume Next
        My.Settings.XLLandscape = Me.XLLandscape.Checked

    End Sub

    Private Sub XLFitToPage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XLFitToPage.CheckedChanged
        On Error Resume Next
        My.Settings.XLFitToPage = Me.XLFitToPage.Checked

    End Sub

    Private Sub XLPageNumbers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XLPageNumbers.CheckedChanged
        On Error Resume Next
        My.Settings.XLPageNumbers = Me.XLPageNumbers.Checked

    End Sub

    Private Sub XLDatePrinted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XLDatePrinted.CheckedChanged
        On Error Resume Next
        My.Settings.XLDatePrinted = Me.XLDatePrinted.Checked

    End Sub

    Private Sub XLHeaderRows_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XLHeaderRows.SelectedValueChanged
        On Error Resume Next
        My.Settings.XLHeaderRows = Me.XLHeaderRows.SelectedValue

    End Sub

#End Region

#Region "Spreadsheet Functions"

    Private Sub SetSpreadsheetFont()
        On Error Resume Next
        With Me
            .wkbReport.GetLock()
            .wkbReport.ActiveWorksheet.Range.Font.Name = "Arial"
            .wkbReport.ActiveWorksheet.Range.Font.Size = 10
            .wkbReport.ReleaseLock()
        End With
    End Sub

    Private Sub GetPrintOptions()
        On Error Resume Next
        With Me
            .XLDatePrinted.Checked = My.Settings.XLDatePrinted
            .XLHeaderRows.SelectedValue = My.Settings.XLHeaderRows
            .XLLandscape.Checked = My.Settings.XLLandscape
            .XLPageNumbers.Checked = My.Settings.XLPageNumbers
            .XLFitToPage.Checked = My.Settings.XLFitToPage
        End With
    End Sub

    Private Sub SetPrintOptions()
        On Error Resume Next
        Dim strRows As String, strDate As String, strPages As String, i As Integer,
            WKS As SpreadsheetGear.IWorksheet
        With Me
            .wkbReport.GetLock()
            strPages = "Page &P of &N"

            If RevaSettings.USADates = True Then
                strDate = Format(Now, "MMMM dd, yyyy")
            Else
                strDate = Format(Now, "dd MMMM yyyy")
            End If

            If .XLHeaderRows.SelectedValue = 0 Then
                strRows = ""
            Else
                strRows = "$1:$" & .XLHeaderRows.SelectedValue.ToString
            End If

            For i = 0 To .wkbReport.ActiveWorkbook.Worksheets.Count - 1
                WKS = .wkbReport.ActiveWorkbook.Worksheets(i)

                WKS.PageSetup.PrintTitleRows = strRows

                If .XLLandscape.Checked = True Then
                    WKS.PageSetup.Orientation = SpreadsheetGear.PageOrientation.Landscape
                Else
                    WKS.PageSetup.Orientation = SpreadsheetGear.PageOrientation.Portrait
                End If

                If .XLPageNumbers.Checked = True Then
                    WKS.PageSetup.CenterFooter = strPages
                Else
                    WKS.PageSetup.CenterFooter = ""
                End If

                If .XLDatePrinted.Checked = True Then
                    WKS.PageSetup.RightFooter = strDate
                Else
                    WKS.PageSetup.RightFooter = ""
                End If

                If .XLFitToPage.Checked = True Then
                    WKS.PageSetup.FitToPagesWide = 1
                    WKS.PageSetup.FitToPagesTall = 0
                    WKS.PageSetup.FitToPages = True
                Else
                    WKS.PageSetup.FitToPages = False
                End If

            Next

            .wkbReport.ReleaseLock()
        End With

    End Sub

    Private Sub SaveSpreadsheet()
        On Error Resume Next
        Dim strFileName As String
        With Me.SaveFileDialog
            .InitialDirectory = Application.StartupPath
            .FileName = ""
            .Filter = "Excel Workbook (*.xls)|*.xls|All Files|*.*"
            .FilterIndex = 1
            .Title = "Name the new spreadsheet"
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName & "") > 3 Then
                strFileName = .FileName
                Me.wkbReport.GetLock()
                Me.wkbReport.ActiveWorkbook.SaveAs(strFileName, SpreadsheetGear.FileFormat.Excel8)
                Me.wkbReport.ReleaseLock()
                If MsgBox("Open the spreadsheet in Excel now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If System.IO.File.Exists(strFileName) Then
                        System.Diagnostics.Process.Start(strFileName)
                    Else
                        MsgBox("Cannot find the file.  There may have been an error creating the spreadsheet.")
                    End If
                End If
            End If
        End With
        bSpreadsheetChanged = False
    End Sub

#End Region

#End Region


   
    
   
    
End Class