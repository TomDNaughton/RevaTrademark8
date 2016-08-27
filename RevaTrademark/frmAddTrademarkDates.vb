Public Class frmAddTrademarkDates

    Private Sub frmAddTrademarkDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        AllForms.frmAddTrademarkDates = Me
        If RevaSettings.USADates = True Then
            Me.grdAddDates.RootTable.Columns("TrademarkDate").FormatString = "MMM dd, yyyy"
        Else
            Me.grdAddDates.RootTable.Columns("TrademarkDate").FormatString = "dd MMM yyyy"
        End If
        GetDatesToAdd()
    End Sub

    Private Sub frmAddTrademarkDates_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmAddTrademarkDates = Nothing
    End Sub

    Friend Sub GetDatesToAdd()
        On Error Resume Next
        Dim strSQL As String, iJurisdictionID As Integer, dtDatesToAdd As DataTable, i As Integer, _
            GRow As Janus.Windows.GridEX.GridEXRow

        'if we're adding dates to a treaty mark, show the grid with related marks in other jurisdictions
        With AllForms.frmTrademarks
            If .bIsTreaty = True Then
                iJurisdictionID = (.FilingBasisID.Value * -1)
                Me.pnlRelated.Visible = True
                Me.Height = 380
                GetTreatyTrademarks()
            Else
                iJurisdictionID = .JurisdictionID.Value
                Me.pnlRelated.Visible = False
                Me.Height = 272
            End If
        End With


        strSQL = "Select * from qvwTrademarkJurisdictionDates where JurisdictionID=" & iJurisdictionID & _
            " and (DateID not in (Select DateID from tblTrademarkDates where TrademarkID=" & Globals.TrademarkID & _
            ") or (CanRecur <> 0)) order by ListOrder"

        dtDatesToAdd = DataStuff.GetDataTable(strSQL)

        With Me
            .grdAddDates.DataSource = dtDatesToAdd
            'set Completed to false for all
            For i = 0 To .grdAddDates.RowCount - 1
                GRow = .grdAddDates.GetRow(i)
                If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                    GRow.BeginEdit()
                    GRow.Cells("Completed").Value = False
                    GRow.Cells("IsLocked").Value = False
                    GRow.EndEdit()
                End If
            Next
        End With

    End Sub

    Private Sub btnAddDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDates.Click
        On Error Resume Next
        Dim i As Integer, iTrademarkID As Integer, GRow As Janus.Windows.GridEX.GridEXRow

        'first, add dates to the current trademark and update the trademarks screen
        AddDatesToTrademark(Globals.TrademarkID)
        AllForms.frmTrademarks.GetDates()

        'if this is a treaty mark, add same dates to other marks selected
        For i = 0 To Me.grdRelated.RowCount - 1
            GRow = Me.grdRelated.GetRow(i)
            If GRow.Cells("AddRelated").Value = True Then
                iTrademarkID = GRow.Cells("TrademarkID").Value
                AddDatesToTrademark(iTrademarkID)
            End If
        Next i

        'requery dates to add in case user wants to add others
        GetDatesToAdd()
    End Sub

    Private Sub AddDatesToTrademark(ByVal iTrademarkID As Integer)
        On Error Resume Next

        Dim i As Integer, GridRow As Janus.Windows.GridEX.GridEXRow, TrademarkDate As Date, _
            RecurNumber As Integer, DateID As Integer, Completed As Boolean, IsLocked As Boolean

        Dim MD As New MarkDates
        With MD
            .TrademarkID = iTrademarkID
            .JurisdictionID = Me.grdAddDates.GetValue("JurisdictionID")
            .LoadJurisdictionDates()
            .LoadMarkDates()
            'more of a precaution than anything
            .UpdateRecurNumbers()

            For i = 0 To Me.grdAddDates.RowCount - 1
                GridRow = Me.grdAddDates.GetRow(i)
                If IsDate(GridRow.Cells("TrademarkDate").Value) Then
                    DateID = GridRow.Cells("DateID").Value
                    TrademarkDate = GridRow.Cells("TrademarkDate").Value
                    RecurNumber = .NextRecurNumber(DateID)
                    Completed = IIf(GridRow.Cells("Completed").Value = True, True, False)
                    IsLocked = IIf(GridRow.Cells("IsLocked").Value = True, True, False)
                    .AddDate(DateID, RecurNumber, TrademarkDate, False, False, Completed, IsLocked)
                    .UpdateTrademarkDate(DateID, RecurNumber, True)
                End If
            Next i
            .ReOrderTrademarkDates()
            .SaveChanges()
        End With

        MD = Nothing

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
                    GRow.Cells("AddRelated").Value = False
                    GRow.EndEdit()
                End If
            Next
        End With

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub grdRelated_ColumnHeaderClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdRelated.ColumnHeaderClick
        On Error Resume Next
        If e.Column.Key = "AddRelated" Then
            Dim bAddRelated As Boolean, i As Integer, GRow As Janus.Windows.GridEX.GridEXRow
            With Me.grdRelated
                .Row = 0
                bAddRelated = .CurrentRow.Cells("AddRelated").Value
                For i = 0 To .RowCount - 1
                    GRow = .GetRow(i)
                    If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                        GRow.BeginEdit()
                        GRow.Cells("AddRelated").Value = Not bAddRelated
                        GRow.EndEdit()
                    End If
                Next i
            End With
        End If
    End Sub

   
End Class