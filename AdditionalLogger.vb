Module AdditionalLogger
    Public LogBox As TextBox = LogBlock.TextBox1
    Public Function Log(ByVal Text As String) As String
        LogBox.Text += Environment.NewLine & "[" & LogBlock.time & "]" & Text
        Return 0
    End Function
    Public Function LogError(ByVal victim As String) As String
        Log(victim & " > Unable to Calculate.")
        Return 0
    End Function
End Module
