
namespace MarbaSoftware
{
    partial class formGestaoConfiguracoesDefinicoes
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
            this.comboBoxSerial = new System.Windows.Forms.ComboBox();
            this.comboBoxTermica = new System.Windows.Forms.ComboBox();
            this.comboBoxA4 = new System.Windows.Forms.ComboBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxComputador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxReparticoes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSerial
            // 
            this.comboBoxSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSerial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerial.FormattingEnabled = true;
            this.comboBoxSerial.Location = new System.Drawing.Point(196, 235);
            this.comboBoxSerial.Name = "comboBoxSerial";
            this.comboBoxSerial.Size = new System.Drawing.Size(312, 26);
            this.comboBoxSerial.TabIndex = 22;
            this.comboBoxSerial.TabStop = false;
            this.comboBoxSerial.Leave += new System.EventHandler(this.comboBoxSerial_Leave);
            // 
            // comboBoxTermica
            // 
            this.comboBoxTermica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTermica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTermica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTermica.FormattingEnabled = true;
            this.comboBoxTermica.Location = new System.Drawing.Point(196, 196);
            this.comboBoxTermica.Name = "comboBoxTermica";
            this.comboBoxTermica.Size = new System.Drawing.Size(312, 26);
            this.comboBoxTermica.TabIndex = 21;
            this.comboBoxTermica.TabStop = false;
            this.comboBoxTermica.SelectedIndexChanged += new System.EventHandler(this.comboBoxTermica_SelectedIndexChanged);
            // 
            // comboBoxA4
            // 
            this.comboBoxA4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxA4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxA4.FormattingEnabled = true;
            this.comboBoxA4.Location = new System.Drawing.Point(196, 157);
            this.comboBoxA4.Name = "comboBoxA4";
            this.comboBoxA4.Size = new System.Drawing.Size(312, 26);
            this.comboBoxA4.TabIndex = 20;
            this.comboBoxA4.TabStop = false;
            this.comboBoxA4.SelectedIndexChanged += new System.EventHandler(this.comboBoxA4_SelectedIndexChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(196, 81);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(312, 26);
            this.textBoxID.TabIndex = 19;
            this.textBoxID.TabStop = false;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.Location = new System.Drawing.Point(196, 48);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(312, 26);
            this.textBoxUsuario.TabIndex = 18;
            this.textBoxUsuario.TabStop = false;
            // 
            // textBoxComputador
            // 
            this.textBoxComputador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxComputador.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComputador.Location = new System.Drawing.Point(196, 15);
            this.textBoxComputador.Name = "textBoxComputador";
            this.textBoxComputador.Size = new System.Drawing.Size(312, 26);
            this.textBoxComputador.TabIndex = 17;
            this.textBoxComputador.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Porta serial (sensores):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Impressora Térmica:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Impressora A4:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Computador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "ID:";
            // 
            // comboBoxReparticoes
            // 
            this.comboBoxReparticoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReparticoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReparticoes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReparticoes.FormattingEnabled = true;
            this.comboBoxReparticoes.Location = new System.Drawing.Point(196, 119);
            this.comboBoxReparticoes.Name = "comboBoxReparticoes";
            this.comboBoxReparticoes.Size = new System.Drawing.Size(312, 26);
            this.comboBoxReparticoes.TabIndex = 25;
            this.comboBoxReparticoes.TabStop = false;
            this.comboBoxReparticoes.SelectedIndexChanged += new System.EventHandler(this.comboBoxReparticoes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Repartição:";
            // 
            // formGestaoConfiguracoesDefinicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 272);
            this.Controls.Add(this.comboBoxReparticoes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSerial);
            this.Controls.Add(this.comboBoxTermica);
            this.Controls.Add(this.comboBoxA4);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.textBoxComputador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formGestaoConfiguracoesDefinicoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formGestaoConfiguracoesDefinicoes";
            this.Load += new System.EventHandler(this.formGestaoConfiguracoesDefinicoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerial;
        private System.Windows.Forms.ComboBox comboBoxTermica;
        private System.Windows.Forms.ComboBox comboBoxA4;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxComputador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxReparticoes;
        private System.Windows.Forms.Label label7;
    }
}