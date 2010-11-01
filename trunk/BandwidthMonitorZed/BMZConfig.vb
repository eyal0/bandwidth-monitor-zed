Public Class BMZConfig
    Private DisplayInBytes_ As Boolean = False
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
    Event DisplayInBytesChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private KiloIs1024_ As Boolean = False
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
    Event KiloIs1024Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    Private ShowBars_ As Boolean = False
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
    Event ShowBarsChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Enum DisplayYAxisStyle
        None
        Max
        Scale
    End Enum

    Private YAxisStyle_ As DisplayYAxisStyle = DisplayYAxisStyle.Scale
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
    Event YAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Enum DisplayXAxisStyle
        None
        Time
        Relative
    End Enum
    Private XAxisStyle_ As DisplayXAxisStyle = DisplayXAxisStyle.None
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
    Event XAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private SamplePeriodMilliseconds_ As Integer
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
    Event SamplePeriodMillisecondsChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private SampleWidthPixels_ As Double
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
    Event SampleWidthPixelsChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private DisplayRectangle_ As Rectangle
    Property X As Integer
        Get
            Return DisplayRectangle_.Top
        End Get
        Set(ByVal value As Integer)
            If DisplayRectangle_.Top <> value Then
                DisplayRectangle_.X = value
                RaiseEvent DisplayRectangleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
    Event DisplayRectangleChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Const BMZ_REGISTRY_KEY As String = "Bandwidth Monitor Zed"
    Public Sub SaveToRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey(BMZ_REGISTRY_KEY)
        BMZ.SetValue("DisplayInBytes", DisplayInBytes, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("KiloIs1024", KiloIs1024, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("ShowBars", ShowBars, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("YAxisStyle", YAxisStyle, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("XAxisStyle", XAxisStyle, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("SamplePeriodMilliseconds", SamplePeriodMilliseconds, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("SampleWidthPixels", BitConverter.DoubleToInt64Bits(SampleWidthPixels), Microsoft.Win32.RegistryValueKind.QWord)
    End Sub

    Public Sub LoadFromRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.OpenSubKey(BMZ_REGISTRY_KEY)
        If BMZ IsNot Nothing Then
            DisplayInBytes = CBool(BMZ.GetValue("DisplayInBytes", False))
            KiloIs1024 = CBool(BMZ.GetValue("KiloIs1024", False))
            ShowBars = CBool(BMZ.GetValue("ShowBars", False))
            YAxisStyle = CType(BMZ.GetValue("YAxisStyle", DisplayYAxisStyle.Scale), DisplayYAxisStyle)
            XAxisStyle = CType(BMZ.GetValue("XAxisStyle", DisplayXAxisStyle.None), DisplayXAxisStyle)
            SamplePeriodMilliseconds = CInt(BMZ.GetValue("SamplePeriodMilliseconds", 1000))
            SampleWidthPixels = BitConverter.Int64BitsToDouble(CLng(BMZ.GetValue("SampleWidthPixels", BitConverter.Int64BitsToDouble(2))))
        End If
    End Sub
End Class
