using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoRegistro : List<dEfdRegistro>
    {
        public void Incluir(string pCodigo, string pQuantidade)
        {
            var registro = new dEfdRegistro();
            registro.codigo = pCodigo;
            registro.quantidade = decimal.Parse(pQuantidade);
            this.Add(registro);
        }
    }

    public class dEfdRegistro
    {
        private string _codigo;
        private decimal _quantidade;

        public string codigo
        {
            get => _codigo;
            set => _codigo = value;
        }

        public decimal quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }
    }

}
