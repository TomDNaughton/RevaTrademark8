Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPatentsByCompanyList

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdPatentReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.PatentReportSubtitle.Text & ""
    End Sub

    Private Sub CompanyHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyHeader.Format
        On Error Resume Next
        Me.CompanyCountLabel.Value = "Total Patents For " & Me.Fields("CompanyName").Value & ":"
    End Sub

   
End Class
