<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As productsRow
</script>

<a href="<%=pageLogic.GetLink("product", dataSource.productsid, dataSource.name, "")%>" class="pthumb" style="width:140px;">
	<img src="components/img.aspx?img=images\<%=dataSource.pic%>&width=140&height=140" width="140" height="140" border="0" alt="<%=server.HtmlEncode(dataSource.name)%>" />
    <div class="sn"><%=dataSource.name%></div>
    <div class="pp"><span><%=siteLogic.currency%></span><%=String.Format("{0:#,###}", dataSource.finalprice)%></div>
</a>

