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
    public partial class LeaveApproval : System.Web.UI.Page
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
                String query = @"SELECT l.Id,l.LeaveId,e.FacultyId,e.FacultyName,LeaveType, FromDate, ToDate, Reason,No_of_days 
                                    FROM LeaveDetails l JOIN LeaveTypes lt
                                    ON l.LeaveId = lt.LeaveId
                                    JOIN Faculty e ON l.FacultyId = e.FacultyId
                                    WHERE Status = 'Pending'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                leaveApprovalGrid.DataSource = dt;
                leaveApprovalGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void leaveApprovalGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Approve")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                    conn.Open();

                    String query = @"UPDATE LeaveDetails SET Status='Approved' WHERE Id=" + e.CommandArgument;
                    Console.WriteLine(e.CommandArgument);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    PopulateGrid();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (e.CommandName == "Reject")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                    conn.Open();

                    String query = @"UPDATE LeaveDetails SET Status='Rejected' WHERE Id=" + e.CommandArgument;
                    Console.WriteLine(e.CommandArgument);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    PopulateGrid();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}