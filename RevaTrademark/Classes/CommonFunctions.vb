Module CommonFunctions

    Public Function Nz(ByVal Value As Object, ByVal ValueIfNull As Object) As Object
        On Error Resume Next
        If Value Is DBNull.Value Then
            Nz = ValueIfNull
        Else
            Nz = Value
        End If
    End Function

    Public Function FixDate(ByVal strDate As String) As String
        On Error Resume Next
        'fucking Access requires a pound sign instead of a quote for dates
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            FixDate = "#" & Format(DateValue(strDate), "MM-dd-yyyy") & "#"
        Else
            FixDate = "'" & Format(DateValue(strDate), "MM-dd-yyyy") & "'"
        End If
    End Function

    Public Function GetFilter(ByVal strField As String, ByVal strValue As String) As String
        On Error Resume Next
        ' Access and SQL have different ways of solving the quote issue
        If My.Settings.CurrentConnection = My.Settings.DemoConnection Then
            GetFilter = strField & "=" & Chr(34) & strValue & Chr(34)
        Else
            GetFilter = "Replace(" & strField & ",char(39),'')= '" & Replace(strValue, "'", "") & "'"
        End If

    End Function

    Public Function NumbersOnly(ByVal strString) As String
        On Error Resume Next
        Dim i As Integer, StrNumbers As String
        StrNumbers = strString
        For i = 1 To Len(StrNumbers)
            If Not IsNumeric(Mid(StrNumbers, i, 1)) Then
                StrNumbers = Replace(StrNumbers, Mid(StrNumbers, i, 1), "")
            End If
        Next i
        StrNumbers = Replace(StrNumbers, ",", "")
        StrNumbers = Replace(StrNumbers, "-", "")
        StrNumbers = Replace(StrNumbers, "\", "")
        StrNumbers = Replace(StrNumbers, "/", "")
        NumbersOnly = StrNumbers

    End Function

    Public Function PointsToInches(ByVal Points As Integer) As Single
        On Error Resume Next
        Return (Points * (1 / 72))
    End Function

    Public Function InchesToPoints(ByVal Inches As Single) As Integer
        On Error Resume Next
        Return Int(Inches * 72)
    End Function

    Public Sub Tutorial(ByVal strTutorial As String)
        On Error Resume Next
        Dim YouTubeURL As String = ""
        Select Case strTutorial
            '01
            Case "WhatsNew"
                YouTubeURL = "http://youtu.be/zurBmJnmko4"
                '02
            Case "Overview"
                YouTubeURL = "http://youtu.be/E4qCMLPcQc0"
                '03
            Case "Preferences"
                YouTubeURL = "http://youtu.be/NTES1o7vmqI"
                '04
            Case "SortFind"
                YouTubeURL = "http://youtu.be/13yy1Md42Bs"
                '05
            Case "CompaniesNew"
                YouTubeURL = "http://youtu.be/WO4YnaUiGVU"
                '06
            Case "LinkCompanies"
                YouTubeURL = "http://youtu.be/5mx-pBOl1P0"
                '07
            Case "Contacts"
                YouTubeURL = "http://youtu.be/qqBu3ZWAgZY"
                '08
            Case "ImportContacts"
                YouTubeURL = "http://youtu.be/z8PGuK2-Eio"
                '09
            Case "NewMarksPatents"
                YouTubeURL = "http://youtu.be/qxGyxJEnoLw"
                '10
            Case "MultipleContacts"
                YouTubeURL = "http://youtu.be/aeBF5pzQw78"
                '11
            Case "WebLinks"
                YouTubeURL = "http://youtu.be/nFBAggI-SJE"
                '12
            Case "DateBasics"
                YouTubeURL = "http://youtu.be/FT9nn6Eb-Vc"
                '13
            Case "MarkDateOptions"
                YouTubeURL = "http://youtu.be/v5_oukdj9iw"
                '14
            Case "PatentDateOptions"
                YouTubeURL = "http://youtu.be/j_C4jxwXGEc"
                '15
            Case "AlertsView"
                YouTubeURL = "http://youtu.be/IuCJTOVAIwI"
                '16
            Case "Merges"
                YouTubeURL = "http://youtu.be/1KaOJxDyAqc"
                '17
            Case "EmailAlerts"
                YouTubeURL = "http://youtu.be/ZVbOuEYtkAg"
                '18
            Case "DateSpecific"
                YouTubeURL = "http://youtu.be/TWfS9OxNKFg"
                '19
            Case "EmailText"
                YouTubeURL = "http://youtu.be/11GB_aQ7XUg"
                '20
            Case "MarkTreatyFilings"
                YouTubeURL = "http://youtu.be/mOxSvXTRL7Y"
                '21
            Case "MarkStatusCheck"
                YouTubeURL = "http://youtu.be/IqkTJvlAnjI"
                '22
            Case "PatentTreatyFilings"
                YouTubeURL = "http://youtu.be/HxvzqiYhJFk"
                '23
            Case "LinkedPatents"
                YouTubeURL = "http://youtu.be/b8Gjt7rq2Po"
                '24
            Case "Reports"
                YouTubeURL = "http://youtu.be/Xzg4aX-UqN8"
                '25
            Case "CustomSpreadsheets"
                YouTubeURL = "http://youtu.be/xdMYEvHy6zI"
                '26
            Case "Oppositions"
                YouTubeURL = "http://youtu.be/564N4wGFtFg"
            Case Else

        End Select
        System.Diagnostics.Process.Start(YouTubeURL)
    End Sub

    Public Sub ShowTable(ByVal dtTable As DataTable)
        Dim f As New frmTestViewTable(dtTable)
        f.Show()
    End Sub

End Module
