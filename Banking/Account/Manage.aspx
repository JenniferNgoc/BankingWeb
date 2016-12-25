<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Banking.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4>User Transaction</h4>


    </div>

    <asp:GridView ID="gvTransaction" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionNo" HeaderText="Transaction No." />

            <asp:TemplateField HeaderText="Transaction Type">
                <ItemTemplate>
                    <asp:Label ID="StartBalance" runat="server" Text='<%# (Convert.ToInt32(Eval("TransactionType"))==1)?"Deposit":"Withdraw"  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Start Balance">
                <ItemTemplate>
                    <asp:Label ID="Amount" runat="server" Text='<%# ((Convert.ToInt32(Eval("TransactionType"))==1)?"+ ":"- " ) +Convert.ToDecimal(Eval("Amount")).ToString("C")   %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Start Balance">
                <ItemTemplate>
                    <asp:Label ID="StartBalance" runat="server" Text='<%# Convert.ToDecimal(Eval("StartBalance")).ToString("C")   %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="End Balance">
                <ItemTemplate>
                    <asp:Label ID="EndBalance" runat="server" Text='<%# Convert.ToDecimal(Eval("EndBalance")).ToString("C")   %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
