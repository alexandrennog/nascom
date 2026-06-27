using System;
using ncDados.nsCategoria;
using ncRegras.nsCategoria;
using ncComum.nsExcecao;

namespace ncServicos.nsCategoria
{
    public class sCategoria
    {
        public ColecaoCategoria Listar()
        {
            try
            {
                var regra = new rCategoria();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCategoria Consultar(dCategoria dados)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCategoria Consultar(int cid)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCategoria dados)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dCategoria dados)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCategoria dados)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Categoria [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCategoria dados)
        {
            try
            {
                var regra = new rCategoria();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Categoria [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
