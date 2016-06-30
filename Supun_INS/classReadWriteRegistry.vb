Public Class classReadWriteRegistry

    Public Sub setValueToRegistry(ByVal subKey As String, ByVal value As String, ByVal data As String)
        My.Computer.Registry.CurrentUser.CreateSubKey(subKey)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & subKey, value, data)
    End Sub

    Public Function getValueFromRegistryByPath(ByVal subKey As String, ByVal value As String) As String
        'If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" & subKey,
        '    value, Nothing) Is Nothing Then
        '    Return "NOTOK"
        'Else
        '    Return STROK
        'End If

        Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" & subKey, value, Nothing)
        If IsNothing(readValue) Then
            Return "NOTHING"
        Else
            Return readValue
        End If


    End Function




End Class
