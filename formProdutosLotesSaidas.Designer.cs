
namespace MarbaSoftware
{
    partial class formProdutosLotesSaidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesSaidas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAjuste = new System.Windows.Forms.Button();
            this.buttonEntrada = new System.Windows.Forms.Button();
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.binding = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.buttonRegistros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.buttonAjuste.Location = new System.Drawing.Point(581, 18);
            this.buttonAjuste.Name = "buttonAjuste";
            this.buttonAjuste.Size = new System.Drawing.Size(180, 28);
            this.buttonAjuste.TabIndex = 433;
            this.buttonAjuste.Text = "Extravios";
            this.buttonAjuste.UseVisualStyleBackColor = false;
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
            this.buttonEntrada.Location = new System.Drawing.Point(767, 18);
            this.buttonEntrada.Name = "buttonEntrada";
            this.buttonEntrada.Size = new System.Drawing.Size(180, 28);
            this.buttonEntrada.TabIndex = 432;
            this.buttonEntrada.Text = "Avarias";
            this.buttonEntrada.UseVisualStyleBackColor = false;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewLista.AutoGenerateContextFilters = true;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewLista.ColumnHeadersHeight = 28;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Produto,
            this.Cod_Barras,
            this.Nome_Produto,
            this.dataGridViewTextBoxColumn2,
            this.Fabricante,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewLista.DateWithTime = false;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLista.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(952, 424);
            this.dataGridViewLista.TabIndex = 434;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tipo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 64);
            this.panel1.TabIndex = 435;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 424);
            this.panel2.TabIndex = 436;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registros:";
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegistros.Location = new System.Drawing.Point(101, 20);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(67, 26);
            this.textBoxRegistros.TabIndex = 1;
            this.textBoxRegistros.Text = "100";
            this.textBoxRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRegistros.Enter += new System.EventHandler(this.textBoxRegistros_Enter);
            this.textBoxRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRegistros_KeyPress);
            this.textBoxRegistros.Leave += new System.EventHandler(this.textBoxRegistros_Leave);
            // 
            // buttonRegistros
            // 
            this.buttonRegistros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRegistros.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistros.ForeColor = System.Drawing.Color.Red;
            this.buttonRegistros.Location = new System.Drawing.Point(180, 19);
            this.buttonRegistros.Name = "buttonRegistros";
            this.buttonRegistros.Size = new System.Drawing.Size(106, 28);
            this.buttonRegistros.TabIndex = 2;
            this.buttonRegistros.Text = "Exibir";
            this.buttonRegistros.UseVisualStyleBackColor = false;
            this.buttonRegistros.Click += new System.EventHandler(this.buttonRegistros_Click);
            // 
            // formProdutosLotesSaidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAjuste);
            this.Controls.Add(this.buttonEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesSaidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saídas";
            this.Load += new System.EventHandler(this.formProdutosLotesSaidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAjuste;
        private System.Windows.Forms.Button buttonEntrada;
        private ADGV.AdvancedDataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        public System.Windows.Forms.BindingSource binding;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRegistros;
        private System.Windows.Forms.TextBox textBoxRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}