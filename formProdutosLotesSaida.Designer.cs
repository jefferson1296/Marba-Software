
namespace MarbaSoftware
{
    partial class formProdutosLotesSaida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesSaida));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLinhaVermelha = new System.Windows.Forms.Panel();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBoxFechar = new System.Windows.Forms.CheckBox();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxProdutos = new System.Windows.Forms.TextBox();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxReparticoes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEstabelecimentos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLocalizacoes = new System.Windows.Forms.ComboBox();
            this.labelAtual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLinhaVermelha
            // 
            this.panelLinhaVermelha.BackColor = System.Drawing.Color.Red;
            this.panelLinhaVermelha.Location = new System.Drawing.Point(12, 50);
            this.panelLinhaVermelha.Name = "panelLinhaVermelha";
            this.panelLinhaVermelha.Size = new System.Drawing.Size(519, 1);
            this.panelLinhaVermelha.TabIndex = 49;
            this.panelLinhaVermelha.Visible = false;
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(545, 27);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 48;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxPesquisa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisa.BackColor = System.Drawing.Color.White;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(12, 22);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(519, 29);
            this.textBoxPesquisa.TabIndex = 1;
            this.textBoxPesquisa.Text = "Digite o produto";
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(592, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "Quantidade:";
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuantidade.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.Location = new System.Drawing.Point(684, 22);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(76, 29);
            this.textBoxQuantidade.TabIndex = 2;
            this.textBoxQuantidade.Text = "0";
            this.textBoxQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuantidade.Enter += new System.EventHandler(this.textBoxQuantidade_Enter);
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            this.textBoxQuantidade.Leave += new System.EventHandler(this.textBoxQuantidade_Leave);
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 32;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column3});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 147);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(835, 334);
            this.dataGridViewLista.TabIndex = 54;
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Código de barras";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 300F;
            this.Column1.HeaderText = "Produto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "Quantidade";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.checkBoxFechar);
            this.panel6.Controls.Add(this.buttonLimpar);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.buttonSalvar);
            this.panel6.Controls.Add(this.textBoxProdutos);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 481);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(835, 52);
            this.panel6.TabIndex = 53;
            // 
            // checkBoxFechar
            // 
            this.checkBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFechar.AutoSize = true;
            this.checkBoxFechar.Checked = true;
            this.checkBoxFechar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFechar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFechar.Location = new System.Drawing.Point(498, 17);
            this.checkBoxFechar.Name = "checkBoxFechar";
            this.checkBoxFechar.Size = new System.Drawing.Size(101, 19);
            this.checkBoxFechar.TabIndex = 36;
            this.checkBoxFechar.TabStop = false;
            this.checkBoxFechar.Text = "Fechar ao salvar";
            this.checkBoxFechar.UseVisualStyleBackColor = true;
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLimpar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpar.Location = new System.Drawing.Point(162, 14);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(95, 23);
            this.buttonLimpar.TabIndex = 35;
            this.buttonLimpar.TabStop = false;
            this.buttonLimpar.Text = "Limpar lista";
            this.buttonLimpar.UseVisualStyleBackColor = false;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Produtos:";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(622, 9);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(197, 32);
            this.buttonSalvar.TabIndex = 19;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxProdutos
            // 
            this.textBoxProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProdutos.Location = new System.Drawing.Point(89, 11);
            this.textBoxProdutos.Name = "textBoxProdutos";
            this.textBoxProdutos.ReadOnly = true;
            this.textBoxProdutos.Size = new System.Drawing.Size(56, 26);
            this.textBoxProdutos.TabIndex = 34;
            this.textBoxProdutos.TabStop = false;
            this.textBoxProdutos.Text = "0";
            this.textBoxProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdicionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.BackgroundImage")));
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdicionar.Location = new System.Drawing.Point(576, 105);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdicionar.Size = new System.Drawing.Size(243, 28);
            this.buttonAdicionar.TabIndex = 3;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Repartição:";
            // 
            // comboBoxReparticoes
            // 
            this.comboBoxReparticoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReparticoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReparticoes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReparticoes.FormattingEnabled = true;
            this.comboBoxReparticoes.Location = new System.Drawing.Point(520, 68);
            this.comboBoxReparticoes.Name = "comboBoxReparticoes";
            this.comboBoxReparticoes.Size = new System.Drawing.Size(299, 26);
            this.comboBoxReparticoes.TabIndex = 55;
            this.comboBoxReparticoes.TabStop = false;
            this.comboBoxReparticoes.SelectedIndexChanged += new System.EventHandler(this.comboBoxReparticoes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 59;
            this.label3.Text = "Estabelecimento:";
            // 
            // comboBoxEstabelecimentos
            // 
            this.comboBoxEstabelecimentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstabelecimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstabelecimentos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstabelecimentos.FormattingEnabled = true;
            this.comboBoxEstabelecimentos.Location = new System.Drawing.Point(137, 67);
            this.comboBoxEstabelecimentos.Name = "comboBoxEstabelecimentos";
            this.comboBoxEstabelecimentos.Size = new System.Drawing.Size(289, 26);
            this.comboBoxEstabelecimentos.TabIndex = 57;
            this.comboBoxEstabelecimentos.TabStop = false;
            this.comboBoxEstabelecimentos.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstabelecimentos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "Localização:";
            // 
            // comboBoxLocalizacoes
            // 
            this.comboBoxLocalizacoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocalizacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLocalizacoes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLocalizacoes.FormattingEnabled = true;
            this.comboBoxLocalizacoes.Location = new System.Drawing.Point(110, 106);
            this.comboBoxLocalizacoes.Name = "comboBoxLocalizacoes";
            this.comboBoxLocalizacoes.Size = new System.Drawing.Size(190, 26);
            this.comboBoxLocalizacoes.TabIndex = 56;
            this.comboBoxLocalizacoes.TabStop = false;
            this.comboBoxLocalizacoes.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocalizacoes_SelectedIndexChanged);
            // 
            // labelAtual
            // 
            this.labelAtual.AutoSize = true;
            this.labelAtual.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtual.Location = new System.Drawing.Point(766, 25);
            this.labelAtual.Name = "labelAtual";
            this.labelAtual.Size = new System.Drawing.Size(31, 22);
            this.labelAtual.TabIndex = 61;
            this.labelAtual.Text = "/ 0";
            // 
            // formProdutosLotesSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 533);
            this.Controls.Add(this.labelAtual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxReparticoes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxEstabelecimentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLocalizacoes);
            this.Controls.Add(this.dataGridViewLista);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.panelLinhaVermelha);
            this.Controls.Add(this.pictureBoxPesquisar);
            this.Controls.Add(this.textBoxPesquisa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "formProdutosLotesSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saídas";
            this.Load += new System.EventHandler(this.formProdutosLotesSaida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formProdutosLotesSaida_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLinhaVermelha;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox checkBoxFechar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.TextBox textBoxProdutos;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxReparticoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEstabelecimentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLocalizacoes;
        private System.Windows.Forms.Label labelAtual;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
    }
}