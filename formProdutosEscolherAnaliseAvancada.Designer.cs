
namespace MarbaSoftware
{
    partial class formProdutosEscolherAnaliseAvancada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosEscolherAnaliseAvancada));
            this.label2 = new System.Windows.Forms.Label();
            this.pedidoComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.analiseButton = new System.Windows.Forms.Button();
            this.fornecedorComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 38;
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
            this.pedidoComboBox.TabIndex = 37;
            this.pedidoComboBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Escolha o Fornecedor:";
            // 
            // analiseButton
            // 
            this.analiseButton.BackColor = System.Drawing.Color.Red;
            this.analiseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("analiseButton.BackgroundImage")));
            this.analiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analiseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analiseButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analiseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.analiseButton.Image = ((System.Drawing.Image)(resources.GetObject("analiseButton.Image")));
            this.analiseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.analiseButton.Location = new System.Drawing.Point(64, 116);
            this.analiseButton.Name = "analiseButton";
            this.analiseButton.Size = new System.Drawing.Size(181, 36);
            this.analiseButton.TabIndex = 35;
            this.analiseButton.TabStop = false;
            this.analiseButton.Text = "Análise avançada";
            this.analiseButton.UseVisualStyleBackColor = false;
            this.analiseButton.Click += new System.EventHandler(this.analiseButton_Click);
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
            this.fornecedorComboBox.TabIndex = 34;
            this.fornecedorComboBox.TabStop = false;
            this.fornecedorComboBox.SelectedIndexChanged += new System.EventHandler(this.fornecedorComboBox_SelectedIndexChanged);
            // 
            // formProdutosEscolherAnaliseAvancada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pedidoComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.analiseButton);
            this.Controls.Add(this.fornecedorComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProdutosEscolherAnaliseAvancada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProdutosEscolherAnaliseAvancada";
            this.Load += new System.EventHandler(this.formProdutosEscolherAnaliseAvancada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pedidoComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button analiseButton;
        private System.Windows.Forms.ComboBox fornecedorComboBox;
    }
}