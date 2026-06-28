using System;
using ncNComum;
using ncRepositorios;
using ncModelos;

namespace ncServicos
{
    public class rSituacao
    {
        public ColecaoSituacao Listar()
        {
            try
            {
                var regra = new rSituacao();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Situacao [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoSituacao ListarFinan()
        {
            try
            {
                var regra = new rSituacao();
                return regra.ListarFinan();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ListarFinan Situacao [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
