
namespace MarbaSoftware
{
    partial class formGestaoExpedientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoExpedientes));
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Previsao_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prev_Lanche_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lanche_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prev_Lanche_Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lanche_Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prev_Almoco_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Almoco_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prev_Almoco_Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Almoco_Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Previsao_Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Termino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liberarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirEscalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.verificarButton = new System.Windows.Forms.Button();
            this.buttonDeslocar = new System.Windows.Forms.Button();
            this.buttonApagar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbProximo = new System.Windows.Forms.PictureBox();
            this.pbAnterior = new System.Windows.Forms.PictureBox();
            this.labelImprimir = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column16,
            this.Previsao_Inicio,
            this.Inicio,
            this.Prev_Lanche_Inicio,
            this.Lanche_Inicio,
            this.Prev_Lanche_Termino,
            this.Lanche_Termino,
            this.Prev_Almoco_Inicio,
            this.Almoco_Inicio,
            this.Prev_Almoco_Termino,
            this.Almoco_Termino,
            this.Previsao_Termino,
            this.Termino,
            this.Column6});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1484, 360);
            this.dataGridViewLista.TabIndex = 65;
            this.dataGridViewLista.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewLista_CellBeginEdit);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellEndEdit);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewLista_Scroll);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.FillWeight = 250F;
            this.Column1.HeaderText = "Colaborador";
            this.Column1.Name = "Column1";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Status";
            this.Column16.Name = "Column16";
            // 
            // Previsao_Inicio
            // 
            this.Previsao_Inicio.FillWeight = 75F;
            this.Previsao_Inicio.HeaderText = "Previsão de início";
            this.Previsao_Inicio.Name = "Previsao_Inicio";
            // 
            // Inicio
            // 
            this.Inicio.FillWeight = 75F;
            this.Inicio.HeaderText = "Início do serviço";
            this.Inicio.Name = "Inicio";
            // 
            // Prev_Lanche_Inicio
            // 
            this.Prev_Lanche_Inicio.FillWeight = 75F;
            this.Prev_Lanche_Inicio.HeaderText = "Previsão de lanche (início)";
            this.Prev_Lanche_Inicio.Name = "Prev_Lanche_Inicio";
            // 
            // Lanche_Inicio
            // 
            this.Lanche_Inicio.FillWeight = 75F;
            this.Lanche_Inicio.HeaderText = "Lanche (início)";
            this.Lanche_Inicio.Name = "Lanche_Inicio";
            // 
            // Prev_Lanche_Termino
            // 
            this.Prev_Lanche_Termino.FillWeight = 75F;
            this.Prev_Lanche_Termino.HeaderText = "Previsão de lanche (término)";
            this.Prev_Lanche_Termino.Name = "Prev_Lanche_Termino";
            // 
            // Lanche_Termino
            // 
            this.Lanche_Termino.FillWeight = 75F;
            this.Lanche_Termino.HeaderText = "Lanche (término)";
            this.Lanche_Termino.Name = "Lanche_Termino";
            // 
            // Prev_Almoco_Inicio
            // 
            this.Prev_Almoco_Inicio.FillWeight = 75F;
            this.Prev_Almoco_Inicio.HeaderText = "Previsão de almoço (início)";
            this.Prev_Almoco_Inicio.Name = "Prev_Almoco_Inicio";
            // 
            // Almoco_Inicio
            // 
            this.Almoco_Inicio.FillWeight = 75F;
            this.Almoco_Inicio.HeaderText = "Almoço (início)";
            this.Almoco_Inicio.Name = "Almoco_Inicio";
            // 
            // Prev_Almoco_Termino
            // 
            this.Prev_Almoco_Termino.FillWeight = 75F;
            this.Prev_Almoco_Termino.HeaderText = "Previsão de almoço (término)";
            this.Prev_Almoco_Termino.Name = "Prev_Almoco_Termino";
            // 
            // Almoco_Termino
            // 
            this.Almoco_Termino.FillWeight = 75F;
            this.Almoco_Termino.HeaderText = "Almoço (término)";
            this.Almoco_Termino.Name = "Almoco_Termino";
            // 
            // Previsao_Termino
            // 
            this.Previsao_Termino.FillWeight = 75F;
            this.Previsao_Termino.HeaderText = "Previsão de término";
            this.Previsao_Termino.Name = "Previsao_Termino";
            // 
            // Termino
            // 
            this.Termino.FillWeight = 75F;
            this.Termino.HeaderText = "Término do serviço";
            this.Termino.Name = "Termino";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Atividade";
            this.Column6.Name = "Column6";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarRegistrosToolStripMenuItem,
            this.liberarToolStripMenuItem,
            this.imprimirEscalaToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(158, 70);
            // 
            // alterarRegistrosToolStripMenuItem
            // 
            this.alterarRegistrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alterarRegistrosToolStripMenuItem.Image")));
            this.alterarRegistrosToolStripMenuItem.Name = "alterarRegistrosToolStripMenuItem";
            this.alterarRegistrosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.alterarRegistrosToolStripMenuItem.Text = "Alterar registros";
            this.alterarRegistrosToolStripMenuItem.Click += new System.EventHandler(this.alterarRegistrosToolStripMenuItem_Click);
            // 
            // liberarToolStripMenuItem
            // 
            this.liberarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("liberarToolStripMenuItem.Image")));
            this.liberarToolStripMenuItem.Name = "liberarToolStripMenuItem";
            this.liberarToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.liberarToolStripMenuItem.Text = "Liberar";
            this.liberarToolStripMenuItem.Click += new System.EventHandler(this.liberarToolStripMenuItem_Click);
            // 
            // imprimirEscalaToolStripMenuItem
            // 
            this.imprimirEscalaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirEscalaToolStripMenuItem.Image")));
            this.imprimirEscalaToolStripMenuItem.Name = "imprimirEscalaToolStripMenuItem";
            this.imprimirEscalaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.imprimirEscalaToolStripMenuItem.Text = "Imprimir escala";
            this.imprimirEscalaToolStripMenuItem.Click += new System.EventHandler(this.imprimirEscalaToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 26);
            this.dateTimePicker1.TabIndex = 490;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // verificarButton
            // 
            this.verificarButton.BackColor = System.Drawing.Color.White;
            this.verificarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("verificarButton.BackgroundImage")));
            this.verificarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verificarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verificarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verificarButton.ForeColor = System.Drawing.Color.White;
            this.verificarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verificarButton.Location = new System.Drawing.Point(156, 24);
            this.verificarButton.Name = "verificarButton";
            this.verificarButton.Size = new System.Drawing.Size(112, 26);
            this.verificarButton.TabIndex = 491;
            this.verificarButton.Text = "Atualizar";
            this.verificarButton.UseVisualStyleBackColor = false;
            this.verificarButton.Click += new System.EventHandler(this.verificarButton_Click);
            // 
            // buttonDeslocar
            // 
            this.buttonDeslocar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeslocar.BackColor = System.Drawing.Color.Red;
            this.buttonDeslocar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeslocar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeslocar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonDeslocar.FlatAppearance.BorderSize = 2;
            this.buttonDeslocar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeslocar.ForeColor = System.Drawing.Color.White;
            this.buttonDeslocar.Location = new System.Drawing.Point(1156, 20);
            this.buttonDeslocar.Name = "buttonDeslocar";
            this.buttonDeslocar.Size = new System.Drawing.Size(150, 30);
            this.buttonDeslocar.TabIndex = 492;
            this.buttonDeslocar.Text = "Deslocar horários";
            this.buttonDeslocar.UseVisualStyleBackColor = false;
            this.buttonDeslocar.Click += new System.EventHandler(this.buttonDeslocar_Click);
            // 
            // buttonApagar
            // 
            this.buttonApagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApagar.BackColor = System.Drawing.Color.Red;
            this.buttonApagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonApagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApagar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonApagar.FlatAppearance.BorderSize = 2;
            this.buttonApagar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApagar.ForeColor = System.Drawing.Color.White;
            this.buttonApagar.Location = new System.Drawing.Point(1312, 20);
            this.buttonApagar.Name = "buttonApagar";
            this.buttonApagar.Size = new System.Drawing.Size(150, 30);
            this.buttonApagar.TabIndex = 493;
            this.buttonApagar.Text = "Apagar registros";
            this.buttonApagar.UseVisualStyleBackColor = false;
            this.buttonApagar.Click += new System.EventHandler(this.buttonApagar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1484, 79);
            this.panel1.TabIndex = 494;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1484, 360);
            this.panel2.TabIndex = 496;
            // 
            // pbProximo
            // 
            this.pbProximo.BackColor = System.Drawing.Color.Transparent;
            this.pbProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbProximo.Image = ((System.Drawing.Image)(resources.GetObject("pbProximo.Image")));
            this.pbProximo.Location = new System.Drawing.Point(316, 28);
            this.pbProximo.Name = "pbProximo";
            this.pbProximo.Size = new System.Drawing.Size(20, 20);
            this.pbProximo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProximo.TabIndex = 498;
            this.pbProximo.TabStop = false;
            this.pbProximo.Click += new System.EventHandler(this.pbProximo_Click);
            // 
            // pbAnterior
            // 
            this.pbAnterior.BackColor = System.Drawing.Color.Transparent;
            this.pbAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("pbAnterior.Image")));
            this.pbAnterior.Location = new System.Drawing.Point(285, 28);
            this.pbAnterior.Name = "pbAnterior";
            this.pbAnterior.Size = new System.Drawing.Size(20, 20);
            this.pbAnterior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnterior.TabIndex = 497;
            this.pbAnterior.TabStop = false;
            this.pbAnterior.Click += new System.EventHandler(this.pbAnterior_Click);
            // 
            // labelImprimir
            // 
            this.labelImprimir.AutoSize = true;
            this.labelImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelImprimir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImprimir.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelImprimir.Location = new System.Drawing.Point(26, 26);
            this.labelImprimir.Name = "labelImprimir";
            this.labelImprimir.Size = new System.Drawing.Size(121, 16);
            this.labelImprimir.TabIndex = 0;
            this.labelImprimir.Text = "Imprimir expediente";
            this.labelImprimir.Click += new System.EventHandler(this.labelImprimir_Click);
            // 
            // formGestaoExpedientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 506);
            this.Controls.Add(this.pbProximo);
            this.Controls.Add(this.pbAnterior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonApagar);
            this.Controls.Add(this.buttonDeslocar);
            this.Controls.Add(this.verificarButton);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoExpedientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expedientes";
            this.Load += new System.EventHandler(this.formTelaInicialAtividadesExpedientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button verificarButton;
        private System.Windows.Forms.Button buttonDeslocar;
        private System.Windows.Forms.Button buttonApagar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem alterarRegistrosToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbProximo;
        private System.Windows.Forms.PictureBox pbAnterior;
        private System.Windows.Forms.ToolStripMenuItem liberarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Previsao_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prev_Lanche_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lanche_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prev_Lanche_Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lanche_Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prev_Almoco_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Almoco_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prev_Almoco_Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Almoco_Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Previsao_Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Termino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolStripMenuItem imprimirEscalaToolStripMenuItem;
        private System.Windows.Forms.Label labelImprimir;
    }
}