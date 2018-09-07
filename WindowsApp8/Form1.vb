Imports System.IO
Imports System.Net
Imports C.TO_API
Public Class Form1

    Dim proxies As New List(Of String)
    Dim combos As New List(Of String)
    Dim nproxies As Integer
    Dim ncombo As Integer
    Dim nunchecked As Integer
    Dim nthreads As Integer = 1
    Dim listofthreads As New List(Of Threading.Thread)
    Dim workingaccounts As New List(Of String)

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.Close()
    End Sub

    Sub reset()
        proxies.Clear()
        nproxies = 0
        nunchecked = 0
        For Each thread As Threading.Thread In listofthreads
            Try
                thread.Suspend()
            Catch ex As Exception
            End Try
        Next
        listofthreads.Clear()
    End Sub

    Private Sub bload_Click(sender As Object, e As EventArgs) Handles bloadproxy.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            proxies.AddRange(File.ReadAllLines(fd.FileName))
            nproxies = proxies.Count
        Else
            MsgBox("This file could not be loaded.")
        End If

        bstart.Enabled = True
    End Sub

    Private Sub bloadcombo_Click(sender As Object, e As EventArgs) Handles bloadcombo.Click


        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            combos.AddRange(File.ReadAllLines(fd.FileName))
            ncombo = combos.Count
            nunchecked = ncombo
        Else
            MsgBox("This file could not be loaded.")
        End If

    End Sub

    Private Sub numthreads_ValueChanged(sender As Object, e As EventArgs) Handles numthreads.ValueChanged
        nthreads = numthreads.Value
    End Sub

    'Private Sub bstart_Click(sender As Object, e As EventArgs) Handles bstart.Click
    '    nthreads = numthreads.Value
    '    If nthreads > nproxies Then nthreads = nproxies

    '    Timer1.Start()

    '    For x = 0 To nthreads - 1
    '        Dim startl = (nproxies / nthreads) * x
    '        Dim endl = ((nproxies / nthreads) * x + (nproxies / nthreads))
    '        Dim thread = New Threading.Thread(Sub() CheckThread(startl, endl, x))
    '        thread.Start()
    '        listofthreads.Add(thread)
    '    Next
    'End Sub

    'Sub CheckThread(ByVal startline As Integer, ByVal endline As Integer, ByVal threadno As Integer)
    '    Dim myProxy As WebProxy
    '    For x = startline To endline - 1
    '        Try
    '            myProxy = New WebProxy(proxies(x))
    '            Dim request As HttpWebRequest = HttpWebRequest.Create("http://proxyjudge.us/azenv.php")
    '            request.Proxy = myProxy
    '            request.Timeout = 8000
    '            Dim response As HttpWebResponse = request.GetResponse
    '        Catch ex As Exception
    '        End Try
    '        nunchecked -= 1
    '    Next
    'End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub bstop_Click(sender As Object, e As EventArgs) Handles bstop.Click

        For Each thread As Threading.Thread In listofthreads
            Try
                thread.Suspend()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub bexport_Click(sender As Object, e As EventArgs)

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "txt files (*.txt)|"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            File.WriteAllLines(saveFileDialog1.FileName, workingaccounts)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
