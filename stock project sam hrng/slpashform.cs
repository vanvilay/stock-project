using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace stock_project_sam_hrng
{
    public partial class slpashform : Form
    {
        public slpashform()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 4;

                label1.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                loginform mf= new loginform();
                mf.Show();
                this.Hide();
            }
        }

        private void slpashform_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
