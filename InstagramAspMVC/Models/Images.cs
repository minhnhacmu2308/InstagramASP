using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagramAspMVC.Models
{
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Images { get; set; }

        [StringLength(255)]
        [Required]
        public string image { get; set; }

        public int id_Post { get; set; }

        public virtual Post Post { get; set; }
    }
}