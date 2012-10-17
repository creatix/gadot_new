
Partial Class register
    Inherits BasePage

    Dim _fieldLogic As New fieldLogic
    Dim _userLogic As New userLogic
    Dim _usersAdapter As New usersAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub registerbut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles registerbut.ServerClick
        If Not checkUserFields() Then
            Exit Sub
        End If
        Dim userRow As usersRow = insertUser()
        If userRow.usersid = 0 Then
            _fieldLogic.showError("error", "אירעה שגיאה בהכנסת פרטי הלקוח - אנא נסה שוב")
            Exit Sub
        End If
        _userLogic.setLoggedUser(userRow)
        Response.Redirect("checkout.aspx")
    End Sub

    Function insertUser() As usersRow
        Dim _encryptionLogic As New encryptionLogic
        Dim newUser As New usersRow
        newUser.rowState.setState(RowState.Inserted)
        newUser.firstname = firstnametxt.Value
        newUser.lastname = lastnametxt.Value
        newUser.email = emailtxt.Value
        newUser.password = _encryptionLogic.Encrypt(passwordtxt.Value)
        If isrecevingupdatescbx.Checked Then
            newUser.isrecevingupdates = 1
        Else
            newUser.isrecevingupdates = 0
        End If
        newUser.usersid = _usersAdapter.Insert(newUser)
        Return newUser
    End Function

    Function checkUserFields() As Boolean
        If _fieldLogic.isEmptyField(firstnametxt, "אנא הכנס שם פרטי") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(lastnametxt, "אנא הכנס שם משפחה") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(emailtxt, "אנא הכנס אימייל") Then
            Return False
        End If
        If _fieldLogic.isEmail(emailtxt, "אנא הכנס אימייל תקין") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(passwordtxt, "אנא הכנס סיסמא") Then
            Return False
        End If
        If _fieldLogic.isEquelField(passwordtxt, passwordconfirmtxt, "שדה אישור הסיסמא אינו תואם לסיסמא") Then
            Return False
        End If
        If _usersAdapter.GetList("email='" & emailtxt.Value.Replace("'", "''") & "'").Count > 0 Then
            _fieldLogic.showError("error", "דואר אלקטרוני זה נמצא כבר באתר")
            _fieldLogic.markField(emailtxt)
            Return False
        End If
        Return True
    End Function

End Class
