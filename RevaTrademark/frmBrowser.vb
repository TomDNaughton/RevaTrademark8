Public Class frmBrowser

    Friend FieldName As String
    Friend SearchNumber As String

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Browser.GoBack()
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        On Error Resume Next
        Me.Browser.GoForward()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        On Error Resume Next
        Me.Browser.Refresh()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        On Error Resume Next
        Me.Browser.Navigate(Me.cboAddress.Text)
    End Sub

    Private Sub cboAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddress.Click
        On Error Resume Next
        Me.Browser.Navigate(Me.cboAddress.Text)
    End Sub

    Private Sub frmBrowser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmBrowser = Nothing
    End Sub

    Private Sub frmBrowser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmBrowser = Me
    End Sub

    Private Sub cboAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAddress.KeyPress
        On Error Resume Next
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Me.Browser.Navigate(Me.cboAddress.Text)
        End If
    End Sub

    Private Sub btnGetNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetNumber.Click
        On Error Resume Next
        Me.Browser.Document.ActiveElement.InnerText = SearchNumber & ""
    End Sub
End Class