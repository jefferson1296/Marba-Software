
namespace MarbaSoftware
{
    partial class formRepHorarioIndividual
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
            this.dataSetHorariosIndividuais = new MarbaSoftware.dataSetHorariosIndividuais();
            this.HorariosIndividuaisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HorariosIndividuaisTableAdapter = new MarbaSoftware.dataSetHorariosIndividuaisTableAdapters.HorariosIndividuaisTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetHorariosIndividuais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorariosIndividuaisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HorariosIndividuaisBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repHorariosSemanais.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(334, 369);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetHorariosIndividuais
            // 
            this.dataSetHorariosIndividuais.DataSetName = "dataSetHorariosIndividuais";
            this.dataSetHorariosIndividuais.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HorariosIndividuaisBindingSource
            // 
            this.HorariosIndividuaisBindingSource.DataMember = "HorariosIndividuais";
            this.HorariosIndividuaisBindingSource.DataSource = this.dataSetHorariosIndividuais;
            // 
            // HorariosIndividuaisTableAdapter
            // 
            this.HorariosIndividuaisTableAdapter.ClearBeforeFill = true;
            // 
            // formRepHorarioIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 369);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRepHorarioIndividual";
            this.Text = "formRepHorarioIndividual";
            this.Load += new System.EventHandler(this.formRepHorarioIndividual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetHorariosIndividuais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorariosIndividuaisBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource HorariosIndividuaisBindingSource;
        public dataSetHorariosIndividuais dataSetHorariosIndividuais;
        public dataSetHorariosIndividuaisTableAdapters.HorariosIndividuaisTableAdapter HorariosIndividuaisTableAdapter;
    }
}