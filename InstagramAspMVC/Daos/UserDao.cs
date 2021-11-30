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
            return myDb.Users.Where(u => u.email == email && u.password == password && u.status == 1).FirstOrDefault();
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

        public User getInformationById(int id)
        {
            return myDb.Users.Where(u => u.id_user == id).FirstOrDefault();
        }

        public void update(User user)
        {
            var obj = myDb.Users.Where(u => u.email == user.email).FirstOrDefault();
            obj.email = user.email;
            obj.password = user.password;
            obj.username = user.username;
            obj.address = user.address;
            obj.gender = user.gender;
            obj.fullname = user.fullname;
            obj.phonenumber = user.phonenumber;
            obj.status = user.status;
            myDb.SaveChanges();
        }

        public User checkPhonenumberExist(string phonenumber)
        {
            return myDb.Users.Where(u => u.phonenumber == phonenumber).FirstOrDefault();
        }

        public void changeImage(string email, string image)
        {
            var obj = myDb.Users.Where(u => u.email == email).FirstOrDefault();
            obj.image = image;
            myDb.SaveChanges();
        }

       public void changePassword(string email, string passwordNew)
       {
            var obj = myDb.Users.Where(u => u.email == email).FirstOrDefault();
            obj.password = passwordNew;
            myDb.SaveChanges();
       }

       public List<User> getUserUnfollow(int id,int number)
       {    
          
            var listFollow = myDb.Follows.Where(x => x.id_userFollow == id).ToList();
            var list =  myDb.Users.Where(x => x.id_user != id).Take(number).ToList();
            foreach(var user in listFollow)
            {

                list = list.Where(x => x.id_user != user.id_userBeFollow).ToList();
            }
            return list;
       }
       
        public List<User> search(string key)
        {
            return myDb.Users.Where(c => c.username.Contains(key) || c.fullname.Contains(key) || c.email.Contains(key)).ToList();
        }
    }
}