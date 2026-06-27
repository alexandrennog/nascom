using System;
using ncDados.nsEstado;
using ncRegras.nsEstado;
using ncComum.nsExcecao;

namespace ncServicos.nsEstado
{
    public class sEstado
    {
        public ColecaoEstado Listar()
        {
            try
            {
                var regra = new rEstado();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Estado [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoEstado Consultar(dEstado dados)
        {
            try
            {
                var regra = new rEstado();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEstado Consultar(int cid)
        {
            try
            {
                var regra = new rEstado();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEstado dados)
        {
            try
            {
                var regra = new rEstado();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Estado [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEstado dados)
        {
            try
            {
                var regra = new rEstado();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Estado [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dEstado dados)
        {
            try
            {
                var regra = new rEstado();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Estado [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
