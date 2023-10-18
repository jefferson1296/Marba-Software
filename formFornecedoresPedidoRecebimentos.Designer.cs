
namespace MarbaSoftware
{
    partial class formFornecedoresPedidoRecebimentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFornecedoresPedidoRecebimentos));
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmarRecebimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirCupomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.menuStripData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 28;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column1});
            this.dataGridViewLista.ContextMenuStrip = this.menuStripData;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 35);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(519, 248);
            this.dataGridViewLista.TabIndex = 516;
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Column2
            // 
            this.Column2.FillWeight = 20F;
            this.Column2.HeaderText = "N°";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fornecedor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "Data";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // menuStripData
            // 
            this.menuStripData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarDataToolStripMenuItem,
            this.confirmarRecebimentoToolStripMenuItem,
            this.imprimirCupomToolStripMenuItem});
            this.menuStripData.Name = "menuStripData";
            this.menuStripData.Size = new System.Drawing.Size(199, 70);
            // 
            // alterarDataToolStripMenuItem
            // 
            this.alterarDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alterarDataToolStripMenuItem.Image")));
            this.alterarDataToolStripMenuItem.Name = "alterarDataToolStripMenuItem";
            this.alterarDataToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.alterarDataToolStripMenuItem.Text = "Alterar data";
            this.alterarDataToolStripMenuItem.Click += new System.EventHandler(this.alterarDataToolStripMenuItem_Click);
            // 
            // confirmarRecebimentoToolStripMenuItem
            // 
            this.confirmarRecebimentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("confirmarRecebimentoToolStripMenuItem.Image")));
            this.confirmarRecebimentoToolStripMenuItem.Name = "confirmarRecebimentoToolStripMenuItem";
            this.confirmarRecebimentoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.confirmarRecebimentoToolStripMenuItem.Text = "Confirmar recebimento";
            this.confirmarRecebimentoToolStripMenuItem.Click += new System.EventHandler(this.confirmarRecebimentoToolStripMenuItem_Click);
            // 
            // imprimirCupomToolStripMenuItem
            // 
            this.imprimirCupomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirCupomToolStripMenuItem.Image")));
            this.imprimirCupomToolStripMenuItem.Name = "imprimirCupomToolStripMenuItem";
            this.imprimirCupomToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.imprimirCupomToolStripMenuItem.Text = "Imprimir cupom";
            this.imprimirCupomToolStripMenuItem.Click += new System.EventHandler(this.imprimirCupomToolStripMenuItem_Click);
            // 
            // formFornecedoresPedidoRecebimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(519, 283);
            this.Controls.Add(this.dataGridViewLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formFornecedoresPedidoRecebimentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Próximos recebimentos";
            this.Load += new System.EventHandler(this.formFornecedoresPedidoProximos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formFornecedoresPedidoProximos_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formFornecedoresPedidoProximos_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formFornecedoresPedidoProximos_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.menuStripData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.ContextMenuStrip menuStripData;
        private System.Windows.Forms.ToolStripMenuItem alterarDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmarRecebimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirCupomToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}