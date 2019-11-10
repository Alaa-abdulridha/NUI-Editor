'(StringToHEX ) Function
Module STH
    Public Function StringToHex(asciiString As String) As String
        Dim str As String = ""
        For Each ch As Char In asciiString
            Dim num As Char = ch
            str = str & String.Format("{0:x2}", Convert.ToUInt32(num.ToString()))
        Next
        Return str
    End Function
End Module
