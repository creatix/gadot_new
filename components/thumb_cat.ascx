<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As catsRow
</script>


<a href="<%=pageLogic.GetLink("cat", dataSource.catsid, dataSource.name, "")%>" class="catthumb">
	<img src="components/img.aspx?img=images\<%=dataSource.pic%>&width=202&height=202" width="202" height="202" border="0" alt="<%=server.HtmlEncode(dataSource.name)%>" />
	<div><%=dataSource.name%></div>
</a>
<br />
