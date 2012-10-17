<%@ Page Language="VB" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="productslist" Src="~/components/productslist.ascx" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="catbreadcrumbs" Src="~/components/catbreadcrumbs.ascx" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">
   
       <div class="clear"></div>

        <h1 class="pagetitle" style="text-align:right;"><%=getPageName()%></h1>
        
        <br /><br />
        
        <section class="main_product">
        	<modulus:msgpanel id="msgpanel1" runat="server" />
        	<modulus:productslist ID="productslist1" runat="server" view="product" colnum="4" />
        </section>
        
        

</asp:Content>