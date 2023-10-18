
namespace MarbaSoftware
{
    partial class formProdutosEditarPecasAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosEditarPecasAdicionar));
            this.comboBoxPeca = new System.Windows.Forms.ComboBox();
            this.salvarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPeca
            // 
            this.comboBoxPeca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPeca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPeca.BackColor = System.Drawing.Color.White;
            this.comboBoxPeca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPeca.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPeca.ForeColor = System.Drawing.Color.Black;
            this.comboBoxPeca.FormattingEnabled = true;
            this.comboBoxPeca.Location = new System.Drawing.Point(12, 16);
            this.comboBoxPeca.Name = "comboBoxPeca";
            this.comboBoxPeca.Size = new System.Drawing.Size(333, 27);
            this.comboBoxPeca.TabIndex = 253;
            // 
            // salvarButton
            // 
            this.salvarButton.BackColor = System.Drawing.Color.White;
            this.salvarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvarButton.BackgroundImage")));
            this.salvarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salvarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salvarButton.ForeColor = System.Drawing.Color.White;
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarButton.Location = new System.Drawing.Point(85, 56);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(186, 32);
            this.salvarButton.TabIndex = 446;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // formProdutosEditarPecasAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 102);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.comboBoxPeca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosEditarPecasAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar peça";
            this.Load += new System.EventHandler(this.formProdutosEditarPecasAdicionar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxPeca;
        private System.Windows.Forms.Button salvarButton;
    }
}