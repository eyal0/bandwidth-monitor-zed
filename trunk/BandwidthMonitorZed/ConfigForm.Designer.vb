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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabGeneral = New System.Windows.Forms.TabPage()
        Me.lblOpacity = New System.Windows.Forms.Label()
        Me.OpacityTrackBar = New System.Windows.Forms.TrackBar()
        Me.chkAlwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.chkStartMinimized = New System.Windows.Forms.CheckBox()
        Me.chkRunAtStartup = New System.Windows.Forms.CheckBox()
        Me.TabGraph = New System.Windows.Forms.TabPage()
        Me.chkKiloIs1024 = New System.Windows.Forms.CheckBox()
        Me.gbxXAxisStyle = New System.Windows.Forms.GroupBox()
        Me.radXAxisRelative = New System.Windows.Forms.RadioButton()
        Me.radXAxisTime = New System.Windows.Forms.RadioButton()
        Me.radXAxisNone = New System.Windows.Forms.RadioButton()
        Me.chkDisplayInBytes = New System.Windows.Forms.CheckBox()
        Me.chkShowBars = New System.Windows.Forms.CheckBox()
        Me.gbxYAxisStyle = New System.Windows.Forms.GroupBox()
        Me.radYAxisScale = New System.Windows.Forms.RadioButton()
        Me.radYAxisNone = New System.Windows.Forms.RadioButton()
        Me.TabSampling = New System.Windows.Forms.TabPage()
        Me.lblSampleCount = New System.Windows.Forms.Label()
        Me.txtSampleCount = New System.Windows.Forms.TextBox()
        Me.lblSampleWidth = New System.Windows.Forms.Label()
        Me.txtSampleWidthPixels = New System.Windows.Forms.TextBox()
        Me.txtSamplePeriod = New System.Windows.Forms.TextBox()
        Me.lblSamplePeriod = New System.Windows.Forms.Label()
        Me.SamplePeriodTrackBar = New System.Windows.Forms.TrackBar()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.MainTabControl.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        CType(Me.OpacityTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGraph.SuspendLayout()
        Me.gbxXAxisStyle.SuspendLayout()
        Me.gbxYAxisStyle.SuspendLayout()
        Me.TabSampling.SuspendLayout()
        CType(Me.SamplePeriodTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(247, 315)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(185, 315)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'MainTabControl
        '
        Me.MainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTabControl.Controls.Add(Me.TabGeneral)
        Me.MainTabControl.Controls.Add(Me.TabGraph)
        Me.MainTabControl.Controls.Add(Me.TabSampling)
        Me.MainTabControl.Location = New System.Drawing.Point(12, 12)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(291, 297)
        Me.MainTabControl.TabIndex = 8
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.lblOpacity)
        Me.TabGeneral.Controls.Add(Me.OpacityTrackBar)
        Me.TabGeneral.Controls.Add(Me.chkAlwaysOnTop)
        Me.TabGeneral.Controls.Add(Me.chkStartMinimized)
        Me.TabGeneral.Controls.Add(Me.chkRunAtStartup)
        Me.TabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeneral.Size = New System.Drawing.Size(283, 271)
        Me.TabGeneral.TabIndex = 0
        Me.TabGeneral.Text = "General"
        Me.TabGeneral.UseVisualStyleBackColor = True
        '
        'lblOpacity
        '
        Me.lblOpacity.AutoSize = True
        Me.lblOpacity.Location = New System.Drawing.Point(6, 75)
        Me.lblOpacity.Name = "lblOpacity"
        Me.lblOpacity.Size = New System.Drawing.Size(43, 13)
        Me.lblOpacity.TabIndex = 12
        Me.lblOpacity.Text = "Opacity"
        '
        'OpacityTrackBar
        '
        Me.OpacityTrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpacityTrackBar.AutoSize = False
        Me.OpacityTrackBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.OpacityTrackBar.LargeChange = 16
        Me.OpacityTrackBar.Location = New System.Drawing.Point(55, 75)
        Me.OpacityTrackBar.Maximum = 255
        Me.OpacityTrackBar.Name = "OpacityTrackBar"
        Me.OpacityTrackBar.Size = New System.Drawing.Size(222, 20)
        Me.OpacityTrackBar.SmallChange = 8
        Me.OpacityTrackBar.TabIndex = 11
        Me.OpacityTrackBar.TickFrequency = 16
        Me.OpacityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'chkAlwaysOnTop
        '
        Me.chkAlwaysOnTop.AutoSize = True
        Me.chkAlwaysOnTop.Location = New System.Drawing.Point(6, 52)
        Me.chkAlwaysOnTop.Name = "chkAlwaysOnTop"
        Me.chkAlwaysOnTop.Size = New System.Drawing.Size(98, 17)
        Me.chkAlwaysOnTop.TabIndex = 10
        Me.chkAlwaysOnTop.Text = "Always On Top"
        Me.chkAlwaysOnTop.UseVisualStyleBackColor = True
        '
        'chkStartMinimized
        '
        Me.chkStartMinimized.AutoSize = True
        Me.chkStartMinimized.Location = New System.Drawing.Point(6, 29)
        Me.chkStartMinimized.Name = "chkStartMinimized"
        Me.chkStartMinimized.Size = New System.Drawing.Size(97, 17)
        Me.chkStartMinimized.TabIndex = 9
        Me.chkStartMinimized.Text = "Start Minimized"
        Me.chkStartMinimized.UseVisualStyleBackColor = True
        '
        'chkRunAtStartup
        '
        Me.chkRunAtStartup.AutoSize = True
        Me.chkRunAtStartup.Location = New System.Drawing.Point(6, 6)
        Me.chkRunAtStartup.Name = "chkRunAtStartup"
        Me.chkRunAtStartup.Size = New System.Drawing.Size(96, 17)
        Me.chkRunAtStartup.TabIndex = 8
        Me.chkRunAtStartup.Text = "Run At Startup"
        Me.chkRunAtStartup.UseVisualStyleBackColor = True
        '
        'TabGraph
        '
        Me.TabGraph.Controls.Add(Me.chkKiloIs1024)
        Me.TabGraph.Controls.Add(Me.gbxXAxisStyle)
        Me.TabGraph.Controls.Add(Me.chkDisplayInBytes)
        Me.TabGraph.Controls.Add(Me.chkShowBars)
        Me.TabGraph.Controls.Add(Me.gbxYAxisStyle)
        Me.TabGraph.Location = New System.Drawing.Point(4, 22)
        Me.TabGraph.Name = "TabGraph"
        Me.TabGraph.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGraph.Size = New System.Drawing.Size(283, 271)
        Me.TabGraph.TabIndex = 2
        Me.TabGraph.Text = "Graph"
        Me.TabGraph.UseVisualStyleBackColor = True
        '
        'chkKiloIs1024
        '
        Me.chkKiloIs1024.AutoSize = True
        Me.chkKiloIs1024.Location = New System.Drawing.Point(6, 6)
        Me.chkKiloIs1024.Name = "chkKiloIs1024"
        Me.chkKiloIs1024.Size = New System.Drawing.Size(80, 17)
        Me.chkKiloIs1024.TabIndex = 8
        Me.chkKiloIs1024.Text = "Kilo is 1024"
        Me.chkKiloIs1024.UseVisualStyleBackColor = True
        '
        'gbxXAxisStyle
        '
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisRelative)
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisTime)
        Me.gbxXAxisStyle.Controls.Add(Me.radXAxisNone)
        Me.gbxXAxisStyle.Location = New System.Drawing.Point(6, 169)
        Me.gbxXAxisStyle.Name = "gbxXAxisStyle"
        Me.gbxXAxisStyle.Size = New System.Drawing.Size(132, 88)
        Me.gbxXAxisStyle.TabIndex = 12
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
        'chkDisplayInBytes
        '
        Me.chkDisplayInBytes.AutoSize = True
        Me.chkDisplayInBytes.Location = New System.Drawing.Point(6, 29)
        Me.chkDisplayInBytes.Name = "chkDisplayInBytes"
        Me.chkDisplayInBytes.Size = New System.Drawing.Size(135, 17)
        Me.chkDisplayInBytes.TabIndex = 9
        Me.chkDisplayInBytes.Text = "Scale in bytes (not bits)"
        Me.chkDisplayInBytes.UseVisualStyleBackColor = True
        '
        'chkShowBars
        '
        Me.chkShowBars.AutoSize = True
        Me.chkShowBars.Location = New System.Drawing.Point(6, 52)
        Me.chkShowBars.Name = "chkShowBars"
        Me.chkShowBars.Size = New System.Drawing.Size(77, 17)
        Me.chkShowBars.TabIndex = 11
        Me.chkShowBars.Text = "Show Bars"
        Me.chkShowBars.UseVisualStyleBackColor = True
        '
        'gbxYAxisStyle
        '
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisScale)
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisNone)
        Me.gbxYAxisStyle.Location = New System.Drawing.Point(6, 75)
        Me.gbxYAxisStyle.Name = "gbxYAxisStyle"
        Me.gbxYAxisStyle.Size = New System.Drawing.Size(129, 88)
        Me.gbxYAxisStyle.TabIndex = 10
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
        'TabSampling
        '
        Me.TabSampling.Controls.Add(Me.lblSampleCount)
        Me.TabSampling.Controls.Add(Me.txtSampleCount)
        Me.TabSampling.Controls.Add(Me.lblSampleWidth)
        Me.TabSampling.Controls.Add(Me.txtSampleWidthPixels)
        Me.TabSampling.Controls.Add(Me.txtSamplePeriod)
        Me.TabSampling.Controls.Add(Me.lblSamplePeriod)
        Me.TabSampling.Controls.Add(Me.SamplePeriodTrackBar)
        Me.TabSampling.Location = New System.Drawing.Point(4, 22)
        Me.TabSampling.Name = "TabSampling"
        Me.TabSampling.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSampling.Size = New System.Drawing.Size(283, 271)
        Me.TabSampling.TabIndex = 1
        Me.TabSampling.Text = "Sampling"
        Me.TabSampling.UseVisualStyleBackColor = True
        '
        'lblSampleCount
        '
        Me.lblSampleCount.AutoSize = True
        Me.lblSampleCount.Location = New System.Drawing.Point(6, 61)
        Me.lblSampleCount.Name = "lblSampleCount"
        Me.lblSampleCount.Size = New System.Drawing.Size(76, 13)
        Me.lblSampleCount.TabIndex = 6
        Me.lblSampleCount.Text = "Sample Count:"
        '
        'txtSampleCount
        '
        Me.txtSampleCount.Location = New System.Drawing.Point(88, 58)
        Me.txtSampleCount.Name = "txtSampleCount"
        Me.txtSampleCount.Size = New System.Drawing.Size(49, 20)
        Me.txtSampleCount.TabIndex = 5
        Me.txtSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtSampleWidthPixels
        '
        Me.txtSampleWidthPixels.Location = New System.Drawing.Point(134, 32)
        Me.txtSampleWidthPixels.Name = "txtSampleWidthPixels"
        Me.txtSampleWidthPixels.Size = New System.Drawing.Size(49, 20)
        Me.txtSampleWidthPixels.TabIndex = 3
        Me.txtSampleWidthPixels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSamplePeriod
        '
        Me.txtSamplePeriod.Location = New System.Drawing.Point(90, 6)
        Me.txtSamplePeriod.Name = "txtSamplePeriod"
        Me.txtSamplePeriod.Size = New System.Drawing.Size(49, 20)
        Me.txtSamplePeriod.TabIndex = 2
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
        Me.SamplePeriodTrackBar.Size = New System.Drawing.Size(132, 20)
        Me.SamplePeriodTrackBar.TabIndex = 0
        Me.SamplePeriodTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.Location = New System.Drawing.Point(12, 315)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(56, 23)
        Me.btnQuit.TabIndex = 9
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'ConfigForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(315, 350)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "ConfigForm"
        Me.Text = "Configuration - BMZ"
        Me.MainTabControl.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        CType(Me.OpacityTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGraph.ResumeLayout(False)
        Me.TabGraph.PerformLayout()
        Me.gbxXAxisStyle.ResumeLayout(False)
        Me.gbxXAxisStyle.PerformLayout()
        Me.gbxYAxisStyle.ResumeLayout(False)
        Me.gbxYAxisStyle.PerformLayout()
        Me.TabSampling.ResumeLayout(False)
        Me.TabSampling.PerformLayout()
        CType(Me.SamplePeriodTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents TabSampling As System.Windows.Forms.TabPage
    Friend WithEvents txtSamplePeriod As System.Windows.Forms.TextBox
    Friend WithEvents lblSamplePeriod As System.Windows.Forms.Label
    Friend WithEvents SamplePeriodTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblSampleWidth As System.Windows.Forms.Label
    Friend WithEvents txtSampleWidthPixels As System.Windows.Forms.TextBox
    Friend WithEvents chkRunAtStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartMinimized As System.Windows.Forms.CheckBox
    Friend WithEvents TabGraph As System.Windows.Forms.TabPage
    Friend WithEvents lblOpacity As System.Windows.Forms.Label
    Friend WithEvents OpacityTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents chkAlwaysOnTop As System.Windows.Forms.CheckBox
    Friend WithEvents chkKiloIs1024 As System.Windows.Forms.CheckBox
    Friend WithEvents gbxXAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radXAxisRelative As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisTime As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisNone As System.Windows.Forms.RadioButton
    Friend WithEvents chkDisplayInBytes As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowBars As System.Windows.Forms.CheckBox
    Friend WithEvents gbxYAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radYAxisScale As System.Windows.Forms.RadioButton
    Friend WithEvents radYAxisNone As System.Windows.Forms.RadioButton
    Friend WithEvents txtSampleCount As System.Windows.Forms.TextBox
    Friend WithEvents lblSampleCount As System.Windows.Forms.Label
    Friend WithEvents btnQuit As System.Windows.Forms.Button
End Class
