using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string id = MemberIdTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            var v = db.Members.Where(m => m.Id == id && m.Password == password).FirstOrDefault();
            if(v != null)
            {
                //Allow access
                Session["username"] = v.Id;
                Session["fullname"] = v.FullName;
                Session["status"] = v.AccountStatus;
                Session["role"] = "user";
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