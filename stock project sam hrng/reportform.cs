using Guna.UI2.WinForms;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_project_sam_hrng
{
    public partial class reportform : Form
    {
        
        public reportform()
        {
            InitializeComponent();
        }

        private void reportform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.importproduct' table. You can move, or remove it, as needed.
            this.importproductTableAdapter.Fill(this.dataSet1.importproduct);

            this.reportViewer1.RefreshReport();
            
        }

        private void btmain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
