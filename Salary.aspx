<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="PayrollApplication.Salary" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container" height="300px"><br />
        <asp:Table runat="server" CssClass="table table-responsive m-2">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Select Faculty" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="drpEmployee" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged" CssClass="form-control form-select w-50"></asp:DropDownList>
                </asp:TableCell>   
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddSalary" CssClass="btn btn-primary" Text="Add" OnClick="AddSalary_Click1" />
                </asp:TableCell> 
                <asp:TableCell>
                    <asp:Button runat="server" ID="UpdateSalary" CssClass="btn btn-primary" Text="Update" OnClick="UpdateSalary_Click1" />
                </asp:TableCell> 
            </asp:TableRow>
                    
        </asp:Table>
        <center>
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
        
            
            <asp:Table runat="server" ID="tblsalary" class="table table-responsive w-50" Visible="false">
            <asp:TableHeaderRow class="bg-light">
                <asp:TableHeaderCell>
                    <asp:Label runat="server" Text="Salary Components" CssClass="form-label m-50 fw-bold"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" Text="Amount" CssClass="form-label m-50 fw-bold "></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Basic Pay" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ValidationGroup="avail" ID="txtBasicPay" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtBasicPay" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Dearness Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtDA" ValidationGroup="avail" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtDA" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="House Rent Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtHRA" ValidationGroup="avail" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtHRA" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Conveyance Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ValidationGroup="avail" ID="txtCA" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtCA" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Special Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ValidationGroup="avail" ID="txtSA" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtSA" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell colspan="2" class="text-center">
                    <asp:Button runat="server" ValidationGroup="avail" Text="Add" CssClass="btn btn-primary w-50" OnClick="AddSalary_Click"/>
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
            <asp:Table runat="server" ID="UpdateTable" class="table table-responsive w-50" Visible="false">
            <asp:TableHeaderRow class="bg-light">
                <asp:TableHeaderCell>
                    <asp:Label runat="server" Text="Salary Components" CssClass="form-label m-50 fw-bold"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" Text="Amount" CssClass="form-label m-50 fw-bold "></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Basic Pay" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="bp" ValidationGroup="avail" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="bp" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Dearness Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="da" ValidationGroup="avail" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="bp" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="House Rent Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="hra" ValidationGroup="avail" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="hra" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Conveyance Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ValidationGroup="avail" ID="ca" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="ca" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Special Allowance" CssClass="form-label m-50"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ValidationGroup="avail" ID="sa" CssClass="form-control w-50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="sa" ErrorMessage="*Required" ForeColor="Red" ></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell colspan="2" class="text-center">
                    <asp:Button runat="server" ValidationGroup="avail" Text="Update" CssClass="btn btn-primary w-50" OnClick="UpdateSalary_Click"/>
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        </center>
        
        
        
    </div>
    

</asp:Content>
