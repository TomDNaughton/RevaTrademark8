Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPatentsLicensed

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdPatentReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.PatentReportSubtitle.Text & ""
    End Sub

    Private Sub DateDetail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateDetail.BeforePrint


    End Sub

    Private Sub DateDetail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateDetail.Format

    End Sub
End Class
