Public Class frmTestViewTable

    Private Sub frmTestViewTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal dt As DataTable)
        InitializeComponent()
        Me.grdViewTable.DataSource = dt
        Me.grdViewTable.RetrieveStructure()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Me.grdViewTable.DataSource = ds
        Me.grdViewTable.RetrieveStructure()
    End Sub


End Class