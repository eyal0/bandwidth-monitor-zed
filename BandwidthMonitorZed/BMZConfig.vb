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

    Public Sub SaveToRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.CreateSubKey("BandwidthMonitorZed")
        BMZ.SetValue("DisplayInBytes", DisplayInBytes_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("KiloIs1024", KiloIs1024_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("ShowBars", ShowBars_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("YAxisStyle", YAxisStyle_, Microsoft.Win32.RegistryValueKind.DWord)
        BMZ.SetValue("XAxisStyle", XAxisStyle_, Microsoft.Win32.RegistryValueKind.DWord)
    End Sub

    Public Sub LoadFromRegistry()
        Dim Software As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software", True)
        Dim BMZ As Microsoft.Win32.RegistryKey = Software.OpenSubKey("BandwidthMonitorZed")
        If BMZ IsNot Nothing Then
            DisplayInBytes = CBool(BMZ.GetValue("DisplayInBytes", False))
            KiloIs1024 = CBool(BMZ.GetValue("KiloIs1024", False))
            ShowBars = CBool(BMZ.GetValue("ShowBars", False))
            YAxisStyle = CType(BMZ.GetValue("YAxisStyle", DisplayYAxisStyle.Scale), DisplayYAxisStyle)
            XAxisStyle = CType(BMZ.GetValue("XAxisStyle", DisplayXAxisStyle.None), DisplayXAxisStyle)
        End If
    End Sub
End Class
