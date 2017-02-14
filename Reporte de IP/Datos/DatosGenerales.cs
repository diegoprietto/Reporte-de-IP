using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Reporte_de_IP.Datos
{
    //Representa la configuración basica
    class DatosGenerales
    {
        public int frecuencia;

        //No alterables, salvo excepción
        public String rutaArchivoDispositivos = ConfigurationManager.AppSettings["rutaArchivoDispositivos"];
        public String rutaArchivoLog = ConfigurationManager.AppSettings["rutaArchivoLog"];
        public String nombreMemoriaCompartida = ConfigurationManager.AppSettings["nombreMemoriaCompartida"];
        public String nombreMutexCompartido = ConfigurationManager.AppSettings["nombreMutexCompartido"];
        public long capacidadMemoriaCompartida = long.Parse(ConfigurationManager.AppSettings["capacidadMemoriaCompartida"]);
        public String leyendaMacSinDescripcion = ConfigurationManager.AppSettings["leyendaMacSinDescripcion"];

        #region Constructores

        public DatosGenerales() { }

        public DatosGenerales(int frecuencia)
        {
            this.frecuencia = frecuencia;
        }

        #endregion
    }
}
