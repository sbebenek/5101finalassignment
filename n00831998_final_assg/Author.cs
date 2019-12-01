using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n00831998_final_assg
{
    public class Author
    {
        public int authorId { get; set; } //-1 if empty
        public String authorFName { get; set; }
        public String authorLName { get; set; }
        public DateTime authorJoinDate { get; set; }


        //A webpage created with the correct paramaters
        public Author(int id, String fName, String lName, String joinDate)
        {
            this.authorId = id;
            this.authorFName = fName;
            this.authorLName = lName;
            this.authorJoinDate = Convert.ToDateTime(joinDate);
        }
        //an empty webpage is created
        public Author()
        {
            this.authorId = -1;
            this.authorFName = "";
            this.authorLName = "";
            this.authorJoinDate = DateTime.Now;
        }
        override public string ToString()
        {
            return authorFName + " " + authorLName + ", joined on " + this.getDateString();
        }

        public string getDateString()
        {
            return authorJoinDate.ToString("MMMM dd, yyyy");
        }
    }
}