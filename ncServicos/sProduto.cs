using System;
using ncDados.nsProduto;
using ncDados.nsGradeEntrada;
using ncDados.nsUsuario;
using ncRegras.nsProduto;
using ncComum.nsExcecao;

namespace ncServicos.nsProduto
{
    public class sProduto
    {
        public dUsuario _usuario { get; set; }

        public ColecaoProduto Listar()
        {
            try
            {
                var regra = new rProduto();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProduto Consultar(dProduto dados)
        {
            try
            {
                var regra = new rProduto();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeEntrada ConsultarGradeEntrada(dProduto dados)
        {
            try
            {
                var regra = new rProduto();
                return regra.ConsultarGradeEntrada(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarGradeEntrada Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public dProduto Consultar(int cid)
        {
            try
            {
                var regra = new rProduto();
                return regra.Consultar(cid);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ConsultarProximoCID()
        {
            try
            {
                var regra = new rProduto();
                return regra.ConsultarProximoCID();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProduto dados)
        {
            try
            {
                var regra = new rProduto();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dProduto dados)
        {
            try
            {
                var regra = new rProduto();
                return regra.Importar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                regra._usuario = usuario;
                return regra.Incluir(dados, colecaoItem, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProduto dados)
        {
            try
            {
                var regra = new rProduto();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProduto dados, ColecaoItensProdutos colecaoItem, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                regra._usuario = usuario;
                return regra.Alterar(dados, colecaoItem, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProduto dados, dUsuario usuario)
        {
            try
            {
                var regra = new rProduto();
                return regra.Excluir(dados, usuario);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Produto [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
