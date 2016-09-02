Public Class frmOppositionStatus

    Private rsRecords As New RecordSet

    Private Sub frmOppositionStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        AllForms.frmOppositionStatus = Me
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
        rsRecords.GetFromSQL("Select * from tblOppositionStatus")
        Me.grdStatus.DataSource = rsRecords.Table
    End Sub

    Private Sub frmOppositionStatus_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        'AllForms.frmOppositions.FillStatus()
        AllForms.frmOppositionStatus = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
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

            If DataStuff.DCount("OppositionID", "tblOppositions", "StatusID=" & iStatusID) > 0 Then
                MsgBox("You cannot delete a Status that's attached to an Opposition.")
                Exit Sub
            End If

            Dim strMsg As String
            strMsg = "Are you sure you want to delete this Status?"
            If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            strSQL = "delete from tblOppositionStatus where StatusID = " & iStatusID
            DataStuff.RunSQL(strSQL)
            GetStatus()

        End If

    End Sub

    
End Class