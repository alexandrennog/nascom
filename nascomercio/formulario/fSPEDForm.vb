Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao
Imports ncRegras.nsEFD
Imports ncDados.nsEFD
Imports ncRegras.nsEstado
Imports ncDados.nsEstado
Imports ncRegras.nsMunicipios
Imports ncDados.nsMunicipios
Imports ncRegras.nsNotaFiscalFornecedor
Imports ncDados.nsNotaFiscalFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFornecedor
Imports ncRegras.nsRegras
Imports ncEfd.nsEfd

Public Class fSPEDForm

    Private arquivo As IO.StreamWriter = Nothing
    Private gEfdArquivo As dEfdArquivo
    Private gEfdEntidade As dEfdEntidade
    Private gEfdEnderecoContato As dEfdEnderecoContato
    Private gEfdContabilidade As dEfdContabilidade
    Private gColecaoEfdItem As ColecaoEfdItem
    Private gColecaoEfdInventario As ColecaoEfdItem
    Private gColecaoUnidadeMedida As ColecaoEfdUnidadeMedida
    Private gColecaoRegistros As ColecaoRegistro
    Private gColecaoNFFornecedor As ColecaoNotaFiscalFornecedor
    Private gColecaoFornecedor As ColecaoFornecedor
    Private gColecaoC190 As ColC190

    Const cNaoInformar As String = ""

    Private Sub fSPEDForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    mdiPrincipal.FecharTela()
                End If
        End Select
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            mdiPrincipal.FecharTela()
        End If
    End Sub

    Private Sub fSPEDForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CarregarDadosBase()
        CarregarInformacoes()

    End Sub

    Private Sub CarregarInformacoes()

        CarregarInfoArquivo()
        CarregarInfoEntidade()
        CarregarInfoEnderecoContato()
        CarregarInfoContabilidade()
        CarregarInfoUnidadeMedida()

    End Sub

    Private Sub CarregarDadosBase()

        CarregarFinalidadeArquivo()
        CarregarPerfilArquivoFiscal()
        CarregarTipoAtividade()
        CarregarTipoPessoa()
        CarregarEstado()
        CarregarMunicipios()
        CarregarEstadoContabilidade()
        CarregarMunicipiosContabilidade()

    End Sub

    Private Sub CarregarInfoArquivo()
        Dim _dArquivo As dEfdArquivo
        Dim _rArquivo As rEfdArquivo

        Try
            _rArquivo = New rEfdArquivo
            _dArquivo = _rArquivo.Consultar()

            If _dArquivo IsNot Nothing Then
                txtVersaoLeiaute.Text = TratarTexto(_dArquivo.versaoLeiaute)
                cboFinalidadeArquivo.SelectedValue = TratarTexto(_dArquivo.finalidadeArquivo)
                cboPerfilArquivoFiscal.SelectedValue = TratarTexto(_dArquivo.perfilArquivoFiscal)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Arquivo.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CarregarInfoEntidade()
        Dim _dEntidade As dEfdEntidade
        Dim _rEntidade As rEfdEntidade

        Try
            _rEntidade = New rEfdEntidade
            _dEntidade = _rEntidade.Consultar()

            If _dEntidade IsNot Nothing Then
                txtNomeEmpresarial.Text = TratarTexto(_dEntidade.nomeEmpresarial)
                cboTipoPessoa.SelectedValue = TratarTexto(_dEntidade.tipoPessoa)
                txtCpfCnpj.Text = TratarTexto(_dEntidade.cpfCnpj)

                If cboUF.Items.Count > 0 Then
                    cboUF.SelectedIndex = 0
                    If ValidarValor(_dEntidade.estados_cid) Then
                        cboUF.SelectedValue = TratarInteiro(_dEntidade.estados_cid)
                    End If
                End If

                CarregarMunicipios()

                txtInscricaoEstadual.Text = TratarTexto(_dEntidade.inscricaoEstadual)
                If cboMunicipio.Items.Count > 0 Then
                    cboMunicipio.SelectedIndex = 0
                    If ValidarValor(_dEntidade.codigoMunicipio) Then
                        cboMunicipio.SelectedValue = TratarInteiro(_dEntidade.codigoMunicipio)
                    End If
                End If
                txtInscricaoMunicipal.Text = TratarTexto(_dEntidade.inscricaoMunicipal)
                txtInscricaoSuframa.Text = TratarTexto(_dEntidade.inscricaoSuframa)
                cboTipoAtividade.SelectedValue = TratarTexto(_dEntidade.tipoAtividade)
                txtNomeFantasia.Text = TratarTexto(_dEntidade.nomeFantasia)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Entidade.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CarregarInfoEnderecoContato()
        Dim _dEnderecoContato As dEfdEnderecoContato
        Dim _rEnderecoContato As rEfdEnderecoContato

        Try
            _rEnderecoContato = New rEfdEnderecoContato
            _dEnderecoContato = _rEnderecoContato.Consultar()

            If _dEnderecoContato IsNot Nothing Then
                txtLogradouro.Text = TratarTexto(_dEnderecoContato.logradouro)
                txtNumero.Text = TratarTexto(_dEnderecoContato.numero)
                txtComplemento.Text = TratarTexto(_dEnderecoContato.complemento)
                txtBairro.Text = TratarTexto(_dEnderecoContato.bairro)
                txtCEP.Text = TratarTexto(_dEnderecoContato.cep)
                txtDDDTelefone.Text = TratarTexto(_dEnderecoContato.dddTelefone)
                txtDDDFax.Text = TratarTexto(_dEnderecoContato.dddFax)
                txtEMail.Text = TratarTexto(_dEnderecoContato.email)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de EnderecoContato.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CarregarInfoContabilidade()
        Dim _dContabilidade As dEfdContabilidade
        Dim _rContabilidade As rEfdContabilidade

        Try
            _rContabilidade = New rEfdContabilidade
            _dContabilidade = _rContabilidade.Consultar()

            If _dContabilidade IsNot Nothing Then
                txtNomeContador.Text = TratarTexto(_dContabilidade.nomeContador)
                txtCPFContador.Text = TratarTexto(_dContabilidade.cpf)
                txtCRCContador.Text = TratarTexto(_dContabilidade.crc)
                txtCNPJContabilidade.Text = TratarTexto(_dContabilidade.cnpjEscritorio)

                If cboUfContabilidade.Items.Count > 0 Then
                    cboUfContabilidade.SelectedIndex = 0
                    If ValidarValor(_dContabilidade.estados_cid) Then
                        cboUfContabilidade.SelectedValue = TratarInteiro(_dContabilidade.estados_cid)
                    End If
                End If

                CarregarMunicipiosContabilidade()

                txtLogradouroContabilidade.Text = TratarTexto(_dContabilidade.logradouro)
                txtNumeroContabilidade.Text = TratarTexto(_dContabilidade.numero)
                txtComplementoContabilidade.Text = TratarTexto(_dContabilidade.complemento)
                txtBairroContabilidade.Text = TratarTexto(_dContabilidade.bairro)

                If cboMunicipioContabilidade.Items.Count > 0 Then
                    cboMunicipioContabilidade.SelectedIndex = 0
                    If ValidarValor(_dContabilidade.municipio) Then
                        cboMunicipioContabilidade.SelectedValue = TratarInteiro(_dContabilidade.municipio)
                    End If
                End If

                txtCEPContabilidade.Text = TratarTexto(_dContabilidade.cep)
                txtDDDTelefoneContabilidade.Text = TratarTexto(_dContabilidade.dddTelefone)
                txtDDDFaxContabilidade.Text = TratarTexto(_dContabilidade.dddFax)
                txtEMailContabilidade.Text = TratarTexto(_dContabilidade.email)
                txtContaAnaliticaContabil.Text = TratarTexto(_dContabilidade.contaAnaliticaContabil)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Contabilidade.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CarregarInfoUnidadeMedida()
        Dim _colecao As ColecaoEfdUnidadeMedida
        Dim _rUnidadeMedida As rEfdUnidadeMedida

        Try
            _rUnidadeMedida = New rEfdUnidadeMedida
            _colecao = _rUnidadeMedida.Listar()

            If ((_colecao IsNot Nothing) AndAlso (_colecao.Count > 0)) Then
                grdUnidadeMedida.DataSource = _colecao
            End If

        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de UnidadeMedida.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CarregarEstado()
        Dim _rEstado As rEstado
        Dim colecao As ColecaoEstado

        Try

            cboUF.Items.Clear()

            _rEstado = New rEstado()
            colecao = _rEstado.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEstado())

                cboUF.ValueMember = "cid"
                cboUF.DisplayMember = "nome"
                cboUF.DataSource = colecao
                cboUF.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Estado.")

        End Try

    End Sub

    Private Sub CarregarEstadoContabilidade()
        Dim _rEstado As rEstado
        Dim colecao As ColecaoEstado

        Try

            cboUfContabilidade.Items.Clear()

            _rEstado = New rEstado()
            colecao = _rEstado.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEstado())

                cboUfContabilidade.ValueMember = "cid"
                cboUfContabilidade.DisplayMember = "nome"
                cboUfContabilidade.DataSource = colecao
                cboUfContabilidade.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Estado.")

        End Try

    End Sub

    Private Sub CarregarMunicipios()
        Dim _rMunicipios As rMunicipios
        Dim colecao As ColecaoMunicipios
        Dim codigo As Integer

        Try

            cboMunicipio.DataSource = Nothing
            cboMunicipio.Items.Clear()

            If cboUF.Items.Count > 0 Then
                If cboUF.SelectedValue IsNot Nothing Then
                    If Not String.IsNullOrEmpty(cboUF.SelectedValue.ToString()) Then

                        codigo = Convert.ToInt32(cboUF.SelectedValue)

                        _rMunicipios = New rMunicipios()
                        colecao = _rMunicipios.ListarPorEstados(codigo)

                        If Not colecao Is Nothing Then
                            colecao.Insert(0, New dMunicipios())

                            cboMunicipio.ValueMember = "cid"
                            cboMunicipio.DisplayMember = "nome"
                            cboMunicipio.DataSource = colecao
                            cboMunicipio.Refresh()
                        End If

                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Municipio.")

        End Try

    End Sub

    Private Sub CarregarMunicipiosContabilidade()
        Dim _rMunicipios As rMunicipios
        Dim colecao As ColecaoMunicipios
        Dim codigo As Integer

        Try

            cboMunicipioContabilidade.DataSource = Nothing
            cboMunicipioContabilidade.Items.Clear()

            If cboUfContabilidade.Items.Count > 0 Then
                If cboUfContabilidade.SelectedValue IsNot Nothing Then
                    If Not String.IsNullOrEmpty(cboUfContabilidade.SelectedValue.ToString()) Then

                        codigo = Convert.ToInt32(cboUfContabilidade.SelectedValue)

                        _rMunicipios = New rMunicipios()
                        colecao = _rMunicipios.ListarPorEstados(codigo)

                        If Not colecao Is Nothing Then
                            colecao.Insert(0, New dMunicipios())

                            cboMunicipioContabilidade.ValueMember = "cid"
                            cboMunicipioContabilidade.DisplayMember = "nome"
                            cboMunicipioContabilidade.DataSource = colecao
                            cboMunicipioContabilidade.Refresh()
                        End If

                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Municipio.")

        End Try

    End Sub

    Private Sub CarregarTipoPessoa()
        Dim _rEfdTipoPessoa As rEfdTipoPessoa
        Dim colecao As ColecaoEfdTipoPessoa

        Try

            cboTipoPessoa.Items.Clear()

            _rEfdTipoPessoa = New rEfdTipoPessoa()
            colecao = _rEfdTipoPessoa.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEfdTipoPessoa())

                cboTipoPessoa.ValueMember = "codigo"
                cboTipoPessoa.DisplayMember = "descricao"
                cboTipoPessoa.DataSource = colecao
                cboTipoPessoa.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoPessoa.")

        End Try

    End Sub

    Private Sub CarregarFinalidadeArquivo()
        Dim _rEfdFinalidadeArquivo As rEfdFinalidadeArquivo
        Dim colecao As ColecaoEfdFinalidadeArquivo

        Try

            cboFinalidadeArquivo.Items.Clear()

            _rEfdFinalidadeArquivo = New rEfdFinalidadeArquivo()
            colecao = _rEfdFinalidadeArquivo.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEfdFinalidadeArquivo())

                cboFinalidadeArquivo.ValueMember = "codigo"
                cboFinalidadeArquivo.DisplayMember = "descricao"
                cboFinalidadeArquivo.DataSource = colecao
                cboFinalidadeArquivo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de FinalidadeArquivo.")

        End Try

    End Sub

    Private Sub CarregarPerfilArquivoFiscal()
        Dim _rEfdPerfilArquivoFiscal As rEfdPerfilArquivoFiscal
        Dim colecao As ColecaoEfdPerfilArquivoFiscal

        Try

            cboPerfilArquivoFiscal.Items.Clear()

            _rEfdPerfilArquivoFiscal = New rEfdPerfilArquivoFiscal()
            colecao = _rEfdPerfilArquivoFiscal.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEfdPerfilArquivoFiscal())

                cboPerfilArquivoFiscal.ValueMember = "codigo"
                cboPerfilArquivoFiscal.DisplayMember = "descricao"
                cboPerfilArquivoFiscal.DataSource = colecao
                cboPerfilArquivoFiscal.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de PerfilArquivoFiscal.")

        End Try

    End Sub

    Private Sub CarregarTipoAtividade()
        Dim _rEfdTipoAtividade As rEfdTipoAtividade
        Dim colecao As ColecaoEfdTipoAtividade

        Try

            cboTipoAtividade.Items.Clear()

            _rEfdTipoAtividade = New rEfdTipoAtividade()
            colecao = _rEfdTipoAtividade.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dEfdTipoAtividade())

                cboTipoAtividade.ValueMember = "codigo"
                cboTipoAtividade.DisplayMember = "descricao"
                cboTipoAtividade.DataSource = colecao
                cboTipoAtividade.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoAtividade.")

        End Try

    End Sub

    Private Sub btoSalvarArquivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvarArquivo.Click
        Dim _dArquivo As dEfdArquivo
        Dim _rArquivo As rEfdArquivo

        Try

            _dArquivo = New dEfdArquivo
            _rArquivo = New rEfdArquivo

            _dArquivo.versaoLeiaute = TratarTexto(txtVersaoLeiaute.Text)
            _dArquivo.finalidadeArquivo = TratarTexto(cboFinalidadeArquivo.SelectedValue)
            _dArquivo.perfilArquivoFiscal = TratarTexto(cboPerfilArquivoFiscal.SelectedValue)

            _rArquivo.Salvar(_dArquivo)

            MessageBox.Show("Leiaute salvo")

        Catch ex As Exception
            MessageBox.Show("Erro na gravação dos dados de Arquivo.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoSalvarEntidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvarEntidade.Click
        Dim _dEntidade As dEfdEntidade
        Dim _rEntidade As rEfdEntidade

        Try

            _dEntidade = New dEfdEntidade
            _rEntidade = New rEfdEntidade

            _dEntidade.nomeEmpresarial = TratarTexto(txtNomeEmpresarial.Text)
            _dEntidade.tipoPessoa = TratarTexto(cboTipoPessoa.SelectedValue)
            _dEntidade.cpfCnpj = TratarTexto(txtCpfCnpj.Text)
            _dEntidade.estados_cid = TratarInteiro(cboUF.SelectedValue)
            _dEntidade.inscricaoEstadual = TratarTexto(txtInscricaoEstadual.Text)
            _dEntidade.codigoMunicipio = TratarTexto(cboMunicipio.SelectedValue)
            _dEntidade.inscricaoMunicipal = TratarTexto(txtInscricaoMunicipal.Text)
            _dEntidade.inscricaoSuframa = TratarTexto(txtInscricaoSuframa.Text)
            _dEntidade.tipoAtividade = TratarTexto(cboTipoAtividade.SelectedValue)
            _dEntidade.nomeFantasia = TratarTexto(txtNomeFantasia.Text)

            _rEntidade.Salvar(_dEntidade)

            MessageBox.Show("Entidade salva")

        Catch ex As Exception
            MessageBox.Show("Erro na gravação dos dados de Entidade.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoSalvarEnderecoContato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvarEnderecoContato.Click
        Dim _dEnderecoContato As dEfdEnderecoContato
        Dim _rEnderecoContato As rEfdEnderecoContato

        Try

            _dEnderecoContato = New dEfdEnderecoContato
            _rEnderecoContato = New rEfdEnderecoContato

            _dEnderecoContato.logradouro = TratarTexto(txtLogradouro.Text)
            _dEnderecoContato.numero = TratarTexto(txtNumero.Text)
            _dEnderecoContato.complemento = TratarTexto(txtComplemento.Text)
            _dEnderecoContato.bairro = TratarTexto(txtBairro.Text)
            _dEnderecoContato.cep = TratarTexto(txtCEP.Text)
            _dEnderecoContato.dddTelefone = TratarTexto(txtDDDTelefone.Text)
            _dEnderecoContato.dddFax = TratarTexto(txtDDDFax.Text)
            _dEnderecoContato.email = TratarTexto(txtEMail.Text)

            _rEnderecoContato.Salvar(_dEnderecoContato)

            MessageBox.Show("Endereço salvo")

        Catch ex As Exception
            MessageBox.Show("Erro na gravação dos dados de EnderecoContato.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoIncluirUnidadeMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirUnidadeMedida.Click
        Dim _dUnidadeMedida As dEfdUnidadeMedida
        Dim _rUnidadeMedida As rEfdUnidadeMedida

        Try
            _dUnidadeMedida = New dEfdUnidadeMedida()
            _rUnidadeMedida = New rEfdUnidadeMedida()

            _dUnidadeMedida.codigo = TratarTexto(txtCodigoUnidadeMedida.Text)

            _dUnidadeMedida = _rUnidadeMedida.Consultar(_dUnidadeMedida)

            If _dUnidadeMedida Is Nothing Then
                _dUnidadeMedida = New dEfdUnidadeMedida()

                _dUnidadeMedida.codigo = TratarTexto(txtCodigoUnidadeMedida.Text)
                _dUnidadeMedida.descricao = TratarTexto(txtDescricaoUnidadeMedida.Text)

                _rUnidadeMedida.Salvar(_dUnidadeMedida)

                CarregarInfoUnidadeMedida()
            Else
                MessageBox.Show("Código já cadastrado.", "EFD", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro na gravação dos dados de UnidadeMedida.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoSalvarContabilidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvarContabilidade.Click
        Dim _dContabilidade As dEfdContabilidade
        Dim _rContabilidade As rEfdContabilidade

        Try

            _dContabilidade = New dEfdContabilidade
            _rContabilidade = New rEfdContabilidade

            _dContabilidade.nomeContador = TratarTexto(txtNomeContador.Text)
            _dContabilidade.cpf = TratarTexto(txtCPFContador.Text)
            _dContabilidade.crc = TratarTexto(txtCRCContador.Text)
            _dContabilidade.cnpjEscritorio = TratarTexto(txtCNPJContabilidade.Text)
            _dContabilidade.logradouro = TratarTexto(txtLogradouroContabilidade.Text)
            _dContabilidade.numero = TratarTexto(txtNumeroContabilidade.Text)
            _dContabilidade.complemento = TratarTexto(txtComplementoContabilidade.Text)
            _dContabilidade.bairro = TratarTexto(txtBairroContabilidade.Text)

            _dContabilidade.estados_cid = TratarInteiro(cboUfContabilidade.SelectedValue)
            _dContabilidade.municipio = TratarTexto(cboMunicipioContabilidade.SelectedValue)
            _dContabilidade.cep = TratarTexto(txtCEPContabilidade.Text)
            _dContabilidade.dddTelefone = TratarTexto(txtDDDTelefoneContabilidade.Text)
            _dContabilidade.dddFax = TratarTexto(txtDDDFaxContabilidade.Text)
            _dContabilidade.email = TratarTexto(txtEMailContabilidade.Text)
            _dContabilidade.contaAnaliticaContabil = TratarTexto(txtContaAnaliticaContabil.Text)

            _rContabilidade.Salvar(_dContabilidade)

            MessageBox.Show("Contabilidade salva")

        Catch ex As Exception
            MessageBox.Show("Erro na gravação dos dados de Contabilidade.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoExcluirUnidadeMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirUnidadeMedida.Click
        Dim linha As Integer
        Dim codigo As String
        Dim _d As dEfdUnidadeMedida
        Dim _r As rEfdUnidadeMedida

        Try
            _d = New dEfdUnidadeMedida()
            _r = New rEfdUnidadeMedida()

            If grdUnidadeMedida.Rows.Count > 0 Then

                linha = grdUnidadeMedida.CurrentRow.Index

                If linha >= 0 Then
                    codigo = grdUnidadeMedida.CurrentRow.Cells(0).Value.ToString()

                    _d.codigo = TratarTexto(codigo)

                    _r.Excluir(_d)
                End If
            End If

            CarregarInfoUnidadeMedida()
        Catch ex As Exception
            MessageBox.Show("Erro na exclusão dos dados de Unidade de Medida.", "EFD", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btoGerarEFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoGerarEFD.Click
        GerarArquivo()
    End Sub

    Private Sub GerarArquivo()
        Dim dataAtual As Date = DateTime.Now
        Dim data As String = dataAtual.Day.ToString() + "/" + dataAtual.Month.ToString() + "/" + dataAtual.Year.ToString()
        Dim arquivoNome As String = System.IO.Directory.GetCurrentDirectory() + "\arquivos_sped\sped_" + FormatarDataUniversal(data) + ".txt"
        Dim _dArquivo As dArquivo = New dArquivo()
        Dim _rArquivo As rArquivo = New rArquivo()
        Dim linha As String

        Dim _tipoEmissao As String
        Dim _tipoFluxo As String
        Dim _tipoFrete As String
        Dim _tipoNF As String
        Dim _tipoPagto As String
        Dim _situacaoNF As String
        Dim _rTipoEmissao As rTipoEmissao = New rTipoEmissao()
        Dim _rTipoFluxo As rTipoFluxo = New rTipoFluxo()
        Dim _rTipoFrete As rTipoFrete = New rTipoFrete()
        Dim _rTipoNF As rTipoNotaFiscal = New rTipoNotaFiscal()
        Dim _rTipoPagto As rTipoPagamento = New rTipoPagamento()
        Dim _rSituacaoNF As rSituacaoNotaFiscal = New rSituacaoNotaFiscal()

        _dArquivo = _rArquivo.MontarRelatorio(dtInicio.Value, dtFim.Value)

        arquivo = New System.IO.StreamWriter(arquivoNome)

        '-- Registro 0000 -- ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
        If _dArquivo.reg0000 IsNot Nothing Then
            linha = "|" & RetornarTexto(_dArquivo.reg0000.reg, 4) & "|" & _
              RetornarTexto(_dArquivo.reg0000.cod_ver, 3) & "|" & _
              RetornarTexto(_dArquivo.reg0000.cod_fin, 1) & "|" & _
              FormatarDataDDMMAAAA(_dArquivo.reg0000.dt_ini) & "|" & _
              FormatarDataDDMMAAAA(_dArquivo.reg0000.dt_fin) & "|" & _
              RetornarTexto(_dArquivo.reg0000.nome, 100) & "|"
            If _dArquivo.reg0000.tipoPessoa = "J" Then
                linha = linha & RetornarTexto(_dArquivo.reg0000.cnpj, 14) & "||"
            ElseIf _dArquivo.reg0000.tipoPessoa = "F" Then
                linha = linha & "|" & RetornarTexto(_dArquivo.reg0000.cpf, 11) & "|"
            End If
            linha = linha & _
                RetornarTexto(_dArquivo.reg0000.uf, 2) & "|" & _
                RetornarTexto(_dArquivo.reg0000.ie, 14) & "|" & _
                RetornarTexto(_dArquivo.reg0000.cod_mun, 7) & "|" & _
                RetornarTexto(_dArquivo.reg0000.im) & "|" & _
                RetornarTexto(_dArquivo.reg0000.suframa, 9) & "|" & _
                RetornarTexto(_dArquivo.reg0000.ind_perfil, 1) & "|" & _
                RetornarTexto(_dArquivo.reg0000.ind_ativ, 1) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro 0001 -- ABERTURA DO BLOCO 0
        If _dArquivo.reg0001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg0001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg0001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro 0005 -- DADOS COMPLEMENTARES DA ENTIDADE
        If _dArquivo.reg0005 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg0005.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg0005.fantasia, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0005.cep, 8) & "|" & _
                RetornarTexto(_dArquivo.reg0005.ende, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0005.num, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0005.compl, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0005.bairro, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0005.fone, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0005.fax, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0005.email) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro 0100 -- DADOS DO CONTABILISTA
        If _dArquivo.reg0100 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg0100.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg0100.nome, 100) & "|" & _
                RetornarTexto(_dArquivo.reg0100.cpf, 11) & "|" & _
                RetornarTexto(_dArquivo.reg0100.crc, 15) & "|" & _
                RetornarTexto(_dArquivo.reg0100.cnpj, 14) & "|" & _
                RetornarTexto(_dArquivo.reg0100.cep, 8) & "|" & _
                RetornarTexto(_dArquivo.reg0100.ende, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0100.num, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0100.compl, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0100.bairro, 60) & "|" & _
                RetornarTexto(_dArquivo.reg0100.fone, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0100.fax, 10) & "|" & _
                RetornarTexto(_dArquivo.reg0100.email) & "|" & _
                RetornarTexto(_dArquivo.reg0100.cod_mun, 7) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro 0150 -- TABELA DE CADASTRO DO PARTICIPANTE
        '-- 1058 = Brasil
        If _dArquivo.col0150 IsNot Nothing Then
            For Each item As dReg0150 In _dArquivo.col0150
                linha = "|" & _
                    RetornarTexto(item.reg) & "|" & _
                    RetornarTexto(item.cod_part) & "|" & _
                    RetornarTexto(item.nome) & "|" & _
                    "1058|" & _
                    RetornarTexto(item.cnpj) & "|" & _
                    RetornarTexto(item.cpf) & "|" & _
                    RetornarTexto(item.ie) & "|" & _
                    RetornarTexto(item.cod_mun) & "|" & _
                    RetornarTexto(item.suframa) & "|" & _
                    RetornarTexto(item.ende) & "|" & _
                    RetornarTexto(item.num) & "|" & _
                    RetornarTexto(item.compl) & "|" & _
                    RetornarTexto(item.bairro) & "|"
                arquivo.WriteLine(linha)
            Next
        End If

        '-- Registro 0190 -- IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
        If _dArquivo.col0190 IsNot Nothing Then
            For Each item As dReg0190 In _dArquivo.col0190
                linha = "|" & _
                    RetornarTexto(item.reg, 4) & "|" & _
                    RetornarTexto(item.unid, 6) & "|" & _
                    RetornarTexto(item.descr) & "|"
                arquivo.WriteLine(linha)
            Next
        End If

        '-- Registro 0200 -- TABELA DE IDENTIFICAÇÃO DO ITEM (PRODUTO E SERVIÇOS)
        If _dArquivo.col0200 IsNot Nothing Then
            For Each item As dReg0200 In _dArquivo.col0200
                linha = "|" & _
                    RetornarTexto(item.reg, 4) & "|" & _
                    RetornarTexto(item.cod_item, 60) & "|" & _
                    RetornarTexto(item.descr_item) & "|" & _
                    RetornarTexto(item.cod_barra) & "|" & _
                    RetornarTexto(item.cod_ant_item, 60) & "|" & _
                    RetornarTexto(item.unid_inv, 6) & "|" & _
                    RetornarTexto(item.tipo_item) & "|" & _
                    RetornarTexto(item.cod_ncm, 8) & "|" & _
                    RetornarTexto(item.ex_ipi, 3) & "|" & _
                    RetornarTexto(item.cod_gen) & "|" & _
                    RetornarTexto(item.cod_lst) & "|" & _
                    RetornarTexto(item.aliq_icms) & "|"
                arquivo.WriteLine(linha)
            Next
        End If

        '-- Registro 0990 -- ENCERRAMENTO DO BLOCO 0
        If _dArquivo.reg0990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg0990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg0990.qtd_lin_0) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro C001 -- ABERTURA DO BLOCO C
        If _dArquivo.regC001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regC001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regC001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- Registro C100 -- NOTA FISCAL (CÓDIGO 01), NOTA FISCAL AVULSA (CÓDIGO 1B), NOTA FISCAL DE PRODUTOR (CÓDIGO 04) E NF-e (CÓDIGO 55).
        If _dArquivo.colC100 IsNot Nothing Then
            For Each item As dRegC100 In _dArquivo.colC100
                _tipoEmissao = ""
                _tipoFluxo = ""
                _tipoFrete = ""
                _tipoNF = ""
                _tipoPagto = ""
                _situacaoNF = ""

                If Not item.tipoFluxo.Equals(Nothing) Then
                    item.ind_oper = _rTipoFluxo.RetornarCodigo(item.tipoFluxo)
                End If
                If Not item.tipoEmissao.Equals(Nothing) Then
                    item.ind_emit = _rTipoEmissao.RetornarCodigo(item.tipoEmissao)
                End If
                If Not item.tipoNF.Equals(Nothing) Then
                    item.cod_mod = _rTipoNF.RetornarCodigo(item.tipoNF)
                End If
                If Not item.situacaoNF.Equals(Nothing) Then
                    item.cod_sit = _rSituacaoNF.RetornarCodigo(item.situacaoNF)
                End If
                If Not item.tipoPagto.Equals(Nothing) Then
                    item.ind_pagto = _rTipoPagto.RetornarCodigo(item.tipoPagto)
                End If
                If Not item.tipoFrete.Equals(Nothing) Then
                    item.ind_frt = _rTipoFrete.RetornarCodigo(item.tipoFrete)
                End If

                linha = "|" & _
                    RetornarTexto(item.reg, 4) & "|" & _
                    RetornarTexto(item.ind_oper, 1) & "|" & _
                    RetornarTexto(item.ind_emit, 1) & "|" & _
                    RetornarTexto(item.cod_part, 60) & "|" & _
                    RetornarTexto(item.cod_mod, 2) & "|" & _
                    RetornarTexto(item.cod_sit) & "|" & _
                    RetornarTexto(item.ser, 3) & "|" & _
                    RetornarTexto(item.num_doc) & "|" & _
                    RetornarTexto(item.chv_nfe, 44) & "|" & _
                    RetornarTexto(FormatarDataDDMMAAAA(item.dt_doc), 8) & "|" & _
                    RetornarTexto(FormatarDataDDMMAAAA(item.dt_e_s), 8) & "|" & _
                    RetornarTexto(item.vl_doc) & "|" & _
                    RetornarTexto(item.ind_pagto, 1) & "|" & _
                    RetornarTexto(item.vl_desc) & "|" & _
                    RetornarTexto(item.vl_abat_nt) & "|" & _
                    RetornarTexto(item.vl_merc) & "|" & _
                    RetornarTexto(item.ind_frt, 1) & "|" & _
                    RetornarTexto(item.vl_frt) & "|" & _
                    RetornarTexto(item.vl_seg) & "|" & _
                    RetornarTexto(item.vl_out_da) & "|" & _
                    RetornarTexto(item.vl_bc_icms) & "|" & _
                    RetornarTexto(item.vl_icms) & "|" & _
                    RetornarTexto(item.vl_bc_icms_st) & "|" & _
                    RetornarTexto(item.vl_icms_st) & "|" & _
                    RetornarTexto(item.vl_ipi) & "|" & _
                    RetornarTexto(item.vl_pis) & "|" & _
                    RetornarTexto(item.vl_cofins) & "|" & _
                    RetornarTexto(item.vl_pis_st) & "|" & _
                    RetornarTexto(item.vl_cofins_st) & "|"

                arquivo.WriteLine(linha)
                '-- Registro C170 -- ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
                For Each itemNota As dRegC170 In _dArquivo.colC170
                    If item.num_doc = itemNota.num_doc Then
                        linha = "|" & _
                              RetornarTexto(itemNota.reg, 4) & "|" & _
                              RetornarTexto(itemNota.num_item) & "|" & _
                              RetornarTexto(itemNota.cod_item) & "|" & _
                              RetornarTexto(itemNota.descr_compl) & "|" & _
                              RetornarTexto(itemNota.qtd) & "|" & _
                              RetornarTexto(itemNota.unid) & "|" & _
                              RetornarTexto(itemNota.vl_item) & "|" & _
                              RetornarTexto(itemNota.vl_desc) & "|" & _
                              RetornarTexto(itemNota.ind_mov) & "|" & _
                              RetornarTexto(itemNota.cst_icms) & "|" & _
                              RetornarTexto(itemNota.cfop) & "|" & _
                              RetornarTexto(itemNota.cod_nat) & "|" & _
                              RetornarTexto(itemNota.vl_bc_icms) & "|" & _
                              RetornarTexto(itemNota.aliq_icms) & "|" & _
                              RetornarTexto(itemNota.vl_icms) & "|" & _
                              RetornarTexto(itemNota.vl_bc_icms_st) & "|" & _
                              RetornarTexto(itemNota.aliq_st) & "|" & _
                              RetornarTexto(itemNota.vl_icms_st) & "|" & _
                              RetornarTexto(itemNota.ind_apur) & "|" & _
                              RetornarTexto(itemNota.cst_ipi) & "|" & _
                              RetornarTexto(itemNota.cod_enq) & "|" & _
                              RetornarTexto(itemNota.vl_bc_ipi) & "|" & _
                              RetornarTexto(itemNota.aliq_ipi) & "|" & _
                              RetornarTexto(itemNota.vl_ipi) & "|" & _
                              RetornarTexto(itemNota.cst_pis) & "|" & _
                              RetornarTexto(itemNota.vl_bc_pis) & "|" & _
                              RetornarTexto(itemNota.aliq_pis) & "|" & _
                              RetornarTexto(itemNota.quant_bc_pis) & "|" & _
                              RetornarTexto(itemNota.aliq_pis_r) & "|" & _
                              RetornarTexto(itemNota.vl_pis) & "|" & _
                              RetornarTexto(itemNota.cst_cofins) & "|" & _
                              RetornarTexto(itemNota.vl_bc_cofins) & "|" & _
                              RetornarTexto(itemNota.aliq_cofins) & "|" & _
                              RetornarTexto(itemNota.quant_bc_cofins) & "|" & _
                              RetornarTexto(itemNota.aliq_cofins_r) & "|" & _
                              RetornarTexto(itemNota.vl_cofins) & "|" & _
                              RetornarTexto(itemNota.cod_cta) & "|"

                        arquivo.WriteLine(linha)
                    End If

                Next
            Next
        End If

        '-- Registro C190 -- REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 01, 1B, 04 E 55).
        If _dArquivo.regC190 IsNot Nothing Then
            linha = "|" & _
              RetornarTexto(_dArquivo.regC190.reg, 4) & "|" & _
              RetornarTexto(_dArquivo.regC190.cst_icms) & "|" & _
              RetornarTexto(_dArquivo.regC190.cfop) & "|" & _
              RetornarTexto(_dArquivo.regC190.aliq_icms) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_opr) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_bc_icms) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_icms) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_bc_icms_st) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_icms_st) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_red_bc) & "|" & _
              RetornarTexto(_dArquivo.regC190.vl_ipi) & "|" & _
              RetornarTexto(_dArquivo.regC190.cod_obs, 60) & "|"

            arquivo.WriteLine(linha)
        End If

        '-- Registro C990 -- ENCERRAMENTO DO BLOCO C
        If _dArquivo.regC990 IsNot Nothing Then
            linha = "|" & _
              RetornarTexto(_dArquivo.regC990.reg, 4) & "|" & _
              RetornarTexto(_dArquivo.regC990.qtd_lin_c) & "|"

            arquivo.WriteLine(linha)
        End If

        '-- REGISTRO D001: ABERTURA DO BLOCO D
        If _dArquivo.regD001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regD001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regD001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO D990: ENCERRAMENTO DO BLOCO D.
        If _dArquivo.regD990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regD990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regD990.qtd_lin_d) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO E001: ABERTURA DO BLOCO E
        If _dArquivo.regE001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regE001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regE001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS.
        If _dArquivo.regE100 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regE100.reg, 4) & "|" & _
                RetornarTexto(FormatarDataDDMMAAAA(_dArquivo.regE100.dt_ini), 8) & "|" & _
                RetornarTexto(FormatarDataDDMMAAAA(_dArquivo.regE100.dt_fin), 8) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS.
        If _dArquivo.regE110 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regE110.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_tot_debitos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_aj_debitos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_tot_aj_debitos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_estornos_cred) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_tot_creditos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_aj_creditos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_tot_aj_creditos) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_estornos_deb) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_sld_credor_ant) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_sld_apurado) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_tot_ded) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_icms_recolher) & "|" & _
                RetornarTexto(_dArquivo.regE110.vl_sld_credor_transportar) & "|" & _
                RetornarTexto(_dArquivo.regE110.deb_esp) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO E990: ENCERRAMENTO DO BLOCO E
        If _dArquivo.regE990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regE990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regE990.qtd_lin_e) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO G001: ABERTURA DO BLOCO G
        If _dArquivo.regG001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regG001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regG001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO G990: ENCERRAMENTO DO BLOCO G
        If _dArquivo.regG990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regG990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regG990.qtd_lin_g) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO H001: ABERTURA DO BLOCO H
        If _dArquivo.regH001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regH001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regH001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO H005: TOTAIS DO INVENTÁRIO
        If _dArquivo.regH005 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regH005.reg, 4) & "|" & _
                RetornarTexto(FormatarDataDDMMAAAA(_dArquivo.regH005.dt_inv), 8) & "|" & _
                RetornarTexto(_dArquivo.regH005.vl_inv) & "|"

            ' Novo campo a partir da versao 005 de layout
            If _dArquivo.reg0000.cod_ver > "005" Then
                linha += RetornarTexto(_dArquivo.regH005.mot_inv) & "|"
            End If

            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO H010: INVENTÁRIO.
        If _dArquivo.colH010 IsNot Nothing Then
            For Each item As dRegH010 In _dArquivo.colH010
                linha = "|" & _
                    RetornarTexto(item.reg, 4) & "|" & _
                    RetornarTexto(item.cod_item, 60) & "|" & _
                    RetornarTexto(item.unid, 6) & "|" & _
                    RetornarTexto(item.qtd) & "|" & _
                    RetornarTexto(item.vl_unit) & "|" & _
                    RetornarTexto(item.vl_item) & "|" & _
                    RetornarTexto(item.ind_prop, 1) & "|" & _
                    RetornarTexto(item.cod_part, 60) & "|" & _
                    RetornarTexto(item.txt_compl, 3) & "|" & _
                    RetornarTexto(item.cod_cta) & "|"

                If _dArquivo.reg0000.cod_ver = "009" Then
                    linha += RetornarTexto(item.vl_item_ir) & "|"
                End If
                arquivo.WriteLine(linha)
            Next
        End If

        ''-- REGISTRO H990: ENCERRAMENTO DO BLOCO H.
        If _dArquivo.regH990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.regH990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.regH990.qtd_lin_h) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO 1001: ABERTURA DO BLOCO 1
        If _dArquivo.reg1001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg1001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg1001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
        If _dArquivo.reg1010 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg1010.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_exp) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_ccrf) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_comb) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_usina) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_va) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_ee) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_cart) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_form) & "|" & _
                RetornarTexto(_dArquivo.reg1010.ind_aer) & "|"
            arquivo.WriteLine(linha)
        End If

        ''-- REGISTRO 1990: ENCERRAMENTO DO BLOCO 1
        If _dArquivo.reg1990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg1990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg1990.qtd_lin_1) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- REGISTRO 9001: ABERTURA DO BLOCO 9
        If _dArquivo.reg9001 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg9001.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg9001.ind_mov) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- REGISTRO 9900: REGISTROS DO ARQUIVO.
        If _dArquivo.col9900 IsNot Nothing Then
            For Each item As dReg9900 In _dArquivo.col9900
                linha = "|" & _
                    RetornarTexto(item.reg, 4) & "|" & _
                    RetornarTexto(item.reg_blc, 4) & "|" & _
                    RetornarTexto(item.qtd_reg_blc) & "|"
                arquivo.WriteLine(linha)
            Next
        End If

        '-- REGISTRO 9990: ENCERRAMENTO DO BLOCO 9
        If _dArquivo.reg9990 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg9990.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg9990.qtd_lin_9) & "|"
            arquivo.WriteLine(linha)
        End If

        '-- REGISTRO 9999: ENCERRAMENTO DO ARQUIVO DIGITAL.
        If _dArquivo.reg9999 IsNot Nothing Then
            linha = "|" & _
                RetornarTexto(_dArquivo.reg9999.reg, 4) & "|" & _
                RetornarTexto(_dArquivo.reg9999.qtd_lin) & "|"
            arquivo.WriteLine(linha)
        End If

        If arquivo IsNot Nothing Then
            arquivo.Close()
            arquivo.Dispose()
        End If

        MessageBox.Show("Arquivo criado com sucesso!", "Arquivo SPED", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cboUF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUF.SelectedIndexChanged
        CarregarMunicipios()
    End Sub

    Private Sub cboUfContabilidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUfContabilidade.SelectedIndexChanged
        CarregarMunicipiosContabilidade()
    End Sub

End Class