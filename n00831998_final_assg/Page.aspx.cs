using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
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

                //Finding the associated author for a page (bootleg inner join)
                

                List<WebPage> rs = db.List_Query("select * from PAGES where pageid =" + pageid);

                if (page_record.pageId != -1) //if pageid = -1, page is empty
                {
                    
                        page_title.InnerHtml = page_record.title;
                        page_body.InnerHtml = page_record.body;
                        publish_date.InnerHtml = "Published by <a href= \"AuthorDetail.aspx?authorid=" + author_record.authorId + "\">" +author_record.authorFName + " " + author_record.authorLName + "</a> on " + page_record.getDateString();
                    
                }
                else
                {
                    valid = false;
                }

            }
            if (!valid)
            {
                error.InnerHtml = "There was an error finding that page.";
                error.InnerHtml += "<button onclick=\"location.href = \"Default.aspx\">Go Back</button>";
            }
        }
    }
}