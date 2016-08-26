Imports System.Data
Imports System.Data.OleDb
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
        strLicense = My.Settings.LicenseKey & ""

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
                strConnection = My.Settings.AccessConnection
                SaveCurrentConnection(strConnection)
                .optAccess.Checked = True
                .optSQL.Checked = False
                .optSQL.Enabled = False
            Else  'default to SQL login for purchased version
                .optAccess.Checked = False
                .optSQL.Enabled = True
                .optSQL.Checked = True
            End If

            SetSecurityOptions()
        End With

    End Sub

    Private Sub SetSecurityOptions()
        On Error Resume Next
        With Me
            If .optAccess.Checked = True Then
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
                .optIntegrated.Checked = My.Settings.SecurityType = 1
                .optSpecific.Checked = My.Settings.SecurityType = 2
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
                    .Server.Text = My.Settings.ServerName & ""
                End If

                If .Database.Text & "" = "" Then
                    .Database.Text = My.Settings.DatabaseName & ""
                End If

                If .UserID.Text & "" = "" Then
                    .UserID.Text = My.Settings.UserName & ""
                End If


                If My.Settings.SavePassword = True Then
                    '.Password.Text = GetPassword(My.Settings.SQLConnection)
                    .Password.Text = My.Settings.Password
                End If

                .chkSavePassword.Checked = (My.Settings.SavePassword = True)

            End If

        End With
    End Sub

    Private Sub optIntegrated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIntegrated.CheckedChanged
        On Error Resume Next
        If Me.optIntegrated.Checked = True Then
            My.Settings.SecurityType = 1
            My.Settings.Save()
            SetSecurityOptions()
        End If
    End Sub

    Private Sub optSpecific_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSpecific.CheckedChanged
        On Error Resume Next
        If Me.optSpecific.Checked = True Then
            My.Settings.SecurityType = 2
            My.Settings.Save()
            SetSecurityOptions()
        End If
    End Sub

    Private Function IsConnection() As Boolean
        On Error Resume Next
        Dim strLogin As String, Cnn As New OleDbConnection

        With Me
            If .optAccess.Checked = True Then
                strLogin = My.Settings.AccessConnection
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
            IsConnection = True
        Else
            IsConnection = False
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
        If My.Settings.TrademarkDocumentsDemo & "" = "" Then
            My.Settings.TrademarkDocumentsDemo = strPath & "Documents"
        End If
        If My.Settings.PatentDocumentsDemo & "" = "" Then
            My.Settings.PatentDocumentsDemo = strPath & "Documents"
        End If
        If My.Settings.TrademarkGraphicsDemo & "" = "" Then
            My.Settings.TrademarkGraphicsDemo = strPath & "Graphics"
        End If
        If My.Settings.PatentGraphicsDemo & "" = "" Then
            My.Settings.PatentGraphicsDemo = strPath & "Graphics"
        End If
        If My.Settings.ReportIconDemo & "" = "" Then
            My.Settings.ReportIconDemo = strPath & "Graphics\RevaLogo.bmp"
        End If
        My.Settings.Save()
    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        On Error Resume Next
        If IsConnection() = True Then
            Dim strLogin As String
            'save settings for next time

            With Me
                If .optAccess.Checked = True Then
                    strLogin = My.Settings.AccessConnection
                    SetDemoFolders()
                Else
                    My.Settings.DatabaseName = .Database.Text
                    My.Settings.ServerName = .Server.Text
                    My.Settings.UserName = .UserID.Text
                    My.Settings.Password = .Password.Text
                    My.Settings.SavePassword = .chkSavePassword.Checked
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
            My.Settings.Save()


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

            If My.Settings.OpenOnMarks = True Then
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
        My.Settings.Save()

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
        My.Settings.Save()

    End Sub

    Private Sub optAccess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAccess.CheckedChanged
        On Error Resume Next
        SetSecurityOptions()
    End Sub

    Private Sub optSQL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSQL.CheckedChanged
        On Error Resume Next
        SetSecurityOptions()
    End Sub

    Private Function GetPassword(ByVal strConnection) As String
        On Error Resume Next

        Dim strPassword As String, iStart As Integer, iEnd As Integer
        If InStr(1, strConnection, "Password") < 2 Then
            GetPassword = ""
            Exit Function
        End If
        'parse password out of the SQL connction string
        iStart = InStr(1, strConnection, "Password")
        iStart = InStr(iStart + 1, strConnection, "=")
        iStart = iStart + 1
        If InStr(iStart + 2, strConnection, ";") < 2 Then
            iEnd = Len(strConnection) + 1
        Else
            iEnd = InStr(iStart + 2, strConnection, ";")
        End If
        GetPassword = Mid(strConnection, iStart, (iEnd - iStart))

    End Function

    Private Sub SetSecurity()
        On Error Resume Next
        If Me.optAccess.Checked = True Then
            Globals.SecurityLevel = 1
        Else
            Dim strUser As String, strUser2005 As String
            If Me.optIntegrated.Checked = True Then
                'becuz the fucking geniuses at Microsoft decided to fuck up how we identify users in SQL 2005 ...
                'for that fucking piece of shit, we now include the domain name in sysusers.name
                strUser = Environment.UserName
                strUser2005 = Environment.UserDomainName & "\" & Environment.UserName
                If DataStuff.DCount("UserName", "qvwRoleMembers", "UserName='" & strUser & "'") > 0 Then
                    Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers", _
                        "UserName='" & strUser & "'")
                Else
                    Globals.SecurityLevel = DataStuff.DMin("SecurityLevel", "qvwRoleMembers", _
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
        strLogin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\_TrademarkDev\RevaVB\RevaTrademark\RevaTrademark.mdb;Persist Security Info=True"

        SaveCurrentConnection(strLogin)
        My.Settings.Save()

        AllForms.frmTrademarks.Close()
        AllForms.frmPatents.Close()
        AllForms.frmReports.Close()
        AllForms.frmCompanies.Close()
        AllForms.frmPreferences.Close()
        AllForms.frmReportPreview.Close()

        SetSecurity()

        If My.Settings.OpenOnMarks = True Then
            AllForms.OpenTrademarks()
        Else
            AllForms.OpenPatents()
        End If

        Me.Close()

    End Sub

    Private Sub HookToSQL()
        On Error Resume Next
        Dim strLogin As String, strUser As String
        strLogin = "Provider=SQLOLEDB;Data Source=Acerlaptop\SQLExpress;User ID=sa; password=fatdog999;Initial Catalog=RevaTrademark"

        SaveCurrentConnection(strLogin)
        My.Settings.Save()

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
        If My.Settings.OpenOnMarks = True Then
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
        MessageBox.Show(RevaSettings.TestSetting)





    End Sub

End Class