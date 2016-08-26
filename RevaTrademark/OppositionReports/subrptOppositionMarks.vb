Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class subrptOppositionMarks

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        If My.Settings.USADates = True Then
            Me.FilingDate.OutputFormat = "MMM dd, yyyy"
            Me.FirstUseDate.OutputFormat = "MMM dd, yyyy"
            Me.RegistrationDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.FilingDate.OutputFormat = "dd MMM yyyy"
            Me.FirstUseDate.OutputFormat = "dd MMM yyyy"
            Me.RegistrationDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub
End Class
