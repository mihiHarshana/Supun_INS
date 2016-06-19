Module Module1
    Public strDBNAME As String
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
    Public Const strVersion As String = "V3.2 Build 19062016_1133 "

    Public dtColor As New classMDataGridL
    Public blnDrugPopUpFromMenu As Boolean = False

    Public strAddUser As String = "AddUser" ' if add user if do the add user

    Public strLUserName As String = ""
    Public strLUType As String = ""

    Public rwtfData(1, 1) As String

End Module
