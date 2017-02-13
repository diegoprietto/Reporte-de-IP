using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporte_de_IP.Datos
{
    //Representa el estado actual de conexión de un dispositivo
    class EstadoActual
    {
        public string MAC;
        public Boolean conectado;

        public EstadoActual(string MAC, Boolean conectado)
        {
            this.MAC = MAC;
            this.conectado = conectado;
        }
    }
}
