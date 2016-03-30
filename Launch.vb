Imports PhyCal.Main
Imports PhyCal.AdditionalLogger

Public Class Launch
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Log(" Starting HeatCapacity.")
        Main.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Log(" Starting ThermalConductivity.")
        ThermalConductivity.Show()
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Log(" Starting Thermal Expansion.")
        ThermalExpansion.Show()
    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Log(" Trying to start calc.exe")
        Try
            Process.Start("calc.exe")
            Log(" Started calc.exe successfully.")
        Catch ex As Exception
            MsgBox("calc.exe not found in %windir%\System32 folder, please run [sfc /scannow] with administrative rights to verify operating system integrity.", 0, "calc.exe Not found")
            Log(" calc.exe not found.")
        End Try
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Process.GetCurrentProcess().Kill()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Log(" Enabled Logger.")
        LogBlock.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Log(" Starting Unit Converter.")
        Convert.Show()
    End Sub
End Class