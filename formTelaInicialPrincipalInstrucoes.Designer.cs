
namespace MarbaSoftware
{
    partial class formTelaInicialPrincipalInstrucoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialPrincipalInstrucoes));
            this.buttonCursos = new System.Windows.Forms.Button();
            this.buttonAtividades = new System.Windows.Forms.Button();
            this.buttonRegulamento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCursos
            // 
            this.buttonCursos.BackColor = System.Drawing.Color.Red;
            this.buttonCursos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCursos.BackgroundImage")));
            this.buttonCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCursos.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonCursos.FlatAppearance.BorderSize = 5;
            this.buttonCursos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCursos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonCursos.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCursos.ForeColor = System.Drawing.Color.White;
            this.buttonCursos.Location = new System.Drawing.Point(319, 12);
            this.buttonCursos.Name = "buttonCursos";
            this.buttonCursos.Size = new System.Drawing.Size(131, 40);
            this.buttonCursos.TabIndex = 63;
            this.buttonCursos.Text = "Cursos";
            this.buttonCursos.UseVisualStyleBackColor = false;
            this.buttonCursos.Click += new System.EventHandler(this.buttonCursos_Click);
            // 
            // buttonAtividades
            // 
            this.buttonAtividades.BackColor = System.Drawing.Color.Red;
            this.buttonAtividades.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAtividades.BackgroundImage")));
            this.buttonAtividades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtividades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtividades.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAtividades.FlatAppearance.BorderSize = 5;
            this.buttonAtividades.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAtividades.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonAtividades.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAtividades.ForeColor = System.Drawing.Color.White;
            this.buttonAtividades.Location = new System.Drawing.Point(15, 12);
            this.buttonAtividades.Name = "buttonAtividades";
            this.buttonAtividades.Size = new System.Drawing.Size(131, 40);
            this.buttonAtividades.TabIndex = 62;
            this.buttonAtividades.Text = "Atividades";
            this.buttonAtividades.UseVisualStyleBackColor = false;
            this.buttonAtividades.Click += new System.EventHandler(this.buttonAtividades_Click);
            // 
            // buttonRegulamento
            // 
            this.buttonRegulamento.BackColor = System.Drawing.Color.Red;
            this.buttonRegulamento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRegulamento.BackgroundImage")));
            this.buttonRegulamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRegulamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegulamento.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonRegulamento.FlatAppearance.BorderSize = 5;
            this.buttonRegulamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRegulamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonRegulamento.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonRegulamento.ForeColor = System.Drawing.Color.White;
            this.buttonRegulamento.Location = new System.Drawing.Point(167, 12);
            this.buttonRegulamento.Name = "buttonRegulamento";
            this.buttonRegulamento.Size = new System.Drawing.Size(131, 40);
            this.buttonRegulamento.TabIndex = 61;
            this.buttonRegulamento.Text = "Regulamento";
            this.buttonRegulamento.UseVisualStyleBackColor = false;
            this.buttonRegulamento.Click += new System.EventHandler(this.buttonRegulamento_Click);
            // 
            // formTelaInicialPrincipalInstrucoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 138);
            this.Controls.Add(this.buttonCursos);
            this.Controls.Add(this.buttonAtividades);
            this.Controls.Add(this.buttonRegulamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formTelaInicialPrincipalInstrucoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instruções";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCursos;
        private System.Windows.Forms.Button buttonAtividades;
        private System.Windows.Forms.Button buttonRegulamento;
    }
}