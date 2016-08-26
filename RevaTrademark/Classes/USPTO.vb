Imports System.Data.OleDb
Imports System.Data
Imports System.Xml

Public Class USPTO

    Private XDoc As XmlDocument
    Private MarkStatus As XmlNode
    Private MarkStatusDate As XmlNode
    Private USPTOUrl As String = "https://tsdrapi.uspto.gov/ts/cd/casestatus/snApplicationNumber/info.xml"
    Private strInsertSQL As String = "insert into tblTrademarkUpdates(TrademarkID, DateRecorded, StatusDate, StatusCode, EmailSent) " & _
        "values (@TrademarkID, @DateRecorded, @StatusDate, @StatusCode, 0)"
    Private strToday As String = DateTime.Today.ToShortDateString


    Friend Sub GetUpdates(ByVal MarksToCheck As DataTable)
        On Error Resume Next
        Dim iTrademarkID As Integer, iStatusCode As Integer, iNewStatusCode As Integer
        Dim strApplication As String, strURL As String, strSQL As String, strStatusDate As String
        Dim iNumUpdates As Integer = 0
        Dim strErrors As String = String.Empty

        For Each dr As DataRow In MarksToCheck.Rows
            'reset values just in case
            strURL = String.Empty
            iTrademarkID = 0
            strApplication = String.Empty
            iStatusCode = 0
            iNewStatusCode = 0
            strStatusDate = String.Empty

            iTrademarkID = dr("TrademarkID")
            iStatusCode = Nz(dr("StatusCode"), 0)  'this is the CURRENT status in our records
            strApplication = dr("ApplicationNumber") & ""
            strApplication = NumbersOnly(strApplication)
            strURL = USPTOUrl.Replace("ApplicationNumber", strApplication)

            XDoc = New XmlDocument

            For i As Integer = 0 To 5 'give it a few shots at it
                XDoc.Load(strURL)
                If XDoc.InnerXml.Contains("MarkCurrentStatusCode") Then
                    ' we got data, so exit
                    Exit For
                Else
                    System.Threading.Thread.Sleep(100) 'try a short delay
                End If
            Next

            ' still couldn't load even after delay
            If XDoc.InnerXml.ToString().Trim() = String.Empty Then
                strErrors = strErrors & strApplication & vbCrLf
                Continue For
            End If

            If (XDoc.GetElementsByTagName("ns2:MarkCurrentStatusCode") Is Nothing) Or _
                (XDoc.GetElementsByTagName("ns2:MarkCurrentStatusDate") Is Nothing) Then
                strErrors = strErrors & strApplication & vbCrLf
                Continue For
            Else
                ' get first (and only) value from the nodes
                MarkStatus = XDoc.GetElementsByTagName("ns2:MarkCurrentStatusCode")(0)
                MarkStatusDate = XDoc.GetElementsByTagName("ns2:MarkCurrentStatusDate")(0)

                '  has the mark's status changed?
                iNewStatusCode = Convert.ToInt32(MarkStatus.InnerText)

                If iNewStatusCode <> iStatusCode Then
                    strSQL = strInsertSQL
                    strSQL = strSQL.Replace("@TrademarkID", iTrademarkID.ToString)
                    strSQL = strSQL.Replace("@StatusCode", iNewStatusCode.ToString)
                    strSQL = strSQL.Replace("@DateRecorded", FixDate(strToday))
                    strSQL = strSQL.Replace("@StatusDate", FixDate(MarkStatusDate.InnerText))
                    'create the new update record
                    DataStuff.RunSQL(strSQL)

                    'now update the trademark status
                    strSQL = "update tblTrademarks set StatusCode = @StatusCode where TrademarkID = @TrademarkID"
                    strSQL = strSQL.Replace("@TrademarkID", iTrademarkID.ToString)
                    strSQL = strSQL.Replace("@StatusCode", iNewStatusCode.ToString)
                    DataStuff.RunSQL(strSQL)
                    iNumUpdates = iNumUpdates + 1

                End If
            End If
        Next

        MsgBox(iNumUpdates & " trademark(s) on your watch list have changed status.")

        ' now show the ones that failed
        If Not (strErrors = String.Empty) Then
            Dim strMessage As String
            strMessage = "Unable to retrieve XML data for the following application numbers:" & vbCrLf & strErrors
            MsgBox(strMessage)
        End If

    End Sub



End Class
