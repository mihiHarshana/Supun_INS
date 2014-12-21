''' <summary>
''' Provides the message box functionality 
''' </summary>
''' <remarks>Mihindu Wijesena 
''' 02/09/2012
''' </remarks>
Public Class classMessages

    Public Sub msgOKInf(ByVal strMessage)
        MessageBox.Show(strMessage, STRTITLE, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub msgOKCri(ByVal strMessage)
        MessageBox.Show(strMessage, STRTITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Public Function msgYesNoQuestion(ByVal strMessage) As Boolean
        Dim res As Integer
        res = MessageBox.Show(strMessage, STRTITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = vbYes Then
            Return True
        Else
            Return False
        End If

    End Function
End Class
