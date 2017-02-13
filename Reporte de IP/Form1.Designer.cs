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
            this.procesoBackground = new System.ComponentModel.BackgroundWorker();
            this.web = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.btActualizar = new System.Windows.Forms.Button();
            this.picHabilitarBtActualizar = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHabilitarBtActualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txFrecuencia);
            this.groupBox2.Location = new System.Drawing.Point(15, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 130);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Frecuencia (Segundos):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txFrecuencia
            // 
            this.txFrecuencia.Location = new System.Drawing.Point(148, 24);
            this.txFrecuencia.MaxLength = 4;
            this.txFrecuencia.Name = "txFrecuencia";
            this.txFrecuencia.Size = new System.Drawing.Size(89, 20);
            this.txFrecuencia.TabIndex = 6;
            this.txFrecuencia.Text = "10";
            this.txFrecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txFrecuencia.TextChanged += new System.EventHandler(this.txFrecuencia_TextChanged);
            // 
            // btIniciar
            // 
            this.btIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btIniciar.Location = new System.Drawing.Point(536, 18);
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
            this.btDetener.Location = new System.Drawing.Point(536, 57);
            this.btDetener.Name = "btDetener";
            this.btDetener.Size = new System.Drawing.Size(189, 33);
            this.btDetener.TabIndex = 1;
            this.btDetener.Text = "Detener";
            this.btDetener.UseVisualStyleBackColor = false;
            this.btDetener.Click += new System.EventHandler(this.btDetener_Click);
            // 
            // btAcciones
            // 
            this.btAcciones.Location = new System.Drawing.Point(537, 109);
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
            this.lsConectados.Size = new System.Drawing.Size(713, 251);
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
            this.label6.Location = new System.Drawing.Point(12, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cantidad:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCant
            // 
            this.lbCant.AutoSize = true;
            this.lbCant.Location = new System.Drawing.Point(70, 426);
            this.lbCant.Name = "lbCant";
            this.lbCant.Size = new System.Drawing.Size(13, 13);
            this.lbCant.TabIndex = 11;
            this.lbCant.Text = "0";
            this.lbCant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(536, 444);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(188, 33);
            this.btGuardar.TabIndex = 8;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // procesoBackground
            // 
            this.procesoBackground.WorkerReportsProgress = true;
            this.procesoBackground.WorkerSupportsCancellation = true;
            this.procesoBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.procesoBackground_DoWork);
            this.procesoBackground.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.procesoBackground_ProgressChanged);
            this.procesoBackground.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.procesoBackground_RunWorkerCompleted);
            // 
            // web
            // 
            this.web.Location = new System.Drawing.Point(731, 18);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(348, 405);
            this.web.TabIndex = 12;
            this.web.Visible = false;
            this.web.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.web_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(801, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Navegando hasta el sitio de Estadísticas...";
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(970, 429);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(109, 24);
            this.btActualizar.TabIndex = 15;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Visible = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // picHabilitarBtActualizar
            // 
            this.picHabilitarBtActualizar.Location = new System.Drawing.Point(970, 429);
            this.picHabilitarBtActualizar.Name = "picHabilitarBtActualizar";
            this.picHabilitarBtActualizar.Size = new System.Drawing.Size(109, 24);
            this.picHabilitarBtActualizar.TabIndex = 16;
            this.picHabilitarBtActualizar.TabStop = false;
            this.picHabilitarBtActualizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHabilitarBtActualizar_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 489);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.web);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.lbCant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsConectados);
            this.Controls.Add(this.btAcciones);
            this.Controls.Add(this.btDetener);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picHabilitarBtActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de IP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHabilitarBtActualizar)).EndInit();
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
        private System.ComponentModel.BackgroundWorker procesoBackground;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.PictureBox picHabilitarBtActualizar;
    }
}

