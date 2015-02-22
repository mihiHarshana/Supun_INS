Public Class DrugDetails
    Public strTType As String = ""
    Private strRDBText As String = ""
    Private intViewed As Integer = 0 ' if 0 will update all the rows, else will update from that point

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call clearALL()
    End Sub

    Public Sub clearALL()
        Me.txtRecAmount.Enabled = True
        txtTotStock.Enabled = False ' just displaying the total
        rdbIssueDrug.Checked = False
        rdbRecieveDrug.Checked = False
        lblRecieveOrderNumber.Text = "Receive  Number"
        lblRevieceAmount.Text = "Receive Amount"
        lblRecieveDate.Text = "Receive Date"
        dtDOExpiry.Value = Today
        dtManDate.Value = Today
        dtREcDate.Value = Today
        strTType = ""
        strRDBText = ""
        intViewed = 0

        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 8

        btnAdd.Enabled = False
        btnRemove.Enabled = False
        btnUpdate.Enabled = False

        With DataGridView1

            .Columns(0).Name = "Stock Label"
            .Columns(1).Name = "SR Number"
            .Columns(2).Name = "Drug Name"
            .Columns(3).Name = "Manufacture Date"
            .Columns(4).Name = "Expirary Date"
            .Columns(5).Name = "Amount"
            .Columns(6).Name = "Total Stock"
            .Columns(7).Name = "DID"
            .Columns(7).Visible = False

        End With

        Me.lblExpiredMsg.Visible = False
        Me.txtDrugName.Clear()
        Me.txtRecAmount.Clear()
        Me.txtSRNumber.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtStockLabel.Clear()
        Me.txtTotStock.Text = 0
        Me.txtOrderNo1.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtOrderNumber.Focus()

    End Sub

    Private Sub rdbRecieveDrug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRecieveDrug.CheckedChanged
        lblRecieveOrderNumber.Text = "Receive Number"
        lblRevieceAmount.Text = "Recieve Amount"
        lblRecieveDate.Text = "Recieve Date"
        strTType = "REC"
        o1.setoType("REC")
        strRDBText = "Recieve"

        Me.txtDrugName.Clear()
        Me.txtRecAmount.Clear()
        Me.txtSRNumber.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtStockLabel.Clear()
        Me.txtTotStock.Text = 0
        Me.txtOrderNo1.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtOrderNo1.Text = GenerateOrderNo()
        Me.txtOrderNumber.Focus()

    End Sub

    Private Sub rdbIssueDrug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbIssueDrug.CheckedChanged
        lblRecieveOrderNumber.Text = "Order Number"
        lblRevieceAmount.Text = "Order Amount"
        lblRecieveDate.Text = "Order Date"
        strTType = "ISS"
        o1.setoType("ISS")
        strRDBText = "Issue"

        Me.txtDrugName.Clear()
        Me.txtRecAmount.Clear()
        Me.txtSRNumber.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtStockLabel.Clear()
        Me.txtTotStock.Text = 0
        Me.txtOrderNo1.Clear()
        Me.txtOrderNumber.Clear()
        Me.txtOrderNo1.Text = GenerateOrderNo()
        Me.txtOrderNumber.Focus()
    End Sub

    Private Sub DrugDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clearALL()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        '   btnAdd.Enabled = False

        Dim strRes As String
        If strTType = "" Then
            msgB.msgOKInf("Please select a Transaction type to continue")
            Exit Sub
        End If

        strRes = o1.setoDateOfIsse(dtREcDate.Value)
        If strRes <> "OK" Then
            msgB.msgOKInf("Please check your date")
            Exit Sub
        End If

        strRes = o1.setONumber(Me.txtOrderNumber.Text)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Me.txtOrderNumber.Clear()
            Me.txtOrderNumber.Focus()
            Exit Sub
        End If
        strRes = d1.setdLabel(Me.txtStockLabel.Text)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Me.txtStockLabel.Clear()
            Me.txtStockLabel.Focus()
            Exit Sub
        End If
        strRes = d1.setDSRnumber(Me.txtSRNumber.Text)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Me.txtSRNumber.Clear()
            Me.txtSRNumber.Focus()
            Exit Sub
        End If
        strRes = d1.setdName(Me.txtDrugName.Text)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Me.txtDrugName.Clear()
            Me.txtDrugName.Focus()
            Exit Sub
        End If
        strRes = d1.setdManDAte(dtManDate.Value)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Exit Sub
        End If
        strRes = d1.setdExpDAte(dtDOExpiry.Value, dtManDate.Value)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)

            Exit Sub
        End If
        strRes = d1.setdRecieved(Me.txtRecAmount.Text, o1.getoType)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Exit Sub
        End If
        strRes = d1.setdTot(Me.txtTotStock.Text)
        If strRes <> STROK Then
            msgB.msgOKInf(strRes)
            Exit Sub
        End If
        ' added this condition to avoid trying to add DID before generating. DID is generated by the system when a new drug is added
        If o1.getoType = "ISS" Then
            DataGridView1.Rows.Add(d1.getdLabel, d1.getDSRnumber, d1.getdName, d1.getdManDAte, d1.getdExpDAte,
                            d1.getdRecieved, d1.getdTot, d1.getDID)
        Else
            DataGridView1.Rows.Add(d1.getdLabel, d1.getDSRnumber, d1.getdName, d1.getdManDAte, d1.getdExpDAte,
                           d1.getdRecieved, d1.getdTot)
        End If
        Me.txtSRNumber.Clear()
        Me.txtDrugName.Clear()
        Me.dtManDate.Value = Now
        Me.dtDOExpiry.Value = Now
        Me.txtStockLabel.Clear()

        Me.txtRecAmount.Clear()
        btnRemove.Enabled = True
        Me.btnUpdate.Enabled = True
        Me.txtTotStock.Text = "0"
        Me.txtRecAmount.Enabled = True


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ' Try
        If DataGridView1.Rows.Count - 1 = 0 Then
            msgB.msgOKInf("No data to save")
            Exit Sub
        End If
        Dim res As String
        '  msgB.msgOKInf(o1.getOnumber & " beofre setting")

        o1.setONumber(Me.txtOrderNo1.Text & Me.txtOrderNumber.Text)
        '  msgB.msgOKInf(o1.getOnumber & "after setting")

        If intViewed = 0 Then
            res = DAO.addOder(o1.getOnumber, o1.getoDateOfIsse, o1.getoType, DataGridView1.RowCount - 1)
        Else
            o1.setONumber(Me.txtOrderNo1.Text & "-" & Me.txtOrderNumber.Text)
            DAO.editOrder(o1.getOnumber, DataGridView1.RowCount - 1)
        End If


        If o1.getoType = "REC" Then
            Dim DrugID As String

            Dim inti As Integer

            For inti = intViewed To DataGridView1.Rows.Count - 2
                With DataGridView1.Rows(inti)
                    DrugID = GenerateDrugID()
                    DAO.addDrugDetailsPerOrder(DrugID, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value,
                                              .Cells(5).Value, .Cells(0).Value)

                    DAO.addOderDetails("0", o1.getOnumber, DrugID, .Cells(5).Value)


                End With
            Next
        End If
        If o1.getoType = "ISS" Then
            Dim intC As Integer

            For intC = intViewed To DataGridView1.Rows.Count - 2
                Dim daDrug = DAO.getDrugDetailsByDID(DataGridView1.Rows(intC).Cells(7).Value)
                DAO.edit_DrugDetailsbyDrugID(daDrug.Tables(strDBNAME).Rows(0).Item("dID"), DataGridView1.Rows(intC).Cells(6).Value)
                ' msgB.msgOKInf("Orderno when Issueing " & o1.getOnumber)
                DAO.addOderDetails("0", o1.getOnumber, daDrug.Tables(strDBNAME).Rows(0).Item("dID"), DataGridView1.Rows(intC).Cells(5).Value)
            Next
        End If
        msgB.msgOKInf("Added New order details successfully")
        MDIParent1.LoadDataGridData()
        MDIParent1.LoadGrid2Data()
        Call clearALL()
        'Catch ex As Exception
        '    msgB.msgOKCri(e.ToString)
        'End Try
    End Sub

    Private Sub txtOrderNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNumber.KeyDown

    End Sub

    Private Sub txtOrderNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderNumber.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            intViewed = 0 ' making this to 0 as this value should be loaded when loading
            If Me.rdbIssueDrug.Checked = False And Me.rdbRecieveDrug.Checked = False Then
                msgB.msgOKInf("Please select a transaction type")
                Call clearALL()
                Exit Sub
            End If
            o1.setONumber(Me.txtOrderNo1.Text & Me.txtOrderNumber.Text)
            ' msgB.msgOKInf(o1.getOnumber & "Order no on keypress event")
            If IsNothing(o1.getOnumber) = True Then
                msgB.msgOKInf(strRDBText + " number can not be a blank")
                Me.txtOrderNumber.Focus()
                Exit Sub
            End If
            Dim dsDROID = DAO.getOrderIDByOID(o1.getOnumber)
            If dsDROID.Tables(strDBNAME).Rows.Count = 0 Then
                Dim res As Boolean
                res = msgB.msgYesNoQuestion(strRDBText + " number does not exists. Do you want to add ?")
                If res = True Then
                    Me.txtSRNumber.Focus()
                    Exit Sub
                Else
                    Call clearALL()
                    Exit Sub
                End If
            Else
                Dim res As Boolean
                res = msgB.msgYesNoQuestion(strRDBText + " number already exists, Do you want to view ?")
                If res = True Then
                    Dim dsOR As DataSet = DAO.getOrderIDByOID(o1.getOnumber)
                    dtREcDate.Value = dsOR.Tables(strDBNAME).Rows(0).Item("OrderDate")
                    If dsOR.Tables(strDBNAME).Rows(0).Item("OrderType") = "REC" Then
                        rdbRecieveDrug.Checked = True
                        ' loading drug details even if it is issue or a Order if that order number exists
                    Else
                        ' rdbRecieveDrug.Checked = False
                        rdbIssueDrug.Checked = True
                    End If
                    Dim dsRdrug As DataSet = DAO.getOrderIDByOID(o1.getOnumber)
                    Dim str As Array = dsRdrug.Tables(strDBNAME).Rows(0).Item("OrderNo").ToString.Split("-")
                    Me.txtOrderNo1.Text = str(0)
                    Me.dtREcDate.Value = dsRdrug.Tables(strDBNAME).Rows(0).Item("OrderDate")
                    Dim strOType As String = dsRdrug.Tables(strDBNAME).Rows(0).Item("OrderType")
                    intViewed = dsRdrug.Tables(strDBNAME).Rows(0).Item("OrderItems")
                    If strOType = "REC" Then
                        Me.rdbRecieveDrug.Checked = True
                    End If
                    If strOType = "ISS" Then
                        Me.rdbIssueDrug.Checked = True
                    End If
                    Dim daA2 = DAO.getOrderDataByOrderID(Me.txtOrderNo1.Text & "-" & Me.txtOrderNumber.Text)
                    Dim daOdetails As DataSet
                    Dim drugId As String
                    Dim dtDrugData As DataSet
                    Dim into As Integer
                    For into = 0 To daA2.Tables(strDBNAME).Rows(into).Item("OrderItems") - 1
                        daOdetails = DAO.getOrderDetailsByOrderID(Me.txtOrderNo1.Text & "-" & Me.txtOrderNumber.Text)
                        drugId = daOdetails.Tables(strDBNAME).Rows(into).Item("DrugId")
                        dtDrugData = DAO.getDrugDataByDrugID(drugId)

                        With dtDrugData.Tables(strDBNAME).Rows(0)
                            DataGridView1.Rows.Add(.Item("dLabel").ToString, .Item("dSRNumber").ToString, .Item("dName").ToString, .Item("dManDate").ToString,
                                                .Item("dExpDate").ToString, .Item("dAvailAmt"), .Item("dAvailAmt"))
                        End With
                    Next
                    Exit Sub
                Else
                    Call clearALL()
                    Exit Sub
                End If
            End If
        End If
    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If DataGridView1.Rows.Count <> 1 Then
            If Not DataGridView1.CurrentRow.IsNewRow Then
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Else
                msgB.msgOKInf("No data to remove")
                btnRemove.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtRecAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecAmount.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim ResR = d1.setdRecieved(Me.txtRecAmount.Text, strRDBText)
            If ResR <> STROK Then
                msgB.msgOKInf(ResR)
                Me.txtRecAmount.Clear()
                Me.txtRecAmount.Focus()
                Exit Sub

            End If
            If o1.getoType = "REC" Then
                Me.txtTotStock.Text = Convert.ToDouble(Me.txtTotStock.Text) + Convert.ToDouble(Me.txtRecAmount.Text)
            ElseIf o1.getoType = "ISS" Then
                If Convert.ToInt32(Me.txtRecAmount.Text) > Convert.ToInt32(Me.txtTotStock.Text) Then
                    msgB.msgOKInf("Not enought stock. Please check the amount you need to issue")
                    Exit Sub
                Else
                    Me.txtTotStock.Text = Convert.ToDouble(Me.txtTotStock.Text) - Convert.ToDouble(Me.txtRecAmount.Text)
                End If
            Else
                msgB.msgOKCri("Seriouse Error ..!  Please contact your systems administrator for more inforamtion")
                '' Log this error.
                Exit Sub
            End If
            Me.txtRecAmount.Enabled = False
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub txtDrugName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDrugName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim res = d1.setdName(Me.txtDrugName.Text)
            If res <> STROK Then
                msgB.msgOKInf(res)
                Exit Sub
            End If
            d1.setdName(Me.txtDrugName.Text)
            If IsNothing(d1.getdName) = False Then
                Dim dsA As DataSet = DAO.getDrugDetails(d1.getdName)
                If dsA.Tables(strDBNAME).Rows.Count <> 0 And dsA.Tables(strDBNAME).Rows.Count <> 1 Then
                    Dim popUpDrug As New frmDrugPopUp
                    frm_DrubPopUPStatus = "BYNAME"
                    string_drugname = Me.txtDrugName.Text
                    blnDrugPopUpFromMenu = False
                    popUpDrug.ShowDialog()
                    '' we just load the drug name with the details
                ElseIf dsA.Tables(strDBNAME).Rows.Count = 1 Then
                    With dsA.Tables(strDBNAME).Rows(0)
                        d1.setDID(.Item("did"))
                        Me.txtSRNumber.Text = .Item("dSRNumber")
                        Me.txtDrugName.Text = .Item("dName")
                        Me.txtStockLabel.Text = .Item("dLabel")
                        If o1.getoType = "REC" Then
                            Me.txtTotStock.Text = 0
                            Me.dtManDate.Value = Now.Date
                            Me.dtDOExpiry.Value = Now.Date
                        Else
                            Me.txtTotStock.Text = .Item("dAvailAmt")
                            Me.dtManDate.Value = .Item("dManDate")
                            Me.dtDOExpiry.Value = .Item("dExpDate")
                        End If
                    End With
                Else
                    If o1.getoType = "ISS" Then
                        msgB.msgOKInf("Drug Not available in stocks. Try with DSR number...! ")
                        Me.txtDrugName.Clear()
                        Me.txtDrugName.Focus()

                    Else
                        Me.txtStockLabel.Focus()
                    End If
                    Exit Sub
                End If
            Else
                If o1.getoType = "ISS" Then
                    msgB.msgOKInf("Drug name not available in the stocks. Please check your spelling")
                    Me.txtDrugName.Clear()
                    Me.txtDrugName.Focus()
                Else
                    Me.txtStockLabel.Focus()
                End If
            End If
            Exit Sub
        End If
    End Sub

    Private Function GenerateOrderNo()
        Dim value As String = ""
        value = o1.getoType & Now.Year & Now.Month & Now.Day & "-"
        Return value

    End Function

    Private Function GenerateDrugID() As String
        Dim value As String = ""

        value = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond

        ' msgB.msgOKInf(value)
        Return value

    End Function

    Private Sub txtSRNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSRNumber.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            d1.setDSRnumber(Me.txtSRNumber.Text)
            If o1.getoType = "REC" Then
                Dim dsD = DAO.getDrugDetailsBySRNumber(d1.getDSRnumber)
                ' msgB.msgOKInf(dsD.Tables(strDBNAME).Rows.Count)
                If dsD.Tables(strDBNAME).Rows.Count = 0 Then
                    Dim res As Boolean = msgB.msgYesNoQuestion("Drug with SR number does not exisits. Do want to add new drug?")
                    If res = True Then
                        Me.txtDrugName.Focus()

                    Else
                        Call clearALL()

                    End If

                ElseIf dsD.Tables(strDBNAME).Rows.Count >= 1 Then
                    Dim res As Boolean = msgB.msgYesNoQuestion("Drug with SRNumer -" & Me.txtSRNumber.Text & " is already exists." & vbCrLf & "Do you wish to load exiting data (YES) or Add new data (NO) ")
                    If res = True Then
                        Dim popUpDrug As New frmDrugPopUp
                        frm_DrubPopUPStatus = "BYDSRNUMBER"
                        string_drugname = Me.txtSRNumber.Text
                        blnDrugPopUpFromMenu = False
                        popUpDrug.ShowDialog()
                        Exit Sub
                    Else
                        Me.txtDrugName.Focus()
                    End If
                Else
                    Me.txtDrugName.Clear()
                    Me.txtRecAmount.Clear()
                    Me.txtStockLabel.Clear()
                    Me.txtTotStock.Text = "0"


                    Exit Sub
                End If



            ElseIf o1.getoType = "ISS" Then

                Dim dsD = DAO.getDrugDetailsBySRNumber(d1.getDSRnumber)
                ' msgB.msgOKInf(dsD.Tables(strDBNAME).Rows.Count)
                If dsD.Tables(strDBNAME).Rows.Count = 0 Then
                    msgB.msgOKInf("Sorry Drug with DSRNumber not in the system")
                    Me.txtSRNumber.Clear()


                ElseIf dsD.Tables(strDBNAME).Rows.Count = 1 Then
                    With dsD.Tables(strDBNAME).Rows(0)
                        d1.setDID(.Item("DID"))
                        Me.txtSRNumber.Text = .Item("dSRNumber")
                        Me.txtDrugName.Text = .Item("dName")
                        Me.dtManDate.Value = .Item("dManDate")
                        Me.dtDOExpiry.Value = .Item("dExpDate")
                        Me.txtStockLabel.Text = .Item("dLabel")
                        Me.txtTotStock.Text = .Item("dAvailAmt")
                        Exit Sub
                    End With
                Else
                    'Dim res As Boolean = msgB.msgYesNoQuestion("Drug with SRNumer -" & Me.txtSRNumber.Text & " is already exists." & vbCrLf & "Do you wish to load exiting data (YES) or Add new data (NO) ")
                    'If res = True Then
                    Dim popUpDrug As New frmDrugPopUp
                    frm_DrubPopUPStatus = "BYDSRNUMBER"
                    string_drugname = Me.txtSRNumber.Text
                    blnDrugPopUpFromMenu = False
                    popUpDrug.ShowDialog()
                    Exit Sub

                End If

                End If

        End If
    End Sub

    Private Sub txtDrugName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDrugName.TextChanged

    End Sub

    Private Sub txtRecAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecAmount.TextChanged

    End Sub

    Private Sub txtSRNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSRNumber.TextChanged

    End Sub

    Private Sub dtDOExpiry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDOExpiry.ValueChanged
        If Me.rdbIssueDrug.Checked = True Then
            If dtDOExpiry.Value <= Now.Date Then
                Me.lblExpiredMsg.Visible = True
            Else
                Me.lblExpiredMsg.Visible = False
            End If
        End If
    End Sub

    Private Sub txtOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderNumber.TextChanged

    End Sub
End Class