Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarkAlertsPosition

    Private LastTrademarkID As Integer
    Private CurrentTrademarkID As Integer

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(My.Settings.ReportIcon)
    End Sub


    Private Sub rptTrademarkAlertsPosition_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        On Error Resume Next
        LastTrademarkID = 0

        Dim i As Integer, iColWidth As Integer, iMaxWidth As Integer, iCurrentLeft As Integer
        Dim strColumnCaption As String, strColumnName As String
        Dim LabelHeight As Single, LabelTop As Single
        Dim DetailFont = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim LabelFont = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim ctlTextBox As DataDynamics.ActiveReports.TextBox
        Dim ctlLabel As DataDynamics.ActiveReports.Label
        Dim ctlCheckBox As DataDynamics.ActiveReports.CheckBox
        Dim Grid As Janus.Windows.GridEX.GridEX, GCol As Janus.Windows.GridEX.GridEXColumn

        'These are the variables to change on other reports as needed
        iMaxWidth = InchesToPoints(9.97)
        Grid = AllForms.frmTrademarks.grdAlerts
        LabelHeight = 0.17
        LabelTop = 0.63 'distance from top of page header

        'Okay, on to it.  This should be the same for any other report.
        iCurrentLeft = 0
        Me.Detail1.CanGrow = True

        For i = 0 To Grid.RootTable.Columns.Count - 1
            'once the current left position exceeds the max width, we need to stop
            If iCurrentLeft > iMaxWidth Then Exit Sub

            GCol = Grid.RootTable.Columns.GetColumnInPosition(i)

            If GCol.Visible = True Then
                strColumnCaption = GCol.Caption
                strColumnName = GCol.Key
                iColWidth = GCol.Width

                ' first create the label
                ctlLabel = New DataDynamics.ActiveReports.Label
                With ctlLabel
                    .Text = strColumnCaption
                    .Top = LabelTop
                    .Height = LabelHeight
                    .Font = LabelFont
                    .Left = PointsToInches(iCurrentLeft)
                    If GCol.CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center Then
                        .Alignment = TextAlignment.Center
                    End If
                End With

                If GCol.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox Then
                    ctlCheckBox = New DataDynamics.ActiveReports.CheckBox
                    With ctlCheckBox
                        .DataField = strColumnName
                        .Top = 0
                        .Left = PointsToInches(iCurrentLeft + 10)
                    End With

                Else
                    'then the corresponding textbox
                    ctlTextBox = New DataDynamics.ActiveReports.TextBox
                    With ctlTextBox
                        .DataField = strColumnName
                        .Top = 0
                        .Height = Me.Detail1.Height - 0.04
                        .Font = DetailFont
                        .CanGrow = True
                        .MultiLine = True
                        .WordWrap = True
                        .Left = PointsToInches(iCurrentLeft)
                        If strColumnName = "TrademarkDate" Then
                            If My.Settings.USADates = True Then
                                .OutputFormat = "MMM dd, yyyy"
                            Else
                                .OutputFormat = "dd MMM yyyy"
                            End If
                        End If
                        If GCol.CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center Then
                            .Alignment = TextAlignment.Center
                        End If
                    End With

                End If

                If (iCurrentLeft + iColWidth) < iMaxWidth Then
                    ctlLabel.Width = PointsToInches(iColWidth)
                    If GCol.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox Then
                        Me.Detail1.Controls.Add(ctlCheckBox)
                    Else
                        ctlTextBox.Width = PointsToInches(iColWidth)
                        Me.Detail1.Controls.Add(ctlTextBox)
                        ctlTextBox.BringToFront()
                    End If

                    iCurrentLeft = iCurrentLeft + iColWidth '+ 2 'leave a little gap for next control
                    Me.ContactIDHeader.Controls.Add(ctlLabel)
                    ctlLabel.BringToFront()

                Else
                    iCurrentLeft = iMaxWidth + iColWidth + 2
                End If

            End If

        Next i

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        On Error Resume Next
        LastTrademarkID = CurrentTrademarkID
    End Sub

    Private Sub TrademarkIDHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkIDHeader.Format
        On Error Resume Next
        CurrentTrademarkID = Me.Fields("TrademarkID").Value
    End Sub

    Private Sub TrademarkIDFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkIDFooter.Format
        On Error Resume Next
        'if user prints this report by date, we don't want actions showing up every time the same mark appears
        If AllForms.frmTrademarks.grdAlerts.RootTable.SortKeys(0).Column.Key = "TrademarkDate" Then
            Me.TrademarkIDFooter.Visible = False
            Exit Sub
        End If

        Dim strSQL As String, drReader As OleDb.OleDbDataReader
        strSQL = "Select * from tblTrademarkActions where TrademarkID=" & CurrentTrademarkID & _
            " order by ActionDate, TrademarkActionID"
        drReader = DataStuff.GetDataReader(strSQL)
        If drReader.HasRows = True Then
            'MsgBox(TrademarkID & " has rows")
            Dim SR As New subrptTrademarkActions
            SR.DataSource = drReader
            Me.SubrptTrademarkActions.Report = SR
            'Me.FooterLine.Visible = True
            Me.TrademarkIDFooter.Visible = True
        Else
            Me.TrademarkIDFooter.Visible = False
            drReader = Nothing
            Me.SubrptTrademarkActions.Report = Nothing
            'Me.FooterLine.Visible = False
        End If
    End Sub
End Class
