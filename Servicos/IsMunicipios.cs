using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsMunicipios
{
    public interface IsMunicipios
    {
        public ColecaoMunicipios Listar();
        public ColecaoMunicipios ListarPorEstados(int estados_cid);
        public ColecaoMunicipios Consultar(dMunicipios dados);
        public dMunicipios Consultar(int cid);
        public int Incluir(dMunicipios dados);
        public int Importar(dMunicipios dados);
        public int Alterar(dMunicipios dados);
        public int Excluir(dMunicipios dados);
    }
}