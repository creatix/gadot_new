<%@ Page Language="VB" AutoEventWireup="false" CodeFile="changedetails.aspx.vb" Inherits="changedetails" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="myaccountbar" Src="~/components/myaccountbar.ascx" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">חשבון שלי</h1></td>
  </tr>
  
  <tr>
    <td>
    
    <modulus:myaccountbar id="myaccountbar1" runat="server" />
    
    <br /><br />
    
<form id="form1" runat="server" class="formcontainer">

				<modulus:msgpanel id="msgpanel1" runat="server" />

				<table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" rowspan="5" valign="top">
                        <br /><br />
                        <%=siteLogic.Config("helptext")%>
                        </td>
                        <td width="50%" valign="top">
                            <label>שם פרטי</label>
                            <input type="text" name="firstnametxt" id="firstnametxt" runat="server" tabindex="1" />
                        </td>
                    </tr>
                    <tr>
                      <td valign="top">
                        <label>שם משפחה</label>
                        <input type="text" name="lastnametxt" id="lastnametxt" runat="server" tabindex="3" />
                      </td>
                  </tr>
                    <tr>
                      <td valign="top">
                        <label>דואר אלקטרוני</label>
                         <input type="text" name="emailtxt" id="emailtxt" runat="server" class="textltr" tabindex="5" />
                    </td>
                  </tr>
                    <tr>
                      <td valign="top">
                      <br>
                      <label><input type="checkbox" name="isrecevingupdatescbx" id="isrecevingupdatescbx" runat="server" tabindex="6" />&nbsp;
                        כן, ברצוני להירשם לרשימת הדיוור </label></td>
                    </tr>
                    <tr>
                      <td valign="top"><br /><input type="submit" id="savebut" runat="server" value="שמור פרטים" class="butstyle" /> </td>
                  </tr>
                </table>
</form>


<br /><br /></td>
  </tr>
  </table>
  

<br>

</asp:Content>
