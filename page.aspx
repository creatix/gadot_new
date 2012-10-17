<%@ Page Language="VB" AutoEventWireup="false" CodeFile="page.aspx.vb" Inherits="page" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="PagesHeader" Src="components/PagesHeader.ascx" %>
<%@ Register TagPrefix="modulus" TagName="pagebreadcrumbs" Src="components/pagebreadcrumbs.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" Runat="Server">
<style type="text/css">
	table,body {
		direction:rtl;
	}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" Runat="Server">
	
    <ul class="toppages">
    <modulus:PagesHeader id="PagesHeader1" runat="server" />
    </ul>
    
    <div class="clearfix"></div>
    
    <div class="pageheader">
		<h1 class="pagetitle"><%=pageRow.name%></h1>
        <modulus:pagebreadcrumbs id="pagebreadcrumbs1" runat="server" />
    </div>
    
	<br />
    <div class="pagecontent">
        <%=pageRow.content1%>
    </div>
    
</asp:Content>

<asp:Content id="leftpanel" ContentPlaceHolderID="leftpanel" runat="server">
	<img src="<%=getSiteLeftImage()%>" alt="Giga" />
</asp:Content>


