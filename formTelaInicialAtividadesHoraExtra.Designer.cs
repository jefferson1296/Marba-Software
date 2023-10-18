
namespace MarbaSoftware
{
    partial class formTelaInicialAtividadesHoraExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTelaInicialAtividadesHoraExtra));
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.colaboradorComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.periodoComboBox = new System.Windows.Forms.ComboBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.horaMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 495;
            this.label2.Text = "Data:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Arial", 12F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(65, 55);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(124, 26);
            this.dateTimePicker.TabIndex = 493;
            // 
            // colaboradorComboBox
            // 
            this.colaboradorComboBox.BackColor = System.Drawing.Color.White;
            this.colaboradorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colaboradorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colaboradorComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colaboradorComboBox.ForeColor = System.Drawing.Color.Black;
            this.colaboradorComboBox.FormattingEnabled = true;
            this.colaboradorComboBox.Location = new System.Drawing.Point(115, 17);
            this.colaboradorComboBox.Name = "colaboradorComboBox";
            this.colaboradorComboBox.Size = new System.Drawing.Size(230, 26);
            this.colaboradorComboBox.TabIndex = 491;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 490;
            this.label1.Text = "Colaborador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(195, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 496;
            this.label3.Text = "Horas Extras:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 498;
            this.label4.Text = "Período:";
            // 
            // periodoComboBox
            // 
            this.periodoComboBox.BackColor = System.Drawing.Color.White;
            this.periodoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.periodoComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.periodoComboBox.ForeColor = System.Drawing.Color.Black;
            this.periodoComboBox.FormattingEnabled = true;
            this.periodoComboBox.Items.AddRange(new object[] {
            "Início do Serviço",
            "Fim do Serviço"});
            this.periodoComboBox.Location = new System.Drawing.Point(86, 92);
            this.periodoComboBox.Name = "periodoComboBox";
            this.periodoComboBox.Size = new System.Drawing.Size(259, 26);
            this.periodoComboBox.TabIndex = 499;
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.White;
            this.cancelarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelarButton.BackgroundImage")));
            this.cancelarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelarButton.Location = new System.Drawing.Point(186, 132);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(145, 30);
            this.cancelarButton.TabIndex = 501;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.BackColor = System.Drawing.Color.White;
            this.salvarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvarButton.BackgroundImage")));
            this.salvarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salvarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvarButton.ForeColor = System.Drawing.Color.White;
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarButton.Location = new System.Drawing.Point(33, 132);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(145, 30);
            this.salvarButton.TabIndex = 500;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // horaMaskedTextBox
            // 
            this.horaMaskedTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.horaMaskedTextBox.Location = new System.Drawing.Point(283, 55);
            this.horaMaskedTextBox.Mask = "90:00";
            this.horaMaskedTextBox.Name = "horaMaskedTextBox";
            this.horaMaskedTextBox.Size = new System.Drawing.Size(62, 26);
            this.horaMaskedTextBox.TabIndex = 503;
            this.horaMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.horaMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // formTelaInicialAtividadesHoraExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 174);
            this.Controls.Add(this.horaMaskedTextBox);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.periodoComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.colaboradorComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formTelaInicialAtividadesHoraExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hora extra";
            this.Load += new System.EventHandler(this.formTelaInicialAtividadesHoraExtra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox colaboradorComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox periodoComboBox;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.MaskedTextBox horaMaskedTextBox;
    }
}