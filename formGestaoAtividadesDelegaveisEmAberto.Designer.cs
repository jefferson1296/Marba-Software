
namespace MarbaSoftware
{
    partial class formGestaoAtividadesDelegaveisEmAberto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGestaoAtividadesDelegaveisEmAberto));
            this.label4 = new System.Windows.Forms.Label();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.salvarButton = new System.Windows.Forms.Button();
            this.atividadeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 518;
            this.label4.Text = "Atividade:";
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelarButton.BackColor = System.Drawing.Color.White;
            this.cancelarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelarButton.BackgroundImage")));
            this.cancelarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelarButton.Location = new System.Drawing.Point(230, 68);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cancelarButton.Size = new System.Drawing.Size(193, 35);
            this.cancelarButton.TabIndex = 516;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.salvarButton.BackColor = System.Drawing.Color.White;
            this.salvarButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvarButton.BackgroundImage")));
            this.salvarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salvarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvarButton.ForeColor = System.Drawing.Color.White;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salvarButton.Location = new System.Drawing.Point(31, 68);
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.salvarButton.Size = new System.Drawing.Size(193, 35);
            this.salvarButton.TabIndex = 515;
            this.salvarButton.Text = "Salvar";
            this.salvarButton.UseVisualStyleBackColor = false;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // atividadeComboBox
            // 
            this.atividadeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.atividadeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.atividadeComboBox.BackColor = System.Drawing.Color.White;
            this.atividadeComboBox.Enabled = false;
            this.atividadeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atividadeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.atividadeComboBox.ForeColor = System.Drawing.Color.Black;
            this.atividadeComboBox.FormattingEnabled = true;
            this.atividadeComboBox.Location = new System.Drawing.Point(92, 23);
            this.atividadeComboBox.Name = "atividadeComboBox";
            this.atividadeComboBox.Size = new System.Drawing.Size(344, 26);
            this.atividadeComboBox.TabIndex = 519;
            // 
            // formGestaoAtividadesDelegaveisEmAberto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 115);
            this.Controls.Add(this.atividadeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.salvarButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGestaoAtividadesDelegaveisEmAberto";
            this.Text = "Em aberto";
            this.Load += new System.EventHandler(this.formGestaoAtividadesDelegaveisEmAberto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button salvarButton;
        private System.Windows.Forms.ComboBox atividadeComboBox;
    }
}