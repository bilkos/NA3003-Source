<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbInput = New System.Windows.Forms.TextBox()
        Me.RtbKonzola = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cmbTip = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbComma = New System.Windows.Forms.CheckBox()
        Me.lblDataStatus = New System.Windows.Forms.Label()
        Me.BtnSettings = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.cbCalibration = New System.Windows.Forms.CheckBox()
        Me.cb1Staff = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File selected"
        '
        'TbInput
        '
        Me.TbInput.Location = New System.Drawing.Point(12, 25)
        Me.TbInput.Name = "TbInput"
        Me.TbInput.ReadOnly = True
        Me.TbInput.Size = New System.Drawing.Size(236, 20)
        Me.TbInput.TabIndex = 1
        Me.TbInput.TabStop = False
        '
        'RtbKonzola
        '
        Me.RtbKonzola.AcceptsTab = True
        Me.RtbKonzola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RtbKonzola.BackColor = System.Drawing.SystemColors.MenuText
        Me.RtbKonzola.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.RtbKonzola.ForeColor = System.Drawing.Color.DarkGray
        Me.RtbKonzola.Location = New System.Drawing.Point(12, 94)
        Me.RtbKonzola.Name = "RtbKonzola"
        Me.RtbKonzola.ReadOnly = True
        Me.RtbKonzola.Size = New System.Drawing.Size(800, 376)
        Me.RtbKonzola.TabIndex = 3
        Me.RtbKonzola.TabStop = False
        Me.RtbKonzola.Text = resources.GetString("RtbKonzola.Text")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "NA3003 Data|*.DAT"
        '
        'cmbTip
        '
        Me.cmbTip.FormattingEnabled = True
        Me.cmbTip.Items.AddRange(New Object() {"Standard Report", "Calculated Report", "CSV", "CSV - Measure Only"})
        Me.cmbTip.Location = New System.Drawing.Point(12, 63)
        Me.cmbTip.Name = "cmbTip"
        Me.cmbTip.Size = New System.Drawing.Size(126, 21)
        Me.cmbTip.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fieldbook type"
        '
        'cbComma
        '
        Me.cbComma.Location = New System.Drawing.Point(335, 56)
        Me.cbComma.Name = "cbComma"
        Me.cbComma.Size = New System.Drawing.Size(115, 32)
        Me.cbComma.TabIndex = 3
        Me.cbComma.Text = "Comma as decimal"
        Me.cbComma.UseVisualStyleBackColor = True
        '
        'lblDataStatus
        '
        Me.lblDataStatus.AutoSize = True
        Me.lblDataStatus.Location = New System.Drawing.Point(335, 28)
        Me.lblDataStatus.Name = "lblDataStatus"
        Me.lblDataStatus.Size = New System.Drawing.Size(45, 13)
        Me.lblDataStatus.TabIndex = 9
        Me.lblDataStatus.Text = "No data"
        '
        'BtnSettings
        '
        Me.BtnSettings.Image = Global.NA3003_Fieldbook.My.Resources.Resources.System_22px
        Me.BtnSettings.Location = New System.Drawing.Point(727, 56)
        Me.BtnSettings.Name = "BtnSettings"
        Me.BtnSettings.Size = New System.Drawing.Size(85, 32)
        Me.BtnSettings.TabIndex = 10
        Me.BtnSettings.Text = "Settings"
        Me.BtnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSettings.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Image = Global.NA3003_Fieldbook.My.Resources.Resources.float_24px
        Me.btnHelp.Location = New System.Drawing.Point(679, 18)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(68, 32)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "Help"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Orb_info_16px
        Me.btnAbout.Location = New System.Drawing.Point(753, 18)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(59, 32)
        Me.btnAbout.TabIndex = 6
        Me.btnAbout.Text = "About"
        Me.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Disquette_18px
        Me.BtnSave.Location = New System.Drawing.Point(583, 56)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(92, 32)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Save to File"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Chalkboard2_21px
        Me.BtnCreate.Location = New System.Drawing.Point(456, 56)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(121, 32)
        Me.BtnCreate.TabIndex = 4
        Me.BtnCreate.Text = "Create Fieldbook"
        Me.BtnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Folder_22px
        Me.BtnBrowse.Location = New System.Drawing.Point(254, 18)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(75, 32)
        Me.BtnBrowse.TabIndex = 0
        Me.BtnBrowse.Text = "Browse"
        Me.BtnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'cbCalibration
        '
        Me.cbCalibration.Enabled = False
        Me.cbCalibration.Location = New System.Drawing.Point(144, 56)
        Me.cbCalibration.Name = "cbCalibration"
        Me.cbCalibration.Size = New System.Drawing.Size(75, 32)
        Me.cbCalibration.TabIndex = 11
        Me.cbCalibration.Text = "Calibration"
        Me.cbCalibration.UseVisualStyleBackColor = True
        '
        'cb1Staff
        '
        Me.cb1Staff.Enabled = False
        Me.cb1Staff.Location = New System.Drawing.Point(225, 56)
        Me.cb1Staff.Name = "cb1Staff"
        Me.cb1Staff.Size = New System.Drawing.Size(104, 32)
        Me.cb1Staff.TabIndex = 12
        Me.cb1Staff.Text = "Single rod meas."
        Me.cb1Staff.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 482)
        Me.Controls.Add(Me.cb1Staff)
        Me.Controls.Add(Me.cbCalibration)
        Me.Controls.Add(Me.BtnSettings)
        Me.Controls.Add(Me.lblDataStatus)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.cbComma)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbTip)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.RtbKonzola)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TbInput)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(840, 480)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NA3003 Fieldbook"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbInput As System.Windows.Forms.TextBox
    Friend WithEvents BtnBrowse As System.Windows.Forms.Button
    Friend WithEvents RtbKonzola As System.Windows.Forms.RichTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmbTip As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents cbComma As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents lblDataStatus As System.Windows.Forms.Label
    Friend WithEvents BtnSettings As System.Windows.Forms.Button
    Friend WithEvents cbCalibration As System.Windows.Forms.CheckBox
    Friend WithEvents cb1Staff As System.Windows.Forms.CheckBox

End Class
