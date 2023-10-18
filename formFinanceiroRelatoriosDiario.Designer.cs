
namespace MarbaSoftware
{
    partial class formFinanceiroRelatoriosDiario
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonDiario = new System.Windows.Forms.Button();
            this.buttonVisualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(280, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // buttonDiario
            // 
            this.buttonDiario.BackColor = System.Drawing.Color.Red;
            this.buttonDiario.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiario.ForeColor = System.Drawing.Color.White;
            this.buttonDiario.Location = new System.Drawing.Point(22, 54);
            this.buttonDiario.Name = "buttonDiario";
            this.buttonDiario.Size = new System.Drawing.Size(124, 41);
            this.buttonDiario.TabIndex = 1;
            this.buttonDiario.Text = "Imprimir";
            this.buttonDiario.UseVisualStyleBackColor = false;
            this.buttonDiario.Click += new System.EventHandler(this.buttonDiario_Click);
            // 
            // buttonVisualizar
            // 
            this.buttonVisualizar.BackColor = System.Drawing.Color.Red;
            this.buttonVisualizar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVisualizar.ForeColor = System.Drawing.Color.White;
            this.buttonVisualizar.Location = new System.Drawing.Point(159, 54);
            this.buttonVisualizar.Name = "buttonVisualizar";
            this.buttonVisualizar.Size = new System.Drawing.Size(124, 41);
            this.buttonVisualizar.TabIndex = 2;
            this.buttonVisualizar.Text = "Visualizar";
            this.buttonVisualizar.UseVisualStyleBackColor = false;
            this.buttonVisualizar.Click += new System.EventHandler(this.buttonVisualizar_Click);
            // 
            // formFinanceiroRelatoriosDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 110);
            this.Controls.Add(this.buttonVisualizar);
            this.Controls.Add(this.buttonDiario);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formFinanceiroRelatoriosDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório diário";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonDiario;
        private System.Windows.Forms.Button buttonVisualizar;
    }
}