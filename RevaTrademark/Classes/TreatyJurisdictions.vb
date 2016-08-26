Public Class TreatyJurisdictions

    'one big class to handle adding/deleting to trademark and patent treaty jurisdictions.
    'for trademarks, a FilingBasis can be a treaty, for Patents it's a PatentType

    Private JuridictionID As Integer
    Private PatentTypeID As Integer
    Private FilingBasisID As Integer

    Private rsMarkTreaties As New RecordSet
    Private rsPatentTreaties As New RecordSet
    Private dtJurisdictions As DataTable
    Private dtPatentTypes As DataTable
    Private dtFilingBasis As DataTable

    Public Sub UpdatePatentTreaties()
        On Error Resume Next
        Dim TreatyJurisID As Integer, PatentTypeID As Integer, JurisdictionID As Integer, _
            i As Integer, j As Integer, dRow As DataRow

        LoadPatentTreaties()
        LoadPatentTypes()
        LoadPatentJurisdictions()

        'first loop through existing treaty/jurisdiction combos and kill any that don't belong
        For i = 0 To rsPatentTreaties.Table.Rows.Count - 1

            dRow = rsPatentTreaties.Table.Rows(i)
            TreatyJurisID = dRow("TreatyJurisID")
            PatentTypeID = dRow("PatentTypeID")
            JurisdictionID = dRow("JurisdictionID")

            If JurisdictionExists(JurisdictionID) = False Then
                DeletePatentTreaty(TreatyJurisID)
            End If

            If PatentTypeExists(PatentTypeID) = False Then
                DeletePatentTreaty(TreatyJurisID)
            End If

        Next i

        'now add every combination of patent type / jurisdiction that should exist but doesn't
        For i = 0 To dtJurisdictions.Rows.Count - 1
            JurisdictionID = dtJurisdictions.Rows(i).Item("JurisdictionID")
            For j = 0 To dtPatentTypes.Rows.Count - 1
                PatentTypeID = dtPatentTypes.Rows(j).Item("PatentTypeID")
                AddPatentTreaty(PatentTypeID, JurisdictionID)
            Next
        Next

        SavePatentChanges()

    End Sub

    Public Sub UpdateTrademarkTreaties()
        On Error Resume Next
        Dim TreatyJurisID As Integer, FilingBasisID As Integer, JurisdictionID As Integer, _
            i As Integer, j As Integer, dRow As DataRow

        LoadTrademarkTreaties()
        LoadFilingBasis()
        LoadTrademarkJurisdictions()

        'first loop through existing treaty/jurisdiction combos and kill any that don't belong
        For i = 0 To rsMarkTreaties.Table.Rows.Count - 1

            dRow = rsMarkTreaties.Table.Rows(i)
            TreatyJurisID = dRow("TreatyJurisID")
            FilingBasisID = dRow("FilingBasisID")
            JurisdictionID = dRow("JurisdictionID")

            If JurisdictionExists(JurisdictionID) = False Then
                DeleteMarkTreaty(TreatyJurisID)
            End If

            If FilingBasisExists(FilingBasisID) = False Then
                DeleteMarkTreaty(TreatyJurisID)
            End If

        Next i

        'now add every combination of filing basis / jurisdiction that should exist but doesn't
        For i = 0 To dtJurisdictions.Rows.Count - 1
            JurisdictionID = dtJurisdictions.Rows(i).Item("JurisdictionID")
            For j = 0 To dtFilingBasis.Rows.Count - 1
                FilingBasisID = dtFilingBasis.Rows(j).Item("FilingBasisID")
                AddTrademarkTreaty(FilingBasisID, JurisdictionID)
            Next
        Next

        SaveTrademarkChanges()

    End Sub

    Private Sub LoadPatentTreaties()
        On Error Resume Next
        rsPatentTreaties.GetFromSQL("Select * from tblPatentTreatyJurisdictions")
    End Sub

    Private Sub LoadTrademarkTreaties()
        On Error Resume Next
        rsMarkTreaties.GetFromSQL("Select * from tblTreatyJurisdictions")
    End Sub

    Private Sub LoadPatentTypes()
        On Error Resume Next
        dtPatentTypes = DataStuff.GetDataTable("Select * from tblPatentTypes where IsTreaty <> 0")
    End Sub

    Private Sub LoadFilingBasis()
        On Error Resume Next
        dtFilingBasis = DataStuff.GetDataTable("Select * from tblFilingBasis where IsTreaty <> 0")
    End Sub

    Private Sub LoadPatentJurisdictions()
        On Error Resume Next
        dtJurisdictions = DataStuff.GetDataTable("Select * from tblJurisdictions where IsPatent <> 0")
    End Sub

    Private Sub LoadTrademarkJurisdictions()
        On Error Resume Next
        dtJurisdictions = DataStuff.GetDataTable("Select * from tblJurisdictions where IsTrademark <> 0")
    End Sub

    Private Function JurisdictionExists(ByVal JurisdictionID As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "JurisdictionID=" & JurisdictionID

        dRows = dtJurisdictions.Select(strFilter)
        If dRows.Length = 0 Then
            JurisdictionExists = False
        Else
            JurisdictionExists = True
        End If

    End Function

    Private Function PatentTypeExists(ByVal PatentTypeID As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "PatentTypeID=" & PatentTypeID

        dRows = dtPatentTypes.Select(strFilter)
        If dRows.Length = 0 Then
            PatentTypeExists = False
        Else
            PatentTypeExists = True
        End If

    End Function

    Private Function PatentTreatyExists(ByVal PatentTypeID As Integer, ByVal JurisdictionID As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "PatentTypeID=" & PatentTypeID & " and JurisdictionID=" & JurisdictionID

        dRows = rsPatentTreaties.Table.Select(strFilter)
        If dRows.Length = 0 Then
            PatentTreatyExists = False
        Else
            PatentTreatyExists = True
        End If

    End Function

    Private Function FilingBasisExists(ByVal FilingBasisID As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "FilingBasisID=" & FilingBasisID

        dRows = dtFilingBasis.Select(strFilter)
        If dRows.Length = 0 Then
            FilingBasisExists = False
        Else
            FilingBasisExists = True
        End If

    End Function

    Private Function TrademarkTreatyExists(ByVal FilingBasisID As Integer, ByVal JurisdictionID As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "FilingBasisID=" & FilingBasisID & " and JurisdictionID=" & JurisdictionID

        dRows = rsMarkTreaties.Table.Select(strFilter)
        If dRows.Length = 0 Then
            TrademarkTreatyExists = False
        Else
            TrademarkTreatyExists = True
        End If

    End Function

    Private Sub DeletePatentTreaty(ByVal TreatyJurisID As Integer)
        On Error Resume Next
        Dim dRow As DataRow
        dRow = rsPatentTreaties.Table.Select("TreatyJurisID=" & TreatyJurisID)(0)
        dRow.Delete()
    End Sub

    Private Sub DeleteMarkTreaty(ByVal TreatyJurisID As Integer)
        On Error Resume Next
        Dim dRow As DataRow
        dRow = rsMarkTreaties.Table.Select("TreatyJurisID=" & TreatyJurisID)(0)
        dRow.Delete()
    End Sub

    Private Sub AddPatentTreaty(ByVal PatentTypeID As Integer, ByVal JurisdictionID As Integer)
        On Error Resume Next
        'only do this if doesn't already exist
        If PatentTreatyExists(PatentTypeID, JurisdictionID) Then Exit Sub

        Dim dRow As DataRow
        rsPatentTreaties.AddRow()
        dRow = rsPatentTreaties.CurrentRow
        dRow("PatentTypeID") = PatentTypeID
        dRow("JurisdictionID") = JurisdictionID
    End Sub

    Private Sub AddTrademarkTreaty(ByVal FilingBasisID As Integer, ByVal JurisdictionID As Integer)
        On Error Resume Next
        'only do this if doesn't already exist
        If TrademarkTreatyExists(FilingBasisID, JurisdictionID) Then Exit Sub

        Dim dRow As DataRow
        rsMarkTreaties.AddRow()
        dRow = rsMarkTreaties.CurrentRow
        dRow("FilingBasisID") = FilingBasisID
        dRow("JurisdictionID") = JurisdictionID
    End Sub

    Private Sub SavePatentChanges()
        On Error Resume Next
        'for when we're all done
        rsPatentTreaties.Update()
    End Sub

    Private Sub SaveTrademarkChanges()
        On Error Resume Next
        'for when we're all done
        rsMarkTreaties.Update()
    End Sub

End Class
