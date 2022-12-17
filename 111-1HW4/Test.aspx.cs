using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _111_1HW4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Conn = ConfigurationManager.ConnectionStrings["SQLLOCALDB"].ConnectionString;
            SqlConnection o_Conn = new SqlConnection(s_Conn);
            o_Conn.Open();
            SqlDataAdapter o_A = new SqlDataAdapter("Select * from Users", o_Conn);
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            string s_Conn = ConfigurationManager.ConnectionStrings["SQLLOCALDB"].ConnectionString;
            try
            {
                SqlConnection o_Conn = new SqlConnection(s_Conn);
                o_Conn.Open();
                string s_Sql = "Insert into Users (Name, Birthday)" + "values(N'阿貓阿狗', '2000/10/10')";
                SqlCommand o_cmd = new SqlCommand(s_Sql, o_Conn);
                o_cmd.ExecuteNonQuery();
                SqlDataAdapter o_A = new SqlDataAdapter("Select * from Users", o_Conn);
                DataSet o_D = new DataSet();
                o_A.Fill(o_D, "ds_Res");
                gv_DataShow.DataSource = o_D;
                gv_DataShow.DataBind();
                o_Conn.Close();
            }
            catch (Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }
        }
    }
}