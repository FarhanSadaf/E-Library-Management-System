<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminPublisherManagement.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card" style="margin: 10px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Publisher Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img width="100px" src="../Images/publisher.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_PublisherIdTextBox">Publisher ID</label>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="ID" ID="PublisherIdTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-dark" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="body_PublisherNameTextBox">Publisher Name</label>
                                    <asp:TextBox class="form-control" placeholder="Publisher Name" ID="PublisherNameTextBox" runat="server"></asp:TextBox>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-block btn-success" ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-block btn-primary" ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-block btn-danger" ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-6">
                <div class="card" style="margin: 10px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Publisher List</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="PublisherSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ELibraryDbContext %>" SelectCommand="SELECT * FROM [Publishers]"></asp:SqlDataSource>
                                <asp:GridView ID="PublisherGridView" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="PublisherSqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
