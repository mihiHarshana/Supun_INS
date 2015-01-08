Public Class frmLoginScreen

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DBConnection.getAccessDBConnection(strDBNAME)

        If Me.txtUserName.Text = "" Then
            msgB.msgOKInf("User Name cannot be a blank")
            Me.txtUserName.Focus()
        ElseIf Me.txtPassword.Text = "" Then
            msgB.msgOKInf("Password cannot be a blank")
            Me.txtUserName.Clear()
            Me.txtPassword.Clear()
            Me.txtUserName.Focus()
        Else
            Dim strRes As String
            strRes = DAO.getUsers(Me.txtUserName.Text, Me.txtPassword.Text)
            If strRes = "OK" Then
                Me.Hide()
                MDIParent1.Show()
            Else
                msgB.msgOKInf(strRes)
                Me.txtPassword.Clear()
                Me.txtUserName.Clear()
                Me.txtUserName.Focus()
            End If
        End If
    End Sub

    Private Sub frmLoginScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtUserName.Focus()

        Me.txtUserName.Text = "Admin"
        Me.txtPassword.Text = "Admin"
        Me.Text = strVersion

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
End Class