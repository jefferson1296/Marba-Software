
namespace MarbaSoftware
{
    partial class formTelaInicialPrincipalGerenteFinanceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialPrincipalGerenteFinanceiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTranferencias = new System.Windows.Forms.Button();
            this.buttonMovimentacao = new System.Windows.Forms.Button();
            this.buttonSangrias = new System.Windows.Forms.Button();
            this.DataGridViewFluxo = new ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceFluxo = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFluxo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonTranferencias);
            this.panel1.Controls.Add(this.buttonMovimentacao);
            this.panel1.Controls.Add(this.buttonSangrias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 56);
            this.panel1.TabIndex = 68;
            // 
            // buttonTranferencias
            // 
            this.buttonTranferencias.BackColor = System.Drawing.Color.MistyRose;
            this.buttonTranferencias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTranferencias.BackgroundImage")));
            this.buttonTranferencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTranferencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTranferencias.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonTranferencias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTranferencias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonTranferencias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranferencias.ForeColor = System.Drawing.Color.White;
            this.buttonTranferencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTranferencias.Location = new System.Drawing.Point(365, 12);
            this.buttonTranferencias.Name = "buttonTranferencias";
            this.buttonTranferencias.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonTranferencias.Size = new System.Drawing.Size(183, 34);
            this.buttonTranferencias.TabIndex = 60;
            this.buttonTranferencias.Text = "Transferência";
            this.buttonTranferencias.UseVisualStyleBackColor = false;
            this.buttonTranferencias.Click += new System.EventHandler(this.buttonTranferencias_Click);
            // 
            // buttonMovimentacao
            // 
            this.buttonMovimentacao.BackColor = System.Drawing.Color.MistyRose;
            this.buttonMovimentacao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMovimentacao.BackgroundImage")));
            this.buttonMovimentacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMovimentacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMovimentacao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonMovimentacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMovimentacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.buttonMovimentacao.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovimentacao.ForeColor = System.Drawing.Color.White;
            this.buttonMovimentacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMovimentacao.Location = new System.Drawing.Point(182, 12);
            this.buttonMovimentacao.Name = "buttonMovimentacao";
            this.buttonMovimentacao.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonMovimentacao.Size = new System.Drawing.Size(177, 34);
            this.buttonMovimentacao.TabIndex = 59;
            this.buttonMovimentacao.Text = "Movimentação";
            this.buttonMovimentacao.UseVisualStyleBackColor = false;
            this.buttonMovimentacao.Click += new System.EventHandler(this.buttonMovimentacao_Click);
            // 
            // buttonSangrias
            // 
            this.buttonSangrias.BackColor = System.Drawing.Color.Red;
            this.buttonSangrias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSangrias.BackgroundImage")));
            this.buttonSangrias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSangrias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSangrias.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSangrias.FlatAppearance.BorderSize = 5;
            this.buttonSangrias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSangrias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonSangrias.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSangrias.ForeColor = System.Drawing.Color.White;
            this.buttonSangrias.Location = new System.Drawing.Point(12, 12);
            this.buttonSangrias.Name = "buttonSangrias";
            this.buttonSangrias.Size = new System.Drawing.Size(164, 35);
            this.buttonSangrias.TabIndex = 58;
            this.buttonSangrias.Text = "Sangrias / Suprimentos";
            this.buttonSangrias.UseVisualStyleBackColor = false;
            this.buttonSangrias.Click += new System.EventHandler(this.buttonSangrias_Click);
            // 
            // DataGridViewFluxo
            // 
            this.DataGridViewFluxo.AllowUserToAddRows = false;
            this.DataGridViewFluxo.AllowUserToDeleteRows = false;
            this.DataGridViewFluxo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewFluxo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewFluxo.AutoGenerateContextFilters = true;
            this.DataGridViewFluxo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewFluxo.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewFluxo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridViewFluxo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFluxo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewFluxo.ColumnHeadersHeight = 60;
            this.DataGridViewFluxo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column14});
            this.DataGridViewFluxo.DateWithTime = false;
            this.DataGridViewFluxo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewFluxo.EnableHeadersVisualStyles = false;
            this.DataGridViewFluxo.GridColor = System.Drawing.Color.LightGray;
            this.DataGridViewFluxo.Location = new System.Drawing.Point(0, 56);
            this.DataGridViewFluxo.Name = "DataGridViewFluxo";
            this.DataGridViewFluxo.ReadOnly = true;
            this.DataGridViewFluxo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewFluxo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewFluxo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewFluxo.Size = new System.Drawing.Size(800, 394);
            this.DataGridViewFluxo.TabIndex = 69;
            this.DataGridViewFluxo.TimeFilter = false;
            this.DataGridViewFluxo.SortStringChanged += new System.EventHandler(this.DataGridViewFluxo_SortStringChanged);
            this.DataGridViewFluxo.FilterStringChanged += new System.EventHandler(this.DataGridViewFluxo_FilterStringChanged);
            this.DataGridViewFluxo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewFluxo_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID_Movimentacao";
            this.Column1.FillWeight = 35F;
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Descricao";
            this.Column9.FillWeight = 250F;
            this.Column9.HeaderText = "Descrição";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Valor";
            this.Column10.FillWeight = 75F;
            this.Column10.HeaderText = "Valor";
            this.Column10.MinimumWidth = 22;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Categoria";
            this.Column11.FillWeight = 130F;
            this.Column11.HeaderText = "Categoria";
            this.Column11.MinimumWidth = 22;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Data";
            this.Column14.FillWeight = 75F;
            this.Column14.HeaderText = "Data";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // formTelaInicialPrincipalGerenteFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGridViewFluxo);
            this.Controls.Add(this.panel1);
            this.Name = "formTelaInicialPrincipalGerenteFinanceiro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro";
            this.Load += new System.EventHandler(this.formTelaInicialPrincipalGerenteFinanceiro_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFluxo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSangrias;
        private ADGV.AdvancedDataGridView DataGridViewFluxo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.BindingSource bindingSourceFluxo;
        private System.Windows.Forms.Button buttonMovimentacao;
        private System.Windows.Forms.Button buttonTranferencias;
    }
}