Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao
Imports System.Configuration
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports com.itextpdf.text
Imports iTextSharp.text.pdf.qrcode
Imports Imagem = System.Drawing.Image
Imports ImagemFormato = System.Drawing.Imaging
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports iTextSharp.text.pdf.draw
Imports System.Linq
Imports ncComum.nsFuncoes
Imports ncDados
Imports ncRegras
Imports System.Globalization
Imports ncRegras.nsLoja
Imports ncDados.nsLoja

Public Class fClienteForm

    Public cid As Nullable(Of Integer)
    Private salvar_foto As Boolean = False
    Private dirRaiz As String
    Private dirFoto As String

    Private Sub MaskClicpf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPF.LostFocus

        Dim valor(9) As UShort
        Dim texto As String
        Dim divisor As Byte
        Dim resultado As Byte
        Dim soma As UShort
        Dim DV(1) As Byte

        Try                                                                      'Vamos tratar a rotina com tri catch para nao dar erro de campo vazio.
            If txtCPF.Mask = "###.###.###-##" Then                           'Vamos sair da rotina se o MsskClicpf estiver em branco ou vazio
                Exit Try                                                         'Sair da rotina TRY/CATCH
            End If
            divisor = 11                                                         'Valor do Divisor
            texto = txtCPF.Text
            valor(0) = texto.Substring(0, 1) * 10                                'Vamos Multiplicar o Primeiro caracter
            valor(1) = texto.Substring(1, 1) * 9                                 'Vamos Multiplicar o Segundo caracter
            valor(2) = texto.Substring(3, 1) * 8                                 'Vamos Multiplicar o Terceiro caracter
            valor(3) = texto.Substring(4, 1) * 7                                 'Vamos Multiplicar o Quarto caracter
            valor(4) = texto.Substring(5, 1) * 6                                 'Vamos Multiplicar o Quinto caracter  
            valor(5) = texto.Substring(7, 1) * 5                                 'Vamos Multiplicar o Sexto caracter
            valor(6) = texto.Substring(8, 1) * 4                                 'Vamos Multiplicar o Setimo caracter
            valor(7) = texto.Substring(9, 1) * 3                                 'Vamos Multiplicar o Oitavo caracter
            valor(8) = texto.Substring(10, 1) * 2                                'Vamos Multiplicar o Nono caracter

            soma = valor(0) + valor(1) + valor(2) + valor(3) + valor(4) + valor(5) + valor(6) + valor(7) + valor(8) 'Soma todos os valores.
            resultado = soma Mod divisor                                         'Coloca dentro da variavel o resto da divisao

            If resultado <= 1 Then                                               'Se o resto da divisao for memor que dois em o resultado é 0
                DV(0) = 0                                                        'Digito verificador (1) = 0
            Else
                DV(0) = (divisor - resultado)                                    'Subtrai o divisor pelo resultado
            End If

            valor(0) = texto.Substring(0, 1) * 11                                'Vamos Multiplicar o Primeiro caracter
            valor(1) = texto.Substring(1, 1) * 10                                'Vamos Multiplicar o Segundo caracter
            valor(2) = texto.Substring(2, 1) * 9                                 'Vamos Multiplicar o Terceiro caracter
            valor(3) = texto.Substring(4, 1) * 8                                 'Vamos Multiplicar o Quarto caracter
            valor(4) = texto.Substring(5, 1) * 7                                 'Vamos Multiplicar o Quinto caracter  
            valor(5) = texto.Substring(6, 1) * 6                                 'Vamos Multiplicar o Sexto caracter
            valor(6) = texto.Substring(8, 1) * 5                                 'Vamos Multiplicar o Setimo caracter
            valor(7) = texto.Substring(9, 1) * 4                                 'Vamos Multiplicar o Oitavo caracter
            valor(8) = texto.Substring(10, 1) * 3                                'Vamos Multiplicar o Nono caracter
            valor(9) = DV(0) * 2

            soma = valor(0) + valor(1) + valor(2) + valor(3) + valor(4) + valor(5) + valor(6) + valor(7) + valor(8) + valor(9) 'Soma todos os valores.
            resultado = soma Mod divisor                                         'Coloca dentro da variavel o resto da divisao

            If resultado <= 1 Then                                               'Se o resto da divisao for memor que dois em o resultado é 0
                DV(1) = 0                                                        'Digito verificador (1) = 0
            Else
                DV(1) = (divisor - resultado)                                    'Subtrai o divisor pelo resultado
            End If
            valor(0) = texto.Substring(12, 1)                                    'Armazena o valor obtido no digito 1 e 2 e recoloca na variavel para tratar condição
            valor(1) = texto.Substring(13, 1)                                    'Armazena o valor obtido no digito 1 e 2 e recoloca na variavel para tratar condição
            If valor(0) = DV(0) And valor(1) = DV(1) Then                        'Compara o que foi digitado com o valor obtido.
                Exit Sub                                                         'Valor Verdadeiro em vamos sair.
            Else
                MessageBox.Show("CPF Invalido", "Atenção", MessageBoxButtons.OK) 'Digito nao esta batendo.
                txtCPF.Focus()                                               'Volta para o maskclicpf   
            End If
        Catch ex As Exception                                                    'Qualquer outro erro vamos sair.   
            Exit Sub
        End Try
    End Sub
    Private Sub CarregarFoto()
        Dim dirFotos As String

        Dim image As Imagem
        image = picImagem.Image

        SaveFileDialog1.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp"
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.RestoreDirectory = False
        SaveFileDialog1.CreatePrompt = True
        SaveFileDialog1.OverwritePrompt = False

        If dirRaiz <> "" Then
            dirFotos = dirRaiz & "\" & dirFoto
        Else
            dirFotos = dirFoto
        End If

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            picImagem.ImageLocation = SaveFileDialog1.FileName
            picImagem.Tag = SaveFileDialog1.FileName
        End If
        ' End Using
    End Sub


    Public Sub CreatePDF()
        ' Step 1: Create a Document object with A4 size and margins
        Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
        Dim dados As New dCliente
        Dim regras As rCliente

        regras = New rCliente()
        dados = regras.ConsultarPorCID(Me.cid)

        Dim arquivoPDF = "RelatorioContrato" & dados.nome & ".pdf"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If

        'doc.SetMargins(10, 10, 10, 10)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF, FileMode.Create))

        'Dim paragrafo As Paragraph = New Paragraph("", New Font(FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14)))

        'paragrafo.Alignment = Element.ALIGN_JUSTIFIED

        Try

            ' Step 4: Open the Document for writing
            doc.Open()

            ' Step 5: Add content to the document
            AddBody(doc, dados)

            If doc IsNot Nothing Then
                doc.Close()
            End If

            ImprimirContrato(arquivoPDF)

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        Finally
            ' Step 6: Close the Document

        End Try
    End Sub
    Private Sub ImprimirContrato(arquivoPDF As String)
        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub
    Private Sub AddBody(documento As Document, dados As dCliente)
        ' Define a font for the body text
        Dim bodyFont As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK)

        Dim bodyFont2 As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK)

        Dim frase As New Phrase
        Dim regrasEndereco As New rClienteEndereco()
        Dim dadosEndereco As New dClienteEndereco()

        Dim regras As rLoja
        Dim colecaoLoja As ColecaoLoja
        Dim loja As New dLoja

        regras = New rLoja
        colecaoLoja = regras.Listar()
        loja = colecaoLoja.FirstOrDefault(Function(s) s.cid = 1)

        Dim regrasEstado As rEstado
        Dim colecaoEstado As ColecaoEstado
        regrasEstado = New rEstado()
        colecaoEstado = regrasEstado.Listar()

        dadosEndereco.cliente_cid = Me.cid
        dadosEndereco = regrasEndereco.Consultar(dadosEndereco)(0)
        Dim nomeEstado = colecaoEstado.FirstOrDefault(Function(s) s.cid = dadosEndereco.estado_cid).nome
        Dim contents As New Paragraph()
        contents.Alignment = Element.ALIGN_CENTER

        Dim paragrap1 As New Paragraph("CÓDIGO CLIENTE", bodyFont)
        paragrap1.Alignment = Element.ALIGN_CENTER
        documento.Add(paragrap1)


        Dim paragrap2 As New Paragraph("CONTRATO DE CREDITO DA LOJA DE CALÇADOS E BOLSAS SAPATEK", bodyFont)
        paragrap2.Alignment = Element.ALIGN_CENTER
        documento.Add(paragrap2)
        Dim paragrap3 As New Paragraph("CONDIÇES GERAIS", bodyFont)
        paragrap3.Alignment = Element.ALIGN_CENTER
        documento.Add(paragrap3)
        Dim paragrap4 As New Paragraph("  ")
        Dim paragrap41 As New Paragraph("  ")
        documento.Add(paragrap4)
        documento.Add(paragrap41)

        Dim dados0 As String = $"DE UM LADO COMO CONTRATANTE A {If(cFuncoes.RetornarTexto(loja.nomeFantasia) Is Nothing, "", cFuncoes.RetornarTexto(loja.nomeFantasia).ToString())} SOB INCRIÇÃO ESTADUAL  {If(cFuncoes.RetornarTexto(loja.Inscestadual) Is Nothing, "", cFuncoes.RetornarTexto(loja.Inscestadual).ToString())}  e CGC {If(cFuncoes.RetornarTexto(loja.cnpj) Is Nothing, "", cFuncoes.RetornarTexto(loja.cnpj).ToString())}, situada a {If(cFuncoes.RetornarTexto(loja.logradouro) Is Nothing, "", cFuncoes.RetornarTexto(loja.logradouro).ToString())},{If(cFuncoes.RetornarTexto(loja.numero) Is Nothing, "", cFuncoes.RetornarTexto(loja.numero).ToString())} - {If(cFuncoes.RetornarTexto(loja.bairro) Is Nothing, "", cFuncoes.RetornarTexto(loja.bairro).ToString())}, {If(cFuncoes.RetornarTexto(loja.cidade) Is Nothing, "", cFuncoes.RetornarTexto(loja.cidade).ToString())}{If(cFuncoes.RetornarTexto(loja.estado_cid) Is Nothing, "", cFuncoes.RetornarTexto(loja.estado_cid).ToString())}. "
        Dim paragrafo0 As New Paragraph(dados0, bodyFont)
        documento.Add(paragrafo0)
        documento.Add(New Paragraph(" "))

        Dim dados00 As String = "De um lado como contratado "
        Dim paragrafo00 As New Paragraph(dados00, bodyFont)
        documento.Add(paragrafo00)
        documento.Add(New Paragraph(" "))
        Dim dados01 As String = "Nome:   " & If(dados.nome Is Nothing, "", dados.nome.ToString())
        Dim paragrafo01 As New Paragraph(dados01, bodyFont2)
        documento.Add(paragrafo01)
        documento.Add(New Paragraph(" "))
        Dim dados02 As String = "Endereço : " & " " & If(cFuncoes.RetornarTexto(dadosEndereco.logradouro) Is Nothing, "", cFuncoes.RetornarTexto(dadosEndereco.logradouro).ToString()) & " " & If(cFuncoes.RetornarTexto(dadosEndereco.numero) Is Nothing, "", cFuncoes.RetornarTexto(dadosEndereco.numero).ToString()) & " " & If(cFuncoes.RetornarTexto(dadosEndereco.complemento) Is Nothing, "", cFuncoes.RetornarTexto(dadosEndereco.complemento).ToString())
        dados02 = dados02 & "            CEP: " & If(dadosEndereco.cep Is Nothing, "", dadosEndereco.cep)
        Dim paragrafo02 As New Paragraph(dados02, bodyFont2)
        documento.Add(paragrafo02)
        documento.Add(New Paragraph(" "))

        Dim dados03 As String = "Cidade: " & If(cFuncoes.RetornarTexto(dadosEndereco.cidade) Is Nothing, "", cFuncoes.RetornarTexto(dadosEndereco.cidade).ToString()) & "           " & "                                        Estado : " & If(nomeEstado Is Nothing, "", nomeEstado.ToString())
        Dim paragrafo03 As New Paragraph(dados03, bodyFont2)
        documento.Add(paragrafo03)
        documento.Add(New Paragraph(" "))

        documento.Add(New Paragraph("Telefone: " & If(dados.telefone Is Nothing, "", dados.telefone.ToString()), bodyFont2))
        documento.Add(New Paragraph(" "))
        Dim texto As String = "Data de Nascimento: " & If(dados.dataNascimento Is Nothing, "", dados.dataNascimento.ToString()) & "            Estado: " & If(nomeEstado Is Nothing, "", nomeEstado)
        documento.Add(New Paragraph(texto, bodyFont2))
        documento.Add(New Paragraph("Natural De " & If(dados.naturalidade Is Nothing, "", dados.naturalidade.ToString()), bodyFont2))
        documento.Add(New Paragraph(" "))
        documento.Add(New Paragraph("CPF: " & If(dados.cpf Is Nothing, "", dados.cpf.ToString()), bodyFont2))
        documento.Add(New Paragraph(" "))
        documento.Add(New Paragraph("RG: " & If(dados.rg Is Nothing, "", dados.rg.ToString()), bodyFont2))
        documento.Add(New Paragraph(" "))
        Dim clausula1 As String = "1-A pessoa física será responsável pelas contas lançadas ao seu crédito."
        Dim paragrafo1 As New Paragraph(clausula1, bodyFont2)
        paragrafo1.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo1)
        documento.Add(New Paragraph(" "))
        Dim clausula2 As String = "2-No ato da compra o contratado ira assinar uma declaração de compra na loja física, onde constara as parcelas e vencimentos definidos entre as partes, no caso da compra online as conversas em nosso WhatsApp servirão como prova da referida compra."
        Dim paragrafo2 As New Paragraph(clausula2, bodyFont2)
        paragrafo2.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo2)
        documento.Add(New Paragraph(" "))
        Dim clausula3 As String = "3-O contratado terá 3 (três) dias de carência após o vencimento para quitação de suas parcelas sem nenhum acréscimo, após (três) dias, a correção diária é de 0,50% ao dia e o pagamento só poderá ser efetuado em dinheiro ou pix."
        Dim paragrafo3 As New Paragraph(clausula3, bodyFont2)
        paragrafo3.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo3)
        documento.Add(New Paragraph(" "))
        Dim clausula4 As String = "4-Em caso de falta de pagamento até o respectivo vencimento incidira em cobrança amigável ou judicial."
        Dim paragrafo4 As New Paragraph(clausula4, bodyFont2)
        paragrafo4.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo4)
        documento.Add(New Paragraph(" "))
        Dim clausula5 As String = "5-No ato da abertura do crediário online o contratado se compromete a enviar uma foto sua segurando o seu documento de identidade, para salvaguardar que realmente é o contratante que está efetuando a compra a fim de evitar fraudes, e a contratada ira se comprometer a guardar o documento enviado de acordo com a lei geral de proteção de dados. "
        Dim paragrafo5 As New Paragraph(clausula5, bodyFont2)
        paragrafo5.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo5)
        documento.Add(New Paragraph(" "))
        Dim clausula6 As String = "6-Este caso tem prazo indeterminado a sua extinção ocorre tão somente com a quitação das obrigações assumidas e obedecidas as disposições contratuais."
        Dim paragrafo6 As New Paragraph(clausula6, bodyFont2)
        paragrafo6.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo6)
        documento.Add(New Paragraph(" "))
        Dim clausula7 As String = "Parágrafo único: o documento ficara guardado com a contratada pelo período que vigorar este contrato, após a contratante se comprometer a descartar de forma segura o documento de acordo com LEI Geral de Proteção de Dados."
        Dim paragrafo7 As New Paragraph(clausula7, bodyFont2)
        paragrafo7.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo7)
        documento.Add(New Paragraph(" "))


        Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Date.Now.Month)

        Dim clausula8 As String = "Santo André, " & Date.Now.Day.ToString() & " de " & monthName & "  de  " & Date.Now.Year.ToString()
        Dim paragrafo8 As New Paragraph(clausula8, bodyFont2)
        paragrafo8.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo8)
        documento.Add(New Paragraph(" "))
        Dim clausula9 As String = "Assinatura:__________________________________________"
        Dim paragrafo9 As New Paragraph(clausula9, bodyFont2)
        paragrafo9.Alignment = Element.ALIGN_JUSTIFIED
        documento.Add(paragrafo9)

    End Sub

    ' Custom PageEventHandler class to handle header and footer
    Public Class PageEventHandler
        Inherits PdfPageEventHelper

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            AddHeader(writer, document)
            AddFooter(writer, document)
        End Sub

        Private Sub AddHeader(writer As PdfWriter, document As Document)
            ' Define a font for the header
            Dim headerFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)

            ' Create a paragraph for the header
            Dim header As New Paragraph("CÓDIGO CLIENTE\n\r CONTRATO DE CREDITO DA LOJA DE CALÇADOS E BOLSAS SAPATEK\n\r CONDIÇES GERAIS", headerFont)
            header.Alignment = Element.ALIGN_CENTER

            ' Get the content byte for the writer
            Dim cb As PdfContentByte = writer.DirectContent
            ' Create a rectangle for the header
            Dim rect As New Rectangle(0, document.PageSize.Height - 50, document.PageSize.Width, document.PageSize.Height - 30)

            ' Begin text
            cb.BeginText()
            ' Move the header to the correct position
            cb.ShowTextAligned(Element.ALIGN_CENTER, header.Content, rect.Width / 2, rect.Top - 20, 0)
            ' End text
            cb.EndText()

            ' Add a line separator
            Dim line As New LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)
            Dim lineChunk As New Chunk(line)
            lineChunk.SetHorizontalScaling(1)
            document.Add(lineChunk)
        End Sub

        Private Sub AddFooter(writer As PdfWriter, document As Document)
            ' Define a font for the footer
            Dim footerFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY)

            ' Add footer text
            Dim footer As New Paragraph("Santo André,     02        de    Maio                              de  2024.\n\r Assinatura:__________________________________________", footerFont)

            footer.Alignment = Element.ALIGN_CENTER

            ' Get the content byte for the writer
            Dim cb As PdfContentByte = writer.DirectContent
            ' Create a rectangle for the footer
            Dim rect As New Rectangle(0, 0, document.PageSize.Width, 50)

            ' Begin text
            cb.BeginText()
            ' Move the footer to the correct position
            cb.ShowTextAligned(Element.ALIGN_CENTER, footer.Content, rect.Width / 2, rect.Bottom + 20, 0)
            ' End text
            cb.EndText()
        End Sub
    End Class

    Private Sub MaskClirg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRG.LostFocus
        Dim valor(8) As UShort
        Dim texto As String
        Dim divisor As Byte
        Dim resultado As Byte
        Dim soma As UShort
        Dim Dv As Byte
        Dim DvString As String = ""

        Try                                                                      'Vamos tratar a rotina com tri catch para nao dar erro de campo vazio.
            If txtRG.Mask = "##.###.###-#" Then                              'Vamos sair da rotina se o MsskClirg estiver em branco ou vazio
                Exit Try
            End If
            divisor = 11                                                         'Valor do Divisor
            texto = txtRG.Text
            valor(0) = texto.Substring(0, 1) * 9                                 'Vamos Multiplicar o Primeiro caracter
            valor(1) = texto.Substring(1, 1) * 8                                 'Vamos Multiplicar o Segundo caracter
            valor(2) = texto.Substring(3, 1) * 7                                 'Vamos Multiplicar o Terceiro caracter
            valor(3) = texto.Substring(4, 1) * 6                                 'Vamos Multiplicar o Quarto caracter
            valor(4) = texto.Substring(5, 1) * 5                                 'Vamos Multiplicar o Quinto caracter  
            valor(5) = texto.Substring(7, 1) * 4                                 'Vamos Multiplicar o Sexto caracter
            valor(6) = texto.Substring(8, 1) * 3                                 'Vamos Multiplicar o Setimo caracter
            valor(7) = texto.Substring(9, 1) * 2                                 'Vamos Multiplicar o Oitavo caracter
            valor(8) = texto.Substring(11, 1)

            soma = valor(0) + valor(1) + valor(2) + valor(3) + valor(4) + valor(5) + valor(6) + valor(7) 'Soma todos os valores.
            resultado = soma Mod divisor                                         'Coloca dentro da variavel o resto da divisao

            If resultado = 10 Then                                               'Se o resto da divisao for igual á 10 
                DvString = "X" Or "x"                                            'Digito verificador  = X
            Else
                Dv = resultado                                                   'Atribui o valor do resultado na variavel de comparação.
            End If

            If valor(8) = Dv Or CStr(valor(8)) = DvString Then                   'Vamos comparar o que foi digitado com o resultado obtido na rotina.
                Exit Try
            Else
                MessageBox.Show("RG Invalido", "Atenção", MessageBoxButtons.OK) 'Digito nao esta batendo.
                txtRG.Focus()                                               'Volta para o maskclirg

            End If
        Catch ex As Exception                                                   'Qualquer outro erro vamos sair.   
            Exit Sub
        End Try
    End Sub

    Private Sub btoCliSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            mdiPrincipal.FecharTela()
        End If
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub btoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEndereco.Click
        CarregarEndereco()
    End Sub

    Private Sub btoProfissional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProfissional.Click
        CarregarProfissional()
    End Sub

    Private Sub btoFinanceiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFinanceiro.Click
        CarregarFinanceiro()
    End Sub

    Private Sub Excluir()
        Dim dados As dCliente
        Dim regras As rCliente

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.ToString().Equals(String.Empty) Then
                    If Not Me.cid.Equals(0) Then
                        If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                            dados = New dCliente
                            regras = New rCliente

                            dados.cid = TratarInteiro(Me.cid)

                            regras.Excluir(dados)

                            Me.cid = Nothing
                            LimparCampos()
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na exclusão dos dados de Cliente.")

        End Try
    End Sub

    Private Function Validar() As Boolean
        Try

            If String.IsNullOrEmpty(txtNome.Text.Trim()) Then
                MessageBox.Show("É necessário informar o Nome!")
                Return False
            End If

            If Not String.IsNullOrEmpty(txtRG.Text.Trim()) Then

                If String.IsNullOrEmpty(txtOrgaoEmissor.Text.Trim()) Then
                    MessageBox.Show("É necessário informar o Orgão Emissor do RG!")
                    Return False
                End If

                If (TratarInteiro(cboEstado.SelectedValue).Equals(Nothing) OrElse TratarInteiro(cboEstado.SelectedValue).Equals(0)) Then
                    MessageBox.Show("É necessário informar a UF do RG!")
                    Return False
                End If

            End If

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub Salvar()
        Dim dados As dCliente
        Dim regras As rCliente
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty
        Dim novoCID As Integer

        Try

            If Not Validar() Then
                Exit Sub
            End If

            tipoMsg = "INCLUSÃO"
            tipoAcao = "i"

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.ToString().Equals(String.Empty) Then
                    If Not Me.cid.Equals(0) Then
                        tipoMsg = "ALTERAÇÃO"
                        tipoAcao = "a"
                    End If
                End If
            End If

            If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                dados = New dCliente
                regras = New rCliente

                dados.cid = Me.cid
                dados.nome = TratarTexto(txtNome.Text)
                dados.dataNascimento = TratarTexto(FormatarData(txtDataNascimento.Text))
                dados.naturalidade = TratarTexto(txtNaturalidade.Text)
                dados.nacionalidade = TratarTexto(txtNacionalidade.Text)
                dados.estadoCivil = TratarTexto(cboEstadoCivil.SelectedValue)
                dados.sexo = TratarTexto(cboSexo.SelectedValue)
                dados.cpf = TratarTexto(txtCPF.Text)
                dados.rg = TratarTexto(txtRG.Text)
                dados.rgOrgaoEmissor = TratarTexto(txtOrgaoEmissor.Text)
                dados.rgUf_cid = TratarInteiro(cboEstado.SelectedValue)
                dados.carteiraProfissional = TratarTexto(txtCarteiraProfissional.Text)
                dados.nomePai = TratarTexto(txtNomePai.Text)
                dados.nomeMae = TratarTexto(txtNomeMae.Text)
                dados.email = TratarTexto(txtEmail.Text)
                dados.ddd = TratarTexto(txtDDD.Text)
                dados.telefone = TratarTexto(txtTelefone.Text)
                dados.dddcel = TratarTexto(txtDddCelular.Text)
                dados.celular = TratarTexto(txtCelular.Text)
                dados.situacao = TratarTexto(cboSituacao.SelectedValue)


                If tipoAcao.Equals("i") Then
                    novoCID = regras.Incluir(dados)

                    Me.cid = novoCID

                    '-- Foto
                    If ExisteFoto() Then
                        SalvarFoto()
                    End If

                    ExibirInformacoesTela()
                ElseIf tipoAcao.Equals("a") Then
                    regras.Alterar(dados)

                    '-- Foto
                    If ExisteFoto() Then
                        SalvarFoto()
                    End If

                    ExibirInformacoesTela()
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Cliente.")

        End Try
    End Sub
    Private Function ExisteFoto()

        Dim res = ""
        If picImagem.ImageLocation.Length > 5 Then
            res = picImagem.ImageLocation.Split(".")(1)
        End If

        ExisteFoto = SaveFileDialog1.Filter.Contains(res)

    End Function
    Private Sub SalvarFoto()
        Dim bmap As Bitmap
        Dim dirFotos As String

        If dirRaiz <> "" Then
            dirFotos = dirRaiz & "\" & dirFoto
        Else
            dirFotos = dirFoto
        End If

        bmap = New Bitmap(picImagem.Image)

        If Not Directory.Exists(dirFotos) Then
            Directory.CreateDirectory(dirFotos)
        End If

        If File.Exists(dirFotos & "\foto" & Me.cid.ToString() & ".jpg") = True Then
            picImagem.ImageLocation = dirFotos & "\foto" & Me.cid.ToString() & ".jpg"
            File.Delete(dirFotos & "\foto" & Me.cid.ToString() & ".jpg")
        End If

        bmap.Save(dirFotos & "\foto" & Me.cid.ToString() & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

    End Sub

    Private Sub ExibirFoto()
        Dim dirFotos As String

        If dirRaiz <> "" Then
            dirFotos = dirRaiz & "\" & dirFoto
        Else
            dirFotos = dirFoto
        End If

        If Not Me.cid.Equals(Nothing) Then
            If Directory.Exists(dirFotos) Then
                If File.Exists(dirFotos & "\foto" & Me.cid.ToString() & ".jpg") Then

                    picImagem.ImageLocation = dirFotos & "\foto" & Me.cid.ToString() & ".jpg"

                End If
            End If
        End If

    End Sub

    Private Sub fClienteForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    mdiPrincipal.FecharTela()
                End If
            Case Keys.F1
                CarregarCamera()
            Case Keys.F2
                CarregarFoto()
            Case Keys.F3
                'ConfigurarRelatorio()
                CreatePDF()
            Case Keys.F5
                Filtrar()
            Case Keys.F6
                CarregarEndereco()
            Case Keys.F7
                CarregarProfissional()
            Case Keys.F8
                CarregarFinanceiro()
            Case Keys.F9
                CarregarCrediario()
            Case Keys.Enter
                Salvar()
            Case Keys.F12
                Excluir()
        End Select
    End Sub

    Private Sub CarregarEndereco()
        If Me.cid.Equals(Nothing) Then
            MessageBox.Show("É necessário selecionar um cliente!", "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            fClienteEnderecoForm.cliente_cid = Me.cid
            fClienteEnderecoForm.cliente_nome = Me.txtNome.Text
            mdiPrincipal.CarregarClienteEnderecoForm()
        End If
    End Sub

    Private Sub CarregarFinanceiro()
        If Me.cid.Equals(Nothing) Then
            MessageBox.Show("É necessário selecionar um cliente!", "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            fClienteFinanceiroForm.cliente_cid = Me.cid
            fClienteFinanceiroForm.cliente_nome = Me.txtNome.Text
            mdiPrincipal.CarregarClienteFinanceiroForm()
        End If
    End Sub

    Private Sub CarregarProfissional()
        If Me.cid.Equals(Nothing) Then
            MessageBox.Show("É necessário selecionar um cliente!", "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            fClienteProfissionalForm.cliente_cid = Me.cid
            fClienteProfissionalForm.cliente_nome = Me.txtNome.Text
            mdiPrincipal.CarregarClienteProfissionalForm()
        End If
    End Sub

    Private Sub CarregarCrediario()
        If Me.cid.Equals(Nothing) Then
            MessageBox.Show("É necessário selecionar um cliente!", "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            fClienteCrediarioForm.cliente_cid = Me.cid
            fClienteCrediarioForm.cliente_nome = Me.txtNome.Text
            mdiPrincipal.CarregarClienteCrediarioForm()
        End If
    End Sub

    Private Sub CarregarVeiculos()
        If Me.cid.Equals(Nothing) Then
            MessageBox.Show("É necessário selecionar um cliente!", "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            fClienteVeiculoForm.cliente_cid = Me.cid
            fClienteVeiculoForm.cliente_nome = Me.txtNome.Text
            mdiPrincipal.CarregarClienteVeiculoForm()
        End If
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarClienteFiltro()
    End Sub

    Private Sub CarregarCamera()
        Dim dirFotos As String

        If dirRaiz <> "" Then
            dirFotos = dirRaiz & "\" & dirFoto
        Else
            dirFotos = dirFoto
        End If
        If Me.cid.HasValue Then
            fCamera.cliente_cid = Me.cid
            fCamera.ShowDialog()
            If fCamera.existe_foto = True Then
                Me.salvar_foto = True
                picImagem.ImageLocation = dirFotos & "\foto" & Me.cid.ToString() & ".jpg"
                'picImagem.SizeMode = PictureBoxSizeMode.StretchImage

                '-- Salvar foto do cliente (foto+codigo.jpg) no diretorio de fotos
            End If
        End If
    End Sub

    Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
        Excluir()
    End Sub

    Private Sub LimparCampos()
        txtNome.Text = String.Empty
        txtDataNascimento.Text = String.Empty
        txtNaturalidade.Text = String.Empty
        txtNacionalidade.Text = String.Empty
        txtCPF.Text = String.Empty
        txtRG.Text = String.Empty
        txtOrgaoEmissor.Text = String.Empty
        txtCarteiraProfissional.Text = String.Empty
        txtNomePai.Text = String.Empty
        txtNomeMae.Text = String.Empty
        txtEmail.Text = String.Empty
        txtDDD.Text = String.Empty
        txtTelefone.Text = String.Empty
        txtDddCelular.Text = String.Empty
        txtCelular.Text = String.Empty
        If cboEstadoCivil.Items.Count > 0 Then
            cboEstadoCivil.SelectedIndex = 0
        End If
        If cboEstado.Items.Count > 0 Then
            cboEstado.SelectedIndex = 0
        End If
        If cboSexo.Items.Count > 0 Then
            cboSexo.SelectedIndex = 0
        End If
        If cboSituacao.Items.Count > 0 Then
            cboSituacao.SelectedIndex = 0
        End If
    End Sub

    Private Sub fClienteForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dirFoto = ConfigurationManager.AppSettings.Item("DIRETORIO_FOTO")

        If dirFoto.Contains("\\") Or dirFoto.Contains(":") Then
            dirRaiz = ""
        Else
            dirRaiz = AppDomain.CurrentDomain.BaseDirectory
        End If

        LimparCampos()
        CarregarComboSituacao()
        CarregarComboSexo()
        CarregarComboEstado()
        CarregarComboEstadoCivil()
        ExibirInformacoesTela()


    End Sub

    Private Sub CarregarComboSituacao()
        Dim regras As rSituacao
        Dim colecao As ColecaoSituacao

        Try

            cboSituacao.Items.Clear()

            regras = New rSituacao()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then


                cboSituacao.ValueMember = "codigo"
                cboSituacao.DisplayMember = "descricao"
                cboSituacao.DataSource = colecao
                cboSituacao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Situação.")

        End Try
    End Sub

    Private Sub CarregarComboEstadoCivil()
        Dim regras As rEstadoCivil
        Dim colecao As ColecaoEstadoCivil

        Try

            cboEstadoCivil.Items.Clear()

            regras = New rEstadoCivil()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEstadoCivil())

                cboEstadoCivil.ValueMember = "codigo"
                cboEstadoCivil.DisplayMember = "descricao"
                cboEstadoCivil.DataSource = colecao
                cboEstadoCivil.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Estado Civil.")

        End Try
    End Sub

    Private Sub CarregarComboSexo()
        Dim regras As rSexo
        Dim colecao As ColecaoSexo

        Try

            cboSexo.Items.Clear()

            regras = New rSexo()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dSexo())

                cboSexo.ValueMember = "codigo"
                cboSexo.DisplayMember = "descricao"
                cboSexo.DataSource = colecao
                cboSexo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Sexo.")

        End Try
    End Sub

    Private Sub ExibirInformacoesTela()
        Dim regras As rCliente
        Dim dados As dCliente

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.Equals(0) Then

                    regras = New rCliente()

                    dados = regras.ConsultarPorCID(Me.cid)

                    If Not dados Is Nothing Then
                        txtCodigo.Text = RetornarTexto(dados.cid)
                        txtNome.Text = RetornarTexto(dados.nome)
                        txtDataNascimento.Text = RetornarTexto(FormatarData(dados.dataNascimento))
                        txtNaturalidade.Text = RetornarTexto(dados.naturalidade)
                        txtNacionalidade.Text = RetornarTexto(dados.nacionalidade)
                        txtCPF.Text = RetornarTexto(dados.cpf)
                        txtRG.Text = RetornarTexto(dados.rg)
                        txtOrgaoEmissor.Text = RetornarTexto(dados.rgOrgaoEmissor)
                        txtCarteiraProfissional.Text = RetornarTexto(dados.carteiraProfissional)
                        txtNomePai.Text = RetornarTexto(dados.nomePai)
                        txtNomeMae.Text = RetornarTexto(dados.nomeMae)
                        txtEmail.Text = RetornarTexto(dados.email)
                        txtDDD.Text = RetornarTexto(dados.ddd)
                        txtTelefone.Text = RetornarTexto(dados.telefone)
                        txtDddCelular.Text = RetornarTexto(dados.dddcel)
                        txtCelular.Text = RetornarTexto(dados.celular)
                        If cboEstadoCivil.Items.Count > 0 Then
                            cboEstadoCivil.SelectedIndex = 0
                        End If
                        If ValidarValor(dados.estadoCivil) Then
                            cboEstadoCivil.SelectedValue = RetornarTexto(dados.estadoCivil)
                        End If
                        If cboEstado.Items.Count > 0 Then
                            cboEstado.SelectedIndex = 0
                        End If
                        If ValidarValor(dados.rgUf_cid) Then
                            cboEstado.SelectedValue = RetornarInteiro(dados.rgUf_cid)
                        End If
                        If cboSexo.Items.Count > 0 Then
                            cboSexo.SelectedIndex = 0
                        End If
                        If ValidarValor(dados.sexo) Then
                            cboSexo.SelectedValue = RetornarTexto(dados.sexo)
                        End If
                        If cboSituacao.Items.Count > 0 Then
                            cboSituacao.SelectedIndex = 0
                        End If
                        If ValidarValor(dados.situacao) Then
                            cboSituacao.SelectedValue = RetornarTexto(dados.situacao)
                        End If

                        ExibirFoto()
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try
    End Sub

    Private Sub btoCrediario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCrediario.Click
        CarregarCrediario()
    End Sub

    Private Sub btoCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCamera.Click
        CarregarCamera()
    End Sub

    Private Sub btoCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCheques.Click
        mdiPrincipal.CarregarCheques(txtNome.Text)
    End Sub

    Private Sub btoVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVendas.Click
        mdiPrincipal.CarregarVendas(txtNome.Text)
    End Sub

    Private Sub CarregarComboEstado()
        Dim regras As rEstado
        Dim colecao As ColecaoEstado

        Try

            cboEstado.Items.Clear()

            regras = New rEstado()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEstado())

                cboEstado.ValueMember = "cid"
                cboEstado.DisplayMember = "sigla"
                cboEstado.DataSource = colecao
                cboEstado.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Estados.")

        End Try
    End Sub


    Private Sub btoVeiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVeiculos.Click
        CarregarVeiculos()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btoContrato_Click(sender As Object, e As EventArgs) Handles btoContrato.Click
        CreatePDF()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLoadImage_Click(sender As Object, e As EventArgs) Handles btnLoadImage.Click
        CarregarFoto()
    End Sub
End Class