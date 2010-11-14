Public Class BMZPointPairList(Of TSource)
    Implements ZedGraph.IPointList
    Dim Fifo_ As IList(Of TSource)
    Dim AccessX_ As Func(Of TSource, Double)
    Dim AccessY_ As Func(Of TSource, Double)

    Sub New(ByVal Fifo As IList(Of TSource), ByVal AccessX As Func(Of TSource, Double), ByVal AccessY As Func(Of TSource, Double))
        Fifo_ = Fifo
        AccessX_ = AccessX
        AccessY_ = AccessY
    End Sub

    Private UseBars_ As Boolean
    Public Property UseBars As Boolean
        Get
            Return UseBars_
        End Get
        Set(ByVal value As Boolean)
            UseBars_ = value
        End Set
    End Property

    Private Property RelativeTime_ As Boolean = False
    Public Property RelativeTime As Boolean
        Get
            Return RelativeTime_
        End Get
        Set(ByVal value As Boolean)
            RelativeTime_ = value
        End Set
    End Property

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return New BMZPointPairList(Of TSource)(Me.Fifo_, Me.AccessX_, Me.AccessY_)
    End Function

    Public ReadOnly Property Count As Integer Implements ZedGraph.IPointList.Count
        Get
            If UseBars_ Then
                Return Math.Max(0, Fifo_.Count * 2 - 2)
            Else
                Return Fifo_.Count
            End If
        End Get
    End Property

    Default ReadOnly Property Item(ByVal index As Integer) As ZedGraph.PointPair Implements ZedGraph.IPointList.Item
        Get
            Dim ret As ZedGraph.PointPair
            Dim x_item, y_item As TSource
            If UseBars_ Then
                If index Mod 2 = 1 Then
                    x_item = Fifo_((index + 1) \ 2)
                    y_item = x_item
                    Dim current_item As TSource = Fifo_((index + 1) \ 2)
                Else
                    x_item = Fifo_(index \ 2)
                    y_item = Fifo_((index + 2) \ 2)
                End If
            Else
                x_item = Fifo_(index)
                y_item = x_item
            End If
            ret = New ZedGraph.PointPair(AccessX_(x_item), AccessY_(y_item))
            If RelativeTime_ Then
                ret.X = (ret.X - AccessX_(Fifo_(Fifo_.Count - 1))) * ZedGraph.XDate.MillisecondsPerDay
            End If
            Return ret
        End Get
    End Property
End Class