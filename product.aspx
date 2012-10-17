<%@ Page Language="VB" AutoEventWireup="false" CodeFile="product.aspx.vb" Inherits="product" MasterPageFile="~/Main.master" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="catbreadcrumbs" Src="~/components/catbreadcrumbs.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidecats" Src="~/components/sidecats.ascx" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="paramslist" Src="~/components/paramslist.ascx" %>

<asp:Content ID="header" ContentPlaceHolderID="header" runat="server">
	<link rel="stylesheet" href="css/milkbox.css" type="text/css" media="screen" />
	<script type="text/javascript" src="js/product.js"></script>
    <script type="text/javascript" src="js/mootools-core-1.3.js"></script> 
	<script type="text/javascript" src="js/mootools-more.js"></script> 
	<script type="text/javascript" src="js/milkbox-yc.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<modulus:msgpanel id="msgpanel1" runat="server" />
    
	<asp:Panel ID="productPanel1" runat="server">
    
	<div class="leftsection">
    	<div class="producttextpanel">
            <modulus:catbreadcrumbs ID="catbreadcrumbs1" runat="server" />
            <h1 class="pagetitle"><%=pageLogic.getEditableDataField("products", "name", productRow.productsid, productRow.name)%></h1>
            <br />
            <div class="pricepanel">
            	<div class="p"><span><%=siteLogic.currency%></span><%=String.Format("{0:#,###}", productRow.finalprice)%></div>
              	<% if productRow.originalprice > 0 then %>
                	<div class="op"><s><span><%=siteLogic.currency%></span><%=String.Format("{0:#,###}", productRow.originalprice)%></s></div>
                <% end if %>
                <div class="t"><%=pageLogic.getEditableDataField("products", "description", productRow.productsid, productRow.description)%></div>
                <div class="clear"></div>
                <br />
                <a href="javascript:addToBasket(<%=productRow.productsid%>);" class="butstyle"><img src="img/plussign.gif" width="11" height="11" border="0" /> קנה עכשיו</a>
            </div>
        </div>
		<div class="productpicpanel">
        	<div id="mainpic"><a href="#" onclick="return showpic();" title="<%=productRow.name%>" class="bigpic"><img src="components/img.aspx?img=images\<%=productRow.pic%>&width=381&height=381" width="381" height="381" /></a></div>
        	<ul class="imglist"><%=getImages()%></ul>
        </div>
        
        <div class="clear"></div>
        
        <div id="tabspanel">
            <ul>
               
                <li><a href="javascript:selectTab(1);" id="tabbut1">מפרט המוצר</a></li>
                <li><a href="javascript:selectTab(2);" id="tabbut2">פרטים נוספים</a></li>
            </ul>
            <div class="content">
                <div id="tabcontent1" style="display:none;"><modulus:paramslist id="paramslist1" runat="server" /></div>
                <div id="tabcontent2" style="display:none;"><%=pageLogic.getEditableDataField("products", "description1", productRow.productsid, productRow.description1)%></div>
                <div class="clear"></div>
            </div>
        	<div class="footer"></div>
    	</div>
        
        <% if Not grid1.datasource is nothing then %>
        <br />
        <h2 class="pagetitle">מוצרים נלווים</h2><br />
        <modulus:grid id="grid1" runat="server" view="related" colNum="4" table_width="" />
        <% end if %>
        
	</div>
    
    <div class="rightsection">
		<modulus:sidecats ID="sidecats1" runat="server" />
	</div>
    
    <script>
		initTabs();
    </script>
    
  </asp:Panel>
  
</asp:Content>