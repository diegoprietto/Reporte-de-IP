using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reporte_de_IP;

namespace BackgroundWorker
{
    class Hilo
    {

        //Pequeña clase que contiene los datos de progreso
        public class EstadoActual
        {
            public List<string> dispositivosConectados = new List<string>();         
        }

        //Código que ejecuta el hilo
        public void procedimientoHilo(System.ComponentModel.BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
        {
            //Se crea el log
            EstadoActual estadoActual = new EstadoActual();

            //Aux para calcular la espera
            DateTime tiempoFin;

            while (true)
            {
                //Realiza las acciones necesarias para obtener la lista de dispositivos conectados
                procesarDatos(ref estadoActual);

                //Reportar dispositivos conectados
                worker.ReportProgress(0, estadoActual);

                //Pausar según la frecuencia
                tiempoFin = DateTime.Now.AddSeconds(Core.datosGenerales.frecuencia);
                while (DateTime.Now < tiempoFin)
                {
                    //Verificar si se canceló a ejecución
                    if (worker.CancellationPending)
                    {
                        //Indicar en parámetro que se canceló y salir del método
                        e.Cancel = true;
                        return;
                    }

                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        //Realiza todo el proceso de lectura de datos, devuelve en el parámetro la lista de dispositivos conectados
        private void procesarDatos(ref EstadoActual estadoActual)
        {
            List<String> registrosMacControl = null;
            List<String> nuevaListaDispConectados = new List<string>();
            List<String> macsEstadosActuales;

            //Obtener datos del control (Null significa que aún no estan listos los datos)
            while (registrosMacControl == null)
            {
                registrosMacControl = ControlWeb.obtenerListaMacs();

                //Esperar si no hay datos
                if (registrosMacControl == null)
                    System.Threading.Thread.Sleep(1000);
            }

            //Obtener una lista de todos los dispositivos conectados, para verificar cuales ya no vinieron en la lista de conectados
            macsEstadosActuales = Core.obtenerListaMacsEstadosActuales();

            foreach (string macActual in registrosMacControl)
            {
                //Añadir al reporte los dispositivos conectados
                nuevaListaDispConectados.Add(Core.generarCadenaDispositivoConectado(macActual));

                //Quitar de la lista de macsEstadosActuales
                if (macsEstadosActuales.Contains(macActual))
                    macsEstadosActuales.Remove(macActual);

                //Verificar si ocurrio un cambio de estado, y realizar las acciones necesarias
                Core.verificarCambioEstado(macActual, true);
            }

            //Recorrer los dispositivos que aún estan en la lista, para determinar si se acaban de desconectar
            foreach (string macActual in macsEstadosActuales)
            {
                //Verificar si ocurrio un cambio de estado, y realizar las acciones necesarias
                Core.verificarCambioEstado(macActual, false);
            }

            //Actualizar lista de dispositivos conectados para mostrar al usuario
            estadoActual.dispositivosConectados = nuevaListaDispConectados;
        }
    }


}
