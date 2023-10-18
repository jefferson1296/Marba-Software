
namespace MarbaSoftware
{
    partial class formTelaInicialPrincipalAtividades
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
            this.panelColaboradores = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelColaboradores
            // 
            this.panelColaboradores.AutoScroll = true;
            this.panelColaboradores.BackColor = System.Drawing.Color.White;
            this.panelColaboradores.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelColaboradores.Location = new System.Drawing.Point(0, 0);
            this.panelColaboradores.Name = "panelColaboradores";
            this.panelColaboradores.Size = new System.Drawing.Size(972, 131);
            this.panelColaboradores.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 521);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 100);
            this.panel2.TabIndex = 1;
            // 
            // formTelaInicialPrincipalAtividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 621);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelColaboradores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formTelaInicialPrincipalAtividades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atividades";
            this.Load += new System.EventHandler(this.formTelaInicialPrincipalAtividades_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelColaboradores;
        private System.Windows.Forms.Panel panel2;
    }
}