<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="CodingChallenge_Banking.Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="col-lg-12 text-center">
            <h1>Transfer</h1>
        </div>
            <div class="offset-lg-3 col-lg-6">
                <div class="card">
                    <div class="card-header">
                        TRANSFER FROM ACCOUNT
                    </div>
                    <div class="card-body">
                        <div class="offset-lg-2 col-lg-8">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">SEARCH IBAN</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="txtSearchIBAN" runat="server"></asp:TextBox>
                            </div>
                            <div class="text-center add-space">
                                <asp:Button CssClass="btn btn-primary" ID="btnSerchAccount" runat="server" Text="Search" />
                            </div>
                            <div class="text-center add-space">
                                <div id="alert_btnSerchAccount" class="alert alert-danger d-none" role="alert" runat="server"></div>

                            </div>
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
            </div>
            <div class="offset-lg-3 col-lg-6">
                <div class="card add-space">
                    <div class="card-header">
                        TRANSFER TO ACCOUNT
                    </div>
                    <div class="card-body">
                        <div class="offset-lg-2 col-lg-8">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">SEARCH IBAN</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class="text-center add-space">
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Search" />
                            </div>
                            <div class="text-center add-space">
                                <div id="Div1" class="alert alert-danger d-none" role="alert" runat="server"></div>

                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">IBAN</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Firstname</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Middlename</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Lastname</span>
                                </div>
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        <div class="offset-lg-3 col-lg-6">
            <div class="card add-space">
                <div class="card-header">
                    TRANSFER
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="long-word input-group-text">Transfer Amount</span>
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
