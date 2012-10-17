<%@ Page Language="VB" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="changepassword" MasterPageFile="~/main.master" %>
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
                            <label>סיסמא ישנה</label>
                            <input type="text" name="oldpasswordtxt" id="oldpasswordtxt" runat="server" tabindex="1" />
                        </td>
                    </tr>
                    <tr>
                      <td valign="top">
                        <label>סיסמא חדשה</label>
                        <input type="text" name="newpasswordtxt" id="newpasswordtxt" runat="server" tabindex="3" />
                      </td>
                  </tr>
                    <tr>
                      <td valign="top">
                        <label>אימות סיסמא חדשה</label>
                         <input type="text" name="newpasswordcomfirmationtxt" id="newpasswordcomfirmationtxt" runat="server" class="textltr" tabindex="5" />
                    </td>
                  </tr>
                    
                    <tr>
                      <td valign="top"><br /><input type="submit" id="savebut" runat="server" value="עדכן סיסמא" class="butstyle" /> </td>
                  </tr>
                </table>
</form>


<br /><br /></td>
  </tr>
  </table>
  

<br>

</asp:Content>
