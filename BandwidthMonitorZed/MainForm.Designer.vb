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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SampleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SmoothScalingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainGraph = New ZedGraph.ZedGraphControl()
        Me.BMZIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BMZContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BMZContextMenu.SuspendLayout()
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
        'BMZIcon
        '
        Me.BMZIcon.ContextMenuStrip = Me.BMZContextMenu
        Me.BMZIcon.Icon = CType(resources.GetObject("BMZIcon.Icon"), System.Drawing.Icon)
        Me.BMZIcon.Text = "Bandwidth Monitor Zed"
        Me.BMZIcon.Visible = True
        '
        'BMZContextMenu
        '
        Me.BMZContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.BMZContextMenu.Name = "BMZContextMenu"
        Me.BMZContextMenu.Size = New System.Drawing.Size(153, 76)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.MainGraph)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bandwidth Monitor Zed"
        Me.BMZContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SampleTimer As System.Windows.Forms.Timer
    Friend WithEvents MainGraph As ZedGraph.ZedGraphControl
    Friend WithEvents SmoothScalingTimer As System.Windows.Forms.Timer
    Friend WithEvents BMZIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents BMZContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
