using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsGradeItem
{
    public interface IsGradeItem
    {
        public ColecaoGradeItem ConsultarReferencia(dGradeItem pFiltro);
        public ColecaoGradeItem ConsultarProdutos(string pReferencia, dGradeItem pGradeItem);
        public ColecaoGradeItem ConsultarItens(int pProdutoCid);
        public dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem);
    }
}