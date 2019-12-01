using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class UpdateAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool valid = true;
            string authorid = Request.QueryString["authorid"];
            if (String.IsNullOrEmpty(authorid)) valid = false;

            try
            {
                Int32.Parse(authorid);
            }
            catch (Exception ex)
            {
                //catching invalid URL ID entries
                valid = false;
            }

            if (valid && !Page.IsPostBack)
            {
                var authorDb = new AUTHORDB();
                Author author_record = authorDb.FindAuthor(Int32.Parse(authorid));

                if (author_record.authorId != -1) //if pageid = -1, page is empty
                {
                    //textboxes are populated with server data when the page is not a postback (loaded for 1st time)
                    author_full.InnerHtml = author_record.authorFName + " " + author_record.authorLName;
                    first_name.Text = author_record.authorFName;
                    last_name.Text = author_record.authorLName;
                }
                else
                {
                    valid = false;
                }

            }
            if (!valid)
            {
                update_author.InnerHtml = "There was an error finding that page. <br />";
                update_author.InnerHtml += "<button type=\"button\" class=\"btn btn-primary\" onclick=\"location.href = 'AuthorView.aspx' \">Go Back</button>";
            }

        }
        protected void BackButton_Click(Object sender,
                      EventArgs e)
        {
            Debug.WriteLine("back is clicked");
            //sending student ID back to the individual view page when back button is clicked
            string authorid = Request.QueryString["authorid"];
            Response.Redirect("AuthorDetail.aspx?authorid=" + authorid);
        }

        protected void UpdateButton_Click(Object sender,
                       EventArgs e)
        {
            int authorid = Int32.Parse(Request.QueryString["authorid"]);
            var authorDb = new AUTHORDB();
            authorDb.UpdateAuthor(authorid, first_name.Text.ToString(), last_name.Text.ToString());

            Response.Redirect("AuthorDetail.aspx?authorid=" + authorid + "&cmd=updated");
        }

    }
   
}
