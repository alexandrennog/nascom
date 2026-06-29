using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsCor
    {
        public ColecaoCor Listar();
        public ColecaoCor Consultar(dCor dados);
        public dCor Consultar(int cid);
        public int Incluir(dCor dados);
        public int Importar(dCor dados);
        public int Alterar(dCor dados);
        public int Excluir(dCor dados);
    }
}