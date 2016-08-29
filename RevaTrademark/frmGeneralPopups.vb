Public Class frmGeneralPopups

    Private rsRecords As New RecordSet
    Public iRecType As Integer

    Public Sub GetRecordset(ByVal iType As Integer)
        On Error Resume Next
        'this form serves up one grid based on which drop down the user is trying to populate

        '4 = tblStatus, 5 = tblJurisdictions,
        '6 = tblPositions, 7 = Matters, 8 = Countries, 9 = Entity Types
        '10 = Trademark Types, 11 = Mark filters, 12 = Patent Filters

        Select Case iType
            Case 4
                LoadStatus()
            Case 5
                LoadJurisdictions()
            Case 6
                LoadPositions()
            Case 7
                LoadMatters()
            Case 8
                LoadCountries()
            Case 9
                LoadEntityTypes()
            Case 10
                LoadTrademarkTypes()
            Case 11
                LoadFilters(True)  ' true means trademark filters
            Case 12
                LoadFilters(False) 'false means patent filters

        End Select
        'so we know what to do when we close
        iRecType = iType

    End Sub

    Private Sub frmTrademarkPopups_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        rsRecords = Nothing

        'requery form depending on what we updated here
        Select Case iRecType
            Case 4
                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.FillStatus()
                If Not (AllForms.frmPatents Is Nothing) Then AllForms.frmPatents.FillStatus()

            Case 5
                Dim TJ As New TreatyJurisdictions
                TJ.UpdateTrademarkTreaties()
                TJ.UpdatePatentTreaties()

                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.FillJurisdictions()
                If Not (AllForms.frmPreferences Is Nothing) Then AllForms.frmPreferences.FillJurisdictions()
                If Not (AllForms.frmCompanies Is Nothing) Then AllForms.frmCompanies.FillJurisdictions()

            Case 6
                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.FillPositions()
                If Not (AllForms.frmPatents Is Nothing) Then AllForms.frmPatents.FillPositions()
                If Not (AllForms.frmContact Is Nothing) Then AllForms.frmContact.FillPositions()
                If Not (AllForms.frmOppositions Is Nothing) Then AllForms.frmOppositions.FillPositions()

            Case 7
                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.GetMatters()
                If Not (AllForms.frmPatents Is Nothing) Then AllForms.frmPatents.GetMatters()

            Case 8
                AllForms.frmCompanies.FillCountries()

            Case 9
                AllForms.frmCompanies.FillEntityTypes()

            Case 10
                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.FillTrademarkTypes()

            Case 11
                AllForms.frmReports.GetTrademarkStoredFilters()

            Case 12
                AllForms.frmReports.GetPatentStoredFilters()


        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub


#Region "Status"

    Private Sub LoadStatus()
        On Error Resume Next
        With Me
            .grdStatus.Top = 0
            .grdStatus.Left = 0
            .grdStatus.Visible = True
            .btnClose.Top = .grdStatus.Height + 5
            .Height = .grdStatus.Height + 70
            .Width = .grdStatus.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Status"
        End With

        GetStatus()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdStatus
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdStatus
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdStatus
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetStatus()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblStatus order by Status"
        rsRecords.GetFromSQL(strSQL)
        Me.grdStatus.DataSource = rsRecords.Table
    End Sub

    Private Sub grdStatus_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdStatus.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdStatus_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdStatus.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdStatus_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdStatus.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iStatusID As Integer
            iStatusID = Me.grdStatus.GetValue("StatusID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "StatusID=" & iStatusID) > 0 Then
                MsgBox("You cannot delete a Status that's attached to a trademark.")
                Exit Sub
            End If

            If DataStuff.DCount("PatentID", "tblPatents", "StatusID=" & iStatusID) > 0 Then
                MsgBox("You cannot delete a Status that's attached to a patent.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Status?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblStatus where StatusID = " & iStatusID
            DataStuff.RunSQL(strSQL)
            GetStatus()

        End If

    End Sub

#End Region

#Region "Jurisdictions"

    Private Sub LoadJurisdictions()
        On Error Resume Next
        With Me
            .grdJurisdictions.Top = 0
            .grdJurisdictions.Left = 0
            .grdJurisdictions.Visible = True
            .btnClose.Top = .grdJurisdictions.Height + 5
            .Height = .grdJurisdictions.Height + 70
            .Width = .grdJurisdictions.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Jurisdictions"
        End With

        GetJurisdictions()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdJurisdictions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetJurisdictions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select JurisdictionID, Jurisdiction, IsTrademark, IsPatent from tblJurisdictions order by Jurisdiction"
        rsRecords.GetFromSQL(strSQL)
        Me.grdJurisdictions.DataSource = rsRecords.Table
    End Sub

    Private Sub grdJurisdictions_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdJurisdictions.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdJurisdictions_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdJurisdictions.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdJurisdictions_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdJurisdictions.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iJurisdictionID As Integer
            iJurisdictionID = Me.grdJurisdictions.GetValue("JurisdictionID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "JurisdictionID=" & iJurisdictionID) > 0 Then
                MsgBox("You cannot delete a Jurisdiction that's attached to a trademark.")
                Exit Sub
            End If

            If DataStuff.DCount("PatentID", "tblPatents", "JurisdictionID=" & iJurisdictionID) > 0 Then
                MsgBox("You cannot delete a Jurisdiction that's attached to a patent.")
                Exit Sub
            End If

            If DataStuff.DCount("OppositionID", "tblOppositions", "JurisdictionID=" & iJurisdictionID) > 0 Then
                MsgBox("You cannot delete a Jurisdiction that's attached to a trademark opposition.")
                Exit Sub
            End If

            If DataStuff.DCount("JurisdictionDateID", "tblJurisdictionDates", "JurisdictionID=" & iJurisdictionID) > 0 Then
                MsgBox("You cannot delete a jurisdiction that has been used to create a dates template.")
                Exit Sub
            End If

            If DataStuff.DCount("JurisdictionDateID", "tblPatentJurisdictionDates", "JurisdictionID=" & iJurisdictionID) > 0 Then
                MsgBox("You cannot delete a jurisdiction that has been used to create a dates template.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Jurisdiction?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblJurisdictions where JurisdictionID = " & iJurisdictionID
            DataStuff.RunSQL(strSQL)

            strSQL = "delete from tblTreatyJurisdictions where JurisdictionID not in (Select JurisdictionID from tblJurisdictions)"
            DataStuff.RunSQL(strSQL)

            strSQL = "delete from tblPatentTreatyJurisdictions where JurisdictionID not in (Select JurisdictionID from tblJurisdictions)"
            DataStuff.RunSQL(strSQL)

            strSQL = "delete from tblJurisdictionDates where JurisdictionID = " & iJurisdictionID
            DataStuff.RunSQL(strSQL)

            strSQL = "delete from tblPatentJurisdictionDates where JurisdictionID = " & iJurisdictionID
            DataStuff.RunSQL(strSQL)

            strSQL = "delete from tblOppositionJurisdictionDates where JurisdictionID = " & iJurisdictionID
            DataStuff.RunSQL(strSQL)

            GetJurisdictions()
        End If
    End Sub

#End Region

#Region "Positions"

    Private Sub LoadPositions()
        On Error Resume Next
        With Me
            .grdPositions.Top = 0
            .grdPositions.Left = 0
            .grdPositions.Visible = True
            .btnClose.Top = .grdPositions.Height + 5
            .Height = .grdPositions.Height + 70
            .Width = .grdPositions.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Trademark/Patent Positions"
        End With

        GetPositions()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdPositions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdPositions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdPositions
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetPositions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPositions order by PositionName"
        rsRecords.GetFromSQL(strSQL)
        Me.grdPositions.DataSource = rsRecords.Table
    End Sub

    Private Sub grdPositions_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPositions.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPositions_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPositions.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPositions_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPositions.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iPositionID As Integer
            iPositionID = Me.grdPositions.GetValue("PositionID")

            If DataStuff.DCount("TrademarkContactID", "tblTrademarkContacts", "PositionID=" & iPositionID) > 0 Then
                MsgBox("You cannot delete a position that has been applied to a trademark contact.")
                Exit Sub
            End If

            If DataStuff.DCount("PatentContactID", "tblPatentContacts", "PositionID=" & iPositionID) > 0 Then
                MsgBox("You cannot delete a position that has been applied to a patent contact.")
                Exit Sub
            End If

            If DataStuff.DCount("OppositionContactID", "tblOppositionContacts", "PositionID=" & iPositionID) > 0 Then
                MsgBox("You cannot delete a position that has been applied to a trademark opposition.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Position?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblPositions where PositionID = " & iPositionID
            DataStuff.RunSQL(strSQL)

            GetPositions()

        End If

    End Sub

#End Region

#Region "File Matters"

    Private Sub LoadMatters()
        On Error Resume Next
        With Me
            .grdFileMatters.Top = 0
            .grdFileMatters.Left = 0
            .grdFileMatters.Visible = True
            .btnClose.Top = .grdFileMatters.Height + 5
            .Height = .grdFileMatters.Height + 70
            .Width = .grdFileMatters.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            MsgBox(Me.Parent.Name)
            If Not (AllForms.frmTrademarks Is Nothing) Then
                .Text = AllForms.frmTrademarks.CompanyID.Text
            Else
                .Text = AllForms.frmPatents.CompanyID.Text
            End If
        End With

        GetMatters()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdFileMatters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetMatters()
        On Error Resume Next
        Dim strSQL As String, iCompanyID As Integer
        If Not (AllForms.frmTrademarks Is Nothing) Then
            iCompanyID = AllForms.frmTrademarks.CompanyID.Value
        Else
            iCompanyID = AllForms.frmPatents.CompanyID.Value
        End If

        'change this to get linked company matters as well
        strSQL = "Select * from tblClientMatters where CompanyID=" & iCompanyID
        rsRecords.GetFromSQL(strSQL)
        Me.grdFileMatters.DataSource = rsRecords.Table
    End Sub

    Private Sub grdFileMatters_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFileMatters.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdFileMatters_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFileMatters.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdFileMatters_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdFileMatters.AddingRecord
        On Error Resume Next
        Dim iCompanyID As Integer

        If Not (AllForms.frmTrademarks Is Nothing) Then
            iCompanyID = AllForms.frmTrademarks.CompanyID.Value
        Else
            iCompanyID = AllForms.frmPatents.CompanyID.Value
        End If

        Me.grdFileMatters.SetValue("CompanyID", iCompanyID)
    End Sub

    Private Sub grdFileMatters_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdFileMatters.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iFileID As Integer
            iFileID = Me.grdFileMatters.GetValue("FileID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "FileID=" & iFileID) > 0 Then
                MsgBox("You cannot delete a file number that's attached to a trademark.")
                Exit Sub
            End If

            If DataStuff.DCount("PatentID", "tblPatents", "FileID=" & iFileID) > 0 Then
                MsgBox("You cannot delete a file number that's attached to a patent.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this File/Matter number?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblClientMatters where FileID = " & iFileID
            DataStuff.RunSQL(strSQL)
            GetMatters()
        End If
    End Sub

#End Region

#Region "Countries"

    Private Sub LoadCountries()
        On Error Resume Next
        With Me
            .grdCountries.Top = 0
            .grdCountries.Left = 0
            .grdCountries.Visible = True
            .btnClose.Top = .grdCountries.Height + 5
            .Height = .grdCountries.Height + 70
            .Width = .grdCountries.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Countries"
        End With

        GetCountries()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdCountries
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdCountries
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdCountries
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetCountries()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblCountries order by Country"
        rsRecords.GetFromSQL(strSQL)
        Me.grdCountries.DataSource = rsRecords.Table
    End Sub

    Private Sub grdCountries_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdCountries.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iCountryID As Integer
            iCountryID = Me.grdCountries.GetValue("CountryID")

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this country?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblCountries where CountryID = " & iCountryID
            DataStuff.RunSQL(strSQL)
            GetCountries()
        End If
    End Sub

    Private Sub grdCountries_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCountries.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdCountries_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCountries.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

#End Region

#Region "Entity Types"

    Private Sub LoadEntityTypes()
        On Error Resume Next
        With Me
            .grdEntityTypes.Top = 0
            .grdEntityTypes.Left = 0
            .grdEntityTypes.Visible = True
            .btnClose.Top = .grdEntityTypes.Height + 5
            .Height = .grdEntityTypes.Height + 70
            .Width = .grdEntityTypes.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "EntityTypes"
        End With

        GetEntityTypes()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdEntityTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdEntityTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdEntityTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetEntityTypes()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblEntityTypes order by EntityType"
        rsRecords.GetFromSQL(strSQL)
        Me.grdEntityTypes.DataSource = rsRecords.Table
    End Sub

    Private Sub grdEntityTypes_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdEntityTypes.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iEntityTypeID As Integer
            iEntityTypeID = Me.grdEntityTypes.GetValue("EntityTypeID")

            If DataStuff.DCount("CompanyID", "tblCompanies", "EntityTypeID=" & iEntityTypeID) > 0 Then
                MsgBox("You cannot delete an entity type that's attached to a company.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this EntityType?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblEntityTypes where EntityTypeID = " & iEntityTypeID
            DataStuff.RunSQL(strSQL)
            GetEntityTypes()
        End If
    End Sub

    Private Sub grdEntityTypes_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEntityTypes.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdEntityTypes_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEntityTypes.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

#End Region

#Region "Trademark Types"

    Private Sub LoadTrademarkTypes()
        On Error Resume Next
        With Me
            .grdTrademarkTypes.Top = 0
            .grdTrademarkTypes.Left = 0
            .grdTrademarkTypes.Visible = True
            .btnClose.Top = .grdTrademarkTypes.Height + 5
            .Height = .grdTrademarkTypes.Height + 70
            .Width = .grdTrademarkTypes.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Trademark Types"
        End With

        GetTrademarkTypes()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdTrademarkTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdTrademarkTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdTrademarkTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetTrademarkTypes()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblTrademarkTypes order by TrademarkType"
        rsRecords.GetFromSQL(strSQL)
        Me.grdTrademarkTypes.DataSource = rsRecords.Table
    End Sub

    Private Sub grdTrademarkTypes_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTrademarkTypes.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iTrademarkTypeID As Integer
            iTrademarkTypeID = Me.grdTrademarkTypes.GetValue("TrademarkTypeID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "TrademarkTypeID=" & iTrademarkTypeID) > 0 Then
                MsgBox("You cannot delete an Trademark Type that's attached to a trademark.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Trademark Type?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblTrademarkTypes where TrademarkTypeID = " & iTrademarkTypeID
            DataStuff.RunSQL(strSQL)
            GetTrademarkTypes()
        End If
    End Sub

    Private Sub grdTrademarkTypes_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkTypes.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdTrademarkTypes_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTrademarkTypes.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

#End Region

#Region "Filters"

    Private Sub LoadFilters(ByVal IsTrademark As Boolean)
        On Error Resume Next
        With Me
            .grdFilters.Top = 0
            .grdFilters.Left = 0
            .grdFilters.Visible = True
            .btnClose.Top = .grdFilters.Height + 5
            .Height = .grdFilters.Height + 70
            .Width = .grdFilters.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Stored Filters"
        End With

        GetFilters(IsTrademark)

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdFilters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdFilters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdFilters
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetFilters(ByVal IsTrademark As Boolean)
        On Error Resume Next
        Dim strSQL As String
        ' we'll be storing these in a local Access table either way, but we need to know if
        ' we're saving the Access values or SQL Server values

        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            If IsTrademark = True Then
                ' Access version, trademark filters
                strSQL = "Select * from tblFilterNames where IsTrademark <> 0 and IsSQL = 0 order by FilterName"
            Else
                ' Access version, patent filters
                strSQL = "Select * from tblFilterNames where IsTrademark = 0 and IsSQL = 0 order by FilterName"
            End If
        Else
            If IsTrademark = True Then
                ' SQL version, trademark filters
                strSQL = "Select * from tblFilterNames where IsTrademark <> 0 and IsSQL <> 0 order by FilterName"
            Else
                ' SQL version, patent filters
                strSQL = "Select * from tblFilterNames where IsTrademark = 0 and IsSQL <> 0 order by FilterName"
            End If
        End If

        rsRecords.GetFromDemo(strSQL)
        Me.grdFilters.DataSource = rsRecords.Table

    End Sub

    Private Sub grdFilters_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdFilters.AddingRecord
        On Error Resume Next
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            If iRecType = 11 Then
                ' Access version, trademark filters
                Me.grdFilters.SetValue("IsTrademark", True)
                Me.grdFilters.SetValue("IsSQL", False)
            Else
                ' Access version, patent filters
                Me.grdFilters.SetValue("IsTrademark", False)
                Me.grdFilters.SetValue("IsSQL", False)
            End If
        Else
            If iRecType = 11 Then
                ' SQL version, trademark filters
                Me.grdFilters.SetValue("IsTrademark", True)
                Me.grdFilters.SetValue("IsSQL", True)
            Else
                ' SQL version, patent filters
                Me.grdFilters.SetValue("IsTrademark", False)
                Me.grdFilters.SetValue("IsSQL", True)
            End If
        End If
    End Sub

    Private Sub grdFilters_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFilters.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdFilters_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFilters.RecordUpdated
        rsRecords.Update()
    End Sub

    Private Sub grdFilters_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdFilters.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iFilterID As Integer
            iFilterID = Me.grdFilters.GetValue("FilterID")

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this stored filter?"

            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblFilterNames where FilterID = " & iFilterID
            DataStuff.RunDemoSQL(strSQL)
            strSQL = "delete from tblFilterValues where FilterID = " & iFilterID
            DataStuff.RunDemoSQL(strSQL)

            If iRecType = 11 Then 'trademark filters
                GetFilters(True)
            Else  ' patent filters
                GetFilters(False)
            End If

        End If

    End Sub

#End Region


End Class