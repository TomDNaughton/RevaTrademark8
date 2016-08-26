Public Class frmEditTrademarkDate

    Private Sub frmEditTrademarkDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        AllForms.frmEditTrademarkDate = Me
        Me.lblDateName.Text = AllForms.frmTrademarks.grdDates.CurrentRow.Cells("DateName").Value
        If My.Settings.USADates = True Then
            Me.grdEditDate.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
        Else
            Me.grdEditDate.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
        End If
        GetTrademarkDate()
    End Sub

    Private Sub GetTrademarkDate()
        On Error Resume Next
        Dim iTrademarkDateID As Integer, iJurisdictionID As Integer, strSQL As String, dtDate As DataTable

        iTrademarkDateID = AllForms.frmTrademarks.grdDates.GetValue("TrademarkDateID")
        strSQL = "Select * from tblTrademarkDates where TrademarkDateID=" & iTrademarkDateID
        dtDate = DataStuff.GetDataTable(strSQL)
        Me.grdEditDate.DataSource = dtDate

        With AllForms.frmTrademarks.grdDates
            If .GetValue("HasRelatives") = True Then
                Me.grdEditDate.RootTable.Columns("UpdateRelated").Visible = True
                Me.grdEditDate.SetValue("UpdateRelated", True)
            Else
                Me.grdEditDate.RootTable.Columns("UpdateRelated").Visible = False
            End If

            If .GetValue("RecursAtInterval") = True Then
                Me.grdEditDate.RootTable.Columns("AddNext").Visible = True
                Me.grdEditDate.SetValue("AddNext", True)
            Else
                Me.grdEditDate.RootTable.Columns("AddNext").Visible = False
            End If
        End With

        'if we're editing a date from a treaty mark, show the grid with related marks in other jurisdictions
        With AllForms.frmTrademarks
            If .bIsTreaty = True Then
                iJurisdictionID = (.FilingBasisID.Value * -1)
                Me.pnlRelated.Visible = True
                Me.Height = 315
                GetTreatyTrademarks()
            Else
                iJurisdictionID = .JurisdictionID.Value
                Me.pnlRelated.Visible = False
                Me.Height = 250
            End If
        End With

    End Sub

    Private Sub GetTreatyTrademarks()
        On Error Resume Next
        Dim strSQL As String, dtTreatyTrademarks As DataTable, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow

        'other marks filed on same treaty filing as this mark
        strSQL = "select * from qvwTreatyFilingTrademarks where TreatyFilingID=" & Globals.TreatyFilingID & _
        " and IsBasis = 0 and TrademarkID <> " & Globals.TrademarkID

        dtTreatyTrademarks = DataStuff.GetDataTable(strSQL)
        With Me.grdRelated
            .DataSource = dtTreatyTrademarks

            For i = 0 To .RowCount - 1
                GRow = .GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    GRow.BeginEdit()
                    GRow.Cells("UpdateRelated").Value = False
                    GRow.EndEdit()
                End If
            Next
        End With

    End Sub

    Private Sub grdRelated_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRelated.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "UpdateRelated" Then
            Dim bAddRelated As Boolean, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
            With Me.grdRelated
                .Row = 0
                bAddRelated = .CurrentRow.Cells("UpdateRelated").Value
                For i = 0 To .RowCount - 1
                    GRow = .GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        GRow.BeginEdit()
                        GRow.Cells("UpdateRelated").Value = Not bAddRelated
                        GRow.EndEdit()
                    End If
                Next i
            End With
        End If
    End Sub

    Private Sub frmEditTrademarkDate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmEditTrademarkDate = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error Resume Next
        Dim DateID As Integer, RecurNumber As Integer, TrademarkDate As Date, NoDay As Boolean, NoMonth As Boolean, _
            Completed As Boolean, IsLocked As Boolean, EmailSent As Boolean, _
            UpdateRelatives As Boolean, AddNext As Boolean, JurisdictionID As Integer

        With Me.grdEditDate
            TrademarkDate = IIf(IsDate(.GetValue("TrademarkDate")), .GetValue("TrademarkDate"), Date.MinValue)
            NoDay = IIf(.GetValue("NoDay") = True, True, False)
            NoMonth = IIf(.GetValue("NoMonth") = True, True, False)
            Completed = IIf(.GetValue("Completed") = True, True, False)
            IsLocked = IIf(.GetValue("IsLocked") = True, True, False)
            EmailSent = IIf(.GetValue("EmailSent") = True, True, False)
            UpdateRelatives = IIf(.GetValue("UpdateRelated") = True, True, False)
            AddNext = IIf(.GetValue("AddNext") = True, True, False)
            'if we're updating a treaty trademark, the jurisdiction of the dates isn't the same
            'as the jurisdiction of the mark itself ... e.g., mark is Germany, dates are Madrid Protocol
            JurisdictionID = .GetValue("JurisdictionID")
            DateID = .GetValue("DateID")
            RecurNumber = .GetValue("RecurNumber")
        End With

        Dim MD As New MarkDates
        With MD
            .TrademarkID = Globals.TrademarkID
            .JurisdictionID = JurisdictionID
            .LoadMarkDates()
            .LoadJurisdictionDates()
            .EditTrademarkDate(DateID, RecurNumber, TrademarkDate, NoDay, NoMonth, Completed, IsLocked, _
                EmailSent, UpdateRelatives, AddNext, JurisdictionID)
            .UpdateRecurNumbers()
            .ReOrderTrademarkDates()
            .SaveChanges()
        End With

        If AllForms.frmTrademarks.bIsTreaty = True Then
            Dim iTrademarkID As Integer, GRow As Janus.Windows.GridEX.GridEXRow, i As Integer
            For i = 0 To Me.grdRelated.RowCount - 1
                GRow = Me.grdRelated.GetRow(i)
                If GRow.Cells("UpdateRelated").Value = True Then
                    iTrademarkID = GRow.Cells("TrademarkID").Value
                    JurisdictionID = GRow.Cells("JurisdictionID").Value
                    With MD
                        'load dates for the treaty trademark; however, we don't
                        're-load jurisdiction dates; it's a treaty jurisdiction -- same for each mark
                        .TrademarkID = iTrademarkID
                        .LoadMarkDates()
                        .EditTrademarkDate(DateID, RecurNumber, TrademarkDate, NoDay, NoMonth, Completed, _
                            IsLocked, EmailSent, UpdateRelatives, AddNext, JurisdictionID)
                        .UpdateRecurNumbers()
                        .ReOrderTrademarkDates()
                        .SaveChanges()
                    End With
                End If
            Next i
        End If

        MD = Nothing
        AllForms.frmTrademarks.GetDates()
        Me.Close()

    End Sub

   
End Class