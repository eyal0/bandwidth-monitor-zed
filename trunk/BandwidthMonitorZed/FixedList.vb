Public Class FixedList(Of T)
    Inherits List(Of T)
    Dim capacity_ As Integer

    Sub New(ByVal capacity As Integer)
        MyBase.New(capacity)
        capacity_ = capacity
    End Sub

    Overloads Sub Add(ByVal item As T)
        If capacity_ > 0 Then 'otherwise we can't store anything!
            If MyBase.Count - capacity_ + 1 > 0 Then
                MyBase.RemoveRange(0, MyBase.Count - capacity_ + 1)
            End If
            MyBase.Add(item)
        End If
    End Sub

    Overloads Property Capacity As Integer
        Get
            Return capacity_
        End Get
        Set(ByVal value As Integer)
            capacity_ = value
            If MyBase.Count - capacity_ > 0 Then
                MyBase.RemoveRange(0, MyBase.Count - capacity_)
            End If
            MyBase.Capacity = capacity_
        End Set
    End Property
End Class
