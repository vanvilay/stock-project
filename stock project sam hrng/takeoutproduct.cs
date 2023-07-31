using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace stock_project_sam_hrng
{
    public partial class takeoutproduct : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        public void showdata()
        {
            adt = new SqlDataAdapter("select * from takeoutproduct", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.Columns[0].HeaderText = "ລະຫັດສີນຄ້າ";
            guna2DataGridView1.Columns[1].HeaderText = "ຊື່ສີນຄ້າ";
            guna2DataGridView1.Columns[2].HeaderText = "ຈຳນວນ";
            guna2DataGridView1.Columns[3].HeaderText = "ລັກສະນະບັນຈຸ";
            guna2DataGridView1.Columns[4].HeaderText = "ວັນທີນຳສົ່ງອອກ";
            guna2DataGridView1.Columns[5].HeaderText = "ວັນໝົດອາຍຸ";
            guna2DataGridView1.Columns[6].HeaderText = "ຮູບ";

        }
      
        public takeoutproduct()
        {
            InitializeComponent();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if (txtquatity.Text == "")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtname.Text == "")
            {
                errMsg += "";
            }
            
            if (errMsg != "")
            {
                MessageBox.Show(errMsg, "ມີຂໍ້ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cd.connectder();
            cd.cmd.Connection = cd.conder;
            cd.cmd.CommandText = $"select productt.product_quatity from productt where product_id = '{txtid.Text}'";
            int quanitty = cd.cmd.ExecuteScalar() == null? 0 :int.Parse(cd.cmd.ExecuteScalar().ToString());
            cd.dbClose();
            int importQuantity = int.Parse(string.IsNullOrEmpty(txtquatity.Text)? "0" : txtquatity.Text);
            if (importQuantity > quanitty)
            {
                MessageBox.Show("ຈຳນວນທີທານຕອງການສົງອອກບໍ່ພຽງພໍ");
                return;
            }
            int remainTotal = quanitty - importQuantity;
            showdata();
            
            cd.connectder();
            cd.cmd.Transaction = cd.conder.BeginTransaction();
            cd.cmd.CommandText = $"update productt set product_quatity={remainTotal} where product_id='{txtid.Text}'";
            int count1 = cd.cmd.ExecuteNonQuery();
            Image img = pictureBox2.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cd.cmd.CommandText = $"insert into takeoutproduct values('{txtid.Text}', '{txtname.Text}', {txtquatity.Text}, '{txtcount.Text}', @exportDate, @expireDate,@pic )";
            cd.cmd.Parameters.AddWithValue("@exportDate", DateTime.Now.Date);
            cd.cmd.Parameters.AddWithValue("@expireDate", DateTime.Parse(txtdateEX.Value.ToString()).Date);
            cd.cmd.Parameters.AddWithValue("@pic", arr);

            int count2 = cd.cmd.ExecuteNonQuery();
            cd.cmd.Parameters.Clear();

            if (count2 > 0) {
                
                cd.cmd.Transaction.Commit();
                MessageBox.Show("successfully exported");
                showdata();
            }
            else
            {
                cd.cmd.Transaction.Rollback();
                MessageBox.Show("Failure exported");
            }
         

            
            cd.dbClose();

        }
       
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void takeoutproduct_Load(object sender, EventArgs e)
        {
          
            cd.connectder();
            showdata();

        }

        private void txtid_Enter(object sender, EventArgs e)
        {
            cd.connectder();
            cd.cmd.Connection = cd.conder;
            cd.cmd.CommandText = $"select * from productt where product_id = '{txtid.Text}'";
            SqlDataReader read =   cd.cmd.ExecuteReader();
            while (read.Read())
            {
                txtname.Text = read.GetString(1);   
            }
        }

        private void txtid_MouseEnter(object sender, EventArgs e)
        {
            cd.connectder();
            cd.cmd.Connection = cd.conder;
            cd.cmd.CommandText = $"select * from productt where product_id = '{txtid.Text}'";
            SqlDataReader read = cd.cmd.ExecuteReader();
            while (read.Read())
            {
                txtname.Text = read.GetString(1);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            cd.connectder();
            cd.cmd.Connection = cd.conder;
            cd.cmd.CommandText = $"select * from productt where product_id = '{txtid.Text}'";
            SqlDataReader read = cd.cmd.ExecuteReader();
            while (read.Read())
            {
                txtname.Text = read.GetString(1);
                txtcount.Text = read.GetString(3);
                txtdateimport.Text = read.GetDateTime(4).ToString();
                txtdateEX.Text= read.GetDateTime(5).ToString();


                int ndx = read.GetOrdinal("pic");
                if (!read.IsDBNull(ndx))
                {
                    long size = read.GetBytes(ndx, 0, null, 0, 0);  //get the length of data
                    byte[] values = new byte[size];

                    int bufferSize = 1024;
                    long bytesRead = 0;
                    int curPos = 0;

                    while (bytesRead < size)
                    {
                        bytesRead += read.GetBytes(ndx, curPos, values, curPos, bufferSize);
                        curPos += bufferSize;
                    }

                    using (var ms = new MemoryStream(values))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
            }
        }

  

        

        private void txtdelete_Click(object sender, EventArgs e)
        {
            cd.dbClose();
            cd.connectder();
            cmd = new SqlCommand("delete takeoutproduct where takeout_id=@takeout_id", cd.conder);
            cmd.Parameters.AddWithValue("@takeout_id", txtid.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                showdata();
                MessageBox.Show("ລຶບແລ້ວ");
            }
            else
            {
                MessageBox.Show("ລຶບບໍ່ໄດ້");
            }
        }

        

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtquatity.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtcount.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdateimport.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtdateEX.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            byte[] imgData = (byte[])guna2DataGridView1.SelectedRows[0].Cells[6].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pictureBox2.Image = Image.FromStream(ms);


        }

        private void txtclear_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtquatity.Text = "";
            txtcount.Text = "";
            pictureBox2.Image = null;
        }

        private void btmain_Click(object sender, EventArgs e)
        {
            new mainform().Show();
            this.Hide();
        }
    }
}
