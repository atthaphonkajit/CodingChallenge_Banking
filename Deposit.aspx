<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="CodingChallenge_Banking.Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">

        <div class="offset-lg-3 col-lg-6">
            <div class="card">
                <div class="card-header">
                    Search Account
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">IBAN</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtSearchIBAN" runat="server"></asp:TextBox>
                        </div>
                        <div class="text-center add-space">
                            <asp:Button CssClass="btn btn-primary" ID="btnSerchAccount" runat="server" Text="Search" />
                        </div>
                        <div class="text-center add-space">
                            <div id="alert_btnSerchAccount" class="alert alert-danger d-none" role="alert" runat="server"></div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="card add-space">
                <div class="card-header">
                    Account Information
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">IBAN</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtIBAN" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Firstname</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Middlename</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtMiddleName" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Lastname</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtLastname" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card add-space">
                <div class="card-header">
                    Transaction
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text long-word">Transaction Type</span>
                            </div>
                            <asp:RadioButtonList ID="rbTransactionList" runat="server" RepeatDirection="Horizontal" CssClass="form-control">
                                <asp:ListItem Selected="True" Text="DEPOSIT" Value="deposit" runat="server" id="rdDeposit"></asp:ListItem>
                                <asp:ListItem Text="WITHDRAW" Value="withdraw" runat="server" id="rdWithdraw"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="long-word input-group-text">Transaction Amount</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtTransactionAmount" runat="server"></asp:TextBox>
                            <div class="short-word input-group-append">
                                <span class="input-group-text">BAHT</span>
                            </div>
                        </div>
                        <div class="text-center add-space">
                            <asp:Button CssClass="btn btn-primary" ID="btnCreateTransaction" runat="server" Text="Complete" />
                        </div>
                        <div class="text-center add-space">
                            <div id="alert_btnCreateTransaction" class="alert alert-danger d-none" role="alert" runat="server"></div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
