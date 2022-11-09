using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayrollApplication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void updatePassword_Click(object sender, EventArgs e)
        {
            
            try
            {
                string currentPassword = txtOldPassword.Text;
                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = "SELECT * FROM Login WHERE LoginId = (SELECT FacultyUserId FROM Faculty WHERE FacultyId="+ Session["FacultyId"]+")";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                string fetchedLoginId = "";
                int up = 0;
                while (reader.Read())
                {
                    if (txtOldPassword.Text == reader["Password"].ToString())
                    {
                        up = 1;
                        fetchedLoginId = reader["LoginId"].ToString();
                    }
                }
                reader.Close();
                if (up == 1)
                {
                    string query1 = "UPDATE Login SET Password = '" + txtNewPassword.Text.Trim() + "' WHERE LoginId = '" + fetchedLoginId + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.ExecuteNonQuery();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Password Updated Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your Current Password is Incorrect";
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