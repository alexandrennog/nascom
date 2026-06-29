using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoSimNao : List<dSimNao> { }

    public class dSimNao
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
    }

}
