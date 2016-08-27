Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptOppositionActions

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)

        If RevaSettings.USADates = True Then
            Me.ActionDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.ActionDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub rptTrademarkActions_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        On Error Resume Next
      
    End Sub
End Class
