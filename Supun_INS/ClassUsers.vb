Public Class ClassUsers

    Private id As Integer
    Private uid As String
    Private upword As String


    Public Sub setId(ByVal strID As Integer)
        id = strID
    End Sub

    Public Function setId() As Integer
        Return id
    End Function

    Public Sub setuId(ByVal strUID As Integer)
        uid = strUID
    End Sub

    Public Function getUId() As String
        Return uid
    End Function

    Public Sub setupword(ByVal strupword As Integer)
        upword = strupword
    End Sub

    Public Function getupword() As String
        Return upword
    End Function

End Class
