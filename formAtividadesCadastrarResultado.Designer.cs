
namespace MarbaSoftware
{
    partial class formAtividadesCadastrarResultado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAtividadesCadastrarResultado));
            this.textBoxCorrecao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridCorrecoes = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.textBoxResultado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExcluir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCorrecoes)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCorrecao
            // 
            this.textBoxCorrecao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCorrecao.Location = new System.Drawing.Point(12, 36);
            this.textBoxCorrecao.Multiline = true;
            this.textBoxCorrecao.Name = "textBoxCorrecao";
            this.textBoxCorrecao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCorrecao.Size = new System.Drawing.Size(735, 45);
            this.textBoxCorrecao.TabIndex = 482;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(311, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 19);
            this.label7.TabIndex = 481;
            this.label7.Text = "Ações corretivas";
            // 
            // dataGridCorrecoes
            // 
            this.dataGridCorrecoes.AllowUserToAddRows = false;
            this.dataGridCorrecoes.AllowUserToResizeColumns = false;
            this.dataGridCorrecoes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridCorrecoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCorrecoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCorrecoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCorrecoes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridCorrecoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCorrecoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridCorrecoes.ColumnHeadersHeight = 28;
            this.dataGridCorrecoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3});
            this.dataGridCorrecoes.ContextMenuStrip = this.contextMenu;
            this.dataGridCorrecoes.EnableHeadersVisualStyles = false;
            this.dataGridCorrecoes.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridCorrecoes.Location = new System.Drawing.Point(12, 123);
            this.dataGridCorrecoes.Name = "dataGridCorrecoes";
            this.dataGridCorrecoes.ReadOnly = true;
            this.dataGridCorrecoes.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridCorrecoes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridCorrecoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCorrecoes.Size = new System.Drawing.Size(735, 99);
            this.dataGridCorrecoes.TabIndex = 493;
            this.dataGridCorrecoes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridCorrecoes_CellMouseDown);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 90F;
            this.Column3.HeaderText = "Correção";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
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
            this.buttonAdicionar.Location = new System.Drawing.Point(12, 87);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdicionar.Size = new System.Drawing.Size(735, 30);
            this.buttonAdicionar.TabIndex = 494;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // textBoxResultado
            // 
            this.textBoxResultado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResultado.Location = new System.Drawing.Point(12, 264);
            this.textBoxResultado.Multiline = true;
            this.textBoxResultado.Name = "textBoxResultado";
            this.textBoxResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultado.Size = new System.Drawing.Size(735, 104);
            this.textBoxResultado.TabIndex = 495;
            this.textBoxResultado.Leave += new System.EventHandler(this.textBoxResultado_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(298, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 496;
            this.label1.Text = "Resultado esperado";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExcluir});
            this.contextMenu.Name = "contextMenuProcedimento";
            this.contextMenu.Size = new System.Drawing.Size(109, 26);
            // 
            // toolStripMenuItemExcluir
            // 
            this.toolStripMenuItemExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExcluir.Image")));
            this.toolStripMenuItemExcluir.Name = "toolStripMenuItemExcluir";
            this.toolStripMenuItemExcluir.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItemExcluir.Text = "Excluir";
            this.toolStripMenuItemExcluir.Click += new System.EventHandler(this.toolStripMenuItemExcluir_Click);
            // 
            // formAtividadesCadastrarResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxResultado);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.dataGridCorrecoes);
            this.Controls.Add(this.textBoxCorrecao);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAtividadesCadastrarResultado";
            this.Text = "formAtividadesCadastrarResultado";
            this.Load += new System.EventHandler(this.formAtividadesCadastrarResultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCorrecoes)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxCorrecao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridCorrecoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.TextBox textBoxResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExcluir;
    }
}