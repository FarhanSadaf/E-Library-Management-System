using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Id = PublisherIdTextBox.Text.Trim();
            publisher.Name = PublisherNameTextBox.Text.Trim();

            if (IsModelValid(publisher))
            {
                var v = db.Publishers.Where(a => a.Id == publisher.Id).FirstOrDefault();
                if (v != null)
                {
                    ErrorLabel.Text = "Publisher Already Exists";
                }
                else
                {
                    db.Publishers.Add(publisher);
                    db.SaveChanges();
                    //other
                    Clear();
                    PublisherGridView.DataBind();
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Id = PublisherIdTextBox.Text.Trim();
            publisher.Name = PublisherNameTextBox.Text.Trim();

            if (IsModelValid(publisher))
            {
                var v = db.Publishers.Where(a => a.Id == publisher.Id).FirstOrDefault();
                if (v != null)
                {
                    v.Name = publisher.Name;
                    db.SaveChanges();
                    //other
                    Clear();
                    PublisherGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "Publisher Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Id = PublisherIdTextBox.Text.Trim();
            publisher.Name = PublisherNameTextBox.Text.Trim();

            if (IsModelValid(publisher))
            {
                var v = db.Publishers.Where(a => a.Id == publisher.Id).FirstOrDefault();
                if (v != null)
                {
                    db.Publishers.Remove(v);
                    db.SaveChanges();
                    //other
                    Clear();
                    PublisherGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "Publisher Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid Format";
            }
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Id = PublisherIdTextBox.Text.Trim();

            if (!publisher.Id.Equals(""))
            {
                var v = db.Publishers.Where(a => a.Id == publisher.Id).FirstOrDefault();
                if (v != null)
                {
                    ErrorLabel.Text = "";
                    PublisherNameTextBox.Text = v.Name;
                }
                else
                {
                    ErrorLabel.Text = "Publisher Doesn't Exist";
                }
            }
            else
            {
                ErrorLabel.Text = "Enter Publisher ID";
            }
        }
        private bool IsModelValid(Publisher publisher)
        {
            if (publisher.Id.Equals("") || publisher.Name.Equals(""))
            {
                return false;
            }
            return true;
        }
        private void Clear()
        {
            PublisherIdTextBox.Text = "";
            PublisherNameTextBox.Text = "";
            ErrorLabel.Text = "";
        }
    }
}