Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.LicenseNumber.Text = RevaSettings.LicenseKey
        Me.lblUser.Text = Environment.UserDomainName & "\" & Environment.UserName
        Me.lblSecurity.Text = Globals.SecurityLevel
    End Sub

    Private Sub btnLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLicense.Click
        Try
            Dim strLicense As String
            strLicense = Me.LicenseNumber.Text & ""

            Select Case strLicense
                Case "DemoVersion"
                    Globals.PurchaseLevel = 0
                    SaveLicense()

                Case "MJ239397"
                    Globals.PurchaseLevel = 1
                    SaveLicense()

                Case "SD110603"
                    Globals.PurchaseLevel = 2
                    SaveLicense()

                Case "CS101672"
                    Globals.PurchaseLevel = 3
                    SaveLicense()

                Case "TD111458"
                    Globals.PurchaseLevel = 4
                    SaveLicense()

                Case "RE082834"
                    Globals.PurchaseLevel = 5
                    SaveLicense()

                Case "ServerDemo"
                    Globals.PurchaseLevel = 6
                    SaveLicense()

                Case Else
                    MsgBox("Sorry, that is not a legitimate license number.  Please try again.")
                    Me.LicenseNumber.Text = RevaSettings.LicenseKey & ""

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub SaveLicense()
        On Error Resume Next
        RevaSettings.LicenseKey = Me.LicenseNumber.Text
        If Me.LicenseNumber.Text = "DemoVersion" Then Exit Sub
        MsgBox("Thank you.  To log in to the SQL Server database, select Connection from the File menu.")
        Me.Close()
    End Sub
End Class
