<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LeaveApproval.aspx.cs" Inherits="PayrollApplication.LeaveApproval" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div class="m-5">
    <asp:GridView ID="leaveApprovalGrid" runat="server" 
                
                AutoGenerateColumns="false" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Leave to be approved/rejected"
                DataKeyNames="Id" CssClass="table table-striped table-responsive" 
                OnRowCommand="leaveApprovalGrid_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Faculty Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FacultyName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                    <asp:TemplateField HeaderText="No_of_Days">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("No_of_days") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason For Leave">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Reason") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="Approve" CommandArgument='<%#Eval("Id")%>' ID="approve" CssClass="btn btn-primary fa" Text="Accept"/>
                            <asp:Button runat="server" CommandName="Reject" CommandArgument='<%#Eval("Id")%>' ID="reject" CssClass="btn btn-danger fa" Text="Reject"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
