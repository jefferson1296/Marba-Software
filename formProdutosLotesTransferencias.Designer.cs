
namespace MarbaSoftware
{
    partial class formProdutosLotesTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesTransferencias));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonTransferencia = new System.Windows.Forms.Button();
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.binding = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRegistros = new System.Windows.Forms.Button();
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDirecionamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTransferencia
            // 
            this.buttonTransferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTransferencia.BackColor = System.Drawing.Color.Red;
            this.buttonTransferencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTransferencia.BackgroundImage")));
            this.buttonTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTransferencia.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonTransferencia.FlatAppearance.BorderSize = 2;
            this.buttonTransferencia.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransferencia.ForeColor = System.Drawing.Color.White;
            this.buttonTransferencia.Location = new System.Drawing.Point(761, 15);
            this.buttonTransferencia.Name = "buttonTransferencia";
            this.buttonTransferencia.Size = new System.Drawing.Size(180, 32);
            this.buttonTransferencia.TabIndex = 434;
            this.buttonTransferencia.Text = "Transferência de estoque";
            this.buttonTransferencia.UseVisualStyleBackColor = false;
            this.buttonTransferencia.Click += new System.EventHandler(this.buttonTransferencia_Click);
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
            this.Column1,
            this.Nome_Produto,
            this.dataGridViewTextBoxColumn2,
            this.Fabricante,
            this.Column2});
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
            this.dataGridViewLista.Size = new System.Drawing.Size(952, 434);
            this.dataGridViewLista.TabIndex = 435;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
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
            this.Cod_Barras.DataPropertyName = "Origem";
            this.Cod_Barras.FillWeight = 150F;
            this.Cod_Barras.HeaderText = "Origem";
            this.Cod_Barras.MinimumWidth = 22;
            this.Cod_Barras.Name = "Cod_Barras";
            this.Cod_Barras.ReadOnly = true;
            this.Cod_Barras.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Destino";
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Destino";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
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
            // Column2
            // 
            this.Column2.DataPropertyName = "Tipo";
            this.Column2.HeaderText = "Tipo";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 46);
            this.panel1.TabIndex = 436;
            // 
            // buttonRegistros
            // 
            this.buttonRegistros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRegistros.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistros.ForeColor = System.Drawing.Color.Red;
            this.buttonRegistros.Location = new System.Drawing.Point(180, 10);
            this.buttonRegistros.Name = "buttonRegistros";
            this.buttonRegistros.Size = new System.Drawing.Size(106, 28);
            this.buttonRegistros.TabIndex = 8;
            this.buttonRegistros.Text = "Exibir";
            this.buttonRegistros.UseVisualStyleBackColor = false;
            this.buttonRegistros.Click += new System.EventHandler(this.buttonRegistros_Click);
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegistros.Location = new System.Drawing.Point(101, 11);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(67, 26);
            this.textBoxRegistros.TabIndex = 7;
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
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Registros:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 434);
            this.panel2.TabIndex = 437;
            // 
            // buttonDirecionamento
            // 
            this.buttonDirecionamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDirecionamento.BackColor = System.Drawing.Color.Red;
            this.buttonDirecionamento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDirecionamento.BackgroundImage")));
            this.buttonDirecionamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDirecionamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDirecionamento.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonDirecionamento.FlatAppearance.BorderSize = 2;
            this.buttonDirecionamento.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDirecionamento.ForeColor = System.Drawing.Color.White;
            this.buttonDirecionamento.Location = new System.Drawing.Point(564, 15);
            this.buttonDirecionamento.Name = "buttonDirecionamento";
            this.buttonDirecionamento.Size = new System.Drawing.Size(180, 32);
            this.buttonDirecionamento.TabIndex = 438;
            this.buttonDirecionamento.Text = "Direcionamento";
            this.buttonDirecionamento.UseVisualStyleBackColor = false;
            this.buttonDirecionamento.Click += new System.EventHandler(this.buttonDirecionamento_Click);
            // 
            // formProdutosLotesTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 546);
            this.Controls.Add(this.buttonDirecionamento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonTransferencia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesTransferencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferências";
            this.Load += new System.EventHandler(this.formProdutosLotesTransferencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonTransferencia;
        private ADGV.AdvancedDataGridView dataGridViewLista;
        public System.Windows.Forms.BindingSource binding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRegistros;
        private System.Windows.Forms.TextBox textBoxRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDirecionamento;
    }
}