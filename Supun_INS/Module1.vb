Module Module1
    Public strDBNAME As String = "INS"
    Public DBcn As New OleDb.OleDbConnection

    Public STRTITLE As String = "Message"

    Public msgB As New classMessages
    Public LogError As New classLogError
    Public DBConnection As New ClassDBConnection
    Public arrayPropfileData(,) As String
    Public DAO As New classDAOAccessDB
    Public user As New ClassUsers
    Public Const STROK As String = "OK"


    Public string_drugname As String = ""
    Public string_dsrNumber As String = ""


    Public frm_drugDetails As DrugDetails
    Public frm_DrubPopUPStatus As String = ""


    Public d1 As New Drugs
    Public o1 As New Order
    Public Const strVersion As String = "V1.2 Build 21022015_2344_Snapshot"

    Public dtColor As New classMDataGridL


    Public blnDrugPopUpFromMenu As Boolean = False
End Module
