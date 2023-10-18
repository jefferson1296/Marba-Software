
namespace MarbaSoftware
{
    partial class formPausar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPausar));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.labelIntervalo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMotivo = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonPausar = new System.Windows.Forms.Button();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.labelIntervalo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(346, 59);
            this.panelSuperior.TabIndex = 494;
            // 
            // labelIntervalo
            // 
            this.labelIntervalo.AutoSize = true;
            this.labelIntervalo.BackColor = System.Drawing.Color.Transparent;
            this.labelIntervalo.Font = new System.Drawing.Font("Arial", 18F);
            this.labelIntervalo.ForeColor = System.Drawing.Color.Black;
            this.labelIntervalo.Location = new System.Drawing.Point(78, 16);
            this.labelIntervalo.Name = "labelIntervalo";
            this.labelIntervalo.Size = new System.Drawing.Size(191, 27);
            this.labelIntervalo.TabIndex = 1;
            this.labelIntervalo.Text = "Pausar Atividade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 498;
            this.label1.Text = "Informe o motivo";
            // 
            // textBoxMotivo
            // 
            this.textBoxMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxMotivo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMotivo.Location = new System.Drawing.Point(12, 102);
            this.textBoxMotivo.Multiline = true;
            this.textBoxMotivo.Name = "textBoxMotivo";
            this.textBoxMotivo.Size = new System.Drawing.Size(322, 72);
            this.textBoxMotivo.TabIndex = 497;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.White;
            this.buttonCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.BackgroundImage")));
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(183, 200);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(131, 30);
            this.buttonCancelar.TabIndex = 496;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonPausar
            // 
            this.buttonPausar.BackColor = System.Drawing.Color.White;
            this.buttonPausar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPausar.BackgroundImage")));
            this.buttonPausar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPausar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPausar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonPausar.ForeColor = System.Drawing.Color.White;
            this.buttonPausar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPausar.Location = new System.Drawing.Point(27, 200);
            this.buttonPausar.Name = "buttonPausar";
            this.buttonPausar.Size = new System.Drawing.Size(131, 30);
            this.buttonPausar.TabIndex = 495;
            this.buttonPausar.Text = "Pausar";
            this.buttonPausar.UseVisualStyleBackColor = false;
            this.buttonPausar.Click += new System.EventHandler(this.buttonPausar_Click);
            // 
            // formPausar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 243);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMotivo);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonPausar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formPausar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formPausar";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelIntervalo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMotivo;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonPausar;
    }
}