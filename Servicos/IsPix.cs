using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsPix
    {
        int Incluir(dPix dados);
        dPix Consultar(string tx);
        ColecaoPix Consultar(dPix dados);
    }
}
