Imports cs3.tableLogic

Partial Class components_sidecats
    Inherits System.Web.UI.UserControl

    Public catid As Integer = 0
    Dim _catsAdapter As New catsAdapter
    Dim _catLogic As New catLogic
    Dim catTree As pList(Of catsRow)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadCats()

    End Sub

    Sub loadCats()

        If catid = 0 Then
            If IsNumeric(Request("id")) Then
                catid = Request("id")
            End If
        End If

        catTree = _catLogic.getCatTree(catid)

        If catTree.Count = 0 Then
            'Exit Sub
        End If

        Dim tl As pList(Of catsRow) = _catsAdapter.GetList("fatherid=0", "isnull(sort,1000)", , 50) '_catsAdapter.GetList("fatherid=" & catTree(catTree.Count - 1).catsid, "isnull(sort,1000)")
        catsRepeater.DataSource = tl
        catsRepeater.DataBind()

    End Sub

    Function getSubCats(ByVal _catid As Integer, ByVal level As Integer) As String
        If Not isReletive(_catid) Then
            Return ""
        End If
        Dim str As String = ""
        Dim tl As pList(Of catsRow) = _catsAdapter.GetList("fatherid=" & _catid & "", "isnull(sort,1000)", , 50)
        For Each p As catsRow In tl
            Dim c As String = "subcatlink"
            If IsNumeric(_catid) Then
                If p.catsid = catid Then
                    c = "subcatlinkselected"
                End If
            End If
            str &= "<li class=""" & c & """><a href=""" & pageLogic.GetLink("cat", p.catsid, p.name, "") & """>" & p.name & "</a></li><div class=""clear""></div>"
            str &= getSubCats(p.catsid, level + 1)
        Next
        If str = "" Then
            Return ""
        End If
        Return "<ul>" & str & "</ul>"
    End Function

    Function isReletive(ByVal catid As Integer) As Boolean
        For Each cat As catsRow In catTree
            If catid = cat.catsid Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function removebottomline(ByVal id As Integer) As String
        If id = catsRepeater.DataSource(catsRepeater.DataSource.count - 1).catsid Then
            Return "style=""background:none;"""
        End If
        Return ""
    End Function

    Public Function getselected(ByVal id As String) As String
        If catid = id Then
            Return "class=""subcatlinkselected"""
        End If
        Return ""
    End Function

    Public Function getlast(ByVal id As Integer) As String
        If id = catid Then
            Return "class=""subcatlinkselected"""
        End If
        If id = catsRepeater.DataSource(catsRepeater.DataSource.count - 1).catsid Then
            Return "class=""last"""
        End If
        If id = catsRepeater.DataSource(0).catsid Then
            Return "class=""first"""
        End If
        Return ""
    End Function

End Class
