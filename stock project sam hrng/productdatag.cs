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
    public partial class productdatag : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string ConnectionString = "Data Source=DESKTOP-VNVAI9F\\SQLEXPRESS;Initial Catalog=stockproduct1;Integrated Security=True";

        public void showdata()
        {
            adt = new SqlDataAdapter("select * from productt", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        public productdatag()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productdatag_Load(object sender, EventArgs e)
        {
            cd.connectder();
            showdata();
        }
    }
}
