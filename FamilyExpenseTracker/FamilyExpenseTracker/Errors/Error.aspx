<%@ Page Language="C#" Title="Error Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="FamilyExpenseTracker.Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div style="font-family: Arial">
    <table>
        <tr>
            <td style="color:Red">
                <h2>Application Error</h2>
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    An unkown error has occured. We are aware of it and the IT team is currently working
                    on this issue. Sorry for the inconvinience caused.</h3>
            </td>
        </tr>
        <tr>
            <td>
                <h5>
                    If you need further assistance, please contact our helpdesk at helpdesk@companyhelpdesk.com
                </h5>
            </td>
        </tr>
    </table>
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

