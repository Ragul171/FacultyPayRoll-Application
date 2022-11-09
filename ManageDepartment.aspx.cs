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
    public partial class ManageDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FacultyId"] == null)
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
                SqlCommand cmd = new SqlCommand("SELECT DeptId,DeptName FROM Department", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                deptGrid.DataSource = dt;
                deptGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void addDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd;
                String query;
                query = @"INSERT INTO Department (DeptName)
                    VALUES(@DeptName)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DeptName", txtDepartmentName.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                txtDepartmentName.Text = "";
                if (n > 0)
                {
                    lblMessage.Text = "Addition Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Oops!!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void deptGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            deptGrid.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        protected void deptGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            deptGrid.EditIndex = e.NewEditIndex;
            PopulateGrid();
        }

        protected void deptGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            deptGrid.EditIndex = -1;
            PopulateGrid();
        }

        protected void deptGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = @"UPDATE Department SET DeptName=@deptName WHERE DeptId = @deptId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@deptName", (deptGrid.Rows[e.RowIndex].FindControl("txtDeptName") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@deptId", Convert.ToInt32(deptGrid.DataKeys[e.RowIndex].Value.ToString()));
                int n = cmd.ExecuteNonQuery();
                deptGrid.EditIndex = -1;
                Console.WriteLine(n);
                PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void deptGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = @"DELETE FROM Department WHERE DeptId = @deptId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@deptId", Convert.ToInt32(deptGrid.DataKeys[e.RowIndex].Value.ToString()));
                int n = cmd.ExecuteNonQuery();
                deptGrid.EditIndex = -1;
                Console.WriteLine(n);
                PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}