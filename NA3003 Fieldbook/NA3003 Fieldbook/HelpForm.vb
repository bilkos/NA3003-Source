Imports System.IO

Public Class HelpForm

    Private Sub BtnCloseHelp_Click(sender As Object, e As EventArgs) Handles BtnCloseHelp.Click
        Me.Close()
    End Sub

    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reader As StreamReader = New StreamReader("Docs\HelpGuide.rtf")
        Dim source As String = reader.ReadToEnd()
        Me.RichTextBox1.Rtf = source
        'Me.RichTextBox1.AppendText(source)
        'Me.RichTextBox1.LoadFile("Docs\HelpGuide.rtf", RichTextBoxStreamType.RichText)

    End Sub
End Class