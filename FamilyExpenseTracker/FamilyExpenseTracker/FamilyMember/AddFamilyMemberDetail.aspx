<%@ Page Language="C#" Title="Add Family Member Detail Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFamilyMemberDetail.aspx.cs" Inherits="FamilyExpenseTracker.FamilyMember.AddFamilyMember" %>

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
                <div class="card-header bg-primary text-white">Add Family Member Detail</div>
                <div class="card-body">
                    <div class="form-group">
                      <label for="name">Name:</label>
                      <asp:TextBox class="form-control" id="name" placeholder="Enter Name" name="name" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Name Required!" ControlToValidate="name" runat="server" Display="Dynamic" ForeColor="Red" />
                      <asp:RegularExpressionValidator ErrorMessage="Name first letter must be in caps.Example: Xyz or Xyz Abc" ControlToValidate="name" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="[A-Z]{1}([a-z]+){2}\s?([A-Z]{1}([a-z]+){2})*" />
                    </div>
                    <div class="form-group">
                      <label for="cell">Cell:</label>
                      <asp:TextBox class="form-control" id="cell" placeholder="Enter CellNo" name="cell" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="CellNo Required!" ControlToValidate="cell" runat="server" Display="Dynamic" ForeColor="Red" />
                        <asp:RegularExpressionValidator ErrorMessage="Enter valid 10 digit no" ControlToValidate="cell" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="\d{10}" />
                    </div>
                     <div class="form-group">
                      <label for="work">Work:</label>
                      <asp:TextBox class="form-control" id="work" placeholder="Enter Work" name="work" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Work Required!.If you are not working specify NIL!" ControlToValidate="work" runat="server" Display="Dynamic" ForeColor="Red" />
                         <asp:RegularExpressionValidator ErrorMessage="Work first letter must be in caps.Example: Software Developer" ControlToValidate="work" runat="server" Display="Dynamic" ForeColor="Red" ValidationExpression="[A-Z]{1}([a-z]+){2}\s?([A-Z]{1}([a-z]+){2})*" />
                     </div>
                    <div class="form-group">
                      <label for="income">Income:</label>
                      <asp:TextBox class="form-control" id="income" placeholder="Enter Income" name="income" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ErrorMessage="Income Required!.If you are not getting income specify NIL!" ControlToValidate="income" runat="server" Display="Dynamic" ForeColor="Red" />
                    </div>
                    <asp:Button  class="btn btn-primary" ID="submit" Text="Submit" runat="server" OnClick="Submit_Click" /><br />
                    <asp:Label ID="errorMessage" runat="server" ForeColor="Red"/>
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
