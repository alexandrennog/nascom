using System;
using ncDados.nsNotaFiscalFornecedor;
using ncPersistencia.nsNotaFiscalFornecedor;
using ncComum.nsExcecao;

namespace ncServicos.nsNotaFiscalFornecedor
{
    public class sNotaFiscalFornecedor
    {
        private readonly IpNotaFiscalFornecedor _repo;
        public sNotaFiscalFornecedor(IpNotaFiscalFornecedor repo) { _repo = repo; }

        public ColecaoNotaFiscalFornecedor Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoNotaFiscalFornecedor Consultar(dNotaFiscalFornecedor dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public dNotaFiscalFornecedor Selecionar(string numero, string serie)
        {
            try
            {
                var lista = _repo.Consultar(new dNotaFiscalFornecedor { notaFiscal = numero, serie = serie });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Selecionar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dNotaFiscalFornecedor dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dNotaFiscalFornecedor dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dNotaFiscalFornecedor dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir NotaFiscalFornecedor [" + ToString() + "] - " + ex.Message); }
        }
    }
}
