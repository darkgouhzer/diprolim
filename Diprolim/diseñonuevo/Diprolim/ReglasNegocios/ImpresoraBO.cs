using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Identidades;
using AccesoDatos;

namespace ReglasNegocios
{
    public class ImpresoraBO
    {
        ImpresoraDAL objImpresoraDAL;
        public ImpresoraBO()
        {
            objImpresoraDAL = new ImpresoraDAL();
        }
        public List<String> ListarImpresoras()
        {
            String pkInstalledPrinters;
            List<String> objImpresoras = new List<string>();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                objImpresoras.Add(pkInstalledPrinters);
            }
            return objImpresoras;
        }
        public Boolean GuardarImpresora(CImpresora objCImpresora)
        {
            return objImpresoraDAL.GuardarImpresora(objCImpresora);
        }
        public CImpresora ObtenerDatosImpresora()
        {
            return objImpresoraDAL.ObtenerDatosImpresoras();
        }
    }
}
