using System;
using ncDados.nsParametro;
using ncRegras.nsParametro;
using ncComum.nsExcecao;

namespace ncServicos.nsParametro
{
    public class sParametro
    {
        public ColecaoParametro Listar()
        {
            try
            {
                var regra = new rParametro();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParametro Consultar(dParametro dados)
        {
            try
            {
                var regra = new rParametro();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados)
        {
            try
            {
                var regra = new rParametro();
                return regra.ConsultarEstoque(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarEstoque Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public dParametro Consultar(int cid)
        {
            try
            {
                var regra = new rParametro();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dParametro dados)
        {
            try
            {
                var regra = new rParametro();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dParametro dados)
        {
            try
            {
                var regra = new rParametro();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Parametro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dParametro dados)
        {
            try
            {
                var regra = new rParametro();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Parametro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
