<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="CodingChallenge_Banking.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="col-lg-12 text-center">
            <h1>Create Account</h1>
            </div>
        <div class="offset-lg-3 col-lg-6">
            <div class="card">
                <div class="card-header">
                    Create new account
                </div>
                <div class="card-body">
                    <div class="offset-lg-2 col-lg-8">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">IBAN</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtIBAN" runat="server"></asp:TextBox>
                        </div>
                        <div id="alert_txtIBAN" class="alert alert-danger d-none" role="alert" runat="server">
                                
                            </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Firstname</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server"></asp:TextBox>
                        </div>
                        <div id="alert_txtFirstName" class="alert alert-danger d-none" role="alert" runat="server">
                                
                            </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Middlename</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtMiddleName" runat="server"></asp:TextBox>
                        </div>
                        <div id="alert_txtMiddleName" class="alert alert-danger d-none" role="alert" runat="server">
                                
                            </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Lastname</span>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtLastname" runat="server"></asp:TextBox>
                        </div>
                        <div id="alert_txtLastname" class="alert alert-danger d-none" role="alert" runat="server">
                                
                            </div>
                        <div class="text-center add-space">
                        <asp:Button CssClass="btn btn-primary" ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" /></div>
                        <div class="text-center add-space">
                        <div id="alert_btnCreateAccount" class="alert alert-danger d-none" role="alert" runat="server"></div>
                                
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
