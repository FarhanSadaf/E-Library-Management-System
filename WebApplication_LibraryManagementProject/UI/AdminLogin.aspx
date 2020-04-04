<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card" style="margin: 30px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img width="150px" src="../Images/adminuser.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Admin Login</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Admin ID" ID="AdminIdTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Password" ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-block btn-success btn-lg" ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <a href="Homepage.aspx"><< Back to Home</a><br /><br />
            </div>
        </div>
    </div>
</asp:Content>
