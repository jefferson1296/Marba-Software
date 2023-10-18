
namespace MarbaSoftware
{
    partial class formLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.buttonAcessar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRedefinir = new System.Windows.Forms.Label();
            this.labelEsqueceuSenha = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonFechar = new System.Windows.Forms.PictureBox();
            this.timerTransparente = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAcessar
            // 
            this.buttonAcessar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcessar.FlatAppearance.BorderSize = 0;
            this.buttonAcessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcessar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcessar.ForeColor = System.Drawing.Color.Red;
            this.buttonAcessar.Location = new System.Drawing.Point(267, 182);
            this.buttonAcessar.Name = "buttonAcessar";
            this.buttonAcessar.Size = new System.Drawing.Size(201, 33);
            this.buttonAcessar.TabIndex = 3;
            this.buttonAcessar.Text = "Acessar";
            this.buttonAcessar.UseVisualStyleBackColor = true;
            this.buttonAcessar.Click += new System.EventHandler(this.buttonAcessar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PeachPuff;
            this.panel3.Location = new System.Drawing.Point(206, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 1);
            this.panel3.TabIndex = 15;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.BackColor = System.Drawing.Color.White;
            this.textBoxSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSenha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.ForeColor = System.Drawing.Color.IndianRed;
            this.textBoxSenha.Location = new System.Drawing.Point(206, 131);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(304, 20);
            this.textBoxSenha.TabIndex = 2;
            this.textBoxSenha.Text = "SENHA";
            this.textBoxSenha.Enter += new System.EventHandler(this.textBoxSenha_Enter);
            this.textBoxSenha.Leave += new System.EventHandler(this.textBoxSenha_Leave);
            this.textBoxSenha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxSenha_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.Location = new System.Drawing.Point(206, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 1);
            this.panel2.TabIndex = 14;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.Color.White;
            this.textBoxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.ForeColor = System.Drawing.Color.IndianRed;
            this.textBoxUsuario.Location = new System.Drawing.Point(206, 93);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(307, 20);
            this.textBoxUsuario.TabIndex = 1;
            this.textBoxUsuario.Text = "MATRÍCULA";
            this.textBoxUsuario.Enter += new System.EventHandler(this.textBoxUsuario_Enter);
            this.textBoxUsuario.Leave += new System.EventHandler(this.textBoxUsuario_Leave);
            this.textBoxUsuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxUsuario_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "LOGIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelRedefinir);
            this.panel1.Controls.Add(this.labelEsqueceuSenha);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 227);
            this.panel1.TabIndex = 11;
            // 
            // labelRedefinir
            // 
            this.labelRedefinir.AutoSize = true;
            this.labelRedefinir.BackColor = System.Drawing.Color.Transparent;
            this.labelRedefinir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRedefinir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRedefinir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelRedefinir.Location = new System.Drawing.Point(63, 156);
            this.labelRedefinir.Name = "labelRedefinir";
            this.labelRedefinir.Size = new System.Drawing.Size(79, 15);
            this.labelRedefinir.TabIndex = 17;
            this.labelRedefinir.Text = "Redefinir senha";
            this.labelRedefinir.Click += new System.EventHandler(this.labelRedefinir_Click);
            // 
            // labelEsqueceuSenha
            // 
            this.labelEsqueceuSenha.AutoSize = true;
            this.labelEsqueceuSenha.BackColor = System.Drawing.Color.Transparent;
            this.labelEsqueceuSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEsqueceuSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEsqueceuSenha.ForeColor = System.Drawing.Color.White;
            this.labelEsqueceuSenha.Location = new System.Drawing.Point(46, 195);
            this.labelEsqueceuSenha.Name = "labelEsqueceuSenha";
            this.labelEsqueceuSenha.Size = new System.Drawing.Size(113, 13);
            this.labelEsqueceuSenha.TabIndex = 16;
            this.labelEsqueceuSenha.Text = "Esqueceu sua senha?";
            this.labelEsqueceuSenha.Click += new System.EventHandler(this.labelEsqueceuSenha_Click);
            this.labelEsqueceuSenha.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.labelEsqueceuSenha.MouseLeave += new System.EventHandler(this.labelEsqueceuSenha_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(59, 71);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 82);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(53, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // buttonFechar
            // 
            this.buttonFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFechar.Image = ((System.Drawing.Image)(resources.GetObject("buttonFechar.Image")));
            this.buttonFechar.Location = new System.Drawing.Point(538, 3);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(12, 12);
            this.buttonFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonFechar.TabIndex = 9;
            this.buttonFechar.TabStop = false;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // timerTransparente
            // 
            this.timerTransparente.Interval = 50;
            this.timerTransparente.Tick += new System.EventHandler(this.timerTransparente_Tick);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 2);
            this.panel4.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 225);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(553, 2);
            this.panel5.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 223);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel7.BackgroundImage")));
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(551, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 223);
            this.panel7.TabIndex = 19;
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 227);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonAcessar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "formLogin";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formLogin_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formLogin_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAcessar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox buttonFechar;
        private System.Windows.Forms.Label labelEsqueceuSenha;
        private System.Windows.Forms.Timer timerTransparente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelRedefinir;
    }
}

