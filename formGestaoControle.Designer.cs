
namespace MarbaSoftware
{
    partial class formGestaoControle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoControle));
            this.buttonControle = new System.Windows.Forms.Button();
            this.buttonLocalizacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonControle
            // 
            this.buttonControle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonControle.BackColor = System.Drawing.Color.Red;
            this.buttonControle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonControle.BackgroundImage")));
            this.buttonControle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonControle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonControle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonControle.FlatAppearance.BorderSize = 2;
            this.buttonControle.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonControle.ForeColor = System.Drawing.Color.White;
            this.buttonControle.Image = ((System.Drawing.Image)(resources.GetObject("buttonControle.Image")));
            this.buttonControle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonControle.Location = new System.Drawing.Point(12, 12);
            this.buttonControle.Name = "buttonControle";
            this.buttonControle.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.buttonControle.Size = new System.Drawing.Size(153, 46);
            this.buttonControle.TabIndex = 148;
            this.buttonControle.Text = "Produtos por repartição";
            this.buttonControle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonControle.UseVisualStyleBackColor = false;
            // 
            // buttonLocalizacao
            // 
            this.buttonLocalizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLocalizacao.BackColor = System.Drawing.Color.Red;
            this.buttonLocalizacao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLocalizacao.BackgroundImage")));
            this.buttonLocalizacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLocalizacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLocalizacao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonLocalizacao.FlatAppearance.BorderSize = 2;
            this.buttonLocalizacao.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLocalizacao.ForeColor = System.Drawing.Color.White;
            this.buttonLocalizacao.Image = ((System.Drawing.Image)(resources.GetObject("buttonLocalizacao.Image")));
            this.buttonLocalizacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLocalizacao.Location = new System.Drawing.Point(171, 12);
            this.buttonLocalizacao.Name = "buttonLocalizacao";
            this.buttonLocalizacao.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.buttonLocalizacao.Size = new System.Drawing.Size(153, 46);
            this.buttonLocalizacao.TabIndex = 149;
            this.buttonLocalizacao.Text = "Localização dos produtos";
            this.buttonLocalizacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLocalizacao.UseVisualStyleBackColor = false;
            this.buttonLocalizacao.Click += new System.EventHandler(this.buttonLocalizacao_Click);
            // 
            // formGestaoControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 234);
            this.Controls.Add(this.buttonLocalizacao);
            this.Controls.Add(this.buttonControle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoControle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonControle;
        private System.Windows.Forms.Button buttonLocalizacao;
    }
}