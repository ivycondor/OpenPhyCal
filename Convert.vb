'   This file stores the formula used for unit conversion'
'   17a7ff2b6731@gmail.com
'   2016    03  27

Public Class Convert
    Public Sub Xcalc() Handles Button2.Click
        If TextBox1.TextLength <> 0 Then
            Try
                TextBox2.Text = (Val(TextBox1.Text) - 32 / 1.8)
                TextBox3.Text = Val(TextBox1.Text) + 459.67
                TextBox4.Text = (Val(TextBox1.Text) + 459.67) * 5 / 9
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox2.TextLength <> 0 Then
            Try
                TextBox1.Text = Val(TextBox2.Text) * 1.8 + 32
                TextBox3.Text = (Val(TextBox2.Text) + 273.15) * 9 / 5
                TextBox4.Text = Val(TextBox2.Text) + 273.15
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox3.TextLength <> 0 Then
            Try
                TextBox1.Text = Val(TextBox3.Text) - 459.67
                TextBox2.Text = (Val(TextBox3.Text) - 491.67) * 5 / 9
                TextBox4.Text = Val(TextBox3.Text) * 5 / 9
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox4.TextLength <> 0 Then
            Try
                TextBox1.Text = Val(TextBox4.Text) * 1.8 - 459.67
                TextBox2.Text = Val(TextBox4.Text) - 273.15
                TextBox3.Text = Val(TextBox4.Text) * 1.8
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        If TextBox5.TextLength <> 0 Then
            Try
                TextBox6.Text = Val(TextBox5.Text) / 4.184
                TextBox20.Text = Val(TextBox5.Text) / 3600
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox6.TextLength <> 0 Then
            Try
                TextBox5.Text = Val(TextBox6.Text) * 4.184
                TextBox20.Text = Val(TextBox6.Text) / 3600
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox20.TextLength <> 0 Then
            Try
                TextBox5.Text = Val(TextBox20.Text) * 3600
                TextBox6.Text = Val(TextBox20.Text) * 4.184 * 3600
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        If TextBox7.TextLength <> 0 Then
            Try
                TextBox8.Text = Val(TextBox7.Text) * 2.20462262
                TextBox9.Text = Val(TextBox7.Text) * 2.20462262 * 16
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox8.TextLength <> 0 Then
            Try
                TextBox7.Text = Val(TextBox8.Text) / 2.20462262
                TextBox9.Text = Val(TextBox8.Text) * 16
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox9.TextLength <> 0 Then
            Try
                TextBox7.Text = Val(TextBox9.Text) / 2.20462262 / 16
                TextBox8.Text = Val(TextBox9.Text) / 16
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        If TextBox10.TextLength <> 0 Then
            Try
                TextBox11.Text = Val(TextBox10.Text) / 100
                TextBox12.Text = Val(TextBox10.Text) / 100 / 0.0254
                TextBox13.Text = Val(TextBox10.Text) / 100 / 0.0254 / 12
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox11.TextLength <> 0 Then
            Try
                TextBox10.Text = Val(TextBox11.Text) * 100
                TextBox12.Text = Val(TextBox11.Text) / 0.0254
                TextBox13.Text = Val(TextBox11.Text) / 0.0254 / 12
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox12.TextLength <> 0 Then
            Try
                TextBox10.Text = Val(TextBox12.Text) * 100 * 0.0254
                TextBox11.Text = Val(TextBox12.Text) * 0.0254
                TextBox13.Text = Val(TextBox12.Text) / 12
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox13.TextLength <> 0 Then
            Try
                TextBox10.Text = Val(TextBox13.Text) * 100 * 0.0254 * 12
                TextBox11.Text = Val(TextBox13.Text) * 0.0254 * 12
                TextBox12.Text = Val(TextBox13.Text) * 12
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        If TextBox14.TextLength <> 0 Then
            Try
                TextBox15.Text = Val(TextBox14.Text) * 1000
                TextBox16.Text = Val(TextBox14.Text) / 3.78541178
                TextBox17.Text = Val(TextBox14.Text) / 3.78541178 * 128
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox15.TextLength <> 0 Then
            Try
                TextBox14.Text = Val(TextBox15.Text) / 1000
                TextBox16.Text = Val(TextBox15.Text) / 1000 / 3.78541178
                TextBox17.Text = Val(TextBox15.Text) / 3.78541178 * 128 / 1000
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox16.TextLength <> 0 Then
            Try
                TextBox14.Text = Val(TextBox16.Text) * 3.78541178
                TextBox15.Text = Val(TextBox16.Text) * 3.78541178 * 1000
                TextBox17.Text = Val(TextBox16.Text) * 128
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox17.TextLength <> 0 Then
            Try
                TextBox14.Text = Val(TextBox17.Text) / 128 * 3.78541178
                TextBox15.Text = Val(TextBox17.Text) / 128 * 3.78541178 * 1000
                TextBox16.Text = Val(TextBox17.Text) / 128
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        If TextBox18.TextLength <> 0 Then
            Try
                TextBox19.Text = Val(TextBox18.Text) / 4184
                TextBox21.Text = Val(TextBox18.Text) / 9.80665
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox19.TextLength <> 0 Then
            Try
                TextBox18.Text = Val(TextBox19.Text) * 4184
                TextBox21.Text = Val(TextBox19.Text) * 4184 / 9.80665
            Catch ex As Exception
                Exit Sub
            End Try
        ElseIf TextBox21.TextLength <> 0 Then
            Try
                TextBox18.Text = Val(TextBox21.Text) * 9.80665
                TextBox19.Text = Val(TextBox21.Text) * 9.80665 / 4184
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox20.Clear()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox21.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox20.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox21.Clear()
    End Sub
End Class
