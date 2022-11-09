<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageFaculty.aspx.cs" Inherits="PayrollApplication.ManageFaculty" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="m-5">
        <asp:Label runat="server" Text="Search by faculty name :"></asp:Label>
        <asp:TextBox ID="empName" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="search" Text="Search" OnClick="search_Click" CssClass="btn btn-primary" /><br /><br />
        <center><asp:Label runat="server" ID="lblGridMessage" Text="" Enabled="false"></asp:Label></center>
    <asp:GridView ID="empGrid" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="empGrid_PageIndexChanging"
                OnRowEditing="empGrid_RowEditing" OnRowCancelingEdit="empGrid_RowCancelingEdit"
                OnRowUpdating="empGrid_RowUpdating" OnRowDeleting="empGrid_RowDeleting"
                AutoGenerateColumns="false" ShowHeader="true" OnRowDataBound="empGrid_RowDataBound"
                DataKeyNames="FacultyId" CssClass="table table-striped table-responsive" >
                <Columns>
                    <asp:TemplateField HeaderText="Faculty Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpName" Text='<%# Eval("FacultyName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty DOB">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FacultyDob") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FacultyEmail") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Address">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FacultyAddress") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Address" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="dept" Text='<%# Eval("FacultyDepartment") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Address" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="desig" Text='<%# Eval("FacultyDesignation") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Mobile No.">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FacultyMobile") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmpMobile" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="10" Text='<%# Eval("FacultyMobile") %>' runat="server" />
                         </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Department">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DeptName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpDept" CssClass="form-control form-select w-50" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Faculty Designation">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DesignationName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="drpDesignation" CssClass="form-control form-select w-50" runat="server" />
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
</asp:Content>
