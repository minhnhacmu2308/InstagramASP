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
    }
}