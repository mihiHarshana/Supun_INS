Public Class frmDrugPopUp


    Private Sub frmDrugPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 7

        With DataGridView1


            .Columns(0).Name = "Stock Label"
            .Columns(1).Name = "SR Number"
            .Columns(2).Name = "Drug Name"
            .Columns(3).Name = "Manufacture Date"
            .Columns(4).Name = "Expirary Date"
            .Columns(5).Name = "Amount"
            .Columns(6).Name = "Total Stock"
        End With



        Me.txtDrugName.Text = string_drugname


        Dim dsRDD As DataSet

        dsRDD = DAO.getDrugDetails(string_drugname)

        Dim intI As Integer
        For intI = 0 To dsRDD.Tables(strDBNAME).Rows.Count - 1
            With dsRDD.Tables(strDBNAME).Rows(intI)
                DataGridView1.Rows.Add(.Item("dLabel"), .Item("dSRNumber"), .Item("dName"), .Item("dManDate"), .Item("dExpDate"), .Item("dRecAmt"), .Item("dAvailAmt"))
            End With
        Next




    End Sub


    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

    End Sub

    Private Sub DataGridView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        msgB.msgOKInf("Double clicked111")
        With DataGridView1.SelectedCells
            msgB.msgOKInf(.Item(0).Value.ToString)
            frm_drugDetails.txtStockLabel.Text = .Item(0).Value.ToString
            frm_drugDetails.txtSRNumber.Text = .Item(1).Value
            frm_drugDetails.txtDrugName.Text = .Item(2).Value
            frm_drugDetails.dtManDate.Value = .Item(3).Value
            frm_drugDetails.dtDOExpiry.Value = .Item(4).Value
            frm_drugDetails.txtTotStock.Text = .Item(6).Value
            Me.Close()

        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class