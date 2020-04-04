<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm3" %>

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
                                <img width="150px" src="../Images/generaluser.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member Login</h3>
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
                                    <asp:TextBox class="form-control" placeholder="Member ID" ID="MemberIdTextBox" runat="server"></asp:TextBox>
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
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <a style="text-decoration: none" href="UserSignUp.aspx"><input class="btn btn-block btn-info btn-lg" id="SignUpButton" type="button" value="Sign Up" /></a>
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
