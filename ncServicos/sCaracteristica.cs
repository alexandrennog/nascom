using System;
using ncDados.nsCaracteristica;
using ncRegras.nsCaracteristica;
using ncComum.nsExcecao;

namespace ncServicos.nsCaracteristica
{
    public class sCaracteristica
    {
        public ColecaoCaracteristica Listar()
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCaracteristica Consultar(dCaracteristica dados)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCaracteristica ConsultarPorCID(int cid)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.ConsultarPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCID Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCaracteristica ConsultarPorNome(string nome)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.ConsultarPorNome(nome);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorNome Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCaracteristica ConsultarPorCodigo(string codigo)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.ConsultarPorCodigo(codigo);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCodigo Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCaracteristica dados)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCaracteristica dados)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCaracteristica dados)
        {
            try
            {
                var regra = new rCaracteristica();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Caracteristica [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
