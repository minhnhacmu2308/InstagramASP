using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InstagramAspMVC.Dao
{
    public class AdminPostDao
    {
        DBContextIG myDb = new DBContextIG();

        public List<Post> getAll()
        {
            return myDb.Posts.OrderByDescending(p => p.id_post).ToList();
        }

        public Post getPostById(int id)
        {
            return myDb.Posts.Where(p => p.id_post == id).FirstOrDefault();
        }

        public void changeStatus(int id)
        {
            var post = getPostById(id);
            post.status = post.status == 1 ? 0 : 1;
            myDb.SaveChanges();
        }
    }
}