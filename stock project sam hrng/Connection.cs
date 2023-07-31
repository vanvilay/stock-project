using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace stock_project_sam_hrng
{
    internal class Connection
    {
        public const string con = "Data Source=DESKTOP-VNVAI9F\\SQLEXPRESS;Initial Catalog=stockproduct1;Integrated Security=True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        public void connectder()
        {

            if (conder.State == System.Data.ConnectionState.Open)
            {
                conder.Close();
            }
            conder.ConnectionString = con;
            conder.Open();
        }


        public void dbClose()
        {
            conder.Close();
        }
    }
}
