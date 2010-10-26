Public Class MainForm
    Inherits SnapForm
    'points always stored in bits, the lowest common denominator
    Dim DownloadPoints As New ZedGraph.RollingPointPairList(2000)
    Dim UploadPoints As New ZedGraph.RollingPointPairList(2000)

    Dim InBits As Boolean = True
    Dim KiloIs1024 As Boolean = True

    Private download_color As Color = Color.Red
    Private upload_color As Color = Color.Green
    Dim dl_counters As New List(Of PerformanceCounter)
    Dim ul_counters As New List(Of PerformanceCounter)
    Dim old_dl_sample As Long
    Dim old_ul_sample As Long
    Dim old_time As Date

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim c As New PerformanceCounterCategory("Network Interface")
        For Each Name As String In c.GetInstanceNames
            If Name = "MS TCP Loopback interface" Then
                Continue For
            End If
            dl_counters.Add(New PerformanceCounter("Network Interface", "Bytes Received/sec", Name))
            ul_counters.Add(New PerformanceCounter("Network Interface", "Bytes Sent/sec", Name))
        Next
        old_dl_sample = 0
        old_ul_sample = 0
        For Each current_counter As PerformanceCounter In dl_counters
            old_dl_sample += current_counter.NextSample.RawValue
        Next
        For Each current_counter As PerformanceCounter In ul_counters
            old_ul_sample += current_counter.NextSample.RawValue
        Next

        old_time = Now

        MainGraph.BorderStyle = BorderStyle.None
        MainGraph.GraphPane.XAxis.IsVisible = False
        MainGraph.GraphPane.YAxis.IsVisible = True
        MainGraph.GraphPane.Fill = New ZedGraph.Fill(Color.Black, Color.DarkGray, 90)
        MainGraph.GraphPane.Chart.Fill = New ZedGraph.Fill(Color.Black, Color.DarkGray, 90)
        MainGraph.GraphPane.YAxis.Scale.MagAuto = False
        MainGraph.GraphPane.YAxis.Scale.MajorStepAuto = False
        MainGraph.GraphPane.YAxis.MinorTic.IsAllTics = False
        MainGraph.GraphPane.YAxis.Scale.MaxAuto = False
        MainGraph.GraphPane.YAxis.Scale.MaxGrace = 0
        MainGraph.GraphPane.YAxis.Scale.MinGrace = 0
        MainGraph.GraphPane.YAxis.Scale.MinAuto = False
        MainGraph.GraphPane.YAxis.Title.IsOmitMag = True
        MainGraph.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White
        MainGraph.GraphPane.YAxis.MajorGrid.IsVisible = True
        MainGraph.GraphPane.YAxis.MajorGrid.Color = Color.LightGray
        MainGraph.GraphPane.YAxis.MajorGrid.DashOff = 2
        MainGraph.GraphPane.YAxis.MajorGrid.DashOn = 3

        MainGraph.GraphPane.Title.IsVisible = False
        MainGraph.GraphPane.Legend.IsVisible = False
        'MainGraph.GraphPane.Margin.Left = 1
        'MainGraph.GraphPane.Margin.Right = 1
        MainGraph.GraphPane.Chart.Border.IsVisible = False
        AddHandler MainGraph.GraphPane.YAxis.ScaleFormatEvent, AddressOf ScaleFormatHandler
        AddHandler MainGraph.GraphPane.YAxis.ScaleTitleEvent, AddressOf ScaleTitleHandler
        MainGraph.GraphPane.AddCurve("Download", DownloadPoints, Color.Red, ZedGraph.SymbolType.None)
        MainGraph.GraphPane.AddCurve("Upload", UploadPoints, Color.Green, ZedGraph.SymbolType.None)
        'MainGraph.AxisChange()
        SampleTimer.Enabled = True
    End Sub

    Private Function ScaleFormatHandler(ByVal pane As ZedGraph.GraphPane, ByVal axis As ZedGraph.Axis, ByVal val As Double, ByVal index As Integer) As String
        If Not InBits Then
            val /= 8
        End If
        If KiloIs1024 Then
            If axis.Scale.MajorStep >= 1024 * 1024 * 1024 Then
                val /= 1024 * 1024 * 1024
            ElseIf axis.Scale.MajorStep >= 1024 * 1024 Then
                val /= 1024 * 1024
            ElseIf axis.Scale.MajorStep >= 1024 Then
                val /= 1024
            End If
        Else
            If axis.Scale.MajorStep >= 100000000 Then
                val /= 1000000000
            ElseIf axis.Scale.MajorStep >= 100000 Then
                val /= 1000000
            ElseIf axis.Scale.MajorStep >= 100 Then
                val /= 1000
            End If
        End If
        Return val.ToString
    End Function

    Public Function ScaleTitleHandler(ByVal axis As ZedGraph.Axis) As String
        If KiloIs1024 Then
            If axis.Scale.MajorStep >= 1024 * 1024 * 1024 Then
                ScaleTitleHandler = "Ti"
            ElseIf axis.Scale.MajorStep >= 1024 * 1024 Then
                ScaleTitleHandler = "Mi"
            ElseIf axis.Scale.MajorStep >= 1024 Then
                ScaleTitleHandler = "ki"
            Else
                ScaleTitleHandler = ""
            End If
        Else
            If axis.Scale.MajorStep >= 100000000 Then
                ScaleTitleHandler = "T"
            ElseIf axis.Scale.MajorStep >= 100000 Then
                ScaleTitleHandler = "M"
            ElseIf axis.Scale.MajorStep >= 100 Then
                ScaleTitleHandler = "k"
            Else
                ScaleTitleHandler = ""
            End If
        End If
        If Not InBits Then
            ScaleTitleHandler &= "B/s"
        Else
            ScaleTitleHandler &= "b/s"
        End If

    End Function

    Dim current_sample As Integer = 0

    Private Sub SampleTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleTimer.Tick
        Dim new_time As DateTime = Now
        If (new_time > old_time) Then
            Dim new_dl_sample As Long = 0
            For Each current_counter As PerformanceCounter In dl_counters
                new_dl_sample += current_counter.NextSample.RawValue
            Next
            DownloadPoints.Add(current_sample, CDbl((new_dl_sample - old_dl_sample) * 8) / (new_time - old_time).TotalSeconds)
            old_dl_sample = new_dl_sample

            Dim new_ul_sample As Long = 0
            For Each current_counter As PerformanceCounter In ul_counters
                new_ul_sample += current_counter.NextSample.RawValue
            Next
            UploadPoints.Add(current_sample, CDbl((new_ul_sample - old_ul_sample) * 8) / (new_time - old_time).TotalSeconds)
            old_ul_sample = new_ul_sample

            old_time = new_time
        End If
        ReDraw()
        current_sample += 1
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

    Private Function CalcBoundedStepSize(ByVal range As Double, ByVal maxSteps As Double) As Double
        Dim tempStep As Double = range / maxSteps
        If tempStep <> 0 Then
            If Not InBits Then tempStep /= 8 'take out 8 before doing the work

            Dim mag As Double
            Dim magPow As Double
            If KiloIs1024 Then
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

            If Not InBits Then magMsd *= 8 'put 8 back in
            Return magMsd * magPow
        End If
        Return 0
    End Function

    Private DestinationMaxY As Double

    Private Function RecomputeMaxY() As Double
        RecomputeMaxY = 0
        If DownloadPoints.Count > 0 Then
            For i As Integer = DownloadPoints.Count - 1 To Math.Max(0, DownloadPoints.Count - 1 - CInt(MainGraph.GraphPane.XAxis.Scale.Max - MainGraph.GraphPane.XAxis.Scale.Min)) Step -1
                RecomputeMaxY = Math.Max(RecomputeMaxY, DownloadPoints(i).Y)
                RecomputeMaxY = Math.Max(RecomputeMaxY, UploadPoints(i).Y)
            Next
        End If
    End Function

    Private Sub ReDraw()
        If Me.WindowState <> FormWindowState.Minimized Then
            MainGraph.GraphPane.XAxis.Scale.Max = current_sample
            MainGraph.GraphPane.XAxis.Scale.Min = current_sample - MainGraph.GraphPane.Chart.Rect.Width / 2
        Else
            MainGraph.GraphPane.XAxis.Scale.Min += current_sample - MainGraph.GraphPane.XAxis.Scale.Max
            MainGraph.GraphPane.XAxis.Scale.Max = current_sample
        End If

        If SmoothScalingTimer.Enabled = False Then
            DestinationMaxY = RecomputeMaxY()
        End If
        Dim BigMove As Double = 0.1 * DestinationMaxY + 0.9 * MainGraph.GraphPane.YAxis.Scale.Max

        If Math.Abs(MainGraph.GraphPane.YAxis.Scale.Max - BigMove) > 5 Then
            MainGraph.GraphPane.YAxis.Scale.Max = BigMove
            SmoothScalingTimer.Enabled = True
        Else
            MainGraph.GraphPane.YAxis.Scale.Max = DestinationMaxY
            DestinationMaxY = RecomputeMaxY()
            If DestinationMaxY = MainGraph.GraphPane.YAxis.Scale.Max Then
                SmoothScalingTimer.Enabled = False
            End If
        End If

        MainGraph.GraphPane.YAxis.Scale.MajorStep = CalcBoundedStepSize(MainGraph.GraphPane.YAxis.Scale.Max - MainGraph.GraphPane.YAxis.Scale.Min, 7)
        MainGraph.AxisChange()
        MainGraph.Invalidate()
    End Sub

    Private Sub MainGraph_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGraph.Resize
        MainGraph.AxisChange() 'to force recalculation of Chart size
        ReDraw() 'now redraw, which uses the new chart size
    End Sub

    Private Sub SmoothScalingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmoothScalingTimer.Tick
        ReDraw()
    End Sub
End Class
