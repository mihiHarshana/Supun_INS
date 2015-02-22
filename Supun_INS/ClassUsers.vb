Public Class ClassUsers

    Private id As Integer
    Private uid As String
    Private upword As String
    Private utype As String
    Private uName As String

    Public Sub setId(ByVal strID As Integer)
        id = strID
    End Sub

    Public Function getId() As Integer
        Return id
    End Function

    Public Sub setuId(ByVal strUID As Integer)
        uid = strUID
    End Sub

    Public Function getUId() As String
        Return uid
    End Function

    Public Function setupword(ByVal strupword As String)
        If Trim(strupword) = "" Then
            Return "Password cannot be blank"
        End If
        If Len(strupword) > 50 Then
            Return "Password cannot be more than 50 charactors"
        End If
        upword = strupword
        Return STROK
    End Function
    Public Function setupword(ByVal strupword As String, ByVal strUpword2 As String)
        If Trim(strupword) = "" Then
            Return "Password cannot be blank"
        End If
        If Len(strupword) > 50 Then
            Return "Password cannot be more than 50 charactors"
        End If
        If Trim(strUpword2) = "" Then
            Return "Re enter Password cannot be blank"
        End If
        If Len(strUpword2) > 50 Then
            Return "Re Enter Password cannot be more than 50 charactors"
        End If

        If strupword <> strUpword2 Then
            Return "Password doesnt match"
        End If
        upword = strupword
        Return STROK
    End Function

    Public Function getupword() As String
        Return upword
    End Function

    Public Function setuType(ByVal strUtype As String)
        If strUtype = "" Then
            Return "User type cannot be blank"
        End If

        utype = strUtype
        Return STROK
    End Function


    Public Function getUType() As String
        Return utype
    End Function

    Public Function setuName(ByVal strUName As String) As String
        '  Dim strRes As String = ""
        If Trim(strUName) = "" Then
            Return "User Name cannot be blank"
        End If
        If Len(strUName) > 50 Then
            Return "User name cannot be more than 50 charactors"
        End If

        uName = strUName
        Return STROK
    End Function

    Public Function getUName() As String
        Return uName
    End Function
End Class
