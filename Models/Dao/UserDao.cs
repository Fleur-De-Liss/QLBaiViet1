using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class UserDao
    {
        private QLBaiVietDbContext db = null;
        public UserDao()
        {
            db = new QLBaiVietDbContext();
        }
        public bool Login(string username, string password)
        {
            object[] sqlParam =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            var res = db.Database.SqlQuery<bool>("Sp_Login @Username, @Password", sqlParam).SingleOrDefault();
            return res;
        }
    }
}
