Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection


Public Class Form1

    Public RDB_List As New List(Of RDB_String)()
    Public SPR_List As New List(Of struc)()


    Dim depart As Point
    Dim deplacement As Boolean = False

    Private Sub SetMoveable(ByRef ctl As Control)

        AddHandler ctl.MouseDown, AddressOf Generic_MouseDown
        AddHandler ctl.MouseMove, AddressOf Generic_MouseMove
        AddHandler ctl.MouseUp, AddressOf Generic_MouseUp
    End Sub

    Private Sub Generic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Mémorisation du point de départ
        depart = e.Location
        deplacement = True
    End Sub

    Private Sub Generic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If deplacement Then
            Dim bt As Control = DirectCast(sender, Control)
            Dim loc As Point
            loc.X = bt.Location.X + e.Location.X - depart.X
            loc.Y = bt.Location.Y + e.Location.Y - depart.Y

            'Chargement de la nouvelle position du controle
            bt.Location = loc
        End If
    End Sub

    Private Sub Generic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        deplacement = False
    End Sub


    Public Class struc
        Public Property ani_name As String
        Public Property count As Integer
        Public Property icon_file As String()
        Public Property unknown As Integer()
        Public Property width_height As String()

        Sub New(_ani_name As String, _count As Integer, _icon_file As String(), _unknown As Integer(), _width_height As String())
            ani_name = _ani_name
            count = _count
            icon_file = _icon_file
            unknown = _unknown
            width_height = _width_height
        End Sub
    End Class
    Public Class RDB_String
        Public code As Integer
        Public group_id As Integer
        Public name As String
        Public value As String
        Sub New(_code As Integer, _group_id As Integer, _name As String, _value As String)
            code = _code
            group_id = _group_id
            name = _name
            value = _value
        End Sub
    End Class



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'ui & string files
        SetMoveable(PictureBox1)
        SetMoveable(DataGridView1)
        SPR.open(Environment.CurrentDirectory + "/spr/minimap.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/logo.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/sprite.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/sprite_icon.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/ui_frame.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/worldmap.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/loading.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/loading1.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/loading2.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/loading3.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/ui_icon.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/06_live.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/05_ui.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/04_event.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/03_skill.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/02_item.spr", Me)
        SPR.open(Environment.CurrentDirectory + "/spr/01_equip.spr", Me)
        RDB.open(Environment.CurrentDirectory + "/rdb/db_string.rdb", Me) '  The windows 1256 string 
        Dim files As FileInfo() = New DirectoryInfo(Environment.CurrentDirectory + "/nui").GetFiles()
        For Each info2 As FileInfo In files
            If New FileInfo(info2.ToString()).Extension = ".nui" Then
                ListBox1.Items.Add(info2.ToString())
            End If
        Next
    End Sub


    Private Sub ListBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        For Each obj2 As Object In Me.ListBox1.SelectedItems
            NUI.open(Environment.CurrentDirectory + "/nui/" + obj2, Me)
            appState.Text = "File: " & obj2 & " selected!"
            file_path = Environment.CurrentDirectory + "\nui\" + obj2
            PaintImage(New Rectangle(0, 2048, 2048, 2048))
        Next
    End Sub
    Sub PaintImage(rectangle As Rectangle)
        Dim image As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using gr As Graphics = Graphics.FromImage(image)
            gr.DrawRectangle(New Pen(Color.Yellow), rectangle)

            gr.FillRectangle(New SolidBrush(Color.FromArgb(176, 0, 0, 0)), rectangle) 'The shadow rect line color 
        End Using
        PictureBox1.Image = image
    End Sub
    Private Sub PictureBox1_Paint_1(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        NUI.paint(e, Me)
    End Sub

    Private Sub PictureRefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NUI.paint(e, Me)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Me.OpenFileDialog1.InitialDirectory = Environment.CurrentDirectory + "/nui/"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "(.nui)|*.nui"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            NUI.open(Me.OpenFileDialog1.FileName, Me)
            appState.Text = "File: " & OpenFileDialog1.FileName & " Opened!" 'the open function that's disables
            file_path = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Public temp_coloumn_6_value As String
    Public file_path As String
    Public row_num As Integer
    Public column_name As String
    Public rect_value As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        row_num = e.RowIndex

        temp_coloumn_6_value = DataGridView1.CurrentCell.Value.ToString()
        column_name = DataGridView1.Columns(e.ColumnIndex).HeaderText
        rect_value = DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value
        edit.Label1.Text = temp_coloumn_6_value
        edit.TextBox1.Text = DataGridView1.CurrentCell.Value.ToString()
        edit.load_it()
        edit.Show()
        edit.Focus()
        edit.Location = New Point(Me.Location.X, Me.Location.Y)
        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub RemoveShadowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveShadowToolStripMenuItem.Click
        PaintImage(New Rectangle(0, 2048, 2048, 2048))
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim item2
        For counter As Integer = 0 To ListBox1.Items.Count - 1
            Dim item = ListBox1.Items(counter).ToString()
            Dim containsText = item.IndexOf(TextBox1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0
            If containsText Then
                item2 = item
                GoTo found
            End If
        Next
found:
        ListBox1.SelectedItem = item2
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        Dim box = New About()
        box.Show()


    End Sub

    Private Sub OthersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OthersToolStripMenuItem.Click

    End Sub
End Class
