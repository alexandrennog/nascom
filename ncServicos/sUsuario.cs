using System;
using ncDados.nsUsuario;
using ncRegras.nsUsuario;
using ncComum.nsExcecao;

namespace ncServicos.nsUsuario
{
    public class sUsuario
    {
        public ColecaoUsuario Listar()
        {
            try
            {
                var regra = new rUsuario();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoUsuario Consultar(dUsuario dados)
        {
            try
            {
                var regra = new rUsuario();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoUsuario ConsultarPorADM(dUsuario dados)
        {
            try
            {
                var regra = new rUsuario();
                return regra.ConsultarPorADM(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorADM Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public dUsuario ConsultarPorCid(int cid)
        {
            try
            {
                var regra = new rUsuario();
                return regra.ConsultarPorCid(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCid Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public dUsuario ConsultarPorEmail(string email)
        {
            try
            {
                var regra = new rUsuario();
                return regra.ConsultarPorEmail(email);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorEmail Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dUsuario dados)
        {
            try
            {
                var regra = new rUsuario();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dUsuario dados)
        {
            try
            {
                var regra = new rUsuario();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dUsuario dados)
        {
            try
            {
                var regra = new rUsuario();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Usuario [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
