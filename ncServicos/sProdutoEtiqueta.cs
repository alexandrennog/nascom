using System;
using ncDados.nsProdutoEtiqueta;
using ncRegras.nsProdutoEtiqueta;
using ncComum.nsExcecao;

namespace ncServicos.nsProdutoEtiqueta
{
    public class sProdutoEtiqueta
    {
        public ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos)
        {
            try
            {
                var regra = new rProdutoEtiqueta();
                return regra.Listar(dataDe, dataAte, ImprimeTodos);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(string data, string produto, string codigoBarras)
        {
            try
            {
                var regra = new rProdutoEtiqueta();
                return regra.Alterar(data, produto, codigoBarras);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
