<%@ Page Language="C#" Title="Family Expense Details" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamilyExpenseDetails.aspx.cs" Inherits="FamilyExpenseTracker.FamilyExpenseDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="row mb-3">
                <div class="col-md-10 mb-3">
                    <asp:TextBox class="form-control" ID="search" placeholder="Search.." runat="server" />
                </div>
                <div class="col-md-2">
                    <%--<asp:Button Text="Search" class="btn btn-outline-primary btn-block" OnClick="SearchExpenseDetailsByName" runat="server" />--%>
                    <asp:LinkButton OnClick="SearchExpenseDetailsByName" class="btn btn-outline-primary btn-block" runat="server"><i class="fas fa-search"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-5 mb-3">
                    <asp:TextBox type="date" class="form-control" ID="startDate" runat="server" />
                </div>
                <div class="col-md-5 mb-3">
                    <asp:TextBox type="date" class="form-control" ID="endDate" runat="server" />
                </div>
                <div class="col-md-2">
                    <asp:LinkButton Id="SearchByDate" OnClick="SearchExpenseDetailsByDate" class="btn btn-outline-primary btn-block" runat="server"><i class="fas fa-filter"></i></asp:LinkButton>
                </div>
            </div>
            <asp:GridView CssClass="table" ID="ExpenseGridView" AutoGenerateColumns="False" runat="server" 
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ExpenseGridView_RowDataBound" ShowFooter="True" OnRowDeleting="ExpenseGridView_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField  ControlStyle-CssClass="text-light btn btn-danger" ShowDeleteButton="true"/>
                    <%--<asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Eid" 
                      DataNavigateUrlFormatString="FamilyExpenseDetails.aspx?eid={0}"  ControlStyle-CssClass="btn btn-outline-danger"/>--%>
                    <asp:BoundField  DataField="ExpenseId" HeaderText="Eid"/>
                    <asp:BoundField Visible="false" DataField="FamilyMemberId" HeaderText="FmId"/>
                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                    <asp:BoundField DataField="Purpose" HeaderText="Purpose"/>
                    <asp:BoundField DataField="Amount" HeaderText="Amount"/>
                    <asp:BoundField DataField="Date"  HeaderText="DateTime"/>
                    <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ExpenseId" 
                        DataNavigateUrlFormatString="EditFamilyExpenseDetail.aspx?expenseId={0}"/>
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
            <p><a href="AddFamilyExpenseDetail.aspx" class="btn btn-primary btn-lg">Add Family Expense Detail &raquo;</a></p>
        </div>
        <div class="col-3">
            <p><a href="../FamilyMember/FamilyMemberDetails.aspx" class="btn btn-primary btn-lg">View Family Member Details &raquo;</a></p>
        </div>
        <div class="col-3">

        </div>
    </div>
    
</asp:Content>
