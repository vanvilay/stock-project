using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace stock_project_sam_hrng
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void btimport_Click(object sender, EventArgs e)
        {
            importproduct ac = new importproduct();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void btproductout_Click(object sender, EventArgs e)
        {
            takeoutproduct ac = new takeoutproduct();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void btproduct_Click(object sender, EventArgs e)
        {
            allproduct ac = new allproduct();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void btregister_Click(object sender, EventArgs e)
        {
            register ac = new register();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btlogout_Click(object sender, EventArgs e)
        {
            new loginform().Show();
            this.Hide();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reportform ac = new reportform();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.TopLevel = false;
            panel3.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }
    }
}
