using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporte_de_IP.Datos
{
    //Modelo de dato para que pueda ser usado por el contorl ListBox
    class MacDispositivo
    {
        public string MAC;
        public string descripcion;

        public MacDispositivo(string MAC, string descripcion)
        {
            this.MAC = MAC;
            this.descripcion = descripcion;
        }

        //Forma de texto
        public override string ToString()
        {
            return String.Format("{0} ({1})",descripcion,MAC); 
        }
    }
}
