using System;
using ncDados.nsGiro;
using ncRegras.nsGiro;
using ncComum.nsExcecao;

namespace ncServicos.nsGiro
{
    public class sGiro
    {
        public ColecaoGiro Listar()
        {
            try
            {
                var regra = new rGiro();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGiro Consultar(dGiro dados)
        {
            try
            {
                var regra = new rGiro();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public dGiro Consultar(int produto_cid, string codigoBarras)
        {
            try
            {
                var regra = new rGiro();
                return regra.Consultar(produto_cid, codigoBarras);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dGiro dados)
        {
            try
            {
                var regra = new rGiro();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dGiro dados)
        {
            try
            {
                var regra = new rGiro();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dGiro dados)
        {
            try
            {
                var regra = new rGiro();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dGiro dados)
        {
            try
            {
                var regra = new rGiro();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Giro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
