<%@ Page Title="" Language="C#" MasterPageFile="~/FacultyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveSummary.aspx.cs" Inherits="PayrollApplication.LeaveSummary" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <div class="m-5">
    <asp:GridView ID="empGrid" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="empGrid_PageIndexChanging"
                AutoGenerateColumns="false" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Leave Applied Yet"
                DataKeyNames="LeaveId" CssClass="table table-striped table-responsive" >
                <Columns>
                    <asp:TemplateField HeaderText="Leave Type">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LeaveType") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From Date">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FromDate") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Date">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ToDate") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason For Leave">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Reason") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No of Days">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("No_of_days") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Center" CssClass="m-2 " Font-Bold="True" />
            </asp:GridView>
        </div>

</asp:Content>
