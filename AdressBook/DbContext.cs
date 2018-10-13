using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    class DbContext
    {
        public SqlSugarClient db;
        public SimpleClient<User> UserDb
        {
            get
            {
                if (null == _userDb) { _userDb = new SimpleClient<User>(db);}
                return _userDb;
            }
        }
        private SimpleClient<User> _userDb;
        public SimpleClient<Comment> CommentDb
        {
            get
            {
                if (null == _commentDb) { _commentDb = new SimpleClient<Comment>(db); }
                return _commentDb;
            }
        }
        private SimpleClient<Comment> _commentDb;

        public DbContext()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=madongyu.ml;database=adress;user=adress;password=93284dihsfhkj38fsdkh;SslMode=none",
                DbType = DbType.MySql,
                IsAutoCloseConnection = false
            });
        }
    }
}
