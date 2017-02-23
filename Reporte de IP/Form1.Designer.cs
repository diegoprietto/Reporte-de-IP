namespace Reporte_de_IP
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txFrecuencia = new System.Windows.Forms.TextBox();
            this.btIniciar = new System.Windows.Forms.Button();
            this.btDetener = new System.Windows.Forms.Button();
            this.btAcciones = new System.Windows.Forms.Button();
            this.lsConectados = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbCant = new System.Windows.Forms.Label();
            this.btGuardar = new System.Windows.Forms.Button();
            this.Reloj = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbFechaMemoria = new System.Windows.Forms.Label();
            this.lbMsjError = new System.Windows.Forms.Label();
            this.chDesactivarAcciones = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txFrecuencia);
            this.groupBox2.Location = new System.Drawing.Point(11, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 146);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Frecuencia (ms):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txFrecuencia
            // 
            this.txFrecuencia.Location = new System.Drawing.Point(25, 46);
            this.txFrecuencia.MaxLength = 4;
            this.txFrecuencia.Name = "txFrecuencia";
            this.txFrecuencia.Size = new System.Drawing.Size(82, 20);
            this.txFrecuencia.TabIndex = 6;
            this.txFrecuencia.Text = "10";
            this.txFrecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txFrecuencia.TextChanged += new System.EventHandler(this.txFrecuencia_TextChanged);
            // 
            // btIniciar
            // 
            this.btIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btIniciar.Location = new System.Drawing.Point(155, 3);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(189, 33);
            this.btIniciar.TabIndex = 0;
            this.btIniciar.Text = "Iniciar";
            this.btIniciar.UseVisualStyleBackColor = false;
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // btDetener
            // 
            this.btDetener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btDetener.Enabled = false;
            this.btDetener.Location = new System.Drawing.Point(155, 36);
            this.btDetener.Name = "btDetener";
            this.btDetener.Size = new System.Drawing.Size(189, 33);
            this.btDetener.TabIndex = 1;
            this.btDetener.Text = "Detener";
            this.btDetener.UseVisualStyleBackColor = false;
            this.btDetener.Click += new System.EventHandler(this.btDetener_Click);
            // 
            // btAcciones
            // 
            this.btAcciones.Location = new System.Drawing.Point(156, 116);
            this.btAcciones.Name = "btAcciones";
            this.btAcciones.Size = new System.Drawing.Size(188, 33);
            this.btAcciones.TabIndex = 2;
            this.btAcciones.Text = "Cambiar acciones";
            this.btAcciones.UseVisualStyleBackColor = true;
            this.btAcciones.Click += new System.EventHandler(this.btAcciones_Click);
            // 
            // lsConectados
            // 
            this.lsConectados.FormattingEnabled = true;
            this.lsConectados.Location = new System.Drawing.Point(11, 172);
            this.lsConectados.Name = "lsConectados";
            this.lsConectados.Size = new System.Drawing.Size(333, 173);
            this.lsConectados.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dispositivos conectados:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cantidad:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCant
            // 
            this.lbCant.AutoSize = true;
            this.lbCant.Location = new System.Drawing.Point(70, 351);
            this.lbCant.Name = "lbCant";
            this.lbCant.Size = new System.Drawing.Size(13, 13);
            this.lbCant.TabIndex = 11;
            this.lbCant.Text = "0";
            this.lbCant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(161, 406);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(188, 33);
            this.btGuardar.TabIndex = 8;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // Reloj
            // 
            this.Reloj.Tick += new System.EventHandler(this.Reloj_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha/Hora:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFechaMemoria
            // 
            this.lbFechaMemoria.AutoSize = true;
            this.lbFechaMemoria.Location = new System.Drawing.Point(226, 351);
            this.lbFechaMemoria.Name = "lbFechaMemoria";
            this.lbFechaMemoria.Size = new System.Drawing.Size(10, 13);
            this.lbFechaMemoria.TabIndex = 13;
            this.lbFechaMemoria.Text = "-";
            this.lbFechaMemoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMsjError
            // 
            this.lbMsjError.AutoSize = true;
            this.lbMsjError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsjError.ForeColor = System.Drawing.Color.Red;
            this.lbMsjError.Location = new System.Drawing.Point(12, 376);
            this.lbMsjError.Name = "lbMsjError";
            this.lbMsjError.Size = new System.Drawing.Size(27, 13);
            this.lbMsjError.TabIndex = 14;
            this.lbMsjError.Text = "     ";
            this.lbMsjError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chDesactivarAcciones
            // 
            this.chDesactivarAcciones.Appearance = System.Windows.Forms.Appearance.Button;
            this.chDesactivarAcciones.Location = new System.Drawing.Point(155, 77);
            this.chDesactivarAcciones.Name = "chDesactivarAcciones";
            this.chDesactivarAcciones.Size = new System.Drawing.Size(188, 33);
            this.chDesactivarAcciones.TabIndex = 15;
            this.chDesactivarAcciones.Text = "Pausar Acciones";
            this.chDesactivarAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chDesactivarAcciones.UseVisualStyleBackColor = true;
            this.chDesactivarAcciones.CheckedChanged += new System.EventHandler(this.chDesactivarAcciones_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 446);
            this.Controls.Add(this.chDesactivarAcciones);
            this.Controls.Add(this.lbMsjError);
            this.Controls.Add(this.lbFechaMemoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.lbCant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsConectados);
            this.Controls.Add(this.btAcciones);
            this.Controls.Add(this.btDetener);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de IP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txFrecuencia;
        private System.Windows.Forms.Button btIniciar;
        private System.Windows.Forms.Button btDetener;
        private System.Windows.Forms.Button btAcciones;
        private System.Windows.Forms.ListBox lsConectados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbCant;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Timer Reloj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFechaMemoria;
        private System.Windows.Forms.Label lbMsjError;
        private System.Windows.Forms.CheckBox chDesactivarAcciones;
    }
}

