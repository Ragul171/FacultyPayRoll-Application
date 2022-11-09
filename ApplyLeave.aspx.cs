using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayrollApplication
{
    public partial class ApplyLeave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
                fillLeaveTypesDrop();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        private void fillLeaveTypesDrop()
        {
            //throw new NotImplementedException();
            drpLeaveTypes.DataSource = getLeaveTypes();
            drpLeaveTypes.DataTextField = "LeaveType";
            drpLeaveTypes.DataValueField = "LeaveId";
            drpLeaveTypes.DataBind();
        }
        public DataTable getLeaveTypes()
        {
            //throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            conn.Open();
            cmd = new SqlCommand("getLeaveTypes", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        protected void ApplyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = "Select * FROM LeaveDetails WHERE FromDate=@FromDate AND FacultyId=@EmpId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim());
                cmd.Parameters.AddWithValue("@EmpId", Session["FacultyId"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    dr.Close();
                    query = @"INSERT INTO LeaveDetails (FacultyId,LeaveId,FromDate,ToDate,Reason,Status)
                    VALUES(@EmpId,@LeaveId,@FromDate,@ToDate,@Reason,@Status)";
                    cmd = new SqlCommand(query, conn);
                    Console.WriteLine(Session["FacultyId"]);
                    cmd.Parameters.AddWithValue("@EmpId", Session["FacultyId"]);
                    cmd.Parameters.AddWithValue("@LeaveId", int.Parse(drpLeaveTypes.SelectedValue));
                    cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Reason", txtReason.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                    cmd.ExecuteNonQuery();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Leave applied successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtFromDate.Text = "";
                    txtToDate.Text = "";
                    txtReason.Text = "";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Leave already applied for the mentioned dates";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void drpLeaveTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}