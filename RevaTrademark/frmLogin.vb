Imports System.Data.SqlClient

Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AllForms.frmLogin = Me

            Dim strLicense As String
            strLicense = RevaSettings.LicenseKey & ""

            Select Case strLicense
                Case "DemoVersion"
                    Globals.PurchaseLevel = 0

                Case "MJ239397"
                    Globals.PurchaseLevel = 1

                Case "SD110603"
                    Globals.PurchaseLevel = 2

                Case "CS101672"
                    Globals.PurchaseLevel = 3

                Case "TD111458"
                    Globals.PurchaseLevel = 4

                Case "RE082834"
                    Globals.PurchaseLevel = 5

                Case "ServerDemo"
                    Globals.PurchaseLevel = 6

            End Select

            With Me
                If Globals.PurchaseLevel = 0 Then  'demo version
                    .optDemo.Checked = True
                    .optSQL.Checked = False
                    .optSQL.Enabled = False
                Else  'default to SQL login for purchased version
                    .optDemo.Checked = False
                    .optSQL.Enabled = True
                    .optSQL.Checked = True
                End If

                SetSecurityOptions()
            End With

            If System.Diagnostics.Debugger.IsAttached Then
                btnSQLDev.Visible = True
                btnHookDev.Visible = True
                btnTest.Visible = True
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmLogin = Nothing
    End Sub

    Private Sub optDemo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDemo.CheckedChanged
        SetSecurityOptions()
    End Sub

    Private Sub optSQL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSQL.CheckedChanged
        SetSecurityOptions()
    End Sub

    Private Sub optIntegrated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIntegrated.CheckedChanged
        On Error Resume Next
        If Me.optIntegrated.Checked = True Then
            RevaSettings.SecurityType = 1
            SetSecurityOptions()
        End If
    End Sub

    Private Sub optSpecific_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSpecific.CheckedChanged
        On Error Resume Next
        If Me.optSpecific.Checked = True Then
            RevaSettings.SecurityType = 2
            SetSecurityOptions()
        End If
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        On Error Resume Next
        If IsConnection() = True Then
            MsgBox("Connection Succeeded.")
        Else
            MsgBox("Unable to connect to the database.  Please check the Server Name, Database Name and Login Information.")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub SetSecurityOptions()
        Try
            With Me
                If .optDemo.Checked = True Then
                    .Server.Text = ""
                    .Database.Text = ""
                    .UserID.Text = ""
                    .Password.Text = ""
                    .Server.Enabled = False
                    .Database.Enabled = False
                    .UserID.Enabled = False
                    .Password.Enabled = False
                    .optIntegrated.Enabled = False
                    .optSpecific.Enabled = False
                    .chkSavePassword.Enabled = False
                    .grpSecurityType.Enabled = False
                Else
                    .optIntegrated.Checked = RevaSettings.SecurityType = 1
                    .optSpecific.Checked = RevaSettings.SecurityType = 2
                    .Server.Enabled = True
                    .Database.Enabled = True
                    .UserID.Enabled = True
                    .Password.Enabled = True
                    .optIntegrated.Enabled = True
                    .optSpecific.Enabled = True
                    .chkSavePassword.Enabled = .optSpecific.Checked
                    .UserID.Enabled = .optSpecific.Checked
                    .Password.Enabled = .optSpecific.Checked
                    .grpSecurityType.Enabled = True
                    .optSQL.Checked = True

                    If .Server.Text & "" = "" Then
                        .Server.Text = RevaSettings.ServerName & ""
                    End If

                    If .Database.Text & "" = "" Then
                        .Database.Text = RevaSettings.DatabaseName & ""
                    End If

                    If .UserID.Text & "" = "" Then
                        .UserID.Text = RevaSettings.UserName & ""
                    End If

                    If RevaSettings.SavePassword = True Then
                        .Password.Text = RevaSettings.Password
                    End If

                    .chkSavePassword.Checked = (RevaSettings.SavePassword = True)

                End If

            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        Try
            If IsConnection() = True Then
                Me.Cursor = Cursors.WaitCursor
                Dim strLogin As String
                'save settings for next time

                With Me
                    If .optDemo.Checked = True Then
                        strLogin = RevaSettings.DemoConnection
                        SetDemoFolders()
                    Else
                        RevaSettings.DatabaseName = .Database.Text
                        RevaSettings.ServerName = .Server.Text
                        RevaSettings.UserName = .UserID.Text
                        RevaSettings.Password = .Password.Text
                        RevaSettings.SavePassword = .chkSavePassword.Checked

                        strLogin = "Data Source=" & .Server.Text & ";"
                        strLogin = strLogin & "Initial Catalog=" & .Database.Text & ";"

                        If .optIntegrated.Checked = True Then
                            strLogin = strLogin & "Integrated Security=SSPI"
                        Else
                            strLogin = strLogin & "User ID=" & .UserID.Text & ";Password=" & .Password.Text
                        End If

                    End If
                End With

                RevaSettings.SQLConnection = strLogin
                RevaSettings.CurrentConnection = strLogin
                RevaData.ConnectionString = strLogin

                If Not (AllForms.frmTrademarks Is Nothing) Then
                    AllForms.frmTrademarks.Close()
                End If

                If Not (AllForms.frmPatents Is Nothing) Then
                    AllForms.frmPatents.Close()
                End If

                If Not (AllForms.frmReports Is Nothing) Then
                    AllForms.frmReports.Close()
                End If

                If Not (AllForms.frmCompanies Is Nothing) Then
                    AllForms.frmCompanies.Close()
                End If

                If Not (AllForms.frmPreferences Is Nothing) Then
                    AllForms.frmPreferences.Close()
                End If

                If Not (AllForms.frmReportPreview Is Nothing) Then
                    AllForms.frmReportPreview.Close()
                End If

                If Not (AllForms.frmOppositions Is Nothing) Then
                    AllForms.frmOppositions.Close()
                End If

                SetSecurity()
                FillDomainTables()

                If RevaSettings.OpenOnMarks = True Then
                    AllForms.OpenTrademarks()
                Else
                    AllForms.OpenPatents()
                End If

                Me.Cursor = Cursors.Default
                Me.Close()
            Else
                MsgBox("Unable to connect to the database.  Please check the Server Name, Database Name and Login Information.")
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function IsConnection() As Boolean
        Try
            With Me
                If .optDemo.Checked = True Then
                    RevaData.ConnectionString = My.Settings.DemoConnection
                    Return RevaData.TestDemoConnection
                End If

                If .optDemo.Checked = False Then

                    Dim strLogin As String = String.Empty, Cnn As New SqlConnection

                    strLogin = "Data Source=" & .Server.Text & ";"
                    strLogin = strLogin & "Initial Catalog=" & .Database.Text & ";"

                    If .optIntegrated.Checked = True Then
                        strLogin = strLogin & "Integrated Security=SSPI"
                    Else
                        strLogin = strLogin & "User ID=" & .UserID.Text & ";Password=" & .Password.Text
                    End If

                    Cnn.ConnectionString = strLogin
                    Cnn.Open()

                    If Cnn.State = ConnectionState.Open Then
                        Return True
                    Else
                        Return False
                    End If

                End If

            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub SetDemoFolders()
        Try
            Dim strPath As String
            strPath = Application.StartupPath & "\"
            strPath = Replace(strPath, "\\", "\")

            If RevaSettings.TrademarkDocumentsDemo & "" = "" Then
                RevaSettings.TrademarkDocumentsDemo = strPath & "Documents"
            End If

            If RevaSettings.PatentDocumentsDemo & "" = "" Then
                RevaSettings.PatentDocumentsDemo = strPath & "Documents"
            End If

            If RevaSettings.TrademarkGraphicsDemo & "" = "" Then
                RevaSettings.TrademarkGraphicsDemo = strPath & "Graphics"
            End If

            If RevaSettings.PatentGraphicsDemo & "" = "" Then
                RevaSettings.PatentGraphicsDemo = strPath & "Graphics"
            End If

            If RevaSettings.ReportIconDemo & "" = "" Then
                RevaSettings.ReportIconDemo = strPath & "Graphics\RevaLogo.bmp"
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub SetSecurity()
        Try
            If Me.optDemo.Checked = True Then
                Globals.SecurityLevel = 1
            End If

            If Me.optSQL.Checked = True Then

                Dim strUser As String

                If optIntegrated.Checked = True Then
                    strUser = Environment.UserDomainName & "\" & Environment.UserName
                Else
                    strUser = Environment.UserName
                End If

                Globals.SecurityLevel = RevaData.RunSPWithResult("prd_recSecurityLevel", "@UserName", strUser)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub FillDomainTables()
        Try
            RevaData.FillTrademarkJurisdictions()
            RevaData.FillPatentJurisdictions()
            RevaData.FillCompaniesList()
            RevaData.FillContactsList()
            RevaData.FillTrademarkFilingBasis()
            RevaData.FillPatentFilingBasis()
            RevaData.FillTrademarkStatus()
            RevaData.FillPatentStatus()
            RevaData.FillTrademarkTypes()
            RevaData.FillPatentTypes()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnHookDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHookDev.Click
        Try
            Dim strLogin As String
            strLogin = "data source = 'RevaTrademark.vdb5'"

            RevaSettings.CurrentConnection = strLogin
            RevaData.ConnectionString = strLogin

            If Not (AllForms.frmTrademarks Is Nothing) Then
                AllForms.frmTrademarks.Close()
            End If

            If Not (AllForms.frmPatents Is Nothing) Then
                AllForms.frmPatents.Close()
            End If

            If Not (AllForms.frmReports Is Nothing) Then
                AllForms.frmReports.Close()
            End If

            If Not (AllForms.frmCompanies Is Nothing) Then
                AllForms.frmCompanies.Close()
            End If

            If Not (AllForms.frmPreferences Is Nothing) Then
                AllForms.frmPreferences.Close()
            End If

            If Not (AllForms.frmReportPreview Is Nothing) Then
                AllForms.frmReportPreview.Close()
            End If

            If Not (AllForms.frmOppositions Is Nothing) Then
                AllForms.frmOppositions.Close()
            End If


            SetSecurity()

            If RevaSettings.OpenOnMarks = True Then
                AllForms.OpenTrademarks()
            Else
                AllForms.OpenPatents()
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSQLDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSQLDev.Click
        Try
            Dim strLogin As String, strUser As String
            strLogin = "Data Source=THOMASNAUGH5871\SQLEXPRESS;Initial Catalog=RevaTrademarkDev7;User ID=tommy;Password=fatdog999"

            RevaSettings.CurrentConnection = strLogin
            RevaData.ConnectionString = strLogin

            If Not (AllForms.frmTrademarks Is Nothing) Then
                AllForms.frmTrademarks.Close()
            End If

            If Not (AllForms.frmPatents Is Nothing) Then
                AllForms.frmPatents.Close()
            End If

            If Not (AllForms.frmReports Is Nothing) Then
                AllForms.frmReports.Close()
            End If

            If Not (AllForms.frmCompanies Is Nothing) Then
                AllForms.frmCompanies.Close()
            End If

            If Not (AllForms.frmPreferences Is Nothing) Then
                AllForms.frmPreferences.Close()
            End If

            If Not (AllForms.frmReportPreview Is Nothing) Then
                AllForms.frmReportPreview.Close()
            End If

            If Not (AllForms.frmOppositions Is Nothing) Then
                AllForms.frmOppositions.Close()
            End If

            SetSecurity()
            strUser = "RevaTest"
            Globals.SecurityLevel = RevaData.DMin("SecurityLevel", "qvwRoleMembers", "UserName='" & strUser & "'")
            Globals.SecurityLevel = 1
            Globals.PurchaseLevel = 5

            If RevaSettings.OpenOnMarks = True Then
                AllForms.OpenTrademarks()
            Else
                AllForms.OpenPatents()
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click


    End Sub

End Class