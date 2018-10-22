using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ORM;

namespace WebApplication
{
    public partial class Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            Model.Comment c = new Model.Comment();
            c.Cuid = int.Parse(Request.QueryString["Id"]);
            c.Content = TextBox123.Text;
            if (Mapper.GetInstance().Insert(c))
            {
                ModelState.AddModelError("", "评价成功");
            }
            else
            {
                ModelState.AddModelError("", "一小时之内只能评价一次");
            }
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Server.Transfer("UserList.aspx");
        }
    }
}