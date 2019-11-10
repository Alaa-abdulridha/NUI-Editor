' Reading the RDB function
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Public Class RDB


    Public Shared Sub open(File As String, fm As Form1)
        Try
            fm.DataGridView1.DataSource = Nothing
            fm.DataGridView1.Refresh()
            fm.DataGridView1.Columns.Clear()
            Dim reader As New BinaryReader(New FileStream(File, FileMode.Open), Encoding.ASCII) ' The read encoding (ASCII).
            reader.BaseStream.Seek(&H84L, SeekOrigin.Begin)
            While reader.PeekChar() > -1
                Dim count As Integer = reader.ReadInt32()
                Dim num2 As Integer = reader.ReadInt32()
                Dim str As String = Convert.ToString(BytesToStringASCIIf(reader.ReadBytes(count)))
                Dim str2 As String = Convert.ToString(BytesToStringASCIIf(reader.ReadBytes(num2)))
                Dim num3 As Integer = reader.ReadInt32()
                Dim num4 As Integer = reader.ReadInt32()
                reader.ReadInt32()
                reader.ReadInt32()
                reader.ReadInt32()
                reader.ReadInt32()
                Dim item As New Form1.RDB_String(num3, num4, str, str2)
                fm.RDB_List.Add(item)
                'MsgBox("ID : " & num3 & " | Value : " & str2) ' just to test
            End While
            reader.Close()
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub


End Class
