'Programming: Boris Bilc
'e-mail: boris.bilc@gmail.com
'Company: 2B geoinformatika, d.o.o., Ljubljana, Slovenia
'Menthor: Andrej Bilc
'Copyright 2015
'This application is private property.
'Please do not copy or distribute withour sunding a prior notification to application author.

Imports System.IO
Imports System.Threading

Public Class Form1

    Dim checkFile As Boolean
    Dim dataError As Integer = 0
    Dim codeNum As Integer

    Dim lataAid As Integer = My.Settings.LataAid
    Dim tempLataNullA As Double = My.Settings.LataATempNull
    Dim alphaA As Double = My.Settings.LataAalfa
    Dim m0A As Double = My.Settings.LataAm0
    Dim l0A As Double = My.Settings.LataAL0
    Dim lataBid As Integer = My.Settings.LataBid
    Dim tempLataNullB As Double = My.Settings.LataBTempNull
    Dim alphaB As Double = My.Settings.LataBalfa
    Dim m0B As Double = My.Settings.LataBm0
    Dim l0B As Double = My.Settings.LataBL0

    Dim measMethod As Integer
    Dim prevWi As String
    Dim staffNr As Integer = 0
    Dim tempStaff As Double
    Dim ptNum As Integer
    Dim ptNumPrev As Integer
    Dim dist As Double
    Dim heightReadingMe As Double
    Dim heightReadingB1 As Double
    Dim heightReadingF1 As Double
    Dim heightReadingF2 As Double
    Dim heightReadingB2 As Double
    Dim heightReadingIn As Double
    Dim heightReadingSo As Double
    Dim sdiff As Double
    Dim ssDiff As Double
    Dim distDiff As Double
    Dim totalDist As Double
    Dim groundHeigth As Double
    Dim GrHt As Double
    Dim GrHtPrev As Double

    'On form load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSave.Enabled = False
        BtnCreate.Enabled = False
        cmbTip.Enabled = False
        cbCalibration.Checked = My.Settings.UseCorrections
        cb1Staff.Checked = My.Settings.OneStaff
        cmbTip.SelectedItem = My.Settings.LastMethod
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        HelpForm.Show()
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles BtnSettings.Click
        SettingsForm.Show()
        Me.Hide()
    End Sub

    Private Sub cmbTip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTip.SelectedIndexChanged
        If cmbTip.SelectedItem = "Calculated Report" And checkFile = True Then
            My.Settings.Reload()
            cbCalibration.Checked = My.Settings.UseCorrections
            cbCalibration.Enabled = True
            cb1Staff.Checked = My.Settings.OneStaff
            cb1Staff.Enabled = True
        Else
            cbCalibration.Enabled = False
            cb1Staff.Enabled = False
        End If
        My.Settings.LastMethod = cmbTip.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub cbCalibration_CheckedChanged(sender As Object, e As EventArgs) Handles cbCalibration.CheckedChanged
        My.Settings.UseCorrections = cbCalibration.Checked
        My.Settings.Save()
    End Sub

    Private Sub cb1Staff_CheckedChanged(sender As Object, e As EventArgs) Handles cb1Staff.CheckedChanged
        My.Settings.OneStaff = cb1Staff.Checked
        My.Settings.Save()
    End Sub
    
    'On Save button click
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'Set filename to original filename without extension
        SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        'If we created text format fbk, then save as *.TXT
        If cmbTip.SelectedItem = "Standard Report" Or cmbTip.SelectedItem = "Calculated Report" Then
            SaveFileDialog1.Filter = "NA3003 Fieldbook|*.TXT"
            SaveFileDialog1.DefaultExt = "*.TXT"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Save contents of RtbKonzola to plain text file
                RtbKonzola.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                RtbKonzola.Clear()
                lblDataStatus.Text = "Saved as " & cmbTip.SelectedItem
                RtbKonzola.AppendText("Save successful... " & vbCrLf & "File >>> " & SaveFileDialog1.FileName)
                MsgBox("'" & Path.GetFileName(SaveFileDialog1.FileName) & "' file saved.", MsgBoxStyle.OkOnly, "File Saved")
            End If
        End If
        'If we created comma separated values export, then same as *.csv
        If cmbTip.SelectedItem = "CSV" Or cmbTip.SelectedItem = "CSV - Measeure Only" Then
            SaveFileDialog1.Filter = "CSV File|*.csv"
            SaveFileDialog1.DefaultExt = "*.csv"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Save contents of RtbKonzola to csv text file
                RtbKonzola.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                RtbKonzola.Clear()
                lblDataStatus.Text = "Saved as " & cmbTip.SelectedItem
                RtbKonzola.AppendText("Save successful... " & vbCrLf & "File >>> " & SaveFileDialog1.FileName)
                MsgBox("'" & Path.GetFileName(SaveFileDialog1.FileName) & "' file saved.", MsgBoxStyle.OkOnly, "File Saved")
            End If
        End If
    End Sub

    'On About button click
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox1.Show()    'Show About box
    End Sub

    'On Browse button click
    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TbInput.Text = OpenFileDialog1.SafeFileName
            checkFile = OpenFileDialog1.CheckFileExists
            RtbKonzola.Clear()
            lblDataStatus.Text = "File ready."
        End If
        'If file is selected
        If checkFile = True Then
            BtnCreate.Enabled = True
            'Enable Fieldbook button
            cmbTip.Enabled = True
            'Enable Type combo box
        End If
        If cmbTip.SelectedItem = "Calculated Report" Then
            cbCalibration.Enabled = True
            cb1Staff.Enabled = True
        End If
    End Sub

    'Read text file until end of file
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If checkFile = True Then
            If cmbTip.SelectedItem = Nothing Then
                MsgBox("Select type of Fieldbook!", MsgBoxStyle.Critical, "NA3003: Error")
                Exit Sub
            End If
            RtbKonzola.Clear()
            If cmbTip.SelectedItem = "Calculated Report" Then
                RtbKonzola.ForeColor = Color.LimeGreen
            Else
                RtbKonzola.ForeColor = Color.DarkGray
            End If
            ' prepare StreamReader
            Dim streamReader As StreamReader = New StreamReader(OpenFileDialog1.FileName)
            Dim i As Integer = 0
            ' loop untill end of stream
            Do Until streamReader.EndOfStream
                'Read and Split each line to separate it into fields
                Dim line() As String = streamReader.ReadLine().Split(" ")
                If dataError = 0 Then
                    'for each line send data to DataType() subroutine
                    If i = 0 Then
                        If cmbTip.SelectedItem = "Standard Report" Then
                            RtbKonzola.AppendText("+++++ NA3003 Fieldbook - Standard v1.1 +++++")
                        End If
                        If cmbTip.SelectedItem = "Calculated Report" Then
                            RtbKonzola.AppendText("+++++ NA3003 Fieldbook - Calc v1.3 +++++")
                            If My.Settings.UseCorrections = True Then
                                RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Calculated using staff calibrations" & vbCrLf & _
                                                      "Staff A: " & _
                                                      "ID= " & My.Settings.LataAid & _
                                                      " / alpha= " & My.Settings.LataAalfa.ToString & " ppm" & _
                                                      " / m0= " & My.Settings.LataAm0.ToString & " ppm" & _
                                                      " / L0= " & My.Settings.LataAL0 & " mm" & vbCrLf & _
                                                      "Staff B: " & _
                                                      "ID= " & My.Settings.LataBid & _
                                                      " / alpha= " & My.Settings.LataBalfa.ToString & " ppm" & _
                                                      " / m0= " & My.Settings.LataBm0.ToString & " ppm" & _
                                                      " / L0= " & My.Settings.LataBL0 & " mm")
                            End If
                        End If
                        If cmbTip.SelectedItem = "CSV" Then
                            RtbKonzola.AppendText("+++++; NA3003; Fieldbook; - CSV; v1.1; +++++")
                        End If
                        If cmbTip.SelectedItem = "CSV - Measure Only" Then
                            RtbKonzola.AppendText("+++++; NA3003; Fieldbook; - CSV; v1.1; +++++")
                        End If
                    End If
                    For Each lineData As String In line
                        DataType(lineData)
                    Next
                    i = i + 1
                ElseIf dataError = 1 Then   'Error: 1 - if data for starting staff is missing
                    Dim dataErrorMsg1 As Object = MessageBox.Show("No staff ID in data." & vbCrLf & "Do you want to continue calculating WITHOUT staff calibration?", _
                                                                  "NA3003 Error: No staff ID", _
                                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    'If user pressed "Yes" then turn off correction and continue running
                    If dataErrorMsg1 = DialogResult.Yes Then
                        dataError = 0
                        My.Settings.UseCorrections = False
                        My.Settings.Save()
                        cbCalibration.Checked = False
                        'Export line
                        For Each lineData As String In line
                            DataType(lineData)
                        Next
                        i = i + 1
                        'Else we destroy sub and stop the process + reset values
                    ElseIf dataErrorMsg1 = DialogResult.No Then
                        dataError = 0
                        MsgBox("Fix raw data and retry.", MsgBoxStyle.Exclamation, "NA3003: Process stopped")
                        Exit Sub
                    End If
                End If
            Loop
            ' close file that was opened for reading
            streamReader.Close()    'close streamreader
            BtnSave.Enabled = True  'enable Save button
            If cbComma.Checked = True Then
                RtbKonzola.Text = Replace(RtbKonzola.Text, ".", ",")
            End If
            lblDataStatus.Text = "File NOT saved!"
            MsgBox("Fieldbook '" & cmbTip.SelectedItem & "' is done." & vbCrLf & vbCrLf & "Don't forget to save.", MsgBoxStyle.Information, "NA3003: Create Fieldbook")
            staffNr = 0
            dataError = 0
        Else
            RtbKonzola.Clear()      'clear rtb
            RtbKonzola.AppendText("No file selected...") 'show error message
        End If
    End Sub

    'Subroutine for extracting data - word index & data
    'Data is sent to Export* subroutines for processing, depending on which cmbTip item is selected
    Public Sub DataType(ByVal lineData As String)
        Dim wordIndex As String
        wordIndex = Microsoft.VisualBasic.Left(lineData, 3)
        Dim data As String
        data = Microsoft.VisualBasic.Right(lineData, 9)

        If cmbTip.SelectedItem = "Standard Report" Then
            ExportStandard(wordIndex, data)

        ElseIf cmbTip.SelectedItem = "Calculated Report" Then
            ExportCalc(wordIndex, data)

        ElseIf cmbTip.SelectedItem = "CSV" Then
            ExportCsv(wordIndex, data)

        ElseIf cmbTip.SelectedItem = "CSV - Measure Only" Then
            ExportCsvMeas(wordIndex, data)

        End If
    End Sub

    Private Sub NextStaff()
        If My.Settings.OneStaff = False And My.Settings.UseCorrections = True And dataError = 0 Then
            If staffNr = lataAid Then
                staffNr = lataBid
            Else
                staffNr = lataAid
            End If
        End If
    End Sub

    Private Function StaffReading(ByVal heightReading As Double)
        Dim calcHeight As Double
        My.Settings.Reload()
        If My.Settings.UseCorrections = True And dataError = 0 Then
            'Let's calculate corrected staff heght reading, depending on which staff is beeing read
            If staffNr = lataAid Then
                calcHeight = ((alphaA * (tempStaff - tempLataNullA) * 0.000001) + (1 + (m0A * 0.000001))) * heightReading + (l0A / 1000)
            ElseIf staffNr = lataBid Then
                calcHeight = ((alphaB * (tempStaff - tempLataNullB) * 0.000001) + (1 + (m0A * 0.000001))) * heightReading + (l0B / 1000)
            End If
        Else
            'Else we just output height values
            calcHeight = heightReading
        End If
        Return calcHeight
    End Function

    'Export subroutine if cmbTip is "GURS"
    Private Sub ExportCalc(ByVal wi As String, ByVal data As String)

        Select Case wi
            Case 410 To 419 'Measuring info or Code line
                If data = "+?......1" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BF")
                    measMethod = 1
                    GrHt = 0
                    GrHtPrev = 0
                    heightReadingB1 = 0
                    heightReadingF1 = 0
                    heightReadingF2 = 0
                    heightReadingB2 = 0

                ElseIf data = "+?......2" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BFFB")
                    measMethod = 2
                    GrHt = 0
                    GrHtPrev = 0
                    heightReadingB1 = 0
                    heightReadingF1 = 0
                    heightReadingF2 = 0
                    heightReadingB2 = 0

                ElseIf data = "+!....331" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: B1")
                    heightReadingB1 = 0
                    heightReadingF1 = 0
                    heightReadingF2 = 0
                    heightReadingB2 = 0
                    If prevWi = "335" Then
                        NextStaff()
                    End If

                ElseIf data = "+!....332" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: F1")
                    heightReadingF1 = 0
                    heightReadingF2 = 0
                    heightReadingB2 = 0

                ElseIf data = "+!....336" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: F2")
                    heightReadingF2 = 0
                    heightReadingB2 = 0

                ElseIf data = "+!....335" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: B2")
                    heightReadingB2 = 0
                    GrHt = GrHtPrev

                Else
                    codeNum = Convert.ToInt32(data)
                    If codeNum = 1 Then
                        'do nothing - old code commented bellow
                        'RtbKonzola.AppendText("Temperatura: ")
                    ElseIf codeNum = 10 Then    'Koda 10 - 3 podatki (poligon, par lat, datum)
                        RtbKonzola.AppendText(vbCrLf & "Code 10 (Info)")
                    ElseIf codeNum = 30 Then    'Koda 30 - 4 podatki (čas, temperatura, vreme, pogoji)
                        RtbKonzola.AppendText(vbCrLf & "Code 30 (Conditions)")
                    ElseIf codeNum = 33 Then    'Koda 33 - 2 podatka (par lat, lata začetek/konec)
                        RtbKonzola.AppendText(vbCrLf & "Code 33 (Staffs)")
                    Else                        'Ostale kode - 1 do 4 podatki
                        RtbKonzola.AppendText(vbCrLf & "Code " & codeNum.ToString)
                    End If
                End If

            Case "42."  'Code
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 1 Then ' koda 1 za temperaturo - info 1
                    'do nothing - old code commented bellow
                    tempStaff = Convert.ToDouble(numData) / 10
                    'RtbKonzola.AppendText(Format(tempT, "0.0").ToString)
                ElseIf codeNum = 10 Then    ' koda 10: številka poligona - info 1
                    RtbKonzola.AppendText(" poligon: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: čas vnosa - info 1
                    RtbKonzola.AppendText(" time: " & numData.ToString)
                ElseIf codeNum = 33 Then    ' koda 33: številka para lat - info 1
                    RtbKonzola.AppendText(" st.pair: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info1
                    RtbKonzola.AppendText(" Info1: " & numData.ToString)
                End If

            Case "43."  ' Code: Info2
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 10 Then        ' koda 10: št. para lat - info 2
                    RtbKonzola.AppendText(" staffs: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: temperatura - info 2
                    RtbKonzola.AppendText(" temp: " & numData.ToString)
                ElseIf codeNum = 33 Then    ' koda 33: lata na začetku/koncu vlaka - info 2
                    RtbKonzola.AppendText(" staff: " & numData.ToString & vbCrLf)
                    staffNr = numData
                    prevWi = wi
                Else                        ' sicer izvozimo običajno Info2
                    RtbKonzola.AppendText(" Info2: " & numData.ToString)
                End If

            Case "44."  ' Code: Info3
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 10 Then    ' koda 10: datum meritve - info 3
                    RtbKonzola.AppendText(" date: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: vremenski pogoji - info 3
                    RtbKonzola.AppendText(" weather: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info3
                    RtbKonzola.AppendText(" Info3: " & numData.ToString)
                End If

            Case "45."  ' Code: Info4
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 30 Then        ' koda 30: pogoji niveliranja
                    RtbKonzola.AppendText(" condit.: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info4
                    RtbKonzola.AppendText(" Info4: " & numData.ToString)
                End If

            Case 110 To 119 'Staff id
                ptNum = Convert.ToInt32(data)
                RtbKonzola.AppendText(vbCrLf & String.Format("{0,-8}", ptNum.ToString))

            Case "32."  'Distance to staff
                dist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" D: " & String.Format("{0,8}", Format(dist, "0.000").ToString))

            Case "330"  'Staff reading in MEAS ONLY
                heightReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" ME: " & String.Format("{0,8}", Format(heightReadingMe, "0.00000").ToString))

            Case "331"  'Staff reading, backsight / B1
                If staffNr = 0 And My.Settings.UseCorrections = True Then
                    dataError = 1
                End If
                If prevWi = "332" And measMethod = 2 Then
                    NextStaff()
                End If
                If prevWi = "335" Then
                    NextStaff()
                End If
                If prevWi = "336" Then
                    NextStaff()
                End If
                heightReadingB1 = Convert.ToDouble(data) / 100000
                heightReadingB1 = StaffReading(heightReadingB1)
                RtbKonzola.AppendText(" B1: " & String.Format("{0,8}", Format(heightReadingB1, "0.00000").ToString) & " ******** Staff: " & staffNr & " T: " & tempStaff.ToString)
                prevWi = "331"

            Case "332"  'Staff reading, foresight / F1
                If prevWi = "331" Then
                    NextStaff()
                End If
                If prevWi = "335" Then
                    NextStaff()
                End If
                heightReadingF1 = Convert.ToDouble(data) / 100000
                heightReadingF1 = StaffReading(heightReadingF1)
                RtbKonzola.AppendText(" F1: ******** " & String.Format("{0,8}", Format(heightReadingF1, "0.00000").ToString) & " Staff: " & staffNr & " T: " & tempStaff.ToString)
                prevWi = "332"

            Case "336"  'Staff reading, foresight / F2
                If prevWi = "335" Then
                    NextStaff()
                End If
                heightReadingF2 = Convert.ToDouble(data) / 100000
                heightReadingF2 = StaffReading(heightReadingF2)
                RtbKonzola.AppendText(" F2: ******** " & String.Format("{0,8}", Format(heightReadingF2, "0.00000").ToString) & " Staff: " & staffNr & " T: " & tempStaff.ToString)
                prevWi = "336"

            Case "335"  'Staff reading, backsight / B2
                If prevWi = "332" Then
                    NextStaff()
                End If
                If prevWi = "336" Then
                    NextStaff()
                End If
                heightReadingB2 = Convert.ToDouble(data) / 100000
                heightReadingB2 = StaffReading(heightReadingB2)
                RtbKonzola.AppendText(" B2: " & String.Format("{0,8}", Format(heightReadingB2, "0.00000").ToString) & " ******** Staff: " & staffNr & " T: " & tempStaff.ToString)
                prevWi = "335"

            Case "333"  'Staff reading, intermediate sight
                heightReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" IN: ******** ******** " & String.Format("{0,8}", Format(heightReadingIn, "0.00000").ToString))

            Case "334"  'Staff reading, setting-out
                heightReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" SO: ******** ******** " & String.Format("{0,8}", Format(heightReadingSo, "0.00000").ToString))

            Case "571"  'Reading difference
                sdiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" s: " & String.Format("{0,8}", Format(sdiff, "0.00000").ToString))

            Case "572"  'Cumulative diff
                ssDiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" ss: " & String.Format("{0,8}", Format(ssDiff, "0.00000").ToString))

            Case "573"  'Difference in distance BF
                distDiff = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" sD: " & String.Format("{0,-8}", Format(distDiff, "0.00").ToString))

            Case "574"  'Total distance
                totalDist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" tD: " & String.Format("{0,-8}", Format(totalDist, "0.000").ToString))

            Case "83."  'Groung heigth
                groundHeigth = Convert.ToDouble(data) / 10000
                'If point number is the same as previous
                'Override current GrHt with previous and calc based on previous point height
                If ptNum = ptNumPrev Then
                    GrHt = GrHtPrev         'Reset GrHt to previous value

                    If measMethod = 1 Then
                        GrHt = (GrHt + heightReadingB1 - heightReadingF1)
                    End If
                    If measMethod = 2 Then
                        GrHt = (GrHt + (heightReadingB1 + heightReadingB2) / 2) - ((heightReadingF1 + heightReadingF2) / 2)
                    End If
                Else
                    'Else we save new point number to previous, and save current GrHt to previous
                    'Do a normal calculation of height
                    ptNumPrev = ptNum       'Save point number
                    GrHtPrev = GrHt         'Save current GrHt

                    If measMethod = 1 Then
                        GrHt = (GrHt + heightReadingB1 - heightReadingF1)
                    End If
                    If measMethod = 2 Then
                        GrHt = (GrHt + (heightReadingB1 + heightReadingB2) / 2) - ((heightReadingF1 + heightReadingF2) / 2)
                    End If
                End If
                RtbKonzola.AppendText(" GrHt-R: " & Format(groundHeigth, "0.0000").ToString & " GrHt: " & Format(GrHt, "0.00000").ToString & vbCrLf)
        End Select
    End Sub

    'Export subroutine if cmbTip is "Standard"
    Private Sub ExportStandard(ByVal wi As String, ByVal data As String)
        Select Case wi
            Case 410 To 419     'Methods and Codes
                If data = "+?......1" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BF")
                ElseIf data = "+?......2" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BFFB")
                ElseIf data = "+!....331" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: BK1")
                ElseIf data = "+!....332" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: FR1")
                ElseIf data = "+!....336" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: FR2")
                ElseIf data = "+!....335" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: BK2")
                Else
                    codeNum = Convert.ToInt32(data)
                    RtbKonzola.AppendText(vbCrLf & "Code: " & String.Format("{0,-8}", codeNum).ToString)
                End If

            Case "42."      'Code: Info 1
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(" Info1: " & String.Format("{0,-8}", numData.ToString))

            Case "43."      'Code: Info2
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(" Info2: " & String.Format("{0,-8}", numData.ToString))

            Case "44."      'Code: Info3
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(" Info3: " & String.Format("{0,-8}", numData.ToString))

            Case "45."      'Code: Info4
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(" Info4: " & numData.ToString)

            Case 110 To 119 'Staff id
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(vbCrLf & String.Format("{0,-8}", numData.ToString))

            Case "32."      'Distance to staff
                Dim dist As Double
                dist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" D: " & String.Format("{0,-9}", Format(dist, "0.000").ToString))

            Case "330"      'Staff reading in MEAS ONLY
                Dim heightReadingMe As Double
                heightReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" ME: ******** ******** " & String.Format("{0,9}", Format(heightReadingMe, "0.00000").ToString))

            Case "331"      'Staff reading, backsight / B1
                Dim heightReadingB1 As Double
                heightReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B1: " & String.Format("{0,9}", Format(heightReadingB1, "0.00000").ToString) & " ******** ********")

            Case "332"      'Staff reading, foresight / F1
                Dim heightReadingF1 As Double
                heightReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F1: ******** " & String.Format("{0,9}", Format(heightReadingF1, "0.00000").ToString) & " ********")

            Case "336"      'Staff reading, foresight / F2
                Dim heightReadingF2 As Double
                heightReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F2: ******** " & String.Format("{0,9}", Format(heightReadingF2, "0.00000").ToString) & " ********")

            Case "335"      'Staff reading, backsight / B2
                Dim heightReadingB2 As Double
                heightReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B2: " & String.Format("{0,9}", Format(heightReadingB2, "0.00000").ToString) & " ******** ********")

            Case "333"      'Staff reading, intermediate sight
                Dim heightReadingIn As Double
                heightReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" IN: ******** ******** " & String.Format("{0,9}", Format(heightReadingIn, "0.00000").ToString))

            Case "334"      'Staff reading, setting-out
                Dim heightReadingSo As Double
                heightReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" SO: ******** ******** " & String.Format("{0,9}", Format(heightReadingSo, "0.00000").ToString))

            Case "52."      'Measurement difference
                Dim sd As Double
                sd = Convert.ToDouble(Microsoft.VisualBasic.Right(data, 4)) / 100
                RtbKonzola.AppendText(" s: " & String.Format("{0,-4}", Format(sd, "0.00").ToString))

            Case "57."
                Dim iTime As Integer
                iTime = Convert.ToInt32(data)
                RtbKonzola.AppendText(" i-time: " & iTime.ToString)

            Case "571"      'Reading difference
                Dim sdiff As Double
                sdiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" S: " & String.Format("{0,-8}", Format(sdiff, "0.00000").ToString))

            Case "572"      'Cumulative diff
                Dim ssDiff As Double
                ssDiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" tS: " & String.Format("{0,-8}", Format(ssDiff, "0.00000").ToString))

            Case "573"      'Difference in distance BF
                Dim distDiff As Double
                distDiff = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" sD: " & String.Format("{0,-8}", Format(distDiff, "0.000").ToString))

            Case "574"      'Total distance
                Dim totalDist As Double
                totalDist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" tD: " & String.Format("{0,-8}", Format(totalDist, "0.000").ToString))

            Case "83."      'Ground heigth
                Dim groundHeigth As Double
                groundHeigth = Convert.ToDouble(data) / 10000
                RtbKonzola.AppendText(" GrHt: " & Format(groundHeigth, "0.0000").ToString)

        End Select
    End Sub

    'Export subroutine if cmbTip is "CSV"
    Private Sub ExportCsv(ByVal wi As String, ByVal data As String)
        Select Case wi

            Case 110 To 119 'Staff id
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(vbCrLf & numData.ToString)

            Case 410 To 419     'Methods and Codes
                If data = "+?......1" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BF")
                ElseIf data = "+?......2" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Method: BFFB")
                ElseIf data = "+!....331" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: BK1")
                ElseIf data = "+!....332" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: FR1")
                ElseIf data = "+!....336" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: FR2")
                ElseIf data = "+!....335" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat: BK2")
                Else
                    codeNum = Convert.ToInt32(data)
                    RtbKonzola.AppendText(vbCrLf & "Code:;" & codeNum.ToString)
                End If

            Case "42."      'Code: Info 1
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(";Info1:;" & numData.ToString)

            Case "43."      'Code: Info2
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(";Info2:;" & numData.ToString)

            Case "44."      'Code: Info3
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(";Info3:;" & numData.ToString)

            Case "45."      'Code: Info4
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(";Info4:;" & numData.ToString)

            Case "32."      'Distance to staff
                Dim dist As Double
                dist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";D:;" & Format(dist, "0.000").ToString)

            Case "330"      'Staff reading in MEAS ONLY
                Dim heightReadingMe As Double
                heightReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";ME:;" & Format(heightReadingMe, "0.00000").ToString & ";;")

            Case "331"      'Staff reading, backsight / B1
                Dim heightReadingB1 As Double
                heightReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B1:;" & Format(heightReadingB1, "0.00000").ToString & ";;")

            Case "332"      'Staff reading, foresight / F1
                Dim heightReadingF1 As Double
                heightReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F1:;;" & Format(heightReadingF1, "0.00000").ToString & ";")

            Case "336"      'Staff reading, foresight / F2
                Dim heightReadingF2 As Double
                heightReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F2:;;" & Format(heightReadingF2, "0.00000").ToString & ";")

            Case "335"      'Staff reading, backsight / B2
                Dim heightReadingB2 As Double
                heightReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B2:;" & Format(heightReadingB2, "0.00000").ToString & ";;")

            Case "333"      'Staff reading, intermediate sight
                Dim heightReadingIn As Double
                heightReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";IN:;;;" & Format(heightReadingIn, "0.00000").ToString)

            Case "334"      'Staff reading, setting-out
                Dim heightReadingSo As Double
                heightReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";SO:;;;" & Format(heightReadingSo, "0.00000").ToString)

            Case "52."      'Measurement difference
                Dim sd As Double
                sd = Convert.ToDouble(Microsoft.VisualBasic.Right(data, 4)) / 100
                RtbKonzola.AppendText(";s:;" & Format(sd, "0.00").ToString)

            Case "57."
                Dim iTime As Integer
                iTime = Convert.ToInt32(data)
                RtbKonzola.AppendText(";i-time:;" & iTime.ToString)

            Case "571"      'Reading difference
                Dim sdiff As Double
                sdiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";S:;" & Format(sdiff, "0.00000").ToString)

            Case "572"      'Cumulative diff
                Dim ssDiff As Double
                ssDiff = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";tS:;" & Format(ssDiff, "0.00000").ToString)

            Case "573"      'Difference in distance BF
                Dim distDiff As Double
                distDiff = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";sD:;" & Format(distDiff, "0.000").ToString)

            Case "574"      'Total distance
                Dim totalDist As Double
                totalDist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";tD:;" & Format(totalDist, "0.000").ToString)

            Case "83."      'Ground heigth
                Dim groundHeigth As Double
                groundHeigth = Convert.ToDouble(data) / 10000
                RtbKonzola.AppendText(";GrHt:;" & Format(groundHeigth, "0.0000").ToString)

        End Select
    End Sub

    'Export subroutine if cmbTip is "CSV"
    Private Sub ExportCsvMeas(ByVal wi As String, ByVal data As String)
        Select Case wi

            Case 110 To 119 'Staff id
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(vbCrLf & numData.ToString)

            Case 410 To 419     'Methods and Codes
                If data = "+?......1" Then
                    RtbKonzola.AppendText(vbCrLf & "******" & vbCrLf & "Method;BF")
                ElseIf data = "+?......2" Then
                    RtbKonzola.AppendText(vbCrLf & "******" & vbCrLf & "Method;BFFB")
                ElseIf data = "+!....331" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat;BK1")
                ElseIf data = "+!....332" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat;FR1")
                ElseIf data = "+!....336" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat;FR2")
                ElseIf data = "+!....335" Then
                    RtbKonzola.AppendText(vbCrLf & "Repeat;BK2")
                Else
                    'codeNum = Convert.ToInt32(data)
                    'RtbKonzola.AppendText(vbCrLf & "Code:;" & codeNum.ToString)
                End If

            Case "42."      'Code: Info 1
                'Dim numData As Integer
                'numData = Convert.ToInt32(data)
                'RtbKonzola.AppendText(";Info1:;" & numData.ToString)

            Case "43."      'Code: Info2
                'Dim numData As Integer
                'numData = Convert.ToInt32(data)
                'RtbKonzola.AppendText(";Info2:;" & numData.ToString)

            Case "44."      'Code: Info3
                'Dim numData As Integer
                'numData = Convert.ToInt32(data)
                'RtbKonzola.AppendText(";Info3:;" & numData.ToString)

            Case "45."      'Code: Info4
                'Dim numData As Integer
                'numData = Convert.ToInt32(data)
                'RtbKonzola.AppendText(";Info4:;" & numData.ToString)

            Case "32."      'Distance to staff
                Dim dist As Double
                dist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";D:;" & Format(dist, "0.000").ToString)

            Case "330"      'Staff reading in MEAS ONLY
                Dim heightReadingMe As Double
                heightReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";ME:;;;" & Format(heightReadingMe, "0.00000").ToString)

            Case "331"      'Staff reading, backsight / B1
                Dim heightReadingB1 As Double
                heightReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B1:;" & Format(heightReadingB1, "0.00000").ToString)

            Case "332"      'Staff reading, foresight / F1
                Dim heightReadingF1 As Double
                heightReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F1:;;" & Format(heightReadingF1, "0.00000").ToString)

            Case "336"      'Staff reading, foresight / F2
                Dim heightReadingF2 As Double
                heightReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F2:;;" & Format(heightReadingF2, "0.00000").ToString)

            Case "335"      'Staff reading, backsight / B2
                Dim heightReadingB2 As Double
                heightReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B2:;" & Format(heightReadingB2, "0.00000").ToString)

            Case "333"      'Staff reading, intermediate sight
                Dim heightReading As Double
                heightReading = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";IN:;;;" & Format(heightReading, "0.00000").ToString)

            Case "334"      'Staff reading, setting-out
                Dim heightReading As Double
                heightReading = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";SO:;;;" & Format(heightReading, "0.00000").ToString)

            Case "52."      'Measurement difference
                'Dim sd As Double
                'sd = Convert.ToDouble(Microsoft.VisualBasic.Right(data, 4)) / 100
                'RtbKonzola.AppendText(";s:;" & Format(sd, "0.00").ToString)

            Case "57."
                'Dim iTime As Integer
                'iTime = Convert.ToInt32(data)
                'RtbKonzola.AppendText(";i-time:;" & iTime.ToString)

            Case "571"      'Reading difference
                'Dim sdiff As Double
                'sdiff = Convert.ToDouble(data) / 100000
                'RtbKonzola.AppendText(";S:;" & Format(sdiff, "0.00000").ToString)

            Case "572"      'Cumulative diff
                'Dim ssDiff As Double
                'ssDiff = Convert.ToDouble(data) / 100000
                'RtbKonzola.AppendText(";tS:;" & Format(ssDiff, "0.00000").ToString)

            Case "573"      'Difference in distance BF
                Dim distDiff As Double
                distDiff = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";sD:;" & Format(distDiff, "0.000").ToString)

            Case "574"      'Total distance
                Dim totalDist As Double
                totalDist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(";tD:;" & Format(totalDist, "0.000").ToString)

            Case "83."      'Ground heigth
                Dim groundHeigth As Double
                groundHeigth = Convert.ToDouble(data) / 10000
                RtbKonzola.AppendText(";GrHt:;" & Format(groundHeigth, "0.0000").ToString)

        End Select
    End Sub

End Class
