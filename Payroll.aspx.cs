using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Html2pdf;
using CW_TestLibrary;
using System.IO;


namespace PayrollApplication
{
    public partial class Payroll : System.Web.UI.Page
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
                String query = @"SELECT m.Id,m.M_BasicPay,m.M_DA,m.M_HRA,m.M_CA,m.M_SA,m.M_GrossPay,m.M_NetPay,d.PF,d.LOPAmount,d.ProfessionalTax,m.Month,m.Year 
                                FROM MonthlySalary m
                                INNER JOIN Deduction d
                                ON m.Id=d.MId AND m.FacultyId="+Session["FacultyId"];
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                payrollGrid.DataSource = dt;
                payrollGrid.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void payrollGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FacultyConnectionString"].ConnectionString);
                    SqlCommand cmd;
                    SqlDataReader dr;
                    DataTable dt;
                    String query;
                    conn.Open();
                    String _url = "";
                    String html = @"<html>
                                    <head>
                                        <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3' crossorigin='anonymous'>
                                    </head>
                                    <body>
                                    <div class='container'>";
                    html += "<center> " +
                            "<h1>ABC Engineering College</h1><br/>" +
                            "<h3>Sivakasi-626123</h3>" +
                            "</center> "+
                            "<table class='table table-responsive'>";
                    query = @"SELECT * FROM Faculty e
                            INNER JOIN Department dept ON e.FacultyDepartment = dept.DeptId
                            INNER JOIN Designation desg ON e.FacultyDesignation = desg.DesignationId AND e.FacultyId =" + Session["FacultyId"];
                    cmd=new SqlCommand(query, conn);
                    dr=cmd.ExecuteReader();
                    dt=new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    foreach (DataRow row in dt.Rows)
                    {
                        html += "<tr> <td>Faculty Name </td>"
                            + "<td>" + row["FacultyName"]+ "</td></tr>"+
                            "<tr> <td>Faculty Designation </td>"
                            + "<td>" + row["DesignationName"] + "</td></tr>"+
                            "<tr> <td>Faculty Department </td>"
                            + "<td>" + row["DeptName"] + "</td></tr>"+
                            "<tr> <td>Faculty Email </td>"
                            + "<td>" + row["FacultyEmail"] + "</td></tr>"+
                            "<tr> <td>Faculty Mobile No. </td>"
                            + "<td>" + row["FacultyMobile"] + "</td></tr>";
                    }
                    html += "</table>" +
                        "<br/><br/>";

                    query = @"SELECT m.Id,m.M_BasicPay,m.M_DA,m.M_HRA,m.M_CA,m.M_SA,m.M_GrossPay,m.M_NetPay,d.PF,d.LOPAmount,d.ProfessionalTax,m.Month,m.Year 
                                FROM MonthlySalary m
                                INNER JOIN Deduction d
                                ON m.Id=d.MId AND m.FacultyId=" + Session["FacultyId"] + " AND m.Id=" + e.CommandArgument;
                    cmd = new SqlCommand(query, conn);
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    foreach(DataRow row in dt.Rows)
                    {
                        html += "<h3>Month: "+row["Month"]+ "</h3><table class='table table-responsive'>" +
                        "<thead class='thead-light'>" +
                        "<tr>" +
                        "<th colspan='2'>Earnings</th>" +
                        "<th colspan='2'>Reduction</th>" +
                        "</tr>" +
                        "</thead><tbody>"+"<tr>" +
                            "<td>Basic Pay</td>" +
                            "<td>" + row["M_BasicPay"] + "</td>" +
                            "<td>PF </td>" +
                            "<td>" + row["PF"] + "</td></tr>" +
                            "<tr>" +
                            "<td>Dearness Allowance</td>" +
                            "<td>" + row["M_DA"] + "</td>" +
                            "<td>LOP Amount </td>" +
                            "<td>" + row["LOPAmount"] + "</td></tr>" +
                            "<tr>" +
                            "<td>House Rent Allowance</td>" +
                            "<td>" + row["M_HRA"] + "</td>" +
                            "<td>Professional Tax </td>" +
                            "<td>" + row["ProfessionalTax"] + "</td></tr>" +
                            "<tr>" +
                            "<td>Conveyance Allowance</td>" +
                            "<td>" + row["M_CA"] + "</td></tr>" +
                            "<tr>" +
                            "<td>Special Allowance</td>" +
                            "<td>" + row["M_SA"] + "</td></tr>";
                        int totEarn = (int)row["M_BasicPay"] + (int)row["M_DA"] + (int)row["M_HRA"] + (int)row["M_CA"] + (int)row["M_SA"];
                        int totDed = (int)row["PF"] + (int)row["LOPAmount"] + (int)row["ProfessionalTax"];
                        html += "<tr>" +
                            "<td>Total Earnings </td>" +
                            "<td>" + totEarn + "</td>" +
                            "<td>Total Deduction</td>" +
                            "<td>" + totDed + "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='2'>Gross Pay</td>" +
                            "<td colspan='2'>" +row["M_GrossPay"]+"</td>"+
                            "</tr>"+
                            "<tr>" +
                            "<td colspan='2'>Net Pay</td>" +
                            "<td colspan='2'>" + row["M_NetPay"] + "</td>" +
                            "</tr>";
                    }
                    html += "</tbody></table></div></body></html>";
                    String fPath = Server.MapPath("~//Report//");
                    String filename=System.Guid.NewGuid().ToString();
                    String file = fPath+filename + ".pdf";

                    ConverterProperties cp=new ConverterProperties();
                    cp.SetBaseUri(_url);
                    HtmlConverter.ConvertToPdf(html,new FileStream(file, FileMode.Create),cp);

                    Response.ContentType = "Application/pdf";
                    Response.AppendHeader("Content-Disposition","attachment; filename="+filename+".pdf");
                    Response.TransmitFile(Server.MapPath("~/Report/"+filename + ".pdf"));
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}