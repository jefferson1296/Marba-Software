
namespace MarbaSoftware
{
    partial class formGestaoEstabelecimentosReparticoesAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoEstabelecimentosReparticoesAdicionar));
            this.comboBoxEstabelecimentos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxReparticao = new System.Windows.Forms.TextBox();
            this.textBoxMetros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSetores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.colaboradorComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxEstabelecimentos
            // 
            this.comboBoxEstabelecimentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstabelecimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstabelecimentos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstabelecimentos.FormattingEnabled = true;
            this.comboBoxEstabelecimentos.Location = new System.Drawing.Point(161, 25);
            this.comboBoxEstabelecimentos.Name = "comboBoxEstabelecimentos";
            this.comboBoxEstabelecimentos.Size = new System.Drawing.Size(324, 26);
            this.comboBoxEstabelecimentos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Estabelecimento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Repartição:";
            // 
            // textBoxReparticao
            // 
            this.textBoxReparticao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReparticao.Location = new System.Drawing.Point(117, 70);
            this.textBoxReparticao.MaxLength = 30;
            this.textBoxReparticao.Name = "textBoxReparticao";
            this.textBoxReparticao.Size = new System.Drawing.Size(368, 26);
            this.textBoxReparticao.TabIndex = 11;
            // 
            // textBoxMetros
            // 
            this.textBoxMetros.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMetros.Location = new System.Drawing.Point(132, 115);
            this.textBoxMetros.Name = "textBoxMetros";
            this.textBoxMetros.Size = new System.Drawing.Size(77, 26);
            this.textBoxMetros.TabIndex = 13;
            this.textBoxMetros.Text = "0";
            this.textBoxMetros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMetros.Enter += new System.EventHandler(this.textBoxMetros_Enter);
            this.textBoxMetros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMetros_KeyPress);
            this.textBoxMetros.Leave += new System.EventHandler(this.textBoxMetros_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tamanho (m²):";
            // 
            // comboBoxSetores
            // 
            this.comboBoxSetores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSetores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSetores.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSetores.FormattingEnabled = true;
            this.comboBoxSetores.Location = new System.Drawing.Point(276, 115);
            this.comboBoxSetores.Name = "comboBoxSetores";
            this.comboBoxSetores.Size = new System.Drawing.Size(209, 26);
            this.comboBoxSetores.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(220, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Setor:";
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
            this.buttonCancelar.Location = new System.Drawing.Point(245, 206);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(159, 32);
            this.buttonCancelar.TabIndex = 57;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
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
            this.buttonCadastrar.Location = new System.Drawing.Point(80, 206);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(159, 32);
            this.buttonCadastrar.TabIndex = 56;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // colaboradorComboBox
            // 
            this.colaboradorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colaboradorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colaboradorComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colaboradorComboBox.FormattingEnabled = true;
            this.colaboradorComboBox.Location = new System.Drawing.Point(94, 157);
            this.colaboradorComboBox.Name = "colaboradorComboBox";
            this.colaboradorComboBox.Size = new System.Drawing.Size(271, 26);
            this.colaboradorComboBox.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 59;
            this.label5.Text = "Gerente:";
            // 
            // formGestaoEstabelecimentosReparticoesAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 261);
            this.Controls.Add(this.colaboradorComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.comboBoxSetores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMetros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxReparticao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEstabelecimentos);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "formGestaoEstabelecimentosReparticoesAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar repartições";
            this.Load += new System.EventHandler(this.formGestaoEstabelecimentosReparticoesAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEstabelecimentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReparticao;
        private System.Windows.Forms.TextBox textBoxMetros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSetores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.ComboBox colaboradorComboBox;
        private System.Windows.Forms.Label label5;
    }
}