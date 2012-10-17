<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" MasterPageFile="Main.master" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %>
<%@ Register TagPrefix="modulus" TagName="bannerslideshow" Src="~/components/bannerslideshow.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<div class="si">
    	<modulus:banner id="bannerslideshow1" runat="server" bannerName="באנר עמוד ראשי" width="682" height="258" />
    	
    </div>
      <div class="details clearfix">
        <div class="details_left">
          <h2><img src="img/img1.png" alt="" align="absmiddle" />&nbsp;פרוייקטים </h2>
          <p>בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה </p>
          <a href="#">לפרטים נוספים</a></a> </div>
        <div class="details_right">
          <h2><img src="img/img2.png" alt="" align="absmiddle" />&nbsp;ההתמחות שלנו</h2>
          <p>בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה </p>
          <a href="#">לפרטים נוספים</a></a> </div>
      </div>
      <div class="boder">&nbsp;</div>
      <div class="details clearfix">
        <div class="details_left">
          <h2><img src="img/img3.png" alt="" align="absmiddle" />&nbsp;בואו להצטרף</h2>
          <p>בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה </p>
          <a href="#">לפרטים נוספים</a></a> </div>
        <div class="details_right">
          <h2><img src="img/img4.png" alt="" align="absmiddle" />&nbsp;הלקוחות שלנו</h2>
          <p>בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה בלה </p>
          <a href="#">לפרטים נוספים</a></a> </div>
      </div>
    
    
</asp:Content>
