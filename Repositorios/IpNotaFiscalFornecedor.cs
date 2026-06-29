using System;
using Modelos;

namespace Repositorios
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
