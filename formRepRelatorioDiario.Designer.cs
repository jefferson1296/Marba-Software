
namespace MarbaSoftware
{
    partial class formRepRelatorioDiario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MovimentacoesFinanceirasDoDiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetMovimentacoesDoDia = new MarbaSoftware.dataSetMovimentacoesDoDia();
            this.PagamentosDosProximos7DiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPagamentosDosProximos7Dias = new MarbaSoftware.dataSetPagamentosDosProximos7Dias();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MovimentacoesFinanceirasDoDiaTableAdapter = new MarbaSoftware.dataSetMovimentacoesDoDiaTableAdapters.MovimentacoesFinanceirasDoDiaTableAdapter();
            this.PagamentosDosProximos7DiasTableAdapter = new MarbaSoftware.dataSetPagamentosDosProximos7DiasTableAdapters.PagamentosDosProximos7DiasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.MovimentacoesFinanceirasDoDiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMovimentacoesDoDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagamentosDosProximos7DiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPagamentosDosProximos7Dias)).BeginInit();
            this.SuspendLayout();
            // 
            // MovimentacoesFinanceirasDoDiaBindingSource
            // 
            this.MovimentacoesFinanceirasDoDiaBindingSource.DataMember = "MovimentacoesFinanceirasDoDia";
            this.MovimentacoesFinanceirasDoDiaBindingSource.DataSource = this.dataSetMovimentacoesDoDia;
            // 
            // dataSetMovimentacoesDoDia
            // 
            this.dataSetMovimentacoesDoDia.DataSetName = "dataSetMovimentacoesDoDia";
            this.dataSetMovimentacoesDoDia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PagamentosDosProximos7DiasBindingSource
            // 
            this.PagamentosDosProximos7DiasBindingSource.DataMember = "PagamentosDosProximos7Dias";
            this.PagamentosDosProximos7DiasBindingSource.DataSource = this.dataSetPagamentosDosProximos7Dias;
            // 
            // dataSetPagamentosDosProximos7Dias
            // 
            this.dataSetPagamentosDosProximos7Dias.DataSetName = "dataSetPagamentosDosProximos7Dias";
            this.dataSetPagamentosDosProximos7Dias.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dataSetMovimentacoes";
            reportDataSource1.Value = this.MovimentacoesFinanceirasDoDiaBindingSource;
            reportDataSource2.Name = "dataSetpagamentos";
            reportDataSource2.Value = this.PagamentosDosProximos7DiasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repRelatorioDiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(698, 477);
            this.reportViewer1.TabIndex = 0;
            // 
            // MovimentacoesFinanceirasDoDiaTableAdapter
            // 
            this.MovimentacoesFinanceirasDoDiaTableAdapter.ClearBeforeFill = true;
            // 
            // PagamentosDosProximos7DiasTableAdapter
            // 
            this.PagamentosDosProximos7DiasTableAdapter.ClearBeforeFill = true;
            // 
            // formRepRelatorioDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 477);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formRepRelatorioDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório diário";
            this.Load += new System.EventHandler(this.formRepRelatorioDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MovimentacoesFinanceirasDoDiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMovimentacoesDoDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagamentosDosProximos7DiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPagamentosDosProximos7Dias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource MovimentacoesFinanceirasDoDiaBindingSource;
        public dataSetMovimentacoesDoDia dataSetMovimentacoesDoDia;
        public System.Windows.Forms.BindingSource PagamentosDosProximos7DiasBindingSource;
        public dataSetPagamentosDosProximos7Dias dataSetPagamentosDosProximos7Dias;
        public dataSetMovimentacoesDoDiaTableAdapters.MovimentacoesFinanceirasDoDiaTableAdapter MovimentacoesFinanceirasDoDiaTableAdapter;
        public dataSetPagamentosDosProximos7DiasTableAdapters.PagamentosDosProximos7DiasTableAdapter PagamentosDosProximos7DiasTableAdapter;
    }
}