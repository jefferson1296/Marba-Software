
namespace MarbaSoftware
{
    partial class formCatalogoLinhasAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogoLinhasAdicionar));
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.textBoxMarketing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMarkup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAtivacao = new System.Windows.Forms.CheckBox();
            this.buttonMarkup = new System.Windows.Forms.Button();
            this.textBoxLucro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(102, 40);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(301, 26);
            this.textBoxDescricao.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descrição:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Red;
            this.buttonCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.BackgroundImage")));
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(209, 247);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(159, 32);
            this.buttonCancelar.TabIndex = 61;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.BackColor = System.Drawing.Color.Red;
            this.buttonCadastrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.BackgroundImage")));
            this.buttonCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCadastrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCadastrar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCadastrar.ForeColor = System.Drawing.Color.White;
            this.buttonCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.Image")));
            this.buttonCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCadastrar.Location = new System.Drawing.Point(44, 247);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(159, 32);
            this.buttonCadastrar.TabIndex = 60;
            this.buttonCadastrar.Text = "Salvar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // textBoxMarketing
            // 
            this.textBoxMarketing.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarketing.Location = new System.Drawing.Point(102, 81);
            this.textBoxMarketing.Multiline = true;
            this.textBoxMarketing.Name = "textBoxMarketing";
            this.textBoxMarketing.Size = new System.Drawing.Size(301, 66);
            this.textBoxMarketing.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 62;
            this.label2.Text = "Marketing:";
            // 
            // textBoxMarkup
            // 
            this.textBoxMarkup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxMarkup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarkup.Location = new System.Drawing.Point(320, 156);
            this.textBoxMarkup.Name = "textBoxMarkup";
            this.textBoxMarkup.ReadOnly = true;
            this.textBoxMarkup.Size = new System.Drawing.Size(82, 26);
            this.textBoxMarkup.TabIndex = 65;
            this.textBoxMarkup.Text = "0,00%";
            this.textBoxMarkup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 64;
            this.label3.Text = "Markup:";
            // 
            // checkBoxAtivacao
            // 
            this.checkBoxAtivacao.AutoSize = true;
            this.checkBoxAtivacao.Checked = true;
            this.checkBoxAtivacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAtivacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxAtivacao.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAtivacao.Location = new System.Drawing.Point(333, 17);
            this.checkBoxAtivacao.Name = "checkBoxAtivacao";
            this.checkBoxAtivacao.Size = new System.Drawing.Size(70, 20);
            this.checkBoxAtivacao.TabIndex = 66;
            this.checkBoxAtivacao.Text = "Ativação";
            this.checkBoxAtivacao.UseVisualStyleBackColor = true;
            // 
            // buttonMarkup
            // 
            this.buttonMarkup.BackColor = System.Drawing.Color.White;
            this.buttonMarkup.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMarkup.ForeColor = System.Drawing.Color.Red;
            this.buttonMarkup.Location = new System.Drawing.Point(154, 193);
            this.buttonMarkup.Name = "buttonMarkup";
            this.buttonMarkup.Size = new System.Drawing.Size(109, 24);
            this.buttonMarkup.TabIndex = 67;
            this.buttonMarkup.Text = "Calcular markup";
            this.buttonMarkup.UseVisualStyleBackColor = false;
            this.buttonMarkup.Click += new System.EventHandler(this.buttonMarkup_Click);
            // 
            // textBoxLucro
            // 
            this.textBoxLucro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxLucro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLucro.Location = new System.Drawing.Point(154, 156);
            this.textBoxLucro.Name = "textBoxLucro";
            this.textBoxLucro.ReadOnly = true;
            this.textBoxLucro.Size = new System.Drawing.Size(82, 26);
            this.textBoxLucro.TabIndex = 69;
            this.textBoxLucro.Text = "0,00%";
            this.textBoxLucro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 68;
            this.label4.Text = "Margem de lucro:";
            // 
            // formCatalogoLinhasAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 309);
            this.Controls.Add(this.textBoxLucro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonMarkup);
            this.Controls.Add(this.checkBoxAtivacao);
            this.Controls.Add(this.textBoxMarkup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMarketing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCatalogoLinhasAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linha";
            this.Load += new System.EventHandler(this.formCatalogoLinhasAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.TextBox textBoxMarketing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMarkup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAtivacao;
        private System.Windows.Forms.Button buttonMarkup;
        private System.Windows.Forms.TextBox textBoxLucro;
        private System.Windows.Forms.Label label4;
    }
}