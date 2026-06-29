using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCheques
{
    public class rCheque : IsCheque
    {
        private readonly IpCheques _repo;
        public rCheque(IpCheques repo) { _repo = repo; }

        public ColecaoCheques Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCheques Consultar(dCheques dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCheques ConsultarCheques(dCheques dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarCheques Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(ColecaoCheques dadosCheques)
        {
            try
            {
                foreach (var cheque in dadosCheques)
                    _repo.Incluir(cheque);
                return 1;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCheques dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCheques dados, ColecaoCheques dadosCheques)
        {
            try
            {
                _repo.Alterar(dados);
                foreach (var cheque in dadosCheques)
                    _repo.Alterar(cheque);
                return 1;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public int Baixar()
        {
            try { return _repo.Baixar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Baixar Cheque [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCheques dados)
        {
            try { return _repo.Excluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Cheque [" + ToString() + "] - " + ex.Message); }
        }
    }
}

