
namespace MarbaSoftware
{
    partial class formTelaInicialAtividades
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
            System.Windows.Forms.PictureBox pictureBoxFechar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialAtividades));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBoxPesquisar = new System.Windows.Forms.PictureBox();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.buttonAtividade = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuAtividades = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEspecificacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewAtividades = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pictureBoxFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).BeginInit();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).BeginInit();
            this.contextMenuAtividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtividades)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFechar
            // 
            pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            pictureBoxFechar.Location = new System.Drawing.Point(1109, 6);
            pictureBoxFechar.Name = "pictureBoxFechar";
            pictureBoxFechar.Size = new System.Drawing.Size(15, 15);
            pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxFechar.TabIndex = 20;
            pictureBoxFechar.TabStop = false;
            pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 469);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1122, 3);
            this.panel4.TabIndex = 82;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 444);
            this.panel3.TabIndex = 83;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1125, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 444);
            this.panel2.TabIndex = 84;
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.pictureBox2);
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.labelTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1128, 28);
            this.panelSuperior.TabIndex = 81;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(30, 7);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(63, 16);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Atividades";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1122, 78);
            this.panel5.TabIndex = 89;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.pictureBoxPesquisar);
            this.panel7.Controls.Add(this.textBoxPesquisa);
            this.panel7.Controls.Add(this.buttonAtividade);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1122, 52);
            this.panel7.TabIndex = 94;
            // 
            // pictureBoxPesquisar
            // 
            this.pictureBoxPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPesquisar.Image")));
            this.pictureBoxPesquisar.Location = new System.Drawing.Point(1085, 14);
            this.pictureBoxPesquisar.Name = "pictureBoxPesquisar";
            this.pictureBoxPesquisar.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPesquisar.TabIndex = 99;
            this.pictureBoxPesquisar.TabStop = false;
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(546, 11);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(537, 29);
            this.textBoxPesquisa.TabIndex = 98;
            this.textBoxPesquisa.Text = "Digite aqui para pesquisar";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // buttonAtividade
            // 
            this.buttonAtividade.BackColor = System.Drawing.Color.Red;
            this.buttonAtividade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAtividade.BackgroundImage")));
            this.buttonAtividade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtividade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtividade.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonAtividade.FlatAppearance.BorderSize = 2;
            this.buttonAtividade.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtividade.ForeColor = System.Drawing.Color.White;
            this.buttonAtividade.Image = ((System.Drawing.Image)(resources.GetObject("buttonAtividade.Image")));
            this.buttonAtividade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtividade.Location = new System.Drawing.Point(10, 11);
            this.buttonAtividade.Name = "buttonAtividade";
            this.buttonAtividade.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAtividade.Size = new System.Drawing.Size(150, 30);
            this.buttonAtividade.TabIndex = 96;
            this.buttonAtividade.Text = "Nova Atividade";
            this.buttonAtividade.UseVisualStyleBackColor = false;
            this.buttonAtividade.Click += new System.EventHandler(this.buttonAtividade_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(486, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "Atividades Cadastradas";
            // 
            // contextMenuAtividades
            // 
            this.contextMenuAtividades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEditar,
            this.menuItemEspecificacoes,
            this.apagarToolStripMenuItem});
            this.contextMenuAtividades.Name = "contextMenuAtividades";
            this.contextMenuAtividades.Size = new System.Drawing.Size(151, 70);
            // 
            // menuItemEditar
            // 
            this.menuItemEditar.Name = "menuItemEditar";
            this.menuItemEditar.Size = new System.Drawing.Size(150, 22);
            this.menuItemEditar.Text = "Editar";
            this.menuItemEditar.Click += new System.EventHandler(this.menuItemEditar_Click);
            // 
            // menuItemEspecificacoes
            // 
            this.menuItemEspecificacoes.Name = "menuItemEspecificacoes";
            this.menuItemEspecificacoes.Size = new System.Drawing.Size(150, 22);
            this.menuItemEspecificacoes.Text = "Especificações";
            this.menuItemEspecificacoes.Click += new System.EventHandler(this.menuItemEspecificacoes_Click);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // dataGridViewAtividades
            // 
            this.dataGridViewAtividades.AllowUserToAddRows = false;
            this.dataGridViewAtividades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAtividades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAtividades.AutoGenerateContextFilters = true;
            this.dataGridViewAtividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAtividades.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAtividades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAtividades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewAtividades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAtividades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAtividades.ColumnHeadersHeight = 40;
            this.dataGridViewAtividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridViewAtividades.ContextMenuStrip = this.contextMenuAtividades;
            this.dataGridViewAtividades.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAtividades.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAtividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAtividades.EnableHeadersVisualStyles = false;
            this.dataGridViewAtividades.Location = new System.Drawing.Point(3, 106);
            this.dataGridViewAtividades.Name = "dataGridViewAtividades";
            this.dataGridViewAtividades.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAtividades.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAtividades.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAtividades.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAtividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAtividades.Size = new System.Drawing.Size(1122, 363);
            this.dataGridViewAtividades.TabIndex = 93;
            this.dataGridViewAtividades.TabStop = false;
            this.dataGridViewAtividades.TimeFilter = false;
            this.dataGridViewAtividades.SortStringChanged += new System.EventHandler(this.dataGridViewAtividades_SortStringChanged);
            this.dataGridViewAtividades.FilterStringChanged += new System.EventHandler(this.dataGridViewAtividades_FilterStringChanged);
            this.dataGridViewAtividades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAtividades_CellDoubleClick);
            this.dataGridViewAtividades.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAtividades_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Imagem";
            this.Column1.FillWeight = 15F;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Descricao";
            this.Column7.FillWeight = 400F;
            this.Column7.HeaderText = "Descrição";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Setor";
            this.Column8.FillWeight = 180F;
            this.Column8.HeaderText = "Setor";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Categoria";
            this.Column9.FillWeight = 200F;
            this.Column9.HeaderText = "Categoria";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // formTelaInicialAtividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 472);
            this.Controls.Add(this.dataGridViewAtividades);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formTelaInicialAtividades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formTelaInicialAtividadesAtiv";
            this.Load += new System.EventHandler(this.formTelaInicialAtividadesAtiv_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPesquisar)).EndInit();
            this.contextMenuAtividades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtividades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBoxPesquisar;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.Button buttonAtividade;
        private System.Windows.Forms.ContextMenuStrip contextMenuAtividades;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditar;
        private System.Windows.Forms.ToolStripMenuItem menuItemEspecificacoes;
        public ADGV.AdvancedDataGridView dataGridViewAtividades;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}