Imports System.Data.SqlClient
Imports System.Configuration


Public Class frmLogin

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmLogin = Nothing
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
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
                Dim strConnection As String
                strConnection = My.Settings.DemoConnection
                SaveCurrentConnection(strConnection)
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

    End Sub

    Private Sub SetSecurityOptions()
        On Error Resume Next
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

    Private Function IsConnection() As Boolean
        On Error Resume Next
        Dim strLogin As String, Cnn As New SqlConnection

        With Me
            If .optDemo.Checked = True Then
                Return True
            Else
                strLogin = "Provider=SQLOLEDB.1;Data Source=" & .Server.Text & ";"
                strLogin = strLogin & "Initial Catalog=" & .Database.Text & ";"
                If .optIntegrated.Checked = True Then
                    strLogin = strLogin & "Integrated Security=SSPI"
                Else
                    strLogin = strLogin & "User ID=" & .UserID.Text & ";Password=" & .Password.Text
                End If
            End If
        End With

        Cnn.ConnectionString = strLogin
        Cnn.Open()

        If Cnn.State = ConnectionState.Open Then
            Return True
        Else
            Return False
        End If

    End Function

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

    Private Sub SetDemoFolders()
        On Error Resume Next
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

    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        On Error Resume Next
        If IsConnection() = True Then
            Dim strLogin As String
            'save settings for next time

            With Me
                If .optDemo.Checked = True Then
                    strLogin = My.Settings.DemoConnection
                    SetDemoFolders()
                Else
                    RevaSettings.DatabaseName = .Database.Text
                    RevaSettings.ServerName = .Server.Text
                    RevaSettings.UserName = .UserID.Text
                    RevaSettings.Password = .Password.Text
                    RevaSettings.SavePassword = .chkSavePassword.Checked
                    strLogin = "Provider=SQLOLEDB.1;Data Source=" & .Server.Text & ";"
                    strLogin = strLogin & "Initial Catalog=" & .Database.Text & ";"
                    If .optIntegrated.Checked = True Then
                        strLogin = strLogin & "Integrated Security=SSPI"
                    Else
                        strLogin = strLogin & "User ID=" & .UserID.Text & ";Password=" & .Password.Text
                    End If
                    SaveSQLConnection(strLogin)
                End If
            End With

            SaveCurrentConnection(strLogin)
            RevaData.ConnectionString = My.Settings.CurrentConnection


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
        Else
            MsgBox("Unable to connect to the database.  Please check the Server Name, Database Name and Login Information.")
        End If
    End Sub

    Private Sub SaveCurrentConnection(ByVal strConnection As String)
        On Error Resume Next
        'not sure why this works; got it off the internet.
        Dim Config As Configuration
        Dim Section As ConnectionStringsSection
        Dim Setting As ConnectionStringSettings
        Dim ConnectionFullName As String

        ConnectionFullName = String.Format("{0}.My.MySettings.{1}", System.Reflection.Assembly.GetExecutingAssembly.GetName.Name, "CurrentConnection")

        Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Section = CType(Config.GetSection("connectionStrings"), ConnectionStringsSection)
        Setting = Section.ConnectionStrings(ConnectionFullName)
        Setting.ConnectionString = strConnection
        Config.Save(ConfigurationSaveMode.Full, False)
        My.MySettings.Default.Item("CurrentConnection") = strConnection


    End Sub

    Private Sub SaveSQLConnection(ByVal strConnection As String)
        On Error Resume Next
        'not sure why this works; got it off the internet.
        Dim Config As Configuration
        Dim Section As ConnectionStringsSection
        Dim Setting As ConnectionStringSettings
        Dim ConnectionFullName As String

        ConnectionFullName = String.Format("{0}.My.MySettings.{1}", System.Reflection.Assembly.GetExecutingAssembly.GetName.Name, "SQLConnection")

        Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Section = CType(Config.GetSection("connectionStrings"), ConnectionStringsSection)
        Setting = Section.ConnectionStrings(ConnectionFullName)
        Setting.ConnectionString = strConnection
        Config.Save(ConfigurationSaveMode.Full, True)
        My.MySettings.Default.Item("SQLConnection") = strConnection


    End Sub

    Private Sub optDemo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDemo.CheckedChanged
        On Error Resume Next
        SetSecurityOptions()
    End Sub

    Private Sub optSQL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSQL.CheckedChanged
        On Error Resume Next
        SetSecurityOptions()
    End Sub

    Private Sub SetSecurity()
        On Error Resume Next
        If Me.optDemo.Checked = True Then
            Globals.SecurityLevel = 1
        Else
            Dim strUser As String, strUser2005 As String

            If Me.optIntegrated.Checked = True Then
                'becuz the fucking geniuses at Microsoft decided to fuck up how we identify users in SQL 2005 ...
                'for that fucking piece of shit, we now include the domain name in sysusers.name
                strUser = Environment.UserName
                strUser2005 = Environment.UserDomainName & "\" & Environment.UserName

                If DataStuff.DCount("UserName", "qvwRoleMembers", "UserName='" & strUser & "'") > 0 Then
                    Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers",
                        "UserName='" & strUser & "'")
                Else
                    Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers",
                    "UserName='" & strUser2005 & "'")
                End If
            Else
                strUser = Me.UserID.Text
                Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers", "UserName='" & strUser & "'")
            End If
        End If

        'DON'T FORGET TO DELETE THIS LATER
        'Globals.SecurityLevel = 1
    End Sub


    Private Sub HookToDeveloperDB()
        On Error Resume Next
        Dim strLogin As String
        strLogin = "data source = 'RevaTrademark.vdb5'"

        SaveCurrentConnection(strLogin)


        AllForms.frmTrademarks.Close()
        AllForms.frmPatents.Close()
        AllForms.frmReports.Close()
        AllForms.frmCompanies.Close()
        AllForms.frmPreferences.Close()
        AllForms.frmReportPreview.Close()

        SetSecurity()

        If RevaSettings.OpenOnMarks = True Then
            AllForms.OpenTrademarks()
        Else
            AllForms.OpenPatents()
        End If

        Me.Close()

    End Sub

    Private Sub HookToSQL()
        On Error Resume Next
        Dim strLogin As String, strUser As String
        strLogin = "Provider=SQLOLEDB;Data Source=THOMASNAUGH5871\SQLEXPRESS;Password=fatdog999;User ID=tommy;Initial Catalog=RevaTrademarkDev7"

        SaveCurrentConnection(strLogin)
        RevaData.ConnectionString = My.Settings.CurrentConnection

        AllForms.frmTrademarks.Close()
        AllForms.frmPatents.Close()
        AllForms.frmReports.Close()
        AllForms.frmCompanies.Close()
        AllForms.frmPreferences.Close()
        AllForms.frmReportPreview.Close()

        SetSecurity()
        strUser = "RevaTest"
        Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers", "UserName='" & strUser & "'")
        Globals.SecurityLevel = 1
        Globals.PurchaseLevel = 5
        If RevaSettings.OpenOnMarks = True Then
            AllForms.OpenTrademarks()
        Else
            AllForms.OpenPatents()
        End If

        Me.Close()

    End Sub

    Private Sub btnHookDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHookDev.Click
        HookToDeveloperDB()
    End Sub

    Private Sub btnSQLDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSQLDev.Click
        HookToSQL()
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click


    End Sub

End Class