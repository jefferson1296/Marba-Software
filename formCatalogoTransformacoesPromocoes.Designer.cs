
namespace MarbaSoftware
{
    partial class formCatalogoTransformacoesPromocoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogoTransformacoesPromocoes));
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxVenda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPromocao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPercentual = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMargem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCusto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(63, 148);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(162, 34);
            this.buttonSalvar.TabIndex = 91;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxProduto
            // 
            this.textBoxProduto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProduto.Location = new System.Drawing.Point(67, 22);
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.ReadOnly = true;
            this.textBoxProduto.Size = new System.Drawing.Size(395, 26);
            this.textBoxProduto.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 93;
            this.label1.Text = "Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 95;
            this.label2.Text = "Venda:";
            // 
            // textBoxVenda
            // 
            this.textBoxVenda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVenda.Location = new System.Drawing.Point(220, 59);
            this.textBoxVenda.Name = "textBoxVenda";
            this.textBoxVenda.ReadOnly = true;
            this.textBoxVenda.Size = new System.Drawing.Size(90, 26);
            this.textBoxVenda.TabIndex = 94;
            this.textBoxVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 97;
            this.label3.Text = "Promoção:";
            // 
            // textBoxPromocao
            // 
            this.textBoxPromocao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPromocao.Location = new System.Drawing.Point(88, 100);
            this.textBoxPromocao.Name = "textBoxPromocao";
            this.textBoxPromocao.Size = new System.Drawing.Size(102, 26);
            this.textBoxPromocao.TabIndex = 96;
            this.textBoxPromocao.Text = "R$,00";
            this.textBoxPromocao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPromocao.Enter += new System.EventHandler(this.textBoxPromocao_Enter);
            this.textBoxPromocao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPromocao_KeyPress);
            this.textBoxPromocao.Leave += new System.EventHandler(this.textBoxPromocao_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 99;
            this.label4.Text = "Percentual:";
            // 
            // textBoxPercentual
            // 
            this.textBoxPercentual.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPercentual.Location = new System.Drawing.Point(295, 100);
            this.textBoxPercentual.Name = "textBoxPercentual";
            this.textBoxPercentual.Size = new System.Drawing.Size(102, 26);
            this.textBoxPercentual.TabIndex = 98;
            this.textBoxPercentual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPercentual.Enter += new System.EventHandler(this.textBoxPercentual_Enter);
            this.textBoxPercentual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPercentual_KeyPress);
            this.textBoxPercentual.Leave += new System.EventHandler(this.textBoxPercentual_Leave);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancelar.BackColor = System.Drawing.Color.Red;
            this.buttonCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.BackgroundImage")));
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(248, 148);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(162, 34);
            this.buttonCancelar.TabIndex = 100;
            this.buttonCancelar.TabStop = false;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(324, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 104;
            this.label5.Text = "Margem:";
            // 
            // textBoxMargem
            // 
            this.textBoxMargem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMargem.Location = new System.Drawing.Point(390, 59);
            this.textBoxMargem.Name = "textBoxMargem";
            this.textBoxMargem.ReadOnly = true;
            this.textBoxMargem.Size = new System.Drawing.Size(72, 26);
            this.textBoxMargem.TabIndex = 103;
            this.textBoxMargem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 102;
            this.label6.Text = "Custo:";
            // 
            // textBoxCusto
            // 
            this.textBoxCusto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCusto.Location = new System.Drawing.Point(67, 59);
            this.textBoxCusto.Name = "textBoxCusto";
            this.textBoxCusto.ReadOnly = true;
            this.textBoxCusto.Size = new System.Drawing.Size(90, 26);
            this.textBoxCusto.TabIndex = 101;
            this.textBoxCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // formCatalogoTransformacoesPromocoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 198);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMargem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCusto);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPercentual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPromocao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProduto);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCatalogoTransformacoesPromocoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoção";
            this.Load += new System.EventHandler(this.formCatalogoTransformacoesPromocoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxVenda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPromocao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPercentual;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMargem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCusto;
    }
}