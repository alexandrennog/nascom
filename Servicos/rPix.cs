using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsPix
{
    public class rPix
    {
        private readonly IpPix _repo;
        public rPix(IpPix repo) { _repo = repo; }

        public int Incluir(dPix dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Pix [" + ToString() + "] - " + ex.Message); }
        }

        public dPix Consultar(string tx)
        {
            try { return _repo.Consultar(tx); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Pix [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoPix Consultar(dPix dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Pix [" + ToString() + "] - " + ex.Message); }
        }
    }
}
