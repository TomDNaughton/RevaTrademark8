Public Class aForm1

    Private Sub aForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtTest As DataTable
        dtTest = DataStuff.GetDataTable("select * from qvwTrademarks")
        Me.grdMarks.DataSource = dtTest
    End Sub
End Class