<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Banking.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-horizontal">
        <h4>Create a new account</h4>
        
         <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AccountNumber" CssClass="col-md-2 control-label">Account Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AccountNumber" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountNumber"
                    CssClass="text-danger" ErrorMessage="The Account Number field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The Password field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AccountName" CssClass="col-md-2 control-label">Account Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AccountName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountName"
                    CssClass="text-danger" ErrorMessage="The Account Name field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Balance" CssClass="col-md-2 control-label">Balance</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Balance" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Balance"
                    CssClass="text-danger" ErrorMessage="The Balance field is required." />
            </div>
        </div>
    
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

</asp:Content>
