Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTrademarksListGroup

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        On Error Resume Next
        Me.ReportGraphic.Image = System.Drawing.Image.FromFile(RevaSettings.ReportIcon)
        Me.lblReportTitle.Text = AllForms.frmReports.grdMarkReports.GetValue("ReportName")
        Me.ReportSubtitle.Value = AllForms.frmReports.ReportSubTitle.Text & ""
    End Sub

    Private Sub rptTrademarksListGroup_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Dim i As Integer, iColWidth As Integer, iMaxWidth As Integer, iCurrentLeft As Integer
        Dim strColumnCaption As String, strColumnName As String
        Dim LabelHeight As Single, LabelTop As Single
        Dim DetailFont = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim LabelFont = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim ctlTextBox As DataDynamics.ActiveReports.TextBox
        Dim ctlLabel As DataDynamics.ActiveReports.Label
        Dim ctlCheckbox As DataDynamics.ActiveReports.CheckBox
        Dim Grid As Janus.Windows.GridEX.GridEX, GCol As Janus.Windows.GridEX.GridEXColumn

        'These are the variables to change on other reports as needed
        iMaxWidth = InchesToPoints(9.97)
        Grid = AllForms.frmReports.grdMarks
        LabelHeight = 0.17
        LabelTop = 0.1 'distance from top of page header

        ' Start by assuming no group sections
        With Me
            .GroupOneHeader.Visible = False
            .GroupOneFooter.Visible = False
            .GroupTwoHeader.Visible = False
            .GroupTwoFooter.Visible = False
        End With

        'Okay, on to it.  This should be the same for any other report.
        iCurrentLeft = 0
        Me.TrademarkDetail.CanGrow = True

        'if there are groupings in the grid, we'll copy them to section headings here.
        If Grid.RootTable.Groups.Count > 0 Then
            Dim strGroupColumn As String
            strGroupColumn = Grid.RootTable.Groups(0).Column.Key

            With Me
                .GroupOneHeader.Visible = True
                .GroupOneHeader.DataField = strGroupColumn
                .GroupOneFooter.Visible = True
                .GroupOneTextField.DataField = strGroupColumn

                'user can decide to create new page on first grouping
                If AllForms.frmReports.chkMarkGroupNewPage.Checked = True Then
                    .GroupOneHeader.NewPage = NewPage.Before
                Else
                    .GroupOneHeader.NewPage = NewPage.None
                End If

                If Grid.RootTable.Groups.Count = 2 Then
                    strGroupColumn = Grid.RootTable.Groups(1).Column.Key
                    .GroupTwoHeader.Visible = True
                    .GroupTwoHeader.DataField = strGroupColumn
                    .GroupTwoFooter.Visible = True
                    .GroupTwoTextField.DataField = strGroupColumn
                End If
            End With
        End If

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
                    ' 'then the corresponding textbox or image

                    If GCol.Key = "Graphic" Then
                        With PictureBox
                            .Visible = True
                            .Top = 0
                            .Height = Me.TrademarkDetail.Height + 0.5
                            .Left = PointsToInches(iCurrentLeft)
                            .SizeMode = SizeModes.Zoom
                            .PictureAlignment = PictureAlignment.TopLeft
                        End With

                    Else
                        ctlTextBox = New DataDynamics.ActiveReports.TextBox
                        With ctlTextBox
                            .DataField = strColumnName
                            .Top = 0
                            .Height = Me.TrademarkDetail.Height - 0.04
                            .Font = DetailFont
                            .CanGrow = True
                            .MultiLine = True
                            .WordWrap = True
                            .Left = PointsToInches(iCurrentLeft)
                            If GCol.CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center Then
                                .Alignment = TextAlignment.Center
                            End If
                        End With

                    End If

                End If

                If (iCurrentLeft + iColWidth) < iMaxWidth Then
                    ctlLabel.Width = PointsToInches(iColWidth)
                    If GCol.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox Then
                        Me.TrademarkDetail.Controls.Add(ctlCheckbox)
                    Else
                        If GCol.Key = "Graphic" Then
                            PictureBox.Width = PointsToInches(iColWidth)
                            PictureBox.BringToFront()
                        Else
                            ctlTextBox.Width = PointsToInches(iColWidth)
                            Me.TrademarkDetail.Controls.Add(ctlTextBox)
                            ctlTextBox.BringToFront()
                        End If
                    End If

                    iCurrentLeft = iCurrentLeft + iColWidth '+ 2 'leave a little gap for next control
                    Me.LabelGroup.Controls.Add(ctlLabel)
                    ctlLabel.BringToFront()

                Else
                    iCurrentLeft = iMaxWidth + iColWidth + 2
                End If

            End If

        Next i
    End Sub

    Private Sub GroupOneHeader_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupOneHeader.AfterPrint
        On Error Resume Next
        Me.GroupOneCountLabel.Text = Me.GroupOneTextField.Text & " Trademarks:"
    End Sub

    Private Sub GroupTwoHeader_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupTwoHeader.AfterPrint
        On Error Resume Next
        Me.GroupTwoCountLabel.Text = Me.GroupTwoTextField.Text & " Trademarks:"
    End Sub

    Private Sub TrademarkDetail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrademarkDetail.Format
        Try
            If Me.Fields("Graphic").Value.ToString <> String.Empty Then
                Me.PictureBox.Image = System.Drawing.Image.FromFile(Me.Fields("Graphic").Value)
                Me.PictureBox.Visible = True
            Else
                Me.PictureBox.Image = Nothing
                Me.PictureBox.Visible = False
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
