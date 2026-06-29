using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCondicao
{
    public interface IsCondicao
    {
        public ColecaoCondicao Listar();
        public ColecaoCondicao Consultar(dCondicao dados);
        public dCondicao Consultar(int cid);
        public int Incluir(dCondicao dados);
        public int Alterar(dCondicao dados);
        public int Excluir(dCondicao dados);
    }
}