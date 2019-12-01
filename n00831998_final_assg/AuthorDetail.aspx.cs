using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class AuthorDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            commandDiv.Visible = false;
            if (!String.IsNullOrEmpty(HttpUtility.UrlDecode(Request.QueryString["cmd"])) && HttpUtility.UrlDecode(Request.QueryString["cmd"]) == "updated")
            {
                commandDiv.Visible = true;
                commandConfirm.InnerHtml = "Entry Updated";
            }
            bool valid = true;
            string authorid = HttpUtility.UrlDecode(Request.QueryString["authorid"]);
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

            if (valid)
            {
                var authorDb = new AUTHORDB();
                Author author_record = authorDb.FindAuthor(Int32.Parse(authorid));
                List<Author> rs = authorDb.List_Query("select * from AUTHORS where authorid =" + authorid);

                if (author_record.authorId != -1)//pageid =-1 means the page is empty
                {
                    foreach (Author author in rs)
                    {
                        author_title.InnerHtml = author.authorFName + " " + author.authorLName;
                        first_name.InnerHtml = author.authorFName;
                        last_name.InnerHtml = author.authorLName;
                        join_date.InnerHtml = author.getDateString();
                    }
                }
                else
                {
                    valid = false;
                }
                pages_result.InnerHtml += "<table class=\"table\"><thead><tr>" +
                    "<th>PAGE TITLE</th>" +
                    "<th>PAGE CONTENT</th>" +
                    "<th>PUBLISH DATE</th>" +
                    "</tr></thead><tbody>";
                var db = new PAGEDB();
                List<WebPage> pageRs = db.List_Query("select * from PAGES where authorid=" + authorid);
                foreach (WebPage page in pageRs)
                {             

                    int pageid = page.pageId;
                    pages_result.InnerHtml += "<tr>";


                    string pagetitle = page.title;
                    pages_result.InnerHtml += "<td><a href=\"PageDetail.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></td>";

                    
                    string pagebody = page.body;
                    if (pagebody.Length > 120)
                    {
                        //if body is longer than 120 characters, put the first 120 characters and an ellipsis at the end
                        pagebody = pagebody.Substring(0, 120) + "...";
                    }
                    pages_result.InnerHtml += "<td>" + pagebody + "</td>";

                    string publishdate = page.getDateString();
                    pages_result.InnerHtml += "<td>" + publishdate + "</td>";

                    pages_result.InnerHtml += "</tr>";
                }
                pages_result.InnerHtml += "</tbody><table>";
            }
            if (!valid)
            {
                error.InnerHtml = "There was an error finding that page.";
                error.InnerHtml += "<button onclick=\"location.href = 'AuthorView.aspx'\">Go Back</button>";
                page_content.Visible = false;
            }


        }
        //Delete entry button clicked
        protected void DeleteButton_Click(Object sender,
                       EventArgs e)
        {
            //Method created in codebehind so that entry deletion can be handled by the server

            //**DATABASE DELETE CODE GOES HERE
            int authorid = Int32.Parse(HttpUtility.UrlDecode(Request.QueryString["authorid"]));
            var authorDb = new AUTHORDB();
            var db = new PAGEDB();
            authorDb.DeleteAuthor(authorid);
            string pageQuery = "delete from PAGES where authorid=" + authorid; //more useful to use this line to delete all entries written by a particular author
                                                                               //than it is to use AUTHORDB.DeletePage() method in this case
            db.List_Query(pageQuery);


            //Putting command=deleted in URL to confirm to Teachers page that something was just deleted
            Response.Redirect("AuthorView.aspx?cmd=deleted");
        }

        //Update entry button clicked
        protected void UpdateButton_Click(Object sender,
                       EventArgs e)
        {
            string authorid = HttpUtility.UrlDecode(Request.QueryString["authorid"]); //Don't need to validate URL because it was already done on page load (these buttons wouldn't appear if invalid)
            //sends teacher ID to the update page
            Response.Redirect("UpdateAuthor.aspx?authorid=" + authorid);
        }
    }
    
}