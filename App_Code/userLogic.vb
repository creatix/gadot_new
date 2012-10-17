Imports cs3.tableLogic

Public Class userLogic

    Dim _fieldLogic As New fieldLogic
    Dim _usersAdapter As New usersAdapter

    Function sendPasswordReminder(ByVal email As String) As usersRow

        Dim userFound As Boolean = False
        Dim userRow As usersRow = _usersAdapter.GetItem(0, "email='" & email.Replace("'", "''") & "'")
        If Not userRow Is Nothing Then
            If userRow.usersid > 0 Then
                userFound = True
            End If
        End If
        If userFound Then
            Dim _encryptionLogic As New encryptionLogic
            Dim _mailLogic As New mailLogic
            Dim placeholders As New Dictionary(Of String, String)
            placeholders.Add("firstname", userRow.firstname)
            placeholders.Add("email", userRow.email)
            placeholders.Add("userpassword", _encryptionLogic.Decrypt(userRow.password))
            _mailLogic.sendMailTemplate("PasswordRemainder", siteLogic.Config("siteemail"), userRow.email, placeholders)
        Else
            _fieldLogic.showError(fieldLogic.messageType.alert, "אימייל לא נמצא")
            Return Nothing
        End If

        Return userRow

    End Function

    Function userLogin(ByVal email As String, ByVal password As String) As usersRow
        Dim _encryptionLogic As New encryptionLogic
        If email = "" Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אנא הכנס דואר אלקטרוני")
            Return Nothing
        End If
        If password = "" Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אנא הכנס סיסמא")
            Return Nothing
        End If
        Dim userRow As usersRow = _usersAdapter.GetItem(0, "email='" & email.Replace("'", "''") & "' AND password='" & _encryptionLogic.Encrypt(password.Replace("'", "''")) & "'")
        Dim userFound As Boolean = False
        If Not userRow Is Nothing Then
            If userRow.usersid > 0 Then
                userFound = True
            End If
        End If
        If Not userFound Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "שם המשתמש או הסיסמא לא נמצאו")
            Return Nothing
        End If
        setLoggedUser(userRow)
        Return userRow
    End Function

    Function getUserID() As Int64
        If HttpContext.Current.Session("UserId") Is Nothing Then
            HttpContext.Current.Session("UserId") = Now.Ticks
            Return HttpContext.Current.Session("UserId")
        Else
            Return HttpContext.Current.Session("UserId")
        End If
    End Function

    Function getLoggedUser() As usersRow
        If Not HttpContext.Current.Session("loggedUser") Is Nothing Then
            Return HttpContext.Current.Session("loggedUser")
        End If
        Return Nothing
    End Function

    Function isUserLogged() As Boolean
        If Not getLoggedUser() Is Nothing Then
            Return True
        End If
        Return False
    End Function

    Sub setLoggedUser(ByVal userRow As usersRow)
        HttpContext.Current.Session("loggedUser") = userRow
    End Sub

End Class
