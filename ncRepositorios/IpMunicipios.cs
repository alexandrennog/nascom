using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpMunicipios
    {
        ColecaoMunicipios Listar();
        ColecaoMunicipios ListarPorEstado(int estados_cid);
        ColecaoMunicipios Consultar(dMunicipios dados);
        int Incluir(dMunicipios dados);
        int Importar(dMunicipios dados);
        int Alterar(dMunicipios dados);
        int Excluir(dMunicipios dados);
    }
}
