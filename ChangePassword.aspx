<%@ Page Title="" Language="C#" MasterPageFile="~/FacultyMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PayrollApplication.ChangePassword" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <center>
        <div class="card m-2" style="width: 38rem;">
            <div class="card-header">
                <h2 class="card-title p-3">Change Password</h2>
            </div>
            <div class="card-body">
                <asp:Label runat="server" ID="lblMessage" ForeColor="Red" Visible="false"></asp:Label><br />
                <asp:TextBox runat="server" TextMode="Password" ID="txtOldPassword" CssClass="form-control p-2 w-75" 
                    placeholder="Current Password"></asp:TextBox><br />
                <asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword" CssClass="form-control p-2 w-75" 
                    ValidationGroup="avail" placeholder="New Password"></asp:TextBox><br />
                <asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" CssClass="form-control p-2 w-75" 
                    ValidationGroup="avail" placeholder="Confirm Password"></asp:TextBox><br />
                <asp:CompareValidator runat="server" ID="NewPasswordCompareValidator" 
                    ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
                    ValidationGroup="avail" ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
            </div>
            <div class="card-footer">
                <asp:Button runat="server" ID="updatePassword" ValidationGroup="avail" Text="Update" CssClass="btn btn-primary p-2 w-75" OnClick="updatePassword_Click"/> 
            </div>
        </div>
    </center>
</asp:Content>
