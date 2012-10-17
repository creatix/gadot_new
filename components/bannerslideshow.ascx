<%@ Control Language="VB" AutoEventWireup="false" CodeFile="bannerslideshow.ascx.vb" Inherits="components_bannerslideshow" %>
<asp:Literal ID="bannercontainer" runat="server"></asp:Literal>

<% if bannersList.count > 0 then %>
<div style="position:relative;">
    <a href="<%=bannersList(0).link%>" id="loaderdivPictures" style="position:absolute; left:0px; overflow:hidden; width:<%=width%>px; height:<%=height%>px; z-index:12; display:block;"></a>
    <a href="<%=bannersList(0).link%>" id="divPictures" style="overflow:hidden; width:<%=width%>px; height:<%=height%>px; display:block; position:relative; z-index:11;" ><img id="imgPictures" src="images/<%=bannersList(0).pic%>" width="<%=width%>" height="<%=height%>" /></a>
    <div id="bannernav" style="position:absolute; bottom:20px; left:20px; z-index:13;"></div>
</div>

<asp:Literal ID="ltrPictures" runat="server"></asp:Literal>

<script type="text/javascript" src="js/bannerslideshow.js"></script>

<% end if %>
