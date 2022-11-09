<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddFaculty.aspx.cs" Inherits="PayrollApplication.AddFaculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
        <center>
            <div class="container"><br />
                <asp:Label runat="server" ID="lblMessage" CssClass="form-label" Visible="false"></asp:Label>
                <table class="table table-responsive m-2">
                    <tr>
                        <td ><asp:Label runat="server" CssClass="form-label" Text="Faculty Name"></asp:Label></td>
                        <td><asp:TextBox ID="txtFacultyNameAdd" runat="server" ValidationGroup="avail" CssClass="form-control w-50"/>
                        </td>
                        <td><asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtFacultyNameAdd" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                        
                    </tr>
                    <tr>
                        <td ><asp:Label runat="server" CssClass="form-label" Text="Faculty DOB"></asp:Label></td>
                        <td><asp:TextBox ID="txtFacultyDobAdd" runat="server" ValidationGroup="avail" TextMode="Date" CssClass="form-control w-50"/>
                        </td>
                        <td><asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtFacultyDobAdd" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                        
                    </tr>
                    <tr>
                        <td ><asp:Label runat="server" CssClass="form-label" Text="Faculty Address"></asp:Label></td>
                        <td><asp:TextBox ID="txtFacultyAddressAdd" runat="server" ValidationGroup="avail" CssClass="form-control w-50"/></td>
                        <td><asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtFacultyAddressAdd" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td ><asp:Label runat="server" CssClass="form-label" Text="Faculty Mobile Number"></asp:Label></td>
                        <td ><asp:TextBox ID="txtFacultyMobileAdd" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ValidationGroup="avail" MaxLength="10" CssClass="form-control w-50"/></td>
                        
                        <td>
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtFacultyMobileAdd" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ValidationExpression="[0-9]{10}" ErrorMessage="*Mobile number must be 10 digits" ForeColor="Red" ControlToValidate="txtFacultyMobileAdd"></asp:RegularExpressionValidator>
                            </td>
                    </tr>
                    <tr>
                        <td ><asp:Label runat="server" CssClass="form-label" Text="Faculty Email ID"></asp:Label></td>
                        <td ><asp:TextBox ID="txtFacultyEmailAdd" runat="server" ValidationGroup="avail" TextMode="Email" CssClass="form-control w-50"/></td>
                        <td><asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtFacultyEmailAdd" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                    </tr>
                    
                    <tr>
                        <td ><asp:Label runat="server" ValidationGroup="avail" CssClass="form-label" Text="Faculty Department"></asp:Label></td>
                        <td ><asp:DropDownList ID="drpDept" runat="server"  ValidationGroup="avail" CssClass="form-control form-select w-50">
                               
                             </asp:DropDownList></td>
                        <td><asp:RequiredFieldValidator runat="server"  ValidationGroup="avail" ControlToValidate="drpDept" InitialValue="0"  ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                         <td ><asp:Label runat="server" ValidationGroup="avail" CssClass="form-label" Text="Faculty Designation"></asp:Label></td>
                        <td ><asp:DropDownList ID="drpDesignation" runat="server" ValidationGroup="avail" CssClass="form-control form-select w-50">
                                <asp:ListItem Text="--Select Designation--"></asp:ListItem>
                             </asp:DropDownList></td>
                        <td><asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="drpDesignation" InitialValue="0" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-center">
                            <asp:Button runat="server" Text="Add" ValidationGroup="avail" CssClass="btn btn-primary w-50" OnClick="Add_Click"/>
                        </td>
                    </tr>
                </table>

            </div>
        </center>
</asp:Content>

