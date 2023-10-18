
namespace MarbaSoftware
{
    partial class formRelatorioReposicaoLoja
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
            this.bd_MarbaDataSet1 = new MarbaSoftware.bd_MarbaDataSet1();
            this.tbl_ReposicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ReposicaoTableAdapter = new MarbaSoftware.bd_MarbaDataSet1TableAdapters.tbl_ReposicaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ReposicaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbl_ReposicaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.Relatórios.repReposicaoLoja.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 290);
            this.reportViewer1.TabIndex = 0;
            // 
            // bd_MarbaDataSet1
            // 
            this.bd_MarbaDataSet1.DataSetName = "bd_MarbaDataSet1";
            this.bd_MarbaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_ReposicaoBindingSource
            // 
            this.tbl_ReposicaoBindingSource.DataMember = "tbl_Reposicao";
            this.tbl_ReposicaoBindingSource.DataSource = this.bd_MarbaDataSet1;
            // 
            // tbl_ReposicaoTableAdapter
            // 
            this.tbl_ReposicaoTableAdapter.ClearBeforeFill = true;
            // 
            // formRelatoriosCupom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 289);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRelatoriosCupom";
            this.Text = "formRelatoriosCupom";
            this.Load += new System.EventHandler(this.formRelatoriosCupom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ReposicaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.BindingSource tbl_ReposicaoBindingSource;
        public bd_MarbaDataSet1 bd_MarbaDataSet1;
        public bd_MarbaDataSet1TableAdapters.tbl_ReposicaoTableAdapter tbl_ReposicaoTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}