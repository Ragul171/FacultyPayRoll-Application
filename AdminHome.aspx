<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="PayrollApplication.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <center>
        <div class="container">
        <div class="row m-5">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-header">
                        <asp:Image runat="server" ImageUrl="payroll_hierarchy.svg" 
                        alt="Online payroll system with automatic payroll calculation" 
                        style="width: 80px; height: 80px;"></asp:Image>
                    </div>
                    <div class="card-body h-50">
                        <h3 class="card-title">Embrace diverse salary structures</h3>
                        <p class="card-text text-center">Create multiple pay slabs for your<br /> faculties the right template with each faculty.</p>
                    </div>
                    <div class="card-footer p-3">
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-header">
                        <asp:Image runat="server" ImageUrl="timely_salary.svg" 
                        alt="Online payroll system with automatic payroll calculation" 
                        style="width: 80px; height: 80px;"></asp:Image>
                    </div>
                    <div class="card-body h-50">
                        <h3 class="card-title">Generate Salary for Faculties</h3>
                        <p class="card-text">Click on the Generate button to generate salries for faculties.</p>
                    </div>
                    <div class="card-footer">
                        <asp:Button runat="server" Text="Generate Salary" CssClass="btn btn-primary " ID="genSalary" OnClick="genSalary_Click" /><br />
                        <asp:Label runat="server" ID="message" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </center>
    
</asp:Content>
