Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmContact

    Dim rsContact As New RecordSet
    Dim dRow As DataRow
    Friend AddOrEdit As Integer

    Private Sub frmContact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmContact = Me
        FillPositions()
        If Globals.SecurityLevel = 3 Then
            Me.btnSaveContact.Enabled = False
        End If
    End Sub

    Friend Sub FillPositions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPositions order by [PositionName]"
        Me.PositionID.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Friend Sub GetContact()
        On Error Resume Next
        With Me
            .Salutation.Text = ""
            .FirstName.Text = ""
            .MiddleName.Text = ""
            .LastName.Text = ""
            .Suffix.Text = ""
            .GreetingLine.Text = ""
            .ContactTitle.Text = ""
            .ContactAddressOne.Text = ""
            .ContactAddressTwo.Text = ""
            .ContactCity.Text = ""
            .ContactStateProvince.Text = ""
            .ContactPostalCode.Text = ""
            .ContactCountry.Text = ""
            .ContactPhone.Text = ""
            .ContactFax.Text = ""
            .ContactPager.Text = ""
            .ContactMobilePhone.Text = ""
            .ContactEmail.Text = ""
            .PositionID.SelectedIndex = -1
            .AddToTrademarks.Checked = False
            .AddToPatents.Checked = False
        End With

        If AddOrEdit = 1 Then  '1 means adding a new contact, so pick up company info as default
            rsContact.GetFromSQL("Select * from tblContacts where ContactID=0")
            rsContact.AddRow()
            dRow = rsContact.CurrentRow

            With Me
                .ContactAddressOne.Text = AllForms.frmCompanies.AddressOne.Text & ""
                .ContactAddressTwo.Text = AllForms.frmCompanies.AddressTwo.Text & ""
                .ContactCity.Text = AllForms.frmCompanies.City.Text & ""
                .ContactStateProvince.Text = AllForms.frmCompanies.StateProvince.Text & ""
                .ContactPostalCode.Text = AllForms.frmCompanies.PostalCode.Text & ""
                .ContactCountry.Text = AllForms.frmCompanies.Country.Text & ""
                .ContactPhone.Text = AllForms.frmCompanies.CompanyPhone.Text & ""
                .ContactFax.Text = AllForms.frmCompanies.CompanyFax.Text & ""
                .AddToTrademarks.Checked = False
                .AddToPatents.Checked = False
            End With
        End If

        If AddOrEdit = 2 Then  '2 means we're editing
            rsContact.GetFromSQL("Select * from tblContacts where ContactID=" & Globals.ContactID)
            dRow = rsContact.CurrentRow

            With Me
                .Salutation.Text = dRow("Salutation") & ""
                .FirstName.Text = dRow("FirstName") & ""
                .MiddleName.Text = dRow("MiddleName") & ""
                .LastName.Text = dRow("LastName") & ""
                .Suffix.Text = dRow("Suffix") & ""
                .GreetingLine.Text = dRow("GreetingLine") & ""
                .ContactTitle.Text = dRow("ContactTitle") & ""
                .ContactAddressOne.Text = dRow("ContactAddressOne") & ""
                .ContactAddressTwo.Text = dRow("ContactAddressTwo") & ""
                .ContactCity.Text = dRow("ContactCity") & ""
                .ContactStateProvince.Text = dRow("ContactStateProvince") & ""
                .ContactPostalCode.Text = dRow("ContactPostalCode") & ""
                .ContactCountry.Text = dRow("ContactCountry") & ""
                .ContactPhone.Text = dRow("ContactPhone") & ""
                .ContactFax.Text = dRow("ContactFax") & ""
                .ContactPager.Text = dRow("ContactPager") & ""
                .ContactMobilePhone.Text = dRow("ContactMobilePhone") & ""
                .ContactEmail.Text = dRow("ContactEmail") & ""
                .PositionID.Value = IIf(Nz(dRow("PositionID"), 0) > 0, dRow("PositionID"), DBNull.Value)
                .AddToTrademarks.Checked = IIf(dRow("AddToTrademarks") = True, True, False)
                .AddToPatents.Checked = IIf(dRow("AddToPatents") = True, True, False)
            End With
        End If
    End Sub

    Private Sub frmContact_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmContact = Nothing
    End Sub

    Private Sub btnSaveContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveContact.Click
        On Error Resume Next
        'MsgBox(Globals.CompanyID)
        'Exit Sub

        With Me
            dRow("CompanyID") = Globals.CompanyID
            dRow("Salutation") = .Salutation.Text & ""
            dRow("FirstName") = .FirstName.Text & ""
            dRow("MiddleName") = .MiddleName.Text & ""
            dRow("LastName") = .LastName.Text & ""
            dRow("Suffix") = .Suffix.Text & ""
            dRow("GreetingLine") = .GreetingLine.Text & ""
            dRow("ContactTitle") = .ContactTitle.Text & ""
            dRow("ContactAddressOne") = .ContactAddressOne.Text & ""
            dRow("ContactAddressTwo") = .ContactAddressTwo.Text & ""
            dRow("ContactCity") = .ContactCity.Text & ""
            dRow("ContactStateProvince") = .ContactStateProvince.Text & ""
            dRow("ContactPostalCode") = .ContactPostalCode.Text & ""
            dRow("ContactCountry") = .ContactCountry.Text & ""
            dRow("ContactPhone") = .ContactPhone.Text & ""
            dRow("ContactFax") = .ContactFax.Text & ""
            dRow("ContactPager") = .ContactPager.Text & ""
            dRow("ContactMobilePhone") = .ContactMobilePhone.Text & ""
            dRow("ContactEmail") = .ContactEmail.Text & ""
            dRow("ContactName") = .LastName.Text & ", " & .FirstName.Text & _
                "" & IIf(.Suffix.Text & "" <> "", " " & .Suffix.Text, "")
            dRow("PositionID") = IIf(Nz(.PositionID.Value, 0) > 0, .PositionID.Value, DBNull.Value)
            dRow("AddToTrademarks") = IIf(.AddToTrademarks.Checked = True, True, False)
            dRow("AddToPatents") = IIf(.AddToPatents.Checked = True, True, False)
        End With


        rsContact.Update()
        AllForms.frmCompanies.GetContacts()
        AllForms.frmCompanies.GetBrowseRecords()
        If Not (AllForms.frmTrademarks Is Nothing) Then
            AllForms.frmTrademarks.FillContactList()
            AllForms.frmTrademarks.GetContacts()
        End If

        If Not (AllForms.frmPatents Is Nothing) Then
            AllForms.frmPatents.FillContactList()
            AllForms.frmPatents.GetContacts()
        End If

        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btnCopyAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAddress.Click
        On Error Resume Next
        With Me
            .ContactAddressOne.Text = AllForms.frmCompanies.AddressOne.Text & ""
            .ContactAddressTwo.Text = AllForms.frmCompanies.AddressTwo.Text & ""
            .ContactCity.Text = AllForms.frmCompanies.City.Text & ""
            .ContactStateProvince.Text = AllForms.frmCompanies.StateProvince.Text & ""
            .ContactPostalCode.Text = AllForms.frmCompanies.PostalCode.Text & ""
            .ContactCountry.Text = AllForms.frmCompanies.Country.Text & ""
        End With
    End Sub

    Private Sub btnCopyPhone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyPhone.Click
        On Error Resume Next
        With Me
            .ContactPhone.Text = AllForms.frmCompanies.CompanyPhone.Text & ""
            .ContactFax.Text = AllForms.frmCompanies.CompanyFax.Text & ""
        End With
    End Sub

    Private Sub btnPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPosition.Click
        On Error Resume Next
        Dim f As New frmGeneralPopups
        f.GetRecordset(6)
        f.ShowDialog(Me)
        f = Nothing
    End Sub

    Private Sub btnAddToOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToOutlook.Click
        On Error Resume Next

        Dim objOutlook As Outlook._Application    'Outlook Namespace will be current session    
        Dim objNS As Outlook._NameSpace
        Dim i As Integer, strContactName As String, strCompany As String, strAddress As String, _
            strFirstName As String, strLastName As String, strMessage As String

        objOutlook = New Outlook.Application()
        objNS = objOutlook.Session
        'Get the Contact folder            
        Dim objAddressList As Outlook.MAPIFolder
        objAddressList = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)

        strFirstName = Me.FirstName.Text & ""
        strLastName = Me.LastName.Text & ""
        strContactName = strLastName & ", " & strFirstName
        strAddress = Me.ContactAddressOne.Text & "" & vbCrLf & Me.ContactAddressTwo.Text & ""

        'Get all the contacts            
        Dim objItems As Outlook.Items = objAddressList.Items
        Dim objContact As Outlook.ContactItem
        'Loop through all contacts           
        For i = 1 To objItems.Count
            If Not (objItems.Item(i) Is Nothing) Then
                objContact = objItems.Item(i)
                If Convert.ToString(objContact.FirstName) = strFirstName _
                    And Convert.ToString(objContact.LastName) = strLastName Then
                    strCompany = Convert.ToString(objContact.CompanyName)
                    strMessage = "The following contact appears to already be in your Outlook address book:"
                    strMessage = strMessage & vbCrLf & vbCrLf & strContactName & vbCrLf & strCompany
                    strMessage = strMessage & vbCrLf & vbCrLf & "Copy the contact to Outlook anyway?"
                    If MsgBox(strMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
        Next

        objContact = objOutlook.CreateItem(Outlook.OlItemType.olContactItem)
        With objContact
            .FirstName = Me.FirstName.Text & ""
            .LastName = Me.LastName.Text & ""
            .CompanyName = AllForms.frmCompanies.CompanyName.Text & ""
            .BusinessAddressStreet = strAddress
            .BusinessAddressCity = Me.ContactCity.Text & ""
            .BusinessAddressState = Me.ContactStateProvince.Text & ""
            .BusinessAddressPostalCode = Me.ContactPostalCode.Text & ""
            .BusinessTelephoneNumber = Me.ContactPhone.Text & ""
            .BusinessFaxNumber = Me.ContactFax.Text & ""
            .MobileTelephoneNumber = Me.ContactMobilePhone.Text & ""
            .Title = Me.ContactTitle.Text & ""
            .PagerNumber = Me.ContactPager.Text & ""
            .Email1Address = Me.ContactEmail.Text & ""
            .Suffix = Me.Suffix.Text & ""
            .MiddleName = Me.MiddleName.Text & ""
            .Save()
        End With
        MsgBox(strContactName & " was saved to your address book.")

    End Sub
End Class