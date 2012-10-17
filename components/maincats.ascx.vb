Imports cs3.tableLogic

Partial Class components_maincats
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadCats()

    End Sub

    Sub loadCats()

        Dim cats As New catsAdapter

        catsRepeater.DataSource = cats.GetList("fatherid=0", "isnull(sort,1000)", , 50)
        catsRepeater.DataBind()

    End Sub

    Public Function GetCats(ByVal catID As String) As String

        Dim str As String = ""
        Dim _catsAdapter As New catsAdapter
        Dim catsList As List(Of catsRow) = _catsAdapter.GetList("fatherid=" & catID, "isnull(sort,1000)")
        For Each cat As catsRow In catsList
            str &= "<li><a href=""" & pageLogic.GetLink("cat", cat.catsid, cat.name, "") & """ id='sub_style'>" & cat.name & "</a></li>"
        Next

        If str <> "" Then
            str = "<ul>" & str
            str = str & "</ul>"
        End If

        Return str

    End Function

    Public Function getselected(ByVal id As Integer) As String
        If IsNumeric(Request("id")) Then
            If Request("id") = id Then
                Return "class=""s"""
            End If
        End If
        Return ""
    End Function

End Class
