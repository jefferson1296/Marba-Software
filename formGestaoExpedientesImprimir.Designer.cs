
namespace MarbaSoftware
{
    partial class formGestaoExpedientesImprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoExpedientesImprimir));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.radioButtonImprimir = new System.Windows.Forms.RadioButton();
            this.radioButtonVisualizar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 69);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(241, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.BackColor = System.Drawing.Color.White;
            this.buttonContinuar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonContinuar.BackgroundImage")));
            this.buttonContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinuar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinuar.ForeColor = System.Drawing.Color.White;
            this.buttonContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonContinuar.Location = new System.Drawing.Point(264, 66);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(112, 26);
            this.buttonContinuar.TabIndex = 492;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = false;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // radioButtonImprimir
            // 
            this.radioButtonImprimir.AutoSize = true;
            this.radioButtonImprimir.Checked = true;
            this.radioButtonImprimir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonImprimir.Location = new System.Drawing.Point(88, 23);
            this.radioButtonImprimir.Name = "radioButtonImprimir";
            this.radioButtonImprimir.Size = new System.Drawing.Size(82, 22);
            this.radioButtonImprimir.TabIndex = 493;
            this.radioButtonImprimir.TabStop = true;
            this.radioButtonImprimir.Text = "Imprimir";
            this.radioButtonImprimir.UseVisualStyleBackColor = true;
            // 
            // radioButtonVisualizar
            // 
            this.radioButtonVisualizar.AutoSize = true;
            this.radioButtonVisualizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonVisualizar.Location = new System.Drawing.Point(205, 23);
            this.radioButtonVisualizar.Name = "radioButtonVisualizar";
            this.radioButtonVisualizar.Size = new System.Drawing.Size(85, 22);
            this.radioButtonVisualizar.TabIndex = 494;
            this.radioButtonVisualizar.Text = "Exportar";
            this.radioButtonVisualizar.UseVisualStyleBackColor = true;
            // 
            // formGestaoExpedientesImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 109);
            this.Controls.Add(this.radioButtonVisualizar);
            this.Controls.Add(this.radioButtonImprimir);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoExpedientesImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir expediente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.RadioButton radioButtonImprimir;
        private System.Windows.Forms.RadioButton radioButtonVisualizar;
    }
}