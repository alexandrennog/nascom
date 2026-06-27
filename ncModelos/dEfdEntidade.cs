using System;

namespace nsEFD
{
    public class dEfdEntidade
    {
        private string _nomeEmpresarial;
        private string _tipoPessoa;
        private string _cpfCnpj;
        private string _uf;
        private int? _estados_cid;
        private string _ufSigla;
        private string _inscricaoEstadual;
        private string _codigoMunicipio;
        private string _municipioCodigoIbge;
        private string _inscricaoMunicipal;
        private string _inscricaoSuframa;
        private string _tipoAtividade;
        private string _nomeFantasia;

        public string nomeEmpresarial
        {
            get => _nomeEmpresarial;
            set => _nomeEmpresarial = value;
        }

        public string tipoPessoa
        {
            get => _tipoPessoa;
            set => _tipoPessoa = value;
        }

        public string cpfCnpj
        {
            get => _cpfCnpj;
            set => _cpfCnpj = value;
        }

        public string uf
        {
            get => _uf;
            set => _uf = value;
        }

        public int? estados_cid
        {
            get => _estados_cid;
            set => _estados_cid = value;
        }

        public string ufSigla
        {
            get => _ufSigla;
            set => _ufSigla = value;
        }

        public string inscricaoEstadual
        {
            get => _inscricaoEstadual;
            set => _inscricaoEstadual = value;
        }

        public string codigoMunicipio
        {
            get => _codigoMunicipio;
            set => _codigoMunicipio = value;
        }

        public string municipioCodigoIbge
        {
            get => _municipioCodigoIbge;
            set => _municipioCodigoIbge = value;
        }

        public string inscricaoMunicipal
        {
            get => _inscricaoMunicipal;
            set => _inscricaoMunicipal = value;
        }

        public string inscricaoSuframa
        {
            get => _inscricaoSuframa;
            set => _inscricaoSuframa = value;
        }

        public string tipoAtividade
        {
            get => _tipoAtividade;
            set => _tipoAtividade = value;
        }

        public string nomeFantasia
        {
            get => _nomeFantasia;
            set => _nomeFantasia = value;
        }
    }
}
