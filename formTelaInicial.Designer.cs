
namespace MarbaSoftware
{
    partial class formTelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicial));
            this.labelColaborador = new System.Windows.Forms.Label();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxColaborador = new System.Windows.Forms.PictureBox();
            this.labelCargo = new System.Windows.Forms.Label();
            this.labelMatricula = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInicio = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCronologico = new System.Windows.Forms.Button();
            this.buttonCronologico1 = new System.Windows.Forms.Button();
            this.buttonAtividades = new System.Windows.Forms.Button();
            this.buttonAtividades1 = new System.Windows.Forms.Button();
            this.buttonGestao = new System.Windows.Forms.Button();
            this.buttonGestao1 = new System.Windows.Forms.Button();
            this.buttonInicial = new System.Windows.Forms.Button();
            this.buttonInicial1 = new System.Windows.Forms.Button();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.labelData = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.timerAviso = new System.Windows.Forms.Timer(this.components);
            this.timerAfazeres = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColaborador)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelColaborador
            // 
            this.labelColaborador.AutoSize = true;
            this.labelColaborador.BackColor = System.Drawing.Color.Transparent;
            this.labelColaborador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelColaborador.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColaborador.Location = new System.Drawing.Point(79, 9);
            this.labelColaborador.Name = "labelColaborador";
            this.labelColaborador.Size = new System.Drawing.Size(48, 14);
            this.labelColaborador.TabIndex = 0;
            this.labelColaborador.Text = "NOME";
            this.labelColaborador.Click += new System.EventHandler(this.labelUsuario_Click);
            // 
            // timerHora
            // 
            this.timerHora.Interval = 1000;
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
            // 
            // pictureBoxColaborador
            // 
            this.pictureBoxColaborador.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxColaborador.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxColaborador.Name = "pictureBoxColaborador";
            this.pictureBoxColaborador.Size = new System.Drawing.Size(70, 68);
            this.pictureBoxColaborador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxColaborador.TabIndex = 3;
            this.pictureBoxColaborador.TabStop = false;
            // 
            // labelCargo
            // 
            this.labelCargo.AutoSize = true;
            this.labelCargo.BackColor = System.Drawing.Color.Transparent;
            this.labelCargo.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCargo.Location = new System.Drawing.Point(79, 26);
            this.labelCargo.Name = "labelCargo";
            this.labelCargo.Size = new System.Drawing.Size(54, 14);
            this.labelCargo.TabIndex = 4;
            this.labelCargo.Text = "CARGO";
            // 
            // labelMatricula
            // 
            this.labelMatricula.AutoSize = true;
            this.labelMatricula.BackColor = System.Drawing.Color.Transparent;
            this.labelMatricula.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricula.Location = new System.Drawing.Point(79, 43);
            this.labelMatricula.Name = "labelMatricula";
            this.labelMatricula.Size = new System.Drawing.Size(86, 14);
            this.labelMatricula.TabIndex = 5;
            this.labelMatricula.Text = "MATRÍCULA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.buttonInicio);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBoxColaborador);
            this.panel1.Controls.Add(this.labelMatricula);
            this.panel1.Controls.Add(this.labelColaborador);
            this.panel1.Controls.Add(this.labelCargo);
            this.panel1.Controls.Add(this.buttonCronologico);
            this.panel1.Controls.Add(this.buttonCronologico1);
            this.panel1.Controls.Add(this.buttonAtividades);
            this.panel1.Controls.Add(this.buttonAtividades1);
            this.panel1.Controls.Add(this.buttonGestao);
            this.panel1.Controls.Add(this.buttonGestao1);
            this.panel1.Controls.Add(this.buttonInicial);
            this.panel1.Controls.Add(this.buttonInicial1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 75);
            this.panel1.TabIndex = 6;
            // 
            // buttonInicio
            // 
            this.buttonInicio.BackColor = System.Drawing.Color.Red;
            this.buttonInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonInicio.Image")));
            this.buttonInicio.Location = new System.Drawing.Point(822, 42);
            this.buttonInicio.Name = "buttonInicio";
            this.buttonInicio.Size = new System.Drawing.Size(30, 30);
            this.buttonInicio.TabIndex = 40;
            this.buttonInicio.UseVisualStyleBackColor = false;
            this.buttonInicio.Visible = false;
            this.buttonInicio.Click += new System.EventHandler(this.buttonInicio_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(82, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 3);
            this.panel2.TabIndex = 6;
            // 
            // buttonCronologico
            // 
            this.buttonCronologico.BackColor = System.Drawing.Color.Transparent;
            this.buttonCronologico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCronologico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCronologico.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonCronologico.FlatAppearance.BorderSize = 0;
            this.buttonCronologico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCronologico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCronologico.ForeColor = System.Drawing.Color.White;
            this.buttonCronologico.Image = ((System.Drawing.Image)(resources.GetObject("buttonCronologico.Image")));
            this.buttonCronologico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCronologico.Location = new System.Drawing.Point(641, 35);
            this.buttonCronologico.Name = "buttonCronologico";
            this.buttonCronologico.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCronologico.Size = new System.Drawing.Size(175, 40);
            this.buttonCronologico.TabIndex = 30;
            this.buttonCronologico.Text = "Controle Cronológico";
            this.buttonCronologico.UseVisualStyleBackColor = false;
            this.buttonCronologico.Visible = false;
            this.buttonCronologico.Click += new System.EventHandler(this.buttonCronologico_Click);
            // 
            // buttonCronologico1
            // 
            this.buttonCronologico1.BackColor = System.Drawing.Color.White;
            this.buttonCronologico1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCronologico1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCronologico1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonCronologico1.FlatAppearance.BorderSize = 0;
            this.buttonCronologico1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCronologico1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCronologico1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonCronologico1.Location = new System.Drawing.Point(641, 35);
            this.buttonCronologico1.Name = "buttonCronologico1";
            this.buttonCronologico1.Size = new System.Drawing.Size(175, 40);
            this.buttonCronologico1.TabIndex = 35;
            this.buttonCronologico1.Text = "Controle Cronológico";
            this.buttonCronologico1.UseVisualStyleBackColor = false;
            this.buttonCronologico1.Visible = false;
            // 
            // buttonAtividades
            // 
            this.buttonAtividades.BackColor = System.Drawing.Color.Transparent;
            this.buttonAtividades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtividades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtividades.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonAtividades.FlatAppearance.BorderSize = 0;
            this.buttonAtividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtividades.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtividades.ForeColor = System.Drawing.Color.White;
            this.buttonAtividades.Image = ((System.Drawing.Image)(resources.GetObject("buttonAtividades.Image")));
            this.buttonAtividades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtividades.Location = new System.Drawing.Point(464, 35);
            this.buttonAtividades.Name = "buttonAtividades";
            this.buttonAtividades.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAtividades.Size = new System.Drawing.Size(175, 40);
            this.buttonAtividades.TabIndex = 29;
            this.buttonAtividades.Text = "Atividades";
            this.buttonAtividades.UseVisualStyleBackColor = false;
            this.buttonAtividades.Visible = false;
            this.buttonAtividades.Click += new System.EventHandler(this.buttonAtividades_Click);
            // 
            // buttonAtividades1
            // 
            this.buttonAtividades1.BackColor = System.Drawing.Color.White;
            this.buttonAtividades1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtividades1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtividades1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonAtividades1.FlatAppearance.BorderSize = 0;
            this.buttonAtividades1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtividades1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtividades1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonAtividades1.Location = new System.Drawing.Point(464, 35);
            this.buttonAtividades1.Name = "buttonAtividades1";
            this.buttonAtividades1.Size = new System.Drawing.Size(175, 40);
            this.buttonAtividades1.TabIndex = 34;
            this.buttonAtividades1.Text = "Atividades";
            this.buttonAtividades1.UseVisualStyleBackColor = false;
            this.buttonAtividades1.Visible = false;
            // 
            // buttonGestao
            // 
            this.buttonGestao.BackColor = System.Drawing.Color.Transparent;
            this.buttonGestao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGestao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGestao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonGestao.FlatAppearance.BorderSize = 0;
            this.buttonGestao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGestao.ForeColor = System.Drawing.Color.White;
            this.buttonGestao.Image = ((System.Drawing.Image)(resources.GetObject("buttonGestao.Image")));
            this.buttonGestao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGestao.Location = new System.Drawing.Point(287, 35);
            this.buttonGestao.Name = "buttonGestao";
            this.buttonGestao.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonGestao.Size = new System.Drawing.Size(175, 40);
            this.buttonGestao.TabIndex = 38;
            this.buttonGestao.Text = "Tela Inicial";
            this.buttonGestao.UseVisualStyleBackColor = false;
            this.buttonGestao.Click += new System.EventHandler(this.buttonGestao_Click);
            // 
            // buttonGestao1
            // 
            this.buttonGestao1.BackColor = System.Drawing.Color.White;
            this.buttonGestao1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGestao1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGestao1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonGestao1.FlatAppearance.BorderSize = 0;
            this.buttonGestao1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestao1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGestao1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonGestao1.Location = new System.Drawing.Point(287, 35);
            this.buttonGestao1.Name = "buttonGestao1";
            this.buttonGestao1.Size = new System.Drawing.Size(175, 40);
            this.buttonGestao1.TabIndex = 39;
            this.buttonGestao1.Text = "Tela Inicial";
            this.buttonGestao1.UseVisualStyleBackColor = false;
            this.buttonGestao1.Visible = false;
            // 
            // buttonInicial
            // 
            this.buttonInicial.BackColor = System.Drawing.Color.Transparent;
            this.buttonInicial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInicial.BackgroundImage")));
            this.buttonInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInicial.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonInicial.FlatAppearance.BorderSize = 0;
            this.buttonInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInicial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicial.ForeColor = System.Drawing.Color.White;
            this.buttonInicial.Image = ((System.Drawing.Image)(resources.GetObject("buttonInicial.Image")));
            this.buttonInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInicial.Location = new System.Drawing.Point(287, 35);
            this.buttonInicial.Name = "buttonInicial";
            this.buttonInicial.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonInicial.Size = new System.Drawing.Size(175, 40);
            this.buttonInicial.TabIndex = 36;
            this.buttonInicial.Text = "Tela Inicial";
            this.buttonInicial.UseVisualStyleBackColor = false;
            this.buttonInicial.Click += new System.EventHandler(this.buttonInicial_Click);
            // 
            // buttonInicial1
            // 
            this.buttonInicial1.BackColor = System.Drawing.Color.White;
            this.buttonInicial1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInicial1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInicial1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonInicial1.FlatAppearance.BorderSize = 0;
            this.buttonInicial1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInicial1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicial1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonInicial1.Location = new System.Drawing.Point(287, 35);
            this.buttonInicial1.Name = "buttonInicial1";
            this.buttonInicial1.Size = new System.Drawing.Size(175, 40);
            this.buttonInicial1.TabIndex = 37;
            this.buttonInicial1.Text = "Tela Inicial";
            this.buttonInicial1.UseVisualStyleBackColor = false;
            this.buttonInicial1.Visible = false;
            // 
            // panelCentral
            // 
            this.panelCentral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCentral.Controls.Add(this.labelData);
            this.panelCentral.Controls.Add(this.labelHora);
            this.panelCentral.Location = new System.Drawing.Point(0, 75);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1301, 663);
            this.panelCentral.TabIndex = 7;
            // 
            // labelData
            // 
            this.labelData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(1000, 600);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(170, 14);
            this.labelData.TabIndex = 22;
            this.labelData.Text = "domingo, 01 de janeiro de 2021";
            // 
            // labelHora
            // 
            this.labelHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHora.AutoSize = true;
            this.labelHora.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.Location = new System.Drawing.Point(994, 546);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(197, 52);
            this.labelHora.TabIndex = 21;
            this.labelHora.Text = "00:00:00";
            // 
            // timerAviso
            // 
            this.timerAviso.Interval = 1000;
            // 
            // timerAfazeres
            // 
            this.timerAfazeres.Interval = 1000;
            this.timerAfazeres.Tick += new System.EventHandler(this.timerAfazeres_Tick);
            // 
            // formTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1301, 738);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formTelaInicial";
            this.Text = "TelaInicial";
            this.Load += new System.EventHandler(this.formTelaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColaborador)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelColaborador;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.PictureBox pictureBoxColaborador;
        private System.Windows.Forms.Label labelCargo;
        private System.Windows.Forms.Label labelMatricula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCronologico;
        private System.Windows.Forms.Button buttonAtividades;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Button buttonCronologico1;
        private System.Windows.Forms.Button buttonAtividades1;
        private System.Windows.Forms.Button buttonInicial1;
        private System.Windows.Forms.Button buttonInicial;
        private System.Windows.Forms.Button buttonGestao;
        private System.Windows.Forms.Button buttonGestao1;
        private System.Windows.Forms.Button buttonInicio;
        private System.Windows.Forms.Timer timerAviso;
        private System.Windows.Forms.Timer timerAfazeres;
    }
}