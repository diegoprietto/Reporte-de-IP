using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reporte_de_IP
{
    //Clase estática que controla a bajo nivel el control WebBrowser
    class ControlWeb
    {
        //Control web
        static WebBrowser web;

        //Acción a realizar luego que se complete la carga del documento (DocumentCompleted)
        public static AccionWeb accionWeb = AccionWeb.Ninguna;

        //Indica si se esta parado en la página de estadisticas o si se debe navegar hasta allí antes de poder leer las Macs
        private static bool paginaEstadistica = false;

        //Se usa como caché para almacenar la lista de Macs antes de devolver a la aplicación
        private static bool listaDisponible = false;
        private static List<String> lsMac = null;

        //Contador de Excepciones
        public static long erroresDetectados = 0;

        //Contador de reintentos, en caso de error, de leer la tabla de Macs
        public static int reintentosTablaMacsFallidos = 0;  ////TEST, falla
        const int reintentosTablaMacsFallidosInicial = 0;

        //Enum
        public enum AccionWeb
        {
            Ninguna,
            LoginRouter,
            MenuWireless,
            MenuWirelessStatistics,
            LeerDatos
        }

        //Obtener referencia al control
        public static void asignarControlWeb(WebBrowser control){
            web = control;

            //Desactivar las notificaciones de error de JavaScript
            web.ScriptErrorsSuppressed = true;

        }

        //Proceso completo para obtener Lista Macs
        public static List<String> obtenerListaMacs()
        {
            //Verificar si hay datos
            if (listaDisponible)
            {
                //Deshabilitar datos disponibles y retornar la lista actual
                listaDisponible = false;
                return lsMac;
            }

            //Llamar a obtener datos, si no se esta en esta vista se inicia el ciclo para llegar
            if (accionWeb == AccionWeb.Ninguna)
                obenerDatosWireless();

            //Indicar que no hay datos disponibles aún
            return null;
        }

        //Navega desde la página principal hasta la de Estadísticas de Wireless
        private static void navegarEstadisticas()
        {
            //Iniciar ciclo
            paginaEstadistica = false;
            try
            {
                //Si no se llega despues de 100 intentos mostrar
                if (!web.Visible && erroresDetectados > 100 ) web.Visible = true;

                //Comenzar desde la página inicial
                web.Navigate("192.168.1.1");

                //Luego de completarse la carga de la página continuar con el logueo
                accionWeb = AccionWeb.LoginRouter;
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("ControlWeb.cs, navegarEstadisticas(): No se pudo navegar desde la página principal hasta la de Estadísticas de Wireless, error: " + ex.Message);
                //Reintentar desde el comienzo
                erroresDetectados++;
                navegarEstadisticas();
            }
        }

        public static void loginRouter()
        {
            try
            {
                //Llenar datos para loguearse
                web.Document.GetElementById("userName").SetAttribute("value", "dprsoft");
                web.Document.GetElementById("pcPassword").SetAttribute("value", "DPRSoft1289");
                web.Document.GetElementById("loginBtn").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless
                accionWeb = AccionWeb.MenuWireless;
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("ControlWeb.cs, loginRouter(): No se pudo loguear desde la página principal, error: " + ex.Message);
                //Reintentar desde el comienzo
                erroresDetectados++;
                navegarEstadisticas();
            }
        }

        public static void menuWireless()
        {
            try
            {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a7").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless Statistics
                accionWeb = AccionWeb.MenuWirelessStatistics;
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("ControlWeb.cs, menuWireless(): No se pudo navegar hacia el menú Wireless, error: " + ex.Message);
                //Reintentar desde el comienzo
                erroresDetectados++;
                navegarEstadisticas();
            }
        }

        public static void menuWirelessStatistics()
        {
            try
            {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a12").InvokeMember("click");

                //Luego de completarse la carga de la página terminar ciclo de ejecución
                paginaEstadistica = true;
                accionWeb = AccionWeb.LeerDatos;
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("ControlWeb.cs, menuWirelessStatistics(): No se pudo navegar hacia la página Wireless Statistics, error: " + ex.Message);
                //Reintentar desde el comienzo
                erroresDetectados++;
                navegarEstadisticas();
            }
        }

        public static void obenerDatosWireless()
        {
            try
            {
                List<String> lsMac = new List<string>();

                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar la tabla que contiene los datos de las estadísticas
                HtmlElement tabla = frame[2].Document.GetElementsByTagName("TBODY")[1];

                //Obtener las filas
                HtmlElementCollection filas = tabla.GetElementsByTagName("tr");

                //Recorrer las filas, excepto el primero q son los títulos, y obtener cada una de las MACs
                for (int i = 1; i < filas.Count; i++)
                {
                    //Obtener la segunda columna, que es donde esta la MAC y añadir a la lista
                    lsMac.Add(filas[i].GetElementsByTagName("td")[1].InnerText);
                }

                //Almacenar lista de MACs en la clase y marcar como datos disponibles
                ControlWeb.lsMac = lsMac;
                listaDisponible = true;

                //Detener el ciclo de ejecución
                accionWeb = AccionWeb.Ninguna;

                //Mostrar solo cuando este en la vista adecuada y habilitar botón de iniciar
                web.Visible = true;

                //Reiniciar el contador de intentos fallidos antes de reiniciar
                reintentosTablaMacsFallidos = 3;
            }
            catch (Exception ex)
            {
                ControlLog.registrarLog("ControlWeb.cs, obenerDatosWireless(): No se pudo leer la tabla de Macs de la página web, error: " + ex.Message);

                //Reintentar desde el comienzo si se agota el contador
                reintentosTablaMacsFallidos--;

                if (reintentosTablaMacsFallidos <= 0)
                {
                    //Reiniciar el contador de intentos fallidos antes de reiniciar
                    reintentosTablaMacsFallidos = reintentosTablaMacsFallidosInicial;

                    erroresDetectados++;
                    paginaEstadistica = false;
                    navegarEstadisticas();
                }
            }
        }
    }
}
