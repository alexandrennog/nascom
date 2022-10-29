Imports System.Net
Imports System.Net.Mail

Namespace nsEmail

    Public Class SendMailService
        Private _from As String
        Private _to As String
        Private _password As String
        Private _subject As String
        Private _body As String

        Public Sub New(ByVal from As String, ByVal [to] As String, ByVal password As String, ByVal subject As String, ByVal body As String)
            _from = from
            _to = [to]
            _password = password
            _subject = subject
            _body = body
        End Sub

        Public Sub Send()
            Dim smtp = New SmtpClient With {
                .Host = "mail.nascom.com.br",
                .Port = 587,
                .DeliveryMethod = SmtpDeliveryMethod.Network,
                .EnableSsl = True,
                .Credentials = New NetworkCredential(_from, _password)
            }

            Using message = New MailMessage(_from, _to) With {
                .Subject = _subject,
                .Body = _body
            }
                smtp.Send(message)
            End Using
        End Sub
    End Class

End Namespace