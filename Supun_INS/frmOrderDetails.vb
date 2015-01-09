Public Class frmOrderDetails

    Private Sub frmOrderDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 7

        With DataGridView1
            .Columns(0).Name = "OrderNo"
            .Columns(1).Name = "OrderDate"
            .Columns(2).Name = "OrderAmount"
            .Columns(3).Name = "OrderType"
            .Columns(4).Name = "DrugId"
            '.Columns(5).Name = "Amount"
            '.Columns(6).Name = "did"
        End With
        Dim dsD = DAO.getAllOrderDetails()
        Dim intI As Integer
        For intI = 0 To dsD.Tables(strDBNAME).Rows.Count - 1
            With dsD.Tables(strDBNAME).Rows(intI)
                '   msgB.msgOKInf(dsD.Tables(strDBNAME).Rows(intI).Item(0))

                DataGridView1.Rows.Add(.Item("OrderNo"), .Item("OrderDate"), .Item("OrderAmount"), .Item("OrderType"), .Item("DrugId"))
            End With
        Next
        Dim intI1 As Integer
        Dim strValue As String
        For intI1 = 0 To DataGridView1.Rows.Count

            strValue = DAO.getDrugNameByDrugID(DataGridView1.Rows(intI1).Cells("drugId").Value)
            DataGridView1.Rows(intI1).Cells("drugID").Value = strValue
        Next
    End Sub
End Class