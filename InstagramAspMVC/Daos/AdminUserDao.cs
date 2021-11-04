using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramAspMVC.Models;

namespace InstagramAspMVC.Dao
{
    public class AdminUserDao
    {
        DBContextIG myDb = new DBContextIG();

        public List<User> getAll()
        {
            return myDb.Users.OrderByDescending(u => u.id_user).ToList();
        }
        public User getUserById(int id)
        {
            return myDb.Users.Where(u => u.id_user == id).FirstOrDefault();
        }

        public void changeStatus(int id)
        {
            var user = getUserById(id);
            user.status = user.status == 1 ? 0 : 1;
            myDb.SaveChanges();
        }
    }
}