using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsParametro
{
    public interface IsParametro
    {
        public ColecaoParametro Listar();
        public ColecaoParametro Consultar(dParametro dados);
        public ColecaoParametroEstoque ConsultarEstoque(dParametroEstoque dados);
        public dParametro Consultar(int cid);
        public int Incluir(dParametro dados);
        public int Alterar(dParametro dados);
        public int Excluir(dParametro dados);
    }
}