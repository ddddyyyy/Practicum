using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.ORM
{
    class Mapper : DbContext
    {

        static Mapper mapper;

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
        }

        public void Insert(ref User user)
        {
            user.Id = UserDb.InsertReturnIdentity(user);
        }

        public bool Insert(Model.Comment comment)
        {
            List<Model.Comment> list = CommentDb.GetList().Where(it => it.Cuid == comment.Cuid && it.Uid == comment.Uid).OrderByDescending(it => it.Date).ToList();
            if (list.Count == 0 || DateTime.Now.Subtract(list[0].Date).TotalHours > 1.0)
            {
                comment.Date = DateTime.Now;
                CommentDb.Insert(comment);
                return true;
            }
            return false;
        }

        public void Update(User user)
        {
            UserDb.Update(user);
        }

        public void Delete(Int32 id)
        {
            UserDb.DeleteById(id);
        }

        public List<User> Select()
        {
            return UserDb.GetList();
        }

        public List<Model.Comment> SelectC(Int32 id)
        {
            return CommentDb.GetList().Where(it => it.Cuid == id).ToList();
        }

        public User Select(Int32 id)
        {
            return UserDb.GetById(id);
        }
    }
}