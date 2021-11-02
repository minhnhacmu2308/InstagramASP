using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InstagramAspMVC.Daos
{
    public class UserDao
    {
        DBContextIG myDb = new DBContextIG();

        public string md5(string password)
        {
            MD5 md = MD5.Create();
            byte[] inputString = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(inputString);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb.ToString();
        }

        public User checkExist(string email,string username,string phonenumber)
        {
            return myDb.Users.Where(u => u.email == email || u.username == username || u.phonenumber == phonenumber).FirstOrDefault();
        }

        public User checkLogin(string email,string password)
        {
            return myDb.Users.Where(u => u.email == email && u.password == password).FirstOrDefault();
        }

        public void add(User user)
        {
            myDb.Users.Add(user);
            myDb.SaveChanges();
        }

        public User getInformationByEmail(string email)
        {
            return myDb.Users.Where(u => u.email == email).FirstOrDefault();
        }
    }
}