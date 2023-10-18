
namespace MarbaSoftware
{
    partial class formGestaoConfiguracoesParametrosEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoConfiguracoesParametrosEditar));
            this.textBoxParametro = new System.Windows.Forms.TextBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salvarButton = new System.Windows.Forms.Button();
            this.comboBoxValor = new System.Windows.Forms.ComboBox();
            this.radioButtonDecimal = new System.Windows.Forms.RadioButton();
            this.radioButtonBool = new System.Windows.Forms.RadioButton();
            this.radioButtonTexto = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxParametro
            // 
            this.textBoxParametro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParametro.Location = new System.Drawing.Point(97, 29);
            this.textBoxParametro.Name = "textBoxParametro";
            this.textBoxParametro.ReadOnly = true;
            this.textBoxParametro.Size = new System.Drawing.Size(285, 26);
            this.textBoxParametro.TabIndex = 1;
            this.textBoxParametro.TabStop = false;
            // 
            // textBoxValor
            // 
            this.textBoxValor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.Location = new System.Drawing.Point(153, 71);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(229, 26);
            this.textBoxValor.TabIndex = 1;
            this.textBoxValor.TabStop = false;
            this.textBoxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValor_KeyPress);
            this.textBoxValor.Leave += new System.EventHandler(this.textBoxValor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Parâmetro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor do parâmetro:";
            // 
            // salvarButton
            // 
            this.salvarButton.BackColor = System.Drawing.Color.White;
            this.salvarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvarButton.BackgroundImage")));
            this.salvarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salvarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvarButton.ForeColor = System.Drawing.Color.White;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarButton.Location = new System.Drawing.Point(96, 117);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.salvarButton.Size = new System.Drawing.Size(193, 35);
            this.salvarButton.TabIndex = 511;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // comboBoxValor
            // 
            this.comboBoxValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxValor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxValor.FormattingEnabled = true;
            this.comboBoxValor.Items.AddRange(new object[] {
            "Verdadeiro",
            "Falso"});
            this.comboBoxValor.Location = new System.Drawing.Point(153, 71);
            this.comboBoxValor.Name = "comboBoxValor";
            this.comboBoxValor.Size = new System.Drawing.Size(229, 26);
            this.comboBoxValor.TabIndex = 512;
            this.comboBoxValor.TabStop = false;
            this.comboBoxValor.Visible = false;
            this.comboBoxValor.SelectedIndexChanged += new System.EventHandler(this.comboBoxValor_SelectedIndexChanged);
            // 
            // radioButtonDecimal
            // 
            this.radioButtonDecimal.AutoSize = true;
            this.radioButtonDecimal.Location = new System.Drawing.Point(15, 4);
            this.radioButtonDecimal.Name = "radioButtonDecimal";
            this.radioButtonDecimal.Size = new System.Drawing.Size(63, 17);
            this.radioButtonDecimal.TabIndex = 513;
            this.radioButtonDecimal.Text = "Decimal";
            this.radioButtonDecimal.UseVisualStyleBackColor = true;
            this.radioButtonDecimal.CheckedChanged += new System.EventHandler(this.radioButtonDecimal_CheckedChanged);
            // 
            // radioButtonBool
            // 
            this.radioButtonBool.AutoSize = true;
            this.radioButtonBool.Location = new System.Drawing.Point(97, 4);
            this.radioButtonBool.Name = "radioButtonBool";
            this.radioButtonBool.Size = new System.Drawing.Size(70, 17);
            this.radioButtonBool.TabIndex = 514;
            this.radioButtonBool.Text = "Booleano";
            this.radioButtonBool.UseVisualStyleBackColor = true;
            this.radioButtonBool.CheckedChanged += new System.EventHandler(this.radioButtonBool_CheckedChanged);
            // 
            // radioButtonTexto
            // 
            this.radioButtonTexto.AutoSize = true;
            this.radioButtonTexto.Location = new System.Drawing.Point(184, 4);
            this.radioButtonTexto.Name = "radioButtonTexto";
            this.radioButtonTexto.Size = new System.Drawing.Size(52, 17);
            this.radioButtonTexto.TabIndex = 515;
            this.radioButtonTexto.Text = "Texto";
            this.radioButtonTexto.UseVisualStyleBackColor = true;
            this.radioButtonTexto.CheckedChanged += new System.EventHandler(this.radioButtonTexto_CheckedChanged);
            // 
            // formGestaoConfiguracoesParametrosEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 171);
            this.Controls.Add(this.radioButtonTexto);
            this.Controls.Add(this.radioButtonBool);
            this.Controls.Add(this.radioButtonDecimal);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxParametro);
            this.Controls.Add(this.comboBoxValor);
            this.Controls.Add(this.textBoxValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoConfiguracoesParametrosEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar parâmetro";
            this.Load += new System.EventHandler(this.formGestaoConfiguracoesParametrosEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxParametro;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.ComboBox comboBoxValor;
        private System.Windows.Forms.RadioButton radioButtonDecimal;
        private System.Windows.Forms.RadioButton radioButtonBool;
        private System.Windows.Forms.RadioButton radioButtonTexto;
    }
}