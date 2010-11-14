Public Class BMZPointPairList
    Implements ZedGraph.IPointListEdit
    Dim rppl As ZedGraph.RollingPointPairList

    Sub New(ByVal capactiy As Integer)
        rppl = New ZedGraph.RollingPointPairList(capactiy)
    End Sub

    Sub New(ByVal rhs As ZedGraph.IPointList)
        rppl = New ZedGraph.RollingPointPairList(rhs)
    End Sub

    Sub New(ByVal capacity As Integer, ByVal preLoad As Boolean)
        rppl = New ZedGraph.RollingPointPairList(capacity, preLoad)
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

    Public Property Capacity As Integer
        Get
            Return rppl.Capacity
        End Get
        Set(ByVal value As Integer)
            Dim new_rppl As New ZedGraph.RollingPointPairList(value)
            For i As Integer = 0 To rppl.Count - 1
                new_rppl.Add(rppl(i))
            Next
            rppl = new_rppl
        End Set
    End Property

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim ret As BMZPointPairList = New BMZPointPairList(0)
        ret.rppl = Me.rppl.Clone()
        Return ret
    End Function

    Public ReadOnly Property Count As Integer Implements ZedGraph.IPointListEdit.Count
        Get
            If UseBars_ Then
                Return Math.Max(0, rppl.Count * 2 - 2)
            Else
                Return rppl.Count
            End If
        End Get
    End Property

    Default Property Item(ByVal index As Integer) As ZedGraph.PointPair Implements ZedGraph.IPointListEdit.Item
        Get
            Dim ret As ZedGraph.PointPair
            If UseBars_ Then
                If index Mod 2 = 1 Then
                    ret = rppl((index + 1) \ 2).Clone()
                Else
                    ret = rppl((index + 2) \ 2).Clone()
                    ret.X = rppl(index \ 2).X
                End If
            Else
                ret = rppl(index).Clone()
            End If
            If RelativeTime_ Then
                ret.X = (ret.X - rppl(rppl.Count - 1).X) * ZedGraph.XDate.MillisecondsPerDay
                'Dim temp_xdate As New ZedGraph.XDate(ret.X)
                'temp_xdate -= rppl(rppl.Count - 1).X
                'temp_xdate()
                'ret.X = (ZedGraph.XDate.XLDateToDateTime(ret.X) - ZedGraph.XDate.XLDateToDateTime(rppl(rppl.Count - 1).X)).TotalMilliseconds
            End If
            Return ret
        End Get
        Set(ByVal value As ZedGraph.PointPair)
            Throw New ApplicationException("Can't set BMZ points")
        End Set
    End Property

    Public Sub Add(ByVal x As Double, ByVal y As Double) Implements ZedGraph.IPointListEdit.Add
        rppl.Add(x, y)
    End Sub

    Public Sub Add(ByVal point As ZedGraph.PointPair) Implements ZedGraph.IPointListEdit.Add
        rppl.Add(point)
    End Sub

    Public Sub Clear() Implements ZedGraph.IPointListEdit.Clear
        rppl.Clear()
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) Implements ZedGraph.IPointListEdit.RemoveAt
        rppl.RemoveAt(index)
    End Sub

    Public ReadOnly Property Item1(ByVal index As Integer) As ZedGraph.PointPair Implements ZedGraph.IPointList.Item
        Get
            Return Item(index)
        End Get
    End Property
End Class