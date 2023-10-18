
namespace MarbaSoftware
{
    partial class formVendasPDVRetiradas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.PictureBox pictureBoxFechar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendasPDVRetiradas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBoxHistorico = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRetiradas = new System.Windows.Forms.BindingSource(this.components);
            pictureBoxFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).BeginInit();
            this.panelSuperior.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistorico)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRetiradas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFechar
            // 
            pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            pictureBoxFechar.Location = new System.Drawing.Point(942, 5);
            pictureBoxFechar.Name = "pictureBoxFechar";
            pictureBoxFechar.Size = new System.Drawing.Size(15, 15);
            pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxFechar.TabIndex = 20;
            pictureBoxFechar.TabStop = false;
            pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.label5);
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.labelTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(960, 24);
            this.panelSuperior.TabIndex = 20;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(5, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "$";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(29, 4);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(130, 16);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Retirada de Produtos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 476);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 3);
            this.panel4.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 83;
            this.label2.Text = "Informe o N° da Retirada:";
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxPesquisa.Location = new System.Drawing.Point(198, 10);
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(136, 19);
            this.textBoxPesquisa.TabIndex = 1;
            this.textBoxPesquisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFinalizar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonFinalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFinalizar.BackgroundImage")));
            this.buttonFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinalizar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.ForeColor = System.Drawing.Color.White;
            this.buttonFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonFinalizar.Image")));
            this.buttonFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinalizar.Location = new System.Drawing.Point(808, 4);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonFinalizar.Size = new System.Drawing.Size(138, 33);
            this.buttonFinalizar.TabIndex = 2;
            this.buttonFinalizar.Text = "Finalizar";
            this.buttonFinalizar.UseVisualStyleBackColor = false;
            this.buttonFinalizar.Click += new System.EventHandler(this.buttonFinalizar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 452);
            this.panel3.TabIndex = 72;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(957, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 452);
            this.panel2.TabIndex = 73;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBoxHistorico);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(954, 35);
            this.panel5.TabIndex = 75;
            // 
            // pictureBoxHistorico
            // 
            this.pictureBoxHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHistorico.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHistorico.Image")));
            this.pictureBoxHistorico.Location = new System.Drawing.Point(932, 12);
            this.pictureBoxHistorico.Name = "pictureBoxHistorico";
            this.pictureBoxHistorico.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxHistorico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHistorico.TabIndex = 84;
            this.pictureBoxHistorico.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "Procure a operação desejada pelo número do CPF ou pelo número da Retirada.";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel15);
            this.panel6.Controls.Add(this.pictureBoxPesquisar);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.buttonFinalizar);
            this.panel6.Controls.Add(this.textBoxPesquisa);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 435);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(954, 41);
            this.panel6.TabIndex = 76;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Khaki;
            this.panel15.Location = new System.Drawing.Point(198, 29);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(136, 1);
            this.panel15.TabIndex = 85;
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(340, 10);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPesquisar.TabIndex = 84;
            this.pictureBoxPesquisar.TabStop = false;
            this.pictureBoxPesquisar.Click += new System.EventHandler(this.pictureBoxPesquisar_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridViewLista);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 59);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(954, 376);
            this.panel7.TabIndex = 77;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoGenerateContextFilters = true;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 40;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.CPF,
            this.Column7,
            this.Column8,
            this.Column10,
            this.Column12,
            this.Column13});
            this.dataGridViewLista.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(954, 376);
            this.dataGridViewLista.TabIndex = 72;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
            this.dataGridViewLista.SortStringChanged += new System.EventHandler(this.dataGridViewLista_SortStringChanged);
            this.dataGridViewLista.FilterStringChanged += new System.EventHandler(this.dataGridViewLista_FilterStringChanged);
            this.dataGridViewLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellClick);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "N°";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "CPF";
            this.CPF.FillWeight = 120F;
            this.CPF.HeaderText = "CPF";
            this.CPF.MinimumWidth = 22;
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            this.CPF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Cliente";
            this.Column7.FillWeight = 200F;
            this.Column7.HeaderText = "Cliente";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Valor";
            this.Column8.HeaderText = "Valor";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Data";
            this.Column10.HeaderText = "Data";
            this.Column10.MinimumWidth = 22;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Validade";
            this.Column12.HeaderText = "Validade";
            this.Column12.MinimumWidth = 22;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Status";
            this.Column13.HeaderText = "Status";
            this.Column13.MinimumWidth = 22;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // formVendasPDVRetiradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(960, 479);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVendasPDVRetiradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formVendasPDVRetiradas";
            this.Load += new System.EventHandler(this.formVendasPDVRetiradas_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistorico)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRetiradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBoxHistorico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel7;
        private ADGV.AdvancedDataGridView dataGridViewLista;
        private System.Windows.Forms.BindingSource bindingSourceRetiradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}