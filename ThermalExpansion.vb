Public Class ThermalExpansion
    Public ARY, CKX As New Collection
    Public i, Mode As Int32
    Private Sub ThermalExpansion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ARY.Add(TextBox1)
        ARY.Add(TextBox2)
        ARY.Add(TextBox3)
        ARY.Add(TextBox4)
        CKX.Add(CheckBox1)
        CKX.Add(CheckBox2)
        CKX.Add(CheckBox3)
        CKX.Add(CheckBox4)
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
        For i = 1 To ARY.Count
            ARY(i).Enabled = True
        Next
        Return 0
    End Function
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click
        Mode = 0
        If TextBox1.TextLength <> 0 Then
            Clear()
            CheckBox1.CheckState = 1
            If Clear2() = 1 Then
                TextBox1.Clear()
            End If
        End If
        If CheckBox1.Checked = True Then
            Reset()
            Mode = 1
            CheckBox1.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=1, Calculating the Thermal Conductivity.")
            TextBox1.Enabled = False
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click
        Mode = 0
        If TextBox2.TextLength <> 0 Then
            Clear()
            CheckBox2.CheckState = 1
            If Clear2() = 1 Then
                TextBox2.Clear()
            End If
        End If
        If CheckBox2.Checked = True Then
            Reset()
            Mode = 2
            CheckBox2.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=2, Calculating the Amount of Heat Transfer.")
            TextBox2.Enabled = False
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click
        Mode = 0
        If TextBox3.TextLength <> 0 Then
            Clear()
            CheckBox3.CheckState = 1
            If Clear2() = 1 Then
                TextBox3.Clear()
            End If
        End If
        If CheckBox3.Checked = True Then
            Reset()
            Mode = 3
            CheckBox3.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=3, Calculating the Area of Body.")
            TextBox3.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox2.CheckState = 0 And CheckBox3.CheckState = 0 And CheckBox4.CheckState = 0 And CheckBox1.CheckState = 0 Then
            Mode = 0
        End If
        If Mode = 1 Then
            Try
                TextBox1.Enabled = True
                TextBox1.Text = Changedata(TextBox2.Text, TextBox3.Text, TextBox4.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the original length,expansion coefficient and the change of temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Expansion")
                TextBox1.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 2 Then
            Try
                TextBox2.Enabled = True
                TextBox2.Text = Originaldata(TextBox1.Text, TextBox3.Text, TextBox4.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the change of length,expansion coefficient and the change of temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Expansion")
                TextBox2.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 3 Then
            Try
                TextBox3.Enabled = True
                TextBox3.Text = Coefficient(TextBox2.Text, TextBox1.Text, TextBox4.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the change of length,original length and the change of temperature with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Expansion")
                TextBox3.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 4 Then
            Try
                TextBox4.Enabled = True
                TextBox4.Text = TempDiff(TextBox2.Text, TextBox1.Text, TextBox3.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the change of length,expansion coefficient and the original length with numbers only.", 0 + 16, "Error")
                LogError(" Thermal Expansion")
                TextBox4.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        Else
            MsgBox("Please specify the target.", 0, "Error")
            AdditionalLogger.Log(" Thermal Expansion > No Target. Unable To start calculation.")
            Clear()
        End If
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label4.Text = "Change of Volume"
            Label5.Text = "Original Volume"
            CheckBox1.Text = Label4.Text
            CheckBox2.Text = Label5.Text
            Label16.Text = 3
            Label17.Text = 3
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label4.Text = "Change of Area"
        Label5.Text = "Original Area"
        CheckBox1.Text = Label4.Text
        CheckBox2.Text = Label5.Text
        Label16.Text = 2
        Label17.Text = 2
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Label4.Text = "Change of Length"
        Label5.Text = "Original Length"
        CheckBox1.Text = Label4.Text
        CheckBox2.Text = Label5.Text
        Label16.Text = ""
        Label17.Text = ""
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Are you sure to clear the results of your previous calcuation?", 1 + 32, "Continute?") = 1 Then
            For i = 1 To ARY.Count
                ARY(i).Clear
            Next
        Else
            Exit Sub
        End If
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click
        Mode = 0
        If TextBox4.TextLength <> 0 Then
            Clear()
            CheckBox4.CheckState = 1
            If Clear2() = 1 Then
                TextBox4.Clear()
            End If
        End If
        If CheckBox4.Checked = True Then
            Reset()
            Mode = 4
            CheckBox4.CheckState = 1
            AdditionalLogger.Log(" Thermal Conductivity > Thermal Conductivity Calculating Mode=4, Calculating the Temperature Changed.")
            TextBox4.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Reset()
    End Sub
End Class