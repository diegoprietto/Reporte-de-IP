using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackgroundWorker;

namespace Reporte_de_IP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btAcciones_Click(object sender, EventArgs e)
        {
            Acciones f = new Acciones();
            DialogResult resp = f.ShowDialog();

            if (resp == DialogResult.OK)      //Si retorna Ok indica que ocurrió un cambio
                habilitarGuardado();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargar desde archivo la configuración
            string resultado = Core.cargarConfiguracion();

            //Validar si hay errores
            if (resultado != String.Empty)
            {
                if (MessageBox.Show(resultado + Environment.NewLine + "¿Desear abrir la aplicación desde cero (Si se guarda se borrará el archivo existente)?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    //Terminar programa si el usuario indica que no
                    this.Close();
                }
            }

            //Cargar desde archivo la lista de dispositivos
            resultado = Core.cargarNombresDispositivos();

            //Validar si hay errores
            if (resultado != String.Empty)
            {
                MessageBox.Show("Lista de Dispositivos:" + Environment.NewLine + resultado);
            }

            //Cargar datos en los controles
            cargarControles();

            //Referenciar control web
            ControlWeb.asignarControlWeb(this.web);

            //Navegar y mostrar
            ControlWeb.obtenerListaMacs();
        }

        //Cargar datos en los controles
        private void cargarControles()
        {
            txFrecuencia.Text = Core.datosGenerales.frecuencia.ToString();
            lsConectados.Items.Clear();

            btGuardar.Enabled = false;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //Almacenar los datos de los controles
            string resultado = validarDatos();

            //Validar si hay errores
            if (resultado != String.Empty)
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + resultado);
            }
            else 
            {
                //Almacenar en datos generales
                almacenarDatosGenerales();

                //Guardar en archivo
                resultado = Core.guardarArchivoConfiguracion();

                if (resultado != String.Empty)
                {
                    MessageBox.Show("No se pudo guardar el archivo:" + resultado);
                }
                else
                {
                    //Dehabilitar botón de guardar
                    btGuardar.Enabled = false;
                }
            }
        }

        //Valida que todos los datos ingresados en los controles sean correctos, devuelve el error, caso contrario devuelve String.Empty
        private string validarDatos()
        {
            string resultado = string.Empty;
            bool auxResultado;
            int auxInt;

            //Frecuencia
            if (txFrecuencia.Text.Trim() == string.Empty)
            {
                resultado += Environment.NewLine + "El campo Frecuencia no puede estar en blanco.";
            }
            else
            {
                auxResultado = Int32.TryParse(txFrecuencia.Text, out auxInt);

                if (auxResultado)
                {
                    txFrecuencia.Text = auxInt.ToString();
                }
                else
                {
                    resultado += Environment.NewLine + "El campo Frecuencia debe ser numérico.";
                }
            }

            return resultado;
        }

        //Guarda los datos de los controles en la clase datos generales (Solo invocar si los datos son válidos)
        private void almacenarDatosGenerales()
        {
            Core.datosGenerales.frecuencia = Int32.Parse(txFrecuencia.Text);
        }

        private void txFrecuencia_TextChanged(object sender, EventArgs e)
        {
            habilitarGuardado();
        }

        //Invocar cada vez que se realiza un cambio que puede ser guardado
        private void habilitarGuardado()
        {
            btGuardar.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Verificar si se guardaron los cambios
            if (btGuardar.Enabled)
            {
                if (MessageBox.Show("Hay cambios sin guardar, si sale se perderán." + Environment.NewLine + "¿Desea cerrar de todos modos?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;    //Cancelar cierre
            }
        }

        private void btIniciar_Click(object sender, EventArgs e)
        {
            //Almacenar los datos de los controles
            string resultado = validarDatos();

            //Validar si hay errores
            if (resultado != String.Empty)
            {
                MessageBox.Show("Se encontraron los siguientes errores:" + resultado);
            }
            else
            {
                //Almacenar en datos generales
                almacenarDatosGenerales();

                //Dehabilitar botones de iniciar y de acciones
                btIniciar.Enabled = false;
                btAcciones.Enabled = false;
                txFrecuencia.Enabled = false;

                btDetener.Enabled = true;

                //Iniciar hilo
                procesoBackground.RunWorkerAsync();
            }
        }

        private void btDetener_Click(object sender, EventArgs e)
        {
            //Solicita al hilo que se detenga
            procesoBackground.CancelAsync();
        }

        private void procesoBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Habilitar botones de iniciar y de acciones
            btIniciar.Enabled = true;
            btAcciones.Enabled = true;
            txFrecuencia.Enabled = true;

            btDetener.Enabled = false;
        }

        //Se invoca cuando se envia información de progreso
        private void procesoBackground_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Obtener reporte
            Hilo.EstadoActual estadoActual = (Hilo.EstadoActual)e.UserState;

            //Mostrar los dispositivos conectados
            lsConectados.Items.Clear();
            foreach (string elemento in estadoActual.dispositivosConectados)
            {
                lsConectados.Items.Add(elemento);
            }

            lbCant.Text = lsConectados.Items.Count.ToString() + "     (Última actualización: " + DateTime.Now.ToLongTimeString() + ")";
        }

        //Ejecutar el hilo
        private void procesoBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            //Obtener objeto
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;

            //Llamar al método
            Hilo h = new Hilo();
            h.procedimientoHilo(worker, e);
        }

        //Se completa la carga de la página
        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (ControlWeb.accionWeb)
            {
                case ControlWeb.AccionWeb.Ninguna:
                    return;
                case ControlWeb.AccionWeb.LoginRouter:
                    ControlWeb.loginRouter();
                    return;
                case ControlWeb.AccionWeb.MenuWireless:
                    ControlWeb.menuWireless();
                    return;
                case ControlWeb.AccionWeb.MenuWirelessStatistics:
                    ControlWeb.menuWirelessStatistics();
                    return;
                case ControlWeb.AccionWeb.LeerDatos:
                    ControlWeb.obenerDatosWireless();
                    return;
                default:
                    ControlWeb.accionWeb  = ControlWeb.AccionWeb.Ninguna;
                    return;
            }
        }

        //Herramienta para test, muestra los items devuelto por el WebControl
        private void btActualizar_Click(object sender, EventArgs e)
        {
            //Navegar y mostrar
            List<String> registrosMacControl = ControlWeb.obtenerListaMacs();

            //Mostrar info al usuario
            if (registrosMacControl != null)
            {
                String cadena = String.Empty;

                foreach (String item in registrosMacControl)
                    cadena += cadena == String.Empty ? item : Environment.NewLine + item;

                MessageBox.Show("Items:" + Environment.NewLine + cadena);
            }
            else
            {
                MessageBox.Show("El control retornó Null");
            }
        }

        //Habilita el botón de test btActualizar
        private void picHabilitarBtActualizar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                btActualizar.Visible = true;
        }
    }
}
