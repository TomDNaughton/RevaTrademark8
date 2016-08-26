Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarkActions

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdMarkReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.ReportSubTitle.Text & ""

        If My.Settings.USADates = True Then
            Me.ActionDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.ActionDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    
End Class
