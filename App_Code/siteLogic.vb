Imports cs3.DataLayer
Imports System.IO
Imports System.Reflection
Imports System.Xml

Public Class siteLogic

    Public Shared currency As String = "₪"

    Public Shared Function Config() As Dictionary(Of String, String)
        If HttpContext.Current.Cache("siteconfig") Is Nothing Then
            Dim _config As New Dictionary(Of String, String)
            Dim _settingsAdapter As New settingsAdapter
            Dim settingsList As List(Of settingsRow) = _settingsAdapter.GetList(, , , 0)
            For Each setting As settingsRow In settingsList
                _config.Add(setting.name, setting.value)
            Next
            Dim dep As New CacheDependency(HttpContext.Current.Server.MapPath("images\updateCache.txt"))
            HttpContext.Current.Cache.Insert("siteconfig", _config, dep)
        End If
        Return HttpContext.Current.Cache("siteconfig")
    End Function

    Function getSiteTemplate() As String
        Dim template As String = "default"
        If HttpContext.Current.Request("tf") <> "" Then
            Return HttpContext.Current.Request("tf")
        End If
        If siteLogic.Config.ContainsKey("templatefolder") Then
            template = siteLogic.Config("templatefolder")
        Else
            If IsNumeric(siteLogic.Config("template")) Then
                Dim _templatesAdapter As New templatesAdapter
                Dim templateObj As templatesRow = _templatesAdapter.GetItem(siteLogic.Config("template"))
                If Not templateObj Is Nothing Then
                    template = templateObj.folder
                    siteLogic.Config("templatefolder") = template
                End If
            End If
        End If
        Return template
    End Function

    Function getSiteCSS() As String
        If HttpContext.Current.Request("ts") <> "" Then
            Return "sitestyle_" & HttpContext.Current.Request("ts") & ".css"
        End If
        Return siteLogic.Config("sitecss")
    End Function

End Class

Public Class URLRewriterConfig
    Implements IConfigurationSectionHandler

    Public Function Create(parent As Object, configContext As Object, section As System.Xml.XmlNode) As Object Implements System.Configuration.IConfigurationSectionHandler.Create
        Return section
    End Function

End Class


Public Class URLRewriter
    Implements IHttpModule

    Public Sub Init(ByVal inst As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
        AddHandler inst.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub

    Public Sub OnBeginRequest(ByVal app As Object, ByVal e As EventArgs)

        Dim oRewriter As Object = System.Configuration.ConfigurationManager.GetSection("urlrewrites")
        Dim zPath As String = HttpContext.Current.Request.Path
        Dim pathextension As String = Path.GetExtension(zPath)
        If (pathextension <> ".aspx" And pathextension <> "") Or zPath.IndexOf("/components") > -1 Then
            Exit Sub
        End If
        Dim zSubst As String = ""
        Dim oReg As Regex
        For Each oNode As XmlNode In oRewriter.SelectNodes("rule")
            oReg = New Regex(oNode.SelectSingleNode("url/text()").Value)
            Dim oMatch As Match = oReg.Match(zPath)
            If oMatch.Success Then
                zSubst = oReg.Replace(zPath, oNode.SelectSingleNode("rewrite/text()").Value)
                Exit For
            End If
        Next

        If zSubst.Length = 0 Then
            zSubst = getDynamicTransferPage(zPath.ToLower())
        End If

        If (zSubst.Length > 0) Then
            Dim sign As String = ""
            If zSubst.IndexOf("?") > -1 Then
                sign = "&"
            Else
                sign = "?"
            End If
            HttpContext.Current.RewritePath(zSubst & sign & HttpContext.Current.Request.QueryString.ToString())
        End If

    End Sub

    Function getDynamicTransferPage(ByVal pageName As String) As String
        Dim dataTableAdapter As New TableAdapter
        Dim pageid As Integer = dataTableAdapter.ExecuteScalar(Data.CommandType.Text, "SELECT TOP 1 isnull(pagesid,0) FROM pages WHERE url='" & Path.GetFileNameWithoutExtension(pageName.ToLower()) & "'")
        If pageid > 0 Then
            Return "page.aspx?id=" & pageid
        End If
        Return ""
    End Function

    Public Sub Dispose() Implements System.Web.IHttpModule.Dispose

    End Sub

End Class

Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnPreInit(e As EventArgs)
        Exit Sub
        Dim _siteLogic As New siteLogic
        Dim template As String = _siteLogic.getSiteTemplate()
        Me.MasterPageFile = "~\templates\" & template & "\layouts\main.master"
        Dim sitecss As String = _siteLogic.getSiteCSS()
        If sitecss <> "" Then
            DirectCast(Me.Master.FindControl("maincss"), System.Web.UI.HtmlControls.HtmlLink).Href = "~/templates/" & template & "/css/" & sitecss
        End If
        MyBase.OnPreInit(e)
    End Sub

End Class