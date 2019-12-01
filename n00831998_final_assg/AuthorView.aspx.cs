using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DATABASE READING CODE
            var authorDb = new AUTHORDB();


            //Change query if search function was run on page 
            string query = "select* from AUTHORS order by authorid asc";
            if (Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(search_value.Text.ToString()))
                {
                    pages_result.InnerHtml = "";
                    query = "select * from AUTHORS where LOWER(authorfname) like '%" + search_value.Text.ToString() + "%' COLLATE utf8_general_ci OR LOWER(authorlname) like '%" + search_value.Text.ToString() + "%' order by authorid asc";
                }
            }

            List<Author> authorRs = authorDb.List_Query(query);



            //Disabling view of command div because it shows on load
            commandDiv.Visible = false;
            //Checking if page was reached after a CRUD command was just done on another page
            string command = Request.QueryString["cmd"];
            if (!String.IsNullOrEmpty(command))
            {
                commandDiv.Visible = true;
                commandConfirm.InnerHtml = "Entry " + command;
            }


            pages_result.InnerHtml += "<table class=\"table\"><thead><tr>" +
                    "<th>AUTHOR</th>" +
                    "<th>JOIN DATE</th>" +
                    "</tr></thead><tbody>";
            foreach (Author author in authorRs)
            {
                

                int authorid = author.authorId;
                pages_result.InnerHtml += "<tr>";

                string authorname;

                if (authorid == -1)//no author found
                {
                    authorname = "No Author Found";
                }
                else
                {
                    authorname = author.authorFName + " " + author.authorLName;
                }
                pages_result.InnerHtml += "<td><a href=\"AuthorDetail.aspx?authorid=" + authorid + "\">" + authorname + "</a></td>";


                

                string joindate = author.getDateString();
                pages_result.InnerHtml += "<td>" + joindate + "</td>";

                pages_result.InnerHtml += "</tr>";
            }
            pages_result.InnerHtml += "</tbody><table>";
        }
    }
}