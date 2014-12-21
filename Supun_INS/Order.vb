Public Class Order
    Private oNumber As String
    Private oDateOfIsse As Date
    Private oType As String
    Private ErrorMsg As String = ""

    Public Function setONumber(ByVal value As String) As String
        If value = "" Then
            ErrorMsg = "Order Number cannot be blank"
        Else
            oNumber = value
            ErrorMsg = STROK
        End If
        Return ErrorMsg
    End Function

    Public Function getOnumber()
        Return oNumber
    End Function

    Public Function setoDateOfIsse(ByVal value As Date) As String
        ErrorMsg = STROK
        oDateOfIsse = value
        Return ErrorMsg
    End Function

    Public Function getoDateOfIsse()
        Return oDateOfIsse
    End Function

    Public Function setoType(ByVal value As String) As String
        oType = value
        Return STROK

    End Function

    Public Function getoType()
        Return oType
    End Function
End Class
