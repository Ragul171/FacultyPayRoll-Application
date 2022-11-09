<%@ Page Title="" Language="C#" MasterPageFile="~/FacultyMaster.Master" AutoEventWireup="true" CodeBehind="FacultyHome.aspx.cs" Inherits="PayrollApplication.EmployeeHome" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <center>
        <h2 class="m-2">Profile</h2>
    <asp:Table runat="server" ID="tblsalary" class="card-body table table-responsive" BorderWidth="0" >
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Name" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyName" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Designation" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyDesg" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Department" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyDept" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Dob" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyDob" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Address" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyAdd" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Email" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyEmail" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Faculty Mobile" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="facultyMobile" CssClass="form-label w-50"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
             
        </asp:Table>
        </center>
</asp:Content>
