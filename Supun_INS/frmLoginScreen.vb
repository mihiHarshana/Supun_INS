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
        Me.txtUserName.Focus()

        'Me.txtUserName.Text = "Admin"
        'Me.txtPassword.Text = "Admin"
        Me.Text = strVersion


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim Smtp_Server As New SmtpClient
        '    Dim e_mail As New MailMessage()
        '    Smtp_Server.UseDefaultCredentials = False
        '    Smtp_Server.Credentials = New Net.NetworkCredential("mihinduwijesena@gmail.com", "Yehemini@129#1")
        '    Smtp_Server.Port = 25
        '    Smtp_Server.EnableSsl = True
        '    Smtp_Server.Host = "smtp.gmail.com"

        '    e_mail = New MailMessage()
        '    e_mail.From = New MailAddress("mihinduwijesena@gmail.com")
        '    e_mail.To.Add("mihinduwijesena@gmail.com")
        '    e_mail.Subject = "Email Sending"
        '    e_mail.IsBodyHtml = False
        '    e_mail.Body = "There are drugs already expired"
        '    Smtp_Server.Send(e_mail)
        '    MsgBox("Mail Sent")

        'Catch error_t As Exception
        '    MsgBox(error_t.ToString)
        'End Try

        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New  _
  Net.NetworkCredential("mihinduwijesena@gmail.com", "Yehemini@129#1")
            SmtpServer.EnableSsl = True
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.googlemail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("mihinduwijesena@gmail.com")
            mail.To.Add("mihinduwijesena@gmail.com")
            mail.Subject = "Test Mail"
            mail.Body = "This is for testing SMTP mail from GMAIL"
            SmtpServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class