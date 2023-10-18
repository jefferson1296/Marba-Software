
namespace MarbaSoftware
{
    partial class formGestaoEstabelecimentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoEstabelecimentos));
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.repartiçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonEquipamentos = new System.Windows.Forms.Button();
            this.buttonDepreciacoes = new System.Windows.Forms.Button();
            this.buttonReparticoes = new System.Windows.Forms.Button();
            this.buttonReposicoes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 28;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column16});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 60);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1064, 375);
            this.dataGridViewLista.TabIndex = 66;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseMove);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 250F;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Categoria";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Endereco";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Tamanho";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 75F;
            this.Column6.HeaderText = "Equipamentos";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 75F;
            this.Column7.HeaderText = "Colaboradores";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.FillWeight = 75F;
            this.Column16.HeaderText = "Status";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repartiçõesToolStripMenuItem,
            this.apagarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(136, 48);
            // 
            // repartiçõesToolStripMenuItem
            // 
            this.repartiçõesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("repartiçõesToolStripMenuItem.Image")));
            this.repartiçõesToolStripMenuItem.Name = "repartiçõesToolStripMenuItem";
            this.repartiçõesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.repartiçõesToolStripMenuItem.Text = "Repartições";
            this.repartiçõesToolStripMenuItem.Click += new System.EventHandler(this.repartiçõesToolStripMenuItem_Click);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.Color.White;
            this.buttonAdicionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.BackgroundImage")));
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.White;
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdicionar.Location = new System.Drawing.Point(891, 11);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdicionar.Size = new System.Drawing.Size(161, 32);
            this.buttonAdicionar.TabIndex = 477;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonEquipamentos
            // 
            this.buttonEquipamentos.BackColor = System.Drawing.Color.White;
            this.buttonEquipamentos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEquipamentos.BackgroundImage")));
            this.buttonEquipamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEquipamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEquipamentos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEquipamentos.ForeColor = System.Drawing.Color.White;
            this.buttonEquipamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEquipamentos.Location = new System.Drawing.Point(12, 11);
            this.buttonEquipamentos.Name = "buttonEquipamentos";
            this.buttonEquipamentos.Size = new System.Drawing.Size(161, 32);
            this.buttonEquipamentos.TabIndex = 479;
            this.buttonEquipamentos.Text = "Equipamentos";
            this.buttonEquipamentos.UseVisualStyleBackColor = false;
            this.buttonEquipamentos.Click += new System.EventHandler(this.buttonEquipamentos_Click);
            // 
            // buttonDepreciacoes
            // 
            this.buttonDepreciacoes.BackColor = System.Drawing.Color.White;
            this.buttonDepreciacoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDepreciacoes.BackgroundImage")));
            this.buttonDepreciacoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDepreciacoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDepreciacoes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDepreciacoes.ForeColor = System.Drawing.Color.White;
            this.buttonDepreciacoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDepreciacoes.Location = new System.Drawing.Point(346, 11);
            this.buttonDepreciacoes.Name = "buttonDepreciacoes";
            this.buttonDepreciacoes.Size = new System.Drawing.Size(161, 32);
            this.buttonDepreciacoes.TabIndex = 480;
            this.buttonDepreciacoes.Text = "Depreciação";
            this.buttonDepreciacoes.UseVisualStyleBackColor = false;
            this.buttonDepreciacoes.Click += new System.EventHandler(this.buttonDepreciacoes_Click);
            // 
            // buttonReparticoes
            // 
            this.buttonReparticoes.BackColor = System.Drawing.Color.White;
            this.buttonReparticoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReparticoes.BackgroundImage")));
            this.buttonReparticoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReparticoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReparticoes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReparticoes.ForeColor = System.Drawing.Color.White;
            this.buttonReparticoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReparticoes.Location = new System.Drawing.Point(179, 11);
            this.buttonReparticoes.Name = "buttonReparticoes";
            this.buttonReparticoes.Size = new System.Drawing.Size(161, 32);
            this.buttonReparticoes.TabIndex = 481;
            this.buttonReparticoes.Text = "Repartições";
            this.buttonReparticoes.UseVisualStyleBackColor = false;
            this.buttonReparticoes.Click += new System.EventHandler(this.buttonReparticoes_Click);
            // 
            // buttonReposicoes
            // 
            this.buttonReposicoes.BackColor = System.Drawing.Color.White;
            this.buttonReposicoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReposicoes.BackgroundImage")));
            this.buttonReposicoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReposicoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReposicoes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReposicoes.ForeColor = System.Drawing.Color.White;
            this.buttonReposicoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReposicoes.Location = new System.Drawing.Point(687, 11);
            this.buttonReposicoes.Name = "buttonReposicoes";
            this.buttonReposicoes.Size = new System.Drawing.Size(161, 32);
            this.buttonReposicoes.TabIndex = 482;
            this.buttonReposicoes.Text = "Reposições";
            this.buttonReposicoes.UseVisualStyleBackColor = false;
            this.buttonReposicoes.Click += new System.EventHandler(this.buttonReposicoes_Click);
            // 
            // formGestaoEstabelecimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 435);
            this.Controls.Add(this.buttonReposicoes);
            this.Controls.Add(this.buttonReparticoes);
            this.Controls.Add(this.buttonDepreciacoes);
            this.Controls.Add(this.buttonEquipamentos);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.dataGridViewLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoEstabelecimentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estabelecimentos";
            this.Load += new System.EventHandler(this.formGestaoEstabelecimentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.Button buttonEquipamentos;
        private System.Windows.Forms.Button buttonDepreciacoes;
        private System.Windows.Forms.ToolStripMenuItem repartiçõesToolStripMenuItem;
        private System.Windows.Forms.Button buttonReparticoes;
        private System.Windows.Forms.Button buttonReposicoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
    }
}