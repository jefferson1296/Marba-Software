
namespace MarbaSoftware
{
    partial class formProdutosLotes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotes));
            this.dataGridProdutos = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.avariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extravioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localizarQuantidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.buttonAcabamentos = new System.Windows.Forms.Button();
            this.buttonPrateleiras = new System.Windows.Forms.Button();
            this.buttonPedidos = new System.Windows.Forms.Button();
            this.buttonTrocados = new System.Windows.Forms.Button();
            this.buttonAvarias = new System.Windows.Forms.Button();
            this.buttonUnidades = new System.Windows.Forms.Button();
            this.buttonPecas = new System.Windows.Forms.Button();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.buttonSaida = new System.Windows.Forms.Button();
            this.buttonSaidas = new System.Windows.Forms.Button();
            this.buttonTransferencias = new System.Windows.Forms.Button();
            this.buttonEntradas = new System.Windows.Forms.Button();
            this.buttonQuarentena = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblProdutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.buttonExibir = new System.Windows.Forms.Button();
            this.buttonTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutos)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblProdutosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProdutos
            // 
            this.dataGridProdutos.AllowUserToAddRows = false;
            this.dataGridProdutos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridProdutos.AutoGenerateContextFilters = true;
            this.dataGridProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridProdutos.ColumnHeadersHeight = 48;
            this.dataGridProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Cod_Barras,
            this.Nome_Produto,
            this.Column3,
            this.Fabricante,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridProdutos.ContextMenuStrip = this.menuStrip;
            this.dataGridProdutos.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridProdutos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProdutos.EnableHeadersVisualStyles = false;
            this.dataGridProdutos.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridProdutos.Location = new System.Drawing.Point(0, 0);
            this.dataGridProdutos.Name = "dataGridProdutos";
            this.dataGridProdutos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridProdutos.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridProdutos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProdutos.Size = new System.Drawing.Size(1370, 477);
            this.dataGridProdutos.TabIndex = 31;
            this.dataGridProdutos.TabStop = false;
            this.dataGridProdutos.TimeFilter = false;
            this.dataGridProdutos.SortStringChanged += new System.EventHandler(this.dataGridProdutos_SortStringChanged);
            this.dataGridProdutos.FilterStringChanged += new System.EventHandler(this.dataGridProdutos_FilterStringChanged);
            this.dataGridProdutos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridProdutos_CellFormatting);
            this.dataGridProdutos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridProdutos_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "N° Produto";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ID_Lote";
            this.Column6.FillWeight = 30F;
            this.Column6.HeaderText = "Lote";
            this.Column6.MinimumWidth = 22;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Cod_Barras
            // 
            this.Cod_Barras.DataPropertyName = "Cod_Barras";
            this.Cod_Barras.HeaderText = "Código de barras";
            this.Cod_Barras.MinimumWidth = 22;
            this.Cod_Barras.Name = "Cod_Barras";
            this.Cod_Barras.ReadOnly = true;
            this.Cod_Barras.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Nome_Produto
            // 
            this.Nome_Produto.DataPropertyName = "Produto";
            this.Nome_Produto.FillWeight = 380F;
            this.Nome_Produto.HeaderText = "Produto";
            this.Nome_Produto.MinimumWidth = 22;
            this.Nome_Produto.Name = "Nome_Produto";
            this.Nome_Produto.ReadOnly = true;
            this.Nome_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantidade";
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "Quantidade";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Fabricante
            // 
            this.Fabricante.DataPropertyName = "Fornecedor";
            this.Fabricante.FillWeight = 130F;
            this.Fabricante.HeaderText = "Fornecedor";
            this.Fabricante.MinimumWidth = 22;
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            this.Fabricante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Localizacao";
            this.Column2.HeaderText = "Localização";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Status";
            this.Column4.FillWeight = 120F;
            this.Column4.HeaderText = "Status";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Disponibilidade";
            this.Column5.FillWeight = 30F;
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avariaToolStripMenuItem,
            this.extravioToolStripMenuItem,
            this.historicoToolStripMenuItem,
            this.localizarQuantidadesToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(189, 92);
            // 
            // avariaToolStripMenuItem
            // 
            this.avariaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("avariaToolStripMenuItem.Image")));
            this.avariaToolStripMenuItem.Name = "avariaToolStripMenuItem";
            this.avariaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.avariaToolStripMenuItem.Text = "Registrar avaria";
            this.avariaToolStripMenuItem.Click += new System.EventHandler(this.avariaToolStripMenuItem_Click);
            // 
            // extravioToolStripMenuItem
            // 
            this.extravioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extravioToolStripMenuItem.Image")));
            this.extravioToolStripMenuItem.Name = "extravioToolStripMenuItem";
            this.extravioToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.extravioToolStripMenuItem.Text = "Registrar extravio";
            this.extravioToolStripMenuItem.Click += new System.EventHandler(this.extravioToolStripMenuItem_Click);
            // 
            // historicoToolStripMenuItem
            // 
            this.historicoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("historicoToolStripMenuItem.Image")));
            this.historicoToolStripMenuItem.Name = "historicoToolStripMenuItem";
            this.historicoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.historicoToolStripMenuItem.Text = "Histórico";
            this.historicoToolStripMenuItem.Click += new System.EventHandler(this.historicoToolStripMenuItem_Click);
            // 
            // localizarQuantidadesToolStripMenuItem
            // 
            this.localizarQuantidadesToolStripMenuItem.Name = "localizarQuantidadesToolStripMenuItem";
            this.localizarQuantidadesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.localizarQuantidadesToolStripMenuItem.Text = "Localizar quantidades";
            this.localizarQuantidadesToolStripMenuItem.Click += new System.EventHandler(this.localizarQuantidadesToolStripMenuItem_Click);
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(591, 39);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 33;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.IndianRed;
            this.textBoxPesquisa.Location = new System.Drawing.Point(23, 36);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(565, 29);
            this.textBoxPesquisa.TabIndex = 32;
            this.textBoxPesquisa.Text = "Digite aqui para pesquisar";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPesquisa_KeyDown);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.buttonTodos);
            this.panelInferior.Controls.Add(this.buttonExibir);
            this.panelInferior.Controls.Add(this.textBoxRegistros);
            this.panelInferior.Controls.Add(this.buttonAcabamentos);
            this.panelInferior.Controls.Add(this.buttonPrateleiras);
            this.panelInferior.Controls.Add(this.buttonPedidos);
            this.panelInferior.Controls.Add(this.buttonTrocados);
            this.panelInferior.Controls.Add(this.buttonAvarias);
            this.panelInferior.Controls.Add(this.buttonUnidades);
            this.panelInferior.Controls.Add(this.buttonPecas);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 559);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1370, 100);
            this.panelInferior.TabIndex = 34;
            // 
            // buttonAcabamentos
            // 
            this.buttonAcabamentos.BackColor = System.Drawing.Color.White;
            this.buttonAcabamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcabamentos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcabamentos.ForeColor = System.Drawing.Color.Red;
            this.buttonAcabamentos.Location = new System.Drawing.Point(554, 59);
            this.buttonAcabamentos.Name = "buttonAcabamentos";
            this.buttonAcabamentos.Size = new System.Drawing.Size(143, 29);
            this.buttonAcabamentos.TabIndex = 44;
            this.buttonAcabamentos.Text = "Acabamentos";
            this.buttonAcabamentos.UseVisualStyleBackColor = false;
            this.buttonAcabamentos.Click += new System.EventHandler(this.buttonAcabamentos_Click);
            // 
            // buttonPrateleiras
            // 
            this.buttonPrateleiras.BackColor = System.Drawing.Color.White;
            this.buttonPrateleiras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrateleiras.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrateleiras.ForeColor = System.Drawing.Color.Red;
            this.buttonPrateleiras.Location = new System.Drawing.Point(23, 45);
            this.buttonPrateleiras.Name = "buttonPrateleiras";
            this.buttonPrateleiras.Size = new System.Drawing.Size(143, 29);
            this.buttonPrateleiras.TabIndex = 43;
            this.buttonPrateleiras.Text = "Prateleiras";
            this.buttonPrateleiras.UseVisualStyleBackColor = false;
            this.buttonPrateleiras.Click += new System.EventHandler(this.buttonPrateleiras_Click);
            // 
            // buttonPedidos
            // 
            this.buttonPedidos.BackColor = System.Drawing.Color.Red;
            this.buttonPedidos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPedidos.BackgroundImage")));
            this.buttonPedidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPedidos.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonPedidos.FlatAppearance.BorderSize = 2;
            this.buttonPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonPedidos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPedidos.ForeColor = System.Drawing.Color.White;
            this.buttonPedidos.Image = ((System.Drawing.Image)(resources.GetObject("buttonPedidos.Image")));
            this.buttonPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPedidos.Location = new System.Drawing.Point(340, 59);
            this.buttonPedidos.Name = "buttonPedidos";
            this.buttonPedidos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonPedidos.Size = new System.Drawing.Size(143, 29);
            this.buttonPedidos.TabIndex = 42;
            this.buttonPedidos.Text = "Pedidos";
            this.buttonPedidos.UseVisualStyleBackColor = false;
            this.buttonPedidos.Click += new System.EventHandler(this.buttonPedidos_Click);
            // 
            // buttonTrocados
            // 
            this.buttonTrocados.BackColor = System.Drawing.Color.White;
            this.buttonTrocados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTrocados.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrocados.ForeColor = System.Drawing.Color.Red;
            this.buttonTrocados.Location = new System.Drawing.Point(1051, 59);
            this.buttonTrocados.Name = "buttonTrocados";
            this.buttonTrocados.Size = new System.Drawing.Size(143, 29);
            this.buttonTrocados.TabIndex = 41;
            this.buttonTrocados.Text = "Produtos trocados";
            this.buttonTrocados.UseVisualStyleBackColor = false;
            this.buttonTrocados.Click += new System.EventHandler(this.buttonTrocados_Click);
            // 
            // buttonAvarias
            // 
            this.buttonAvarias.BackColor = System.Drawing.Color.White;
            this.buttonAvarias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAvarias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAvarias.ForeColor = System.Drawing.Color.Red;
            this.buttonAvarias.Location = new System.Drawing.Point(1210, 59);
            this.buttonAvarias.Name = "buttonAvarias";
            this.buttonAvarias.Size = new System.Drawing.Size(143, 29);
            this.buttonAvarias.TabIndex = 40;
            this.buttonAvarias.Text = "Avaliação de avarias";
            this.buttonAvarias.UseVisualStyleBackColor = false;
            // 
            // buttonUnidades
            // 
            this.buttonUnidades.BackColor = System.Drawing.Color.White;
            this.buttonUnidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUnidades.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnidades.ForeColor = System.Drawing.Color.Red;
            this.buttonUnidades.Location = new System.Drawing.Point(887, 59);
            this.buttonUnidades.Name = "buttonUnidades";
            this.buttonUnidades.Size = new System.Drawing.Size(143, 29);
            this.buttonUnidades.TabIndex = 39;
            this.buttonUnidades.Text = "Últimas unidades";
            this.buttonUnidades.UseVisualStyleBackColor = false;
            this.buttonUnidades.Click += new System.EventHandler(this.buttonUnidades_Click);
            // 
            // buttonPecas
            // 
            this.buttonPecas.BackColor = System.Drawing.Color.White;
            this.buttonPecas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPecas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPecas.ForeColor = System.Drawing.Color.Red;
            this.buttonPecas.Location = new System.Drawing.Point(722, 59);
            this.buttonPecas.Name = "buttonPecas";
            this.buttonPecas.Size = new System.Drawing.Size(143, 29);
            this.buttonPecas.TabIndex = 38;
            this.buttonPecas.Text = "Peças soltas";
            this.buttonPecas.UseVisualStyleBackColor = false;
            this.buttonPecas.Click += new System.EventHandler(this.buttonPecas_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.buttonSaida);
            this.panelSuperior.Controls.Add(this.buttonSaidas);
            this.panelSuperior.Controls.Add(this.buttonTransferencias);
            this.panelSuperior.Controls.Add(this.buttonEntradas);
            this.panelSuperior.Controls.Add(this.buttonQuarentena);
            this.panelSuperior.Controls.Add(this.textBoxPesquisa);
            this.panelSuperior.Controls.Add(this.pictureBoxPesquisar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1370, 82);
            this.panelSuperior.TabIndex = 36;
            // 
            // buttonSaida
            // 
            this.buttonSaida.Location = new System.Drawing.Point(682, 39);
            this.buttonSaida.Name = "buttonSaida";
            this.buttonSaida.Size = new System.Drawing.Size(75, 23);
            this.buttonSaida.TabIndex = 38;
            this.buttonSaida.Text = "Saída";
            this.buttonSaida.UseVisualStyleBackColor = true;
            this.buttonSaida.Click += new System.EventHandler(this.buttonSaida_Click);
            // 
            // buttonSaidas
            // 
            this.buttonSaidas.BackColor = System.Drawing.Color.White;
            this.buttonSaidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaidas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaidas.ForeColor = System.Drawing.Color.Red;
            this.buttonSaidas.Location = new System.Drawing.Point(1219, 36);
            this.buttonSaidas.Name = "buttonSaidas";
            this.buttonSaidas.Size = new System.Drawing.Size(143, 29);
            this.buttonSaidas.TabIndex = 37;
            this.buttonSaidas.Text = "Saídas";
            this.buttonSaidas.UseVisualStyleBackColor = false;
            this.buttonSaidas.Click += new System.EventHandler(this.buttonSaidas_Click);
            // 
            // buttonTransferencias
            // 
            this.buttonTransferencias.BackColor = System.Drawing.Color.White;
            this.buttonTransferencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTransferencias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransferencias.ForeColor = System.Drawing.Color.Red;
            this.buttonTransferencias.Location = new System.Drawing.Point(921, 36);
            this.buttonTransferencias.Name = "buttonTransferencias";
            this.buttonTransferencias.Size = new System.Drawing.Size(143, 29);
            this.buttonTransferencias.TabIndex = 36;
            this.buttonTransferencias.Text = "Transferências";
            this.buttonTransferencias.UseVisualStyleBackColor = false;
            this.buttonTransferencias.Click += new System.EventHandler(this.buttonTransferencias_Click);
            // 
            // buttonEntradas
            // 
            this.buttonEntradas.BackColor = System.Drawing.Color.White;
            this.buttonEntradas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEntradas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntradas.ForeColor = System.Drawing.Color.Red;
            this.buttonEntradas.Location = new System.Drawing.Point(1070, 36);
            this.buttonEntradas.Name = "buttonEntradas";
            this.buttonEntradas.Size = new System.Drawing.Size(143, 29);
            this.buttonEntradas.TabIndex = 35;
            this.buttonEntradas.Text = "Entradas";
            this.buttonEntradas.UseVisualStyleBackColor = false;
            this.buttonEntradas.Click += new System.EventHandler(this.buttonEntradas_Click);
            // 
            // buttonQuarentena
            // 
            this.buttonQuarentena.BackColor = System.Drawing.Color.White;
            this.buttonQuarentena.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuarentena.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuarentena.ForeColor = System.Drawing.Color.Red;
            this.buttonQuarentena.Location = new System.Drawing.Point(772, 36);
            this.buttonQuarentena.Name = "buttonQuarentena";
            this.buttonQuarentena.Size = new System.Drawing.Size(143, 29);
            this.buttonQuarentena.TabIndex = 34;
            this.buttonQuarentena.Text = "Quarentena";
            this.buttonQuarentena.UseVisualStyleBackColor = false;
            this.buttonQuarentena.Click += new System.EventHandler(this.buttonQuarentena_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridProdutos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 477);
            this.panel2.TabIndex = 37;
            // 
            // tblProdutosBindingSource
            // 
            this.tblProdutosBindingSource.DataMember = "tbl_ProdutosLote";
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Location = new System.Drawing.Point(1136, 21);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(43, 20);
            this.textBoxRegistros.TabIndex = 45;
            this.textBoxRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRegistros.Enter += new System.EventHandler(this.textBoxRegistros_Enter);
            this.textBoxRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRegistros_KeyPress);
            this.textBoxRegistros.Leave += new System.EventHandler(this.textBoxRegistros_Leave);
            // 
            // buttonExibir
            // 
            this.buttonExibir.BackColor = System.Drawing.Color.White;
            this.buttonExibir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExibir.Location = new System.Drawing.Point(1185, 19);
            this.buttonExibir.Name = "buttonExibir";
            this.buttonExibir.Size = new System.Drawing.Size(75, 23);
            this.buttonExibir.TabIndex = 46;
            this.buttonExibir.Text = "Exibir";
            this.buttonExibir.UseVisualStyleBackColor = false;
            this.buttonExibir.Click += new System.EventHandler(this.buttonExibir_Click);
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.White;
            this.buttonTodos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.Location = new System.Drawing.Point(1266, 19);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(87, 23);
            this.buttonTodos.TabIndex = 47;
            this.buttonTodos.Text = "Mostrar todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // formProdutosLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 659);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotes";
            this.Load += new System.EventHandler(this.formProdutosLotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutos)).EndInit();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblProdutosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView dataGridProdutos;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        public System.Windows.Forms.BindingSource tblProdutosBindingSource;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonQuarentena;
        private System.Windows.Forms.Button buttonSaidas;
        private System.Windows.Forms.Button buttonTransferencias;
        private System.Windows.Forms.Button buttonEntradas;
        private System.Windows.Forms.Button buttonAvarias;
        private System.Windows.Forms.Button buttonUnidades;
        private System.Windows.Forms.Button buttonPecas;
        private System.Windows.Forms.Button buttonTrocados;
        private System.Windows.Forms.Button buttonPedidos;
        private System.Windows.Forms.Button buttonPrateleiras;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem historicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extravioToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaida;
        private System.Windows.Forms.Button buttonAcabamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem localizarQuantidadesToolStripMenuItem;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonExibir;
        private System.Windows.Forms.TextBox textBoxRegistros;
    }
}