using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reporte_de_IP
{
    class MemoriaCompartida
    {
        private String _nombreMemoria;
        private String _nombreMutex;
        private long _capacidadMemoria;

        //Indica si se esta preparado para leer o escribir (Archivo y Mutex creados)
        private bool _inicializado = false;
        //Archivo en memoria
        private MemoryMappedFile _memoria;
        //Mutex para acceso concurrido
        private Mutex _mutex;


        public MemoriaCompartida(String nombreMemoria, String nombreMutex, long capacidadMemoria)
        {
            _nombreMemoria = nombreMemoria;
            _nombreMutex = nombreMutex;
            _capacidadMemoria = capacidadMemoria;
        }

        //Inicializar, devuelve true si se crea con éxito
        public bool IniciarConexion(ref String mensajeLog)
        {
            String nuevoMensajeLog;

            //Crear archivo en memoria
            try
            {
                //Abrir archivo
                _memoria = MemoryMappedFile.CreateOrOpen(_nombreMemoria, _capacidadMemoria);
                _inicializado = true;
                nuevoMensajeLog = "Se abrió el espacio en memoria.";
            }
            catch (Exception ex)
            {
                nuevoMensajeLog = "Error al intentar abrir o crear el archivo en memoria: " + ex.Message;
                return false;
            }

            //Intentar crear Mutex o unirse a uno previamente creado.
            try
            {
                // Try to open existing mutex.
                _mutex = Mutex.OpenExisting(_nombreMutex);
                nuevoMensajeLog += Environment.NewLine + "Se unió a un Mutex previamente creado.";
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                _mutex = new Mutex(false, _nombreMutex);
                nuevoMensajeLog += Environment.NewLine + "Se crea nuevo Mutex.";
            }

            return true;
        }

        //Escribir cadena en memoria compartida
        public bool EscribirEnMemoria(String cadena, ref String mensajeLog)
        {
            if (!_inicializado)
            {
                mensajeLog = "Modulo no inicializado.";
                return false;
            }

            try
            {
                //Completar con espacios en blanco hasta alcanzar la longitud
                cadena = cadena.PadRight((int)_capacidadMemoria,' ');

                //Convertir cadena a Bytes
                Byte[] buffer = Encoding.ASCII.GetBytes(cadena);

                //Solicitar Mutex
                _mutex.WaitOne();

                using (MemoryMappedViewStream stream = _memoria.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(buffer);
                }

                //Liberar Mutex
                _mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                mensajeLog = "Error al intentar escribir en memoria: " + ex.Message;
                return false;
            }

            mensajeLog = "Escrito con éxito.";
            return true;
        }

        //Leer cadena en memoria compartida
        public bool LeerEnMemoria(out String cadena, bool aplicarTrim, ref String mensajeLog)
        {
            cadena = String.Empty;

            if (!_inicializado)
            {
                mensajeLog = "Modulo no inicializado.";
                return false;
            }

            try
            {
                byte[] cadenaByte = new byte[_capacidadMemoria];

                //Solicitar Mutex
                _mutex.WaitOne();
                
                using (MemoryMappedViewStream stream = _memoria.CreateViewStream())
                {
                    BinaryReader reader = new BinaryReader(stream);

                    //Leer bytes
                    stream.Read(cadenaByte, 0, (int)_capacidadMemoria);

                    //Convertir a texto
                    cadena = ASCIIEncoding.ASCII.GetString(cadenaByte);

                    //Trim, si se especificó
                    if (aplicarTrim) cadena = cadena.Trim();
                }
                _mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                mensajeLog = "Error al intentar leer la memoria: " + ex.Message;
                return false;
            }

            mensajeLog = "Leido con éxito.";
            return true;
        }
    }
}
