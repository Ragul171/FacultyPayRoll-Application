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
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            PopulateTable();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        void PopulateTable()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                SqlCommand cmd;
                SqlDataReader dr;
                DataTable dt;
                String query;
                conn.Open();
                query = @"SELECT * FROM Faculty e
                            INNER JOIN Department dept ON e.FacultyDepartment = dept.DeptId
                            INNER JOIN Designation desg ON e.FacultyDesignation = desg.DesignationId AND e.FacultyId =" + Session["FacultyId"];
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                foreach (DataRow row in dt.Rows)
                {
                    facultyName.Text = (string)row["FacultyName"];
                    facultyDesg.Text = (string)row["DesignationName"];
                    facultyDept.Text = (string)row["DeptName"];
                    facultyDob.Text = row["FacultyDob"].ToString();
                    facultyAdd.Text = row["FacultyAddress"].ToString();
                    facultyEmail.Text = row["FacultyEmail"].ToString();
                    facultyMobile.Text = row["FacultyMobile"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}