Public Class Form1
    Private Spoken As Boolean = True
    Private Ticker As Boolean = False
    Private FrmClose As Boolean = False
'Private Sub LabelControl1_Click( sender As Object,  e As EventArgs) Handles LabelControl1.Click
'        Timer1.Interval = GetNearstquarter(DateTime.Now) - DateTime.Now.Millisecond
'        Timer1.Start
'End Sub

'    ''Private Sub DoStuffThread()
'    ''    Dim NextExecutionTime As DateTime = DateTime.Now
'    ''    Dim speaker As New SpeechLib.SpVoice

'    ''    Timer1.Interval = GetNearstquarter(NextExecutionTime) - NextExecutionTime.Millisecond

'    ''    ''nextExecution = New DateTime(nextExecution.Year, nextExecution.Month, nextExecution.Day, 10, 0, 0)

'    ''    'If NextExecutionTime < DateTime.Now Then NextExecutionTime = NextExecutionTime.AddMinutes(15)

'    ''    'Do
'    ''    '    If NextExecutionTime < DateTime.Now Then
                
'    ''    '        speaker.Speak(DateTime.Now.ToString)
'    ''    '       NextExecutionTime = NextExecutionTime.AddMinutes(15)
'    ''    '    End If

'    ''    '    Threading.Thread.Sleep(60 * 1000) ' Just sleep 1 minutes
'    ''    'Loop
'    ''End Sub

'    Private Function GetNearstquarter(NowDateTime As DateTime) As Integer
'        While (NowDateTime.Minute mod 15 <> 0)
'            NowDateTime.AddSeconds(1)
'        End While
'        Return NowDateTime.Millisecond
'    End Function

Private Sub Timer1_Tick( sender As Object,  e As EventArgs) Handles Timer1.Tick
        If Ticker  Then
            Label1.Text = format(DateTime.Now, "hh mm tt"): Ticker = False
        Else
            Label1.Text = format(DateTime.Now, "hh:mm tt"): Ticker = True
        End If
        'LabelControl1.Text = format(DateTime.Now, "hh:mm tt")     
  
        If DateTime.Now.Minute mod 15 = 0  and Spoken Then
            'LabelControl1.Text = DateTime.Now
            Dim speaker As new SpeechLib.SpVoice
            speaker.Rate = 1
            speaker.Speak(format(DateTime.Now, "hh:mm"))
            Spoken = False
        ElseIf Spoken = False andalso DateTime.Now.Minute mod 15 <> 0 then
            Spoken = True
        End If
        
End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not FrmClose
        Me.Hide
        NotifyIcon1.Visible = True
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label1.Text = format(DateTime.Now, "hh:mm tt")

    End Sub

Private Sub Form1_SizeChanged( sender As Object,  e As EventArgs) Handles MyBase.load
        Me.Hide
        NotifyIcon1.Visible = True
End Sub

Private Sub ShowToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ShowToolStripMenuItem.Click, ContextMenuStrip1.MouseDoubleClick
        Me.Show
        NotifyIcon1.Visible = False
End Sub

Private Sub ExitToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ExitToolStripMenuItem.Click
        FrmClose = True
        Application.Exit
End Sub

End Class
