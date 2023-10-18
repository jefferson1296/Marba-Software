
namespace MarbaSoftware
{
    partial class formTelaInicialAtividadesExpedientesAlterar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialAtividadesExpedientesAlterar));
            this.panel105 = new System.Windows.Forms.Panel();
            this.panel104 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LancheInicio = new System.Windows.Forms.MaskedTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.ServicoInicio = new System.Windows.Forms.MaskedTextBox();
            this.ServicoTermino = new System.Windows.Forms.MaskedTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.LancheTermino = new System.Windows.Forms.MaskedTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.AlmocoInicio = new System.Windows.Forms.MaskedTextBox();
            this.AlmocoTermino = new System.Windows.Forms.MaskedTextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.radioButtonExpediente = new System.Windows.Forms.RadioButton();
            this.radioButtonFolga = new System.Windows.Forms.RadioButton();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel105
            // 
            this.panel105.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel105.BackgroundImage")));
            this.panel105.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel105.Location = new System.Drawing.Point(103, 138);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(110, 1);
            this.panel105.TabIndex = 541;
            // 
            // panel104
            // 
            this.panel104.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel104.BackgroundImage")));
            this.panel104.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel104.Location = new System.Drawing.Point(103, 99);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(110, 1);
            this.panel104.TabIndex = 540;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(103, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 1);
            this.panel6.TabIndex = 539;
            // 
            // LancheInicio
            // 
            this.LancheInicio.Font = new System.Drawing.Font("Arial", 12F);
            this.LancheInicio.Location = new System.Drawing.Point(235, 85);
            this.LancheInicio.Mask = "90:00";
            this.LancheInicio.Name = "LancheInicio";
            this.LancheInicio.Size = new System.Drawing.Size(72, 26);
            this.LancheInicio.TabIndex = 4;
            this.LancheInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LancheInicio.ValidatingType = typeof(System.DateTime);
            this.LancheInicio.Leave += new System.EventHandler(this.LancheInicio_Leave);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(28, 57);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(54, 16);
            this.label45.TabIndex = 527;
            this.label45.Text = "Serviço:";
            // 
            // ServicoInicio
            // 
            this.ServicoInicio.Font = new System.Drawing.Font("Arial", 12F);
            this.ServicoInicio.Location = new System.Drawing.Point(235, 53);
            this.ServicoInicio.Mask = "90:00";
            this.ServicoInicio.Name = "ServicoInicio";
            this.ServicoInicio.Size = new System.Drawing.Size(72, 26);
            this.ServicoInicio.TabIndex = 2;
            this.ServicoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServicoInicio.ValidatingType = typeof(System.DateTime);
            this.ServicoInicio.Leave += new System.EventHandler(this.ServicoInicio_Leave);
            // 
            // ServicoTermino
            // 
            this.ServicoTermino.Font = new System.Drawing.Font("Arial", 12F);
            this.ServicoTermino.Location = new System.Drawing.Point(358, 52);
            this.ServicoTermino.Mask = "90:00";
            this.ServicoTermino.Name = "ServicoTermino";
            this.ServicoTermino.Size = new System.Drawing.Size(72, 26);
            this.ServicoTermino.TabIndex = 3;
            this.ServicoTermino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServicoTermino.ValidatingType = typeof(System.DateTime);
            this.ServicoTermino.Leave += new System.EventHandler(this.ServicoTermino_Leave);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(324, 60);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(18, 13);
            this.label46.TabIndex = 530;
            this.label46.Text = "às";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(28, 90);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(54, 16);
            this.label48.TabIndex = 531;
            this.label48.Text = "Lanche:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(28, 126);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(56, 16);
            this.label50.TabIndex = 532;
            this.label50.Text = "Almoço:";
            // 
            // LancheTermino
            // 
            this.LancheTermino.Font = new System.Drawing.Font("Arial", 12F);
            this.LancheTermino.Location = new System.Drawing.Point(358, 84);
            this.LancheTermino.Mask = "90:00";
            this.LancheTermino.Name = "LancheTermino";
            this.LancheTermino.Size = new System.Drawing.Size(72, 26);
            this.LancheTermino.TabIndex = 5;
            this.LancheTermino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LancheTermino.ValidatingType = typeof(System.DateTime);
            this.LancheTermino.Leave += new System.EventHandler(this.LancheTermino_Leave);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(324, 92);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(18, 13);
            this.label47.TabIndex = 535;
            this.label47.Text = "às";
            // 
            // AlmocoInicio
            // 
            this.AlmocoInicio.Font = new System.Drawing.Font("Arial", 12F);
            this.AlmocoInicio.Location = new System.Drawing.Point(235, 119);
            this.AlmocoInicio.Mask = "90:00";
            this.AlmocoInicio.Name = "AlmocoInicio";
            this.AlmocoInicio.Size = new System.Drawing.Size(72, 26);
            this.AlmocoInicio.TabIndex = 6;
            this.AlmocoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AlmocoInicio.ValidatingType = typeof(System.DateTime);
            this.AlmocoInicio.Leave += new System.EventHandler(this.AlmocoInicio_Leave);
            // 
            // AlmocoTermino
            // 
            this.AlmocoTermino.Font = new System.Drawing.Font("Arial", 12F);
            this.AlmocoTermino.Location = new System.Drawing.Point(358, 118);
            this.AlmocoTermino.Mask = "90:00";
            this.AlmocoTermino.Name = "AlmocoTermino";
            this.AlmocoTermino.Size = new System.Drawing.Size(72, 26);
            this.AlmocoTermino.TabIndex = 7;
            this.AlmocoTermino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AlmocoTermino.ValidatingType = typeof(System.DateTime);
            this.AlmocoTermino.Leave += new System.EventHandler(this.AlmocoTermino_Leave);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(324, 126);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(18, 13);
            this.label49.TabIndex = 538;
            this.label49.Text = "às";
            // 
            // radioButtonExpediente
            // 
            this.radioButtonExpediente.AutoSize = true;
            this.radioButtonExpediente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExpediente.Location = new System.Drawing.Point(132, 17);
            this.radioButtonExpediente.Name = "radioButtonExpediente";
            this.radioButtonExpediente.Size = new System.Drawing.Size(85, 20);
            this.radioButtonExpediente.TabIndex = 542;
            this.radioButtonExpediente.Text = "Expediente";
            this.radioButtonExpediente.UseVisualStyleBackColor = true;
            // 
            // radioButtonFolga
            // 
            this.radioButtonFolga.AutoSize = true;
            this.radioButtonFolga.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFolga.Location = new System.Drawing.Point(248, 17);
            this.radioButtonFolga.Name = "radioButtonFolga";
            this.radioButtonFolga.Size = new System.Drawing.Size(56, 20);
            this.radioButtonFolga.TabIndex = 543;
            this.radioButtonFolga.Text = "Folga";
            this.radioButtonFolga.UseVisualStyleBackColor = true;
            this.radioButtonFolga.CheckedChanged += new System.EventHandler(this.radioButtonFolga_CheckedChanged);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonSalvar.FlatAppearance.BorderSize = 2;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(63, 163);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(150, 30);
            this.buttonSalvar.TabIndex = 1;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(235, 163);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 545;
            this.button1.TabStop = false;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // formTelaInicialAtividadesExpedientesAlterar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.radioButtonFolga);
            this.Controls.Add(this.radioButtonExpediente);
            this.Controls.Add(this.panel105);
            this.Controls.Add(this.panel104);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.LancheInicio);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.ServicoInicio);
            this.Controls.Add(this.ServicoTermino);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.LancheTermino);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.AlmocoInicio);
            this.Controls.Add(this.AlmocoTermino);
            this.Controls.Add(this.label49);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formTelaInicialAtividadesExpedientesAlterar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar expediente";
            this.Load += new System.EventHandler(this.formTelaInicialAtividadesExpedientesAlterar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel105;
        private System.Windows.Forms.Panel panel104;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.MaskedTextBox LancheInicio;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.MaskedTextBox ServicoInicio;
        private System.Windows.Forms.MaskedTextBox ServicoTermino;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.MaskedTextBox LancheTermino;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.MaskedTextBox AlmocoInicio;
        private System.Windows.Forms.MaskedTextBox AlmocoTermino;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.RadioButton radioButtonExpediente;
        private System.Windows.Forms.RadioButton radioButtonFolga;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button button1;
    }
}