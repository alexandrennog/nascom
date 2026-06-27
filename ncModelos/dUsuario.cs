using System;
using System.Collections.Generic;

namespace nsModelos
{
    public class ColecaoUsuario : List<dUsuario>
    {
    }

    public class dUsuario
    {
        private int? _cid;
        private string _usuario;
        private string _senha;
        private string _nomeCompleto;
        private string _situacao;
        private int? _usuarioPerfil_cid;
        private string _usuarioPerfil_codigo;
        private decimal? _descontoProduto;
        private decimal? _descontoPedido;
        private decimal? _comissao;
        private string _email;

        public int? cid
        {
            get => _cid;
            set => _cid = value;
        }

        public string usuario
        {
            get => _usuario;
            set => _usuario = value;
        }

        public string senha
        {
            get => _senha;
            set => _senha = value;
        }

        public string nomeCompleto
        {
            get => _nomeCompleto;
            set => _nomeCompleto = value;
        }

        public string situacao
        {
            get => _situacao;
            set => _situacao = value;
        }

        public int? usuarioPerfil_cid
        {
            get => _usuarioPerfil_cid;
            set => _usuarioPerfil_cid = value;
        }

        public string usuarioPerfil_codigo
        {
            get => _usuarioPerfil_codigo;
            set => _usuarioPerfil_codigo = value;
        }

        public decimal? descontoProduto
        {
            get => _descontoProduto;
            set => _descontoProduto = value;
        }

        public decimal? descontoPedido
        {
            get => _descontoPedido;
            set => _descontoPedido = value;
        }

        public decimal? comissao
        {
            get => _comissao;
            set => _comissao = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }

}