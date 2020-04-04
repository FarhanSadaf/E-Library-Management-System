using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        private static string gImagePath;
        private static int gActualStock, gCurrentStock, gIssuedBooks;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropdownsWithAuthorPublisher();
            }
            BooksGridViewDataBind();
        }
        private void BooksGridViewDataBind()
        {
            BooksGridView.DataSource = db.Books.ToList();
            BooksGridView.DataBind();
        }
        private void FillDropdownsWithAuthorPublisher()
        {
            try
            {
                var auhtors = db.Authors.ToList();
                var publishers = db.Publishers.ToList();
                AutherNameDropDownList.DataSource = auhtors;
                AutherNameDropDownList.DataTextField = "Name";
                AutherNameDropDownList.DataValueField = "Id";
                AutherNameDropDownList.DataBind();

                PublisherNameDropDownList.DataSource = publishers;
                PublisherNameDropDownList.DataTextField = "Name";
                PublisherNameDropDownList.DataValueField = "Id";
                PublisherNameDropDownList.DataBind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }
        private Book GetBookInfo(string operation = "add")
        {
            string genres = "";
            foreach (var i in GenreListBox.GetSelectedIndices())
            {
                genres = genres + GenreListBox.Items[i] + ",";
            }
            //genres = Adventure, Crime, Thriller,
            genres = genres.Remove(genres.Length - 1);

            //img link
            string filepath = "~/Images/Books/books1.png";
            string filename = Path.GetFileName(BookCoverFileUpload.PostedFile.FileName);
            if (filename == null || filename == "")
            {
                filepath = gImagePath;
            }
            else
            {
                BookCoverFileUpload.SaveAs(Server.MapPath("~/Images/Books/" + filename));
                filepath = "~/Images/Books/" + filename;
            }

            Book book = new Book();
            book.Id = BookIdTextBox.Text.Trim();
            book.Name = BookNameTextBox.Text.Trim();
            book.Language = LanguageDropDownList.SelectedItem.Value;
            book.AuthorId = AutherNameDropDownList.SelectedItem.Value;
            book.PublisherId = PublisherNameDropDownList.SelectedItem.Value;
            book.PublishDate = Convert.ToDateTime(PublishDateTextBox.Text.Trim());
            book.Genre = genres;
            book.Edition = EditionTextBox.Text.Trim();
            book.BookCost = Convert.ToDouble(BookCostTextBox.Text.Trim());
            book.NoOfPages = Convert.ToInt32(PagesTextBox.Text.Trim());
            book.ActualStock = Convert.ToInt32(ActualStockTextBox.Text.Trim());
            if (operation.Equals("update"))
            {
                book.CurrentStock = book.ActualStock - gIssuedBooks;
            }
            else
            {
                book.CurrentStock = book.ActualStock;
            }
            book.BookDescription = BookDescriptionTextBox.Text;
            book.BookImgLink = filepath;
            return book;
        }
        private bool CheckIfBookExists(string id, string name)
        {
            var v = db.Books.Where(b => b.Id == id && b.Name == name).FirstOrDefault();
            return v != null;
        }
        private void Clear()
        {
            BookIdTextBox.Text = "";
            BookNameTextBox.Text = "";
            LanguageDropDownList.SelectedIndex = 0;
            AutherNameDropDownList.SelectedIndex = 0;
            PublisherNameDropDownList.SelectedIndex = 0;
            PublishDateTextBox.Text = "";
            EditionTextBox.Text = "";
            BookCostTextBox.Text = "";
            PagesTextBox.Text = "";
            ActualStockTextBox.Text = "";
            BookDescriptionTextBox.Text = "";
        }
        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            Book book = GetBookInfo();
            try
            {
                if (CheckIfBookExists(book.Id, book.Name))
                {
                    Response.Write("<script>alert('Book Already Exists')</script>");
                }
                else
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void UpdateBookButton_Click(object sender, EventArgs e)
        {
            Book book = GetBookInfo("update");
            try
            {
                var v = db.Books.Where(b => b.Id == book.Id && b.Name == book.Name).FirstOrDefault();
                if (v != null)
                {
                    v.Genre = book.Genre;
                    v.PublishDate = book.PublishDate;
                    v.Language = book.Language;
                    v.Edition = book.Edition;
                    v.BookCost = book.BookCost;
                    v.NoOfPages = book.NoOfPages;
                    v.BookDescription = book.BookDescription;
                    v.ActualStock = book.ActualStock;
                    v.CurrentStock = book.CurrentStock;
                    v.BookImgLink = book.BookImgLink;
                    v.AuthorId = book.AuthorId;
                    v.PublisherId = book.PublisherId;
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void DeleteBookButton_Click(object sender, EventArgs e)
        {
            string id = BookIdTextBox.Text.Trim();
            try
            {
                var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (v != null)
                {
                    db.Books.Remove(v);
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            string id = BookIdTextBox.Text.Trim();
            try
            {
                var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (v != null)
                {
                    BookNameTextBox.Text = v.Name;
                    LanguageDropDownList.SelectedValue = v.Language;
                    PublisherNameDropDownList.SelectedValue = v.PublisherId;
                    AutherNameDropDownList.SelectedValue = v.AuthorId;
                    PublishDateTextBox.Text = v.PublishDate.ToShortDateString();
                    string[] genres = v.Genre.Split(',');
                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < GenreListBox.Items.Count; j++)
                        {
                            if (GenreListBox.Items[j].ToString() == genres[i])
                            {
                                GenreListBox.Items[j].Selected = true;
                            }
                        }
                    }
                    EditionTextBox.Text = v.Edition;
                    BookCostTextBox.Text = v.BookCost.ToString();
                    PagesTextBox.Text = v.NoOfPages.ToString();
                    gActualStock = v.ActualStock;
                    gCurrentStock = v.CurrentStock;
                    gIssuedBooks = v.ActualStock - v.CurrentStock;
                    ActualStockTextBox.Text = v.ActualStock.ToString();
                    CurrentStockTextBox.Text = v.CurrentStock.ToString();
                    IssuedBooksTextBox.Text = gIssuedBooks.ToString();
                    BookDescriptionTextBox.Text = v.BookDescription;
                    gImagePath = v.BookImgLink;
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }
    }
}