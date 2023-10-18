
namespace MarbaSoftware
{
    partial class formCatalogoTransformacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogoTransformacoes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.buttonCapsulas = new System.Windows.Forms.Button();
            this.buttonCapsula = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewLista = new ADGV.AdvancedDataGridView();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utensilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogarTemporariamenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binding = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.promoçaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binding)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxPesquisar);
            this.panel1.Controls.Add(this.textBoxPesquisa);
            this.panel1.Controls.Add(this.buttonCapsulas);
            this.panel1.Controls.Add(this.buttonCapsula);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 53);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(542, 17);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 77;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.BackColor = System.Drawing.Color.White;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(12, 12);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(524, 29);
            this.textBoxPesquisa.TabIndex = 76;
            this.textBoxPesquisa.Text = "Digite aqui para pesquisar";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // buttonCapsulas
            // 
            this.buttonCapsulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCapsulas.BackColor = System.Drawing.Color.Red;
            this.buttonCapsulas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapsulas.ForeColor = System.Drawing.Color.White;
            this.buttonCapsulas.Location = new System.Drawing.Point(889, 9);
            this.buttonCapsulas.Name = "buttonCapsulas";
            this.buttonCapsulas.Size = new System.Drawing.Size(156, 35);
            this.buttonCapsulas.TabIndex = 1;
            this.buttonCapsulas.Text = "Cápsulas";
            this.buttonCapsulas.UseVisualStyleBackColor = false;
            this.buttonCapsulas.Click += new System.EventHandler(this.buttonCapsulas_Click);
            // 
            // buttonCapsula
            // 
            this.buttonCapsula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCapsula.BackColor = System.Drawing.Color.Red;
            this.buttonCapsula.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapsula.ForeColor = System.Drawing.Color.White;
            this.buttonCapsula.Location = new System.Drawing.Point(1051, 9);
            this.buttonCapsula.Name = "buttonCapsula";
            this.buttonCapsula.Size = new System.Drawing.Size(156, 35);
            this.buttonCapsula.TabIndex = 0;
            this.buttonCapsula.Text = "Criar cápsula";
            this.buttonCapsula.UseVisualStyleBackColor = false;
            this.buttonCapsula.Click += new System.EventHandler(this.buttonCapsula_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 578);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 15);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1219, 3);
            this.panel6.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1219, 3);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1219, 3);
            this.panel4.TabIndex = 2;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoGenerateContextFilters = true;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 42;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fabricante,
            this.ID_Produto,
            this.Utensilio,
            this.Produto,
            this.Custo});
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
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.Control;
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1219, 525);
            this.dataGridViewLista.TabIndex = 85;
            this.dataGridViewLista.TabStop = false;
            this.dataGridViewLista.TimeFilter = false;
            this.dataGridViewLista.SortStringChanged += new System.EventHandler(this.dataGridViewLista_SortStringChanged);
            this.dataGridViewLista.FilterStringChanged += new System.EventHandler(this.dataGridViewLista_FilterStringChanged);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Fabricante
            // 
            this.Fabricante.DataPropertyName = "Fabricante";
            this.Fabricante.FillWeight = 130F;
            this.Fabricante.HeaderText = "Fabricante";
            this.Fabricante.MinimumWidth = 22;
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            this.Fabricante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ID_Produto
            // 
            this.ID_Produto.DataPropertyName = "ID";
            this.ID_Produto.FillWeight = 35F;
            this.ID_Produto.HeaderText = "N°";
            this.ID_Produto.MinimumWidth = 22;
            this.ID_Produto.Name = "ID_Produto";
            this.ID_Produto.ReadOnly = true;
            this.ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Utensilio
            // 
            this.Utensilio.DataPropertyName = "Utensilio";
            this.Utensilio.FillWeight = 200F;
            this.Utensilio.HeaderText = "Utensílio";
            this.Utensilio.MinimumWidth = 22;
            this.Utensilio.Name = "Utensilio";
            this.Utensilio.ReadOnly = true;
            this.Utensilio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Produto
            // 
            this.Produto.DataPropertyName = "Produto";
            this.Produto.FillWeight = 350F;
            this.Produto.HeaderText = "Produto";
            this.Produto.MinimumWidth = 22;
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Custo
            // 
            this.Custo.DataPropertyName = "Custo";
            this.Custo.FillWeight = 50F;
            this.Custo.HeaderText = "Custo (R$)";
            this.Custo.MinimumWidth = 22;
            this.Custo.Name = "Custo";
            this.Custo.ReadOnly = true;
            this.Custo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.catalogarTemporariamenteToolStripMenuItem,
            this.editarProdutoToolStripMenuItem,
            this.apagarProdutoToolStripMenuItem,
            this.editarCatalogoToolStripMenuItem,
            this.imagensToolStripMenuItem,
            this.promoçaoToolStripMenuItem});
            this.menuStrip.Name = "menuStripFluxo";
            this.menuStrip.Size = new System.Drawing.Size(240, 180);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.apagarToolStripMenuItem.Text = "Descartar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // catalogarTemporariamenteToolStripMenuItem
            // 
            this.catalogarTemporariamenteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catalogarTemporariamenteToolStripMenuItem.Image")));
            this.catalogarTemporariamenteToolStripMenuItem.Name = "catalogarTemporariamenteToolStripMenuItem";
            this.catalogarTemporariamenteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.catalogarTemporariamenteToolStripMenuItem.Text = "Catalogar temporariamente";
            this.catalogarTemporariamenteToolStripMenuItem.Click += new System.EventHandler(this.catalogarTemporariamenteToolStripMenuItem_Click);
            // 
            // editarProdutoToolStripMenuItem
            // 
            this.editarProdutoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarProdutoToolStripMenuItem.Image")));
            this.editarProdutoToolStripMenuItem.Name = "editarProdutoToolStripMenuItem";
            this.editarProdutoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.editarProdutoToolStripMenuItem.Text = "Editar produto";
            this.editarProdutoToolStripMenuItem.Click += new System.EventHandler(this.editarProdutoToolStripMenuItem_Click);
            // 
            // apagarProdutoToolStripMenuItem
            // 
            this.apagarProdutoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarProdutoToolStripMenuItem.Image")));
            this.apagarProdutoToolStripMenuItem.Name = "apagarProdutoToolStripMenuItem";
            this.apagarProdutoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.apagarProdutoToolStripMenuItem.Text = "Apagar produto";
            this.apagarProdutoToolStripMenuItem.Click += new System.EventHandler(this.apagarProdutoToolStripMenuItem_Click);
            // 
            // editarCatalogoToolStripMenuItem
            // 
            this.editarCatalogoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarCatalogoToolStripMenuItem.Image")));
            this.editarCatalogoToolStripMenuItem.Name = "editarCatalogoToolStripMenuItem";
            this.editarCatalogoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.editarCatalogoToolStripMenuItem.Text = "Editar informações no catálogo";
            this.editarCatalogoToolStripMenuItem.Click += new System.EventHandler(this.editarCatalogoToolStripMenuItem_Click);
            // 
            // imagensToolStripMenuItem
            // 
            this.imagensToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imagensToolStripMenuItem.Image")));
            this.imagensToolStripMenuItem.Name = "imagensToolStripMenuItem";
            this.imagensToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.imagensToolStripMenuItem.Text = "Imagens";
            this.imagensToolStripMenuItem.Click += new System.EventHandler(this.imagensToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewLista);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1219, 525);
            this.panel3.TabIndex = 2;
            // 
            // promoçaoToolStripMenuItem
            // 
            this.promoçaoToolStripMenuItem.Name = "promoçaoToolStripMenuItem";
            this.promoçaoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.promoçaoToolStripMenuItem.Text = "Editar promoção";
            this.promoçaoToolStripMenuItem.Click += new System.EventHandler(this.promoçaoToolStripMenuItem_Click);
            // 
            // formCatalogoTransformacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 593);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCatalogoTransformacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transformações";
            this.Load += new System.EventHandler(this.formCatalogoTransformacoes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.menuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binding)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCapsula;
        private System.Windows.Forms.Button buttonCapsulas;
        public ADGV.AdvancedDataGridView dataGridViewLista;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogarTemporariamenteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.BindingSource binding;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utensilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Custo;
        private System.Windows.Forms.ToolStripMenuItem editarProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarProdutoToolStripMenuItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem editarCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promoçaoToolStripMenuItem;
    }
}