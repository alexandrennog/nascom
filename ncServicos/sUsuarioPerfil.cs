using System;
using ncDados.nsUsuarioPerfil;
using ncRegras.nsUsuarioPerfil;
using ncComum.nsExcecao;

namespace ncServicos.nsUsuarioPerfil
{
    public class sUsuarioPerfil
    {
        public ColecaoUsuarioPerfil Listar()
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados)
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public dUsuarioPerfil Consultar(int cid)
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dUsuarioPerfil dados)
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dUsuarioPerfil dados)
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dUsuarioPerfil dados)
        {
            try
            {
                var regra = new rUsuarioPerfil();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
