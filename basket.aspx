<%@ Page Language="VB" AutoEventWireup="false" CodeFile="basket.aspx.vb" Inherits="basket" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="basketpanel" Src="~/components/basketpanel.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

    <h1 class="pagetitle">סל קניות</h1>
    <br /><br />
    <modulus:basketpanel id="basketpanel1" runat="server" showCheckoutBut="True"></modulus:basketpanel>

</asp:Content>