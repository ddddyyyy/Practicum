using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdressBook
{
    class Mapper:DbContext
    {

        static Mapper mapper;

        MySqlConnection conn = new MySqlConnection("server=madongyu.ml;database=adress;user=adress;password=93284dihsfhkj38fsdkh;SslMode=none");

        public static Mapper GetInstance()
        {
            if (mapper == null)
            {
                mapper = new Mapper();
            }
            return mapper;
        }

        public Mapper()
        {
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("数据库打开失败"+e.Message);
            }
        }

        public  void Insert(User user)
        {
            UserDb.Insert(user);
        }

        public bool Insert(Comment comment)
        {
            List<Comment> list =  CommentDb.GetList().Where(it => it.Cuid == comment.Cuid && it.Uid == comment.Uid).OrderByDescending(it => it.Date).ToList();
            if (list.Count == 0 || DateTime.Now.Subtract(list[0].Date).TotalHours > 1.0)
            {
                comment.Date = DateTime.Now;
                CommentDb.Insert(comment);
                return true;
            }
            return false;
        }

        public  void Update(User user)
        {
            UserDb.Update(user);
        }

        public  void Delete(Int32 id)
        {
            UserDb.DeleteById(id);
        }

        public List<User> Select()
        {
            return UserDb.GetList();
        }

        public List<Comment> SelectC(Int32 id)
        {
            return CommentDb.GetList().Where(it => it.Cuid == id).ToList();
        }

        public User Select(Int32 id)
        {
            return UserDb.GetById(id);
        }
    }
}
