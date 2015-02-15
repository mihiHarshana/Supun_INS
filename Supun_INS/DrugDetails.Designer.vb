<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrugDetails
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRevieceAmount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdbRecieveDrug = New System.Windows.Forms.RadioButton()
        Me.rdbIssueDrug = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSRNumber = New System.Windows.Forms.TextBox()
        Me.txtRecAmount = New System.Windows.Forms.TextBox()
        Me.txtDrugName = New System.Windows.Forms.TextBox()
        Me.txtTotStock = New System.Windows.Forms.TextBox()
        Me.dtManDate = New System.Windows.Forms.DateTimePicker()
        Me.dtDOExpiry = New System.Windows.Forms.DateTimePicker()
        Me.txtOrderNumber = New System.Windows.Forms.TextBox()
        Me.lblRecieveOrderNumber = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtREcDate = New System.Windows.Forms.DateTimePicker()
        Me.lblRecieveDate = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtStockLabel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOrderNo1 = New System.Windows.Forms.TextBox()
        Me.lblExpiredMsg = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SR Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Drug Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Manufacutre Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(248, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Date Of Expiry"
        '
        'lblRevieceAmount
        '
        Me.lblRevieceAmount.AutoSize = True
        Me.lblRevieceAmount.Location = New System.Drawing.Point(12, 137)
        Me.lblRevieceAmount.Name = "lblRevieceAmount"
        Me.lblRevieceAmount.Size = New System.Drawing.Size(74, 13)
        Me.lblRevieceAmount.TabIndex = 5
        Me.lblRevieceAmount.Text = " Issue Amount"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(227, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Total in Stock"
        '
        'rdbRecieveDrug
        '
        Me.rdbRecieveDrug.AutoSize = True
        Me.rdbRecieveDrug.Location = New System.Drawing.Point(37, 15)
        Me.rdbRecieveDrug.Name = "rdbRecieveDrug"
        Me.rdbRecieveDrug.Size = New System.Drawing.Size(68, 17)
        Me.rdbRecieveDrug.TabIndex = 0
        Me.rdbRecieveDrug.TabStop = True
        Me.rdbRecieveDrug.Text = "&Recieve "
        Me.rdbRecieveDrug.UseVisualStyleBackColor = True
        '
        'rdbIssueDrug
        '
        Me.rdbIssueDrug.AutoSize = True
        Me.rdbIssueDrug.Location = New System.Drawing.Point(121, 15)
        Me.rdbIssueDrug.Name = "rdbIssueDrug"
        Me.rdbIssueDrug.Size = New System.Drawing.Size(50, 17)
        Me.rdbIssueDrug.TabIndex = 1
        Me.rdbIssueDrug.TabStop = True
        Me.rdbIssueDrug.Text = "&Issue"
        Me.rdbIssueDrug.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbIssueDrug)
        Me.GroupBox1.Controls.Add(Me.rdbRecieveDrug)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 38)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Drug Transaction Type"
        '
        'txtSRNumber
        '
        Me.txtSRNumber.Location = New System.Drawing.Point(80, 60)
        Me.txtSRNumber.Name = "txtSRNumber"
        Me.txtSRNumber.Size = New System.Drawing.Size(98, 20)
        Me.txtSRNumber.TabIndex = 3
        '
        'txtRecAmount
        '
        Me.txtRecAmount.BackColor = System.Drawing.Color.Khaki
        Me.txtRecAmount.Location = New System.Drawing.Point(111, 134)
        Me.txtRecAmount.Name = "txtRecAmount"
        Me.txtRecAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtRecAmount.TabIndex = 8
        '
        'txtDrugName
        '
        Me.txtDrugName.Location = New System.Drawing.Point(251, 61)
        Me.txtDrugName.Name = "txtDrugName"
        Me.txtDrugName.Size = New System.Drawing.Size(130, 20)
        Me.txtDrugName.TabIndex = 4
        '
        'txtTotStock
        '
        Me.txtTotStock.Location = New System.Drawing.Point(306, 130)
        Me.txtTotStock.Name = "txtTotStock"
        Me.txtTotStock.Size = New System.Drawing.Size(100, 20)
        Me.txtTotStock.TabIndex = 9
        '
        'dtManDate
        '
        Me.dtManDate.CustomFormat = ""
        Me.dtManDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtManDate.Location = New System.Drawing.Point(111, 96)
        Me.dtManDate.Name = "dtManDate"
        Me.dtManDate.Size = New System.Drawing.Size(114, 20)
        Me.dtManDate.TabIndex = 6
        Me.dtManDate.Value = New Date(2014, 11, 2, 11, 39, 44, 0)
        '
        'dtDOExpiry
        '
        Me.dtDOExpiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDOExpiry.Location = New System.Drawing.Point(338, 96)
        Me.dtDOExpiry.Name = "dtDOExpiry"
        Me.dtDOExpiry.Size = New System.Drawing.Size(133, 20)
        Me.dtDOExpiry.TabIndex = 7
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BackColor = System.Drawing.Color.Khaki
        Me.txtOrderNumber.Location = New System.Drawing.Point(444, 15)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(61, 20)
        Me.txtOrderNumber.TabIndex = 2
        '
        'lblRecieveOrderNumber
        '
        Me.lblRecieveOrderNumber.AutoSize = True
        Me.lblRecieveOrderNumber.Location = New System.Drawing.Point(238, 18)
        Me.lblRecieveOrderNumber.Name = "lblRecieveOrderNumber"
        Me.lblRecieveOrderNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblRecieveOrderNumber.TabIndex = 19
        Me.lblRecieveOrderNumber.Text = "Order Number"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(210, 387)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(318, 386)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(430, 387)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtREcDate
        '
        Me.dtREcDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtREcDate.Location = New System.Drawing.Point(588, 15)
        Me.dtREcDate.Name = "dtREcDate"
        Me.dtREcDate.Size = New System.Drawing.Size(114, 20)
        Me.dtREcDate.TabIndex = 25
        '
        'lblRecieveDate
        '
        Me.lblRecieveDate.AutoSize = True
        Me.lblRecieveDate.Location = New System.Drawing.Point(522, 18)
        Me.lblRecieveDate.Name = "lblRecieveDate"
        Me.lblRecieveDate.Size = New System.Drawing.Size(30, 13)
        Me.lblRecieveDate.TabIndex = 24
        Me.lblRecieveDate.Text = "Date"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 171)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(576, 192)
        Me.DataGridView1.TabIndex = 26
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(613, 219)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(613, 264)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'txtStockLabel
        '
        Me.txtStockLabel.Location = New System.Drawing.Point(457, 61)
        Me.txtStockLabel.Name = "txtStockLabel"
        Me.txtStockLabel.Size = New System.Drawing.Size(126, 20)
        Me.txtStockLabel.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(387, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Stock Label"
        '
        'txtOrderNo1
        '
        Me.txtOrderNo1.BackColor = System.Drawing.Color.Khaki
        Me.txtOrderNo1.Location = New System.Drawing.Point(341, 15)
        Me.txtOrderNo1.Name = "txtOrderNo1"
        Me.txtOrderNo1.Size = New System.Drawing.Size(97, 20)
        Me.txtOrderNo1.TabIndex = 31
        '
        'lblExpiredMsg
        '
        Me.lblExpiredMsg.AutoSize = True
        Me.lblExpiredMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpiredMsg.ForeColor = System.Drawing.Color.Red
        Me.lblExpiredMsg.Location = New System.Drawing.Point(500, 94)
        Me.lblExpiredMsg.Name = "lblExpiredMsg"
        Me.lblExpiredMsg.Size = New System.Drawing.Size(83, 24)
        Me.lblExpiredMsg.TabIndex = 32
        Me.lblExpiredMsg.Text = "Expired"
        '
        'DrugDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblExpiredMsg)
        Me.Controls.Add(Me.txtOrderNo1)
        Me.Controls.Add(Me.txtStockLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dtREcDate)
        Me.Controls.Add(Me.lblRecieveDate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtOrderNumber)
        Me.Controls.Add(Me.lblRecieveOrderNumber)
        Me.Controls.Add(Me.dtDOExpiry)
        Me.Controls.Add(Me.dtManDate)
        Me.Controls.Add(Me.txtTotStock)
        Me.Controls.Add(Me.txtDrugName)
        Me.Controls.Add(Me.txtRecAmount)
        Me.Controls.Add(Me.txtSRNumber)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblRevieceAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DrugDetails"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drug Details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRevieceAmount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdbRecieveDrug As System.Windows.Forms.RadioButton
    Friend WithEvents rdbIssueDrug As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSRNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRecAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDrugName As System.Windows.Forms.TextBox
    Friend WithEvents txtTotStock As System.Windows.Forms.TextBox
    Friend WithEvents dtManDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDOExpiry As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblRecieveOrderNumber As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtREcDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRecieveDate As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtStockLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo1 As System.Windows.Forms.TextBox
    Friend WithEvents lblExpiredMsg As System.Windows.Forms.Label
End Class
