using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaodVendasABC : List<dCurvaAbc>
    {
    }

    public class dCurvaAbc
    {
        public string PeriodoIni { get; set; }
        public string PeriodoFim { get; set; }
        public string Fabricante { get; set; }
        public string valor { get; set; }
        public decimal PercReceita { get; set; }
        public decimal PercAcumulado { get; set; }
        public string ClasseAbc { get; set; }
        public string Estrategia { get; set; }
    }

}
