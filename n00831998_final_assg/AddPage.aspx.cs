using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                new_author.Visible = false;
                var authorDb = new AUTHORDB();
                List<Author> authorRs = authorDb.List_Query("select * from AUTHORS");

                author.DataSource = authorRs;
                author.DataBind();
            }
        }
        protected void AddButton_Click(Object sender,
                       EventArgs e)
        {
            //Not the best way to get the authorID from the text but best I can do without rewriting everything
            string[] authorToString = author.SelectedItem.Text.ToString().Split(' ');
            string selectedFName = authorToString[0];
            Debug.WriteLine("seleted item = " + author.SelectedItem);
            int authorIdHolder = 0;

            var authorDb = new AUTHORDB();
            List<Author> authorRs = authorDb.List_Query("select * from AUTHORS");
            foreach (Author au in authorRs)
            {
                if (au.authorFName == selectedFName)
                {
                    authorIdHolder = au.authorId;
                }
            }


            //**DATABASE ADD CODE GOES HERE
            var db = new PAGEDB();
            string query;
            if (firstName.Text.ToString() != "" && lastName.Text.ToString() != "")//if the First and Last name entry fields are not empty, a new author needs to be added
            {
                authorDb.AddAuthor(firstName.Text.ToString(), lastName.Text.ToString());
                authorDb = new AUTHORDB();//grabbing updated table with new entry
                authorRs = authorDb.List_Query("select * from AUTHORS");

                foreach (Author au in authorRs)
                {
                    if (au.authorFName == firstName.Text.ToString() && au.authorLName == lastName.Text.ToString())
                    {
                        authorIdHolder = au.authorId;
                    }
                }
            }

            db.AddPage(pageTitle.Text.ToString(), pageBody.Text.ToString(), authorIdHolder);

            Response.Redirect("PageView.aspx?cmd=added");
        }
        protected void CancelNewAuthor_Click(Object sender, EventArgs e)
        {
            drop_down.Visible = true;
            new_author.Visible = false;
            firstName.Text = "";
            lastName.Text = "";
        }
        protected void ShowNewAuthor_Click(Object sender, EventArgs e)
        {
            drop_down.Visible = false;
            new_author.Visible = true;
            firstName.Text = "";
            lastName.Text = "";
        }
    }
}