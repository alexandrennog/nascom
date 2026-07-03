Imports System.Configuration
Imports System.Reflection

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ' Nomes das entradas de <connectionStrings> no app.config que guardam a senha do MySQL
        ' criptografada (ncComum.criptografia). O My.Settings (usado pelos TableAdapters do
        ' nascomercioDataSet) le essas entradas via ConfigurationManager.ConnectionStrings, que
        ' fica ReadOnly apos o carregamento. Aqui destravamos e substituimos, SOMENTE EM MEMORIA,
        ' pela versao com a senha decodificada -- o arquivo em disco continua criptografado.
        Private Shared ReadOnly NomesConnectionStrings As String() = {
            "nascomercio",
            "nascomercio.My.MySettings.nascomercioConnectionString"
        }

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            DecodificarConnectionStringsEmMemoria()
        End Sub

        Private Sub DecodificarConnectionStringsEmMemoria()
            Try
                Dim connStrings As ConnectionStringSettingsCollection = ConfigurationManager.ConnectionStrings

                Dim fiColecao As FieldInfo = GetType(ConfigurationElementCollection).GetField(
                    "bReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)
                fiColecao.SetValue(connStrings, False)

                Dim fiElemento As FieldInfo = GetType(ConfigurationElement).GetField(
                    "_bReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)

                For Each nome As String In NomesConnectionStrings
                    Dim item As ConnectionStringSettings = connStrings(nome)

                    If item IsNot Nothing Then
                        fiElemento.SetValue(item, False)
                        item.ConnectionString = ncComum.criptografia.DecodificarConnectionString(item.ConnectionString)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(
                    "Nao foi possivel decodificar a senha do banco de dados em memoria." & vbCrLf & vbCrLf & ex.Message,
                    "Nascomercio", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
