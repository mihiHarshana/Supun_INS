Public Class frmOrderBySRNumber

    Private Sub frmOrderBySRNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 4

        With DataGridView1
            .Columns(0).Name = "SRNumber"
            .Columns(1).Name = "DrugName"
            .Columns(2).Name = "TotalStock"
            .Columns(3).Name = "REOL"


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
                    Me.lblReportGenDate.Text = "Report Generated Date : " & Date.Now

                Next

                'load Re Order Leven by DSRNumber
                Dim intI2 As Integer
                Dim dsDD As DataSet
                For intI2 = 0 To DataGridView1.Rows.Count - 2

                    dsDD = DAO.getDrugREOLbyDSRNumber(DataGridView1.Rows(intI2).Cells(0).Value)

                    If dsDD.Tables(strDBNAME).Rows.Count <> 0 Then
                        DataGridView1.Rows(intI2).Cells("REOL").Value = dsDD.Tables(strDBNAME).Rows(0).Item("REOL")
                    End If
                Next
                dtColor.DataGrid1_rowcolors(dsRA, Me.DataGridView1)

            Catch ex As Exception
                msgB.msgOKInf(ex.Message)
            End Try
        End With
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        ' msgB.msgOKInf(user.getUType)
        If strLUType = "Admin" Then

            ' msgB.msgOKInf(DataGridView1.SelectedCells.Item(0).Value.ToString())
            Dim dsD As DataSet = DAO.getDrugREOLbyDSRNumber(DataGridView1.SelectedCells.Item(0).Value.ToString())
            If dsD.Tables(strDBNAME).Rows.Count = 0 Then
                Dim res = InputBox("Enter Re order Level for " & DataGridView1.SelectedCells.Item(0).Value.ToString() & "(" & DataGridView1.SelectedCells.Item(1).Value.ToString() & ")", "Enter Re order Level")
                If res <> "" Then
                    res = DAO.addREOL(DataGridView1.SelectedCells.Item(0).Value.ToString(), Convert.ToInt32(res))
                    If res = "Added" Then
                        msgB.msgOKInf("Re order level added")
                        MDIParent1.LoadGrid2Data()
                        Exit Sub
                    End If
                End If
            Else


                Dim res = InputBox("Change  Re order Level for " & dsD.Tables(strDBNAME).Rows(0).Item("DSRNumber"), "Enter Re order Level to change", dsD.Tables(strDBNAME).Rows(0).Item("REOL"))
                If res <> "" Then
                    res = DAO.editREOL(dsD.Tables(strDBNAME).Rows(0).Item("DSRNumber"), res)
                    If res = "Updated" Then
                        msgB.msgOKInf("Re order level Updated")
                        MDIParent1.LoadGrid2Data()
                        Exit Sub
                    End If
                End If
            End If


            'Dim res = InputBox("Enter Re order Level for " & DataGridView1.SelectedCells.Item(0).Value.ToString(), "Enter Re order Level")
            'If res <> "" Then
            '    msgB.msgOKInf("We will add it to database")
            'End If


        End If
    End Sub
End Class