﻿Public Class BMZPointPairList
    Implements ZedGraph.IPointList, ZedGraph.IPointListEdit

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

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim ret As BMZPointPairList = New BMZPointPairList(0)
        ret.rppl = Me.rppl.Clone()
        Return ret
    End Function

    Public ReadOnly Property Count As Integer Implements ZedGraph.IPointListEdit.Count
        Get
            If UseBars_ Then
                Return Math.Max(0, rppl.Count * 2 - 1)
            Else
                Return rppl.Count
            End If
        End Get
    End Property

    Default Property Item(ByVal index As Integer) As ZedGraph.PointPair Implements ZedGraph.IPointListEdit.Item
        Get
            If UseBars_ Then
                If index Mod 2 = 1 Then
                    Dim new_pp As ZedGraph.PointPair = rppl((index + 1) \ 2).Clone()
                    new_pp.X = rppl.Item((index - 1) \ 2).X
                    Return new_pp
                Else
                    Return rppl(index \ 2)
                End If
            Else
                Return rppl(index)
            End If
        End Get
        Set(ByVal value As ZedGraph.PointPair)
            If UseBars_ Then
                If index Mod 2 = 1 Then
                    rppl((index - 1) \ 2).X = value.X
                    value.X = rppl((index + 1) \ 2).X
                    rppl((index + 1) \ 2) = value
                Else
                    rppl(index \ 2) = value
                End If
            End If
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
            If UseBars_ Then
                If index Mod 2 = 1 Then
                    Dim new_pp As ZedGraph.PointPair = rppl((index - 1) \ 2).Clone()
                    new_pp.X = rppl.Item((index + 1) \ 2).X
                    Return new_pp
                Else
                    Return rppl(index \ 2)
                End If
            Else
                Return rppl(index).Clone()
            End If
        End Get
    End Property
End Class