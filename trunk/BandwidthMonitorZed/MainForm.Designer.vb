<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits BandwidthMonitorZed.SnapForm

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
        Me.components = New System.ComponentModel.Container()
        Me.SampleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SmoothScalingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainGraph = New ZedGraph.ZedGraphControl()
        Me.SuspendLayout()
        '
        'SampleTimer
        '
        Me.SampleTimer.Interval = 5000
        '
        'SmoothScalingTimer
        '
        Me.SmoothScalingTimer.Interval = 25
        '
        'MainGraph
        '
        Me.MainGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGraph.IsEnableHPan = False
        Me.MainGraph.IsEnableHZoom = False
        Me.MainGraph.IsEnableVPan = False
        Me.MainGraph.IsEnableVZoom = False
        Me.MainGraph.IsEnableWheelZoom = False
        Me.MainGraph.IsShowContextMenu = False
        Me.MainGraph.IsShowCopyMessage = False
        Me.MainGraph.Location = New System.Drawing.Point(0, 0)
        Me.MainGraph.Name = "MainGraph"
        Me.MainGraph.ScrollGrace = 0.0R
        Me.MainGraph.ScrollMaxX = 0.0R
        Me.MainGraph.ScrollMaxY = 0.0R
        Me.MainGraph.ScrollMaxY2 = 0.0R
        Me.MainGraph.ScrollMinX = 0.0R
        Me.MainGraph.ScrollMinY = 0.0R
        Me.MainGraph.ScrollMinY2 = 0.0R
        Me.MainGraph.Size = New System.Drawing.Size(284, 262)
        Me.MainGraph.TabIndex = 0
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.MainGraph)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bandwidth Monitor Zed"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SampleTimer As System.Windows.Forms.Timer
    Friend WithEvents MainGraph As ZedGraph.ZedGraphControl
    Friend WithEvents SmoothScalingTimer As System.Windows.Forms.Timer
End Class
