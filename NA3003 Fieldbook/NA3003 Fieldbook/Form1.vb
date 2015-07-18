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
    Dim codeNum As Integer

    Dim dist As Double
    Dim heigthReadingMe As Double
    Dim heigthReadingB1 As Double
    Dim heigthReadingF1 As Double
    Dim heigthReadingF2 As Double
    Dim heigthReadingB2 As Double
    Dim heigthReadingIn As Double
    Dim heigthReadingSo As Double
    Dim sdiff As Double
    Dim ssDiff As Double
    Dim distDiff As Double
    Dim totalDist As Double
    Dim groundHeigth As Double
    Dim GrHt As Double
    Dim GrHtPrev As Double

    'On form load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTip.SelectedItem = "Standard Report"
        BtnSave.Enabled = False
        BtnCreate.Enabled = False
        cmbTip.Enabled = False
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        HelpForm.Show()

    End Sub

    'On Save button click
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'Set filename to original filename without extension
        SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        'If we created text format fbk, then save as *.TXT
        If cmbTip.SelectedItem = "Standard Report" Or cmbTip.SelectedItem = "GURS Report" Then
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
    End Sub

    'Read text file until end of file
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If checkFile = True Then
            RtbKonzola.Clear()
            If cmbTip.SelectedItem = "Standard Report" Then
                RtbKonzola.ForeColor = Color.LimeGreen
            ElseIf cmbTip.SelectedItem = "GURS Report" Then
                RtbKonzola.ForeColor = Color.Orange
            ElseIf cmbTip.SelectedItem = "CSV" Or cmbTip.SelectedItem = "CSV - Measure Only" Then
                RtbKonzola.ForeColor = Color.DarkTurquoise
            Else
                RtbKonzola.ForeColor = Color.Silver
            End If
            ' prepare StreamReader
            Dim streamReader As StreamReader = New StreamReader(OpenFileDialog1.FileName)
            Dim i As Integer = 0
            ' loop untill end of stream
            Do Until streamReader.EndOfStream
                'Split each line to separate fields
                Dim line() As String = streamReader.ReadLine().Split(" ")
                'for each line send data to DataType() subroutine
                If i = 0 Then
                    If cmbTip.SelectedItem = "Standard Report" Then
                        RtbKonzola.AppendText("+++++ Leica NA3003 Fieldbook - Standard v1.1 +++++")
                    End If
                    If cmbTip.SelectedItem = "GURS Report" Then
                        RtbKonzola.AppendText("+++++ Leica NA3003 Fieldbook - GURS v1.1 +++++")
                    End If
                    If cmbTip.SelectedItem = "CSV" Then
                        RtbKonzola.AppendText("+++++; Leica; NA3003; Fieldbook; - CSV; v1.1; +++++")
                    End If
                    If cmbTip.SelectedItem = "CSV - Measure Only" Then
                        RtbKonzola.AppendText("+++++; Leica; NA3003; Fieldbook; - CSV; v1.1; +++++")
                    End If
                End If
                For Each lineData As String In line
                    DataType(lineData)
                Next
                i = i + 1
            Loop
            ' close file that was opened for reading
            streamReader.Close()    'close streamreader
            BtnSave.Enabled = True  'enable Save button
            If cbComma.Checked = True Then
                RtbKonzola.Text = Replace(RtbKonzola.Text, ".", ",")
            End If
            lblDataStatus.Text = "File NOT saved."
            MsgBox("Export to '" & cmbTip.SelectedItem & "' done." & vbCrLf & "Don't forget to save.", MsgBoxStyle.Information, "Create Fieldbook")
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

        ElseIf cmbTip.SelectedItem = "GURS Report" Then
            ExportGURS(wordIndex, data)

        ElseIf cmbTip.SelectedItem = "CSV" Then
            ExportCsv(wordIndex, data)

        ElseIf cmbTip.SelectedItem = "CSV - Measure Only" Then
            ExportCsvMeas(wordIndex, data)

        End If
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
                Dim heigthReadingMe As Double
                heigthReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" ME: ******** ******** " & String.Format("{0,9}", Format(heigthReadingMe, "0.00000").ToString))

            Case "331"      'Staff reading, backsight / B1
                Dim heigthReadingB1 As Double
                heigthReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B1: " & String.Format("{0,9}", Format(heigthReadingB1, "0.00000").ToString) & " ******** ********")

            Case "332"      'Staff reading, foresight / F1
                Dim heigthReadingF1 As Double
                heigthReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F1: ******** " & String.Format("{0,9}", Format(heigthReadingF1, "0.00000").ToString) & " ********")

            Case "336"      'Staff reading, foresight / F2
                Dim heigthReadingF2 As Double
                heigthReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F2: ******** " & String.Format("{0,9}", Format(heigthReadingF2, "0.00000").ToString) & " ********")

            Case "335"      'Staff reading, backsight / B2
                Dim heigthReadingB2 As Double
                heigthReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B2: " & String.Format("{0,9}", Format(heigthReadingB2, "0.00000").ToString) & " ******** ********")

            Case "333"      'Staff reading, intermediate sight
                Dim heigthReadingIn As Double
                heigthReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" IN: ******** ******** " & String.Format("{0,9}", Format(heigthReadingIn, "0.00000").ToString))

            Case "334"      'Staff reading, setting-out
                Dim heigthReadingSo As Double
                heigthReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" SO: ******** ******** " & String.Format("{0,9}", Format(heigthReadingSo, "0.00000").ToString))

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

    'Export subroutine if cmbTip is "GURS"
    Private Sub ExportGURS(ByVal wi As String, ByVal data As String)

        Select Case wi
            Case 410 To 419 'Measuring info or Code line
                If data = "+?......1" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Metoda: BF")
                ElseIf data = "+?......2" Then
                    RtbKonzola.AppendText(vbCrLf & "********" & vbCrLf & "Metoda: BFFB")
                    GrHt = 0
                    heigthReadingB1 = 0
                    heigthReadingB2 = 0
                    heigthReadingF1 = 0
                    heigthReadingF2 = 0
                ElseIf data = "+!....331" Then
                    RtbKonzola.AppendText(vbCrLf & "Ponovitev: B1")
                ElseIf data = "+!....332" Then
                    RtbKonzola.AppendText(vbCrLf & "Ponovitev: F1")
                ElseIf data = "+!....336" Then
                    RtbKonzola.AppendText(vbCrLf & "Ponovitev: F2")
                ElseIf data = "+!....335" Then
                    RtbKonzola.AppendText(vbCrLf & "Ponovitev: B2")
                    GrHt = GrHtPrev

                Else
                    codeNum = Convert.ToInt32(data)
                    If codeNum = 1 Then
                        'do nothing - old code commented bellow
                        'RtbKonzola.AppendText("Temperatura: ")
                    ElseIf codeNum = 10 Then    'Koda 10 - 3 podatki (poligon, par lat, datum)
                        RtbKonzola.AppendText(vbCrLf & "Koda 10 (Info)")
                    ElseIf codeNum = 30 Then    'Koda 30 - 4 podatki (čas, temperatura, vreme, pogoji)
                        RtbKonzola.AppendText(vbCrLf & "Koda 30 (Pogoji)")
                    ElseIf codeNum = 33 Then    'Koda 33 - 2 podatka (par lat, lata začetek/konec)
                        RtbKonzola.AppendText(vbCrLf & "Koda 33 (Late)")
                    Else                        'Ostale kode - 1 do 4 podatki
                        RtbKonzola.AppendText(vbCrLf & "Koda " & codeNum.ToString)
                    End If
                End If

            Case "42."  'Code
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 1 Then ' koda 1 za temperaturo - info 1
                    'do nothing - old code commented bellow
                    'Dim tempT As Double = Convert.ToDouble(numData) / 10
                    'RtbKonzola.AppendText(Format(tempT, "0.0").ToString)
                ElseIf codeNum = 10 Then    ' koda 10: številka poligona - info 1
                    RtbKonzola.AppendText(" poligon: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: čas vnosa - info 1
                    RtbKonzola.AppendText(" čas: " & numData.ToString)
                ElseIf codeNum = 33 Then    ' koda 33: številka para lat - info 1
                    RtbKonzola.AppendText(" par: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info1
                    RtbKonzola.AppendText(" Info1: " & numData.ToString)
                End If

            Case "43."  ' Code: Info2
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 10 Then        ' koda 10: št. para lat - info 2
                    RtbKonzola.AppendText(" št.lat: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: temperatura - info 2
                    RtbKonzola.AppendText(" temp: " & numData.ToString)
                ElseIf codeNum = 33 Then    ' koda 33: lata na začetku/koncu vlaka - info 2
                    RtbKonzola.AppendText(" lata: " & numData.ToString & vbCrLf)
                Else                        ' sicer izvozimo običajno Info2
                    RtbKonzola.AppendText(" Info2: " & numData.ToString)
                End If

            Case "44."  ' Code: Info3
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 10 Then    ' koda 10: datum meritve - info 3
                    RtbKonzola.AppendText(" datum: " & numData.ToString)
                ElseIf codeNum = 30 Then    ' koda 30: vremenski pogoji - info 3
                    RtbKonzola.AppendText(" vreme: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info3
                    RtbKonzola.AppendText(" Info3: " & numData.ToString)
                End If

            Case "45."  ' Code: Info4
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                If codeNum = 30 Then        ' koda 30: pogoji niveliranja
                    RtbKonzola.AppendText(" pogoji: " & numData.ToString)
                Else                        ' sicer izvozimo običajno Info4
                    RtbKonzola.AppendText(" Info4: " & numData.ToString)
                End If

            Case 110 To 119 'Staff id
                Dim numData As Integer
                numData = Convert.ToInt32(data)
                RtbKonzola.AppendText(vbCrLf & String.Format("{0,-8}", numData.ToString))

            Case "32."  'Distance to staff
                dist = Convert.ToDouble(data) / 1000
                RtbKonzola.AppendText(" D: " & String.Format("{0,8}", Format(dist, "0.000").ToString))

            Case "330"  'Staff reading in MEAS ONLY
                heigthReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" ME: " & String.Format("{0,8}", Format(heigthReadingMe, "0.00000").ToString))

            Case "331"  'Staff reading, backsight / B1
                heigthReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B1: " & String.Format("{0,8}", Format(heigthReadingB1, "0.00000").ToString))

            Case "332"  'Staff reading, foresight / F1
                heigthReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F1: ******** " & String.Format("{0,8}", Format(heigthReadingF1, "0.00000").ToString))

            Case "336"  'Staff reading, foresight / F2
                heigthReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" F2: ******** " & String.Format("{0,8}", Format(heigthReadingF2, "0.00000").ToString))

            Case "335"  'Staff reading, backsight / B2
                heigthReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" B2: " & String.Format("{0,8}", Format(heigthReadingB2, "0.00000").ToString))

            Case "333"  'Staff reading, intermediate sight
                heigthReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" IN: ******** ******** " & String.Format("{0,8}", Format(heigthReadingIn, "0.00000").ToString))

            Case "334"  'Staff reading, setting-out
                heigthReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(" SO: ******** ******** " & String.Format("{0,8}", Format(heigthReadingSo, "0.00000").ToString))

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
                GrHtPrev = GrHt
                GrHt = (GrHt + (heigthReadingB1 + heigthReadingB2) / 2) - ((heigthReadingF1 + heigthReadingF2) / 2)
                RtbKonzola.AppendText(" GrHt: " & Format(groundHeigth, "0.0000").ToString & " GrHtIzr: " & Format(GrHt, "0.00000").ToString & vbCrLf)

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
                Dim heigthReadingMe As Double
                heigthReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";ME:;" & Format(heigthReadingMe, "0.00000").ToString & ";;")

            Case "331"      'Staff reading, backsight / B1
                Dim heigthReadingB1 As Double
                heigthReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B1:;" & Format(heigthReadingB1, "0.00000").ToString & ";;")

            Case "332"      'Staff reading, foresight / F1
                Dim heigthReadingF1 As Double
                heigthReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F1:;;" & Format(heigthReadingF1, "0.00000").ToString & ";")

            Case "336"      'Staff reading, foresight / F2
                Dim heigthReadingF2 As Double
                heigthReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F2:;;" & Format(heigthReadingF2, "0.00000").ToString & ";")

            Case "335"      'Staff reading, backsight / B2
                Dim heigthReadingB2 As Double
                heigthReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B2:;" & Format(heigthReadingB2, "0.00000").ToString & ";;")

            Case "333"      'Staff reading, intermediate sight
                Dim heigthReadingIn As Double
                heigthReadingIn = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";IN:;;;" & Format(heigthReadingIn, "0.00000").ToString)

            Case "334"      'Staff reading, setting-out
                Dim heigthReadingSo As Double
                heigthReadingSo = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";SO:;;;" & Format(heigthReadingSo, "0.00000").ToString)

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
                Dim heigthReadingMe As Double
                heigthReadingMe = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";ME:;;;" & Format(heigthReadingMe, "0.00000").ToString)

            Case "331"      'Staff reading, backsight / B1
                Dim heigthReadingB1 As Double
                heigthReadingB1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B1:;" & Format(heigthReadingB1, "0.00000").ToString)

            Case "332"      'Staff reading, foresight / F1
                Dim heigthReadingF1 As Double
                heigthReadingF1 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F1:;;" & Format(heigthReadingF1, "0.00000").ToString)

            Case "336"      'Staff reading, foresight / F2
                Dim heigthReadingF2 As Double
                heigthReadingF2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";F2:;;" & Format(heigthReadingF2, "0.00000").ToString)

            Case "335"      'Staff reading, backsight / B2
                Dim heigthReadingB2 As Double
                heigthReadingB2 = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";B2:;" & Format(heigthReadingB2, "0.00000").ToString)

            Case "333"      'Staff reading, intermediate sight
                Dim heigthReading As Double
                heigthReading = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";IN:;;;" & Format(heigthReading, "0.00000").ToString)

            Case "334"      'Staff reading, setting-out
                Dim heigthReading As Double
                heigthReading = Convert.ToDouble(data) / 100000
                RtbKonzola.AppendText(";SO:;;;" & Format(heigthReading, "0.00000").ToString)

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
