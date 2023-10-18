
namespace MarbaSoftware
{
    partial class formRelatorioCupomRetirada
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
            this.bd_MarbaDataSet4 = new MarbaSoftware.bd_MarbaDataSet4();
            this.PreencherCupomRetiradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PreencherCupomRetiradaTableAdapter = new MarbaSoftware.bd_MarbaDataSet4TableAdapters.PreencherCupomRetiradaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreencherCupomRetiradaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PreencherCupomRetiradaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.RepCupomRetiradas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(240, 172);
            this.reportViewer1.TabIndex = 0;
            // 
            // bd_MarbaDataSet4
            // 
            this.bd_MarbaDataSet4.DataSetName = "bd_MarbaDataSet4";
            this.bd_MarbaDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PreencherCupomRetiradaBindingSource
            // 
            this.PreencherCupomRetiradaBindingSource.DataMember = "PreencherCupomRetirada";
            this.PreencherCupomRetiradaBindingSource.DataSource = this.bd_MarbaDataSet4;
            // 
            // PreencherCupomRetiradaTableAdapter
            // 
            this.PreencherCupomRetiradaTableAdapter.ClearBeforeFill = true;
            // 
            // formRelatorioCupomRetirada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 172);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRelatorioCupomRetirada";
            this.Text = "formRelatorioCupomRetirada";
            this.Load += new System.EventHandler(this.formRelatorioCupomRetirada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_MarbaDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreencherCupomRetiradaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource PreencherCupomRetiradaBindingSource;
        public bd_MarbaDataSet4 bd_MarbaDataSet4;
        public bd_MarbaDataSet4TableAdapters.PreencherCupomRetiradaTableAdapter PreencherCupomRetiradaTableAdapter;
    }
}