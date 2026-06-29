using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Comum
{
    public class Impressao
    {
        private const int GENERIC_WRITE = 0x40000000;
        private const int OPEN_EXISTING = 3;
        private const int FILE_SHARE_WRITE = 0x2;

        private StreamWriter _fileWriter;
        private FileStream _outFile;
        private int _hPort;
        private string _porta;
        private string _arquivo, _diretorio;

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            private int nLength;
            private int lpSecurityDescriptor;
            private int bInheritHandle;
        }

        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        private static extern int CloseHandle(int hObject);

        [DllImport("kernel32", EntryPoint = "CreateFileA")]
        private static extern int CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode,
            [MarshalAs(UnmanagedType.Struct)] ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

        public void StartWrite(string printerPath)
        {
            SECURITY_ATTRIBUTES SA = new SECURITY_ATTRIBUTES();
            _porta = printerPath;

            if (_porta.Substring(0, 3) == "USB" || _porta.Substring(0, 3) == "LAZ" || _porta.Substring(0, 3) == "ELG")
            {
                _diretorio = @"c:\nascomercio\";
                _arquivo = @"c:\nascomercio\print.txt";

                if (!Directory.Exists(_diretorio))
                    Directory.CreateDirectory(_diretorio);

                if (File.Exists(_arquivo))
                {
                    File.Delete(_arquivo);
                    var criar = File.CreateText(_arquivo);
                    criar.Close();
                }
                else
                {
                    var criar = File.CreateText(_arquivo);
                    criar.Close();
                }
            }
            else
            {
                _hPort = CreateFile(printerPath, GENERIC_WRITE, FILE_SHARE_WRITE, ref SA, OPEN_EXISTING, 0, 0);
                IntPtr hPortP = new IntPtr(_hPort);
                _outFile = new FileStream(hPortP, FileAccess.Write);
                _fileWriter = new StreamWriter(_outFile);
            }
        }

        public void Write(string rawLine)
        {
            if (_porta.Substring(0, 3) == "USB" || _porta.Substring(0, 3) == "LAZ" || _porta.Substring(0, 3) == "ELG")
            {
                var codutf = System.Text.Encoding.GetEncoding("ISO-8859-1");
                var fluxoTexto = new StreamWriter(_arquivo, true, codutf);
                fluxoTexto.WriteLine(rawLine);
                fluxoTexto.Close();
            }
            else
            {
                _fileWriter.WriteLine(rawLine);
            }
        }

        public void EndWrite()
        {
            if (ConfigurationManager.AppSettings["CORTAR_PAPEL"] == "SIM")
                Write("<B1>m");

            if (_porta.Substring(0, 3) == "LAZ")
            {
                var p = new Process();
                var pi = new ProcessStartInfo("notepad.exe", "/p " + _arquivo);
                p.StartInfo = pi;
                p.Start();
            }
            else if (_porta.Substring(0, 3) == "USB")
            {
                File.Copy(_arquivo, "LPT" + _porta.Substring(3, 1), true);
            }
            else if (_porta.Substring(0, 3) == "ELG")
            {
                RawPrinterHelper.SendStringToPrinter("BTP-L42", File.ReadAllText(_arquivo));
            }
            else
            {
                _fileWriter.Flush();
                _fileWriter.Close();
                _outFile.Close();
                CloseHandle(_hPort);
            }
        }
    }
}
