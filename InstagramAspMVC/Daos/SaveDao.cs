using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramAspMVC.Daos
{
    public class SaveDao
    {
        DBContextIG myDb = new DBContextIG();

        public void add(SavePost savePost)
        {
            myDb.Saves.Add(savePost);   
            myDb.SaveChanges();
        }

        public void unSave(SavePost savePost)
        {
            var obj  = myDb.Saves.FirstOrDefault(x => x.id_user == savePost.id_user && x.id_post == savePost.id_post);
            myDb.Saves.Remove(obj);
            myDb.SaveChanges();
        }

        public SavePost checkExist(SavePost savePost)
        {
            return myDb.Saves.FirstOrDefault(x => x.id_user == savePost.id_user && x.id_post == savePost.id_post);
        }

        public List<SavePost> GetSavePosts(int id)
        {
            return myDb.Saves.Where(x => x.id_user == id).ToList();
        }
    }
}