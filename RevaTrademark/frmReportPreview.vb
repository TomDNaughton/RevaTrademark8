Public Class frmReportPreview

    Private Sub frmReportPreview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmReportPreview = Nothing
    End Sub

    Private Sub frmReportPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmReportPreview = Me

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        On Error Resume Next
        Dim strFileName As String
        With Me.SaveFileDialog
            If Not (AllForms.frmTrademarks Is Nothing) Then
                .InitialDirectory = RevaSettings.TrademarkDocuments
            Else
                .InitialDirectory = RevaSettings.PatentDocuments
            End If

            .FileName = ""
            .Filter = "PDF Documents (*.pdf)|*.pdf"
            .FilterIndex = 1
            .Title = "Name the new document"
            .RestoreDirectory = False
            .OverwritePrompt = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = .FileName & ""
                Me.PdfExport.Export(Me.ReportViewer.Document, strFileName)
                If MsgBox("Open the PDF document now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strFileName)
                End If
            End If
        End With
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        On Error Resume Next
        Dim strFileName As String
        With Me.SaveFileDialog
            If Not (AllForms.frmTrademarks Is Nothing) Then
                .InitialDirectory = RevaSettings.TrademarkDocuments
            Else
                .InitialDirectory = RevaSettings.PatentDocuments
            End If
            .FileName = ""
            .Filter = "Excel Documents (*.xls)|*.xls"
            .FilterIndex = 1
            .Title = "Name the new document"
            .RestoreDirectory = False
            .OverwritePrompt = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = .FileName & ""
                Me.XlsExport.Export(Me.ReportViewer.Document, strFileName)
                If MsgBox("Open the Excel document now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strFileName)
                End If
            End If
        End With
    End Sub

    Private Sub btnRTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRTF.Click
        On Error Resume Next
        Dim strFileName As String
        With Me.SaveFileDialog
            If Not (AllForms.frmPatents Is Nothing) Then
                .InitialDirectory = RevaSettings.PatentDocuments
            Else
                .InitialDirectory = RevaSettings.TrademarkDocuments
            End If

            .FileName = ""
            .Filter = "Rich Text Documents (*.rtf)|*.rtf"
            .FilterIndex = 1
            .Title = "Name the new document"
            .RestoreDirectory = False
            .OverwritePrompt = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = .FileName & ""
                Me.RtfExport.EnableShapes = True
                Me.RtfExport.Export(Me.ReportViewer.Document, strFileName)
                If MsgBox("Open the document now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strFileName)
                End If
            End If
        End With
    End Sub
End Class