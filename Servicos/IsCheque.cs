using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCheques
{
    public interface IsCheque
    {
        public ColecaoCheques Listar();
        public ColecaoCheques Consultar(dCheques dados);
        public ColecaoCheques ConsultarCheques(dCheques dados);
        public int Incluir(ColecaoCheques dadosCheques);
        public int Incluir(dCheques dados);
        public int Alterar(dCheques dados, ColecaoCheques dadosCheques);
        public int Baixar();
        public int Excluir(dCheques dados);
    }
}