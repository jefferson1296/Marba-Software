
namespace MarbaSoftware
{
    partial class formVendasCaixaAtual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendasCaixaAtual));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBarra = new System.Windows.Forms.Panel();
            this.labelAbrir = new System.Windows.Forms.Label();
            this.pictureBoxEtiqueta = new System.Windows.Forms.PictureBox();
            this.labelVendas = new System.Windows.Forms.Label();
            this.dataGridVendas = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirCupomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNenhumaVenda = new System.Windows.Forms.Label();
            this.labelCaixaFechado = new System.Windows.Forms.Label();
            this.timerVerificar = new System.Windows.Forms.Timer(this.components);
            this.buttonAbrir = new System.Windows.Forms.Button();
            this.buttonFecharCaixa = new System.Windows.Forms.Button();
            this.buttonContador = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.buttonSangrias = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSourceVendas = new System.Windows.Forms.BindingSource(this.components);
            this.panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendas)).BeginInit();
            this.contextMenuStripDataGrid.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarra
            // 
            this.panelBarra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBarra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarra.Controls.Add(this.labelAbrir);
            this.panelBarra.Controls.Add(this.pictureBoxEtiqueta);
            this.panelBarra.Controls.Add(this.labelVendas);
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Location = new System.Drawing.Point(0, 50);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(1301, 28);
            this.panelBarra.TabIndex = 1;
            this.panelBarra.Resize += new System.EventHandler(this.panelBarra_Resize);
            // 
            // labelAbrir
            // 
            this.labelAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAbrir.AutoSize = true;
            this.labelAbrir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAbrir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbrir.Location = new System.Drawing.Point(1174, 5);
            this.labelAbrir.Name = "labelAbrir";
            this.labelAbrir.Size = new System.Drawing.Size(118, 17);
            this.labelAbrir.TabIndex = 2;
            this.labelAbrir.Text = "Abrir caixa registradora";
            this.labelAbrir.Click += new System.EventHandler(this.labelAbrir_Click);
            // 
            // pictureBoxEtiqueta
            // 
            this.pictureBoxEtiqueta.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEtiqueta.Image")));
            this.pictureBoxEtiqueta.Location = new System.Drawing.Point(527, 2);
            this.pictureBoxEtiqueta.Name = "pictureBoxEtiqueta";
            this.pictureBoxEtiqueta.Size = new System.Drawing.Size(23, 22);
            this.pictureBoxEtiqueta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEtiqueta.TabIndex = 1;
            this.pictureBoxEtiqueta.TabStop = false;
            // 
            // labelVendas
            // 
            this.labelVendas.AutoSize = true;
            this.labelVendas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendas.Location = new System.Drawing.Point(556, 0);
            this.labelVendas.Name = "labelVendas";
            this.labelVendas.Size = new System.Drawing.Size(170, 24);
            this.labelVendas.TabIndex = 0;
            this.labelVendas.Text = "VENDAS DO DIA";
            // 
            // dataGridVendas
            // 
            this.dataGridVendas.AllowUserToAddRows = false;
            this.dataGridVendas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVendas.AutoGenerateContextFilters = true;
            this.dataGridVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridVendas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column3,
            this.Column2,
            this.Column8,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10});
            this.dataGridVendas.ContextMenuStrip = this.contextMenuStripDataGrid;
            this.dataGridVendas.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVendas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVendas.EnableHeadersVisualStyles = false;
            this.dataGridVendas.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridVendas.Location = new System.Drawing.Point(0, 78);
            this.dataGridVendas.Name = "dataGridVendas";
            this.dataGridVendas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridVendas.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridVendas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVendas.Size = new System.Drawing.Size(1301, 542);
            this.dataGridVendas.TabIndex = 32;
            this.dataGridVendas.TabStop = false;
            this.dataGridVendas.TimeFilter = false;
            this.dataGridVendas.SortStringChanged += new System.EventHandler(this.dataGridVendas_SortStringChanged);
            this.dataGridVendas.FilterStringChanged += new System.EventHandler(this.dataGridVendas_FilterStringChanged);
            this.dataGridVendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVendas_CellDoubleClick);
            this.dataGridVendas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridVendas_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID_Venda";
            this.Column1.FillWeight = 65F;
            this.Column1.HeaderText = "N° Venda";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Hora";
            this.Column7.HeaderText = "Hora";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Pagamento";
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "Forma de Pagamento";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Valor";
            this.Column2.HeaderText = "Valor (R$)";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Troco";
            this.Column8.HeaderText = "Troco (R$)";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Desconto";
            this.Column9.HeaderText = "Desconto (R$)";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quantidade";
            this.Column4.HeaderText = "Qtd. Produtos";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Cliente";
            this.Column5.FillWeight = 160F;
            this.Column5.HeaderText = "Cliente";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Data";
            this.Column6.HeaderText = "Data";
            this.Column6.MinimumWidth = 22;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Operador";
            this.Column10.FillWeight = 160F;
            this.Column10.HeaderText = "Operador";
            this.Column10.MinimumWidth = 22;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // contextMenuStripDataGrid
            // 
            this.contextMenuStripDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirCupomToolStripMenuItem,
            this.apagarVendaToolStripMenuItem});
            this.contextMenuStripDataGrid.Name = "contextMenuStripDataGrid";
            this.contextMenuStripDataGrid.Size = new System.Drawing.Size(164, 48);
            // 
            // imprimirCupomToolStripMenuItem
            // 
            this.imprimirCupomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirCupomToolStripMenuItem.Image")));
            this.imprimirCupomToolStripMenuItem.Name = "imprimirCupomToolStripMenuItem";
            this.imprimirCupomToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.imprimirCupomToolStripMenuItem.Text = "Imprimir Cupom";
            this.imprimirCupomToolStripMenuItem.Click += new System.EventHandler(this.imprimirCupomToolStripMenuItem_Click);
            // 
            // apagarVendaToolStripMenuItem
            // 
            this.apagarVendaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarVendaToolStripMenuItem.Image")));
            this.apagarVendaToolStripMenuItem.Name = "apagarVendaToolStripMenuItem";
            this.apagarVendaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.apagarVendaToolStripMenuItem.Text = "Apagar venda";
            this.apagarVendaToolStripMenuItem.Click += new System.EventHandler(this.apagarVendaToolStripMenuItem_Click);
            // 
            // labelNenhumaVenda
            // 
            this.labelNenhumaVenda.AutoSize = true;
            this.labelNenhumaVenda.BackColor = System.Drawing.Color.White;
            this.labelNenhumaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNenhumaVenda.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelNenhumaVenda.Location = new System.Drawing.Point(493, 344);
            this.labelNenhumaVenda.Name = "labelNenhumaVenda";
            this.labelNenhumaVenda.Size = new System.Drawing.Size(315, 20);
            this.labelNenhumaVenda.TabIndex = 33;
            this.labelNenhumaVenda.Text = "Nenhuma venda registrada até o momento.\r\n";
            this.labelNenhumaVenda.Visible = false;
            // 
            // labelCaixaFechado
            // 
            this.labelCaixaFechado.AutoSize = true;
            this.labelCaixaFechado.BackColor = System.Drawing.Color.White;
            this.labelCaixaFechado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaixaFechado.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCaixaFechado.Location = new System.Drawing.Point(593, 344);
            this.labelCaixaFechado.Name = "labelCaixaFechado";
            this.labelCaixaFechado.Size = new System.Drawing.Size(114, 20);
            this.labelCaixaFechado.TabIndex = 34;
            this.labelCaixaFechado.Text = "Caixa fechado.";
            this.labelCaixaFechado.Visible = false;
            // 
            // timerVerificar
            // 
            this.timerVerificar.Interval = 1;
            this.timerVerificar.Tick += new System.EventHandler(this.timerVerificar_Tick);
            // 
            // buttonAbrir
            // 
            this.buttonAbrir.BackColor = System.Drawing.Color.Red;
            this.buttonAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAbrir.FlatAppearance.BorderSize = 0;
            this.buttonAbrir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbrir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAbrir.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbrir.Image")));
            this.buttonAbrir.Location = new System.Drawing.Point(6, 3);
            this.buttonAbrir.Name = "buttonAbrir";
            this.buttonAbrir.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonAbrir.Size = new System.Drawing.Size(205, 38);
            this.buttonAbrir.TabIndex = 33;
            this.buttonAbrir.Text = "Abrir Caixa";
            this.buttonAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAbrir.UseVisualStyleBackColor = false;
            this.buttonAbrir.Click += new System.EventHandler(this.buttonAbrir_Click);
            // 
            // buttonFecharCaixa
            // 
            this.buttonFecharCaixa.BackColor = System.Drawing.Color.Red;
            this.buttonFecharCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFecharCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFecharCaixa.FlatAppearance.BorderSize = 0;
            this.buttonFecharCaixa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFecharCaixa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("buttonFecharCaixa.Image")));
            this.buttonFecharCaixa.Location = new System.Drawing.Point(5, 3);
            this.buttonFecharCaixa.Name = "buttonFecharCaixa";
            this.buttonFecharCaixa.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonFecharCaixa.Size = new System.Drawing.Size(205, 38);
            this.buttonFecharCaixa.TabIndex = 34;
            this.buttonFecharCaixa.Text = "Fechar Caixa";
            this.buttonFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFecharCaixa.UseVisualStyleBackColor = false;
            this.buttonFecharCaixa.Click += new System.EventHandler(this.buttonFecharCaixa_Click);
            // 
            // buttonContador
            // 
            this.buttonContador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonContador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContador.FlatAppearance.BorderSize = 0;
            this.buttonContador.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContador.ForeColor = System.Drawing.Color.Red;
            this.buttonContador.Image = ((System.Drawing.Image)(resources.GetObject("buttonContador.Image")));
            this.buttonContador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonContador.Location = new System.Drawing.Point(415, 3);
            this.buttonContador.Name = "buttonContador";
            this.buttonContador.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonContador.Size = new System.Drawing.Size(205, 38);
            this.buttonContador.TabIndex = 2;
            this.buttonContador.Text = "Contador de Moedas";
            this.buttonContador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonContador.UseVisualStyleBackColor = false;
            this.buttonContador.Click += new System.EventHandler(this.buttonContador_Click);
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRelatorio.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRelatorio.FlatAppearance.BorderSize = 0;
            this.buttonRelatorio.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.ForeColor = System.Drawing.Color.Red;
            this.buttonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.Image")));
            this.buttonRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorio.Location = new System.Drawing.Point(620, 3);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonRelatorio.Size = new System.Drawing.Size(205, 38);
            this.buttonRelatorio.TabIndex = 3;
            this.buttonRelatorio.Text = "Relatório de Vendas";
            this.buttonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelatorio.UseVisualStyleBackColor = false;
            this.buttonRelatorio.Click += new System.EventHandler(this.buttonRelatorio_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.imprimirToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.imprimirToolStripMenuItem.Text = "Visualizar";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem1
            // 
            this.imprimirToolStripMenuItem1.Name = "imprimirToolStripMenuItem1";
            this.imprimirToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.imprimirToolStripMenuItem1.Text = "Imprimir";
            this.imprimirToolStripMenuItem1.Click += new System.EventHandler(this.imprimirToolStripMenuItem1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1301, 7);
            this.panel3.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.textBoxPesquisa);
            this.panel4.Controls.Add(this.pictureBoxPesquisar);
            this.panel4.Controls.Add(this.buttonRelatorio);
            this.panel4.Controls.Add(this.buttonContador);
            this.panel4.Controls.Add(this.buttonSangrias);
            this.panel4.Controls.Add(this.buttonFecharCaixa);
            this.panel4.Controls.Add(this.buttonAbrir);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1301, 43);
            this.panel4.TabIndex = 35;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(835, 3);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(413, 29);
            this.textBoxPesquisa.TabIndex = 28;
            this.textBoxPesquisa.Text = "Digite o número da venda";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPesquisa_KeyPress);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(1254, 8);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 29;
            this.pictureBoxPesquisar.TabStop = false;
            this.pictureBoxPesquisar.Click += new System.EventHandler(this.pictureBoxPesquisar_Click);
            // 
            // buttonSangrias
            // 
            this.buttonSangrias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSangrias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSangrias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSangrias.FlatAppearance.BorderSize = 0;
            this.buttonSangrias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSangrias.ForeColor = System.Drawing.Color.Red;
            this.buttonSangrias.Image = ((System.Drawing.Image)(resources.GetObject("buttonSangrias.Image")));
            this.buttonSangrias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSangrias.Location = new System.Drawing.Point(210, 3);
            this.buttonSangrias.Name = "buttonSangrias";
            this.buttonSangrias.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonSangrias.Size = new System.Drawing.Size(205, 38);
            this.buttonSangrias.TabIndex = 37;
            this.buttonSangrias.Text = "Sangrias / Suprimentos";
            this.buttonSangrias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSangrias.UseVisualStyleBackColor = false;
            this.buttonSangrias.Click += new System.EventHandler(this.buttonSangrias_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 50);
            this.panel1.TabIndex = 0;
            // 
            // formVendasCaixaAtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 620);
            this.Controls.Add(this.labelCaixaFechado);
            this.Controls.Add(this.labelNenhumaVenda);
            this.Controls.Add(this.dataGridVendas);
            this.Controls.Add(this.panelBarra);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVendasCaixaAtual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formVendasCaixaAtual";
            this.Load += new System.EventHandler(this.formVendasCaixaAtual_Load);
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendas)).EndInit();
            this.contextMenuStripDataGrid.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.PictureBox pictureBoxEtiqueta;
        private System.Windows.Forms.Label labelVendas;
        private ADGV.AdvancedDataGridView dataGridVendas;
        public System.Windows.Forms.Label labelNenhumaVenda;
        public System.Windows.Forms.Label labelCaixaFechado;
        private System.Windows.Forms.BindingSource bindingSourceVendas;
        private System.Windows.Forms.Timer timerVerificar;
        public System.Windows.Forms.Button buttonAbrir;
        public System.Windows.Forms.Button buttonFecharCaixa;
        private System.Windows.Forms.Button buttonContador;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSangrias;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGrid;
        private System.Windows.Forms.ToolStripMenuItem imprimirCupomToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ToolStripMenuItem apagarVendaToolStripMenuItem;
        private System.Windows.Forms.Label labelAbrir;
    }
}