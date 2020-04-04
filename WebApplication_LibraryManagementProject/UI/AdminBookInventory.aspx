<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.AdminBookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#body_PublishDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1950:2020",
                dateFormat: 'dd-mm-yy'
            });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
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
                                <h3>Book Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img id="imgview" width="100px" src="../Images/Books/books1.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="BookCoverFileUpload" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="body_BookIdTextBox">Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="ID" ID="BookIdTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label for="body_BookNameTextBox">Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Book Name" ID="BookNameTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_LanguageDropDownList">Language</label>
                                    <asp:DropDownList CssClass="form-control" ID="LanguageDropDownList" runat="server">
                                        <asp:ListItem Text="--SELECT--" Selected="True" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Bangla" Value="Bangla" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                        <asp:ListItem Text="German" Value="German" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="body_PublisherNameDropDownList">Publisher Name</label>
                                    <asp:DropDownList CssClass="form-control" ID="PublisherNameDropDownList" runat="server">
                                        <asp:ListItem Text="--SELECT--" Selected="True" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_AutherNameDropDownList">Auther Name</label>
                                    <asp:DropDownList CssClass="form-control" ID="AutherNameDropDownList" runat="server">
                                        <asp:ListItem Text="--SELECT--" Selected="True" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="body_PublishDateTextBox">Publish Date</label>
                                    <asp:TextBox class="form-control" placeholder="dd-mm-yyyy" ID="PublishDateTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_GenreListBox">Genre</label>
                                    <asp:ListBox ID="GenreListBox" CssClass="form-control" runat="server" Rows="5" SelectionMode="Multiple">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                        <asp:ListItem Text="Self Help" Value="Self Help" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_EditionTextBox">Edition</label>
                                    <asp:TextBox class="form-control" placeholder="Edition" ID="EditionTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_BookCostTextBox">Book Cost (per unit)</label>
                                    <asp:TextBox class="form-control" placeholder="Book Cost" ID="BookCostTextBox" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_PagesTextBox">Pages</label>
                                    <asp:TextBox class="form-control" placeholder="Pages" ID="PagesTextBox" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_ActualStockTextBox">Actual Stock</label>
                                    <asp:TextBox class="form-control" placeholder="Actual Stock" ID="ActualStockTextBox" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_CurrentStockTextBox">Current Stock</label>
                                    <asp:TextBox class="form-control" placeholder="Current Stock" ID="CurrentStockTextBox" ReadOnly="true" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_IssuedBooksTextBox">Issued Books</label>
                                    <asp:TextBox class="form-control" placeholder="Issued Books" ID="IssuedBooksTextBox" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="body_BookDescriptionTextBox">Book Description</label>
                                    <asp:TextBox class="form-control" placeholder="Book Description" ID="BookDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-success" ID="AddBookButton" runat="server" Text="Add" OnClick="AddBookButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-primary" ID="UpdateBookButton" runat="server" Text="Update" OnClick="UpdateBookButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-danger" ID="DeleteBookButton" runat="server" Text="Delete" OnClick="DeleteBookButton_Click" />
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
                                <h3>Book Inventory List</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="BooksGridView" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Bold="True" Font-Size="Larger"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span>Author - </span>
                                                                    <asp:Label ID="AuthorGridLabel" runat="server" Font-Bold="True" Text='<%# Eval("Author.Name") %>'></asp:Label>
                                                                    &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                                    <asp:Label ID="Label" runat="server" Font-Bold="True" Text='<%# Eval("Genre") %>'></asp:Label>
                                                                    &nbsp;| 
                                                                   <span>Language -<span>&nbsp;</span>
                                                                       <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Language") %>'></asp:Label>
                                                                   </span>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher -
                                                                   <asp:Label ID="PublisherGridLabel" runat="server" Font-Bold="True" Text='<%# Eval("Publisher.Name") %>'></asp:Label>
                                                                    &nbsp;| Publish Year -
                                                                   <asp:Label ID="PublishDateGridLabel" runat="server" Font-Bold="True" Text='<%# Eval("PublishDate.Date.Year") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("NoOfPages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("Edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Cost -
                                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("BookCost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("ActualStock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("CurrentStock") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("BookDescription") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("BookImgLink") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

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
