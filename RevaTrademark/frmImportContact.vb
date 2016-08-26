Public Class frmImportContact

    
    Private Sub frmImportContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from qvwContactsAndCompanies order by CompanyName, LastName"
        Me.grdContactList.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub grdContactList_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContactList.LinkClicked
        On Error Resume Next
        Dim iContactID As Integer, strSQL As String
        iContactID = Me.grdContactList.GetValue("ContactID")
        strSQL = "update tblContacts set CompanyID=" & Globals.CompanyID & " where ContactID=" & iContactID
        DataStuff.RunSQL(strSQL)
        AllForms.frmCompanies.GetContacts()
    End Sub
End Class