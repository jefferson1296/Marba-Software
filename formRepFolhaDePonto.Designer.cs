
namespace MarbaSoftware
{
    partial class formRepFolhaDePonto
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
            this.dataSetFolhaDePonto = new MarbaSoftware.dataSetFolhaDePonto();
            this.FolhaDePontoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FolhaDePontoTableAdapter = new MarbaSoftware.dataSetFolhaDePontoTableAdapters.FolhaDePontoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFolhaDePonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FolhaDePontoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetFolha";
            reportDataSource1.Value = this.FolhaDePontoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repFolhaDePonto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(735, 349);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetFolhaDePonto
            // 
            this.dataSetFolhaDePonto.DataSetName = "dataSetFolhaDePonto";
            this.dataSetFolhaDePonto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FolhaDePontoBindingSource
            // 
            this.FolhaDePontoBindingSource.DataMember = "FolhaDePonto";
            this.FolhaDePontoBindingSource.DataSource = this.dataSetFolhaDePonto;
            // 
            // FolhaDePontoTableAdapter
            // 
            this.FolhaDePontoTableAdapter.ClearBeforeFill = true;
            // 
            // formRepFolhaDePonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 349);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formRepFolhaDePonto";
            this.Text = "Folha de ponto eletrônico";
            this.Load += new System.EventHandler(this.formRepFolhaDePonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFolhaDePonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FolhaDePontoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource FolhaDePontoBindingSource;
        public dataSetFolhaDePonto dataSetFolhaDePonto;
        public dataSetFolhaDePontoTableAdapters.FolhaDePontoTableAdapter FolhaDePontoTableAdapter;
    }
}