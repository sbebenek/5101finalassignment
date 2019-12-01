using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var db = new PAGEDB();
                List<WebPage> rs = db.List_Query("select * from PAGES order by pagepublishdate");

                foreach (WebPage page in rs)
                {

                    string pageid = page.pageId.ToString();
                    string pagetitle = page.title;
                    //<li><a runat="server" href="~/">Home</a></li>

                    navbar.InnerHtml += "<li><a href=\"Page.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></li>";

                }
            }
            
        }
    }
}