Public Class frmAddPatentDates

    Private Sub frmAddPatentDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        AllForms.frmAddPatentDates = Me
        If My.Settings.USADates = True Then
            Me.grdAddDates.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
        Else
            Me.grdAddDates.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
        End If
        GetDatesToAdd()
    End Sub

    Private Sub frmAddPatentDates_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmAddPatentDates = Nothing
    End Sub

    Friend Sub GetDatesToAdd()
        On Error Resume Next
        Dim strSQL As String, iJurisdictionID As Integer, iPatentTypeID As Integer, dtDatesToAdd As DataTable, _
            i As Integer, GRow As Janus.Windows.GridEX.GridEXRow

        iJurisdictionID = Nz(AllForms.frmPatents.JurisdictionID.Value, 0)
        iPatentTypeID = Nz(AllForms.frmPatents.PatentTypeID.Value, 0)

        strSQL = "Select * from qvwPatentJurisdictionDates where JurisdictionID=" & iJurisdictionID & _
            " and PatentTypeID=" & iPatentTypeID & _
            " and (DateID not in (Select DateID from tblPatentDates where PatentID=" & Globals.PatentID & _
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
        Dim i As Integer, iPatentID As Integer

        'first, add dates to the current Patent and update the Patents screen
        AddDatesToPatent(Globals.PatentID)
        AllForms.frmPatents.GetDates()

        'requery dates to add in case user wants to add others
        GetDatesToAdd()

    End Sub

    Private Sub AddDatesToPatent(ByVal iPatentID As Integer)
        On Error Resume Next

        Dim i As Integer, GridRow As Janus.Windows.GridEX.GridEXRow, PatentDate As Date, _
            RecurNumber As Integer, DateID As Integer, Completed As Boolean, IsLocked As Boolean

        Dim PD As New PatentDates
        With PD
            .PatentID = iPatentID
            .PatentTypeID = AllForms.frmPatents.PatentTypeID.Value
            .JurisdictionID = Me.grdAddDates.GetValue("JurisdictionID")
            .LoadJurisdictionDates()
            .LoadPatentDates()
            'more of a precaution than anything
            .UpdateRecurNumbers()

            For i = 0 To Me.grdAddDates.RowCount - 1
                GridRow = Me.grdAddDates.GetRow(i)
                If IsDate(GridRow.Cells("PatentDate").Value) Then
                    DateID = GridRow.Cells("DateID").Value
                    PatentDate = GridRow.Cells("PatentDate").Value
                    RecurNumber = .NextRecurNumber(DateID)
                    Completed = IIf(GridRow.Cells("Completed").Value = True, True, False)
                    IsLocked = IIf(GridRow.Cells("IsLocked").Value = True, True, False)
                    .AddDate(DateID, RecurNumber, PatentDate, False, False, Completed, IsLocked)
                    .UpdatePatentDate(DateID, RecurNumber, True)
                End If
            Next i
            .ReOrderPatentDates()
            .SaveChanges()
        End With

        PD = Nothing

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub


End Class