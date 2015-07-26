'Serial Port Interfacing with VB.net 2010 Express Edition
'Copyright (C) 2010  Richard Myrick T. Arellaga
'
'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.
'
'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/&gt;.

Imports System.IO.Ports

Public Class frmMain
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'When our form loads, auto detect all serial ports in the system and populate the cmbPort Combo box.
        myPort = SerialPort.GetPortNames() 'Get all com ports available
        cmbBaud.Items.Add(2400)     'Populate the cmbBaud Combo box to common baud rates used
        cmbBaud.Items.Add(4800)
        cmbBaud.Items.Add(9600)

        For i = 0 To UBound(myPort)
            cmbPort.Items.Add(myPort(i))
        Next
        cmbPort.Text = cmbPort.Items.Item(My.Settings.LastSelectedPort)    'Set cmbPort text to the first COM port detected
        cmbBaud.Text = cmbBaud.Items.Item(My.Settings.LastSelectedRate)    'Set cmbBaud text to the first Baud rate on the list

        btnDisconnect.Enabled = False           'Initially Disconnect Button is Disabled

    End Sub

    Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
        rtbReceived.Clear()
        lblStatus.Text = "Status: connected to " & cmbPort.Text & " with " & cmbBaud.Text & " bps"
        SerialPort1.PortName = cmbPort.Text         'Set SerialPort1 to the selected COM port at startup
        SerialPort1.BaudRate = cmbBaud.Text         'Set Baud rate to the selected value on

        'Other Serial Port Property
        SerialPort1.Parity = Parity.Even       'Set parity
        SerialPort1.StopBits = StopBits.One    'Set stop bits
        SerialPort1.DataBits = 7                        'Set data bits
        SerialPort1.Open()                  'Open our serial port

        cmbPort.Enabled = False
        cmbBaud.Enabled = False
        btnConnect.Enabled = False          'Disable Connect button
        btnDisconnect.Enabled = True        'and Enable Disconnect button

    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDisconnect.Click
        SerialPort1.Close()             'Close our Serial Port
        lblStatus.Text = "Status: No connection open..."

        cmbPort.Enabled = True
        cmbBaud.Enabled = True
        btnConnect.Enabled = True
        btnDisconnect.Enabled = False
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadLine())    'Automatically called every time a data is received at the serialPort
    End Sub
    Private Sub ReceivedText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If rtbReceived.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Invoke(x, New Object() {(text)})
        Else
            Dim recText As String = [text]
            Dim waitLine As String = "w"
            Dim endOfFile As String = "! ----+"
            Dim doubleQuest As String = "??"

            recText = Replace(recText, doubleQuest, "")
            recText = Replace(recText, waitLine, "")
            'At end of file - EOF
            If recText.Contains(endOfFile) = True Then
                recText = Replace(recText, endOfFile, "")
                Dim eofMessage As Object = MsgBox("End of transfer." & vbCrLf & vbCrLf & "Do you want to save data?", MsgBoxStyle.YesNo, "NA3003: Transfer done")
                If eofMessage = DialogResult.Yes Then
                    SaveFileSub()
                End If
            End If

            If recText.Length > 10 Then
                rtbReceived.AppendText(recText)
            End If

            SerialPort1.Write("?" & vbCrLf)
        End If
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPort.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.PortName = cmbPort.Text
            My.Settings.LastSelectedPort = cmbPort.SelectedIndex    'save index of selected port to My.Settings
            My.Settings.Save()
        Else
            MsgBox("Valid only if port is Closed", vbCritical)  'pop a message box to user if he is changing baud rate
        End If
    End Sub

    Private Sub cmbBaud_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBaud.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.BaudRate = cmbBaud.Text
            My.Settings.LastSelectedRate = cmbBaud.SelectedIndex    'save index of selected rate to My.Settings
            My.Settings.Save()
        Else
            MsgBox("Valid only if port is Closed", vbCritical)  'pop a message box to user if he is changing ports
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rtbReceived.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveFileSub()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox1.Show()
    End Sub

    Private Sub SaveFileSub()
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            rtbReceived.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
            MsgBox("Data saved to '" & SaveFileDialog1.FileName, MsgBoxStyle.Information, "NA3003: File saved")
            rtbReceived.Clear()
        End If
    End Sub
End Class
