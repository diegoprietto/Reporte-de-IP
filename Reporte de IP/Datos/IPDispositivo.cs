using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporte_de_IP.Datos
{
    //Almacena los datos que relacionan las MAC con los nombres de dispositivos
    class IPDispositivo
    {
        public string MAC;
        public string descripcion;

        public IPDispositivo(string MAC, string descripcion)
        {
            this.MAC = MAC;
            this.descripcion = descripcion;
        }

        //Útil para utilizarse en el ComboBox
        public override string ToString()
        {
            return MAC + "  -  " + descripcion; 
        }
    }
}
