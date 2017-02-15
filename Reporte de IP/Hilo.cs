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

        public Hilo(MemoriaCompartida memoriaCompartida, ListBox lsConectados, Label lbCant)
        {
            //Obtener referencia del control de memoria
            _memoriaCompartida = memoriaCompartida;
            _lsConectados = lsConectados;
            _lbCant = lbCant;
        }

        //Código que ejecuta el hilo
        public void procedimientoHilo()
        {
            //Indica si ocurrió algún cambio de estado o no
            bool huboCambios = false;

            //Obtener lista de conectados
            List<String> MacsConectadas = ObtenerListaMacMemoria();

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
