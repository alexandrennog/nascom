using System;
using Modelos;

namespace Repositorios
{
    public interface IpGradeItem
    {
        ColecaoGradeItem ConsultarReferencia(dGradeItem dados);
        dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem);
        ColecaoGradeItem ConsultarProdutos(string referencia, dGradeItem gradeItem);
        ColecaoGradeItem ConsultarItens(int pProdutoCid);
    }
}
