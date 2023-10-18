
namespace MarbaSoftware
{
    partial class formProdutosEntradaReajustar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosEntradaReajustar));
            this.produtoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.baseTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.custoAntigoTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.custoNovoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AliquotaICMSTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AliquotaIPITextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonReajustar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            pictureBoxFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).BeginInit();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFechar
            // 
            pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            pictureBoxFechar.Location = new System.Drawing.Point(486, 5);
            pictureBoxFechar.Name = "pictureBoxFechar";
            pictureBoxFechar.Size = new System.Drawing.Size(15, 15);
            pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxFechar.TabIndex = 17;
            pictureBoxFechar.TabStop = false;
            pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // produtoTextBox
            // 
            this.produtoTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.produtoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.produtoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.produtoTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.produtoTextBox.ForeColor = System.Drawing.Color.Black;
            this.produtoTextBox.Location = new System.Drawing.Point(12, 55);
            this.produtoTextBox.Name = "produtoTextBox";
            this.produtoTextBox.ReadOnly = true;
            this.produtoTextBox.Size = new System.Drawing.Size(480, 26);
            this.produtoTextBox.TabIndex = 280;
            this.produtoTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 281;
            this.label2.Text = "Nome do Produto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(9, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 16);
            this.label12.TabIndex = 322;
            this.label12.Text = "IPI:";
            // 
            // baseTextBox
            // 
            this.baseTextBox.BackColor = System.Drawing.Color.White;
            this.baseTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseTextBox.ForeColor = System.Drawing.Color.Black;
            this.baseTextBox.Location = new System.Drawing.Point(99, 91);
            this.baseTextBox.Name = "baseTextBox";
            this.baseTextBox.Size = new System.Drawing.Size(100, 26);
            this.baseTextBox.TabIndex = 1;
            this.baseTextBox.TabStop = false;
            this.baseTextBox.Text = "R$0,00";
            this.baseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseTextBox.Enter += new System.EventHandler(this.baseTextBox_Enter);
            this.baseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baseTextBox_KeyPress);
            this.baseTextBox.Leave += new System.EventHandler(this.baseTextBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 321;
            this.label7.Text = "Base (Custo):";
            // 
            // custoAntigoTextBox
            // 
            this.custoAntigoTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.custoAntigoTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.custoAntigoTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.custoAntigoTextBox.Location = new System.Drawing.Point(138, 161);
            this.custoAntigoTextBox.Name = "custoAntigoTextBox";
            this.custoAntigoTextBox.ReadOnly = true;
            this.custoAntigoTextBox.Size = new System.Drawing.Size(100, 26);
            this.custoAntigoTextBox.TabIndex = 318;
            this.custoAntigoTextBox.TabStop = false;
            this.custoAntigoTextBox.Text = "R$0,00";
            this.custoAntigoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 320;
            this.label9.Text = "Custo Antigo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(280, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 319;
            this.label5.Text = "ICMS:";
            // 
            // custoNovoTextBox
            // 
            this.custoNovoTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.custoNovoTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.custoNovoTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.custoNovoTextBox.Location = new System.Drawing.Point(392, 161);
            this.custoNovoTextBox.Name = "custoNovoTextBox";
            this.custoNovoTextBox.ReadOnly = true;
            this.custoNovoTextBox.Size = new System.Drawing.Size(100, 26);
            this.custoNovoTextBox.TabIndex = 323;
            this.custoNovoTextBox.TabStop = false;
            this.custoNovoTextBox.Text = "R$0,00";
            this.custoNovoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(280, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 324;
            this.label1.Text = "Custo Novo:";
            // 
            // AliquotaICMSTextBox
            // 
            this.AliquotaICMSTextBox.BackColor = System.Drawing.Color.White;
            this.AliquotaICMSTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AliquotaICMSTextBox.ForeColor = System.Drawing.Color.Black;
            this.AliquotaICMSTextBox.Location = new System.Drawing.Point(424, 91);
            this.AliquotaICMSTextBox.Name = "AliquotaICMSTextBox";
            this.AliquotaICMSTextBox.Size = new System.Drawing.Size(68, 26);
            this.AliquotaICMSTextBox.TabIndex = 3;
            this.AliquotaICMSTextBox.TabStop = false;
            this.AliquotaICMSTextBox.Text = "0,00%";
            this.AliquotaICMSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AliquotaICMSTextBox.Enter += new System.EventHandler(this.AliquotaICMSTextBox_Enter);
            this.AliquotaICMSTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AliquotaICMSTextBox_KeyPress);
            this.AliquotaICMSTextBox.Leave += new System.EventHandler(this.AliquotaICMSTextBox_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(205, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 16);
            this.label13.TabIndex = 325;
            this.label13.Text = "Alíq. IPI:";
            // 
            // AliquotaIPITextBox
            // 
            this.AliquotaIPITextBox.BackColor = System.Drawing.Color.White;
            this.AliquotaIPITextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AliquotaIPITextBox.ForeColor = System.Drawing.Color.Black;
            this.AliquotaIPITextBox.Location = new System.Drawing.Point(265, 91);
            this.AliquotaIPITextBox.Name = "AliquotaIPITextBox";
            this.AliquotaIPITextBox.Size = new System.Drawing.Size(74, 26);
            this.AliquotaIPITextBox.TabIndex = 2;
            this.AliquotaIPITextBox.TabStop = false;
            this.AliquotaIPITextBox.Text = "0,00%";
            this.AliquotaIPITextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AliquotaIPITextBox.Enter += new System.EventHandler(this.AliquotaIPITextBox_Enter);
            this.AliquotaIPITextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AliquotaIPITextBox_KeyPress);
            this.AliquotaIPITextBox.Leave += new System.EventHandler(this.AliquotaIPITextBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(345, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 328;
            this.label11.Text = "Alíq. ICMS:";
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.icmsTextBox.Enabled = false;
            this.icmsTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icmsTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.icmsTextBox.Location = new System.Drawing.Point(400, 126);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.ReadOnly = true;
            this.icmsTextBox.Size = new System.Drawing.Size(92, 26);
            this.icmsTextBox.TabIndex = 330;
            this.icmsTextBox.TabStop = false;
            this.icmsTextBox.Text = "R$0,00";
            this.icmsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ipiTextBox.Enabled = false;
            this.ipiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipiTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ipiTextBox.Location = new System.Drawing.Point(138, 126);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.ReadOnly = true;
            this.ipiTextBox.Size = new System.Drawing.Size(100, 26);
            this.ipiTextBox.TabIndex = 329;
            this.ipiTextBox.TabStop = false;
            this.ipiTextBox.Text = "R$0,00";
            this.ipiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.pictureBox12);
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.label4);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(504, 28);
            this.panelSuperior.TabIndex = 335;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(8, 6);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(16, 16);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 2;
            this.pictureBox12.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(30, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Reajustar";
            // 
            // buttonReajustar
            // 
            this.buttonReajustar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReajustar.BackgroundImage")));
            this.buttonReajustar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReajustar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReajustar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonReajustar.FlatAppearance.BorderSize = 2;
            this.buttonReajustar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReajustar.ForeColor = System.Drawing.Color.White;
            this.buttonReajustar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReajustar.Location = new System.Drawing.Point(169, 200);
            this.buttonReajustar.Name = "buttonReajustar";
            this.buttonReajustar.Size = new System.Drawing.Size(166, 32);
            this.buttonReajustar.TabIndex = 336;
            this.buttonReajustar.Text = "Reajustar";
            this.buttonReajustar.UseVisualStyleBackColor = true;
            this.buttonReajustar.Click += new System.EventHandler(this.buttonReajustar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 246);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(498, 3);
            this.panel4.TabIndex = 337;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 221);
            this.panel3.TabIndex = 338;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(501, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(3, 221);
            this.panel5.TabIndex = 339;
            // 
            // formProdutosEntradaReajustar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 249);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.buttonReajustar);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.icmsTextBox);
            this.Controls.Add(this.ipiTextBox);
            this.Controls.Add(this.AliquotaICMSTextBox);
            this.Controls.Add(this.AliquotaIPITextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.custoNovoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.baseTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.custoAntigoTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.produtoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProdutosEntradaReajustar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProdutosEntradaReajustar";
            this.Load += new System.EventHandler(this.formProdutosEntradaReajustar_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox produtoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox baseTextBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox custoAntigoTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox custoNovoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AliquotaICMSTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox AliquotaIPITextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonReajustar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
    }
}