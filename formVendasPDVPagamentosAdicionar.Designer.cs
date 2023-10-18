
namespace MarbaSoftware
{
    partial class formVendasPDVPagamentosAdicionar
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
            System.Windows.Forms.PictureBox pictureBoxFechar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVendasPDVPagamentosAdicionar));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTroco = new System.Windows.Forms.TextBox();
            this.labelPagamento = new System.Windows.Forms.Label();
            this.comboBoxForma = new System.Windows.Forms.ComboBox();
            this.labelTroco = new System.Windows.Forms.Label();
            this.labelForma = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelValor = new System.Windows.Forms.Label();
            this.textBoxPagamento = new System.Windows.Forms.TextBox();
            this.textBoxPago = new System.Windows.Forms.TextBox();
            this.comboBoxBandeira = new System.Windows.Forms.ComboBox();
            this.labelBandeira = new System.Windows.Forms.Label();
            this.labelParcelas = new System.Windows.Forms.Label();
            this.comboBoxParcelas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRestante = new System.Windows.Forms.TextBox();
            this.linha = new System.Windows.Forms.Panel();
            this.labelPagar = new System.Windows.Forms.Label();
            this.textBoxPagar = new System.Windows.Forms.TextBox();
            this.labelJuros = new System.Windows.Forms.Label();
            this.textBoxJuros = new System.Windows.Forms.TextBox();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            pictureBoxFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).BeginInit();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxFechar
            // 
            pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            pictureBoxFechar.Location = new System.Drawing.Point(409, 4);
            pictureBoxFechar.Name = "pictureBoxFechar";
            pictureBoxFechar.Size = new System.Drawing.Size(15, 15);
            pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxFechar.TabIndex = 20;
            pictureBoxFechar.TabStop = false;
            pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Red;
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.label13);
            this.panelSuperior.Controls.Add(pictureBoxFechar);
            this.panelSuperior.Controls.Add(this.labelTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(428, 24);
            this.panelSuperior.TabIndex = 17;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 23);
            this.label13.TabIndex = 37;
            this.label13.Text = "$";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(29, 4);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(67, 16);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Pagamento";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 463);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(422, 3);
            this.panel4.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 442);
            this.panel3.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(425, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 442);
            this.panel2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Location = new System.Drawing.Point(21, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 1);
            this.panel1.TabIndex = 88;
            // 
            // textBoxTroco
            // 
            this.textBoxTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTroco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTroco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTroco.Location = new System.Drawing.Point(199, 355);
            this.textBoxTroco.Name = "textBoxTroco";
            this.textBoxTroco.ReadOnly = true;
            this.textBoxTroco.Size = new System.Drawing.Size(214, 28);
            this.textBoxTroco.TabIndex = 87;
            this.textBoxTroco.TabStop = false;
            this.textBoxTroco.Text = "R$0,00";
            this.textBoxTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPagamento
            // 
            this.labelPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPagamento.AutoSize = true;
            this.labelPagamento.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelPagamento.Location = new System.Drawing.Point(16, 306);
            this.labelPagamento.Name = "labelPagamento";
            this.labelPagamento.Size = new System.Drawing.Size(128, 19);
            this.labelPagamento.TabIndex = 78;
            this.labelPagamento.Text = "Valor recebido:";
            // 
            // comboBoxForma
            // 
            this.comboBoxForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxForma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxForma.FormattingEnabled = true;
            this.comboBoxForma.Items.AddRange(new object[] {
            "CRÉDITO",
            "DÉBITO",
            "DINHEIRO",
            "PICPAY",
            "PIX",
            "VALE-TROCA"});
            this.comboBoxForma.Location = new System.Drawing.Point(21, 61);
            this.comboBoxForma.Name = "comboBoxForma";
            this.comboBoxForma.Size = new System.Drawing.Size(392, 28);
            this.comboBoxForma.TabIndex = 1;
            this.comboBoxForma.TabStop = false;
            this.comboBoxForma.SelectedIndexChanged += new System.EventHandler(this.comboBoxForma_SelectedIndexChanged);
            // 
            // labelTroco
            // 
            this.labelTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTroco.AutoSize = true;
            this.labelTroco.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTroco.Location = new System.Drawing.Point(16, 354);
            this.labelTroco.Name = "labelTroco";
            this.labelTroco.Size = new System.Drawing.Size(86, 29);
            this.labelTroco.TabIndex = 82;
            this.labelTroco.Text = "Troco:";
            // 
            // labelForma
            // 
            this.labelForma.AutoSize = true;
            this.labelForma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForma.Location = new System.Drawing.Point(17, 38);
            this.labelForma.Name = "labelForma";
            this.labelForma.Size = new System.Drawing.Size(251, 19);
            this.labelForma.TabIndex = 80;
            this.labelForma.Text = "Escolha a forma de pagamento:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.BackColor = System.Drawing.Color.Red;
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(215, 411);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(180, 32);
            this.buttonCancelar.TabIndex = 86;
            this.buttonCancelar.TabStop = false;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // labelValor
            // 
            this.labelValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelValor.AutoSize = true;
            this.labelValor.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelValor.Location = new System.Drawing.Point(16, 261);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(238, 19);
            this.labelValor.TabIndex = 85;
            this.labelValor.Text = "Valor total desse pagamento:";
            // 
            // textBoxPagamento
            // 
            this.textBoxPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPagamento.Location = new System.Drawing.Point(256, 250);
            this.textBoxPagamento.Name = "textBoxPagamento";
            this.textBoxPagamento.Size = new System.Drawing.Size(157, 35);
            this.textBoxPagamento.TabIndex = 3;
            this.textBoxPagamento.Text = "R$0,00";
            this.textBoxPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPagamento.TextChanged += new System.EventHandler(this.textBoxPagamento_TextChanged);
            this.textBoxPagamento.Enter += new System.EventHandler(this.textBoxPagamento_Enter);
            this.textBoxPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPagamento_KeyPress);
            this.textBoxPagamento.Leave += new System.EventHandler(this.textBoxPagamento_Leave);
            // 
            // textBoxPago
            // 
            this.textBoxPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPago.Location = new System.Drawing.Point(256, 296);
            this.textBoxPago.Name = "textBoxPago";
            this.textBoxPago.ReadOnly = true;
            this.textBoxPago.Size = new System.Drawing.Size(157, 35);
            this.textBoxPago.TabIndex = 4;
            this.textBoxPago.Text = "R$0,00";
            this.textBoxPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPago.TextChanged += new System.EventHandler(this.textBoxPago_TextChanged);
            this.textBoxPago.Enter += new System.EventHandler(this.textBoxPago_Enter);
            this.textBoxPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPago_KeyPress);
            this.textBoxPago.Leave += new System.EventHandler(this.textBoxPago_Leave);
            // 
            // comboBoxBandeira
            // 
            this.comboBoxBandeira.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBandeira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBandeira.FormattingEnabled = true;
            this.comboBoxBandeira.Location = new System.Drawing.Point(256, 99);
            this.comboBoxBandeira.Name = "comboBoxBandeira";
            this.comboBoxBandeira.Size = new System.Drawing.Size(157, 28);
            this.comboBoxBandeira.TabIndex = 2;
            this.comboBoxBandeira.TabStop = false;
            this.comboBoxBandeira.Visible = false;
            this.comboBoxBandeira.SelectedIndexChanged += new System.EventHandler(this.comboBoxBandeira_SelectedIndexChanged);
            // 
            // labelBandeira
            // 
            this.labelBandeira.AutoSize = true;
            this.labelBandeira.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBandeira.Location = new System.Drawing.Point(17, 103);
            this.labelBandeira.Name = "labelBandeira";
            this.labelBandeira.Size = new System.Drawing.Size(233, 19);
            this.labelBandeira.TabIndex = 90;
            this.labelBandeira.Text = "Informe a bandeira do cartão:";
            this.labelBandeira.Visible = false;
            // 
            // labelParcelas
            // 
            this.labelParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelParcelas.AutoSize = true;
            this.labelParcelas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParcelas.Location = new System.Drawing.Point(17, 140);
            this.labelParcelas.Name = "labelParcelas";
            this.labelParcelas.Size = new System.Drawing.Size(268, 19);
            this.labelParcelas.TabIndex = 92;
            this.labelParcelas.Text = "Informe a quantidade de parcelas:";
            this.labelParcelas.Visible = false;
            // 
            // comboBoxParcelas
            // 
            this.comboBoxParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxParcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParcelas.Enabled = false;
            this.comboBoxParcelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxParcelas.FormattingEnabled = true;
            this.comboBoxParcelas.Location = new System.Drawing.Point(313, 136);
            this.comboBoxParcelas.Name = "comboBoxParcelas";
            this.comboBoxParcelas.Size = new System.Drawing.Size(100, 28);
            this.comboBoxParcelas.TabIndex = 3;
            this.comboBoxParcelas.TabStop = false;
            this.comboBoxParcelas.Visible = false;
            this.comboBoxParcelas.SelectedIndexChanged += new System.EventHandler(this.comboBoxParcelas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(16, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 19);
            this.label3.TabIndex = 94;
            this.label3.Text = "Restante da compra a pagar:";
            // 
            // textBoxRestante
            // 
            this.textBoxRestante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxRestante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.textBoxRestante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBoxRestante.Location = new System.Drawing.Point(256, 201);
            this.textBoxRestante.Name = "textBoxRestante";
            this.textBoxRestante.ReadOnly = true;
            this.textBoxRestante.Size = new System.Drawing.Size(157, 25);
            this.textBoxRestante.TabIndex = 93;
            this.textBoxRestante.TabStop = false;
            this.textBoxRestante.Text = "R$0,00";
            this.textBoxRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linha
            // 
            this.linha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linha.BackColor = System.Drawing.Color.White;
            this.linha.Location = new System.Drawing.Point(21, 184);
            this.linha.Name = "linha";
            this.linha.Size = new System.Drawing.Size(392, 1);
            this.linha.TabIndex = 96;
            // 
            // labelPagar
            // 
            this.labelPagar.AutoSize = true;
            this.labelPagar.Font = new System.Drawing.Font("Arial", 12.25F);
            this.labelPagar.Location = new System.Drawing.Point(17, 246);
            this.labelPagar.Name = "labelPagar";
            this.labelPagar.Size = new System.Drawing.Size(146, 19);
            this.labelPagar.TabIndex = 98;
            this.labelPagar.Text = "Valor total a pagar:";
            this.labelPagar.Visible = false;
            // 
            // textBoxPagar
            // 
            this.textBoxPagar.BackColor = System.Drawing.Color.White;
            this.textBoxPagar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPagar.Location = new System.Drawing.Point(256, 238);
            this.textBoxPagar.Name = "textBoxPagar";
            this.textBoxPagar.Size = new System.Drawing.Size(157, 28);
            this.textBoxPagar.TabIndex = 2;
            this.textBoxPagar.TabStop = false;
            this.textBoxPagar.Text = "R$0,00";
            this.textBoxPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPagar.Visible = false;
            this.textBoxPagar.TextChanged += new System.EventHandler(this.textBoxPagar_TextChanged);
            this.textBoxPagar.Enter += new System.EventHandler(this.textBoxPagar_Enter);
            this.textBoxPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPagar_KeyPress);
            this.textBoxPagar.Leave += new System.EventHandler(this.textBoxPagar_Leave);
            // 
            // labelJuros
            // 
            this.labelJuros.AutoSize = true;
            this.labelJuros.Font = new System.Drawing.Font("Arial", 12.25F);
            this.labelJuros.Location = new System.Drawing.Point(16, 281);
            this.labelJuros.Name = "labelJuros";
            this.labelJuros.Size = new System.Drawing.Size(129, 19);
            this.labelJuros.TabIndex = 100;
            this.labelJuros.Text = "Juros do cartão:";
            this.labelJuros.Visible = false;
            // 
            // textBoxJuros
            // 
            this.textBoxJuros.BackColor = System.Drawing.Color.White;
            this.textBoxJuros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxJuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJuros.ForeColor = System.Drawing.Color.Red;
            this.textBoxJuros.Location = new System.Drawing.Point(256, 277);
            this.textBoxJuros.Name = "textBoxJuros";
            this.textBoxJuros.Size = new System.Drawing.Size(157, 22);
            this.textBoxJuros.TabIndex = 99;
            this.textBoxJuros.TabStop = false;
            this.textBoxJuros.Text = "R$0,00";
            this.textBoxJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxJuros.Visible = false;
            this.textBoxJuros.TextChanged += new System.EventHandler(this.textBoxJuros_TextChanged);
            this.textBoxJuros.Enter += new System.EventHandler(this.textBoxJuros_Enter);
            this.textBoxJuros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJuros_KeyPress);
            this.textBoxJuros.Leave += new System.EventHandler(this.textBoxJuros_Leave);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFinalizar.BackColor = System.Drawing.Color.Red;
            this.buttonFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinalizar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.ForeColor = System.Drawing.Color.White;
            this.buttonFinalizar.Location = new System.Drawing.Point(29, 411);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(180, 32);
            this.buttonFinalizar.TabIndex = 5;
            this.buttonFinalizar.Text = "Finalizar";
            this.buttonFinalizar.UseVisualStyleBackColor = false;
            this.buttonFinalizar.Click += new System.EventHandler(this.buttonFinalizar_Click);
            // 
            // formVendasPDVPagamentosAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 466);
            this.Controls.Add(this.linha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRestante);
            this.Controls.Add(this.labelParcelas);
            this.Controls.Add(this.comboBoxParcelas);
            this.Controls.Add(this.labelBandeira);
            this.Controls.Add(this.comboBoxBandeira);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxTroco);
            this.Controls.Add(this.labelPagamento);
            this.Controls.Add(this.comboBoxForma);
            this.Controls.Add(this.labelTroco);
            this.Controls.Add(this.labelForma);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.textBoxPagamento);
            this.Controls.Add(this.textBoxPago);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.labelJuros);
            this.Controls.Add(this.textBoxJuros);
            this.Controls.Add(this.labelPagar);
            this.Controls.Add(this.textBoxPagar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "formVendasPDVPagamentosAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formVendasPDVPagamentosAdicionar";
            this.Load += new System.EventHandler(this.formVendasPDVPagamentosAdicionar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formVendasPDVPagamentosAdicionar_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formVendasPDVPagamentosAdicionar_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formVendasPDVPagamentosAdicionar_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxFechar)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxTroco;
        private System.Windows.Forms.Label labelPagamento;
        private System.Windows.Forms.ComboBox comboBoxForma;
        private System.Windows.Forms.Label labelTroco;
        private System.Windows.Forms.Label labelForma;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelValor;
        public System.Windows.Forms.TextBox textBoxPago;
        private System.Windows.Forms.ComboBox comboBoxBandeira;
        private System.Windows.Forms.Label labelBandeira;
        private System.Windows.Forms.Label labelParcelas;
        private System.Windows.Forms.ComboBox comboBoxParcelas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRestante;
        private System.Windows.Forms.Panel linha;
        private System.Windows.Forms.Label labelPagar;
        private System.Windows.Forms.TextBox textBoxPagar;
        private System.Windows.Forms.Label labelJuros;
        private System.Windows.Forms.TextBox textBoxJuros;
        public System.Windows.Forms.TextBox textBoxPagamento;
        public System.Windows.Forms.Button buttonFinalizar;
    }
}