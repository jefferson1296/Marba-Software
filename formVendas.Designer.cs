
namespace MarbaSoftware
{
    partial class formVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendas));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAtual1 = new System.Windows.Forms.Button();
            this.buttonAnteriores1 = new System.Windows.Forms.Button();
            this.buttonPDV1 = new System.Windows.Forms.Button();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.comboBoxReparticao = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelOperador = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.panelSuperior.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.tableLayoutPanel1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1301, 83);
            this.panelSuperior.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAtual1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAnteriores1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPDV1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1299, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAtual1
            // 
            this.buttonAtual1.BackColor = System.Drawing.Color.White;
            this.buttonAtual1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtual1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtual1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAtual1.FlatAppearance.BorderSize = 0;
            this.buttonAtual1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAtual1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonAtual1.Image = ((System.Drawing.Image)(resources.GetObject("buttonAtual1.Image")));
            this.buttonAtual1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtual1.Location = new System.Drawing.Point(435, 3);
            this.buttonAtual1.Name = "buttonAtual1";
            this.buttonAtual1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAtual1.Size = new System.Drawing.Size(427, 71);
            this.buttonAtual1.TabIndex = 4;
            this.buttonAtual1.Text = "Caixa Atual";
            this.buttonAtual1.UseVisualStyleBackColor = false;
            this.buttonAtual1.Click += new System.EventHandler(this.buttonAtual1_Click);
            // 
            // buttonAnteriores1
            // 
            this.buttonAnteriores1.BackColor = System.Drawing.Color.White;
            this.buttonAnteriores1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAnteriores1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAnteriores1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAnteriores1.FlatAppearance.BorderSize = 0;
            this.buttonAnteriores1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnteriores1.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonAnteriores1.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnteriores1.Image")));
            this.buttonAnteriores1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAnteriores1.Location = new System.Drawing.Point(868, 3);
            this.buttonAnteriores1.Name = "buttonAnteriores1";
            this.buttonAnteriores1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAnteriores1.Size = new System.Drawing.Size(428, 71);
            this.buttonAnteriores1.TabIndex = 5;
            this.buttonAnteriores1.Text = "Caixas Anteriores";
            this.buttonAnteriores1.UseVisualStyleBackColor = false;
            this.buttonAnteriores1.Click += new System.EventHandler(this.buttonAnteriores1_Click);
            // 
            // buttonPDV1
            // 
            this.buttonPDV1.BackColor = System.Drawing.Color.Red;
            this.buttonPDV1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPDV1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPDV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPDV1.FlatAppearance.BorderSize = 0;
            this.buttonPDV1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPDV1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonPDV1.Image = ((System.Drawing.Image)(resources.GetObject("buttonPDV1.Image")));
            this.buttonPDV1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPDV1.Location = new System.Drawing.Point(3, 3);
            this.buttonPDV1.Name = "buttonPDV1";
            this.buttonPDV1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonPDV1.Size = new System.Drawing.Size(426, 71);
            this.buttonPDV1.TabIndex = 3;
            this.buttonPDV1.Text = "PDV";
            this.buttonPDV1.UseVisualStyleBackColor = false;
            this.buttonPDV1.Click += new System.EventHandler(this.buttonPDV1_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.Red;
            this.panelInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInferior.Controls.Add(this.comboBoxReparticao);
            this.panelInferior.Controls.Add(this.pictureBox2);
            this.panelInferior.Controls.Add(this.labelOperador);
            this.panelInferior.Controls.Add(this.pictureBox1);
            this.panelInferior.Controls.Add(this.label1);
            this.panelInferior.Controls.Add(this.pictureBox3);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 711);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1301, 27);
            this.panelInferior.TabIndex = 1;
            // 
            // comboBoxReparticao
            // 
            this.comboBoxReparticao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReparticao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.comboBoxReparticao.Enabled = false;
            this.comboBoxReparticao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReparticao.ForeColor = System.Drawing.Color.White;
            this.comboBoxReparticao.FormattingEnabled = true;
            this.comboBoxReparticao.Location = new System.Drawing.Point(993, 2);
            this.comboBoxReparticao.Name = "comboBoxReparticao";
            this.comboBoxReparticao.Size = new System.Drawing.Size(274, 21);
            this.comboBoxReparticao.TabIndex = 5;
            this.comboBoxReparticao.SelectedIndexChanged += new System.EventHandler(this.comboBoxReparticao_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1273, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // labelOperador
            // 
            this.labelOperador.AutoSize = true;
            this.labelOperador.BackColor = System.Drawing.Color.Transparent;
            this.labelOperador.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperador.Location = new System.Drawing.Point(138, 6);
            this.labelOperador.Name = "labelOperador";
            this.labelOperador.Size = new System.Drawing.Size(61, 15);
            this.labelOperador.TabIndex = 2;
            this.labelOperador.Text = "USUÁRIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "OPERADOR(A):";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1273, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // panelCentral
            // 
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 83);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1301, 628);
            this.panelCentral.TabIndex = 2;
            // 
            // formVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 738);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "formVendas";
            this.Text = "formVendas";
            this.Load += new System.EventHandler(this.formVendas_Load);
            this.panelSuperior.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label labelOperador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPDV1;
        private System.Windows.Forms.Button buttonAtual1;
        private System.Windows.Forms.Button buttonAnteriores1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxReparticao;
    }
}