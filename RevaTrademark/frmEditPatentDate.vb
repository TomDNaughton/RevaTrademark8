Public Class frmEditPatentDate

    Private Sub frmEditPatentDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        AllForms.frmEditPatentDate = Me
        Me.lblDateName.Text = AllForms.frmPatents.grdDates.CurrentRow.Cells("DateName").Value
        If RevaSettings.USADates = True Then
            Me.grdEditDate.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
            Me.grdDates.RootTable.Columns("PatentDate").FormatString = "MMM dd, yyyy"
        Else
            Me.grdEditDate.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
            Me.grdDates.RootTable.Columns("PatentDate").FormatString = "dd MMM yyyy"
        End If
        GetPatentDate()

        With Me.grdDates.RootTable.Columns("IntervalType").ValueList
            .Add(0, "(None)")
            .Add(1, "Days Before")
            .Add(2, "Months Before")
            .Add(3, "Years Before")
            .Add(4, "Days After")
            .Add(5, "Months After")
            .Add(6, "Years After")
        End With

        Me.grdDates.DataSource = AllForms.frmPatents.grdDates.DataSource

    End Sub

    Private Sub GetPatentDate()
        On Error Resume Next
        Dim iPatentDateID As Integer, iJurisdictionID As Integer, strSQL As String, dtDate As DataTable

        iPatentDateID = AllForms.frmPatents.grdDates.GetValue("PatentDateID")
        strSQL = "Select * from tblPatentDates where PatentDateID=" & iPatentDateID
        dtDate = DataStuff.GetDataTable(strSQL)
        Me.grdEditDate.DataSource = dtDate

        With AllForms.frmPatents.grdDates
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

    End Sub

    Private Sub frmEditPatentDate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmEditPatentDate = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error Resume Next
        Dim DateID As Integer, RecurNumber As Integer, PatentDate As Date, NoDay As Boolean, NoMonth As Boolean, _
            Completed As Boolean, IsLocked As Boolean, EmailSent As Boolean, _
            UpdateRelatives As Boolean, AddNext As Boolean, JurisdictionID As Integer

        With Me.grdEditDate
            PatentDate = IIf(IsDate(.GetValue("PatentDate")), .GetValue("PatentDate"), Date.MinValue)
            NoDay = IIf(.GetValue("NoDay") = True, True, False)
            NoMonth = IIf(.GetValue("NoMonth") = True, True, False)
            Completed = IIf(.GetValue("Completed") = True, True, False)
            IsLocked = IIf(.GetValue("IsLocked") = True, True, False)
            EmailSent = IIf(.GetValue("EmailSent") = True, True, False)
            UpdateRelatives = IIf(.GetValue("UpdateRelated") = True, True, False)
            AddNext = IIf(.GetValue("AddNext") = True, True, False)
            JurisdictionID = .GetValue("JurisdictionID")
            DateID = .GetValue("DateID")
            RecurNumber = .GetValue("RecurNumber")
        End With

        Dim PD As New PatentDates
        With PD
            .PatentID = Globals.PatentID
            .JurisdictionID = JurisdictionID
            .PatentTypeID = Nz(AllForms.frmPatents.PatentTypeID.Value, 0)
            .LoadPatentDates()
            .LoadJurisdictionDates()
            .EditPatentDate(DateID, RecurNumber, PatentDate, NoDay, NoMonth, Completed, IsLocked, _
                EmailSent, UpdateRelatives, AddNext, JurisdictionID)
            .UpdateRecurNumbers()
            .ReOrderPatentDates()
            .SaveChanges()
        End With


        PD = Nothing
        AllForms.frmPatents.GetDates()
        Me.Close()

    End Sub

    Private Sub grdDates_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDates.LinkClicked
        On Error Resume Next
        Dim PatentDate As Date, iInterval As Integer, iIntervalType As Integer

        If IsDate(Me.grdDates.GetValue("PatentDate")) = False Then
            MsgBox("Cannot calculate against a blank date")
            Exit Sub
        End If

        With Me.grdDates
            PatentDate = .GetValue("PatentDate")
            iInterval = Nz(.GetValue("IntervalNumber"), 0)
            iIntervalType = Nz(.GetValue("IntervalType"), 0)
        End With

        If (iInterval = 0) Or (iIntervalType = 0) Then
            Me.grdEditDate.SetValue("PatentDate", PatentDate)
            Exit Sub
        End If

        RecalcDate(PatentDate, iInterval, iIntervalType)

    End Sub

    Private Sub RecalcDate(ByVal BaseDate As Date, ByVal IntervalNumber As Integer, _
       ByVal IntervalType As Integer)

        On Error Resume Next
        Dim NewDate As Date

        Select Case IntervalType
            Case 1  'days before
                NewDate = DateAdd("d", -IntervalNumber, BaseDate)

            Case 2  'months before
                NewDate = DateAdd("m", -IntervalNumber, BaseDate)

            Case 3  'years before
                NewDate = DateAdd("yyyy", -IntervalNumber, BaseDate)

            Case 4  'days after
                NewDate = DateAdd("d", IntervalNumber, BaseDate)

            Case 5  'months after
                NewDate = DateAdd("m", IntervalNumber, BaseDate)

            Case 6  'years after
                NewDate = DateAdd("yyyy", IntervalNumber, BaseDate)
        End Select

        Me.grdEditDate.SetValue("PatentDate", NewDate)
    End Sub

    
    
End Class