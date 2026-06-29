using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsGiro
    {
        public ColecaoGiro Listar();
        public ColecaoGiro Consultar(dGiro dados);
        public dGiro Consultar(int produto_cid, string codigoBarras);
        public int Incluir(dGiro dados);
        public int Importar(dGiro dados);
        public int Alterar(dGiro dados);
        public int Excluir(dGiro dados);
    }
}