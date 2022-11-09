using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayrollApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
            conn.Open();
            String uname=txtUsername.Text;
            String pass=txtPassword.Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE LoginId='" + uname + "' AND Password ='" + pass + "'", conn);
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.HasRows && uname == "admin")
            {
                Session["FacultyId"] = 0;
                Response.Redirect("AdminHome.aspx");
            }
            else if (dr.HasRows)
            {
                dr.Close();
                cmd = new SqlCommand("SELECT * FROM Faculty WHERE FacultyUserId='" + uname + "'", conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["FacultyId"] = dr.GetValue(0);
                        Console.WriteLine(dr.GetValue(0));
                        Response.Write(dr.GetValue(0));
                    }
                }

                Response.Redirect("FacultyHome.aspx");
                dr.Close();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "* Username/Password is not valid";
            }
        }
    }
}