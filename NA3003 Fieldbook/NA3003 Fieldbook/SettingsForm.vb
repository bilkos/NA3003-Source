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
            My.Settings.LataATempNull = TextBox1.Text
            My.Settings.LataAalfa = TextBox2.Text
            My.Settings.LataAm0 = TextBox3.Text
            My.Settings.LataAL0 = TbL0a.Text
            My.Settings.LataBTempNull = TextBox4.Text
            My.Settings.LataBalfa = TextBox5.Text
            My.Settings.LataBm0 = TextBox6.Text
            My.Settings.LataBL0 = TbL0b.Text
            My.Settings.LataAid = TextBox7.Text
            My.Settings.LataBid = TextBox8.Text
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
            TbL0a.Text = 0
            TbL0b.Text = 0
            CheckBox1.Checked = False
        End If
    End Sub

End Class