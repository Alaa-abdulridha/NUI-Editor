Imports System.IO

Public Class edit
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Environment.CurrentDirectory + "/nui/" + obj2, Me
        Dim rtb As New RichTextBox
        MsgBox(Form1.file_path)
        rtb.LoadFile(Form1.file_path, RichTextBoxStreamType.PlainText)
        rtb.Text = rtb.Text.Replace(Form1.temp_coloumn_6_value, TextBox1.Text)
        'rtb.SaveFile(Form1.file_path, RichTextBoxStreamType.PlainText)
letsTry:
        Try
            File.WriteAllText(Form1.file_path, rtb.Text)
        Catch ex As Exception
            If (ex.ToString.Contains("used")) Then
                GoTo letsTry
            End If
        End Try

        NUI.open(Form1.file_path, Form1)
        Form1.appState.Text = "Saved! & refreshed!"
        Me.Close()
    End Sub
    Public newFile_text As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NUI.edit(TextBox1.Text)
        Form1.appState.Text = "Saved! & refreshed!"
        NUI.open(Form1.file_path, Form1)
    End Sub
    Dim my_default_value As String
    Function load_it()
        my_default_value = TextBox1.Text
        GroupBox1.Text = Form1.column_name
        Me.Text = Form1.column_name
        'get rect information to dark all around the rect
        Dim words As String() = Form1.rect_value.Split(New Char() {","c})
        Dim rect_x As Integer
        Dim rect_y As Integer
        Dim rect_width As Integer
        Dim rect_height As Integer
        Dim count As Integer = 1
        For Each word In words
            If (count = 1) Then
                rect_x = word
            ElseIf (count = 2) Then
                rect_y = word
            ElseIf (count = 3) Then
                rect_width = word
            ElseIf (count = 4) Then
                rect_height = word
            End If
            count += 1
        Next
        Form1.PaintImage(New Rectangle(rect_x, rect_y, rect_width, rect_height))
        ' IF rect
        If (Form1.column_name.Contains("rect")) Then
            GroupBox1.Visible = True
            TextBox2.Text = rect_x
            TrackBar1.Value = rect_x
            TextBox3.Text = rect_y
            TrackBar2.Value = rect_y
            TextBox4.Text = rect_width
            TrackBar3.Value = rect_width
            TextBox5.Text = rect_height
            TrackBar4.Value = rect_height
            count += 1
        Else
            GroupBox1.Visible = False
        End If
    End Function
    Private Sub edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_it()
    End Sub


    Private Sub edit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub edit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        TextBox2.Text = TrackBar1.Value
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.PerformClick()
        Form1.PaintImage(New Rectangle(0, 2048, 2048, 2048))
        Me.Close()
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        TextBox3.Text = TrackBar2.Value
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        TextBox4.Text = TrackBar3.Value
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        TextBox5.Text = TrackBar4.Value
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TrackBar1.Value = TextBox2.Text
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TrackBar2.Value = TextBox3.Text
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TrackBar3.Value = TextBox4.Text
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TrackBar4.Value = TextBox5.Text
        TextBox1.Text = TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text
        Form1.PaintImage(New Rectangle(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value, TrackBar4.Value))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (Form1.column_name.Contains("rect")) Then
            Dim words As String() = my_default_value.Split(New Char() {","c})
            Dim count As Integer = 1
            For Each word In words
                If (count = 1) Then
                    TextBox2.Text = word
                    TrackBar1.Value = word
                ElseIf (count = 2) Then
                    TextBox3.Text = word
                    TrackBar2.Value = word
                ElseIf (count = 3) Then
                    TextBox4.Text = word
                    TrackBar3.Value = word
                ElseIf (count = 4) Then
                    TextBox5.Text = word
                    TrackBar4.Value = word
                End If
                count += 1
            Next
        Else
            TextBox1.Text = my_default_value
        End If
    End Sub

    Private Sub edit_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub
End Class