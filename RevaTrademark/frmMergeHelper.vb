

Public Class frmMergeHelper

    Friend TrademarkID As Integer
    Friend PatentID As Integer
    Friend JurisdictionDateID As Integer
    Friend DateID As Integer

    Friend bNewDocument As Boolean
    Friend DocumentName As String

    Friend MergeStatus As mStatus
    Friend strFieldList As String

    Private dtMarkPatent As DataTable
    Private dtContacts As DataTable
    Private dtDates As DataTable

    Private FocusField As TextBox
    Private bWasEdited As Boolean


    Friend Enum mStatus As Integer
        TrademarkOutlook = 2
        TrademarkAlertDate = 3
        TrademarkJurisDate = 4
        PatentOutlook = 6
        PatentAlertDate = 7
        PatentJurisDate = 8
        OppositionAlertDate = 9
    End Enum

    Private Sub frmMergeHelper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        AllForms.frmMergeHelper = Me
    End Sub

    Private Sub frmMergeHelper_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        AllForms.frmMergeHelper = Nothing
    End Sub

    Private Sub PlainTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PlainTextBox.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub EmailSubjectLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailSubjectLine.TextChanged
        On Error Resume Next
        bWasEdited = True
    End Sub

    Private Sub PlainTextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlainTextBox.Enter
        On Error Resume Next
        FocusField = Me.PlainTextBox
        Select Case MergeStatus
            Case mStatus.OppositionAlertDate, mStatus.TrademarkAlertDate, mStatus.PatentAlertDate
                Me.cboContacts.Enabled = False
                Me.cboDates.Enabled = False
            Case Else
                Me.cboContacts.Enabled = True
                Me.cboDates.Enabled = True
        End Select
    End Sub

    Private Sub EmailSubjectLine_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailSubjectLine.Enter
        On Error Resume Next
        FocusField = Me.EmailSubjectLine
        Me.cboContacts.Enabled = False
        Me.cboDates.Enabled = False
    End Sub


#Region "Button /Toolbar Events"

    Private Sub SaveChanges()
        On Error Resume Next
        Select Case MergeStatus

            Case mStatus.TrademarkAlertDate
                SaveTrademarkAlertDate()

            Case mStatus.TrademarkJurisDate
                SaveTrademarkJurisDate()

            Case mStatus.TrademarkOutlook
                If bNewDocument = True Then
                    SaveNewTextFile()
                    AllForms.frmTrademarks.MergeDocument.Text = Me.DocumentName
                    My.Settings.LastMergeOutlook = Me.DocumentName

                Else
                    SaveExistingTextFile()
                End If

            Case mStatus.PatentAlertDate
                SavePatentAlertDate()

            Case mStatus.PatentJurisDate
                SavePatentJurisDate()

            Case mStatus.PatentOutlook
                If bNewDocument = True Then
                    SaveNewTextFile()
                    AllForms.frmPatents.MergeDocument.Text = Me.DocumentName
                    My.Settings.LastMergeOutlook = Me.DocumentName

                Else
                    SaveExistingTextFile()
                End If

            Case mStatus.OppositionAlertDate
                SaveOppositionAlertDate()

        End Select

        bWasEdited = False

    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        On Error Resume Next
        Clipboard.SetDataObject(CType(ActiveControl, TextBox).SelectedText)
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        On Error Resume Next
        Dim oDataObject As IDataObject
        oDataObject = Clipboard.GetDataObject()
        If oDataObject.GetDataPresent(DataFormats.Text) Then
            CType(ActiveControl, TextBox).SelectedText = CType(oDataObject.GetData(DataFormats.Text), String)
        End If
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        On Error Resume Next
        CType(ActiveControl, TextBox).Undo()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error Resume Next
        SaveChanges()
    End Sub

    Private Sub btnCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseForm.Click
        On Error Resume Next
        If bWasEdited = True Then
            If MsgBox("Save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveChanges()
            End If
        End If
        Me.Close()
    End Sub

    Private Sub btnSpellCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpellCheck.Click
        On Error Resume Next
        Dim SP As SpellChecker = New SpellChecker
        SP.StartWord()
        SP.CheckSpelling(Me.PlainTextBox)
        SP.StopWord()
        SP = Nothing
        MsgBox("Spell check complete.")
    End Sub

    Private Sub cboMarkPatent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarkPatent.SelectedIndexChanged
        On Error Resume Next
        Me.FocusField.Paste(Me.cboMarkPatent.Text)
        Me.FocusField.Focus()
    End Sub

    Private Sub cboContacts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContacts.SelectedIndexChanged
        On Error Resume Next
        Me.FocusField.Paste(Me.cboContacts.Text)
        Me.FocusField.Focus()
    End Sub

    Private Sub cboDates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDates.SelectedIndexChanged
        On Error Resume Next
        Me.FocusField.Paste(Me.cboDates.Text)
        Me.FocusField.Focus()
    End Sub

#End Region

    Friend Sub SetOptions()
        On Error Resume Next
        With Me
            Select Case MergeStatus

                Case mStatus.TrademarkAlertDate
                    GetTrademarkAlertFields()
                    .btnSave.Text = "Save Date Text"
                    'no contacts or date fields for alerts
                    .cboContacts.Enabled = False
                    .cboDates.Enabled = False
                    LoadTrademarkAlertDate()
                    .lblMarkPatent.Text = "Trademark Fields:"
                    .EmailSubjectLine.Visible = True
                    .lblEmailSubjectLine.Visible = True
                    .pnlFields.Height = 71

                Case mStatus.TrademarkJurisDate
                    GetTrademarkFields()
                    .btnSave.Text = "Save Date Text"
                    LoadTrademarkJurisDate()
                    .lblMarkPatent.Text = "Trademark Fields:"
                    .EmailSubjectLine.Visible = True
                    .lblEmailSubjectLine.Visible = True
                    .pnlFields.Height = 71

                Case mStatus.TrademarkOutlook
                    GetTrademarkFields()
                    .btnSave.Text = "Save Text Document"
                    If bNewDocument = False Then LoadTextFile()
                    .lblMarkPatent.Text = "Trademark Fields:"
                    .EmailSubjectLine.Visible = False
                    .lblEmailSubjectLine.Visible = False
                    .pnlFields.Height = 41

                Case mStatus.PatentAlertDate
                    GetPatentAlertFields()
                    .btnSave.Text = "Save Date Text"
                    'no contacts or date fields for alerts
                    .cboContacts.Enabled = False
                    .cboDates.Enabled = False
                    LoadPatentAlertDate()
                    .lblMarkPatent.Text = "Patent Fields:"
                    .EmailSubjectLine.Visible = True
                    .lblEmailSubjectLine.Visible = True
                    .pnlFields.Height = 71

                Case mStatus.PatentJurisDate
                    GetPatentFields()
                    .btnSave.Text = "Save Date Text"
                    LoadPatentJurisDate()
                    .lblMarkPatent.Text = "Patent Fields:"
                    .EmailSubjectLine.Visible = True
                    .lblEmailSubjectLine.Visible = True
                    .pnlFields.Height = 71

                Case mStatus.PatentOutlook
                    GetPatentFields()
                    .btnSave.Text = "Save Text Document"
                    If bNewDocument = False Then LoadTextFile()
                    .lblMarkPatent.Text = "Patent Fields:"
                    .EmailSubjectLine.Visible = False
                    .lblEmailSubjectLine.Visible = False
                    .pnlFields.Height = 38

                Case mStatus.OppositionAlertDate
                    GetOppositionAlertFields()
                    .btnSave.Text = "Save Date Text"
                    'no contacts or date fields for alerts
                    .cboContacts.Enabled = False
                    .cboDates.Enabled = False
                    LoadOppositionAlertDate()
                    .lblMarkPatent.Text = "Opposition Fields:"
                    .EmailSubjectLine.Visible = True
                    .lblEmailSubjectLine.Visible = True
                    .pnlFields.Height = 71


            End Select
            FillDropDowns()
            bWasEdited = False

        End With
    End Sub

    Private Sub GetTrademarkFields()
        On Error Resume Next
        Dim strSQL As String

        strSQL = SQL.vwTrademarkMerge & "where TrademarkID=0"
        dtMarkPatent = DataStuff.GetDataTable(strSQL)

        strSQL = SQL.vwTrademarkContactsMerge & "where TrademarkID=0"
        dtContacts = DataStuff.GetDataTable(strSQL)

        dtDates = DataStuff.GetDataTable("Select DateID, DateName from tblDatesTemplate order by ListOrder")
    End Sub

    Private Sub GetTrademarkAlertFields()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select distinct TrademarkName, CompanyName, Jurisdiction, ApplicationNumber, RegistrationNumber," &
            " FileNumber, OurDocket, ClientDocket, RegistrationType, Status, TrademarkDate from " &
            "qvwTrademarkDates where TrademarkDateID=0"
        'limited fields for alerts
        dtMarkPatent = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub GetPatentAlertFields()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select distinct PatentName, CompanyName, Jurisdiction, ApplicationNumber, PatentNumber," &
            " FileNumber, OurDocket, ClientDocket, PatentType, Status, PatentDate from " &
            "qvwPatentDates where PatentDateID=0"
        'limited fields for alerts
        dtMarkPatent = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub GetPatentFields()
        On Error Resume Next
        Dim strSQL As String

        strSQL = SQL.vwPatentMerge & "where PatentID=0"
        dtMarkPatent = DataStuff.GetDataTable(strSQL)

        strSQL = SQL.vwPatentContactsMerge & "where PatentID=0"
        dtContacts = DataStuff.GetDataTable(strSQL)

        dtDates = DataStuff.GetDataTable("Select DateID, DateName from tblPatentDatesTemplate order by ListOrder")
    End Sub

    Private Sub GetOppositionAlertFields()
        On Error Resume Next
        Dim strSQL As String
        strSQL = "Select distinct OppositionName, CompanyName, OppositionCompany as OpposingCompanyName, Jurisdiction, ProceedingNumber," &
            " Status, OppositionDate from qvwOppositionDates where OppositionDateID=0"
        'limited fields for alerts
        dtMarkPatent = DataStuff.GetDataTable(strSQL)
    End Sub

    Private Sub FillDropDowns()
        On Error Resume Next
        Dim i As Integer, strField As String

        'we store a field list in case user clicks the Get fields buttons
        strFieldList = ""

        With dtMarkPatent
            For i = 0 To .Columns.Count - 1
                strField = dtMarkPatent.Columns(i).ColumnName
                If Not (strField Like "*ID") Then
                    strField = "[" & strField & "]"
                    Me.cboMarkPatent.Items.Add(strField, strField)
                    strFieldList = strFieldList & strField & vbCrLf
                End If
            Next
        End With
        dtMarkPatent = Nothing

        'trademark merge of some kind
        Select Case Me.MergeStatus

            Case mStatus.TrademarkOutlook, mStatus.TrademarkJurisDate
                Me.cboMarkPatent.Items.Add("[RegistrationClasses]", "[RegistrationClasses]")
                strFieldList = strFieldList & "[RegistrationClasses]" & vbCrLf

            Case mStatus.PatentJurisDate, mStatus.PatentOutlook
                Me.cboMarkPatent.Items.Add("[PatentClasses]", "[PatentClasses]")
                strFieldList = strFieldList & "[PatentClasses]" & vbCrLf

            Case Else
        End Select


        strFieldList = strFieldList & "---- Contact Fields ----" & vbCrLf

        With dtContacts
            For i = 0 To .Columns.Count - 1
                strField = dtContacts.Columns(i).ColumnName
                If Not (strField Like "*ID") Then
                    strField = "[" & strField & "]"
                    Me.cboContacts.Items.Add(strField, strField)
                    strFieldList = strFieldList & strField & vbCrLf
                End If
            Next
        End With
        dtContacts = Nothing

        strFieldList = strFieldList & "----- Date Fields -----" & vbCrLf
        'this one is actually reading the data, not just the field names.
        With dtDates
            For i = 0 To .Rows.Count - 1
                strField = dtDates.Rows(i).Item("DateName")
                strField = Replace(strField, " ", "")
                strField = Replace(strField, "'", "")
                strField = "[" & strField & "]"
                Me.cboDates.Items.Add(strField, strField)
                strFieldList = strFieldList & strField & vbCrLf
            Next
        End With

    End Sub

    Private Sub LoadTextFile()
        On Error Resume Next
        Dim oRead As System.IO.StreamReader, strText As String
        oRead = New System.IO.StreamReader(DocumentName)
        strText = oRead.ReadToEnd
        Me.PlainTextBox.Text = strText
        Me.PlainTextBox.SelectionStart = 0
        Me.PlainTextBox.SelectionLength = 0
    End Sub

    Private Sub SaveNewTextFile()
        On Error Resume Next

        With Me.SaveFileDialog
            If My.Settings.DemoConnection = My.Settings.CurrentConnection Then
                .InitialDirectory = RevaSettings.TrademarkDocumentsDemo
            Else
                .InitialDirectory = RevaSettings.TrademarkDocuments
            End If
            .FileName = ""
            .Filter = "Text Documents (*.txt)|*.txt|All Files|*.*"
            .FilterIndex = 1
            .Title = "Name the new document"
            .RestoreDirectory = False
            .ShowDialog()
            If Len(.FileName & "") > 3 Then
                Me.DocumentName = .FileName
                Dim oWrite As System.IO.StreamWriter
                oWrite = New System.IO.StreamWriter(DocumentName)
                oWrite.Write(Me.PlainTextBox.Text)
                oWrite.Close()
            End If
        End With

    End Sub

    Private Sub SaveExistingTextFile()
        On Error Resume Next
        'out with the old, in with the new
        System.IO.File.Delete(DocumentName)
        Dim oWrite As System.IO.StreamWriter
        oWrite = New System.IO.StreamWriter(DocumentName)
        oWrite.Write(Me.PlainTextBox.Text)
        oWrite.Close()
    End Sub

#Region "Load Dates From Database"

    Private Sub LoadTrademarkJurisDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select EmailMessage, EmailSubjectLine from tblJurisdictionDates where JurisdictionDateID=" & _
            Me.JurisdictionDateID)
        dr.Read()
        Me.PlainTextBox.Text = dr("EmailMessage")
        Me.EmailSubjectLine.Text = dr("EmailSubjectLine")
        dr.Close()
    End Sub

    Private Sub LoadTrademarkAlertDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select DateID, EmailAlert, EmailSubjectLine from tblDatesTemplate where DateID=" & Me.DateID)
        dr.Read()
        Me.PlainTextBox.Text = dr("EmailAlert")
        Me.EmailSubjectLine.Text = dr("EmailSubjectLine")
        dr.Close()
    End Sub

    Private Sub LoadPatentJurisDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select EmailMessage, EmailSubjectLine from tblPatentJurisdictionDates where JurisdictionDateID=" & _
            Me.JurisdictionDateID)
        dr.Read()
        Me.PlainTextBox.Text = dr("EmailMessage")
        Me.EmailSubjectLine.Text = dr("EmailSubjectLine")
        dr.Close()
    End Sub

    Private Sub LoadPatentAlertDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select EmailAlert, EmailSubjectLine from tblPatentDatesTemplate where DateID=" & Me.DateID)
        dr.Read()
        Me.PlainTextBox.Text = dr("EmailAlert")
        Me.EmailSubjectLine.Text = dr("EmailSubjectLine")
        dr.Close()
    End Sub

    Private Sub LoadOppositionAlertDate()
        On Error Resume Next
        Dim dr As OleDb.OleDbDataReader
        dr = DataStuff.GetDataReader("Select DateID, EmailAlert, EmailSubjectLine from tblOppositionTemplate where DateID=" & Me.DateID)
        dr.Read()
        Me.PlainTextBox.Text = dr("EmailAlert")
        Me.EmailSubjectLine.Text = dr("EmailSubjectLine")
        dr.Close()
    End Sub

#End Region

#Region "Save Dates to Database"

    Private Sub SaveTrademarkJurisDate()
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, strText As String, strSQL As String
        strSQL = "Select JurisdictionDateID, EmailMessage, EmailSubjectLine from tblJurisdictionDates where JurisdictionDateID=" & _
            Me.JurisdictionDateID
        rsRecord.GetFromSQL(strSQL)
        strText = Me.PlainTextBox.Text
        dRow = rsRecord.CurrentRow
        dRow("EmailMessage") = strText & ""
        strText = Me.EmailSubjectLine.Text
        dRow("EmailSubjectLine") = strText & ""
        rsRecord.Update()
    End Sub

    Private Sub SaveTrademarkAlertDate()
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, strText As String, strSQL As String
        strSQL = "Select DateID, EmailAlert, EmailSubjectLine from tblDatesTemplate where DateID=" & Me.DateID
        rsRecord.GetFromSQL(strSQL)
        strText = Me.PlainTextBox.Text
        dRow = rsRecord.CurrentRow
        dRow("EmailAlert") = strText & ""
        strText = Me.EmailSubjectLine.Text
        dRow("EmailSubjectLine") = strText & ""
        rsRecord.Update()
    End Sub

    Private Sub SavePatentJurisDate()
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, strText As String, strSQL As String
        strSQL = "Select JurisdictionDateID, EmailMessage, EmailSubjectLine from tblPatentJurisdictionDates where JurisdictionDateID=" & _
            Me.JurisdictionDateID
        rsRecord.GetFromSQL(strSQL)
        strText = Me.PlainTextBox.Text
        dRow = rsRecord.CurrentRow
        dRow("EmailMessage") = strText & ""
        strText = Me.EmailSubjectLine.Text
        dRow("EmailSubjectLine") = strText & ""
        rsRecord.Update()
    End Sub

    Private Sub SavePatentAlertDate()
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, strText As String, strSQL As String
        strSQL = "Select DateID, EmailAlert, EmailSubjectLine from tblPatentDatesTemplate where DateID=" & Me.DateID
        rsRecord.GetFromSQL(strSQL)
        strText = Me.PlainTextBox.Text
        dRow = rsRecord.CurrentRow
        dRow("EmailAlert") = strText & ""
        strText = Me.EmailSubjectLine.Text
        dRow("EmailSubjectLine") = strText & ""
        rsRecord.Update()
    End Sub

    Private Sub SaveOppositionAlertDate()
        On Error Resume Next
        Dim rsRecord As New RecordSet, dRow As DataRow, strText As String, strSQL As String
        strSQL = "Select DateID, EmailAlert, EmailSubjectLine from tblOppositionTemplate where DateID=" & Me.DateID
        rsRecord.GetFromSQL(strSQL)
        strText = Me.PlainTextBox.Text
        dRow = rsRecord.CurrentRow
        dRow("EmailAlert") = strText & ""
        strText = Me.EmailSubjectLine.Text
        dRow("EmailSubjectLine") = strText & ""
        rsRecord.Update()
    End Sub

#End Region

    
    
    
End Class