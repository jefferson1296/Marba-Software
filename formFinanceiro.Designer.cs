
namespace MarbaSoftware
{
    partial class formFinanceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFinanceiro));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.buttonFluxo = new System.Windows.Forms.Button();
            this.buttonLancamentos = new System.Windows.Forms.Button();
            this.buttonOrcamentos = new System.Windows.Forms.Button();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.timerAviso = new System.Windows.Forms.Timer(this.components);
            this.panelSuperior.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSuperior.BackgroundImage")));
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Controls.Add(this.tableLayoutPanel1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1301, 84);
            this.panelSuperior.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDashboard, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFluxo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonLancamentos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOrcamentos, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1299, 77);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.BackColor = System.Drawing.Color.Red;
            this.buttonDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDashboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.Image")));
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(975, 3);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonDashboard.Size = new System.Drawing.Size(321, 71);
            this.buttonDashboard.TabIndex = 5;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.UseVisualStyleBackColor = false;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonFin2_Click);
            // 
            // buttonFluxo
            // 
            this.buttonFluxo.BackColor = System.Drawing.Color.Red;
            this.buttonFluxo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFluxo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFluxo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFluxo.FlatAppearance.BorderSize = 0;
            this.buttonFluxo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFluxo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFluxo.Image = ((System.Drawing.Image)(resources.GetObject("buttonFluxo.Image")));
            this.buttonFluxo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFluxo.Location = new System.Drawing.Point(327, 3);
            this.buttonFluxo.Name = "buttonFluxo";
            this.buttonFluxo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonFluxo.Size = new System.Drawing.Size(318, 71);
            this.buttonFluxo.TabIndex = 6;
            this.buttonFluxo.Text = "Fluxo de caixa";
            this.buttonFluxo.UseVisualStyleBackColor = false;
            this.buttonFluxo.Click += new System.EventHandler(this.buttonFluxo_Click);
            // 
            // buttonLancamentos
            // 
            this.buttonLancamentos.BackColor = System.Drawing.Color.Red;
            this.buttonLancamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLancamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLancamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLancamentos.FlatAppearance.BorderSize = 0;
            this.buttonLancamentos.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLancamentos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLancamentos.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancamentos.Image")));
            this.buttonLancamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLancamentos.Location = new System.Drawing.Point(651, 3);
            this.buttonLancamentos.Name = "buttonLancamentos";
            this.buttonLancamentos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonLancamentos.Size = new System.Drawing.Size(318, 71);
            this.buttonLancamentos.TabIndex = 4;
            this.buttonLancamentos.Text = "Lançamentos";
            this.buttonLancamentos.UseVisualStyleBackColor = false;
            this.buttonLancamentos.Click += new System.EventHandler(this.buttonLancamentos_Click);
            // 
            // buttonOrcamentos
            // 
            this.buttonOrcamentos.BackColor = System.Drawing.Color.Red;
            this.buttonOrcamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOrcamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOrcamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOrcamentos.FlatAppearance.BorderSize = 0;
            this.buttonOrcamentos.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrcamentos.ForeColor = System.Drawing.Color.White;
            this.buttonOrcamentos.Image = ((System.Drawing.Image)(resources.GetObject("buttonOrcamentos.Image")));
            this.buttonOrcamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOrcamentos.Location = new System.Drawing.Point(3, 3);
            this.buttonOrcamentos.Name = "buttonOrcamentos";
            this.buttonOrcamentos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonOrcamentos.Size = new System.Drawing.Size(318, 71);
            this.buttonOrcamentos.TabIndex = 3;
            this.buttonOrcamentos.Text = "Orçamentos";
            this.buttonOrcamentos.UseVisualStyleBackColor = false;
            this.buttonOrcamentos.Click += new System.EventHandler(this.buttonPrevisoes2_Click);
            // 
            // panelCentral
            // 
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 84);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1301, 654);
            this.panelCentral.TabIndex = 3;
            // 
            // timerAviso
            // 
            this.timerAviso.Interval = 1000;
            this.timerAviso.Tick += new System.EventHandler(this.timerAviso_Tick);
            // 
            // formFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 738);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formFinanceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formFinanceiro";
            this.Load += new System.EventHandler(this.formFinanceiro_Load);
            this.panelSuperior.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Button buttonOrcamentos;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonLancamentos;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timerAviso;
        private System.Windows.Forms.Button buttonFluxo;
    }
}