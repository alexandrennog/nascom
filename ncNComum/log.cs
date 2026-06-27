using System;
using ncNComum.nsAcessoBD;
using static ncNComum.nsFuncoes.cFuncoes;

namespace ncNComum.nsLog
{
    public class cLog
    {
        public static void GravarLog(string usuario, string descricao)
        {
            try
            {
                var acessoBanco = new cAcessoBD();
                DateTime dataHora = DateTime.Now;
                string dataHoraFormatada =
                    dataHora.Year.ToString().PadLeft(4, '0') + "-" +
                    dataHora.Month.ToString().PadLeft(2, '0') + "-" +
                    dataHora.Day.ToString().PadLeft(2, '0') + " " +
                    dataHora.Hour.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Minute.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Second.ToString().PadLeft(2, '0');

                string comandoSQL =
                    " INSERT INTO " +
                    " log ( data, descricao, usuario ) " +
                    " VALUES (" +
                    PersistirTexto(dataHoraFormatada) + "," +
                    PersistirTexto(descricao) + "," +
                    PersistirTexto(usuario) + ")";

                acessoBanco.ExecutarINT(comandoSQL);
            }
            catch { }
        }

        public static void GravarLogTransferencia(int origemCID, string origemRazao,
            int destinoCID, string destinoRazao, int usuarioCID, string usuarioNome,
            int produtoCID, string codigoBarras, int quantidade)
        {
            try
            {
                var acessoBanco = new cAcessoBD();
                DateTime dataHora = DateTime.Now;
                string dataHoraFormatada =
                    dataHora.Year.ToString().PadLeft(4, '0') + "-" +
                    dataHora.Month.ToString().PadLeft(2, '0') + "-" +
                    dataHora.Day.ToString().PadLeft(2, '0') + " " +
                    dataHora.Hour.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Minute.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Second.ToString().PadLeft(2, '0');

                string comandoSQL =
                    " INSERT INTO " +
                    " logtransferencia ( data, usuario_cid, usuario_nomeCompleto, lojaOrigem_cid, lojaOrigem_razaoSocial, " +
                    " lojaDestino_cid, lojaDestino_razaoSocial, produto_cid, produtoItem_codigoBarras, quantidade ) " +
                    " VALUES (" +
                    PersistirTexto(dataHoraFormatada) + "," +
                    PersistirInteiro(usuarioCID) + "," +
                    PersistirTexto(usuarioNome) + "," +
                    PersistirInteiro(origemCID) + "," +
                    PersistirTexto(origemRazao) + "," +
                    PersistirInteiro(destinoCID) + "," +
                    PersistirTexto(destinoRazao) + "," +
                    PersistirInteiro(produtoCID) + "," +
                    PersistirTexto(codigoBarras) + "," +
                    PersistirInteiro(quantidade) + ")";

                acessoBanco.ExecutarINT(comandoSQL);
            }
            catch { }
        }

        public static void GravarLogEstoque(int usuarioCID, string usuarioNome,
            int produtoCID, string codigoBarras, int quantidade,
            string notaFiscalNumero, string notaFiscalSerie)
        {
            try
            {
                var acessoBanco = new cAcessoBD();
                DateTime dataHora = DateTime.Now;
                string dataHoraFormatada =
                    dataHora.Year.ToString().PadLeft(4, '0') + "-" +
                    dataHora.Month.ToString().PadLeft(2, '0') + "-" +
                    dataHora.Day.ToString().PadLeft(2, '0') + " " +
                    dataHora.Hour.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Minute.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Second.ToString().PadLeft(2, '0');

                string comandoSQL =
                    " INSERT INTO " +
                    " logestoque ( data, usuario_cid, usuario_nomeCompleto, " +
                    " produto_cid, produtoItem_codigoBarras, quantidade, impressao, notaFiscalNumero, notaFiscalSerie ) " +
                    " VALUES (" +
                    PersistirTexto(dataHoraFormatada) + "," +
                    PersistirInteiro(usuarioCID) + "," +
                    PersistirTexto(usuarioNome) + "," +
                    PersistirInteiro(produtoCID) + "," +
                    PersistirTexto(codigoBarras) + "," +
                    PersistirInteiro(quantidade) + ",null," +
                    PersistirTexto(notaFiscalNumero) + "," +
                    PersistirTexto(notaFiscalSerie) + ")";

                acessoBanco.ExecutarINT(comandoSQL);
            }
            catch { }
        }

        public static void GravarLogBalanco(int usuarioCID, string usuarioNome,
            int produtoCID, string codigoBarras,
            int quantidadeEstoque, int quantidadeAtualizacao)
        {
            try
            {
                var acessoBanco = new cAcessoBD();
                DateTime dataHora = DateTime.Now;
                string dataHoraFormatada =
                    dataHora.Year.ToString().PadLeft(4, '0') + "-" +
                    dataHora.Month.ToString().PadLeft(2, '0') + "-" +
                    dataHora.Day.ToString().PadLeft(2, '0') + " " +
                    dataHora.Hour.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Minute.ToString().PadLeft(2, '0') + ":" +
                    dataHora.Second.ToString().PadLeft(2, '0');

                string comandoSQL =
                    " INSERT INTO " +
                    " logbalanco ( usuario_cid, usuario_nomeCompleto, " +
                    " produto_cid, produtoItem_codigoBarras, data, " +
                    " quantidadeEstoque, quantidadeAtualizacao ) " +
                    " VALUES (" +
                    PersistirInteiro(usuarioCID) + "," +
                    PersistirTexto(usuarioNome) + "," +
                    PersistirInteiro(produtoCID) + "," +
                    PersistirTexto(codigoBarras) + "," +
                    PersistirData(dataHoraFormatada) + "," +
                    PersistirInteiro(quantidadeEstoque) + "," +
                    PersistirInteiro(quantidadeAtualizacao) + ")";

                acessoBanco.ExecutarINT(comandoSQL);
            }
            catch { }
        }
    }
}
