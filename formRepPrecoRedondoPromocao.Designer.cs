
namespace MarbaSoftware
{
    partial class formRepPrecoRedondoPromocao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRepPrecoRedondoPromocao));
            this.GerarEtiquetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GerarEtiquetasDataSet = new MarbaSoftware.GerarEtiquetasDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GerarEtiquetasTableAdapter = new MarbaSoftware.GerarEtiquetasDataSetTableAdapters.GerarEtiquetasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GerarEtiquetasBindingSource
            // 
            this.GerarEtiquetasBindingSource.DataMember = "GerarEtiquetas";
            this.GerarEtiquetasBindingSource.DataSource = this.GerarEtiquetasDataSet;
            // 
            // GerarEtiquetasDataSet
            // 
            this.GerarEtiquetasDataSet.DataSetName = "GerarEtiquetasDataSet";
            this.GerarEtiquetasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GerarEtiquetasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repEtiquetaPrecoRedondo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // GerarEtiquetasTableAdapter
            // 
            this.GerarEtiquetasTableAdapter.ClearBeforeFill = true;
            // 
            // formRepPrecoRedondoPromocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formRepPrecoRedondoPromocao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preço (Redondo - Promoção)";
            this.Load += new System.EventHandler(this.formRepPrecoRedondoPromocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GerarEtiquetasBindingSource;
        private GerarEtiquetasDataSet GerarEtiquetasDataSet;
        private GerarEtiquetasDataSetTableAdapters.GerarEtiquetasTableAdapter GerarEtiquetasTableAdapter;
    }
}