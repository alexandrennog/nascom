using System;

namespace ncNComum
{
    public class ExcecaoNascomercio : Exception
    {
        public ExcecaoNascomercio() : base() { }

        public ExcecaoNascomercio(string mensagem) : base(mensagem) { }
    }
}
