''' <summary>
''' This class s used to read and write to a text file
''' </summary>
''' <remarks>Mihindu Wijesena 02/09/2012</remarks>
Public Class classReadWriteTextFile
    Private ARRAYDATA(,) As String = Nothing ' holds all values in Propertyfile
    Public Function GetPropertyFileDAta() As Array
        Dim FILE_NAME As String = "Property.txt"
        ' Dim TextLine As String
        Dim intocunt As Integer
        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            intocunt = 0
            Dim lines As String() = IO.File.ReadAllLines(FILE_NAME)
            '  ReDim strDataPropFile(lines.Length)
            ReDim ARRAYDATA(lines.Length, 1)
            Dim intC As Integer = 0
            Dim intCend As Integer = 1 ' this value should be same as array Column
            For intocunt = 0 To lines.Length
                If objReader.Peek <> -1 Then
                    ' intLength.SetValue(objReader.ReadLine(), intocunt)
                    Dim STRLineDATA = objReader.ReadLine().Split("=")
                    For intC = 0 To intCend
                        ARRAYDATA(intocunt, intC) = STRLineDATA(intC)
                        '  MessageBox.Show(ARRAYDATA(intocunt, intC))
                    Next
                End If
            Next
            Return ARRAYDATA
            intC = Nothing
            intCend = Nothing
            GC.Collect()
        Else
            MessageBox.Show("File not Available")
        End If
    End Function
End Class
