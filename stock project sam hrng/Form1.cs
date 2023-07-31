using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_project_sam_hrng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.takeoutproduct' table. You can move, or remove it, as needed.
            this.takeoutproductTableAdapter.Fill(this.dataSet1.takeoutproduct);
            // TODO: This line of code loads data into the 'dataSet2.takeoutproduct' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }

        private void btmain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
