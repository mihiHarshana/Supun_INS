Public Class frmCalTotPerSRNumber

    Private Sub frmCalTotPerSRNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 6

        With DataGridView1
            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "DrugName"
            .Columns(2).Name = "TotalStock"
            .Columns(3).Name = "TotExpired"
            .Columns(4).Name = "TotAvailable"
            .Columns(5).Name = "REOL"

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
                    ' Me.lblReportGenDate.Text = "Report Generated Date : " & Date.Now
                    dtColor.DataGrid1_rowcolors(dsRA, Me.DataGridView1)
                Next
            Catch ex As Exception
                msgB.msgOKInf(ex.Message)
            End Try
            ' add total of expired drugs per SR number to the table
            Dim intI2 As Integer
            Dim intI3 As Integer
            For intI2 = 0 To DataGridView1.Rows.Count - 2
                Dim dsd = DAO.getDrugsExpiredTotPerSRNo()
                For intI3 = 0 To dsd.Tables(strDBNAME).Rows.Count - 1
                    If dsd.Tables(strDBNAME).Rows(intI3).Item("dSRNumber") = DataGridView1.Rows(intI2).Cells(0).Value Then
                        DataGridView1.Rows(intI2).Cells("TotExpired").Value = dsd.Tables(strDBNAME).Rows(intI3).Item("totExp").ToString
                    Else
                        DataGridView1.Rows(intI2).Cells("TotExpired").Value = 0
                    End If
                Next
            Next
            Dim intI4 As Integer
            For intI4 = 0 To DataGridView1.Rows.Count - 2
                With DataGridView1.Rows(intI4)
                    .Cells("TotAvailable").Value = .Cells("TotalStock").Value - .Cells("TotExpired").Value
                End With
            Next

            'load Re Order Leven by DSRNumber
            Dim intI5 As Integer
            Dim dsDD As DataSet
            For intI5 = 0 To DataGridView1.Rows.Count - 2

                dsDD = DAO.getDrugREOLbyDSRNumber(DataGridView1.Rows(intI5).Cells(0).Value)

                If dsDD.Tables(strDBNAME).Rows.Count <> 0 Then
                    DataGridView1.Rows(intI5).Cells("REOL").Value = dsDD.Tables(strDBNAME).Rows(0).Item("REOL")
                End If
            Next
        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class