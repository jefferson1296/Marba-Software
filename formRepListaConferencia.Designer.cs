
namespace MarbaSoftware
{
    partial class formRepListaConferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRepListaConferencia));
            this.GerarListasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetGerarListas = new MarbaSoftware.DataSetGerarListas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GerarListasTableAdapter = new MarbaSoftware.DataSetGerarListasTableAdapters.GerarListasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GerarListasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetGerarListas)).BeginInit();
            this.SuspendLayout();
            // 
            // GerarListasBindingSource
            // 
            this.GerarListasBindingSource.DataMember = "GerarListas";
            this.GerarListasBindingSource.DataSource = this.DataSetGerarListas;
            // 
            // DataSetGerarListas
            // 
            this.DataSetGerarListas.DataSetName = "DataSetGerarListas";
            this.DataSetGerarListas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetListas";
            reportDataSource1.Value = this.GerarListasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repListaConferencia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // GerarListasTableAdapter
            // 
            this.GerarListasTableAdapter.ClearBeforeFill = true;
            // 
            // formRepListaConferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formRepListaConferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista para Conferência";
            this.Load += new System.EventHandler(this.formRepListaConferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GerarListasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetGerarListas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource GerarListasBindingSource;
        public DataSetGerarListas DataSetGerarListas;
        public DataSetGerarListasTableAdapters.GerarListasTableAdapter GerarListasTableAdapter;
    }
}