<%@ Control Language="VB" AutoEventWireup="false" CodeFile="paramslist.ascx.vb" Inherits="components_paramslist" %>
<% if paramsRepeater.datasource.count > 0 then %>
<table cellpadding="8" cellspacing="2" border="0" class="paramstable" width="100%">
    <asp:Repeater ID="paramsRepeater" runat="server">
        <ItemTemplate>
            <tr class="odd">
                <%#getParamRow(Eval("paramsstructureid"), Eval("value"))%>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="even">
            	<%#getParamRow(Eval("paramsstructureid"), Eval("value"))%>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>
<% end if %>