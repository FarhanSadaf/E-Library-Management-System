using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        private ELibraryDbContext db = new ELibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            MemberGridView.DataBind();
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            Clear();
            string id = MemberIdTextBox.Text.Trim();
            if (!id.Equals(""))
            {
                var v = db.Members.Where(m => m.Id == id).FirstOrDefault();
                if(v != null)
                {
                    FullNameTextBox.Text = v.FullName;
                    AccountStatusTextBox.Text = v.AccountStatus;
                    DoBTextBox.Text = v.DateOfBirth.Date.ToShortDateString();
                    ContactNoTextBox.Text = v.ContactNo;
                    EmailIDTextBox.Text = v.Email;
                    CountryTextBox.Text = v.Country;
                    CityTextBox.Text = v.City;
                    PincodeTextBox.Text = v.Pincode;
                    FullAddressTextBox.Text = v.FullAddress;
                }
                else
                {
                    Response.Write("<script>alert('Account Not Found')</script>");
                }
            }
        }

        protected void ActiveButton_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("active");
            GoButton_Click(sender, e);
        }

        protected void PendingButton_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("pending");
            GoButton_Click(sender, e);
        }
        protected void DeactiveButton_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("deactive");
            GoButton_Click(sender, e);
        }
        private void UpdateMemberStatusById(string status)
        {
            string id = MemberIdTextBox.Text.Trim();
            if (!id.Equals(""))
            {
                var v = db.Members.Where(m => m.Id == id).FirstOrDefault();
                if (v != null)
                {
                    v.AccountStatus = status;
                    db.SaveChanges();
                    MemberGridView.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Account Not Found')</script>");
                }
            }
        }
        private void Clear()
        {
            FullNameTextBox.Text = "";
            AccountStatusTextBox.Text = "";
            DoBTextBox.Text = "";
            ContactNoTextBox.Text = "";
            EmailIDTextBox.Text = "";
            CountryTextBox.Text = "";
            CityTextBox.Text = "";
            PincodeTextBox.Text = "";
            FullAddressTextBox.Text = "";
        }

        protected void MemberGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[2].Text.Equals("active"))
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else if (e.Row.Cells[2].Text.Equals("pending"))
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    }
                    else
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