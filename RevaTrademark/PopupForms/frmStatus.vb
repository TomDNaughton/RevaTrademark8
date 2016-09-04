Public Class frmStatus

    Private rsRecords As New RevaData.RecordSet
    Private TableUpdated As Boolean = False

    Private Sub frmStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetStatus()
    End Sub

    Private Sub GetStatus()
        Try

            rsRecords.GetFromSQL("Select * from tblStatus order by Status")
            Me.grdStatus.DataSource = rsRecords.Table

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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdStatus_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdStatus.RecordAdded
        TableUpdated = True
        rsRecords.Update()
    End Sub

    Private Sub grdStatus_RecordUpdated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdStatus.RecordUpdated
        TableUpdated = True
        rsRecords.Update()
    End Sub

    Private Sub grdStatus_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdStatus.LinkClicked
        On Error Resume Next
        If (Globals.SecurityLevel = 1) And (e.Column.Key = "lnkDelete") Then

            Dim iStatusID As Integer
            iStatusID = Me.grdStatus.GetValue("StatusID")

            If RevaData.DCount("TrademarkID", "tblTrademarks", "StatusID=" & iStatusID) > 0 Then
                MsgBox("You cannot delete a Status that's attached to a trademark.")
                Exit Sub
            End If

            If RevaData.DCount("PatentID", "tblPatents", "StatusID=" & iStatusID) > 0 Then
                MsgBox("You cannot delete a Status that's attached to a patent.")
                Exit Sub
            End If

            If MsgBox("Are you sure you want to delete this Status?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim strSQL As String = "delete from tblStatus where StatusID = " & iStatusID

            RevaData.RunSQL(strSQL)
            TableUpdated = True
            GetStatus()

        End If

    End Sub

    Private Sub frmStatus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If TableUpdated = True Then

                RevaData.FillStatus()

                If AllForms.frmTrademarks IsNot Nothing Then
                    frmTrademarks.FillDropDowns()
                End If

                If AllForms.frmPatents IsNot Nothing Then
                    frmPatents.FillDropDowns()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class