
namespace MarbaSoftware
{
    partial class formProdutosEditarAcabamentosAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosEditarAcabamentosAdicionar));
            this.salvarButton = new System.Windows.Forms.Button();
            this.comboBoxAcabamento = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.salvarButton.Location = new System.Drawing.Point(85, 55);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(186, 32);
            this.salvarButton.TabIndex = 448;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // comboBoxAcabamento
            // 
            this.comboBoxAcabamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxAcabamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAcabamento.BackColor = System.Drawing.Color.White;
            this.comboBoxAcabamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAcabamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAcabamento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAcabamento.ForeColor = System.Drawing.Color.Black;
            this.comboBoxAcabamento.FormattingEnabled = true;
            this.comboBoxAcabamento.Location = new System.Drawing.Point(12, 15);
            this.comboBoxAcabamento.Name = "comboBoxAcabamento";
            this.comboBoxAcabamento.Size = new System.Drawing.Size(333, 27);
            this.comboBoxAcabamento.TabIndex = 447;
            // 
            // formProdutosEditarAcabamentosAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 102);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.comboBoxAcabamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosEditarAcabamentosAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar acabamento";
            this.Load += new System.EventHandler(this.formProdutosEditarAcabamentosAdicionar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button salvarButton;
        public System.Windows.Forms.ComboBox comboBoxAcabamento;
    }
}