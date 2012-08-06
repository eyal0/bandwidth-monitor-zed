Public Class BMZConfig
#Region "DisplayInBytes"
    Private DisplayInBytes_ As Boolean = False
    Event DisplayInBytesChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property DisplayInBytes As Boolean
        Get
            Return DisplayInBytes_
        End Get
        Set(ByVal value As Boolean)
            If DisplayInBytes_ <> value Then
                DisplayInBytes_ = value
                RaiseEvent DisplayInBytesChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "KiloIs1024"
    Private KiloIs1024_ As Boolean = False
    Event KiloIs1024Changed(ByVal sender As Object, ByVal e As System.EventArgs)
    Property KiloIs1024 As Boolean
        Get
            Return KiloIs1024_
        End Get
        Set(ByVal value As Boolean)
            If KiloIs1024_ <> value Then
                KiloIs1024_ = value
                RaiseEvent KiloIs1024Changed(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "ShowBars"
    Private ShowBars_ As Boolean
    Event ShowBarsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property ShowBars As Boolean
        Get
            Return ShowBars_
        End Get
        Set(ByVal value As Boolean)
            If ShowBars_ <> value Then
                ShowBars_ = value
                RaiseEvent ShowBarsChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "AlwaysOnTop"
    Private AlwaysOnTop_ As Boolean
    Event AlwaysOnTopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property AlwaysOnTop As Boolean
        Get
            Return AlwaysOnTop_
        End Get
        Set(ByVal value As Boolean)
            If AlwaysOnTop_ <> value Then
                AlwaysOnTop_ = value
                RaiseEvent AlwaysOnTopChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "Opacity"
    Private Opacity_ As Integer
    Event OpacityChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property Opacity As Integer
        Get
            Return Opacity_
        End Get
        Set(ByVal value As Integer)
            If Opacity_ <> value Then
                Opacity_ = value
                RaiseEvent OpacityChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "YAxisStyle"
    Public Enum DisplayYAxisStyle
        None
        Max
        Scale
    End Enum

    Private YAxisStyle_ As DisplayYAxisStyle = DisplayYAxisStyle.Scale
    Event YAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property YAxisStyle() As DisplayYAxisStyle
        Get
            Return YAxisStyle_
        End Get
        Set(ByVal value As DisplayYAxisStyle)
            If value <> YAxisStyle_ Then
                YAxisStyle_ = value
                RaiseEvent YAxisStyleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "XAxisStyle"
    Public Enum DisplayXAxisStyle
        None
        Time
        Relative
    End Enum
    Private XAxisStyle_ As DisplayXAxisStyle
    Event XAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property XAxisStyle As DisplayXAxisStyle
        Get
            Return XAxisStyle_
        End Get
        Set(ByVal value As DisplayXAxisStyle)
            If value <> XAxisStyle_ Then
                XAxisStyle_ = value
                RaiseEvent XAxisStyleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "SamplePeriodMilliseconds"
    Private SamplePeriodMilliseconds_ As Integer
    Event SamplePeriodMillisecondsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property SamplePeriodMilliseconds As Integer
        Get
            Return SamplePeriodMilliseconds_
        End Get
        Set(ByVal value As Integer)
            If SamplePeriodMilliseconds_ <> value Then
                SamplePeriodMilliseconds_ = value
                RaiseEvent SamplePeriodMillisecondsChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "SampleWidthPixels"
    Private SampleWidthPixels_ As Double
    Event SampleWidthPixelsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property SampleWidthPixels As Double
        Get
            Return SampleWidthPixels_
        End Get
        Set(ByVal value As Double)
            If SampleWidthPixels_ <> value Then
                SampleWidthPixels_ = value
                RaiseEvent SampleWidthPixelsChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "SampleCount"
    Private SampleCount_ As Integer
    Event SampleCountChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property SampleCount As Integer
        Get
            Return SampleCount_
        End Get
        Set(ByVal value As Integer)
            If SampleCount_ <> value Then
                SampleCount_ = value
                RaiseEvent SampleCountChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "RunAtStartup"
    Private RunAtStartup_ As Boolean
    Event RunAtStartupChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property RunAtStartup As Boolean
        Get
            Return RunAtStartup_
        End Get
        Set(ByVal value As Boolean)
            If RunAtStartup_ <> value Then
                RunAtStartup_ = value
                RaiseEvent RunAtStartupChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartMinimized"
    Private StartMinimized_ As Boolean
    Event StartMinimizedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Property StartMinimized As Boolean
        Get
            Return StartMinimized_
        End Get
        Set(ByVal value As Boolean)
            If StartMinimized_ <> value Then
                StartMinimized_ = value
                RaiseEvent StartMinimizedChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartRectangle"
    Private StartRectangle_ As Rectangle
    Event DisplayRectangleChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#Region "StartX"
    Property StartX As Integer
        Get
            Return StartRectangle_.X
        End Get
        Set(ByVal value As Integer)
            If StartRectangle_.X <> value Then
                StartRectangle_.X = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartX", StartX, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartY"
    Property StartY As Integer
        Get
            Return StartRectangle_.Y
        End Get
        Set(ByVal value As Integer)
            If StartRectangle_.Y <> value Then
                StartRectangle_.Y = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartY", StartY, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartWidth"
    Property StartWidth As Integer
        Get
            Return StartRectangle_.Width
        End Get
        Set(ByVal value As Integer)
            If StartRectangle_.Width <> value Then
                StartRectangle_.Width = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartWidth", StartWidth, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartHeight"
    Property StartHeight As Integer
        Get
            Return StartRectangle_.Height
        End Get
        Set(ByVal value As Integer)
            If StartRectangle_.Height <> value Then
                StartRectangle_.Height = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartHeight", StartHeight, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartRectangle"
    Property StartRectangle As Rectangle
        Get
            Return StartRectangle_
        End Get
        Set(ByVal value As Rectangle)
            If StartRectangle_ <> value Then
                StartRectangle_ = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartX", StartX, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.SetValue("StartY", StartY, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.SetValue("StartWidth", StartWidth, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.SetValue("StartHeight", StartHeight, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartLocation"
    Property StartLocation As Point
        Get
            Return StartRectangle_.Location
        End Get
        Set(ByVal value As Point)
            If StartRectangle_.Location <> value Then
                StartRectangle_.Location = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartX", StartX, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.SetValue("StartY", StartY, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region

#Region "StartSize"
    Property StartSize As Size
        Get
            Return StartRectangle_.Size
        End Get
        Set(ByVal value As Size)
            If StartRectangle_.Size <> value Then
                StartRectangle_.Size = value
                'write location and size immediately
                Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
                Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
                BMZ.SetValue("StartWidth", StartWidth, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.SetValue("StartHeight", StartHeight, Microsoft.Win32.RegistryValueKind.DWord)
                BMZ.Close()
                Software.Close()
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
#End Region
#End Region

#Region "Registry"
    Private Const BMZ_REGISTRY_KEY As String = "Bandwidth Monitor Zed"
    Public Sub SaveToRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
        BMZ.SetValue("DisplayInBytes", DisplayInBytes_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("KiloIs1024", KiloIs1024_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("ShowBars", ShowBars_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("YAxisStyle", YAxisStyle_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("XAxisStyle", XAxisStyle_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("SamplePeriodMilliseconds", SamplePeriodMilliseconds_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("SampleWidthPixels", BitConverter.DoubleToInt64Bits(SampleWidthPixels_), Microsoft.Win32.RegistryValueKind.QWord)
        BMZ.SetValue("SampleCount", SampleCount_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("StartMinimized", StartMinimized_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("AlwaysOnTop", AlwaysOnTop_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("Opacity", Opacity_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.Close()
        Software.Close()
        Dim Run As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        If RunAtStartup_ Then
            Run.SetValue(BMZ_REGISTRY_KEY, Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String)
        ElseIf Run.GetValue(BMZ_REGISTRY_KEY) IsNot Nothing Then
            Run.DeleteValue(BMZ_REGISTRY_KEY)
        End If
        Run.Close()
    End Sub

    Public Sub LoadFromRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
        DisplayInBytes = CBool(BMZ.GetValue("DisplayInBytes", False))
        KiloIs1024 = CBool(BMZ.GetValue("KiloIs1024", False))
        ShowBars = CBool(BMZ.GetValue("ShowBars", False))
        YAxisStyle = CType(BMZ.GetValue("YAxisStyle", DisplayYAxisStyle.Scale), DisplayYAxisStyle)
        XAxisStyle = CType(BMZ.GetValue("XAxisStyle", DisplayXAxisStyle.None), DisplayXAxisStyle)
        SamplePeriodMilliseconds = CInt(BMZ.GetValue("SamplePeriodMilliseconds", 1000))
        SampleWidthPixels = BitConverter.Int64BitsToDouble(CLng(BMZ.GetValue("SampleWidthPixels", BitConverter.DoubleToInt64Bits(2))))
        SampleCount = CInt(BMZ.GetValue("SampleCount", 2000))
        StartMinimized = CBool(BMZ.GetValue("StartMinimized", False))
        AlwaysOnTop = CBool(BMZ.GetValue("AlwaysOnTop", False))
        Opacity = CInt(BMZ.GetValue("Opacity", 255))
        StartRectangle_.X = CInt(BMZ.GetValue("StartX", -1))
        StartRectangle_.Y = CInt(BMZ.GetValue("StartY", -1))
        StartRectangle_.Width = CInt(BMZ.GetValue("StartWidth", -1))
        StartRectangle_.Height = CInt(BMZ.GetValue("StartHeight", -1))
        BMZ.Close()
        Dim Run As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        RunAtStartup_ = Run.GetValue(BMZ_REGISTRY_KEY) IsNot Nothing
        Run.Close()
        Software.Close()
    End Sub
#End Region
End Class
