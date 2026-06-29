using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsPix
{
    public class rPixConfig : IsPixConfig
    {
        private readonly IpPix _repo;
        public rPixConfig(IpPix repo) { _repo = repo; }

        public int Incluir(dPixConfig dados)
        {
            try { return _repo.IncluirPixConfig(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir PixConfig [" + ToString() + "] - " + ex.Message); }
        }

        public dPixConfig Consultar()
        {
            try { return _repo.ConsultarConfig(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar PixConfig [" + ToString() + "] - " + ex.Message); }
        }
    }
}

