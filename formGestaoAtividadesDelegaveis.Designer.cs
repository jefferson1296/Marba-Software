
namespace MarbaSoftware
{
    partial class formGestaoAtividadesDelegaveis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoAtividadesDelegaveis));
            this.buttonDelegavel = new System.Windows.Forms.Button();
            this.buttonAtividade = new System.Windows.Forms.Button();
            this.buttonAberto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDelegavel
            // 
            this.buttonDelegavel.BackColor = System.Drawing.Color.Red;
            this.buttonDelegavel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelegavel.BackgroundImage")));
            this.buttonDelegavel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelegavel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelegavel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDelegavel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelegavel.ForeColor = System.Drawing.Color.White;
            this.buttonDelegavel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelegavel.Location = new System.Drawing.Point(14, 27);
            this.buttonDelegavel.Name = "buttonDelegavel";
            this.buttonDelegavel.Size = new System.Drawing.Size(197, 32);
            this.buttonDelegavel.TabIndex = 3;
            this.buttonDelegavel.TabStop = false;
            this.buttonDelegavel.Text = "Delegar atividade delegável";
            this.buttonDelegavel.UseVisualStyleBackColor = false;
            this.buttonDelegavel.Click += new System.EventHandler(this.buttonDelegavel_Click);
            // 
            // buttonAtividade
            // 
            this.buttonAtividade.BackColor = System.Drawing.Color.Red;
            this.buttonAtividade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAtividade.BackgroundImage")));
            this.buttonAtividade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtividade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtividade.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAtividade.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAtividade.ForeColor = System.Drawing.Color.White;
            this.buttonAtividade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtividade.Location = new System.Drawing.Point(14, 71);
            this.buttonAtividade.Name = "buttonAtividade";
            this.buttonAtividade.Size = new System.Drawing.Size(197, 32);
            this.buttonAtividade.TabIndex = 4;
            this.buttonAtividade.TabStop = false;
            this.buttonAtividade.Text = "Delegar atividade";
            this.buttonAtividade.UseVisualStyleBackColor = false;
            this.buttonAtividade.Click += new System.EventHandler(this.buttonAtividade_Click);
            // 
            // buttonAberto
            // 
            this.buttonAberto.BackColor = System.Drawing.Color.Red;
            this.buttonAberto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAberto.BackgroundImage")));
            this.buttonAberto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAberto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAberto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAberto.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAberto.ForeColor = System.Drawing.Color.White;
            this.buttonAberto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAberto.Location = new System.Drawing.Point(14, 115);
            this.buttonAberto.Name = "buttonAberto";
            this.buttonAberto.Size = new System.Drawing.Size(197, 32);
            this.buttonAberto.TabIndex = 5;
            this.buttonAberto.TabStop = false;
            this.buttonAberto.Text = "Lançar atividade em aberto";
            this.buttonAberto.UseVisualStyleBackColor = false;
            this.buttonAberto.Click += new System.EventHandler(this.buttonAberto_Click);
            // 
            // formGestaoAtividadesDelegaveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 166);
            this.Controls.Add(this.buttonAberto);
            this.Controls.Add(this.buttonAtividade);
            this.Controls.Add(this.buttonDelegavel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoAtividadesDelegaveis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atividades delegáveis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDelegavel;
        private System.Windows.Forms.Button buttonAtividade;
        private System.Windows.Forms.Button buttonAberto;
    }
}