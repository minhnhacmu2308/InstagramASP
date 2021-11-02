using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InstagramAspMVC.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_post { get; set; }

        public string content { get; set; }

        public DateTime createdAt { get; set; }

        public int status { get; set; }

        public int id_user { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        public virtual ICollection<Images> images { get; set; }
    }
}