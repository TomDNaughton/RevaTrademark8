Public Class frmCopyTrademarkName


    Private Sub frmCopyTrademarkName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim strSQL As String, iCompanyID As Integer
        iCompanyID = AllForms.frmTrademarks.CompanyID.Value
        strSQL = "Select distinct TrademarkName from tblTrademarks where CompanyID=" & iCompanyID
        Me.grdMarkNames.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub grdMarkNames_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdMarkNames.LinkClicked
        On Error Resume Next
        AllForms.frmTrademarks.TrademarkName.Text = Me.grdMarkNames.GetValue("TrademarkName")
        Me.Close()
    End Sub
End Class