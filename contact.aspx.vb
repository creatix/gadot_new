Imports cs3

Imports System.IO
Imports System.Web.Mail

Partial Class contact
    Inherits BasePage

    Public table As tableLogic.tableAdapter
    Public pagRow As pagesRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Request("Msg") Is Nothing Then
            divContact.Visible = False
            divMessage.Visible = True
        Else
            divContact.Visible = True
            divMessage.Visible = False
        End If

        loadPage()
        loadProduct()

    End Sub

    Sub loadPage()

        Dim pagesA As New pagesAdapter
        pagRow = pagesA.GetItem(34)

        If Not pagRow Is Nothing Then
            Dim pl As New pageLogic
            pl.setPageTitle(pagRow.metatitle, pagRow.metadescription, pagRow.metakeywords, Page)
            pagecontentlbl.Text = pagRow.content1
        End If

    End Sub

    Sub loadProduct()

        If Not IsNumeric(Request("pid")) Then
            Exit Sub
        End If

        Dim productsA As New productsAdapter
        Dim productRow As productsRow = productsA.GetItem(Request("pid"))

        If Not productRow Is Nothing Then
            txtContent.Text = "בקשה לרכישת מוצר: " & productRow.name & vbNewLine & "מק""ט מוצר: " & productRow.catalogno
        End If

    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click

        Dim Email As String = txtEmail.Text
        Dim FirstName As String = txtFirstName.Text
        Dim LastName As String = txtLastName.Text
        Dim Phone As String = txtPhone.Text
        Dim Subject As String = txtSubject.Text
        Dim Content As String = txtContent.Text
        Dim EmailTo As String = "avishay@ronlight.co.il"

        If Email = "" Then
            lblMessage.Text = "אנא הכנס אימייל."
            Exit Sub
        End If
        If FirstName = "" Then
            lblMessage.Text = "אנא הכנס שם פרטי."
            Exit Sub
        End If
        If LastName = "" Then
            lblMessage.Text = "אנא הכנס שם משפחה."
            Exit Sub
        End If
        If Phone = "" Then
            lblMessage.Text = "אנא הכנס טלפון."
            Exit Sub
        End If
        If Subject = "" Then
            lblMessage.Text = "אנא הכנס נושא."
            Exit Sub
        End If

        Dim msg As String
        msg = "<div align=""right"" style=""direction:rtl;""><div style=""font-size:18px;color:Red;""> פרטים </div>"
        msg &= "דוא""ל: " & Email
        msg &= "<br/>"
        msg &= "שם פרטי: " & FirstName
        msg &= "<br/>"
        msg &= "שם משפחה: " & LastName
        msg &= "<br/>"
        msg &= "טלפון: " & Phone
        msg &= "<br/>"
        msg &= "נושא: " & Subject
        msg &= "<br/>"
        msg &= "תוכן: " & Content

        msg &= "<br/></div>"

        Dim e_msg As New MailMessage

        e_msg.From = Email
        e_msg.To = EmailTo
        e_msg.Subject = "פניה באתר " & siteLogic.Config("sitename")
        e_msg.Body = msg
        e_msg.BodyFormat = MailFormat.Html

        SmtpMail.Send(e_msg)

        'Try

        'smtpClient.Send(e_msg)

        'Catch ex As Exception
        'lblMessage.Text = "ישנן בעיות בשליחת דואר האלקטרוני"
        'Exit Sub
        'End Try

        Response.Redirect("contact.aspx?Msg=true")

    End Sub


End Class
