using System;
using System.Transactions;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos.nsCrediario
{
    public class rCrediario
    {
        private readonly IpCrediario _crediario;
        private readonly IpParcela _parcela;

        public rCrediario(IpCrediario crediario, IpParcela parcela)
        {
            _crediario = crediario;
            _parcela = parcela;
        }

        public ColecaoCrediario Listar()
        {
            try { return _crediario.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarMax()
        {
            try { return _crediario.ConsultarMax(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarMax Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCrediario Consultar(dCrediario dados)
        {
            try { return _crediario.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParcelas ConsultarParcelas(dParcelas dados)
        {
            try { return _parcela.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarParcelas Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParcelas ConsultarParcelasPagamentos(dParcelas dados)
        {
            try { return _parcela.ConsultarPagamentos(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarParcelasPagamentos Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public dParcelas ConsultarParcela(int cid)
        {
            try
            {
                var lista = _parcela.Consultar(new dParcelas { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarParcela Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParcelas ConsultarParcelasCliente(int codCliente)
        {
            try { return _parcela.ConsultarParcelasCliente(codCliente); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarParcelasCliente Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoParcelas ConsultarParcelasVencidas(int codCliente)
        {
            try { return _parcela.ConsultarParcelasVencidas(codCliente); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarParcelasVencidas Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    int retorno = _crediario.Incluir(dados);
                    foreach (var parcela in dadosParcelas)
                    {
                        parcela.crediarioId = retorno;
                        _parcela.Incluir(parcela);
                    }
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirCrediario(dCrediario dados)
        {
            try { return _crediario.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirCrediario [" + ToString() + "] - " + ex.Message); }
        }

        public int IncluirParcela(dParcelas dadosParcela)
        {
            try { return _parcela.Incluir(dadosParcela); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em IncluirParcela Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    int retorno = _crediario.Alterar(dados);
                    foreach (var parcela in dadosParcelas)
                        _parcela.Alterar(parcela);
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int GravarPagamentoParcelas(ColecaoParcelas dadosParcelas)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    foreach (var parcela in dadosParcelas)
                        _parcela.IncluirPagamento(parcela);
                    ts.Complete();
                    return 1;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em GravarPagamentoParcelas Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int Renegociar(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    int retorno = dados.cid != 0 ? _crediario.Alterar(dados) : _crediario.Incluir(dados);
                    _crediario.ExcluirParcelas(dados);
                    foreach (var parcela in dadosParcelas)
                    {
                        if (parcela.crediarioId == 0)
                            parcela.crediarioId = retorno;
                        _parcela.Incluir(parcela);
                    }
                    ts.Complete();
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Renegociar Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int AlterarCrediario(dCrediario dados)
        {
            try { return _crediario.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarCrediario [" + ToString() + "] - " + ex.Message); }
        }

        public int AlterarControle(dCrediario dados)
        {
            try { return _crediario.AlterarControle(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em AlterarControle Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCrediario dados)
        {
            try { return _crediario.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Crediario [" + ToString() + "] - " + ex.Message); }
        }

        public int CorrigirParcelas()
        {
            try { return _parcela.Corrigir(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em CorrigirParcelas Crediario [" + ToString() + "] - " + ex.Message); }
        }
    }
}
