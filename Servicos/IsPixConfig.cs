using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsPix
{
    public interface IsPixConfig
    {
        public int Incluir(dPixConfig dados);
        public dPixConfig Consultar();
    }
}