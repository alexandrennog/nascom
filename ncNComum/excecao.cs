using System;

namespace ncNComum.nsExcecao
{
    public class ExcecaoNascomercio : Exception
    {
        public ExcecaoNascomercio() : base() { }

        public ExcecaoNascomercio(string mensagem) : base(mensagem) { }
    }
}
