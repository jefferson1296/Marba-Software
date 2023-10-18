
namespace MarbaSoftware
{
    partial class formVendasCaixasAnteriores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendasCaixasAnteriores));
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.id_caixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quebra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBarra = new System.Windows.Forms.Panel();
            this.labelVendas = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fecharCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStripDataGrid.SuspendLayout();
            this.panelBarra.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoGenerateContextFilters = true;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 52;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_caixa,
            this.colaborador,
            this.data,
            this.Column2,
            this.Column3,
            this.status,
            this.quebra,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column15,
            this.Column14});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStripDataGrid;
            this.dataGridViewLista.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 71);
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
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1301, 549);
            this.dataGridViewLista.TabIndex = 37;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
            this.dataGridViewLista.SortStringChanged += new System.EventHandler(this.dataGridViewLista_SortStringChanged);
            this.dataGridViewLista.FilterStringChanged += new System.EventHandler(this.dataGridViewLista_FilterStringChanged);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // id_caixa
            // 
            this.id_caixa.DataPropertyName = "ID_Caixa";
            this.id_caixa.FillWeight = 50F;
            this.id_caixa.HeaderText = "N°";
            this.id_caixa.MinimumWidth = 22;
            this.id_caixa.Name = "id_caixa";
            this.id_caixa.ReadOnly = true;
            this.id_caixa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colaborador
            // 
            this.colaborador.DataPropertyName = "Colaborador";
            this.colaborador.FillWeight = 200F;
            this.colaborador.HeaderText = "Colaborador";
            this.colaborador.MinimumWidth = 22;
            this.colaborador.Name = "colaborador";
            this.colaborador.ReadOnly = true;
            this.colaborador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data
            // 
            this.data.DataPropertyName = "Data";
            this.data.FillWeight = 75F;
            this.data.HeaderText = "Data";
            this.data.MinimumWidth = 22;
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Abertura";
            this.Column2.FillWeight = 75F;
            this.Column2.HeaderText = "Abertura";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Fechamento";
            this.Column3.HeaderText = "Fechamento";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.FillWeight = 75F;
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 22;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // quebra
            // 
            this.quebra.DataPropertyName = "Quebra";
            this.quebra.HeaderText = "Quebra de caixa";
            this.quebra.MinimumWidth = 22;
            this.quebra.Name = "quebra";
            this.quebra.ReadOnly = true;
            this.quebra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Sangrias";
            this.Column5.HeaderText = "Sangrias";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Suprimentos";
            this.Column8.HeaderText = "Suprimentos";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Dinheiro";
            this.Column9.FillWeight = 75F;
            this.Column9.HeaderText = "Dinheiro";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Débito";
            this.Column10.FillWeight = 75F;
            this.Column10.HeaderText = "Débito";
            this.Column10.MinimumWidth = 22;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Crédito";
            this.Column11.HeaderText = "Crédito";
            this.Column11.MinimumWidth = 22;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Transferência";
            this.Column12.HeaderText = "Transferência";
            this.Column12.MinimumWidth = 22;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Pix";
            this.Column13.FillWeight = 75F;
            this.Column13.HeaderText = "Pix";
            this.Column13.MinimumWidth = 22;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "Vale";
            this.Column15.HeaderText = "Vale-troca";
            this.Column15.MinimumWidth = 22;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Picpay";
            this.Column14.FillWeight = 75F;
            this.Column14.HeaderText = "Picpay";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // contextMenuStripDataGrid
            // 
            this.contextMenuStripDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarVendaToolStripMenuItem,
            this.fecharCaixaToolStripMenuItem});
            this.contextMenuStripDataGrid.Name = "contextMenuStripDataGrid";
            this.contextMenuStripDataGrid.Size = new System.Drawing.Size(181, 70);
            // 
            // apagarVendaToolStripMenuItem
            // 
            this.apagarVendaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarVendaToolStripMenuItem.Image")));
            this.apagarVendaToolStripMenuItem.Name = "apagarVendaToolStripMenuItem";
            this.apagarVendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apagarVendaToolStripMenuItem.Text = "Apagar caixa";
            this.apagarVendaToolStripMenuItem.Click += new System.EventHandler(this.apagarVendaToolStripMenuItem_Click);
            // 
            // panelBarra
            // 
            this.panelBarra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBarra.BackgroundImage")));
            this.panelBarra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarra.Controls.Add(this.labelVendas);
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Location = new System.Drawing.Point(0, 43);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(1301, 28);
            this.panelBarra.TabIndex = 36;
            this.panelBarra.Resize += new System.EventHandler(this.panelBarra_Resize);
            // 
            // labelVendas
            // 
            this.labelVendas.AutoSize = true;
            this.labelVendas.BackColor = System.Drawing.Color.Transparent;
            this.labelVendas.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendas.Location = new System.Drawing.Point(539, 1);
            this.labelVendas.Name = "labelVendas";
            this.labelVendas.Size = new System.Drawing.Size(223, 24);
            this.labelVendas.TabIndex = 0;
            this.labelVendas.Text = "CAIXAS ANTERIORES";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.textBoxPesquisa);
            this.panel4.Controls.Add(this.pictureBoxPesquisar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1301, 43);
            this.panel4.TabIndex = 38;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(835, 7);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(413, 29);
            this.textBoxPesquisa.TabIndex = 28;
            this.textBoxPesquisa.Text = "Digite o número do caixa";
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
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(1254, 12);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 29;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // fecharCaixaToolStripMenuItem
            // 
            this.fecharCaixaToolStripMenuItem.Name = "fecharCaixaToolStripMenuItem";
            this.fecharCaixaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fecharCaixaToolStripMenuItem.Text = "Fechar caixa";
            this.fecharCaixaToolStripMenuItem.Click += new System.EventHandler(this.fecharCaixaToolStripMenuItem_Click);
            // 
            // formVendasCaixasAnteriores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 620);
            this.Controls.Add(this.dataGridViewLista);
            this.Controls.Add(this.panelBarra);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVendasCaixasAnteriores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixas Anteriores";
            this.Load += new System.EventHandler(this.formVendasCaixasAnteriores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStripDataGrid.ResumeLayout(false);
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView dataGridViewLista;
        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.Label labelVendas;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_caixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn quebra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGrid;
        private System.Windows.Forms.ToolStripMenuItem apagarVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharCaixaToolStripMenuItem;
    }
}