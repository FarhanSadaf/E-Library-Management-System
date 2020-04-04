using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = AdminIdTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            var v = db.AdminLogin.Where(m => m.Username == username && m.Password == password).FirstOrDefault();
            if (v != null)
            {
                //Allow access
                Session["username"] = v.Username;
                Session["fullname"] = v.FullName;
                Session["status"] = "";
                Session["role"] = "admin";
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                //Deny Access
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

    }
}