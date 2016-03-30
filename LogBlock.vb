Public Class LogBlock
    Public Shared time As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    Private Sub Logger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = vbNewLine & "[" & time & "]" & "  ===== Logger Started =====  "
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Save As New SaveFileDialog()
        Dim myStreamWriter As System.IO.StreamWriter
        Save.Filter = "Log [*.log*]|*.log|All Files [*.*]|*.*"
        Save.CheckPathExists = True
        Save.Title = "Save Log"
        Save.ShowDialog(Me)
        Try
            myStreamWriter = System.IO.File.AppendText(Save.FileName)
            myStreamWriter.Write(TextBox1.Text)
            myStreamWriter.Flush()
            MsgBox("The Log has been exported.")
            Exit Sub
        Catch ex As Exception
        End Try
    End Sub
End Class