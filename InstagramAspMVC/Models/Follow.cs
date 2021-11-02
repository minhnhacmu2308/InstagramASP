using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InstagramAspMVC.Models
{
    public class Follow
    {
        [Key]
        [Column(Order = 1)]
        public int id_userFollow { get; set; }

        [Key]
        [Column(Order = 2)]
        public int id_userBeFollow { get; set; }


    }
}