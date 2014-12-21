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


    Public Function getDrugTableCount() As Integer
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLC As String = "Select  *  from table_Drug "
        Dim dsC As New DataSet
        Dim daC As New OleDb.OleDbDataAdapter(strSQLC, DBcn)
        daC.Fill(dsC, strDBNAME)

        Dim rc As Integer = dsC.Tables(strDBNAME).Rows.Count

        Return rc
    End Function

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

    Public Function addOderDetails(ByVal id As Integer, ByVal oid As String, ByVal ORTDAte As Date, ByVal OTRtype As String) As String
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim dsA As New DataSet
        Dim STRSQLA As String = "Select * from table_OrderDetails"
        Dim daA As New OleDb.OleDbDataAdapter(STRSQLA, DBcn)
        daA.Fill(dsA, strDBNAME)

        Dim cbA As New OleDb.OleDbCommandBuilder(daA)
        Dim dsnrA As DataRow
        dsnrA = dsA.Tables(strDBNAME).NewRow

        With dsnrA
            .Item("id") = id
            .Item("Oid") = oid
            .Item("OTRDate") = ORTDAte
            .Item("OTRType") = OTRtype
        End With
        dsA.Tables(strDBNAME).Rows.Add(dsnrA)
        daA.Update(dsA, strDBNAME)
        Return "Added"
    End Function


    Public Function getOrderDetailsByOID(ByVal OID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_OrderDetails where OID = '" & OID & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function

    Public Function getDrugDetailsByOID(ByVal OID As String) As DataSet
        DBConnection.getAccessDBConnection(strDBNAME)
        Dim strSQLOID As String = "Select * from table_Drug where OID = '" & OID & "'"
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
        Dim strSQLOID As String = "Select * from table_Drug where dName = '" & drugName & "'"
        Dim dsOID As New DataSet
        Dim daOID As New OleDb.OleDbDataAdapter(strSQLOID, DBcn)
        daOID.Fill(dsOID, strDBNAME)

        Return dsOID

    End Function
End Class