<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <section>
        <div class="row homebanner">
        <div class="col-md-5 text-right">
            <img src="../Images/home.png" style="height: 400px" />
        </div>
        <div class="col-md-7">
            <div class="row text-right" style="height: 200px">
                <div class="col-md-5"></div>
                <div class="col-md-5">
                    <p class="bannertext">
                        Borrow
                        <br />
                        Read
                        <br />
                        Repeat
                    </p>
                    <h6 class="bannertext2">Your online library...</h6>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </div>
    </section>
    <section>
        <div class="container mt-5">
            <div class="row">
                <div class="col-12 text-center">
                    <h2>Our Features</h2>
                    <p>Our 2 Primary Features</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/digital-inventory.png" />
                    <h4>Digital Book Inventory</h4>
                    <p>The use of a digital inventory management system can help shippers gain control and visibility into existing inventory and plan for future inventory needs. ... Gain real-time visibility into inventory, especially perishable inventory, automated technologies, such as RFID and the Internet of Things.</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/search-online.png" />
                    <h4>Search Books</h4>
                    <p>Find any book at the best price. Compare Book Prices Online. Author. Title. or ISBN. Language. Any Language, Dutch, English, French, German, Italian, Spanish.</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/defaulters-list.png" />
                    <h4>Defaulter List</h4>
                    <p> Big scammers top defaulters' list. Finance minister unveils the list in JS; 8,238 owe Tk 96,986.38 crore to public, private banks.</p>
                </div>
            </div>
        </div>
    </section>
    <img class="img-fluid" src="../Images/in-homepage-banner.jpg" style="margin-right: auto"/>
    <section>
        <div class="container mt-5">
            <div class="row">
                <div class="col-12 text-center">
                    <h2>Our Process</h2>
                    <p>We have simple 3 step process</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/sign-up.png" />
                    <h4>Sign Up</h4>
                    <p>A single username and password gets you into everything Google (Gmail, Chrome, YouTube, Google Maps). Set up your profile and preferences just the way ...</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/search-online.png" />
                    <h4>Search Books</h4>
                    <p>Find any book at the best price. Compare Book Prices Online. Author. Title. or ISBN. Language. Any Language, Dutch, English, French, German, Italian, Spanish.</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="../Images/library.png" />
                    <h4>Visit Us</h4>
                    <p>The purpose of your trip, Your intent to depart the United States after your trip, and/or. Your ability to pay all costs of the trip.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
