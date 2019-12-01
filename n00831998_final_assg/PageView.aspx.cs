using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //DATABASE READING CODE
            var db = new PAGEDB();
            var authorDb = new AUTHORDB();

            List<Author> authorRs = authorDb.List_Query("select * from AUTHORS");

            //Change query if search function was run on page 
            //(currently can't figure out how to search for all pages by an author on this page given that the information is split into WebPage and Author objects)
            string query = "select* from PAGES order by pagepublishdate asc";
            if (Page.IsPostBack)
            { 
                if (!String.IsNullOrEmpty(search_value.Text.ToString()))
                {
                    pages_result.InnerHtml = "";
                    query = "select * from PAGES where LOWER(pagetitle) like '%" + search_value.Text.ToString() + "%' COLLATE utf8_general_ci order by pagepublishdate asc";
                }
            }

            List<WebPage> rs = db.List_Query(query);


            //Disabling view of command div because it shows on load
            commandDiv.Visible = false;
            //Checking if page was reached after a CRUD command was just done on another page
            string command = Request.QueryString["cmd"];
            if (!String.IsNullOrEmpty(command))
            {
                commandDiv.Visible = true;
                commandConfirm.InnerHtml = "Entry " + command;
            }


            //holder variable for the associated author
            Author authorHolder = new Author();

            pages_result.InnerHtml += "<table class=\"table\"><thead><tr>" +
                    "<th>PAGE TITLE</th>" +
                    "<th>AUTHOR</th>" +
                    "<th>PAGE CONTENT</th>" +
                    "<th>PUBLISH DATE</th>" +
                    "</tr></thead><tbody>";
            foreach (WebPage page in rs)
            {
                //Finding the associated author for a page (bootleg inner join)
                foreach (Author au in authorRs)
                {
                    //go through all authors, if authorid = current iteration of page's authorid, authorHolder is the page's author
                    if(page.authorId == au.authorId)
                    {
                        authorHolder = au;
                    }
                }

                int pageid = page.pageId;
                pages_result.InnerHtml += "<tr>";



                string pagetitle = page.title;
                pages_result.InnerHtml += "<td><a href=\"PageDetail.aspx?pageid="+pageid+"\">" + pagetitle + "</a></td>";

                //page author
                string pageauthor;
                if (authorHolder.authorId == -1)//no author found
                {
                    pageauthor = "No Author Found";
                }
                else
                {
                    pageauthor = authorHolder.authorFName + " " + authorHolder.authorLName;
                }
                pages_result.InnerHtml += "<td><a href=\"AuthorDetail.aspx?authorid=" + page.authorId + "\">" + pageauthor + "</a></td>";


                string pagebody = page.body; 
                if(pagebody.Length>120) 
                {
                    //if body is longer than 120 characters, put the first 120 characters and an ellipsis at the end
                    pagebody = pagebody.Substring(0, 120)+"...";
                }
                pages_result.InnerHtml += "<td>" + pagebody + "</td>";

                string publishdate = page.getDateString();
                pages_result.InnerHtml += "<td>" + publishdate + "</td>";

                pages_result.InnerHtml += "</tr>";
            }
            pages_result.InnerHtml += "</tbody><table>";

        }
    }  
}