using System;
using System.Collections.Generic;

namespace nsCaracteristica
{
    public class ColecaoCaracteristicaItem : List<dCaracteristicaItem>
    {
    }

    public class dCaracteristicaItem
    {
        private int? _cid;
        private int? _caracteristicas_cid;
        private string _valor;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public int? caracteristicas_cid
        {
            get => _caracteristicas_cid;
            set => _caracteristicas_cid = value;
        }

        public string valor
        {
            get => _valor;
            set => _valor = value;
        }
    }
}
