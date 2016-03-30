Public Class ThermalConductivity
    Public ARY, CKX As New Collection
    Public i, Mode As Int32
    Public Sub ThermalConductivity_Load(sender As Object, e As EventArgs) Handles Me.Load
        ARY.Add(TextBox1)
        ARY.Add(TextBox2)
        ARY.Add(TextBox3)
        ARY.Add(TextBox4)
        ARY.Add(TextBox5)
        CKX.Add(CheckBox2)
        CKX.Add(CheckBox3)
        CKX.Add(CheckBox4)
        CKX.Add(CheckBox5)
    End Sub
    Public Function Clear()
        For i = 1 To CKX.Count
            CKX(i).CheckState = False
        Next
        Return 0
    End Function
    Public Function Clear2()
        If MsgBox("Are you sure to clear the results of your previous calcuation?", 1 + 32, "Continute?") = 1 Then
            For i = 1 To ARY.Count
                ARY(i).Enabled = True
            Next
            Return 1
        Else
            Return 0
            Exit Function
        End If
    End Function
    Public Function Reset()
        Clear()
        Label16.Text = "Initial Temperature"
        TextBox5.Show()
        Button1.Show()
        Label13.Show()
        Label14.Show()
        Button2.Hide()
        For i = 1 To ARY.Count
            ARY(i).Enabled = True
        Next
        Return 0
        Exit Function
    End Function
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click
        Mode = 0
        If TextBox1.TextLength <> 0 Then
            Clear()
            CheckBox2.CheckState = 1
            If Clear2() = 1 Then
                TextBox1.Clear()
            End If
        End If
        If CheckBox2.Checked = True Then
            Mode = 1
            Reset()
            CheckBox2.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=1, Calculating the Thermal Conductivity.")
            TextBox1.Enabled = False
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click
        Mode = 0
        If TextBox2.TextLength <> 0 Then
            Clear()
            CheckBox3.CheckState = 1
            If Clear2() = 1 Then
                TextBox2.Clear()
            End If
        End If
        If CheckBox3.Checked = True Then
            Mode = 2
            Reset()
            CheckBox3.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=2, Calculating the Amount of Heat Transfer.")
            TextBox2.Enabled = False
        End If
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click
        Mode = 0
        If TextBox3.TextLength <> 0 Then
            Clear()
            CheckBox4.CheckState = 1
            If Clear2() = 1 Then
                TextBox3.Clear()
            End If
        End If
        If CheckBox4.Checked = True Then
            Mode = 3
            Reset()
            CheckBox4.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=3, Calculating the Area of Body.")
            TextBox3.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reset()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure to clear the results of your previous calcuation?", 1 + 32, "Continute?") = 1 Then
            For i = 1 To ARY.Count
                ARY(i).Clear
            Next
        Else
            Exit Sub
        End If
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.Click
        Mode = 0
        If TextBox4.TextLength <> 0 Then
            Clear()
            CheckBox5.CheckState = 1
            If Clear2() = 1 Then
                TextBox4.Clear()
            End If
        End If
        If CheckBox5.Checked = True Then
            Mode = 4
            Reset()
            CheckBox5.CheckState = 1
            Label16.Text = "Temperature Changed"
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=4, Calculating the Temperature Changed.")
            TextBox4.Enabled = False
            TextBox5.Hide()
            Label13.Hide()
            Label14.Hide()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox2.CheckState = 0 And CheckBox3.CheckState = 0 And CheckBox4.CheckState = 0 And CheckBox5.CheckState = 0 Then
            Mode = 0
        End If
        If Mode = 1 Then
            Try
                TextBox1.Enabled = True
                TextBox1.Text = Conductivity(TextBox2.Text, TextBox3.Text, Val(TextBox5.Text - TextBox4.Text))
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the amount of heat transferred ,the initial temperature and the final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Conductivity")
                TextBox1.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 2 Then
            Try
                TextBox2.Enabled = True
                TextBox2.Text = Heat(TextBox1.Text, TextBox3.Text, Val(TextBox5.Text - TextBox4.Text))
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the thermal conductivity ,the initial temperature and The final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Conductivity")
                TextBox2.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 3 Then
            Try
                TextBox3.Enabled = True
                TextBox3.Text = Bodyarea(TextBox2.Text, TextBox1.Text, Val(TextBox5.Text - TextBox4.Text))
                Exit Sub
            Catch ex As Exception
                MsgBox("Please Enter the amount of heat transferred,thermal conductivity,initial temperature and final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Conductivity")
                TextBox3.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 4 Then
            Try
                Button2.Show()
                Button1.Hide()
                TextBox4.Enabled = True
                TextBox4.Text = DiffTemp(TextBox2.Text, TextBox1.Text, TextBox3.Text)
                Exit Sub
            Catch ex As Exception
                TextBox4.Enabled = False
                MsgBox("Please Enter the amount of heat transferred,thermal conductivity,area of body With numbers only.", 0 + 16, "Error")
                LogError(" Thermal Conductivity")
                Exit Sub
            End Try
        Else
            MsgBox("Please Specify the Function by clicking the labels On Algerbric Target panel.", 0, "Error")
            AdditionalLogger.Log(" Thermal Conductivity > No Target. Unable To start calculation.")
            Clear()
        End If
    End Sub
End Class