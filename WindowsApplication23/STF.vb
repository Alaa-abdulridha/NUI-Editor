'(String To File) Function

Imports System
Imports System.IO
Module STF


    Public Class StringToFile
        Public Shared Function CLASSTYPEID(br As BinaryReader) As String
            Dim str As String = Convert.ToString(br.ReadByte(), &H10)
            If str.Length < 2 Then
                str = Convert.ToString("0") & str
            End If
            Select Case str.Replace("a", "A").ToString().Replace("b", "B").ToString().Replace("c", "C").ToString().Replace("d", "D").ToString().Replace("e", "E").ToString().Replace("f", "F").ToString()
                Case "00"
                    Return "NONE"

                Case "28"
                    Return "WORD"

                Case "29"
                    Return "DWORD"

                Case "2A"
                    Return "FLOAT"

                Case "2C"
                    Return "CHAR"

                Case "2D"
                    Return "UCHAR"

                Case "33"
                    Return "STRING"

                Case "34"
                    Return "ARRAY"

                Case "1F"
                    Return "TEMPLATE"
            End Select
            Return "NULL"
        End Function

        Public Shared Function GUI(br As BinaryReader) As String
            Dim str2 As String = Convert.ToString(br.ReadByte(), &H10)
            If str2.Length < 2 Then
                str2 = Convert.ToString("0") & str2
            End If
            Dim str10 As String = Convert.ToString(br.ReadByte(), &H10)
            If str10.Length < 2 Then
                str10 = Convert.ToString("0") & str10
            End If
            Dim str3 As String = Convert.ToString(br.ReadByte(), &H10)
            If str3.Length < 2 Then
                str3 = Convert.ToString("0") & str3
            End If
            Dim str11 As String = Convert.ToString(br.ReadByte(), &H10)
            If str11.Length < 2 Then
                str11 = Convert.ToString("0") & str11
            End If
            Dim str4 As String = Convert.ToString(br.ReadByte(), &H10)
            If str4.Length < 2 Then
                str4 = Convert.ToString("0") & str4
            End If
            Dim str12 As String = Convert.ToString(br.ReadByte(), &H10)
            If str12.Length < 2 Then
                str12 = Convert.ToString("0") & str12
            End If
            Dim str5 As String = Convert.ToString(br.ReadByte(), &H10)
            If str5.Length < 2 Then
                str5 = Convert.ToString("0") & str5
            End If
            Dim str13 As String = Convert.ToString(br.ReadByte(), &H10)
            If str13.Length < 2 Then
                str13 = Convert.ToString("0") & str13
            End If
            Dim str6 As String = Convert.ToString(br.ReadByte(), &H10)
            If str6.Length < 2 Then
                str6 = Convert.ToString("0") & str6
            End If
            Dim str14 As String = Convert.ToString(br.ReadByte(), &H10)
            If str14.Length < 2 Then
                str14 = Convert.ToString("0") & str14
            End If
            Dim str7 As String = Convert.ToString(br.ReadByte(), &H10)
            If str7.Length < 2 Then
                str7 = Convert.ToString("0") & str7
            End If
            Dim str15 As String = Convert.ToString(br.ReadByte(), &H10)
            If str15.Length < 2 Then
                str15 = Convert.ToString("0") & str15
            End If
            Dim str8 As String = Convert.ToString(br.ReadByte(), &H10)
            If str8.Length < 2 Then
                str8 = Convert.ToString("0") & str8
            End If
            Dim str16 As String = Convert.ToString(br.ReadByte(), &H10)
            If str16.Length < 2 Then
                str16 = Convert.ToString("0") & str16
            End If
            Dim str9 As String = Convert.ToString(br.ReadByte(), &H10)
            If str9.Length < 2 Then
                str9 = Convert.ToString("0") & str9
            End If
            Dim str17 As String = Convert.ToString(br.ReadByte(), &H10)
            If str17.Length < 2 Then
                str17 = Convert.ToString("0") & str17
            End If
            Return (Convert.ToString(Convert.ToString(Convert.ToString(Convert.ToString(Convert.ToString(Convert.ToString((Convert.ToString(Convert.ToString((Convert.ToString(Convert.ToString((Convert.ToString(Convert.ToString((Convert.ToString(Convert.ToString(str11 & str3) & str10) & str2) + "-") & str12) & str4) + "-") & str13) & str5) + "-") & str6) & str14) + "-") & str7) & str15) & str8) & str16) & str9) & str17).Replace("a", "A").ToString().Replace("b", "B").ToString().Replace("c", "C").ToString().Replace("d", "D").ToString().Replace("e", "E").ToString().Replace("f", "F").ToString()
        End Function

        Public Shared Function Str128(sentence As String) As Byte()
            If sentence = "0" Then
                Dim str As String = "30"
                For j As Integer = 0 To 126
                    str = str & Convert.ToString("00")
                Next
                Return STA.StringToByteArrayf(str)
            End If
            Dim hexa As String = STH.StringToHEX(sentence)
            hexa.Replace("0", "")
            For i As Integer = 0 To (&H80 - sentence.Length) - 1
                hexa = hexa & Convert.ToString("00")
            Next
            Return STA.StringToByteArrayf(hexa)
        End Function

        Public Shared Function Str256(sentence As String) As Byte()
            If sentence = "0" Then
                Dim str As String = "30"
                For j As Integer = 0 To 254
                    str = str & Convert.ToString("00")
                Next
                Return STA.StringToByteArrayf(str)
            End If
            Dim hexa As String = STH.StringToHEX(sentence)
            hexa.Replace("0", "")
            For i As Integer = 0 To (&H100 - sentence.Length) - 1
                hexa = hexa & Convert.ToString("00")
            Next
            Return STA.StringToByteArrayf(hexa)
        End Function

        Public Shared Function Str512(sentence As String) As Byte()
            If sentence = "0" Then
                Dim str As String = "30"
                For j As Integer = 0 To 510
                    str = str & Convert.ToString("00")
                Next
                Return STA.StringToByteArrayf(str)
            End If
            Dim hexa As String = STH.StringToHEX(sentence)
            hexa.Replace("0", "")
            For i As Integer = 0 To (&H200 - sentence.Length) - 1
                hexa = hexa & Convert.ToString("00")
            Next
            Return STA.StringToByteArrayf(hexa)
        End Function

        Public Shared Function Str64(sentence As String) As Byte()
            If sentence = "0" Then
                Dim str As String = "30"
                For j As Integer = 0 To 62
                    str = str & Convert.ToString("00")
                Next
                Return StringToByteArrayf(str)
            End If
            Dim hexa As String = STH.StringToHEX(sentence)
            hexa.Replace("0", "")
            For i As Integer = 0 To (&H40 - sentence.Length) - 1
                hexa = hexa & Convert.ToString("00")
            Next
            Return STA.StringToByteArrayf(hexa)
        End Function
    End Class
End Module
