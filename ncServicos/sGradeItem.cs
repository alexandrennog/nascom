using System;
using ncDados.nsGradeItem;
using ncPersistencia.nsGradeItem;
using ncComum.nsExcecao;

namespace ncServicos.nsGradeItem
{
    public class sGradeItem
    {
        private readonly IpGradeItem _repo;
        public sGradeItem(IpGradeItem repo) { _repo = repo; }

        public ColecaoGradeItem ConsultarReferencia(dGradeItem pFiltro)
        {
            try { return _repo.ConsultarReferencia(pFiltro); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarReferencia GradeItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGradeItem ConsultarProdutos(string pReferencia, dGradeItem pGradeItem)
        {
            try { return _repo.ConsultarProdutos(pReferencia, pGradeItem); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarProdutos GradeItem [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGradeItem ConsultarItens(int pProdutoCid)
        {
            try { return _repo.ConsultarItens(pProdutoCid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarItens GradeItem [" + ToString() + "] - " + ex.Message); }
        }

        public dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem)
        {
            try { return _repo.ConsultarUltimaVenda(referencia, gradeItem); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarUltimaVenda GradeItem [" + ToString() + "] - " + ex.Message); }
        }
    }
}
