'Reading the NUI function
Imports Paloma
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.WinForms
Imports System.Text.RegularExpressions

Public Class NUI
    Public Shared Sub open(File As String, fm As Form1)
        Try
            fm.DataGridView1.DataSource = Nothing
            fm.DataGridView1.Refresh()
            fm.DataGridView1.Columns.Clear()
            Dim reader As New StreamReader(File, Encoding.ASCII)
            Dim num As Integer = 0
            fm.DataGridView1.Columns.Add("Column Name", "type")
            fm.DataGridView1.Columns.Add("Column Name", "identifier")
            fm.DataGridView1.Columns.Add("Column Name", "spr")
            fm.DataGridView1.Columns.Add("Column Name", "ani")
            fm.DataGridView1.Columns.Add("Column Name", "rect")
            fm.DataGridView1.Columns.Add("Column Name", "flag")
            fm.DataGridView1.Columns.Add("Column Name", "caption")
            fm.DataGridView1.Columns.Add("Column Name", "style")
            fm.DataGridView1.Columns.Add("Column Name", "Image")
            fm.DataGridView1.Columns.Add("Column Name", "String")
            fm.DataGridView1.Columns.Add("Column Name", "line")
            While reader.Peek() > -1
                Dim strArray As String() = reader.ReadLine().Split(New Char() {" "c})
                If strArray(0) = "begin" Then
                    fm.DataGridView1.Rows.Add()
                    fm.DataGridView1.Rows(num).Cells(0).Value = strArray(1) 'the type loader
                    fm.DataGridView1.Rows(num).Cells(1).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(2).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(3).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(4).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(5).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(6).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(7).Value = "NULL"
                    fm.DataGridView1.Rows(num).Cells(8).Value = ""
                    fm.DataGridView1.Rows(num).Cells(9).Value = ""
                    fm.DataGridView1.Rows(num).Cells(10).Value = ""
                    Dim num2 As Integer = 0
                    While num2 < 1
                        strArray = reader.ReadLine().Replace(";", "").Replace(" = ", "=").Split(New Char() {"="c})
                        If strArray(0) = "id" Then
                            fm.DataGridView1.Rows(num).Cells(1).Value = strArray(1)
                        End If
                        If strArray(0) = "spr" Then
                            fm.DataGridView1.Rows(num).Cells(2).Value = strArray(1)
                        End If
                        If strArray(0) = "ani" Then
                            fm.DataGridView1.Rows(num).Cells(3).Value = strArray(1)
                        End If
                        If strArray(0) = "rect" Then
                            fm.DataGridView1.Rows(num).Cells(4).Value = strArray(1)
                        End If
                        If strArray(0) = "flag" Then
                            fm.DataGridView1.Rows(num).Cells(5).Value = strArray(1)
                        End If
                        If strArray(0) = "caption" Then
                            fm.DataGridView1.Rows(num).Cells(6).Value = strArray(1)
                        End If
                        If strArray(0) = "style" Then
                            fm.DataGridView1.Rows(num).Cells(7).Value = strArray(1)
                        End If
                        If strArray(0) = "end" Then
                            num += 1
                            Exit While
                        End If
                    End While
                End If
            End While
            reader.Close()
            fm.PictureBox1.Refresh()
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub


    Public Shared Sub edit(new_text As String)
        Dim source As String = File.ReadAllText(Form1.file_path)
        Dim stringSeparators() As String = {"begin"}
        Dim result() As String
        Dim final_string As String
        result = source.Split(stringSeparators, StringSplitOptions.None)
        Dim count As Integer = 0
        For Each thing In result
            Dim thing_edited = "begin" & thing
            If (Not thing = "") Then
                If ((count) = Form1.row_num) Then
                    Dim tm As String() = thing_edited.Split(vbLf)
                    For Each line As String In tm
                        Dim line_String As String
                        If (line.Contains(Form1.column_name)) Then
                            line_String = Form1.column_name & " = " & new_text & ";"
                        Else
                            line_String = line
                        End If
                        final_string = final_string & vbCrLf & line_String
                    Next
                Else
                    final_string = final_string & vbCrLf & thing_edited
                End If
                count = count + 1
            End If
        Next
        Try
            final_string = final_string.Trim()
            File.WriteAllText(Form1.file_path, final_string, Encoding.UTF8)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Sub paint(e As PaintEventArgs, fm As Form1)
        Dim exception As Exception
        Try
            Dim g As Graphics = e.Graphics
            Dim num As Integer = 0
            Dim y As Integer = 0
            Dim num3 As Integer = 0
            Dim num4 As Integer = 0
            Dim count As Integer = 0
            Dim match As Predicate(Of Form1.struc) = Nothing
            Dim predicate11 As Predicate(Of Form1.struc) = Nothing
            Dim predicate12 As Predicate(Of Form1.struc) = Nothing
            Dim predicate13 As Predicate(Of Form1.struc) = Nothing
            For i As Integer = 0 To (fm.DataGridView1.RowCount - 1) - 1
                Dim strArray As String()
                Dim strArray2 As String()
                Dim unknown As Integer()
                Dim num6 As Integer
                Dim num7 As Integer
                Dim strArray4 As String()
                Dim num8 As Integer
                Dim flag As Boolean
                Dim strArray3 As String() = fm.DataGridView1.Rows(i).Cells(4).Value.ToString().Split(New Char() {","c})
                num = Convert.ToInt32(strArray3(0))
                y = Convert.ToInt32(strArray3(1))
                num3 = Convert.ToInt32(strArray3(2))
                num4 = Convert.ToInt32(strArray3(3))
                If ((fm.DataGridView1.Rows(i).Cells(0).Value.ToString() = "genwnd") OrElse (((fm.DataGridView1.Rows(i).Cells(3).Value.ToString() = "") OrElse (fm.DataGridView1.Rows(i).Cells(3).Value.ToString() = "NULL")) And ((fm.DataGridView1.Rows(i).Cells(6).Value.ToString() = "") OrElse (fm.DataGridView1.Rows(i).Cells(6).Value.ToString() = "NULL")))) OrElse ((fm.DataGridView1.Rows(i).Cells(0).Value.ToString() = "simplebutton") And ((fm.DataGridView1.Rows(i).Cells(3).Value.ToString() = "") OrElse (fm.DataGridView1.Rows(i).Cells(3).Value.ToString() = "NULL"))) Then
                    Dim rects As Rectangle() = New Rectangle() {New Rectangle(num, y, num3 - num, num4 - y)}
                    g.DrawRectangles(New Pen(Color.Green, 1.5F), rects) 'The react line color
                    fm.DataGridView1.Rows(i).Cells(10).Value = "Loaded"
                End If
                If (((fm.DataGridView1.Rows(i).Cells(0).Value.ToString() = "v_scrollSmallEx") OrElse (fm.DataGridView1.Rows(i).Cells(0).Value.ToString() = "v_scroll")) And (fm.DataGridView1.Rows(i).Cells(3).Value.ToString() <> "")) And (fm.DataGridView1.Rows(i).Cells(3).Value.ToString() <> "NULL") Then
                    Dim predicate5 As Predicate(Of Form1.struc) = Nothing
                    Dim predicate6 As Predicate(Of Form1.struc) = Nothing
                    Dim predicate7 As Predicate(Of Form1.struc) = Nothing
                    Dim predicate8 As Predicate(Of Form1.struc) = Nothing
                    Dim ani As String() = fm.DataGridView1.Rows(i).Cells(3).Value.ToString().Split(New Char() {"/"c})
                    If ani.Length = 1 Then
                        If predicate5 Is Nothing Then
                            predicate5 = Function(x) x.ani_name = ani(0)
                        End If
                        count = fm.SPR_List.Find(predicate5).count
                        If predicate6 Is Nothing Then
                            predicate6 = Function(x) x.ani_name = ani(0)
                        End If
                        strArray = fm.SPR_List.Find(predicate6).icon_file
                        If predicate7 Is Nothing Then
                            predicate7 = Function(x) x.ani_name = ani(0)
                        End If
                        strArray2 = fm.SPR_List.Find(predicate7).width_height
                        If predicate8 Is Nothing Then
                            predicate8 = Function(x) x.ani_name = ani(0)
                        End If
                        unknown = fm.SPR_List.Find(predicate8).unknown
                        Select Case count
                            Case 1, 3
                                paint_scroll_1(e, strArray(0), num, y, num3 - num, num4 - y)
                                Exit Select
                        End Select
                        If count = 4 Then
                            paint_scroll_4(0, e, strArray, num, y, num3 - num,
                                    num4 - y)
                        End If
                        If count = 12 Then
                            paint_scroll_12(e, strArray, num, y, num3 - num, num4 - y)
                        End If
                    Else
                        Dim predicate As Predicate(Of Form1.struc) = Nothing
                        Dim predicate2 As Predicate(Of Form1.struc) = Nothing
                        Dim predicate3 As Predicate(Of Form1.struc) = Nothing
                        Dim predicate4 As Predicate(Of Form1.struc) = Nothing
                        For j As Integer = 0 To 3
                            If predicate Is Nothing Then
                                predicate = Function(x) x.ani_name = ani(j)
                            End If
                            count = fm.SPR_List.Find(predicate).count
                            If predicate2 Is Nothing Then
                                predicate2 = Function(x) x.ani_name = ani(j)
                            End If
                            strArray = fm.SPR_List.Find(predicate2).icon_file
                            If predicate3 Is Nothing Then
                                predicate3 = Function(x) x.ani_name = ani(j)
                            End If
                            strArray2 = fm.SPR_List.Find(predicate3).width_height
                            If predicate4 Is Nothing Then
                                predicate4 = Function(x) x.ani_name = ani(j)
                            End If
                            unknown = fm.SPR_List.Find(predicate4).unknown
                            Select Case count
                                Case 1, 3
                                    paint_scroll_1(e, strArray(0), num, y, num3 - num, num4 - y)
                                    Exit Select
                            End Select
                            If count = 4 Then
                                paint_scroll_4(j, e, strArray, num, y, num3 - num,
                                        num4 - y)
                            End If
                            If count = 12 Then
                                paint_scroll_12(e, strArray, num, y, num3 - num, num4 - y)
                            End If
                        Next
                    End If
                    fm.DataGridView1.Rows(i).Cells(8).Value = "Loaded"
                End If
                If (((fm.DataGridView1.Rows(i).Cells(3).Value.ToString() <> "") And (fm.DataGridView1.Rows(i).Cells(3).Value.ToString() <> "NULL")) And (fm.DataGridView1.Rows(i).Cells(0).Value.ToString() <> "v_scrollSmallEx")) And (fm.DataGridView1.Rows(i).Cells(0).Value.ToString() <> "v_scroll") Then
                    Try
                        If match Is Nothing Then
                            match = Function(x) x.ani_name = fm.DataGridView1.Rows(i).Cells(3).Value.ToString()
                        End If
                        count = fm.SPR_List.Find(match).count
                        If predicate11 Is Nothing Then
                            predicate11 = Function(x) x.ani_name = fm.DataGridView1.Rows(i).Cells(3).Value.ToString()
                        End If
                        strArray = fm.SPR_List.Find(predicate11).icon_file
                        If predicate12 Is Nothing Then
                            predicate12 = Function(x) x.ani_name = fm.DataGridView1.Rows(i).Cells(3).Value.ToString()
                        End If
                        strArray2 = fm.SPR_List.Find(predicate12).width_height
                        If predicate13 Is Nothing Then
                            predicate13 = Function(x) x.ani_name = fm.DataGridView1.Rows(i).Cells(3).Value.ToString()
                        End If
                        unknown = fm.SPR_List.Find(predicate13).unknown
                        Select Case count
                            Case 1
                                paint_image_1(e, strArray(0), num, y, num3 - num, num4 - y)
                                fm.DataGridView1.Rows(i).Cells(8).Value = "LOaded"
                                Exit Select

                            Case 3
                                paint_image_3(e, strArray, num, y, num3 - num, num4 - y)
                                fm.DataGridView1.Rows(i).Cells(8).Value = "LOaded"
                                Exit Select

                            Case 4
                                paint_image_4(e, strArray, num, y, num3 - num, num4 - y)
                                fm.DataGridView1.Rows(i).Cells(8).Value = "LOaded"
                                Exit Select

                            Case 9
                                paint_image_9(e, strArray, num, y, num3 - num, num4 - y)
                                fm.DataGridView1.Rows(i).Cells(8).Value = "LOaded"
                                Exit Select

                            Case 12
                                paint_image_12(e, strArray, num, y, num3 - num, num4 - y)
                                fm.DataGridView1.Rows(i).Cells(8).Value = "LOaded"
                                Exit Select
                        End Select
                    Catch exception1 As Exception
                        exception = exception1
                        fm.DataGridView1.Rows(i).Cells(8).Value = "Error"
                    End Try
                End If
                If Not ((fm.DataGridView1.Rows(i).Cells(6).Value.ToString() <> "") And (fm.DataGridView1.Rows(i).Cells(6).Value.ToString() <> "NULL")) Then
                    GoTo Label_1158
                End If
                Dim predicate9 As Predicate(Of Form1.RDB_String) = Nothing
                Dim list As New List(Of Tuple(Of String, String))()
                Dim str As String = fm.DataGridView1.Rows(i).Cells(6).Value.ToString().Replace("""", "").Replace("<<", "<").Replace(">>", ">").Replace("<br>", "=br=")
                Try
                    GoTo Label_0D51
Label_0C97:
                    num6 = str.IndexOf("<")
                    num7 = str.IndexOf(">") + 1
                    If (num7 = -1) OrElse (num6 = -1) Then
                        GoTo Label_0D61
                    End If
                    strArray4 = str.Substring(num6 + 1, (num7 - 2) - num6).Split(New Char() {":"c})
                    If strArray4.Count() = 1 Then
                        list.Add(New Tuple(Of String, String)("", strArray4(0)))
                    Else
                        list.Add(New Tuple(Of String, String)(strArray4(0), strArray4(1)))
                    End If
                    str = str.Remove(num6, num7 - num6)
Label_0D51:
                    flag = True
                    GoTo Label_0C97
                Catch
                End Try
Label_0D61:
                num8 = 0
                Dim num9 As Integer = 0
                Dim rdb_code As Integer = 0
                Dim str3 As String = "#ffffff"
                num8 = list.FindIndex(Function(x) x.Item1 = "size")
                If num8 > -1 Then
                    num9 = Convert.ToInt32(list(num8).Item2)
                Else
                    num9 = 8
                End If
                Dim num10 As Integer = 0
                While num10 < list.Count
                    If (list(num10).Item2.Length > 0) AndAlso (list(num10).Item2(0) = "#"c) Then
                        str3 = list(num10).Item2
                    End If
                    num10 += 1
                End While
                For num10 = 0 To list.Count - 1
                    If (list(num10).Item1.Length <= 0) OrElse (list(num10).Item1(0) <> "$"c) Then
                        Continue For
                    End If
                    rdb_code = Convert.ToInt32(list(num10).Item1.Replace("$", ""))
                    If predicate9 Is Nothing Then
                        predicate9 = Function(x) x.code = rdb_code
                    End If
                    num8 = fm.RDB_List.FindIndex(predicate9)
                    If num8 <= -1 Then
                        Continue For
                    End If
                    Dim list2 As New List(Of Tuple(Of String, String))()
                    str = fm.RDB_List(num8).value.Replace("<br>", "=br=")
                    GoTo Label_0FE2
Label_0F28:
                    num6 = str.IndexOf("<")
                    num7 = str.IndexOf(">") + 1
                    If (num7 = -1) OrElse (num6 = -1) Then
                        GoTo Label_0FEA
                    End If
                    strArray4 = str.Substring(num6 + 1, (num7 - 2) - num6).Split(New Char() {":"c})
                    If strArray4.Count() = 1 Then
                        list2.Add(New Tuple(Of String, String)("", strArray4(0)))
                    Else
                        list2.Add(New Tuple(Of String, String)(strArray4(0), strArray4(1)))
                    End If
                    str = str.Remove(num6, num7 - num6)
Label_0FE2:
                    flag = True
                    GoTo Label_0F28
Label_0FEA:
                    num8 = list2.FindIndex(Function(x) x.Item1 = "size")
                    If num8 > -1 Then
                        num9 = Convert.ToInt32(list2(num8).Item2)
                    Else
                        num9 = 8
                    End If
                    For k As Integer = 0 To list2.Count - 1
                        If list2(k).Item2(0) = "#"c Then
                            str3 = list2(k).Item2
                        End If
                    Next
                Next
                HtmlRender.Render(g, String.Concat(New Object() {"<STYLE type='text/css'>.block {width:", Convert.ToInt32(CInt(num3 - num)), "px;height:", Convert.ToInt32(CInt(num4 - y)), "px;text-align:center;vertical-align:middle;}</STYLE><div class='block'><span style='color: ", str3,
                        "; font: ", Convert.ToString(num9), "pt Tahoma'>", str.Replace("=br=", "<br>"), "</span></div>"}), CSng(num), y + 3.0F, 0.0F, Nothing,
                        Nothing, Nothing)
Label_1158:
                fm.DataGridView1.Rows(i).Cells(9).Value = "LOaded"
            Next
        Catch exception2 As Exception
            exception = exception2
        End Try
    End Sub

    Public Shared Sub paint_image_1(e As PaintEventArgs, spr_icon_file As String, left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image 'Loading the TGA for the NUI
            Dim graphics As Graphics = e.Graphics
            If New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") + "\") & spr_icon_file)
                graphics.DrawImage(image, left, top, right, bottom)
            Else
                Try
                    image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") + "\") & spr_icon_file)
                    graphics.DrawImage(image, left, top, right, bottom)
                Catch exception1 As Exception
                    Dim exception As Exception = exception1
                End Try
            End If
        Catch exception2 As Exception
            MessageBox.Show(exception2.ToString())
        End Try
    End Sub

    Public Shared Sub paint_image_12(e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim image2 As Image
            Dim image3 As Image
            Dim image4 As Image
            Dim graphics As Graphics = e.Graphics
            Dim fileName As String = spr_icon_file(0)
            Dim str2 As String = spr_icon_file(1)
            Dim str3 As String = spr_icon_file(2)
            If New FileInfo(fileName).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                graphics.DrawImage(image, left, top, image.Width, bottom)
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                graphics.DrawImage(image, left, top, image.Width, bottom)
            End If
            If New FileInfo(str2).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image3 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image4 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image3, left + image2.Width, top, ((right - image2.Width) - image4.Width) + 1, bottom)
            Else
                image2 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image3 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image4 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image3, left + image2.Width, top, ((right - image2.Width) - image4.Width) + 1, bottom)
            End If
            If New FileInfo(str3).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, bottom)
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, bottom)
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_image_3(e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim image2 As Image
            Dim image3 As Image
            Dim image4 As Image
            Dim num As Integer
            Dim graphics As Graphics = e.Graphics
            Dim fileName As String = spr_icon_file(0)
            Dim str2 As String = spr_icon_file(1)
            Dim str3 As String = spr_icon_file(2)
            If New FileInfo(fileName).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                graphics.DrawImage(image, left, top, image.Width, bottom)
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                graphics.DrawImage(image, left, top, image.Width, bottom)
            End If
            If New FileInfo(str2).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image3 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image4 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, top, image3.Width, bottom)
                    num += image3.Width
                End While
            Else
                image2 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image3 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image4 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, top, image3.Width, bottom)
                    num += image3.Width
                End While
            End If
            If New FileInfo(str3).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, bottom)
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, bottom)
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_image_4(e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim graphics As Graphics = e.Graphics
            If New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                graphics.DrawImage(image, left, top, right, bottom)
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                graphics.DrawImage(image, left, top, right, bottom)
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_image_9(e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim image2 As Image
            Dim image3 As Image
            Dim image4 As Image
            Dim num As Integer
            Dim image5 As Image
            Dim image6 As Image
            Dim image7 As Image
            Dim image8 As Image
            Dim num2 As Integer
            Dim graphics As Graphics = e.Graphics
            If New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                graphics.DrawImage(image, left, top, image.Width, image.Height)
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                graphics.DrawImage(image, left, top, image.Width, image.Height)
            End If
            If New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                image3 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(1))
                image4 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, top, image3.Width, image3.Height)
                    num += image3.Width
                End While
            Else
                image2 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                image3 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(1))
                image4 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, top, image3.Width, image3.Height)
                    num += image3.Width
                End While
            End If
            If New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, image.Height)
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                graphics.DrawImage(image, (left + right) - image.Width, top, image.Width, image.Height)
            End If
            If New FileInfo(spr_icon_file(3)).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                image3 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(3)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(3))
                image4 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                num = 0
                While num <= ((bottom - image2.Height) - image4.Height)
                    graphics.DrawImage(image3, left, (top + image2.Height) + num, image3.Width, image3.Height)
                    num += image3.Height
                End While
            Else
                image2 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                image3 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(3)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(3))
                image4 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                num = 0
                While num <= ((bottom - image2.Height) - image4.Height)
                    graphics.DrawImage(image3, left, (top + image2.Height) + num, image3.Width, image3.Height)
                    num += image3.Height
                End While
            End If
            If New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") = "tga" Then
                image3 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(1))
                image5 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(3)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(3))
                image6 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(4)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(4))
                image7 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(5)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(5))
                image8 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(7)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(7))
                num2 = 0
                While num2 <= ((bottom - image3.Height) - image8.Height)
                    num = 0
                    While num <= ((right - image5.Width) - image7.Width)
                        graphics.DrawImage(image6, (left + image5.Width) + num, (top + image3.Height) + num2, image6.Width, image6.Height)
                        num += image6.Width
                    End While
                    num2 += image6.Height
                End While
            Else
                image3 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(1)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(1))
                image5 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(3)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(3))
                image6 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(4)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(4))
                image7 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(5)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(5))
                image8 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(7)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(7))
                num2 = 0
                While num2 <= ((bottom - image3.Height) - image8.Height)
                    num = 0
                    While num <= ((right - image5.Width) - image7.Width)
                        graphics.DrawImage(image6, (left + image5.Width) + num, (top + image3.Height) + num2, image6.Width, image6.Height)
                        num += image6.Width
                    End While
                    num2 += image6.Height
                End While
            End If
            If New FileInfo(spr_icon_file(5)).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                image3 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(5)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(5))
                image4 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                num = 0
                While num <= ((bottom - image2.Height) - image4.Height)
                    graphics.DrawImage(image3, (left + right) - image3.Width, (top + image2.Height) + num, image3.Width, image3.Height)
                    num += image3.Height
                End While
            Else
                image2 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(2)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(2))
                image3 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(5)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(5))
                image4 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                num = 0
                While num <= ((bottom - image2.Height) - image4.Height)
                    graphics.DrawImage(image3, (left + right) - image3.Width, (top + image2.Height) + num, image3.Width, image3.Height)
                    num += image3.Height
                End While
            End If
            If New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                graphics.DrawImage(image, left, (top + bottom) - image.Height, image.Width, image.Height)
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                graphics.DrawImage(image, left, (top + bottom) - image.Height, image.Width, image.Height)
            End If
            If New FileInfo(spr_icon_file(7)).Extension.ToString().Replace(".", "") = "tga" Then
                image2 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                image3 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(7)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(7))
                image4 = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, (top + bottom) - image3.Height, image3.Width, image3.Height)
                    num += image3.Width
                End While
            Else
                image2 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(6)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(6))
                image3 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(7)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(7))
                image4 = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                num = 0
                While num <= ((right - image2.Width) - image4.Width)
                    graphics.DrawImage(image3, (left + image2.Width) + num, (top + bottom) - image3.Height, image3.Width, image3.Height)
                    num += image3.Width
                End While
            End If
            If New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                graphics.DrawImage(image, (left + right) - image.Width, (top + bottom) - image.Height, image.Width, image.Height)
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(8)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(8))
                graphics.DrawImage(image, (left + right) - image.Width, (top + bottom) - image.Height, image.Width, image.Height)
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_scroll_1(e As PaintEventArgs, spr_icon_file As String, left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim num As Integer
            Dim graphics As Graphics = e.Graphics
            If New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") + "\") & spr_icon_file)
                num = 0
                While num <= bottom
                    graphics.DrawImage(image, left, top + num, right, image.Height)
                    num += image.Height
                End While
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file).Extension.ToString().Replace(".", "") + "\") & spr_icon_file)
                num = 0
                While num <= bottom
                    graphics.DrawImage(image, left, top + num, right, image.Height)
                    num += image.Height
                End While
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_scroll_12(e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer, bottom As Integer)
        Try
            Dim image As Image
            Dim image2 As Image
            Dim image3 As Image
            Dim graphics As Graphics = e.Graphics
            Dim fileName As String = spr_icon_file(0)
            Dim str2 As String = spr_icon_file(1)
            Dim str3 As String = spr_icon_file(2)
            If New FileInfo(fileName).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image2 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image3 = Paloma.TargaImage.LoadTargaImage(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, left, top + (bottom - top), right, image.Height)
                graphics.DrawImage(image2, left, (top + (bottom - top)) + image.Height, right, image2.Height)
                graphics.DrawImage(image3, left, ((top + (bottom - top)) + image.Height) + image2.Height, right, image3.Height)
            Else
                image = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(fileName).Extension.ToString().Replace(".", "") + "\") & fileName)
                image2 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str2).Extension.ToString().Replace(".", "") + "\") & str2)
                image3 = New Bitmap(Convert.ToString(Environment.CurrentDirectory + "\" + New FileInfo(str3).Extension.ToString().Replace(".", "") + "\") & str3)
                graphics.DrawImage(image, left, top + (bottom - top), right, image.Height)
                graphics.DrawImage(image2, left, (top + (bottom - top)) + image.Height, right, image2.Height)
                graphics.DrawImage(image3, left, ((top + (bottom - top)) + image.Height) + image2.Height, right, image3.Height)
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub

    Public Shared Sub paint_scroll_4(j As Integer, e As PaintEventArgs, spr_icon_file As String(), left As Integer, top As Integer, right As Integer,
            bottom As Integer)
        Try
            Dim image As Image
            Dim graphics As Graphics = e.Graphics
            If New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") = "tga" Then
                image = Paloma.TargaImage.LoadTargaImage(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                If j = 2 Then
                    graphics.DrawImage(image, left, top, right, image.Height)
                End If
                If j = 3 Then
                    graphics.DrawImage(image, left, (top + bottom) - image.Height, right, image.Height)
                End If
            Else
                image = New Bitmap(Environment.CurrentDirectory + "\" + New FileInfo(spr_icon_file(0)).Extension.ToString().Replace(".", "") + "\" + spr_icon_file(0))
                If j = 2 Then
                    graphics.DrawImage(image, left, top, right, image.Height)
                End If
                If j = 3 Then
                    graphics.DrawImage(image, left, (top + bottom) - image.Height, right, image.Height)
                End If
            End If
        Catch exception As Exception
            MessageBox.Show(exception.ToString())
        End Try
    End Sub
End Class

