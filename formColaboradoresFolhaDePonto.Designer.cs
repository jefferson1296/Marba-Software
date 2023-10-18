
namespace MarbaSoftware
{
    partial class formColaboradoresFolhaDePonto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formColaboradoresFolhaDePonto));
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(12, 15);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(190, 26);
            this.comboBoxMes.TabIndex = 6;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.BackColor = System.Drawing.Color.Red;
            this.buttonImprimir.ContextMenuStrip = this.menuStrip;
            this.buttonImprimir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimir.ForeColor = System.Drawing.Color.White;
            this.buttonImprimir.Location = new System.Drawing.Point(27, 59);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(159, 41);
            this.buttonImprimir.TabIndex = 5;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = false;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarPDFToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // exportarPDFToolStripMenuItem
            // 
            this.exportarPDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportarPDFToolStripMenuItem.Image")));
            this.exportarPDFToolStripMenuItem.Name = "exportarPDFToolStripMenuItem";
            this.exportarPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarPDFToolStripMenuItem.Text = "Exportar PDF";
            this.exportarPDFToolStripMenuItem.Click += new System.EventHandler(this.exportarPDFToolStripMenuItem_Click);
            // 
            // formColaboradoresFolhaDePonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 114);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.buttonImprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formColaboradoresFolhaDePonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folha de ponto";
            this.Load += new System.EventHandler(this.formColaboradoresFolhaDePonto_Load);
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportarPDFToolStripMenuItem;
    }
}