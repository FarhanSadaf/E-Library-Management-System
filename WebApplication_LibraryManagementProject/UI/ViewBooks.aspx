<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm10" %>

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
            <div class="col">
                <div class="row">
                    <div class="col text-center">
                        <h3>Book List</h3>
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
</asp:Content>
