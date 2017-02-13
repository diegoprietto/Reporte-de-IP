using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporte_de_IP.Datos
{
    //Representa una acción a realizar para un dispositivo determinado
    class RegistroAccion
    {
        public string direccionMAC;
        public bool alConectarse;
        public bool alDesconectarse;
        public string descripcion;
        public string rutaExe;
        public string parametro;
            /*
                %i: Se reemplaza por la dirección MAC
                %f: Se reemplaza por la fecha y hora
                %a: Se reemplaza por "C" (Se conectó) o por "D" (se desconectó)
                %d: Se reemplaza por el nombre del dispositivo, si no contiene por "Desconocido"
             */

        public RegistroAccion(string direccionMAC, bool alConectarse, bool alDesconectarse, string descripcion, string rutaExe, string parametro)
        {
            this.direccionMAC = direccionMAC;
            this.alConectarse = alConectarse;
            this.alDesconectarse = alDesconectarse;
            this.descripcion = descripcion;
            this.rutaExe = rutaExe;
            this.parametro = parametro;
        }

        //Lectura de un registro a partir de una cadena (Constructor)
        public RegistroAccion(string cadena)
        {
            string[] arrayCadena = cadena.Split('\t');
            int indice = 0;

            this.direccionMAC = arrayCadena[indice++];
            this.alConectarse = Boolean.Parse(arrayCadena[indice++]);
            this.alDesconectarse = Boolean.Parse(arrayCadena[indice++]);
            this.descripcion = arrayCadena[indice++];
            this.rutaExe = arrayCadena[indice++];
            this.parametro = arrayCadena[indice++];
        }

        //Sobreescritura para utilizarse en el guardado, se devuelve todos sus datos separados por tab '\t'
        public override string ToString()
        {
            return (direccionMAC + '\t' + alConectarse.ToString() + '\t' + alDesconectarse.ToString() + '\t' + descripcion + '\t' + rutaExe + '\t' + parametro);
        }
    }
}
