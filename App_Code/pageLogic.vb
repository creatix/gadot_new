Imports Microsoft.VisualBasic
Imports System.IO

Public Class pageLogic

    Public Shared Function GetLink(ByVal page As String, ByVal pagesid As String, ByVal name As String, Optional ByVal page_link As String = "") As String
        If IsDBNull(page_link) Then
            page_link = ""
        End If
        If page_link <> "" Then
            Return page_link
        Else
            If name = "" Then
                Return page & "-" & pagesid & "-" & page & ".aspx"
            Else
                Return page & "-" & pagesid & "-" & parseURL(name) & ".aspx"
            End If
        End If
    End Function

    Public Shared Function GetPageURL(url As String, link As String) As String
        If link <> "" Then
            Return link
        End If
        If Not url.EndsWith(".aspx") Then
            url &= ".aspx"
        End If
        Return url
    End Function

    Public Shared Function GetPageName(ByVal name As String, ByVal menuname As String) As String
        If menuname <> "" Then
            Return menuname
        End If
        Return name
    End Function

    Public Shared Function parseURL(ByVal url As String) As String
        url = url.Replace(" ", "_")
        url = url.Replace("-", "_")
        url = url.Replace("?", "")
        url = url.Replace("'", "")
        url = url.Replace("&", "")
        url = url.Replace("+", "")
        url = url.Replace("/", "")
        url = url.Replace("\", "")
        url = url.Replace(":", "")
        url = url.Replace("""", "")
        'url = Server.UrlEncode(url)
        Return url
    End Function

    Public Sub setPageTitle(ByVal metatitle As String, ByVal metadescription As String, ByVal metakeywords As String, ByVal page As System.Web.UI.Page)

        If Trim(metatitle) <> "" Then
            page.Title = metatitle
        End If

        Dim metaTag As New HtmlMeta

        If Trim(metadescription) <> "" Then
            metaTag.Name = "description"
            metaTag.Content = metadescription
            page.Header.Controls.Add(metaTag)
        End If

        If Trim(metakeywords) <> "" Then
            metaTag = New HtmlMeta
            metaTag.Name = "keywords"
            metaTag.Content = metakeywords
            page.Header.Controls.Add(metaTag)
        End If

    End Sub

    Public Sub addCanonical(ByVal pageUrl As String, ByVal page As System.Web.UI.Page)
        Dim linkTag As New HtmlLink
        linkTag.Attributes.Add("rel", "canonical")
        linkTag.Attributes.Add("href", siteLogic.Config("siteurl") & pageUrl)
        page.Header.Controls.Add(linkTag)
    End Sub

    Public Shared Function getEditableHTMLField(name As String, path As String) As String
        Return "class=""editable"" title=""html:" & path & ":" & name & """"
    End Function

    Public Shared Function getEditableDataField(table As String, name As String, id As Integer, cont As String, Optional tag As String = "editable") As String
        Return "<" & tag & " class=""editable"" title=""data:" & table & ":" & name & ":" & id & """>" & cont & "</" & tag & ">"
    End Function

    Function getPageTree(ByVal pageid As Integer) As pList(Of pagesRow)

        Dim _pagesAdapter As New pagesAdapter
        Dim _pagesList As pList(Of pagesRow) = _pagesAdapter.GetList(, , , , , "SELECT * FROM getpageparents('" & pageid & "')")
        Return _pagesList

    End Function

End Class

Public Class pageHelper

    Public Shared Function RenderControl(url As String) As HtmlString
        Dim page As Page = New Page()
        Dim control = page.LoadControl(url)
        page.Controls.Add(control)
        Dim sw As StringWriter = New StringWriter()
        HttpContext.Current.Server.Execute(page, sw, True)
        Return New HtmlString(sw.ToString())
    End Function

End Class


Public Class fieldLogic

    Public Sub New()

    End Sub

    Public Enum messageType
        alert
        success
        notify
    End Enum

    Sub showError(ByVal type As messageType, ByVal msg As String)
        Select Case type
            Case messageType.alert
                HttpContext.Current.Session("errormsg") = msg
            Case messageType.success
                HttpContext.Current.Session("successmsg") = msg
            Case messageType.notify
                HttpContext.Current.Session("notifymsg") = msg
        End Select
    End Sub

    Function isEmptyField(ByVal c As Object, ByVal msg As String, Optional ByVal matchValue As String = "") As Boolean
        If c.Value = matchValue Then
            showError(messageType.alert, msg)
            markField(c)
            Return True
        End If
        Return False
    End Function

    Function isEquelField(ByVal c1 As Object, ByVal c2 As Object, ByVal msg As String) As Boolean
        If c1.Value <> c2.Value Then
            showError(messageType.alert, msg)
            markField(c2)
            Return True
        End If
        Return False
    End Function

    Function isEmail(ByVal c As Object, ByVal msg As String) As Boolean
        Dim strRegex As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim re As Regex = New Regex(strRegex)
        If Not re.IsMatch(c.Value) Then
            showError(messageType.alert, msg)
            markField(c)
            Return True
        End If
        Return False
    End Function

    Sub markField(ByVal f As Object)
        f.Attributes.Add("style", "border:2px solid #F00;")
    End Sub

End Class