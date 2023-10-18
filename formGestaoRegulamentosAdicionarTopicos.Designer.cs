
namespace MarbaSoftware
{
    partial class formGestaoRegulamentosAdicionarTopicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoRegulamentosAdicionarTopicos));
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxDetalhes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTopico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonSalvar.FlatAppearance.BorderSize = 2;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(121, 215);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(170, 30);
            this.buttonSalvar.TabIndex = 494;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxDetalhes
            // 
            this.textBoxDetalhes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDetalhes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDetalhes.Location = new System.Drawing.Point(16, 82);
            this.textBoxDetalhes.Multiline = true;
            this.textBoxDetalhes.Name = "textBoxDetalhes";
            this.textBoxDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDetalhes.Size = new System.Drawing.Size(413, 116);
            this.textBoxDetalhes.TabIndex = 493;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 492;
            this.label4.Text = "Detalhes:";
            // 
            // textBoxTopico
            // 
            this.textBoxTopico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTopico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTopico.Location = new System.Drawing.Point(110, 20);
            this.textBoxTopico.Name = "textBoxTopico";
            this.textBoxTopico.Size = new System.Drawing.Size(319, 26);
            this.textBoxTopico.TabIndex = 491;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 490;
            this.label3.Text = "Tópico:";
            // 
            // formGestaoRegulamentosAdicionarTopicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 257);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.textBoxDetalhes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTopico);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoRegulamentosAdicionarTopicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tópico";
            this.Load += new System.EventHandler(this.formGestaoRegulamentosAdicionarTopicos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.TextBox textBoxDetalhes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTopico;
        private System.Windows.Forms.Label label3;
    }
}