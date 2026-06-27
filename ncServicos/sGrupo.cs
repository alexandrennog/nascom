using System;
using ncDados.nsGrupo;
using ncRegras.nsGrupo;
using ncComum.nsExcecao;

namespace ncServicos.nsGrupo
{
    public class sGrupo
    {
        public ColecaoGrupo Listar()
        {
            try
            {
                var regra = new rGrupo();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGrupo Consultar(dGrupo dados)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public dGrupo Consultar(int cid)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dGrupo dados)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dGrupo dados)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dGrupo dados)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Grupo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dGrupo dados)
        {
            try
            {
                var regra = new rGrupo();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Grupo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
