<%@ Page Title="" Language="C#" MasterPageFile="~/FacultyMaster.Master" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="PayrollApplication.Payroll" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="container mt-5">
        <asp:GridView ID="payrollGrid" runat="server" 
                AutoGenerateColumns="false" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="No payroll available"
                DataKeyNames="Id" CssClass="table table-responsive" OnRowCommand="payrollGrid_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Month">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Month") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Year") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payroll">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="download" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" Text="Download Payroll" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

    </div>
    
</asp:Content>
