
namespace MarbaSoftware
{
    partial class formFimDoIntervalo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFimDoIntervalo));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.labelHorario = new System.Windows.Forms.Label();
            this.labelIntervalo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.panelLinha = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.labelHorario);
            this.panelSuperior.Controls.Add(this.labelIntervalo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(2, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(396, 68);
            this.panelSuperior.TabIndex = 505;
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.BackColor = System.Drawing.Color.Transparent;
            this.labelHorario.Font = new System.Drawing.Font("Arial", 10F);
            this.labelHorario.ForeColor = System.Drawing.Color.Black;
            this.labelHorario.Location = new System.Drawing.Point(157, 42);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(96, 16);
            this.labelHorario.TabIndex = 496;
            this.labelHorario.Text = "00:00 ~ 00:00";
            // 
            // labelIntervalo
            // 
            this.labelIntervalo.AutoSize = true;
            this.labelIntervalo.BackColor = System.Drawing.Color.Transparent;
            this.labelIntervalo.Font = new System.Drawing.Font("Arial", 18F);
            this.labelIntervalo.ForeColor = System.Drawing.Color.Black;
            this.labelIntervalo.Location = new System.Drawing.Point(58, 16);
            this.labelIntervalo.Name = "labelIntervalo";
            this.labelIntervalo.Size = new System.Drawing.Size(284, 27);
            this.labelIntervalo.TabIndex = 1;
            this.labelIntervalo.Text = "Fim do intervalo - Lanche";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(398, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 191);
            this.panel3.TabIndex = 511;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 191);
            this.panel2.TabIndex = 510;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 2);
            this.panel1.TabIndex = 509;
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.BackColor = System.Drawing.Color.White;
            this.buttonContinuar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonContinuar.BackgroundImage")));
            this.buttonContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonContinuar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonContinuar.ForeColor = System.Drawing.Color.White;
            this.buttonContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonContinuar.Location = new System.Drawing.Point(201, 134);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(117, 30);
            this.buttonContinuar.TabIndex = 508;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = false;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.BackColor = System.Drawing.Color.White;
            this.buttonFinalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFinalizar.BackgroundImage")));
            this.buttonFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFinalizar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonFinalizar.ForeColor = System.Drawing.Color.White;
            this.buttonFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinalizar.Location = new System.Drawing.Point(78, 134);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(117, 30);
            this.buttonFinalizar.TabIndex = 507;
            this.buttonFinalizar.Text = "Finalizar";
            this.buttonFinalizar.UseVisualStyleBackColor = false;
            this.buttonFinalizar.Click += new System.EventHandler(this.buttonFinalizar_Click);
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.BackColor = System.Drawing.Color.Transparent;
            this.labelMensagem.Font = new System.Drawing.Font("Arial", 10F);
            this.labelMensagem.ForeColor = System.Drawing.Color.Black;
            this.labelMensagem.Location = new System.Drawing.Point(157, 82);
            this.labelMensagem.MaximumSize = new System.Drawing.Size(320, 0);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(77, 16);
            this.labelMensagem.TabIndex = 506;
            this.labelMensagem.Text = "Mensagem";
            this.labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinha
            // 
            this.panelLinha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLinha.BackgroundImage")));
            this.panelLinha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLinha.Location = new System.Drawing.Point(3, 67);
            this.panelLinha.Name = "panelLinha";
            this.panelLinha.Size = new System.Drawing.Size(394, 3);
            this.panelLinha.TabIndex = 512;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // formFimDoIntervalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 193);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.panelLinha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formFimDoIntervalo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formFimDoIntervalo";
            this.Load += new System.EventHandler(this.formFimDoIntervalo_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.Label labelIntervalo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Panel panelLinha;
        private System.Windows.Forms.Timer timer;
    }
}