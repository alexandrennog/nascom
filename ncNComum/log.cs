using System;
using ncNComum.nsAcessoBD;


namespace ncNComum
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
                    cFuncoes.PersistirTexto(dataHoraFormatada) + "," +
                    cFuncoes.PersistirTexto(descricao) + "," +
                    cFuncoes.PersistirTexto(usuario) + ")";

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
                    cFuncoes.PersistirTexto(dataHoraFormatada) + "," +
                    cFuncoes.PersistirInteiro(usuarioCID) + "," +
                    cFuncoes.PersistirTexto(usuarioNome) + "," +
                    cFuncoes.PersistirInteiro(origemCID) + "," +
                    cFuncoes.PersistirTexto(origemRazao) + "," +
                    cFuncoes.PersistirInteiro(destinoCID) + "," +
                    cFuncoes.PersistirTexto(destinoRazao) + "," +
                    cFuncoes.PersistirInteiro(produtoCID) + "," +
                    cFuncoes.PersistirTexto(codigoBarras) + "," +
                    cFuncoes.PersistirInteiro(quantidade) + ")";

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
                    cFuncoes.PersistirTexto(dataHoraFormatada) + "," +
                    cFuncoes.PersistirInteiro(usuarioCID) + "," +
                    cFuncoes.PersistirTexto(usuarioNome) + "," +
                    cFuncoes.PersistirInteiro(produtoCID) + "," +
                    cFuncoes.PersistirTexto(codigoBarras) + "," +
                    cFuncoes.PersistirInteiro(quantidade) + ",null," +
                    cFuncoes.PersistirTexto(notaFiscalNumero) + "," +
                    cFuncoes.PersistirTexto(notaFiscalSerie) + ")";

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
                    cFuncoes.PersistirInteiro(usuarioCID) + "," +
                    cFuncoes.PersistirTexto(usuarioNome) + "," +
                    cFuncoes.PersistirInteiro(produtoCID) + "," +
                    cFuncoes.PersistirTexto(codigoBarras) + "," +
                    cFuncoes.PersistirData(dataHoraFormatada) + "," +
                    cFuncoes.PersistirInteiro(quantidadeEstoque) + "," +
                    cFuncoes.PersistirInteiro(quantidadeAtualizacao) + ")";

                acessoBanco.ExecutarINT(comandoSQL);
            }
            catch { }
        }
    }
}
