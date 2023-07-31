namespace stock_project_sam_hrng
{
    partial class reportform
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
            this.importproductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new stock_project_sam_hrng.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importproductTableAdapter = new stock_project_sam_hrng.DataSet1TableAdapters.importproductTableAdapter();
            this.btmain = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.importproductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // importproductBindingSource
            // 
            this.importproductBindingSource.DataMember = "importproduct";
            this.importproductBindingSource.DataSource = this.dataSet1BindingSource1;
            // 
            // dataSet1BindingSource1
            // 
            this.dataSet1BindingSource1.DataSource = this.dataSet1;
            this.dataSet1BindingSource1.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.importproductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "stock_project_sam_hrng.reportimport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1628, 692);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // importproductTableAdapter
            // 
            this.importproductTableAdapter.ClearBeforeFill = true;
            // 
            // btmain
            // 
            this.btmain.AutoRoundedCorners = true;
            this.btmain.BackColor = System.Drawing.Color.Transparent;
            this.btmain.BorderRadius = 21;
            this.btmain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btmain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btmain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btmain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btmain.FillColor = System.Drawing.Color.Transparent;
            this.btmain.Font = new System.Drawing.Font("Noto Sans Lao", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmain.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btmain.Image = global::stock_project_sam_hrng.Properties.Resources.close;
            this.btmain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btmain.ImageSize = new System.Drawing.Size(40, 40);
            this.btmain.Location = new System.Drawing.Point(1401, 3);
            this.btmain.Name = "btmain";
            this.btmain.Size = new System.Drawing.Size(215, 45);
            this.btmain.TabIndex = 64;
            this.btmain.Text = "ປິດ";
            this.btmain.Click += new System.EventHandler(this.btmain_Click);
            // 
            // reportform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1628, 744);
            this.Controls.Add(this.btmain);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "reportform";
            this.Text = "reportform";
            this.Load += new System.EventHandler(this.reportform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.importproductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource dataSet1BindingSource1;
        private System.Windows.Forms.BindingSource importproductBindingSource;
        private DataSet1TableAdapters.importproductTableAdapter importproductTableAdapter;
        private Guna.UI2.WinForms.Guna2Button btmain;
    }
}