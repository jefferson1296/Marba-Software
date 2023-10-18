
namespace MarbaSoftware
{
    partial class formProdutosLotesExtravios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesExtravios));
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.labelAtual = new System.Windows.Forms.Label();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.buttonSalvar.Location = new System.Drawing.Point(129, 100);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(197, 32);
            this.buttonSalvar.TabIndex = 277;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxProduto
            // 
            this.textBoxProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProduto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxProduto.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxProduto.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProduto.Location = new System.Drawing.Point(9, 14);
            this.textBoxProduto.MaxLength = 150;
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.ReadOnly = true;
            this.textBoxProduto.Size = new System.Drawing.Size(445, 26);
            this.textBoxProduto.TabIndex = 276;
            this.textBoxProduto.TabStop = false;
            // 
            // labelAtual
            // 
            this.labelAtual.AutoSize = true;
            this.labelAtual.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtual.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelAtual.Location = new System.Drawing.Point(226, 55);
            this.labelAtual.Name = "labelAtual";
            this.labelAtual.Size = new System.Drawing.Size(34, 24);
            this.labelAtual.TabIndex = 275;
            this.labelAtual.Text = "/ 0";
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxQuantidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxQuantidade.BackColor = System.Drawing.Color.White;
            this.textBoxQuantidade.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.ForeColor = System.Drawing.Color.Black;
            this.textBoxQuantidade.Location = new System.Drawing.Point(118, 52);
            this.textBoxQuantidade.MaxLength = 150;
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(93, 32);
            this.textBoxQuantidade.TabIndex = 273;
            this.textBoxQuantidade.Text = "1";
            this.textBoxQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 274;
            this.label1.Text = "Quantidade:";
            // 
            // formProdutosLotesExtravios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 146);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.textBoxProduto);
            this.Controls.Add(this.labelAtual);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesExtravios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProdutosLotesExtravios";
            this.Load += new System.EventHandler(this.formProdutosLotesExtravios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Label labelAtual;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Label label1;
    }
}