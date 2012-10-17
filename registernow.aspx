<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="register" MasterPageFile="~/inner.master" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
    <script src="js/mootools-1.2.4-core-yc.js"></script>
	<script src="js/mootools-1.2.3.1-more.js"></script>
    <script src="js/ajax.js"></script>
    <script src="js/checkout.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle1">הרשמה</h1></td>
  </tr>
  
  <tr>
    <td>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
  <td width="50%" valign="top">
  <br /><Br /><Br /><Br /><Br />
  <%=siteLogic.Config("helptext")%></td>
    <td width="50%">
    <br><br><br>
    <modulus:msgpanel id="msgpanel1" runat="server" />
    <form id="form1" runat="server" class="formcontainer">
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
                            <label>סיסמא</label>
                            <input type="password" name="passwordtxt" id="passwordtxt" runat="server" class="textltr" tabindex="4" />
                        </td>
                      <td valign="top">
                        <label>דואר אלקטרוני</label>
                        <input type="text" name="emailtxt" id="emailtxt" runat="server" class="textltr" tabindex="3" />
                      </td>
                  </tr>
                    <tr>
                      <td valign="top">
                      <label>אימות סיסמא</label>
                         <input type="password" name="passwordconfirmtxt" id="passwordconfirmtxt" runat="server" class="textltr" tabindex="5" />
                        
                        </td>
                      <td valign="top">
                        <br /><label><input name="isrecevingupdatescbx" type="checkbox" id="isrecevingupdatescbx" tabindex="6" checked="checked" runat="server" />&nbsp;
                        כן, ברצוני להירשם לרשימת הדיוור </label>
                    </td>
                  </tr>
                    <tr>
                      <td colspan="2" valign="top"><br /><input type="submit" id="registerbut" runat="server" value="הרשם" class="butstyle" />  &nbsp;&nbsp; כבר רשום? <a href="login.aspx">התחבר</a> </td>
                  </tr>
                </table>
    
    <input type="hidden" id="resultpage" name="resultpage" value="registernow.aspx?success=true" />
    
    </form></td>
    
  </tr>
  </table>

    
    
    <br /><br />




<br /><br /><br /></td>
  </tr>
  </table>
  

<br>

</asp:Content>