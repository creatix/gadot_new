<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="register" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="basketpanel" Src="~/components/basketpanel_side.ascx" %>

<asp:Content ID="header" ContentPlaceHolderID="header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
    <script src="js/mootools-1.2.4-core-yc.js"></script>
	<script src="js/mootools-1.2.3.1-more.js"></script>
    <script src="js/ajax.js"></script>
    <script src="js/checkout.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

<form id="form1" runat="server" class="formcontainer">

<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">קופה</h1></td>
  </tr>
  </table>
  <br />
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
    <div class="sidebaskettile">
    	<h2 class="subtitle1">סל הקניות שלך</h2>
        <div><a href="basket.aspx" class="linkbut">עידכון סל קניות</a></div>
    </div>
    <div id="basketpaneldiv">
    	<modulus:basketpanel id="basketpanel1" runat="server"></modulus:basketpanel>
	</div>
    <br />
    <br />
    <%=siteLogic.Config("helptext")%>
    </td>
    <td width="30" valign="top"><img src="img/pixel.gif" width="30" height="1" /></td>
    <td width="386">
    
    	<modulus:msgpanel id="msgpanel1" runat="server" />
        
    	<div class="checkoutpaneltitle"><span class="num">1</span><span class="text">פרטי הלקוח</span><span class="link">כבר רשום? <a href="checkout.aspx">התחבר</a></span></div>
        <div class="checkoutpanel">
        	<div class="checkoutsubpanel">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" valign="top">
                            <label>שם משפחה</label>
                            <input type="text" name="lastnametxt" id="lastnametxt" runat="server" tabindex="2" />
                        </td>
                        <td width="50%" valign="top">
                            <label>שם פרטי</label>
                            <input type="text" name="firstnametxt" id="firstnametxt" runat="server" tabindex="1" />
                        </td>
                    </tr>
                    <tr>
                      <td valign="top">
                      <br />
                      <label><input type="checkbox" name="isrecevingupdatescbx" id="isrecevingupdatescbx" runat="server" tabindex="4" />&nbsp;
                        כן, ברצוני להירשם לרשימת הדיוור </label>
                            
                        </td>
                      <td valign="top">
                      <label>דואר אלקטרוני</label>
                        <input type="text" name="emailtxt" id="emailtxt" runat="server" class="textltr" tabindex="3" />
                        
                      </td>
                  </tr>
                    <tr>
                      <td valign="top">
                      <label>אישור סיסמא</label>
                         <input type="password" name="passwordconfirmtxt" id="passwordconfirmtxt" runat="server" class="textltr" tabindex="6" />
                        
                        </td>
                      <td valign="top">
                        <label>סיסמא</label>
                            <input type="password" name="passwordtxt" id="passwordtxt" runat="server" class="textltr" tabindex="5" />
                    </td>
                  </tr>
                    <tr>
                      <td valign="top">&nbsp;</td>
                      <td valign="top"><br /><input type="submit" id="registerbut" runat="server" value="המשך" class="butstyle" tabindex="7" /> </td>
                  </tr>
                </table>
                
                <div class="clear"></div>
         	</div>
        </div>
        
        <br />
        <div class="checkoutpaneltitle"><span class="num">2</span><span class="text">פרטי משלוח</span></div>
        <br />
        <div class="checkoutpaneltitle"><span class="num">3</span><span class="text">פרטי תשלום</span></div>
        
    </td>
  </tr>
  </table>
<br />


  </form>
    <br /><br />
    
</asp:Content>