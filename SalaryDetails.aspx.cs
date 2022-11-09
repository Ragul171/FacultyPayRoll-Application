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
    public partial class SalaryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            if(!IsPostBack)
                PopulateGrid();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        void PopulateGrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id,BasicPay,DA,HRA,CA,SA FROM Salary WHERE FacultyId="+Session["FacultyId"], conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                salaryGrid.DataSource = dt;
                salaryGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}