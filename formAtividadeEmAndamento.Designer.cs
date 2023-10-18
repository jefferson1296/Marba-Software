
namespace MarbaSoftware
{
    partial class formAtividadeEmAndamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAtividadeEmAndamento));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPausar = new System.Windows.Forms.Button();
            this.continuarButton = new System.Windows.Forms.Button();
            this.buttonEncerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.label1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(446, 68);
            this.panelSuperior.TabIndex = 487;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(180, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.buttonPausar);
            this.groupBox1.Controls.Add(this.continuarButton);
            this.groupBox1.Controls.Add(this.buttonEncerrar);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.groupBox1.Location = new System.Drawing.Point(7, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 63);
            this.groupBox1.TabIndex = 489;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escolha a próxima ação a ser realizada";
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
            this.buttonPausar.Location = new System.Drawing.Point(149, 24);
            this.buttonPausar.Name = "buttonPausar";
            this.buttonPausar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonPausar.Size = new System.Drawing.Size(134, 30);
            this.buttonPausar.TabIndex = 488;
            this.buttonPausar.Text = "Pausar";
            this.buttonPausar.UseVisualStyleBackColor = false;
            this.buttonPausar.Click += new System.EventHandler(this.buttonPausar_Click);
            // 
            // continuarButton
            // 
            this.continuarButton.BackColor = System.Drawing.Color.White;
            this.continuarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("continuarButton.BackgroundImage")));
            this.continuarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.continuarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continuarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.continuarButton.Font = new System.Drawing.Font("Arial", 8.25F);
            this.continuarButton.ForeColor = System.Drawing.Color.White;
            this.continuarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.continuarButton.Location = new System.Drawing.Point(293, 24);
            this.continuarButton.Name = "continuarButton";
            this.continuarButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.continuarButton.Size = new System.Drawing.Size(134, 30);
            this.continuarButton.TabIndex = 487;
            this.continuarButton.Text = "Continuar";
            this.continuarButton.UseVisualStyleBackColor = false;
            this.continuarButton.Click += new System.EventHandler(this.continuarButton_Click);
            // 
            // buttonEncerrar
            // 
            this.buttonEncerrar.BackColor = System.Drawing.Color.White;
            this.buttonEncerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEncerrar.BackgroundImage")));
            this.buttonEncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEncerrar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonEncerrar.ForeColor = System.Drawing.Color.White;
            this.buttonEncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEncerrar.Location = new System.Drawing.Point(5, 24);
            this.buttonEncerrar.Name = "buttonEncerrar";
            this.buttonEncerrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEncerrar.Size = new System.Drawing.Size(134, 30);
            this.buttonEncerrar.TabIndex = 489;
            this.buttonEncerrar.Text = "Encerrar";
            this.buttonEncerrar.UseVisualStyleBackColor = false;
            this.buttonEncerrar.Click += new System.EventHandler(this.buttonEncerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 488;
            this.label2.Text = "label2";
            // 
            // formAtividadeEmAndamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 200);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAtividadeEmAndamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formAtividadeEmAndamento";
            this.Load += new System.EventHandler(this.formAtividadeEmAndamento_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPausar;
        private System.Windows.Forms.Button continuarButton;
        private System.Windows.Forms.Button buttonEncerrar;
        private System.Windows.Forms.Label label2;
    }
}