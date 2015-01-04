Public Class Drugs
    Private dSRnumber As String
    Private dName As String
    Private dManDAte As Date
    Private dExpDate As Date
    Private dRecieveDate As Date
    'Private dAvailableAmount As Double
    Private dRecieved As Double
    Private dLabel As String
    Private dTot As Double
    Private dId As String
    Public ErrorMsg As String = ""

    Public Function setDID(ByVal value As String) As String
        dId = value
        Return STROK
    End Function

    Public Function getDID() As String
        Return dId
    End Function


    Public Function setDSRnumber(ByVal value As String) As String
        If value = "" Then
            Return "SR Number cannot be blank"
        End If
        If Len(value) >= 9 Then
            Return "SR Number should be in 8 charactors"
        End If
        dSRnumber = value
        Return STROK
    End Function

    Public Function getDSRnumber() As String
        Return dSRnumber
    End Function

    Public Function setdName(ByVal value As String) As String
        If value = "" Then
            Return "Drug name cannot be blank"
        End If
        If Len(value) >= 50 Then
            Return "Drug Name should be in 50 charactors"
        End If
        dName = value
        Return STROK
    End Function

    Public Function getdName() As String
        Return dName
    End Function

    Public Function setdManDAte(ByVal value As Date) As String
        If value > Now Then
            Return "Manufacturing date cannot be in future"

        End If
        dManDAte = value
        Return STROK
    End Function

    Public Function getdManDAte() As Date
        Return dManDAte
    End Function
    Public Function setdExpDAte(ByVal value As Date, ByVal manDate As Date) As String
        If value < Now Then
            Return "Expiry date cannot be in past"
        End If
        If value < Now Then
            Return "Expiry date cannot be today"
        End If
        If manDate > value Then
            Return "Check the drug manfacture date and expire date are propserly entered"
        End If
        dExpDate = value
        Return STROK
    End Function

    Public Function getdExpDAte() As Date
        Return dExpDate

    End Function
    Public Function setdRecieveDate(ByVal value As Date) As String
        dRecieveDate = value
        Return STROK
    End Function

    Public Function getdRecieveDate() As Date
        Return dRecieveDate
    End Function

    'Public Function setdAvailableAmount(ByVal value As String) As String

    '    Return STROK
    'End Function

    Public Function getdRecieved() As String
        Return dRecieved
    End Function

    Public Function setdRecieved(ByVal value As Double, ByVal Ttype As String) As String
        If value = "" Then
            Return "Please enter value for " & Ttype
        End If
        If IsNumeric(value) = False Then
            Return Ttype & " amount cannot be Text "
        End If
        dRecieved = value
        Return STROK
    End Function

    Public Function setdRecieved(ByVal value As String, ByVal Ttype As String) As String
        If value = "" Then
            Return "Amount for " & Ttype & " cannot be blank"
        End If
        If IsNumeric(value) = False Then
            Return "Amount for " & Ttype & " cannot be Text"
        End If
        dRecieved = value
        Return STROK
    End Function

    'Public Function getdAvailableAmount() As String
    '    Return dAvailableAmount
    'End Function

    Public Function setdLabel(ByVal value As String) As String

        If value = "" Then
            Return "Please mention a store location"

        End If
        dLabel = value
        Return STROK
    End Function

    Public Function getdLabel() As String
        Return dLabel
    End Function

    Public Function setdTot(ByVal value As Double) As String
        dTot = value
        Return STROK
    End Function

    Public Function getdTot() As Double
        Return dTot
    End Function
End Class
