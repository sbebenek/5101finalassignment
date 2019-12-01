using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
namespace n00831998_final_assg
{
    public class WebPage
    {
        public int pageId { get; set; } //-1 if empty
        public String title { get; set; }
        public String body { get; set; }
        public DateTime publishDate { get; set; }

        public int authorId { get; set; } //-1 if empty

        //A webpage created with the correct paramaters
        public WebPage(int id, String title, String body, String publish, int aId)
        {
            this.pageId = id;
            this.title = title;
            this.body = body;
            this.publishDate = Convert.ToDateTime(publish);
            this.authorId = aId;
        }
        //an empty webpage is created
        public WebPage()
        {
            this.pageId = -1;
            this.title = "";
            this.body = "";
            this.publishDate = DateTime.Now;
            this.authorId = -1;
        }
        override public string ToString()
        {
            return title + ": " + body + ", published on " + publishDate;
        }

        public string getDateString()
        {
            return publishDate.ToString("MMMM dd, yyyy");
        }
    }
}