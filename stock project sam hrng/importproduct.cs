using Guna.UI2.WinForms;
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
using System.Xml.Linq;
using Microsoft.SqlServer;
using System.Runtime.Remoting.Contexts;
using System.Drawing.Imaging;
using System.Dynamic;
using Image = System.Drawing.Image;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace stock_project_sam_hrng
{
    public partial class importproduct : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        public void showdata()
        {
            adt = new SqlDataAdapter("select * from importproduct", cd.conder);
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
            public importproduct()
        {
            InitializeComponent();
            this.guna2DataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.guna2DataGridView1_DataError);
        }

        private void importproduct_Load(object sender, EventArgs e)
        {
            cd.connectder();
            showdata();

        }

        private void btpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Open Image";
            ofdlg.Filter = "Image Files(*.JPG;*.PNG;*.GiF) |*.JPG;*.PNG;*.GiF";

            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                picture1.Image = Image.FromFile(ofdlg.FileName);
            }
        }

        private void txtadd_Click(object sender, EventArgs e)
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
            try 
            {
                Image img = picture1.Image;
                ImageConverter converter = new ImageConverter();
                byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                {
                    SqlCommand cmd = new SqlCommand("insert into importproduct values(@im_id,@im_name,@im_qua,@im_count,@im_date,@im_expir,@im_pic)", cd.conder);
                    cmd.Parameters.AddWithValue("@im_id", txtid.Text);
                    cmd.Parameters.AddWithValue("@im_name", txtname.Text);
                    cmd.Parameters.AddWithValue("@im_qua", txtquatity.Text);
                    cmd.Parameters.AddWithValue("@im_count", txtcount.Text);
                    cmd.Parameters.AddWithValue("@im_date", txtdateimport.Value.Date);
                    cmd.Parameters.AddWithValue("@im_expir", txtdateEX.Value.Date);
                    cmd.Parameters.AddWithValue("@im_pic", arr);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        showdata();
                        MessageBox.Show("ເພີ່ມສໍາເລັດ");
                    }
                    else
                    {
                        MessageBox.Show("ເພີ່ມບໍ່ໄດ້");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtedit_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if (txtid.Text == "")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtname.Text == "")
            {
                errMsg += "";
            }
            if (txtquatity.Text == "")
            {
                errMsg += "";
            }
            if (txtcount.Text == "")
            {
                errMsg += "";
            }
            if (picture1.Image == null)
            {
                errMsg += "";
            }
            if (errMsg != "")
            {
                MessageBox.Show(errMsg, "ມີຂໍ້ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Image img = picture1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("update importproduct set im_name=@im_name, im_qua=@im_qua, im_count=@im_count, im_date=@im_date, im_expir=@im_expir, im_pic=@im_pic where im_id=@im_id", cd.conder);
            cmd.Parameters.AddWithValue("@im_id", txtid.Text);
            cmd.Parameters.AddWithValue("@im_name", txtname.Text);
            cmd.Parameters.AddWithValue("@im_qua", txtquatity.Text);
            cmd.Parameters.AddWithValue("@im_count", txtcount.Text);
            cmd.Parameters.AddWithValue("@im_date", txtdateimport.Value.Date);
            cmd.Parameters.AddWithValue("@im_expir", txtdateEX.Value.Date);
            cmd.Parameters.AddWithValue("@im_pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                showdata();
                MessageBox.Show("update leo");
            }
            else
            {
                MessageBox.Show("update br dai y va");
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
            byte[] imgData = (byte[]) guna2DataGridView1.SelectedRows[0].Cells[6].Value;
            MemoryStream ms = new MemoryStream(imgData);
            picture1.Image = Image.FromStream(ms);
        }

        private void txtdelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete importproduct where im_id=@im_id", cd.conder);
            cmd.Parameters.AddWithValue("@im_id", txtid.Text);

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

        private void txtcacel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtquatity.Text = "";
            txtcount.Text = "";
            picture1.Image = null;

        }

        private void btmain_Click(object sender, EventArgs e)
        {
            new mainform().Show();
            this.Hide();
        }

        private void txted_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if (txtid.Text == "")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtname.Text == "")
            {
                errMsg += "";
            }
            if (txtquatity.Text == "")
            {
                errMsg += "";
            }
            if (txtcount.Text == "")
            {
                errMsg += "";
            }
            if (picture1.Image == null)
            {
                errMsg += "";
            }
            if (errMsg != "")
            {
                MessageBox.Show(errMsg, "ມີຂໍ້ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Image img = picture1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("update productt set product_name=@product_name, product_quatity=@product_quatity, product_count=@product_count, datatime_import=@datatime_import, expiration_date=@expiration_date, pic=@pic where product_id=@product_id", cd.conder);
            cmd.Parameters.AddWithValue("@product_id", txtid.Text);
            cmd.Parameters.AddWithValue("@product_name", txtname.Text);
            cmd.Parameters.AddWithValue("@product_quatity", txtquatity.Text);
            cmd.Parameters.AddWithValue("@product_count", txtcount.Text);
            cmd.Parameters.AddWithValue("@datatime_import", txtdateimport.Value.Date);
            cmd.Parameters.AddWithValue("@expiration_date", txtdateEX.Value.Date);
            cmd.Parameters.AddWithValue("@pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                showdata();
                MessageBox.Show("update leo");
            }
            else
            {
                MessageBox.Show("update br dai y va");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if (txtid.Text == "")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtname.Text == "")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtquatity.Text == "ກະລຸນາໃສ່ຂໍ້ມູນ")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (txtcount.Text == "ກະລຸນາໃສ່ຂໍ້ມູນ")
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (picture1.Image == null)
            {
                errMsg += "ກະລຸນາໃສ່ຂໍ້ມູນ";
            }
            if (errMsg != "")
            {
                MessageBox.Show(errMsg, "ມີຂໍ້ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Image img = picture1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            SqlCommand cmd = new SqlCommand("insert into productt values(@product_id,@product_name,@product_quatity,@product_count,@datetime_import,@expiration_date,@pic)", cd.conder);
            cmd.Parameters.AddWithValue("@product_id", txtid.Text);
            cmd.Parameters.AddWithValue("@product_name", txtname.Text);
            cmd.Parameters.AddWithValue("@product_quatity", txtquatity.Text);
            cmd.Parameters.AddWithValue("@product_count", txtcount.Text);
            cmd.Parameters.AddWithValue("@datetime_import", txtdateimport.Value.Date);
            cmd.Parameters.AddWithValue("@expiration_date", txtdateEX.Value.Date);
            cmd.Parameters.AddWithValue("@pic", arr);

            if (cmd.ExecuteNonQuery() == 1)
            {
                showdata();
                MessageBox.Show("ເພີ່ມສໍາເລັດ");
            }
            else
            {
                MessageBox.Show("ເພີ່ມບໍ່ໄດ້");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete productt where product_id=@product_id", cd.conder);
            cmd.Parameters.AddWithValue("@product_id", txtid.Text);

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            productdatag ac = new productdatag();
            ac.TopLevel = false;
            panel1.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }

        private void guna2DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.guna2DataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.guna2DataGridView1_DataError);
        }
    }
}
