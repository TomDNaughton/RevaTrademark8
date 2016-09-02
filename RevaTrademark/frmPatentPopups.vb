Public Class frmPatentPopups

    Private rsRecords As New RecordSet
    Public iRecType As Integer

    Public Sub GetRecordset(ByVal iType As Integer)
        On Error Resume Next
        'this form serves up one grid based on which drop down the user is trying to populate

        '1 = tblPatentFilingBasis, 2 = tblPatentTypes, 3= tblPatentClass

        Select Case iType
            Case 1
                LoadFilingBasis()
            Case 2
                LoadPatentTypes()
            Case 3
                LoadPatentClass()
        End Select
        'so we know what to do when we close
        iRecType = iType
    End Sub

    Private Sub frmPatentPopups_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        rsRecords = Nothing

        'requery patents form depending on what we updated here
        Select Case iRecType
            Case 1
                ' AllForms.frmPatents.FillFilingBasis()

            Case 2
                Dim TJ As New TreatyJurisdictions
                TJ.UpdatePatentTreaties()
                If Not (AllForms.frmPatents Is Nothing) Then
                    '  AllForms.frmPatents.FillPatentTypes()
                End If
                If Not (AllForms.frmPreferences Is Nothing) Then
                    AllForms.frmPreferences.FillPatentTypes()
                    AllForms.frmPreferences.FillWebLinks()
                End If

            Case 3
                AllForms.frmPatents.FillPatentClasses()

        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

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
            .Text = "Patent Filing Basis"
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
        rsRecords.GetFromSQL("Select * from tblPatentFilingBasis order by FilingBasis")
        Me.grdFilingBasis.DataSource = rsRecords.Table
    End Sub

    Private Sub grdRegTypes_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFilingBasis.RecordAdded
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
            Dim iFilingBasisID As Integer
            iFilingBasisID = Me.grdFilingBasis.GetValue("FilingBasisID")
            If DataStuff.DCount("PatentID", "tblPatents", "FilingBasisID=" & iFilingBasisID) > 0 Then
                MsgBox("You cannot delete a Filing Basis that's attached to a patent.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this FilingBasis?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String
            strSQL = "delete from tblPatentFilingBasis where FilingBasisID = " & iFilingBasisID
            DataStuff.RunSQL(strSQL)
            GetFilingBasis()
        End If

    End Sub

#End Region

#Region "Patent Types"

    Private Sub LoadPatentTypes()
        On Error Resume Next
        With Me
            .grdPatentTypes.Top = 0
            .grdPatentTypes.Left = 0
            .grdPatentTypes.Visible = True
            .btnClose.Top = .grdPatentTypes.Height + 5
            .Height = .grdPatentTypes.Height + 70
            .Width = .grdPatentTypes.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Patent Types"
        End With

        GetPatentTypes()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdPatentTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdPatentTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdPatentTypes
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With
        End Select

    End Sub

    Private Sub GetPatentTypes()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPatentTypes order by PatentType"
        rsRecords.GetFromSQL(strSQL)
        Me.grdPatentTypes.DataSource = rsRecords.Table
    End Sub

    Private Sub grdPatentTypes_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentTypes.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPatentTypes_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentTypes.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPatentTypes_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentTypes.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim strSQL As String, iPatentTypeID As Integer
            iPatentTypeID = Me.grdPatentTypes.GetValue("PatentTypeID")

            If DataStuff.DCount("PatentID", "tblPatents", "PatentTypeID=" & iPatentTypeID) > 0 Then
                MsgBox("You cannot delete a patent type that's attached to a Patent.")
                Exit Sub
            End If

            If DataStuff.DCount("JurisdictionDateID", "tblPatentJurisdictionDates", "JurisdictionID=" & (iPatentTypeID * -1)) > 0 Then
                MsgBox("You cannot delete a Patent Type that's been used to create a dates template.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Patent Type?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            strSQL = "delete from tblPatentTypes where PatentTypeID = " & iPatentTypeID
            DataStuff.RunSQL(strSQL)
            GetPatentTypes()

        End If
    End Sub

#End Region

#Region "Patent Classes"

    Private Sub LoadPatentClass()
        On Error Resume Next
        With Me
            .grdPatentClass.Top = 0
            .grdPatentClass.Left = 0
            .grdPatentClass.Visible = True
            .btnClose.Top = .grdPatentClass.Height + 5
            .Height = .grdPatentClass.Height + 70
            .Width = .grdPatentClass.Width + 15
            .btnClose.Left = (.Width / 2) - 47
            .Text = "Patent Classes"
        End With

        GetClasses()

        Select Case Globals.SecurityLevel
            Case 1 'TrademarkUser
                With Me.grdPatentClass
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Red
                End With

            Case 2 'No Delete
                With Me.grdPatentClass
                    .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    .RootTable.Columns("lnkDelete").CellStyle.ForeColor = Color.Gray
                End With

            Case 3 'View Only
                With Me.grdPatentClass
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
        strSQL = "Select * from tblPatentClass order by PatentClass"
        rsRecords.GetFromSQL(strSQL)
        Me.grdPatentClass.DataSource = rsRecords.Table
    End Sub

    Private Sub grdPatentClass_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentClass.RecordAdded
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPatentClass_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPatentClass.RecordUpdated
        On Error Resume Next
        rsRecords.Update()
    End Sub

    Private Sub grdPatentClass_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdPatentClass.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then
            Dim iPatentClassID As Integer
            iPatentClassID = Me.grdPatentClass.GetValue("PatentClassID")

            If DataStuff.DCount("PatentClassesID", "tblPatentClasses", "PatentClassID=" & iPatentClassID) > 0 Then
                MsgBox("You cannot delete a Class that's attached to a patent.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Class?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String

            strSQL = "delete from tblPatentClass where PatentClassID = " & iPatentClassID
            DataStuff.RunSQL(strSQL)
            GetClasses()
        End If
    End Sub

#End Region



End Class