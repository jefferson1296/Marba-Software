
namespace MarbaSoftware
{
    partial class formCatalogoLinhasAdicionarMarkup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogoLinhasAdicionarMarkup));
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTermino = new System.Windows.Forms.DateTimePicker();
            this.textBoxLucro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAvarias = new System.Windows.Forms.TextBox();
            this.textBoxFixas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFaturamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVariaveis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCalcular = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTotalVariaveis = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTotalFixas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxMarkup = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicio.Location = new System.Drawing.Point(55, 19);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(123, 26);
            this.dateTimeInicio.TabIndex = 0;
            // 
            // dateTimeTermino
            // 
            this.dateTimeTermino.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTermino.Location = new System.Drawing.Point(233, 19);
            this.dateTimeTermino.Name = "dateTimeTermino";
            this.dateTimeTermino.Size = new System.Drawing.Size(129, 26);
            this.dateTimeTermino.TabIndex = 1;
            this.dateTimeTermino.ValueChanged += new System.EventHandler(this.dateTimeTermino_ValueChanged);
            // 
            // textBoxLucro
            // 
            this.textBoxLucro.BackColor = System.Drawing.Color.White;
            this.textBoxLucro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLucro.Location = new System.Drawing.Point(250, 249);
            this.textBoxLucro.Name = "textBoxLucro";
            this.textBoxLucro.Size = new System.Drawing.Size(112, 26);
            this.textBoxLucro.TabIndex = 67;
            this.textBoxLucro.Text = "0,00%";
            this.textBoxLucro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLucro.Enter += new System.EventHandler(this.textBoxLucro_Enter);
            this.textBoxLucro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLucro_KeyPress);
            this.textBoxLucro.Leave += new System.EventHandler(this.textBoxLucro_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 66;
            this.label3.Text = "Lucro desejado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 68;
            this.label1.Text = "Taxa de avarias:";
            // 
            // textBoxAvarias
            // 
            this.textBoxAvarias.BackColor = System.Drawing.Color.White;
            this.textBoxAvarias.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAvarias.Location = new System.Drawing.Point(250, 284);
            this.textBoxAvarias.Name = "textBoxAvarias";
            this.textBoxAvarias.Size = new System.Drawing.Size(112, 26);
            this.textBoxAvarias.TabIndex = 69;
            this.textBoxAvarias.Text = "0,00%";
            this.textBoxAvarias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAvarias.Enter += new System.EventHandler(this.textBoxAvarias_Enter);
            this.textBoxAvarias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAvarias_KeyPress);
            this.textBoxAvarias.Leave += new System.EventHandler(this.textBoxAvarias_Leave);
            // 
            // textBoxFixas
            // 
            this.textBoxFixas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxFixas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFixas.Location = new System.Drawing.Point(250, 179);
            this.textBoxFixas.Name = "textBoxFixas";
            this.textBoxFixas.ReadOnly = true;
            this.textBoxFixas.Size = new System.Drawing.Size(112, 26);
            this.textBoxFixas.TabIndex = 73;
            this.textBoxFixas.Text = "0,00%";
            this.textBoxFixas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 72;
            this.label2.Text = "Despesas fixas:";
            // 
            // textBoxFaturamento
            // 
            this.textBoxFaturamento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxFaturamento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFaturamento.Location = new System.Drawing.Point(144, 74);
            this.textBoxFaturamento.Name = "textBoxFaturamento";
            this.textBoxFaturamento.ReadOnly = true;
            this.textBoxFaturamento.Size = new System.Drawing.Size(218, 26);
            this.textBoxFaturamento.TabIndex = 71;
            this.textBoxFaturamento.Text = "R$0,00";
            this.textBoxFaturamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 70;
            this.label4.Text = "Faturamento:";
            // 
            // textBoxVariaveis
            // 
            this.textBoxVariaveis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxVariaveis.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVariaveis.Location = new System.Drawing.Point(250, 214);
            this.textBoxVariaveis.Name = "textBoxVariaveis";
            this.textBoxVariaveis.ReadOnly = true;
            this.textBoxVariaveis.Size = new System.Drawing.Size(112, 26);
            this.textBoxVariaveis.TabIndex = 75;
            this.textBoxVariaveis.Text = "0,00%";
            this.textBoxVariaveis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 19);
            this.label5.TabIndex = 74;
            this.label5.Text = "Despesas variáveis:";
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.BackColor = System.Drawing.Color.Red;
            this.buttonCalcular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCalcular.BackgroundImage")));
            this.buttonCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalcular.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCalcular.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalcular.ForeColor = System.Drawing.Color.White;
            this.buttonCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCalcular.Location = new System.Drawing.Point(104, 402);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCalcular.Size = new System.Drawing.Size(159, 32);
            this.buttonCalcular.TabIndex = 76;
            this.buttonCalcular.Text = "Aplicar";
            this.buttonCalcular.UseVisualStyleBackColor = false;
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(199, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "até:";
            // 
            // textBoxTotalVariaveis
            // 
            this.textBoxTotalVariaveis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTotalVariaveis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalVariaveis.Location = new System.Drawing.Point(256, 109);
            this.textBoxTotalVariaveis.Name = "textBoxTotalVariaveis";
            this.textBoxTotalVariaveis.ReadOnly = true;
            this.textBoxTotalVariaveis.Size = new System.Drawing.Size(106, 22);
            this.textBoxTotalVariaveis.TabIndex = 81;
            this.textBoxTotalVariaveis.Text = "R$0,00";
            this.textBoxTotalVariaveis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 80;
            this.label7.Text = "Variáveis:";
            // 
            // textBoxTotalFixas
            // 
            this.textBoxTotalFixas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTotalFixas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalFixas.Location = new System.Drawing.Point(74, 109);
            this.textBoxTotalFixas.Name = "textBoxTotalFixas";
            this.textBoxTotalFixas.ReadOnly = true;
            this.textBoxTotalFixas.Size = new System.Drawing.Size(106, 22);
            this.textBoxTotalFixas.TabIndex = 79;
            this.textBoxTotalFixas.Text = "R$0,00";
            this.textBoxTotalFixas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "Fixas:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dateTimeTermino);
            this.panel1.Controls.Add(this.dateTimeInicio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 57);
            this.panel1.TabIndex = 82;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 16);
            this.label9.TabIndex = 78;
            this.label9.Text = "De:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(23, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 1);
            this.panel2.TabIndex = 83;
            // 
            // textBoxMarkup
            // 
            this.textBoxMarkup.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxMarkup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarkup.Location = new System.Drawing.Point(266, 348);
            this.textBoxMarkup.Name = "textBoxMarkup";
            this.textBoxMarkup.ReadOnly = true;
            this.textBoxMarkup.Size = new System.Drawing.Size(96, 26);
            this.textBoxMarkup.TabIndex = 85;
            this.textBoxMarkup.Text = "0,00";
            this.textBoxMarkup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 351);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(234, 19);
            this.label10.TabIndex = 84;
            this.label10.Text = "Índice Multiplicador (Markup):";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(23, 328);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 1);
            this.panel3.TabIndex = 86;
            // 
            // formCatalogoLinhasAdicionarMarkup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 467);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxMarkup);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxTotalVariaveis);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxTotalFixas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonCalcular);
            this.Controls.Add(this.textBoxVariaveis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFixas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFaturamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAvarias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLucro);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCatalogoLinhasAdicionarMarkup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calcular Markup";
            this.Load += new System.EventHandler(this.formCatalogoLinhasAdicionarMarkup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.DateTimePicker dateTimeTermino;
        private System.Windows.Forms.TextBox textBoxLucro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAvarias;
        private System.Windows.Forms.TextBox textBoxFixas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFaturamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVariaveis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCalcular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTotalVariaveis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTotalFixas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxMarkup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
    }
}