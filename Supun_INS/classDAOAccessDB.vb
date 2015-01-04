''' <summary>
''' This class is to access data from and to Access DB
''' </summary>
''' <remarks>Mihindu Wijesena 09/01/2013 </remarks>
Public Class classDAOAccessDB
    ''' <summary>
    ''' Checks the user availability.
    ''' checks for the user name and password
    ''' </summary>
    ''' <param name="strUName"></param>
    ''' <param name="strUpword"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getUsers(ByVal strUName As String, ByVal strUpword As String) As String
        DBConnection.getAccessDBConnection(strDBNAME)

        Dim ds As New DataSet
        Dim strsql As String = "Select * from table_Users where uName='" & strUName & "' and uPword= '" & strUpword & "'"
        Dim da As New OleDb.OleDbDataAdapter(strsql, DBcn)
        da.Fill(ds, STRDBNAME)
        Dim res As String
        If ds.Tables(STRDBNAME).Rows.Count = 1 Then
            If ds.Tables(strDBNAME).Rows(0).Item("uPword") = strUpword Then
                res = "OK"
            Else
                res = "Incorrect Password"
            End If
        Else
            res = "Invalid User Name"
        End If
        Return res
    End Function



    Public Function getLDetails1() As DataSet

        DBConnection.getAccessDBConnection(strDBNAME)

        Dim dsL As New DataSet
        Dim strSQLL As String = "Select * from LDetails1"

        Dim daL As New OleDb.OleDbDataAdapter(strSQLL, DBcn)
        daL.Fill(dsL, STRDBNAME)
        DBConnection.closeDBConnection()

        Return dsL

    End Function

    Public Function addDrugDetails(ByVal dID As Integer, ByVal dLabel As String, ByVal dsrNumber As String, ByVal dname As String, ByVal dManDate As Date,
                                   ByVal dExpDate As Date, ByVal dRecAmt As Double, ByVal dAvailAmount As Double, ByVal OId As String) As String

        DBConnection.getAccessDBConnection(strDBNAME)
        Dim dsA As New DataSet
        Dim STRSQLA As String = "Select * from table_Drug"
        Dim daA As New OleDb.OleDbDataAdapter(STRSQLA, DBcn)
        daA.Fill(dsA, strDBNAME)

        Dim cbA As New OleDb.OleDbCommandBuilder(daA)
        Dim dsnrA As DataRow
        dsnrA = dsA.Tables(strDBNAME).NewRow

        With dsnrA
            .Item("did") = getDrugTableCount()
            .Item("dLabel") = dLabel
            .Item("dsrNumber") = dsrNumber
            .Item("dname") = dname
            .Item("dmanDate") = dManDate
            .Item("dexpdate") = dExpDate
            .Item("dRecAmt") = dRecAmt
            .Item("dAvailAmt") = dAvailAmount
            .Item("OId") = OId

        End With
        dsA.Tables(strDBNAME).Rows.Add(dsnrA)
        daA.Update(dsA, strDBNAME)
        Return "Added"
    End Function
    ''' <summary>
    ''' GEt Drug Table count
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>


    'Public Function getDrugTableCount() As Integer
    '    DBConnection.getAccessDBConnection(strDBNAME)
    '    Dim strSQLC As String = "Select  *  from table_Drug "
    '    Dim dsC As New DataSet
    '    Dim daC As New OleDb.OleDbDataAdapter(strSQLC, DBcn)
    '    daC.Fill(dsC, strDBNAME)

    '    Dim rc As Integer = dsC.Tables(strDBNAME).Rows.Count

    '    Return rc
    'End Function

    ''' <summary>
    ''' Get order table count
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getOrderTableCount() As Integer
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLC As String = "Select  *  from table_OrderDetails "
        Dim dsC As New DataSet
        Dim daC As New OleDb.OleDbDataAdapter(strSQLC, DBcn)
        daC.Fill(dsC, strDBNAME)

        Dim rc As Integer = dsC.Tables(strDBNAME).Rows.Count

        Return rc
    End Function

    Public Function addOder(ByVal OrderNo As String, ByVal OrderDate As Date, ByVal OrderType As String, ByVal OrderItems As Integer) As String
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim dsA As New DataSet
        Dim STRSQLA As String = "Select * from table_Order"
        Dim daA As New OleDb.OleDbDataAdapter(STRSQLA, DBcn)
        daA.Fill(dsA, strDBNAME)

        Dim cbA As New OleDb.OleDbCommandBuilder(daA)
        Dim dsnrA As DataRow
        dsnrA = dsA.Tables(strDBNAME).NewRow

        With dsnrA
            .Item("OrderNo") = OrderNo
            .Item("OrderDate") = OrderDate
            .Item("OrderType") = OrderType
            .Item("OrderItems") = OrderItems

        End With
        dsA.Tables(strDBNAME).Rows.Add(dsnrA)
        daA.Update(dsA, strDBNAME)
        dsA = Nothing
        daA = Nothing

        Return "Added"
    End Function


    Public Function getOrderIDByOID(ByVal OID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Order where OrderNo = '" & OID & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function

    Public Function getDrugByOID(ByVal OID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where OrderNo = '" & OID & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function


    Public Function getDrugsExpireInThreeMonths(ByVal dtToday As Date) As DataSet
        Dim months As Date = dtToday.AddMonths(2)
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dExpDate >= '" & months & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function

    Public Function getDrugDetails(ByVal drugName As String) As DataSet
        '  Dim months As Date = dtToday.AddMonths(2)
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dName like '%" & drugName & "%'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function


    Public Function getDrugDetails(ByVal drugName As String, ByVal dsrNumbber As String) As DataSet
        '  Dim months As Date = dtToday.AddMonths(2)
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dName like '%" & drugName & "%' or dSRNumber like '%" & dsrNumbber & "%'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function

    Public Function getDrugDetailsByDSRNumber(ByVal DSRNumber As String) As DataSet
        '  Dim months As Date = dtToday.AddMonths(2)
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dSRNumber like '%" & DSRNumber & "%'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function


    Public Function addDrugDetailsPerOrder(ByVal dID As String, ByVal dSRNumber As String, ByVal dName As String, _
                                           ByVal dManDate As Date, ByVal dExpDate As Date, ByVal dAvailAmt As String, ByVal dLabel As String) As String
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim dsA As New DataSet
        Dim STRSQLA As String = "Select * from table_Drug"
        Dim daA As New OleDb.OleDbDataAdapter(STRSQLA, DBcn)
        daA.Fill(dsA, strDBNAME)

        Dim cbA As New OleDb.OleDbCommandBuilder(daA)
        Dim dsnrA As DataRow
        dsnrA = dsA.Tables(strDBNAME).NewRow

        With dsnrA
            .Item("dID") = dID
            .Item("dSRNumber") = dSRNumber
            .Item("dName") = dName
            .Item("dManDate") = dManDate
            .Item("dExpDate") = dExpDate
            .Item("dAvailAmt") = dAvailAmt
            .Item("dLabel") = dLabel

        End With
        dsA.Tables(strDBNAME).Rows.Add(dsnrA)
        daA.Update(dsA, strDBNAME)
        Return "Added"
        DBConnection.closeDBConnection()
    End Function

    Public Function getDrugTableCount() As Integer
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLC As String = "Select   COUNT (*)  from table_Drug "
        Dim dsC As New DataSet
        Dim daC As New OleDb.OleDbDataAdapter(strSQLC, DBcn)
        daC.Fill(dsC, strDBNAME)

        ' msgB.msgOKInf("row count is" & dsC.Tables(strDBNAME).Rows(0).Item(0).ToString)
        Dim rc As Integer = dsC.Tables(strDBNAME).Rows(0).Item(0)

        Return rc
    End Function

    Public Function addOderDetails(ByVal ID As String, ByVal OrderNo As String, ByVal DrugId As String, _
                                          ByVal OrderAmount As String) As String
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim dsA As New DataSet
        Dim STRSQLA As String = "Select * from table_OrderDetails"
        Dim daA As New OleDb.OleDbDataAdapter(STRSQLA, DBcn)
        daA.Fill(dsA, strDBNAME)

        Dim cbA As New OleDb.OleDbCommandBuilder(daA)
        Dim dsnrA As DataRow
        dsnrA = dsA.Tables(strDBNAME).NewRow

        With dsnrA
            '.Item("id") = ID
            .Item("OrderNo") = OrderNo
            .Item("DrugId") = DrugId
            .Item("OrderAmount") = OrderAmount



        End With
        dsA.Tables(strDBNAME).Rows.Add(dsnrA)
        daA.Update(dsA, strDBNAME)
        Return "Added"
        DBConnection.closeDBConnection()
    End Function


    Public Function getOrderDetailsByOrderID(ByVal OrderID As String) As DataSet

        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_OrderDetails where OrderNo = '" & OrderID & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function


    Public Function getDrugDataByDrugID(ByVal drugID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID1 As String = "Select * from table_drug where dID = '" & drugID & "'"
        Dim dsOID1 As New DataSet
        Dim daOID1 As New OleDb.OleDbDataAdapter(strSQLOID1, DBcn)
        daOID1.Fill(dsOID1, strDBNAME)
        Return dsOID1


    End Function

    Public Function getOrderDataByOrderID(ByVal OrderID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID1 As String = "Select * from table_Order where OrderNo = '" & OrderID & "'"
        Dim dsOID1 As New DataSet
        Dim daOID1 As New OleDb.OleDbDataAdapter(strSQLOID1, DBcn)
        daOID1.Fill(dsOID1, strDBNAME)
        Return dsOID1


    End Function

    Public Function getDrugDetailsByDSRumAndDName(ByVal dSRNumber As String, ByVal dName As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID1 As String = "Select * from table_Drug where dName = '" & dName & "' and  dSRNumber = '" & dSRNumber & "'"
        Dim dsOID1 As New DataSet
        Dim daOID1 As New OleDb.OleDbDataAdapter(strSQLOID1, DBcn)
        daOID1.Fill(dsOID1, strDBNAME)
        Return dsOID1

    End Function

    Public Function getDrugDetailsByDID(ByVal DID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID1 As String = "Select * from table_Drug where DID = '" & DID & "'"
        Dim dsOID1 As New DataSet
        Dim daOID1 As New OleDb.OleDbDataAdapter(strSQLOID1, DBcn)
        daOID1.Fill(dsOID1, strDBNAME)
        Return dsOID1

    End Function

    Public Function edit_DrugDetailsbyDrugID(ByVal drugID As String, ByVal availAmount As String)
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLU As String = "Select * from table_Drug where dID='" & drugID & "'"
        Dim dsU As New DataSet
        Dim daU As New OleDb.OleDbDataAdapter(strSQLU, DBcn)
        Dim cbU As New OleDb.OleDbCommandBuilder(daU)
        daU.Fill(dsU, strDBNAME)
        'Dim intU As Integer
        With dsU.Tables(strDBNAME)
            '  For intU = 0 To .Rows.Count - 1
            .Rows(0).Item("dAvailAmt") = availAmount
            ' Next
            daU.Update(dsU, strDBNAME)
            strSQLU = Nothing
            daU = Nothing
            dsU = Nothing
            cbU = Nothing
            GC.Collect()
            Return True
        End With
    End Function
    Public Function getDrugDetailsBySRNumber(ByVal dSRNumber As String) As DataSet

        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dSRNumber = '" & dSRNumber & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)
        Return dsOID
    End Function

    Public Function getAllOrderDetails() As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        'Dim strSQLOID As String = "Select table_Order.OrderNo , table_order.OrderDate , table_order.OrderType, table_OrderDetails.DrugId, table_OrderDetails.OrderAmount  from table_Order INNER JOIN table_OrderDetails ON table_Order.OrderNo = table_OrderDetails.OrderNo"
        'Dim strSQLOID As String = "Select table_Order.OrderNo , table_order.OrderDate , table_order.OrderType, table_OrderDetails.DrugId, table_OrderDetails.OrderAmount  from table_Order LEFT JOIN table_OrderDetails ON table_Order.OrderNo = table_OrderDetails.OrderNo"

        Dim strSQLOID As String = "Select table_OrderDetails.OrderNo, table_OrderDetails.DrugId, table_OrderDetails.OrderAmount,table_Order.OrderDate, table_order.OrderType from  table_OrderDetails INNER JOIN table_Order ON table_OrderDetails.OrderNo = table_Order.OrderNo"

        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)
        Return dsOID
    End Function

    Public Function getDrugNameByDrugID(ByVal drugID As String) As String
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where dID = '" & drugID & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)
        Return dsOID.Tables(strDBNAME).Rows(0).Item("dname")

    End Function
End Class
