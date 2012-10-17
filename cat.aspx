<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cat.aspx.vb" Inherits="cat" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="sidecats" Src="~/components/sidecats.ascx" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %>
<%@ Register TagPrefix="modulus" TagName="catbreadcrumbs" Src="~/components/catbreadcrumbs.ascx" %>

<asp:Content ID="header" ContentPlaceHolderID="header" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<div class="leftsection">
    	<modulus:catbreadcrumbs ID="catbreadcrumbs1" runat="server" />
    	<h1 class="pagetitle"><%=catitem.name%></h1>
        <br />
		<modulus:grid ID="grid1" runat="server" showPaging="true" colnum="3" table_width="" />
	</div>
    
    <div class="rightsection">
		<modulus:sidecats ID="sidecats1" runat="server" />
	</div>
    
</asp:Content>





