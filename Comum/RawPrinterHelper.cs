using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Comum
{
    public class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPWStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)] public string pDataType;
        }

        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA")]
        private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv")]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA")]
        private static extern int StartDocPrinter(IntPtr hPrinter, int Level, [In] ref DOCINFOW pDocInfo);

        [DllImport("winspool.drv")]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv")]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv")]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv")]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBuf, int cdBuf, out int pcWritten);

        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
        {
            IntPtr hPrinter;
            var di = new DOCINFOW { pDocName = "VBDocument", pDataType = "RAW" };
            bool bSuccess = false;

            if (OpenPrinter(szPrinterName, out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, ref di) > 0)
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out _);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            if (!bSuccess)
                Marshal.GetLastWin32Error();

            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            var fs = new FileStream(szFileName, FileMode.Open);
            var br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((int)fs.Length);
            IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem((int)fs.Length);
            Marshal.Copy(bytes, 0, pUnmanagedBytes, (int)fs.Length);
            bool bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, (int)fs.Length);
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public static void SendStringToPrinter(string szPrinterName, string szString)
        {
            int dwCount = szString.Length;
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
        }
    }
}
