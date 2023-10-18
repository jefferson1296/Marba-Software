
namespace MarbaSoftware
{
    partial class formRepQuarentena
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
            this.ProdutosDaQuarentenaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetQuarentena = new MarbaSoftware.DataSetQuarentena();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProdutosDaQuarentenaTableAdapter = new MarbaSoftware.DataSetQuarentenaTableAdapters.ProdutosDaQuarentenaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosDaQuarentenaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetQuarentena)).BeginInit();
            this.SuspendLayout();
            // 
            // ProdutosDaQuarentenaBindingSource
            // 
            this.ProdutosDaQuarentenaBindingSource.DataMember = "ProdutosDaQuarentena";
            this.ProdutosDaQuarentenaBindingSource.DataSource = this.DataSetQuarentena;
            // 
            // DataSetQuarentena
            // 
            this.DataSetQuarentena.DataSetName = "DataSetQuarentena";
            this.DataSetQuarentena.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dataSetQuarentena";
            reportDataSource1.Value = this.ProdutosDaQuarentenaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repQuarentena.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(859, 487);
            this.reportViewer1.TabIndex = 0;
            // 
            // ProdutosDaQuarentenaTableAdapter
            // 
            this.ProdutosDaQuarentenaTableAdapter.ClearBeforeFill = true;
            // 
            // formRepQuarentena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 487);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRepQuarentena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quarentena";
            this.Load += new System.EventHandler(this.formRepQuarentena_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosDaQuarentenaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetQuarentena)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource ProdutosDaQuarentenaBindingSource;
        public DataSetQuarentena DataSetQuarentena;
        public DataSetQuarentenaTableAdapters.ProdutosDaQuarentenaTableAdapter ProdutosDaQuarentenaTableAdapter;
    }
}