
namespace MarbaSoftware
{
    partial class formIntervalo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formIntervalo));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.labelHorario = new System.Windows.Forms.Label();
            this.labelIntervalo = new System.Windows.Forms.Label();
            this.irButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPausar = new System.Windows.Forms.Button();
            this.atividadesButton = new System.Windows.Forms.Button();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.panelLinha = new System.Windows.Forms.Panel();
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
            this.panelSuperior.TabIndex = 496;
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
            this.labelIntervalo.Location = new System.Drawing.Point(98, 16);
            this.labelIntervalo.Name = "labelIntervalo";
            this.labelIntervalo.Size = new System.Drawing.Size(204, 27);
            this.labelIntervalo.TabIndex = 1;
            this.labelIntervalo.Text = "Intervalo - Lanche";
            // 
            // irButton
            // 
            this.irButton.BackColor = System.Drawing.Color.White;
            this.irButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("irButton.BackgroundImage")));
            this.irButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.irButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.irButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.irButton.Font = new System.Drawing.Font("Arial", 8.25F);
            this.irButton.ForeColor = System.Drawing.Color.White;
            this.irButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.irButton.Location = new System.Drawing.Point(20, 134);
            this.irButton.Name = "irButton";
            this.irButton.Size = new System.Drawing.Size(117, 30);
            this.irButton.TabIndex = 498;
            this.irButton.Text = "Ir para o almoço";
            this.irButton.UseVisualStyleBackColor = false;
            this.irButton.Click += new System.EventHandler(this.irButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(398, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 191);
            this.panel3.TabIndex = 503;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 191);
            this.panel2.TabIndex = 502;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 2);
            this.panel1.TabIndex = 501;
            // 
            // buttonPausar
            // 
            this.buttonPausar.BackColor = System.Drawing.Color.White;
            this.buttonPausar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPausar.BackgroundImage")));
            this.buttonPausar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPausar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPausar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonPausar.ForeColor = System.Drawing.Color.White;
            this.buttonPausar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPausar.Location = new System.Drawing.Point(264, 134);
            this.buttonPausar.Name = "buttonPausar";
            this.buttonPausar.Size = new System.Drawing.Size(117, 30);
            this.buttonPausar.TabIndex = 500;
            this.buttonPausar.Text = "Continuar";
            this.buttonPausar.UseVisualStyleBackColor = false;
            this.buttonPausar.Click += new System.EventHandler(this.buttonPausar_Click);
            // 
            // atividadesButton
            // 
            this.atividadesButton.BackColor = System.Drawing.Color.White;
            this.atividadesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("atividadesButton.BackgroundImage")));
            this.atividadesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.atividadesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.atividadesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.atividadesButton.Font = new System.Drawing.Font("Arial", 8.25F);
            this.atividadesButton.ForeColor = System.Drawing.Color.White;
            this.atividadesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.atividadesButton.Location = new System.Drawing.Point(142, 134);
            this.atividadesButton.Name = "atividadesButton";
            this.atividadesButton.Size = new System.Drawing.Size(117, 30);
            this.atividadesButton.TabIndex = 499;
            this.atividadesButton.Text = "Atividades";
            this.atividadesButton.UseVisualStyleBackColor = false;
            this.atividadesButton.Click += new System.EventHandler(this.atividadesButton_Click);
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
            this.labelMensagem.TabIndex = 497;
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
            this.panelLinha.TabIndex = 504;
            // 
            // formIntervalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 193);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.irButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonPausar);
            this.Controls.Add(this.atividadesButton);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.panelLinha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formIntervalo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formIntervalo";
            this.Load += new System.EventHandler(this.formIntervalo_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.Label labelIntervalo;
        private System.Windows.Forms.Button irButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPausar;
        private System.Windows.Forms.Button atividadesButton;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Panel panelLinha;
    }
}