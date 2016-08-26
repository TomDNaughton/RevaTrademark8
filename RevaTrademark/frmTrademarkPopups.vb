Public Class frmTrademarkPopups

    Private rsRecords As New RecordSet
    Public iRecType As Integer

    Public Sub GetRecordset(ByVal iType As Integer)
        On Error Resume Next
        'this form serves up one grid based on which drop down the user is trying to populate

        '1 = tblRegistrationTypes, 2 = tblRegistrationClass, 3= tblFilingBasis

        Select Case iType
            Case 1
                LoadRegTypes()
            Case 2
                LoadRegClasses()
            Case 3
                LoadFilingBasis()
        End Select
        'so we know what to do when we close
        iRecType = iType
    End Sub

    Private Sub frmTrademarkPopups_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        rsRecords = Nothing

        'requery Trademarks form depending on what we updated here
        Select Case iRecType
            Case 1
                AllForms.frmTrademarks.FillRegTypes()

            Case 2
                AllForms.frmTrademarks.FillRegClasses()

            Case 3
                Dim TJ As New TreatyJurisdictions
                TJ.UpdateTrademarkTreaties()
                If Not (AllForms.frmTrademarks Is Nothing) Then AllForms.frmTrademarks.FillFilingBasis()
                If Not (AllForms.frmPreferences Is Nothing) Then
                    AllForms.frmPreferences.FillWebLinks()
                    AllForms.frmPreferences.FillFilingBasis()
                End If

        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

#Region "Registration Types"

    Private Sub LoadRegTypes()
        On Error Resume Next
        With Me
            .grdRegTypes.Top = 0
            .grdRegTypes.Left = 0
            .grdRegTypes.Visible = True
            .btnClose.Top = .grdRegTypes.Height + 5
            .Height = .grdRegTypes.Height + 70
            .Width = .grdRegTypes.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Registration Types"
        End With

        GetRegTypes()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdRegTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdRegTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdRegTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetRegTypes()
        On Error Resume Next
        rsRecords.GetFromSQL("Select *, (Select Count(RegTypeID) from tblTrademarks where RegTypeID=tblRegistrationTypes.RegTypeID" & _
            ") as InTrademarks from tblRegistrationTypes order by RegistrationType")
        ' rsRecords.GetFromSQL("Select * from tblRegistrationTypes order by RegistrationType")
        Me.grdRegTypes.DataSource = rsRecords.Table
    End Sub

    Private Sub grdRegTypes_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRegTypes.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdRegTypes_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRegTypes.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdRegTypes_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRegTypes.LinkClicked
        On Error Resume Next

        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            If Me.grdRegTypes.GetValue("InTrademarks") > 0 Then
                MsgBox("You cannot delete a Registration Type that's attached to a trademark.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Registration Type?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iRegTypeID As Integer
            iRegTypeID = Me.grdRegTypes.GetValue("RegTypeID")
            strSQL = "delete from tblRegistrationTypes where RegTypeID = " & iRegTypeID
            DataStuff.RunSQL(strSQL)
            GetRegTypes()
        End If

    End Sub

#End Region

#Region "Registration Classes"

    Private Sub LoadRegClasses()
        On Error Resume Next
        With Me
            .grdRegClasses.Top = 0
            .grdRegClasses.Left = 0
            .grdRegClasses.Visible = True
            .btnClose.Top = .grdRegClasses.Height + 5
            .Height = .grdRegClasses.Height + 70
            .Width = .grdRegClasses.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Registration Classes"
        End With

        GetClasses()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdRegClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdRegClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdRegClasses
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetClasses()
        On Error Resume Next
        Dim strSQL As String
        'strSQL = "Select * from tblRegistrationClass order by RegClass"
        strSQL = "Select *, (Select Count(RegClassID) from tblTrademarkRegClasses where " & _
            "RegClassID=tblRegistrationClass.RegClassID) as InTrademarks from tblRegistrationClass order by RegClass"
        rsRecords.GetFromSQL(strSQL)
        Me.grdRegClasses.DataSource = rsRecords.Table
    End Sub

    Private Sub grdRegClasses_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRegClasses.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdRegClasses_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRegClasses.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdRegClasses_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRegClasses.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            If Me.grdRegClasses.GetValue("InTrademarks") > 0 Then
                MsgBox("You cannot delete a Registration Class that's attached to a trademark.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Registration Class?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String, iRegClassID As Integer
            iRegClassID = Me.grdRegClasses.GetValue("RegClassID")
            strSQL = "delete from tblRegistrationClass where RegClassID = " & iRegClassID
            DataStuff.RunSQL(strSQL)
            GetClasses()
        End If
    End Sub

#End Region

#Region "Filing Basis"

    Private Sub LoadFilingBasis()
        On Error Resume Next
        With Me
            .grdFilingBasis.Top = 0
            .grdFilingBasis.Left = 0
            .grdFilingBasis.Visible = True
            .btnClose.Top = .grdFilingBasis.Height + 5
            .Height = .grdFilingBasis.Height + 70
            .Width = .grdFilingBasis.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Filing Basis"
        End With

        GetFilingBasis()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdFilingBasis
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdFilingBasis
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdFilingBasis
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetFilingBasis()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select FilingBasisID, FilingBasis, IsTreaty from tblFilingBasis order by FilingBasis"
        rsRecords.GetFromSQL(strSQL)
        Me.grdFilingBasis.DataSource = rsRecords.Table
    End Sub

    Private Sub grdFilingBasis_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFilingBasis.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdFilingBasis_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFilingBasis.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdFilingBasis_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdFilingBasis.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iFilingBasisID As Integer
            iFilingBasisID = Me.grdFilingBasis.GetValue("FilingBasisID")

            If DataStuff.DCount("TrademarkID", "tblTrademarks", "FilingBasisID=" & iFilingBasisID) > 0 Then
                MsgBox("You cannot delete a filing basis that's attached to a trademark.")
                Exit Sub
            End If

            If DataStuff.DCount("JurisdictionDateID", "tblJurisdictionDates", "JurisdictionID=" & (iFilingBasisID * -1)) > 0 Then
                MsgBox("You cannot delete a Treaty filing basis that's been used to create a dates template.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Filing Basis?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblFilingBasis where FilingBasisID = " & iFilingBasisID
            DataStuff.RunSQL(strSQL)
            GetFilingBasis()

        End If
    End Sub

#End Region

End Class