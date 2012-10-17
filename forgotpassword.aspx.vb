
Partial Class forgotpassword
    Inherits BasePage

    Public _userLogic As New userLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub sendbut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendbut.ServerClick
        If Not _userLogic.sendPasswordReminder(loginemailtxt.Value) Is Nothing Then
            Dim _fieldLogic As New fieldLogic
            _fieldLogic.showError(fieldLogic.messageType.success, "הסיסמא שלך נשלחה למייל בהצלחה.")
        End If
    End Sub

End Class
