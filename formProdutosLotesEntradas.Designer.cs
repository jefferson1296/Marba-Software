
namespace MarbaSoftware
{
    partial class formProdutosLotesEntradas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesEntradas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonEntrada = new System.Windows.Forms.Button();
            this.buttonAjuste = new System.Windows.Forms.Button();
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confirmarRecebimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binding = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRegistros = new System.Windows.Forms.Button();
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.excluirLoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEntrada
            // 
            this.buttonEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEntrada.BackColor = System.Drawing.Color.Red;
            this.buttonEntrada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEntrada.BackgroundImage")));
            this.buttonEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEntrada.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonEntrada.FlatAppearance.BorderSize = 2;
            this.buttonEntrada.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntrada.ForeColor = System.Drawing.Color.White;
            this.buttonEntrada.Location = new System.Drawing.Point(930, 12);
            this.buttonEntrada.Name = "buttonEntrada";
            this.buttonEntrada.Size = new System.Drawing.Size(180, 28);
            this.buttonEntrada.TabIndex = 429;
            this.buttonEntrada.Text = "Dar entrada";
            this.buttonEntrada.UseVisualStyleBackColor = false;
            this.buttonEntrada.Click += new System.EventHandler(this.buttonEntrada_Click);
            // 
            // buttonAjuste
            // 
            this.buttonAjuste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjuste.BackColor = System.Drawing.Color.Red;
            this.buttonAjuste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAjuste.BackgroundImage")));
            this.buttonAjuste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAjuste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAjuste.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonAjuste.FlatAppearance.BorderSize = 2;
            this.buttonAjuste.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjuste.ForeColor = System.Drawing.Color.White;
            this.buttonAjuste.Location = new System.Drawing.Point(744, 12);
            this.buttonAjuste.Name = "buttonAjuste";
            this.buttonAjuste.Size = new System.Drawing.Size(180, 28);
            this.buttonAjuste.TabIndex = 430;
            this.buttonAjuste.Text = "Ajuste de entrada";
            this.buttonAjuste.UseVisualStyleBackColor = false;
            this.buttonAjuste.Click += new System.EventHandler(this.buttonAjuste_Click);
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
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 32;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Produto,
            this.Cod_Barras,
            this.Nome_Produto,
            this.dataGridViewTextBoxColumn2,
            this.Fabricante,
            this.dataGridViewTextBoxColumn3,
            this.Column1});
            this.dataGridViewLista.ContextMenuStrip = this.menuStrip;
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
            this.dataGridViewLista.Size = new System.Drawing.Size(1115, 435);
            this.dataGridViewLista.TabIndex = 431;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
            this.dataGridViewLista.SortStringChanged += new System.EventHandler(this.dataGridViewLista_SortStringChanged);
            this.dataGridViewLista.FilterStringChanged += new System.EventHandler(this.dataGridViewLista_FilterStringChanged);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // ID_Produto
            // 
            this.ID_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID_Produto.DataPropertyName = "ID";
            this.ID_Produto.FillWeight = 50F;
            this.ID_Produto.Frozen = true;
            this.ID_Produto.HeaderText = "N°";
            this.ID_Produto.MinimumWidth = 22;
            this.ID_Produto.Name = "ID_Produto";
            this.ID_Produto.ReadOnly = true;
            this.ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ID_Produto.Width = 53;
            // 
            // Cod_Barras
            // 
            this.Cod_Barras.DataPropertyName = "Descricao";
            this.Cod_Barras.FillWeight = 375F;
            this.Cod_Barras.HeaderText = "Descrição";
            this.Cod_Barras.MinimumWidth = 22;
            this.Cod_Barras.Name = "Cod_Barras";
            this.Cod_Barras.ReadOnly = true;
            this.Cod_Barras.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Nome_Produto
            // 
            this.Nome_Produto.DataPropertyName = "Produtos";
            this.Nome_Produto.FillWeight = 75F;
            this.Nome_Produto.HeaderText = "Produtos";
            this.Nome_Produto.MinimumWidth = 22;
            this.Nome_Produto.Name = "Nome_Produto";
            this.Nome_Produto.ReadOnly = true;
            this.Nome_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Responsavel";
            this.dataGridViewTextBoxColumn2.FillWeight = 180F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Responsável";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Fabricante
            // 
            this.Fabricante.DataPropertyName = "Data";
            this.Fabricante.HeaderText = "Data";
            this.Fabricante.MinimumWidth = 22;
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            this.Fabricante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tipo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Recebimento";
            this.Column1.HeaderText = "Recebimento";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarRecebimentoToolStripMenuItem,
            this.excluirLoteToolStripMenuItem});
            this.menuStrip.Name = "menuStripData";
            this.menuStrip.Size = new System.Drawing.Size(199, 48);
            // 
            // confirmarRecebimentoToolStripMenuItem
            // 
            this.confirmarRecebimentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("confirmarRecebimentoToolStripMenuItem.Image")));
            this.confirmarRecebimentoToolStripMenuItem.Name = "confirmarRecebimentoToolStripMenuItem";
            this.confirmarRecebimentoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.confirmarRecebimentoToolStripMenuItem.Text = "Confirmar recebimento";
            this.confirmarRecebimentoToolStripMenuItem.Click += new System.EventHandler(this.confirmarRecebimentoToolStripMenuItem_Click);
            // 
            // binding
            // 
            this.binding.DataMember = "tbl_ProdutosLote";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRegistros);
            this.panel1.Controls.Add(this.textBoxRegistros);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 55);
            this.panel1.TabIndex = 432;
            // 
            // buttonRegistros
            // 
            this.buttonRegistros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRegistros.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistros.ForeColor = System.Drawing.Color.Red;
            this.buttonRegistros.Location = new System.Drawing.Point(180, 12);
            this.buttonRegistros.Name = "buttonRegistros";
            this.buttonRegistros.Size = new System.Drawing.Size(106, 28);
            this.buttonRegistros.TabIndex = 5;
            this.buttonRegistros.Text = "Exibir";
            this.buttonRegistros.UseVisualStyleBackColor = false;
            this.buttonRegistros.Click += new System.EventHandler(this.buttonRegistros_Click);
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegistros.Location = new System.Drawing.Point(101, 13);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(67, 26);
            this.textBoxRegistros.TabIndex = 4;
            this.textBoxRegistros.Text = "100";
            this.textBoxRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRegistros.Enter += new System.EventHandler(this.textBoxRegistros_Enter);
            this.textBoxRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRegistros_KeyPress);
            this.textBoxRegistros.Leave += new System.EventHandler(this.textBoxRegistros_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registros:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1115, 435);
            this.panel2.TabIndex = 433;
            // 
            // excluirLoteToolStripMenuItem
            // 
            this.excluirLoteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excluirLoteToolStripMenuItem.Image")));
            this.excluirLoteToolStripMenuItem.Name = "excluirLoteToolStripMenuItem";
            this.excluirLoteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.excluirLoteToolStripMenuItem.Text = "Excluir lote";
            this.excluirLoteToolStripMenuItem.Click += new System.EventHandler(this.excluirLoteToolStripMenuItem_Click);
            // 
            // formProdutosLotesEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAjuste);
            this.Controls.Add(this.buttonEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.formProdutosLotesEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binding)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonEntrada;
        private System.Windows.Forms.Button buttonAjuste;
        private ADGV.AdvancedDataGridView dataGridViewLista;
        public System.Windows.Forms.BindingSource binding;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem confirmarRecebimentoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRegistros;
        private System.Windows.Forms.TextBox textBoxRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem excluirLoteToolStripMenuItem;
    }
}