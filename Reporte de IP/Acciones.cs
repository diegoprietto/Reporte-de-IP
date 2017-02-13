using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reporte_de_IP.Datos;

namespace Reporte_de_IP
{
    public partial class Acciones : Form
    {
        public Acciones()
        {
            InitializeComponent();
        }

        //Indica si se modificó algun dato en esta vista, que se requiera guardar
        private bool modificado = false;

        private void Acciones_Load(object sender, EventArgs e)
        {
            //Cargar datos en los controles
            limpiarDatos();
            cargarControles();

            //Quitar la marca de modificado
            modificado = false;
        }

        //Borra todos los datos
        private void limpiarDatos()
        {
            //Borrar todas las filas
            grillaAcciones.Rows.Clear();

            //Borrar combo
            cmbDispositivos.Items.Clear();
        }

        //Carga la grilla y el combo
        private void cargarControles()
        {
            //Cargar grilla
            foreach (RegistroAccion registro in Core.listaAcciones)
            {
                //Agregar una nueva fila
                grillaAcciones.Rows.Add();
                DataGridViewRow nuevo = grillaAcciones.Rows[grillaAcciones.Rows.Count - 2];

                //Cargar datos
                nuevo.Cells[0].Value = registro.direccionMAC;
                nuevo.Cells[1].Value = registro.alConectarse;
                nuevo.Cells[2].Value = registro.alDesconectarse;
                nuevo.Cells[3].Value = registro.descripcion;
                nuevo.Cells[4].Value = registro.rutaExe;
                nuevo.Cells[5].Value = registro.parametro;
            }

            //Cargar combo
            foreach (IPDispositivo registro in Core.descripcionDispositivos)
            {
                cmbDispositivos.Items.Add(registro);
            }
        }

        private void btAgDisp_Click(object sender, EventArgs e)
        {
            if (cmbDispositivos.SelectedIndex >= 0)
            {
                //Obtener registro
                IPDispositivo seleccion = (IPDispositivo)cmbDispositivos.SelectedItem;

                //Agregar una nueva fila
                grillaAcciones.Rows.Add();
                DataGridViewRow nuevo = grillaAcciones.Rows[grillaAcciones.Rows.Count - 2];

                //Cargar datos
                nuevo.Cells[0].Value = seleccion.MAC.Trim();
                nuevo.Cells[1].Value = false;
                nuevo.Cells[2].Value = false;
                nuevo.Cells[3].Value = String.Empty;
                nuevo.Cells[4].Value = String.Empty;
                nuevo.Cells[5].Value = String.Empty;
            }

            modificado = true;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            //Crear colección con los items actuales
            List<RegistroAccion> nuevaLista = new List<RegistroAccion>();

            //Recorrer filas
            foreach (DataGridViewRow fila in grillaAcciones.Rows)
            {
                //La última fila no contiene datos
                if (fila.Index != grillaAcciones.Rows.Count - 1)
                {
                    //Obtener datos
                    RegistroAccion nuevo = new RegistroAccion(fila.Cells[0].Value.ToString(),
                        Boolean.Parse(fila.Cells[1].Value.ToString()),
                        Boolean.Parse(fila.Cells[2].Value.ToString()),
                        fila.Cells[3].Value != null ? fila.Cells[3].Value.ToString() : "",
                        fila.Cells[4].Value != null ? fila.Cells[4].Value.ToString() : "",
                        fila.Cells[5].Value != null ? fila.Cells[5].Value.ToString() : "");

                    nuevaLista.Add(nuevo);
                }
            }

            //Insertar la nueva lista
            Core.listaAcciones = nuevaLista;

            //Indicar que no hay cambios pendientes para guardar
            modificado = false;

            //Cerrar formulario
            DialogResult = DialogResult.OK;
        }

        private void Acciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Verificar si se guardaron los cambios
            if (modificado)
            {
                if (MessageBox.Show("Hay cambios sin guardar, si sale se perderán." + Environment.NewLine + "¿Desea cerrar de todos modos?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;    //Cancelar cierre
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void grillaAcciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            modificado = true;
        }

        private void grillaAcciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            modificado = true;
        }

        private void grillaAcciones_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            modificado = true;
        }
    }
}
