<%@ Page Language="VB" AutoEventWireup="false" CodeFile="maincat.aspx.vb" Inherits="maincat" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="catbreadcrumbs" Src="~/components/catbreadcrumbs.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidecats" Src="~/components/sidecats.ascx" %>
<%@ Register TagPrefix="modulus" TagName="maincats" Src="~/components/maincats.ascx" %>

<asp:Content ID="header" ContentPlaceHolderID="header" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">
   
   <div class="pagecont">
   <h1 class="pagetitle" style="padding-top:0px; margin:0px;">בחר קטגוריה</h1>
   <div class="clear"></div>
          <br />
          <modulus:grid ID="grid1" runat="server" colNum="3" view="cat" table_width="" />

	</div>
        

</asp:Content>