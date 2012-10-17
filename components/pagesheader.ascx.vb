Imports cs3

Partial Class components_pagesheader
    Inherits System.Web.UI.UserControl

    Public table As tableLogic.tableAdapter
    Dim page_name As String = ""
    Dim page_id As String = ""
    Dim firstlevel As System.Data.DataTable
    Dim _pagesAdapter As New pagesAdapter
    Dim pagesTree As pList(Of pagesRow)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        page_id = Request("id")
        loadpages()

    End Sub

    Sub loadpages()

        If Not IsNumeric(page_id) Then
            Exit Sub
        End If

        Dim _pageLogic As New pageLogic
        pagesTree = _pageLogic.getPageTree(page_id)
        rptPages.DataSource = _pagesAdapter.GetList("fatherid=" & pagesTree(pagesTree.Count - 1).pagesid & " AND isnull(hide, 0) <> 1", "sort")
        rptPages.DataBind()

    End Sub

    Public Function GetTabClass(ByVal PageName As String, ByVal pagesid As String) As String
        If PageName = "home" And page_name = "index.aspx" Then
            Return "class='CurrentTab'"
        Else
            If pagesid = page_id Then
                Return "class='CurrentTab'"
            Else
                Return "class='topbut'"
            End If
        End If
    End Function

    Public Function GetClass(ByVal title As String) As String
        If title = "Home" Then
            Return "class='first'"
        Else
            Return ""
        End If

    End Function

    Public Function getCatsNav(ByVal pagesid As Integer) As String

        If pagesid <> 31 Then
            Return ""
        End If

        Dim str As String = ""
        table = New tableLogic.tableAdapter("cats")
        Dim catslist As tableLogic.tableList = table.GetList("fatherid=0", "sort")
        Dim i As Integer

        For i = 0 To catslist.Rows.Count - 1
            str &= "<li><a href=""" & pageLogic.GetLink("cat", catslist.Rows(i)("catsid"), catslist.Rows(i)("name"), "") & """>" & catslist.Rows(i)("name") & "</a></li>"
        Next

        Return "<div class=""drop""><ul>" & str & "</ul></div>"

    End Function

    Public Function GetSubPages(ByVal PagesID As String) As String

        Dim str As String = ""
        Dim pagesList As List(Of pagesRow) = _pagesAdapter.GetList("fatherid=" & PagesID & " AND isnull(hide, 0) <> 1", "sort")
        For Each page As pagesRow In pagesList
            str &= "<li><a href=""" & pageLogic.GetLink("page", page.pagesid, page.name, page.page_link) & """ id='sub_style'>" & page.title & "</a></li>"
        Next

        If str <> "" Then
            str = "<ul>" & str
            str = str & "</ul>"
        End If

        Return str

    End Function

    Public Function GetCats(ByVal PagesID As String) As String

        If PagesID <> "43" Then
            Return ""
        End If

        Dim str As String = ""
        Dim _catsAdapter As New catsAdapter
        Dim catsList As List(Of catsRow) = _catsAdapter.GetList("fatherid=0", "sort")
        For Each cat As catsRow In catsList
            str &= "<li><a href=""" & pageLogic.GetLink("cat", cat.catsid, cat.name, "") & """ id='sub_style'>" & cat.name & "</a></li>"
        Next

        If str <> "" Then
            str = "<ul>" & str
            str = str & "</ul>"
        End If

        Return str

    End Function

End Class
