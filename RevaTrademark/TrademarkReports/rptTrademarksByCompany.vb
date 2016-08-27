Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarksByCompany

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdMarkReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.ReportSubTitle.Text & ""

        If RevaSettings.USADates = True Then
            Me.TrademarkDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.TrademarkDate.OutputFormat = "dd MMM yyyy"
        End If

    End Sub

    Private Sub TrademarkIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkIDHeader.Format
        On Error Resume Next
        Dim TrademarkID As Integer, strSQL As String, drReader As OleDb.OleDbDataReader
        TrademarkID = Me.Fields("TrademarkID").Value
        strSQL = "Select * from qvwTrademarkClasses where TrademarkID=" & TrademarkID & " order by RegClass"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            Dim SR As New subrptTrademarkClasses
            SR.DataSource = drReader
            Me.RegClassSubReport.Report = SR
        Else
            Me.RegClassSubReport.Visible = False
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

    Private Sub TrademarkIDFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkIDFooter.Format

    End Sub

    Private Sub DateDetail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateDetail.Format

    End Sub
End Class
