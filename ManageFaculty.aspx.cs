using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PayrollApplication
{
    public partial class ManageFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FacultyId"]==null)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                PopulateGrid();
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

        }
        public DataTable getDepartment()
        {
            //throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            conn.Open();
            cmd = new SqlCommand("getDepartment", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable getDesignation()
        {
            //throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            conn.Open();
            cmd = new SqlCommand("getDesignation", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        void PopulateGrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FacultyId,FacultyName,FacultyDob,FacultyAddress,FacultyMobile,FacultyEmail,FacultyDepartment,FacultyDesignation,dt.DeptName,dsg.DesignationName " +
                    " FROM Faculty INNER JOIN Department dt ON FacultyDepartment=dt.DeptId" +
                    " INNER JOIN Designation dsg ON FacultyDesignation=dsg.DesignationId", conn);
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

        protected void empGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            empGrid.EditIndex = e.NewEditIndex;
            
                /*fillDepartmentDrop();
                fillDesignationDrop();*/
            PopulateGrid();
        }

        protected void empGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblGridMessage.Text = "";
            lblGridMessage.Enabled = false;
            empGrid.EditIndex = -1;
            
            PopulateGrid();
        }

        protected void empGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if((empGrid.Rows[e.RowIndex].FindControl("txtEmpMobile") as TextBox).Text.Trim().Length == 10)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                    conn.Open();
                    string query = @"UPDATE Faculty SET FacultyMobile=@Faculty_Mobile,FacultyDepartment=@Faculty_Dept,FacultyDesignation=@Faculty_Designation WHERE FacultyId=@Faculty_Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Faculty_Mobile", (empGrid.Rows[e.RowIndex].FindControl("txtEmpMobile") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Faculty_Dept", int.Parse((empGrid.Rows[e.RowIndex].FindControl("drpDept") as DropDownList).SelectedValue));
                    cmd.Parameters.AddWithValue("@Faculty_Designation", int.Parse((empGrid.Rows[e.RowIndex].FindControl("drpDesignation") as DropDownList).SelectedValue));
                    cmd.Parameters.AddWithValue("@Faculty_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                    int n = cmd.ExecuteNonQuery();
                    empGrid.EditIndex = -1;
                    Console.WriteLine(n);
                    PopulateGrid();
                    lblGridMessage.Text = "";
                    lblGridMessage.Enabled = false;
                    conn.Close();
                }
                else
                {
                    lblGridMessage.Enabled = true;
                    lblGridMessage.Text = "Mobile No. must have 10 digits";
                    lblGridMessage.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void empGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string qry = @"SELECT FacultyUserId FROM Faculty WHERE FacultyId=@Emp_Id";

                SqlCommand cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                SqlDataReader dr=cmnd.ExecuteReader();
                String userid="";
                while (dr.Read())
                {
                    userid = dr.GetString(0);
                }
                dr.Close();
                qry = @"DELETE FROM Deduction WHERE FacultyId=@Emp_Id";
                cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                cmnd.ExecuteNonQuery();
                qry = @"DELETE FROM Salary WHERE FacultyId=@Emp_Id";
                cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                cmnd.ExecuteNonQuery();
                qry = @"DELETE FROM MonthlySalary WHERE FacultyId=@Emp_Id";
                cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                cmnd.ExecuteNonQuery();
                qry = @"DELETE FROM LeaveDetails WHERE FacultyId=@Emp_Id";
                cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                cmnd.ExecuteNonQuery();
                qry = @"DELETE FROM Faculty WHERE FacultyId=@Emp_Id";
                cmnd = new SqlCommand(qry, conn);
                cmnd.Parameters.AddWithValue("@Emp_Id", Convert.ToInt32(empGrid.DataKeys[e.RowIndex].Value.ToString()));
                cmnd.ExecuteNonQuery();
                qry = "DELETE FROM Login WHERE LoginId='" + userid + "'";
                cmnd = new SqlCommand(qry, conn);
                cmnd.ExecuteNonQuery();
                empGrid.EditIndex = -1;
                PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void empGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            empGrid.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        protected void empName_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT FacultyId, FacultyName, FacultyDob, FacultyAddress, FacultyMobile, FacultyEmail, FacultyDepartment, FacultyDesignation, dt.DeptName,dsg.DesignationName " +
                    " FROM Faculty INNER JOIN Department dt ON FacultyDepartment=dt.DeptId" +
                    " INNER JOIN Designation dsg ON FacultyDesignation=dsg.DesignationId WHERE FacultyName LIKE '%"+ empName.Text + "%'", conn);
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

        protected void empGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("drpDept");
                    Label dept = (Label)e.Row.FindControl("dept");
                    ddList.SelectedValue= dept.Text;
                    //return DataTable havinf department data
                    DataTable dt = getDepartment();
                    ddList.DataSource = dt;
                    ddList.DataTextField = "DeptName";
                    ddList.DataValueField = "DeptId";
                    ddList.DataBind();

                    DropDownList ddList1 = (DropDownList)e.Row.FindControl("drpDesignation");
                    Label desig = (Label)e.Row.FindControl("desig");
                    ddList1.SelectedValue = desig.Text;
                    //return DataTable havinf department data
                    DataTable dt1 = getDesignation();
                    ddList1.DataSource = dt1;
                    ddList1.DataTextField = "DesignationName";
                    ddList1.DataValueField = "DesignationId";
                    ddList1.DataBind();
                }
            }
        }

    }
}