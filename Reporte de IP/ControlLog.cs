using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporte_de_IP
{
    class ControlLog
    {
        private static String _nombreArchivo;
        private static bool _inicializado = false;
        private static StreamWriter _archivo;

        //Enumeraciones
        public enum TipoGravedad
        {
            INFO,
            WARNING,
            ERROR,
        }

        //Abrir archivo para comenzar la lectura
        public static bool Inicializar(String nombreArchivo, out String mensajeLog)
        {
            mensajeLog = String.Empty;

            _nombreArchivo = nombreArchivo;

            try
            {
                //Abrir archivo en modo AppendText
                _archivo = File.AppendText(_nombreArchivo);

                _inicializado = true;
            }
            catch (Exception ex)
            {
                mensajeLog = "Error al intentar abrir el archivo de log: " + ex.Message;
                return false;
            }

            return true;
        }

        //Cerrar archivo
        public static void CerrarArchivo()
        {
            _inicializado = false;

            try
            {
                _archivo.Dispose();
            }
            catch (Exception)
            {}
        }

        //Escribir en Log
        public static bool EscribirLog(TipoGravedad tipoGravedad, String archivo, String procedimiento, String mensaje)
        {
            //Si no esta inicializado salir
            if (!_inicializado) return false;

            //Generar cadena
            String cadena = DateTime.Now.ToLongTimeString() + '\t' + DateTime.Now.ToShortDateString() + '\t' + tipoGravedad.ToString() + '\t' + archivo + '\t' + procedimiento + '\t' + mensaje;

            try
            {
                //Escribir en archivo
                _archivo.WriteLine(cadena);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
