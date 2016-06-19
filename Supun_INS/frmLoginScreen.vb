Imports System.Net.Mail

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
                DAO.addHistory(Now, "Login | UserName-" & strLUserName & "| UserType-" & strLUType, strLUserName)
                Me.Hide()
                If strLUType = "Admin" Then
                    MDIParent1.AddUsersToolStripMenuItem.Enabled = True
                    MDIParent1.HistoryToolStripMenuItem.Enabled = True

                Else
                    MDIParent1.AddUsersToolStripMenuItem.Enabled = False
                    MDIParent1.HistoryToolStripMenuItem.Enabled = False
                End If
                MDIParent1.Text = "Inventory Control System " & strVersion & "| User - " & strLUserName & "User Type -" & strLUType
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

        Dim rwtf As New classReadWriteTextFile
        ' Dim rwtfData As Array

        rwtfData = rwtf.GetPropertyFileDAta()





        'Dim IntI As Integer
        'For IntI = 0 To rwtfData.GetLength(0) - 1
        '    msgB.msgOKInf(rwtfData(IntI, 1))

        'Next


        Module1.strDBNAME = rwtfData(0, 1)

        Me.txtUserName.Focus()

        'Me.txtUserName.Text = "Admin"
        'Me.txtPassword.Text = "Admin"
        Me.Text = strVersion


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class