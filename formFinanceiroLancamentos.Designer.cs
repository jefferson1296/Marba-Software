
namespace MarbaSoftware
{
    partial class formFinanceiroLancamentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFinanceiroLancamentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVisualizar = new System.Windows.Forms.ComboBox();
            this.labelContas = new System.Windows.Forms.Label();
            this.buttonSaldo = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaida = new System.Windows.Forms.Button();
            this.buttonEntrada = new System.Windows.Forms.Button();
            this.buttonTranferencias = new System.Windows.Forms.Button();
            this.buttonSangrias = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonLicitacao = new System.Windows.Forms.Button();
            this.buttonRelatorios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSimulacoes = new System.Windows.Forms.Button();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.buttonExibir = new System.Windows.Forms.Button();
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.buttonMovimentacoes = new System.Windows.Forms.Button();
            this.buttonProLabore = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridViewFluxo = new ADGV.AdvancedDataGridView();
            this.ID_Movimentacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Prevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_Previsto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orcamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripFluxo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceFluxo = new System.Windows.Forms.BindingSource(this.components);
            this.timerFormatacao = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFluxo)).BeginInit();
            this.menuStripFluxo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.comboBoxVisualizar);
            this.panel1.Controls.Add(this.labelContas);
            this.panel1.Controls.Add(this.buttonSaldo);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 102);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxVisualizar
            // 
            this.comboBoxVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVisualizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxVisualizar.FormattingEnabled = true;
            this.comboBoxVisualizar.Items.AddRange(new object[] {
            "Visualizar apenas Lançamentos",
            "Visualizar apenas Orçamentos",
            "Visualizar Lançamentos e Orçamentos"});
            this.comboBoxVisualizar.Location = new System.Drawing.Point(1081, 67);
            this.comboBoxVisualizar.Name = "comboBoxVisualizar";
            this.comboBoxVisualizar.Size = new System.Drawing.Size(207, 21);
            this.comboBoxVisualizar.TabIndex = 86;
            this.comboBoxVisualizar.SelectedIndexChanged += new System.EventHandler(this.comboBoxVisualizar_SelectedIndexChanged);
            // 
            // labelContas
            // 
            this.labelContas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContas.AutoSize = true;
            this.labelContas.BackColor = System.Drawing.Color.Transparent;
            this.labelContas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContas.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelContas.Location = new System.Drawing.Point(1203, 51);
            this.labelContas.Name = "labelContas";
            this.labelContas.Size = new System.Drawing.Size(40, 13);
            this.labelContas.TabIndex = 85;
            this.labelContas.Text = "Contas";
            this.labelContas.Click += new System.EventHandler(this.labelContas_Click);
            // 
            // buttonSaldo
            // 
            this.buttonSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaldo.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaldo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSaldo.BackgroundImage")));
            this.buttonSaldo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaldo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaldo.ForeColor = System.Drawing.Color.White;
            this.buttonSaldo.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaldo.Image")));
            this.buttonSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaldo.Location = new System.Drawing.Point(1151, 11);
            this.buttonSaldo.Name = "buttonSaldo";
            this.buttonSaldo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSaldo.Size = new System.Drawing.Size(144, 40);
            this.buttonSaldo.TabIndex = 83;
            this.buttonSaldo.Text = "Ver Saldo";
            this.buttonSaldo.UseVisualStyleBackColor = false;
            this.buttonSaldo.Click += new System.EventHandler(this.buttonSaldo_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.22395F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.13064F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.56765F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPesquisa, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 61);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1286, 32);
            this.tableLayoutPanel2.TabIndex = 82;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(702, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(581, 2);
            this.panel5.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(552, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Lançamentos";
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(3, 3);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(537, 26);
            this.textBoxPesquisa.TabIndex = 67;
            this.textBoxPesquisa.Text = "Digite aqui para pesquisar";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPesquisa_KeyDown);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSaida, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonEntrada, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTranferencias, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSangrias, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 40);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // buttonSaida
            // 
            this.buttonSaida.BackColor = System.Drawing.Color.White;
            this.buttonSaida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSaida.BackgroundImage")));
            this.buttonSaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaida.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSaida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSaida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaida.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaida.ForeColor = System.Drawing.Color.White;
            this.buttonSaida.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaida.Image")));
            this.buttonSaida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaida.Location = new System.Drawing.Point(228, 3);
            this.buttonSaida.Name = "buttonSaida";
            this.buttonSaida.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSaida.Size = new System.Drawing.Size(219, 34);
            this.buttonSaida.TabIndex = 32;
            this.buttonSaida.Text = "Saída";
            this.buttonSaida.UseVisualStyleBackColor = false;
            this.buttonSaida.Click += new System.EventHandler(this.buttonSaida_Click);
            // 
            // buttonEntrada
            // 
            this.buttonEntrada.BackColor = System.Drawing.Color.White;
            this.buttonEntrada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEntrada.BackgroundImage")));
            this.buttonEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEntrada.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrada.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntrada.ForeColor = System.Drawing.Color.White;
            this.buttonEntrada.Image = ((System.Drawing.Image)(resources.GetObject("buttonEntrada.Image")));
            this.buttonEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEntrada.Location = new System.Drawing.Point(3, 3);
            this.buttonEntrada.Name = "buttonEntrada";
            this.buttonEntrada.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEntrada.Size = new System.Drawing.Size(219, 34);
            this.buttonEntrada.TabIndex = 19;
            this.buttonEntrada.Text = "Entrada";
            this.buttonEntrada.UseVisualStyleBackColor = false;
            this.buttonEntrada.Click += new System.EventHandler(this.buttonEntrada_Click);
            // 
            // buttonTranferencias
            // 
            this.buttonTranferencias.BackColor = System.Drawing.Color.White;
            this.buttonTranferencias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTranferencias.BackgroundImage")));
            this.buttonTranferencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTranferencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTranferencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTranferencias.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonTranferencias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTranferencias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonTranferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTranferencias.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranferencias.ForeColor = System.Drawing.Color.Black;
            this.buttonTranferencias.Image = ((System.Drawing.Image)(resources.GetObject("buttonTranferencias.Image")));
            this.buttonTranferencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTranferencias.Location = new System.Drawing.Point(453, 3);
            this.buttonTranferencias.Name = "buttonTranferencias";
            this.buttonTranferencias.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonTranferencias.Size = new System.Drawing.Size(219, 34);
            this.buttonTranferencias.TabIndex = 31;
            this.buttonTranferencias.Text = "Transferência";
            this.buttonTranferencias.UseVisualStyleBackColor = false;
            this.buttonTranferencias.Click += new System.EventHandler(this.buttonTranferencias_Click);
            // 
            // buttonSangrias
            // 
            this.buttonSangrias.BackColor = System.Drawing.Color.White;
            this.buttonSangrias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSangrias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSangrias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSangrias.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSangrias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSangrias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonSangrias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSangrias.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSangrias.ForeColor = System.Drawing.Color.Black;
            this.buttonSangrias.Image = ((System.Drawing.Image)(resources.GetObject("buttonSangrias.Image")));
            this.buttonSangrias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSangrias.Location = new System.Drawing.Point(678, 3);
            this.buttonSangrias.Name = "buttonSangrias";
            this.buttonSangrias.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSangrias.Size = new System.Drawing.Size(221, 34);
            this.buttonSangrias.TabIndex = 30;
            this.buttonSangrias.Text = "Sangrias e Suprimentos";
            this.buttonSangrias.UseVisualStyleBackColor = false;
            this.buttonSangrias.Click += new System.EventHandler(this.buttonSangrias_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1301, 3);
            this.panel2.TabIndex = 29;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1301, 10);
            this.panel6.TabIndex = 26;
            // 
            // buttonLicitacao
            // 
            this.buttonLicitacao.BackColor = System.Drawing.Color.MistyRose;
            this.buttonLicitacao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLicitacao.BackgroundImage")));
            this.buttonLicitacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLicitacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLicitacao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonLicitacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLicitacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonLicitacao.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLicitacao.ForeColor = System.Drawing.Color.White;
            this.buttonLicitacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLicitacao.Location = new System.Drawing.Point(444, 28);
            this.buttonLicitacao.Name = "buttonLicitacao";
            this.buttonLicitacao.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonLicitacao.Size = new System.Drawing.Size(177, 34);
            this.buttonLicitacao.TabIndex = 25;
            this.buttonLicitacao.Text = "Licitação";
            this.buttonLicitacao.UseVisualStyleBackColor = false;
            this.buttonLicitacao.Click += new System.EventHandler(this.buttonLicitacao_Click);
            // 
            // buttonRelatorios
            // 
            this.buttonRelatorios.BackColor = System.Drawing.Color.MistyRose;
            this.buttonRelatorios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRelatorios.BackgroundImage")));
            this.buttonRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRelatorios.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonRelatorios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRelatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonRelatorios.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorios.ForeColor = System.Drawing.Color.White;
            this.buttonRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorios.Location = new System.Drawing.Point(627, 28);
            this.buttonRelatorios.Name = "buttonRelatorios";
            this.buttonRelatorios.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonRelatorios.Size = new System.Drawing.Size(177, 34);
            this.buttonRelatorios.TabIndex = 23;
            this.buttonRelatorios.Text = "Relatórios";
            this.buttonRelatorios.UseVisualStyleBackColor = false;
            this.buttonRelatorios.Click += new System.EventHandler(this.buttonRelatorios_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.buttonSimulacoes);
            this.panel3.Controls.Add(this.buttonTodos);
            this.panel3.Controls.Add(this.buttonLicitacao);
            this.panel3.Controls.Add(this.buttonRelatorios);
            this.panel3.Controls.Add(this.buttonExibir);
            this.panel3.Controls.Add(this.textBoxRegistros);
            this.panel3.Controls.Add(this.buttonMovimentacoes);
            this.panel3.Controls.Add(this.buttonProLabore);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1301, 130);
            this.panel3.TabIndex = 1;
            // 
            // buttonSimulacoes
            // 
            this.buttonSimulacoes.BackColor = System.Drawing.Color.White;
            this.buttonSimulacoes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimulacoes.ForeColor = System.Drawing.Color.Red;
            this.buttonSimulacoes.Image = ((System.Drawing.Image)(resources.GetObject("buttonSimulacoes.Image")));
            this.buttonSimulacoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSimulacoes.Location = new System.Drawing.Point(247, 28);
            this.buttonSimulacoes.Name = "buttonSimulacoes";
            this.buttonSimulacoes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSimulacoes.Size = new System.Drawing.Size(127, 55);
            this.buttonSimulacoes.TabIndex = 51;
            this.buttonSimulacoes.Text = "Simulações";
            this.buttonSimulacoes.UseVisualStyleBackColor = false;
            this.buttonSimulacoes.Click += new System.EventHandler(this.buttonSimulacoes_Click);
            // 
            // buttonTodos
            // 
            this.buttonTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTodos.BackColor = System.Drawing.Color.White;
            this.buttonTodos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.Location = new System.Drawing.Point(1208, 6);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(87, 23);
            this.buttonTodos.TabIndex = 50;
            this.buttonTodos.Text = "Mostrar todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // buttonExibir
            // 
            this.buttonExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExibir.BackColor = System.Drawing.Color.White;
            this.buttonExibir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExibir.Location = new System.Drawing.Point(1127, 6);
            this.buttonExibir.Name = "buttonExibir";
            this.buttonExibir.Size = new System.Drawing.Size(75, 23);
            this.buttonExibir.TabIndex = 49;
            this.buttonExibir.Text = "Exibir";
            this.buttonExibir.UseVisualStyleBackColor = false;
            this.buttonExibir.Click += new System.EventHandler(this.buttonExibir_Click);
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegistros.Location = new System.Drawing.Point(1078, 8);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(43, 20);
            this.textBoxRegistros.TabIndex = 48;
            this.textBoxRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRegistros.Enter += new System.EventHandler(this.textBoxRegistros_Enter);
            this.textBoxRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRegistros_KeyPress);
            this.textBoxRegistros.Leave += new System.EventHandler(this.textBoxRegistros_Leave);
            // 
            // buttonMovimentacoes
            // 
            this.buttonMovimentacoes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonMovimentacoes.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovimentacoes.Location = new System.Drawing.Point(28, 28);
            this.buttonMovimentacoes.Name = "buttonMovimentacoes";
            this.buttonMovimentacoes.Size = new System.Drawing.Size(92, 55);
            this.buttonMovimentacoes.TabIndex = 6;
            this.buttonMovimentacoes.Text = "Movimentações do dia";
            this.buttonMovimentacoes.UseVisualStyleBackColor = false;
            this.buttonMovimentacoes.Click += new System.EventHandler(this.buttonMovimentacoes_Click);
            // 
            // buttonProLabore
            // 
            this.buttonProLabore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonProLabore.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProLabore.Location = new System.Drawing.Point(142, 28);
            this.buttonProLabore.Name = "buttonProLabore";
            this.buttonProLabore.Size = new System.Drawing.Size(77, 55);
            this.buttonProLabore.TabIndex = 5;
            this.buttonProLabore.Text = "Pró-labore";
            this.buttonProLabore.UseVisualStyleBackColor = false;
            this.buttonProLabore.Visible = false;
            this.buttonProLabore.Click += new System.EventHandler(this.buttonProLabore_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1301, 2);
            this.panel7.TabIndex = 3;
            // 
            // dataGridViewFluxo
            // 
            this.dataGridViewFluxo.AllowUserToAddRows = false;
            this.dataGridViewFluxo.AllowUserToDeleteRows = false;
            this.dataGridViewFluxo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewFluxo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFluxo.AutoGenerateContextFilters = true;
            this.dataGridViewFluxo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFluxo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFluxo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFluxo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewFluxo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFluxo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFluxo.ColumnHeadersHeight = 70;
            this.dataGridViewFluxo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewFluxo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Movimentacao,
            this.Column9,
            this.Categoria,
            this.Data_Prevista,
            this.Valor_Previsto,
            this.Column14,
            this.Valor,
            this.Column12,
            this.Column13,
            this.Orcamento});
            this.dataGridViewFluxo.ContextMenuStrip = this.menuStripFluxo;
            this.dataGridViewFluxo.DateWithTime = false;
            this.dataGridViewFluxo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFluxo.EnableHeadersVisualStyles = false;
            this.dataGridViewFluxo.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewFluxo.Location = new System.Drawing.Point(0, 102);
            this.dataGridViewFluxo.Name = "dataGridViewFluxo";
            this.dataGridViewFluxo.ReadOnly = true;
            this.dataGridViewFluxo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewFluxo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFluxo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFluxo.Size = new System.Drawing.Size(1301, 422);
            this.dataGridViewFluxo.TabIndex = 66;
            this.dataGridViewFluxo.TimeFilter = false;
            this.dataGridViewFluxo.SortStringChanged += new System.EventHandler(this.DataGridViewFluxo_SortStringChanged);
            this.dataGridViewFluxo.FilterStringChanged += new System.EventHandler(this.DataGridViewFluxo_FilterStringChanged);
            this.dataGridViewFluxo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFluxo_CellDoubleClick);
            this.dataGridViewFluxo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewFluxo_CellMouseDown);
            this.dataGridViewFluxo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewFluxo_CellPainting);
            this.dataGridViewFluxo.SelectionChanged += new System.EventHandler(this.dataGridViewFluxo_SelectionChanged);
            // 
            // ID_Movimentacao
            // 
            this.ID_Movimentacao.DataPropertyName = "ID_Movimentacao";
            this.ID_Movimentacao.FillWeight = 35F;
            this.ID_Movimentacao.HeaderText = "ID";
            this.ID_Movimentacao.MinimumWidth = 22;
            this.ID_Movimentacao.Name = "ID_Movimentacao";
            this.ID_Movimentacao.ReadOnly = true;
            this.ID_Movimentacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ID_Movimentacao.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Descricao";
            this.Column9.FillWeight = 300F;
            this.Column9.HeaderText = "Descrição";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 150F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 22;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Data_Prevista
            // 
            this.Data_Prevista.DataPropertyName = "Data_Prevista";
            this.Data_Prevista.FillWeight = 80F;
            this.Data_Prevista.HeaderText = "Data agendada";
            this.Data_Prevista.MinimumWidth = 22;
            this.Data_Prevista.Name = "Data_Prevista";
            this.Data_Prevista.ReadOnly = true;
            this.Data_Prevista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Valor_Previsto
            // 
            this.Valor_Previsto.DataPropertyName = "Valor_Previsto";
            this.Valor_Previsto.FillWeight = 80F;
            this.Valor_Previsto.HeaderText = "Valor a pagar";
            this.Valor_Previsto.MinimumWidth = 22;
            this.Valor_Previsto.Name = "Valor_Previsto";
            this.Valor_Previsto.ReadOnly = true;
            this.Valor_Previsto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Data";
            this.Column14.FillWeight = 80F;
            this.Column14.HeaderText = "Data realizada";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.FillWeight = 80F;
            this.Valor.HeaderText = "Valor pago";
            this.Valor.MinimumWidth = 22;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Conta";
            this.Column12.FillWeight = 130F;
            this.Column12.HeaderText = "Conta";
            this.Column12.MinimumWidth = 22;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Responsavel";
            this.Column13.HeaderText = "Responsável";
            this.Column13.MinimumWidth = 22;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Orcamento
            // 
            this.Orcamento.DataPropertyName = "Orcamento";
            this.Orcamento.HeaderText = "Orcamento";
            this.Orcamento.MinimumWidth = 22;
            this.Orcamento.Name = "Orcamento";
            this.Orcamento.ReadOnly = true;
            this.Orcamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Orcamento.Visible = false;
            // 
            // menuStripFluxo
            // 
            this.menuStripFluxo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.somatorioToolStripMenuItem});
            this.menuStripFluxo.Name = "menuStripFluxo";
            this.menuStripFluxo.Size = new System.Drawing.Size(130, 48);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // somatorioToolStripMenuItem
            // 
            this.somatorioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("somatorioToolStripMenuItem.Image")));
            this.somatorioToolStripMenuItem.Name = "somatorioToolStripMenuItem";
            this.somatorioToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.somatorioToolStripMenuItem.Text = "Somatório";
            this.somatorioToolStripMenuItem.Click += new System.EventHandler(this.somatorioToolStripMenuItem_Click);
            // 
            // timerFormatacao
            // 
            this.timerFormatacao.Tick += new System.EventHandler(this.timerFormatacao_Tick);
            // 
            // formFinanceiroLancamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 654);
            this.Controls.Add(this.dataGridViewFluxo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formFinanceiroLancamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formFinanceiroFluxo";
            this.Load += new System.EventHandler(this.formFinanceiroFluxo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFluxo)).EndInit();
            this.menuStripFluxo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonEntrada;
        private System.Windows.Forms.Button buttonRelatorios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonLicitacao;
        private System.Windows.Forms.BindingSource bindingSourceFluxo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ADGV.AdvancedDataGridView dataGridViewFluxo;
        private System.Windows.Forms.Button buttonSangrias;
        private System.Windows.Forms.Button buttonTranferencias;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonSaldo;
        private System.Windows.Forms.ContextMenuStrip menuStripFluxo;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.Button buttonProLabore;
        private System.Windows.Forms.Button buttonMovimentacoes;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.ToolStripMenuItem somatorioToolStripMenuItem;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonExibir;
        private System.Windows.Forms.TextBox textBoxRegistros;
        private System.Windows.Forms.Label labelContas;
        private System.Windows.Forms.Button buttonSimulacoes;
        private System.Windows.Forms.Button buttonSaida;
        private System.Windows.Forms.Timer timerFormatacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Movimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Prevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_Previsto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orcamento;
        private System.Windows.Forms.ComboBox comboBoxVisualizar;
    }
}