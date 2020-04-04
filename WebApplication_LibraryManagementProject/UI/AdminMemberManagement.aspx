<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img width="100px" src="../Images/generaluser.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="body_MemberIdTextBox">Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="ID" ID="MemberIdTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label for="body_FullNameTextBox">Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Full Name" ID="FullNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label for="body_BookIdTextBox">Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="Status" ID="AccountStatusTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success" ID="ActiveButton" runat="server" OnClick="ActiveButton_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning" ID="PendingButton" runat="server" OnClick="PendingButton_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="DeactiveButton" runat="server" OnClick="DeactiveButton_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="body_DoBTextBox">Date of Birth</label>
                                <asp:TextBox class="form-control" placeholder="dd-mm-yyyy" ID="DoBTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="body_ContactNoTextBox">Contact No.</label>
                                <asp:TextBox class="form-control" placeholder="01xxxxxxxxxx" ID="ContactNoTextBox" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label for="body_EmailIDTextBox">Email ID</label>
                                <asp:TextBox class="form-control" placeholder="example@mail.com" ID="EmailIDTextBox" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_CountryTextBox">Country</label>
                                    <asp:TextBox class="form-control" placeholder="Country" ID="CountryTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_CityTextBox">City</label>
                                    <asp:TextBox class="form-control" placeholder="City" ID="CityTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_PincodeTextBox">Pincode</label>
                                    <asp:TextBox class="form-control" placeholder="Pincode" ID="PincodeTextBox" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="body_FullAddressTextBox">Full Address</label>
                                    <asp:TextBox class="form-control" placeholder="Full Address" ID="FullAddressTextBox" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button CssClass="btn btn-block btn-danger" ID="DeleteUserButton" runat="server" Text="Delete User Permanently" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member List</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="MemberSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ELibraryDbContext %>" SelectCommand="SELECT [Id], [FullName], [DateOfBirth], [ContactNo], [Email], [Country], [City], [AccountStatus] FROM [Members]"></asp:SqlDataSource>
                                <asp:GridView ID="MemberGridView" CssClass="table table-striped table-bordered table-responsive" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="MemberSqlDataSource" OnRowDataBound="MemberGridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="FullName" HeaderText="Full name" SortExpression="FullName" />
                                        <asp:BoundField DataField="AccountStatus" HeaderText="Account status" SortExpression="AccountStatus" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact no." SortExpression="ContactNo" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date of birth" SortExpression="DateOfBirth" />
                                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
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
