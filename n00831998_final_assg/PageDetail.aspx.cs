using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class IndividualPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            commandDiv.Visible = false;
            if(!String.IsNullOrEmpty(HttpUtility.UrlDecode(Request.QueryString["cmd"])) && HttpUtility.UrlDecode(Request.QueryString["cmd"]) == "updated")
            {
                commandDiv.Visible = true;
                commandConfirm.InnerHtml = "Entry Updated";
            }
            bool valid = true;
            string pageid = HttpUtility.UrlDecode(Request.QueryString["pageid"]);
            if (String.IsNullOrEmpty(pageid)) valid = false;

            try
            {
                Int32.Parse(pageid);
            }
            catch (Exception ex)
            {
                //catching invalid URL ID entries
                valid = false;
            }

            if (valid)
            {
                var db = new PAGEDB();
                var authorDb = new AUTHORDB();
                WebPage page_record = db.FindPage(Int32.Parse(pageid));
                Author author_record = authorDb.FindAuthor(page_record.authorId);
                List<WebPage> rs = db.List_Query("select * from PAGES where pageid ="+pageid);

                if (page_record.pageId!=-1)//pageid =-1 means the page is empty
                {
                    foreach (WebPage page in rs)
                    {
                        page_title.InnerHtml = page.title;
                        page_name.InnerHtml = page.title;
                        author.InnerHtml = "<a href=\"AuthorDetail.aspx?authorid="+page.authorId+"\">" + author_record.authorFName + " " + author_record.authorLName + "</a>";
                        page_body.InnerHtml = page.body;
                        publish_date.InnerHtml = page.getDateString();
                    }
                }
                else
                {
                    valid = false;
                }
            }
            if (!valid)
            {
                error.InnerHtml = "There was an error finding that page.";
                error.InnerHtml += "<button onclick=\"location.href = 'PageView.aspx'\">Go Back</button>";
                page_content.Visible = false;
            }


        }
        //Delete entry button clicked
        protected void DeleteButton_Click(Object sender,
                       EventArgs e)
        {
            //Method created in codebehind so that entry deletion can be handled by the server

            //**DATABASE DELETE CODE GOES HERE
            int pageid = Int32.Parse(HttpUtility.UrlDecode(Request.QueryString["pageid"])); 
            var db = new PAGEDB();
            db.DeletePage(pageid);

            //Putting command=deleted in URL to confirm to Teachers page that something was just deleted
            Response.Redirect("PageView.aspx?cmd=deleted");
        }

        //Update entry button clicked
        protected void UpdateButton_Click(Object sender,
                       EventArgs e)
        {
            string pageid = HttpUtility.UrlDecode(Request.QueryString["pageid"]); //Don't need to validate URL because it was already done on page load (these buttons wouldn't appear if invalid)
            //sends teacher ID to the update page
            Response.Redirect("UpdatePage.aspx?pageid=" + pageid);
        }
    }
}