using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayrollApplication
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count==0)
                Response.Redirect("Login.aspx");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void genSalary_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                String query = "SELECT * FROM MonthlySalary";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                SqlDataReader reader = cmd1.ExecuteReader();
                int flag = 0;
                while (reader.Read())
                {
                    if (reader.GetValue(9).ToString() == DateTime.Now.AddMonths(-1).ToString("MMMM"))
                        flag = 1;
                }
                reader.Close();
                if(flag != 1)
                {
                    query = "SELECT * FROM Salary;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr=cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    int i = 0;
                    foreach(DataRow row in dt.Rows)
                    {
                        
                        String query1 = "INSERT INTO MonthlySalary(FacultyId,M_BasicPay,M_DA,M_HRA,M_CA,M_SA) " +
                            "VALUES(@empid,@bp,@da,@hra,@ca,@sa)";
                        SqlCommand cmd2 = new SqlCommand(query1, conn);
                        cmd2.Parameters.AddWithValue("@empid", (int)row["FacultyId"]);
                        cmd2.Parameters.AddWithValue("@bp", (int)row["BasicPay"]);
                        cmd2.Parameters.AddWithValue("@da", (int)row["DA"]);
                        cmd2.Parameters.AddWithValue("@hra", (int)row["HRA"]);
                        cmd2.Parameters.AddWithValue("@ca", (int)row["CA"]);
                        cmd2.Parameters.AddWithValue("@sa", (int)row["SA"]);
                        cmd2.ExecuteNonQuery();
                    }
                    //dr.Close();
                    message.Visible = true;
                    message.Text = "Salary generated for this month";
                    message.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    message.Visible = true;
                    message.Text = "Salary already generated for this month";
                    message.ForeColor = System.Drawing.Color.Red;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}