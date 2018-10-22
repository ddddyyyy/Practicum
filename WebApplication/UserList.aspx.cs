using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.ORM;

namespace WebApplication
{
    public partial class UserList : System.Web.UI.Page
    {

        static List<User> list;
 
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void Update(int Id)
        {
            User user = new User();
            TryUpdateModel(user);
            list[list.IndexOf(list.Single(i => i.Id == Id))] = user;
            Mapper.GetInstance().Update(user);
        }

        public void Delete(int Id)
        {
            list.Remove(list.Single(i => i.Id == Id));
            Mapper.GetInstance().Delete(Id);
        }

        protected void New(object sender, EventArgs e)
        {
            User user = new User();
            Mapper.GetInstance().Insert(ref user);
            list.Add(user);
            DataBind();
        }

        // 返回类型可以更改为 IEnumerable，但是为了支持
        // 分页和排序，必须添加以下参数:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<WebApplication.Model.User> GridView1_GetData()
        {
            TextBox text = (TextBox)Page.FindControl("LoginUser");

            if (text.Text == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('登陆！！！')", true);
            }
            
            if (list == null) { list = Mapper.GetInstance().Select(); }
            
            return list.AsQueryable();
        }
    }
}