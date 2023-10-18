
namespace MarbaSoftware
{
    partial class formVendasCaixasAnterioresVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendasCaixasAnterioresVendas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.buttonSangrias = new System.Windows.Forms.Button();
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
            this.panelBarra = new System.Windows.Forms.Panel();
            this.pictureBoxEtiqueta = new System.Windows.Forms.PictureBox();
            this.labelVendas = new System.Windows.Forms.Label();
            this.bindingSourceVendas = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBoxTroco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxOutros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxCredito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxDebito = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.textBoxDinheiro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirCupomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendas)).BeginInit();
            this.panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVendas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStripDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxPesquisa);
            this.panel1.Controls.Add(this.pictureBoxPesquisar);
            this.panel1.Controls.Add(this.buttonRelatorio);
            this.panel1.Controls.Add(this.buttonSangrias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 57);
            this.panel1.TabIndex = 0;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(561, 15);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(413, 29);
            this.textBoxPesquisa.TabIndex = 40;
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
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(980, 20);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 41;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRelatorio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.BackgroundImage")));
            this.buttonRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRelatorio.FlatAppearance.BorderSize = 0;
            this.buttonRelatorio.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.ForeColor = System.Drawing.Color.Red;
            this.buttonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.Image")));
            this.buttonRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorio.Location = new System.Drawing.Point(235, 12);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonRelatorio.Size = new System.Drawing.Size(205, 38);
            this.buttonRelatorio.TabIndex = 38;
            this.buttonRelatorio.Text = "Relatório de Vendas";
            this.buttonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelatorio.UseVisualStyleBackColor = false;
            // 
            // buttonSangrias
            // 
            this.buttonSangrias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSangrias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSangrias.BackgroundImage")));
            this.buttonSangrias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSangrias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSangrias.FlatAppearance.BorderSize = 0;
            this.buttonSangrias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSangrias.ForeColor = System.Drawing.Color.Red;
            this.buttonSangrias.Image = ((System.Drawing.Image)(resources.GetObject("buttonSangrias.Image")));
            this.buttonSangrias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSangrias.Location = new System.Drawing.Point(12, 12);
            this.buttonSangrias.Name = "buttonSangrias";
            this.buttonSangrias.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonSangrias.Size = new System.Drawing.Size(205, 38);
            this.buttonSangrias.TabIndex = 39;
            this.buttonSangrias.Text = "Sangrias / Suprimentos";
            this.buttonSangrias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSangrias.UseVisualStyleBackColor = false;
            // 
            // dataGridVendas
            // 
            this.dataGridVendas.AllowUserToAddRows = false;
            this.dataGridVendas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVendas.AutoGenerateContextFilters = true;
            this.dataGridVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridVendas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridVendas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridVendas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
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
            this.dataGridVendas.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridVendas.Size = new System.Drawing.Size(1013, 404);
            this.dataGridVendas.TabIndex = 34;
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
            // panelBarra
            // 
            this.panelBarra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBarra.BackgroundImage")));
            this.panelBarra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarra.Controls.Add(this.pictureBoxEtiqueta);
            this.panelBarra.Controls.Add(this.labelVendas);
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Location = new System.Drawing.Point(0, 57);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(1013, 28);
            this.panelBarra.TabIndex = 33;
            this.panelBarra.Resize += new System.EventHandler(this.panelBarra_Resize);
            // 
            // pictureBoxEtiqueta
            // 
            this.pictureBoxEtiqueta.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEtiqueta.Image")));
            this.pictureBoxEtiqueta.Location = new System.Drawing.Point(420, 3);
            this.pictureBoxEtiqueta.Name = "pictureBoxEtiqueta";
            this.pictureBoxEtiqueta.Size = new System.Drawing.Size(23, 22);
            this.pictureBoxEtiqueta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEtiqueta.TabIndex = 1;
            this.pictureBoxEtiqueta.TabStop = false;
            // 
            // labelVendas
            // 
            this.labelVendas.AutoSize = true;
            this.labelVendas.BackColor = System.Drawing.Color.Transparent;
            this.labelVendas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendas.Location = new System.Drawing.Point(449, 1);
            this.labelVendas.Name = "labelVendas";
            this.labelVendas.Size = new System.Drawing.Size(170, 24);
            this.labelVendas.TabIndex = 0;
            this.labelVendas.Text = "VENDAS DO DIA";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.textBoxTroco);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.textBoxOutros);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.textBoxCredito);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.textBoxDebito);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.textBoxDinheiro);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 69);
            this.panel2.TabIndex = 36;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Khaki;
            this.panel7.Location = new System.Drawing.Point(891, 37);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(110, 1);
            this.panel7.TabIndex = 33;
            // 
            // textBoxTroco
            // 
            this.textBoxTroco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxTroco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTroco.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTroco.ForeColor = System.Drawing.Color.Red;
            this.textBoxTroco.Location = new System.Drawing.Point(891, 19);
            this.textBoxTroco.Name = "textBoxTroco";
            this.textBoxTroco.ReadOnly = true;
            this.textBoxTroco.Size = new System.Drawing.Size(110, 19);
            this.textBoxTroco.TabIndex = 32;
            this.textBoxTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(820, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "Troco:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Khaki;
            this.panel6.Location = new System.Drawing.Point(689, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 1);
            this.panel6.TabIndex = 30;
            // 
            // textBoxOutros
            // 
            this.textBoxOutros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxOutros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOutros.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutros.ForeColor = System.Drawing.Color.Red;
            this.textBoxOutros.Location = new System.Drawing.Point(689, 19);
            this.textBoxOutros.Name = "textBoxOutros";
            this.textBoxOutros.ReadOnly = true;
            this.textBoxOutros.Size = new System.Drawing.Size(110, 19);
            this.textBoxOutros.TabIndex = 29;
            this.textBoxOutros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(618, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Outros:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Khaki;
            this.panel5.Location = new System.Drawing.Point(488, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(110, 1);
            this.panel5.TabIndex = 27;
            // 
            // textBoxCredito
            // 
            this.textBoxCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxCredito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCredito.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCredito.ForeColor = System.Drawing.Color.Red;
            this.textBoxCredito.Location = new System.Drawing.Point(488, 19);
            this.textBoxCredito.Name = "textBoxCredito";
            this.textBoxCredito.ReadOnly = true;
            this.textBoxCredito.Size = new System.Drawing.Size(110, 19);
            this.textBoxCredito.TabIndex = 26;
            this.textBoxCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(417, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Crédito:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Khaki;
            this.panel4.Location = new System.Drawing.Point(290, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 1);
            this.panel4.TabIndex = 24;
            // 
            // textBoxDebito
            // 
            this.textBoxDebito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxDebito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDebito.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDebito.ForeColor = System.Drawing.Color.Red;
            this.textBoxDebito.Location = new System.Drawing.Point(290, 19);
            this.textBoxDebito.Name = "textBoxDebito";
            this.textBoxDebito.ReadOnly = true;
            this.textBoxDebito.Size = new System.Drawing.Size(110, 19);
            this.textBoxDebito.TabIndex = 23;
            this.textBoxDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Débito:";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Khaki;
            this.panel15.Location = new System.Drawing.Point(94, 38);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(110, 1);
            this.panel15.TabIndex = 21;
            // 
            // textBoxDinheiro
            // 
            this.textBoxDinheiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDinheiro.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDinheiro.ForeColor = System.Drawing.Color.Red;
            this.textBoxDinheiro.Location = new System.Drawing.Point(94, 20);
            this.textBoxDinheiro.Name = "textBoxDinheiro";
            this.textBoxDinheiro.ReadOnly = true;
            this.textBoxDinheiro.Size = new System.Drawing.Size(110, 19);
            this.textBoxDinheiro.TabIndex = 20;
            this.textBoxDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Dinheiro:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridVendas);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1013, 404);
            this.panel3.TabIndex = 37;
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
            // formVendasCaixasAnterioresVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 558);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBarra);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formVendasCaixasAnterioresVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.formVendasCaixasAnterioresVendas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendas)).EndInit();
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVendas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.contextMenuStripDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView dataGridVendas;
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
        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.PictureBox pictureBoxEtiqueta;
        private System.Windows.Forms.Label labelVendas;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonSangrias;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.BindingSource bindingSourceVendas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBoxTroco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxOutros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBoxCredito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxDebito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox textBoxDinheiro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGrid;
        private System.Windows.Forms.ToolStripMenuItem imprimirCupomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarVendaToolStripMenuItem;
    }
}