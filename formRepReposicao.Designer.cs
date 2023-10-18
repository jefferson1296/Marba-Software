
namespace MarbaSoftware
{
    partial class formRepReposicao
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetReposicao = new MarbaSoftware.DataSetReposicao();
            this.ProdutosDaReposicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProdutosDaReposicaoTableAdapter = new MarbaSoftware.DataSetReposicaoTableAdapters.ProdutosDaReposicaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReposicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosDaReposicaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetReposicao";
            reportDataSource1.Value = this.ProdutosDaReposicaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repReposicao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetReposicao
            // 
            this.DataSetReposicao.DataSetName = "DataSetReposicao";
            this.DataSetReposicao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProdutosDaReposicaoBindingSource
            // 
            this.ProdutosDaReposicaoBindingSource.DataMember = "ProdutosDaReposicao";
            this.ProdutosDaReposicaoBindingSource.DataSource = this.DataSetReposicao;
            // 
            // ProdutosDaReposicaoTableAdapter
            // 
            this.ProdutosDaReposicaoTableAdapter.ClearBeforeFill = true;
            // 
            // formRepReposicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRepReposicao";
            this.Text = "formRepReposicao";
            this.Load += new System.EventHandler(this.formRepReposicao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReposicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosDaReposicaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProdutosDaReposicaoBindingSource;
        private DataSetReposicao DataSetReposicao;
        private DataSetReposicaoTableAdapters.ProdutosDaReposicaoTableAdapter ProdutosDaReposicaoTableAdapter;
    }
}