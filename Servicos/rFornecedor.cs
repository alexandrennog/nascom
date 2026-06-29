using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rFornecedor : IsFornecedor
    {
        private readonly IpFornecedor _repo;
        public rFornecedor(IpFornecedor repo) { _repo = repo; }

        public ColecaoFornecedor Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoFornecedor Consultar(dFornecedor dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public dFornecedor Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dFornecedor { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dFornecedor dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dFornecedor dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dFornecedor dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Fornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dFornecedor dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Fornecedor [" + ToString() + "] - " + ex.Message); }
        }
    }
}

