Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptOnePatent

    Private CurrentPatentID As Integer

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)

        If RevaSettings.USADates = True Then
            Me.PatentDate.OutputFormat = "MMM dd, yyyy"
        Else
            Me.PatentDate.OutputFormat = "dd MMM yyyy"
        End If
    End Sub

    Private Sub PatentIDHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatentIDHeader.BeforePrint
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

    Private Sub PatentIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatentIDHeader.Format
        On Error Resume Next
        Dim PatentID As Integer, strSQL As String, drReader As OleDb.OleDbDataReader
        PatentID = Me.Fields("PatentID").Value
        CurrentPatentID = PatentID
        strSQL = "Select * from qvwPatentClasses where PatentID=" & PatentID & " order by PatentClass"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            Dim SR As New subrptPatentClasses
            SR.DataSource = drReader
            Me.subrptPatentClasses.Report = SR
        Else
            Me.subrptPatentClasses.Visible = False
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

    Private Sub PatentIDFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatentIDFooter.Format
        On Error Resume Next
        Dim strSQL As String, drReader As OleDb.OleDbDataReader
        strSQL = "Select * from tblPatentActions where PatentID=" & CurrentPatentID & " order by ActionDate, PatentActionID"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            Dim SR As New subrptPatentActions
            SR.DataSource = drReader
            Me.subrptPatentActions.Report = SR
            Me.PatentIDFooter.Visible = True
        Else
            Me.PatentIDFooter.Visible = False
            drReader = Nothing
            Me.subrptPatentActions.Report = Nothing
        End If
    End Sub
End Class
