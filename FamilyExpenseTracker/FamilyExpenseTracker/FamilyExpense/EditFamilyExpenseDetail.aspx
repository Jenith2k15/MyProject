<%@ Page Language="C#" Title="Edit Family Expense Detail Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFamilyExpenseDetail.aspx.cs" Inherits="FamilyExpenseTracker.EditFamilyExpenseDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
    <div class="col-md-3 ht">
        <img class="img-fluid rounded" src="../Images/DefaultDisplay1.jpg" alt="Chania">
        <br />
        <br />
        <button type="button" class="btn btn-primary btn-block">Try Premium&raquo;</button>
        <div class="card-body">
            <blockquote class="blockquote text-center">
                <img src="../Images/User.jpg" class="align-self-end mr-3" style="width:60px">
                <p class="mb-0">Fab Product!</p>
                <footer class="blockquote-footer"><cite title="Source Title">Sathish,Google - Android Development Lead</cite></footer>
            </blockquote>
        </div>
    </div>
    <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">Edit Family Expense Detail</div>
                <div class="card-body">
                    <div class="form-group">
                      <label for="name">Name:</label>
                        <asp:HiddenField ID="expenseId" runat="server"/>
                        <asp:HiddenField ID="familyMemberId" runat="server"/>
                        <asp:DropDownList class="form-control" ID="name" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ErrorMessage="Select Name!" ControlToValidate="name" runat="server" Display="Dynamic" ForeColor="Red" InitialValue="--Select Name--" />
                    </div>
                    <div class="form-group">
                      <label for="purpose">Purpose:</label>
                      <asp:TextBox class="form-control" id="purpose" placeholder="Enter Purpose" name="purpose" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Purpose Required!" ControlToValidate="purpose" runat="server" Display="Dynamic" ForeColor="Red" />
                      <asp:RegularExpressionValidator ErrorMessage="Purpose first letter must be in caps.Example: Xyz or Xyz Abc" ControlToValidate="purpose" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="[A-Z]{1}([a-z]+){2}\s?([A-Z]{1}([a-z]+){2})*" />  
                    </div>
                     <div class="form-group">
                      <label for="amount">Amount:</label>
                      <asp:TextBox class="form-control" id="amount" placeholder="Enter Amount" name="amount" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Amount Required!" ControlToValidate="amount" runat="server" Display="Dynamic" ForeColor="Red" />
                     </div>
                    <div class="form-group">
                      <label for="date">Date:&nbsp&nbsp<asp:Label ID="expenseDate" runat="server" ForeColor="Red"/></label>
                      <asp:TextBox class="form-control" type="date" id="date" placeholder="Enter Income" name="date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="Select Date!" ControlToValidate="date" runat="server" Display="Dynamic" ForeColor="Red" />
                    </div>
                    <asp:Button  class="btn btn-primary" ID="submit" Text="Submit" runat="server" OnClick="Submit_Click" /><br />
                </div>
            </div>
        </div>
    <div class="col-md-3 ht">
            <img class="img-fluid rounded" src="../Images/DefaultDisplay2.png" alt="Chania">
           <div class="card-body">
            <blockquote class="blockquote text-center">
                <img src="../Images/User.jpg" class="align-self-end mr-3" style="width:60px">
                <p class="mb-0">Family Expense Tracker,Good Product!</p>
                <footer class="blockquote-footer"><cite title="Source Title">Mark,Google - Head of Operations</cite></footer>
            </blockquote>
            <blockquote class="blockquote text-center">
                <img src="../Images/User.jpg" class="align-self-end mr-3" style="width:60px">
                <p class="mb-0">Smart Product!</p>
                <footer class="blockquote-footer"><cite title="Source Title">Vikram</cite></footer>
            </blockquote>
           </div>
        </div>
   </div>

</asp:Content>
