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
    public partial class Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox text = Page.Master.FindControl("LoginUser") as TextBox;
            Button button = Page.Master.FindControl("Button1") as Button;

            if (Session["user"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('请先登录！！！')", true);
            }
            else
            {
                text.ReadOnly = true;
                text.Text = ((User)Session["user"]).Id.ToString();
                button.Text = "退出登陆";
            }
        }

        protected void Submit(object sender, EventArgs e)
        {
            if (null != Session["user"] && ((((Model.User)Session["user"]).Role == Model.Roles.只读用户) || ((Model.User)Session["user"]).Role == Model.Roles.非法用户))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('无权限！！！')", true);
                return;
            }
              
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