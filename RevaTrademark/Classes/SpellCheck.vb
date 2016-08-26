Imports Microsoft.Office.Interop

Public Class SpellChecker
    'Despite the examples on the internet, all this code seems to do is lock up Word and RevaTrademark both.
    'I'll leave it for now in case there's a fix.

    Private WordApp As Word.Application
    Private WordDoc As Word.Document
    Private iData As IDataObject

    Friend Sub StartWord()
        On Error Resume Next
        If (WordApp Is Nothing) Then
            WordApp = New Word.Application
        End If
        WordApp.Visible = False
        WordApp.WindowState = 0
        WordApp.Top = -3500
    End Sub

    Friend Sub StopWord()
        On Error Resume Next
        If Not (WordApp Is Nothing) Then
            WordApp.Quit()
            WordApp = Nothing
        End If

    End Sub

    Friend Sub CheckSpelling(ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal ColumnName As String)
        On Error Resume Next

        Dim GRow As Janus.Windows.GridEX.GridEXRow, GCell As Janus.Windows.GridEX.GridEXCell, i As Integer

        For i = 0 To Grid.RowCount - 1
            GRow = Grid.GetRow(i)
            If GRow.RowType = Janus.Windows.GridEX.RowType.Record Then
                GCell = GRow.Cells(ColumnName)
                If GCell.Text & "" <> "" Then
                    RunSpeller(GCell)
                End If
            End If
        Next
        Grid.UpdateData()
        StopWord()
    End Sub

    Friend Sub CheckSpelling(ByVal TextBox1 As TextBox)
        On Error Resume Next
        RunSpeller(TextBox1)
        StopWord()
    End Sub

    Friend Sub CheckSpelling(ByVal TextBox1 As TextBox, ByVal TextBox2 As TextBox)
        RunSpeller(TextBox1)
        RunSpeller(TextBox2)
        StopWord()
    End Sub

    Friend Sub CheckSpelling(ByVal TextBox1 As TextBox, ByVal TextBox2 As TextBox, ByVal TextBox3 As TextBox)
        RunSpeller(TextBox1)
        RunSpeller(TextBox2)
        RunSpeller(TextBox3)
        StopWord()
    End Sub

    Friend Sub RunSpeller(ByVal RowCell As Janus.Windows.GridEX.GridEXCell)
        On Error Resume Next
        WordDoc = Nothing
        WordDoc = WordApp.Documents.Add
        WordApp.Visible = False
        WordApp.WindowState = 0
        WordApp.Top = -3500
        Clipboard.SetDataObject(RowCell.Text)

        With WordDoc
            .Content.Paste()
            .Activate()
            .CheckSpelling()

            'Transfer the contents clipboard to the control
            .Content.Copy()
            iData = Clipboard.GetDataObject
            If iData.GetDataPresent(DataFormats.Text) Then
                RowCell.Row.BeginEdit()
                RowCell.Value = CType(iData.GetData(DataFormats.Text), String)
                RowCell.DataChanged = True
                RowCell.Row.EndEdit()
            End If
            .Close(False)
        End With
        WordDoc = Nothing
    End Sub

    Friend Sub RunSpeller(ByVal TextBox As TextBox)
        On Error Resume Next
        If TextBox.Text & "" = "" Then Exit Sub

        Dim TextColor As System.Drawing.Color = TextBox.BackColor
        TextBox.BackColor = Color.Yellow
        WordDoc = Nothing
        WordDoc = WordApp.Documents.Add
        WordApp.Visible = False
        WordApp.WindowState = 0
        WordApp.Top = -3500
        Clipboard.SetDataObject(TextBox.Text)

        With WordDoc
            .Content.Paste()
            .Activate()
            .CheckSpelling()

            'Transfer the contents clipboard to the control
            .Content.Copy()
            iData = Clipboard.GetDataObject
            If iData.GetDataPresent(DataFormats.Text) Then
                TextBox.Text = CType(iData.GetData(DataFormats.Text), String)
            End If
            .Close(False)
        End With
        WordDoc = Nothing
        TextBox.BackColor = TextColor
    End Sub


End Class
