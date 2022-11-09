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
    public partial class Salary : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                fillEmployeeDrop();
                AddSalary.Enabled = false;
                UpdateSalary.Enabled = false;
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        private void fillEmployeeDrop()
        {
            //throw new NotImplementedException();
            drpEmployee.DataSource = getFaculty();
            drpEmployee.DataTextField = "FacultyName";
            drpEmployee.DataValueField = "FacultyId";
            drpEmployee.DataBind();
            drpEmployee.Items.Insert(0, new ListItem("--Select Faculty--", "0"));
        }

        public DataTable getFaculty()
        {
            //throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            conn.Open();
            cmd = new SqlCommand("getFaculty", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        protected void AddSalary_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd;
                String query;
                query = @"INSERT INTO Salary (FacultyId,BasicPay,DA,HRA,CA,SA)
                    VALUES(@EmpId,@BasicPay,@DA,@HRA,@CA,@SA)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", int.Parse(drpEmployee.SelectedValue));
                cmd.Parameters.AddWithValue("@BasicPay", txtBasicPay.Text.Trim());
                cmd.Parameters.AddWithValue("@DA", txtDA.Text.Trim());
                cmd.Parameters.AddWithValue("@HRA", txtHRA.Text.Trim());
                cmd.Parameters.AddWithValue("@CA", txtCA.Text.Trim());
                cmd.Parameters.AddWithValue("@SA", txtSA.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                txtBasicPay.Text = "";
                txtDA.Text = "";
                txtHRA.Text = "";
                txtCA.Text = "";
                txtSA.Text = "";
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
                
                //  PopulateGrid();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void UpdateSalary_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                SqlCommand cmd;
                conn.Open();
                string query = @"SELECT * FROM Salary WHERE FacultyId=@EmpId;";
                cmd =new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", int.Parse(drpEmployee.SelectedValue));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                query = @"UPDATE Salary SET BasicPay=@BasicPay , DA=@DA, HRA=@HRA, CA=@CA, SA=@SA WHERE FacultyId=@EmpId;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", int.Parse(drpEmployee.SelectedValue));
                cmd.Parameters.AddWithValue("@BasicPay", bp.Text.Trim());
                cmd.Parameters.AddWithValue("@DA", da.Text.Trim());
                cmd.Parameters.AddWithValue("@HRA", hra.Text.Trim());
                cmd.Parameters.AddWithValue("@CA", ca.Text.Trim());
                cmd.Parameters.AddWithValue("@SA", sa.Text.Trim());
                int n = cmd.ExecuteNonQuery();
                bp.Text = "";
                da.Text = "";
                hra.Text = "";
                ca.Text = "";
                sa.Text = "";
                if (n > 0)
                {
                    lblMessage.Text = "Updation Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Oops!!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void AddSalary_Click1(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmd;
                string query = @"SELECT * FROM Salary WHERE FacultyId=@EmpId;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", int.Parse(drpEmployee.SelectedValue));

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tblsalary.Visible = false;
                    UpdateTable.Visible = false;
                    lblMessage.Text = "Salary already added for this faculty.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    
                    tblsalary.Visible = true;
                    UpdateTable.Visible = false;
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.StackTrace);
            }
            
        }

        protected void UpdateSalary_Click1(object sender, EventArgs e)
        {

            lblMessage.Text = "";
            tblsalary.Visible = false;
            UpdateTable.Visible = true;
        }

        protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                SqlCommand cmd;
                conn.Open();
                tblsalary.Visible = false;
                UpdateTable.Visible = false;
                string query = @"SELECT * FROM Salary WHERE FacultyId=@EmpId;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", int.Parse(drpEmployee.SelectedValue));
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    dr.Close();
                    AddSalary.Enabled = true;
                    UpdateSalary.Enabled = false;
                }
                else
                {
                    UpdateSalary.Enabled = true;
                    AddSalary.Enabled = false;
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