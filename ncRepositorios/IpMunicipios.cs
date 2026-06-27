using System;
using nsMunicipios;

namespace ncPersistencia.nsMunicipios
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
