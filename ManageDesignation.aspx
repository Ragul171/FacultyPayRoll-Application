<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageDesignation.aspx.cs" Inherits="PayrollApplication.ManageDesignation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
     <div class="container" height="300px">
        <div class="row">
            <asp:Label runat="server" ID="lblMessage" CssClass="text-center"></asp:Label>
            <asp:Table runat="server" CssClass="table table-responsive m-2">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Designation Name" CssClass="form-label"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDesignationName" runat="server" ValidationGroup="avail" CssClass="form-control w-50"/>
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="avail" ControlToValidate="txtDesignationName" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>   
                    <asp:TableCell>
                        <asp:Button runat="server" ID="addDesignation" Text="Add" ValidationGroup="avail" CssClass="btn btn-primary w-50" OnClick="addDesignation_Click"/>
                    </asp:TableCell> 
                </asp:TableRow>         
            </asp:Table>
        </div>
        <div class="row">
            <asp:GridView ID="desigGrid" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="desigGrid_PageIndexChanging"
                OnRowEditing="desigGrid_RowEditing" OnRowCancelingEdit="desigGrid_RowCancelingEdit"
                OnRowUpdating="desigGrid_RowUpdating" OnRowDeleting="desigGrid_RowDeleting"
                AutoGenerateColumns="false" ShowHeader="true" 
                DataKeyNames="DesignationId" CssClass="table table-striped table-responsive" >
                <Columns>
                    <asp:TemplateField HeaderText="Department Id">
                        <ItemTemplate>
                            <asp:Label ID="lblDesigId" Text='<%# Eval("DesignationId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DesignationName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDesigName" Text='<%# Eval("DesignationName") %>' runat="server" />
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
