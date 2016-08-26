Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarksByCompanyDates

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdMarkReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.ReportSubTitle.Text & ""

        If My.Settings.USADates = True Then
            Me.TrademarkDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.TrademarkDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub DateDetail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateDetail.BeforePrint
        On Error Resume Next
        If Me.Fields("NoDay").Value = False Then
            Me.TrademarkDate.Visible = True
            Me.MonthYear.Visible = False
        Else
            Me.TrademarkDate.Visible = False
            Me.MonthYear.Visible = True
        End If

    End Sub


    
End Class
