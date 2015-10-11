Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click

        frm_drugDetails = New DrugDetails
        frm_drugDetails.ShowDialog()

    End Sub

    Private Sub MDIParent1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim res As Boolean
        res = msgB.msgYesNoQuestion("Are you sure you want to Exit ")
        If res = True Then
            DAO.addHistory(Now, "Exit | UserName-" & strLUserName & "| UserType-" & strLUType, strLUserName)
            End
        Else
            e.Cancel = True

        End If

    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 6
        With DataGridView1

            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "Drug Name"
            .Columns(2).Name = "Manufacture Date"
            .Columns(3).Name = "Expirary Date"
            .Columns(4).Name = "Amount"
            .Columns(5).Name = "Store Location"
        End With

        With DataGridView2
            .Columns.Clear()
            .ColumnCount = 3
            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "Drug Name"
            .Columns(2).Name = "Available Amount"
        End With



        Call LoadDataGridData()
        Call LoadGrid2Data()
        '  Me.Text = "Inventory Control System " & strVersion & "| User - " & strLUserName & "User Type -" & strLUType
        Me.Refresh()
    End Sub

    Private Sub DrugListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrugListToolStripMenuItem.Click
        Dim druglist As New frmDrugPopUp
        blnDrugPopUpFromMenu = True
        druglist.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm_aboutBox As New AboutBox1
        frm_aboutBox.ShowDialog()

    End Sub

    Private Sub MDIParent1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Close()

    End Sub

    Private Sub OrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdersToolStripMenuItem.Click
        Dim frm_orderDetails As New frmOrderDetails
        frm_orderDetails.ShowDialog()

    End Sub

    Public Sub LoadDataGridData()
        DataGridView1.Rows.Clear()

        Dim dsD = DAO.getDrugsExpireInThreeMonths()

        Try
            Dim intI As Integer
            For intI = 0 To dsD.Tables(strDBNAME).Rows.Count - 1
                With DataGridView1.Rows
                    DataGridView1.Rows.Add(dsD.Tables(strDBNAME).Rows(intI).Item("dSRNumber"), dsD.Tables(strDBNAME).Rows(intI).Item("dName"),
                    dsD.Tables(strDBNAME).Rows(intI).Item("dManDate"), dsD.Tables(strDBNAME).Rows(intI).Item("dExpDate"), dsD.Tables(strDBNAME).Rows(intI).Item("dAvailAmt"),
                    dsD.Tables(strDBNAME).Rows(intI).Item("dLabel"))

                    If dsD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                        DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    End If
                End With
            Next

            dtColor.DataGrid1_rowcolors(dsD)

        Catch ex As Exception
            msgB.msgOKInf(ex.ToString)
        End Try
    End Sub

    Private Sub TotalPerSRNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalPerSRNoToolStripMenuItem.Click
        Dim frm_OderBySRNumber As New frmOrderBySRNumber
        frm_OderBySRNumber.ShowDialog()

    End Sub

    Public Sub LoadGrid2Data()
        ' Loading Drid2 data 
        ' ----- getting REOL setted drug DSRNumbers --- from table_DrugReorder
        DataGridView2.Rows.Clear()
        Dim dsDA As DataSet = DAO.getAllfromDrugREOL()
        Dim dsRA As DataSet = DAO.getTotalPerSRNumber()

        Dim intII As Integer
        Dim intI2 As Integer
        Dim intAvailAmount As Integer
        For intII = 0 To dsDA.Tables(strDBNAME).Rows.Count - 1
            For intI2 = 0 To dsRA.Tables(strDBNAME).Rows.Count - 1
                If dsRA.Tables(strDBNAME).Rows(intI2).Item("DSRNumber") = dsDA.Tables(strDBNAME).Rows(intII).Item("DSRNumber") Then


                    With dsRA.Tables(strDBNAME).Rows(intI2)
                        intAvailAmount = Convert.ToInt32(.Item("tot").ToString)
                        If dsDA.Tables(strDBNAME).Rows(intII).Item("REOL") >= intAvailAmount Then
                            DataGridView2.Rows.Add(.Item(0).ToString, .Item(0).ToString, .Item("tot").ToString)
                        End If
                    End With
                End If
            Next

            ' changing column2 to drug name
            Dim intI3 As Integer
            Dim value As String
            For intI3 = 0 To DataGridView2.Rows.Count - 2
                value = DAO.getDrugNameBydSRNumber(DataGridView2.Rows(intI3).Cells(0).Value)
                DataGridView2.Rows(intI3).Cells(1).Value = value
            Next
        Next
        dtColor.DataGrid1_rowcolors(dsDA, Me.DataGridView2)
    End Sub

    Private Sub AddUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUsersToolStripMenuItem.Click
        Dim addUser As New frmAddUsers
        strAddUser = "AddUser"
        addUser.ShowDialog()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim changePassword As New frmAddUsers
        strAddUser = "ChangePassword"
        changePassword.ShowDialog()

    End Sub

    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        Dim frm_DisplaayHistory As New frmDisplayHistory
        frmDisplayHistory.ShowDialog()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        DAO.addHistory(Now, "Log Out | UserName- " & strLUserName & " | UserType- " & strLUType, strLUserName)
        strLUserName = ""
        strLUType = ""
        GC.Collect()

        Dim frm_Login1 As New frmLoginScreen

        frm_Login1.Show()
        Me.Hide()
    End Sub

    Private Sub DeleteExpiredDrugsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteExpiredDrugsToolStripMenuItem.Click
        Dim frm_ExpiredDrugs As New frmExpiredDrugs
        frm_ExpiredDrugs.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
