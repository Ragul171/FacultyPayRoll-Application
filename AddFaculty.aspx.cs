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
    public partial class AddFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count==0)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                fillDepartmentDrop();
                fillDesignationDrop();
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        private void fillDepartmentDrop()
        {
            //throw new NotImplementedException();
            drpDept.DataSource = getDepartment();
            drpDept.DataTextField = "DeptName";
            drpDept.DataValueField = "DeptId";
            drpDept.DataBind();
            drpDept.Items.Insert(0, new ListItem("--Select Department--", "0"));
        }
        private void fillDesignationDrop()
        {
            //throw new NotImplementedException();
            drpDesignation.DataSource = getDesignation();
            drpDesignation.DataTextField = "DesignationName";
            drpDesignation.DataValueField = "DesignationId";
            drpDesignation.DataBind();
            drpDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));
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
        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                string query = "INSERT INTO Login(LoginId,Password) VALUES('" + txtFacultyEmailAdd.Text.Trim() + "','" + txtFacultyDobAdd.Text.Trim() + "');";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                query = @"INSERT INTO Faculty (FacultyName,FacultyDob,FacultyAddress,FacultyMobile,FacultyEmail,FacultyUserId,FacultyDesignation,FacultyDepartment)
                    VALUES(@Faculty_Name,@Faculty_DOB,@Faculty_Address,@Faculty_Mobile,@Faculty_Email,@Faculty_UserId,@Faculty_Designation,@Faculty_Department)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Faculty_Name", txtFacultyNameAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_DOB", txtFacultyDobAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_Address", txtFacultyAddressAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_Mobile", txtFacultyMobileAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_Email", txtFacultyEmailAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_UserId", txtFacultyEmailAdd.Text.Trim());
                cmd.Parameters.AddWithValue("@Faculty_Department", int.Parse(drpDept.SelectedValue));
                cmd.Parameters.AddWithValue("@Faculty_Designation", int.Parse(drpDesignation.SelectedValue));
                int n = cmd.ExecuteNonQuery();
               
                
                txtFacultyNameAdd.Text = "";
                txtFacultyAddressAdd.Text = "";
                txtFacultyMobileAdd.Text = "";
                txtFacultyDobAdd.Text = "";
                txtFacultyEmailAdd.Text = "";
                
                if (n > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Addition Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    //Console.WriteLine("Addition Successfull");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Addition Failed";
                }
              //  PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}