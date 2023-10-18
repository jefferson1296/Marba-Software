
namespace MarbaSoftware
{
    partial class formRepPedido
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
            this.DataSetVisualizarPedidos = new MarbaSoftware.DataSetVisualizarPedidos();
            this.VisualizarPedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VisualizarPedidosTableAdapter = new MarbaSoftware.DataSetVisualizarPedidosTableAdapters.VisualizarPedidosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetVisualizarPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarPedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VisualizarPedidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repPedido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(286, 110);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetVisualizarPedidos
            // 
            this.DataSetVisualizarPedidos.DataSetName = "DataSetVisualizarPedidos";
            this.DataSetVisualizarPedidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VisualizarPedidosBindingSource
            // 
            this.VisualizarPedidosBindingSource.DataMember = "VisualizarPedidos";
            this.VisualizarPedidosBindingSource.DataSource = this.DataSetVisualizarPedidos;
            // 
            // VisualizarPedidosTableAdapter
            // 
            this.VisualizarPedidosTableAdapter.ClearBeforeFill = true;
            // 
            // formRepPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRepPedido";
            this.Text = "formRepPedido";
            this.Load += new System.EventHandler(this.formRepPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetVisualizarPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarPedidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource VisualizarPedidosBindingSource;
        public DataSetVisualizarPedidos DataSetVisualizarPedidos;
        public DataSetVisualizarPedidosTableAdapters.VisualizarPedidosTableAdapter VisualizarPedidosTableAdapter;
    }
}