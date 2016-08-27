Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPatentsByCompanyDates

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdPatentReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.PatentReportSubtitle.Text & ""

        If RevaSettings.USADates = True Then
            Me.PatentDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.PatentDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub DateDetail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateDetail.BeforePrint
        On Error Resume Next
        If Me.Fields("NoDay").Value = False Then
            Me.PatentDate.Visible = True
            Me.MonthYear.Visible = False
        Else
            Me.PatentDate.Visible = False
            Me.MonthYear.Visible = True
        End If

    End Sub
   
End Class
