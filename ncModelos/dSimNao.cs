using System.Collections.Generic;

namespace nsDados
{
    public class ColecaoSimNao : List<dSimNao> { }

    public class dSimNao
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
    }
}
