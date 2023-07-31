using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace stock_project_sam_hrng
{
    public partial class allproduct : Form
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
            guna2DataGridView1.Columns[0].HeaderText = "ລະຫັດສີນຄ້າ";
            guna2DataGridView1.Columns[1].HeaderText = "ຊື່ສີນຄ້າ";
            guna2DataGridView1.Columns[2].HeaderText = "ຈຳນວນ";
            guna2DataGridView1.Columns[3].HeaderText = "ລັກສະນະບັນຈຸ";
            guna2DataGridView1.Columns[4].HeaderText = "ວັນທີນຳເຂົ້າ";
            guna2DataGridView1.Columns[5].HeaderText = "ວັນໝົດອາຍຸ";
            guna2DataGridView1.Columns[6].HeaderText = "ຮູບ";
        }
        
            public allproduct()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void allproduct_Load(object sender, EventArgs e)
        {
            cd.connectder();
            showdata();
        }
        private DataTable SearchProductByName(string productName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM productt WHERE product_name LIKE @ProductName ORDER BY product_name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show("An SQL exception occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("An exception occurred: " + ex.Message);
                }
            }

            return dataTable;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtsearch_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            string productName = txtsearch.Text;
            DataTable searchResults = SearchProductByName(productName);
            guna2DataGridView1.DataSource = searchResults;
        }

        private void btmain_Click(object sender, EventArgs e)
        {
            new mainform().Show();
            this.Hide();
        }
    }
}
