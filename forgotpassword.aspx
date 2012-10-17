<%@ Page Language="VB" AutoEventWireup="false" CodeFile="forgotpassword.aspx.vb" Inherits="forgotpassword" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">הזכרת סיסמא</h1></td>
  </tr>
  
  <tr>
    <td>
    
    <modulus:msgpanel id="msgpanel1" runat="server"></modulus:msgpanel>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50%"><%=siteLogic.Config("helptext")%></td>
    <td width="50%"><form id="form1" runat="server" class="formcontainer" onsubmit="return formSubmited()">
    <div class="loginpanel" style=" padding-right:0px;">
                                    
                                    <br />
                                    <br />
                                    <br />
                                    <label>אימייל</label>
                                    <input type="text" name="loginemailtxt" id="loginemailtxt" runat="server" class="textltr" tabindex="4" />
                                    
                                    <br /><br />
                                    <input type="submit" id="sendbut" runat="server" value="שלח" class="butstyle loginpanelbut" style="right:0px;" />
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
