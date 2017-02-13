namespace Reporte_de_IP
{
    partial class Acciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acciones));
            this.grillaAcciones = new System.Windows.Forms.DataGridView();
            this.direccionIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alConectarse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alDesconectarse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutaExe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDispositivos = new System.Windows.Forms.ComboBox();
            this.btAgDisp = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaAcciones
            // 
            this.grillaAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.direccionIP,
            this.alConectarse,
            this.alDesconectarse,
            this.descripcion,
            this.rutaExe,
            this.parametro});
            this.grillaAcciones.Location = new System.Drawing.Point(12, 12);
            this.grillaAcciones.Name = "grillaAcciones";
            this.grillaAcciones.Size = new System.Drawing.Size(941, 367);
            this.grillaAcciones.TabIndex = 2;
            this.grillaAcciones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaAcciones_CellEndEdit);
            this.grillaAcciones.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grillaAcciones_RowsAdded);
            this.grillaAcciones.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grillaAcciones_RowsRemoved);
            // 
            // direccionIP
            // 
            this.direccionIP.HeaderText = "Dirección IP";
            this.direccionIP.Name = "direccionIP";
            // 
            // alConectarse
            // 
            this.alConectarse.HeaderText = "Conectarse";
            this.alConectarse.Name = "alConectarse";
            // 
            // alDesconectarse
            // 
            this.alDesconectarse.HeaderText = "Desconectarse";
            this.alDesconectarse.Name = "alDesconectarse";
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // rutaExe
            // 
            this.rutaExe.HeaderText = "Aplicación";
            this.rutaExe.Name = "rutaExe";
            // 
            // parametro
            // 
            this.parametro.HeaderText = "Parametros";
            this.parametro.Name = "parametro";
            // 
            // cmbDispositivos
            // 
            this.cmbDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispositivos.FormattingEnabled = true;
            this.cmbDispositivos.Location = new System.Drawing.Point(12, 411);
            this.cmbDispositivos.Name = "cmbDispositivos";
            this.cmbDispositivos.Size = new System.Drawing.Size(388, 21);
            this.cmbDispositivos.TabIndex = 3;
            // 
            // btAgDisp
            // 
            this.btAgDisp.Location = new System.Drawing.Point(406, 411);
            this.btAgDisp.Name = "btAgDisp";
            this.btAgDisp.Size = new System.Drawing.Size(123, 21);
            this.btAgDisp.TabIndex = 4;
            this.btAgDisp.Text = "Agregar a la grilla";
            this.btAgDisp.UseVisualStyleBackColor = true;
            this.btAgDisp.Click += new System.EventHandler(this.btAgDisp_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(765, 428);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(188, 33);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(571, 428);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(188, 33);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dispositivos:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 473);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btAgDisp);
            this.Controls.Add(this.cmbDispositivos);
            this.Controls.Add(this.grillaAcciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Acciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Acciones_FormClosing);
            this.Load += new System.EventHandler(this.Acciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaAcciones;
        private System.Windows.Forms.ComboBox cmbDispositivos;
        private System.Windows.Forms.Button btAgDisp;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionIP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alConectarse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alDesconectarse;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaExe;
        private System.Windows.Forms.DataGridViewTextBoxColumn parametro;
    }
}