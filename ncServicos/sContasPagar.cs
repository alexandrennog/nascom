using System;
using ncDados.nsContasPagar;
using ncRegras.nsContasPagar;
using ncComum.nsExcecao;

namespace ncServicos.nsContasPagar
{
    public class sContasPagar
    {
        public ColecaoContasPagar Listar()
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoContasPagar Consultar(dContasPagar dados)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public dContasPagar Consultar(int cid)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dContasPagar dados)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dContasPagar dados)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dContasPagar dados)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dContasPagar dados)
        {
            try
            {
                var regra = new rContasPagar();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
