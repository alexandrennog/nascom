using System;
using ncDados.nsCrediario;
using ncRegras.nsCrediario;
using ncComum.nsExcecao;

namespace ncServicos.nsCrediario
{
    public class sCrediario
    {
        public ColecaoCrediario Listar()
        {
            try
            {
                var regra = new rCrediario();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarMax()
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarMax();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarMax Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCrediario Consultar(dCrediario dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelas(dParcelas dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarParcelas(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarParcelas Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelasPagamentos(dParcelas dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarParcelasPagamentos(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarParcelasPagamentos Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public dParcelas ConsultarParcela(int cid)
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarParcela(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarParcela Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelasCliente(int codCliente)
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarParcelasCliente(codCliente);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarParcelasCliente Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParcelas ConsultarParcelasVencidas(int codCliente)
        {
            try
            {
                var regra = new rCrediario();
                return regra.ConsultarParcelasVencidas(codCliente);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarParcelasVencidas Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                var regra = new rCrediario();
                return regra.Incluir(dados, dadosParcelas);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirCrediario(dCrediario dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.IncluirCrediario(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirCrediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirParcela(dParcelas dadosParcela)
        {
            try
            {
                var regra = new rCrediario();
                return regra.IncluirParcela(dadosParcela);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirParcela Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                var regra = new rCrediario();
                return regra.Alterar(dados, dadosParcelas);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int GravarPagamentoParcelas(ColecaoParcelas dadosParcelas)
        {
            try
            {
                var regra = new rCrediario();
                return regra.GravarPagamentoParcelas(dadosParcelas);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em GravarPagamentoParcelas Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Renegociar(dCrediario dados, ColecaoParcelas dadosParcelas)
        {
            try
            {
                var regra = new rCrediario();
                return regra.Renegociar(dados, dadosParcelas);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Renegociar Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarCrediario(dCrediario dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.AlterarCrediario(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarCrediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarControle(dCrediario dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.AlterarControle(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarControle Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCrediario dados)
        {
            try
            {
                var regra = new rCrediario();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Crediario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int CorrigirParcelas()
        {
            try
            {
                var regra = new rCrediario();
                return regra.CorrigirParcelas();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em CorrigirParcelas Crediario [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
