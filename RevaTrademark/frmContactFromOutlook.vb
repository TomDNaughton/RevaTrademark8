Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmContactFromOutlook

    Dim rsContact As New RecordSet
    Dim dRow As DataRow
    Friend AddOrEdit As Integer

    Private Sub frmContactFromOutlook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        AllForms.frmContactFromOutlook = Me
        FillPositions()
        ClearContact()
    End Sub

    Friend Sub FillPositions()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select * from tblPositions order by [PositionName]"
        Me.PositionID.DataSource = DataStuff.GetDataTable(strSQL)
    End Sub

    Friend Sub ClearContact()
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
    End Sub

    Private Sub btnGetFromOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFromOutlook.Click
        GetContacts()
    End Sub

    Private Sub GetContacts()
        On Error Resume Next

        Dim objOutlook As Outlook.Application    'Outlook Namespace will be current session    
        Dim objNS As Outlook.NameSpace, i As Integer, strStreetAddress As String, strLines() As String

        objOutlook = New Outlook.Application()
        objNS = objOutlook.Session
        'Get the Contact folder            
        Dim objAddressList As Outlook.MAPIFolder
        objAddressList = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)

        'Get all the contacts            
        Dim objItems As Outlook.Items = objAddressList.Items
        Dim objContact As Outlook.ContactItem
        grdContacts.RootTable.SortKeys.Clear()

        'Loop through all contacts           
        For i = 1 To objItems.Count
            If Not (objItems.Item(i) Is Nothing) Then
                objContact = objItems.Item(i)
                'NOTE:  UNBOUND GRID!
                With Me.grdContacts
                    .AddItem()
                    .MoveLast()
                    .SetValue("FirstName", objContact.FirstName)
                    .SetValue("LastName", objContact.LastName)
                    .SetValue("CompanyName", objContact.CompanyName)
                    .SetValue("Suffix", objContact.Suffix)
                    .SetValue("Salutation", objContact.Title)
                    .SetValue("ContactTitle", objContact.JobTitle)
                    .SetValue("ContactPager", objContact.PagerNumber)
                    .SetValue("ContactEmail", objContact.Email1Address)
                    .SetValue("ContactMobilePhone", objContact.MobileTelephoneNumber)

                    If Nz(objContact.BusinessAddressCity, "") <> "" Then
                        .SetValue("ContactCity", objContact.BusinessAddressCity)
                    Else
                        .SetValue("ContactCity", objContact.HomeAddressCity)
                    End If

                    If Nz(objContact.BusinessAddressState, "") <> "" Then
                        .SetValue("ContactStateProvince", objContact.BusinessAddressState)
                    Else
                        .SetValue("ContactStateProvince", objContact.HomeAddressState)
                    End If

                    If Nz(objContact.BusinessAddressPostalCode, "") <> "" Then
                        .SetValue("ContactPostalCode", objContact.BusinessAddressPostalCode)
                    Else
                        .SetValue("ContactPostalCode", objContact.HomeAddressPostalCode)
                    End If

                    If Nz(objContact.BusinessAddressCountry, "") <> "" Then
                        .SetValue("ContactCountry", objContact.BusinessAddressCountry)
                    Else
                        .SetValue("ContactCountry", objContact.HomeAddressCountry)
                    End If

                    If Nz(objContact.BusinessTelephoneNumber, "") <> "" Then
                        .SetValue("ContactPhone", objContact.BusinessTelephoneNumber)
                    Else
                        .SetValue("ContactPhone", objContact.HomeTelephoneNumber)
                    End If

                    If Nz(objContact.BusinessFaxNumber, "") <> "" Then
                        .SetValue("ContactFax", objContact.BusinessFaxNumber)
                    Else
                        .SetValue("ContactFax", objContact.HomeFaxNumber)
                    End If

                    If Nz(objContact.BusinessAddressStreet, "") <> "" Then
                        strStreetAddress = objContact.BusinessAddressStreet
                    Else
                        strStreetAddress = objContact.HomeAddressStreet
                    End If

                    'take address, split into array, parse them out
                    strLines = Split(strStreetAddress, vbCrLf)
                    .SetValue("ContactAddressOne", strLines(0))
                    .SetValue("ContactAddressTwo", strLines(1))

                End With
            End If
        Next

        grdContacts.RootTable.SortKeys.Add("LastName", Janus.Windows.GridEX.SortOrder.Ascending)
        grdContacts.RootTable.SortKeys.Add("FirstName", Janus.Windows.GridEX.SortOrder.Ascending)

    End Sub

    Private Sub grdContacts_LinkClicked(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdContacts.LinkClicked
        On Error Resume Next
        ClearContact()
        With Me.grdContacts
            Me.LastName.Text = .GetValue("LastName")
            Me.FirstName.Text = .GetValue("FirstName")
            Me.Salutation.Text = .GetValue("Salutation")
            Me.MiddleName.Text = .GetValue("MiddleName")
            Me.Suffix.Text = .GetValue("Suffix")
            Me.ContactTitle.Text = .GetValue("ContactTitle")
            Me.ContactAddressOne.Text = .GetValue("ContactAddressOne")
            Me.ContactAddressTwo.Text = .GetValue("ContactAddressTwo")
            Me.ContactCity.Text = .GetValue("ContactCity")
            Me.ContactStateProvince.Text = .GetValue("ContactStateProvince")
            Me.ContactPostalCode.Text = .GetValue("ContactPostalCode")
            Me.ContactCountry.Text = .GetValue("ContactCountry")
            Me.ContactPhone.Text = .GetValue("ContactPhone")
            Me.ContactFax.Text = .GetValue("ContactFax")
            Me.ContactPager.Text = .GetValue("ContactPager")
            Me.ContactMobilePhone.Text = .GetValue("ContactMobilePhone")
            Me.ContactEmail.Text = .GetValue("ContactEmail")
        End With
    End Sub

    Private Sub frmContactFromOutlook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmContactFromOutlook = Nothing
    End Sub

    Private Sub btnSaveContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveContact.Click
        On Error Resume Next
        'MsgBox(Globals.CompanyID)
        'Exit Sub

        rsContact.GetFromSQL("Select * from tblContacts where ContactID=0")
        rsContact.AddRow()
        dRow = rsContact.CurrentRow

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
            ' AllForms.frmTrademarks.FillContactList()
            AllForms.frmTrademarks.GetContacts()
        End If

        If Not (AllForms.frmPatents Is Nothing) Then
            'AllForms.frmPatents.FillContactList()
            AllForms.frmPatents.GetContacts()
        End If

        If Me.optCopyCompanyInfo.Checked = True Then
            With AllForms.frmCompanies
                .AddressOne.Text = Me.ContactAddressOne.Text
                .AddressTwo.Text = Me.ContactAddressTwo.Text
                .City.Text = Me.ContactCity.Text
                .StateProvince.Text = Me.ContactStateProvince.Text
                .PostalCode.Text = Me.ContactPostalCode.Text
                .Country.Text = Me.ContactCountry.Text
                .CompanyPhone.Text = Me.ContactPhone.Text
            End With
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

    Private Sub btnAddToOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next

        Dim objOutlook As Outlook.Application    'Outlook Namespace will be current session    
        Dim objNS As Outlook.NameSpace


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


    Private Sub btnSetPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPermission.Click
        On Error Resume Next
        Dim objOutlook As Outlook.Application    'Outlook Namespace will be current session    
        Dim objNS As Outlook.NameSpace, i As Integer, strEmail As Integer

        objOutlook = New Outlook.Application()
        objNS = objOutlook.Session
        'Get the Contact folder            
        Dim objAddressList As Outlook.MAPIFolder
        objAddressList = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)

        'Get all the contacts            
        Dim objItems As Outlook.Items = objAddressList.Items
        Dim objContact As Outlook.ContactItem

        'Loop through all contacts           
        For i = 1 To 2
            If Not (objItems.Item(i) Is Nothing) Then
                objContact = objItems.Item(i)
                strEmail = objContact.Email1Address
            End If
        Next

        Me.btnGetFromOutlook.Enabled = True
    End Sub

    
End Class