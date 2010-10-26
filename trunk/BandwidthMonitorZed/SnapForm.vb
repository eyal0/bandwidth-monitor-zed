Public Class SnapForm
    Inherits Form

    Public Property SnapOffset As Integer = 35
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure WINDOWPOS
        Public hwnd As IntPtr
        Public hwndInsertAfter As IntPtr
        Public x As Integer
        Public y As Integer
        Public cx As Integer
        Public cy As Integer
        Public flags As Integer
    End Structure

    Protected Overrides Sub WndProc(ByRef m As Message)
        'Listen for operating system messages
        Select Case m.Msg
            Case WM_WINDOWPOSCHANGING
                SnapToDesktopBorder(m.LParam)
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Sub SnapToDesktopBorder(ByVal LParam As IntPtr)
        ' Snap client to the top, left, bottom or right desktop border
        ' as the form is moved near that border.
        Try
            Dim NewPosition As New WINDOWPOS
            NewPosition = CType(Runtime.InteropServices.Marshal.PtrToStructure(LParam, GetType(WINDOWPOS)), WINDOWPOS)

            If NewPosition.y = 0 OrElse NewPosition.x = 0 Then
                Return ' Nothing to do!
            End If

            ' Adjust the client size for borders and caption bar

            Dim ClientRect As New Rectangle(Me.Location, Me.Size)
            'Select Case Me.FormBorderStyle
            '    Case Windows.Forms.FormBorderStyle.Fixed3D, Windows.Forms.FormBorderStyle.FixedDialog, Windows.Forms.FormBorderStyle.FixedSingle, Windows.Forms.FormBorderStyle.FixedToolWindow
            '        ClientRect.Width += SystemInformation.FixedFrameBorderSize.Width
            '        ClientRect.Height += SystemInformation.FixedFrameBorderSize.Height

            '    Case Windows.Forms.FormBorderStyle.Sizable, Windows.Forms.FormBorderStyle.SizableToolWindow
            '        ClientRect.Width += SystemInformation.FrameBorderSize.Width
            '        ClientRect.Height += SystemInformation.FrameBorderSize.Height
            'End Select
            'Select Case Me.FormBorderStyle
            '    Case Windows.Forms.FormBorderStyle.FixedToolWindow, Windows.Forms.FormBorderStyle.SizableToolWindow
            '        ClientRect.Height += SystemInformation.ToolWindowCaptionHeight
            '    Case Else
            '        ClientRect.Height += SystemInformation.CaptionHeight
            'End Select

            ' Now get the screen working area (without taskbar)

            Dim WorkingRect As Rectangle = Screen.GetWorkingArea(ClientRectangle)

            ' Left border
            If NewPosition.x >= WorkingRect.X - SnapOffset AndAlso NewPosition.x <= WorkingRect.X + SnapOffset Then
                NewPosition.x = WorkingRect.X
            End If

            ' Top border
            If NewPosition.y >= WorkingRect.Y - SnapOffset AndAlso newposition.y <= WorkingRect.y + SnapOffset Then
                NewPosition.y = WorkingRect.Y
            End If

            ' Right border
            If NewPosition.x + ClientRect.Width <= WorkingRect.Right + SnapOffset AndAlso NewPosition.x + ClientRect.Width >= WorkingRect.Right - SnapOffset Then
                NewPosition.x = WorkingRect.Right - (ClientRect.Width)
            End If

            ' Bottom border
            If NewPosition.y + ClientRect.Height <= WorkingRect.Bottom + SnapOffset AndAlso NewPosition.y + ClientRect.Height >= WorkingRect.Bottom - SnapOffset Then
                NewPosition.y = WorkingRect.Bottom - (ClientRect.Height)
            End If

            ' Marshal it back
            Runtime.InteropServices.Marshal.StructureToPtr(NewPosition, LParam, True)
        Catch ex As ArgumentException
        End Try
    End Sub
End Class
