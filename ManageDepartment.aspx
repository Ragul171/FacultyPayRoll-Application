<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="PayrollApplication.ManageDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    
    <div class="container" height="300px">
        <div class="row">
            <asp:Label runat="server" ID="lblMessage" CssClass="text-center"></asp:Label>
            <asp:Table runat="server" CssClass="table table-responsive m-2">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Department Name" CssClass="form-label"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDepartmentName" runat="server" ValidationGroup="avail" CssClass="form-control w-50"/>
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtDepartmentName" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>   
                    <asp:TableCell>
                        <asp:Button runat="server" ID="addDepartment" Text="Add" ValidationGroup="avail" CssClass="btn btn-primary w-50" OnClick="addDepartment_Click"/>
                    </asp:TableCell> 
                </asp:TableRow>         
            </asp:Table>
        </div>
        <div class="row">
            <asp:GridView ID="deptGrid" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="deptGrid_PageIndexChanging"
                OnRowEditing="deptGrid_RowEditing" OnRowCancelingEdit="deptGrid_RowCancelingEdit"
                OnRowUpdating="deptGrid_RowUpdating" OnRowDeleting="deptGrid_RowDeleting"
                AutoGenerateColumns="false" ShowHeader="true" 
                DataKeyNames="DeptId" CssClass="table table-striped table-responsive" >
                <Columns>
                    <asp:TemplateField HeaderText="Department Id">
                        <ItemTemplate>
                            <asp:Label ID="lblDeptId" Text='<%# Eval("DeptId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DeptName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDeptName" Text='<%# Eval("DeptName") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="Edit" CssClass="btn btn-primary fa" Text="&#xf044;"/>
                            <asp:Button runat="server" CommandName="Delete" CssClass="btn btn-danger fa" Text="&#xf1f8;" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button runat="server" CommandName="Update" CssClass="btn btn-primary fa" Text="&#xf0c7;" />
                            <asp:Button runat="server" CommandName="Cancel" CssClass="btn btn-danger fa" Text="&#xf00d;" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>

       
</asp:Content>
