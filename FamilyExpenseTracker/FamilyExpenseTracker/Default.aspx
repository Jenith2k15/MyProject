<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FamilyExpenseTracker.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div style="height:300px" class="jumbotron">
        <h1 class="text-primary">Family Expense Tracker</h1>
        <p class="lead">Family Expense Tracker is a free web application for maintaining family expenses.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-3 ht">
            <img class="img-fluid rounded" src="Images/DefaultDisplay1.jpg" alt="Chania">
            <br />
            <br />
            <button type="button" class="btn btn-primary btn-block">Try Premium &raquo;</button>
        </div>
        <div class="col-md-6 ht">
            <div class="card">
                <div class="card-header bg-primary text-white">Login</div>
                <div class="card-body">
                    <div class="form-group">
                      <label for="email">Email:</label>
                      <asp:TextBox class="form-control" id="email" placeholder="Enter email" name="email" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Email Required!" ControlToValidate="email" runat="server" ForeColor="Red" Display="Dynamic" />
                      <asp:RegularExpressionValidator ErrorMessage="Invalid Format!" ControlToValidate="email" runat="server" ForeColor="Red" ValidationExpression="([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})" Display="Dynamic" />
                    </div>
                    <div class="form-group">
                      <label for="pwd">Password:</label>
                      <asp:TextBox class="form-control" id="pwd" placeholder="Enter password" name="pwd" type="password" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Password Required!" ControlToValidate="pwd" runat="server" ForeColor="Red" Display="Dynamic" />
                    </div>
                    <div class="form-group form-check">
                      <label class="form-check-label">
                        <input class="form-check-input" id="remember" type="checkbox" name="remember" runat="server"> Remember me
                      </label>
                    </div>
                    <asp:Button class="btn btn-primary" ID="Submit"  Text="submit" runat="server" OnClick="Submit_Click"/><br />
                    <asp:Label ID="errorMessage" runat="server" ForeColor="Red"/>
                </div>
            </div>
        </div>
        <div class="col-md-3 ht">
            <img class="img-fluid rounded" src="Images/DefaultDisplay2.png" alt="Chania">
           <div class="card-body">
            <blockquote class="blockquote text-center">
                <img src="Images/User.jpg" class="align-self-end mr-3" style="width:60px">
                <p class="mb-0">Family Expense Tracker,Good Product!</p>
                <footer class="blockquote-footer"><cite title="Source Title">Mark,Google - Head of Operations</cite></footer>
            </blockquote>
           </div>
        </div>
    </div>

</asp:Content>
