Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptOneOpposition

    Private CurrentOppositionID As Integer

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)


        If My.Settings.USADates = True Then
            Me.OppositionDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.OppositionDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub OppositionIDHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles OppositionIDHeader.BeforePrint

    End Sub

    Private Sub OppositionIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OppositionIDHeader.Format
        On Error Resume Next
        Dim OppositionID As Integer, strSQL As String, drClientReader As OleDb.OleDbDataReader, _
            drOpposingReader As OleDb.OleDbDataReader

        OppositionID = Me.Fields("OppositionID").Value
        CurrentOppositionID = OppositionID

        strSQL = "Select * from qvwOppositionClientMarks where OppositionID=" & OppositionID
        drClientReader = DataStuff.GetDataReader(strSQL)
        If drClientReader.HasRows = True Then
            Dim SR As New subrptOppositionClientMarks
            SR.DataSource = drClientReader
            Me.subrptOppositionClientMarks.Report = SR
        Else
            Me.subrptOppositionClientMarks.Visible = False
        End If

        strSQL = "Select * from tblOppositionTrademarks where OppositionID=" & OppositionID
        drOpposingReader = DataStuff.GetDataReader(strSQL)
        If drOpposingReader.HasRows = True Then
            Dim SR2 As New subrptOppositionMarks
            SR2.DataSource = drOpposingReader
            Me.subrptOppositionMarks.Report = SR2
        Else
            Me.subrptOppositionMarks.Visible = False
        End If

    End Sub

    Private Sub OppositionIDFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OppositionIDFooter.Format
        GetActions()
    End Sub

    Private Sub GetActions()
        On Error Resume Next
        Dim strSQL As String, drReader As OleDb.OleDbDataReader
        strSQL = "Select * from tblOppositionActions where OppositionID=" & CurrentOppositionID & _
            " order by ActionDate, OppositionActionID"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            Dim SR As New subrptOppositionActions
            SR.DataSource = drReader
            Me.SubrptOppositionActions.Report = SR
            Me.OppositionIDFooter.Visible = True
        Else
            Me.OppositionIDFooter.Visible = False
            drReader = Nothing
            Me.SubrptOppositionActions.Report = Nothing
        End If
    End Sub
End Class
