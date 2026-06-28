using System;
using ncModelos;

namespace ncRepositorios
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
