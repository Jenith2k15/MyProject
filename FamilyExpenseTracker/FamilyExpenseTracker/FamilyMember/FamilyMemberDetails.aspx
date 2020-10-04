<%@ Page Language="C#" Title="Family Member Details" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamilyMemberDetails.aspx.cs" Inherits="FamilyExpenseTracker.FamilyMember.FamilyMembers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <asp:GridView CssClass="table" ID="GV" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GV_RowDataBound" ShowFooter="True" OnRowDeleting="GV_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField  ControlStyle-CssClass="text-light btn btn-danger" ShowDeleteButton="true"/>
                    <%--<asp:HyperLinkField Text="Delete" DataNavigateUrlFields="FmId" 
                      DataNavigateUrlFormatString="FamilyMemberDetails.aspx?fmid={0}"  ControlStyle-CssClass="btn btn-outline-danger"/>--%>
                    <asp:BoundField HeaderText="Id"  DataField="FamilyMemberId"/>
                    <asp:BoundField HeaderText="Name" DataField="Name"/>
                    <asp:BoundField HeaderText="Cell" DataField="Cell"/>
                    <asp:BoundField HeaderText="Work" DataField="Work"/>
                    <asp:BoundField HeaderText="Income" DataField="Income"/>
                    <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="FamilyMemberId" 
                     DataNavigateUrlFormatString="EditFamilyMemberDetail.aspx?FamilyMemberId={0}" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <div id="message" class="alert alert-danger collapse" style="text-align:center" runat="server">
                <div id="errorMessage" ForeColor="Red" runat="server"></div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-3">

        </div>
        <div class="col-3">
            <p><a href="AddFamilyMemberDetail.aspx" class="btn btn-primary btn-lg">Add Family Member Detail &raquo;</a></p>
        </div>
        <div class="col-3">
            <p><a href="../FamilyExpense/FamilyExpenseDetails.aspx" class="btn btn-primary btn-lg">View Family Expense Details &raquo;</a></p>
        </div>
        <div class="col-3">

        </div>
    </div>

</asp:Content>
