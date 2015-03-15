Public Class frmDisplayHistory

    Private Sub frmDisplayHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 4

        With DataGridView1
            .Columns(0).Name = "#"
            .Columns(1).Name = "Date"
            .Columns(2).Name = "Description"
            .Columns(3).Name = "User"
        End With

        Dim dsDR = DAO.getTRHistory()
        Dim intI As Integer
        For intI = 0 To dsDR.Tables(strDBNAME).Rows.Count - 1
            With dsDR.Tables(strDBNAME).Rows(intI)
                DataGridView1.Rows.Add(.Item("trID"), .Item("trDate"), .Item("trDesc"), .Item("trUser"))
            End With
        Next
        dtColor.DataGrid1_rowcolors(dsDR, Me.DataGridView1)
    End Sub
End Class