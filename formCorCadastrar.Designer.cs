
namespace MarbaSoftware
{
    partial class formCorCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCorCadastrar));
            this.salvarButton = new System.Windows.Forms.Button();
            this.corTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // salvarButton
            // 
            this.salvarButton.BackColor = System.Drawing.Color.White;
            this.salvarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvarButton.BackgroundImage")));
            this.salvarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salvarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salvarButton.ForeColor = System.Drawing.Color.White;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarButton.Location = new System.Drawing.Point(14, 83);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.salvarButton.Size = new System.Drawing.Size(273, 29);
            this.salvarButton.TabIndex = 324;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // corTextBox
            // 
            this.corTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.corTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corTextBox.Location = new System.Drawing.Point(14, 40);
            this.corTextBox.Name = "corTextBox";
            this.corTextBox.Size = new System.Drawing.Size(273, 26);
            this.corTextBox.TabIndex = 323;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 322;
            this.label1.Text = "Cor:";
            // 
            // formCorCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 131);
            this.Controls.Add(this.salvarButton);
            this.Controls.Add(this.corTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCorCadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar cor";
            this.Load += new System.EventHandler(this.formCorCadastrar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.TextBox corTextBox;
        private System.Windows.Forms.Label label1;
    }
}