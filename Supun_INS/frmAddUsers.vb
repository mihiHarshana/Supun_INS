Public Class frmAddUsers
    Private newUser As New ClassUsers
    Private Sub frmAddUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmbUType.Items.Add("Admin")
        Me.cmbUType.Items.Add("User")
        Call clearALL()
    End Sub

    Public Sub clearALL()

        Me.txtUName.Clear()
        Me.txtPassword1.Clear()
        Me.txtPassword2.Clear()
        Me.cmbUType.Text = ""

        If strAddUser = "AddUser" Then
            Me.cmbUType.Enabled = True
            Me.txtUName.Enabled = True
            Me.btnAddUser.Enabled = True
            Me.btnChangePassword.Enabled = False
            Me.Text = "Add User"

        Else
            Me.Text = "Change Password"
            Me.btnAddUser.Enabled = False
            Me.btnChangePassword.Enabled = True

            Me.txtUName.Text = strLUserName
            Me.cmbUType.Text = strLUType
            Me.cmbUType.Enabled = False
            Me.txtUName.Enabled = False
            If strLUType = "Admin" Then
                Me.txtUName.Focus()
            Else
                Me.txtPassword1.Focus()
            End If

        End If

    End Sub

    Private Sub txtUName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim res As String
            res = newUser.setuName(Me.txtUName.Text)
            If res <> STROK Then
                msgB.msgOKInf(STROK)
                Exit Sub
            End If

            res = DAO.getUsers(newUser.getUName)
            If res = STROK Then
                Me.txtUName.Text = user.getUName
                Me.cmbUType.Text = user.getUType
                Me.btnAddUser.Enabled = False
                Me.btnChangePassword.Enabled = True
                Me.txtPassword1.Focus()
            End If
        End If
    End Sub

    Private Sub txtPassword1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim res As String
            res = newUser.setupword(Me.txtPassword1.Text)
            If res <> STROK Then
                msgB.msgOKInf(STROK)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtPassword2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim res As String
            res = newUser.setupword(Me.txtPassword1.Text, Me.txtPassword2.Text)
            If res <> STROK Then
                msgB.msgOKInf(STROK)
                Exit Sub
            End If
            If user.getUType = "Admin" Then
                Me.cmbUType.Focus()
            Else
                Me.btnAddUser.Text = "Change Password"
                Me.btnAddUser.Focus()

            End If
        End If
    End Sub

    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click

        Call addUser()
    End Sub

    Public Sub addUser()
        Dim res As String
        res = newUser.setuName(Me.txtUName.Text)
        If res <> STROK Then
            msgB.msgOKInf(res)
            Me.txtUName.Clear()
            Exit Sub
        End If
        res = newUser.setupword(Me.txtPassword1.Text)
        If res <> STROK Then
            msgB.msgOKInf(res)
            Me.txtPassword1.Clear()
            Me.txtPassword1.Focus()
            Exit Sub
        End If

        res = newUser.setupword(Me.txtPassword1.Text, Me.txtPassword2.Text)
        If res <> STROK Then
            msgB.msgOKInf(res)
            Me.txtPassword1.Clear()
            Me.txtPassword2.Clear()
            Me.txtPassword1.Focus()
            Exit Sub
        End If

        res = newUser.setuType(Me.cmbUType.Text)
        If res <> STROK Then
            msgB.msgOKInf(res)
            Exit Sub
        End If

        If Me.btnAddUser.Enabled = True Then
            res = DAO.addUsers(DAO.getUserCount(), newUser.getUName, newUser.getupword, newUser.getUType)
            If res = "Added" Then
                msgB.msgOKInf("New user added to the system")
                Call clearALL()

            End If
        End If

        If Me.btnChangePassword.Enabled = True Then
            res = DAO.editUserDetails(Me.txtUName.Text, Me.txtPassword2.Text, Me.cmbUType.Text)
            If res = "Updated" Then
                msgB.msgOKInf("User Details updated in the system")
                Call clearALL()
            End If
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.btnClear.Enabled = False

        Call clearALL()
        Me.txtUName.Focus()
    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Call addUser()
    End Sub

    Private Sub txtUName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUName.TextChanged
        If Me.txtUName.Text = "" Then
            Me.btnClear.Enabled = False
        Else
            Me.btnClear.Enabled = True

        End If
    End Sub

    Private Sub txtPassword1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword1.TextChanged
        If Me.txtPassword1.Text <> "" Then
            Me.btnClear.Enabled = True
        Else
            Me.btnClear.Enabled = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
End Class