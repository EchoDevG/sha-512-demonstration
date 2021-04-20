Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Sub KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Button1_Click(sender, e)
        End If
    End Sub

    Sub KeyDown2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Button2_Click(sender, e)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim password As String = TextBox1.Text
        TextBox2.Text = SHA.GenerateSHA512String(password)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim password As String = TextBox4.Text
        TextBox3.Text = SHA.GenerateSHA512String(password)
        If TextBox3.Text = TextBox2.Text Then
            TextBox5.Text &= "You're in!" + vbNewLine
        Else
            TextBox5.Text &= "Please try again" + vbNewLine
        End If
    End Sub
End Class

Public Class SHA

        Public Shared Function GenerateSHA256String(ByVal inputString) As String
            Dim sha256 As SHA256 = SHA256Managed.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            Return stringBuilder.ToString()
        End Function

        Public Shared Function GenerateSHA512String(ByVal inputString) As String
            Dim sha512 As SHA512 = SHA512Managed.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
            Dim hash As Byte() = sha512.ComputeHash(bytes)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            Return stringBuilder.ToString()
        End Function
    End Class

