Imports cs3.tableLogic

Partial Class product
    Inherits BasePage

    Dim productid As String = ""
    Dim productsA As New productsAdapter
    Dim _fieldLogic As New fieldLogic
    Public productRow As productsRow
    Public catRow As catsRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        productid = Request("id")
        productPanel1.Visible = False

        If Not IsNumeric(productid) Then
            Exit Sub
        End If

        loadProduct()

    End Sub

    Sub loadProduct()
        productRow = productsA.GetItem(CInt(productid))
        If productRow.name = "" Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "פרטי המוצר לא נמצאו. <a href=""index.aspx"">לחץ כאן</a> לחזרה לאתר")
            Exit Sub
        End If
        loadCat()
        setPageTitle()
        If productRow.relatedproducts <> "" Then
            If productRow.relatedproducts.EndsWith(",") Then productRow.relatedproducts = productRow.relatedproducts.Substring(0, productRow.relatedproducts.Length - 1)
            grid1.dataSource = productsA.GetList("productsid IN(" & productRow.relatedproducts & ")")
            grid1.DataBind()
        End If
        sidecats1.catid = productRow.catid
        productPanel1.Visible = True
        paramslist1.catid = productRow.catid
        paramslist1.productid = productRow.productsid
    End Sub

    Sub loadCat()
        If productRow Is Nothing Then Exit Sub
        Dim catsA As New catsAdapter
        catRow = catsA.GetItem(CInt(productRow.catid))
        catbreadcrumbs1.catid = catRow.catsid
    End Sub

    Public Function getImages() As String
        Dim str As String = ""
        If productRow.pic <> "" Then
            str &= getImage(0, productRow.pic, productRow.name)
        End If
        If productRow.pic1 <> "" Then
            str &= getImage(1, productRow.pic1, productRow.name)
        End If
        If productRow.pic2 <> "" Then
            str &= getImage(2, productRow.pic2, productRow.name)
        End If
        If productRow.pic3 <> "" Then
            str &= getImage(3, productRow.pic3, productRow.name)
        End If
        If productRow.pic4 <> "" Then
            str &= getImage(4, productRow.pic4, productRow.name)
        End If
        Return str
    End Function

    Function getImage(ByVal index As Integer, ByVal pic As String, ByVal name As String) As String
        Return "<li><a onclick=""return showthumb(" & index & ",'" & pic & "','" & name & "');""><img src=""components/img.aspx?img=images\" & pic & "&width=40&height=40"" alt=""" & name & """ width=""40"" height=""40"" border=""0"" style=""float:left;"" /></a><a href=""components/img.aspx?img=images\" & pic & "&width=600"" rel=""milkbox[gall1]"" title=""" & name & """ style=""display:none;""></a></li>"
    End Function

    Sub setPageTitle()
        If Not catRow Is Nothing And Not productRow Is Nothing Then
            Dim pl As New pageLogic
            If productRow.metatitle = "" Then
                productRow.metatitle = productRow.name
            End If
            pl.setPageTitle(productRow.metatitle, productRow.metadescription, productRow.metakeywords, Page)
            pl.addCanonical(pageLogic.GetLink("product", productRow.productsid, productRow.name), Page)
        End If
    End Sub

End Class
