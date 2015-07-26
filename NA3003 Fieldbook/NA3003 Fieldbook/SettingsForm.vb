Imports System.IO

Public Class SettingsForm

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Read settings and show them
        TextBox1.Text = My.Settings.LataATempNull
        TextBox2.Text = My.Settings.LataAalfa
        TextBox3.Text = My.Settings.LataAm0
        TextBox4.Text = My.Settings.LataBTempNull
        TextBox5.Text = My.Settings.LataBalfa
        TextBox6.Text = My.Settings.LataBm0
        TextBox7.Text = My.Settings.LataAid
        TextBox8.Text = My.Settings.LataBid
        TextBox9.Text = My.Settings.LataASN
        TextBox10.Text = My.Settings.LataBSN
        TbL0a.Text = My.Settings.LataAL0
        TbL0b.Text = My.Settings.LataBL0
        CheckBox1.Checked = My.Settings.UseCorrections
    End Sub

    Private Sub SettingsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.cbCalibration.Checked = My.Settings.UseCorrections
        Form1.Show()
    End Sub

    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles BtnSaveSettings.Click
        'Saving settings of each textbox and close form after save
        Dim confirm As Object = MsgBox("Save new settings?", MsgBoxStyle.YesNo, "Save settings")
        If confirm = vbYes Then
            My.Settings.LataAid = TextBox7.Text
            My.Settings.LataATempNull = TextBox1.Text
            My.Settings.LataAalfa = TextBox2.Text
            My.Settings.LataAm0 = TextBox3.Text
            My.Settings.LataAL0 = TbL0a.Text
            My.Settings.LataASN = TextBox9.Text
            My.Settings.LataBid = TextBox8.Text
            My.Settings.LataBTempNull = TextBox4.Text
            My.Settings.LataBalfa = TextBox5.Text
            My.Settings.LataBm0 = TextBox6.Text
            My.Settings.LataBL0 = TbL0b.Text
            My.Settings.LataBSN = TextBox10.Text
            My.Settings.UseCorrections = CheckBox1.Checked
            My.Settings.Save()
            My.Settings.Reload()
            Close()
        End If

    End Sub

    Private Sub BtnCancelSettings_Click(sender As Object, e As EventArgs) Handles BtnCancelSettings.Click
        'Close form if user clicked Cancel
        Close()

    End Sub

    Private Sub BtnDefaults_Click(sender As Object, e As EventArgs) Handles BtnDefaults.Click
        Dim defaults As Object = MsgBox("Reset to default settings?", MsgBoxStyle.YesNo, "Reset settings")
        If defaults = vbYes Then
            TextBox1.Text = 20
            TextBox2.Text = 1
            TextBox3.Text = 1
            TextBox4.Text = 20
            TextBox5.Text = 1
            TextBox6.Text = 1
            TextBox7.Text = 1
            TextBox8.Text = 2
            TextBox9.Text = ""
            TextBox10.Text = ""
            TbL0a.Text = 0
            TbL0b.Text = 0
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            ImportCalibration()
        End If
    End Sub

    'Import calibration
    Private Sub ImportCalibration()
        Dim streamReader2 As StreamReader = New StreamReader(OpenFileDialog1.FileName)
        Dim i As Integer = 0
        Do Until streamReader2.EndOfStream
            Dim readLine As String = streamReader2.ReadLine()
            If i = 0 And readLine = "NA3003 Staff Calibrations" Then
                i = 1
            ElseIf i > 0
                'Import Staff A
                For i = 1 To 12
                    Dim staffData() As String
                    staffData = readLine.Split(" ")

                    If staffData(0) = "idA" Then
                        TextBox7.Text = staffData(1)
                    ElseIf staffData(0) = "calTA"
                        TextBox1.Text = staffData(1)
                    ElseIf staffData(0) = "alphaA"
                        TextBox2.Text = staffData(1)
                    ElseIf staffData(0) = "m0A"
                        TextBox3.Text = staffData(1)
                    ElseIf staffData(0) = "L0A"
                        TbL0a.Text = staffData(1)
                    ElseIf staffData(0) = "SNA"
                        TextBox9.Text = staffData(1)
                    ElseIf staffData(0) = "idB"
                        TextBox8.Text = staffData(1)
                    ElseIf staffData(0) = "calTB"
                        TextBox4.Text = staffData(1)
                    ElseIf staffData(0) = "alphaB"
                        TextBox5.Text = staffData(1)
                    ElseIf staffData(0) = "m0B"
                        TextBox6.Text = staffData(1)
                    ElseIf staffData(0) = "L0B"
                        TbL0b.Text = staffData(1)
                    ElseIf staffData(0) = "SNB"
                        TextBox10.Text = staffData(1)
                    Else
                        MsgBox("Error in data.", MsgBoxStyle.Critical, "NA3003: Import Error")
                        Exit Do
                    End If
                    i = i + 1
                Next
            Else
                MsgBox("Not a calibration data file." & vbCrLf & "Please fix data and try again.", MsgBoxStyle.Critical, "NA3003: Error in data")
                streamReader2.Close()
                Exit Sub
            End If
        Loop
        streamReader2.Close()
        If i = 13 Then
            MsgBox("Calibration imported. Check data and Save.", MsgBoxStyle.Information, "NA3003: Imported")
        End If
    End Sub

    Private Sub ExportCalibration()
        Dim streamWriter As StreamWriter = New StreamWriter(SaveFileDialog1.FileName, False)
        streamWriter.WriteLine("NA3003 Staff Calibrations")
        streamWriter.WriteLine("idA " & TextBox7.Text.ToString)
        streamWriter.WriteLine("calTA " & TextBox1.Text)
        streamWriter.WriteLine("alphaA " & TextBox2.Text)
        streamWriter.WriteLine("m0A " & TextBox3.Text)
        streamWriter.WriteLine("L0A " & TbL0a.Text)
        streamWriter.WriteLine("SNA " & TextBox9.Text)
        streamWriter.WriteLine("idB " & TextBox8.Text)
        streamWriter.WriteLine("calTB " & TextBox4.Text)
        streamWriter.WriteLine("alphaB " & TextBox5.Text)
        streamWriter.WriteLine("m0B " & TextBox6.Text)
        streamWriter.WriteLine("L0B " & TbL0b.Text)
        streamWriter.WriteLine("SNB " & TextBox10.Text)
        streamWriter.Close()
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            ExportCalibration()
        End If
    End Sub
End Class