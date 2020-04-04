using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewDataBind();
        }
        private void GridViewDataBind()
        {
            try
            {
                IssuedBookGridView.DataSource = db.BookIssues.ToList();
                IssuedBookGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }
        private bool CheckIfBookExists(string id)
        {
            var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfMemberExists(string id)
        {
            var v = db.Members.Where(b => b.Id == id).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfAccountActive(string id)
        {
            var v = db.Members.Where(b => b.Id == id && b.AccountStatus.Equals("active")).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfIssueEntryExists(string mId, string bId)
        {
            var v = db.BookIssues.Where(b => b.MemberId == mId && b.BookId == bId).FirstOrDefault();
            return v != null;
        }
        private void Clear()
        {
            MemberIdTextBox.Text = "";
            BookIdTextBox.Text = "";
            MemberNameTextBox.Text = "";
            BookNameTextBox.Text = "";
            StartDateTextBox.Text = "";
            EndDateTextBox.Text = "";
            ErrorLabel.Text = "";
        }
        protected void GoButton_Click(object sender, EventArgs e)
        {
            try
            {
                var member = db.Members.Where(m => m.Id == MemberIdTextBox.Text.Trim()).FirstOrDefault();
                var book = db.Books.Where(b => b.Id == BookIdTextBox.Text.Trim()).FirstOrDefault();
                if(member != null && book != null)
                {
                    MemberNameTextBox.Text = member.FullName;
                    BookNameTextBox.Text = book.Name;
                    ErrorLabel.Text = "";
                }
                else
                {
                    ErrorLabel.Text = "Member and Book with given id doesn't exist!";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex+"')</script>");
            }
        }

        protected void IssueButton_Click(object sender, EventArgs e)
        {
            try
            {
                BookIssue bookIssue = new BookIssue();
                bookIssue.MemberId = MemberIdTextBox.Text.Trim();
                bookIssue.BookId = BookIdTextBox.Text.Trim();
                bookIssue.IssueDate = Convert.ToDateTime(StartDateTextBox.Text.Trim());
                bookIssue.DueDate = Convert.ToDateTime(EndDateTextBox.Text.Trim());

                if (CheckIfBookExists(bookIssue.BookId) && CheckIfMemberExists(bookIssue.MemberId))
                {
                    if(CheckIfIssueEntryExists(bookIssue.MemberId, bookIssue.BookId))
                    {
                        ErrorLabel.Text = "Member already have this book";
                    }
                    else
                    {
                        if (CheckIfAccountActive(bookIssue.MemberId))
                        {
                            var book = db.Books.Where(b => b.Id == bookIssue.BookId).FirstOrDefault();
                            if (book.CurrentStock > 0)
                            {
                                book.CurrentStock--;
                                db.BookIssues.Add(bookIssue);
                                db.SaveChanges();
                                GridViewDataBind();
                                Clear(); 
                            }
                            else
                            {
                                ErrorLabel.Text = "Sorry! No more book in stock.";
                            }
                        }
                        else
                        {
                            ErrorLabel.Text = "Account is not active!";
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book or Mebmber doesn't exist!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            try
            {
                string mId = MemberIdTextBox.Text.Trim();
                string bId = BookIdTextBox.Text.Trim();

                if (CheckIfBookExists(bId) && CheckIfMemberExists(mId))
                {
                    var v = db.BookIssues.Where(b => b.MemberId == mId && b.BookId == bId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Book.CurrentStock++;
                        db.BookIssues.Remove(v);
                        db.SaveChanges();
                        GridViewDataBind();
                        Clear();
                    }
                    else
                    {
                        ErrorLabel.Text = "Entry doesn't exist!";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book or Mebmber doesn't exist!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        //For coloring defaulters list on gridview row
        protected void IssuedBookGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
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