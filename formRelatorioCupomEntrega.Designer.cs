
namespace MarbaSoftware
{
    partial class formRelatorioCupomEntrega
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
            this.bd_MarbaDataSetEntregas = new MarbaSoftware.bd_MarbaDataSetEntregas();
            this.PreencherCupomEntregasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PreencherCupomEntregasTableAdapter = new MarbaSoftware.bd_MarbaDataSetEntregasTableAdapters.PreencherCupomEntregasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSetEntregas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreencherCupomEntregasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PreencherCupomEntregasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(284, 288);
            this.reportViewer1.TabIndex = 0;
            // 
            // bd_MarbaDataSetEntregas
            // 
            this.bd_MarbaDataSetEntregas.DataSetName = "bd_MarbaDataSetEntregas";
            this.bd_MarbaDataSetEntregas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PreencherCupomEntregasBindingSource
            // 
            this.PreencherCupomEntregasBindingSource.DataMember = "PreencherCupomEntregas";
            this.PreencherCupomEntregasBindingSource.DataSource = this.bd_MarbaDataSetEntregas;
            // 
            // PreencherCupomEntregasTableAdapter
            // 
            this.PreencherCupomEntregasTableAdapter.ClearBeforeFill = true;
            // 
            // formRelatorioCupomEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 288);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRelatorioCupomEntrega";
            this.Text = "formRelatorioCupomEntrega";
            this.Load += new System.EventHandler(this.formRelatorioCupomEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSetEntregas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreencherCupomEntregasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource PreencherCupomEntregasBindingSource;
        public bd_MarbaDataSetEntregas bd_MarbaDataSetEntregas;
        public bd_MarbaDataSetEntregasTableAdapters.PreencherCupomEntregasTableAdapter PreencherCupomEntregasTableAdapter;
    }
}