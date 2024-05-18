Imports Newtonsoft.Json

Public Class PayloadCobranca
    <JsonProperty("cliente")>
    Public Property Cliente As Integer
    <JsonProperty("txId")>
    Public Property TxId As String
    <JsonProperty("cpf")>
    Public Property Cpf As String
    <JsonProperty("cnpj")>
    Public Property Cnpj As String
    <JsonProperty("nome")>
    Public Property Nome As String
    <JsonProperty("solicitacaoPagador")>
    Public Property SolicitacaoPagador As String
    <JsonProperty("original")>
    Public Property Original As Decimal
    <JsonProperty("status")>
    Public Property Status As String
    <JsonProperty("chave")>
    Public Property Chave As String
End Class
