using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramAspMVC.Daos
{
    public class LikeDao
    {
        DBContextIG myDb = new DBContextIG();

        public void like(Like like)
        {
            myDb.Likes.Add(like);
            myDb.SaveChanges();
        }

        public void unLike(Like like)
        {
           var obj =  myDb.Likes.Where(x => x.id_user == like.id_user && x.id_post == like.id_post ).FirstOrDefault();
            myDb.Likes.Remove(obj);
            myDb.SaveChanges();
        }

        public Like checkExist(Like like)
        {
            return myDb.Likes.FirstOrDefault(x => x.id_user == like.id_user && x.id_post == like.id_post);
        }

        public int getNumberLike(int id,int idUser)
        {
            return myDb.Likes.Where(x => x.id_post == id && x.id_user != idUser).ToList().Count;
        }

    }
}