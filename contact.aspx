<%@ Page Language="VB" AutoEventWireup="false" CodeFile="contact.aspx.vb" MasterPageFile="~/main.master" Inherits="contact" %>
<%@ Register TagPrefix="UC" TagName="PagesHeader" Src="components/PagesHeader.ascx" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

<table width="100%"  border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="40%" align="right" valign="top">
        <br /><br /><br /><br />
        <asp:Label ID="pagecontentlbl" runat="server"></asp:Label>
        
        </td>
        <td width="60%" align="right" valign="top"><table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="middle">&nbsp;</td>
            <td align="right">
                
            <h1 class="pagetitle">צור קשר</h1>
            </td>
          </tr>
          <tr>
            <td colspan="2" align="right">
            
            <br /><br />
            <form id="form1" runat="server">
            	<table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                               
                                <tr>
                                    <td align="right">
                                        <div id="divContact" visible="true" runat="server">
                                            <table border="0" cellspacing="0" cellpadding="0">
                                              <tr>
                                                <td align="right">שם פרטי</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtFirstName" runat="server" CssClass="inputstyle"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right">שם משפחה</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtLastName" runat="server" CssClass="inputstyle"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right">דוא"ל</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtEmail" runat="server" CssClass="inputstyle"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right">בבית</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtPhone" runat="server" CssClass="inputstyle"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right">נושא</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtSubject" runat="server" CssClass="inputstyle"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right">תוכן</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="4" CssClass="inputstyle" style=" height:100px;"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td align="right">&nbsp;</td>
                                              </tr>
                                              <tr>
                                                <td align="right"><asp:Button ID="btnSend" runat="server"  Text="שלח" CssClass="butstyle" /></td>
                                              </tr>
                                            </table>
                                            
                              </div>
                                        <div style="text-align:center;"> <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label> </div>
                                        <div id="divMessage" runat="server" visible="false" style="color:#000000;font-size:16px;text-align:center;color:#179c2d;">
                                            תודה על פנייתך.
                                            
                                            <!-- Google Code for contac us Conversion Page -->
<script type="text/javascript">
/* <![CDATA[ */
var google_conversion_id = 998203271;
var google_conversion_language = "iw";
var google_conversion_format = "2";
var google_conversion_color = "ffffff";
var google_conversion_label = "GjnoCMnU8QEQh7_92wM";
var google_conversion_value = 0;
if (2) {
  google_conversion_value = 2;
}
/* ]]> */
</script>
<script type="text/javascript" src="http://www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="http://www.googleadservices.com/pagead/conversion/998203271/?value=2&amp;label=GjnoCMnU8QEQh7_92wM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>


                                        </div>
                                    </td>
                                </tr>                                                               
              </table>
              </form>
            <br />
            
            </td>
          </tr>
          <tr>
            <td colspan="2">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
  </table>
    
<script type="text/javascript">
    function f(Name) {
        if (Name == "הצטרפות לחוזה אחזקה")
            document.location = "Maintenance.aspx";
    }
</script>
<script>
    function OpenAttachment() {
        document.getElementById('divAttachment').style.display = 'block';
    }
</script>
</asp:Content>
