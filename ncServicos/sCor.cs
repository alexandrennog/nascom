using System;
using ncDados.nsCor;
using ncRegras.nsCor;
using ncComum.nsExcecao;

namespace ncServicos.nsCor
{
    public class sCor
    {
        public ColecaoCor Listar()
        {
            try
            {
                var regra = new rCor();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCor Consultar(dCor dados)
        {
            try
            {
                var regra = new rCor();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCor Consultar(int cid)
        {
            try
            {
                var regra = new rCor();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCor dados)
        {
            try
            {
                var regra = new rCor();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dCor dados)
        {
            try
            {
                var regra = new rCor();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCor dados)
        {
            try
            {
                var regra = new rCor();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cor [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCor dados)
        {
            try
            {
                var regra = new rCor();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cor [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
