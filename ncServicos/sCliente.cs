using System;
using ncDados.nsCliente;
using ncRegras.nsCliente;
using ncComum.nsExcecao;

namespace ncServicos.nsCliente
{
    public class sCliente
    {
        public ColecaoCliente Listar()
        {
            try
            {
                var regra = new rCliente();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoCliente Consultar(dCliente dados)
        {
            try
            {
                var regra = new rCliente();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public dCliente ConsultarPorCID(int cid)
        {
            try
            {
                var regra = new rCliente();
                return regra.ConsultarPorCID(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarPorCID Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dCliente dados)
        {
            try
            {
                var regra = new rCliente();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirImportacao(dCliente dados)
        {
            try
            {
                var regra = new rCliente();
                return regra.IncluirImportacao(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em IncluirImportacao Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dCliente dados)
        {
            try
            {
                var regra = new rCliente();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Cliente [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dCliente dados)
        {
            try
            {
                var regra = new rCliente();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Cliente [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
