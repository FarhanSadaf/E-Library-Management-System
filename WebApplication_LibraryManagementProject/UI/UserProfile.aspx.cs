using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMemberInfo();
                LoadIssuedBooks();
            }
        }
        private void LoadIssuedBooks()
        {
            try
            {
                string userId = Session["username"].ToString();
                List<BookIssue> bookIssues = db.BookIssues.Where(m => m.MemberId == userId).ToList();
                List<dynamic> dList = new List<dynamic>();
                foreach (BookIssue book in bookIssues)
                {
                    dList.Add(new { ID = book.BookId, Book = book.Book.Name, Issue = book.IssueDate.ToShortDateString(), Return = book.DueDate.ToShortDateString() });
                }
                BooksGridView.DataSource = dList;
                BooksGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }
        private void LoadMemberInfo()
        {
            try
            {
                string userId = Session["username"].ToString();
                var v = db.Members.Where(m => m.Id == userId).FirstOrDefault();
                if (v != null)
                {
                    AccountStatusLabel.Text = v.AccountStatus;
                    if (v.AccountStatus.Equals("active"))
                    {
                        AccountStatusLabel.CssClass = "badge badge-pill badge-success";
                    }
                    else if (v.AccountStatus.Equals("pending"))
                    {
                        AccountStatusLabel.CssClass = "badge badge-pill badge-warning";
                    }
                    else
                    {
                        AccountStatusLabel.CssClass = "badge badge-pill badge-danger";
                    }
                    FullNameTextBox.Text = v.FullName;
                    DoBTextBox.Text = v.DateOfBirth.ToShortDateString();
                    ContactNumberTextBox.Text = v.ContactNo;
                    EmailIdTextBox.Text = v.Email;
                    CountryDropDownList.SelectedValue = v.Country;
                    CityTextBox.Text = v.City;
                    PincodeTextBox.Text = v.Pincode;
                    FullAddressTextBox.Text = v.FullAddress;
                    UserIdTextBox.Text = v.Id;
                    NewPasswordTextBox.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Invalid Request! Please login again.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = Session["username"].ToString();
                var v = db.Members.Where(m => m.Id == userId).FirstOrDefault();
                if (PasswordTextBox.Text.Trim().Equals(v.Password))
                {
                    v.FullName = FullNameTextBox.Text.Trim();
                    Session["fullname"] = v.FullName;
                    v.DateOfBirth = Convert.ToDateTime(DoBTextBox.Text.Trim());
                    v.ContactNo = ContactNumberTextBox.Text.Trim();
                    v.Email = EmailIdTextBox.Text.Trim();
                    v.Country = CountryDropDownList.SelectedItem.Value;
                    v.City = CityTextBox.Text.Trim();
                    v.Pincode = PincodeTextBox.Text.Trim();
                    v.FullAddress = FullAddressTextBox.Text;
                    string newPass = NewPasswordTextBox.Text.Trim();
                    if (!newPass.Equals(""))
                    {
                        v.Password = newPass;
                    }
                    db.SaveChanges();
                    Response.Write("<script>alert('Informations updated successfully!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        protected void BooksGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DateTime dt = Convert.ToDateTime(e.Row.Cells[2].Text);
                        DateTime today = DateTime.Today;
                        if (today > dt)
                        {
                            e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}