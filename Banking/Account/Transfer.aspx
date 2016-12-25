<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="Banking.Account.Transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Transfer</h4>
        
         <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">From Account Number</asp:Label>
            <div class="col-md-10">
                 <asp:Label runat="server" ID="AccountNumber" CssClass="col-md-2 control-label"></asp:Label>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Current Balance</asp:Label>
            <div class="col-md-10">
                 <asp:Label runat="server" ID="CurrentBalance" CssClass="col-md-2 control-label"></asp:Label>
            </div>
        </div>
      
        
     <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DestinationAccount" CssClass="col-md-2 control-label">To Account Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="DestinationAccount" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DestinationAccount"
                    CssClass="text-danger" ErrorMessage="The Destination Account field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Amount" CssClass="col-md-2 control-label">Amount</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Amount" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Amount"
                    CssClass="text-danger" ErrorMessage="The Amount field is required." />
            </div>
        </div>
    
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Transfer_Click" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
