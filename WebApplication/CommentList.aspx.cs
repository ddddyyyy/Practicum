using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ORM;

namespace WebApplication
{
    public partial class CommentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<WebApplication.Model.Comment> GridView1_GetData()
        {
            
            return Mapper.GetInstance().SelectC(int.Parse(Request.QueryString["Id"])).AsQueryable();
        }
    }
}