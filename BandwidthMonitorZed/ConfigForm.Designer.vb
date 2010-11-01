<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
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
        Me.chkKiloIs1024 = New System.Windows.Forms.CheckBox()
        Me.chkDisplayInBytes = New System.Windows.Forms.CheckBox()
        Me.radYAxisNone = New System.Windows.Forms.RadioButton()
        Me.gbxYAxisStyle = New System.Windows.Forms.GroupBox()
        Me.radYAxisScale = New System.Windows.Forms.RadioButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkShowBars = New System.Windows.Forms.CheckBox()
        Me.gbxXAxisStyle = New System.Windows.Forms.GroupBox()
        Me.radXAxisRelative = New System.Windows.Forms.RadioButton()
        Me.radXAxisTime = New System.Windows.Forms.RadioButton()
        Me.radXAxisNone = New System.Windows.Forms.RadioButton()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabGeneral = New System.Windows.Forms.TabPage()
        Me.TabSampling = New System.Windows.Forms.TabPage()
        Me.lblSampleWidth = New System.Windows.Forms.Label()
        Me.txtSampleWidth = New System.Windows.Forms.TextBox()
        Me.txtSamplePeriod = New System.Windows.Forms.TextBox()
        Me.lblSamplePeriod = New System.Windows.Forms.Label()
        Me.SamplePeriodTrackBar = New System.Windows.Forms.TrackBar()
        Me.gbxYAxisStyle.SuspendLayout()
        Me.gbxXAxisStyle.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.TabSampling.SuspendLayout()
        CType(Me.SamplePeriodTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkKiloIs1024
        '
        Me.chkKiloIs1024.AutoSize = True
        Me.chkKiloIs1024.Location = New System.Drawing.Point(6, 6)
        Me.chkKiloIs1024.Name = "chkKiloIs1024"
        Me.chkKiloIs1024.Size = New System.Drawing.Size(80, 17)
        Me.chkKiloIs1024.TabIndex = 0
        Me.chkKiloIs1024.Text = "Kilo is 1024"
        Me.chkKiloIs1024.UseVisualStyleBackColor = True
        '
        'chkDisplayInBytes
        '
        Me.chkDisplayInBytes.AutoSize = True
        Me.chkDisplayInBytes.Location = New System.Drawing.Point(6, 29)
        Me.chkDisplayInBytes.Name = "chkDisplayInBytes"
        Me.chkDisplayInBytes.Size = New System.Drawing.Size(135, 17)
        Me.chkDisplayInBytes.TabIndex = 1
        Me.chkDisplayInBytes.Text = "Scale in bytes (not bits)"
        Me.chkDisplayInBytes.UseVisualStyleBackColor = True
        '
        'radYAxisNone
        '
        Me.radYAxisNone.AutoSize = True
        Me.radYAxisNone.Location = New System.Drawing.Point(6, 19)
        Me.radYAxisNone.Name = "radYAxisNone"
        Me.radYAxisNone.Size = New System.Drawing.Size(51, 17)
        Me.radYAxisNone.TabIndex = 2
        Me.radYAxisNone.TabStop = True
        Me.radYAxisNone.Text = "None"
        Me.radYAxisNone.UseVisualStyleBackColor = True
        '
        'gbxYAxisStyle
        '
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisScale)
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisNone)
        Me.gbxYAxisStyle.Location = New System.Drawing.Point(6, 120)
        Me.gbxYAxisStyle.Name = "gbxYAxisStyle"
        Me.gbxYAxisStyle.Size = New System.Drawing.Size(129, 88)
        Me.gbxYAxisStyle.TabIndex = 3
        Me.gbxYAxisStyle.TabStop = False
        Me.gbxYAxisStyle.Text = "YAxis"
        '
        'radYAxisScale
        '
        Me.radYAxisScale.AutoSize = True
        Me.radYAxisScale.Location = New System.Drawing.Point(6, 42)
        Me.radYAxisScale.Name = "radYAxisScale"
        Me.radYAxisScale.Size = New System.Drawing.Size(82, 17)
        Me.radYAxisScale.TabIndex = 4
        Me.radYAxisScale.TabStop = True
        Me.radYAxisScale.Text = "Show Scale"
        Me.radYAxisScale.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(258, 258)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(196, 258)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkShowBars
        '
        Me.chkShowBars.AutoSize = True
        Me.chkShowBars.Location = New System.Drawing.Point(6, 52)
        Me.chkShowBars.Name = "chkShowBars"
        Me.chkShowBars.Size = New System.Drawing.Size(77, 17)
        Me.chkShowBars.TabIndex = 6
        Me.chkShowBars.Text = "Show Bars"
        Me.chkShowBars.UseVisualStyleBackColor = True
        '
        'gbxXAxisStyle
        '
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisRelative)
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisTime)
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisNone)
        Me.gbxXAxisStyle.Location = New System.Drawing.Point(141, 120)
        Me.gbxXAxisStyle.Name = "gbxXAxisStyle"
        Me.gbxXAxisStyle.Size = New System.Drawing.Size(132, 88)
        Me.gbxXAxisStyle.TabIndex = 7
        Me.gbxXAxisStyle.TabStop = False
        Me.gbxXAxisStyle.Text = "XAxis"
        '
        'radXAxisRelative
        '
        Me.radXAxisRelative.AutoSize = True
        Me.radXAxisRelative.Location = New System.Drawing.Point(6, 65)
        Me.radXAxisRelative.Name = "radXAxisRelative"
        Me.radXAxisRelative.Size = New System.Drawing.Size(120, 17)
        Me.radXAxisRelative.TabIndex = 4
        Me.radXAxisRelative.TabStop = True
        Me.radXAxisRelative.Text = "Show Relative Time"
        Me.radXAxisRelative.UseVisualStyleBackColor = True
        '
        'radXAxisTime
        '
        Me.radXAxisTime.AutoSize = True
        Me.radXAxisTime.Location = New System.Drawing.Point(6, 42)
        Me.radXAxisTime.Name = "radXAxisTime"
        Me.radXAxisTime.Size = New System.Drawing.Size(78, 17)
        Me.radXAxisTime.TabIndex = 3
        Me.radXAxisTime.TabStop = True
        Me.radXAxisTime.Text = "Show Time"
        Me.radXAxisTime.UseVisualStyleBackColor = True
        '
        'radXAxisNone
        '
        Me.radXAxisNone.AutoSize = True
        Me.radXAxisNone.Location = New System.Drawing.Point(6, 19)
        Me.radXAxisNone.Name = "radXAxisNone"
        Me.radXAxisNone.Size = New System.Drawing.Size(51, 17)
        Me.radXAxisNone.TabIndex = 2
        Me.radXAxisNone.TabStop = True
        Me.radXAxisNone.Text = "None"
        Me.radXAxisNone.UseVisualStyleBackColor = True
        '
        'MainTabControl
        '
        Me.MainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTabControl.Controls.Add(Me.TabGeneral)
        Me.MainTabControl.Controls.Add(Me.TabSampling)
        Me.MainTabControl.Location = New System.Drawing.Point(12, 12)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(302, 240)
        Me.MainTabControl.TabIndex = 8
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.chkKiloIs1024)
        Me.TabGeneral.Controls.Add(Me.gbxXAxisStyle)
        Me.TabGeneral.Controls.Add(Me.chkDisplayInBytes)
        Me.TabGeneral.Controls.Add(Me.chkShowBars)
        Me.TabGeneral.Controls.Add(Me.gbxYAxisStyle)
        Me.TabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeneral.Size = New System.Drawing.Size(294, 214)
        Me.TabGeneral.TabIndex = 0
        Me.TabGeneral.Text = "General"
        Me.TabGeneral.UseVisualStyleBackColor = True
        '
        'TabSampling
        '
        Me.TabSampling.Controls.Add(Me.lblSampleWidth)
        Me.TabSampling.Controls.Add(Me.txtSampleWidth)
        Me.TabSampling.Controls.Add(Me.txtSamplePeriod)
        Me.TabSampling.Controls.Add(Me.lblSamplePeriod)
        Me.TabSampling.Controls.Add(Me.SamplePeriodTrackBar)
        Me.TabSampling.Location = New System.Drawing.Point(4, 22)
        Me.TabSampling.Name = "TabSampling"
        Me.TabSampling.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSampling.Size = New System.Drawing.Size(294, 178)
        Me.TabSampling.TabIndex = 1
        Me.TabSampling.Text = "Sampling"
        Me.TabSampling.UseVisualStyleBackColor = True
        '
        'lblSampleWidth
        '
        Me.lblSampleWidth.AutoSize = True
        Me.lblSampleWidth.Location = New System.Drawing.Point(6, 35)
        Me.lblSampleWidth.Name = "lblSampleWidth"
        Me.lblSampleWidth.Size = New System.Drawing.Size(122, 13)
        Me.lblSampleWidth.TabIndex = 4
        Me.lblSampleWidth.Text = "Sample Width (in pixels):"
        '
        'txtSampleWidth
        '
        Me.txtSampleWidth.Location = New System.Drawing.Point(134, 32)
        Me.txtSampleWidth.Name = "txtSampleWidth"
        Me.txtSampleWidth.Size = New System.Drawing.Size(49, 20)
        Me.txtSampleWidth.TabIndex = 3
        Me.txtSampleWidth.Text = "3"
        Me.txtSampleWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSamplePeriod
        '
        Me.txtSamplePeriod.Location = New System.Drawing.Point(90, 6)
        Me.txtSamplePeriod.Name = "txtSamplePeriod"
        Me.txtSamplePeriod.Size = New System.Drawing.Size(49, 20)
        Me.txtSamplePeriod.TabIndex = 2
        Me.txtSamplePeriod.Text = "1000ms"
        Me.txtSamplePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSamplePeriod
        '
        Me.lblSamplePeriod.AutoSize = True
        Me.lblSamplePeriod.Location = New System.Drawing.Point(6, 9)
        Me.lblSamplePeriod.Name = "lblSamplePeriod"
        Me.lblSamplePeriod.Size = New System.Drawing.Size(78, 13)
        Me.lblSamplePeriod.TabIndex = 1
        Me.lblSamplePeriod.Text = "Sample Period:"
        '
        'SamplePeriodTrackBar
        '
        Me.SamplePeriodTrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SamplePeriodTrackBar.AutoSize = False
        Me.SamplePeriodTrackBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.SamplePeriodTrackBar.Location = New System.Drawing.Point(145, 6)
        Me.SamplePeriodTrackBar.Maximum = 20
        Me.SamplePeriodTrackBar.Name = "SamplePeriodTrackBar"
        Me.SamplePeriodTrackBar.Size = New System.Drawing.Size(143, 20)
        Me.SamplePeriodTrackBar.TabIndex = 0
        Me.SamplePeriodTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'ConfigForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(326, 293)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "ConfigForm"
        Me.Text = "Configuration - BMZ"
        Me.gbxYAxisStyle.ResumeLayout(False)
        Me.gbxYAxisStyle.PerformLayout()
        Me.gbxXAxisStyle.ResumeLayout(False)
        Me.gbxXAxisStyle.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        Me.TabSampling.ResumeLayout(False)
        Me.TabSampling.PerformLayout()
        CType(Me.SamplePeriodTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkKiloIs1024 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisplayInBytes As System.Windows.Forms.CheckBox
    Friend WithEvents radYAxisNone As System.Windows.Forms.RadioButton
    Friend WithEvents gbxYAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radYAxisScale As System.Windows.Forms.RadioButton
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkShowBars As System.Windows.Forms.CheckBox
    Friend WithEvents gbxXAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radXAxisRelative As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisTime As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisNone As System.Windows.Forms.RadioButton
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents TabSampling As System.Windows.Forms.TabPage
    Friend WithEvents txtSamplePeriod As System.Windows.Forms.TextBox
    Friend WithEvents lblSamplePeriod As System.Windows.Forms.Label
    Friend WithEvents SamplePeriodTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblSampleWidth As System.Windows.Forms.Label
    Friend WithEvents txtSampleWidth As System.Windows.Forms.TextBox
End Class
