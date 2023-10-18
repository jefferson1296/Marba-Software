
namespace MarbaSoftware
{
    partial class formGestaoFerramentasGerarCodigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoFerramentasGerarCodigo));
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.carregarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(12, 15);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(338, 26);
            this.textBoxCodigo.TabIndex = 94;
            this.textBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // carregarButton
            // 
            this.carregarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.carregarButton.BackColor = System.Drawing.Color.Red;
            this.carregarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("carregarButton.BackgroundImage")));
            this.carregarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carregarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.carregarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carregarButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.carregarButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.carregarButton.Location = new System.Drawing.Point(99, 53);
            this.carregarButton.Name = "carregarButton";
            this.carregarButton.Size = new System.Drawing.Size(162, 34);
            this.carregarButton.TabIndex = 93;
            this.carregarButton.TabStop = false;
            this.carregarButton.Text = "Carregar";
            this.carregarButton.UseVisualStyleBackColor = false;
            this.carregarButton.Click += new System.EventHandler(this.carregarButton_Click);
            // 
            // formGestaoFerramentasGerarCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 98);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.carregarButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoFerramentasGerarCodigo";
            this.Text = "Gerar código";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Button carregarButton;
    }
}