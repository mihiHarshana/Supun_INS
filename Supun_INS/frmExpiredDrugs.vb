Public Class frmExpiredDrugs


    Private Sub frmExpiredDrugs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ClearALL()

    End Sub

    Private Sub ClearALL()
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 7
        With DataGridView1

            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "Drug Name"
            .Columns(2).Name = "Manufacture Date"
            .Columns(3).Name = "Expirary Date"
            .Columns(4).Name = "Amount"
            .Columns(5).Name = "Store Location"
            .Columns(6).Name = "DDID"
        End With


        DataGridView2.Columns.Clear()
        DataGridView2.ColumnCount = 7
        With DataGridView2

            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "Drug Name"
            .Columns(2).Name = "Manufacture Date"
            .Columns(3).Name = "Expirary Date"
            .Columns(4).Name = "Amount"
            .Columns(5).Name = "Store Location"
            .Columns(6).Name = "DDID"
        End With

        LoadDataGridData()
    End Sub

    Public Sub LoadDataGridData()
        DataGridView1.Rows.Clear()

        Dim dsD = DAO.getDrugsExpired(False)

        Try
            Dim intI As Integer
            For intI = 0 To dsD.Tables(strDBNAME).Rows.Count - 1
                With DataGridView1.Rows
                    DataGridView1.Rows.Add(dsD.Tables(strDBNAME).Rows(intI).Item("dSRNumber"), dsD.Tables(strDBNAME).Rows(intI).Item("dName"),
                    dsD.Tables(strDBNAME).Rows(intI).Item("dManDate"), dsD.Tables(strDBNAME).Rows(intI).Item("dExpDate"), dsD.Tables(strDBNAME).Rows(intI).Item("dAvailAmt"),
                    dsD.Tables(strDBNAME).Rows(intI).Item("dLabel"), dsD.Tables(strDBNAME).Rows(intI).Item("did"))

                    'If dsD.Tables(strDBNAME).Rows(intI).Item("dExpDate") <= Now.Date Then
                    '    DataGridView1.Rows(intI).DefaultCellStyle.ForeColor = Color.Red
                    'End If
                End With
            Next

            dtColor.DataGrid1_rowcolors(dsD)

        Catch ex As Exception
            msgB.msgOKInf(ex.ToString)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim i As Integer = DataGridView1.CurrentCell.RowIndex
        With DataGridView1.Rows(i)
            If .Cells("SRNumber").Value Is Nothing Then
                msgB.msgOKInf("Please select a row")
                Exit Sub
            End If
            DataGridView2.Rows.Add(.Cells("SRNumber").Value, .Cells("Drug Name").Value, .Cells("Manufacture Date").Value,
                                   .Cells("Expirary Date").Value, .Cells("Amount").Value, .Cells("Store Location").Value,
                                   .Cells("DDID").Value)
        End With
        DataGridView1.Rows.RemoveAt(i)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        Dim i As Integer = DataGridView2.CurrentCell.RowIndex
        With DataGridView2.Rows(i)
            If .Cells("SRNumber").Value Is Nothing Then
                msgB.msgOKInf("Please select a row")
                Exit Sub
            End If
            DataGridView1.Rows.Add(.Cells("SRNumber").Value, .Cells("Drug Name").Value, .Cells("Manufacture Date").Value,
                                   .Cells("Expirary Date").Value, .Cells("Amount").Value, .Cells("Store Location").Value,
                                   .Cells("DDID").Value)
        End With
        DataGridView2.Rows.RemoveAt(i)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DataGridView2.Rows.Count <= 0 Then
            msgB.msgOKInf("Please add atleast one drug to save as inactive")
            Exit Sub
        End If

        For intI = 0 To DataGridView2.Rows.Count - 2
            DAO.editDrugStaus(DataGridView2.Rows(intI).Cells("DDID").Value, True)
        Next
        msgB.msgOKInf("Selected Drugs are inactivated from the system")
        MDIParent1.LoadDataGridData()
        MDIParent1.LoadGrid2Data()
        Call ClearALL()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class