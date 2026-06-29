using System;
using Modelos;

namespace Repositorios
{
    public interface IpVenda
    {
        ColecaoVenda Listar();
        ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim);
        ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo);
        ColecaoVenda Consultar(dVenda dados);
        ColecaoVenda ConsultarPix(dVenda dados);
        ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados);
        ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados);
        ColecaoVenda ConsultarCrediarioPix(dVenda dados);
        ColecaoVenda ConsultarTroca(dVenda dados);
        dVenda ConsultarUltimaVenda(int produtos_cid);
        int ConsultarMax();
        int Incluir(dVenda dados);
        int IncluirVale(dVenda dados);
        int IncluirnNF(dBasennf dados);
        int IncluirCrediarioPagamento(dVenda dados);
        int Alterar(dVenda dados);
        int Alterar(string controle, string chave);
        int AlterarBaseNnf(dBasennf dados);
        int Excluir(dVenda dados);
        int ExcluirVale(dVenda dados);
        ColecaoVenda ConsultarFechamento(dVenda dados);
    }
}
