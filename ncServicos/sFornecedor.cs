using System;
using ncDados.nsFornecedor;
using ncRegras.nsFornecedor;
using ncComum.nsExcecao;

namespace ncServicos.nsFornecedor
{
    public class sFornecedor
    {
        public ColecaoFornecedor Listar()
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoFornecedor Consultar(dFornecedor dados)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public dFornecedor Consultar(int cid)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dFornecedor dados)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dFornecedor dados)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dFornecedor dados)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dFornecedor dados)
        {
            try
            {
                var regra = new rFornecedor();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Fornecedor [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
