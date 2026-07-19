using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNF65.Modelo
{
    public class dDadosImpostos
    {
        public int? regra_cid { get; set; }

        public dImpostoIcms icms { get; set; }

        public dImpostoPis pis { get; set; }

        public dImpostoCofins cofins { get; set; }

        public dImpostoIpi ipi { get; set; }

        public dImpostoIbsCbs ibsCbs { get; set; }

        public ColecaoRegraCfop cfops { get; set; }
    }
}
