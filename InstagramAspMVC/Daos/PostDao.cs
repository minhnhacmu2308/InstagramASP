using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramAspMVC.Daos
{
    public class PostDao
    {
        DBContextIG myDb = new DBContextIG();

        public int getNumberPost(int idUser)
        {
            return myDb.Posts.Where(p => p.id_user == idUser).ToList().Count;
        }

        public List<Post> getNewFeed(int idUser)
        {
            return myDb.Posts.ToList();
            /*return myDb.Posts.Where(x => x.id_user != idUser).ToList();*/
        }
    }
}