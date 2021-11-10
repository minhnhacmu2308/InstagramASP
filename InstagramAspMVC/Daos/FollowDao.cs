using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramAspMVC.Daos
{
    public class FollowDao
    {
        DBContextIG myDb = new DBContextIG();

        public int getNumberFollower(int idUser)
        {
            return myDb.Follows.Where(f => f.id_userBeFollow == idUser).ToList().Count;
        }

        public int getNumberFollowing(int idUser)
        {
            return myDb.Follows.Where(f => f.id_userFollow == idUser).ToList().Count;
        }


        public List<Follow> getListFollower(int idUser)
        {
            return myDb.Follows.Where(f => f.id_userBeFollow == idUser).ToList();
        }

        public List<Follow> getListFollowing(int idUser)
        {
            return myDb.Follows.Where(f => f.id_userFollow == idUser).ToList();
        }

        public void followUser(Follow follow)
        {
            myDb.Follows.Add(follow);
            myDb.SaveChanges();
        }

        public void unFollowUser(Follow follow)
        {
            var obj = myDb.Follows.FirstOrDefault(x => x.id_userBeFollow == follow.id_userBeFollow && x.id_userFollow == follow.id_userFollow);
            myDb.Follows.Remove(obj);
            myDb.SaveChanges();
        }

        public Follow checkExist(Follow follow)
        {
            return myDb.Follows.FirstOrDefault(x => x.id_userBeFollow == follow.id_userBeFollow && x.id_userFollow == follow.id_userFollow);
        }
    }
}