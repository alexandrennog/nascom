using System;
using ncDados.nsCheques;
using ncRegras.nsCheques;
using ncComum.nsExcecao;

namespace ncServicos.nsCheques
{
    public class sCheque
    {
        public ColecaoCheques Listar()
        {
            try
            {
                var regra = new rCheque();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCheques Consultar(dCheques dados)
        {
            try
            {
                var regra = new rCheque();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCheques ConsultarCheques(dCheques dados)
        {
            try
            {
                var regra = new rCheque();
                return regra.ConsultarCheques(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarCheques Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(ColecaoCheques dadosCheques)
        {
            try
            {
                var regra = new rCheque();
                return regra.Incluir(dadosCheques);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCheques dados)
        {
            try
            {
                var regra = new rCheque();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCheques dados, ColecaoCheques dadosCheques)
        {
            try
            {
                var regra = new rCheque();
                return regra.Alterar(dados, dadosCheques);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Baixar()
        {
            try
            {
                var regra = new rCheque();
                return regra.Baixar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Baixar Cheque [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCheques dados)
        {
            try
            {
                var regra = new rCheque();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cheque [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
