﻿
namespace MarbaSoftware
{
    partial class formRepPrecoJardinagem
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
            this.GerarEtiquetasDataSet = new MarbaSoftware.GerarEtiquetasDataSet();
            this.GerarEtiquetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GerarEtiquetasTableAdapter = new MarbaSoftware.GerarEtiquetasDataSetTableAdapters.GerarEtiquetasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GerarEtiquetasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MarbaSoftware.repEtiquetaPrecoJardinagem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(296, 253);
            this.reportViewer1.TabIndex = 0;
            // 
            // GerarEtiquetasDataSet
            // 
            this.GerarEtiquetasDataSet.DataSetName = "GerarEtiquetasDataSet";
            this.GerarEtiquetasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GerarEtiquetasBindingSource
            // 
            this.GerarEtiquetasBindingSource.DataMember = "GerarEtiquetas";
            this.GerarEtiquetasBindingSource.DataSource = this.GerarEtiquetasDataSet;
            // 
            // GerarEtiquetasTableAdapter
            // 
            this.GerarEtiquetasTableAdapter.ClearBeforeFill = true;
            // 
            // formRepPrecoJardinagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 253);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formRepPrecoJardinagem";
            this.Text = "formRepPrecoJardinagem";
            this.Load += new System.EventHandler(this.formRepPrecoJardinagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GerarEtiquetasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GerarEtiquetasBindingSource;
        private GerarEtiquetasDataSet GerarEtiquetasDataSet;
        private GerarEtiquetasDataSetTableAdapters.GerarEtiquetasTableAdapter GerarEtiquetasTableAdapter;
    }
}