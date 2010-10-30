Public Class MainForm
    Inherits SnapForm
    'points always stored in bytes, the lowest common denominator
    Dim DownloadPoints As New BMZPointPairList(2000)
    Dim UploadPoints As New BMZPointPairList(2000)
    Dim WithEvents config As BMZConfig = New BMZConfig
    Private download_color As Color = Color.Red
    Private upload_color As Color = Color.Green

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        MainGraph.BorderStyle = BorderStyle.None
        MainGraph.GraphPane.XAxis.IsVisible = False
        MainGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Date
        MainGraph.GraphPane.YAxis.IsVisible = True
        MainGraph.GraphPane.Fill = New ZedGraph.Fill(Color.Black, Color.DarkGray, 90)
        MainGraph.GraphPane.Chart.Fill = New ZedGraph.Fill(Color.Transparent)
        MainGraph.GraphPane.YAxis.Scale.MagAuto = False
        MainGraph.GraphPane.YAxis.Scale.MajorStepAuto = False
        MainGraph.GraphPane.YAxis.MinorTic.IsAllTics = False
        MainGraph.GraphPane.YAxis.Scale.MaxAuto = False
        MainGraph.GraphPane.YAxis.Scale.MaxGrace = 0
        MainGraph.GraphPane.YAxis.Scale.MinGrace = 0
        MainGraph.GraphPane.YAxis.Scale.MinAuto = False
        MainGraph.GraphPane.YAxis.Scale.IsSkipFirstLabel = True
        MainGraph.GraphPane.YAxis.Title.IsOmitMag = True
        MainGraph.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.YAxis.MajorGrid.IsVisible = True
        MainGraph.GraphPane.YAxis.MajorGrid.Color = Color.LightGray
        MainGraph.GraphPane.YAxis.MajorGrid.DashOff = 2
        MainGraph.GraphPane.YAxis.MajorGrid.DashOn = 3
        MainGraph.GraphPane.YAxis.Title.FontSpec.Size = 10
        MainGraph.GraphPane.YAxis.Scale.FontSpec.Size = 10
        MainGraph.GraphPane.XAxis.Title.FontSpec.Size = 10
        MainGraph.GraphPane.XAxis.Scale.FontSpec.Size = 10
        MainGraph.GraphPane.XAxis.Title.IsVisible = False
        MainGraph.GraphPane.IsFontsScaled = False

        MainGraph.GraphPane.Title.IsVisible = False
        MainGraph.GraphPane.Legend.IsVisible = False
        MainGraph.GraphPane.Margin.All = 0
        MainGraph.GraphPane.Chart.Border.IsVisible = False
        AddHandler MainGraph.GraphPane.YAxis.ScaleFormatEvent, AddressOf YScaleFormatHandler
        AddHandler MainGraph.GraphPane.YAxis.ScaleTitleEvent, AddressOf YScaleTitleHandler
        MainGraph.GraphPane.AddCurve("Download", DownloadPoints, Color.Red, ZedGraph.SymbolType.None)
        MainGraph.GraphPane.AddCurve("Upload", UploadPoints, Color.Green, ZedGraph.SymbolType.None)
        SampleTimer.Enabled = True

        config.LoadFromRegistry()
    End Sub

    Private Function XScaleFormatHandler(ByVal pane As ZedGraph.GraphPane, ByVal axis As ZedGraph.Axis, ByVal val As Double, ByVal index As Integer) As String
        'assume that val is in milliseconds
        XScaleFormatHandler = ""
        If val < 0 Then
            XScaleFormatHandler &= "-"
            val = -val
        End If
        If Math.Floor(val / (24 * 60 * 60 * 1000)) > 0 Then
            XScaleFormatHandler &= Math.Floor(val / (24 * 60 * 60 * 1000)) & "d"
            val = val Mod (24 * 60 * 60 * 1000)
        End If
        If Math.Floor(val / (60 * 60 * 1000)) > 0 Then
            XScaleFormatHandler &= Math.Floor(val / (60 * 60 * 1000)) & "h"
            val = val Mod (60 * 60 * 1000)
        End If
        If Math.Floor(val / (60 * 1000)) > 0 Then
            XScaleFormatHandler &= Math.Floor(val / (60 * 1000)) & "m"
            val = val Mod (60 * 1000)
        End If
        If Math.Floor(val / 1000) > 0 Then
            XScaleFormatHandler &= Math.Floor(val / 1000) & "s"
            val = val Mod 1000
        End If
        If val > 0 Then
            XScaleFormatHandler &= val & "ms"
        End If
        If XScaleFormatHandler = "" Then
            XScaleFormatHandler = "0"
        End If
    End Function


    Private Function YScaleFormatHandler(ByVal pane As ZedGraph.GraphPane, ByVal axis As ZedGraph.Axis, ByVal val As Double, ByVal index As Integer) As String
        Dim MyMajorStep As Double = axis.Scale.MajorStep
        If Not config.DisplayInBytes Then
            val *= 8
            MyMajorStep *= 8
        End If
        If config.KiloIs1024 Then
            If MyMajorStep >= 1024 * 1024 * 1024 Then
                val /= 1024 * 1024 * 1024
            ElseIf MyMajorStep >= 1024 * 1024 Then
                val /= 1024 * 1024
            ElseIf MyMajorStep >= 1024 Then
                val /= 1024
            End If
        Else
            If MyMajorStep >= 100000000 Then
                val /= 1000000000
            ElseIf MyMajorStep >= 100000 Then
                val /= 1000000
            ElseIf MyMajorStep >= 100 Then
                val /= 1000
            End If
        End If
        Return val.ToString
    End Function

    Public Function YScaleTitleHandler(ByVal axis As ZedGraph.Axis) As String
        Dim MyMajorStep As Double = axis.Scale.MajorStep
        If Not config.DisplayInBytes Then
            MyMajorStep *= 8
        End If
        Dim MaxValueFactor As Double = 1.0
        Dim Units As String = ""
        If config.KiloIs1024 Then
            If MyMajorStep >= 1024 * 1024 * 1024 Then
                Units = "Ti"
                MaxValueFactor /= 1024 * 1024 * 1024
            ElseIf MyMajorStep >= 1024 * 1024 Then
                Units = "Mi"
                MaxValueFactor /= 1024 * 1024
            ElseIf MyMajorStep >= 1024 Then
                Units = "ki"
                MaxValueFactor /= 1024
            Else
                Units = ""
            End If
        Else
            If MyMajorStep >= 100000000 Then
                Units = "T"
                MaxValueFactor /= 1000 * 1000 * 1000
            ElseIf MyMajorStep >= 100000 Then
                Units = "M"
                MaxValueFactor /= 1000 * 1000
            ElseIf MyMajorStep >= 100 Then
                Units = "k"
                MaxValueFactor /= 1000
            Else
                Units = ""
            End If
        End If
        If config.DisplayInBytes Then
            Units &= "B/s"
        Else
            Units &= "b/s"
            MaxValueFactor *= 8
        End If
        YScaleTitleHandler = String.Format("{0} (Max: {1:f} {0} U/L, {2:f} {0} D/L)", Units, MaxValueFactor * UploadMax, MaxValueFactor * DownloadMax)
    End Function

    Private Sub SampleTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleTimer.Tick
        Static Dim old_dl_sample As Long = -1
        Static Dim old_ul_sample As Long = -1
        Static Dim old_time As Date = Date.MinValue

        Dim dl_counters As New List(Of PerformanceCounter)
        Dim ul_counters As New List(Of PerformanceCounter)
        Dim c As New PerformanceCounterCategory("Network Interface")
        Dim new_dl_sample As Long = 0
        Dim new_ul_sample As Long = 0

        Dim new_time As DateTime = Now
        For Each Name As String In c.GetInstanceNames
            If Name = "MS TCP Loopback interface" Then
                Continue For
            End If
            Dim dl_pc As New PerformanceCounter("Network Interface", "Bytes Received/sec", Name, True)
            new_dl_sample += dl_pc.RawValue
            Dim ul_pc As New PerformanceCounter("Network Interface", "Bytes Sent/sec", Name, True)
            new_ul_sample += ul_pc.RawValue
        Next
        If new_time > old_time Then
            If old_time <> Date.MinValue Then 'not the first sample
                DownloadPoints.Add(ZedGraph.XDate.DateTimeToXLDate(new_time), (new_dl_sample - old_dl_sample) / (new_time - old_time).TotalSeconds)
                UploadPoints.Add(ZedGraph.XDate.DateTimeToXLDate(new_time), (new_ul_sample - old_ul_sample) / (new_time - old_time).TotalSeconds)
            End If
        End If
        old_time = new_time
        old_dl_sample = new_dl_sample
        old_ul_sample = new_ul_sample
        ReDraw()
    End Sub

    Function SafeLog(ByVal d As Double, ByVal newBase As Double) As Double
        Try
            Return Math.Log(d, newBase)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function SafePow(ByVal x As Double, ByVal y As Double) As Double
        Try
            Return Math.Pow(x, y)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function CalcXBoundedStepSize(ByVal range As Double, ByVal maxSteps As Double) As Double
        If range < 0 Then range = 0
        Dim tempStep As Double = range / maxSteps
        If tempStep <> 0 Then
            If tempStep < 1000 Then
                Dim mag As Double
                Dim magPow As Double
                mag = Math.Floor(SafeLog(tempStep, 10))
                magPow = SafePow(10, mag)
                'Calculate most significant digit of the new step size
                Dim magMsd As Integer = CInt(tempStep / magPow + 0.5)
                If magMsd > 5 Then
                    magMsd = 10
                ElseIf magMsd > 2 Then
                    magMsd = 5
                ElseIf magMsd > 1 Then
                    magMsd = 2
                End If
                Return magMsd * magPow
            ElseIf tempStep < 60 * 1000 Then
                tempStep = tempStep / 1000
                'Calculate the new step size, in seconds
                If tempStep > 30 Then
                    tempStep = 60
                ElseIf tempStep > 10 Then
                    tempStep = 30
                ElseIf tempStep > 5 Then
                    tempStep = 10
                ElseIf tempStep > 2 Then
                    tempStep = 5
                ElseIf tempStep > 1 Then
                    tempStep = 2
                Else
                    tempStep = 1
                End If
                Return tempStep * 1000
            Else 'if tempStep < 60*60*1000 then
                tempStep = tempStep / (60 * 1000)
                'Calculate the new step size, in minutes
                If tempStep > 30 Then
                    tempStep = 60
                ElseIf tempStep > 10 Then
                    tempStep = 30
                ElseIf tempStep > 5 Then
                    tempStep = 10
                ElseIf tempStep > 2 Then
                    tempStep = 5
                ElseIf tempStep > 1 Then
                    tempStep = 2
                Else
                    tempStep = 1
                End If
                Return tempStep * 1000 * 60
            End If
        End If
        Return 0
    End Function

    Private Function CalcYBoundedStepSize(ByVal range As Double, ByVal maxSteps As Double) As Double
        If range < 0 Then range = 0
        If Not config.DisplayInBytes Then range *= 8 'we will multiply by 8 for display
        Dim tempStep As Double = range / maxSteps
        If tempStep <> 0 Then

            Dim mag As Double
            Dim magPow As Double
            If config.KiloIs1024 Then
                mag = Math.Floor(SafeLog(tempStep, 1024))
                magPow = SafePow(1024, mag)
            Else
                mag = Math.Floor(SafeLog(tempStep, 10))
                magPow = SafePow(10, mag)
            End If

            'Calculate most significant digit of the new step size
            Dim magMsd As Integer = CInt(tempStep / magPow + 0.5)

            'promote the MSD to either 1, 2, or 5
            If magMsd > 1000 Then
                magMsd = 2000
            ElseIf magMsd > 500 Then
                magMsd = 1000
            ElseIf magMsd > 200 Then
                magMsd = 500
            ElseIf magMsd > 100 Then
                magMsd = 200
            ElseIf magMsd > 50 Then
                magMsd = 100
            ElseIf magMsd > 10 Then
                magMsd = 50
            ElseIf magMsd > 5 Then
                magMsd = 10
            ElseIf magMsd > 2 Then
                magMsd = 5
            ElseIf magMsd > 1 Then
                magMsd = 2
            End If

            If Not config.DisplayInBytes Then magPow /= 8 'factor out the 8 that we just factored in
            Return magMsd * magPow
        End If
        Return 0
    End Function

    Private DownloadMax As Double
    Private UploadMax As Double
    Private DestinationMaxY As Double
    Private CurrentSpeed As Double = 1.0 'as a percentage of the current size
    Private Const MaxAcceleration As Double = 0.001
    Private Const MaxSpeed As Double = 1.1

    Private Function RecomputeMaxY() As Double
        RecomputeMaxY = 0
        DownloadMax = 0
        UploadMax = 0
        If DownloadPoints.Count > 0 Then
            Dim i As Integer = DownloadPoints.Count - 1
            While i >= 0 AndAlso DownloadPoints(i).X >= MainGraph.GraphPane.XAxis.Scale.Min
                DownloadMax = Math.Max(DownloadMax, DownloadPoints(i).Y)
                UploadMax = Math.Max(UploadMax, UploadPoints(i).Y)
                i -= 1
            End While
            RecomputeMaxY = Math.Max(DownloadMax, UploadMax)
        End If
    End Function

    Private Sub ReDraw()
        If DownloadPoints.Count > 0 Then
            Dim current_time As DateTime = Now
            If Me.WindowState <> FormWindowState.Minimized Then
                MainGraph.GraphPane.XAxis.Scale.Max = DownloadPoints(DownloadPoints.Count - 1).X
                If config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Relative Then
                    MainGraph.GraphPane.XAxis.Scale.Min = MainGraph.GraphPane.XAxis.Scale.Max - MainGraph.GraphPane.Chart.Rect.Width * 1000 / 3
                Else
                    MainGraph.GraphPane.XAxis.Scale.Min = _
                        ZedGraph.XDate.DateTimeToXLDate(ZedGraph.XDate.XLDateToDateTime(MainGraph.GraphPane.XAxis.Scale.Max) - _
                                                        TimeSpan.FromSeconds(MainGraph.GraphPane.Chart.Rect.Width / 3))
                End If
            Else 'the chart size can't be trusted if minimized
                MainGraph.GraphPane.XAxis.Scale.Min += DownloadPoints(DownloadPoints.Count - 1).X - MainGraph.GraphPane.XAxis.Scale.Max
                MainGraph.GraphPane.XAxis.Scale.Max = DownloadPoints(DownloadPoints.Count - 1).X
            End If
        End If
        DestinationMaxY = RecomputeMaxY()
        If DestinationMaxY <> MainGraph.GraphPane.YAxis.Scale.Max Then 'create a new DestinationMaxY only if not scaling at the moment
            SmoothScalingTimer.Enabled = True
        End If
        If config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Relative Then
            MainGraph.GraphPane.XAxis.Scale.MajorStep = CalcXBoundedStepSize(MainGraph.GraphPane.XAxis.Scale.Max - MainGraph.GraphPane.XAxis.Scale.Min, 7)
        End If
        MainGraph.AxisChange()
        MainGraph.Invalidate()
    End Sub

    Private Sub MainGraph_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGraph.Resize
        MainGraph.AxisChange() 'to force recalculation of Chart size
        ReDraw() 'now redraw, which uses the new chart size
    End Sub

    Private Sub SmoothScalingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmoothScalingTimer.Tick
        If DestinationMaxY > MainGraph.GraphPane.YAxis.Scale.Max Then 'need to grow the graph
            Dim TestMaxY As Double = DestinationMaxY
            Dim TestSpeed As Double = 1
            Do While TestMaxY > MainGraph.GraphPane.YAxis.Scale.Max And TestSpeed < CurrentSpeed + MaxAcceleration
                TestSpeed += MaxAcceleration
                TestMaxY = Math.Min(TestMaxY - 1, TestMaxY / TestSpeed)
            Loop
            'TestSpeed is the fastest that we can go without overshooting the Destination
            CurrentSpeed = Math.Min(CurrentSpeed + MaxAcceleration, TestSpeed)
        ElseIf DestinationMaxY < MainGraph.GraphPane.YAxis.Scale.Max Then 'need to shrink the graph
            Dim TestMaxY As Double = DestinationMaxY
            Dim TestSpeed As Double = 1
            Do While TestMaxY < MainGraph.GraphPane.YAxis.Scale.Max And TestSpeed > CurrentSpeed - MaxAcceleration
                TestSpeed -= MaxAcceleration
                TestMaxY = Math.Max(TestMaxY + 1, TestMaxY / TestSpeed)
            Loop
            'TestSpeed is the fastest that we can go without overshooting the Destination
            CurrentSpeed = Math.Max(CurrentSpeed - MaxAcceleration, TestSpeed)
        End If
        If (Math.Abs(DestinationMaxY - MainGraph.GraphPane.YAxis.Scale.Max) <= 1) OrElse _
           (DestinationMaxY >= MainGraph.GraphPane.YAxis.Scale.Max AndAlso MainGraph.GraphPane.YAxis.Scale.Max * (1.0 + MaxAcceleration) >= DestinationMaxY) OrElse _
           (DestinationMaxY <= MainGraph.GraphPane.YAxis.Scale.Max AndAlso MainGraph.GraphPane.YAxis.Scale.Max * (1.0 - MaxAcceleration) <= DestinationMaxY) Then
            MainGraph.GraphPane.YAxis.Scale.Max = DestinationMaxY 'close enough, all done
            SmoothScalingTimer.Enabled = False
        ElseIf CurrentSpeed > 1 Then 'move as current speed, at least 1
            MainGraph.GraphPane.YAxis.Scale.Max = Math.Max(MainGraph.GraphPane.YAxis.Scale.Max + 1, MainGraph.GraphPane.YAxis.Scale.Max * CurrentSpeed)
        ElseIf CurrentSpeed < 1 Then 'move as current speed, at least 1
            MainGraph.GraphPane.YAxis.Scale.Max = Math.Min(MainGraph.GraphPane.YAxis.Scale.Max - 1, MainGraph.GraphPane.YAxis.Scale.Max * CurrentSpeed)
        End If
        MainGraph.GraphPane.YAxis.Scale.MajorStep = CalcYBoundedStepSize(MainGraph.GraphPane.YAxis.Scale.Max - MainGraph.GraphPane.YAxis.Scale.Min, 7)
        MainGraph.AxisChange()
        MainGraph.Invalidate()
    End Sub

    Private Sub config_DisplayInBytesChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles config.DisplayInBytesChanged, _
                                                                                                          config.KiloIs1024Changed
        ReDraw()
    End Sub

    Private Sub config_ShowBarsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles config.ShowBarsChanged
        DownloadPoints.UseBars = config.ShowBars
        UploadPoints.UseBars = config.ShowBars
        ReDraw()
    End Sub

    Private Sub config_YAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles config.YAxisStyleChanged
        Select Case config.YAxisStyle
            Case BMZConfig.DisplayYAxisStyle.None
                MainGraph.GraphPane.YAxis.IsVisible = False
            Case BMZConfig.DisplayYAxisStyle.Max
                MainGraph.GraphPane.YAxis.IsVisible = True
                MainGraph.GraphPane.YAxis.MajorTic.IsAllTics = False
                MainGraph.GraphPane.YAxis.MajorGrid.IsVisible = False
                MainGraph.GraphPane.YAxis.Scale.IsVisible = False
            Case BMZConfig.DisplayYAxisStyle.Scale
                MainGraph.GraphPane.YAxis.IsVisible = True
                MainGraph.GraphPane.YAxis.MajorTic.IsAllTics = True
                MainGraph.GraphPane.YAxis.MajorGrid.IsVisible = True
                MainGraph.GraphPane.YAxis.Scale.IsVisible = True
        End Select
        MainGraph.AxisChange() 'to force recalculation of Chart size
        ReDraw()
    End Sub

    Private Sub config_XAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles config.XAxisStyleChanged
        Select Case config.XAxisStyle
            Case BMZConfig.DisplayXAxisStyle.None
                MainGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Date
                DownloadPoints.RelativeTime = False
                UploadPoints.RelativeTime = False
                RemoveHandler MainGraph.GraphPane.XAxis.ScaleFormatEvent, AddressOf XScaleFormatHandler
                MainGraph.GraphPane.XAxis.Scale.MajorStepAuto = True
                MainGraph.GraphPane.XAxis.IsVisible = False
            Case BMZConfig.DisplayXAxisStyle.Time
                MainGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Date
                DownloadPoints.RelativeTime = False
                UploadPoints.RelativeTime = False
                RemoveHandler MainGraph.GraphPane.XAxis.ScaleFormatEvent, AddressOf XScaleFormatHandler
                MainGraph.GraphPane.XAxis.Scale.MajorStepAuto = True
                MainGraph.GraphPane.XAxis.IsVisible = True
            Case BMZConfig.DisplayXAxisStyle.Relative
                MainGraph.GraphPane.XAxis.Type = ZedGraph.AxisType.Linear
                DownloadPoints.RelativeTime = True
                UploadPoints.RelativeTime = True
                AddHandler MainGraph.GraphPane.XAxis.ScaleFormatEvent, AddressOf XScaleFormatHandler
                MainGraph.GraphPane.XAxis.Scale.MajorStepAuto = False
                MainGraph.GraphPane.XAxis.IsVisible = True
        End Select
        MainGraph.AxisChange() 'to force recalculation of Chart size
        ReDraw()
    End Sub

    Private Sub MainGraph_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGraph.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim cf As New ConfigForm(config)
            cf.Show(Me)
        End If
    End Sub
End Class
