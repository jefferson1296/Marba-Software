
namespace MarbaSoftware
{
    partial class formColaboradores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formColaboradores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.permissõesDeAcessoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirHorárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definirEscalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definirTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demitirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAcessos = new System.Windows.Forms.Button();
            this.buttonTurnos = new System.Windows.Forms.Button();
            this.buttonLicencas = new System.Windows.Forms.Button();
            this.buttonFeriados = new System.Windows.Forms.Button();
            this.labelDigital = new System.Windows.Forms.Label();
            this.checkBoxInativo = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imprimirEscalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.BackColor = System.Drawing.Color.Red;
            this.buttonCadastrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.BackgroundImage")));
            this.buttonCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCadastrar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.ForeColor = System.Drawing.Color.Red;
            this.buttonCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.Image")));
            this.buttonCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCadastrar.Location = new System.Drawing.Point(15, 12);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(140, 32);
            this.buttonCadastrar.TabIndex = 530;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 40;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column5});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(1067, 383);
            this.dataGridViewLista.TabIndex = 529;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // N
            // 
            this.N.FillWeight = 20F;
            this.N.HeaderText = "N°";
            this.N.Name = "N";
            this.N.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nome";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Cargo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Setor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Matrícula";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permissõesDeAcessoToolStripMenuItem,
            this.imprimirHorárioToolStripMenuItem,
            this.escalaToolStripMenuItem,
            this.demitirToolStripMenuItem,
            this.pontoToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 136);
            // 
            // permissõesDeAcessoToolStripMenuItem
            // 
            this.permissõesDeAcessoToolStripMenuItem.Name = "permissõesDeAcessoToolStripMenuItem";
            this.permissõesDeAcessoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.permissõesDeAcessoToolStripMenuItem.Text = "Permissões de acesso";
            this.permissõesDeAcessoToolStripMenuItem.Click += new System.EventHandler(this.permissõesDeAcessoToolStripMenuItem_Click);
            // 
            // imprimirHorárioToolStripMenuItem
            // 
            this.imprimirHorárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.imprimirHorárioToolStripMenuItem.Enabled = false;
            this.imprimirHorárioToolStripMenuItem.Name = "imprimirHorárioToolStripMenuItem";
            this.imprimirHorárioToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.imprimirHorárioToolStripMenuItem.Text = "Horário semanal";
            this.imprimirHorárioToolStripMenuItem.Click += new System.EventHandler(this.imprimirHorárioToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripMenuItem.Image")));
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportarToolStripMenuItem.Image")));
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // escalaToolStripMenuItem
            // 
            this.escalaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.definirEscalaToolStripMenuItem,
            this.definirTurnosToolStripMenuItem,
            this.imprimirEscalaToolStripMenuItem});
            this.escalaToolStripMenuItem.Name = "escalaToolStripMenuItem";
            this.escalaToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.escalaToolStripMenuItem.Text = "Escala";
            // 
            // definirEscalaToolStripMenuItem
            // 
            this.definirEscalaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("definirEscalaToolStripMenuItem.Image")));
            this.definirEscalaToolStripMenuItem.Name = "definirEscalaToolStripMenuItem";
            this.definirEscalaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.definirEscalaToolStripMenuItem.Text = "Definir escala";
            this.definirEscalaToolStripMenuItem.Click += new System.EventHandler(this.definirEscalaToolStripMenuItem_Click);
            // 
            // definirTurnosToolStripMenuItem
            // 
            this.definirTurnosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("definirTurnosToolStripMenuItem.Image")));
            this.definirTurnosToolStripMenuItem.Name = "definirTurnosToolStripMenuItem";
            this.definirTurnosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.definirTurnosToolStripMenuItem.Text = "Alternar turnos";
            this.definirTurnosToolStripMenuItem.Click += new System.EventHandler(this.definirTurnosToolStripMenuItem_Click);
            // 
            // demitirToolStripMenuItem
            // 
            this.demitirToolStripMenuItem.Name = "demitirToolStripMenuItem";
            this.demitirToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.demitirToolStripMenuItem.Text = "Registrar demissão";
            this.demitirToolStripMenuItem.Click += new System.EventHandler(this.demitirToolStripMenuItem_Click);
            // 
            // pontoToolStripMenuItem
            // 
            this.pontoToolStripMenuItem.Name = "pontoToolStripMenuItem";
            this.pontoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pontoToolStripMenuItem.Text = "Folha de ponto";
            this.pontoToolStripMenuItem.Click += new System.EventHandler(this.pontoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(785, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 531;
            this.button1.Text = "Setores";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(922, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 32);
            this.button2.TabIndex = 532;
            this.button2.Text = "Cargos";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonAcessos
            // 
            this.buttonAcessos.BackColor = System.Drawing.Color.Transparent;
            this.buttonAcessos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAcessos.BackgroundImage")));
            this.buttonAcessos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAcessos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcessos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcessos.ForeColor = System.Drawing.Color.White;
            this.buttonAcessos.Location = new System.Drawing.Point(648, 12);
            this.buttonAcessos.Name = "buttonAcessos";
            this.buttonAcessos.Size = new System.Drawing.Size(130, 32);
            this.buttonAcessos.TabIndex = 533;
            this.buttonAcessos.Text = "Acessos";
            this.buttonAcessos.UseVisualStyleBackColor = false;
            this.buttonAcessos.Click += new System.EventHandler(this.buttonAcessos_Click);
            // 
            // buttonTurnos
            // 
            this.buttonTurnos.BackColor = System.Drawing.Color.Transparent;
            this.buttonTurnos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTurnos.BackgroundImage")));
            this.buttonTurnos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTurnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTurnos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurnos.ForeColor = System.Drawing.Color.White;
            this.buttonTurnos.Location = new System.Drawing.Point(511, 12);
            this.buttonTurnos.Name = "buttonTurnos";
            this.buttonTurnos.Size = new System.Drawing.Size(130, 32);
            this.buttonTurnos.TabIndex = 534;
            this.buttonTurnos.Text = "Turnos";
            this.buttonTurnos.UseVisualStyleBackColor = false;
            this.buttonTurnos.Click += new System.EventHandler(this.buttonTurnos_Click);
            // 
            // buttonLicencas
            // 
            this.buttonLicencas.BackColor = System.Drawing.Color.Transparent;
            this.buttonLicencas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLicencas.BackgroundImage")));
            this.buttonLicencas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLicencas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLicencas.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLicencas.ForeColor = System.Drawing.Color.White;
            this.buttonLicencas.Location = new System.Drawing.Point(374, 12);
            this.buttonLicencas.Name = "buttonLicencas";
            this.buttonLicencas.Size = new System.Drawing.Size(130, 32);
            this.buttonLicencas.TabIndex = 535;
            this.buttonLicencas.Text = "Licenças e férias";
            this.buttonLicencas.UseVisualStyleBackColor = false;
            this.buttonLicencas.Click += new System.EventHandler(this.buttonLicencas_Click);
            // 
            // buttonFeriados
            // 
            this.buttonFeriados.BackColor = System.Drawing.Color.Transparent;
            this.buttonFeriados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFeriados.BackgroundImage")));
            this.buttonFeriados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFeriados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFeriados.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFeriados.ForeColor = System.Drawing.Color.White;
            this.buttonFeriados.Location = new System.Drawing.Point(237, 12);
            this.buttonFeriados.Name = "buttonFeriados";
            this.buttonFeriados.Size = new System.Drawing.Size(130, 32);
            this.buttonFeriados.TabIndex = 536;
            this.buttonFeriados.Text = "Feriados";
            this.buttonFeriados.UseVisualStyleBackColor = false;
            this.buttonFeriados.Click += new System.EventHandler(this.buttonFeriados_Click);
            // 
            // labelDigital
            // 
            this.labelDigital.AutoSize = true;
            this.labelDigital.BackColor = System.Drawing.Color.Transparent;
            this.labelDigital.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDigital.Font = new System.Drawing.Font("Arial Narrow", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDigital.Location = new System.Drawing.Point(170, 20);
            this.labelDigital.Name = "labelDigital";
            this.labelDigital.Size = new System.Drawing.Size(83, 15);
            this.labelDigital.TabIndex = 537;
            this.labelDigital.Text = "Cadastrar digital";
            this.labelDigital.Click += new System.EventHandler(this.labelDigital_Click);
            // 
            // checkBoxInativo
            // 
            this.checkBoxInativo.AutoSize = true;
            this.checkBoxInativo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxInativo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxInativo.Location = new System.Drawing.Point(960, 50);
            this.checkBoxInativo.Name = "checkBoxInativo";
            this.checkBoxInativo.Size = new System.Drawing.Size(90, 19);
            this.checkBoxInativo.TabIndex = 538;
            this.checkBoxInativo.Text = "Mostrar inativos";
            this.checkBoxInativo.UseVisualStyleBackColor = true;
            this.checkBoxInativo.CheckedChanged += new System.EventHandler(this.checkBoxInativo_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExportar);
            this.panel1.Controls.Add(this.labelDigital);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 60);
            this.panel1.TabIndex = 539;
            // 
            // buttonExportar
            // 
            this.buttonExportar.BackColor = System.Drawing.Color.Transparent;
            this.buttonExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportar.ForeColor = System.Drawing.Color.Gray;
            this.buttonExportar.Location = new System.Drawing.Point(15, 15);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(130, 25);
            this.buttonExportar.TabIndex = 537;
            this.buttonExportar.Text = "Imprimir escala";
            this.buttonExportar.UseVisualStyleBackColor = false;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.buttonCadastrar);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.checkBoxInativo);
            this.panel2.Controls.Add(this.buttonAcessos);
            this.panel2.Controls.Add(this.buttonTurnos);
            this.panel2.Controls.Add(this.buttonFeriados);
            this.panel2.Controls.Add(this.buttonLicencas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 80);
            this.panel2.TabIndex = 540;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewLista);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 383);
            this.panel3.TabIndex = 541;
            // 
            // imprimirEscalaToolStripMenuItem
            // 
            this.imprimirEscalaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirEscalaToolStripMenuItem.Image")));
            this.imprimirEscalaToolStripMenuItem.Name = "imprimirEscalaToolStripMenuItem";
            this.imprimirEscalaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imprimirEscalaToolStripMenuItem.Text = "Imprimir escala";
            this.imprimirEscalaToolStripMenuItem.Click += new System.EventHandler(this.imprimirEscalaToolStripMenuItem_Click);
            // 
            // formColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 523);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formColaboradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colaboradores";
            this.Load += new System.EventHandler(this.formColaboradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imprimirHorárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissõesDeAcessoToolStripMenuItem;
        private System.Windows.Forms.Button buttonAcessos;
        private System.Windows.Forms.ToolStripMenuItem escalaToolStripMenuItem;
        private System.Windows.Forms.Button buttonTurnos;
        private System.Windows.Forms.Button buttonLicencas;
        private System.Windows.Forms.Button buttonFeriados;
        private System.Windows.Forms.Label labelDigital;
        private System.Windows.Forms.CheckBox checkBoxInativo;
        private System.Windows.Forms.ToolStripMenuItem demitirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem definirEscalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definirTurnosToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem imprimirEscalaToolStripMenuItem;
    }
}