
namespace MarbaSoftware
{
    partial class formFinanceiroRelatorios
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
            this.buttonDiario = new System.Windows.Forms.Button();
            this.buttonDRE = new System.Windows.Forms.Button();
            this.buttonPatrimonial = new System.Windows.Forms.Button();
            this.buttonDespesa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDiario
            // 
            this.buttonDiario.BackColor = System.Drawing.Color.Red;
            this.buttonDiario.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiario.ForeColor = System.Drawing.Color.White;
            this.buttonDiario.Location = new System.Drawing.Point(12, 12);
            this.buttonDiario.Name = "buttonDiario";
            this.buttonDiario.Size = new System.Drawing.Size(159, 41);
            this.buttonDiario.TabIndex = 0;
            this.buttonDiario.Text = "Relatório Diário";
            this.buttonDiario.UseVisualStyleBackColor = false;
            this.buttonDiario.Click += new System.EventHandler(this.buttonDiario_Click);
            // 
            // buttonDRE
            // 
            this.buttonDRE.BackColor = System.Drawing.Color.Red;
            this.buttonDRE.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDRE.ForeColor = System.Drawing.Color.White;
            this.buttonDRE.Location = new System.Drawing.Point(185, 12);
            this.buttonDRE.Name = "buttonDRE";
            this.buttonDRE.Size = new System.Drawing.Size(159, 41);
            this.buttonDRE.TabIndex = 1;
            this.buttonDRE.Text = "DRE";
            this.buttonDRE.UseVisualStyleBackColor = false;
            this.buttonDRE.Click += new System.EventHandler(this.buttonDRE_Click);
            // 
            // buttonPatrimonial
            // 
            this.buttonPatrimonial.BackColor = System.Drawing.Color.Red;
            this.buttonPatrimonial.Enabled = false;
            this.buttonPatrimonial.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPatrimonial.ForeColor = System.Drawing.Color.White;
            this.buttonPatrimonial.Location = new System.Drawing.Point(185, 59);
            this.buttonPatrimonial.Name = "buttonPatrimonial";
            this.buttonPatrimonial.Size = new System.Drawing.Size(159, 41);
            this.buttonPatrimonial.TabIndex = 2;
            this.buttonPatrimonial.Text = "Balanço Patrimonial";
            this.buttonPatrimonial.UseVisualStyleBackColor = false;
            // 
            // buttonDespesa
            // 
            this.buttonDespesa.BackColor = System.Drawing.Color.Red;
            this.buttonDespesa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDespesa.ForeColor = System.Drawing.Color.White;
            this.buttonDespesa.Location = new System.Drawing.Point(358, 12);
            this.buttonDespesa.Name = "buttonDespesa";
            this.buttonDespesa.Size = new System.Drawing.Size(159, 41);
            this.buttonDespesa.TabIndex = 3;
            this.buttonDespesa.Text = "Gasto por despesa";
            this.buttonDespesa.UseVisualStyleBackColor = false;
            this.buttonDespesa.Click += new System.EventHandler(this.buttonDespesa_Click);
            // 
            // formFinanceiroRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 231);
            this.Controls.Add(this.buttonDespesa);
            this.Controls.Add(this.buttonPatrimonial);
            this.Controls.Add(this.buttonDRE);
            this.Controls.Add(this.buttonDiario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formFinanceiroRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDiario;
        private System.Windows.Forms.Button buttonDRE;
        private System.Windows.Forms.Button buttonPatrimonial;
        private System.Windows.Forms.Button buttonDespesa;
    }
}