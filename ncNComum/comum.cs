using System;
using System.Diagnostics;
using LibNF65;
using LibNF65.Modelo;

namespace ncNComum
{
    public class cComum
    {
        public PixConfig RecuperarConfig()
        {
            try
            {
                return NFCe65.ConsultarConfig();
            }
            catch (Exception ex)
            {
                Trace.TraceError("cComum.RecuperarConfig error: " + ex.ToString());
                return null;
            }
        }
    }
}
