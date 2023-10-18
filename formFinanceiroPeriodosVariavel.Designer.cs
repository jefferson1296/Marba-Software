
namespace MarbaSoftware
{
    partial class formFinanceiroPeriodosVariavel
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
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.textBoxUnitario = new System.Windows.Forms.TextBox();
            this.textBoxProdutos = new System.Windows.Forms.TextBox();
            this.textBoxMensal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(20, 12);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(230, 26);
            this.comboBoxMes.TabIndex = 5;
            this.comboBoxMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxMes_SelectedIndexChanged);
            // 
            // textBoxUnitario
            // 
            this.textBoxUnitario.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxUnitario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUnitario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitario.Location = new System.Drawing.Point(144, 107);
            this.textBoxUnitario.Name = "textBoxUnitario";
            this.textBoxUnitario.ReadOnly = true;
            this.textBoxUnitario.Size = new System.Drawing.Size(106, 19);
            this.textBoxUnitario.TabIndex = 89;
            this.textBoxUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxProdutos
            // 
            this.textBoxProdutos.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProdutos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProdutos.Location = new System.Drawing.Point(144, 80);
            this.textBoxProdutos.Name = "textBoxProdutos";
            this.textBoxProdutos.ReadOnly = true;
            this.textBoxProdutos.Size = new System.Drawing.Size(106, 19);
            this.textBoxProdutos.TabIndex = 88;
            this.textBoxProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMensal
            // 
            this.textBoxMensal.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxMensal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMensal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMensal.Location = new System.Drawing.Point(144, 53);
            this.textBoxMensal.Name = "textBoxMensal";
            this.textBoxMensal.ReadOnly = true;
            this.textBoxMensal.Size = new System.Drawing.Size(106, 19);
            this.textBoxMensal.TabIndex = 87;
            this.textBoxMensal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(13, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 86;
            this.label7.Text = "Variável unitário:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(13, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 16);
            this.label6.TabIndex = 85;
            this.label6.Text = "Produtos vendidos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 84;
            this.label5.Text = "Variável mensal:";
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.BackColor = System.Drawing.Color.Red;
            this.buttonAplicar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAplicar.ForeColor = System.Drawing.Color.White;
            this.buttonAplicar.Location = new System.Drawing.Point(49, 139);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(159, 32);
            this.buttonAplicar.TabIndex = 90;
            this.buttonAplicar.Text = "Aplicar";
            this.buttonAplicar.UseVisualStyleBackColor = false;
            this.buttonAplicar.Click += new System.EventHandler(this.buttonAplicar_Click);
            // 
            // formFinanceiroPeriodosVariavel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 184);
            this.Controls.Add(this.buttonAplicar);
            this.Controls.Add(this.textBoxUnitario);
            this.Controls.Add(this.textBoxProdutos);
            this.Controls.Add(this.textBoxMensal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formFinanceiroPeriodosVariavel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redefinir custo variável";
            this.Load += new System.EventHandler(this.formFinanceiroPeriodosVariavel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.TextBox textBoxUnitario;
        private System.Windows.Forms.TextBox textBoxProdutos;
        private System.Windows.Forms.TextBox textBoxMensal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAplicar;
    }
}