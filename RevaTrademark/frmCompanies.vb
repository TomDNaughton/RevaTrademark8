Imports Microsoft.Office.Interop

Public Class frmCompanies

#Region "Declarations"

    Private rsCompanies As New RecordSet
    Private CompanyRow As DataRow
    Private dtCompaniesAndContacts As DataTable
    Private dtContacts As DataTable
    Private dtCountries As DataTable
    Private dtMatters As DataTable
    Private dtEntityTypes As DataTable
    Private dtJurisdictions As DataTable
    Private rsMatters As New RecordSet
    'so we know if record was changed
    Private bWasEdited As Boolean

#End Region

#Region "Form General"

    Private Sub frmCompanies_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmCompanies = Me
        GetCompanies()
        SetSecurity()
        FillJurisdictions()
        FillEntityTypes()
        FillCountries()
        GetBrowseRecords()
        SetShowLinked()

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            Me.sepDemo.Visible = True
            Me.lblDemo.Visible = True
        Else
            Me.sepDemo.Visible = False
            Me.lblDemo.Visible = False
        End If
    End Sub

    Private Sub frmCompanies_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        SaveCompany()
        AllForms.frmCompanies = Nothing

        'trying to get a clean close
        If AllForms.frmTrademarks Is Nothing And AllForms.frmPatents Is Nothing And AllForms.frmLogin Is Nothing _
        And AllForms.frmPreferences Is Nothing And AllForms.frmReports Is Nothing _
        And AllForms.frmCompanies Is Nothing And AllForms.frmOppositions Is Nothing Then

            Application.Exit()
        End If
    End Sub

    Private Sub GetCompanies()
        On Error Resume Next
        rsCompanies.GetFromSQL("Select * from tblCompanies order by CompanyName")
    End Sub

    Private Sub GetCompaniesAndContacts()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from qvwContactsAndCompanies order by CompanyName, LastName"
        dtCompaniesAndContacts = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub SetSecurity()
        On Error Resume Next

        Dim iSecurityLevel As Integer
        iSecurityLevel = Globals.SecurityLevel
        With Me
            .JurisdictionID.ReadOnly = (iSecurityLevel = 3)
            .EntityTypeID.ReadOnly = (iSecurityLevel = 3)
            .Country.ReadOnly = (iSecurityLevel = 3)
            .CompanyName.ReadOnly = (iSecurityLevel = 3)
            .AddressOne.ReadOnly = (iSecurityLevel = 3)
            .AddressTwo.ReadOnly = (iSecurityLevel = 3)
            .City.ReadOnly = (iSecurityLevel = 3)
            .StateProvince.ReadOnly = (iSecurityLevel = 3)
            .PostalCode.ReadOnly = (iSecurityLevel = 3)
            .WebSite.ReadOnly = (iSecurityLevel = 3)
            .Notes.ReadOnly = (iSecurityLevel = 3)
            .CompanyPhone.ReadOnly = (iSecurityLevel = 3)
            .CompanyFax.ReadOnly = (iSecurityLevel = 3)

            .btnNewCompany.Enabled = (iSecurityLevel < 3)
            .btnNewContact.Enabled = (iSecurityLevel < 3)
            .btnImportContact.Enabled = (iSecurityLevel < 3)
            .btnGetFromOutlook.Enabled = (iSecurityLevel < 3)
            .chkShowLinked.Enabled = (iSecurityLevel < 3)

        End With

        'Janus has their own versions of true and false; have to use them
        Select Case iSecurityLevel
            Case 1 'TrademarkUser

                With Me.grdCompanyList
                    '.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdContacts
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With


            Case 2 'No Delete

                With Me.grdCompanyList
                    '.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdContacts
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With


            Case 3 'View Only

                With Me.grdCompanyList
                    '.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdContacts
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

        End Select
    End Sub

    Private Sub tbCompany_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCompany.Leave
        On Error Resume Next
        SaveCompany()
    End Sub

#End Region

#Region "Toolbar Buttons"

    Private Sub btnGoTrademarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoTrademarks.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenTrademarks()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        If MsgBox("Are you sure want to exit RevaTrademark?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveCompany()

            Application.Exit()
        End If
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenLogin()
        Me.Close()
        AllForms.frmTrademarks.Close()
        AllForms.frmPatents.Close()
    End Sub

    Private Sub btnGoToPatents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToPatents.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenPatents()
        Me.Close()
    End Sub

    Private Sub btnGoToOppositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToOppositions.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenOppositions()
        Me.Close()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenReports()
        Me.Close()
    End Sub

    Private Sub btnPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreferences.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenPreferences()
        Me.Close()
    End Sub

#End Region

#Region "Browse"

    Private Sub optCompanies_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCompanies.CheckedChanged
        On Error Resume Next
        If Me.optCompanies.Checked = True Then
            GetBrowseRecords()
        End If
    End Sub

    Private Sub optContacts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optContacts.CheckedChanged
        On Error Resume Next
        If Me.optContacts.Checked = True Then
            If dtCompaniesAndContacts Is Nothing Then
                GetCompaniesAndContacts()
            End If
            GetBrowseRecords()
        End If
    End Sub

    Friend Sub GetBrowseRecords()
        On Error Resume Next
        Dim bCompanyOnly As Boolean

        If Me.optCompanies.Checked = True Then
            Me.grdCompanyList.DataSource = rsCompanies.Table
            bCompanyOnly = True
            Me.grdCompanyList.RootTable.Columns("CompanyName").Width = (Me.grdCompanyList.Width - 780)
        Else
            Me.grdCompanyList.DataSource = dtCompaniesAndContacts
            bCompanyOnly = False
            Me.grdCompanyList.RootTable.Columns("CompanyName").Width = (Me.grdCompanyList.Width - 797)
        End If

        With Me.grdCompanyList.RootTable
            .Columns("FirstName").Visible = Not bCompanyOnly
            .Columns("LastName").Visible = Not bCompanyOnly
            .Columns("ContactTitle").Visible = Not bCompanyOnly
            .Columns("ContactPhone").Visible = Not bCompanyOnly

            .Columns("AddressOne").Visible = bCompanyOnly
            .Columns("AddressTwo").Visible = bCompanyOnly
            .Columns("StateProvince").Visible = bCompanyOnly
            .Columns("lnkDelete").Visible = bCompanyOnly
        End With

        Me.btnPrintAllContacts.Enabled = (Me.optContacts.Checked = True)

    End Sub

    Private Sub grdCompanyList_SortKeysChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCompanyList.SortKeysChanged
        On Error Resume Next
        Me.grdCompanyList.Row = 0
    End Sub

    Private Sub btnNewCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCompany.Click
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Insert into tblCompanies (CompanyName) values ('Type Company Name Here')"
        DataStuff.RunSQL(strSQL)
        GetCompanies()
        Globals.CompanyID = DataStuff.DMax("CompanyID", "tblCompanies")
        GetCompany()
        Me.Tabs.SelectedIndex = 1
    End Sub

    Private Sub btnClearFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFilters.Click
        On Error Resume Next
        Me.grdCompanyList.RemoveFilters()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        On Error Resume Next
        If Me.optContacts.Checked = True Then
            GetCompaniesAndContacts()
        Else
            GetCompanies()
        End If
        GetBrowseRecords()
    End Sub

    Private Sub btnPrintAllContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllContacts.Click
        On Error Resume Next
        Dim strFilter As String, i As Integer, strSort As String
        Dim drReader As OleDb.OleDbDataReader, rptCompanyContacts As New rptCompanyContacts, strSQL As String
        Dim GRow As Janus.Windows.GridEX.GridEXRow

        Me.Cursor = Cursors.WaitCursor
        strFilter = "ContactID in ("
        strSort = "CompanyName, LastName, FirstName"

        For i = 0 To Me.grdCompanyList.RowCount - 1
            GRow = Me.grdCompanyList.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                strFilter = strFilter & Nz(GRow.Cells("ContactID").Value, 0) & ","
            End If
        Next
        strFilter = strFilter & "0)"

        strSQL = "Select * from qvwContactsAndCompanies where " & strFilter & " order by " & strSort
        drReader = DataStuff.GetDataReader(strSQL)
        rptCompanyContacts.DataSource = drReader
        AllForms.OpenReport()
        AllForms.frmReportPreview.ReportViewer.Document = rptCompanyContacts.Document
        rptCompanyContacts.Run()
        AllForms.frmReportPreview.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdCompanyList_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdCompanyList.LinkClicked
        On Error Resume Next
        If e.Column.Key = "CompanyName" Then
            Globals.CompanyID = Me.grdCompanyList.GetValue("CompanyID")
            GetCompany()
        End If

        If e.Column.Key = "lnkDelete" Then
            If Globals.SecurityLevel > 1 Then Exit Sub

            Dim strMessage As String, strSQL As String, drTrademarks As OleDb.OleDbDataReader,
                drPatents As OleDb.OleDbDataReader, iTrademarkID As Integer, iPatentID As Integer,
                drOppositions As OleDb.OleDbDataReader, iOppositionID As Integer

            strMessage = "You are about to delete " & Me.grdCompanyList.GetValue("CompanyName") & ".  "
            strMessage = strMessage & "Deleting a company will also delete all company contacts and all " &
                "trademarks and patents owned by the company.  This cannot be undone.  Are you sure?"

            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strMessage = "LAST CHANCE TO CHANGE YOUR MIND!" & vbCrLf & vbCrLf &
            "This will delete ALL PATENTS AND TRADEMARKS OWNED BY THIS COMPANY FROM THE DATABASE. Are you sure?"
            If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'still here?  Then mass delete
            Dim iCompanyID As Integer
            iCompanyID = Me.grdCompanyList.GetValue("CompanyID")

            strSQL = "Delete from tblCompanies where CompanyID=" & iCompanyID
            DataStuff.RunSQL(strSQL)

            strSQL = "Delete from tblContacts where CompanyID=" & iCompanyID
            DataStuff.RunSQL(strSQL)

            strSQL = "Delete from tblClientMatters where CompanyID=" & iCompanyID
            DataStuff.RunSQL(strSQL)

            strSQL = "Delete from tblLinkCompanies where CompanyID=" & iCompanyID
            DataStuff.RunSQL(strSQL)

            strSQL = "Delete from tblLinkCompanies where LinkCompanyID=" & iCompanyID
            DataStuff.RunSQL(strSQL)

            'delete company's trademark stuff
            strSQL = "Select TrademarkID from tblTrademarks where CompanyID=" & iCompanyID
            drTrademarks = DataStuff.GetDataReader(strSQL)

            While drTrademarks.Read
                iTrademarkID = drTrademarks.Item("TrademarkID")
                DataStuff.DeleteTrademark(iTrademarkID)
            End While

            'now the patent stuff
            strSQL = "Select PatentID from tblPatents where CompanyID=" & iCompanyID
            drPatents = DataStuff.GetDataReader(strSQL)

            While drPatents.Read
                iPatentID = drPatents.Item("PatentID")
                DataStuff.DeletePatent(iPatentID)
            End While

            'now the opposition stuff, twice
            strSQL = "Select OppositionID from tblOppositions where CompanyID=" & iCompanyID
            drOppositions = DataStuff.GetDataReader(strSQL)

            While drOppositions.Read
                iOppositionID = drOppositions.Item("OppositionID")
                DataStuff.DeleteOpposition(iOppositionID)
            End While

            strSQL = "Select OppositionID from tblOppositions where OpposingCompanyID=" & iCompanyID
            drOppositions = DataStuff.GetDataReader(strSQL)

            While drOppositions.Read
                iOppositionID = drOppositions.Item("OppositionID")
                DataStuff.RunSQL("update tblOppositions set OpposingCompanyID=null where OppositionID=" & iOppositionID)
            End While

            GetCompanies()
            GetBrowseRecords()

        End If

    End Sub

#End Region

#Region "Fill Data Tables"

    Friend Sub FillJurisdictions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select JurisdictionID, Jurisdiction from tblJurisdictions where IsTrademark <> 0 Order by Jurisdiction"
        dtJurisdictions = DataStuff.GetDataTable(strSQL)
        Me.JurisdictionID.DataSource = dtJurisdictions
    End Sub

    Friend Sub FillEntityTypes()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblEntityTypes order by EntityType"
        dtEntityTypes = DataStuff.GetDataTable(strSQL)
        Me.EntityTypeID.DataSource = dtEntityTypes
    End Sub

    Friend Sub FillCountries()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblCountries order by Country"
        dtCountries = DataStuff.GetDataTable(strSQL)
        Me.Country.DataSource = dtCountries
    End Sub

#End Region

#Region "Company Details"

    Friend Sub GetCompany()
        On Error Resume Next
        'CompanyRow is one row from rsCompanies, all declared above
        CompanyRow = rsCompanies.Table.Select("CompanyID=" & Globals.CompanyID)(0)

        With Me
            .CompanyName.Text = CompanyRow("CompanyName") & ""
            .AddressOne.Text = CompanyRow("AddressOne") & ""
            .AddressTwo.Text = CompanyRow("AddressTwo") & ""
            .City.Text = CompanyRow("City") & ""
            .StateProvince.Text = CompanyRow("StateProvince") & ""
            .PostalCode.Text = CompanyRow("PostalCode") & ""
            .Country.Text = CompanyRow("Country") & ""
            .CompanyPhone.Text = CompanyRow("CompanyPhone") & ""
            .CompanyFax.Text = CompanyRow("CompanyFax") & ""
            .WebSite.Text = CompanyRow("WebSite") & ""
            .Notes.Text = CompanyRow("Notes") & ""
            .EntityTypeID.Value = CompanyRow("EntityTypeID")
            .JurisdictionID.Value = CompanyRow("JurisdictionID")
        End With

        Me.Tabs.SelectedIndex = 1
        bWasEdited = False
        GetContacts()
        GetMatters()
        GetTrademarks()
        GetPatents()

        If Me.chkShowLinked.Checked = True Then
            GetLinked()
        End If

        If RevaSettings.OpenOnMarks = True Then
            Me.tabMarksPats.SelectedIndex = 0
        Else
            Me.tabMarksPats.SelectedIndex = 1
        End If

    End Sub

    Private Sub SaveCompany()
        On Error Resume Next
        If bWasEdited = False Then Exit Sub

        With Me
            CompanyRow("CompanyName") = .CompanyName.Text & ""
            CompanyRow("AddressOne") = .AddressOne.Text & ""
            CompanyRow("AddressTwo") = .AddressTwo.Text & ""
            CompanyRow("City") = .City.Text & ""
            CompanyRow("StateProvince") = .StateProvince.Text & ""
            CompanyRow("PostalCode") = .PostalCode.Text & ""
            CompanyRow("Country") = .Country.Text & ""
            CompanyRow("CompanyPhone") = .CompanyPhone.Text & ""
            CompanyRow("CompanyFax") = .CompanyFax.Text & ""
            CompanyRow("WebSite") = .WebSite.Text & ""
            CompanyRow("Notes") = .Notes.Text & ""
            CompanyRow("EntityTypeID") = .EntityTypeID.Value
            CompanyRow("JurisdictionID") = .JurisdictionID.Value
        End With

        rsCompanies.Update()
        bWasEdited = False
        GetCompanies()
        GetBrowseRecords()

        If Not (AllForms.frmTrademarks Is Nothing) Then
            'AllForms.frmTrademarks.FillCompanies()
            ' AllForms.frmTrademarks.FillContactList()
            AllForms.frmTrademarks.GetCompany()
            AllForms.frmTrademarks.GetContacts()
        End If

        If Not (AllForms.frmPatents Is Nothing) Then
            ' AllForms.frmPatents.FillCompanies()
            ' AllForms.frmPatents.FillContactList()
            AllForms.frmPatents.GetCompany()
            AllForms.frmPatents.GetContacts()
        End If

        If Not (AllForms.frmOppositions Is Nothing) Then
            'AllForms.frmOppositions.FillCompanies()
            'AllForms.frmOppositions.FillContactList()
            AllForms.frmOppositions.GetContacts()
        End If

    End Sub

    Private Sub btnCountry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountry.Click
        On Error Resume Next
        SaveCompany()
        Dim f As New frmGeneralPopups
        f.GetRecordset(8)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWebSite.Click
        On Error Resume Next
        Dim strURL As String
        strURL = Me.WebSite.Text & ""
        System.Diagnostics.Process.Start(strURL)
    End Sub

    Private Sub btnEntityType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntityType.Click
        On Error Resume Next
        SaveCompany()
        Dim f As New frmGeneralPopups
        f.GetRecordset(9)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJurisdiction.Click
        On Error Resume Next
        SaveCompany()
        Dim f As New frmGeneralPopups
        f.GetRecordset(5)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

#Region "Was Edited"

    Private Sub CompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyName.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub AddressOne_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressOne.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub AddressTwo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressTwo.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub City_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles City.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub StateProvince_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateProvince.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub PostalCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostalCode.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub Country_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Country.ValueChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub CompanyPhone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyPhone.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub CompanyFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyFax.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub WebSite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebSite.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub EntityTypeID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntityTypeID.ValueChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub JurisdictionID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JurisdictionID.ValueChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub Notes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Notes.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

#End Region

#Region "Undo for textboxes"

    Private Sub CompanyName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CompanyName.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.CompanyName.Undo()
    End Sub

    Private Sub AddressOne_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AddressOne.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.AddressOne.Undo()
    End Sub

    Private Sub AddressTwo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AddressTwo.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.AddressTwo.Undo()
    End Sub

    Private Sub City_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles City.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.City.Undo()
    End Sub

    Private Sub StateProvince_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles StateProvince.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.StateProvince.Undo()
    End Sub

    Private Sub PostalCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PostalCode.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.PostalCode.Undo()
    End Sub

    Private Sub CompanyPhone_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CompanyPhone.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.CompanyPhone.Undo()
    End Sub

    Private Sub CompanyFax_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CompanyFax.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.CompanyFax.Undo()
    End Sub

    Private Sub WebSite_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles WebSite.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.WebSite.Undo()
    End Sub

    Private Sub Notes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Notes.KeyUp
        On Error Resume Next
        If e.KeyCode = Keys.Escape Then Me.Notes.Undo()
    End Sub

#End Region

#End Region

#Region "Matters Grid"

    Private Sub GetMatters()
        On Error Resume Next
        rsMatters.GetFromSQL("Select * from tblClientMatters where CompanyID=" & Globals.CompanyID & " order by FileNumber")
        Me.grdFileMatters.DataSource = rsMatters.Table
    End Sub

    Private Sub grdFileMatters_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdFileMatters.AddingRecord
        On Error Resume Next
        Me.grdFileMatters.SetValue("CompanyID", Globals.CompanyID)
    End Sub

    Private Sub grdFileMatters_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFileMatters.RecordAdded
        On Error Resume Next
        rsMatters.Update()
    End Sub

    Private Sub grdFileMatters_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFileMatters.RecordUpdated
        On Error Resume Next
        rsMatters.Update()
    End Sub

    Private Sub grdFileMatters_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdFileMatters.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim strSQL As String, iFileID As Integer

            iFileID = Me.grdFileMatters.GetValue("FileID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "FileID=" & iFileID) > 0 Then
                MsgBox("You cannot delete a client matter that is attached to a trademark.")
                Exit Sub
            End If

            If DataStuff.DCount("PatentID", "tblPatents", "FileID=" & iFileID) > 0 Then
                MsgBox("You cannot delete a client matter that is attached to a patent.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this client matter?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblClientMatters where FileID = " & iFileID
            DataStuff.RunSQL(strSQL)
            GetMatters()
        End If
    End Sub

#End Region

#Region "Linked Companies Grid"

    Private Sub chkShowLinked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowLinked.CheckedChanged
        On Error Resume Next
        SetShowLinked()
    End Sub

    Private Sub chkLinkedOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLinkedOnly.CheckedChanged
        GetLinked()
    End Sub

    Private Sub SetShowLinked()
        On Error Resume Next
        With Me
            If .chkShowLinked.Checked = False Then
                .grdFileMatters.Width = 353
                .grdFileMatters.Left = 634
                .grdLinks.Visible = False
                .grdFileMatters.Visible = True
                .chkLinkedOnly.Visible = False
            Else
                GetLinked()
                .grdFileMatters.Visible = False
                .chkLinkedOnly.Visible = True
                .grdLinks.Visible = True
                .grdLinks.Width = 353
                .grdLinks.Left = 634
            End If
        End With
    End Sub

    Private Sub GetLinked()
        On Error Resume Next
        Dim dtLinked As DataTable
        dtLinked = rsCompanies.Table.DefaultView.ToTable

        If Me.chkLinkedOnly.Checked = True Then
            dtLinked.DefaultView.RowFilter = "GroupID=" & Nz(CompanyRow("GroupID"), -6)
        End If

        Me.grdLinks.DataSource = dtLinked

        'check the box for companies that are already linked
        Dim i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.grdLinks.RowCount - 1
            GRow = Me.grdLinks.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GRow.BeginEdit()
                If Nz(GRow.Cells("GroupID").Value, -2) = Nz(CompanyRow("GroupID"), -99) Then
                    GRow.Cells("IsLinked").Value = True
                Else
                    GRow.Cells("IsLinked").Value = False
                End If
                GRow.EndEdit()
            End If
        Next

    End Sub

    Private Sub grdLinks_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLinks.RecordUpdated
        On Error Resume Next
        Dim iCompanyID As Integer, iLinkCompanyID As Integer, iGroupID As Integer, i As Integer, _
            iLinkGroupID As Integer, LinkedRow As DataRow

        iCompanyID = Globals.CompanyID
        iLinkCompanyID = Me.grdLinks.GetValue("CompanyID")
        iGroupID = Nz(CompanyRow("GroupID"), 0)
        iLinkGroupID = Nz(Me.grdLinks.GetValue("GroupID"), 0)

        If Me.grdLinks.GetValue("IsLinked") = True Then '----------box was checked--------

            'neither company is linked, use companyID as groupID
            If (iGroupID = 0) And (iLinkGroupID = 0) Then
                CompanyRow("GroupID") = CompanyRow("CompanyID")
                For i = 0 To rsCompanies.Table.Rows.Count - 1
                    LinkedRow = rsCompanies.Table.Rows(i)
                    If Nz(LinkedRow("CompanyID"), 0) = iLinkCompanyID Then
                        LinkedRow("GroupID") = CompanyRow("CompanyID")
                    End If
                Next
            End If

            'this company is in a group, but linked company isn't
            If (iGroupID <> 0) And (iLinkGroupID = 0) Then
                For i = 0 To rsCompanies.Table.Rows.Count - 1
                    LinkedRow = rsCompanies.Table.Rows(i)
                    If Nz(LinkedRow("CompanyID"), 0) = iLinkCompanyID Then
                        LinkedRow("GroupID") = iGroupID
                    End If
                Next
            End If

            'this company isn't in a group, but linked company IS
            If (iGroupID = 0) And (iLinkGroupID <> 0) Then
                CompanyRow("GroupID") = iLinkGroupID
            End If

            'They are BOTH in a group already, switch all to this group
            If (iGroupID <> 0) And (iLinkGroupID <> 0) Then
                For i = 0 To rsCompanies.Table.Rows.Count - 1
                    LinkedRow = rsCompanies.Table.Rows(i)
                    If Nz(LinkedRow("GroupID"), 0) = iLinkGroupID Then
                        LinkedRow("GroupID") = iGroupID
                    End If
                Next
            End If

            rsCompanies.Update()

        Else '---------------------box was unchecked --------------------------------

            Dim iGroupCount As Integer
            iGroupCount = 0
            'set GroupID for unchecked row to null, also count group members
            For i = 0 To rsCompanies.Table.Rows.Count - 1
                LinkedRow = rsCompanies.Table.Rows(i)

                If Nz(LinkedRow("GroupID"), 0) = iLinkGroupID Then
                    iGroupCount = iGroupCount + 1
                End If

                If Nz(LinkedRow("CompanyID"), 0) = iLinkCompanyID Then
                    LinkedRow("GroupID") = DBNull.Value
                End If
            Next

            'if iGroupCount = 2, then we unlinked one of two companies in a group.
            'in that case, there is no more group, so clear the other as well
            If iGroupCount = 2 Then
                For i = 0 To rsCompanies.Table.Rows.Count - 1
                    LinkedRow = rsCompanies.Table.Rows(i)
                    If Nz(LinkedRow("GroupID"), 0) = iLinkGroupID Then
                        LinkedRow("GroupID") = DBNull.Value
                    End If
                Next
            End If

            rsCompanies.Update()

        End If  '------------------------if box checked -----------------------------

    End Sub

#End Region

#Region "Contacts Grid"

    Friend Sub GetContacts()
        On Error Resume Next
        dtContacts = DataStuff.GetDataTable("Select * from tblContacts where CompanyID=" & Globals.CompanyID & _
            " order by LastName, FirstName")
        Me.grdContacts.DataSource = dtContacts
    End Sub

    Private Sub grdContacts_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.LinkClicked
        On Error Resume Next
        Select Case e.Column.Key
            Case "lnkDelete"
                If Globals.SecurityLevel > 1 Then Exit Sub
                Dim strMsg As String, strSQL As String, iContactID As Integer

                strMsg = "This will delete the contact from the company and from all trademarks and patents."
                strMsg = strMsg & " Are you sure?"

                If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                iContactID = Me.grdContacts.GetValue("ContactID")

                strSQL = "Delete from tblTrademarkContacts where ContactID=" & iContactID
                DataStuff.RunSQL(strSQL)
                strSQL = "Delete from tblPatentContacts where ContactID=" & iContactID
                DataStuff.RunSQL(strSQL)
                strSQL = "Delete from tblContacts where ContactID=" & iContactID
                DataStuff.RunSQL(strSQL)
                GetContacts()

            Case "LastName"
                Globals.ContactID = Me.grdContacts.GetValue("ContactID")
                OpenContact()
                AllForms.frmContact.AddOrEdit = 2  '2 means edit
                AllForms.frmContact.GetContact()

            Case "ContactEmail"
                Me.Cursor = Cursors.WaitCursor
                Dim OL As Outlook.Application, Email As Outlook.MailItem, strTo As String
                strTo = Me.grdContacts.GetValue("ContactEmail") & ""
                If strTo <> "" Then
                    OL = GetObject(, "Outlook.Application")
                    If OL Is Nothing Then
                        OL = CreateObject("Outlook.Application")
                    End If
                    Email = OL.CreateItem(Outlook.OlItemType.olMailItem)
                    With Email
                        .To = strTo
                        .Display()
                    End With
                End If
                OL = Nothing
                Email = Nothing
                Me.Cursor = Cursors.Default

        End Select
    End Sub

    Private Sub btnNewContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewContact.Click
        On Error Resume Next
        OpenContact()
        AllForms.frmContact.AddOrEdit = 1  '1 means new contact
        AllForms.frmContact.GetContact()
    End Sub

    Private Sub btnImportContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportContact.Click
        On Error Resume Next
        SaveCompany()
        Dim f As New frmImportContact
        f.ShowDialog()
    End Sub

    Private Sub btnGetFromOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFromOutlook.Click
        On Error Resume Next
        SaveCompany()
        AllForms.OpenContactFromOutlook()
    End Sub

#End Region

#Region "Trademarks/Patents Grids"

    Private Sub GetTrademarks()
        On Error Resume Next
        Dim strSQL As String
        strSQL = SQL.vwTrademarksList & " where CompanyID=" & Globals.CompanyID & " order by TrademarkName, Jurisdiction"
        Me.grdTrademarks.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub grdTrademarks_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarks.LinkClicked
        On Error Resume Next
        If (e.Column.Key = "TrademarkName") Or (e.Column.Key = "ApplicationNumber") Then
            SaveCompany()
            Globals.TrademarkID = Me.grdTrademarks.GetValue("TrademarkID")
            Globals.NavigateMarksFrom = 4
            AllForms.OpenTrademarks()
            AllForms.frmTrademarks.GetTrademark()
            AllForms.frmTrademarks.Tabs.SelectedIndex = 1
            Me.Close()
        End If
    End Sub

    Private Sub GetPatents()
        On Error Resume Next
        Dim strSQL As String
        strSQL = SQL.vwPatentsList & " where CompanyID=" & Globals.CompanyID & " order by PatentName, Jurisdiction"
        Me.grdPatents.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub grdPatents_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatents.LinkClicked
        On Error Resume Next
        If (e.Column.Key = "PatentName") Or (e.Column.Key = "ApplicationNumber") Then
            SaveCompany()
            Globals.PatentID = Me.grdPatents.GetValue("PatentID")
            Globals.NavigatePatentsFrom = 4
            AllForms.OpenPatents()
            AllForms.frmPatents.GetPatent()
            AllForms.frmPatents.Tabs.SelectedIndex = 1
            Me.Close()
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


End Class