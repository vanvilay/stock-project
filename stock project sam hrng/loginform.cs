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
    public partial class loginform : Form
    {
        public string con = "Data Source=DESKTOP-VNVAI9F\\SQLEXPRESS;Initial Catalog=stockproduct1;Integrated Security=True";
        public loginform()
        {
            InitializeComponent();
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtname.Text;
            password = txtpass.Text;

            try
            {
                String querry = "Select * from userderr where user_id = '" + txtname.Text + "' And user_pass = '" + txtpass.Text + "'";
                SqlDataAdapter adt = new SqlDataAdapter(querry, con);

                DataTable dt = new DataTable();
                adt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = txtname.Text;
                    password = txtpass.Text;

                    mainform main = new mainform();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ລະຫັດ ຫຼື ຊື່ບໍ່ຖືກ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtname.Text = "";
                    txtpass.Text = "";

                    txtname.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {

            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpass.Clear();    
        }
    }
}
