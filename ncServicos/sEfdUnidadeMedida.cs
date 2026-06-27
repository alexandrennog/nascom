using System;
using ncDados.nsEfd;
using ncRegras.nsEFD;
using ncComum.nsExcecao;

namespace ncServicos.nsEFD
{
    public class sEfdUnidadeMedida
    {
        public int Salvar(dEfdUnidadeMedida dados)
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Salvar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Salvar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoEfdUnidadeMedida Listar()
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Listar();
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados)
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Consultar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dEfdUnidadeMedida dados)
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Incluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dEfdUnidadeMedida dados)
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Alterar(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dEfdUnidadeMedida dados)
        {
            try
            {
                var regra = new rEfdUnidadeMedida();
                return regra.Excluir(dados);
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
