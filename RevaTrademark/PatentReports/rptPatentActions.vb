Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPatentActions

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdPatentReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.PatentReportSubtitle.Text & ""

        If RevaSettings.USADates = True Then
            Me.ActionDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.ActionDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub
    
End Class
