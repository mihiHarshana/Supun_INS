<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUName = New System.Windows.Forms.TextBox()
        Me.txtPassword1 = New System.Windows.Forms.TextBox()
        Me.txtPassword2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUType = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddUser
        '
        Me.btnAddUser.Location = New System.Drawing.Point(41, 183)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(75, 23)
        Me.btnAddUser.TabIndex = 4
        Me.btnAddUser.Text = "Add"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(235, 183)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Re Enter Password"
        '
        'txtUName
        '
        Me.txtUName.Location = New System.Drawing.Point(142, 35)
        Me.txtUName.Name = "txtUName"
        Me.txtUName.Size = New System.Drawing.Size(160, 20)
        Me.txtUName.TabIndex = 0
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(142, 61)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword1.Size = New System.Drawing.Size(160, 20)
        Me.txtPassword1.TabIndex = 1
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(142, 87)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword2.Size = New System.Drawing.Size(160, 20)
        Me.txtPassword2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "User Type"
        '
        'cmbUType
        '
        Me.cmbUType.FormattingEnabled = True
        Me.cmbUType.Location = New System.Drawing.Point(142, 117)
        Me.cmbUType.Name = "cmbUType"
        Me.cmbUType.Size = New System.Drawing.Size(121, 21)
        Me.cmbUType.TabIndex = 3
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(235, 242)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(122, 183)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(107, 23)
        Me.btnChangePassword.TabIndex = 5
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'frmAddUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 285)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cmbUType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPassword2)
        Me.Controls.Add(Me.txtPassword1)
        Me.Controls.Add(Me.txtUName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAddUser)
        Me.Name = "frmAddUsers"
        Me.Text = "frmAddUsers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
End Class
