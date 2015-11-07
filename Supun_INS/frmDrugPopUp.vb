Public Class frmDrugPopUp

    Private Sub frmDrugPopUp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.txtDrugName.Clear()

    End Sub


    Private Sub frmDrugPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 7

        With DataGridView1

            .Columns(0).Name = "Stock Label"
            .Columns(1).Name = "SR Number"
            .Columns(2).Name = "Drug Name"
            .Columns(3).Name = "Manufacture Date"
            .Columns(4).Name = "Expirary Date"
            .Columns(5).Name = "Amount"

            .Columns(6).Name = "did"
            .Columns(6).Visible = False

        End With
        Me.txtDrugName.Text = string_drugname

    End Sub


    Private Sub DataGridView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        ' msgB.msgOKInf("Double clicked111")
        With DataGridView1.SelectedCells

            Try

                If blnDrugPopUpFromMenu = False Then
                    'msgB.msgOKInf(.Item(0).Value.ToString)
                    frm_drugDetails.txtStockLabel.Text = .Item(0).Value
                    ' msgB.msgOKInf("on the click this happend " & .Item(0).Value.ToString)
                    frm_drugDetails.txtSRNumber.Text = .Item(1).Value
                    frm_drugDetails.txtDrugName.Text = .Item(2).Value

                    If o1.getoType = "REC" Then

                        frm_drugDetails.txtTotStock.Text = 0
                        frm_drugDetails.dtManDate.Value = Now.Date
                        frm_drugDetails.dtDOExpiry.Value = Now.Date
                    Else
                        frm_drugDetails.dtManDate.Value = .Item(3).Value
                        frm_drugDetails.dtDOExpiry.Value = .Item(4).Value
                        frm_drugDetails.txtTotStock.Text = .Item(5).Value
                    End If


                    d1.setDID(.Item(6).Value)
                    frm_DrubPopUPStatus = ""
                    Me.Close()
                End If


            Catch ex As Exception
                msgB.msgOKCri(ex.Message)
            End Try


        End With
    End Sub

    Private Sub txtDrugName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDrugName.KeyPress
        DataGridView1.Rows.Clear()

        If e.KeyChar = ChrW(Keys.Enter) Then

            If frm_DrubPopUPStatus = "BYNAME" Then
                '   Me.txtDrugName.Text = string_drugname


                Dim dsRDD As DataSet

                dsRDD = DAO.getDrugDetails(Me.txtDrugName.Text)

                Dim intI As Integer
                For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
                    With dsRDD.Tables(strDBNAME).Rows(intI)
                        DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dAvailAmt"), .Item("did"))
                    End With

                    dtColor.DataGrid1_rowcolors(dsRDD, Me.DataGridView1)
                    If dsRDD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                        DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    End If

                Next
            End If
            If frm_DrubPopUPStatus = "BYDSRNUMBER" Then
                '   Me.txtDrugName.Text = string_drugname
                Dim dsRDD As DataSet
                dsRDD = DAO.getDrugDetailsByDSRNumber(Me.txtDrugName.Text)
                Dim intI As Integer
                For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
                    ' msgB.msgOKInf(dsRDD.Tables(strDBNAME).Rows.Count)
                    With dsRDD.Tables(strDBNAME).Rows(intI)
                        DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dAvailAmt"), .Item("did"))
                    End With
                    dtColor.DataGrid1_rowcolors(dsRDD, Me.DataGridView1)
                    If dsRDD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                        DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtDrugName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDrugName.TextChanged
        DataGridView1.Rows.Clear()
        Dim dsRDD As DataSet

        dsRDD = DAO.getDrugDetails(Me.txtDrugName.Text, Me.txtDrugName.Text)

        Dim intI As Integer
        For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
            ' msgB.msgOKInf(dsRDD.Tables(strDBNAME).Rows.Count)
            With dsRDD.Tables(strDBNAME).Rows(intI)
                DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dAvailAmt"), .Item("did"))

            End With
            dtColor.DataGrid1_rowcolors(dsRDD, Me.DataGridView1)

            If dsRDD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub txtSrNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DataGridView1.Rows.Clear()

        If e.KeyChar = ChrW(Keys.Enter) Then

            If frm_DrubPopUPStatus = "BYNAME" Then
                '   Me.txtDrugName.Text = string_drugname
                Dim dsRDD As DataSet

                dsRDD = DAO.getDrugDetails(Me.txtDrugName.Text)

                Dim intI As Integer
                For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
                    With dsRDD.Tables(strDBNAME).Rows(intI)
                        DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dAvailAmt"), .Item("did"))
                    End With
                    dtColor.DataGrid1_rowcolors(dsRDD, Me.DataGridView1)
                    If dsRDD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                        DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next
            End If

            If frm_DrubPopUPStatus = "BYDSRNUMBER" Then
                '   Me.txtDrugName.Text = string_drugname
                Dim dsRDD As DataSet
                dsRDD = DAO.getDrugDetailsByDSRNumber(Me.txtDrugName.Text)
                Dim intI As Integer
                For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
                    ' msgB.msgOKInf(dsRDD.Tables(strDBNAME).Rows.Count)
                    With dsRDD.Tables(strDBNAME).Rows(intI)
                        DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dAvailAmt"), .Item("did"))
                    End With
                    dtColor.DataGrid1_rowcolors(dsRDD, Me.DataGridView1)
                    If dsRDD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                        DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next
            End If
        End If
    End Sub
End Class