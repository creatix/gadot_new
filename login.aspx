<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">התחברות</h1></td>
  </tr>
  
  <tr>
    <td>
    
    <modulus:msgpanel id="msgpanel1" runat="server"></modulus:msgpanel>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50%" valign="top"><br /><br /><br /><%=siteLogic.Config("helptext")%></td>
    <td width="50%">
	<form id="form1" runat="server" class="formcontainer" onsubmit="return formSubmited()">
    <div class="loginpanel" style=" padding-right:0px;">
                                    
                                    <br />
                                    <br />
                                    <br />
                                    <label style="color:#666;">דוא"ל</label>
                                    <input type="text" name="loginemailtxt" id="loginemailtxt" runat="server" class="textltr" tabindex="4" />
                                    <label style="color:#666;">סיסמא &nbsp;&nbsp;&nbsp; <a href="forgotpassword.aspx">שכחת סיסמא?</a></label>
                                    <input type="password" name="loginpasswordtxt" id="loginpasswordtxt" runat="server" class="textltr" tabindex="4" />
                                    <div class="clear"></div>
                                    <br /><br /><br />
                                    <div class="clear"></div>
                                    <input type="submit" id="loginbut" runat="server" value="התחבר" class="butstyle loginpanelbut" style="right:0px; top:190px; height:40px;" />
                  <div style="padding-right:110px; padding-top:5px;">עדיין לא רשום? <a href="register.aspx"><b>הרשם</b></a></div>
          </div>
    
    </form></td>
  </tr>
  </table>

    
    
    <br /><br />




<br /><br /><br /></td>
  </tr>
  </table>
  

<br>

</asp:Content>
