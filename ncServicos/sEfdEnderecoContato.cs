using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdEnderecoContato
    {
        public int Salvar(dEfdEnderecoContato dados)
        {
            try
            {
                var regra = new rEfdEnderecoContato();
                return regra.Salvar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Salvar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdEnderecoContato Consultar()
        {
            try
            {
                var regra = new rEfdEnderecoContato();
                return regra.Consultar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdEnderecoContato dados)
        {
            try
            {
                var regra = new rEfdEnderecoContato();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdEnderecoContato dados)
        {
            try
            {
                var regra = new rEfdEnderecoContato();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir()
        {
            try
            {
                var regra = new rEfdEnderecoContato();
                return regra.Excluir();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
