Imports System.Net.Mail

Public Class frmLoginScreen

    Private rSubKey As String = "DRG"
    Private rValue As String = "value1"
    Private rExDate As String = "value2"
    Private regData As String = "Demo Version1"
    Private regDate As String

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




        Dim rwRegistry As New classReadWriteRegistry

        Dim regValue As String = rwRegistry.getValueFromRegistryByPath(rSubKey, rValue)
        Dim regDateValue As String = rwRegistry.getValueFromRegistryByPath(rSubKey, rExDate)
        If regValue = "NOTHING" Then
            regDate = Date.Now

            rwRegistry.setValueToRegistry(rSubKey, rValue, regData)
            rwRegistry.setValueToRegistry(rSubKey, rExDate, regDate)
            Me.txtUserName.Text = "Demo"
            Me.txtPassword.Text = "Demo"
            Dim res As String = DAO.getUsers(Me.txtUserName.Text)
            If res <> STROK Then
                DAO.addUsers(DAO.getUserCount(), Me.txtUserName.Text, Me.txtPassword.Text, "User")
            End If

        Else
            Dim dateTime As DateTime
            dateTime = regDateValue
            If regValue = "Demo Version" And dateTime.AddDays(7) < Date.Now Then

                'If dateTime > Date.Now Then
                Me.txtUserName.Text = "Demo"
                Me.txtPassword.Text = "Demo"

                Dim res As String = DAO.getUsers(Me.txtUserName.Text)
                If res <> STROK Then
                    DAO.addUsers(DAO.getUserCount(), Me.txtUserName.Text, Me.txtPassword.Text, "User")
                End If
            ElseIf (dateTime.AddYears(1) < Date.Now) Then
                msgB.msgOKCri("License Expired. Contact mhsoftsolutions for new license")
                Application.Exit()
            Else
                strVersion = regValue & strVersion_Nu
                Me.Text = strVersion
        
            End If


        End If






    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class