
namespace MarbaSoftware
{
    partial class formAtividadesCadastrarProcedimentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAtividadesCadastrarProcedimentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResumo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProcedimento = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.buttonSubir = new System.Windows.Forms.Button();
            this.buttonDescer = new System.Windows.Forms.Button();
            this.textBoxDetalhes = new System.Windows.Forms.TextBox();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.ordemTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuProcedimento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuProcedimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.Color.White;
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Red;
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdicionar.Location = new System.Drawing.Point(652, 108);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.buttonAdicionar.Size = new System.Drawing.Size(95, 60);
            this.buttonAdicionar.TabIndex = 3;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gray;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Location = new System.Drawing.Point(15, 61);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(729, 1);
            this.panel7.TabIndex = 474;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 16);
            this.label2.TabIndex = 473;
            this.label2.Text = "Digite um resumo da etapa (título):";
            // 
            // textBoxResumo
            // 
            this.textBoxResumo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResumo.Location = new System.Drawing.Point(15, 28);
            this.textBoxResumo.Name = "textBoxResumo";
            this.textBoxResumo.Size = new System.Drawing.Size(729, 26);
            this.textBoxResumo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 16);
            this.label1.TabIndex = 472;
            this.label1.Text = "Digite a etapa detalhadamente:";
            // 
            // textBoxProcedimento
            // 
            this.textBoxProcedimento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProcedimento.Location = new System.Drawing.Point(12, 103);
            this.textBoxProcedimento.Multiline = true;
            this.textBoxProcedimento.Name = "textBoxProcedimento";
            this.textBoxProcedimento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProcedimento.Size = new System.Drawing.Size(633, 65);
            this.textBoxProcedimento.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.buttonSubir);
            this.panel11.Controls.Add(this.buttonDescer);
            this.panel11.Location = new System.Drawing.Point(690, 189);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(54, 179);
            this.panel11.TabIndex = 491;
            // 
            // buttonSubir
            // 
            this.buttonSubir.BackColor = System.Drawing.Color.White;
            this.buttonSubir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSubir.BackgroundImage")));
            this.buttonSubir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubir.ForeColor = System.Drawing.Color.Black;
            this.buttonSubir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSubir.Image")));
            this.buttonSubir.Location = new System.Drawing.Point(11, 11);
            this.buttonSubir.Name = "buttonSubir";
            this.buttonSubir.Size = new System.Drawing.Size(30, 66);
            this.buttonSubir.TabIndex = 485;
            this.buttonSubir.UseVisualStyleBackColor = false;
            this.buttonSubir.Click += new System.EventHandler(this.buttonSubir_Click);
            // 
            // buttonDescer
            // 
            this.buttonDescer.BackColor = System.Drawing.Color.White;
            this.buttonDescer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDescer.BackgroundImage")));
            this.buttonDescer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDescer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDescer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDescer.ForeColor = System.Drawing.Color.Black;
            this.buttonDescer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDescer.Image")));
            this.buttonDescer.Location = new System.Drawing.Point(11, 96);
            this.buttonDescer.Name = "buttonDescer";
            this.buttonDescer.Size = new System.Drawing.Size(30, 63);
            this.buttonDescer.TabIndex = 486;
            this.buttonDescer.UseVisualStyleBackColor = false;
            this.buttonDescer.Click += new System.EventHandler(this.buttonDescer_Click);
            // 
            // textBoxDetalhes
            // 
            this.textBoxDetalhes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDetalhes.Location = new System.Drawing.Point(336, 305);
            this.textBoxDetalhes.Multiline = true;
            this.textBoxDetalhes.Name = "textBoxDetalhes";
            this.textBoxDetalhes.Size = new System.Drawing.Size(188, 20);
            this.textBoxDetalhes.TabIndex = 490;
            this.textBoxDetalhes.Visible = false;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.Column3});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuProcedimento;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(15, 189);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(669, 179);
            this.dataGridViewLista.TabIndex = 492;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellMouseLeave);
            this.dataGridViewLista.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseMove);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 10F;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 90F;
            this.Column3.HeaderText = "Procedimento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(646, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 494;
            this.label4.Text = "N°";
            // 
            // ordemTextBox
            // 
            this.ordemTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ordemTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordemTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.ordemTextBox.Location = new System.Drawing.Point(674, 71);
            this.ordemTextBox.Name = "ordemTextBox";
            this.ordemTextBox.ReadOnly = true;
            this.ordemTextBox.Size = new System.Drawing.Size(70, 26);
            this.ordemTextBox.TabIndex = 493;
            this.ordemTextBox.TabStop = false;
            this.ordemTextBox.Text = "1";
            this.ordemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuProcedimento
            // 
            this.contextMenuProcedimento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExcluir});
            this.contextMenuProcedimento.Name = "contextMenuProcedimento";
            this.contextMenuProcedimento.Size = new System.Drawing.Size(109, 26);
            // 
            // toolStripMenuItemExcluir
            // 
            this.toolStripMenuItemExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExcluir.Image")));
            this.toolStripMenuItemExcluir.Name = "toolStripMenuItemExcluir";
            this.toolStripMenuItemExcluir.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItemExcluir.Text = "Excluir";
            this.toolStripMenuItemExcluir.Click += new System.EventHandler(this.toolStripMenuItemExcluir_Click);
            // 
            // formAtividadesCadastrarProcedimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 380);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ordemTextBox);
            this.Controls.Add(this.textBoxDetalhes);
            this.Controls.Add(this.dataGridViewLista);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxResumo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProcedimento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAtividadesCadastrarProcedimentos";
            this.Text = "formAtividadesCadastrarProcedimentos";
            this.Load += new System.EventHandler(this.formAtividadesCadastrarProcedimentos_Load);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuProcedimento.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResumo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProcedimento;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button buttonSubir;
        private System.Windows.Forms.Button buttonDescer;
        private System.Windows.Forms.TextBox textBoxDetalhes;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ordemTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuProcedimento;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExcluir;
    }
}