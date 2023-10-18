
namespace MarbaSoftware
{
    partial class formTelaInicialPrincipalEstoque
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
            System.Windows.Forms.PictureBox pictureBoxFechar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialPrincipalEstoque));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEtiquetas = new System.Windows.Forms.Button();
            this.buttonSobrando = new System.Windows.Forms.Button();
            this.buttonPrevisoes = new System.Windows.Forms.Button();
            this.buttonAlmoxarifado = new System.Windows.Forms.Button();
            this.buttonTransferencia = new System.Windows.Forms.Button();
            this.buttonAvarias = new System.Windows.Forms.Button();
            this.buttonAcabamento = new System.Windows.Forms.Button();
            this.buttonLocalizacoes = new System.Windows.Forms.Button();
            pictureBoxFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).BeginInit();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFechar
            // 
            pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            pictureBoxFechar.Location = new System.Drawing.Point(423, 3);
            pictureBoxFechar.Name = "pictureBoxFechar";
            pictureBoxFechar.Size = new System.Drawing.Size(15, 15);
            pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxFechar.TabIndex = 20;
            pictureBoxFechar.TabStop = false;
            pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.pictureBox2);
            this.panelSuperior.Controls.Add(this.labelTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(443, 26);
            this.panelSuperior.TabIndex = 47;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(24, 4);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(52, 16);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Estoque";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 215);
            this.panel3.TabIndex = 52;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(440, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 215);
            this.panel2.TabIndex = 51;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 241);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(443, 3);
            this.panel4.TabIndex = 50;
            // 
            // buttonEtiquetas
            // 
            this.buttonEtiquetas.BackColor = System.Drawing.Color.Red;
            this.buttonEtiquetas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEtiquetas.BackgroundImage")));
            this.buttonEtiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEtiquetas.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEtiquetas.FlatAppearance.BorderSize = 5;
            this.buttonEtiquetas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonEtiquetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonEtiquetas.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonEtiquetas.ForeColor = System.Drawing.Color.White;
            this.buttonEtiquetas.Location = new System.Drawing.Point(155, 46);
            this.buttonEtiquetas.Name = "buttonEtiquetas";
            this.buttonEtiquetas.Size = new System.Drawing.Size(131, 40);
            this.buttonEtiquetas.TabIndex = 54;
            this.buttonEtiquetas.Text = "Etiquetas";
            this.buttonEtiquetas.UseVisualStyleBackColor = false;
            this.buttonEtiquetas.Click += new System.EventHandler(this.buttonEtiquetas_Click);
            // 
            // buttonSobrando
            // 
            this.buttonSobrando.BackColor = System.Drawing.Color.Red;
            this.buttonSobrando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSobrando.BackgroundImage")));
            this.buttonSobrando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSobrando.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSobrando.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSobrando.FlatAppearance.BorderSize = 5;
            this.buttonSobrando.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSobrando.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonSobrando.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSobrando.ForeColor = System.Drawing.Color.White;
            this.buttonSobrando.Location = new System.Drawing.Point(296, 46);
            this.buttonSobrando.Name = "buttonSobrando";
            this.buttonSobrando.Size = new System.Drawing.Size(131, 40);
            this.buttonSobrando.TabIndex = 55;
            this.buttonSobrando.Text = "Produtos sobrando";
            this.buttonSobrando.UseVisualStyleBackColor = false;
            this.buttonSobrando.Click += new System.EventHandler(this.buttonSobrando_Click);
            // 
            // buttonPrevisoes
            // 
            this.buttonPrevisoes.BackColor = System.Drawing.Color.Red;
            this.buttonPrevisoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrevisoes.BackgroundImage")));
            this.buttonPrevisoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevisoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrevisoes.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonPrevisoes.FlatAppearance.BorderSize = 5;
            this.buttonPrevisoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPrevisoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonPrevisoes.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPrevisoes.ForeColor = System.Drawing.Color.White;
            this.buttonPrevisoes.Location = new System.Drawing.Point(14, 106);
            this.buttonPrevisoes.Name = "buttonPrevisoes";
            this.buttonPrevisoes.Size = new System.Drawing.Size(131, 47);
            this.buttonPrevisoes.TabIndex = 56;
            this.buttonPrevisoes.Text = "Previsões de recebimento";
            this.buttonPrevisoes.UseVisualStyleBackColor = false;
            this.buttonPrevisoes.Click += new System.EventHandler(this.buttonPrevisoes_Click);
            // 
            // buttonAlmoxarifado
            // 
            this.buttonAlmoxarifado.BackColor = System.Drawing.Color.Red;
            this.buttonAlmoxarifado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAlmoxarifado.BackgroundImage")));
            this.buttonAlmoxarifado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAlmoxarifado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAlmoxarifado.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAlmoxarifado.FlatAppearance.BorderSize = 5;
            this.buttonAlmoxarifado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAlmoxarifado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonAlmoxarifado.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAlmoxarifado.ForeColor = System.Drawing.Color.White;
            this.buttonAlmoxarifado.Location = new System.Drawing.Point(155, 106);
            this.buttonAlmoxarifado.Name = "buttonAlmoxarifado";
            this.buttonAlmoxarifado.Size = new System.Drawing.Size(131, 47);
            this.buttonAlmoxarifado.TabIndex = 57;
            this.buttonAlmoxarifado.Text = "Almoxarifado";
            this.buttonAlmoxarifado.UseVisualStyleBackColor = false;
            this.buttonAlmoxarifado.Click += new System.EventHandler(this.buttonAlmoxarifado_Click);
            // 
            // buttonTransferencia
            // 
            this.buttonTransferencia.BackColor = System.Drawing.Color.Red;
            this.buttonTransferencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTransferencia.BackgroundImage")));
            this.buttonTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTransferencia.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonTransferencia.FlatAppearance.BorderSize = 5;
            this.buttonTransferencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTransferencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonTransferencia.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonTransferencia.ForeColor = System.Drawing.Color.White;
            this.buttonTransferencia.Location = new System.Drawing.Point(296, 106);
            this.buttonTransferencia.Name = "buttonTransferencia";
            this.buttonTransferencia.Size = new System.Drawing.Size(131, 47);
            this.buttonTransferencia.TabIndex = 58;
            this.buttonTransferencia.Text = "Transferência de estoque";
            this.buttonTransferencia.UseVisualStyleBackColor = false;
            this.buttonTransferencia.Click += new System.EventHandler(this.buttonTransferencia_Click);
            // 
            // buttonAvarias
            // 
            this.buttonAvarias.BackColor = System.Drawing.Color.Red;
            this.buttonAvarias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAvarias.BackgroundImage")));
            this.buttonAvarias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAvarias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAvarias.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAvarias.FlatAppearance.BorderSize = 5;
            this.buttonAvarias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAvarias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonAvarias.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAvarias.ForeColor = System.Drawing.Color.White;
            this.buttonAvarias.Location = new System.Drawing.Point(14, 173);
            this.buttonAvarias.Name = "buttonAvarias";
            this.buttonAvarias.Size = new System.Drawing.Size(131, 47);
            this.buttonAvarias.TabIndex = 59;
            this.buttonAvarias.Text = "Identificação de avarias";
            this.buttonAvarias.UseVisualStyleBackColor = false;
            this.buttonAvarias.Click += new System.EventHandler(this.buttonAvarias_Click);
            // 
            // buttonAcabamento
            // 
            this.buttonAcabamento.BackColor = System.Drawing.Color.Red;
            this.buttonAcabamento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAcabamento.BackgroundImage")));
            this.buttonAcabamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAcabamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcabamento.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAcabamento.FlatAppearance.BorderSize = 5;
            this.buttonAcabamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAcabamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonAcabamento.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAcabamento.ForeColor = System.Drawing.Color.White;
            this.buttonAcabamento.Location = new System.Drawing.Point(155, 173);
            this.buttonAcabamento.Name = "buttonAcabamento";
            this.buttonAcabamento.Size = new System.Drawing.Size(131, 47);
            this.buttonAcabamento.TabIndex = 60;
            this.buttonAcabamento.Text = "Registrar acabamento";
            this.buttonAcabamento.UseVisualStyleBackColor = false;
            // 
            // buttonLocalizacoes
            // 
            this.buttonLocalizacoes.BackColor = System.Drawing.Color.Red;
            this.buttonLocalizacoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLocalizacoes.BackgroundImage")));
            this.buttonLocalizacoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLocalizacoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLocalizacoes.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonLocalizacoes.FlatAppearance.BorderSize = 5;
            this.buttonLocalizacoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLocalizacoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonLocalizacoes.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonLocalizacoes.ForeColor = System.Drawing.Color.White;
            this.buttonLocalizacoes.Location = new System.Drawing.Point(14, 46);
            this.buttonLocalizacoes.Name = "buttonLocalizacoes";
            this.buttonLocalizacoes.Size = new System.Drawing.Size(131, 40);
            this.buttonLocalizacoes.TabIndex = 61;
            this.buttonLocalizacoes.Text = "Definir localizações";
            this.buttonLocalizacoes.UseVisualStyleBackColor = false;
            this.buttonLocalizacoes.Click += new System.EventHandler(this.buttonLocalizacoes_Click);
            // 
            // formTelaInicialPrincipalEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 244);
            this.Controls.Add(this.buttonLocalizacoes);
            this.Controls.Add(this.buttonAcabamento);
            this.Controls.Add(this.buttonAvarias);
            this.Controls.Add(this.buttonTransferencia);
            this.Controls.Add(this.buttonAlmoxarifado);
            this.Controls.Add(this.buttonPrevisoes);
            this.Controls.Add(this.buttonSobrando);
            this.Controls.Add(this.buttonEtiquetas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formTelaInicialPrincipalEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formTelaInicialPrincipalEstoque";
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonEtiquetas;
        private System.Windows.Forms.Button buttonSobrando;
        private System.Windows.Forms.Button buttonPrevisoes;
        private System.Windows.Forms.Button buttonAlmoxarifado;
        private System.Windows.Forms.Button buttonTransferencia;
        private System.Windows.Forms.Button buttonAvarias;
        private System.Windows.Forms.Button buttonAcabamento;
        private System.Windows.Forms.Button buttonLocalizacoes;
    }
}