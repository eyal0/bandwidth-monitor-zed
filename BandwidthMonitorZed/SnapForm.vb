Public Class SnapForm
    Inherits Form

    Public Property SnapOffset As Integer = 25
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46
    Private Const WM_MOVING As Integer = &H216
    Private Const WM_ENTERSIZEMOVE As Integer = &H231
    Private Const WM_EXITSIZEMOVE As Integer = &H232

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Public Structure RECT
        Private _Left As Integer, _Top As Integer, _Right As Integer, _Bottom As Integer

        Public Sub New(ByVal Rectangle As Rectangle)
            Me.New(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
        End Sub
        Public Sub New(ByVal Left As Integer, ByVal Top As Integer, ByVal Right As Integer, ByVal Bottom As Integer)
            _Left = Left
            _Top = Top
            _Right = Right
            _Bottom = Bottom
        End Sub

        Public Property X As Integer
            Get
                Return _Left
            End Get
            Set(ByVal value As Integer)
                _Left = value
            End Set
        End Property
        Public Property Y As Integer
            Get
                Return _Top
            End Get
            Set(ByVal value As Integer)
                _Top = value
            End Set
        End Property
        Public Property Left As Integer
            Get
                Return _Left
            End Get
            Set(ByVal value As Integer)
                _Left = value
            End Set
        End Property
        Public Property Top As Integer
            Get
                Return _Top
            End Get
            Set(ByVal value As Integer)
                _Top = value
            End Set
        End Property
        Public Property Right As Integer
            Get
                Return _Right
            End Get
            Set(ByVal value As Integer)
                _Right = value
            End Set
        End Property
        Public Property Bottom As Integer
            Get
                Return _Bottom
            End Get
            Set(ByVal value As Integer)
                _Bottom = value
            End Set
        End Property
        Public Property Height() As Integer
            Get
                Return _Bottom - _Top
            End Get
            Set(ByVal value As Integer)
                _Bottom = value - _Top
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return _Right - _Left
            End Get
            Set(ByVal value As Integer)
                _Right = value + _Left
            End Set
        End Property
        Public Property Location() As Point
            Get
                Return New Point(Left, Top)
            End Get
            Set(ByVal value As Point)
                _Left = value.X
                _Top = value.Y
            End Set
        End Property
        Public Property Size() As Size
            Get
                Return New Size(Width, Height)
            End Get
            Set(ByVal value As Size)
                _Right = value.Width + _Left
                _Bottom = value.Height + _Top
            End Set
        End Property

        Public Shared Widening Operator CType(ByVal Rectangle As RECT) As Rectangle
            Return New Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height)
        End Operator
        Public Shared Widening Operator CType(ByVal Rectangle As Rectangle) As RECT
            Return New RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
        End Operator
        Public Shared Operator =(ByVal Rectangle1 As RECT, ByVal Rectangle2 As RECT) As Boolean
            Return Rectangle1.Equals(Rectangle2)
        End Operator
        Public Shared Operator <>(ByVal Rectangle1 As RECT, ByVal Rectangle2 As RECT) As Boolean
            Return Not Rectangle1.Equals(Rectangle2)
        End Operator

        Public Overrides Function ToString() As String
            Return "{Left: " & _Left & "; " & "Top: " & _Top & "; Right: " & _Right & "; Bottom: " & _Bottom & "}"
        End Function

        Public Overloads Function Equals(ByVal Rectangle As RECT) As Boolean
            Return Rectangle.Left = _Left AndAlso Rectangle.Top = _Top AndAlso Rectangle.Right = _Right AndAlso Rectangle.Bottom = _Bottom
        End Function

        Public Overloads Overrides Function Equals(ByVal [Object] As Object) As Boolean
            If TypeOf [Object] Is RECT Then
                Return Equals(DirectCast([Object], RECT))
            ElseIf TypeOf [Object] Is Rectangle Then
                Return Equals(New RECT(DirectCast([Object], Rectangle)))
            End If

            Return False
        End Function
    End Structure

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure WINDOWPOS
        Public hwnd As IntPtr
        Public hwndInsertAfter As IntPtr
        Public x As Integer
        Public y As Integer
        Public cx As Integer
        Public cy As Integer
        Public flags As Integer
        Public Sub New(ByVal Left As Integer, ByVal Top As Integer, ByVal Width As Integer, ByVal Height As Integer)
            x = Left
            y = Top
            cx = Width
            cy = Height
        End Sub
        Public Shared Narrowing Operator CType(ByVal Rectangle As WINDOWPOS) As Rectangle
            Return New Rectangle(Rectangle.x, Rectangle.y, Rectangle.cx, Rectangle.cy)
        End Operator
        Public Shared Widening Operator CType(ByVal Rectangle As Rectangle) As WINDOWPOS
            Return New WINDOWPOS(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height)
        End Operator
        Public Overrides Function ToString() As String
            Return "{hwnd: " & hwnd.ToString & "; hwndInsertAfter: " & hwndInsertAfter.ToString & "; x: " & x & "; " & "y: " & y & "; cx: " & cx & "; cy: " & cy & "; flags: " & flags & "}"
        End Function
    End Structure

    Private MouseOffset As Size

    Protected Overrides Sub WndProc(ByRef m As Message)
        'Listen for operating system messages
        Select Case m.Msg
            'Case WM_WINDOWPOSCHANGING
            '    Dim NewPosition As New WINDOWPOS
            '    NewPosition = CType(Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(WINDOWPOS)), WINDOWPOS)
            '    Dim FinalRect As Rectangle = SnapToDesktopBorder(CType(NewPosition, Rectangle))
            '    ' Marshal it back
            '    NewPosition.x = FinalRect.X
            '    NewPosition.y = FinalRect.Y
            '    NewPosition.cx = FinalRect.Width
            '    NewPosition.cy = FinalRect.Height
            '    Runtime.InteropServices.Marshal.StructureToPtr(NewPosition, m.LParam, True)
            Case WM_MOVING
                Dim FinalRect As Rectangle = SnapToDesktopBorder(New Rectangle(Cursor.Position + MouseOffset, Me.Size))
                ' Marshal it back
                Dim NewRect As New RECT(FinalRect)
                Runtime.InteropServices.Marshal.StructureToPtr(NewRect, m.LParam, True)
            Case WM_ENTERSIZEMOVE
                'remember where the mouse is so that we can play with the rectangle safely
                MouseOffset = CType(Me.Location - CType(Cursor.Position, Size), Drawing.Size)
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Function SnapToDesktopBorder(ByVal NewRect As Rectangle) As Rectangle
        Dim WorkingRect As Rectangle = Screen.GetWorkingArea(ClientRectangle)

        Dim left_distance As Integer = WorkingRect.Left - NewRect.Left 'Distance to left border
        Dim right_distance As Integer = WorkingRect.Right - NewRect.Right
        Dim top_distance As Integer = WorkingRect.Top - NewRect.Top
        Dim bottom_distance As Integer = WorkingRect.Bottom - NewRect.Bottom

        If Math.Abs(left_distance) <= Math.Abs(right_distance) AndAlso Math.Abs(left_distance) < SnapOffset Then
            NewRect.X = WorkingRect.Left
        ElseIf Math.Abs(right_distance) <= Math.Abs(left_distance) AndAlso Math.Abs(right_distance) < SnapOffset Then
            NewRect.X = WorkingRect.Right - Me.Width
        End If

        If Math.Abs(top_distance) <= Math.Abs(bottom_distance) AndAlso Math.Abs(top_distance) < SnapOffset Then
            NewRect.Y = WorkingRect.Top
        ElseIf Math.Abs(bottom_distance) <= Math.Abs(top_distance) AndAlso Math.Abs(bottom_distance) < SnapOffset Then
            NewRect.Y = WorkingRect.Bottom - Me.Height
        End If

        Return NewRect
    End Function
End Class
