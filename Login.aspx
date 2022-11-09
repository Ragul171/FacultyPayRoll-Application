<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PayrollApplication.Login" EnableViewState="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="row m-5">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-6">
                    <div class="card">
                        <div class="card-header">
                            <asp:Image runat="server" ImageUrl="automatic_calculation.svg" 
                                alt="Online payroll system with automatic payroll calculation" 
                                style="width: 80px; height: 80px;"></asp:Image>
                        </div>
                        <div class="card-body h-50">
                        <h3 class="card-title">Automatic payroll calculation</h3>
                        <p class="card-text">Run payroll in a few clicks and automatically generate pay-slips 
                            online with a thorough breakdown of taxes, allowances, and deductions.</p>
                        </div>
                    </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card">
                            <div class="card-header">
                                <asp:Image runat="server" ImageUrl="collaborative_portal.svg" 
                                    alt="Online payroll system with automatic payroll calculation" 
                                    style="width: 80px; height: 80px;"></asp:Image>
                            </div>
                            <div class="card-body h-50">
                            <h3 class="card-title">Encourage faculty self-service</h3>
                            <p class="card-text">Enable seamless collaboration between faculties and your 
                                payroll staff and reduce the burden of <br />faculty requests.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="card align-content-center" style="width: 38rem;">
                   <div class="card-body">
                   <h2 class="card-title p-3">Login</h2>
                    <asp:Label runat="server" ID="lblMessage" ForeColor="Red" Visible="false"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control p-2 w-75" placeholder="Enter Username"></asp:TextBox><br />
                    <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control p-2 w-75" placeholder="Enter Password"></asp:TextBox><br />
                    <asp:Button runat="server" Text="Login" CssClass="btn btn-primary p-2 w-75" OnClick="Login_Click"/> 
                    </div>
                </div>
            </div>
        </div>
        
    
    </center>
</asp:Content>
