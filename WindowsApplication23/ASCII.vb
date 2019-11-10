'This file now is support the Window-1256 encoding , If you want it to read Ascii or windows-1252 You need to do like this


'Return Reverse(ASCIIfToAr(Encoding.[Default].GetString(bytes)))
'Dim converted As New String(Encoding.GetEncoding(1252).GetChars(rawBytes))
'        Return converted


Imports System.Text
Module ASCII
    Public Function BytesToStringASCIIf(b As Byte()) As String
        Dim num As Integer = 0
        For i As Integer = 0 To b.Length - 1
            If b(i) <= 0 Then
                Exit For
            End If
            num += 1
        Next
        Dim bytes As Byte() = New Byte(num - 1) {}
        For j As Integer = 0 To num - 1
            If b(j) <= 0 Then
                Exit For
            End If
            bytes(j) = b(j)
        Next
   
        Return Reverse(ASCIIfToAr(Encoding.[Default].GetString(bytes)))

    End Function
    Public Function ASCIIfToAr(ASCII As String)  'The encoding function start
        Dim badEncodingText As String = ASCII
        Dim rawBytes As Byte() = Encoding.Default.GetBytes(badEncodingText)
        Dim converted As New String(Encoding.GetEncoding(1256).GetChars(rawBytes))
        Return converted
    End Function
    Public Function Reverse(ByVal input As String) As String
        If CheckForAlphaCharacters(input) Then
            Return input
        Else
            Return String.Join(" ", input.Split(" ").Reverse())
        End If
    End Function

    Public Function CheckForAlphaCharacters(ByVal StringToCheck As String)


        Return RegularExpressions.Regex.IsMatch(StringToCheck, "[A-Z][a-z][0-9]")


    End Function
End Module
