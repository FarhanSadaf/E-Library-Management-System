using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Id = AuthorIdTextBox.Text.Trim();
            author.Name = AuthorNameTextBox.Text.Trim();

            if (IsModelValid(author))
            {
                var v = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();
                if (v != null)
                {
                    ErrorLabel.Text = "Author Already Exists";
                }
                else
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                    //other
                    Clear();
                    AuthorsGridView.DataBind();
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Id = AuthorIdTextBox.Text.Trim();
            author.Name = AuthorNameTextBox.Text.Trim();

            if (IsModelValid(author))
            {
                var v = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();
                if (v != null)
                {
                    v.Name = author.Name;
                    db.SaveChanges();
                    //other
                    Clear();
                    AuthorsGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "Author Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Id = AuthorIdTextBox.Text.Trim();
            author.Name = AuthorNameTextBox.Text.Trim();

            if (IsModelValid(author))
            {
                var v = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();
                if (v != null)
                {
                    db.Authors.Remove(v);
                    db.SaveChanges();
                    //other
                    Clear();
                    AuthorsGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "Author Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Id = AuthorIdTextBox.Text.Trim();

            if (!author.Id.Equals(""))
            {
                var v = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();
                if (v != null)
                {
                    ErrorLabel.Text = "";
                    AuthorNameTextBox.Text = v.Name;
                }
                else
                {
                    ErrorLabel.Text = "Author Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Enter Author ID";
            }
        }
        private bool IsModelValid(Author author)
        {
            if(author.Id.Equals("") || author.Name.Equals(""))
            {
                return false;
            }
            return true;
        }
        private void Clear()
        {
            AuthorIdTextBox.Text = "";
            AuthorNameTextBox.Text = "";
            ErrorLabel.Text = "";
        }
    }
}