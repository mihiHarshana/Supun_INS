''' <summary>
''' Provides the connections to the databases
''' 
''' </summary>
''' <remarks></remarks>
Public Class ClassDBConnection
    ''' <summary>
    ''' Provides the SQL server connecction 
    ''' </summary>
    ''' <returns></returns>
    Public Function getSQLDBConnection(ByVal strLServerName As String, ByVal strLServerUName As String, ByVal strLServerPassword As String, ByVal DBNAME As String)
        Try
            If ConnectionState.Closed Then
                MSGB.msgOKInf("No contact with SQL Server")
                Return False ' no contact with server
            Else
                Dim strDBcn As String
                strDBcn = "Provider=SQLOLEDB;Data Source=" & strLServerName & " ;User ID=" & strLServerUName & "; Password=" & strLServerPassword & "; Initial Catalog=" & DBNAME & "; "
                DBcn = New OleDb.OleDbConnection
                DBcn.ConnectionString = strDBcn
                DBcn.Open()
                Return True ' Connected
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            LogError.log(ex.Message & "DBConnectionClass")
            Return False
        End Try
    End Function

    Public Sub closeDBConnection()
        DBcn.Close()
    End Sub

    Public Function getAccessDBConnection(ByVal STR_DBNAME As String)
        Dim strdbname1 = STR_DBNAME & ".mdb"
        'Dim strDBcn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strdbname1 & ";Jet OLEDB:Database; "
        Dim strDBcn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strdbname1 & ";Persist Security Info=False"
        ' MessageBox.Show(strdbname1)
        Try
            DBcn = New OleDb.OleDbConnection
            DBcn.ConnectionString = strDBcn
            DBcn.Open()
        Catch ex As Exception
            ' dsM.msgOkCritial("Database error ..! Contact your System Administrator")
            MSGB.msgOKCri(ex.Message & " Error is logged")
            LogError.log(ex.Message & "DBconnection Class")
            End
        End Try
    End Function
End Class
