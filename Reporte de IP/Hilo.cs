using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reporte_de_IP;
using Reporte_de_IP.Datos;

namespace BackgroundWorker
{
    class Hilo
    {

        //Pequeña clase que contiene los datos de progreso
        public class EstadoActual
        {
            public List<string> dispositivosConectados = new List<string>();         
        }

        private MemoriaCompartida _memoriaCompartida;
        private ListBox _lsConectados;
        private Label _lbCant;
        private Label _lbFechaMemoria;
        private Label _lbMsjError;

        public Hilo(MemoriaCompartida memoriaCompartida, ListBox lsConectados, Label lbCant, Label lbFechaMemoria, Label lbMsjError)
        {
            //Obtener referencia del control de memoria
            _memoriaCompartida = memoriaCompartida;
            _lsConectados = lsConectados;
            _lbCant = lbCant;
            _lbFechaMemoria = lbFechaMemoria;
            _lbMsjError = lbMsjError;
        }

        //Código que ejecuta el hilo
        public void procedimientoHilo()
        {
            //Indica si ocurrió algún cambio de estado o no
            bool huboCambios = false;
            DateTime fechaHora = DateTime.Now;
            String msjError = String.Empty;

            //Obtener lista de conectados
            List<String> MacsConectadas = ObtenerListaMacMemoria();

            //Verificar si hay datos
            if (MacsConectadas[0].Replace('\0', ' ').Trim() != String.Empty)
            {
                try
                {
                    //Obtener la fecha y hora de última actualización
                    fechaHora = ObtenerFechaHoraMemoria(MacsConectadas);

                    //Determinar si no hay un desfasaje muy grande
                    TimeSpan ts = DateTime.Now - fechaHora;

                    //Diferencia en minutos
                    double difMintos = ts.TotalMinutes;
                    if (difMintos > 1)
                    {  //Si es mayor a un minuto advertir
                        msjError = "Datos en memoria desactualizado";
                    }
                }
                catch (Exception ex)
                {
                    //Error
                    msjError = "Error al intentar leer la fecha";
                    ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "Hilo.cs", "procedimientoHilo", msjError + ": " + ex.Message);

                    fechaHora = DateTime.Now;
                }
            }
            else
            {
                //Sin datos, no se inició la aplicación de Fuente u ocurrió un error
                msjError = "No se encontraron datos en la memoria";
                MacsConectadas.RemoveAt(0);
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "Hilo.cs", "procedimientoHilo", msjError + ", no se inició la aplicación de Fuente u ocurrió un error en dicha aplicación.");
            }

            //Mostrar en la vista
            actualizarHoraMemoria(fechaHora, msjError);

            //Obtener una lista de todos los dispositivos conectados de la lista EstadosActuales, para verificar cuales ya no vinieron en la lista de conectados
            List<String> macsEstadosActuales = Core.obtenerListaMacsEstadosActuales();

            foreach (string macActual in MacsConectadas)
            {
                //Quitar de la lista de macsEstadosActuales
                if (macsEstadosActuales.Contains(macActual))
                    macsEstadosActuales.Remove(macActual);

                //Verificar si ocurrio un cambio de estado, y realizar las acciones necesarias
                if (Core.verificarCambioEstado(macActual, true)) huboCambios = true;
            }

            //Recorrer los dispositivos que aún estan en la lista, para determinar si se acaban de desconectar
            foreach (string macActual in macsEstadosActuales)
            {
                //Verificar si ocurrio un cambio de estado, y realizar las acciones necesarias
                if (Core.verificarCambioEstado(macActual, false)) huboCambios = true;
            }

            //Actualizar lista de dispositivos conectados para mostrar al usuario
            if (huboCambios)
                actualizarListaConectados(MacsConectadas);
        }

        //Obtiene el primer item de la lista de Macs, que corresponde a la fecha y hora de escritura
        //Elimina este item de la lista y devuelve la fecha y hora como DateTime
        private DateTime ObtenerFechaHoraMemoria(List<String> lista){
            //Tener en cuenta que puede provocar error, envolver en Try Catch
            String primerItem = lista[0];
            lista.RemoveAt(0);

            //Formato esperado: yyyyMMddHHmmss

            DateTime fecha = new DateTime(int.Parse(primerItem.Substring(0, 4)),
                int.Parse(primerItem.Substring(4, 2)),
                int.Parse(primerItem.Substring(6, 2)),
                int.Parse(primerItem.Substring(8, 2)),
                int.Parse(primerItem.Substring(10, 2)),
                int.Parse(primerItem.Substring(12, 2)));

            return fecha;
        }

        //Obtener de la memoria la lista de dispositivos conectados
        private List<String> ObtenerListaMacMemoria()
        {
            String log = string.Empty;
            String cadena;
            char[] caracterSeparador = {'&'};
            List<String> respuesta = null;

            //Leer memoria
            if (!_memoriaCompartida.LeerEnMemoria(out cadena, true, ref log))
            {
                //Error
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "Hilo.cs", "ObtenerListaMacMemoria", "Error al obtener datos de la memoria compartida: " + log);
            }else{
                //Convertir a lista
                respuesta = cadena.Split(caracterSeparador).ToList<String>();
            }

            return respuesta;
        }

        //Actualiza el LisBox de dispositivos conectados de la pantalla principal
        private void actualizarListaConectados(List<String> lsMac)
        {
            List<MacDispositivo> lsObjMac;

            //Mapear a objetos
            lsObjMac = mapearObjetoMacDispositivo(lsMac);

            //Actualizar ListBox
            _lsConectados.Items.Clear();
            foreach (var item in lsObjMac)
            {
                _lsConectados.Items.Add(item);
            }
            //Cantidad de conectados y última actualización
            _lbCant.Text = _lsConectados.Items.Count.ToString();
        }

        //Muestra la hora, si es <> null, de escritura del area de memoria y el mensaje de error indicado, si no esta Empty
        private void actualizarHoraMemoria(DateTime fechaHora, String msjError){
            if (msjError != String.Empty)
            {
                _lbFechaMemoria.Text = "-";
                _lbMsjError.Text = msjError;
            }
            else
            {
                _lbFechaMemoria.Text = fechaHora.ToLongTimeString();
                _lbMsjError.Text = String.Empty;
            }
        }

        //Obtiene una lista de Macs y lo convierte en una lista de objetos MacDispositivos, que contiene la descripción
        private List<MacDispositivo> mapearObjetoMacDispositivo(List<String> lsMac)
        {
            List<MacDispositivo> nuevaLista = new List<MacDispositivo>();

            if (lsMac != null)
            {
                foreach (String macActual in lsMac)
                {
                    String descripcion;

                    //Buscar descripción en el diccionario, si no existe colocar el valor de Desconocido
                    if (Core.descripcionDispositivosDiccionario.ContainsKey(macActual))
                        descripcion = Core.descripcionDispositivosDiccionario[macActual];
                    else
                        descripcion = Core.datosGenerales.leyendaMacSinDescripcion;

                    //Agregar a la lista
                    nuevaLista.Add(new MacDispositivo(macActual, descripcion));
                }
            }

            return nuevaLista;
        }

    }


}
