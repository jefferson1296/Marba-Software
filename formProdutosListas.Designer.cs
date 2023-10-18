
namespace MarbaSoftware
{
    partial class formProdutosListas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosListas));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.labelCabecalho = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLista = new System.Windows.Forms.Label();
            this.listaComboBox = new System.Windows.Forms.ComboBox();
            this.labelEscolher = new System.Windows.Forms.Label();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.escolherComboBox = new System.Windows.Forms.ComboBox();
            this.buttonVisualizar = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonEntrada = new System.Windows.Forms.Button();
            this.buttonPedido = new System.Windows.Forms.Button();
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
            pictureBoxFechar.Location = new System.Drawing.Point(328, 4);
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
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.labelCabecalho);
            this.panelSuperior.Controls.Add(this.pictureBox2);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(346, 30);
            this.panelSuperior.TabIndex = 25;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // labelCabecalho
            // 
            this.labelCabecalho.AutoSize = true;
            this.labelCabecalho.BackColor = System.Drawing.Color.Transparent;
            this.labelCabecalho.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCabecalho.ForeColor = System.Drawing.Color.White;
            this.labelCabecalho.Location = new System.Drawing.Point(26, 7);
            this.labelCabecalho.Name = "labelCabecalho";
            this.labelCabecalho.Size = new System.Drawing.Size(40, 16);
            this.labelCabecalho.TabIndex = 8;
            this.labelCabecalho.Text = "Listas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(340, 3);
            this.panel4.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 185);
            this.panel3.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(343, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 185);
            this.panel2.TabIndex = 28;
            // 
            // labelLista
            // 
            this.labelLista.AutoSize = true;
            this.labelLista.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLista.Location = new System.Drawing.Point(24, 96);
            this.labelLista.Name = "labelLista";
            this.labelLista.Size = new System.Drawing.Size(112, 17);
            this.labelLista.TabIndex = 43;
            this.labelLista.Text = "Informe a Lista:";
            this.labelLista.Visible = false;
            // 
            // listaComboBox
            // 
            this.listaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listaComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaComboBox.FormattingEnabled = true;
            this.listaComboBox.Items.AddRange(new object[] {
            "LISTA PARA CONFERÊNCIA",
            "LISTA DE REAJUSTES",
            "LISTA DE PRODUTOS ZERADOS",
            "CÓDIGO DE BARRAS - AUTOMÁTICO",
            "PREÇOS - AUTOMÁTICO",
            "PLACAS - AUTOMÁTICO",
            "LISTA DE NOVOS PRODUTOS"});
            this.listaComboBox.Location = new System.Drawing.Point(21, 116);
            this.listaComboBox.Name = "listaComboBox";
            this.listaComboBox.Size = new System.Drawing.Size(307, 26);
            this.listaComboBox.TabIndex = 42;
            this.listaComboBox.Visible = false;
            // 
            // labelEscolher
            // 
            this.labelEscolher.AutoSize = true;
            this.labelEscolher.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscolher.Location = new System.Drawing.Point(24, 42);
            this.labelEscolher.Name = "labelEscolher";
            this.labelEscolher.Size = new System.Drawing.Size(144, 17);
            this.labelEscolher.TabIndex = 41;
            this.labelEscolher.Text = "Selecione a Entrada:";
            this.labelEscolher.Visible = false;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.BackColor = System.Drawing.Color.Red;
            this.buttonImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.BackgroundImage")));
            this.buttonImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImprimir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonImprimir.Location = new System.Drawing.Point(193, 162);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(122, 34);
            this.buttonImprimir.TabIndex = 40;
            this.buttonImprimir.TabStop = false;
            this.buttonImprimir.Text = "Imprmir";
            this.buttonImprimir.UseVisualStyleBackColor = false;
            this.buttonImprimir.Visible = false;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // escolherComboBox
            // 
            this.escolherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.escolherComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.escolherComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escolherComboBox.FormattingEnabled = true;
            this.escolherComboBox.Location = new System.Drawing.Point(21, 62);
            this.escolherComboBox.Name = "escolherComboBox";
            this.escolherComboBox.Size = new System.Drawing.Size(307, 26);
            this.escolherComboBox.TabIndex = 39;
            this.escolherComboBox.Visible = false;
            // 
            // buttonVisualizar
            // 
            this.buttonVisualizar.BackColor = System.Drawing.Color.Red;
            this.buttonVisualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonVisualizar.BackgroundImage")));
            this.buttonVisualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVisualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVisualizar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVisualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVisualizar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonVisualizar.Location = new System.Drawing.Point(33, 162);
            this.buttonVisualizar.Name = "buttonVisualizar";
            this.buttonVisualizar.Size = new System.Drawing.Size(122, 34);
            this.buttonVisualizar.TabIndex = 44;
            this.buttonVisualizar.TabStop = false;
            this.buttonVisualizar.Text = "Visualizar";
            this.buttonVisualizar.UseVisualStyleBackColor = false;
            this.buttonVisualizar.Visible = false;
            this.buttonVisualizar.Click += new System.EventHandler(this.buttonVisualizar_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(44, 40);
            this.labelInfo.MaximumSize = new System.Drawing.Size(300, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(254, 38);
            this.labelInfo.TabIndex = 45;
            this.labelInfo.Text = "Informe de onde as informações serão extraídas:";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEntrada
            // 
            this.buttonEntrada.BackColor = System.Drawing.Color.Red;
            this.buttonEntrada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEntrada.BackgroundImage")));
            this.buttonEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEntrada.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntrada.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEntrada.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonEntrada.Location = new System.Drawing.Point(33, 86);
            this.buttonEntrada.Name = "buttonEntrada";
            this.buttonEntrada.Size = new System.Drawing.Size(122, 34);
            this.buttonEntrada.TabIndex = 47;
            this.buttonEntrada.TabStop = false;
            this.buttonEntrada.Text = "Entrada";
            this.buttonEntrada.UseVisualStyleBackColor = false;
            this.buttonEntrada.Click += new System.EventHandler(this.buttonEntrada_Click);
            // 
            // buttonPedido
            // 
            this.buttonPedido.BackColor = System.Drawing.Color.Red;
            this.buttonPedido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPedido.BackgroundImage")));
            this.buttonPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPedido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPedido.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPedido.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonPedido.Location = new System.Drawing.Point(193, 86);
            this.buttonPedido.Name = "buttonPedido";
            this.buttonPedido.Size = new System.Drawing.Size(122, 34);
            this.buttonPedido.TabIndex = 46;
            this.buttonPedido.TabStop = false;
            this.buttonPedido.Text = "Pedido";
            this.buttonPedido.UseVisualStyleBackColor = false;
            this.buttonPedido.Click += new System.EventHandler(this.buttonPedido_Click);
            // 
            // formProdutosListas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 215);
            this.Controls.Add(this.buttonEntrada);
            this.Controls.Add(this.buttonPedido);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonVisualizar);
            this.Controls.Add(this.labelLista);
            this.Controls.Add(this.listaComboBox);
            this.Controls.Add(this.labelEscolher);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.escolherComboBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProdutosListas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProdutosListas";
            this.Load += new System.EventHandler(this.formProdutosListas_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelCabecalho;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelLista;
        private System.Windows.Forms.ComboBox listaComboBox;
        private System.Windows.Forms.Label labelEscolher;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.ComboBox escolherComboBox;
        private System.Windows.Forms.Button buttonVisualizar;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonEntrada;
        private System.Windows.Forms.Button buttonPedido;
    }
}