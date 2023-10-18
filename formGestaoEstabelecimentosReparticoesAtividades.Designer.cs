
namespace MarbaSoftware
{
    partial class formGestaoEstabelecimentosReparticoesAtividades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoEstabelecimentosReparticoesAtividades));
            this.dataGridViewDisponiveis = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRelacionadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColaborador = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.intervalosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisponiveis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelacionadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDisponiveis
            // 
            this.dataGridViewDisponiveis.AllowDrop = true;
            this.dataGridViewDisponiveis.AllowUserToAddRows = false;
            this.dataGridViewDisponiveis.AllowUserToResizeColumns = false;
            this.dataGridViewDisponiveis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDisponiveis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDisponiveis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDisponiveis.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDisponiveis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisponiveis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDisponiveis.ColumnHeadersHeight = 28;
            this.dataGridViewDisponiveis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewDisponiveis.EnableHeadersVisualStyles = false;
            this.dataGridViewDisponiveis.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewDisponiveis.Location = new System.Drawing.Point(12, 24);
            this.dataGridViewDisponiveis.Name = "dataGridViewDisponiveis";
            this.dataGridViewDisponiveis.ReadOnly = true;
            this.dataGridViewDisponiveis.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDisponiveis.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDisponiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisponiveis.Size = new System.Drawing.Size(318, 395);
            this.dataGridViewDisponiveis.TabIndex = 69;
            this.dataGridViewDisponiveis.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDisponiveis_CellMouseDown);
            this.dataGridViewDisponiveis.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDisponiveis_CellMouseMove);
            this.dataGridViewDisponiveis.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewDisponiveis_DragDrop);
            this.dataGridViewDisponiveis.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewDisponiveis_DragEnter);
            this.dataGridViewDisponiveis.MouseLeave += new System.EventHandler(this.dataGridViewDisponiveis_MouseLeave);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Atividades disponíveis";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewRelacionadas
            // 
            this.dataGridViewRelacionadas.AllowDrop = true;
            this.dataGridViewRelacionadas.AllowUserToAddRows = false;
            this.dataGridViewRelacionadas.AllowUserToResizeColumns = false;
            this.dataGridViewRelacionadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewRelacionadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewRelacionadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRelacionadas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewRelacionadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRelacionadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewRelacionadas.ColumnHeadersHeight = 28;
            this.dataGridViewRelacionadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColumnColaborador});
            this.dataGridViewRelacionadas.ContextMenuStrip = this.contextMenu;
            this.dataGridViewRelacionadas.EnableHeadersVisualStyles = false;
            this.dataGridViewRelacionadas.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewRelacionadas.Location = new System.Drawing.Point(425, 24);
            this.dataGridViewRelacionadas.Name = "dataGridViewRelacionadas";
            this.dataGridViewRelacionadas.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewRelacionadas.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewRelacionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRelacionadas.Size = new System.Drawing.Size(526, 395);
            this.dataGridViewRelacionadas.TabIndex = 70;
            this.dataGridViewRelacionadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRelacionadas_CellClick);
            this.dataGridViewRelacionadas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRelacionadas_CellMouseDown);
            this.dataGridViewRelacionadas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRelacionadas_CellMouseMove);
            this.dataGridViewRelacionadas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRelacionadas_CellValueChanged);
            this.dataGridViewRelacionadas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewRelacionadas_CurrentCellDirtyStateChanged);
            this.dataGridViewRelacionadas.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewRelacionadas_DragDrop);
            this.dataGridViewRelacionadas.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewRelacionadas_DragEnter);
            this.dataGridViewRelacionadas.MouseLeave += new System.EventHandler(this.dataGridViewRelacionadas_MouseLeave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nome_Colaborador";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Atividades relacionadas à repartição";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // ColumnColaborador
            // 
            this.ColumnColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnColaborador.HeaderText = "Colaborador padrão";
            this.ColumnColaborador.Name = "ColumnColaborador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(346, 207);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalosToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // intervalosToolStripMenuItem
            // 
            this.intervalosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("intervalosToolStripMenuItem.Image")));
            this.intervalosToolStripMenuItem.Name = "intervalosToolStripMenuItem";
            this.intervalosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.intervalosToolStripMenuItem.Text = "Intervalos";
            this.intervalosToolStripMenuItem.Click += new System.EventHandler(this.intervalosToolStripMenuItem_Click);
            // 
            // formGestaoEstabelecimentosReparticoesAtividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewRelacionadas);
            this.Controls.Add(this.dataGridViewDisponiveis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoEstabelecimentosReparticoesAtividades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atividades da repartição";
            this.Load += new System.EventHandler(this.formGestaoEstabelecimentosReparticoesAtividades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisponiveis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelacionadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDisponiveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridViewRelacionadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnColaborador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem intervalosToolStripMenuItem;
    }
}