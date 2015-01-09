Public Class frmOrderBySRNumber

    Private Sub frmOrderBySRNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 3
        With DataGridView1
            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "DrugName"
            .Columns(2).Name = "TotalStock"
            Dim dsRA = DAO.getTotalPerSRNumber()
            Dim dsrNumber As String = ""
            Dim intI As Integer
            Try
                For intI = 0 To dsRA.Tables(strDBNAME).Rows.Count - 1
                    With dsRA.Tables(strDBNAME).Rows(intI)

                        DataGridView1.Rows.Add(.Item(0).ToString, .Item("tot").ToString, .Item("tot").ToString)
                    End With
                Next
                Dim intI1 As Integer
                Dim strValue As String
                For intI1 = 0 To DataGridView1.Rows.Count - 2

                    '    msgB.msgOKInf(DataGridView1.Rows(0).Cells(0).Value)

                    strValue = DAO.getDrugNameBySRNumber(DataGridView1.Rows(intI1).Cells(0).Value)
                    DataGridView1.Rows(intI1).Cells("DrugName").Value = strValue
                Next
            Catch ex As Exception
                msgB.msgOKInf(ex.Message)
            End Try
        End With
    End Sub
End Class