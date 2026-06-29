using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsProduto
{
    public class rProduto
    {
        private readonly IpProduto _repo;
        private readonly IpProdutoItem _repoItem;
        private readonly IpCaracteristica _repoCaracteristica;
        public dUsuario _usuario { get; set; }

        public rProduto(IpProduto repo, IpProdutoItem repoItem, IpCaracteristica repoCaracteristica)
        {
            _repo = repo;
            _repoItem = repoItem;
            _repoCaracteristica = repoCaracteristica;
        }

        public ColecaoProduto Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProduto Consultar(dProduto dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados)
        {
            try { return _repo.ConsultarGradeEntrada(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarGradeEntrada Produto [" + ToString() + "] - " + ex.Message); }
        }

        public dProduto Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dProduto { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarProximoCID()
        {
            try { return _repo.ConsultarProximoCID(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProduto dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dProduto dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                _usuario = usuario;
                int retorno;
                using (var ts = new TransactionScope())
                {
                    retorno = _repo.Incluir(dados);
                    if (retorno <= 0) throw new Exception("Inclusão do produto não retornou CID.");

                    if (colecaoItem != null && colecaoItem.Count > 0)
                    {
                        _repoItem.ExcluirPorProduto(new dProdutoItem { produtos_cid = retorno });
                        cLog.GravarLog(usuario.usuario, "Exclusão dos itens do produto cid[" + retorno + "] - rProduto.Incluir");

                        foreach (ColecaoProdutoItem itemColecao in colecaoItem)
                        {
                            string codigoBarras = string.Empty;
                            string estoque = string.Empty;

                            foreach (var item in itemColecao)
                            {
                                if (item.caracteristicas_codigo?.Trim().ToLower() == "estoquenovo") continue;

                                var caract = _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })?.Count > 0
                                    ? _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })[0]
                                    : throw new Exception("Característica não encontrada: " + item.caracteristicas_codigo);

                                item.caracteristicas_cid = caract.cid;

                                if (caract.codigo?.ToLower() == "codigobarras" && string.IsNullOrEmpty(item.valor))
                                {
                                    string novoCB = _repoItem.ConsultarUltimoCodigoBarras();
                                    item.valor = cFuncoes.ObterCodigoBarrasProduto(novoCB);
                                }

                                item.produtos_cid = retorno;
                                _repoItem.Incluir(item);

                                if (caract.codigo?.ToLower() == "codigobarras") codigoBarras = item.valor ?? string.Empty;
                                if (caract.codigo?.ToLower() == "estoque") estoque = item.valor ?? string.Empty;

                                if (!string.IsNullOrEmpty(codigoBarras) && !string.IsNullOrEmpty(estoque))
                                {
                                    cLog.GravarLogEstoque(usuario.cid ?? 0, usuario.nomeCompleto, item.produtos_cid ?? 0,
                                        codigoBarras, Convert.ToInt32(estoque), dados.notaFiscalNumero, dados.notaFiscalSerie);
                                    cLog.GravarLog(usuario.usuario, "Inclusão de novo item - codigoBarras[" + codigoBarras + "] - rProduto.Incluir");
                                    codigoBarras = string.Empty;
                                    estoque = string.Empty;
                                }
                            }
                        }
                    }
                    ts.Complete();
                }
                return retorno;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dProduto dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                _usuario = usuario;
                int retorno;
                using (var ts = new TransactionScope())
                {
                    retorno = _repo.Alterar(dados);

                    _repoItem.ExcluirPorProduto(new dProdutoItem { produtos_cid = dados.cid });
                    cLog.GravarLog(usuario.usuario, "Exclusão dos itens do produto cid[" + dados.cid + "] - rProduto.Alterar");

                    if (colecaoItem != null && colecaoItem.Count > 0)
                    {
                        // Primeira passagem: itens com codigoBarras existente
                        foreach (ColecaoProdutoItem itemColecao in colecaoItem)
                        {
                            bool temCodigoBarras = false;
                            foreach (var item in itemColecao)
                            {
                                if (item.caracteristicas_codigo?.ToLower() == "estoquenovo") continue;
                                var caract = _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })?.Count > 0
                                    ? _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })[0]
                                    : throw new Exception("Característica não encontrada: " + item.caracteristicas_codigo);
                                item.caracteristicas_cid = caract.cid;
                                if (caract.codigo?.ToLower() == "codigobarras" && !string.IsNullOrEmpty(item.valor))
                                { temCodigoBarras = true; break; }
                            }
                            if (!temCodigoBarras) continue;
                            foreach (var item in itemColecao)
                            {
                                if (item.caracteristicas_codigo?.ToLower() == "estoquenovo") continue;
                                var caract = _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })[0];
                                item.caracteristicas_cid = caract.cid;
                                _repoItem.Incluir(item);
                                if (caract.codigo?.ToLower() == "codigobarras")
                                    cLog.GravarLog(usuario.usuario, "Inclusão de item existente - codigobarras[" + item.valor + "] - rProduto.Alterar");
                            }
                        }

                        // Segunda passagem: itens sem codigoBarras (novos)
                        foreach (ColecaoProdutoItem itemColecao in colecaoItem)
                        {
                            bool semCodigoBarras = false;
                            foreach (var item in itemColecao)
                            {
                                if (item.caracteristicas_codigo?.ToLower() == "estoquenovo") continue;
                                var caract = _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })?.Count > 0
                                    ? _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })[0]
                                    : throw new Exception("Característica não encontrada: " + item.caracteristicas_codigo);
                                item.caracteristicas_cid = caract.cid;
                                if (caract.codigo?.ToLower() == "codigobarras" && string.IsNullOrEmpty(item.valor))
                                { semCodigoBarras = true; break; }
                            }
                            if (!semCodigoBarras) continue;

                            string _codigoBarras = string.Empty, _estoque = string.Empty;
                            int? _produtos_cid = null;

                            foreach (var item in itemColecao)
                            {
                                if (item.caracteristicas_codigo?.ToLower() == "estoquenovo")
                                {
                                    if (!string.IsNullOrEmpty(item.valor?.ToString())) _estoque = item.valor;
                                    continue;
                                }
                                var caract = _repoCaracteristica.Consultar(new dCaracteristica { codigo = item.caracteristicas_codigo })[0];
                                item.caracteristicas_cid = caract.cid;

                                if (caract.codigo?.ToLower() == "codigobarras")
                                {
                                    string novoCB = cFuncoes.ObterCodigoBarrasProduto(_repoItem.ConsultarUltimoCodigoBarras());
                                    item.valor = novoCB;
                                    _repoItem.Incluir(item);
                                    cLog.GravarLog(usuario.usuario, "Inclusão de novo item - codigobarras[" + novoCB + "] - rProduto.Alterar");
                                    _codigoBarras = novoCB;
                                }
                                else
                                {
                                    _repoItem.Incluir(item);
                                }
                                _produtos_cid = item.produtos_cid;
                            }

                            if (!string.IsNullOrEmpty(_codigoBarras) && !string.IsNullOrEmpty(_estoque) && _produtos_cid.HasValue)
                            {
                                if (Convert.ToInt32(_estoque) > 0)
                                    cLog.GravarLogEstoque(usuario.cid ?? 0, usuario.nomeCompleto, _produtos_cid.Value,
                                        _codigoBarras, Convert.ToInt32(_estoque), dados.notaFiscalNumero, dados.notaFiscalSerie);
                            }
                        }
                    }
                    ts.Complete();
                }
                return retorno;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dProduto dados, dUsuario usuario)
        {
            try
            {
                int retorno;
                using (var ts = new TransactionScope())
                {
                    _repoItem.ExcluirPorProduto(new dProdutoItem { produtos_cid = dados.cid });
                    cLog.GravarLog(usuario.usuario, "Exclusão de itens de produto - " + dados.descricao + " referência: " + dados.referencia);
                    retorno = _repo.Excluir(dados);
                    cLog.GravarLog(usuario.usuario, "Exclusão de produto - " + dados.descricao + " referência: " + dados.referencia);
                    ts.Complete();
                }
                return retorno;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Produto [" + ToString() + "] - " + ex.Message); }
        }
    }
}
