Module AllForms

    Friend frmTrademarks As frmTrademarks
    Friend frmPatents As frmPatents
    Friend frmCompanies As frmCompanies
    Friend frmLogin As frmLogin
    Friend frmPreferences As frmPreferences
    Friend frmMergeHelper As frmMergeHelper
    Friend frmAddTrademarkDates As frmAddTrademarkDates
    Friend frmAddPatentDates As frmAddPatentDates
    Friend frmEditTrademarkDate As frmEditTrademarkDate
    Friend frmEditPatentDate As frmEditPatentDate
    Friend frmReportPreview As frmReportPreview
    Friend frmBrowser As frmBrowser
    Friend frmContact As frmContact
    Friend frmContactFromOutlook As frmContactFromOutlook
    Friend frmReports As frmReports
    Friend frmOppositions As frmOppositions
    Friend frmOppositionStatus As frmOppositionStatus

    Friend Sub OpenTrademarks()
        On Error Resume Next
        If frmTrademarks Is Nothing Then
            frmTrademarks = New frmTrademarks
        End If
        frmTrademarks.Show()
        frmTrademarks.Activate()
    End Sub

    Friend Sub OpenPatents()
        On Error Resume Next
        If frmPatents Is Nothing Then
            frmPatents = New frmPatents
        End If
        frmPatents.Show()
        frmPatents.Activate()
    End Sub

    Friend Sub OpenContact()
        On Error Resume Next
        If frmContact Is Nothing Then
            frmContact = New frmContact
        End If
        frmContact.Show()
    End Sub

    Friend Sub OpenContactFromOutlook()
        On Error Resume Next
        If frmContactFromOutlook Is Nothing Then
            frmContactFromOutlook = New frmContactFromOutlook
        End If
        frmContactFromOutlook.Show()
    End Sub

    Friend Sub OpenCompanies()
        On Error Resume Next
        If frmCompanies Is Nothing Then
            frmCompanies = New frmCompanies
        End If
        frmCompanies.Show()
        frmCompanies.Activate()
    End Sub

    Friend Sub OpenLogin()
        On Error Resume Next
        If frmLogin Is Nothing Then
            frmLogin = New frmLogin
        End If
        frmLogin.Show()
    End Sub

    Friend Sub OpenReport()
        On Error Resume Next
        If frmReportPreview Is Nothing Then
            frmReportPreview = New frmReportPreview
        End If
        frmReportPreview.Show()
        frmReportPreview.Activate()
    End Sub

    Friend Sub OpenPreferences()
        On Error Resume Next
        If frmPreferences Is Nothing Then
            frmPreferences = New frmPreferences
        End If
        frmPreferences.Show()
        frmPreferences.Activate()
    End Sub

    Friend Sub OpenMergeHelper()
        On Error Resume Next
        If frmMergeHelper Is Nothing Then
            frmMergeHelper = New frmMergeHelper
        End If
        frmMergeHelper.Show()
        frmMergeHelper.Activate()
    End Sub

    Friend Sub OpenAddTrademarkDates()
        On Error Resume Next
        If frmAddTrademarkDates Is Nothing Then
            frmAddTrademarkDates = New frmAddTrademarkDates
        End If
        frmAddTrademarkDates.Show()
    End Sub

    Friend Sub OpenAddPatentDates()
        On Error Resume Next
        If frmAddPatentDates Is Nothing Then
            frmAddPatentDates = New frmAddPatentDates
        End If
        frmAddPatentDates.Show()
    End Sub

    Friend Sub OpenEditTrademarkDate()
        On Error Resume Next
        If frmEditTrademarkDate Is Nothing Then
            frmEditTrademarkDate = New frmEditTrademarkDate
        End If
        frmEditTrademarkDate.Show()
    End Sub

    Friend Sub OpenEditPatentDate()
        On Error Resume Next
        If frmEditPatentDate Is Nothing Then
            frmEditPatentDate = New frmEditPatentDate
        End If
        frmEditPatentDate.Show()
    End Sub

    Friend Sub OpenBrowser()
        On Error Resume Next
        If frmBrowser Is Nothing Then
            frmBrowser = New frmBrowser
        End If
        frmBrowser.Show()
        frmBrowser.Activate()
    End Sub

    Friend Sub OpenReports()
        On Error Resume Next
        If frmReports Is Nothing Then
            AllForms.frmReports = New frmReports
            AllForms.frmReports.Show()
            AllForms.frmReports.Activate()
        End If
    End Sub

    Friend Sub OpenOppositions()
        On Error Resume Next
        If frmOppositions Is Nothing Then
            frmOppositions = New frmOppositions
        End If
        frmOppositions.Show()
        frmOppositions.Activate()
    End Sub

    Friend Sub OpenOppositionStatus()
        On Error Resume Next
        If frmOppositionStatus Is Nothing Then
            frmOppositionStatus = New frmOppositionStatus
        End If
        frmOppositionStatus.Show()
    End Sub

End Module
