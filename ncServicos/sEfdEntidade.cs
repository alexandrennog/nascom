using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdEntidade
    {
        public int Salvar(dEfdEntidade dados)
        {
            try
            {
                var regra = new rEfdEntidade();
                return regra.Salvar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Salvar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdEntidade Consultar()
        {
            try
            {
                var regra = new rEfdEntidade();
                return regra.Consultar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdEntidade dados)
        {
            try
            {
                var regra = new rEfdEntidade();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdEntidade dados)
        {
            try
            {
                var regra = new rEfdEntidade();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                var regra = new rEfdEntidade();
                return regra.Excluir();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdEntidade [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
