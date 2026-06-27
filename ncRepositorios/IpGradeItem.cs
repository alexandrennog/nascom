using System;
using nsGradeItem;

namespace ncPersistencia.nsGradeItem
{
    public interface IpGradeItem
    {
        ColecaoGradeItem ConsultarReferencia(dGradeItem dados);
        dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem);
        ColecaoGradeItem ConsultarProdutos(string referencia, dGradeItem gradeItem);
        ColecaoGradeItem ConsultarItens(int pProdutoCid);
    }
}
