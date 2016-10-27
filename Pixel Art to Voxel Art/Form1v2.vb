'https://en.wikipedia.org/wiki/Wavefront_.obj_file
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Public Class Form1


    'WWASH 20161026 20:56 Notes to Alex
    'You need to comment your code, like a lot. Just imagine you are explaining it to someone and type naturally. It doesn't have to be formal, the more comments you put the shorter they become.

    'Instead of Coding 10 boxes, think about being flexible with the application and allowing someone to add as many as they want.
    '1. Get rid of those 10 boxes, and the open file dialog on the form.
    ' I try to perform all my dialogs in line with my code so I don't need to go to a different panel to make changes it's all the same code anyway and it reduces the number of steps.
    '2. Add a button to "Add Image Layer"
    '3. Add a flow layout panel
    '4. The code would look something like this: 

   'We need a list of images to store each one. I will use these to create the pictures, but we need the raw files for processing.
    Public images as new list(of Bitmap)

    'This sub will allow someone to select an image file, we will add it to the array above, and then create controls on the form so they can see it.

    Private Sub imgAdd() handles btnAddImage.Click

    'They need a file dialog to open the file. 
    dim odf as openfiledialog as new openfiledialog()
    odf_open.Title = "Open a PNG File"
    odf_open.FileName = imgBox.Name.Replace("img_", "Image ")
    'If they don't click okay then exit
    If odf_open.ShowDialog() != System.Windows.Forms.DialogResult.OK Then
    'I can exit the sub and not worry about an Else. If I don't exit, it is an assumed else. Now you don't have nested Ifs
    exit sub
    'Good, they clicked okay et's keep moving
    End if

    'Set a variable to the path of the file, it is fully qualified in case you were wondering
    '^^ Leave notes to yourself so you don't have to keep researching things
    'You can declare and set the variable in one swoop, it results in cleaner code.
    Dim path As String = odf_open.FileName

    'Check early on to see if it is the right size, if it's not then throw an error
    ' Test the negative first, and exit early that way we are not digging through code to see what the *else* is
    'Declare variables you only use once inside the sub so you don't have to go hunting and it is very clear what you intend....declare then use.

    Dim img_size As New Size(10, 10)
    If imgArray(imgIndex).Size != img_size Then
        MsgBox("Please use a 10 × 10 pixel file.")
        'See i'm exiting again, nice huh?
        Exit sub
    End If

    'We know now that this is the correct size keep trucking
    'We need to create the raw bitmap and add it to the list of bitmaps
    dim image as new Bitmap = CType(Image.FromFile(path, True), Bitmap)
    images.add(image)

    'These images are tiny and impposible to see, so we are going to create another bitmap that is resized to 100X
    'If you are only using the scaleimg once, then just put the declaration here, that way you're not scrolling through all sorts of code to find out what it is (like I just did)
    Dim scaleimg As New Size(100, 100)
    Dim imageScaled As Bitmap = New Bitmap(imgArray(imgIndex), scaleimg)
    Dim x_move As Integer = 0
    Dim y_move As Integer = 0

    dim pb as new PictureBox
    me.THATFLOWLAYOUTPANELISAIDTOCREATEABOVE.Controls.Add(pb)
    pb.image = imageScaled

    ' I think with this you are just looping through the image to find the color of each pixel and add it to the list box
    ' Because you didn't comment this section I have no clue what is going on and I am getting very angry. If your laptop is wrapped in duct tape tomorrow, you will know why.
    For run As Integer = 0 To 100
                        If y_move = 10 Then
                            Exit For
                        End If
                    curPixColor = image.GetPixel(x_move, y_move)
                    If x_move = 9 Then
                            x_move = -1
                            y_move += 1
                        End If
                        x_move += 1
                        lbx_colors.Items.Add(curPixColor.ToString)
                        RemoveDuplicatesFromListBox()
    Next


'Because I exited sub, I don't need this two oddly placed End Ifs, they're lonely down here. Try to keep them with their mates.
'   End If
'End If
        


            end Sub
    'Dim img1 As Bitmap
    'Dim img2 As Bitmap
    'Dim img3 As Bitmap
    'Dim img4 As Bitmap
    'Dim img5 As Bitmap
    'Dim img6 As Bitmap
    'Dim img7 As Bitmap
    'Dim img8 As Bitmap
    'Dim img9 As Bitmap
    'Dim img10 As Bitmap
    Dim imgArray() As Bitmap

    Dim imgview1 As Bitmap
    Dim imgview2 As Bitmap
    Dim imgview3 As Bitmap
    Dim imgview4 As Bitmap
    Dim imgview5 As Bitmap
    Dim imgview6 As Bitmap
    Dim imgview7 As Bitmap
    Dim imgview8 As Bitmap
    Dim imgview9 As Bitmap
    Dim imgview10 As Bitmap

    Dim imguse1 As Boolean = False
    Dim imguse2 As Boolean = False
    Dim imguse3 As Boolean = False
    Dim imguse4 As Boolean = False
    Dim imguse5 As Boolean = False
    Dim imguse6 As Boolean = False
    Dim imguse7 As Boolean = False
    Dim imguse8 As Boolean = False
    Dim imguse9 As Boolean = False
    Dim imguse10 As Boolean = False

    Dim imglongview As Bitmap
    Dim img_long_scale As New Size(1000, 100)
    Dim long_img As Boolean = False
    Dim imglong As Bitmap
    Dim img_longuse As Boolean = False

    Dim fs As FileStream
    
    
    Dim curPixColor As Color
    Dim Z_find As String
    Dim D_X As Integer 'Left to Right
    Dim D_Y As Integer 'Forward and Back
    Dim D_Z As Integer 'Top to Bottom
    Dim cube_count As Integer = 0
    Dim info As Byte()





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        tbx_obj.Text = "# Pixel to Voxel 1.0 OBJ File: ''
mtllib POOP.mtl

"
        tbx_mtl.Text = "# Blender MTL File: 'None'
# Material Count:"

        img_1.Image = My.Resources.Open_Img
        img_2.Image = My.Resources.Open_Img
        img_3.Image = My.Resources.Open_Img
        img_4.Image = My.Resources.Open_Img
        img_5.Image = My.Resources.Open_Img
        img_6.Image = My.Resources.Open_Img
        img_7.Image = My.Resources.Open_Img
        img_8.Image = My.Resources.Open_Img
        img_9.Image = My.Resources.Open_Img
        img_10.Image = My.Resources.Open_Img


        For Each ctl As Control In pnlSourcePictures.Controls
            If TypeOf ctl Is Panel Then
                AddHandler ctl.Click, AddressOf imgClick
            End If
        Next


    End Sub

    Private Sub imgClick(sender As Object, e As EventArgs)
        Dim imgBox As PictureBox = sender
        Dim imgIndex As Integer = imgBox.Name.ToString.Substring(5, 2)


        imgArray(imgIndex) = CType(Image.FromFile(path, True), Bitmap)

        Dim imgViewScaled As Bitmap = New Bitmap(imgArray(imgIndex), scaleimg)


        Dim x_move As Integer = 0
            Dim y_move As Integer = 0

            odf_open.Title = "Open a PNG File"
            odf_open.FileName = imgBox.Name.Replace("img_", "Image ")
            If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = odf_open.FileName
            'img1 = CType(Image.FromFile(path, True), Bitmap)
            If imgArray(imgIndex).Size = img_size Then
                'imgview1 = New Bitmap(img1, scaleimg)
                'imgBox.Image = imgview1
                imgBox.Image = imgViewScaled
                'imguse1 = True
                ' Instead you can loop through the array of images to get the length.
                ' Dim x As Integer = imgArray.Length

                For run As Integer = 0 To 100
                        If y_move = 10 Then
                            Exit For
                        End If
                    curPixColor = imgArray(imgIndex).GetPixel(x_move, y_move)
                    If x_move = 9 Then
                            x_move = -1
                            y_move += 1
                        End If
                        x_move += 1

                        lbx_colors.Items.Add(curPixColor.ToString)
                        RemoveDuplicatesFromListBox()
                    Next

                Else
                    MsgBox("Please use a 10 × 10 pixel file.")
                End If
            End If


    End Sub


    'Private Sub img_1_Click(sender As Object, e As EventArgs) Handles img_1.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_1.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img1 = CType(Image.FromFile(path, True), Bitmap)
    '        If img1.Size = img_size Then
    '            imgview1 = New Bitmap(img1, scaleimg)
    '            img_1.Image = imgview1
    '            imguse1 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img1.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_2_Click(sender As Object, e As EventArgs) Handles img_2.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_2.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img2 = CType(Image.FromFile(path, True), Bitmap)
    '        If img2.Size = img_size Then
    '            imgview2 = New Bitmap(img2, scaleimg)
    '            img_2.Image = imgview2
    '            imguse2 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img2.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_3_Click(sender As Object, e As EventArgs) Handles img_3.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_3.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img3 = CType(Image.FromFile(path, True), Bitmap)
    '        If img3.Size = img_size Then
    '            imgview3 = New Bitmap(img3, scaleimg)
    '            img_3.Image = imgview3
    '            imguse3 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img3.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_4_Click(sender As Object, e As EventArgs) Handles img_4.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_4.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img4 = CType(Image.FromFile(path, True), Bitmap)
    '        If img4.Size = img_size Then
    '            imgview4 = New Bitmap(img4, scaleimg)
    '            img_4.Image = imgview4
    '            imguse4 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img4.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_5_Click(sender As Object, e As EventArgs) Handles img_5.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_5.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img5 = CType(Image.FromFile(path, True), Bitmap)
    '        If img5.Size = img_size Then
    '            imgview5 = New Bitmap(img5, scaleimg)
    '            img_5.Image = imgview5
    '            imguse5 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img5.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_6_Click(sender As Object, e As EventArgs) Handles img_6.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_6.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img6 = CType(Image.FromFile(path, True), Bitmap)
    '        If img6.Size = img_size Then
    '            imgview6 = New Bitmap(img6, scaleimg)
    '            img_6.Image = imgview6
    '            imguse6 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img6.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_7_Click(sender As Object, e As EventArgs) Handles img_7.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_7.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img7 = CType(Image.FromFile(path, True), Bitmap)
    '        If img7.Size = img_size Then
    '            imgview7 = New Bitmap(img7, scaleimg)
    '            img_7.Image = imgview7
    '            imguse7 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img7.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_8_Click(sender As Object, e As EventArgs) Handles img_8.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_8.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img8 = CType(Image.FromFile(path, True), Bitmap)
    '        If img8.Size = img_size Then
    '            imgview8 = New Bitmap(img8, scaleimg)
    '            img_8.Image = imgview8
    '            imguse8 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img8.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_9_Click(sender As Object, e As EventArgs) Handles img_9.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_9.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img9 = CType(Image.FromFile(path, True), Bitmap)
    '        If img9.Size = img_size Then
    '            imgview9 = New Bitmap(img9, scaleimg)
    '            img_9.Image = imgview9
    '            imguse9 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img9.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    'Private Sub img_10_Click(sender As Object, e As EventArgs) Handles img_10.Click
    '    Dim x_move As Integer = 0
    '    Dim y_move As Integer = 0

    '    odf_open.Title = "Open a PNG File"
    '    odf_open.FileName = img_10.Name.Replace("img_", "Image ")
    '    If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        path = odf_open.FileName
    '        img10 = CType(Image.FromFile(path, True), Bitmap)
    '        If img10.Size = img_size Then
    '            imgview10 = New Bitmap(img10, scaleimg)
    '            img_10.Image = imgview10
    '            imguse10 = True
    '            For run As Integer = 0 To 100
    '                If y_move = 10 Then
    '                    Exit For
    '                End If
    '                curPixColor = img10.GetPixel(x_move, y_move)
    '                If x_move = 9 Then
    '                    x_move = -1
    '                    y_move += 1
    '                End If
    '                x_move += 1

    '                lbx_colors.Items.Add(curPixColor.ToString)
    '                RemoveDuplicatesFromListBox()
    '            Next

    '        Else
    '            MsgBox("Please use a 10 × 10 pixel file.")
    '        End If
    '    End If
    'End Sub

    Private Sub RemoveDuplicatesFromListBox()
        Dim List As New ArrayList
        For Each item1 As String In lbx_colors.Items
            If Not List.Contains(item1) Then
                List.Add(item1)
            End If
        Next
        lbx_colors.Items.Clear()
        For Each item2 As String In List
            lbx_colors.Items.Add(item2)
        Next
    End Sub

    Private Sub lbx_colors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbx_colors.SelectedIndexChanged
        Dim a As Integer, r As Integer, g As Integer, b As Integer
        Dim s As String = lbx_colors.SelectedItem.ToString
        'Dim s As String = "[A=255, R=241, G=24, B=2]"
        Dim mc As MatchCollection = System.Text.RegularExpressions.Regex.Matches(s, "(\d+)\D+(\d+)\D+(\d+)\D+(\d+)\D+", RegexOptions.None)
        Integer.TryParse(mc(0).Groups(1).Value, a)
        Integer.TryParse(mc(0).Groups(2).Value, r)
        Integer.TryParse(mc(0).Groups(3).Value, g)
        Integer.TryParse(mc(0).Groups(4).Value, b)

        pnl_color.BackColor = System.Drawing.Color.FromArgb(CType(CType(r, Byte), Integer), CType(CType(g, Byte), Integer), CType(CType(b, Byte), Integer))

    End Sub

    Private Sub pnl_color_Paint(sender As Object, e As PaintEventArgs) Handles pnl_color.Paint

    End Sub

    Private Sub pnl_color_Click(sender As Object, e As EventArgs) Handles pnl_color.Click
        If cdg_pick.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pnl_color.BackColor = cdg_pick.Color
        End If
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        Dim x_move As Integer = 0
        Dim y_move As Integer = 0

        tbx_obj.Text = "# Pixel to Voxel 1.0 OBJ File:
mtllib POOP.mtl

"
        tbx_mtl.Text = "# Pixel to Voxel 1.0 MTL File:
# Material Count:"

        cube_count = 0

        Z_find = imguse1 & imguse2 & imguse3 & imguse4 & imguse5 & imguse6 & imguse7 & imguse8 & imguse9 & imguse10
        'MsgBox(Z_find)
        Z_find = Z_find.Replace("True", "1")
        'MsgBox(Z_find)
        Z_find = Z_find.Replace("False", "0")
        'MsgBox(Z_find)

        If Z_find = "0000000000" Then
            MsgBox("Please pick at least 1 image.")
            Exit Sub
        Else
            If Z_find = "1000000000" Then
                D_Z = 1
            Else
                If Z_find = "1100000000" Then
                    D_Z = 2
                Else
                    If Z_find = "1110000000" Then
                        D_Z = 3
                    Else
                        If Z_find = "1111000000" Then
                            D_Z = 4
                        Else
                            If Z_find = "1111100000" Then
                                D_Z = 5
                            Else
                                If Z_find = "1111110000" Then
                                    D_Z = 6
                                Else
                                    If Z_find = "1111111000" Then
                                        D_Z = 7
                                    Else
                                        If Z_find = "1111111100" Then
                                            D_Z = 8
                                        Else
                                            If Z_find = "1111111110" Then
                                                D_Z = 9
                                            Else
                                                If Z_find = "1111111111" Then
                                                    D_Z = 10
                                                Else
                                                    MsgBox("Please go in order.")
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        tbx_mtl.Text &= "FIND"
        If D_Z >= 1 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img1.GetPixel(x_move, y_move)

                '1
                '
                '1

                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 -1.000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 1.000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 1.000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 -1.000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 -1.000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 1.000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 1.000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 -1.000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '1
        '
        '2

        If D_Z >= 2 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img2.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (2) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (2) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (2) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (2) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (2) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (2) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (2) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (2) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '2
        '
        '3


        If D_Z >= 3 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img3.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (3) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (3) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (3) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (3) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (3) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (3) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (3) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (3) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '3
        '
        '4


        If D_Z >= 4 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img4.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (4) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (4) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (4) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (4) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (4) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (4) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (4) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (4) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '4
        '
        '5


        If D_Z >= 5 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img5.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (5) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (5) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (5) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (5) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (5) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (5) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (5) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (5) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '5
        '
        '6


        If D_Z >= 6 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img6.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (6) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (6) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (6) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (6) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (6) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (6) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (6) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (6) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '6
        '
        '7


        If D_Z >= 7 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img7.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (7) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (7) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (7) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (7) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (7) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (7) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (7) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (7) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '7
        '
        '8


        If D_Z >= 8 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img8.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (8) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (8) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (8) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (8) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (8) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (8) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (8) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (8) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '8
        '
        '9


        If D_Z >= 9 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img9.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (9) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (9) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (9) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (9) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (9) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (9) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (9) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (9) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '9
        '
        '10


        If D_Z = 10 Then
            For run As Integer = 0 To 100
                If y_move = 10 Then
                    Exit For
                End If
                curPixColor = img10.GetPixel(x_move, y_move)


                If curPixColor.A = 255 Then
                    tbx_obj.Text &= "o Cube." & cube_count & "
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (10) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (10) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (10) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + -1 & ".000000 " & (10) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (10) + -1 & ".000000
v " & (x_move * 2) + 1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (10) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (10) + 1 & ".000000
v " & (x_move * 2) + -1 & ".000000 " & (y_move * 2) + 1 & ".000000 " & (10) + -1 & ".000000
usemtl Material" & cube_count & "
s off"

                    tbx_obj.Text &= "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 1 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 2 + (cube_count * 5) & "
f " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & " " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 3 + (cube_count * 5) & "
f " & cube_count + 2 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 6 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & " " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 4 + (cube_count * 5) & "
f " & cube_count + 3 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 7 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 5 + (cube_count * 5) & "
f " & cube_count + 5 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 1 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 4 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & " " & cube_count + 8 + (cube_count * 7) & "//" & cube_count + 6 + (cube_count * 5) & "

"
                    tbx_mtl.Text &= "

newmtl Material" & cube_count & "
Kd " & (curPixColor.R / 255) & " " & (curPixColor.G / 255) & " " & (curPixColor.B / 255) & "

"

                    cube_count += 1
                Else
                    'MsgBox("no yay")
                End If

                If x_move = 9 Then
                    x_move = -1
                    y_move += 1
                End If
                x_move += 1


            Next
        End If

        x_move = 0
        y_move = 0

        '10
        '
        '10

        tbx_mtl.Text = tbx_mtl.Text.Replace("FIND", cube_count - 1)

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'Dim message, title, defaultValue, replacevalue As String
        'Dim myValue As Object
        'message = "Please pick a name for the file."
        'title = "Save File"
        'defaultValue = "Pixel Art"
        'myValue = InputBox(message, title, defaultValue)
        'replacevalue = myValue.ToString

        Dim replacevalue As String

        sdf_save.Filter = "Wavefront OBJ File|*.obj"
        sdf_save.FileName = ""

        If sdf_save.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            If sdf_save.FileName = "" Then
                Exit Sub
            End If

            path = sdf_save.FileName
            sdf_save.FileName = path
            If path.Substring(path.Length - 4, 4) <> ".obj" Then
                path &= ".obj"
            End If

            Dim FileInfo As New FileInfo(path)
            replacevalue = FileInfo.Name
            replacevalue = replacevalue.Replace(".obj", "")

            tbx_obj.Text = tbx_obj.Text.Replace("POOP", replacevalue)

            fs = File.Create(path)
            info = New UTF8Encoding(True).GetBytes(tbx_obj.Text.ToString)
            fs.Write(info, 0, info.Length)
            fs.Close()


            fs = File.Create(path.Replace(".obj", ".mtl"))
            info = New UTF8Encoding(True).GetBytes(tbx_mtl.Text.ToString)
            fs.Write(info, 0, info.Length)
            fs.Close()



            MsgBox("File Saved to [" & path & "]")
        End If



    End Sub

    Private Sub btn_layer_Click(sender As Object, e As EventArgs) Handles btn_layer.Click
        If long_img = False Then
            MsgBox("Please pick a long image")
        Else

        End If

    End Sub

    Private Sub img_long_Click(sender As Object, e As EventArgs) Handles img_long.Click
        Dim x_move As Integer = 0
        Dim y_move As Integer = 0

        odf_open.Title = "Open a PNG File"
        odf_open.FileName = img_long.Name.Replace("img_long_", "Image ")
        If odf_open.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path = odf_open.FileName
            imglong = CType(Image.FromFile(path, True), Bitmap)
            If img_long.Size = img_long_scale Then
                imglongview = New Bitmap(imglong, 1000, 100)
                img_long.Image = imglongview
                img_longuse = True
                For run As Integer = 0 To 100000

                    If y_move = imglong.Height Then
                        Exit For
                    End If
                    curPixColor = imglong.GetPixel(x_move, y_move)
                    If x_move = imglong.Width - 1 Then
                        x_move = -1
                        y_move += 1
                    End If
                    x_move += 1

                    lbx_colors.Items.Add(curPixColor.ToString)
                    RemoveDuplicatesFromListBox()

                    lbl_log.Text = "Part " & run & "out of " & imglong.Width * imglong & ""
                Next

            Else
                MsgBox("Please use a 100 × 10 pixel file.")
            End If
        End If
    End Sub

    Private Sub btn_color_reset_Click(sender As Object, e As EventArgs) Handles btn_color_reset.Click
        lbx_colors.Items.Clear()
    End Sub
End Class
