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
        If radYAxisMax.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.Max
        If radYAxisNone.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.None
        If radYAxisScale.Checked Then config.YAxisStyle = BMZConfig.DisplayYAxisStyle.Scale
        If radXAxisNone.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.None
        If radXAxisTime.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Time
        If radXAxisRelative.Checked Then config.XAxisStyle = BMZConfig.DisplayXAxisStyle.Relative
        config.SaveToRegistry()
    End Sub

    Private Sub LoadFromConfig()
        chkDisplayInBytes.Checked = config.DisplayInBytes
        chkKiloIs1024.Checked = config.KiloIs1024
        chkShowBars.Checked = config.ShowBars
        Select Case config.YAxisStyle
            Case BMZConfig.DisplayYAxisStyle.Max
                radYAxisMax.Checked = True
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
    End Sub
End Class