
Partial Class changedetails
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
        If Not Page.IsPostBack Then
            loadUserData()
        End If
    End Sub

    Sub loadUserData()
        firstnametxt.Value = userRow.firstname
        lastnametxt.Value = userRow.lastname
        emailtxt.Value = userRow.email
        If userRow.isrecevingupdates = 1 Then
            isrecevingupdatescbx.Checked = True
        Else
            isrecevingupdatescbx.Checked = False
        End If
    End Sub

    Protected Sub savebut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebut.ServerClick
        If userRow Is Nothing Then
            Response.Redirect("login.aspx")
        End If
        If _fieldLogic.isEmptyField(firstnametxt, "אנא הכנס שם פרטי") Then
            Exit Sub
        End If
        If _fieldLogic.isEmptyField(lastnametxt, "אנא הכנס שם משפחה") Then
            Exit Sub
        End If
        If _fieldLogic.isEmptyField(emailtxt, "אנא הכנס דואר אלקטרוני") Then
            Exit Sub
        End If
        userRow.firstname = firstnametxt.Value
        userRow.lastname = lastnametxt.Value
        userRow.email = emailtxt.Value
        If isrecevingupdatescbx.Checked Then
            userRow.isrecevingupdates = 1
        Else
            userRow.isrecevingupdates = 0
        End If
        _usersAdapter.Update(userRow)
        _fieldLogic.showError(fieldLogic.messageType.success, "הפרטים נשמרו בהצלחה")
    End Sub

End Class
