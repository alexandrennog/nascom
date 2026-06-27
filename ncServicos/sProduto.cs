using System;
using ncDados.nsProduto;
using ncDados.nsGradeEntrada;
using ncDados.nsUsuario;
using ncPersistencia.nsProduto;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProduto
    {
        private readonly IpProduto _repo;
        public dUsuario _usuario { get; set; }

        public sProduto(IpProduto repo) { _repo = repo; }

        public ColecaoProduto Listar()
        {
            try { return _repo.Listar(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoProduto Consultar(dProduto dados)
        {
            try { return _repo.Consultar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados)
        {
            try { return _repo.ConsultarGradeEntrada(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarGradeEntrada Produto [" + ToString() + "] - " + ex.Message); }
        }

        public dProduto Consultar(int cid)
        {
            try
            {
                var lista = _repo.Consultar(new dProduto { cid = cid });
                return lista != null && lista.Count > 0 ? lista[0] : null;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int ConsultarProximoCID()
        {
            try { return _repo.ConsultarProximoCID(); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dProduto dados)
        {
            try { return _repo.Incluir(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Importar(dProduto dados)
        {
            try { return _repo.Importar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Importar Produto [" + ToString() + "] - " + ex.Message); }
        }

        // Overload complexo com itens e usuário — mantém rProduto (lógica de código de barras + log)
        public int Incluir(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                regra._usuario = usuario;
                return regra.Incluir(dados, colecaoItem, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dProduto dados)
        {
            try { return _repo.Alterar(dados); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message); }
        }

        // Overload complexo com itens e usuário — mantém rProduto
        public int Alterar(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                regra._usuario = usuario;
                return regra.Alterar(dados, colecaoItem, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dProduto dados, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                return regra.Excluir(dados, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Produto [" + ToString() + "] - " + ex.Message); }
        }
    }
}
