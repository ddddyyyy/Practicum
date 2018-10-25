using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ORM;

namespace WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            if (Button1.Text.Equals("登陆"))
            {
                LoginUser.ReadOnly = true;
                Session["user"] = Mapper.GetInstance().Select(int.Parse(LoginUser.Text));
                Button1.Text = "退出登陆";
            }
            else
            {
                Session["user"] = null;
                Button1.Text = "登陆";
                LoginUser.ReadOnly = false;
            }
        }
    }
}