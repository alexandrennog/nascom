using System;
using ncDados.nsGradeItem;
using ncRegras.nsGradeItem;
using ncComum.nsExcecao;

namespace ncServicos.nsGradeItem
{
    public class sGradeItem
    {
        public ColecaoGradeItem ConsultarReferencia(dGradeItem pFiltro)
        {
            try
            {
                var regra = new rGradeItem();
                return regra.ConsultarReferencia(pFiltro);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarReferencia GradeItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeItem ConsultarProdutos(string pReferencia, dGradeItem pGradeItem)
        {
            try
            {
                var regra = new rGradeItem();
                return regra.ConsultarProdutos(pReferencia, pGradeItem);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarProdutos GradeItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeItem ConsultarItens(int pProdutoCid)
        {
            try
            {
                var regra = new rGradeItem();
                return regra.ConsultarItens(pProdutoCid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarItens GradeItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem)
        {
            try
            {
                var regra = new rGradeItem();
                return regra.ConsultarUltimaVenda(referencia, gradeItem);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda GradeItem [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
