
namespace MarbaSoftware
{
    partial class formRepPlanoDeAcao
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
            this.EtapasDoPlanoDeAcaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetEtapasDoPlano = new MarbaSoftware.dataSetEtapasDoPlano();
            this.CustosDoPlanoDeAcaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCustosDoPlano = new MarbaSoftware.dataSetCustosDoPlano();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EtapasDoPlanoDeAcaoTableAdapter = new MarbaSoftware.dataSetEtapasDoPlanoTableAdapters.EtapasDoPlanoDeAcaoTableAdapter();
            this.CustosDoPlanoDeAcaoTableAdapter = new MarbaSoftware.dataSetCustosDoPlanoTableAdapters.CustosDoPlanoDeAcaoTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.EtapasDoPlanoDeAcaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEtapasDoPlano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustosDoPlanoDeAcaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCustosDoPlano)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EtapasDoPlanoDeAcaoBindingSource
            // 
            this.EtapasDoPlanoDeAcaoBindingSource.DataMember = "EtapasDoPlanoDeAcao";
            this.EtapasDoPlanoDeAcaoBindingSource.DataSource = this.dataSetEtapasDoPlano;
            // 
            // dataSetEtapasDoPlano
            // 
            this.dataSetEtapasDoPlano.DataSetName = "dataSetEtapasDoPlano";
            this.dataSetEtapasDoPlano.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustosDoPlanoDeAcaoBindingSource
            // 
            this.CustosDoPlanoDeAcaoBindingSource.DataMember = "CustosDoPlanoDeAcao";
            this.CustosDoPlanoDeAcaoBindingSource.DataSource = this.dataSetCustosDoPlano;
            // 
            // dataSetCustosDoPlano
            // 
            this.dataSetCustosDoPlano.DataSetName = "dataSetCustosDoPlano";
            this.dataSetCustosDoPlano.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "DataSetEtapas";
            reportDataSource1.Value = this.EtapasDoPlanoDeAcaoBindingSource;
            reportDataSource2.Name = "DataSetCustos";
            reportDataSource2.Value = this.CustosDoPlanoDeAcaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repPlanoDeAcao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(57, 10);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowProgress = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(711, 566);
            this.reportViewer1.TabIndex = 0;
            // 
            // EtapasDoPlanoDeAcaoTableAdapter
            // 
            this.EtapasDoPlanoDeAcaoTableAdapter.ClearBeforeFill = true;
            // 
            // CustosDoPlanoDeAcaoTableAdapter
            // 
            this.CustosDoPlanoDeAcaoTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 579);
            this.panel1.TabIndex = 1;
            // 
            // formRepPlanoDeAcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 579);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formRepPlanoDeAcao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de ação";
            this.Load += new System.EventHandler(this.formRepPlanoDeAcao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EtapasDoPlanoDeAcaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEtapasDoPlano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustosDoPlanoDeAcaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCustosDoPlano)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource EtapasDoPlanoDeAcaoBindingSource;
        public dataSetEtapasDoPlano dataSetEtapasDoPlano;
        public System.Windows.Forms.BindingSource CustosDoPlanoDeAcaoBindingSource;
        public dataSetCustosDoPlano dataSetCustosDoPlano;
        public dataSetEtapasDoPlanoTableAdapters.EtapasDoPlanoDeAcaoTableAdapter EtapasDoPlanoDeAcaoTableAdapter;
        public dataSetCustosDoPlanoTableAdapters.CustosDoPlanoDeAcaoTableAdapter CustosDoPlanoDeAcaoTableAdapter;
        private System.Windows.Forms.Panel panel1;
    }
}