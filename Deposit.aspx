<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="CodingChallenge_Banking.Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="col-lg-12 text-center">
            <h1>Deposit</h1>
            </div>
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
                            <asp:Button CssClass="btn btn-primary" ID="btnSearchAccount" runat="server" Text="Search" OnClick="btnSearchAccount_Click" />
                        </div>
                        <div class="text-center add-space">
                            <div id="alert_btnSearchAccount" class="alert alert-danger d-none" role="alert" runat="server"></div>

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
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Balance</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtBalance" runat="server" Enabled="false"></asp:TextBox>
                            <div class="short-word input-group-append">
                                <span class="input-group-text">BAHT</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card add-space">
                <div class="card-header">
                    DEPOSIT
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="long-word input-group-text">Deposit Amount</span>
                            </div>
                            <asp:TextBox CssClass="form-control text-right" ID="txtDepositNumber" runat="server"></asp:TextBox>
                            <div class="input-group-prepend">
                                <span class="long-word input-group-text decimal text-center">.</span>
                            </div>
                            <asp:TextBox CssClass="decimal-text text-right" ID="txtDepositDecimal" runat="server"></asp:TextBox>
                            <div class="short-word input-group-append">
                                <span class="input-group-text">BAHT</span>
                            </div>
                        </div>
                        <div class="text-center add-space">
                            <asp:Button CssClass="btn btn-primary" ID="btnCreateTransaction" runat="server" Text="Complete" OnClick="btnCreateTransaction_Click" />
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
