using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpNotaFiscalFornecedor
    {
        ColecaoNotaFiscalFornecedor Listar();
        ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados);
        ColecaoNotaFiscalItem ConsultarItemNota(string notaFiscal, string serie);
        int Incluir(dNotaFiscalFornecedor dados);
        int Alterar(dNotaFiscalFornecedor dados);
        int Excluir(dNotaFiscalFornecedor dados);
    }
}
