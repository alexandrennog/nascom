Imports System.IO
Imports System.Security.Cryptography

Public Class criptografia

    Private sKy As String = "chavede0criptografia9nascomercio"  '32 chr shared ascii string (32 * 8 = 256 bit)
    Private sIV As String = "vetorde9criptografia0nascomercio"  '32 chr shared ascii string (32 * 8 = 256 bit)

    Public Function Criptografar(texto As String) As String
        Dim myRijndael As New RijndaelManaged

        Try
            myRijndael.Padding = PaddingMode.Zeros
            myRijndael.Mode = CipherMode.CBC
            myRijndael.KeySize = 256
            myRijndael.BlockSize = 256

            Dim encrypted() As Byte
            Dim toEncrypt() As Byte
            Dim key() As Byte
            Dim IV() As Byte

            key = System.Text.Encoding.ASCII.GetBytes(sKy)
            IV = System.Text.Encoding.ASCII.GetBytes(sIV)

            Dim encryptor As ICryptoTransform = myRijndael.CreateEncryptor(key, IV)

            Dim msEncrypt As New MemoryStream()
            Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

            toEncrypt = System.Text.Encoding.ASCII.GetBytes(texto)

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length)
            csEncrypt.FlushFinalBlock()

            encrypted = msEncrypt.ToArray()

            Return Convert.ToBase64String(encrypted)
        Catch ex As Exception
            Return ""
        Finally
            myRijndael = Nothing
        End Try
    End Function

    Public Function Descriptografar(texto As String) As String
        Dim myRijndael As New RijndaelManaged

        Try
            myRijndael.Padding = PaddingMode.Zeros
            myRijndael.Mode = CipherMode.CBC
            myRijndael.KeySize = 256
            myRijndael.BlockSize = 256

            Dim key() As Byte
            Dim IV() As Byte

            key = System.Text.Encoding.ASCII.GetBytes(sKy)
            IV = System.Text.Encoding.ASCII.GetBytes(sIV)

            Dim decryptor As ICryptoTransform = myRijndael.CreateDecryptor(key, IV)

            Dim sEncrypted As Byte() = Convert.FromBase64String(texto)

            Dim fromEncrypt() As Byte = New Byte(sEncrypted.Length) {}

            Dim msDecrypt As New MemoryStream(sEncrypted)
            Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

            Return System.Text.Encoding.ASCII.GetString(fromEncrypt)
        Catch ex As Exception
            Return ""
        Finally
            myRijndael = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Recebe uma connection string com a senha criptografada (via Criptografar) e devolve
    ''' a mesma string com a senha decodificada, pronta para uso em uma conexao real.
    ''' </summary>
    Public Shared Function DecodificarConnectionString(ByVal strConn As String) As String
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()
        builder.ConnectionString = strConn

        If Not builder.ContainsKey("Password") Then
            Return strConn
        End If

        Dim senhaCriptografada As String = builder("Password").ToString()

        If String.IsNullOrEmpty(senhaCriptografada) Then
            Return strConn
        End If

        Dim cripto As New criptografia()
        Dim senhaDecodificada As String = Split(cripto.Descriptografar(senhaCriptografada), vbNullChar)(0)

        Return strConn.Replace(senhaCriptografada, senhaDecodificada)
    End Function

End Class
