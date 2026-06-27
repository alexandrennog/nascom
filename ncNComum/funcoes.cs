using System;
using System.Globalization;

namespace ncNComum.nsFuncoes
{
    public class cFuncoes
    {
        public static string PersistirTexto(string valor)
        {
            return PersistirTexto(valor, true);
        }

        public static string PersistirTexto(string valor, bool haspas)
        {
            try
            {
                if (valor == null) return "NULL";
                if (valor.Trim() == string.Empty) return "NULL";
                return haspas ? "'" + valor + "'" : valor;
            }
            catch { return "NULL"; }
        }

        public static string PersistirInteiro(object valor)
        {
            try
            {
                if (valor == null) return "NULL";
                if (valor.ToString().Trim() == string.Empty) return "NULL";
                return valor.ToString();
            }
            catch { return "NULL"; }
        }

        public static string PersistirBoleano(object valor)
        {
            try
            {
                if (valor == null) return "NULL";
                return (bool)valor ? "1" : "0";
            }
            catch { return "NULL"; }
        }

        public static string PersistirDecimal(object valor)
        {
            try
            {
                if (valor == null) return "NULL";
                string s = valor.ToString().Trim();
                if (s == string.Empty) return "NULL";
                if (s.IndexOf(",") > 0)
                    return s.Replace(".", "").Replace(",", ".");
                else
                {
                    string r = Convert.ToDecimal(s).ToString("0.00");
                    return r.Replace(".", "").Replace(",", ".");
                }
            }
            catch { return "NULL"; }
        }

        public static string PersistirData(object valor)
        {
            try
            {
                if (valor == null) return "NULL";
                string s = valor.ToString().Trim();
                if (s == string.Empty || s == "000000" || valor.Equals(DateTime.MinValue)) return "NULL";

                if (s.IndexOf("-") <= 0)
                {
                    s = FormatarData(s);
                    s = s.Substring(4, 4) + "-" + s.Substring(2, 2) + "-" + s.Substring(0, 2);
                }

                if (DateTime.TryParse(s, out DateTime dataEntrada))
                {
                    if (dataEntrada == DateTime.MinValue) return "NULL";
                    return "'" + dataEntrada.ToString("yyyy-MM-dd") + "'";
                }
                return "NULL";
            }
            catch { return "NULL"; }
        }

        public static string PersistirDataHora(object valor)
        {
            try
            {
                if (valor == null) return "NULL";
                string s = valor.ToString().Trim();
                if (s == string.Empty) return "NULL";
                if (DateTime.TryParse(s, out DateTime dataEntrada))
                {
                    if (dataEntrada == DateTime.MinValue) return "NULL";
                    return "'" + dataEntrada.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
                return "NULL";
            }
            catch { return "NULL"; }
        }

        public static string TratarTexto(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor.ToString().Trim() == string.Empty) return null;
                return valor.ToString().Trim();
            }
            catch { return null; }
        }

        public static string FormatarTextoDecimal(string valor, string ehDecimal)
        {
            try
            {
                if (valor == null) return null;
                if (valor.Trim() == string.Empty) return null;
                if (ehDecimal == "1")
                    return string.Format(CultureInfo.InvariantCulture, "{0:n}", Convert.ToInt32(valor));
                else
                    return Convert.ToInt32(valor).ToString();
            }
            catch { return null; }
        }

        public static int? TratarInteiro(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor.ToString().Trim() == string.Empty) return null;
                return Convert.ToInt32(valor.ToString().Trim());
            }
            catch { return null; }
        }

        public static decimal? TratarDecimal(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor.ToString().Trim() == string.Empty) return null;
                return Convert.ToDecimal(valor.ToString().Replace("R$", ""));
            }
            catch { return null; }
        }

        public static string RetornarTexto(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                return valor.ToString();
            }
            catch { return null; }
        }

        public static string RetornarTexto(object valor, int tamanho)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                string s = valor.ToString();
                return s.Length > tamanho ? s.Substring(0, tamanho) : s;
            }
            catch { return null; }
        }

        public static string RetornarVazio(object valor)
        {
            try
            {
                if (valor == null) return "";
                if (valor is DBNull) return "";
                return valor.ToString();
            }
            catch { return null; }
        }

        public static int? RetornarInteiro(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                return Convert.ToInt32(valor.ToString());
            }
            catch { return null; }
        }

        public static bool? RetornarBoleano(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                return Convert.ToBoolean(valor);
            }
            catch { return null; }
        }

        public static decimal? RetornarDecimal(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                return Convert.ToDecimal(valor.ToString());
            }
            catch { return null; }
        }

        public static DateTime? RetornarData(object valor)
        {
            try
            {
                if (valor == null) return null;
                if (valor is DBNull) return null;
                return Convert.ToDateTime(valor.ToString());
            }
            catch { return null; }
        }

        public static DateTime RetornarDataValida(string valor)
        {
            try
            {
                if (valor != null && !(valor is DBNull))
                {
                    string dataFormatada = valor.Substring(4, 4) + "-" + valor.Substring(2, 2) + "-" + valor.Substring(0, 2);
                    return Convert.ToDateTime(dataFormatada);
                }
            }
            catch { }
            return DateTime.MinValue;
        }

        public static bool ValidarValor(object valor)
        {
            try
            {
                if (valor == null) return false;
                return !valor.ToString().Trim().Equals(string.Empty);
            }
            catch { return false; }
        }

        public static string MontarParametrosSQL(string parametros, string valor)
        {
            try
            {
                string retorno = string.Empty;
                if (!string.IsNullOrEmpty(valor))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        retorno = " AND ";
                    retorno += valor;
                }
                return parametros + retorno;
            }
            catch { return string.Empty; }
        }

        public static string MontarParametrosSQL(string parametros, object valor, string nomeCampo)
        {
            return MontarParametrosSQL(parametros, valor, nomeCampo, false);
        }

        public static string MontarParametrosSQL(string parametros, object valor, string nomeCampo, bool usarLike)
        {
            try
            {
                string retorno = string.Empty;
                if (ValidarValor(valor))
                {
                    if (!parametros.Equals(string.Empty))
                        retorno = " AND ";

                    switch (valor.GetType().Name.ToLower())
                    {
                        case "int32":
                            retorno += " ( " + nomeCampo + " = " + PersistirInteiro(valor) + " ) ";
                            break;
                        case "decimal":
                            retorno += " ( " + nomeCampo + " = " + PersistirDecimal(valor) + " ) ";
                            break;
                        case "boolean":
                            retorno += " ( " + nomeCampo + " = " + PersistirBoleano(valor) + " ) ";
                            break;
                        default:
                            if (!usarLike)
                                retorno += " ( " + nomeCampo + " = " + PersistirTexto(valor.ToString()) + " ) ";
                            else
                                retorno += " ( " + nomeCampo + " LIKE '%" + PersistirTexto(valor.ToString(), false) + "%' ) ";
                            break;
                    }
                }
                return parametros + retorno;
            }
            catch { return string.Empty; }
        }

        public static string RemoverCaracterEspecial(string parametro)
        {
            return parametro.Replace("ç", "c").Replace("Ç", "C").Replace("ã", "a").Replace("Ã", "A");
        }

        public static bool ValidarData(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return false;
                if (valor.Length != 8) return false;
                string dataFormatada = valor.Substring(4, 4) + "-" + valor.Substring(2, 2) + "-" + valor.Substring(0, 2);
                return DateTime.TryParse(dataFormatada, out _);
            }
            catch { return false; }
        }

        public static bool ValidarLong(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return false;
                return long.TryParse(valor, out _);
            }
            catch { return false; }
        }

        public static bool ValidarInteiro(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return false;
                return int.TryParse(valor, out _);
            }
            catch { return false; }
        }

        public static bool ValidarDecimal(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return false;
                return decimal.TryParse(valor, out _);
            }
            catch { return false; }
        }

        public static string FormatarValorSemDecimal(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;
                return valor.Trim().Replace(",", "").Replace(".", "");
            }
            catch { return null; }
        }

        public static string FormatarData(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;

                if (valor.Contains("/"))
                {
                    DateTime dataAux = Convert.ToDateTime(valor);
                    string dataFormatada = dataAux.Day.ToString().PadLeft(2, '0') +
                        dataAux.Month.ToString().PadLeft(2, '0') +
                        dataAux.Year.ToString().PadLeft(4, '0');
                    string dataFormatadaSep = dataAux.Year.ToString().PadLeft(4, '0') + "-" +
                        dataAux.Month.ToString().PadLeft(2, '0') + "-" +
                        dataAux.Day.ToString().PadLeft(2, '0');
                    return DateTime.TryParse(dataFormatadaSep, out _) ? dataFormatada : null;
                }
                else
                {
                    if (valor.Length != 8) return null;
                    string dataFormatadaSep = valor.Substring(4, 4) + "-" + valor.Substring(2, 2) + "-" + valor.Substring(0, 2);
                    return DateTime.TryParse(dataFormatadaSep, out _) ? dataFormatadaSep : null;
                }
            }
            catch { return null; }
        }

        public static string FormatarDataHoraAAAAMMDDHHMMSS(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                if (DateTime.TryParse(dataAux.ToString(), out _))
                {
                    return dataAux.Year.ToString().PadLeft(4, '0') +
                        dataAux.Month.ToString().PadLeft(2, '0') +
                        dataAux.Day.ToString().PadLeft(2, '0') +
                        dataAux.Hour.ToString().PadLeft(2, '0') +
                        dataAux.Minute.ToString().PadLeft(2, '0') +
                        dataAux.Second.ToString().PadLeft(2, '0');
                }
                return null;
            }
            catch { return null; }
        }

        public static string FormatarDataDDMMAAAA(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                if (DateTime.TryParse(dataAux.ToString(), out _))
                {
                    return dataAux.Day.ToString().PadLeft(2, '0') +
                        dataAux.Month.ToString().PadLeft(2, '0') +
                        dataAux.Year.ToString().PadLeft(4, '0');
                }
                return null;
            }
            catch { return null; }
        }

        public static string FormatarDataBarras(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;

                if (valor.Contains("/"))
                {
                    DateTime dataAux = Convert.ToDateTime(valor);
                    string dataFormatada = dataAux.Day.ToString().PadLeft(2, '0') + "/" +
                        dataAux.Month.ToString().PadLeft(2, '0') + "/" +
                        dataAux.Year.ToString().PadLeft(4, '0');
                    return DateTime.TryParse(dataFormatada, out _) ? dataFormatada : null;
                }
                else
                {
                    if (valor.Length != 8) return null;
                    string dataFormatada = valor.Substring(0, 2) + "/" + valor.Substring(2, 2) + "/" + valor.Substring(4, 4);
                    return DateTime.TryParse(dataFormatada, out _) ? dataFormatada : null;
                }
            }
            catch { return null; }
        }

        public static string FormatarDataUniversal(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;

                if (valor.Contains("/"))
                {
                    DateTime dataAux = Convert.ToDateTime(valor);
                    string dataFormatada = dataAux.Year.ToString().PadLeft(4, '0') + "-" +
                        dataAux.Month.ToString().PadLeft(2, '0') + "-" +
                        dataAux.Day.ToString().PadLeft(2, '0');
                    return DateTime.TryParse(dataFormatada, out _) ? dataFormatada : null;
                }
                else
                {
                    if (valor.Length != 8) return null;
                    string dataFormatada = valor.Substring(4, 4) + "-" + valor.Substring(2, 2) + "-" + valor.Substring(0, 2);
                    return DateTime.TryParse(dataFormatada, out _) ? dataFormatada : null;
                }
            }
            catch { return null; }
        }

        public static string FormatarDataUniversalBarras(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                if (DateTime.TryParse(dataAux.ToString(), out _))
                {
                    return dataAux.Day.ToString().PadLeft(2, '0') + "/" +
                        dataAux.Month.ToString().PadLeft(2, '0') + "/" +
                        dataAux.Year.ToString().PadLeft(4, '0');
                }
                return null;
            }
            catch { return null; }
        }

        public static DateTime? ConverterDataUniversalDATETIME(string valor)
        {
            try
            {
                if (valor == null || valor.Trim() == string.Empty) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                if (DateTime.TryParse(dataAux.ToString(), out DateTime data))
                    return data;
                return null;
            }
            catch { return null; }
        }

        public static string ConverterDATETIMEDataBarras(DateTime? valor)
        {
            try
            {
                if (valor == null) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                return dataAux.Day.ToString().PadLeft(2, '0') + "/" +
                    dataAux.Month.ToString().PadLeft(2, '0') + "/" +
                    dataAux.Year.ToString().PadLeft(4, '0');
            }
            catch { return null; }
        }

        public static string ConverterDATETIMEDataUniversal(DateTime? valor)
        {
            try
            {
                if (valor == null) return null;
                DateTime dataAux = Convert.ToDateTime(valor);
                return dataAux.Year.ToString().PadLeft(4, '0') + "-" +
                    dataAux.Month.ToString().PadLeft(2, '0') + "-" +
                    dataAux.Day.ToString().PadLeft(2, '0');
            }
            catch { return null; }
        }

        public static bool SoNumero(char tecla)
        {
            if ((tecla >= '0' && tecla <= '9') || tecla == ',' || tecla == '.' || tecla == (char)8 || tecla == (char)9)
                return false;
            return true;
        }

        public static string ObterCodigoBarrasProduto(string codigoBarras)
        {
            string retorno = string.Empty;
            if (!codigoBarras.Trim().Equals(string.Empty))
            {
                if (long.TryParse(codigoBarras, out long inteiro))
                {
                    inteiro++;
                    retorno = inteiro.ToString().PadLeft(14, '0');
                }
            }
            return retorno;
        }

        public static bool ValidaCpf(string CPF)
        {
            if (string.IsNullOrEmpty(CPF)) return true;

            string strcampo = CPF.Length >= 9 ? CPF.Substring(0, 9) : CPF;
            long lngSoma = 0;

            for (int i = 2; i <= 10; i++)
            {
                string strCaracter = strcampo.Substring(strcampo.Length - (i - 1));
                int intNumero = int.Parse(strCaracter.Substring(0, 1));
                lngSoma += intNumero * i;
            }

            double dblDivisao = lngSoma / 11.0;
            long lngInteiro = (long)dblDivisao * 11;
            int intResto = (int)(lngSoma - lngInteiro);
            int intDig1 = (intResto == 0 || intResto == 1) ? 0 : 11 - intResto;

            strcampo += intDig1.ToString();
            lngSoma = 0;

            for (int i = 2; i <= 11; i++)
            {
                string strCaracter = strcampo.Substring(strcampo.Length - (i - 1));
                int intNumero = int.Parse(strCaracter.Substring(0, 1));
                lngSoma += intNumero * i;
            }

            dblDivisao = lngSoma / 11.0;
            lngInteiro = (long)dblDivisao * 11;
            intResto = (int)(lngSoma - lngInteiro);
            int intDig2 = (intResto == 0 || intResto == 1) ? 0 : 11 - intResto;

            string strConf = intDig1.ToString() + intDig2.ToString();
            return strConf == CPF.Substring(CPF.Length - 2);
        }

        public static bool ValidaCnpj(string strCNPJ)
        {
            if (strCNPJ.Length != 14) return false;
            if (!long.TryParse(strCNPJ, out _)) return false;

            double a = 0, d1 = 0, d2 = 0;
            double j = 5;

            for (int i = 1; i <= 12; i++)
            {
                a += double.Parse(strCNPJ.Substring(i - 1, 1)) * j;
                j = j > 2 ? j - 1 : 9;
            }

            a = a % 11;
            d1 = a > 1 ? 11 - a : 0;

            a = 0;
            j = 6;

            for (int i = 1; i <= 13; i++)
            {
                a += double.Parse(strCNPJ.Substring(i - 1, 1)) * j;
                j = j > 2 ? j - 1 : 9;
            }

            a = a % 11;
            d2 = a > 1 ? 11 - a : 0;

            return d1 == double.Parse(strCNPJ.Substring(12, 1)) &&
                   d2 == double.Parse(strCNPJ.Substring(13, 1));
        }
    }
}
