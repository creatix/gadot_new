
Partial Class changepassword
    Inherits BasePage

    Dim userRow As usersRow
    Dim _usersAdapter As New usersAdapter
    Dim _fieldLogic As New fieldLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _userLogic As New userLogic
        userRow = _userLogic.getLoggedUser()
        If userRow Is Nothing Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub savebut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebut.ServerClick
        If _fieldLogic.isEmptyField(oldpasswordtxt, "אנא הכנס סיסמא ישנה") Then
            Exit Sub
        End If
        If _fieldLogic.isEmptyField(newpasswordtxt, "אנא הכנס סיסמא חדשה") Then
            Exit Sub
        End If
        If _fieldLogic.isEmptyField(newpasswordcomfirmationtxt, "אנא הכנס אימות סיסמא חדשה") Then
            Exit Sub
        End If
        If _fieldLogic.isEquelField(newpasswordtxt, newpasswordcomfirmationtxt, "שדה אימות הסיסמא לא תואם לסיסמא") Then
            Exit Sub
        End If
        Dim _encryptionLogic As New encryptionLogic
        If oldpasswordtxt.Value <> _encryptionLogic.Decrypt(userRow.password) Then
            _fieldLogic.showError("error", "שדה הסיסמא הישנה לא תואם לסיסמא")
            Exit Sub
        End If
        userRow.password = _encryptionLogic.Encrypt(newpasswordtxt.Value)
        _usersAdapter.Update(userRow)
        _fieldLogic.showError("success", "הפרטים נשמרו בהצלחה")
    End Sub

End Class
