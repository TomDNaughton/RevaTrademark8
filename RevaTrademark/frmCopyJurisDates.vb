Public Class frmCopyJurisDates

    Private iJurisdictionID As Integer, iPatentTypeID As Integer, bIsTrademark As Boolean

    Private Sub frmCopyJurisDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim strSQL As String
        strSQL = ""
        If AllForms.frmPreferences.Tabs.SelectedIndex = 0 Then
            bIsTrademark = True
            iJurisdictionID = Nz(AllForms.frmPreferences.cboMarkJurisdiction.Value, 0)
            strSQL = "Select * from tblJurisdictions where IsTrademark <> 0 and JurisdictionID <>" & _
                iJurisdictionID & " order by Jurisdiction"
            Me.grdJurisidictions.RootTable.Columns("PatentTypeID").Visible = False
            Me.Width = 299
            Me.btnClose.Left = 111
        Else
            bIsTrademark = False
            iJurisdictionID = Nz(AllForms.frmPreferences.cboPatentJurisdiction.Value, 0)
            iPatentTypeID = Nz(AllForms.frmPreferences.cboPatentType.Value, 0)
            strSQL = "Select * from tblJurisdictions where IsPatent <> 0 order by Jurisdiction"
            Me.grdJurisidictions.DropDowns("cboPatentType").SetDataBinding(AllForms.frmPreferences.dtPatentTypes, "")
            Me.grdJurisidictions.RootTable.Columns("PatentTypeID").Visible = True
            Me.Width = 425
            Me.btnClose.Left = 171
        End If

        Me.grdJurisidictions.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub grdJurisidictions_LinkClicked(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdJurisidictions.LinkClicked
        On Error Resume Next
        Dim rsJurisDates As New RecordSet, dtJurisDates As DataTable, dRow As DataRow, DateID As Integer, _
            dRows As DataRow(), i As Integer, j As Integer, iCopyJurisdiction As Integer

        iCopyJurisdiction = Me.grdJurisidictions.GetValue("JurisdictionID")

        If bIsTrademark = True Then
            rsJurisDates.GetFromSQL("Select * from tblJurisdictionDates where JurisdictionID=" & iJurisdictionID)
            dtJurisDates = DataStuff.GetDataTable("Select * from tblJurisdictionDates where JurisdictionID=" & iCopyJurisdiction)

            For i = 0 To dtJurisDates.Rows.Count - 1
                dRow = dtJurisDates.Rows(i)
                DateID = dRow("DateID")
                dRows = rsJurisDates.Table.Select("DateID=" & DateID)
                If dRows.Length = 0 Then 'no match
                    rsJurisDates.AddRow()
                    For j = 0 To dtJurisDates.Columns.Count - 1
                        Select Case dtJurisDates.Columns(j).ColumnName
                            Case "JurisdictionDateID"
                                'nothing, it's primary key
                            Case "JurisdictionID"
                                rsJurisDates.CurrentRow.Item(j) = iJurisdictionID
                            Case Else
                                rsJurisDates.CurrentRow.Item(j) = dRow.Item(j)
                        End Select
                    Next j
                End If
            Next i
            rsJurisDates.Update()
            AllForms.frmPreferences.ReOrderMarkJurisDates()
            AllForms.frmPreferences.GetTrademarkJurisDates()
        End If

        If bIsTrademark = False Then
            Dim iCopyPatentType As Integer
            iCopyPatentType = Nz(Me.grdJurisidictions.GetValue("PatentTypeID"), 0)

            If iCopyPatentType = 0 Then
                MsgBox("You must select a patent type before copying the template.")
                Exit Sub
            End If

            If ((iPatentTypeID = iCopyPatentType) And (iJurisdictionID = iCopyJurisdiction)) Then
                MsgBox("You cannot copy the same patent type to the same jurisdiction.")
                Exit Sub
            End If

            rsJurisDates.GetFromSQL("Select * from tblPatentJurisdictionDates where JurisdictionID=" & _
                iJurisdictionID & " and PatentTypeID=" & iPatentTypeID)
            dtJurisDates = DataStuff.GetDataTable("Select * from tblPatentJurisdictionDates where JurisdictionID=" & _
                iCopyJurisdiction & " and PatentTypeID=" & iCopyPatentType)

            For i = 0 To dtJurisDates.Rows.Count - 1
                dRow = dtJurisDates.Rows(i)
                DateID = dRow("DateID")
                dRows = rsJurisDates.Table.Select("DateID=" & DateID)
                If dRows.Length = 0 Then 'no match
                    rsJurisDates.AddRow()
                    For j = 0 To dtJurisDates.Columns.Count - 1
                        Select Case dtJurisDates.Columns(j).ColumnName
                            Case "JurisdictionDateID"
                                'nothing, it's primary key
                            Case "JurisdictionID"
                                rsJurisDates.CurrentRow.Item(j) = iJurisdictionID
                            Case "PatentTypeID"
                                rsJurisDates.CurrentRow.Item(j) = iPatentTypeID
                            Case Else
                                rsJurisDates.CurrentRow.Item(j) = dRow.Item(j)
                        End Select
                    Next j
                End If
            Next i
            rsJurisDates.Update()
            AllForms.frmPreferences.ReOrderPatentJurisDates()
            AllForms.frmPreferences.GetPatentJurisDates()
        End If


        Me.Close()

    End Sub
End Class