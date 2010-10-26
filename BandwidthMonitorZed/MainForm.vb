Public Class MainForm
    Dim DownloadPoints As New ZedGraph.RollingPointPairList(2000)
    Dim UploadPoints As New ZedGraph.RollingPointPairList(2000)
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
        MainGraph.GraphPane.YAxis.Scale.MaxAuto = True
        MainGraph.GraphPane.YAxis.Scale.MaxGrace = 0
        MainGraph.GraphPane.YAxis.Scale.MinAuto = False
        MainGraph.GraphPane.YAxis.Title.IsOmitMag = False

        'MainGraph.GraphPane.YAxis.Title.Gap = 0
        'MainGraph.GraphPane.YAxis.Title.Text = "kb/s"
        'MainGraph.GraphPane.YAxis.Scale.MinAuto = False
        'MainGraph.GraphPane.YAxis.Scale.MaxGrace = 0
        'MainGraph.GraphPane.YAxis.Scale.MajorStepAuto = True
        'MainGraph.GraphPane.YAxis.Scale.MagAuto = False
        'MainGraph.GraphPane.YAxis.Scale.LabelGap = 0
        'MainGraph.GraphPane.YAxis.Scale.FormatAuto = True
        'MainGraph.GraphPane.YAxis.Scale.FontSpec.IsBold = True

        MainGraph.GraphPane.Title.IsVisible = False
        MainGraph.GraphPane.Legend.IsVisible = False
        MainGraph.GraphPane.Margin.All = 0
        MainGraph.GraphPane.Chart.Border.IsVisible = False

        MainGraph.GraphPane.AddCurve("Download", DownloadPoints, Color.Red, ZedGraph.SymbolType.None)
        MainGraph.GraphPane.AddCurve("Upload", UploadPoints, Color.Green, ZedGraph.SymbolType.None)
        MainGraph.AxisChange()
        SampleTimer.Enabled = True
    End Sub

    Dim current_sample As Integer = 0

    Private Sub SampleTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleTimer.Tick
        Dim new_dl_sample As Long = 0
        For Each current_counter As PerformanceCounter In dl_counters
            new_dl_sample += current_counter.NextSample.RawValue
        Next
        Dim new_ul_sample As Long = 0
        For Each current_counter As PerformanceCounter In ul_counters
            new_ul_sample += current_counter.NextSample.RawValue
        Next
        Dim new_time As DateTime = Now

        DownloadPoints.Add(current_sample, CDbl((new_dl_sample - old_dl_sample) * 8) / (new_time - old_time).TotalSeconds)
        UploadPoints.Add(current_sample, CDbl((new_ul_sample - old_ul_sample) * 8) / (new_time - old_time).TotalSeconds)
        old_dl_sample = new_dl_sample
        old_ul_sample = new_ul_sample
        old_time = new_time
        MainGraph.GraphPane.XAxis.Scale.Max = current_sample
        MainGraph.GraphPane.XAxis.Scale.Min = MainGraph.GraphPane.XAxis.Scale.Max - MainGraph.GraphPane.Chart.Rect.Width
        MainGraph.GraphPane.YAxis.Scale.LabelGap = 0
        MainGraph.GraphPane.YAxis.Scale.Exponent = 2

        Select Case MainGraph.GraphPane.YAxis.Scale.Mag
            Case 0
                MainGraph.GraphPane.YAxis.Title.Text = "b/s"
            Case 3
                MainGraph.GraphPane.YAxis.Title.Text = "kb/s"
            Case 6
                MainGraph.GraphPane.YAxis.Title.Text = "Mb/s"
            Case 9
                MainGraph.GraphPane.YAxis.Title.Text = "Gb/s"
            Case 12
                MainGraph.GraphPane.YAxis.Title.Text = "Tb/s"
        End Select
        MainGraph.AxisChange()
        MainGraph.Invalidate()
        current_sample += 1
    End Sub
End Class
