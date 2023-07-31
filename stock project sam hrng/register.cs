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

namespace stock_project_sam_hrng
{
    public partial class register : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        public void showdata()
        {
            adt = new SqlDataAdapter("select * from userderr", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.Columns[0].HeaderText = "ລະຫັດuser";
            guna2DataGridView1.Columns[1].HeaderText = "ຊື່";
            guna2DataGridView1.Columns[2].HeaderText = "ນາມສະກຸນ";
            guna2DataGridView1.Columns[3].HeaderText = "ອາຍຸ";
            guna2DataGridView1.Columns[4].HeaderText = "ວັນເກີດ";
            guna2DataGridView1.Columns[5].HeaderText = "ບ້ານ";
            guna2DataGridView1.Columns[6].HeaderText = "ເມືອງ";
            guna2DataGridView1.Columns[7].HeaderText = "ແຂວງ";
            guna2DataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            guna2DataGridView1.Columns[9].HeaderText = "ລະຫັດ";
        }
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {
            cd.connectder();
            showdata();
        }

        private void cobdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            cobprovince.Items.Clear();
            if (cobdistrict.SelectedItem == "ນະຄອນຫຼວງວຽງຈັນ")
            {
                cobprovince.Items.Add("ຈັນທະບູລີ");
                cobprovince.Items.Add("ສີໂຄດຕະບອງ");
                cobprovince.Items.Add("ໄຊເສດຖາ");
                cobprovince.Items.Add("ສີສັດຕະນາກ");
                cobprovince.Items.Add("ນາຊາຍທອງ");
                cobprovince.Items.Add("ໄຊທານີ");
                cobprovince.Items.Add("ຫາດຊາຍຟອງ");
                cobprovince.Items.Add("ສັງທອງ");
                cobprovince.Items.Add("ປາກງື່ມ");
            }
            if (cobdistrict.SelectedItem == "ຜົ້ງສາລີ")
            {
                cobprovince.Items.Add("ໃໝ່");
                cobprovince.Items.Add("ຂວາ");
                cobprovince.Items.Add("ສໍາພັນ");
                cobprovince.Items.Add("ບຸນເໜືອ");
                cobprovince.Items.Add("ຍອດອູ");
                cobprovince.Items.Add("ບຸນໃຕ້");
            }
            if (cobdistrict.SelectedItem == "ຫລວງນໍ້າທາ")
            {
                cobprovince.Items.Add("ສີງ");
                cobprovince.Items.Add("ລອງ");
                cobprovince.Items.Add("ວຽງພູຄາ");
                cobprovince.Items.Add("ນາແລ");
            }
            if (cobdistrict.SelectedItem == "ອຸດົມໄຊ")
            {
                cobprovince.Items.Add("ໄຊ");
                cobprovince.Items.Add("ຫຼາ");
                cobprovince.Items.Add("ນາໝໍ້");
                cobprovince.Items.Add("ງາ");
                cobprovince.Items.Add("ແບ່ງ");
                cobprovince.Items.Add("ຮຸນ");
                cobprovince.Items.Add("ປາກແບ່ງ");
            }
            if (cobdistrict.SelectedItem == "ບໍ່ແກ້ວ")
            {
                cobprovince.Items.Add("ຫ້ວຍຊາຍ");
                cobprovince.Items.Add("ຕົ້ນເຜິ້ງ");
                cobprovince.Items.Add("ເມິງ");
                cobprovince.Items.Add("ຜາອຸດົມ");
                cobprovince.Items.Add("ປາກທາ");
            }
            if (cobdistrict.SelectedItem == "ຫຼວງພະບາງ")
            {
                cobprovince.Items.Add("ຊຽງເງິນ");
                cobprovince.Items.Add("ນານ");
                cobprovince.Items.Add("ປາກອູ");
                cobprovince.Items.Add("ນ້ຳບາກ");
                cobprovince.Items.Add("ງອຍ");
                cobprovince.Items.Add("ປາກແຊງ");
                cobprovince.Items.Add("ໂພນໄຊ");
                cobprovince.Items.Add("ຈອມເພັດ");
                cobprovince.Items.Add("ວຽງຄໍາ");
                cobprovince.Items.Add("ພູຄູນ");
                cobprovince.Items.Add("ໂພນທອງ");
            }
            if (cobdistrict.SelectedItem == "ຫົວພັນ")
            {
                cobprovince.Items.Add("ຊໍາເໜືອ");
                cobprovince.Items.Add("ຊຽງຄໍ້");
                cobprovince.Items.Add("ວຽງທອງ");
                cobprovince.Items.Add("ວຽງໄຊ");
                cobprovince.Items.Add("ຫົວເມືອງ");
                cobprovince.Items.Add("ຊໍາໃຕ້");
                cobprovince.Items.Add("ສົບເບົາ");
                cobprovince.Items.Add("ແອດ");
                cobprovince.Items.Add("ກອັນ");
                cobprovince.Items.Add("ຊ່ອນ");
            }
            if (cobdistrict.SelectedItem == "ໄຊຍະບູລີ")
            {
                cobprovince.Items.Add("ຄອບ");
                cobprovince.Items.Add("ຫົງສາ");
                cobprovince.Items.Add("ເງີນ");
                cobprovince.Items.Add("ຊຽງຮ່ອນ");
                cobprovince.Items.Add("ພຽງ");
                cobprovince.Items.Add("ປາກລາຍ");
                cobprovince.Items.Add("ແກ່ນທ້າວ");
                cobprovince.Items.Add("ບໍ່ແຕນ");
                cobprovince.Items.Add("ທົ່ງມີໄຊ");
                cobprovince.Items.Add("ໄຊສະຖານ");
            }
            if (cobdistrict.SelectedItem == "ຊຽງຂວາງ")
            {
                cobprovince.Items.Add("ແປກ");
                cobprovince.Items.Add("ຄໍາ");
                cobprovince.Items.Add("ໜອງແຮດ");
                cobprovince.Items.Add("ຄູນ");
                cobprovince.Items.Add("ໝອກໃໝ່");
                cobprovince.Items.Add("ພູກູດ");
                cobprovince.Items.Add("ຜາໄຊ");
            }
            if (cobdistrict.SelectedItem == "ວຽງຈັນ")
            {
                cobprovince.Items.Add("ໂພນໂຮງ");
                cobprovince.Items.Add("ທຸລະຄົມ");
                cobprovince.Items.Add("ແກ້ວອຸດົມ");
                cobprovince.Items.Add("ກາສີ");
                cobprovince.Items.Add("ວັງວຽງ");
                cobprovince.Items.Add("ເຟືອງ");
                cobprovince.Items.Add("ຊະນະຄາມ");
                cobprovince.Items.Add("ແມດ");
                cobprovince.Items.Add("ວຽງຄໍາ");
                cobprovince.Items.Add("ຫີນເຫີບ");
                cobprovince.Items.Add("ໝື່ນ");
            }
            if (cobdistrict.SelectedItem == "ບໍລິຄໍາໄຊ")
            {
                cobprovince.Items.Add("ປາກຊັນ");
                cobprovince.Items.Add("ທ່າພະບາດ");
                cobprovince.Items.Add("ປາກກະດິງ");
                cobprovince.Items.Add("ບໍລິຄັນ");
                cobprovince.Items.Add("ຄໍາເກີດ");
                cobprovince.Items.Add("ວຽງທອງ");
                cobprovince.Items.Add("ໄຊຈໍາພອນ");
            }
            if (cobdistrict.SelectedItem == "ຄໍໍາມ່ວນ")
            {
                cobprovince.Items.Add("ທ່າແຂກ");
                cobprovince.Items.Add("ມະຫາໄຊ");
                cobprovince.Items.Add("ໜອງບົກ");
                cobprovince.Items.Add("ຫີນບູນ");
                cobprovince.Items.Add("ຍົມມະລາດ");
                cobprovince.Items.Add("ບົວລະພາ");
                cobprovince.Items.Add("ນາກາຍ");
                cobprovince.Items.Add("ເຊບັ້ງໄຟ");
                cobprovince.Items.Add("ໄຊບົວທອງ");
                cobprovince.Items.Add("ຄູນຄໍາ");
            }
            if (cobdistrict.SelectedItem == "ຄໍາມ່ວນ")
            {
                cobprovince.Items.Add("ທ່າແຂກ");
                cobprovince.Items.Add("ມະຫາໄຊ");
                cobprovince.Items.Add("ໜອງບົກ");
                cobprovince.Items.Add("ຫີນບູນ");
                cobprovince.Items.Add("ຍົມມະລາດ");
                cobprovince.Items.Add("ບົວລະພາ");
                cobprovince.Items.Add("ນາກາຍ");
                cobprovince.Items.Add("ເຊບັ້ງໄຟ");
                cobprovince.Items.Add("ໄຊບົວທອງ");
                cobprovince.Items.Add("ຄູນຄໍາ");
            }
            if (cobdistrict.SelectedItem == "ສະຫວັນນະເຂດ")
            {
                cobprovince.Items.Add("ໄກສອນ ພົມວິຫານ");
                cobprovince.Items.Add("ອຸທຸມພອນ");
                cobprovince.Items.Add("ອາດສະພັງທອງ");
                cobprovince.Items.Add("ພີນ");
                cobprovince.Items.Add("ເຊໂປນ");
                cobprovince.Items.Add("ນອງ");
                cobprovince.Items.Add("ທ່າປາງທອງ");
                cobprovince.Items.Add("ສອງຄອນ");
                cobprovince.Items.Add("ຈໍາພອນ");
                cobprovince.Items.Add("ຊົນນະບູລີ");
                cobprovince.Items.Add("ໄຊບູລີ");
                cobprovince.Items.Add("ວີລະບຸລີ");
                cobprovince.Items.Add("ອາດສະພອນ");
                cobprovince.Items.Add("ໄຊພູທອງ");
                cobprovince.Items.Add("ພະລານໄຊ");
            }
            if (cobdistrict.SelectedItem == "ສາລະວັນ")
            {
                cobprovince.Items.Add("ຕະໂອ້ຍ");
                cobprovince.Items.Add("ຕຸ້ມລານ");
                cobprovince.Items.Add("ລະຄອນເພັງ");
                cobprovince.Items.Add("ວາປີ");
                cobprovince.Items.Add("ຄົງເຊໂດນ");
                cobprovince.Items.Add("ເລົ່າງານ");
                cobprovince.Items.Add("ສະມ້ວຍ");
            }
            if (cobdistrict.SelectedItem == "ເຊກອງ")
            {
                cobprovince.Items.Add("ລະມານ");
                cobprovince.Items.Add("ກະເລິມ");
                cobprovince.Items.Add("ດາກຈຶງ");
                cobprovince.Items.Add("ທ່າແຕງ");
            }
            if (cobdistrict.SelectedItem == "ຈໍາປາສັກ")
            {
                cobprovince.Items.Add("ປາກເຊ");
                cobprovince.Items.Add("ຊະນະສົມບູນ");
                cobprovince.Items.Add("ບາຈຽງຈະເລີນສຸກ");
                cobprovince.Items.Add("ປາກຊ່ອງ");
                cobprovince.Items.Add("ປະທຸມພອນ");
                cobprovince.Items.Add("ໂພນທອງ");
                cobprovince.Items.Add("ຈໍາປາສັກ");
                cobprovince.Items.Add("ສຸຂຸມາ");
                cobprovince.Items.Add("ມູນລະປະໂມກ");
                cobprovince.Items.Add("ໂຂງ");
            }
            if (cobdistrict.SelectedItem == "ອັດຕະປື")
            {
                cobprovince.Items.Add("ໄຊເສດຖາ");
                cobprovince.Items.Add("ສາມັກຄີໄຊ");
                cobprovince.Items.Add("ສະໜາມໄຊ");
                cobprovince.Items.Add("ສານໄຊ");
                cobprovince.Items.Add("ພູວົງ");
            }
            if (cobdistrict.SelectedItem == "ໄຊສົມບູນ")
            {
                cobprovince.Items.Add("ອະນຸວົງ");
                cobprovince.Items.Add("ລ້ອງແຈ້ງ");
                cobprovince.Items.Add("ລ້ອງຊານ");
                cobprovince.Items.Add("ເມືອງຮົ່ມ");
                cobprovince.Items.Add("ທ່າໂທມ");
            }
        }

        private void txtadd_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("insert into userderr values(@user_id,@user_name,@user_surename,@user_age,@user_birthday,@user_village,@user_province,@user_district,@user_phone,@user_pass)", cd.conder);
            cmd.Parameters.AddWithValue("@user_id", txtuser.Text);
            cmd.Parameters.AddWithValue("@user_name", txtname.Text);
            cmd.Parameters.AddWithValue("@user_surename", txtsurename.Text);
            cmd.Parameters.AddWithValue("@user_age", txtage.Text);
            cmd.Parameters.AddWithValue("@user_birthday", txtbirthday.Value.Date);
            cmd.Parameters.AddWithValue("@user_village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@user_province", cobprovince.Text);
            cmd.Parameters.AddWithValue("@user_district", cobdistrict.Text);
            cmd.Parameters.AddWithValue("@user_phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@user_pass", txtpass.Text);


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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtuser.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsurename.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtage.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbirthday.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtvillage.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cobprovince.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cobdistrict.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtphone.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtpass.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();


        }

        private void txtedit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update userderr set user_id=@user_id,user_name=@user_name,user_surename=@user_surename,user_age=@user_age,user_birthday=@user_birthday,user_village=@user_village,user_province=@user_province,user_district=@user_district,user_phone=@user_phone,user_pass=@user_pass", cd.conder);
            cmd.Parameters.AddWithValue("@user_id", txtuser.Text);
            cmd.Parameters.AddWithValue("@user_name", txtname.Text);
            cmd.Parameters.AddWithValue("@user_surename", txtsurename.Text);
            cmd.Parameters.AddWithValue("@user_age", txtage.Text);
            cmd.Parameters.AddWithValue("@user_birthday", txtbirthday.Value.Date);
            cmd.Parameters.AddWithValue("@user_village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@user_province", cobprovince.Text);
            cmd.Parameters.AddWithValue("@user_district", cobdistrict.Text);
            cmd.Parameters.AddWithValue("@user_phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@user_pass", txtpass.Text);
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

        private void txtdelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete userderr where user_name=@user_name", cd.conder);
            cmd.Parameters.AddWithValue("@user_name", txtname.Text);

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

        private void btmain_Click(object sender, EventArgs e)
        {
            new mainform().Show();
            this.Hide();
        }
    }
}
