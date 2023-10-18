
namespace MarbaSoftware
{
    partial class formRepDirecionamento
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
            this.ProdutosParaDirecionamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetDirecionamento = new MarbaSoftware.DataSetDirecionamento();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProdutosParaDirecionamentoTableAdapter = new MarbaSoftware.DataSetDirecionamentoTableAdapters.ProdutosParaDirecionamentoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosParaDirecionamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDirecionamento)).BeginInit();
            this.SuspendLayout();
            // 
            // ProdutosParaDirecionamentoBindingSource
            // 
            this.ProdutosParaDirecionamentoBindingSource.DataMember = "ProdutosParaDirecionamento";
            this.ProdutosParaDirecionamentoBindingSource.DataSource = this.DataSetDirecionamento;
            // 
            // DataSetDirecionamento
            // 
            this.DataSetDirecionamento.DataSetName = "DataSetDirecionamento";
            this.DataSetDirecionamento.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDirecionamento";
            reportDataSource1.Value = this.ProdutosParaDirecionamentoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repDirecionamento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ProdutosParaDirecionamentoTableAdapter
            // 
            this.ProdutosParaDirecionamentoTableAdapter.ClearBeforeFill = true;
            // 
            // formRepDirecionamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formRepDirecionamento";
            this.Text = "Direcionamento";
            this.Load += new System.EventHandler(this.formRepDirecionamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosParaDirecionamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDirecionamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource ProdutosParaDirecionamentoBindingSource;
        public DataSetDirecionamento DataSetDirecionamento;
        public DataSetDirecionamentoTableAdapters.ProdutosParaDirecionamentoTableAdapter ProdutosParaDirecionamentoTableAdapter;
    }
}