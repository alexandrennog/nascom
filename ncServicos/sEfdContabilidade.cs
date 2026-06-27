using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdContabilidade
    {
        public int Salvar(dEfdContabilidade dados)
        {
            try
            {
                var regra = new rEfdContabilidade();
                return regra.Salvar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Salvar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdContabilidade Consultar()
        {
            try
            {
                var regra = new rEfdContabilidade();
                return regra.Consultar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdContabilidade dados)
        {
            try
            {
                var regra = new rEfdContabilidade();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdContabilidade dados)
        {
            try
            {
                var regra = new rEfdContabilidade();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                var regra = new rEfdContabilidade();
                return regra.Excluir();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
