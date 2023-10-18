
namespace MarbaSoftware
{
    partial class formCatalogoImagens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogoImagens));
            this.panelImagem = new System.Windows.Forms.Panel();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.buttonApagar = new System.Windows.Forms.Button();
            this.textBoxAtual = new System.Windows.Forms.TextBox();
            this.pbAnterior = new System.Windows.Forms.PictureBox();
            this.pbProximo = new System.Windows.Forms.PictureBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelVenda = new System.Windows.Forms.Label();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxImagem = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.textBoxDimensao = new System.Windows.Forms.TextBox();
            this.panelImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelImagem
            // 
            this.panelImagem.Controls.Add(this.pictureBoxImagem);
            this.panelImagem.Controls.Add(this.panel3);
            this.panelImagem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelImagem.Location = new System.Drawing.Point(0, 111);
            this.panelImagem.Name = "panelImagem";
            this.panelImagem.Size = new System.Drawing.Size(800, 597);
            this.panelImagem.TabIndex = 0;
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BackColor = System.Drawing.Color.White;
            this.pictureBoxImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImagem.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(800, 524);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxImagem.TabIndex = 1;
            this.pictureBoxImagem.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.buttonSalvar);
            this.panel3.Controls.Add(this.buttonExportar);
            this.panel3.Controls.Add(this.buttonApagar);
            this.panel3.Controls.Add(this.textBoxAtual);
            this.panel3.Controls.Add(this.pbAnterior);
            this.panel3.Controls.Add(this.pbProximo);
            this.panel3.Controls.Add(this.textBoxTotal);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 73);
            this.panel3.TabIndex = 0;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonSalvar.FlatAppearance.BorderSize = 2;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(274, 10);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(253, 51);
            this.buttonSalvar.TabIndex = 435;
            this.buttonSalvar.Text = "Salvar imagem";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Visible = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonExportar
            // 
            this.buttonExportar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportar.ForeColor = System.Drawing.Color.Red;
            this.buttonExportar.Location = new System.Drawing.Point(17, 22);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(200, 28);
            this.buttonExportar.TabIndex = 441;
            this.buttonExportar.Text = "Exportar imagem";
            this.buttonExportar.UseVisualStyleBackColor = true;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // buttonApagar
            // 
            this.buttonApagar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApagar.ForeColor = System.Drawing.Color.Red;
            this.buttonApagar.Location = new System.Drawing.Point(572, 22);
            this.buttonApagar.Name = "buttonApagar";
            this.buttonApagar.Size = new System.Drawing.Size(200, 28);
            this.buttonApagar.TabIndex = 440;
            this.buttonApagar.Text = "Apagar imagem";
            this.buttonApagar.UseVisualStyleBackColor = true;
            this.buttonApagar.Click += new System.EventHandler(this.buttonApagar_Click);
            // 
            // textBoxAtual
            // 
            this.textBoxAtual.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAtual.Location = new System.Drawing.Point(330, 19);
            this.textBoxAtual.Name = "textBoxAtual";
            this.textBoxAtual.Size = new System.Drawing.Size(44, 32);
            this.textBoxAtual.TabIndex = 438;
            this.textBoxAtual.Text = "0";
            this.textBoxAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAtual.TextChanged += new System.EventHandler(this.textBoxAtual_TextChanged);
            this.textBoxAtual.Enter += new System.EventHandler(this.textBoxAtual_Enter);
            this.textBoxAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAtual_KeyPress);
            this.textBoxAtual.Leave += new System.EventHandler(this.textBoxAtual_Leave);
            // 
            // pbAnterior
            // 
            this.pbAnterior.BackColor = System.Drawing.Color.Transparent;
            this.pbAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("pbAnterior.Image")));
            this.pbAnterior.Location = new System.Drawing.Point(283, 19);
            this.pbAnterior.Name = "pbAnterior";
            this.pbAnterior.Size = new System.Drawing.Size(30, 30);
            this.pbAnterior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnterior.TabIndex = 435;
            this.pbAnterior.TabStop = false;
            this.pbAnterior.Click += new System.EventHandler(this.pbAnterior_Click);
            // 
            // pbProximo
            // 
            this.pbProximo.BackColor = System.Drawing.Color.Transparent;
            this.pbProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbProximo.Image = ((System.Drawing.Image)(resources.GetObject("pbProximo.Image")));
            this.pbProximo.Location = new System.Drawing.Point(488, 19);
            this.pbProximo.Name = "pbProximo";
            this.pbProximo.Size = new System.Drawing.Size(30, 30);
            this.pbProximo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProximo.TabIndex = 436;
            this.pbProximo.TabStop = false;
            this.pbProximo.Click += new System.EventHandler(this.pbProximo_Click);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTotal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(427, 19);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(44, 32);
            this.textBoxTotal.TabIndex = 439;
            this.textBoxTotal.TabStop = false;
            this.textBoxTotal.Text = "0";
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 437;
            this.label1.Text = "/";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.textBoxDimensao);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelVenda);
            this.panel2.Controls.Add(this.textBoxProduto);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBoxImagem);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.buttonInserir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 111);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(620, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 25);
            this.label4.TabIndex = 481;
            this.label4.Text = "R$";
            // 
            // labelVenda
            // 
            this.labelVenda.AutoSize = true;
            this.labelVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelVenda.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVenda.Location = new System.Drawing.Point(663, 53);
            this.labelVenda.Name = "labelVenda";
            this.labelVenda.Size = new System.Drawing.Size(79, 40);
            this.labelVenda.TabIndex = 480;
            this.labelVenda.Text = "0,00";
            // 
            // textBoxProduto
            // 
            this.textBoxProduto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxProduto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProduto.ForeColor = System.Drawing.Color.Black;
            this.textBoxProduto.Location = new System.Drawing.Point(82, 14);
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.ReadOnly = true;
            this.textBoxProduto.Size = new System.Drawing.Size(481, 26);
            this.textBoxProduto.TabIndex = 479;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 477;
            this.label3.Text = "Produto:";
            // 
            // comboBoxImagem
            // 
            this.comboBoxImagem.BackColor = System.Drawing.Color.White;
            this.comboBoxImagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxImagem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxImagem.ForeColor = System.Drawing.Color.Black;
            this.comboBoxImagem.FormattingEnabled = true;
            this.comboBoxImagem.Location = new System.Drawing.Point(84, 62);
            this.comboBoxImagem.Name = "comboBoxImagem";
            this.comboBoxImagem.Size = new System.Drawing.Size(329, 27);
            this.comboBoxImagem.TabIndex = 474;
            this.comboBoxImagem.SelectedIndexChanged += new System.EventHandler(this.comboBoxImagem_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(14, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 473;
            this.label18.Text = "Imagem:";
            // 
            // buttonInserir
            // 
            this.buttonInserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInserir.BackColor = System.Drawing.Color.Red;
            this.buttonInserir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInserir.BackgroundImage")));
            this.buttonInserir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInserir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInserir.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonInserir.FlatAppearance.BorderSize = 2;
            this.buttonInserir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInserir.ForeColor = System.Drawing.Color.White;
            this.buttonInserir.Location = new System.Drawing.Point(608, 12);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(180, 28);
            this.buttonInserir.TabIndex = 1;
            this.buttonInserir.Text = "Inserir imagem";
            this.buttonInserir.UseVisualStyleBackColor = false;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // textBoxDimensao
            // 
            this.textBoxDimensao.Location = new System.Drawing.Point(463, 71);
            this.textBoxDimensao.Name = "textBoxDimensao";
            this.textBoxDimensao.Size = new System.Drawing.Size(55, 20);
            this.textBoxDimensao.TabIndex = 482;
            this.textBoxDimensao.Text = "100%";
            this.textBoxDimensao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDimensao.Enter += new System.EventHandler(this.textBoxDimensao_Enter);
            this.textBoxDimensao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDimensao_KeyPress);
            this.textBoxDimensao.Leave += new System.EventHandler(this.textBoxDimensao_Leave);
            // 
            // formCatalogoImagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 708);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelImagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCatalogoImagens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagens do produto";
            this.Load += new System.EventHandler(this.formCatalogoImagens_Load);
            this.panelImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImagem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.TextBox textBoxAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbProximo;
        private System.Windows.Forms.PictureBox pbAnterior;
        private System.Windows.Forms.ComboBox comboBoxImagem;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelVenda;
        private System.Windows.Forms.Button buttonApagar;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.TextBox textBoxDimensao;
    }
}