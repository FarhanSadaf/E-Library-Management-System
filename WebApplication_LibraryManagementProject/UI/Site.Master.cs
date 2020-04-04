using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                LogoutNavLinkButton_Click(sender, e);
            }
            try
            {
                if (Session["role"].Equals(""))
                {
                    ViewBooksNavLinkButton.Visible = true;
                    UserLoginNavLinkButton.Visible = true;
                    SignUpNavLinkButton.Visible = true;
                    LogoutNavLinkButton.Visible = false;
                    HelloUserNavLinkButton.Visible = false;
                    AdminLoginFooterLinkButton.Visible = true;
                    AuthorManagementFooterLinkButton.Visible = false;
                    PublisherManagementFooterLinkButton.Visible = false;
                    BookInventoryFooterLinkButton.Visible = false;
                    BookIssuingFooterLinkButton.Visible = false;
                    MemberManagementFooterLinkButton.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    ViewBooksNavLinkButton.Visible = true;
                    UserLoginNavLinkButton.Visible = false;
                    SignUpNavLinkButton.Visible = false;
                    LogoutNavLinkButton.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, " + Session["fullname"];
                    AdminLoginFooterLinkButton.Visible = true;
                    AuthorManagementFooterLinkButton.Visible = false;
                    PublisherManagementFooterLinkButton.Visible = false;
                    BookInventoryFooterLinkButton.Visible = false;
                    BookIssuingFooterLinkButton.Visible = false;
                    MemberManagementFooterLinkButton.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    ViewBooksNavLinkButton.Visible = true;
                    UserLoginNavLinkButton.Visible = false;
                    SignUpNavLinkButton.Visible = false;
                    LogoutNavLinkButton.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, Admin";
                    AdminLoginFooterLinkButton.Visible = false;
                    AuthorManagementFooterLinkButton.Visible = true;
                    PublisherManagementFooterLinkButton.Visible = true;
                    BookInventoryFooterLinkButton.Visible = true;
                    BookIssuingFooterLinkButton.Visible = true;
                    MemberManagementFooterLinkButton.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void AdminLoginFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void AuthorManagementFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorManagement.aspx");
        }

        protected void PublisherManagementFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisherManagement.aspx");
        }

        protected void BookInventoryFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void BookIssuingFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void MemberManagementFooterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void UserLoginNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void SignUpNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LogoutNavLinkButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Session["role"] = "";
            Response.Redirect("HomePage.aspx");
        }

        protected void HelloUserNavLinkButton_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("user"))
            {
                Response.Redirect("UserProfile.aspx");
            }
        }

        protected void ViewBooksNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }
    }
}