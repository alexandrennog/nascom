using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdArquivo
    {
        public int Salvar(dEfdArquivo dados)
        {
            try
            {
                var regra = new rEfdArquivo();
                return regra.Salvar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Salvar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdArquivo Consultar()
        {
            try
            {
                var regra = new rEfdArquivo();
                return regra.Consultar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdArquivo dados)
        {
            try
            {
                var regra = new rEfdArquivo();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdArquivo dados)
        {
            try
            {
                var regra = new rEfdArquivo();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                var regra = new rEfdArquivo();
                return regra.Excluir();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdArquivo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
