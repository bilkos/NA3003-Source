<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.cbCalibration = New System.Windows.Forms.CheckBox()
        Me.cb1Staff = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffCalibrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuickHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File selected:"
        '
        'TbInput
        '
        Me.TbInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TbInput.Location = New System.Drawing.Point(168, 36)
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
        Me.RtbKonzola.BackColor = System.Drawing.Color.Black
        Me.RtbKonzola.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.RtbKonzola.ForeColor = System.Drawing.Color.Silver
        Me.RtbKonzola.Location = New System.Drawing.Point(12, 109)
        Me.RtbKonzola.Name = "RtbKonzola"
        Me.RtbKonzola.ReadOnly = True
        Me.RtbKonzola.Size = New System.Drawing.Size(800, 472)
        Me.RtbKonzola.TabIndex = 10
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
        Me.cmbTip.Items.AddRange(New Object() {"Calculated Report", "Standard Report", "CSV", "CSV - Measure Only"})
        Me.cmbTip.Location = New System.Drawing.Point(12, 78)
        Me.cmbTip.Name = "cmbTip"
        Me.cmbTip.Size = New System.Drawing.Size(126, 21)
        Me.cmbTip.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fieldbook type"
        '
        'cbComma
        '
        Me.cbComma.Location = New System.Drawing.Point(335, 71)
        Me.cbComma.Name = "cbComma"
        Me.cbComma.Size = New System.Drawing.Size(115, 32)
        Me.cbComma.TabIndex = 4
        Me.cbComma.Text = "Comma as decimal"
        Me.cbComma.UseVisualStyleBackColor = True
        '
        'lblDataStatus
        '
        Me.lblDataStatus.AutoSize = True
        Me.lblDataStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblDataStatus.Location = New System.Drawing.Point(410, 39)
        Me.lblDataStatus.Name = "lblDataStatus"
        Me.lblDataStatus.Size = New System.Drawing.Size(52, 13)
        Me.lblDataStatus.TabIndex = 9
        Me.lblDataStatus.Text = "No data"
        '
        'cbCalibration
        '
        Me.cbCalibration.Enabled = False
        Me.cbCalibration.Location = New System.Drawing.Point(144, 71)
        Me.cbCalibration.Name = "cbCalibration"
        Me.cbCalibration.Size = New System.Drawing.Size(75, 32)
        Me.cbCalibration.TabIndex = 2
        Me.cbCalibration.Text = "Calibration"
        Me.cbCalibration.UseVisualStyleBackColor = True
        '
        'cb1Staff
        '
        Me.cb1Staff.Enabled = False
        Me.cb1Staff.Location = New System.Drawing.Point(225, 71)
        Me.cb1Staff.Name = "cb1Staff"
        Me.cb1Staff.Size = New System.Drawing.Size(104, 32)
        Me.cb1Staff.TabIndex = 3
        Me.cb1Staff.Text = "Single rod meas."
        Me.cb1Staff.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(824, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Folder_22px
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Disquette_18px
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Power_21px
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StaffCalibrationToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'StaffCalibrationToolStripMenuItem
        '
        Me.StaffCalibrationToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.System_22px
        Me.StaffCalibrationToolStripMenuItem.Name = "StaffCalibrationToolStripMenuItem"
        Me.StaffCalibrationToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.StaffCalibrationToolStripMenuItem.Text = "&Staff Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.QuickHelpToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Orb_info_16px
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'QuickHelpToolStripMenuItem
        '
        Me.QuickHelpToolStripMenuItem.Image = Global.NA3003_Fieldbook.My.Resources.Resources.float_24px
        Me.QuickHelpToolStripMenuItem.Name = "QuickHelpToolStripMenuItem"
        Me.QuickHelpToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.QuickHelpToolStripMenuItem.Text = "Quick &Help"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        Me.OpenFileDialog2.Filter = "NA3003 Calibration File|*.txt"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnSave.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Disquette_18px
        Me.BtnSave.Location = New System.Drawing.Point(583, 71)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(65, 32)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCreate
        '
        Me.BtnCreate.BackColor = System.Drawing.Color.Transparent
        Me.BtnCreate.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Chalkboard2_21px
        Me.BtnCreate.Location = New System.Drawing.Point(456, 71)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(121, 32)
        Me.BtnCreate.TabIndex = 5
        Me.BtnCreate.Text = "Create Fieldbook"
        Me.BtnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'BtnBrowse
        '
        Me.BtnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.BtnBrowse.Image = Global.NA3003_Fieldbook.My.Resources.Resources.Folder_22px
        Me.BtnBrowse.Location = New System.Drawing.Point(12, 28)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(75, 32)
        Me.BtnBrowse.TabIndex = 0
        Me.BtnBrowse.Text = "Browse"
        Me.BtnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBrowse.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 593)
        Me.Controls.Add(Me.cb1Staff)
        Me.Controls.Add(Me.cbCalibration)
        Me.Controls.Add(Me.lblDataStatus)
        Me.Controls.Add(Me.cbComma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbTip)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.RtbKonzola)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TbInput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(840, 480)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NA3003 Fieldbook v1.3"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
    Friend WithEvents cbComma As System.Windows.Forms.CheckBox
    Friend WithEvents lblDataStatus As System.Windows.Forms.Label
    Friend WithEvents cbCalibration As System.Windows.Forms.CheckBox
    Friend WithEvents cb1Staff As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StaffCalibrationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuickHelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
End Class
