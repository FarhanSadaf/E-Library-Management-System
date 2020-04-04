<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#body_StartDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "2000:2025",
                dateFormat: 'dd-mm-yy'
            });
            $("#body_EndDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "2000:2025",
                dateFormat: 'dd-mm-yy'
            });
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card" style="margin: 10px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Book Issuing</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img width="100px" src="../Images/books.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_MemberIdTextBox">Member ID</label>
                                    <asp:TextBox class="form-control" placeholder="Member ID" ID="MemberIdTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_BookIdTextBox">Book ID</label>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="Book ID" ID="BookIdTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-dark" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_MemberNameTextBox">Member Name</label>
                                    <asp:TextBox class="form-control" placeholder="Member Name" ID="MemberNameTextBox" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_BookNameTextBox">Book Name</label>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="Book Name" ID="BookNameTextBox" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_StartDateTextBox">Start Date</label>
                                    <asp:TextBox class="form-control" placeholder="Start Date" ID="StartDateTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_EndDateTextBox">End Date</label>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="End Date" ID="EndDateTextBox" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button CssClass="btn btn-block btn-primary" ID="IssueButton" runat="server" Text="Issue" OnClick="IssueButton_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button CssClass="btn btn-block btn-success" ID="ReturnButton" runat="server" Text="Return" OnClick="ReturnButton_Click" />
                            </div>
                            <div class="col text-center">
                                <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7">
                <div class="card" style="margin: 10px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Issued Book List</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="IssuedBookGridView" CssClass="table table-striped table-bordered" runat="server" OnRowDataBound="IssuedBookGridView_RowDataBound" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="MemberId" HeaderText="Member ID" ReadOnly="True" SortExpression="MemberId" />
                                        <asp:BoundField DataField="Member.FullName" HeaderText="Member Name" ReadOnly="True" SortExpression="Member.FullName" />
                                        <asp:BoundField DataField="BookId" HeaderText="Book ID" ReadOnly="True" SortExpression="BookId" />
                                        <asp:BoundField DataField="Book.Name" HeaderText="Book Name" ReadOnly="True" SortExpression="Book.Name" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" ReadOnly="True" SortExpression="IssueDate" />
                                        <asp:BoundField DataField="DueDate" HeaderText="Return Date" ReadOnly="True" SortExpression="DueDate" />
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
