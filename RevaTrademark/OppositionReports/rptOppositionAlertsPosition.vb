Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptOppositionAlertsPosition

    Private LastOppositionID As Integer
    Private CurrentOppositionID As Integer

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
    End Sub

    Private Sub OppositionIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OppositionIDHeader.Format
        On Error Resume Next
        CurrentOppositionID = Me.Fields("OppositionID").Value
    End Sub

    Private Sub PositionIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PositionIDHeader.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        On Error Resume Next
        With Me
            If LastOppositionID = CurrentOppositionID Then
                .OppositionName.Visible = False
                .CompanyName.Visible = False
                .Jurisdiction.Visible = False
                .ProceedingNumber.Visible = False
            Else
                .OppositionName.Visible = True
                .CompanyName.Visible = True
                .Jurisdiction.Visible = True
                .ProceedingNumber.Visible = True
            End If
        End With
        LastOppositionID = CurrentOppositionID
    End Sub

    Private Sub rptOppositionAlertsPosition_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        On Error Resume Next
        LastOppositionID = 0
    End Sub
End Class
