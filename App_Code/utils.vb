Imports cs3.tableLogic
Imports System.Net.Mail
Imports System.Security.Cryptography

Public Class mailLogic

    Function sendMailTemplate(ByVal mailname As String, ByVal fromMail As String, ByVal toMail As String, Optional ByVal placeholders As Dictionary(Of String, String) = Nothing) As Boolean
        If mailname = "" Then Return False
        Dim _siteLogic As New siteLogic
        Dim _mailtemplatesAdapter As New mailtemplatesAdapter
        Dim mailtemplateRow As mailtemplatesRow = _mailtemplatesAdapter.GetItem(0, "name='" & mailname & "'")
        If Not mailtemplateRow Is Nothing And mailtemplateRow.mailtemplatesid > 0 Then
            placeholders.Add("sitename", siteLogic.Config("sitename"))
            placeholders.Add("siteurl", siteLogic.Config("siteurl"))
            If Not placeholders Is Nothing Then
                For Each placeholder As String In placeholders.Keys
                    mailtemplateRow.subject = mailtemplateRow.subject.Replace("{" & placeholder & "}", placeholders(placeholder))
                    mailtemplateRow.content1 = mailtemplateRow.content1.Replace("{" & placeholder & "}", placeholders(placeholder))
                Next
            End If
            sendMail(mailtemplateRow.subject, mailtemplateRow.content1, fromMail, toMail)
            If siteLogic.Config("sendordernotificationmail") = "1" Then
                sendMail(mailtemplateRow.subject, mailtemplateRow.content1, fromMail, fromMail)
            End If
        End If
        Return True
    End Function

    Function sendMail(ByVal subject As String, ByVal msg As String, ByVal fromMail As String, ByVal toMail As String) As Boolean
        Dim msgObj As New MailMessage()
        msgObj.From = New MailAddress(fromMail)
        msgObj.To.Add(toMail)
        msgObj.Subject = subject
        Dim str As String = "<html><body dir=rtl style=""direction:rtl;""><div align=""right"" style=""width:621px; border:1px solid #8b8b8b; padding:30px;"">"
        'str &= "<img src="""" alt="""" align=""right"" /><br>"
        str &= msg
        str &= "</div></body></html>"
        msgObj.Body = str
        msgObj.IsBodyHtml = True
        Dim smtpClient As SmtpClient = New SmtpClient()
        smtpClient.Host = "mail.creatixssl.co.il"
        smtpClient.Port = 25
        smtpClient.Send(msgObj)
    End Function

End Class

Public Class encryptionLogic

    Public Function Encrypt(ByVal Data As String) As String

        Try
            If Data = "" Then
                Return ""
            End If
            Dim shaM As New SHA1Managed
            Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(Data)))
            Dim eNC_data() As Byte = ASCIIEncoding.ASCII.GetBytes(Data)
            Dim eNC_str As String = Convert.ToBase64String(eNC_data)
            Return eNC_str
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function Decrypt(ByVal Data As String) As String

        Try
            If Data = "" Then
                Return ""
            End If
            Dim dEC_data() As Byte = Convert.FromBase64String(Data)
            Dim dEC_Str As String = ASCIIEncoding.ASCII.GetString(dEC_data)
            Return dEC_Str
        Catch ex As Exception
            Return ""
        End Try

    End Function

End Class