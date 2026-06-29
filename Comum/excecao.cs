using System;

namespace Comum
{
    public class ExcecaoNascomercio : Exception
    {
        public ExcecaoNascomercio() : base() { }

        public ExcecaoNascomercio(string mensagem) : base(mensagem) { }
    }
}
