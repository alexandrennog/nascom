using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColC190 : List<dC190>
    {
    }

    public class dC190
    {
        private string _reg;
        private int? _cst_icms;
        private int? _cfop;
        private decimal? _aliq_icms;
        private decimal? _vl_opr;
        private decimal? _vl_bc_icms;
        private decimal? _vl_icms;
        private decimal? _vl_bc_icms_st;
        private decimal? _vl_icms_st;
        private decimal? _vl_red_bc;
        private decimal? _vl_ipi;
        private string _cod_obs;

        public string reg
        {
            get => _reg;
            set => _reg = value;
        }

        public int? cst_icms
        {
            get => _cst_icms;
            set => _cst_icms = value;
        }

        public int? cfop
        {
            get => _cfop;
            set => _cfop = value;
        }

        public decimal? aliq_icms
        {
            get => _aliq_icms;
            set => _aliq_icms = value;
        }

        public decimal? vl_opr
        {
            get => _vl_opr;
            set => _vl_opr = value;
        }

        public decimal? vl_bc_icms
        {
            get => _vl_bc_icms;
            set => _vl_bc_icms = value;
        }

        public decimal? vl_icms
        {
            get => _vl_icms;
            set => _vl_icms = value;
        }

        public decimal? vl_bc_icms_st
        {
            get => _vl_bc_icms_st;
            set => _vl_bc_icms_st = value;
        }

        public decimal? vl_icms_st
        {
            get => _vl_icms_st;
            set => _vl_icms_st = value;
        }

        public decimal? vl_red_bc
        {
            get => _vl_red_bc;
            set => _vl_red_bc = value;
        }

        public decimal? vl_ipi
        {
            get => _vl_ipi;
            set => _vl_ipi = value;
        }

        public string cod_obs
        {
            get => _cod_obs;
            set => _cod_obs = value;
        }
    }

    public class dEfd
    {
    }

}
