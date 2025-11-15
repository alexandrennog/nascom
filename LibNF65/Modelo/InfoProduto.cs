using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Xml.NFe;

namespace LibNF65.Modelo
{
    public class InfoProduto
    {
        public string VerAplic { get; set; }
        public string ChNFe { get; set; }
        public DateTime DhRecbto { get; set; }
        public string NProt { get; set; }
        public string DigVal { get; set; }
        public int CStat { get; set; }
        public string XMotivo { get; set; }
        public string CMsg { get; set; }
        public string XMsg { get; set; }
    }

}
