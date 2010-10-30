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
        Me.radYAxisMax = New System.Windows.Forms.RadioButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkShowBars = New System.Windows.Forms.CheckBox()
        Me.gbxXAxisStyle = New System.Windows.Forms.GroupBox()
        Me.radXAxisRelative = New System.Windows.Forms.RadioButton()
        Me.radXAxisTime = New System.Windows.Forms.RadioButton()
        Me.radXAxisNone = New System.Windows.Forms.RadioButton()
        Me.gbxYAxisStyle.SuspendLayout()
        Me.gbxXAxisStyle.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkKiloIs1024
        '
        Me.chkKiloIs1024.AutoSize = True
        Me.chkKiloIs1024.Location = New System.Drawing.Point(12, 12)
        Me.chkKiloIs1024.Name = "chkKiloIs1024"
        Me.chkKiloIs1024.Size = New System.Drawing.Size(80, 17)
        Me.chkKiloIs1024.TabIndex = 0
        Me.chkKiloIs1024.Text = "Kilo is 1024"
        Me.chkKiloIs1024.UseVisualStyleBackColor = True
        '
        'chkDisplayInBytes
        '
        Me.chkDisplayInBytes.AutoSize = True
        Me.chkDisplayInBytes.Location = New System.Drawing.Point(12, 35)
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
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisMax)
        Me.gbxYAxisStyle.Controls.Add(Me.radYAxisNone)
        Me.gbxYAxisStyle.Location = New System.Drawing.Point(12, 81)
        Me.gbxYAxisStyle.Name = "gbxYAxisStyle"
        Me.gbxYAxisStyle.Size = New System.Drawing.Size(129, 88)
        Me.gbxYAxisStyle.TabIndex = 3
        Me.gbxYAxisStyle.TabStop = False
        Me.gbxYAxisStyle.Text = "YAxis"
        '
        'radYAxisScale
        '
        Me.radYAxisScale.AutoSize = True
        Me.radYAxisScale.Location = New System.Drawing.Point(6, 65)
        Me.radYAxisScale.Name = "radYAxisScale"
        Me.radYAxisScale.Size = New System.Drawing.Size(82, 17)
        Me.radYAxisScale.TabIndex = 4
        Me.radYAxisScale.TabStop = True
        Me.radYAxisScale.Text = "Show Scale"
        Me.radYAxisScale.UseVisualStyleBackColor = True
        '
        'radYAxisMax
        '
        Me.radYAxisMax.AutoSize = True
        Me.radYAxisMax.Location = New System.Drawing.Point(6, 42)
        Me.radYAxisMax.Name = "radYAxisMax"
        Me.radYAxisMax.Size = New System.Drawing.Size(75, 17)
        Me.radYAxisMax.TabIndex = 3
        Me.radYAxisMax.TabStop = True
        Me.radYAxisMax.Text = "Show Max"
        Me.radYAxisMax.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(223, 201)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(161, 201)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkShowBars
        '
        Me.chkShowBars.AutoSize = True
        Me.chkShowBars.Location = New System.Drawing.Point(12, 58)
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
        Me.gbxXAxisStyle.Location = New System.Drawing.Point(147, 81)
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
        'ConfigForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(291, 236)
        Me.Controls.Add(Me.gbxXAxisStyle)
        Me.Controls.Add(Me.chkShowBars)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gbxYAxisStyle)
        Me.Controls.Add(Me.chkDisplayInBytes)
        Me.Controls.Add(Me.chkKiloIs1024)
        Me.Name = "ConfigForm"
        Me.Text = "Configuration - BMZ"
        Me.gbxYAxisStyle.ResumeLayout(False)
        Me.gbxYAxisStyle.PerformLayout()
        Me.gbxXAxisStyle.ResumeLayout(False)
        Me.gbxXAxisStyle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkKiloIs1024 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisplayInBytes As System.Windows.Forms.CheckBox
    Friend WithEvents radYAxisNone As System.Windows.Forms.RadioButton
    Friend WithEvents gbxYAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radYAxisScale As System.Windows.Forms.RadioButton
    Friend WithEvents radYAxisMax As System.Windows.Forms.RadioButton
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkShowBars As System.Windows.Forms.CheckBox
    Friend WithEvents gbxXAxisStyle As System.Windows.Forms.GroupBox
    Friend WithEvents radXAxisRelative As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisTime As System.Windows.Forms.RadioButton
    Friend WithEvents radXAxisNone As System.Windows.Forms.RadioButton
End Class
