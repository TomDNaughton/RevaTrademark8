Public Class MarkDates
    'to update trademark dates, you gotta have class ...
    'the idea here is to open the jurisdiction dates and the trademark dates ONCE, 
    'make all the change we need to make -- add, delete, recalculate, renumber, 
    'reorder, etc. -- in one shot, then update.

    Friend TrademarkID As Integer
    Friend JurisdictionID As Integer

    Private strSQL As String
    Private dtJurisDates As DataTable
    Private rsMarkDates As New RecordSet

    Friend Sub LoadMarkDates()
        On Error Resume Next
        'open all dates for the trademark
        rsMarkDates.GetFromSQL("Select * from tblTrademarkDates where TrademarkID=" & TrademarkID)
    End Sub

    Friend Sub LoadJurisdictionDates()
        On Error Resume Next
        'the date template for this jurisdiction
        strSQL = "Select * from tblJurisdictionDates where JurisdictionID=" & JurisdictionID
        dtJurisDates = DataStuff.GetDataTable(strSQL)
    End Sub

    Friend Sub EditTrademarkDate(ByVal DateID As Integer, ByVal RecurNumber As Integer, _
        ByVal TrademarkDate As Date, ByVal NoDay As Boolean, ByVal NoMonth As Boolean, _
        ByVal Completed As Boolean, ByVal IsLocked As Boolean, ByVal EmailSent As Boolean, _
        ByVal UpdateRelatives As Boolean, ByVal AddNext As Boolean, ByVal MarkJurisdictionID As Integer)

        On Error Resume Next

        Dim dRow As DataRow, dJurisRow As DataRow
        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)

        If DateExists(DateID, RecurNumber) = True Then
            dRow = rsMarkDates.Table.Select("DateID=" & DateID & " and RecurNumber=" & RecurNumber)(0)
            dRow("TrademarkDate") = IIf(TrademarkDate = Date.MinValue, DBNull.Value, TrademarkDate)
            dRow("NoDay") = NoDay
            dRow("NoMonth") = NoMonth
            dRow("Completed") = Completed
            dRow("IsLocked") = IsLocked
            dRow("EmailSent") = EmailSent
        Else      'would only happen if we're dealing with treaty dates being added to stay linked
            rsMarkDates.AddRow()
            dRow = rsMarkDates.CurrentRow
            dRow("TrademarkID") = TrademarkID
            dRow("TrademarkDate") = IIf(TrademarkDate = Date.MinValue, DBNull.Value, TrademarkDate)
            dRow("JurisdictionID") = MarkJurisdictionID
            dRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
            dRow("DateID") = DateID
            dRow("RecurNumber") = RecurNumber
            dRow("ListOrder") = dJurisRow("ListOrder") + 1000
            dRow("NoDay") = NoDay
            dRow("NoMonth") = NoMonth
            dRow("EmailSent") = EmailSent
            dRow("Completed") = Completed
            dRow("IsLocked") = IsLocked
        End If

        If UpdateRelatives = True Then
            UpdateTrademarkDate(DateID, RecurNumber, True)
        End If

        ' add next occurence (new, version 5, check that it recurs at interval)
        If (AddNext = True) And (dJurisRow("RecursAtInterval") = True) _
            And (Nz(dJurisRow("RecurIntervalNumber"), 0) <> 0) Then

            RecurNumber = RecurNumber + 1
            If DateExists(DateID, RecurNumber) = False Then
                Dim IntervalNumber As Integer, IntervalType As Integer, IntervalAdjust As Integer
                ' get recur values for this date from the jurisdiction dates
                IntervalNumber = Nz(dJurisRow("RecurIntervalNumber"), 0)
                IntervalType = Nz(dJurisRow("RecurIntervalType"), 0)
                IntervalAdjust = Nz(dJurisRow("RecurAdjust"), 0)

                If (IsDate(TrademarkDate)) And (TrademarkDate <> Date.MinValue) Then
                    TrademarkDate = RecalcDate(TrademarkDate, IntervalNumber, IntervalType, IntervalAdjust)
                End If

                rsMarkDates.AddRow()
                dRow = rsMarkDates.CurrentRow
                dRow("TrademarkID") = TrademarkID
                dRow("TrademarkDate") = IIf(TrademarkDate = Date.MinValue, DBNull.Value, TrademarkDate)
                dRow("JurisdictionID") = JurisdictionID
                dRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
                dRow("DateID") = DateID
                dRow("RecurNumber") = RecurNumber
                dRow("ListOrder") = dJurisRow("ListOrder") + 1000
                dRow("NoDay") = False
                dRow("NoMonth") = False
                dRow("EmailSent") = False
                dRow("Completed") = False
                dRow("IsLocked") = False
                UpdateTrademarkDate(DateID, RecurNumber, UpdateRelatives)
            End If
        End If

    End Sub

    Friend Sub UpdateTrademarkDate(ByVal DateID As Integer, ByVal RecurNumber As Integer, _
        ByVal UpdateRelatives As Boolean)

        On Error Resume Next

        Dim dRow As DataRow, FirstRelatives As DataRow(), TrademarkDate As Date, strFilter As String, _
             RelativeDateID As Integer, i As Integer, bAlwaysAdd As Boolean, bDateExists As Boolean


        'pluck out the row for the date in question
        strFilter = "DateID=" & DateID & " and RecurNumber=" & RecurNumber
        dRow = rsMarkDates.Table.Select(strFilter)(0)    'zero gets first row only
        TrademarkDate = dRow("TrademarkDate")

        'get an array of our relative dates
        FirstRelatives = GetRelativeDates(DateID)
        For i = 0 To FirstRelatives.Length - 1
            dRow = FirstRelatives(i)
            RelativeDateID = dRow("DateID")
            bAlwaysAdd = dRow("AlwaysAddRelative")
            bDateExists = DateExists(RelativeDateID, RecurNumber)

            If (bDateExists = False) And (bAlwaysAdd = True) Then
                'once again, the date.MinValue check is required because Microsoft didn't give us the ability
                'to create date variables that contain null or no date ... fucking idiots.
                If IsDate(TrademarkDate) And (TrademarkDate <> Date.MinValue) And (UpdateRelatives = True) Then
                    AddUpdateRelative(RelativeDateID, RecurNumber, TrademarkDate)
                Else
                    AddRelativeNoDate(RelativeDateID, RecurNumber)
                End If

                AddSecondRelatives(RelativeDateID, RecurNumber, UpdateRelatives)
            End If

            If bDateExists = True Then
                If IsDate(TrademarkDate) And (TrademarkDate <> Date.MinValue) And (UpdateRelatives = True) Then
                    UpdateRelative(RelativeDateID, RecurNumber, TrademarkDate)
                End If
                AddSecondRelatives(RelativeDateID, RecurNumber, UpdateRelatives)
            End If
        Next i

    End Sub

    Private Sub AddSecondRelatives(ByVal DateID As Integer, ByVal RecurNumber As Integer, _
        ByVal UpdateRelatives As Boolean)
        On Error Resume Next

        Dim dRow As DataRow, SecondRelatives As DataRow(), TrademarkDate As Date, bAlwaysAdd As Boolean, _
        RelativeDateID As Integer, i As Integer, j As Integer, bDateExists As Boolean, strFilter As String

        ' Look familiar?  It's the same logic as above, but we're dealing with the relatives of the first relatives
        strFilter = "DateID=" & DateID & " and RecurNumber=" & RecurNumber
        dRow = rsMarkDates.Table.Select(strFilter)(0)
        TrademarkDate = dRow("TrademarkDate")

        SecondRelatives = GetRelativeDates(DateID)

        For i = 0 To SecondRelatives.Length - 1
            dRow = SecondRelatives(i)
            RelativeDateID = dRow("DateID")
            bAlwaysAdd = dRow("AlwaysAddRelative")
            bDateExists = DateExists(RelativeDateID, RecurNumber)

            If (bDateExists = False) And (bAlwaysAdd = True) Then
                If (IsDate(TrademarkDate)) And (TrademarkDate <> Date.MinValue) And (UpdateRelatives = True) Then
                    AddUpdateRelative(RelativeDateID, RecurNumber, TrademarkDate)
                Else
                    AddRelativeNoDate(RelativeDateID, RecurNumber)
                End If

            End If

            If (bDateExists = True) And (IsDate(TrademarkDate)) And (TrademarkDate <> Date.MinValue) _
                And (UpdateRelatives = True) Then
                UpdateRelative(RelativeDateID, RecurNumber, TrademarkDate)
            End If
        Next i

    End Sub

    Private Function GetRelativeDates(ByVal DateID As Integer) As DataRow()
        On Error Resume Next
        'returns a collection of datarows from Jurisdiction Dates that are related to the current DateID
        GetRelativeDates = dtJurisDates.Select("OtherDateID=" & DateID)
    End Function

    Friend Function DateExists(ByVal DateID As Integer, ByVal RecurNumber As Integer) As Boolean
        On Error Resume Next
        Dim dRows As DataRow(), strFilter As String

        strFilter = "DateID=" & DateID & " and RecurNumber=" & RecurNumber

        dRows = rsMarkDates.Table.Select(strFilter)
        If dRows.Length = 0 Then
            DateExists = False
        Else
            DateExists = True
        End If

    End Function

    Friend Sub AddDate(ByVal DateID As Integer, ByVal RecurNumber As Integer, ByVal TrademarkDate As Date, _
        ByVal NoDay As Boolean, ByVal NoMonth As Boolean, ByVal Completed As Boolean, ByVal IsLocked As Boolean)

        On Error Resume Next

        'only do this if the date doesn't already exist
        If DateExists(DateID, RecurNumber) Then Exit Sub

        Dim dRow As DataRow, dJurisRow As DataRow

        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)   'zero gets first row ... only row in this case

        rsMarkDates.AddRow()
        dRow = rsMarkDates.CurrentRow

        dRow("TrademarkID") = TrademarkID
        'becuz the fucking idiots at Microsoft didn't think we'd ever want to insert null dates
        dRow("TrademarkDate") = IIf(TrademarkDate = Date.MinValue, DBNull.Value, TrademarkDate)
        dRow("JurisdictionID") = JurisdictionID
        dRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
        dRow("DateID") = DateID
        dRow("RecurNumber") = RecurNumber
        dRow("ListOrder") = dJurisRow("ListOrder") + 1000
        dRow("EmailSent") = False
        dRow("NoDay") = NoDay
        dRow("NoMonth") = NoMonth
        dRow("Completed") = Completed
        dRow("IsLocked") = IsLocked

        If (IsLocked = False) And (Completed = False) Then
            'if date was just added, need to update from parent
            UpdateFromParent(DateID, RecurNumber)
        End If

        UpdateTrademarkDate(DateID, RecurNumber, True)

    End Sub

    Friend Sub AddJurisdictionDate(ByVal JurisdictionDateID As Integer, ByVal TrademarkDate As Date)
        On Error Resume Next
        Dim DateID As Integer, RecurNumber As Integer, dJurisRow As DataRow, dRow As DataRow

        dJurisRow = dtJurisDates.Select("JurisdictionDateID=" & JurisdictionDateID)(0)
        DateID = dJurisRow("DateID")
        RecurNumber = NextRecurNumber(DateID)

        If DateExists(DateID, RecurNumber) Then Exit Sub
        rsMarkDates.AddRow()
        dRow = rsMarkDates.CurrentRow

        dRow("TrademarkID") = TrademarkID
        'becuz the fucking idiots at Microsoft didn't think we'd ever want to insert null dates
        dRow("TrademarkDate") = IIf(TrademarkDate = Date.MinValue, DBNull.Value, TrademarkDate)
        dRow("JurisdictionID") = JurisdictionID
        dRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
        dRow("DateID") = DateID
        dRow("RecurNumber") = RecurNumber
        dRow("ListOrder") = dJurisRow("ListOrder") + 1000
        dRow("NoDay") = False
        dRow("NoMonth") = False
        dRow("EmailSent") = False
        dRow("Completed") = False

        UpdateTrademarkDate(DateID, RecurNumber, True)

    End Sub

    Friend Function NextRecurNumber(ByVal DateID As Integer) As Integer
        On Error Resume Next
        Dim i As Integer, iRecur As Integer, dRow As DataRow

        iRecur = 0
        For i = 0 To rsMarkDates.Table.Rows.Count - 1
            dRow = rsMarkDates.Table.Rows(i)
            If dRow("DateID") = DateID Then
                iRecur = iRecur + 1
            End If
        Next i
        NextRecurNumber = iRecur

    End Function

    Private Sub UpdateFromParent(ByVal DateID As Integer, ByVal RecurNumber As Integer)
        On Error Resume Next
        Dim dJurisRow As DataRow, ParentDateID As Integer, dRow As DataRow, ParentDate As Date

        'jurisdiction date values for THIS date
        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)   'zero gets first row ... only row in this case
        'find parent date
        ParentDateID = dJurisRow("OtherDateID")

        If DateExists(ParentDateID, RecurNumber) = False Then Exit Sub
        'if it does exist, get Parent's date
        dRow = rsMarkDates.Table.Select("DateID=" & ParentDateID & " and RecurNumber=" & RecurNumber)(0)

        If IsDate(dRow("TrademarkDate")) Then
            ParentDate = dRow("TrademarkDate")
            UpdateRelative(DateID, RecurNumber, ParentDate)
        End If

    End Sub

    Private Sub UpdateRelative(ByVal DateID As Integer, ByVal RecurNumber As Integer, ByVal BaseDate As Date)
        On Error Resume Next

        'don't bother if we're talking no date or fake date
        If (IsDate(BaseDate) = False) Or (BaseDate = Date.MinValue) Then
            Exit Sub
        End If

        Dim dRow As DataRow, dJurisRow As DataRow, IntervalNumber As Integer, _
            IntervalType As Integer, IntervalAdjust As Integer

        'updates a trademark date, identified by DateID and RecurNumber, by looking up its 
        'interval values in the jurisdiction dates

        'get values for this date from the jurisdiction dates
        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)   'zero gets first row ... only row in this case
        IntervalNumber = dJurisRow("IntervalNumber")
        IntervalType = dJurisRow("IntervalType")
        IntervalAdjust = dJurisRow("IntervalAdjust")

        dRow = rsMarkDates.Table.Select("DateID=" & DateID & " and RecurNumber=" & RecurNumber)(0)
        If (dRow("Completed") = False) And (dRow("IsLocked") = False) Then
            dRow("TrademarkDate") = RecalcDate(BaseDate, IntervalNumber, IntervalType, IntervalAdjust)
        End If

    End Sub

    Private Sub AddUpdateRelative(ByVal DateID As Integer, ByVal RecurNumber As Integer, ByVal BaseDate As Date)
        On Error Resume Next
        Dim iRow As Integer, dRow As DataRow, dJurisRow As DataRow, IntervalNumber As Integer, _
            IntervalType As Integer, IntervalAdjust As Integer

        'get values for this date from the jurisdiction dates
        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)   'zero gets first row ... only row in this case
        IntervalNumber = dJurisRow("IntervalNumber")
        IntervalType = dJurisRow("IntervalType")
        IntervalAdjust = dJurisRow("IntervalAdjust")

        With rsMarkDates
            .AddRow()
            .CurrentRow("TrademarkID") = TrademarkID
            .CurrentRow("RecurNumber") = RecurNumber
            .CurrentRow("DateID") = dJurisRow("DateID")
            .CurrentRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
            .CurrentRow("JurisdictionID") = dJurisRow("JurisdictionID")
            .CurrentRow("ListOrder") = dJurisRow("ListOrder") + 1000
            .CurrentRow("Completed") = False
            .CurrentRow("NoDay") = False
            .CurrentRow("NoMonth") = False
            .CurrentRow("IsLocked") = False
            .CurrentRow("EmailSent") = False
            If (IsDate(BaseDate)) And (BaseDate <> Date.MinValue) Then
                .CurrentRow("TrademarkDate") = RecalcDate(BaseDate, IntervalNumber, IntervalType, IntervalAdjust)
            Else
                .CurrentRow("TrademarkDate") = DBNull.Value
            End If

        End With

    End Sub

    Private Sub AddRelativeNoDate(ByVal DateID As Integer, ByVal RecurNumber As Integer)
        On Error Resume Next
        Dim iRow As Integer, dRow As DataRow, dJurisRow As DataRow

        'get values for this date from the jurisdiction dates
        dJurisRow = dtJurisDates.Select("DateID=" & DateID)(0)   'zero gets first row ... only row in this case

        With rsMarkDates
            .AddRow()
            .CurrentRow("TrademarkID") = TrademarkID
            .CurrentRow("RecurNumber") = RecurNumber
            .CurrentRow("DateID") = dJurisRow("DateID")
            .CurrentRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
            .CurrentRow("JurisdictionID") = dJurisRow("JurisdictionID")
            .CurrentRow("ListOrder") = dJurisRow("ListOrder") + 1000
            .CurrentRow("Completed") = False
            .CurrentRow("NoDay") = False
            .CurrentRow("NoMonth") = False
            .CurrentRow("IsLocked") = False
            .CurrentRow("EmailSent") = False
            .CurrentRow("TrademarkDate") = DBNull.Value
        End With

    End Sub

    Private Function RecalcDate(ByVal BaseDate As Date, ByVal IntervalNumber As Integer, _
       ByVal IntervalType As Integer, ByVal IntervalAdjust As Integer) As Date

        On Error Resume Next
        Dim NewDate As Date

        Select Case IntervalType
            Case 1  'days before
                NewDate = DateAdd("d", -IntervalNumber, BaseDate)

            Case 2  'months before
                NewDate = DateAdd("m", -IntervalNumber, BaseDate)

            Case 3  'years before
                NewDate = DateAdd("yyyy", -IntervalNumber, BaseDate)

            Case 4  'days after
                NewDate = DateAdd("d", IntervalNumber, BaseDate)

            Case 5  'months after
                NewDate = DateAdd("m", IntervalNumber, BaseDate)

            Case 6  'years after
                NewDate = DateAdd("yyyy", IntervalNumber, BaseDate)
        End Select

        ' adjust date according to template
        Select Case IntervalAdjust
            Case 0
                NewDate = NewDate
                'subtract one day
            Case 1
                NewDate = DateAdd("d", -1, NewDate)
                'end of current month; subtract to first of current month, move forward a month, subtract a day
            Case 2
                NewDate = DateAdd("d", -1, DateAdd("m", 1, (DateAdd("d", -(NewDate.Day - 1), NewDate))))
                'beginning of current month
            Case 3
                NewDate = DateAdd("d", -(NewDate.Day - 1), NewDate)
                'end of previous month (subtract number of days)
            Case 4
                NewDate = DateAdd("d", -NewDate.Day, NewDate)
                'beginning of next month
            Case 5
                NewDate = DateAdd("m", 1, (DateAdd("d", -(NewDate.Day - 1), NewDate)))
                ' plus one day ... freakin' germans
            Case 6
                NewDate = DateAdd("d", 1, NewDate)
        End Select

        RecalcDate = NewDate

    End Function

    Friend Sub ReOrderTrademarkDates()
        On Error Resume Next
        Dim dRows As DataRow(), dRow As DataRow, i As Integer

        dRows = rsMarkDates.Table.Select("", "ListOrder,TrademarkDateID")
        For i = 0 To dRows.Length - 1
            dRow = dRows(i)
            dRow("ListOrder") = i + 1
        Next i

    End Sub

    Friend Sub UpdateRecurNumbers()
        On Error Resume Next
        Dim dRows As DataRow(), dRow As DataRow, DateID As Integer, i As Integer, iRecur As Integer, j As Integer

        dRows = rsMarkDates.Table.Select("", "TrademarkDate, ListOrder")

        For i = 0 To dRows.Length - 1
            dRow = dRows(i)
            iRecur = 0
            DateID = dRow("DateID")
            'loop back through table and find earlier dates; start at one becuz earliest date is always Recur = 0
            For j = 1 To (i - 1)
                dRow = dRows(j)
                If dRow("DateID") = DateID Then iRecur = iRecur + 1
            Next
            'reset row to first loop
            dRow = dRows(i)
            dRow("RecurNumber") = iRecur
        Next i

    End Sub

    Public Sub AppendFilingBasisDates(ByVal FilingBasisID As Integer)
        On Error Resume Next
        'don't bother if not enough info
        If (Nz(FilingBasisID, 0) = 0) Or (Nz(JurisdictionID, 0) = 0) Then Exit Sub

        Dim dRows As DataRow(), dRow As DataRow, strFilter As String, i As Integer, DateID As Integer

        ' in jurisdiction template, -1 means ALL Filing Bases
        strFilter = "FilingBasisID in (-1," & FilingBasisID & ")"
        dRows = dtJurisDates.Select(strFilter)

        For i = 0 To dRows.Length - 1
            dRow = dRows(i)
            DateID = dRow("DateID")
            If DateExists(DateID, 0) = False Then
                'we have to use date.MinValue because the asswipes at Microsoft didn't think
                'we'd ever need to send a null date value to the database.
                AddDate(DateID, 0, Date.MinValue, False, False, False, False)
            End If
        Next i

    End Sub

    Public Sub AppendStatusDates(ByVal StatusID As Integer)
        On Error Resume Next
        'don't bother if not enough info
        If (Nz(StatusID, 0) = 0) Or (Nz(JurisdictionID, 0) = 0) Then Exit Sub

        Dim dRows As DataRow(), dRow As DataRow, strFilter As String, i As Integer, DateID As Integer

        ' in jurisdiction template, -1 means ALL Filing Bases
        strFilter = "StatusID in (-1," & StatusID & ")"
        dRows = dtJurisDates.Select(strFilter)

        For i = 0 To dRows.Length - 1
            dRow = dRows(i)
            DateID = dRow("DateID")
            If DateExists(DateID, 0) = False Then
                AddDate(DateID, 0, Date.MinValue, False, False, False, False)
            End If
        Next i

    End Sub

    Friend Sub ChangeJurisdiction()
        On Error Resume Next
        Dim dMarkRow As DataRow, dJurisRow As DataRow, dJurisRows As DataRow(), DateID As Integer, i As Integer
        'when user changes jurisdictions, we keep dates that are in the template for the new jurisdiction,
        'but delete the others

        For i = 0 To rsMarkDates.Table.Rows.Count - 1
            dMarkRow = rsMarkDates.Table.Rows(i)
            DateID = dMarkRow("DateID")
            dJurisRows = dtJurisDates.Select("DateID=" & DateID)
            If dJurisRows.Length = 0 Then   'no matching date for new jurisdiction, delete
                dMarkRow.Delete()
            Else
                dJurisRow = dJurisRows(0)
                dMarkRow("JurisdictionDateID") = dJurisRow("JurisdictionDateID")
                dMarkRow("JurisdictionID") = dJurisRow("JurisdictionID")
            End If
        Next i

    End Sub

    Friend Sub DeleteDate(ByVal TrademarkDateID As Integer)
        On Error Resume Next
        Dim dRow As DataRow
        dRow = rsMarkDates.Table.Select("TrademarkDateID=" & TrademarkDateID)(0)
        dRow.Delete()
        UpdateRecurNumbers()
        ReOrderTrademarkDates()
    End Sub

    Friend Sub SaveChanges()
        On Error Resume Next
        'for when we're all done
        rsMarkDates.Update()
    End Sub

    Friend Sub BatchUpdate(ByVal iJurisdictionID As Integer, ByVal iDateID As Integer)
        On Error Resume Next
        Dim drReader As OleDb.OleDbDataReader, iTrademarkID As Integer, iRecurNumber As Integer, _
            dJurisRow As DataRow, ParentDateID As Integer, dRow As DataRow, ParentDate As Date

        Me.JurisdictionID = iJurisdictionID
        Me.LoadJurisdictionDates()

        'jurisdiction date values for THIS date
        dJurisRow = dtJurisDates.Select("DateID=" & iDateID)(0)   'zero gets first row ... only row in this case
        'find parent date ... we really want to back up the parent and run the update on that one so we
        'also get any relatives of relatives updated
        ParentDateID = dJurisRow("OtherDateID")

        drReader = DataStuff.GetDataReader("Select * from tblTrademarkDates where JurisdictionID=" & _
            iJurisdictionID & " and Completed = 0 and DateID=" & iDateID)
        If drReader.HasRows = False Then Exit Sub
        While drReader.Read
            iTrademarkID = drReader("TrademarkID")
            iRecurNumber = drReader("RecurNumber")
            Me.TrademarkID = iTrademarkID
            LoadMarkDates()
            UpdateTrademarkDate(ParentDateID, iRecurNumber, True)
            SaveChanges()
        End While
        drReader = Nothing

    End Sub

End Class
