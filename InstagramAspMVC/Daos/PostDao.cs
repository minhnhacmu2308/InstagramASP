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
            return myDb.Posts.Where(p => p.id_user == idUser && p.status == 1).ToList().Count;
        }

        public List<Post> getNewFeed(int idUser)
        {
            return myDb.Posts.Where(b => b.status == 1).OrderByDescending(p => p.id_post).ToList();
            /*return myDb.Posts.Where(x => x.id_user != idUser).ToList();*/
        }
        public void addPost(Post post)
        {
            myDb.Posts.Add(post);
            myDb.SaveChanges();
        }
        public void addImg(Images images)
        {
            myDb.Images.Add(images);
            myDb.SaveChanges();
        }
        public Images getImg(int id)
        {
            return myDb.Images.FirstOrDefault(i => i.id_Post == id);
        }
        public List<Post> getPostUser(int id)
        {
            return myDb.Posts.Where(p => p.id_user == id && p.status == 1).OrderByDescending(c => c.id_post).ToList();
        }
        public int getLike(int id)
        {
            return myDb.Likes.Where(l => l.id_post == id).ToList().Count;
        }
        public int getCmt(int id)
        {
            return myDb.Comments.Where(l => l.id_post == id).ToList().Count;
        }
        public List<Comment> getComment(int id)
        {
            return myDb.Comments.Where(c => c.id_post == id).OrderByDescending(a => a.id_comment).Take(2).ToList();
        }
        public void addComment(Comment comment)
        {
            myDb.Comments.Add(comment);
            myDb.SaveChanges();
        }
        public Post getInforPost(int id)
        {
            return myDb.Posts.FirstOrDefault(p => p.id_post == id);
        }
        public List<Comment> getAllComment(int id)
        {
            return myDb.Comments.Where(c => c.id_post == id).OrderByDescending(a => a.id_comment).ToList();
        }
    }
}