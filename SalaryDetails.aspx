<%@ Page Title="" Language="C#" MasterPageFile="~/FacultyMaster.Master" AutoEventWireup="true" CodeBehind="SalaryDetails.aspx.cs" Inherits="PayrollApplication.SalaryDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="m-5">
        <h3 class="m-5">Basic Salary Structure </h3>
    <asp:GridView ID="salaryGrid" runat="server" 
                AutoGenerateColumns="false" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="Salary is not added as of now"
                DataKeyNames="Id" CssClass="table table-responsive" >
                <Columns>
                    <asp:TemplateField HeaderText="BasicPay">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("BasicPay") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DA") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HRA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("HRA") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("CA") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("SA") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
