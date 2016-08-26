Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rtpOneTrademark

    Private CurrentTrademarkID As Integer

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)


        If My.Settings.USADates = True Then
            Me.TrademarkDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.TrademarkDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub TrademarkIDHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrademarkIDHeader.BeforePrint
        On Error Resume Next
        Me.picGraphic.Image = Nothing
        If Me.Fields("GraphicPath").Value & "" = "" Then
        Else
            Me.picGraphic.Image = System.Drawing.Image.FromFile(Me.Fields("GraphicPath").Value & "")
        End If

        If Me.Fields("GraphicSizeToFit").Value = True Then
            Me.picGraphic.SizeMode = SizeModes.Zoom
        End If
    End Sub

    Private Sub TrademarkIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkIDHeader.Format
        On Error Resume Next
        Dim TrademarkID As Integer, strSQL As String, drReader As OleDb.OleDbDataReader

        TrademarkID = Me.Fields("TrademarkID").Value
        CurrentTrademarkID = TrademarkID

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
        GetActions()
    End Sub

    Private Sub GetActions()
        On Error Resume Next
        Dim strSQL As String, drReader As OleDb.OleDbDataReader
        strSQL = "Select * from tblTrademarkActions where TrademarkID=" & CurrentTrademarkID & _
            " order by ActionDate, TrademarkActionID"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            Dim SR As New subrptTrademarkActions
            SR.DataSource = drReader
            Me.SubrptTrademarkActions.Report = SR
            Me.TrademarkIDFooter.Visible = True
        Else
            Me.TrademarkIDFooter.Visible = False
            drReader = Nothing
            Me.SubrptTrademarkActions.Report = Nothing
        End If
    End Sub
End Class
