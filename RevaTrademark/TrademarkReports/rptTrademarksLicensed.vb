Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarksLicensed

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdMarkReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.ReportSubTitle.Text & ""
    End Sub

    Private Sub DateDetail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateDetail.BeforePrint


    End Sub

    Private Sub DateDetail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateDetail.Format

    End Sub
End Class
