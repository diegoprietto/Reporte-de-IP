using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporte_de_IP.Datos;
using System.IO;
using System.Diagnostics;

namespace Reporte_de_IP
{
    //Nucleo del programa
    static class Core
    {
        //Datos
        public static List<EstadoActual> estadosActuales = new List<EstadoActual>();              //Estado de los dispositivos
        public static List<IPDispositivo> descripcionDispositivos = new List<IPDispositivo>();    //Contiene el nombre del dispositivo según la IP
        public static List<RegistroAccion> listaAcciones = new List<RegistroAccion>();            //Acciones asignadas a los dispositivos
        public static DatosGenerales datosGenerales;                                              //Configuraciones

        //Constantes
        public static string rutaArchivoConfig = "Reporte.config";


        #region Metodos Públicos

        //Carga la configuración guardada del archivo (Se devuelve String.Empty indica que se cargó sin errores)
        public static String cargarConfiguracion()
        {
            string[] lineas = new string[0];
            string cadenaAux;
            bool resultAux;
            int cantidadDatosFijos = 2; //Cantidad de registros que debe tener el archivo minimamente
            int cantidadAcciones;

            datosGenerales = new DatosGenerales();
            int indice = 0;

            //Cargar archivo
            try
            {
                if (!(File.Exists(rutaArchivoConfig)))
                {
                    //Primera ejecución, no se encontró el archivo
                    return String.Empty;
                }

                lineas = System.IO.File.ReadAllLines(rutaArchivoConfig);
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("Core.cs, cargarConfiguracion(): No se pudo leer el archivo de configuración, error: " + ex.Message);
                //Error de lectura
                return "Se produjo el error al intentar cargar el archivo: " + ex.Message;
            }

            //Si no hay registros informar
            if (lineas.Length == 0)
            {
                return "Se produjo el error al intentar cargar el archivo: No hay ningún dato";
            }

            //Verificar la cantidad de registros
            if (lineas.Length < cantidadDatosFijos)
            {
                return "Se produjo el error al intentar cargar el archivo: Cantidad de registros insuficientes (" + lineas.Length.ToString() + " lineas)";
            }

            //Cargar frecuencia
            cadenaAux = lineas[indice];
            resultAux = Int32.TryParse(cadenaAux, out datosGenerales.frecuencia);
            if (!resultAux)
            {
                return "Se produjo el error al intentar cargar la frecuencia: Valor no numérico (" + cadenaAux + ")";
            }
            indice++;

            //Cargar cantidad de acciones
            cadenaAux = lineas[indice];
            resultAux = Int32.TryParse(cadenaAux, out cantidadAcciones);
            if (!resultAux)
            {
                return "Se produjo el error al intentar cargar la cantidad de acciones: Valor no numérico (" + cadenaAux + ")";
            }
            indice++;

            //Cargar acciones
            try
            {
                for (int i = 0; i < cantidadAcciones; i++)
                {
                    RegistroAccion nuevo = new RegistroAccion(lineas[indice++]);
                    listaAcciones.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("Core.cs, cargarConfiguracion(): Se produjo un error en la lectura del archivo de configuración, en el momento de lectura de las acciones programadas, error: " + ex.Message);
                return "Se produjo un error al cargar las acciones: " + ex.Message;
            }

            //Ok
            return string.Empty;
        }

        //Carga los nombres de dispositivos según la dirección MAC
        public static String cargarNombresDispositivos()
        {
            string[] lineas = new string[0];

            //Cargar archivo
            try
            {
                if (!(File.Exists(datosGenerales.rutaArchivoDispositivos)))
                {
                    //Primera ejecución, no se encontró el archivo
                    return "Archivo no encontrado: " + datosGenerales.rutaArchivoDispositivos;
                }

                lineas = System.IO.File.ReadAllLines(datosGenerales.rutaArchivoDispositivos);
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("Core.cs, cargarNombresDispositivos(): Se produjo un error en la lectura del archivo de dispositivos, error: " + ex.Message);
                //Error de lectura
                return "Se produjo el error al intentar cargar el archivo: " + ex.Message;
            }

            //Recorrer los registros
            foreach (string registro in lineas)
            {
                string registroAct = registro.Trim();
                string[] registroArr;
                
                //Registro no vacio
                if (registroAct != string.Empty)
                {
                    registroArr = registroAct.Split('\t');

                    //Valores no vacios
                    if (registroArr.Length > 1 && registroArr[0].Trim() != string.Empty && registroArr[0].Trim() != string.Empty){
                        IPDispositivo nuevo = new IPDispositivo(registroArr[0].Trim(), registroArr[1].Trim());

                        //Añadir a la lista
                        descripcionDispositivos.Add(nuevo);
                    }
                }
            }

            //Ok
            return string.Empty;
        }

        //Guarda los valores de Datos Generales en el archivo de configuración (Devuelve String.Empty en caso de éxito)
        public static string guardarArchivoConfiguracion(){
            int cantidadDatosFijos = 2;
            int cantidadDatosVariables = listaAcciones.Count;
            string[] lineas = new string[cantidadDatosFijos + cantidadDatosVariables];
            int indice = 0;

            //Guardar frecuencia
            lineas[indice++] = datosGenerales.frecuencia.ToString();

            //Guardar cantidad de registro de acciones
            lineas[indice++] = cantidadDatosVariables.ToString();

            //Guardar acciones
            foreach (RegistroAccion elemento in listaAcciones)
            {
                lineas[indice++] = elemento.ToString(); //Se guarda un registro en una sola linea donde se separan los campos mediante tab '\t'
            }

            //Guardar archivo
            try
            {
                System.IO.File.WriteAllLines(rutaArchivoConfig, lineas);
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("Core.cs, guardarArchivoConfiguracion(): Se produjo un error en el guardado del archivo de configuración, error: " + ex.Message);
                return ex.Message;
            }

            //Ok
            return String.Empty;
        }

        //Generar la cadena a mostrar en la lista de conectados
        public static string generarCadenaDispositivoConectado(string MAC)
        {
            string descripcion = "(Desconocido)";

            //Buscar en la lista de nombres la descripción
            foreach (IPDispositivo dispActual in descripcionDispositivos)
            {
                if (dispActual.MAC.Trim() == MAC.Trim())
                {
                    //Encontrado
                    descripcion = dispActual.descripcion;
                    break;
                }
            }

            //Armar string
            return MAC.Trim() + " \t" + descripcion;
        }

        //Obtener nombre de dispositivo, String.Empty si no se encuentra
        public static string obtenerNombreDispositivo(string MAC)
        {
            //Buscar en la lista de nombres la descripción
            foreach (IPDispositivo dispActual in descripcionDispositivos)
            {
                if (dispActual.MAC.Trim() == MAC.Trim())
                {
                    //Encontrado
                    return dispActual.descripcion;
                }
            }

            //No encontrado
            return String.Empty;
        }

        //Verifica cambios de estado y ejecuta las acciones si corresponde, actualiza el estado actual en caso de cambio
        public static void verificarCambioEstado(string mac, bool estadoActual)
        {
            //Obtener estado anterior
            bool estadoAnterior = estadoActualConectado(mac);
            string parametros;

            //Verificar si cambió el estado
            if (estadoActual != estadoAnterior)
            {
                //Buscar registro de acciones para este dispositivo
                List<RegistroAccion> acciones = obtenerAccionesAsociadas(mac, estadoActual);

                //Por cada registro de acciones ejecutar el exe
                foreach (RegistroAccion accionActual in acciones)
                {
                    //Generar parámetros
                    parametros = generarParametroAccion(accionActual, estadoActual);

                    //Ejecutar
                    try
                    {
                        Process.Start(accionActual.rutaExe, parametros);
                    }
                    catch (Exception ex)
                    {
                        ControlLog.registrarLog("Core.cs, verificarCambioEstado(): Error al inicializar el proceso de la acción programada '" + accionActual.rutaExe + "' con parámetros '" + parametros + "' , error: " + ex.Message);
                    }
                }

                //Actualizar estado actual
                actualizarEstadoDispositivo(mac, estadoActual);
            }

        }

        //Devuelve una lista de las Macs que estan registradas en la lista estadosActuales
        //Es decir todas las que en algún momento estuvieron conectadas alguna vez desde la ejecución de la aplicación
        public static List<String> obtenerListaMacsEstadosActuales(){
            List<String> listaMacs = new List<string>();

            foreach (EstadoActual item in estadosActuales)
            {
                listaMacs.Add(item.MAC);
            }

            return listaMacs;
        }

        #endregion

        //Métodos internos
        #region Metodos Privados

        //Ejecuta un comando en CMD en background, no se muestra ninguna ventana
        private static String ejecutarComandoBackground(string comando)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);

            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = true;
            //Esconder la ventana
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();

            //Muestra en pantalla la salida del Comando
            return result;
        }

        //Devuelve true si el dispositivo se encuentra en la lista y esta conectado, si esta desconectado o no esta devuelve false
        //Si no esta, se agrega a la lista
        private static bool estadoActualConectado(string MAC)
        {
            //Buscar en la lista de estados el dispositivo
            foreach (EstadoActual dispActual in estadosActuales)
            {
                if (dispActual.MAC.Trim() == MAC.Trim())
                {
                    //Encontrado
                    return dispActual.conectado;
                }
            }

            //No esta en la lista, se agrega como desconectado
            EstadoActual nuevo = new EstadoActual(MAC,false);
            estadosActuales.Add(nuevo);

            return false;
        }

        //Obtiene la lista de todas las acciones filtradas por la MAC y por el nuevo estado del dispositivo
        //Si conectado = true, devuelve las acciones que se deben ejecutar cuando se conecta
        //Si conectado = false, devuelve las acciones que se deben ejecutar cuando se desconecta
        private static List<RegistroAccion> obtenerAccionesAsociadas(string MAC, bool conectado)
        {
            List<RegistroAccion> lsFiltro = new List<RegistroAccion>();

            //Recorrer las acciones
            foreach (RegistroAccion registro in listaAcciones)
            {
                if (registro.direccionMAC.Trim() == MAC.Trim())
                {
                    //Misma MAC
                    if ((conectado && registro.alConectarse) || (!conectado && registro.alDesconectarse))
                    {
                        //Coincide
                        lsFiltro.Add(registro);
                    }
                }
            }

            return lsFiltro;
        }

        //Genera los parámetros de ejecución para la acción indicada, si alConectarse = true, el evento es de conexión, si es false, es de desconexión
        private static string generarParametroAccion(RegistroAccion accion, bool alConectarse)
        {
            //Parámetro en bruto
            string resultado = accion.parametro;

            //Asignar MAC
            resultado = resultado.Replace("%i", accion.direccionMAC);

            //Asignar fecha y hora
            resultado = resultado.Replace("%f", DateTime.Now.ToString("dd/MM/yyyy H:mm:ss"));

            //Asignar evento
            if (alConectarse)
                resultado = resultado.Replace("%a", "C");
            else
                resultado = resultado.Replace("%a", "D");

            //Asignar dispositivo
            string descripcion = obtenerNombreDispositivo(accion.direccionMAC);
            if (descripcion == string.Empty) descripcion = "Desconocido";

            resultado = resultado.Replace("%d", descripcion);


            //Retornar cadena armada
            return resultado;
        }

        //Actualiza el estado actual del dispositivo indicado
        private static void actualizarEstadoDispositivo(string MAC, bool conectado)
        {
            //Buscar en la lista de estados el dispositivo
            foreach (EstadoActual dispActual in estadosActuales)
            {
                if (dispActual.MAC.Trim() == MAC.Trim())
                {
                    //Encontrado
                    dispActual.conectado = conectado;
                    return;
                }
            }

            //Si no esta en la lista, se agrega
            EstadoActual nuevo = new EstadoActual(MAC, conectado);
            estadosActuales.Add(nuevo);
        }

        #endregion
    }
}
