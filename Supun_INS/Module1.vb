Module Module1
    Public strDBNAME As String = "INS"
    Public DBcn As New OleDb.OleDbConnection

    Public STRTITLE As String

    Public msgB As New classMessages
    Public LogError As New classLogError
    Public DBConnection As New ClassDBConnection
    Public arrayPropfileData(,) As String
    Public DAO As New classDAOAccessDB
    Public user As New ClassUsers
    Public Const STROK As String = "OK"


    Public string_drugname As String = ""


    Public frm_drugDetails As New DrugDetails

End Module
