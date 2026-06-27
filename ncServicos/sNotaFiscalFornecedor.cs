using System;
using ncDados.nsNotaFiscalFornecedor;
using ncRegras.nsNotaFiscalFornecedor;
using ncComum.nsExcecao;

namespace ncServicos.nsNotaFiscalFornecedor
{
    public class sNotaFiscalFornecedor
    {
        public ColecaoNotaFiscalFornecedor Listar()
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados)
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public dNotaFiscalFornecedor Selecionar(string numero, string serie)
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Selecionar(numero, serie);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Selecionar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dNotaFiscalFornecedor dados)
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dNotaFiscalFornecedor dados)
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dNotaFiscalFornecedor dados)
        {
            try
            {
                var regra = new rNotaFiscalFornecedor();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
