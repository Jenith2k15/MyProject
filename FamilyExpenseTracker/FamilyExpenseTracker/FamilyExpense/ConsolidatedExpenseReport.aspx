<%@ Page Language="C#" Title="Consolidated Report" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsolidatedExpenseReport.aspx.cs" Inherits="FamilyExpenseTracker.FamilyExpense.ConsolidatedExpenseReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mb-3">
        <div class="col-md-5 mb-3">
            <asp:TextBox type="date" class="form-control" ID="startDate" runat="server" />
        </div>
        <div class="col-md-5 mb-3">
            <asp:TextBox type="date" class="form-control" ID="endDate" runat="server" />
        </div>
        <div class="col-md-2">
            <asp:LinkButton ID="SearchByDate" OnClick="FilterExpenseSpentByIndidual" class="btn btn-outline-primary btn-block" runat="server"><i class="fas fa-filter"></i></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card-deck">
                <div class="card">
                    <div class="card-header bg-primary text-center text-white"><h5>Today</h5></div>
                    <div id="divToday" class="card-body border border-primary text-center" runat="server">
                    </div>
                    <div id="divTodayTotal" class="card-footer bg-primary text-center text-white lead" runat="server"></div>
                </div>
                <div class="card">
                    <div class="card-header bg-info text-center text-white"><h5>Yesterday</h5></div>
                    <div id="divYesterday" class="card-body border border-info text-center" runat="server">
                    </div>
                    <div id="divYesterdayTotal" class="card-footer bg-info text-center text-white lead" runat="server"><h5>Total</h5></div>
                </div>
                <div class="card">
                    <div class="card-header bg-success text-center text-white"><h5>This Month</h5></div>
                    <div id="divCurrentMonth" class="card-body border border-success text-center" runat="server">
                    </div>
                    <div id="divCurrentMonthTotal" class="card-footer bg-success text-center text-white lead" runat="server"><h5>Total</h5></div>
                </div>
                <div class="card ">
                    <div id="divDateRangeTxt" class="card-header bg-warning text-center text-white lead" runat="server">Search by date range..</div>
                    <div id="divDateRange" class="card-body border border-warning text-center" runat="server">
                        <div id="message" class="alert alert-danger collapse" style="text-align: center" runat="server">
                            <div id="errorMessage" forecolor="Red" runat="server"></div>
                        </div>
                    </div>
                    <div id="divDateRangeTotal" class="card-footer bg-warning text-center text-white lead" runat="server">
                        <h5>Total</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

