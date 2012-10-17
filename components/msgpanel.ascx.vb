
Partial Class components_msgpanel
    Inherits System.Web.UI.UserControl

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        msglbl.Text = ""
        getMsg("errormsg")
        getMsg("successmsg")
        getMsg("notifymsg")

    End Sub

    Sub getMsg(ByVal msgtype As String)
        Dim msgstr As String = ""
        Dim classstr As String = ""
        If Session(msgtype) <> "" Then
            msgstr = Session(msgtype)
            classstr = msgtype
            Session(msgtype) = ""
        End If
        If msgstr <> "" Then
            msglbl.Text &= "<div class=""" & classstr & """>" & msgstr & "</div><br />"
        End If
    End Sub

End Class
