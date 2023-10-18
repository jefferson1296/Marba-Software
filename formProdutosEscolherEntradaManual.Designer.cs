
namespace MarbaSoftware
{
    partial class formProdutosEscolherEntradaManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosEscolherEntradaManual));
            this.fornecedorComboBox = new System.Windows.Forms.ComboBox();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pedidoComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fornecedorComboBox
            // 
            this.fornecedorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fornecedorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fornecedorComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fornecedorComboBox.FormattingEnabled = true;
            this.fornecedorComboBox.Location = new System.Drawing.Point(14, 25);
            this.fornecedorComboBox.Name = "fornecedorComboBox";
            this.fornecedorComboBox.Size = new System.Drawing.Size(282, 26);
            this.fornecedorComboBox.TabIndex = 0;
            this.fornecedorComboBox.TabStop = false;
            this.fornecedorComboBox.SelectedIndexChanged += new System.EventHandler(this.fornecedorComboBox_SelectedIndexChanged);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.BackColor = System.Drawing.Color.Red;
            this.buttonFinalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFinalizar.BackgroundImage")));
            this.buttonFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinalizar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFinalizar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonFinalizar.Location = new System.Drawing.Point(64, 116);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(181, 34);
            this.buttonFinalizar.TabIndex = 30;
            this.buttonFinalizar.TabStop = false;
            this.buttonFinalizar.Text = "Dar Entrada";
            this.buttonFinalizar.UseVisualStyleBackColor = false;
            this.buttonFinalizar.Click += new System.EventHandler(this.buttonFinalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Escolha o Fornecedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Informe o Pedido:";
            // 
            // pedidoComboBox
            // 
            this.pedidoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pedidoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pedidoComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidoComboBox.FormattingEnabled = true;
            this.pedidoComboBox.Location = new System.Drawing.Point(14, 79);
            this.pedidoComboBox.Name = "pedidoComboBox";
            this.pedidoComboBox.Size = new System.Drawing.Size(282, 26);
            this.pedidoComboBox.TabIndex = 32;
            this.pedidoComboBox.TabStop = false;
            // 
            // formProdutosEscolherEntradaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pedidoComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.fornecedorComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProdutosEscolherEntradaManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProdutosEscolherEntradaManual";
            this.Load += new System.EventHandler(this.formProdutosEscolherEntradaManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fornecedorComboBox;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pedidoComboBox;
    }
}