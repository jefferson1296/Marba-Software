
namespace MarbaSoftware
{
    partial class formProdutosLotesAvarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesAvarias));
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.labelAtual = new System.Windows.Forms.Label();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxEstabelecimentos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(265, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 265;
            this.label8.Text = "Destino:";
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDestino.BackColor = System.Drawing.Color.White;
            this.comboBoxDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDestino.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDestino.ForeColor = System.Drawing.Color.Black;
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(336, 56);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(117, 27);
            this.comboBoxDestino.TabIndex = 264;
            // 
            // labelAtual
            // 
            this.labelAtual.AutoSize = true;
            this.labelAtual.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtual.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelAtual.Location = new System.Drawing.Point(225, 95);
            this.labelAtual.Name = "labelAtual";
            this.labelAtual.Size = new System.Drawing.Size(34, 24);
            this.labelAtual.TabIndex = 268;
            this.labelAtual.Text = "/ 0";
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxQuantidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxQuantidade.BackColor = System.Drawing.Color.White;
            this.textBoxQuantidade.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.ForeColor = System.Drawing.Color.Black;
            this.textBoxQuantidade.Location = new System.Drawing.Point(117, 92);
            this.textBoxQuantidade.MaxLength = 150;
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(93, 32);
            this.textBoxQuantidade.TabIndex = 266;
            this.textBoxQuantidade.Text = "1";
            this.textBoxQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 267;
            this.label1.Text = "Quantidade:";
            // 
            // textBoxProduto
            // 
            this.textBoxProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProduto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxProduto.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxProduto.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProduto.Location = new System.Drawing.Point(8, 12);
            this.textBoxProduto.MaxLength = 150;
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.ReadOnly = true;
            this.textBoxProduto.Size = new System.Drawing.Size(445, 26);
            this.textBoxProduto.TabIndex = 269;
            this.textBoxProduto.TabStop = false;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(128, 140);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(197, 32);
            this.buttonSalvar.TabIndex = 270;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // comboBoxEstabelecimentos
            // 
            this.comboBoxEstabelecimentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstabelecimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstabelecimentos.FormattingEnabled = true;
            this.comboBoxEstabelecimentos.Location = new System.Drawing.Point(8, 58);
            this.comboBoxEstabelecimentos.Name = "comboBoxEstabelecimentos";
            this.comboBoxEstabelecimentos.Size = new System.Drawing.Size(251, 21);
            this.comboBoxEstabelecimentos.TabIndex = 271;
            this.comboBoxEstabelecimentos.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstabelecimentos_SelectedIndexChanged);
            // 
            // formProdutosLotesAvarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 187);
            this.Controls.Add(this.comboBoxEstabelecimentos);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.textBoxProduto);
            this.Controls.Add(this.labelAtual);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesAvarias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avarias";
            this.Load += new System.EventHandler(this.formProdutosLotesAvarias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboBoxDestino;
        private System.Windows.Forms.Label labelAtual;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxEstabelecimentos;
    }
}