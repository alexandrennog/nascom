using ncModelos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ncNComum
{
    public class ColecaoLinha : List<string> { }

    public class ColecaoEtiqueta : List<ColecaoLinha> { }

    public class EtiquetaProduto
    {
        private string _campo1;
        private string _campo2;
        private string _campo3;
        private string _campo4;
        private string _campo5;
        private string _campo6;
        private string _campo7;
        private string _campo8;
        private string _codigoBarras;
        private ColecaoLinha colecaoLinha;
        private ColecaoEtiqueta colecaoEtiqueta;

        public string campo1 { set { _campo1 = value; } }
        public string campo2 { set { _campo2 = value; } }
        public string campo3 { set { _campo3 = value; } }
        public string campo4 { set { _campo4 = value; } }
        public string campo5 { set { _campo5 = value; } }
        public string campo6 { set { _campo6 = value; } }
        public string campo7 { set { _campo7 = value; } }
        public string campo8 { set { _campo8 = value; } }
        public string codigoBarras { set { _codigoBarras = value; } }

        private void MontarCamposEtiquetaProduto(string loja, string fabricante,
            dProduto produto, ColecaoProdutoItem colecaoItem, string cor,
            bool imprimirPreco, string imprimeDataEtiqueta)
        {
            string tamanho = string.Empty;
            string codigoBarras = string.Empty;
            string data = string.Empty;

            foreach (dProdutoItem _item in colecaoItem)
            {
                switch (_item.caracteristicas_codigo)
                {
                    case "codigoBarras": codigoBarras = _item.valor; break;
                    case "tamanho": tamanho = _item.valor; break;
                }
            }

            if (imprimeDataEtiqueta.Equals("1"))
                data = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0');
            else
                data = string.Empty;

            _campo1 = loja == null ? string.Empty : loja;
            _campo2 = produto.referencia == null ? string.Empty : produto.referencia;
            _campo3 = fabricante == null ? string.Empty : fabricante;
            _campo4 = data == null ? string.Empty : data;
            _campo5 = produto.descricao == null ? string.Empty : produto.descricao;
            _campo6 = cor == null ? string.Empty : cor;
            _campo7 = tamanho == null ? string.Empty : tamanho;
            _campo8 = imprimirPreco ? (produto.valorVenda == null ? string.Empty : produto.valorVenda.ToString()) : string.Empty;
            _codigoBarras = codigoBarras == null ? string.Empty : codigoBarras;
        }

        public void ImprimirColecaoEtiquetaProduto(ColecaoEtiquetaProdutoImpressao colecao, bool imprimirPreco, string tamanho, string imprimeDataEtiqueta)
        {
            if (colecao.Count > 0)
            {
                colecaoEtiqueta = new ColecaoEtiqueta();
                var impressao = new Impressao();
                int contador = 1;

                foreach (dEtiquetaProdutoImpressao itemEtiqueta in colecao)
                {
                    if (contador % 2 != 0)
                    {
                        MontarEtiquetaProdutoInicio();
                        MontarCamposEtiquetaProduto(itemEtiqueta.loja, itemEtiqueta.fabricante, itemEtiqueta.produto, itemEtiqueta.colecaoProdutoItem, itemEtiqueta.corNome, imprimirPreco, imprimeDataEtiqueta);
                        MontarEtiquetaProdutoEsquerda(tamanho);
                    }
                    if (contador % 2 == 0)
                    {
                        MontarCamposEtiquetaProduto(itemEtiqueta.loja, itemEtiqueta.fabricante, itemEtiqueta.produto, itemEtiqueta.colecaoProdutoItem, itemEtiqueta.corNome, imprimirPreco, imprimeDataEtiqueta);
                        MontarEtiquetaProdutoDireita(tamanho);
                        MontarEtiquetaProdutoFim();
                    }
                    contador++;
                }

                if (contador % 2 == 0)
                    MontarEtiquetaProdutoFim();

                impressao.StartWrite(ConfigurationManager.AppSettings["ETIQUETA"]);
                foreach (var cl in colecaoEtiqueta)
                    foreach (string linha in cl)
                        impressao.Write(linha);
                impressao.EndWrite();
            }
        }

        private void MontarEtiquetaProdutoInicio()
        {
            colecaoLinha = new ColecaoLinha();
            colecaoLinha.Add((char)2 + "L" + (char)13);
            colecaoLinha.Add((char)2 + "m" + (char)13);
            colecaoLinha.Add((char)2 + "r" + (char)13);
            colecaoLinha.Add("PC" + (char)13);
            colecaoLinha.Add("D11" + (char)13);
            colecaoLinha.Add("H14" + (char)13);
            colecaoLinha.Add("z" + (char)13);
            colecaoLinha.Add(((char)13).ToString());
            colecaoEtiqueta.Add(colecaoLinha);
        }

        private void MontarEtiquetaProdutoEsquerda(string tamanho)
        {
            string c1 = _campo1.PadRight(22, ' ').Substring(0, 22);
            string c2 = _campo2.PadRight(15, ' ').Substring(0, 15);
            string c3 = _campo3.PadRight(14, ' ').Substring(0, 14);
            string c4 = _campo4.PadLeft(14, ' ').Substring(0, 14);
            string c5 = _campo5.PadRight(14, ' ').Substring(0, 14);
            string c6 = _campo6.PadLeft(14, ' ').Substring(0, 14);
            string c7 = _campo7.PadRight(11, ' ').Substring(0, 11);
            string c8 = _campo8.PadLeft(11, ' ').Substring(0, 11);
            string cb = _codigoBarras.PadLeft(14, ' ').Substring(0, 14).Trim();

            colecaoLinha = new ColecaoLinha();
            if (tamanho.Equals("50x70"))
            {
                colecaoLinha.Add("122200005900030" + c1 + (char)13);
                colecaoLinha.Add("113200005000030" + c2 + (char)13);
                colecaoLinha.Add("121100004200030" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("121100003600030" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d7307002600030" + cb + (char)13);
                colecaoLinha.Add("112200001600100" + cb + (char)13);
                colecaoLinha.Add("121200000500030" + c7 + "       " + c8 + (char)13);
            }
            else
            {
                colecaoLinha.Add("121100002100050" + c1 + (char)13);
                colecaoLinha.Add("112100001900050" + c2 + (char)13);
                colecaoLinha.Add("111100001700050" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("111100001500050" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d6207000700050" + cb + (char)13);
                colecaoLinha.Add("121100000400120" + cb + (char)13);
                colecaoLinha.Add("121100000100050" + c7 + " " + c8 + (char)13);
            }
            colecaoEtiqueta.Add(colecaoLinha);
        }

        private void MontarEtiquetaProdutoDireita(string tamanho)
        {
            string c1 = _campo1.PadRight(22, ' ').Substring(0, 22);
            string c2 = _campo2.PadRight(15, ' ').Substring(0, 15);
            string c3 = _campo3.PadRight(14, ' ').Substring(0, 14);
            string c4 = _campo4.PadLeft(14, ' ').Substring(0, 14);
            string c5 = _campo5.PadRight(14, ' ').Substring(0, 14);
            string c6 = _campo6.PadLeft(14, ' ').Substring(0, 14);
            string c7 = _campo7.PadRight(11, ' ').Substring(0, 11);
            string c8 = _campo8.PadLeft(11, ' ').Substring(0, 11);
            string cb = _codigoBarras.PadLeft(14, ' ').Substring(0, 14).Trim();

            colecaoLinha = new ColecaoLinha();
            if (tamanho.Equals("50x70"))
            {
                colecaoLinha.Add("122200005900535" + c1 + (char)13);
                colecaoLinha.Add("113200005000535" + c2 + (char)13);
                colecaoLinha.Add("121100004200535" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("121100003600535" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d7307002600535" + cb + (char)13);
                colecaoLinha.Add("112200001600585" + cb + (char)13);
                colecaoLinha.Add("121200000500535" + c7 + "       " + c8 + (char)13);
            }
            else
            {
                colecaoLinha.Add("121100002100475" + c1 + (char)13);
                colecaoLinha.Add("112100001900475" + c2 + (char)13);
                colecaoLinha.Add("111100001700475" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("111100001500475" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d6207000700475" + cb + (char)13);
                colecaoLinha.Add("121100000400525" + cb + (char)13);
                colecaoLinha.Add("121100000100475" + c7 + " " + c8 + (char)13);
            }
            colecaoEtiqueta.Add(colecaoLinha);
        }

        private void MontarEtiquetaProdutoFim()
        {
            colecaoLinha = new ColecaoLinha();
            colecaoLinha.Add(((char)13).ToString());
            colecaoLinha.Add("Q0001" + (char)13);
            colecaoLinha.Add((char)2 + "E" + (char)13);
            colecaoEtiqueta.Add(colecaoLinha);
        }

        public void ImprimirEtiquetaProduto(string loja, string fornecedor,
            dProduto produto, ColecaoProdutoItem colecaoItem, int quantidade,
            string cor, bool imprimirPreco, string tamanho, string imprimeDataEtiqueta)
        {
            var impressao = new Impressao();
            MontarEtiquetaProduto(loja, fornecedor, produto, colecaoItem, quantidade, cor, imprimirPreco, tamanho, imprimeDataEtiqueta);

            impressao.StartWrite(ConfigurationManager.AppSettings["ETIQUETA"]);
            foreach (var cl in colecaoEtiqueta)
                foreach (string linha in cl)
                    impressao.Write(linha);
            impressao.EndWrite();
        }

        private void MontarEtiquetaProduto(string loja, string fornecedor,
            dProduto produto, ColecaoProdutoItem colecaoItem, int quantidade,
            string cor, bool imprimirPreco, string tamanho, string imprimeDataEtiqueta)
        {
            MontarCamposEtiquetaProduto(loja, fornecedor, produto, colecaoItem, cor, imprimirPreco, imprimeDataEtiqueta);

            bool colunaDireita;
            int qtdeLinha;
            if ((quantidade % 2) > 0)
            {
                qtdeLinha = ((quantidade - 1) / 2) + 1;
                colunaDireita = false;
            }
            else
            {
                qtdeLinha = quantidade / 2;
                colunaDireita = true;
            }

            colecaoEtiqueta = new ColecaoEtiqueta();

            for (int cont = 1; cont <= qtdeLinha; cont++)
            {
                PreencherDadosEtiquetaProduto(cont == qtdeLinha ? colunaDireita : true, tamanho);
            }
        }

        private void PreencherDadosEtiquetaProduto(bool colunaDireita, string tamanho)
        {
            string c1 = _campo1.PadRight(22, ' ').Substring(0, 22);
            string c2 = _campo2.PadRight(15, ' ').Substring(0, 15);
            string c3 = _campo3.PadRight(14, ' ').Substring(0, 14);
            string c4 = _campo4.PadLeft(14, ' ').Substring(0, 14);
            string c5 = _campo5.PadRight(14, ' ').Substring(0, 14);
            string c6 = _campo6.PadLeft(14, ' ').Substring(0, 14);
            string c7 = _campo7.PadRight(11, ' ').Substring(0, 11);
            string c8 = _campo8.PadLeft(11, ' ').Substring(0, 11);
            string cb = _codigoBarras.PadLeft(14, ' ').Substring(0, 14).Trim();

            colecaoLinha = new ColecaoLinha();
            colecaoLinha.Add((char)2 + "L" + (char)13);
            colecaoLinha.Add((char)2 + "m" + (char)13);
            colecaoLinha.Add((char)2 + "r" + (char)13);
            colecaoLinha.Add("PC" + (char)13);
            colecaoLinha.Add("D11" + (char)13);
            colecaoLinha.Add("H14" + (char)13);
            colecaoLinha.Add("z" + (char)13);
            colecaoLinha.Add(((char)13).ToString());

            if (colunaDireita)
            {
                if (tamanho.Equals("50x70"))
                {
                    colecaoLinha.Add("122200005900535" + c1 + (char)13);
                    colecaoLinha.Add("113200005000535" + c2 + (char)13);
                    colecaoLinha.Add("121100004200535" + c3 + "  " + c4 + (char)13);
                    colecaoLinha.Add("121100003600535" + c5 + "  " + c6 + (char)13);
                    colecaoLinha.Add("1d7307002600535" + cb + (char)13);
                    colecaoLinha.Add("112200001600585" + cb + (char)13);
                    colecaoLinha.Add("121200000500535" + c7 + "       " + c8 + (char)13);
                }
                else
                {
                    colecaoLinha.Add("121100002100450" + c1 + (char)13);
                    colecaoLinha.Add("112100001900450" + c2 + (char)13);
                    colecaoLinha.Add("111100001700450" + c3 + "  " + c4 + (char)13);
                    colecaoLinha.Add("111100001500450" + c5 + "  " + c6 + (char)13);
                    colecaoLinha.Add("1d6207000700450" + cb + (char)13);
                    colecaoLinha.Add("121100000400520" + cb + (char)13);
                    colecaoLinha.Add("121100000100450" + c7 + " " + c8 + (char)13);
                }
            }

            if (tamanho.Equals("50x70"))
            {
                colecaoLinha.Add("122200005900030" + c1 + (char)13);
                colecaoLinha.Add("113200005000030" + c2 + (char)13);
                colecaoLinha.Add("121100004200030" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("121100003600030" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d7307002600030" + cb + (char)13);
                colecaoLinha.Add("112200001600100" + cb + (char)13);
                colecaoLinha.Add("121200000500030" + c7 + "       " + c8 + (char)13);
            }
            else
            {
                colecaoLinha.Add("121100002100050" + c1 + (char)13);
                colecaoLinha.Add("112100001900050" + c2 + (char)13);
                colecaoLinha.Add("111100001700050" + c3 + "  " + c4 + (char)13);
                colecaoLinha.Add("111100001500050" + c5 + "  " + c6 + (char)13);
                colecaoLinha.Add("1d6207000700050" + cb + (char)13);
                colecaoLinha.Add("121100000400120" + cb + (char)13);
                colecaoLinha.Add("121100000100050" + c7 + " " + c8 + (char)13);
            }

            colecaoLinha.Add(((char)13).ToString());
            colecaoLinha.Add("Q0001" + (char)13);
            colecaoLinha.Add((char)2 + "E" + (char)13);
            colecaoEtiqueta.Add(colecaoLinha);
        }
    }

    public class ColecaoEtiquetaMalaDireta : List<dEtiquetaMalaDireta> { }

    public class dEtiquetaMalaDireta
    {
        public string NomeCliente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public dEtiquetaMalaDireta()
        {
            NomeCliente = string.Empty;
            Logradouro = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Cep = string.Empty;
        }

        public dEtiquetaMalaDireta(string nome, string logradouro, string numero, string complemento,
            string bairro, string cidade, string estado, string cep)
        {
            NomeCliente = nome ?? string.Empty;
            Logradouro = logradouro ?? string.Empty;
            Numero = numero ?? string.Empty;
            Complemento = complemento ?? string.Empty;
            Bairro = bairro ?? string.Empty;
            Cidade = cidade ?? string.Empty;
            Estado = estado ?? string.Empty;
            Cep = cep ?? string.Empty;
        }

        public void ImprimirEtiquetaMalaDireta(ColecaoEtiquetaMalaDireta colecaoEtiquetaMalaDireta)
        {
            var ColecaoLinha = new ColecaoLinha();
            var colecaoEtiqueta = new ColecaoEtiqueta();
            var impressao = new Impressao();

            foreach (dEtiquetaMalaDireta etiqueta in colecaoEtiquetaMalaDireta)
            {
                ColecaoLinha.Add((char)2 + "L" + (char)13);
                ColecaoLinha.Add((char)2 + "m" + (char)13);
                ColecaoLinha.Add((char)2 + "r" + (char)13);
                ColecaoLinha.Add("PC" + (char)13);
                ColecaoLinha.Add("D11" + (char)13);
                ColecaoLinha.Add("H14" + (char)13);
                ColecaoLinha.Add("z" + (char)13);
                ColecaoLinha.Add(((char)13).ToString());
                ColecaoLinha.Add("131100202100050" + etiqueta.NomeCliente + (char)13);
                ColecaoLinha.Add("131100201700050" + etiqueta.Logradouro + " " + etiqueta.Numero + " " + etiqueta.Complemento + (char)13);
                ColecaoLinha.Add("131100201300050" + etiqueta.Bairro + (char)13);
                ColecaoLinha.Add("131100200900050" + etiqueta.Cidade + " - " + etiqueta.Estado + (char)13);
                ColecaoLinha.Add("131100200500050" + etiqueta.Cep + (char)13);
                ColecaoLinha.Add(((char)13).ToString());
                ColecaoLinha.Add("Q0001" + (char)13);
                ColecaoLinha.Add((char)2 + "E" + (char)13);
                colecaoEtiqueta.Add(ColecaoLinha);
            }

            impressao.StartWrite(ConfigurationManager.AppSettings["ETIQUETA"]);
            foreach (var cl in colecaoEtiqueta)
                foreach (string linha in cl)
                    impressao.Write(linha);
            impressao.EndWrite();
        }
    }

    public class EtiquetaCrediario
    {
        private string _nomeLoja;
        private string _nomeCliente;
        private dCrediario _crediario;
        private ColecaoParcelas _colecaoParcelas;
        private ColecaoLinha _colecaoLinha;
        private ColecaoEtiqueta _colecaoEtiqueta;
        private int _contEtiqueta;

        public string nomeLoja { set { _nomeLoja = value; } }
        public string nomeCliente { set { _nomeCliente = value; } }

        public ColecaoEtiqueta MontarEtiqueta(ColecaoParcelas colecaoParcelas, dCrediario crediario,
            string NomeCliente, string nomeLoja, string tamanho)
        {
            _colecaoParcelas = colecaoParcelas;
            _crediario = crediario;
            _nomeCliente = NomeCliente;
            _nomeLoja = nomeLoja;

            int qtdeParcelas = _colecaoParcelas.Count;
            _contEtiqueta = 1;
            _colecaoEtiqueta = new ColecaoEtiqueta();

            int qtdeResumo = qtdeParcelas / 7;
            if (qtdeParcelas % 7 > 0) qtdeResumo++;

            for (int contador = 1; contador <= qtdeResumo; contador++)
            {
                if (_contEtiqueta % 2 != 0)
                {
                    _colecaoLinha = new ColecaoLinha();
                    MontarEtiquetaInicio();
                }
                MontarEtiquetaResumo(contador, tamanho);
                if (_contEtiqueta % 2 == 0)
                {
                    MontarEtiquetaFim();
                    _colecaoEtiqueta.Add(_colecaoLinha);
                }
                _contEtiqueta++;
            }

            for (int contador = 1; contador <= qtdeParcelas; contador++)
            {
                if (_contEtiqueta % 2 != 0)
                {
                    _colecaoLinha = new ColecaoLinha();
                    MontarEtiquetaInicio();
                }
                MontarEtiquetaParcela(contador, tamanho);
                if (_contEtiqueta % 2 == 0)
                {
                    MontarEtiquetaFim();
                    _colecaoEtiqueta.Add(_colecaoLinha);
                }
                _contEtiqueta++;
            }

            if (_contEtiqueta % 2 == 0)
            {
                MontarEtiquetaFim();
                _colecaoEtiqueta.Add(_colecaoLinha);
            }

            return _colecaoEtiqueta;
        }

        private void MontarEtiquetaResumo(int contador, string tamanho)
        {
            string posicao = _contEtiqueta % 2 != 0 ? "0040" : "0435";

            if (tamanho.Equals("50x70"))
            {
                _colecaoLinha.Add("12220000240" + posicao + _nomeLoja);
                _colecaoLinha.Add("12110000210" + posicao + _crediario.clienteId + "-" + _nomeCliente);
            }
            else
            {
                _colecaoLinha.Add("12110000215" + posicao + _nomeLoja);
                _colecaoLinha.Add("11110000195" + posicao + _crediario.clienteId + "-" + _nomeCliente);
            }

            for (int slot = 1; slot <= 7; slot++)
            {
                int indice = ((contador - 1) * 7) + slot;
                if (_colecaoParcelas.Count >= indice)
                {
                    int linha = tamanho.Equals("50x70") ? (195 - ((slot - 1) * 20)) : (175 - ((slot - 1) * 20));
                    _colecaoLinha.Add("11110000" + linha.ToString().PadLeft(3, '0') + posicao + indice.ToString().PadLeft(2, ' ') + "." +
                        _colecaoParcelas[indice - 1].dataVecimento.ToString("dd/MM/yyyy") + " " +
                        _colecaoParcelas[indice - 1].valorReceber.ToString("C"));
                }
            }

            if (tamanho.Equals("50x70"))
            {
                _colecaoLinha.Add("12110000030" + posicao + "TOTAL -->  " + _crediario.ValorTotal.ToString("C"));
                _colecaoLinha.Add("12110000001" + posicao + _crediario.DataVenda + "  CT:" + _crediario.controle.ToString());
            }
            else
            {
                _colecaoLinha.Add("12110000027" + posicao + "TOTAL -->  " + _crediario.ValorTotal.ToString("C"));
                _colecaoLinha.Add("11110000010" + posicao + _crediario.DataVenda + "  CT:" + _crediario.controle.ToString());
            }
        }

        private void MontarEtiquetaInicio()
        {
            _colecaoLinha.Add((char)2 + "L" + (char)13);
            _colecaoLinha.Add((char)2 + "m" + (char)13);
            _colecaoLinha.Add((char)2 + "r" + (char)13);
            _colecaoLinha.Add("PC" + (char)13);
            _colecaoLinha.Add("D11" + (char)13);
            _colecaoLinha.Add("H14" + (char)13);
            _colecaoLinha.Add("z" + (char)13);
            _colecaoLinha.Add(((char)13).ToString());
        }

        private void MontarEtiquetaFim()
        {
            _colecaoLinha.Add(((char)13).ToString());
            _colecaoLinha.Add("Q0001" + (char)13);
            _colecaoLinha.Add((char)2 + "E" + (char)13);
        }

        private void MontarEtiquetaParcela(int indice, string tamanho)
        {
            dParcelas parcela = _colecaoParcelas[indice - 1];

            if (tamanho.Equals("50x70"))
            {
                if (_contEtiqueta % 2 != 0)
                {
                    _colecaoLinha.Add("122200002800040" + _nomeLoja);
                    _colecaoLinha.Add("121100002400040" + _crediario.clienteId + "-" + _nomeCliente);
                    _colecaoLinha.Add("121100002100035" + indice.ToString().PadLeft(2, ' ') + "." + _colecaoParcelas[indice - 1].dataVecimento.ToString("dd/MM/yyyy") + " " + _colecaoParcelas[indice - 1].valorReceber.ToString("C"));
                    _colecaoLinha.Add("1d6208501000055" + _colecaoParcelas[indice - 1].codigoBarras);
                    _colecaoLinha.Add("121100000400100" + _colecaoParcelas[indice - 1].codigoBarras);
                }
                else
                {
                    _colecaoLinha.Add("122200002800550" + _nomeLoja);
                    _colecaoLinha.Add("121100002400550" + _crediario.clienteId + "-" + _nomeCliente);
                    _colecaoLinha.Add("121100002100550" + indice.ToString().PadLeft(2, ' ') + "." + _colecaoParcelas[indice - 1].dataVecimento.ToString("dd/MM/yyyy") + " " + _colecaoParcelas[indice - 1].valorReceber.ToString("C"));
                    _colecaoLinha.Add("1d6208501000565" + _colecaoParcelas[indice - 1].codigoBarras);
                    _colecaoLinha.Add("121100000400600" + _colecaoParcelas[indice - 1].codigoBarras);
                }
            }
            else
            {
                if (_contEtiqueta % 2 != 0)
                {
                    _colecaoLinha.Add("121100002100040" + _nomeLoja);
                    _colecaoLinha.Add("111100001900040" + _crediario.clienteId + "-" + _nomeCliente);
                    _colecaoLinha.Add("121100001600035" + indice.ToString().PadLeft(2, ' ') + "." + _colecaoParcelas[indice - 1].dataVecimento.ToString("dd/MM/yyyy") + " " + _colecaoParcelas[indice - 1].valorReceber.ToString("C"));
                    _colecaoLinha.Add("1d6208500500055" + _colecaoParcelas[indice - 1].codigoBarras);
                    _colecaoLinha.Add("121100000200100" + _colecaoParcelas[indice - 1].codigoBarras);
                }
                else
                {
                    _colecaoLinha.Add("121100002100460" + _nomeLoja);
                    _colecaoLinha.Add("111100001900460" + _crediario.clienteId + "-" + _nomeCliente);
                    _colecaoLinha.Add("121100001600450" + indice.ToString().PadLeft(2, ' ') + "." + _colecaoParcelas[indice - 1].dataVecimento.ToString("dd/MM/yyyy") + " " + _colecaoParcelas[indice - 1].valorReceber.ToString("C"));
                    _colecaoLinha.Add("1d6208500500475" + _colecaoParcelas[indice - 1].codigoBarras);
                    _colecaoLinha.Add("121100000200500" + _colecaoParcelas[indice - 1].codigoBarras);
                }
            }
        }
    }
}
