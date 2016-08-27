Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmOppositions

#Region "Declarations"

    Private iSecurityLevel As Integer

    'data tables for Grids and Drop-Down lists
    Private dtOppositionsList As DataTable
    Private dtCompanies As DataTable
    Private dtContactList As DataTable
    Private dtContacts As DataTable
    Private dtJurisdictions As DataTable
    Private dtStatus As DataTable
    Private dtPositions As DataTable
    Private dtMarkDates As DataTable
    Private dtMarkJurisDates As DataTable
    Private dtDateList As DataTable

    Private dtCompanyMarks As DataTable
    Private DMarkRow As DataRow
    Private iTrademarkID As Integer
    Private rsActions As New RecordSet
    Private rsDates As New RecordSet
    Private rsClientMarks As New RecordSet
    Private rsOppositionMarks As New RecordSet
    Private rsOpposition As New BoundRecordSet

    Private iOldJurisdictionID As Integer
    Private dtDocLinks As DataTable

    'because lots of stuff shouldn't happen until form is loaded
    Private bFormLoaded As Boolean = False

#End Region

#Region "Toolbar Buttons"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        If MsgBox("Are you sure want to exit RevaTrademark?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveOpposition()
            Application.Exit()
        End If
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        AllForms.OpenLogin()
    End Sub

    Private Sub btnGoTrademarks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoTrademarks.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenTrademarks()
        Me.Close()
    End Sub

    Private Sub btnGoToPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToPatents.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenPatents()
        Me.Close()
    End Sub

    Private Sub btnGoToContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToContacts.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenCompanies()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenReports()
    End Sub

    Private Sub btnPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreferences.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenPreferences()
    End Sub

    Private Sub btnPrevRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevRecord.Click
        On Error Resume Next
        SaveOpposition()

        Select Case Globals.NavigateOppositionsFrom
            Case 1
                Me.grdList.MovePrevious()
                Globals.OppositionID = Me.grdList.GetValue("OppositionID")
                GetOpposition()

            Case 2
                Me.grdAlerts.MovePrevious()
                Globals.OppositionID = Me.grdAlerts.GetValue("OppositionID")
                GetOpposition()

        End Select
    End Sub

    Private Sub btnNextRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextRecord.Click
        On Error Resume Next

        SaveOpposition()

        Select Case Globals.NavigateOppositionsFrom
            Case 1
                Me.grdList.MoveNext()
                Globals.OppositionID = Me.grdList.GetValue("OppositionID")
                GetOpposition()

            Case 2
                Me.grdAlerts.MoveNext()
                Globals.OppositionID = Me.grdAlerts.GetValue("OppositionID")
                GetOpposition()

        End Select
    End Sub

#End Region

#Region "Browse Screen"

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

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        On Error Resume Next
        With Me
            If .optList.Checked = True Then
                RefreshBrowse()
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
                .btnPrintList.Text = "Print Opposition List"
                .btnPrintRecords.Visible = False
                .btnNewOpposition.Visible = True

                .pnlBrowse.Height = 15
                .grpSetContact.Visible = False
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .cboSetPosition.DataBindings.Clear()
                .cboSetPosition.Clear()
            End With

            With Me.grdList
                .Visible = True
                .Dock = DockStyle.Fill
                .SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End With

        End If

        If Me.optAlerts.Checked = True Then
            With Me
                .pnlBrowse.Height = 46
                .cboSetPosition.SetDataBinding(dtPositions, "")
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .grpSetContact.Visible = True
                .grpAlerts.Enabled = True
                .grdList.Visible = False
                .BetweenStart.Enabled = True
                .BetweenEnd.Enabled = True
                .cboEnd.Enabled = True
                .cboStart.Enabled = True
                .grpListButtons.Enabled = True
                .btnPrintList.Text = "Print Opposition Alerts"
                .btnPrintRecords.Visible = True
                .btnNewOpposition.Visible = False
                'get previous date range selection from stored settings
                .cboStart.SelectedIndex = My.Settings.DateFromIndex
                .cboEnd.SelectedIndex = My.Settings.DateToIndex
                SetAlertStartDate()
                SetAlertEndDate()
            End With

            With Me.grdAlerts
                .Dock = DockStyle.Fill
                .Visible = True
                .DataSource = Nothing
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RowFormatStyle.BackColor = Color.Lavender
                .AlternatingRowFormatStyle.BackColor = Color.WhiteSmoke
                .RootTable.Columns("EmailSent").Visible = False
                .RootTable.Columns("lnkSend").Visible = False
                .RootTable.Columns("DateID").Visible = False
                ' .RootTable.Columns("ProceedingNumber").Visible = True
                .RootTable.Columns("Completed").Visible = True
                .RootTable.Columns("OppositionName").Width = 295
                .RootTable.Columns("CompanyName").Width = 172
                .RootTable.Columns("DateName").Width = 190
                .RootTable.Columns("ProceedingNumber").Width = 75
                GetAlertDates()
                '.Row = 0
            End With

        End If

        If Me.optEmailAlerts.Checked = True Then
            With Me
                .pnlBrowse.Height = 46
                .cboSetPosition.SetDataBinding(dtPositions, "")
                .cboSetContact.DataBindings.Clear()
                .cboSetContact.Clear()
                .grpSetContact.Visible = False
                .grpAlerts.Enabled = False
                .grdList.Visible = False
                .BetweenStart.Enabled = True
                .BetweenEnd.Enabled = True
                .cboEnd.Enabled = False
                .cboStart.Enabled = False
                .grpListButtons.Enabled = False
                .btnPrintList.Text = "Print Opposition Alerts"
                .btnPrintRecords.Visible = True
                .btnNewOpposition.Visible = False
            End With

            With Me.grdAlerts
                .Dock = DockStyle.Fill
                .Visible = True
                .DataSource = Nothing
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .RowFormatStyle.BackColor = Color.Beige
                .AlternatingRowFormatStyle.BackColor = Color.Beige
                .RootTable.Columns("EmailSent").Visible = True
                .RootTable.Columns("lnkSend").Visible = True
                .RootTable.Columns("DateID").Visible = False
                .RootTable.Columns("Completed").Visible = False
                .RootTable.Columns("OppositionName").Width = 242
                .RootTable.Columns("CompanyName").Width = 170
                .RootTable.Columns("DateName").Width = 175
                .RootTable.Columns("ProceedingNumber").Width = 70
                .RootTable.Columns("lnkSend").Width = 74

                GetEmailAlerts()
                '.Row = 0
            End With

        End If

    End Sub

    Private Sub RefreshBrowse()
        On Error Resume Next
        Dim iRow As Integer, iFirst As Integer
        iRow = Me.grdList.CurrentRow.RowIndex
        iFirst = Me.grdList.FirstRow
        GetOppositionsList()
        Me.grdList.Row = iRow
        Me.grdList.FirstRow = iFirst
    End Sub

    Private Sub grdList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.Resize
        On Error Resume Next
        Me.grdList.RootTable.Columns("OppositionName").Width = (Me.grdList.Width - 728)
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
                GetOppositionsList()
            End If

        End With
    End Sub

    Private Sub cboSetPosition_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSetPosition.ValueChanged
        On Error Resume Next

        If Me.optAlerts.Checked = True Then
            Dim iPositionID As Integer, dtContactList As DataTable, strSQL As String
            iPositionID = cboSetPosition.Value
            If iPositionID > 0 Then
                strSQL = "Select distinct ContactID, PositionID, ContactName, ContactCompany as CompanyName from qvwTrademarkContacts" &
                    " where PositionID=" & iPositionID & " order by ContactName"
                dtContactList = DataStuff.GetDataTable(strSQL)
                Me.cboSetContact.DataSource = dtContactList
            End If
        End If
        Me.cboSetContact.SelectedIndex = -1
    End Sub

    Private Sub cboSetContact_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSetContact.ValueChanged
        On Error Resume Next
        If Me.optAlerts.Checked = True Then
            GetAlertDates()
        End If
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
        Dim drReader As OleDb.OleDbDataReader, rptOpposition As New rptOneOpposition, strSQL As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor
        strFilter = "OppositionID in ("
        strSort = "CompanyName, OppositionName, Jurisdiction, OppositionID, OppositionDate"

        For i = 0 To Me.grdAlerts.RowCount
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("OppositionID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = "SELECT distinct OppositionID, StatusID, CompanyID, OppositionName, JurisdictionID, ProceedingNumber, " &
        "CompanyName, OppositionCompany, ListOrder, DateName, OppositionDate, Completed, " &
        "IsAlert, Status, Jurisdiction from qvwOppositionDates where " & strFilter & " order by " & strSort

        drReader = DataStuff.GetDataReader(strSQL)
        rptOpposition.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptOpposition.Document
        rptOpposition.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnNewOpposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewOpposition.Click
        On Error Resume Next

        DataStuff.RunSQL("insert into tblOppositions (OppositionName) values ('Type Opposition Name Here')")
        Globals.OppositionID = DataStuff.DMax("OppositionID", "tblOppositions")

        ' add any contacts who are supposed to be on all Trademarks, which will include Oppositions for marks
        DataStuff.RunSQL("Insert into tblOppositionContacts (OppositionID, ContactID, PositionID) select distinct" &
            Globals.OppositionID & ", ContactID, PositionID from tblContacts where PositionID > 0 and AddToTrademarks<>0")

        GetOpposition()
        Me.btnNextRecord.Enabled = False
        Me.btnPrevRecord.Enabled = False
        Me.RecordCount.Text = ""

    End Sub

    Private Sub grdList_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdList.LinkClicked
        On Error Resume Next

        If (e.Column.Key = "OppositionName") Or (e.Column.Key = "ProceedingNumber") Then
            If Me.optList.Checked = True Then
                Globals.OppositionID = Me.grdList.GetValue("OppositionID")
                Globals.NavigateOppositionsFrom = 1
                GetOpposition()
            End If
        End If

        If e.Column.Key = "lnkDelete" Then
            If Globals.SecurityLevel > 1 Then Exit Sub
            Dim strMessage As String, iOppositionID As Integer
            iOppositionID = Me.grdList.GetValue("OppositionID")

            strMessage = "This will delete the Opposition and all related Opposition contacts and Opposition dates." &
                    vbCrLf & "This delete cannot be undone.  Are you sure?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'if we're still here, let's do it
            DataStuff.DeleteOpposition(iOppositionID)
            GetOppositionsList()
        End If

    End Sub


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
                    strSQL = "SELECT distinct OppositionID, OppositionName, CompanyName, Jurisdiction, ProceedingNumber, DateName, IsAlert, Completed, " &
                    "OppositionDate, DateID, JurisdictionID, CompanyID, ShowInAlerts, OppositionDateID, EmailSent, Suspended " &
                    "from qvwOppositionDates where IsAlert <> 0 and ShowInAlerts <> 0 and Suspended = 0"
                    strSQL = strSQL & " and OppositionDate >=" & FixDate(.BetweenStart.Text)
                    strSQL = strSQL & " and OppositionDate <=" & FixDate(.BetweenEnd.Text)

                    If .cboSetPosition.Value > 0 And .cboSetContact.Value > 0 Then
                        strSQL = strSQL & " and OppositionID in (Select OppositionID from qvwOppositionContacts" &
                            " where ContactID=" & .cboSetContact.Value & " and PositionID=" & .cboSetPosition.Value & ")"
                    End If

                    strSQL = strSQL & " order by OppositionDate, CompanyName"
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

        If (e.Column.Key = "OppositionName") Or (e.Column.Key = "ProceedingNumber") Then
            Me.grdAlerts.UpdateData()
            Globals.OppositionID = Me.grdAlerts.GetValue("OppositionID")
            Globals.NavigateOppositionsFrom = 2
            GetOpposition()
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

    Private Sub grdAlerts_GetChildList(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.GetChildListEventArgs) Handles grdAlerts.GetChildList
        On Error Resume Next
        'populates child table rows when the + sign is clicked on a parent row.
        Dim OppositionID As Integer, strSQL As String
        OppositionID = e.ParentRow.Cells("OppositionID").Value

        grdAlerts.Tables("Dates").FormatConditions.Clear()
        ApplyListDateFormatting()

        If e.ChildTable.Key = "Actions" Then
            strSQL = "Select * from tblOppositionActions where OppositionID=" & OppositionID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If

        If e.ChildTable.Key = "Dates" Then
            strSQL = "Select OppositionID, DateName, Completed, OppositionDate, DateID, OppositionDateID " &
            "from qvwOppositionDates where OppositionID=" & OppositionID
            e.ChildList = DataStuff.GetDataTable(strSQL)
        End If

    End Sub

    Private Sub ApplyListDateFormatting()
        On Error Resume Next
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition, OppositionDateID As Integer
        OppositionDateID = grdAlerts.GetValue("OppositionDateID")
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(Me.grdAlerts.Tables("Dates").Columns("OppositionDateID"),
            Janus.Windows.GridEX.ConditionOperator.Equal, OppositionDateID)
        fc.FormatStyle.BackColor = Color.Yellow
        Me.grdAlerts.Tables("Dates").FormatConditions.Add(fc)
    End Sub

    Private Sub grdAlerts_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.Resize
        On Error Resume Next
        Me.grdAlerts.RootTable.Columns("OppositionName").Width = (Me.grdAlerts.Width - 780)
    End Sub

    Private Sub grdAlerts_SortKeysChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.SortKeysChanged
        On Error Resume Next
        Me.grdAlerts.Row = 0
    End Sub

    Private Sub PrintAlerts()
        On Error Resume Next
        Dim strSort As String, strFilter As String, strField As String, strValue As String,
            i As Integer, strSQL As String, drReader As OleDb.OleDbDataReader

        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor

        strFilter = ""

        With Me

            If .cboSetPosition.Value > 0 Then
                strFilter = strFilter & " and PositionID=" & .cboSetPosition.Value
            End If

            If .cboSetContact.Value > 0 Then
                strFilter = strFilter & " and ContactID=" & .cboSetContact.Value
            End If

        End With

        With Me.grdAlerts.RootTable
            strSort = .SortKeys(0).Column.Key
        End With

        strFilter = strFilter & " and OppositionDateID in ("
        For i = 0 To Me.grdAlerts.RowCount
            GRow = Me.grdAlerts.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("OppositionDateID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        If Me.cboSetPosition.Value > 0 Then
            Dim rptAlertsPosition As New rptOppositionAlertsPosition
            strSQL = "SELECT distinct OppositionDateID, OppositionID, CompanyID, OppositionName, JurisdictionID, " &
            "ProceedingNumber, CompanyName, Jurisdiction, ListOrder, OppositionDate, Completed, DateID, " &
            "IsAlert, DateName, '' AS SubTitle, ContactID, PositionID, ContactName, PositionName, Suspended " &
            "from qvwOppositionDatesAndContacts where IsAlert <> 0 and ShowInAlerts <> 0 and Suspended = 0" & strFilter

            Select Case strSort
                Case "CompanyName"
                    strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                        "CompanyName, OppositionName, OppositionID, OppositionDate"

                Case "OppositionName"
                    strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                        "OppositionName, OppositionID, CompanyName, OppositionDate"

                Case "OppositionDate"
                    strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                        "OppositionDate, OppositionID,CompanyName, OppositionName"

                Case Else
                    strSQL = strSQL & " order by PositionName, PositionID, ContactName, ContactID, " &
                         "CompanyName, OppositionName, OppositionID, OppositionDate"

            End Select

            drReader = DataStuff.GetDataReader(strSQL)
            rptAlertsPosition.DataSource = drReader
            rptAlertsPosition.ReportDescription.Text = "Between " & Me.BetweenStart.Text & " and " & Me.BetweenEnd.Text
            AllForms.OpenReport()
            AllForms.frmReportPreview.ReportViewer.Document = rptAlertsPosition.Document
            rptAlertsPosition.Run()
            AllForms.frmReportPreview.Show()

        Else
            Dim rptAlerts As New rptOppositionAlerts
            strSQL = "SELECT distinct OppositionDateID, OppositionID, CompanyID, OppositionName, JurisdictionID, ProceedingNumber, CompanyName, " &
            "Jurisdiction, ListOrder, DateName, OppositionDate, Completed, DateID, ShowInAlerts, IsAlert, Suspended " &
            "from qvwOppositionDates Where IsAlert <> 0 and ShowInAlerts <> 0 and Suspended = 0" & strFilter

            Select Case strSort
                Case "CompanyName"
                    strSQL = strSQL & " order by CompanyName, OppositionDate, OppositionName"

                Case "OppositionName"
                    strSQL = strSQL & " order by OppositionName, CompanyName, OppositionDate"

                Case "OppositionDate"
                    strSQL = strSQL & " order by OppositionDate, CompanyName, OppositionName"

                Case Else
                    strSQL = strSQL & " order by CompanyName, OppositionDate, OppositionName"

            End Select


            drReader = DataStuff.GetDataReader(strSQL)
            rptAlerts.DataSource = drReader
            rptAlerts.ReportDescription.Text = "Between " & Me.BetweenStart.Text & " and " & Me.BetweenEnd.Text
            AllForms.OpenReport()
            AllForms.frmReportPreview.ReportViewer.Document = rptAlerts.Document
            rptAlerts.Run()
            AllForms.frmReportPreview.Show()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrintList()
        On Error Resume Next
        Dim strSort As String, strFilter As String, strField As String, strValue As String,
            i As Integer, strSQL As String, drReader As OleDb.OleDbDataReader

        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor
        strFilter = "OppositionID in ("
        strSort = ""

        For i = 0 To Me.grdList.RowCount
            GRow = Me.grdList.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & GRow.Cells("OppositionID").Value & ","
            End If
        Next
        strFilter = strFilter & "0)"

        With Me.grdList.RootTable
            For i = 0 To .FilterApplied.Conditions.Count - 1
                strField = .FilterApplied.Conditions(i).Column.Key
                strValue = .FilterApplied.Conditions(i).Value1
                If strField <> "" And strFilter <> "" Then
                    ' workaround because Access and SQL server have different ways of handling strings with quotes in them
                    strFilter = strFilter & " and " & GetFilter(strField, strValue)
                End If
            Next i

            For i = 0 To .SortKeys.Count - 1
                strSort = strSort & .SortKeys(i).Column.Key & ", "
            Next
        End With

        strSort = " order by " & strSort
        If InStr(strSort, "CompanyName") < 1 Then strSort = strSort & "CompanyName, "
        If InStr(strSort, "OppositionName") < 1 Then strSort = strSort & "OppositionName, "
        If InStr(strSort, "Jurisdiction") < 1 Then strSort = strSort & "Jurisdiction, "
        strSort = strSort & "OppositionID"

        Dim rptList As New rptOppositionsList
        strSQL = "Select * from qvwOppositions where " & strFilter & strSort

        drReader = DataStuff.GetDataReader(strSQL)
        rptList.DataSource = drReader
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
        Dim strSubject As String, dOppositionDate As Date, strDayBefore As String, strDayAfter As String,
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
                strSubject = strSubject & Replace(.Cells("OppositionName").Value, Chr(34), "") & " | "
                strSubject = strSubject & Replace(.Cells("CompanyName").Value, Chr(34), "") & " | "

                strSubject = strSubject & .Cells("Jurisdiction").Value & " | "
                strSubject = strSubject & .Cells("ProceedingNumber").Value & " | "
                strSubject = strSubject & .Cells("DateName").Value & " | "

                strBody = strBody & .Cells("OppositionName").Value & vbCrLf
                strBody = strBody & .Cells("CompanyName").Value & vbCrLf
                strBody = strBody & .Cells("Jurisdiction").Value & vbCrLf
                strBody = strBody & .Cells("ProceedingNumber").Value & vbCrLf
                strBody = strBody & .Cells("DateName").Value & " due on " & .Cells("OppositionDate").Value


                dOppositionDate = .Cells("OppositionDate").Value
                If IsDate(dOppositionDate) = False Then
                    MsgBox("Could not interpret date for " & .Cells("OppositionName").Value & ".  Please check the selected data and try again.")
                End If
            End With

            dOppositionDate = DateAdd("d", -iLeadDays, dOppositionDate)
            If sngAlertTime <> 0 Then
                dOppositionDate = DateAdd(DateInterval.Minute, sngAlertTime * 60, dOppositionDate)
            End If

            'if saturday or sunday, move warning to Friday
            If Weekday(dOppositionDate) = vbSunday Then dOppositionDate = DateAdd("d", -2, dOppositionDate)
            If Weekday(dOppositionDate) = vbSaturday Then dOppositionDate = DateAdd("d", -1, dOppositionDate)

            'needed for restrict clause later
            strDayBefore = Format(DateAdd("d", -1, dOppositionDate), "MMM dd, yyyy")
            strDayAfter = Format(DateAdd("d", 1, dOppositionDate), "MMM dd, yyyy")

            objTask = objOutlook.CreateItem(Outlook.OlItemType.olAppointmentItem)

            With objTask
                .Subject = strSubject
                .Body = strBody
                .AllDayEvent = IIf(sngAlertTime = 0, True, False)
                .ReminderMinutesBeforeStart = 0
                .ReminderSet = True
                .Start = dOppositionDate

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
        Me.grdAlerts.DataSource = DataStuff.GetDataTable("Select * from qvwOppositionEmailAlerts order by OppositionDate, CompanyName")
    End Sub

    Private Sub grdAlerts_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAlerts.RecordUpdated
        On Error Resume Next
        Dim iOppositionDateID As Long, bEmailSent As Boolean, bCompleted As Boolean, strSQL As String
        iOppositionDateID = Me.grdAlerts.GetValue("OppositionDateID")

        If Me.optEmailAlerts.Checked = True Then
            bEmailSent = Me.grdAlerts.GetValue("EmailSent")
            If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                strSQL = "update tblOppositionDates set EmailSent=" & IIf(bEmailSent = True, "-1", "0") &
                    " where OppositionDateID=" & iOppositionDateID
            Else
                strSQL = "update tblOppositionDates set EmailSent=" & IIf(bEmailSent = True, "1", "0") &
                    " where OppositionDateID=" & iOppositionDateID
            End If
            DataStuff.RunSQL(strSQL)
        End If

        If Me.optAlerts.Checked = True Then
            bCompleted = Me.grdAlerts.GetValue("Completed")
            If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                strSQL = "update tblOppositionDates set Completed=" & IIf(bCompleted = True, "-1", "0") &
                    " where OppositionDateID=" & iOppositionDateID
            Else
                strSQL = "update tblOppositionDates set Completed=" & IIf(bCompleted = True, "1", "0") &
                    " where OppositionDateID=" & iOppositionDateID
            End If
            DataStuff.RunSQL(strSQL)
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
                    strFilter = strFilter & GRow.Cells("OppositionDateID").Text & ","
                End If
            Next

            strFilter = strFilter & "0)"

            If bSent = True Then
                If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                    strSQL = "update tblOppositionDates set EmailSent= -1 where OppositionDateID in " & strFilter
                Else
                    strSQL = "update tblOppositionDates set EmailSent= 1 where OppositionDateID in " & strFilter
                End If
            Else
                strSQL = "update tblOppositionDates set EmailSent= 0 where OppositionDateID in " & strFilter
            End If

            DataStuff.RunSQL(strSQL)

        End If


    End Sub

    Private Sub GenerateEmails(ByVal GRow As Janus.Windows.GridEX.GridEXRow, ByVal Email As Outlook.MailItem)
        On Error Resume Next
        Dim strTo As String, strSubject As String, strMessage As String,
             drToList As OleDb.OleDbDataReader, strSQL As String

        strTo = ""
        strSQL = "SELECT distinct OppositionDateID, AutoEmail, EmailSent, ReceivesAlerts, FirstName, LastName, ContactEmail " &
        "from qvwOppositionDatesAndContacts where AutoEmail <> 0 and EmailSent = 0 and ReceivesAlerts <> 0 and OppositionDateID=" &
        GRow.Cells("OppositionDateID").Text
        drToList = DataStuff.GetDataReader(strSQL)

        'don't bother if there are no recipients
        If drToList.HasRows = False Then
            MsgBox("There are no contacts designated to receive alert emails for the opposition.")
            Exit Sub
        End If


        While drToList.Read
            strTo = strTo & drToList("ContactEmail") & ";"
        End While

        strSubject = GRow.Cells("EmailSubjectLine").Value.ToString

        strMessage = GRow.Cells("EmailAlert").Value.ToString
        strMessage = Replace(strMessage, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strMessage = Replace(strMessage, "[OpposingCompanyName]", GRow.Cells("OpposingCompanyName").Value.ToString)
        strMessage = Replace(strMessage, "[OppositionName]", GRow.Cells("OppositionName").Value.ToString)
        strMessage = Replace(strMessage, "[ProceedingNumber]", GRow.Cells("ProceedingNumber").Value.ToString)
        strMessage = Replace(strMessage, "[Status]", GRow.Cells("Status").Value.ToString)
        strMessage = Replace(strMessage, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        strSubject = Replace(strSubject, "[CompanyName]", GRow.Cells("CompanyName").Value.ToString)
        strSubject = Replace(strSubject, "[OpposingCompanyName]", GRow.Cells("OpposingCompanyName").Value.ToString)
        strSubject = Replace(strSubject, "[OppositionName]", GRow.Cells("OppositionName").Value.ToString)
        strSubject = Replace(strSubject, "[ProceedingNumber]", GRow.Cells("ProceedingNumber").Value.ToString)
        strSubject = Replace(strSubject, "[Status]", GRow.Cells("Status").Value.ToString)
        strSubject = Replace(strSubject, "[Jurisdiction]", GRow.Cells("Jurisdiction").Value.ToString)

        If RevaSettings.USADates = True Then
            strMessage = Replace(strMessage, "[OppositionDate]", Format(GRow.Cells("OppositionDate").Value, "MMM dd, yyyy"))
            strSubject = Replace(strSubject, "[OppositionDate]", Format(GRow.Cells("OppositionDate").Value, "MMM dd, yyyy"))
        Else
            strMessage = Replace(strMessage, "[OppositionDate]", Format(GRow.Cells("OppositionDate").Value, "dd MMM, yyyy"))
            strSubject = Replace(strSubject, "[OppositionDate]", Format(GRow.Cells("OppositionDate").Value, "dd MMM, yyyy"))
        End If

        GRow.BeginEdit()
        GRow.Cells("EmailSent").Value = True
        GRow.EndEdit()

        If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
            strSQL = "update tblOppositionDates set EmailSent= -1" &
                " where OppositionDateID=" & GRow.Cells("OppositionDateID").Value
        Else
            strSQL = "update tblOppositionDates set EmailSent= 1" &
                " where OppositionDateID=" & GRow.Cells("OppositionDateID").Value
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

    Private Sub frmOppositions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        AllForms.frmOppositions = Me
        iSecurityLevel = Globals.SecurityLevel

        'if there email alerts due, open that form
        If DataStuff.DCount("OppositionDateID", "vwOppositionEmailAlerts", "OppositionID<>0") > 0 Then
            Me.optEmailAlerts.Checked = True
        End If

        With Me
            If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
                .sepDemo.Visible = True
                .lblDemo.Visible = True
            Else
                .sepDemo.Visible = False
                .lblDemo.Visible = False
            End If

            .optLitigationDates.Checked = True
            .optClientAndOpposition.Checked = True
            SetDateDocumentView()
        End With

        SetSecurity()
        SetDateDocumentView()
        SetTrademarksView()
        SetDateFormats()
        GetOppositionsList()
        FillCompanies()
        FillJurisdictions()
        FillStatus()
        FillContactList()
        FillPositions()
        SetSecurity()

        'now we consider the form loaded, let stuff happen
        bFormLoaded = True
        SetBrowseGrid()
        'SetOptions()
        'SetNavigationButtons()

    End Sub

    Private Sub frmOppositions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        SaveOpposition()
        AllForms.frmOppositions = Nothing
        Globals.OppositionID = 0

        'trying to get a clean close
        If AllForms.frmTrademarks Is Nothing And AllForms.frmPatents Is Nothing And AllForms.frmLogin Is Nothing _
        And AllForms.frmPreferences Is Nothing And AllForms.frmReports Is Nothing _
        And AllForms.frmCompanies Is Nothing And AllForms.frmOppositions Is Nothing Then

            Application.Exit()
        End If
    End Sub

    Private Sub Tabs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.SelectedIndexChanged
        On Error Resume Next
        'keep user from opening empty data forms
        If (Me.Tabs.SelectedIndex = 1) Then
            If (Globals.OppositionID = 0) Then
                Me.Tabs.SelectedIndex = 0
            End If
        End If

        SetNavigationButtons()
    End Sub

    Friend Sub SetDateFormats()
        On Error Resume Next
        With Me
            If RevaSettings.USADates = True Then
                .grdDates.RootTable.Columns("OppositionDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.Columns("OppositionDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "MMM dd, yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("OppositionDate").FormatString = "MMM dd, yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "MMM dd, yyyy"
                .grdOppositionMarks.RootTable.Columns("FilingDate").FormatString = "MMM dd, yyyy"
                .grdOppositionMarks.RootTable.Columns("FirstUseDate").FormatString = "MMM dd, yyyy"
                .grdOppositionMarks.RootTable.Columns("RegistrationDate").FormatString = "MMM dd, yyyy"
            Else
                .grdDates.RootTable.Columns("OppositionDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.Columns("OppositionDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Actions").Columns("ActionDate").FormatString = "dd MMM yyyy"
                .grdAlerts.RootTable.ChildTables("Dates").Columns("OppositionDate").FormatString = "dd MMM yyyy"
                .grdActions.RootTable.Columns("ActionDate").FormatString = "dd MMM yyyy"
                .grdOppositionMarks.RootTable.Columns("FilingDate").FormatString = "dd MMM yyyy"
                .grdOppositionMarks.RootTable.Columns("FirstUseDate").FormatString = "dd MMM yyyy"
                .grdOppositionMarks.RootTable.Columns("RegistrationDate").FormatString = "dd MMM yyyy"
            End If

        End With
    End Sub

    Private Sub SetSecurity()
        On Error Resume Next

        With Me
            '.StatusID.ReadOnly = (iSecurityLevel = 3)
            '.CompanyID.ReadOnly = (iSecurityLevel = 3)
            '.OpposingCompanyID.ReadOnly = (iSecurityLevel = 3)
            '.JurisdictionID.ReadOnly = (iSecurityLevel = 3)

            .OppositionName.ReadOnly = (iSecurityLevel = 3)
            .OppositionNotes.ReadOnly = (iSecurityLevel = 3)
            .ProceedingNumber.ReadOnly = (iSecurityLevel = 3)
            .btnNewOpposition.Enabled = (iSecurityLevel < 3)
        End With

        'Janus has their own versions of true and false; have to use them
        Select Case iSecurityLevel
            Case 1 'TrademarkUser

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
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
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
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
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With


            Case 3 'View Only

                With Me.grdList
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
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
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdDocumentLinks
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

        End Select

        'same routine for Opposition preferences

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

                Me.btnAddTrademarkDates.Enabled = True

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

                Me.btnAddTrademarkDates.Enabled = True

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

                Me.btnAddTrademarkDates.Enabled = False

        End Select

    End Sub

    Private Sub SetNavigationButtons()
        On Error Resume Next
        With Me

            Select Case Globals.NavigateOppositionsFrom
                Case 1  'list view
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                    .grdList.Row < (grdList.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (.grdList.Row > 0)
                    .RecordCount.Text = (.grdList.Row + 1) & " of " & .grdList.RowCount

                Case 2  'either alerts view
                    .btnNextRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                    .grdAlerts.Row < (grdAlerts.RowCount - 1)
                    .btnPrevRecord.Enabled = ((.Tabs.SelectedIndex = 1) Or (.Tabs.SelectedIndex = 2)) And
                        (.grdAlerts.Row > 0)
                    .RecordCount.Text = (.grdAlerts.Row + 1).ToString & " of " & .grdAlerts.RowCount.ToString

                Case 3 'trademarks
                    .btnNextRecord.Enabled = False
                    .btnPrevRecord.Enabled = False
                    .RecordCount.Text = ""
            End Select

            If Not (.Tabs.SelectedIndex = 1) Then
                .RecordCount.Text = ""
            End If

        End With

    End Sub

    Friend Sub GetOpposition()
        On Error Resume Next
        rsOpposition.GetFromSQL("Select * from tblOppositions where OppositionID=" & Globals.OppositionID)

        With rsOpposition
            .BindData(Me.StatusID)
            .BindData(Me.CompanyID)
            .BindData(Me.OpposingCompanyID)
            .BindData(Me.OppositionName)
            .BindData(Me.JurisdictionID)
            .BindData(Me.ProceedingNumber)
            .BindData(Me.OppositionNotes)
            .BindData(Me.optPlaintiff, "Checked", "ClientIsPlaintiff")
            If Not (rsOpposition.CurrentRow("ClientIsPlaintiff") = True) Then
                Me.optDefendant.Checked = True
            End If
        End With

        'store so we can warn user if changed later
        Me.iOldJurisdictionID = JurisdictionID.Value

        GetCompanyMarks()
        FillDateList()
        GetDates()
        GetActions()
        GetContacts()
        GetClientMarks()
        GetOppositionMarks()
        GetDocuments()
        Me.Tabs.SelectedIndex = 1
        SetNavigationButtons()


    End Sub

    Private Sub btnCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompany.Click
        On Error Resume Next
        If Nz(Me.CompanyID.Value, 0) = 0 Then Exit Sub
        SaveOpposition()
        AllForms.OpenCompanies()
        Globals.CompanyID = Me.CompanyID.Value
        AllForms.frmCompanies.GetCompany()
        AllForms.frmCompanies.Tabs.SelectedIndex = 1
    End Sub

    Private Sub btnOpposingCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpposingCompany.Click
        On Error Resume Next
        If Nz(Me.OpposingCompanyID.Value, 0) = 0 Then Exit Sub
        SaveOpposition()
        AllForms.OpenCompanies()
        Globals.CompanyID = Me.OpposingCompanyID.Value
        AllForms.frmCompanies.GetCompany()
        AllForms.frmCompanies.Tabs.SelectedIndex = 1
    End Sub

    Private Sub btnProceeding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceeding.Click
        On Error Resume Next
        If Nz(Me.JurisdictionID.Value, 0) = 0 Then
            MsgBox("You must select a jurisdiction before using the application link.")
            Exit Sub
        End If

        'still here, then proceed
        Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strProceeding As String,
            bUsesFields As Boolean, strFieldName As String, strSQL As String

        strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value

        dr = DataStuff.GetDataReader(strSQL)
        dr.Read()
        strTargetURL = dr("OppositionURL") & ""

        If strTargetURL = "" Then
            MsgBox("Opposition search is not configured or not available for this jurisdiction.")
            Exit Sub
        End If

        bUsesFields = dr("OppositionUsesFields")
        strFieldName = dr("OppositionField")
        strProceeding = Me.ProceedingNumber.Text & ""
        If dr("OppositionNumbersOnly") = True Then strProceeding = NumbersOnly(strProceeding)
        strTargetURL = Replace(strTargetURL, "[OppositionNumber]", strProceeding)

        AllForms.OpenBrowser()
        With AllForms.frmBrowser
            If bUsesFields = True Then
                .btnGetNumber.Visible = True
                .btnGetNumber.Text = "Get Proceeding Number"
                .FieldName = strFieldName & ""
                .SearchNumber = strProceeding & ""
            Else
                .btnGetNumber.Visible = False
            End If
            .cboAddress.Text = strTargetURL
            .Browser.Navigate(strTargetURL)
        End With
    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        On Error Resume Next
        SaveOpposition()
        AllForms.OpenOppositionStatus()
    End Sub

    Friend Sub SaveOpposition()
        On Error Resume Next
        If Not (rsOpposition.Table Is Nothing) Then
            rsOpposition.Update()
        End If

        'actions
        Me.grdActions.UpdateData()
        rsActions.Update()

        'client marks
        Me.grdClientMarks.UpdateData()
        rsClientMarks.Update()

        'opposition marks
        Me.grdOppositionMarks.UpdateData()
        rsOppositionMarks.Update()

        'litigation dates
        ReOrderDates()
        Me.grdDates.UpdateData()
        rsDates.Update()

        'contacts
        Me.grdContacts.UpdateData()

        'documents
        Me.grdDocumentLinks.UpdateData()

    End Sub

    Private Sub tbOpposition_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbOpposition.Leave
        On Error Resume Next
        SaveOpposition()
    End Sub

    Private Sub tbList_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbList.Enter
        On Error Resume Next
        SetNavigationButtons()
    End Sub

    Private Sub tbPreferences_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPreferences.Enter
        On Error Resume Next
        'no use filling this unless they enter this page
        If dtMarkDates Is Nothing Then
            GetTrademarkMasterDates()
        End If
    End Sub

    Private Sub CompanyID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CompanyID.Validated
        On Error Resume Next
        SaveOpposition()
        AddContacts()
        GetCompanyMarks()
    End Sub

    Private Sub JurisdictionID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JurisdictionID.Validated
        On Error Resume Next
        FillDateList()

        'user changed jurisdictions of the Opposition
        If (Nz(Me.JurisdictionID.Value, 0) <> Me.iOldJurisdictionID) And (Nz(Me.iOldJurisdictionID, 0) <> 0) Then

            'make sure we're on trademark page
            Me.Tabs.SelectedIndex = 1

            Dim strMessage As String
            strMessage = "You are about to change the jurisdiction for this opposition.  " &
                "Opposition dates with the same names will remain intact, " &
                "but others will be deleted.  Proceed?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.JurisdictionID.Value = Me.iOldJurisdictionID
                Exit Sub
            End If
            SaveOpposition()
        End If

        SaveOpposition()
        GetDates()

    End Sub

    Private Sub btnPrintOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOne.Click
        On Error Resume Next
        Dim strSort As String
        Dim drReader As OleDb.OleDbDataReader, rptOpposition As New rptOneOpposition, strSQL As String
        SaveOpposition()
        Me.Cursor = Cursors.WaitCursor
        strSort = "CompanyName, OppositionName, Jurisdiction, OppositionID, ListOrder, OppositionDate"

        strSQL = "SELECT OppositionID, StatusID, CompanyID, OppositionName, JurisdictionID, ProceedingNumber, CompanyName, " &
        "OppositionCompany, ListOrder, DateName, OppositionDate, Completed, IsAlert, Status, Jurisdiction " &
        "from qvwOppositionDates where OppositionID=" & Globals.OppositionID & " order by " & strSort

        drReader = DataStuff.GetDataReader(strSQL)
        rptOpposition.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptOpposition.Document
        rptOpposition.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Kill The Wheel"

    Private Sub ComboClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.ButtonClick, OpposingCompanyID.ButtonClick, JurisdictionID.ButtonClick, CompanyID.ButtonClick
        On Error Resume Next
        If Globals.SecurityLevel < 3 Then
            Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
            Combo = sender
            Combo.ReadOnly = False
            Combo.DroppedDown = True
        End If
    End Sub

    Private Sub ComboCloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusID.CloseUp, OpposingCompanyID.CloseUp, JurisdictionID.CloseUp, CompanyID.CloseUp
        On Error Resume Next
        Dim Combo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Combo = sender
        Combo.ReadOnly = True
    End Sub

#End Region

#Region "Escape/Undo for TextBoxes"

    Private Sub OppositionName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OppositionName.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.OppositionName.Undo()
    End Sub

    Private Sub ProceedingNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProceedingNumber.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.ProceedingNumber.Undo()
    End Sub

    Private Sub OppositionNotes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OppositionNotes.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.OppositionNotes.Undo()
    End Sub

#End Region

#Region "Fill Data Tables / Drop Downs"

    Friend Sub FillCompanies()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select CompanyID, CompanyName from tblCompanies order by CompanyName"
        dtCompanies = DataStuff.GetDataTable(strSQL)
        Me.CompanyID.DataSource = dtCompanies
        Me.OpposingCompanyID.DataSource = dtCompanies
    End Sub

    Friend Sub FillJurisdictions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsTrademark <> 0 Order by Jurisdiction"
        dtJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.JurisdictionID.DataSource = dtJurisdictions
        Me.cboMarkJurisdiction.DataSource = dtJurisdictions
    End Sub

    Friend Sub FillStatus()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select StatusID, Status from tblOppositionStatus order by Status"
        dtStatus = DataStuff.GetDataTable(strSQL)
        Me.StatusID.DataSource = dtStatus
    End Sub

    Friend Sub FillContactList()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select distinct ContactID, ContactName, CompanyName from qvwContactsAndCompanies where ContactID is not null order by ContactName"
        dtContactList = DataStuff.GetDataTable(strSQL)
        Me.grdContacts.DropDowns("cboContact").SetDataBinding(dtContactList, "")
    End Sub

    Friend Sub FillPositions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select PositionID, [PositionName] from tblPositions where IsTrademark <> 0 order by [PositionName]"
        dtPositions = DataStuff.GetDataTable(strSQL)
        Me.grdContacts.DropDowns("cboPositions").SetDataBinding(dtPositions, "")
    End Sub

    Private Sub GetOppositionsList()
        On Error Resume Next
        dtOppositionsList = DataStuff.GetDataTable("Select * from qvwOppositions order by OppositionName")
        Me.grdList.DataSource = dtOppositionsList
    End Sub

    Private Sub FillDateList()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from qvwOppositionJurisdictionDates order by ListOrder"
        dtDateList = DataStuff.GetDataTable(strSQL)
        Me.grdDates.DropDowns("cboOppositionDates").SetDataBinding(dtDateList, "")
    End Sub

#End Region

#Region "Fill Grid Subforms"

    Private Sub GetCompanyMarks()
        On Error Resume Next
        Dim strSQL As String, iCompanyID As Integer
        iCompanyID = rsOpposition.CurrentRow("CompanyID")

        strSQL = "Select distinct TrademarkID, TrademarkName, RegistrationNumber, ApplicationNumber, Jurisdiction" &
            " from qvwTrademarks where CompanyID=" & iCompanyID & " order by TrademarkName"
        dtCompanyMarks = DataStuff.GetDataTable(strSQL)
        Me.grdClientMarks.DropDowns("cboTrademarks").SetDataBinding(dtCompanyMarks, "")
    End Sub

    Private Sub GetActions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblOppositionActions where OppositionID=" & Globals.OppositionID &
            " order by ActionDate, OppositionActionID"
        rsActions.GetFromSQL(strSQL)
        Me.grdActions.DataSource = rsActions.Table
    End Sub

    Friend Sub GetContacts()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "SELECT distinct CompanyID, ContactID, OppositionContactID, CompanyName, ContactName, ContactPhone, " &
        "OppositionID, PositionID, ContactEmail from qvwOppositionContacts where OppositionID=" & Globals.OppositionID
        dtContacts = DataStuff.GetDataTable(strSQL)
        Me.grdContacts.DataSource = dtContacts
    End Sub

    Friend Sub GetDates()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblOppositionDates where OppositionID=" & Globals.OppositionID & " order by ListOrder"
        rsDates.GetFromSQL(strSQL)
        Me.grdDates.DataSource = rsDates.Table
    End Sub

    Friend Sub GetDocuments()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblOppositionDocuments where OppositionID=" & Globals.OppositionID
        dtDocLinks = DataStuff.GetDataTable(strSQL)
        Me.grdDocumentLinks.DataSource = dtDocLinks
    End Sub

    Friend Sub GetClientMarks()
        On Error Resume Next
        rsClientMarks.GetFromSQL("Select * from tblOppositionClientTrademarks where OppositionID=" &
            Globals.OppositionID)
        Me.grdClientMarks.DataSource = rsClientMarks.Table
    End Sub

    Friend Sub GetOppositionMarks()
        On Error Resume Next
        rsOppositionMarks.GetFromSQL("Select * from tblOppositionTrademarks where OppositionID=" &
            Globals.OppositionID)
        Me.grdOppositionMarks.DataSource = rsOppositionMarks.Table
    End Sub

#End Region

#Region "Trademark Grids"

    Private Sub optClientAndOpposition_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optClientAndOpposition.CheckedChanged
        On Error Resume Next
        If Me.optClientAndOpposition.Checked = True Then SetTrademarksView()
    End Sub

    Private Sub optClientMarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optClientMarks.CheckedChanged
        On Error Resume Next
        If Me.optClientMarks.Checked = True Then SetTrademarksView()
    End Sub

    Private Sub optOppositionMarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOppositionMarks.CheckedChanged
        On Error Resume Next
        If Me.optOppositionMarks.Checked = True Then SetTrademarksView()
    End Sub

    Private Sub SetTrademarksView()
        On Error Resume Next
        With Me

            If .optClientMarks.Checked = True Then
                .grdClientMarks.Visible = True
                .grdOppositionMarks.Visible = False
                With .grdClientMarks
                    .Left = 40
                    .Top = 138
                    .Width = 925
                    .Height = 96
                    .RootTable.Columns("TrademarkNote").Visible = True
                    .RootTable.Columns("lnkDelete").Visible = True
                    .RootTable.Columns("ApplicationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                    .RootTable.Columns("RegistrationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                    .RootTable.Columns("TrademarkID").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                    If iSecurityLevel < 3 Then
                        .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                        .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    End If
                    If iSecurityLevel = 1 Then
                        .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                    Else
                        .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                    End If
                End With
            End If

            If .optOppositionMarks.Checked = True Then
                .grdClientMarks.Visible = False
                .grdOppositionMarks.Visible = True
                With .grdOppositionMarks
                    .Left = 40
                    .Top = 138
                    .Width = 925
                    .Height = 96
                    .RootTable.Columns("Classes").Visible = True
                    .RootTable.Columns("FilingDate").Visible = True
                    .RootTable.Columns("FirstUseDate").Visible = True
                    .RootTable.Columns("RegistrationDate").Visible = True
                    .RootTable.Columns("lnkDelete").Visible = True
                    .RootTable.Columns("ApplicationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                    .RootTable.Columns("RegistrationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Text
                    If iSecurityLevel < 3 Then
                        .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                        .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    End If
                    If iSecurityLevel = 1 Then
                        .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                    Else
                        .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                    End If
                End With
            End If

            If .optClientAndOpposition.Checked = True Then
                .grdClientMarks.Visible = True
                .grdOppositionMarks.Visible = True

                With .grdClientMarks
                    .Left = 40
                    .Top = 138
                    .Width = 456
                    .Height = 96
                    .RootTable.Columns("TrademarkNote").Visible = False
                    .RootTable.Columns("lnkDelete").Visible = False
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("ApplicationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                    .RootTable.Columns("RegistrationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                    .RootTable.Columns("TrademarkID").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                End With

                With .grdOppositionMarks
                    .Left = 508
                    .Top = 138
                    .Width = 456
                    .Height = 96
                    .RootTable.Columns("Classes").Visible = False
                    .RootTable.Columns("FilingDate").Visible = False
                    .RootTable.Columns("FirstUseDate").Visible = False
                    .RootTable.Columns("RegistrationDate").Visible = False
                    .RootTable.Columns("lnkDelete").Visible = False
                    .RootTable.Columns("ApplicationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                    .RootTable.Columns("RegistrationNumber").ColumnType = Janus.Windows.GridEX.ColumnType.Link
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End With

            End If

        End With
    End Sub

    Private Sub grdClientMarks_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdClientMarks.AddingRecord
        On Error Resume Next
        Me.grdClientMarks.SetValue("OppositionID", Globals.OppositionID)
    End Sub

    Private Sub grdClientMarks_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdClientMarks.FormattingRow
        On Error Resume Next
        iTrademarkID = e.Row.Cells("TrademarkID").Value
        DMarkRow = dtCompanyMarks.Select("TrademarkID=" & iTrademarkID)(0)
        e.Row.Cells("ApplicationNumber").Text = DMarkRow("ApplicationNumber")
        e.Row.Cells("RegistrationNumber").Text = DMarkRow("RegistrationNumber")
    End Sub

    Private Sub grdClientMarks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdClientMarks.LinkClicked
        On Error Resume Next
        SaveOpposition()
        Select Case e.Column.Key
            Case "TrademarkID"
                Globals.TrademarkID = Me.grdClientMarks.GetValue("TrademarkID")
                Globals.NavigateMarksFrom = 5
                AllForms.OpenTrademarks()
                AllForms.frmTrademarks.GetTrademark()
                AllForms.frmTrademarks.Tabs.SelectedIndex = 1

            Case "ApplicationNumber"
                If Nz(Me.JurisdictionID.Value, 0) = 0 Then
                    MsgBox("You must select a jurisdiction before using the application link.")
                    Exit Sub
                End If

                'still here, then proceed
                Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strAppNumber As String,
                    bUsesFields As Boolean, strFieldName As String, strSQL As String

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
                strAppNumber = Me.grdClientMarks.GetRow.Cells("ApplicationNumber").Text & ""
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

            Case "RegistrationNumber"

                If Nz(Me.JurisdictionID.Value, 0) = 0 Then
                    MsgBox("You must select a jurisdiction before using the Registration link.")
                    Exit Sub
                End If


                'still here, then proceed
                Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strRegNumber As String,
                    bUsesFields As Boolean, strFieldName As String, strSQL As String

                strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value
                dr = DataStuff.GetDataReader(strSQL)
                dr.Read()
                strTargetURL = dr("RegistrationURL") & ""

                If strTargetURL = "" Then
                    MsgBox("Registration search is not configured or not available for this jurisdiction.")
                    Exit Sub
                End If

                bUsesFields = dr("RegistrationUsesFields")
                strFieldName = dr("RegistrationField")
                strRegNumber = Me.grdClientMarks.GetRow.Cells("RegistrationNumber").Text & ""
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

            Case "lnkDelete"
                If iSecurityLevel < 2 Then
                    Dim strMsg As String
                    strMsg = "Are you sure you want to delete this mark from the list?"
                    If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    Me.grdClientMarks.CurrentRow.Delete()
                End If
        End Select

    End Sub

    Private Sub grdOppositionMarks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdOppositionMarks.LinkClicked
        On Error Resume Next

        Select Case e.Column.Key

            Case "ApplicationNumber"
                If Nz(Me.JurisdictionID.Value, 0) = 0 Then
                    MsgBox("You must select a jurisdiction before using the application link.")
                    Exit Sub
                End If

                'still here, then proceed
                Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strAppNumber As String,
                    bUsesFields As Boolean, strFieldName As String, strSQL As String

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
                strAppNumber = Me.grdOppositionMarks.GetRow.Cells("ApplicationNumber").Text & ""
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

            Case "RegistrationNumber"

                If Nz(Me.JurisdictionID.Value, 0) = 0 Then
                    MsgBox("You must select a jurisdiction before using the Registration link.")
                    Exit Sub
                End If

                'still here, then proceed
                Dim dr As OleDb.OleDbDataReader, strTargetURL As String, strRegNumber As String,
                    bUsesFields As Boolean, strFieldName As String, strSQL As String

                strSQL = "Select * from tblJurisdictions where JurisdictionID=" & Me.JurisdictionID.Value
                dr = DataStuff.GetDataReader(strSQL)
                dr.Read()
                strTargetURL = dr("RegistrationURL") & ""

                If strTargetURL = "" Then
                    MsgBox("Registration search is not configured or not available for this jurisdiction.")
                    Exit Sub
                End If

                bUsesFields = dr("RegistrationUsesFields")
                strFieldName = dr("RegistrationField")
                strRegNumber = Me.grdOppositionMarks.GetRow.Cells("RegistrationNumber").Text & ""
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

            Case "lnkDelete"
                If iSecurityLevel < 2 Then
                    Dim strMsg As String
                    strMsg = "Are you sure you want to delete this mark from the list?"
                    If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    Me.grdOppositionMarks.CurrentRow.Delete()
                End If

        End Select
    End Sub

    Private Sub grdOppositionMarks_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdOppositionMarks.AddingRecord
        On Error Resume Next
        Me.grdOppositionMarks.SetValue("OppositionID", Globals.OppositionID)
    End Sub

#End Region

#Region "Actions Grid"

    Private Sub grdActions_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdActions.AddingRecord
        On Error Resume Next
        Me.grdActions.SetValue("OppositionID", Globals.OppositionID)
        Me.grdActions.SetValue("ActionDate", Date.Now)
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

    Private Sub btnPrintActions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintActions.Click
        On Error Resume Next
        Dim strSort As String
        Dim drReader As OleDb.OleDbDataReader, rptOppositionActions As New rptOppositionActions, strSQL As String
        SaveOpposition()
        Me.Cursor = Cursors.WaitCursor
        strSort = "CompanyName, OppositionName, Jurisdiction, OppositionID, ActionDate"

        strSQL = "SELECT OppositionID, StatusID, CompanyID, OppositionName, JurisdictionID, ProceedingNumber, CompanyName, " &
        "Jurisdiction, Status, ActionDate, OppositionAction, ActionHours, ActionBilled, Expenses, BilledHours, " &
        "UnbilledHours, BilledExpenses, UnbilledExpenses, ExpensesBilled from qvwOppositionActions where OppositionID=" &
        Globals.OppositionID & " order by " & strSort

        drReader = DataStuff.GetDataReader(strSQL)
        rptOppositionActions.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptOppositionActions.Document
        rptOppositionActions.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Contacts Grid"

    Private Sub AddContacts()
        On Error Resume Next
        Dim iCompanyID As Integer, strSQL As String
        iCompanyID = Nz(Me.CompanyID.Value, 0)
        If iCompanyID = 0 Then Exit Sub

        strSQL = "Insert into tblOppositionContacts (OppositionID, ContactID, PositionID) Select " &
            Globals.OppositionID & ", ContactID, PositionID from tblContacts where CompanyID=" & iCompanyID &
                " and PositionID is not null and PositionID in (Select PositionID from tblPositions" &
                " where IsTrademark <> 0)"
        DataStuff.RunSQL(strSQL)

        GetContacts()

    End Sub

    Private Sub grdContacts_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "PositionID" Then
            SaveOpposition()
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
                    strSubject = .OppositionName.Text & " | " & .JurisdictionID.Text &
                        " | Proc# " & .ProceedingNumber.Text
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
            If MsgBox("Are you sure you want to delete this contact from the Opposition?",
                MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iOppositionContactID As Integer
            iOppositionContactID = Me.grdContacts.GetValue("OppositionContactID")
            strSQL = "Delete from tblOppositionContacts where OppositionContactID=" & iOppositionContactID
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
                    strSubject = .OppositionName.Text & " | " & .JurisdictionID.Text &
                        " | Proc# " & .ProceedingNumber.Text

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
            SaveOpposition()
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
            rsContacts.GetFromSQL("Select * from tblOppositionContacts where OppositionContactID=0")
            dRow = rsContacts.Table.Rows.Add
            dRow("OppositionID") = Globals.OppositionID
            dRow("PositionID") = .GetValue("PositionID")
            dRow("ContactID") = .GetValue("ContactID")
        End With
        rsContacts.Update()
        GetContacts()
    End Sub

    Private Sub grdContacts_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContacts.RecordUpdated
        On Error Resume Next
        Dim rsContacts As New RecordSet, dRow As DataRow
        With Me.grdContacts
            rsContacts.GetFromSQL("Select * from tblOppositionContacts where OppositionContactID=" &
                .GetValue("OppositionContactID"))
            dRow = rsContacts.CurrentRow
            dRow("PositionID") = .GetValue("PositionID")
            dRow("ContactID") = .GetValue("ContactID")
        End With
        rsContacts.Update()
        GetContacts()

    End Sub

#End Region

#Region "Documents Grid"

    Private Sub grdDocumentLinks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDocumentLinks.LinkClicked
        On Error Resume Next
        If e.Column.Key = "SetLink" Then

            If Globals.SecurityLevel = 3 Then Exit Sub

            If grdDocumentLinks.GetValue("IsFolder") = False Then
                With Me.OpenFileDialog
                    If My.Settings.AccessConnection = My.Settings.CurrentConnection Then
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
                    If My.Settings.CurrentConnection = My.Settings.AccessConnection Then
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
            Dim strSQL As String, iOppositionDocID As Integer
            iOppositionDocID = Me.grdDocumentLinks.GetValue("OppositionDocID")
            strSQL = "delete from tblOppositionDocuments where OppositionDocID = " & iOppositionDocID
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

        rsRecord.GetFromSQL("Select * from tblOppositionDocuments where OppositionDocID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdDocumentLinks
            dRow("OppositionID") = Globals.OppositionID
            dRow("DocumentLink") = .GetValue("DocumentLink")
            dRow("DocDescription") = .GetValue("DocDescription")
            dRow("OnExtraNet") = False
            dRow("IsFolder") = IIf(.GetValue("IsFolder") = False, False, True)
        End With
        rsRecord.Update()
    End Sub

    Private Sub grdDocumentLinks_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumentLinks.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iOppositionDocID As Integer

        With Me.grdDocumentLinks
            iOppositionDocID = .GetValue("OppositionDocID")
            rsRecord.GetFromSQL("Select * from tblOppositionDocuments where OppositionDocID=" & iOppositionDocID)
            dRow = rsRecord.CurrentRow
            dRow("DocumentLink") = .GetValue("DocumentLink")
            dRow("DocDescription") = .GetValue("DocDescription")
            dRow("OnExtraNet") = False
            dRow("IsFolder") = IIf(.GetValue("IsFolder") = False, False, True)
        End With
        rsRecord.Update()
    End Sub

#End Region

#Region "Dates Grid / Date Events"

    Private Sub optLitigationDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLitigationDates.CheckedChanged
        On Error Resume Next
        If Me.optLitigationDates.Checked = True Then SetDateDocumentView()
    End Sub

    Private Sub optLitigationActions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLitigationActions.CheckedChanged
        On Error Resume Next
        If Me.optLitigationActions.Checked = True Then SetDateDocumentView()
    End Sub

    Private Sub optDocumentLinks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDocumentLinks.CheckedChanged
        On Error Resume Next
        If Me.optDocumentLinks.Checked = True Then SetDateDocumentView()
    End Sub

    Private Sub chkReOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReOrder.CheckedChanged
        On Error Resume Next
        SetDateDocumentView()
        If Me.chkReOrder.Checked = False Then
            grdDates.UpdateData()
            rsDates.Update()
        End If
    End Sub

    Private Sub grdDates_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDates.AddingRecord
        On Error Resume Next
        Dim iJurisdictionID As Integer
        iJurisdictionID = Me.JurisdictionID.Value
        With Me.grdDates
            .SetValue("OppositionID", Globals.OppositionID)
            .SetValue("JurisdictionID", iJurisdictionID)
            .SetValue("ListOrder", grdDates.RecordCount)
            .SetValue("EmailSent", False)
            .SetValue("Completed", False)
            .SetValue("Suspended", False)
        End With
    End Sub

    Private Sub grdDates_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Me.grdDates.CurrentRow.Delete()
            ReOrderDates()
            grdDates.UpdateData()
            rsDates.Update()
        End If

        If e.Column.Key = "MoveUp" Then

            Dim iOrder As Integer, iNewOrder As Integer
            Dim iDateID As Integer, iSwitchDateID As Integer
            Dim iRow As Integer, GRow As Janus.Windows.GridEX.GridEXRow
            Dim dRow As DataRow, i As Integer

            iOrder = Me.grdDates.GetValue("ListOrder")

            If iOrder > 1 Then

                iDateID = Me.grdDates.GetValue("OppositionDateID")
                iRow = Me.grdDates.Row
                'get values from row above
                GRow = Me.grdDates.GetRow(iRow - 1)
                iNewOrder = GRow.Cells("ListOrder").Value
                iSwitchDateID = GRow.Cells("OppositionDateID").Value

                For i = 0 To rsDates.Table.Rows.Count - 1
                    dRow = rsDates.Table.Rows(i)
                    Select Case dRow("OppositionDateID")
                        Case iDateID
                            dRow("ListOrder") = iNewOrder
                        Case iSwitchDateID
                            dRow("ListOrder") = iOrder
                    End Select
                Next i
                Me.grdDates.Row = iRow - 1
            End If

        End If

        If e.Column.Key = "MoveDown" Then

            Dim iOrder As Integer, iNewOrder As Integer
            Dim iDateID As Integer, iSwitchDateID As Integer
            Dim iRow As Integer, GRow As Janus.Windows.GridEX.GridEXRow
            Dim dRow As DataRow, i As Integer

            iOrder = Me.grdDates.GetValue("ListOrder")

            If iOrder < Me.grdDates.RowCount Then
                iDateID = Me.grdDates.GetValue("OppositionDateID")
                iRow = Me.grdDates.Row
                'get values from Date below
                GRow = Me.grdDates.GetRow(iRow + 1)
                iNewOrder = GRow.Cells("ListOrder").Value
                iSwitchDateID = GRow.Cells("OppositionDateID").Value

                For i = 0 To rsDates.Table.Rows.Count - 1
                    dRow = rsDates.Table.Rows(i)
                    Select Case dRow("OppositionDateID")
                        Case iDateID
                            dRow("ListOrder") = iNewOrder
                        Case iSwitchDateID
                            dRow("ListOrder") = iOrder
                    End Select
                Next i
                Me.grdDates.Row = iRow + 1
            End If

        End If

    End Sub

    Private Sub ReOrderDates()
        On Error Resume Next
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To grdDates.RecordCount - 1
            GRow = grdDates.GetRow(i)
            GRow.BeginEdit()
            GRow.Cells("ListOrder").Value = (i + 1)
            GRow.EndEdit()
        Next
    End Sub

    Private Sub btnDatesFromTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatesFromTemplate.Click
        On Error Resume Next
        Dim iJurisdictionID As Integer, strSQL As String, rsOppositionDates As New RecordSet, strFilter As String, _
            iDateID As Integer, drJurisdictionDates As OleDb.OleDbDataReader, iOppositionID As Integer

        iJurisdictionID = Nz(Me.JurisdictionID.Value, 0)
        iOppositionID = Globals.OppositionID

        If iJurisdictionID = 0 Then
            MsgBox("You must select the jurisdiction first.")
            Exit Sub
        End If

        strSQL = "Select * from tblOppositionDates where OppositionID=" & iOppositionID
        rsOppositionDates.GetFromSQL(strSQL)

        strSQL = "Select * from tblOppositionJurisdictionDates where JurisdictionID=" & iJurisdictionID & _
            " order by ListOrder"
        drJurisdictionDates = DataStuff.GetDataReader(strSQL)

        If drJurisdictionDates.HasRows = False Then
            MsgBox("There are no dates in the template for this jurisdiction.")
            Exit Sub
        End If

        FillDateList()

        While drJurisdictionDates.Read
            iDateID = drJurisdictionDates("DateID")
            'make sure it's not a blank dateID
            If iDateID <> 0 Then
                'make sure it doesn't already exist
                strFilter = "DateID=" & iDateID
                If rsOppositionDates.RecordExists(strFilter) = False Then
                    rsOppositionDates.AddRow()
                    'final precaution, make sure it's a new row
                    If rsOppositionDates.CurrentRow("DateID").ToString = "" Then
                        rsOppositionDates.CurrentRow("DateID") = iDateID
                        rsOppositionDates.CurrentRow("JurisdictionID") = iJurisdictionID
                        rsOppositionDates.CurrentRow("OppositionID") = iOppositionID
                        rsOppositionDates.CurrentRow("ListOrder") = drJurisdictionDates("ListOrder")
                        'rsOppositionDates.CurrentRow("JurisdictionDateID") = drJurisdictionDates("JurisdictionDateID")
                        rsOppositionDates.CurrentRow("EmailSent") = False
                        rsOppositionDates.CurrentRow("Completed") = False
                        rsOppositionDates.CurrentRow("Suspended") = False
                    End If
                End If
            End If
        End While

        rsOppositionDates.Update()
        GetDates()

    End Sub

    Private Sub SetDateDocumentView()
        On Error Resume Next
        With Me
            .grdDates.Visible = (.optLitigationDates.Checked = True) Or (.optDocumentLinks.Checked = True)
            .grdActions.Visible = .optLitigationActions.Checked = True
            .grdDocumentLinks.Visible = .optDocumentLinks.Checked = True
            .btnDatesFromTemplate.Enabled = (.optLitigationDates.Checked = True)
            .chkReOrder.Enabled = (.optLitigationDates.Checked = True)

            If .optLitigationDates.Checked = True Then
                .grdDates.Left = 40
                .grdDates.Top = 292
                .grdDates.Height = 183
                .grdDates.Width = 927
                .grdDates.RootTable.Columns("EmailSent").Visible = (.chkReOrder.Checked = False)
                .grdDates.RootTable.Columns("MoveUp").Visible = (.chkReOrder.Checked = True)
                .grdDates.RootTable.Columns("MoveDown").Visible = (.chkReOrder.Checked = True)
            End If

            If .optLitigationActions.Checked = True Then
                .grdActions.Left = 40
                .grdActions.Top = 292
                .grdActions.Height = 183
                .grdActions.Width = 927
            End If

            If .optDocumentLinks.Checked = True Then
                .grdDocumentLinks.Left = 395
                .grdDocumentLinks.Top = 292
                .grdDocumentLinks.Height = 183
                .grdDocumentLinks.Width = 571

                .grdDates.Left = 40
                .grdDates.Top = 292
                .grdDates.Height = 183
                .grdDates.Width = 347
            End If

        End With

    End Sub

    Private Sub grdDates_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "OppositionDate" Then
            Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
            'make sure we've written to database first
            Me.grdDates.UpdateData()
            rsDates.Update()

            rsRecord.GetFromSQL("Select OppositionDateID, OppositionDate, ListOrder from tblOppositionDates " & _
                "where OppositionID=" & Globals.OppositionID & " order by OppositionDate, ListOrder")

            For i = 0 To rsRecord.Table.Rows.Count - 1
                dRow = rsRecord.Table.Rows(i)
                dRow("ListOrder") = (i + 1)
            Next i
            rsRecord.Update()
            GetDates()
        End If

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

#Region "Opposition Date Preferences"

    Private Sub GetTrademarkMasterDates()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblOppositionTemplate"
        dtMarkDates = DataStuff.GetDataTable(strSQL)
        Me.grdTrademarkMasterDates.DataSource = dtMarkDates
    End Sub


    Private Sub grdTrademarkMasterDates_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdTrademarkMasterDates.AddingRecord
        On Error Resume Next
        Dim iListOrder As Integer
        'apparently the grid counts header rows
        iListOrder = Me.grdTrademarkMasterDates.RowCount - 1
        Me.grdTrademarkMasterDates.SetValue("ListOrder", iListOrder)
    End Sub

    Private Sub grdTrademarkMasterDates_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkMasterDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strSQL As String, iDateID As Integer
            iDateID = Me.grdTrademarkMasterDates.GetValue("DateID")

            If DataStuff.DCount("DateID", "tblOppositionJurisdictionDates", "DateID=" & iDateID) > 0 Then
                MsgBox("You cannot delete a date that has been applied to a Jurisdiction.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblOppositionTemplate where DateID = " & iDateID
            DataStuff.RunSQL(strSQL)
            ReOrderMarkMasterDates()
            GetTrademarkMasterDates()
        End If

        If e.Column.Key = "MoveUp" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdTrademarkMasterDates.GetValue("ListOrder")
            iRow = Me.grdTrademarkMasterDates.CurrentRow.RowIndex

            If iOrder > 1 Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select DateID, ListOrder from tblOppositionTemplate")
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
                GetTrademarkMasterDates()
                Me.grdTrademarkMasterDates.Row = iOrder - 2
            End If

        End If

        If e.Column.Key = "MoveDown" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdTrademarkMasterDates.GetValue("ListOrder")
            iRow = Me.grdTrademarkMasterDates.CurrentRow.RowIndex


            If iOrder < Me.grdTrademarkMasterDates.RowCount Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select DateID, ListOrder from tblOppositionTemplate")
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
                GetTrademarkMasterDates()
                Me.grdTrademarkMasterDates.Row = iOrder
            End If
        End If

        If (e.Column.Key = "lnkEmail") And (Globals.SecurityLevel < 3) Then
            On Error Resume Next
            'new in version 5, fix a flaw ... save first if new record, or email doesn't save
            Dim iRow As Integer, iScroll As Integer
            With Me.grdTrademarkMasterDates
                iRow = .Row
                iScroll = .FirstRow
                .UpdateData()
                .FirstRow = iScroll
                .Row = iRow
            End With

            AllForms.OpenMergeHelper()
            With AllForms.frmMergeHelper
                .MergeStatus = frmMergeHelper.mStatus.OppositionAlertDate
                .DateID = Me.grdTrademarkMasterDates.GetValue("DateID")
                .SetOptions()
            End With
        End If
    End Sub

    Private Sub grdTrademarkMasterDates_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkMasterDates.RecordAdded
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iDateID As Integer, i As Integer

        rsRecord.GetFromSQL("Select * from tblOppositionTemplate where DateID=0")
        dRow = rsRecord.Table.Rows.Add

        With Me.grdTrademarkMasterDates
            dRow("DateName") = .GetValue("DateName")
            dRow("ListOrder") = .GetValue("ListOrder")
            dRow("IsAlert") = IIf(.GetValue("IsAlert") = True, True, False)
            ' dRow("DisplayOnExtranet") = IIf(.GetValue("DisplayOnExtranet") = True, True, False)
            dRow("AutoEmail") = IIf(.GetValue("AutoEmail") = True, True, False)
            dRow("EmailDaysBefore") = .GetValue("EmailDaysBefore")
        End With

        rsRecord.Update()

        i = Me.grdTrademarkMasterDates.Row
        GetTrademarkMasterDates()
        Me.grdTrademarkMasterDates.Row = i

    End Sub

    Private Sub grdTrademarkMasterDates_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkMasterDates.RecordUpdated
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, iDateID As Integer

        With Me.grdTrademarkMasterDates
            iDateID = .GetValue("DateID")
            rsRecord.GetFromSQL("Select * from tblOppositionTemplate where DateID=" & iDateID)
            dRow = rsRecord.CurrentRow
            dRow("DateName") = .GetValue("DateName")
            dRow("IsAlert") = IIf(.GetValue("IsAlert") = True, True, False)
            'dRow("DisplayOnExtranet") = IIf(.GetValue("DisplayOnExtranet") = True, True, False)
            dRow("AutoEmail") = IIf(.GetValue("AutoEmail") = True, True, False)
            dRow("EmailDaysBefore") = .GetValue("EmailDaysBefore")
        End With

        rsRecord.Update()
    End Sub

    Private Sub ReOrderMarkMasterDates()
        On Error Resume Next
        Dim RS As New RecordSet, i As Integer
        RS.GetFromSQL("Select DateID, ListOrder from tblOppositionTemplate order by ListOrder, DateID")
        For i = 0 To RS.Table.Rows.Count - 1
            RS.Table.Rows(i).Item("ListOrder") = i + 1
        Next i
        RS.Update()
    End Sub

    Private Sub btnAddTrademarkDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrademarkDates.Click
        On Error Resume Next
        Dim iJurisdictionID As Integer, GRow As Janus.Windows.GridEX.GridEXRow, i As Integer, _
        strSQL As String, rsMarkJurisDates As New RecordSet, iDateID As Integer, strFilter As String

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

        strSQL = "Select * from tblOppositionJurisdictionDates where JurisdictionID=" & iJurisdictionID
        rsMarkJurisDates.GetFromSQL(strSQL)

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
                        rsMarkJurisDates.CurrentRow("Completed") = False
                        rsMarkJurisDates.CurrentRow("EmailSent") = False
                        rsMarkJurisDates.CurrentRow("Suspended") = False
                    End If
                End If
            End If
        Next i

        rsMarkJurisDates.Update()
        ReOrderMarkJurisDates()
        GetTrademarkJurisDates()
        Me.grdTrademarkMasterDates.SelectedItems.Clear()

    End Sub

    Friend Sub GetTrademarkJurisDates()
        On Error Resume Next
        Dim strSQL As String, iJurisdictionID As Integer

        iJurisdictionID = Me.cboMarkJurisdiction.Value
        strSQL = "Select * from qvwOppositionJurisdictionDates where JurisdictionID=" & iJurisdictionID
        dtMarkJurisDates = DataStuff.GetDataTable(strSQL)
        Me.grdTrademarkJurisDates.DataSource = dtMarkJurisDates

    End Sub

    Private Sub cboMarkJurisdiction_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkJurisdiction.ValueChanged
        On Error Resume Next
        GetTrademarkJurisDates()
    End Sub

    Private Sub ReOrderMarkJurisDates()
        On Error Resume Next
        Dim RS As New RecordSet, i As Integer, JurisdictionID As Integer, strSQL As String
        JurisdictionID = Me.cboMarkJurisdiction.Value

        'clean up any blank goofs
        strSQL = "Delete from tblOppositionJurisdictionDates where DateID=0 and JurisdictionID=" & JurisdictionID
        DataStuff.RunSQL(strSQL)

        RS.GetFromSQL("Select JurisdictionDateID, ListOrder from tblOppositionJurisdictionDates where JurisdictionID=" & _
            JurisdictionID & " order by ListOrder, JurisdictionDateID")
        For i = 0 To RS.Table.Rows.Count - 1
            RS.Table.Rows(i).Item("ListOrder") = i + 1
        Next i
        RS.Update()
    End Sub

    Private Sub grdTrademarkJurisDates_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkJurisDates.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iJurisdictionDateID As Integer, iDateID As Integer, _
                iJurisdictionID As Integer, strFilter As String

            iJurisdictionDateID = Me.grdTrademarkJurisDates.GetValue("JurisdictionDateID")
            iDateID = Me.grdTrademarkJurisDates.GetValue("DateID")
            iJurisdictionID = Me.grdTrademarkJurisDates.GetValue("JurisdictionID")

            strFilter = "JurisdictionID=" & iJurisdictionID & " and DateID=" & iDateID
            If DataStuff.DCount("OppositionDateID", "tblOppositionDates", strFilter) > 0 Then
                MsgBox("You cannot delete a date that has been applied to an opposition.")
                Exit Sub
            End If


            Dim strMsg As String
            strMsg = "Are you sure you want to delete this date from the jurisdiction?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblOppositionJurisdictionDates where JurisdictionDateID = " & iJurisdictionDateID
            DataStuff.RunSQL(strSQL)
            ReOrderMarkJurisDates()
            GetTrademarkJurisDates()

        End If

        If e.Column.Key = "MoveUp" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdTrademarkJurisDates.GetValue("ListOrder")
            iRow = Me.grdTrademarkJurisDates.CurrentRow.RowIndex

            If iOrder > 1 Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select JurisdictionDateID, ListOrder from tblOppositionJurisdictionDates where" & _
                    " JurisdictionID=" & Me.cboMarkJurisdiction.Value)
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
                GetTrademarkJurisDates()
                Me.grdTrademarkJurisDates.Row = iOrder - 2
            End If

        End If

        If e.Column.Key = "MoveDown" Then
            Dim iOrder As Integer, iRow As Integer
            iOrder = Me.grdTrademarkJurisDates.GetValue("ListOrder")
            iRow = Me.grdTrademarkJurisDates.CurrentRow.RowIndex


            If iOrder < Me.grdTrademarkJurisDates.RowCount Then
                Dim rsRecord As New RecordSet, dRow As DataRow, i As Integer
                rsRecord.GetFromSQL("Select JurisdictionDateID, ListOrder from tblOppositionJurisdictionDates where" & _
                    " JurisdictionID=" & Me.cboMarkJurisdiction.Value)
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
                GetTrademarkJurisDates()
                Me.grdTrademarkJurisDates.Row = iOrder
            End If
        End If



    End Sub

    Private Sub chkOrderDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOrderDates.CheckedChanged
        On Error Resume Next
        SetOrderOptions()
    End Sub

    Private Sub SetOrderOptions()
        On Error Resume Next
        Dim bOrder As Boolean
        bOrder = Me.chkOrderDates.Checked

        With Me.grdTrademarkJurisDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
            If (bOrder = False) Then
                .Columns("DateName").Width = 185
            Else
                .Columns("DateName").Width = 167
            End If
        End With

        With Me.grdTrademarkMasterDates.RootTable
            .Columns("MoveUp").Visible = bOrder
            .Columns("MoveDown").Visible = bOrder
            .Columns("lnkEmail").Visible = Not bOrder
        End With

        If bOrder = True Then Me.grdTrademarkMasterDates.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
        If bOrder = False Then SetSecurity()
    End Sub

#End Region


End Class