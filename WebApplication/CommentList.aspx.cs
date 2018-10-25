using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
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
            TextBox text = Page.Master.FindControl("LoginUser") as TextBox;
            Button button = Page.Master.FindControl("Button1") as Button;

            if (Session["user"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('请先登录！！！')", true);
                return null;
            }
            else
            {
                text.ReadOnly = true;
                text.Text = ((User)Session["user"]).Id.ToString();
                button.Text = "退出登陆";
            }
            return Mapper.GetInstance().SelectC(int.Parse(Request.QueryString["Id"])).AsQueryable();
        }
    }
}