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
    public partial class LeaveSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                PopulateGrid();
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        private void PopulateGrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                String query = @"SELECT l.LeaveId,LeaveType, FromDate, ToDate, Reason,No_of_days,Status FROM LeaveDetails l JOIN LeaveTypes lt
                                    ON l.LeaveId = lt.LeaveId
                                    WHERE l.FacultyId ="+Session["FacultyId"] +"ORDER BY FromDate DESC;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                empGrid.DataSource = dt;
                empGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void empGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            empGrid.PageIndex = e.NewPageIndex;
            PopulateGrid();
            
        }
    }
}