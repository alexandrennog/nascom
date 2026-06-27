using System;
using nsFornecedor;

namespace ncPersistencia.nsFornecedor
{
    public interface IpFornecedor
    {
        ColecaoFornecedor Listar();
        ColecaoFornecedor Consultar(dFornecedor dados);
        int Incluir(dFornecedor dados);
        int Importar(dFornecedor dados);
        int Alterar(dFornecedor dados);
        int Excluir(dFornecedor dados);
    }
}
