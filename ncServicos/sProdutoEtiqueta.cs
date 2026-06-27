using System;
using ncDados.nsProdutoEtiqueta;
using ncPersistencia.nsProdutoEtiqueta;
using ncComum.nsExcecao;

namespace ncServicos.nsProdutoEtiqueta
{
    public class sProdutoEtiqueta
    {
        private readonly IpProdutoEtiqueta _repo;
        public sProdutoEtiqueta(IpProdutoEtiqueta repo) { _repo = repo; }

        public ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos)
        {
            try { return _repo.Listar(dataDe, dataAte, ImprimeTodos); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(string data, string produto, string codigoBarras)
        {
            try { return _repo.Alterar(data, produto, codigoBarras); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message); }
        }
    }
}
