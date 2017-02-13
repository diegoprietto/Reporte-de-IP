using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporte_de_IP
{
    class ControlLog
    {
        //Contiene todos los logs registrados
        public static List<String> lsLog = new List<string>();

        //Registra un log
        public static void registrarLog(String texto)
        {
            lsLog.Add(texto);
        }
    }
}
