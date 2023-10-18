
namespace MarbaSoftware
{
    partial class formRelatorioVisualizarPedidoDetalhado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProcedureVisualizarPedido = new MarbaSoftware.ProcedureVisualizarPedido();
            this.VisualizarPedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VisualizarPedidosTableAdapter = new MarbaSoftware.ProcedureVisualizarPedidoTableAdapters.VisualizarPedidosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProcedureVisualizarPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarPedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.VisualizarPedidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repVisualizarPedidoDetalhado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ProcedureVisualizarPedido
            // 
            this.ProcedureVisualizarPedido.DataSetName = "ProcedureVisualizarPedido";
            this.ProcedureVisualizarPedido.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VisualizarPedidosBindingSource
            // 
            this.VisualizarPedidosBindingSource.DataMember = "VisualizarPedidos";
            this.VisualizarPedidosBindingSource.DataSource = this.ProcedureVisualizarPedido;
            // 
            // VisualizarPedidosTableAdapter
            // 
            this.VisualizarPedidosTableAdapter.ClearBeforeFill = true;
            // 
            // formRelatorioVisualizarPedidoDetalhado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRelatorioVisualizarPedidoDetalhado";
            this.Text = "formRelatorioVisualizarPedidoDetalhado";
            this.Load += new System.EventHandler(this.formRelatorioVisualizarPedidoDetalhado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcedureVisualizarPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarPedidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource VisualizarPedidosBindingSource;
        public ProcedureVisualizarPedido ProcedureVisualizarPedido;
        public ProcedureVisualizarPedidoTableAdapters.VisualizarPedidosTableAdapter VisualizarPedidosTableAdapter;
    }
}