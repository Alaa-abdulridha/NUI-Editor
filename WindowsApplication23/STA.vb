'(StringToByteArray) Function

Imports System.Linq
Module STA
    Public Function StringToByteArrayf(hexa As String) As Byte()
        Dim hex As String = hexa.Replace(" ", "")
        Return (From x In Enumerable.Range(0, hex.Length)
                Where (x Mod 2) = 0
                Select Convert.ToByte(hex.Substring(x, 2), &H10)).ToArray()
    End Function
End Module
