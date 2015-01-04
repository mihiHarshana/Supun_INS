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

        'Try
        '    Dim dsR As DataSet
        '    dsR = DAO.getLDetails1()
        '    If dsR.Tables(strDBNAME).Rows.Count = 1 Then
        '        With dsR.Tables(strDBNAME).Rows(0)

        '            If .Item("Lend") < Now Then
        '                msgB.msgOKCri("Serious Error" & vbCrLf & "Contact mhsoftsolutions@gmail.com for assistance")
        '                End
        '            ElseIf .Item("LCurrent") > Now Then
        '                msgB.msgOKCri("Serious Error" & vbCrLf & "Contact mhsoftsolutions@gmail.com for assistance")
        '                End
        '            Else

        '                DAO.setUpdateLDetails(Now, True)
        '            End If
        '        End With
        '    Else
        '        msgB.msgOKCritical("Serious Error" & vbCrLf & "Contact mhsoftsolutions@gmail.com for assistance")
        '        End

        '    End If
        '    Me.txtUserName.Text = "Mihindu"
        '    Me.txtPassword.Text = "Mihindu"
        'Catch ex As Exception
        '    msgB.msgOKInfor(ex.Message)
        'End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
End Class