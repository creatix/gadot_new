<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As productsRow
</script>

<a href="<%=pageLogic.GetLink("product", dataSource.productsid, dataSource.name, "")%>" style="text-decoration:none;" class="pthumb">
	<div class="p"><img src="components/img.aspx?img=images\<%=dataSource.pic%>&width=202&height=202" width="202" height="202" border="0" alt="<%=server.HtmlEncode(dataSource.name)%>" /></div>
    <div class="n"><%=pageLogic.getEditableDataField("products", "name", dataSource.productsid, dataSource.name)%></div>
    <div class="sd"><%=pageLogic.getEditableDataField("products", "shortdescription", dataSource.productsid, dataSource.shortdescription)%></div>
    <div class="pp"><span><%=siteLogic.currency%></span><%=pageLogic.getEditableDataField("products", "price", dataSource.productsid, dataSource.price)%></div>
    <div class="b">לפרטים</div>
    <div class="clear"></div>
</a>


