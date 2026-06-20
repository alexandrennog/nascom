using LibNF65.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNF65.Interfaces
{
    public interface IInfProtRepository
    {
        PixConfig GetPixConfig();
        void Add(InfoProduto infoProduto);
        InfoProduto GetByChNFe(string chNFe);
        IEnumerable<InfoProduto> GetAll();
        void Update(InfoProduto infoProduto);
        void Delete(string chNFe);
        void UpdateEvent(string ChNFe, string xEvento, string NProt);
    }
}
