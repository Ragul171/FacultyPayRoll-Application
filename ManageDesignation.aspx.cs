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
    public partial class ManageDesignation : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("SELECT DesignationId,DesignationName FROM Designation", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                desigGrid.DataSource = dt;
                desigGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void addDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd;
                String query;
                query = @"INSERT INTO Designation (DesignationName)
                    VALUES(@DesigName)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DesigName", txtDesignationName.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                txtDesignationName.Text = "";
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

        protected void desigGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            desigGrid.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        protected void desigGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            desigGrid.EditIndex = e.NewEditIndex;
            PopulateGrid();
        }

        protected void desigGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            desigGrid.EditIndex = -1;
            PopulateGrid();
        }

        protected void desigGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = @"UPDATE Designation SET DesignationName=@desigName WHERE DesignationId = @desigId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desigName", (desigGrid.Rows[e.RowIndex].FindControl("txtDesigName") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@desigId", Convert.ToInt32(desigGrid.DataKeys[e.RowIndex].Value.ToString()));
                int n = cmd.ExecuteNonQuery();
                desigGrid.EditIndex = -1;
                Console.WriteLine(n);
                PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void desigGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = @"DELETE FROM Designation WHERE DesignationId = @desigId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desigId", Convert.ToInt32(desigGrid.DataKeys[e.RowIndex].Value.ToString()));
                int n = cmd.ExecuteNonQuery();
                desigGrid.EditIndex = -1;
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