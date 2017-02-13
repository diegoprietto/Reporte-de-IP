using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporte_de_IP.Datos
{
    //Representa la configuración basica
    class DatosGenerales
    {
        public int frecuencia;

        //No alterables, salvo excepción
        public string rutaArchivoDispositivos = "Dispositivos.txt";

        #region Constructores

        public DatosGenerales() { }

        public DatosGenerales(int frecuencia)
        {
            this.frecuencia = frecuencia;
        }

        #endregion
    }
}
