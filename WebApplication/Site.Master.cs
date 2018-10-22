using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                Button1.Text = "退出登陆";
            }
            else
            {
                Button1.Text = "登陆";
                LoginUser.ReadOnly = false;
            }
            
            
        }
    }
}