'Reading the SPR function
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Public Class SPR

    Public Shared Function ToInt32(
    value As String
) As Integer

    End Function
    Public Shared Sub open(File As String, fm As Form1)
        Try
            fm.DataGridView1.DataSource = Nothing
            fm.DataGridView1.Refresh()
            fm.DataGridView1.Columns.Clear()
            Dim reader As New StreamReader(File, Encoding.ASCII)
            While reader.Peek() > -1
                Dim num As Integer = 0
                Dim str As String = reader.ReadLine()
                num = Convert.ToInt32(reader.ReadLine())
                Dim strArray As String() = New String(num - 1) {}
                Dim strArray2 As String() = New String(num - 1) {}
                Dim numArray As Integer() = New Integer(num - 1) {}
                For i As Integer = 0 To num - 1
                    strArray(i) = reader.ReadLine()
                    strArray2(i) = reader.ReadLine()
                    numArray(i) = Convert.ToInt32(reader.ReadLine())
                Next
                Dim item As New Form1.struc(str, num, strArray, numArray, strArray2)
                fm.SPR_List.Add(item)
            End While
            reader.Close()
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub


End Class
