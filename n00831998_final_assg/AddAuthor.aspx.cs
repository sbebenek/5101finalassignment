using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n00831998_final_assg
{
    public partial class AddAuthor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void AddButton_Click(Object sender,
                       EventArgs e)
        {            

            //**DATABASE ADD CODE GOES HERE
            var authorDb = new AUTHORDB();
            authorDb.AddAuthor(firstName.Text.ToString(), lastName.Text.ToString());

            Response.Redirect("AuthorView.aspx?cmd=added");
        }
       

    }
}
