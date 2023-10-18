
namespace MarbaSoftware
{
    partial class formProdutosLotesQuarentenasProdutos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProdutosLotesQuarentenasProdutos));
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEtiqueta = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAcabamento = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCondicionamento = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLista = new System.Windows.Forms.Button();
            this.buttonEtiquetas = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acabamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condicionamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.WhiteSmoke;
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
            this.Column2,
            this.Column1,
            this.Column3,
            this.ColumnEtiqueta,
            this.ColumnAcabamento,
            this.ColumnCondicionamento,
            this.Column7});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenu;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1005, 363);
            this.dataGridViewLista.TabIndex = 42;
            this.dataGridViewLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellValueChanged);
            this.dataGridViewLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewLista_CurrentCellDirtyStateChanged);
            // 
            // Column2
            // 
            this.Column2.FillWeight = 300F;
            this.Column2.HeaderText = "Descricão";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "Quantidade";
            this.Column3.Name = "Column3";
            // 
            // ColumnEtiqueta
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnEtiqueta.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnEtiqueta.FillWeight = 75F;
            this.ColumnEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnEtiqueta.HeaderText = "Etiqueta";
            this.ColumnEtiqueta.Name = "ColumnEtiqueta";
            this.ColumnEtiqueta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnEtiqueta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnAcabamento
            // 
            this.ColumnAcabamento.FillWeight = 75F;
            this.ColumnAcabamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnAcabamento.HeaderText = "Acabamento";
            this.ColumnAcabamento.Name = "ColumnAcabamento";
            this.ColumnAcabamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAcabamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnCondicionamento
            // 
            this.ColumnCondicionamento.FillWeight = 75F;
            this.ColumnCondicionamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCondicionamento.HeaderText = "Condicionamento";
            this.ColumnCondicionamento.Name = "ColumnCondicionamento";
            this.ColumnCondicionamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCondicionamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 20F;
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 53);
            this.panel1.TabIndex = 43;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(796, 9);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(197, 32);
            this.buttonSalvar.TabIndex = 3;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLista);
            this.panel2.Controls.Add(this.buttonEtiquetas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 50);
            this.panel2.TabIndex = 44;
            // 
            // buttonLista
            // 
            this.buttonLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLista.BackColor = System.Drawing.Color.Red;
            this.buttonLista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLista.BackgroundImage")));
            this.buttonLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLista.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonLista.FlatAppearance.BorderSize = 2;
            this.buttonLista.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLista.ForeColor = System.Drawing.Color.White;
            this.buttonLista.Location = new System.Drawing.Point(198, 12);
            this.buttonLista.Name = "buttonLista";
            this.buttonLista.Size = new System.Drawing.Size(180, 28);
            this.buttonLista.TabIndex = 435;
            this.buttonLista.Text = "Imprimir lista";
            this.buttonLista.UseVisualStyleBackColor = false;
            this.buttonLista.Click += new System.EventHandler(this.buttonLista_Click);
            // 
            // buttonEtiquetas
            // 
            this.buttonEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEtiquetas.BackColor = System.Drawing.Color.Red;
            this.buttonEtiquetas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEtiquetas.BackgroundImage")));
            this.buttonEtiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEtiquetas.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonEtiquetas.FlatAppearance.BorderSize = 2;
            this.buttonEtiquetas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEtiquetas.ForeColor = System.Drawing.Color.White;
            this.buttonEtiquetas.Location = new System.Drawing.Point(12, 12);
            this.buttonEtiquetas.Name = "buttonEtiquetas";
            this.buttonEtiquetas.Size = new System.Drawing.Size(180, 28);
            this.buttonEtiquetas.TabIndex = 434;
            this.buttonEtiquetas.Text = "Imprimir etiquetas";
            this.buttonEtiquetas.UseVisualStyleBackColor = false;
            this.buttonEtiquetas.Click += new System.EventHandler(this.buttonEtiquetas_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewLista);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 363);
            this.panel3.TabIndex = 45;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarTodosToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(145, 26);
            // 
            // marcarTodosToolStripMenuItem
            // 
            this.marcarTodosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiquetasToolStripMenuItem,
            this.acabamentoToolStripMenuItem,
            this.condicionamentoToolStripMenuItem});
            this.marcarTodosToolStripMenuItem.Name = "marcarTodosToolStripMenuItem";
            this.marcarTodosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.marcarTodosToolStripMenuItem.Text = "Marcar todos";
            // 
            // etiquetasToolStripMenuItem
            // 
            this.etiquetasToolStripMenuItem.Name = "etiquetasToolStripMenuItem";
            this.etiquetasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.etiquetasToolStripMenuItem.Text = "Etiquetas";
            this.etiquetasToolStripMenuItem.Click += new System.EventHandler(this.etiquetasToolStripMenuItem_Click);
            // 
            // acabamentoToolStripMenuItem
            // 
            this.acabamentoToolStripMenuItem.Name = "acabamentoToolStripMenuItem";
            this.acabamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acabamentoToolStripMenuItem.Text = "Acabamento";
            this.acabamentoToolStripMenuItem.Click += new System.EventHandler(this.acabamentoToolStripMenuItem_Click);
            // 
            // condicionamentoToolStripMenuItem
            // 
            this.condicionamentoToolStripMenuItem.Name = "condicionamentoToolStripMenuItem";
            this.condicionamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.condicionamentoToolStripMenuItem.Text = "Condicionamento";
            this.condicionamentoToolStripMenuItem.Click += new System.EventHandler(this.condicionamentoToolStripMenuItem_Click);
            // 
            // formProdutosLotesQuarentenasProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 466);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formProdutosLotesQuarentenasProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos da quarentena";
            this.Load += new System.EventHandler(this.formProdutosLotesQuarentenasQuarentena_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonEtiquetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnEtiqueta;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnAcabamento;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCondicionamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.Button buttonLista;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem marcarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acabamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condicionamentoToolStripMenuItem;
    }
}