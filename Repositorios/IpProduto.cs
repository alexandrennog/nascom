using System;
using Modelos;

namespace Repositorios
{
    public interface IpProduto
    {
        ColecaoProduto Listar();
        ColecaoProduto Consultar(dProduto dados);
        ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados);
        int ConsultarProximoCID();
        int Incluir(dProduto dados);
        int Importar(dProduto dados);
        int Alterar(dProduto dados);
        int Excluir(dProduto dados);
    }
}
