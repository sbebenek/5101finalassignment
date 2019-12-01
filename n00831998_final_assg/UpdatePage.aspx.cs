using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace n00831998_final_assg
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            WebPage page_record = new WebPage();

            try
            {
                Int32.Parse(pageid);
            }
            catch (Exception ex)
            {
                //catching invalid URL ID entries
                valid = false;
            }

            if (valid && !Page.IsPostBack)
            {
                var db = new PAGEDB();
                page_record = db.FindPage(Int32.Parse(pageid));

                if (page_record.pageId != -1) //if pageid = -1, page is empty
                {
                    //textboxes are populated with server data when the page is not a postback (loaded for 1st time)
                    page_title.InnerHtml = page_record.title;
                    page_name.Text = page_record.title;
                    page_body.Text = page_record.body;
                }
                else
                {
                    valid = false;
                }

            }
            if (!valid)
            {
                updatestudentForm.InnerHtml = "There was an error finding that page. <br />";
                updatestudentForm.InnerHtml += "<button type=\"button\" class=\"btn btn-primary\" onclick=\"location.href = 'PageView.aspx' \">Go Back</button>";
            }


            /*populating dropdownlist*/
            new_author.Visible = false;
            var authorDb = new AUTHORDB();
            Author selectedAuthor = authorDb.FindAuthor(page_record.authorId);
            List<Author> authorRs = authorDb.List_Query("select * from AUTHORS");

            if (!Page.IsPostBack)
            {
                author.DataSource = authorRs;
                author.DataBind();
            }
            if (author.Items.FindByText(selectedAuthor.ToString()) != null)
            {
                author.ClearSelection(); //making sure the previous selection has been cleared
                author.Items.FindByText(selectedAuthor.ToString()).Selected = true; //setting the page's current author to be selected in the dropdownlist
            }

        }
        protected void BackButton_Click(Object sender,
                       EventArgs e)
        {
            Debug.WriteLine("back is clicked");
            //sending student ID back to the individual view page when back button is clicked
            string pageid = Request.QueryString["pageid"];
            Response.Redirect("PageDetail.aspx?pageid=" + pageid);
        }

        protected void UpdateButton_Click(Object sender,
                       EventArgs e)
        {
            var db = new PAGEDB();
            var authorDb = new AUTHORDB();
            string query;
            //Not the best way to get the authorID from the text but best I can do without rewriting everything
            string[] authorToString = author.SelectedItem.Text.ToString().Split(' ');
            string selectedFName = authorToString[0];
            Debug.WriteLine("seleted item = " + author.SelectedItem);
            int authorIdHolder = 0;

            List<Author> authorRs = authorDb.List_Query("select * from AUTHORS");
            foreach (Author au in authorRs)
            {
                if (au.authorFName == selectedFName)
                {
                    authorIdHolder = au.authorId;
                }
            }

            if (firstName.Text.ToString() != "" && lastName.Text.ToString() != "")//if the First and Last name entry fields are not empty, a new author needs to be added
            {
                authorDb.AddAuthor(firstName.Text.ToString(), lastName.Text.ToString());
                authorDb = new AUTHORDB();//grabbing table with new entry
                authorRs = authorDb.List_Query("select * from AUTHORS");

                foreach (Author au in authorRs)
                {
                    if (au.authorFName == firstName.Text.ToString() && au.authorLName == lastName.Text.ToString())
                    {
                        authorIdHolder = au.authorId;
                    }
                }
            }

            int pageid = Int32.Parse(Request.QueryString["pageid"]);
            db.UpdatePage(pageid, page_name.Text.ToString(), page_body.Text.ToString(), authorIdHolder);

            Response.Redirect("PageDetail.aspx?pageid=" + pageid + "&cmd=updated");
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