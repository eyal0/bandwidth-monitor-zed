Public Class ConfigForm
    Dim config As BMZConfig

    Public Sub New(ByVal config As BMZConfig)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.config = config
    End Sub

    Private Sub ConfigForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFromConfig()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveToConfig()
    End Sub

    Private Sub SaveToConfig()
        config.DisplayInBytes = chkDisplayInBytes.Checked
        config.KiloIs1024 = chkKiloIs1024.Checked
        config.ShowBars = chkShowBars.Checked
        'If radYAxisMax.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.Max
        If radYAxisNone.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.None
        If radYAxisScale.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.Scale
        If radXAxisNone.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.None
        If radXAxisTime.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Time
        If radXAxisRelative.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Relative
        config.SamplePeriodMilliseconds = TextToMilliseconds(txtSamplePeriod.Text)
        config.SampleWidthPixels = Double.Parse(txtSampleWidthPixels.Text)
        config.SampleCount = Integer.Parse(txtSampleCount.Text)
        config.RunAtStartup = chkRunAtStartup.Checked
        config.StartMinimized = chkStartMinimized.Checked
        config.AlwaysOnTop = chkAlwaysOnTop.Checked
        config.Opacity = OpacityTrackBar.Value
        config.SaveToRegistry()
    End Sub

    Private Sub LoadFromConfig()
        chkDisplayInBytes.Checked = config.DisplayInBytes
        chkKiloIs1024.Checked = config.KiloIs1024
        chkShowBars.Checked = config.ShowBars
        Select Case config.YAxisStyle
            Case BMZConfig.DisplayYAxisStyle.Max
                'radYAxisMax.Checked = True
            Case BMZConfig.DisplayYAxisStyle.None
                radYAxisNone.Checked = True
            Case BMZConfig.DisplayYAxisStyle.Scale
                radYAxisScale.Checked = True
        End Select
        Select Case config.XAxisStyle
            Case BMZConfig.DisplayXAxisStyle.Time
                radXAxisTime.Checked = True
            Case BMZConfig.DisplayXAxisStyle.None
                radXAxisNone.Checked = True
            Case BMZConfig.DisplayXAxisStyle.Relative
                radXAxisRelative.Checked = True
        End Select
        txtSamplePeriod.Text = MillisecondsToText(config.SamplePeriodMilliseconds)
        txtSampleWidthPixels.Text = config.SampleWidthPixels.ToString
        txtSampleCount.Text = config.SampleCount.ToString
        chkRunAtStartup.Checked = config.RunAtStartup
        chkStartMinimized.Checked = config.StartMinimized
        chkAlwaysOnTop.Checked = config.AlwaysOnTop
        OpacityTrackBar.Value = config.Opacity
    End Sub

    Private Sub SamplePeriodTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SamplePeriodTrackBar.Scroll
        Dim NewSamplePeriod As Integer
        If SamplePeriodTrackBar.Value < 9 Then
            'in the millisecond range
            Select Case SamplePeriodTrackBar.Value Mod 3
                Case 0
                    NewSamplePeriod = 1
                Case 1
                    NewSamplePeriod = 2
                Case 2
                    NewSamplePeriod = 5
            End Select
            NewSamplePeriod *= CInt(Math.Pow(10, Math.Floor(SamplePeriodTrackBar.Value / 3)))
        Else
            Select Case (SamplePeriodTrackBar.Value - 9) Mod 6
                Case 0
                    NewSamplePeriod = 1
                Case 1
                    NewSamplePeriod = 2
                Case 2
                    NewSamplePeriod = 5
                Case 3
                    NewSamplePeriod = 10
                Case 4
                    NewSamplePeriod = 20
                Case 5
                    NewSamplePeriod = 30
            End Select
            If SamplePeriodTrackBar.Value < 15 Then
                NewSamplePeriod *= 1000
            Else
                NewSamplePeriod *= 60000
            End If
        End If
        txtSamplePeriod.Text = MillisecondsToText(NewSamplePeriod)
    End Sub

    Private Function TextToMilliseconds(ByVal s As String) As Integer
        TextToMilliseconds = 0
        Dim current_pos As Integer = 0
        Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "([^a-zA-Z]+)([a-zA-Z]*)")
        Do While m.Success
            Dim current_num As Double = Double.Parse(m.Groups(1).Value)
            Select Case m.Groups(2).Value.ToLower()
                Case "ms"
                    'current_num *= 1
                Case "m"
                    current_num *= 60 * 1000
                Case "s"
                    current_num *= 1000
                Case ""
                    'assume ms current_num *= 1
                Case Else
                    current_num = 0
            End Select
            TextToMilliseconds += CInt(current_num)
            m = m.NextMatch()
        Loop
    End Function

    Private Function MillisecondsToText(ByVal Milliseconds As Integer) As String
        MillisecondsToText = ""
        If Math.Floor(Milliseconds / 60000) > 0 Then
            MillisecondsToText &= Math.Floor(Milliseconds / 60000) & "m"
            Milliseconds -= CInt(Math.Floor(Milliseconds / 60000)) * 60000
        End If
        If Math.Floor(Milliseconds / 1000) > 0 Then
            MillisecondsToText &= Math.Floor(Milliseconds / 1000) & "s"
            Milliseconds -= CInt(Math.Floor(Milliseconds / 1000)) * 1000
        End If
        If Math.Floor(Milliseconds) > 0 Then
            MillisecondsToText &= Math.Floor(Milliseconds) & "ms"
            Milliseconds -= CInt(Math.Floor(Milliseconds))
        End If
    End Function

    Private Sub txtSamplePeriod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSamplePeriod.Validating
        If TextToMilliseconds(txtSamplePeriod.Text) > 0 Then
            txtSamplePeriod.Text = MillisecondsToText(TextToMilliseconds(txtSamplePeriod.Text))
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSampleWidth_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSampleWidthPixels.Validating
        Dim SampleWidthPixels As Double
        If Double.TryParse(txtSampleWidthPixels.Text, SampleWidthPixels) Then
            txtSampleWidthPixels.Text = SampleWidthPixels.ToString()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSampleCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSampleCount.Validating
        Dim SampleCount As Integer
        If Integer.TryParse(txtSampleCount.Text, SampleCount) Then
            txtSampleCount.Text = SampleCount.ToString()
        Else
            e.Cancel = True
        End If
    End Sub
End Class