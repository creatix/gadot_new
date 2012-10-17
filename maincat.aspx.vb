
Partial Class maincat
    Inherits BasePage

    Dim catid As String = ""
    Dim catitem As catsRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        catid = Request("id")

        If Not IsNumeric(catid) Then
            'Exit Sub
            catid = 0
        End If

        loadCats()
        loadCat()

        If grid1.dataSource.count = 0 Then
            Response.Redirect(pageLogic.GetLink("cat", catitem.catsid, catitem.name, ""))
        End If

    End Sub

    Sub loadCats()
        Dim _catsAdapter As New catsAdapter
        grid1.dataSource = _catsAdapter.GetList("fatherid=" & catid, "isnull(sort,1000)", , 50)
    End Sub

    Sub loadCat()

        Dim catA As New catsAdapter
        catitem = catA.GetItem(CInt(catid))
        Page.Title = siteConfig.siteTitle & " - " & catitem.name

    End Sub

End Class
