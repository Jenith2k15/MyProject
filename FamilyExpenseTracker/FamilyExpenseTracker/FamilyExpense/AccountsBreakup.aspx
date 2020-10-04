<%@ Page Language="C#" Title="Accounts Breakup" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountsBreakup.aspx.cs" Inherits="FamilyExpenseTracker.FamilyExpense.Savings" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            
        </div>
        <div class="col-md-6">
            <div class="card">
                <div class="card-header text-center text-white bg-primary">
                    <h1>Accounts Breakup</h1>
                </div>
                <div class="card-body border border-primary text-center text-primary">
                    <h3>Income</h3>
                    <h2><asp:Label ID="lblIncome" CssClass="text-info" runat="server" ForeColor="Red"/></h2>
                    <hr />
                    <h3>Expenditure</h3>
                    <h2><asp:Label ID="lblExpenditure" CssClass="text-info" runat="server" ForeColor="Red"/></h2>
                    <hr />
                    <h3>Savings</h3>
                    <h2><asp:Label ID="lblSavings" CssClass="text-info" runat="server" ForeColor="Red"/></h2>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            
        </div>
    </div>

</asp:Content>