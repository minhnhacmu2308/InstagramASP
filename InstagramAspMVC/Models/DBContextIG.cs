using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InstagramAspMVC.Models
{
    public class DBContextIG : DbContext
    {
        public DBContextIG() : base("IGDBConnectionString")
        {
             
        }
        public DbSet<User> Users {  get; set; }

        public DbSet<Post> Posts { get; set; }


        public DbSet<Like> Likes { get; set; }

        public DbSet<SavePost> Saves { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Follow> Follows { get; set; }

        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}