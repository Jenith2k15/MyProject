<%@ Page Language="C#" Title="404 Error Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404Error.aspx.cs" Inherits="FamilyExpenseTracker._404Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12 text-center">
            <div style="font-family: Arial;text-align:center">
                <h2 style="color: Red">Requested page not found in Server.</h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <img class="img-fluid rounded" src="../Images/Error.png" alt="Chania">
        </div>
        <div class="col-md-3">
        </div>
    </div>

</asp:Content>
