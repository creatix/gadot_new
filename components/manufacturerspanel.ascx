<%@ Control Language="VB" AutoEventWireup="false" CodeFile="manufacturerspanel.ascx.vb" Inherits="components_manufacturerspanel" %>

<ul>
    <asp:Repeater ID="manrep" runat="server">
        <itemtemplate>
            <li><a href="cat.aspx?man=<%#Eval("name")%>" onmouseover="Pixastic.revert(document.getElementById('man<%#Eval("manufacturersid")%>'));" onmouseout="Pixastic.process(document.getElementById('man<%#Eval("manufacturersid")%>'), 'desaturate');"><img src="components/img.aspx?img=images\<%#Eval("logo")%>&width=70&height=70" alt="<%#Eval("name")%>" title="<%#Eval("name")%>" id="man<%#Eval("manufacturersid")%>"></a></li>

			<script type="text/javascript" >  
                //jsImageFX.doImage(document.getElementById("man<%#Eval("manufacturersid")%>"), "desaturate");
				Pixastic.process(document.getElementById('man<%#Eval("manufacturersid")%>'), "desaturate");
            </script>

        </itemtemplate>
    </asp:Repeater>
</ul>