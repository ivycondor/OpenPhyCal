Imports PhyCal.Formula
Imports PhyCal.AdditionalLogger
Public Class Main
    Public Shared ARY, CKX As New Collection
    Public Shared Mode As Integer = 0
    Public Shared i, specific As Integer
    Public Shared Function Clear()
        For i = 1 To CKX.Count
            CKX(i).CheckState = False
        Next
        Return 0
    End Function
    Public Shared Function Clear2()
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
    Public Shared Function Reset()
        Clear()
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
            Button1.Show()
            Button2.Hide()
            CheckBox2.CheckState = 1
            Label11.Show()
            Label16.Text = "Heat Capacity"
            Label10.Text = "Initial Temperature"
            Label12.Show()
            AdditionalLogger.Log(" Heat Capacity > Heat Capacity Calculating Mode=1, Calculating the Energy Released.")
            TextBox1.Enabled = False
            TextBox3.Show()
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click
        Mode = 0
        If TextBox5.TextLength <> 0 Then
            Clear()
            CheckBox3.CheckState = 1
            If Clear2() = 1 Then
                TextBox5.Clear()
            End If
        End If
        If CheckBox3.Checked = True Then
            Mode = 2
            Reset()
            Button1.Show()
            Button2.Hide()
            CheckBox3.CheckState = 1
            Label10.Text = "Initial Temperature"
            Label16.Text = "Heat Capacity"
            Label12.Show()
            Label11.Show()
            AdditionalLogger.Log(" Heat Capacity > Heat Capacity Calculating Mode=2, Calculating the Heat Capacity.")
            TextBox5.Enabled = False
            TextBox3.Show()
        End If
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click
        Mode = 0
        If TextBox3.TextLength <> 0 Then
            Clear()
            CheckBox4.CheckState = 1
            If Clear2() = 1 Then
                TextBox3.Clear()
                TextBox2.Clear()
            End If
        End If
        If CheckBox4.Checked = True Then
            Mode = 3
            Reset()
            CheckBox4.CheckState = 1
            AdditionalLogger.Log(" Heat Capacity > Heat Capacity Calculating Mode=3, Calculating the Temperature Difference.")
            Label16.Text = "Heat Capacity"
            Label12.Hide()
            Label11.Hide()
            Label10.Text = "Temperature Change (∆T)"
            TextBox2.Enabled = False
            TextBox3.Hide()
        End If
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.Click
        Mode = 0
        If TextBox4.TextLength <> 0 Then
            Clear()
            CheckBox5.CheckState = 1
            If Clear2() = 1 Then
                TextBox5.Clear()
            End If
        End If
        If CheckBox5.Checked = True Then
            Mode = 4
            Reset()
            Button1.Show()
            Button2.Hide()
            CheckBox5.CheckState = 1
            Label16.Text = "Specific Heat Capacity"
            Label12.Show()
            Label11.Show()
            Label10.Text = "Initial Temperature"
            AdditionalLogger.Log(" Heat Capacity > Heat Capacity Calculating Mode= 4, Calculating the Specific Heat Capacity.")
            AdditionalLogger.Log(" Heat Capacity > Reverting To Default Layout.")
            TextBox3.Show()
            TextBox5.Enabled = False
        End If
    End Sub
    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.Click
        Mode = 0
        If TextBox5.TextLength <> 0 Then
            TextBox5.Clear()
            Clear()
            Clear2()
            CheckBox6.CheckState = 1
        End If
        If CheckBox6.Checked = True Then
            Mode = 5
            Reset()
            Button1.Show()
            Button2.Hide()
            CheckBox6.CheckState = 1
            Label16.Text = "Specific Heat Capacity"
            Label12.Show()
            Label11.Show()
            Label10.Text = "Initial Temperature"
            AdditionalLogger.Log(" Heat Capacity > Reverting To Default Layout.")
            AdditionalLogger.Log(" Heat Capacity > Heat Capacity Calculating Mode=5, Calculating the Mass.")
            TextBox4.Enabled = 0
            TextBox3.Show()
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            AdditionalLogger.Log(" Heat Capacity > Enabled the Specific Heat Capacity Extension")
            Label15.Text = "J/˚C/kg"
            TextBox4.Show()
            Label14.Show()
            Label13.Show()
            CheckBox5.Show()
            CheckBox6.Show()
            specific = 1
        ElseIf CheckBox1.Checked = False Then
            AdditionalLogger.Log(" Heat Capacity > Disabled the Specific Heat Capacity Extension")
            Label15.Text = "J/˚C"
            TextBox4.Hide()
            Label13.Hide()
            Label14.Hide()
            CheckBox5.Hide()
            CheckBox6.Hide()
            specific = 0
            Mode = 0
            Clear()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If CheckBox2.CheckState = 0 And CheckBox3.CheckState = 0 And CheckBox4.CheckState = 0 And CheckBox5.CheckState = 0 And CheckBox6.CheckState = 0 Then
            Mode = 0
        End If
        If Mode = 1 Then
            If specific = 0 Then
                Try
                    TextBox1.Enabled = True
                    TextBox1.Text = Energy(Val(TextBox3.Text - TextBox2.Text), TextBox5.Text, 0, 0, 0)
                    AdditionalLogger.Log(" Heat Capacity > Calculating the Energy Released, applying formula E=C∆T")
                    AdditionalLogger.Log(" Heat Capacity > E= " & TextBox5.Text & " x " & " ( " & TextBox3.Text & " - " & TextBox2.Text & " ) ")
                    AdditionalLogger.Log(" Heat Capacity > E= " & TextBox1.Text)
                    Exit Sub
                Catch ex As Exception
                    MsgBox("Please enter the heat capacity ,the initial temperature and the final Temperature with numbers only.", 0 + 16, "Error")
                    LogError(" Heat Capacity")
                    TextBox1.Enabled = False
                    Exit Sub
                End Try
                Exit Sub
            ElseIf specific = 1 Then
                Try
                    TextBox1.Enabled = True
                    TextBox1.Text = Energy(Val(TextBox3.Text - TextBox2.Text), 0, TextBox5.Text, TextBox4.Text, 1)
                    AdditionalLogger.Log(" Heat Capacity > Calculating the Energy Released, applying formula E=mc∆T")
                    AdditionalLogger.Log(" Heat Capacity > E= " & TextBox4.Text & " x " & TextBox5.Text & " x " & " ( " & TextBox3.Text & " - " & TextBox2.Text & " ) ")
                    AdditionalLogger.Log(" Heat Capacity > E= " & TextBox1.Text)
                    Exit Sub
                Catch ex As Exception
                    MsgBox("Please enter the mass , specific heat capacity ,the initial Temperature , The final temperature With numbers only.", 0 + 16, "Error")
                    LogError(" Heat Capacity")
                    TextBox1.Enabled = False
                    Exit Sub
                End Try
                Exit Sub
            End If
        ElseIf Mode = 2 Then
            Try
                TextBox5.Enabled = True
                TextBox5.Text = Heat_Capacity(Val(TextBox3.Text - TextBox2.Text), TextBox1.Text, 0, 0)
                AdditionalLogger.Log(" Heat Capacity > Calculating the Heat Capacity, applying formula E=C∆T")
                AdditionalLogger.Log(" Heat Capacity > Changed subject, We Get C=E/∆T")
                AdditionalLogger.Log(" Heat Capacity > C= " & TextBox1.Text & " / " & " ( " & TextBox3.Text & " - " & TextBox2.Text & " ) ")
                AdditionalLogger.Log(" Heat Capacity > C= " & TextBox5.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the energy Released ,the initial temperature and the final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Heat Capacity")
                TextBox5.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 3 Then
            Try
                Button1.Hide()
                Button2.Show()
                TextBox2.Enabled = True
                TextBox2.Text = TempChange(TextBox1.Text, TextBox5.Text, 0, 0, 0)
                AdditionalLogger.Log(" Heat Capacity > Calculating the Temperature Difference, applying formula E=C∆T")
                AdditionalLogger.Log(" Heat Capacity > Changed subject, We Get ∆T=E/C")
                AdditionalLogger.Log(" Heat Capacity > ∆T= " & TextBox1.Text & " / " & TextBox5.Text)
                AdditionalLogger.Log(" Heat Capacity > ∆T= " & TextBox2.Text)
                Exit Sub
            Catch ex As Exception
                MsgBox("Please enter the energy released and the heat capacity with numbers only.", 0 + 16, "Error")
                LogError(" Heat Capacity")
                TextBox2.Enabled = False
                Exit Sub
            End Try
            Exit Sub
        ElseIf Mode = 4 Then
            Label16.Text = "Specific Heat Capacity"
            Try
                TextBox5.Enabled = True
                TextBox5.Text = Heat_Capacity(Val(TextBox3.Text - TextBox2.Text), TextBox1.Text, TextBox4.Text, 1)
                AdditionalLogger.Log(" Heat Capacity > Calculating the Specific Heat Capacity, applying formula E=mc∆T")
                AdditionalLogger.Log(" Heat Capacity > Changed subject, We Get c=E/∆T/m")
                AdditionalLogger.Log(" Heat Capacity > c= " & TextBox1.Text & " / " & " ( " & TextBox3.Text & " - " & TextBox2.Text & " ) " & " / " & TextBox4.Text)
                AdditionalLogger.Log(" Heat Capacity > c= " & TextBox5.Text)
                Exit Sub
            Catch ex As Exception
                TextBox5.Enabled = False
                MsgBox("Please enter the energy released,mass,initial temperature and the Final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Heat Capacity")
                Exit Sub
            End Try

        ElseIf Mode = 5 Then
            Try
                TextBox4.Enabled = True
                TextBox4.Text = weight(TextBox1.Text, TextBox5.Text, Val(TextBox3.Text - TextBox2.Text))
                AdditionalLogger.Log(" Heat Capacity > Calculating the Mass, applying formula E=mc∆T")
                AdditionalLogger.Log(" Heat Capacity > Changed subject, We Get m=E/∆T/c")
                AdditionalLogger.Log(" Heat Capacity > m= " & TextBox1.Text & " / " & " ( " & TextBox3.Text & " - " & TextBox2.Text & " ) " & " / " & TextBox5.Text)
                AdditionalLogger.Log(" Heat Capacity > m= " & TextBox4.Text)
                Exit Sub
            Catch ex As Exception
                TextBox4.Enabled = False
                MsgBox("Please enter the energy released,the heat Capacity,the initial Temperature and the final temperature with numbers only.", 0 + 16, "Error")
                LogError(" Heat Capacity")
                Exit Sub
            End Try
            Exit Sub
        Else
            MsgBox("Please specify the target.", 0, "Error")
            AdditionalLogger.Log(" Heat Capacity > No Target. Unable To start calculation.")
            Clear()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Hide()
        Button1.Show()
        Clear()
        Clear2()
        Label12.Show()
        Label11.Hide()
        Label10.Text = "Initial Temperature"
        TextBox3.Show()
    End Sub
    Public Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ARY.Add(TextBox1)
        ARY.Add(TextBox2)
        ARY.Add(TextBox3)
        ARY.Add(TextBox4)
        ARY.Add(TextBox5)
        CKX.Add(CheckBox2)
        CKX.Add(CheckBox3)
        CKX.Add(CheckBox4)
        CKX.Add(CheckBox5)
        CKX.Add(CheckBox6)
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
End Class
