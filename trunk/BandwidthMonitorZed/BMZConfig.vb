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

    Public Enum DisplayYAxisType
        None
        Max
        Scale
    End Enum

    Private YAxisStyle_ As DisplayYAxisType = DisplayYAxisType.Scale
    Property YAxisStyle() As DisplayYAxisType
        Get
            Return YAxisStyle_
        End Get
        Set(ByVal value As DisplayYAxisType)
            If value <> YAxisStyle_ Then
                YAxisStyle_ = value
                RaiseEvent YAxisStyleChanged(Me, New System.EventArgs)
            End If
        End Set
    End Property
    Event YAxisStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
End Class
