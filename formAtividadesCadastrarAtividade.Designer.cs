
namespace MarbaSoftware
{
    partial class formAtividadesCadastrarAtividade
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCargos = new System.Windows.Forms.ComboBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.prioridadeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.intervaloTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButtonRotina = new System.Windows.Forms.RadioButton();
            this.radioButtonAtividade = new System.Windows.Forms.RadioButton();
            this.comboBoxSetores = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(299, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 491;
            this.label3.Text = "Cargo:";
            // 
            // comboBoxCargos
            // 
            this.comboBoxCargos.BackColor = System.Drawing.Color.White;
            this.comboBoxCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCargos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCargos.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCargos.FormattingEnabled = true;
            this.comboBoxCargos.Location = new System.Drawing.Point(355, 94);
            this.comboBoxCargos.Name = "comboBoxCargos";
            this.comboBoxCargos.Size = new System.Drawing.Size(241, 26);
            this.comboBoxCargos.TabIndex = 490;
            this.comboBoxCargos.SelectedIndexChanged += new System.EventHandler(this.comboBoxCargos_SelectedIndexChanged);
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCategoria.BackColor = System.Drawing.Color.White;
            this.comboBoxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCategoria.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(104, 137);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(318, 26);
            this.comboBoxCategoria.TabIndex = 488;
            this.comboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoria_SelectedIndexChanged);
            this.comboBoxCategoria.Leave += new System.EventHandler(this.comboBoxCategoria_Leave);
            // 
            // prioridadeComboBox
            // 
            this.prioridadeComboBox.BackColor = System.Drawing.Color.White;
            this.prioridadeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prioridadeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prioridadeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prioridadeComboBox.ForeColor = System.Drawing.Color.Black;
            this.prioridadeComboBox.FormattingEnabled = true;
            this.prioridadeComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.prioridadeComboBox.Location = new System.Drawing.Point(526, 137);
            this.prioridadeComboBox.Name = "prioridadeComboBox";
            this.prioridadeComboBox.Size = new System.Drawing.Size(70, 26);
            this.prioridadeComboBox.TabIndex = 487;
            this.prioridadeComboBox.SelectedIndexChanged += new System.EventHandler(this.prioridadeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(443, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 486;
            this.label7.Text = "Prioridade:";
            // 
            // intervaloTextBox
            // 
            this.intervaloTextBox.BackColor = System.Drawing.Color.White;
            this.intervaloTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intervaloTextBox.ForeColor = System.Drawing.Color.Black;
            this.intervaloTextBox.Location = new System.Drawing.Point(140, 179);
            this.intervaloTextBox.Name = "intervaloTextBox";
            this.intervaloTextBox.Size = new System.Drawing.Size(86, 26);
            this.intervaloTextBox.TabIndex = 483;
            this.intervaloTextBox.Text = "0";
            this.intervaloTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervaloTextBox.Visible = false;
            this.intervaloTextBox.Enter += new System.EventHandler(this.intervaloTextBox_Enter);
            this.intervaloTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intervaloTextBox_KeyPress);
            this.intervaloTextBox.Leave += new System.EventHandler(this.intervaloTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(24, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 482;
            this.label5.Text = "Intervalo (dias):";
            this.label5.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(32, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(564, 1);
            this.panel6.TabIndex = 481;
            // 
            // radioButtonRotina
            // 
            this.radioButtonRotina.AutoSize = true;
            this.radioButtonRotina.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRotina.Location = new System.Drawing.Point(325, 20);
            this.radioButtonRotina.Name = "radioButtonRotina";
            this.radioButtonRotina.Size = new System.Drawing.Size(61, 20);
            this.radioButtonRotina.TabIndex = 480;
            this.radioButtonRotina.Text = "Rotina";
            this.radioButtonRotina.UseVisualStyleBackColor = true;
            this.radioButtonRotina.CheckedChanged += new System.EventHandler(this.radioButtonRotina_CheckedChanged);
            // 
            // radioButtonAtividade
            // 
            this.radioButtonAtividade.AutoSize = true;
            this.radioButtonAtividade.Checked = true;
            this.radioButtonAtividade.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAtividade.Location = new System.Drawing.Point(235, 20);
            this.radioButtonAtividade.Name = "radioButtonAtividade";
            this.radioButtonAtividade.Size = new System.Drawing.Size(75, 20);
            this.radioButtonAtividade.TabIndex = 479;
            this.radioButtonAtividade.TabStop = true;
            this.radioButtonAtividade.Text = "Atividade";
            this.radioButtonAtividade.UseVisualStyleBackColor = true;
            // 
            // comboBoxSetores
            // 
            this.comboBoxSetores.BackColor = System.Drawing.Color.White;
            this.comboBoxSetores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSetores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSetores.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSetores.ForeColor = System.Drawing.Color.Black;
            this.comboBoxSetores.FormattingEnabled = true;
            this.comboBoxSetores.Location = new System.Drawing.Point(81, 94);
            this.comboBoxSetores.Name = "comboBoxSetores";
            this.comboBoxSetores.Size = new System.Drawing.Size(212, 26);
            this.comboBoxSetores.TabIndex = 478;
            this.comboBoxSetores.SelectedIndexChanged += new System.EventHandler(this.comboBoxSetores_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(24, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 16);
            this.label12.TabIndex = 477;
            this.label12.Text = "Descrição:";
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.BackColor = System.Drawing.Color.White;
            this.descricaoTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descricaoTextBox.ForeColor = System.Drawing.Color.Black;
            this.descricaoTextBox.Location = new System.Drawing.Point(109, 52);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(487, 26);
            this.descricaoTextBox.TabIndex = 476;
            this.descricaoTextBox.Leave += new System.EventHandler(this.descricaoTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 489;
            this.label2.Text = "Categoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 492;
            this.label1.Text = "Setor:";
            // 
            // formAtividadesCadastrarAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCargos);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.prioridadeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.intervaloTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.radioButtonRotina);
            this.Controls.Add(this.radioButtonAtividade);
            this.Controls.Add(this.comboBoxSetores);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAtividadesCadastrarAtividade";
            this.Text = "formAtividadesCadastrarAtividade";
            this.Load += new System.EventHandler(this.formAtividadesCadastrarAtividade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCargos;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox prioridadeComboBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox intervaloTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioButtonRotina;
        private System.Windows.Forms.RadioButton radioButtonAtividade;
        private System.Windows.Forms.ComboBox comboBoxSetores;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}