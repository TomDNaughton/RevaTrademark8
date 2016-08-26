Imports System.Data.OleDb
Imports System.Data

Public Class BoundRecordSet

    Friend Table As DataTable
    Friend strSQL As String
    Friend CurrentRow As DataRow
    Friend SortString As String

    Friend DSet As New DataSet
    Private dbAdapter As OleDbDataAdapter
    Private cmdBuilder As OleDbCommandBuilder
    Private cnn As New OleDbConnection
    Private bsBindingSource As New BindingSource
    Private PrimaryKeyField As String

    Friend Sub Connect()
        On Error Resume Next
        cnn.ConnectionString = My.Settings.CurrentConnection
        dbAdapter = New OleDbDataAdapter(strSQL, cnn)
        cmdBuilder = New OleDbCommandBuilder(dbAdapter)
        cmdBuilder = New OleDbCommandBuilder
        cmdBuilder.DataAdapter = dbAdapter
        dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
    End Sub

    Friend Sub GetRecords()
        On Error Resume Next
        DSet.Tables.Clear()
        dbAdapter.Fill(DSet, "tblTable")
        Table = DSet.Tables(0)
        CurrentRow = Table.Rows(0)
        bsBindingSource.DataSource = Table
        ' Always make the primary key first in the table or query!
        ' If not, use FindRecordByColumn and FilterByString
        PrimaryKeyField = Table.Columns(0).ColumnName
    End Sub

    Friend Sub AddRow()
        On Error Resume Next
        Table.Rows.Add()
        CurrentRow = Table.Rows(Table.Rows.Count - 1)
    End Sub

    Friend Sub GetFromSQL(ByVal SQL As String)
        On Error Resume Next
        strSQL = SQL
        Connect()
        GetRecords()
    End Sub

    Friend Sub GetFromSQL(ByVal SQL As String, ByVal SortOrder As String)
        On Error Resume Next
        strSQL = SQL
        SortString = SortOrder
        Connect()
        GetRecords()
        bsBindingSource.Sort = SortString & ""
    End Sub

    Friend Sub BindData(ByVal Control As Control)
        On Error Resume Next
        ' for standard controls, same name as database field, we know what to bind
        If Control.DataBindings.Count < 1 Then
            If TypeOf Control Is TextBox Then
                Control.DataBindings.Add("Text", bsBindingSource, Control.Name)
                Exit Sub
            End If

            If TypeOf Control Is CheckBox Then
                Control.DataBindings.Add("Checked", bsBindingSource, Control.Name)
                Exit Sub
            End If

            If TypeOf Control Is ComboBox Then
                Control.DataBindings.Add("Value", bsBindingSource, Control.Name)
                Exit Sub
            End If

            If TypeOf Control Is Janus.Windows.GridEX.EditControls.MultiColumnCombo Then
                Control.DataBindings.Add("Value", bsBindingSource, Control.Name)
                Exit Sub
            End If

            If TypeOf Control Is MaskedTextBox Then
                Control.DataBindings.Add("Text", bsBindingSource, Control.Name)
                Exit Sub
            End If
        End If
    End Sub

    Friend Sub BindData(ByVal Control As Control, ByVal BindToProperty As String)
        On Error Resume Next
        ' if control has same name as field, but we need to name binding property
        If Control.DataBindings.Count < 1 Then
            Control.DataBindings.Add(BindToProperty, bsBindingSource, Control.Name)
        End If
    End Sub

    Friend Sub BindData(ByVal Control As Control, ByVal BindToProperty As String, ByVal FieldName As String)
        On Error Resume Next
        ' if control doesn't have same name as field, and we need to name binding property
        If Control.DataBindings.Count < 1 Then
            Control.DataBindings.Add(BindToProperty, bsBindingSource, FieldName)
        End If
    End Sub

    Friend Sub FindRecordByKey(ByVal KeyValue As Object)
        On Error Resume Next
        Dim iPos As Integer
        iPos = bsBindingSource.Find(PrimaryKeyField, KeyValue)
        bsBindingSource.Position = iPos
    End Sub

    Friend Sub FindRecordByColumn(ByVal ColumnName As String, ByVal KeyValue As Object)
        On Error Resume Next
        Dim iPos As Integer
        iPos = bsBindingSource.Find(ColumnName, KeyValue)
        bsBindingSource.Position = iPos
    End Sub

    Friend Sub FilterByKey(ByVal KeyValue As Object)
        On Error Resume Next
        Dim strFilter As String
        strFilter = PrimaryKeyField & "=" & KeyValue.ToString
        bsBindingSource.Filter = strFilter
    End Sub

    Friend Sub FilterByString(ByVal FilterString As String)
        On Error Resume Next
        bsBindingSource.Filter = FilterString
    End Sub

    Friend Sub RemoveFilter()
        On Error Resume Next
        bsBindingSource.RemoveFilter()
    End Sub

    Friend Sub CancelEdit()
        On Error Resume Next
        bsBindingSource.CancelEdit()
    End Sub

    Friend Sub Update()
        'On Error Resume Next
        Try
            bsBindingSource.EndEdit()
            If DSet.HasChanges = True Then
                dbAdapter.Update(Table)
                bsBindingSource.Sort = SortString
                'MsgBox("changes made") 'JUST FOR TESTING
            Else
                'MsgBox("No changes")  'this is just for testing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Friend Function RecordExists(ByVal strFilter) As Boolean
        On Error Resume Next
        'to see if a record exists, filter and check results
        Dim dr As DataRow
        dr = Table.Select(strFilter)(0)  'zero gets first row only
        RecordExists = Not (dr Is Nothing)
        dr = Nothing
    End Function

End Class
